/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Application                                                ║
║  Fichier : App.xaml.cs                                               ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit le point d’entrée logique de l’application.                 ║
║  Gère le cycle de vie initial et l’ouverture de la fenêtre.          ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using Microsoft.UI.Xaml;
using Windows.ApplicationModel.Activation;

#endregion

namespace Vigie
{
    #region 2. Description Générale

    /*
     * Classe : App
     *
     * Rôle :
     * Représente l’application dans son ensemble.
     *
     * Responsabilités :
     * - Initialiser les composants globaux
     * - Gérer le lancement
     * - Créer et afficher la fenêtre principale
     *
     * Limites :
     * - Ne contient aucune logique métier
     * - Ne contient aucune logique d’interface spécifique
     */

    #endregion

    #region 3. Déclaration

    public partial class App : Application
    {
        #region 3.1 Propriétés

        // Référence vers la fenêtre principale
        private Window? _window;

        #endregion

        #region 3.2 Constructeur

        /*
         * Initialise l’application.
         * Appelle InitializeComponent() pour charger App.xaml.
         */
        public App()
        {
            InitializeComponent();
        }

        #endregion

        #region 3.3 Méthodes Publiques

        /*
         * Méthode : OnLaunched
         *
         * Objectif :
         * Appelée automatiquement lorsque l’application démarre.
         *
         * Effet :
         * - Instancie MainWindow
         * - Active la fenêtre
         */
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            _window = new MainWindow();
            _window.Activate();
        }

        #endregion
    }

    #endregion
}