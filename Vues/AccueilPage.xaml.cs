/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Vues                                                       ║
║  Fichier : AccueilPage.xaml.cs                                       ║
║                                                                      ║
║  Rôle :                                                              ║
║  Code-behind minimal de la page Accueil.                             ║
║                                                                      ║
║  Responsabilités :                                                   ║
║  - Initialiser la page                                               ║
║  - Recevoir le ViewModel via navigation                              ║
║                                                                      ║
║  Limites :                                                           ║
║  - Aucune logique métier                                             ║
║  - Binding uniquement via ViewModel                                  ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

using Vigie.VueModeles;

#endregion

namespace Vigie.Vues
{
    #region 2. Description Générale

    /*
     * Classe : AccueilPage
     *
     * Rôle :
     * Page d’accueil affichant l’état du système.
     *
     * Particularité :
     * Le ViewModel est injecté via NavigationService.
     */

    #endregion

    #region 3. Déclaration

    public sealed partial class AccueilPage : Page
    {
        #region 3.1 Constructeur

        /*
         * Initialise la page.
         * Aucune création de ViewModel ici.
         */
        public AccueilPage()
        {
            InitializeComponent();
        }

        #endregion

        #region 3.2 Navigation

        /*
         * Méthode : OnNavigatedTo
         *
         * Objectif :
         * Récupérer le ViewModel transmis via navigation
         * et l’associer au DataContext.
         */
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is AccueilVueModele vm)
            {
                DataContext = vm;
            }

            base.OnNavigatedTo(e);
        }

        #endregion
    }

    #endregion
}
