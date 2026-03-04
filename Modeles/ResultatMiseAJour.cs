/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Modeles                                                    ║
║  Fichier : ResultatMiseAJour.cs                                      ║
║                                                                      ║
║  Rôle :                                                              ║
║  Représente le résultat technique d’une tentative de mise            ║
║  à jour logicielle.                                                  ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Stocker le résultat brut d’exécution                              ║
║  - Indiquer succès ou échec                                          ║
║  - Conserver code retour et durée                                    ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - Aucune dépendance métier                                          ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © Année 2026 Flo Latury                                   ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using Vigie.Modeles;

#endregion

#region 2. Description Générale

/*
 * Classe : ResultatMiseAJour
 *
 * Rôle :
 * Modèle technique représentant le résultat d’une tentative
 * d’exécution d’une mise à jour via un gestionnaire de paquets.
 *
 * Responsabilités :
 * 1. Conserver les informations avant/après mise à jour
 * 2. Conserver le statut final (Succès / Échec)
 * 3. Conserver le code retour du processus système
 * 4. Conserver la durée d’exécution
 *
 * Limites :
 * - Ne gère pas la persistance
 * - Ne gère pas l’historique
 * - Ne contient aucune logique métier
 */

#endregion

#region 3. Déclaration de la Classe

public class ResultatMiseAJour
{
    #region 3.1 Propriétés

    public string Nom { get; set; } = string.Empty;

    public string VersionAvant { get; set; } = string.Empty;

    public string VersionApres { get; set; } = string.Empty;

    public string Source { get; set; } = string.Empty;

    public StatutMiseAJour Statut { get; set; } = StatutMiseAJour.Inconnu;

    public string MessageErreur { get; set; } = string.Empty;

    public int CodeRetourProcessus { get; set; }

    public TimeSpan DureeExecution { get; set; }

    #endregion

    #region 3.2 Constructeur

    public ResultatMiseAJour()
    {
        DureeExecution = TimeSpan.Zero;
    }

    #endregion
}

#endregion
