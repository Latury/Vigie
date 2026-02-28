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

#endregion

namespace Vigie.Services.Gestionnaires
{
    public class GestionnaireGlobal : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly List<IGestionnairePaquets> _gestionnaires;
        private readonly IJournalService _journal;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireGlobal()
        {
            _journal = new JournalService();

            _gestionnaires = new List<IGestionnairePaquets>
            {
                new PackageManagers.GestionnaireWinget()
            };
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

                    if (resultats != null && resultats.Any())
                    {
                        tousLesResultats.AddRange(resultats);
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
    .GroupBy(l =>
        string.IsNullOrWhiteSpace(l.IdentifiantNormalise)
            ? l.Nom
            : l.IdentifiantNormalise)
    .Select(g => g.First())
    .ToList();

            _journal.Info($"Total agrégé après déduplication : {resultatsDedup.Count}.");

            return resultatsDedup;
        }

        #endregion
    }
}