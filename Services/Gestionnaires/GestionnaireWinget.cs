/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services                                                   ║
║  Fichier : GestionnaireWinget.cs                                     ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémente le gestionnaire winget.                                  ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Exécuter winget                                                   ║
║  - Lire la sortie console                                            ║
║  - Parser les mises à jour                                           ║
║  - Journaliser les événements                                        ║
║                                                                      ║
║  Limites :                                                           ║
║  - Dépend du format texte winget                                     ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
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

        #region 3.3 Méthodes publiques

        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                _journal.Info("");
                _journal.Info("");
                _journal.Info("══════════════════════════════════════════════");
                _journal.Info("Début du scan winget");
                _journal.Info("══════════════════════════════════════════════");

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

                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(30));
                var exitTask = process.WaitForExitAsync();
                var completedTask = await Task.WhenAny(exitTask, timeoutTask);

                if (completedTask == timeoutTask)
                {
                    try { process.Kill(); } catch { }
                    stopwatch.Stop();

                    _journal.Erreur("Timeout lors du scan winget.");
                    _journal.Info("══════════════════════════════════════════════");
                    _journal.Info("");
                    return new List<LogicielMiseAJour>();
                }

                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                if (process.ExitCode != 0)
                {
                    stopwatch.Stop();

                    _journal.Erreur($"Winget a retourné un code {process.ExitCode}. Erreur : {error}");
                    _journal.Info("══════════════════════════════════════════════");
                    _journal.Info("");
                    return new List<LogicielMiseAJour>();
                }

                var logiciels = ParserSortieWinget(output);

                stopwatch.Stop();

                if (logiciels.Count == 0)
                {
                    _journal.Info("Aucune mise à jour déte  ctée.");
                }
                else
                {
                    _journal.Info($"{logiciels.Count} mise(s) à jour détectée(s).");

                    foreach (var logiciel in logiciels)
                    {
                        _journal.Info(
                            $"- {logiciel.Nom}  {logiciel.VersionActuelle} → {logiciel.NouvelleVersion}");
                    }
                }

                _journal.Info("----------------------------------------------");
                _journal.Info($"Durée du scan : {stopwatch.ElapsedMilliseconds} ms");
                _journal.Info("Fin du scan");
                _journal.Info("══════════════════════════════════════════════");
                _journal.Info("");

                return logiciels;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                _journal.Erreur($"Exception lors du scan winget : {ex.Message}");
                _journal.Info("══════════════════════════════════════════════");
                _journal.Info("");
                return new List<LogicielMiseAJour>();
            }
        }

        #endregion

        #region 3.4 Méthodes privées

        /// <summary>
        /// Analyse la sortie texte de winget upgrade
        /// et extrait les mises à jour détectées.
        /// </summary>
        private List<LogicielMiseAJour> ParserSortieWinget(string sortie)
        {
            var logiciels = new List<LogicielMiseAJour>();

            if (string.IsNullOrWhiteSpace(sortie))
            {
                _journal.Erreur("Sortie winget vide.");
                return logiciels;
            }

            var lignes = sortie.Split(Environment.NewLine);

            int indexSeparateur = -1;

            for (int i = 0; i < lignes.Length; i++)
            {
                if (lignes[i].Trim().StartsWith("---"))
                {
                    indexSeparateur = i;
                    break;
                }
            }

            if (indexSeparateur == -1)
            {
                _journal.Info("Aucune section de mise à jour détectée.");
                return logiciels;
            }

            for (int i = indexSeparateur + 1; i < lignes.Length; i++)
            {
                var ligne = lignes[i].Trim();

                if (string.IsNullOrWhiteSpace(ligne))
                    continue;

                if (ligne.StartsWith("Les ") || ligne.StartsWith("No "))
                    break;

                var colonnes = Regex.Split(ligne, @"\s{2,}");

                if (colonnes.Length < 5)
                    continue;

                // Colonnes fixes à partir de la fin
                var versionActuelle = colonnes[colonnes.Length - 3];
                var nouvelleVersion = colonnes[colonnes.Length - 2];

                // Nom toujours première colonne
                var nom = colonnes[0];

                // Sécurité : si le nom contient accidentellement la version,
                // on supprime la version installée du nom.
                if (nom.EndsWith(versionActuelle))
                {
                    nom = nom.Replace(versionActuelle, "").Trim();
                }

                logiciels.Add(new LogicielMiseAJour
                {
                    Nom = nom,
                    VersionActuelle = versionActuelle,
                    NouvelleVersion = nouvelleVersion
                });
            }

            return logiciels;
        }

        #endregion
    }
}