/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.MisesAJour                                        ║
║  Fichier : ServiceMiseAJourGlobal.cs                                 ║
║                                                                      ║
║  Rôle :                                                              ║
║  Orchestrateur sécurisé des mises à jour logicielles.                ║
║                                                                      ║
║  Objectif :                                                          ║
║  - Encapsuler toute exception                                        ║
║  - Journaliser les événements critiques                              ║
║  - Garantir stabilité application                                    ║
║  - Gérer préparation point de restauration                           ║
║  - Gérer timeout d'exécution                                         ║
║  - Enregistrer l’historique des opérations                           ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Vigie.Modeles;
using Vigie.Services.Interfaces;

#endregion

namespace Vigie.Services.MisesAJour
{
    #region 2. Description Générale

    /*
     * Classe : ServiceMiseAJourGlobal
     *
     * Rôle :
     * Orchestrateur central sécurisé des mises à jour.
     *
     * Responsabilités :
     * 1. Préparer point de restauration
     * 2. Encapsuler toute exception
     * 3. Journaliser les événements
     * 4. Garantir qu’aucune exception ne remonte vers l’UI
     * 5. Gérer timeout d’exécution
     * 6. Mettre à jour le statut visuel des logiciels
     * 7. Enregistrer les opérations dans l’historique
     */

    #endregion

    #region 3. Déclaration

    public class ServiceMiseAJourGlobal
    {
        #region 3.1 Champs privés

        private readonly IServiceMiseAJour _serviceMiseAJour;
        private readonly IJournalService? _journal;
        private readonly IPointRestaurationService? _pointRestauration;
        private readonly IHistoriqueService? _historique;

        private readonly TimeSpan _timeoutMiseAJour =
            TimeSpan.FromMinutes(10);

        #endregion

        #region 3.2 Constructeur

        public ServiceMiseAJourGlobal(
            IServiceMiseAJour serviceMiseAJour,
            IJournalService? journal = null,
            IPointRestaurationService? pointRestauration = null,
            IHistoriqueService? historique = null)
        {
            _serviceMiseAJour =
                serviceMiseAJour
                ?? throw new ArgumentNullException(nameof(serviceMiseAJour));

            _journal = journal;
            _pointRestauration = pointRestauration;
            _historique = historique;
        }

        #endregion

        #region 3.3 Méthodes publiques

        public async Task<bool> PreparerPointRestaurationAsync()
        {
            if (_pointRestauration == null)
            {
                _journal?.Info("Aucun service de point de restauration configuré.");
                return true;
            }

            try
            {
                _journal?.Info("Création point de restauration système...");

                bool succes =
                    await _pointRestauration
                        .CreerPointRestaurationAsync(
                            "Vigie - Avant mise à jour globale");

                if (succes)
                {
                    _journal?.Info("Point de restauration créé avec succès.");
                }
                else
                {
                    _journal?.Erreur("Échec création point de restauration.");
                }

                return succes;
            }
            catch (Exception ex)
            {
                _journal?.Erreur(
                    $"Erreur création point restauration : {ex.Message}");

                return false;
            }
        }

