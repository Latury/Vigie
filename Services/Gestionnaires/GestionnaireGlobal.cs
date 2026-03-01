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
║  Limites :                                                                  ║
║  - Déduplication basée sur IdentifiantNormalise (fallback sur Nom si vide)  ║
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

#endregion

namespace Vigie.Services.Gestionnaires
{
    public class GestionnaireGlobal : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly List<IGestionnairePaquets> _gestionnaires;
        private readonly IJournalService _journal;
        private readonly INormaliseur _normaliseur;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireGlobal()
        {
            _journal = new JournalService();
            _normaliseur = new NormaliseurWinget();

            _gestionnaires = new List<IGestionnairePaquets>
            {
                new GestionnaireWinget(),
                new GestionnaireScoop()
            };
        }

        #endregion

        #region 3.3 Méthodes publiques

        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            List<LogicielMiseAJour> tousLesResultats = new List<LogicielMiseAJour>();

            _journal.Info("Agrégation des gestionnaires de paquets.");

            foreach (IGestionnairePaquets gestionnaire in _gestionnaires)
            {
                try
                {
                    List<LogicielMiseAJour> resultats = await gestionnaire.ScanAsync();

                    if (resultats != null && resultats.Count > 0)
                    {
                        foreach (LogicielMiseAJour logiciel in resultats)
                        {
                            LogicielMiseAJour normalise = _normaliseur.Normaliser(logiciel);

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

            List<LogicielMiseAJour> resultatsDedup =
    tousLesResultats
        .GroupBy(l =>
            string.IsNullOrWhiteSpace(l.IdentifiantNormalise)
                ? l.Nom
                : l.IdentifiantNormalise)
        .Select(g =>
        {
            List<LogicielMiseAJour> groupe = g.ToList();

            LogicielMiseAJour? winget =
                groupe.FirstOrDefault(l => l.Source == "winget");

            if (winget != null)
            {
                bool memeVersionExiste =
                    groupe.Any(l =>
                        l.Source != "winget" &&
                        l.NouvelleVersion == winget.NouvelleVersion);

                if (memeVersionExiste)
                {
                    return winget;
                }
            }

            LogicielMiseAJour plusRecente =
                groupe
                    .OrderByDescending(l => l.NouvelleVersion)
                    .First();

            return plusRecente;
        })
        .ToList();

_journal.Info($"Total agrégé après déduplication : {resultatsDedup.Count}.");

return resultatsDedup;

            #endregion
        }
    }
}
