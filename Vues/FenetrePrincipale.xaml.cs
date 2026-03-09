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
║  - Configurer les propriétés système de la fenêtre                   ║
║  - Empêcher la réduction sous la taille minimale                     ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Runtime.InteropServices;

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
 * Fenêtre principale servant de conteneur de navigation.
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

        private const int LargeurMinimale = 1400;

        private const int HauteurMinimale = 820;

        private const int WM_GETMINMAXINFO = 0x24;

        private SubclassProcDelegate? _subclassDelegate;

        #endregion


        #region 3.2 Constructeur

        public FenetrePrincipale()
        {
            InitializeComponent();

            _navigationService = new NavigationService(RootFrame);

            ConfigurerFenetre();

            InitialiserRestrictionTaille();

            this.Activated += FenetrePrincipale_Activated;
        }

        #endregion


        #region 3.3 Configuration fenêtre

        private void ConfigurerFenetre()
        {
            var appWindow = ObtenirAppWindow();

            appWindow.Resize(
                new Windows.Graphics.SizeInt32(1400, 900));
        }

        #endregion


        #region 3.4 Restriction taille minimale

        private void InitialiserRestrictionTaille()
        {
            var hwnd = WindowNative.GetWindowHandle(this);

            _subclassDelegate = SubclassProc;

            SetWindowSubclass(
                hwnd,
                _subclassDelegate,
                IntPtr.Zero,
                IntPtr.Zero);
        }

        private IntPtr SubclassProc(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam,
            IntPtr uIdSubclass,
            IntPtr dwRefData)
        {
            if (msg == WM_GETMINMAXINFO)
            {
                MINMAXINFO mmi =
                    Marshal.PtrToStructure<MINMAXINFO>(lParam);

                mmi.ptMinTrackSize.x = LargeurMinimale;
                mmi.ptMinTrackSize.y = HauteurMinimale;

                Marshal.StructureToPtr(mmi, lParam, true);
            }

            return DefSubclassProc(hWnd, msg, wParam, lParam);
        }

        #endregion


        #region 3.5 Injection ViewModel

        public void DefinirViewModel(AccueilVueModele accueilVM)
        {
            _accueilVM = accueilVM
                ?? throw new ArgumentNullException(nameof(accueilVM));

            _navigationService.Navigate(typeof(AccueilPage), _accueilVM);
        }

        #endregion


        #region 3.6 Accès XamlRoot

        public XamlRoot ObtenirXamlRoot()
        {
            return this.Content.XamlRoot;
        }

        #endregion


        #region 3.7 Navigation

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            if (_accueilVM != null)
            {
                _navigationService.Navigate(typeof(AccueilPage), _accueilVM);
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

        private async void BoutonQuitter_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Quitter l'application",
                Content = "Vous allez quitter l'application. Voulez-vous continuer ?",
                PrimaryButtonText = "Oui",
                CloseButtonText = "Non",
                XamlRoot = this.Content.XamlRoot
            };

            var resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {
                Application.Current.Exit();
            }
        }

        #endregion


        #region 3.8 Activation fenêtre

        private void FenetrePrincipale_Activated(
            object sender,
            WindowActivatedEventArgs args)
        {
            this.Activated -= FenetrePrincipale_Activated;

            var appWindow = ObtenirAppWindow();

            string cheminIcone = System.IO.Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                "Vigie.ico");

            appWindow.SetIcon(cheminIcone);
        }

        #endregion


        #region 3.9 Utilitaires internes

        private AppWindow ObtenirAppWindow()
        {
            var hWnd = WindowNative.GetWindowHandle(this);

            var windowId =
                Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);

            return AppWindow.GetFromWindowId(windowId);
        }

        #endregion


        #region 3.10 Structures Win32

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        #endregion


        #region 3.11 Imports Win32

        [DllImport("comctl32.dll")]
        private static extern bool SetWindowSubclass(
            IntPtr hWnd,
            SubclassProcDelegate pfnSubclass,
            IntPtr uIdSubclass,
            IntPtr dwRefData);

        [DllImport("comctl32.dll")]
        private static extern IntPtr DefSubclassProc(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam);

        private delegate IntPtr SubclassProcDelegate(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam,
            IntPtr uIdSubclass,
            IntPtr dwRefData);

        #endregion
    }

    #endregion
}
