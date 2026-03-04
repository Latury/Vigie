/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.UI                                                ║
║  Fichier : ConfirmationService.cs                                    ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémentation WinUI du service de confirmation utilisateur.        ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Afficher un ContentDialog                                         ║
║  - Retourner la décision utilisateur                                 ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Threading.Tasks;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using Vigie.Services.Interfaces;

#endregion

#region 2. Description Générale

/*
 * Classe : ConfirmationService
 *
 * Rôle :
 * Implémente IConfirmationService en utilisant
 * un ContentDialog WinUI.
 *
 * Objectif architectural :
 * - Isoler toute dépendance UI hors du ViewModel
 * - Respecter le pattern MVVM
 *
 * Particularité :
 * - Récupère dynamiquement le XamlRoot
 */

#endregion

namespace Vigie.Services.UI
{
    #region 3. Déclaration

    public class ConfirmationService : IConfirmationService
    {
        #region 3.1 Champs privés

        private readonly Window _window;

        #endregion

        #region 3.2 Constructeur

        public ConfirmationService(Window window)
        {
            _window = window
                ?? throw new ArgumentNullException(nameof(window));
        }

        #endregion

        #region 3.3 Méthodes publiques

        public async Task<bool> DemanderConfirmationAsync(
            string titre,
            string message)
        {
            var xamlRoot = _window.Content?.XamlRoot;

            if (xamlRoot == null)
            {
                return false;
            }

            var dialog = new ContentDialog
            {
                Title = titre,
                Content = message,
                PrimaryButtonText = "Confirmer",
                CloseButtonText = "Annuler",
                XamlRoot = xamlRoot
            };

            var result = await dialog.ShowAsync();

            return result == ContentDialogResult.Primary;
        }

        #endregion
    }

    #endregion
}
