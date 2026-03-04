/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Infrastructure                                             ║
║  Fichier : NavigationService.cs                                      ║
║                                                                      ║
║  Rôle :                                                              ║
║  Centralise la navigation entre les pages.                           ║
║                                                                      ║
║  Responsabilités :                                                   ║
║  - Exposer une méthode Navigate                                      ║
║  - Encapsuler l’utilisation du Frame                                 ║
║  - Permettre la transmission de paramètres de navigation             ║
║                                                                      ║
║  Limites :                                                           ║
║  - Pas encore de gestion historique                                  ║
║  - Pas encore de gestion paramètres complexes                        ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using Microsoft.UI.Xaml.Controls;

using System;

#endregion

namespace Vigie.Infrastructure
{
    #region 2. Description Générale

    /*
     * Classe : NavigationService
     *
     * Rôle :
     * Encapsule la navigation entre les pages.
     *
     * Objectif architectural :
     * Éviter que FenetrePrincipale manipule directement le Frame.
     */

    #endregion

    #region 3. Déclaration

    public class NavigationService
    {
        #region 3.1 Champs privés

        private readonly Frame _frame;

        #endregion

        #region 3.2 Constructeur

        public NavigationService(Frame frame)
        {
            _frame = frame
                ?? throw new ArgumentNullException(nameof(frame));
        }

        #endregion

        #region 3.3 Méthodes publiques

        /*
         * Méthode : Navigate
         *
         * Objectif :
         * Naviguer vers une page sans paramètre.
         */
        public void Navigate(Type pageType)
        {
            _frame.Navigate(pageType);
        }

        /*
         * Méthode : Navigate (surcharge)
         *
         * Objectif :
         * Naviguer vers une page avec paramètre.
         *
         * Utilisation :
         * Permet l’injection d’un ViewModel
         * via le système de navigation.
         */
        public void Navigate(Type pageType, object parameter)
        {
            _frame.Navigate(pageType, parameter);
        }

        #endregion
    }

    #endregion
}
