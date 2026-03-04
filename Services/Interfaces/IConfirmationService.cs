/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Interfaces                                        ║
║  Fichier : IConfirmationService.cs                                   ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit le contrat permettant de demander                           ║
║  une confirmation utilisateur avant action critique.                 ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Afficher une confirmation utilisateur                             ║
║  - Retourner la décision (Oui / Non)                                 ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Threading.Tasks;

#endregion

#region 2. Description Générale

/*
 * Interface : IConfirmationService
 *
 * Rôle :
 * Définit le contrat permettant d’afficher une
 * confirmation utilisateur dans l’interface.
 *
 * Objectif architectural :
 * - Isoler la logique UI du ViewModel
 * - Respecter le principe MVVM
 * - Permettre une implémentation spécifique à WinUI
 *
 * Limites :
 * - Ne contient aucune logique métier
 */

#endregion

namespace Vigie.Services.Interfaces
{
    #region 3. Déclaration

    public interface IConfirmationService
    {
        #region 3.1 Méthodes publiques

        Task<bool> DemanderConfirmationAsync(
            string titre,
            string message);

        #endregion
    }

    #endregion
}
