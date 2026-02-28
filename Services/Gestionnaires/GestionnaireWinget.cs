/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services                                                   ║
║  Fichier : GestionnaireWinget.cs                                     ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémente GestionnaireWinget pour le gestionnaire winget.          ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Exécuter winget                                                   ║
║  - Lire la sortie console                                            ║
║  - Journaliser les événements                                        ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Vigie.Modeles;
using Vigie.Services.Interfaces;
using Vigie.JournalEvenements;

#endregion

namespace Vigie.Services.PackageManagers
{
    public class GestionnaireWinget : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly IJournalService _journal;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireWinget()
        {
            _journal = new JournalService();
        }

        #endregion

        #region 3.3 Méthodes

        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            var logiciels = new List<LogicielMiseAJour>();

            try
            {
                _journal.Info("Début du scan winget.");

                var processInfo = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = "upgrade",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = new Process
                {
                    StartInfo = processInfo
                };

                process.Start();

                // Timeout 30 secondes
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(30));
                var exitTask = process.WaitForExitAsync();

                var completedTask = await Task.WhenAny(exitTask, timeoutTask);

                if (completedTask == timeoutTask)
                {
                    try { process.Kill(); } catch { }
                    _journal.Erreur("Timeout lors du scan winget.");
                    return logiciels;
                }

                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                if (process.ExitCode != 0)
                {
                    _journal.Erreur($"Winget a retourné un code {process.ExitCode}. Erreur : {error}");
                    return logiciels;
                }

                _journal.Info("Scan winget terminé avec succès.");

                // Parsing texte sera amélioré au commit suivant.

                return logiciels;
            }
            catch (Exception ex)
            {
                _journal.Erreur($"Exception lors du scan winget : {ex.Message}");
                return logiciels;
            }
        }

        #endregion
    }
}