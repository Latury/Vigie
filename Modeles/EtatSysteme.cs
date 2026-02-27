/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Modeles                                                    ║
║  Fichier : EtatSysteme.cs                                            ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit les états possibles du système Vigie.                       ║
║                                                                      ║
║  Responsabilités :                                                   ║
║  - Centraliser les états logiques globaux                            ║
║  - Garantir une cohérence métier                                     ║
║                                                                      ║
║  Limites :                                                           ║
║  - Ne contient aucune logique                                        ║
║  - Ne contient aucune méthode                                        ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Description Générale

/*
 * Enum : EtatSysteme
 *
 * Rôle :
 * Représente l’état global du système après un scan.
 *
 * Objectif architectural :
 * - Éviter l’utilisation de chaînes de caractères libres
 * - Garantir un état unique et contrôlé
 * - Faciliter l’évolution vers un moteur d’état complet
 */

#endregion

#region 2. Déclaration

namespace Vigie.Modeles
{
    public enum EtatSysteme
    {
        Inconnu,
        AnalyseEnCours,
        Ajour,
        MisesAJourDisponibles,
        Erreur
    }
}

#endregion