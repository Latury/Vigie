/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : JournalEvenements                                          ║
║  Fichier : JournalService.cs                                         ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémentation du service de journalisation système.                ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Écrire les événements dans le stockage local MSIX                 ║
║  - Centraliser la logique de journalisation                          ║
║                                                                      ║
║  Limites :                                                           ║
║  - Journalisation synchrone                                          ║
║  - Pas encore de rotation de logs                                    ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.IO;
using Windows.Storage;
using Vigie.Services.Interfaces;

#endregion

namespace Vigie.JournalEvenements
{
    public class JournalService : IJournalService
    {
        #region 3.1 Champs privés

        private readonly string _cheminFichier;

        #endregion

        #region 3.2 Constructeur

        /// <summary>
        /// Initialise le service de journalisation.
        /// Utilise le dossier LocalState de l'application MSIX.
        /// </summary>
        public JournalService()
        {
            var dossier = ApplicationData.Current.LocalFolder.Path;

            _cheminFichier = Path.Combine(dossier, "vigie.log");
        }

        #endregion

        #region 3.3 Méthodes publiques

        /// <summary>
        /// Journalise un message d'information.
        /// </summary>
        public void Info(string message)
        {
            Ecrire("INFO", message);
        }

        /// <summary>
        /// Journalise un message d'erreur.
        /// </summary>
        public void Erreur(string message)
        {
            Ecrire("ERREUR", message);
        }

        /// <summary>
        /// Retourne le chemin complet du fichier de journalisation.
        /// Permet l'ouverture du dossier des logs en mode expert.
        /// </summary>
        /// <returns>
        /// Chemin absolu du fichier vigie.log.
        /// </returns>
        public string ObtenirCheminJournal()
        {
            return _cheminFichier;
        }

        #endregion

        #region 3.4 Méthodes privées

        /// <summary>
        /// Écrit une ligne formatée dans le fichier log.
        /// </summary>
        private void Ecrire(string niveau, string message)
        {
            var ligne = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{niveau}] {message}";
            File.AppendAllText(_cheminFichier, ligne + Environment.NewLine);
        }

        #endregion
    }
}