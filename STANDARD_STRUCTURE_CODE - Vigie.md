# STANDARD OFFICIEL DE STRUCTURATION

Projet : Vigie – Centre de maintenance logicielle intelligent

Ce document définit le standard obligatoire de structuration du code pour le projet Vigie.

Il vise à garantir :

- Lisibilité
- Cohérence architecturale
- Maintenabilité long terme
- Discipline documentaire
- Valeur pédagogique

Ce standard est obligatoire pour chaque fichier créé dans le projet.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

1. EN-TÊTE OBLIGATOIRE POUR CHAQUE FICHIER

Règle absolue :

Tout fichier .cs ou .xaml doit commencer par un bloc d’en-tête conforme au modèle ci-dessous.

Aucune exception.

Objectifs :

- Identifier immédiatement le rôle du fichier
- Situer sa place dans l’architecture
- Rappeler la licence
- Maintenir une cohérence documentaire

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Modèle obligatoire pour fichiers .cs

```csharp
/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : NomDuModule                                                ║
║  Fichier : NomDuFichier.cs                                           ║
║                                                                      ║
║  Rôle :                                                              ║
║  Description précise du rôle du fichier dans l’architecture MVVM.    ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - À détailler                                                       ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - Interfaces ou services utilisés                                   ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © Année 2026 Flo Latury                                   ║
╚══════════════════════════════════════════════════════════════════════╝
*/


Le champ "Rôle" est obligatoire.
Il ne doit jamais rester vide.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Modèle obligatoire pour fichiers XAML

<!--
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : NomDuModule                                                ║
║  Fichier : NomDuFichier.xaml                                         ║
║                                                                      ║
║  Rôle :                                                              ║
║  Description claire du rôle de cette vue.                            ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © Année 2026 Flo Latury                                   ║
╚══════════════════════════════════════════════════════════════════════╝
-->

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

STRUCTURE INTERNE OBLIGATOIRE D’UN FICHIER C#

Chaque fichier doit respecter une organisation numérotée claire.

Ordre obligatoire :

Imports

Description Générale

Déclaration principale
3.1 Propriétés
3.2 Constructeur
3.3 Méthodes publiques
3.4 Méthodes privées
3.5 Événements (si applicable)
3.6 Interfaces implémentées (si applicable)

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Exemple structure adaptée à Vigie

#region 1. Imports

using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

#region 2. Description Générale

/*
 * Classe : WingetManager
 *
 * Rôle :
 * Implémente l’interface IPackageManager pour gérer
 * le scan et la mise à jour via winget.
 *
 * Responsabilités :
 * 1. Exécuter les commandes système winget
 * 2. Lire et parser les sorties JSON
 * 3. Retourner des modèles normalisés
 *
 * Limites :
 * - Ne contient aucune logique UI
 * - Ne gère pas la navigation
 * - Ne gère pas la persistance
 */

#endregion

#region 3. Déclaration de la Classe

public class WingetManager : IPackageManager
{
    #region 3.1 Propriétés

    private readonly ILogService _logService;

    #endregion

    #region 3.2 Constructeur

    public WingetManager(ILogService logService)
    {
        _logService = logService;
    }

    #endregion

    #region 3.3 Méthodes Publiques

    /*
     * Méthode : ScanAsync
     *
     * Objectif :
     * Exécute la commande winget upgrade --output json
     * et retourne la liste des logiciels à mettre à jour.
     *
     * Paramètres :
     * Aucun.
     *
     * Retour :
     * Liste de LogicielMiseAJour.
     *
     * Exceptions possibles :
     * ProcessStartException
     * JsonException
     */
    public async Task<List<LogicielMiseAJour>> ScanAsync()
    {
        // Implémentation future
        return new List<LogicielMiseAJour>();
    }

    #endregion
}

#endregion

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

RÈGLES DE COMMENTAIRES

Chaque élément important doit être documenté.

Pour une classe :

Rôle

Responsabilités

Limites

Pour une méthode :

Objectif

Paramètres

Retour

Effets secondaires

Exceptions possibles

Pour une propriété :

Rôle architectural

Pourquoi elle existe

Toute logique complexe doit être expliquée.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

RÈGLES STRICTES

Aucun emoji dans le code

Aucun commentaire décoratif inutile

Aucun commentaire vide

Aucun commentaire vague

Aucun mélange UI / logique métier

Toute décision non évidente doit être expliquée

Toute dépendance importante doit être documentée

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

OBJECTIF DU STANDARD

Ce standard vise à produire un code :

Lisible

Structuré

Maintenable

Pédagogique

Durable

Compréhensible plusieurs années plus tard

Un fichier non structuré devient fragile.
Un fichier documenté devient un actif architectural.

Ce document est obligatoire pour tout nouveau fichier créé dans le projet Vigie.

```
