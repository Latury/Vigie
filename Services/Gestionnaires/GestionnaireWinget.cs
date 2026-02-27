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

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "winget",
                Arguments = "upgrade --output json",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process();
            process.StartInfo = processStartInfo;

            process.Start();

            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            await process.WaitForExitAsync();

            if (!string.IsNullOrWhiteSpace(error))
            {
                Debug.WriteLine("Winget error: " + error);
                return logiciels;
            }

            if (string.IsNullOrWhiteSpace(output))
                return logiciels;

            try
            {
                using JsonDocument document = JsonDocument.Parse(output);

                foreach (var element in document.RootElement.EnumerateArray())
                {
                    logiciels.Add(new LogicielMiseAJour
                    {
                        Nom = element.GetProperty("Name").GetString() ?? "",
                        VersionActuelle = element.GetProperty("Version").GetString() ?? "",
                        NouvelleVersion = element.GetProperty("AvailableVersion").GetString() ?? ""
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Parsing error: " + ex.Message);
            }

            return logiciels;
        }
    }
}