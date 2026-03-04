/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Modeles                                                    ║
║  Fichier : StatutMiseAJour.cs                                        ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit les différents statuts possibles d’une tentative            ║
║  de mise à jour logicielle.                                          ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Standardiser l’état d’une opération                               ║
║  - Éviter l’usage d’un simple booléen                                ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - Aucune                                                            ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © Année 2026 Flo Latury                                   ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

#endregion

#region 2. Description Générale

/*
 * Enum : StatutMiseAJour
 *
 * Rôle :
 * Représente l’état final d’une tentative
 * de mise à jour logicielle.
 *
 * Objectif :
 * Remplacer un booléen trop limité
 * par une représentation explicite et extensible.
 */

#endregion

#region 3. Déclaration de l'Enum

public enum StatutMiseAJour
{
    Inconnu = 0,
    Succes = 1,
    Echec = 2,
    Annule = 3,
    Timeout = 4
}

#endregion
