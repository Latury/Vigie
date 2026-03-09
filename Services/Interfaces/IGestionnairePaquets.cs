/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services                                                   ║
║  Fichier : IGestionnairePaquets.cs                                   ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit le contrat d’un gestionnaire de paquets utilisé             ║
║  pour scanner et mettre à jour les logiciels du système.             ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Définir les méthodes de scan                                      ║
║  - Définir les méthodes de mise à jour                               ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - LogicielMiseAJour                                                 ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Collections.Generic;
using System.Threading.Tasks;

using Vigie.Modeles;

#endregion

namespace Vigie.Services.Interfaces
{
    public interface IGestionnairePaquets
    {
        #region 3.1 Méthodes publiques

        Task<List<LogicielMiseAJour>> ScanAsync();

        /*
         * Méthode : MettreAJourAsync
         *
         * Objectif :
         * Lancer la mise à jour d’un logiciel.
         *
         * Dans la phase actuelle (0.3.0-dev)
         * cette méthode peut être simulée.
         */

        Task<bool> MettreAJourAsync(LogicielMiseAJour logiciel);

        #endregion
    }
}
