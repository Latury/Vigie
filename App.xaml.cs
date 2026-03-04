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
 * - Centraliser l’injection
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

        #region 3.3 Méthodes

        protected override void OnLaunched(
            Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            // 1️⃣ Journalisation
            var journal = new JournalService();

            // 2️⃣ Gestionnaires de scan
            var gestionnaires = new List<IGestionnairePaquets>
            {
                new GestionnaireWinget(),
                new GestionnaireScoop()
            };

            var normaliseur = new NormaliseurWinget();

            var gestionnaireGlobal = new GestionnaireGlobal(
                gestionnaires,
                normaliseur,
                journal);

            // 3️⃣ Service mise à jour simulé
            IServiceMiseAJour serviceSimule =
                new ServiceMiseAJourSimule();

            // 4️⃣ Point de restauration simulé
            IPointRestaurationService pointRestauration =
                new PointRestaurationSimule();

            var serviceMiseAJourGlobal =
                new ServiceMiseAJourGlobal(
                    serviceSimule,
                    journal,
                    pointRestauration);

            // 5️⃣ Création fenêtre
            var fenetre = new FenetrePrincipale();
            fenetre.Activate();

            // 6️⃣ Service de confirmation (Window-based)
            var confirmationService =
                new ConfirmationService(fenetre);

            // 7️⃣ Création ViewModel
            var accueilVM = new AccueilVueModele(
                gestionnaireGlobal,
                serviceMiseAJourGlobal,
                confirmationService);

            // 8️⃣ Injection ViewModel
            fenetre.DefinirViewModel(accueilVM);

            _window = fenetre;
        }

        #endregion
    }

    #endregion
}
