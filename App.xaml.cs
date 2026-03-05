/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Application                                                ║
║  Fichier : App.xaml.cs                                               ║
║                                                                      ║
║  Rôle :                                                              ║
║  Point d’entrée logique de l’application.                            ║
║  Centralise la composition des dépendances.                          ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Initialiser l’application                                         ║
║  - Créer les services principaux                                     ║
║  - Injecter les dépendances                                          ║
║  - Créer la fenêtre principale                                       ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using Microsoft.UI.Xaml;

using System.Collections.Generic;

using Vigie.JournalEvenements;
using Vigie.Services.Gestionnaires;
using Vigie.Services.Interfaces;
using Vigie.Services.MisesAJour;
using Vigie.Services.Normalisation;
using Vigie.Services.Securite;
using Vigie.Services.UI;
using Vigie.VueModeles;

#endregion

#region 2. Description Générale

/*
 * Classe : App
 *
 * Rôle :
 * Initialise l’application et compose les dépendances.
 *
 * Objectif architectural :
 * - Centraliser l’injection de dépendances
 * - Éviter toute dépendance UI dans les services métier
 */

#endregion

namespace Vigie
{
    #region 3. Déclaration

    public partial class App : Application
    {
        #region 3.1 Champs privés

        private Window? _window;

        #endregion

        #region 3.2 Constructeur

        public App()
        {
            InitializeComponent();
        }

        #endregion

        #region 3.3 Méthodes publiques

        protected override void OnLaunched(
            Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            #region 1️⃣ Initialisation journal

            IJournalService journal =
                new JournalService();

            #endregion


            #region 2️⃣ Gestionnaires de scan

            var gestionnaires = new List<IGestionnairePaquets>
            {
                new GestionnaireWinget(journal),
                new GestionnaireScoop(journal)
            };

            var normaliseur =
                new NormaliseurWinget();

            var gestionnaireGlobal =
                new GestionnaireGlobal(
                    gestionnaires,
                    normaliseur,
                    journal);

            #endregion


            #region 3️⃣ Services de mise à jour

            IServiceMiseAJour serviceSimule =
                new ServiceMiseAJourSimule();

            IPointRestaurationService pointRestauration =
                new PointRestaurationSimule();

            var serviceMiseAJourGlobal =
                new ServiceMiseAJourGlobal(
                    serviceSimule,
                    journal,
                    pointRestauration);

            #endregion


            #region 4️⃣ Création fenêtre principale

            var fenetre =
                new FenetrePrincipale();

            fenetre.Activate();

            #endregion


            #region 5️⃣ Service de confirmation UI

            var confirmationService =
                new ConfirmationService(fenetre);

            #endregion


            #region 6️⃣ Création ViewModel

            var accueilVM =
                new AccueilVueModele(
                    gestionnaireGlobal,
                    serviceMiseAJourGlobal,
                    confirmationService);

            #endregion


            #region 7️⃣ Injection ViewModel

            fenetre.DefinirViewModel(accueilVM);

            _window = fenetre;

            #endregion
        }

        #endregion
    }

    #endregion
}
