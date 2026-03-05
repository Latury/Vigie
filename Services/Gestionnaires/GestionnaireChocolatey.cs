/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Gestionnaires                                     ║
║  Fichier : GestionnaireChocolatey.cs                                 ║
║                                                                      ║
║  Rôle :                                                              ║
║  Gestionnaire de paquets pour Chocolatey.                            ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Exécuter la commande chocolatey pour détecter les mises à jour    ║
║  - Parser la sortie texte                                            ║
║  - Produire des modèles LogicielMiseAJour                            ║
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

#endregion

namespace Vigie.Services.Gestionnaires
{
    #region 2. Description Générale

    /*
     * Classe : GestionnaireChocolatey
     *
     * Rôle :
     * Implémente IGestionnairePaquets pour
     * récupérer les mises à jour via Chocolatey.
     *
     * Commande utilisée :
     * choco outdated
     */

    #endregion

    #region 3. Déclaration

    public class GestionnaireChocolatey : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly IJournalService _journal;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireChocolatey(IJournalService journal)
        {
            _journal =
                journal ?? throw new ArgumentNullException(nameof(journal));
        }

        #endregion

        #region 3.3 Méthodes publiques

        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            var logiciels = new List<LogicielMiseAJour>();

            try
            {
                _journal.Info("Début du scan Chocolatey.");

                var process = new Process();

                process.StartInfo.FileName = "choco";
                process.StartInfo.Arguments = "outdated";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string sortie =
                    await process.StandardOutput.ReadToEndAsync();

                process.WaitForExit();

                var lignes =
                    sortie.Split(
                        new[] { '\r', '\n' },
                        StringSplitOptions.RemoveEmptyEntries);

                foreach (var ligne in lignes)
                {
                    if (!ligne.Contains("|"))
                    {
                        continue;
                    }

                    var parties = ligne.Split('|');

                    if (parties.Length < 3)
                    {
                        continue;
                    }

                    var logiciel = new LogicielMiseAJour
                    {
                        Nom = parties[0],
                        VersionActuelle = parties[1],
                        NouvelleVersion = parties[2],
                        Source = "chocolatey",
                        IdentifiantSource = parties[0]
                    };

                    logiciels.Add(logiciel);
                }

                _journal.Info(
                    $"{logiciels.Count} mise(s) à jour détectée(s) via Chocolatey.");
            }
            catch (Exception ex)
            {
                _journal.Erreur(
                    $"Erreur scan Chocolatey : {ex.Message}");
            }

            return logiciels;
        }

        #endregion
    }

    #endregion
}
