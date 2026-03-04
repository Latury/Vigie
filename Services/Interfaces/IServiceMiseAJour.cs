/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Interfaces                                        ║
║  Fichier : IServiceMiseAJour.cs                                      ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit le contrat du service responsable                           ║
║  de l’exécution des mises à jour logicielles.                        ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Exécuter une mise à jour individuelle                             ║
║  - Retourner un résultat technique standardisé                       ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - Modeles.ResultatMiseAJour                                         ║
║  - Modeles.LogicielMiseAJour                                         ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © Année 2026 Flo Latury                                   ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Threading.Tasks;

using Vigie.Modeles;

#endregion

#region 2. Description Générale

/*
 * Interface : IServiceMiseAJour
 *
 * Rôle :
 * Définit le contrat permettant d’exécuter
 * une mise à jour logicielle via un gestionnaire de paquets.
 *
 * Responsabilités :
 * 1. Lancer une mise à jour individuelle
 * 2. Retourner un ResultatMiseAJour
 *
 * Limites :
 * - Ne gère pas l’historique
 * - Ne gère pas la journalisation
 * - Ne gère pas l’élévation administrateur
 */

#endregion

#region 3. Déclaration de l’Interface

public interface IServiceMiseAJour
{
    #region 3.1 Méthodes publiques

    Task<ResultatMiseAJour> ExecuterMiseAJourAsync(LogicielMiseAJour logiciel);

    #endregion
}

#endregion
