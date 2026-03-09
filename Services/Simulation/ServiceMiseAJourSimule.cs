/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.MisesAJour                                        ║
║  Fichier : ServiceMiseAJourSimule.cs                                 ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémentation simulée du service de mise à jour.                   ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Simuler une mise à jour logicielle                                ║
║  - Tester le pipeline global sans action système                     ║
║  - Générer succès / échec / timeout                                  ║
║                                                                      ║
║  Particularité :                                                     ║
║  Le comportement peut être contrôlé par ConfigurationSimulation.     ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Threading.Tasks;

using Vigie.Modeles;
using Vigie.Services.Interfaces;
using Vigie.Services.Simulation;

#endregion

#region 2. Description Générale

/*
 * Classe : ServiceMiseAJourSimule
 *
 * Rôle :
 * Implémente IServiceMiseAJour
 * sans exécuter aucune commande système réelle.
 *
 * Objectif :
 * Tester le pipeline complet :
 *
 * UI → ServiceMiseAJourGlobal → ServiceSimule
 * → Resultat → Historique → UI
 *
 * Particularités :
 * - Génération aléatoire contrôlée
 * - Simulation temps d'exécution
 * - Simulation échec / timeout
 */

#endregion

namespace Vigie.Services.MisesAJour
{
    public class ServiceMiseAJourSimule : IServiceMiseAJour
    {
        #region 3.1 Champs privés

        private static readonly Random _random = new();

        #endregion

        #region 3.2 Méthodes publiques

        public async Task<ResultatMiseAJour> ExecuterMiseAJourAsync(
            LogicielMiseAJour logiciel)
        {
            if (logiciel == null)
            {
                return ConstruireEchec(
                    "Logiciel invalide (simulation).");
            }

            // Durée réaliste entre 600 ms et 1800 ms
            int delai = _random.Next(600, 1800);

            await Task.Delay(delai);

            StatutMiseAJour statut;

            if (ConfigurationSimulation.SimulationErreursAleatoires)
            {
                statut = TirerStatutAleatoire();
            }
            else
            {
                statut = StatutMiseAJour.Succes;
            }

            return ConstruireResultat(
                logiciel,
                statut,
                TimeSpan.FromMilliseconds(delai));
        }

        #endregion

        #region 3.3 Méthodes privées

        private StatutMiseAJour TirerStatutAleatoire()
        {
            int tirage = _random.Next(100);

            if (tirage < ConfigurationSimulation.PourcentageSucces)
            {
                return StatutMiseAJour.Succes;
            }

            if (tirage <
                ConfigurationSimulation.PourcentageSucces +
                ConfigurationSimulation.PourcentageEchec)
            {
                return StatutMiseAJour.Echec;
            }

            return StatutMiseAJour.Timeout;
        }

        private ResultatMiseAJour ConstruireResultat(
            LogicielMiseAJour logiciel,
            StatutMiseAJour statut,
            TimeSpan duree)
        {
            return new ResultatMiseAJour
            {
                Nom = logiciel.Nom,
                VersionAvant = logiciel.VersionActuelle,
                VersionApres = logiciel.NouvelleVersion,
                Source = logiciel.Source,
                Statut = statut,
                CodeRetourProcessus = statut switch
                {
                    StatutMiseAJour.Succes => 0,
                    StatutMiseAJour.Echec => -1,
                    StatutMiseAJour.Timeout => -2,
                    _ => -1
                },
                DureeExecution = duree,
                MessageErreur = statut switch
                {
                    StatutMiseAJour.Echec =>
                        "Erreur simulée.",

                    StatutMiseAJour.Timeout =>
                        "Timeout simulé.",

                    _ => string.Empty
                }
            };
        }

        private ResultatMiseAJour ConstruireEchec(string message)
        {
            return new ResultatMiseAJour
            {
                Nom = string.Empty,
                Statut = StatutMiseAJour.Echec,
                MessageErreur = message
            };
        }

        #endregion
    }
}
