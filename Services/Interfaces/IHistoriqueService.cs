/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Interfaces                                        ║
║  Fichier : IHistoriqueService.cs                                     ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit le contrat du service de gestion de l’historique            ║
║  des mises à jour.                                                   ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Ajouter une entrée d’historique                                   ║
║  - Fournir la liste des opérations enregistrées                      ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - Modeles.HistoriqueMiseAJour                                       ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © Année 2026 Flo Latury                                   ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Collections.Generic;
using Vigie.Modeles;

#endregion

#region 2. Description Générale

/*
 * Interface : IHistoriqueService
 *
 * Rôle :
 * Définit le contrat permettant de gérer l’historique
 * des mises à jour effectuées par l’application.
 *
 * Responsabilités :
 * 1. Ajouter une entrée
 * 2. Exposer la liste des entrées
 *
 * Limites :
 * - Ne définit pas la persistance
 * - Ne définit pas la logique de mise à jour
 */

#endregion

#region 3. Déclaration de l’Interface

public interface IHistoriqueService
{
    #region 3.1 Méthodes publiques

    void Ajouter(HistoriqueMiseAJour entree);

    IReadOnlyList<HistoriqueMiseAJour> ObtenirTout();

    #endregion
}

#endregion
