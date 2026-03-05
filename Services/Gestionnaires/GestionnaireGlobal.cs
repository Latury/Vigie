/*
╔═════════════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                              ║
║        Centre de maintenance logicielle intelligent                         ║
║                                                                             ║
║  Module : Services                                                          ║
║  Fichier : GestionnaireGlobal.cs                                            ║
║                                                                             ║
║  Rôle :                                                                     ║
║  Orchestrateur central des gestionnaires de paquets.                        ║
║                                                                             ║
║  Responsabilités principales :                                              ║
║  - Agréger plusieurs sources de mises à jour                                ║
║  - Appliquer la normalisation                                               ║
║  - Fusionner les résultats                                                  ║
║  - Garantir la résilience globale                                           ║
║  - Journaliser l’agrégation                                                 ║
║                                                                             ║
║  Décision architecturale importante :                                       ║
║  Aucune exception ne doit remonter vers l’UI.                               ║
║  Toute erreur interne est capturée, journalisée et neutralisée.             ║
║                                                                             ║
║  Licence : MIT                                                              ║
║  Copyright © 2026 Flo Latury                                                ║
╚═════════════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Vigie.Modeles;
using Vigie.Services.Interfaces;

#endregion

namespace Vigie.Services.Gestionnaires
{
    #region 2. Déclaration

    public class GestionnaireGlobal : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly IEnumerable<IGestionnairePaquets> _gestionnaires;
        private readonly IJournalService _journal;
        private readonly INormaliseur _normaliseur;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireGlobal(
            IEnumerable<IGestionnairePaquets> gestionnaires,
            INormaliseur normaliseur,
            IJournalService journal)
        {
            _gestionnaires =
                gestionnaires ?? throw new ArgumentNullException(nameof(gestionnaires));

            _normaliseur =
                normaliseur ?? throw new ArgumentNullException(nameof(normaliseur));

            _journal =
                journal ?? throw new ArgumentNullException(nameof(journal));
        }

        #endregion

        #region 3.3 Méthodes publiques

        /*
         * Méthode : ScanAsync
         *
         * Objectif :
         * Orchestrer l’agrégation multi-gestionnaires.
         */

        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            try
            {
                _journal.Info("Agrégation des gestionnaires de paquets.");

                var tousLesResultats = new List<LogicielMiseAJour>();

                foreach (var gestionnaire in _gestionnaires)
                {
                    string nomGestionnaire = gestionnaire.GetType().Name;

                    string commande = nomGestionnaire switch
                    {
                        "GestionnaireWinget" => "winget",
                        "GestionnaireScoop" => "scoop",
                        "GestionnaireChocolatey" => "choco",
                        _ => null
                    };

                    if (commande != null && !GestionnaireDisponible(commande))
                    {
                        _journal.Info(
                            $"{nomGestionnaire} ignoré (outil non installé).");

                        continue;
                    }

                    var resultats =
                        await ExecuterGestionnaireAsync(gestionnaire);

                    tousLesResultats.AddRange(resultats);
                }

                var resultatsDedup =
                    DedoublonnerResultats(tousLesResultats);

                _journal.Info(
                    $"Total agrégé après déduplication : {resultatsDedup.Count}.");

                return resultatsDedup;
            }
            catch (Exception exGlobal)
            {
                _journal.Erreur(
                    $"Erreur critique orchestrateur : {exGlobal.Message}");

                return new List<LogicielMiseAJour>();
            }
        }

        #endregion

        #region 3.4 Méthodes privées

        private async Task<List<LogicielMiseAJour>> ExecuterGestionnaireAsync(
            IGestionnairePaquets gestionnaire)
        {
            var resultatsNormalises = new List<LogicielMiseAJour>();

            string nomGestionnaire = gestionnaire.GetType().Name;

            _journal.Info($"Exécution {nomGestionnaire}...");

            try
            {
                var resultats =
                    await gestionnaire.ScanAsync();

                if (resultats == null || resultats.Count == 0)
                {
                    _journal.Info(
                        $"Aucune mise à jour retournée par {nomGestionnaire}.");

                    return resultatsNormalises;
                }

                foreach (var logiciel in resultats)
                {
                    try
                    {
                        var normalise =
                            _normaliseur.Normaliser(logiciel);

                        resultatsNormalises.Add(normalise);
                    }
                    catch (Exception exNormalisation)
                    {
                        _journal.Erreur(
                            $"Erreur normalisation ({nomGestionnaire}) : {exNormalisation.Message}");
                    }
                }

                _journal.Info(
                    $"{resultatsNormalises.Count} mise(s) ajoutée(s) depuis {nomGestionnaire}.");
            }
            catch (Exception exGestionnaire)
            {
                _journal.Erreur(
                    $"Erreur dans {nomGestionnaire} : {exGestionnaire.Message}");
            }

            _journal.Info($"Fin exécution {nomGestionnaire}.");

            return resultatsNormalises;
        }


        private List<LogicielMiseAJour> DedoublonnerResultats(
            List<LogicielMiseAJour> resultats)
        {
            return resultats
                .Where(l => l != null)
                .GroupBy(l =>
                    !string.IsNullOrWhiteSpace(l.IdentifiantNormalise)
                        ? l.IdentifiantNormalise.ToLowerInvariant()
                        : l.Nom.ToLowerInvariant())
                .Select(g =>
                {
                    var groupe = g.ToList();

                    var winget =
                        groupe.FirstOrDefault(x => x.Source == "winget");

                    if (winget != null)
                    {
                        bool memeVersionExiste =
                            groupe.Any(x =>
                                x.Source != "winget" &&
                                x.NouvelleVersion == winget.NouvelleVersion);

                        if (memeVersionExiste)
                        {
                            return winget;
                        }
                    }

                    return groupe
                        .OrderByDescending(x =>
                            ParseVersionSafe(x.NouvelleVersion))
                        .First();
                })
                .ToList();
        }


        /*
         * Méthode : ParseVersionSafe
         *
         * Objectif :
         * Convertir une version string en System.Version
         * pour comparaison fiable.
         */

        private Version ParseVersionSafe(string versionString)
        {
            if (string.IsNullOrWhiteSpace(versionString))
            {
                return new Version(0, 0);
            }

            try
            {
                var propre = versionString
                    .Split('-', '+')[0]
                    .Trim();

                var segments = propre
                    .Split('.')
                    .Take(4)
                    .Select(s =>
                    {
                        if (int.TryParse(s, out var val))
                        {
                            return val;
                        }

                        return 0;
                    })
                    .ToArray();

                while (segments.Length < 2)
                {
                    segments = segments.Append(0).ToArray();
                }

                return segments.Length switch
                {
                    2 => new Version(segments[0], segments[1]),
                    3 => new Version(segments[0], segments[1], segments[2]),
                    _ => new Version(segments[0], segments[1], segments[2], segments[3])
                };
            }
            catch
            {
                return new Version(0, 0);
            }
        }


        /*
         * Méthode : GestionnaireDisponible
         *
         * Objectif :
         * Vérifier si un gestionnaire de paquets
         * est disponible sur la machine.
         */

        private bool GestionnaireDisponible(string commande)
        {
            try
            {
                var process = new Process();

                process.StartInfo.FileName = commande;
                process.StartInfo.Arguments = "--version";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                process.WaitForExit(2000);

                return process.ExitCode == 0;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }

    #endregion
}
