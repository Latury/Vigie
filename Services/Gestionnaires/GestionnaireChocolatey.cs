/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services                                                   ║
║  Fichier : GestionnaireChocolatey.cs                                 ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémente le gestionnaire Chocolatey (simulation actuelle).        ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Simuler les mises à jour Chocolatey                               ║
║  - Préparer l'intégration future                                     ║
║                                                                      ║
║  Limites :                                                           ║
║  - Simulation uniquement                                             ║
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

    public class GestionnaireChocolatey : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly IJournalService _journal;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireChocolatey(IJournalService journal)
        {
            _journal =
                journal ?? throw new ArgumentNullException(nameof(journal));
        }

        #endregion

        #region 3.3 Méthodes publiques

        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            _journal.Info("[SIMULATION] Scan Chocolatey.");

            await Task.Delay(500);

            return new List<LogicielMiseAJour>();
        }

        public async Task<bool> MettreAJourAsync(LogicielMiseAJour logiciel)
        {
            try
            {
                _journal.Info($"[SIMULATION] Mise à jour chocolatey : {logiciel.Nom}");

                logiciel.StatutMiseAJour = StatutMiseAJour.EnCours;

                await Task.Delay(1300);

                logiciel.StatutMiseAJour = StatutMiseAJour.Succes;

                _journal.Info($"[SIMULATION] Mise à jour chocolatey terminée : {logiciel.Nom}");

                return true;
            }
            catch (Exception ex)
            {
                logiciel.StatutMiseAJour = StatutMiseAJour.Echec;

                _journal.Erreur($"Erreur simulation chocolatey : {ex.Message}");

                return false;
            }
        }

        #endregion
    }

    #endregion
}
