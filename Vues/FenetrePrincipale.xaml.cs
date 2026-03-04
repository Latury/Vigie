/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Vues                                                       ║
║  Fichier : FenetrePrincipale.xaml.cs                                 ║
║                                                                      ║
║  Rôle :                                                              ║
║  Gère la navigation principale de l’application.                     ║
║                                                                      ║
║  Responsabilités :                                                   ║
║  - Initialiser le service de navigation                              ║
║  - Charger la page d’accueil                                         ║
║  - Gérer les clics de navigation                                     ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;

using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using Vigie.Infrastructure;
using Vigie.VueModeles;
using Vigie.Vues;

using WinRT.Interop;

#endregion

#region 2. Description Générale

/*
 * Classe : FenetrePrincipale
 *
 * Rôle :
 * Fenêtre principale servant de conteneur de navigation.
 *
 * Objectif architectural :
 * Déléguer la navigation à NavigationService
 * et recevoir le ViewModel via injection tardive.
 */

#endregion

namespace Vigie
{
    #region 3. Déclaration

    public sealed partial class FenetrePrincipale : Window
    {
        #region 3.1 Champs privés

        private readonly NavigationService _navigationService;

        private AccueilVueModele? _accueilVM;

        #endregion

        #region 3.2 Constructeur

        public FenetrePrincipale()
        {
            InitializeComponent();

            _navigationService = new NavigationService(RootFrame);

            this.Activated += FenetrePrincipale_Activated;
        }

        #endregion

        #region 3.3 Injection ViewModel

        public void DefinirViewModel(AccueilVueModele accueilVM)
        {
            _accueilVM = accueilVM
                ?? throw new ArgumentNullException(nameof(accueilVM));

            _navigationService.Navigate(typeof(AccueilPage), _accueilVM);
        }

        #endregion

        #region 3.4 Accès XamlRoot

        public XamlRoot ObtenirXamlRoot()
        {
            return this.Content.XamlRoot;
        }

        #endregion

        #region 3.5 Navigation

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            if (_accueilVM != null)
            {
                _navigationService.Navigate(
                    typeof(AccueilPage),
                    _accueilVM);
            }
        }

        private void Historique_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(typeof(HistoriquePage));
        }

        private void Parametres_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(typeof(ParametresPage));
        }

        private void APropos_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(typeof(AProposPage));
        }

        private void FenetrePrincipale_Activated(
            object sender,
            WindowActivatedEventArgs args)
        {
            this.Activated -= FenetrePrincipale_Activated;

            var hWnd = WindowNative.GetWindowHandle(this);
            var windowId =
                Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow =
                AppWindow.GetFromWindowId(windowId);

            string cheminIcone = System.IO.Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                "Vigie.ico");

            appWindow.SetIcon(cheminIcone);
        }

        #endregion
    }

    #endregion
}
