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
║  Licence : MIT                                                              ║
║  Copyright © 2026 Flo Latury                                                ║
╚═════════════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigie.JournalEvenements;
using Vigie.Modeles;
using Vigie.Services.Interfaces;
using Vigie.Services.Normalisation;
using System.Globalization;

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

        /*
         * Constructeur :
         * Reçoit les dépendances externes.
         *
         * Objectif :
         * - Supprimer tout couplage direct
         * - Permettre testabilité
         * - Préparer injection DI future
         */
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

        public async Task<List<LogicielMiseAJour>> ScanAsync()
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
                            var normalise = _normaliseur.Normaliser(logiciel);
                            tousLesResultats.Add(normalise);
                        }

                        _journal.Info($"{resultats.Count} mise(s) ajoutée(s) depuis {gestionnaire.GetType().Name}.");
                    }
                    else
                    {
                        _journal.Info($"Aucune mise à jour retournée par {gestionnaire.GetType().Name}.");
                    }
                }
                catch (Exception ex)
                {
                    _journal.Erreur($"Erreur dans {gestionnaire.GetType().Name} : {ex.Message}");
                }
            }

            var resultatsDedup = tousLesResultats
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

            _journal.Info($"Total agrégé après déduplication : {resultatsDedup.Count}.");

            return resultatsDedup;
        }

        #region 3.4 Méthodes privées

        /*
         * Méthode : ParseVersionSafe
         *
         * Objectif :
         * Convertir une version string en System.Version
         * pour comparaison fiable.
         *
         * Comportement :
         * - Si parsing réussi → retourne Version valide
         * - Si parsing échoue → retourne Version(0,0)
         *
         * Pourquoi :
         * Éviter comparaison lexicographique incorrecte.
         */
        private Version ParseVersionSafe(string versionString)
        {
            if (string.IsNullOrWhiteSpace(versionString))
            {
                return new Version(0, 0);
            }

            // Nettoyage éventuel (ex: "1.2.3-preview")
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
#endregion
