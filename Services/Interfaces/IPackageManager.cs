/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Interfaces                                        ║
║  Fichier : IPackageManager.cs                                        ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit le contrat commun que tous les gestionnaires de paquets     ║
║  doivent implémenter (winget, scoop, chocolatey, etc.).              ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Standardiser les opérations de scan                               ║
║  - Permettre une abstraction multi-gestionnaires                     ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - Modeles.LogicielMiseAJour                                         ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © Année 2026 Flo Latury                                   ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Collections.Generic;
using System.Threading.Tasks;
using Vigie.Modeles;

#endregion

#region 2. Description Générale

/*
 * Interface : IPackageManager
 *
 * Rôle :
 * Représente une abstraction commune pour tous les gestionnaires
 * de paquets supportés par Vigie.
 *
 * Objectif architectural :
 * Découpler la logique métier du type spécifique de gestionnaire
 * utilisé (winget, scoop, etc.).
 *
 * Limites :
 * - Ne contient aucune logique d’implémentation
 * - Ne dépend d’aucune vue
 * - Ne gère pas l’affichage
 */

#endregion

#region 3. Déclaration de l’Interface

public interface IPackageManager
{
    #region 3.1 Méthodes Publiques

    /*
     * Méthode : ScanAsync
     *
     * Objectif :
     * Lance une opération asynchrone de scan des logiciels
     * installés et retourne la liste des mises à jour détectées.
     *
     * Paramètres :
     * Aucun.
     *
     * Retour :
     * Une liste de LogicielMiseAJour.
     *
     * Exceptions possibles :
     * Exception liée au processus système
     * Exception liée au parsing JSON
     */
    Task<List<LogicielMiseAJour>> ScanAsync();

    #endregion
}

#endregion