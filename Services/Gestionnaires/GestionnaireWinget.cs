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

            var processInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "winget",
                Arguments = "upgrade",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new System.Diagnostics.Process
            {
                StartInfo = processInfo
            };

            process.Start();

            string output = await process.StandardOutput.ReadToEndAsync();
            await process.WaitForExitAsync();

            var lignes = output.Split(Environment.NewLine);

            // Trouver la ligne de séparation ------
            int separatorIndex = Array.FindIndex(lignes, l => l.StartsWith("---"));

            if (separatorIndex <= 0)
                return logiciels;

            string header = lignes[separatorIndex - 1];

            int idIndex = header.IndexOf("ID");
            int versionIndex = header.IndexOf("Version");
            int dispoIndex = header.IndexOf("Disponible");

            for (int i = separatorIndex + 1; i < lignes.Length; i++)
            {
                var ligne = lignes[i];

                if (string.IsNullOrWhiteSpace(ligne))
                    continue;

                if (ligne.StartsWith("Les packages") ||
                    ligne.Contains("mise") ||
                    ligne.Contains("upgrade"))
                    break;

                var colonnes = System.Text.RegularExpressions.Regex
                    .Split(ligne.Trim(), @"\s{2,}");

                if (colonnes.Length < 4)
                    continue;

                logiciels.Add(new LogicielMiseAJour
                {
                    Nom = colonnes[0],
                    VersionActuelle = colonnes[2],
                    NouvelleVersion = colonnes[3]
                });
            }

            return logiciels;
        }
    }
}