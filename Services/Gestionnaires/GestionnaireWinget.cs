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
║  - Lire la sortie JSON                                               ║
║  - Parser les mises à jour                                           ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Vigie.Modeles;
using Vigie.Services.Interfaces;

#endregion

namespace Vigie.Services.PackageManagers
{
    public class GestionnaireWinget : IGestionnairePaquets
    {
        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            var logiciels = new List<LogicielMiseAJour>();

            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = "winget",
                    Arguments = "upgrade --output json",
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
                    return logiciels;
                }

                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                if (process.ExitCode != 0)
                {
                    return logiciels;
                }

                // Pour l’instant on ne parse pas encore.
                // Parsing JSON sécurisé au commit suivant.

                return logiciels;
            }
            catch (Exception)
            {
                return logiciels;
            }
        }
    }
}