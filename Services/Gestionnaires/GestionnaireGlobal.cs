/*
╔═════════════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                              ║
║        Centre de maintenance logicielle intelligent                         ║
║                                                                             ║
║  Module : Services                                                          ║
║  Fichier : GestionnaireGlobal.cs                                            ║
║                                                                             ║
║  Rôle :                                                                     ║
║  Orchestrateur central des gestionnaires de paquets.                        ║
║                                                                             ║
║  Responsabilités principales :                                              ║
║  - Agréger plusieurs sources de mises à jour                                ║
║  - Appliquer la normalisation                                               ║
║  - Fusionner les résultats                                                  ║
║  - Garantir la résilience globale                                           ║
║  - Journaliser l’agrégation                                                 ║
║                                                                             ║
║  Décision architecturale importante :                                       ║
║  Aucune exception ne doit remonter vers l’UI.                               ║
║  Toute erreur interne est capturée, journalisée et neutralisée.             ║
║                                                                             ║
║  Licence : MIT                                                              ║
║  Copyright © 2026 Flo Latury                                                ║
╚═════════════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Vigie.Modeles;
using Vigie.Services.Interfaces;
using Vigie.Services.Normalisation;

#endregion

namespace Vigie.Services.Gestionnaires
{
    public class GestionnaireGlobal : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly IEnumerable<IGestionnairePaquets> _gestionnaires;
        private readonly IJournalService _journal;
        private readonly INormaliseur _normaliseur;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireGlobal(
            IEnumerable<IGestionnairePaquets> gestionnaires,
            INormaliseur normaliseur,
            IJournalService journal)
        {
            _gestionnaires = gestionnaires ?? throw new ArgumentNullException(nameof(gestionnaires));
            _normaliseur = normaliseur ?? throw new ArgumentNullException(nameof(normaliseur));
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }

        #endregion

        #region 3.3 Méthodes publiques

        /*
         * Méthode : ScanAsync
         *
         * Objectif :
         * Orchestrer l’agrégation multi-gestionnaires.
         *
         * Résilience :
         * - Chaque gestionnaire est isolé
         * - La normalisation est protégée
         * - La fusion est protégée
         * - Aucune exception ne remonte à l’UI
         */
        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            try
            {
                var tousLesResultats = new List<LogicielMiseAJour>();

                _journal.Info("Agrégation des gestionnaires de paquets.");

                foreach (var gestionnaire in _gestionnaires)
                {
                    try
                    {
                        var resultats = await gestionnaire.ScanAsync();

                        if (resultats != null && resultats.Count > 0)
                        {
                            foreach (var logiciel in resultats)
                            {
                                try
                                {
                                    var normalise = _normaliseur.Normaliser(logiciel);
                                    tousLesResultats.Add(normalise);
                                }
                                catch (Exception exNormalisation)
                                {
                                    _journal.Erreur(
                                        $"Erreur normalisation ({gestionnaire.GetType().Name}) : {exNormalisation.Message}");
                                }
                            }

                            _journal.Info(
                                $"{resultats.Count} mise(s) ajoutée(s) depuis {gestionnaire.GetType().Name}.");
                        }
                        else
                        {
                            _journal.Info(
                                $"Aucune mise à jour retournée par {gestionnaire.GetType().Name}.");
                        }
                    }
                    catch (Exception exGestionnaire)
                    {
                        _journal.Erreur(
                            $"Erreur dans {gestionnaire.GetType().Name} : {exGestionnaire.Message}");
                    }
                }

                var resultatsDedup = tousLesResultats
                    .Where(l => l != null && !string.IsNullOrWhiteSpace(l.IdentifiantNormalise))
                    .GroupBy(l => l.IdentifiantNormalise)
                    .Select(g =>
                    {
                        var groupe = g.ToList();

                        var winget = groupe.FirstOrDefault(x => x.Source == "winget");

                        if (winget != null)
                        {
                            bool memeVersionExiste =
                                groupe.Any(x =>
                                    x.Source != "winget" &&
                                    x.NouvelleVersion == winget.NouvelleVersion);

                            if (memeVersionExiste)
                            {
                                return winget;
                            }
                        }

                        return groupe
                            .OrderByDescending(x => ParseVersionSafe(x.NouvelleVersion))
                            .First();
                    })
                    .ToList();

                _journal.Info(
                    $"Total agrégé après déduplication : {resultatsDedup.Count}.");

                return resultatsDedup;
            }
            catch (Exception exGlobal)
            {
                _journal.Erreur(
                    $"Erreur critique orchestrateur : {exGlobal.Message}");

                return new List<LogicielMiseAJour>();
            }
        }

        #endregion

        #region 3.4 Méthodes privées

        /*
         * Méthode : ParseVersionSafe
         *
         * Objectif :
         * Convertir une version string en System.Version
         * pour comparaison fiable.
         *
         * Sécurité :
         * Retourne Version(0,0) si parsing impossible.
         */
        private Version ParseVersionSafe(string versionString)
        {
            if (string.IsNullOrWhiteSpace(versionString))
            {
                return new Version(0, 0);
            }

            var propre = versionString.Split('-')[0];

            if (Version.TryParse(propre, out var version))
            {
                return version;
            }

            return new Version(0, 0);
        }

        #endregion
    }
}
