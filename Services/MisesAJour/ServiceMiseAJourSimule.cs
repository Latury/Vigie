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
║  - Simuler une mise à jour                                           ║
║  - Tester le pipeline global sans action système                     ║
║  - Retourner un ResultatMiseAJour cohérent                           ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - IServiceMiseAJour                                                 ║
║  - ResultatMiseAJour                                                 ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Threading.Tasks;

using Vigie.Modeles;
using Vigie.Services.Interfaces;

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
 * Permettre le test complet du pipeline :
 * UI → Global → Service → Resultat → Historique
 *
 * Limites :
 * - Aucune exécution winget
 * - Aucune modification système
 * - Simulation volontairement contrôlée
 */

#endregion

namespace Vigie.Services.MisesAJour
{
    public class ServiceMiseAJourSimule : IServiceMiseAJour
    {
        #region 3.1 Méthodes publiques

        public async Task<ResultatMiseAJour> ExecuterMiseAJourAsync(LogicielMiseAJour logiciel)
        {
            if (logiciel == null)
            {
                return new ResultatMiseAJour
                {
                    Nom = string.Empty,
                    Statut = StatutMiseAJour.Echec,
                    MessageErreur = "Logiciel invalide (simulation)."
                };
            }

            // Simulation d'un délai réaliste
            await Task.Delay(800);

            return new ResultatMiseAJour
            {
                Nom = logiciel.Nom,
                VersionAvant = logiciel.VersionActuelle,
                VersionApres = logiciel.NouvelleVersion,
                Source = logiciel.Source,
                Statut = StatutMiseAJour.Succes,
                CodeRetourProcessus = 0,
                DureeExecution = TimeSpan.FromMilliseconds(800),
                MessageErreur = string.Empty
            };
        }

        #endregion
    }
}
