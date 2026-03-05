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
 * Représente l’état d’une tentative
 * de mise à jour logicielle.
 *
 * Cycle typique :
 *
 * Scan détecte logiciel
 * ↓
 * EnAttente
 * ↓
 * EnCours
 * ↓
 * Succes / Echec / Timeout / Annule
 */

#endregion

#region 3. Déclaration de l'Enum

public enum StatutMiseAJour
{
    Inconnu = 0,
    EnAttente = 1,
    EnCours = 2,
    Succes = 3,
    Echec = 4,
    Annule = 5,
    Timeout = 6
}

#endregion