        public async Task<ResultatMiseAJour> ExecuterMiseAJourAsync(
            LogicielMiseAJour logiciel)
        {
            if (!EstLogicielValide(logiciel))
            {
                _journal?.Erreur(
                    "Tentative mise à jour avec logiciel invalide.");

                return ConstruireEchec(
                    logiciel,
                    "Logiciel invalide.");
            }

            var stopwatch = Stopwatch.StartNew();

            try
            {
                logiciel.StatutMiseAJour = StatutMiseAJour.EnCours;

                _journal?.Info(
                    $"Début mise à jour : {logiciel.Nom} ({logiciel.Source})");

                var tacheMiseAJour =
                    _serviceMiseAJour
                        .ExecuterMiseAJourAsync(logiciel);

                var tacheTimeout =
                    Task.Delay(_timeoutMiseAJour);

                var tacheTerminee =
                    await Task.WhenAny(tacheMiseAJour, tacheTimeout);

                if (tacheTerminee == tacheTimeout)
                {
                    throw new TaskCanceledException(
                        $"Timeout mise à jour après {_timeoutMiseAJour.TotalMinutes} minutes.");
                }

                var resultat = await tacheMiseAJour;

                stopwatch.Stop();

                if (resultat == null)
                {
                    logiciel.StatutMiseAJour = StatutMiseAJour.Echec;

                    return ConstruireEchec(
                        logiciel,
                        "Service interne retourné null.",
                        stopwatch.Elapsed);
                }

                resultat.DureeExecution = stopwatch.Elapsed;

                logiciel.StatutMiseAJour =
                    resultat.Statut == StatutMiseAJour.Succes
                    ? StatutMiseAJour.Succes
                    : StatutMiseAJour.Echec;

                _journal?.Info(
                    $"Fin mise à jour : {logiciel.Nom} - {resultat.Statut}");

                EnregistrerHistorique(resultat);

                return resultat;
            }
            catch (TaskCanceledException)
            {
                stopwatch.Stop();

                logiciel.StatutMiseAJour = StatutMiseAJour.Timeout;

                _journal?.Erreur(
                    $"Timeout mise à jour : {logiciel.Nom}");

                var resultat =
                    ConstruireTimeout(
                        logiciel,
                        stopwatch.Elapsed);

                EnregistrerHistorique(resultat);

                return resultat;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                logiciel.StatutMiseAJour = StatutMiseAJour.Echec;

                _journal?.Erreur(
                    $"Erreur critique mise à jour {logiciel.Nom} : {ex.Message}");

                var resultat =
                    ConstruireEchec(
                        logiciel,
                        ex.Message,
                        stopwatch.Elapsed);

                EnregistrerHistorique(resultat);

                return resultat;
            }
        }

        #endregion

        #region 3.4 Méthodes privées

        private bool EstLogicielValide(LogicielMiseAJour? logiciel)
        {
            return logiciel != null
                && !string.IsNullOrWhiteSpace(logiciel.Nom)
                && !string.IsNullOrWhiteSpace(logiciel.Source);
        }

        private void EnregistrerHistorique(ResultatMiseAJour resultat)
        {
            if (_historique == null)
            {
                return;
            }

            var entree = new HistoriqueMiseAJour
            {
                Nom = resultat.Nom,
                VersionAvant = resultat.VersionAvant,
                VersionApres = resultat.VersionApres,
                Source = resultat.Source,
                Statut = resultat.Statut,
                MessageErreur = resultat.MessageErreur
            };

            _historique.Ajouter(entree);
        }

        private ResultatMiseAJour ConstruireEchec(
            LogicielMiseAJour? logiciel,
            string message,
            TimeSpan? duree = null)
        {
            return new ResultatMiseAJour
            {
                Nom = logiciel?.Nom ?? string.Empty,
                VersionAvant = logiciel?.VersionActuelle ?? string.Empty,
                VersionApres = logiciel?.NouvelleVersion ?? string.Empty,
                Source = logiciel?.Source ?? string.Empty,
                Statut = StatutMiseAJour.Echec,
                MessageErreur = message,
                CodeRetourProcessus = -1,
                DureeExecution = duree ?? TimeSpan.Zero
            };
        }

        private ResultatMiseAJour ConstruireTimeout(
            LogicielMiseAJour logiciel,
            TimeSpan duree)
        {
            return new ResultatMiseAJour
            {
                Nom = logiciel.Nom,
                VersionAvant = logiciel.VersionActuelle,
                VersionApres = logiciel.NouvelleVersion,
                Source = logiciel.Source,
                Statut = StatutMiseAJour.Timeout,
                MessageErreur = "Timeout lors de l'exécution.",
                CodeRetourProcessus = -2,
                DureeExecution = duree
            };
        }

        #endregion
    }

    #endregion
}
