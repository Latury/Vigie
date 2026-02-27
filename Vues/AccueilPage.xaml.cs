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
║  - Associer le ViewModel                                             ║
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
     */

    #endregion

    #region 3. Déclaration

    public sealed partial class AccueilPage : Page
    {
        #region 3.1 Constructeur

        /*
         * Initialise la page et associe le ViewModel.
         */
        public AccueilPage()
        {
            InitializeComponent();

            DataContext = new AccueilVueModele();
        }

        #endregion
    }

    #endregion
}