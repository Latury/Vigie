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

#region 2. Description Générale

/*
 * Interface : IGestionnairePaquets
 *
 * Rôle :
 * Définit le contrat commun pour tous les gestionnaires
 * de paquets supportés par Vigie (winget, scoop, etc.).
 *
 * Objectif architectural :
 * Permettre l’abstraction complète de la logique
 * de scan et de mise à jour.
 *
 * Limites :
 * - Aucune implémentation
 * - Aucune logique système
 */

#endregion

#region 3. Déclaration

namespace Vigie.Services.Interfaces
{
    public interface IGestionnairePaquets
    {
        #region 3.1 Méthodes Publiques

        /*
         * Méthode : ScanAsync
         *
         * Objectif :
         * Scanner le système et retourner la liste
         * des logiciels nécessitant une mise à jour.
         *
         * Retour :
         * Liste de LogicielMiseAJour.
         */
        Task<List<LogicielMiseAJour>> ScanAsync();

        #endregion
    }
}

#endregion