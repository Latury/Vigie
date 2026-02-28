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
║  - Charger la page d’accueil au démarrage                            ║
║  - Gérer les clics de navigation via NavigationService               ║
║                                                                      ║
║  Limites :                                                           ║
║  - Navigation simple (pas encore de gestion historique)              ║
║  - Pas encore de gestion de paramètres de navigation                 ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Vigie.Infrastructure;
using Vigie.Vues;
using WinRT.Interop;

#endregion

namespace Vigie
{
    #region 2. Description Générale

    /*
     * Classe : FenetrePrincipale
     *
     * Rôle :
     * Fenêtre principale servant de conteneur de navigation.
     *
     * Objectif architectural :
     * Déléguer la navigation à NavigationService.
     */

    #endregion

    #region 3. Déclaration

    public sealed partial class FenetrePrincipale : Window
    {
        #region 3.1 Champs privés

        private readonly NavigationService _navigationService;

        #endregion

        #region 3.2 Constructeur

        public FenetrePrincipale()
        {
            InitializeComponent();

            // Initialisation du service de navigation
            _navigationService = new NavigationService(RootFrame);
            _navigationService.Navigate(typeof(AccueilPage));

            // Forcer l’icône après activation complète
            this.Activated += FenetrePrincipale_Activated;
        }

        private void FenetrePrincipale_Activated(object sender, WindowActivatedEventArgs args)
        {
            this.Activated -= FenetrePrincipale_Activated;

            var hWnd = WindowNative.GetWindowHandle(this);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            string cheminIcone = System.IO.Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                "Vigie.ico");

            appWindow.SetIcon(cheminIcone);
        }

        #endregion

        #region 3.3 Navigation

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(typeof(AccueilPage));
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

        #endregion
    }

    #endregion
}