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
║  - Garantir une écriture sécurisée des logs                          ║
║  - Gérer la rotation automatique des journaux                        ║
║                                                                      ║
║  Limites :                                                           ║
║  - Journalisation synchrone                                          ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.IO;
using System.Globalization;

using Windows.Storage;

using Vigie.Services.Interfaces;

#endregion

namespace Vigie.JournalEvenements
{
    #region 2. Description Générale

    /*
     * Classe : JournalService
     *
     * Rôle :
     * Service responsable de la journalisation des événements
     * internes de l'application Vigie.
     *
     * Responsabilités :
     * 1. Écrire les messages d'information
     * 2. Écrire les messages d'erreur
     * 3. Garantir un format uniforme des logs
     * 4. Empêcher l'accumulation de lignes vides
     * 5. Garantir une écriture sécurisée des logs
     * 6. Gérer la rotation automatique des journaux
     *
     * Fonctionnement de la rotation :
     * Si vigie.log dépasse la taille maximale autorisée,
     * les anciens journaux sont archivés et un nouveau
     * fichier vigie.log est créé.
     */

    #endregion

    #region 3. Déclaration

    public class JournalService : IJournalService
    {
        #region 3.1 Champs privés

        private readonly string _cheminFichier;

        private bool _derniereLigneVide = false;

        private readonly object _verrouJournal = new();

        private const long TailleMaxJournal = 5 * 1024 * 1024;

        private const int NombreArchivesMax = 3;

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

            AssurerCreationFichier();
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
        public string ObtenirCheminJournal()
        {
            return _cheminFichier;
        }

        #endregion

        #region 3.4 Méthodes privées

        /// <summary>
        /// Vérifie que le fichier log existe.
        /// Si absent, il est automatiquement créé.
        /// </summary>
        private void AssurerCreationFichier()
        {
            if (!File.Exists(_cheminFichier))
            {
                File.WriteAllText(_cheminFichier, string.Empty);
            }
        }

        /// <summary>
        /// Vérifie si le journal doit être rotaté.
        /// </summary>
        private void VerifierRotationLogs()
        {
            var info = new FileInfo(_cheminFichier);

            if (info.Length < TailleMaxJournal)
            {
                return;
            }

            for (int i = NombreArchivesMax; i >= 1; i--)
            {
                string ancien = $"{_cheminFichier.Replace(".log", "")}-{i}.log";
                string suivant = $"{_cheminFichier.Replace(".log", "")}-{i + 1}.log";

                if (File.Exists(ancien))
                {
                    if (i == NombreArchivesMax)
                    {
                        File.Delete(ancien);
                    }
                    else
                    {
                        File.Move(ancien, suivant);
                    }
                }
            }

            string archive = $"{_cheminFichier.Replace(".log", "")}-1.log";

            File.Move(_cheminFichier, archive);

            File.WriteAllText(_cheminFichier, string.Empty);
        }

        /// <summary>
        /// Écrit une ligne formatée dans le fichier log.
        /// </summary>
        private void Ecrire(string niveau, string message)
        {
            message = message?.Trim();

            lock (_verrouJournal)
            {
                VerifierRotationLogs();

                if (string.IsNullOrWhiteSpace(message))
                {
                    if (_derniereLigneVide)
                    {
                        return;
                    }

                    File.AppendAllText(
                        _cheminFichier,
                        Environment.NewLine);

                    _derniereLigneVide = true;

                    return;
                }

                _derniereLigneVide = false;

                var cultureFr = CultureInfo.GetCultureInfo("fr-FR");

                string horodatage =
                    DateTime.Now.ToString(
                        "dd MMMM yyyy HH:mm:ss",
                        cultureFr);

                var ligne =
                    $"{horodatage} [{niveau}] {message}";

                File.AppendAllText(
                    _cheminFichier,
                    ligne + Environment.NewLine);
            }
        }

        #endregion
    }

    #endregion
}
