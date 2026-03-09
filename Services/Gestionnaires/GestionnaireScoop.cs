/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services                                                   ║
║  Fichier : GestionnaireScoop.cs                                      ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémente le gestionnaire Scoop (simulation actuelle).             ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Simuler la détection de mises à jour Scoop                        ║
║  - Simuler les mises à jour                                          ║
║  - Journaliser les opérations                                        ║
║                                                                      ║
║  Limites :                                                           ║
║  - Simulation uniquement (phase de développement)                    ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Vigie.Modeles;
using Vigie.Services.Interfaces;

#endregion

namespace Vigie.Services.Gestionnaires
{
    #region 2. Déclaration

    public class GestionnaireScoop : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly IJournalService _journal;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireScoop(IJournalService journal)
        {
            _journal =
                journal ?? throw new ArgumentNullException(nameof(journal));
        }

        #endregion

        #region 3.3 Méthodes publiques

        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            _journal.Info("[SIMULATION] Scan Scoop.");

            await Task.Delay(500);

            return new List<LogicielMiseAJour>();
        }

        /*
         * Méthode : MettreAJourAsync
         *
         * Objectif :
         * Simuler une mise à jour Scoop.
         */

        public async Task<bool> MettreAJourAsync(LogicielMiseAJour logiciel)
        {
            try
            {
                _journal.Info($"[SIMULATION] Mise à jour scoop : {logiciel.Nom}");

                logiciel.StatutMiseAJour = StatutMiseAJour.EnCours;

                await Task.Delay(1200);

                logiciel.StatutMiseAJour = StatutMiseAJour.Succes;

                _journal.Info($"[SIMULATION] Mise à jour scoop terminée : {logiciel.Nom}");

                return true;
            }
            catch (Exception ex)
            {
                logiciel.StatutMiseAJour = StatutMiseAJour.Echec;

                _journal.Erreur($"Erreur simulation scoop : {ex.Message}");

                return false;
            }
        }

        #endregion
    }

    #endregion
}
