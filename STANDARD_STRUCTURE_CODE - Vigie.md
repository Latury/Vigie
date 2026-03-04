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

#region 1. Imports

#region 2. Description Générale

#region 3. Déclaration de la Classe

3.1 Champs privés
3.2 Propriétés
3.3 Constructeur
3.4 Méthodes publiques
3.5 Méthodes privées
3.6 Événements (si applicable)
3.7 Interfaces implémentées (mentionnées dans la déclaration de classe)

Chaque section doit être structurée à l’aide de blocs #region
afin de faciliter la navigation dans les fichiers longs.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

Exemple structure adaptée à Vigie

#region 1. Imports

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Vigie.Modeles;
using Vigie.Services.Interfaces;

#endregion

#region 2. Description Générale

/*
 * Classe : GestionnaireWinget
 *
 * Rôle :
 * Implémente l’interface IGestionnairePaquets
 * pour gérer le scan via winget.
 *
 * Responsabilités :
 * 1. Exécuter la commande système winget upgrade
 * 2. Lire la sortie texte standard
 * 3. Parser les colonnes pour extraire les mises à jour
 * 4. Retourner des modèles normalisés LogicielMiseAJour
 *
 * Limites :
 * - Ne contient aucune logique UI
 * - Ne gère pas la navigation
 * - Ne gère pas la persistance
 * - Dépend du format texte winget
 */

#endregion

#region 3. Déclaration de la Classe

public class GestionnaireWinget : IGestionnairePaquets
{
    #region 3.1 Champs privés

    private readonly IJournalService _journal;

    #endregion

    #region 3.2 Constructeur

    /*
     * Dépendances injectées via constructeur
     * pour garantir découplage et testabilité.
     */

    public GestionnaireWinget(IJournalService journal)
    {
        _journal = journal;
    }

    #endregion

    #region 3.3 Méthodes publiques

    /*
     * Méthode : ScanAsync
     *
     * Objectif :
     * Exécute la commande winget upgrade
     * et retourne la liste des logiciels à mettre à jour.
     *
     * Paramètres :
     * Aucun.
     *
     * Retour :
     * Liste de LogicielMiseAJour.
     *
     * Exceptions possibles :
     * Exception liée au processus système
     */
   
public async Task<List<LogicielMiseAJour>> ScanAsync()
    {
        // Implémentation
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

Testable

Maintenable

Pédagogique

Durable

Compréhensible plusieurs années plus tard

Un fichier non structuré devient fragile.
Un fichier documenté devient un actif architectural.

Ce document est obligatoire pour tout nouveau fichier créé dans le projet Vigie.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

INJECTION DE DÉPENDANCES (RÈGLE ARCHITECTURALE)

Toute classe métier ou service :

- Ne doit pas instancier directement ses dépendances internes
- Doit recevoir ses dépendances via le constructeur
- Doit dépendre d’interfaces plutôt que d’implémentations concrètes

Objectif :

- Supprimer le couplage fort
- Permettre la testabilité
- Préparer l’intégration future d’un conteneur DI
- Garantir l’évolutivité long terme

Exemple interdit :

new JournalService()

Exemple conforme :

public GestionnaireWinget(IJournalService journal)

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

COUCHE DE NORMALISATION (RÈGLE)

Toute donnée issue d’une source externe doit passer par une étape de
normalisation avant d’être utilisée par le moteur interne de l’application.

Règles :

- Toute donnée externe doit être transformée en modèle interne standardisé.
- Les données brutes issues des gestionnaires de paquets ne doivent jamais être utilisées directement dans la couche d’orchestration.
- La normalisation doit produire un identifiant technique stable lorsque cela est nécessaire.

Pipeline officiel du projet :

Scan → Normalisation → Fusion

Explication :

1. Scan  
   Les gestionnaires (winget, scoop, etc.) récupèrent les informations depuis les outils système.

2. Normalisation  
   Les données sont converties dans un format interne cohérent  
   (ex : `LogicielMiseAJour`, `IdentifiantNormalise`).

3. Fusion  
   Les résultats provenant de plusieurs gestionnaires sont regroupés,
   dédupliqués et consolidés.

Objectif architectural :

Séparer clairement :

- l’acquisition des données externes
- la normalisation des données
- la consolidation interne

Cela permet :

- d’ajouter facilement de nouveaux gestionnaires
- d’éviter les dépendances directes au format des outils externes
- de garantir une cohérence interne du moteur de mise à jour.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

RESSOURCES VISUELLES (RÈGLE ARCHITECTURALE)

Les ressources visuelles globales de l’application doivent être centralisées
dans le dossier `Ressources/`.

Objectifs :

- éviter les valeurs visuelles codées directement dans les vues
- garantir la cohérence graphique de l'application
- préparer un futur système de thème
- simplifier la maintenance UI

Structure recommandée :

Ressources/
├── Couleurs/
├── Styles/
├── Dimensions/
└── Themes/

Règles :

Les vues XAML ne doivent pas contenir de couleurs codées directement.

Exemple interdit :

Foreground="#2563EB"

Exemple conforme :

Foreground="{StaticResource CouleurPrincipale}"

Les styles de contrôles doivent être définis dans `Ressources/Styles`.

Les constantes visuelles (espacements, tailles standard, rayons de bordure)
doivent être définies dans `Ressources/Dimensions`.

Les vues doivent uniquement consommer ces ressources
et ne pas définir leurs propres valeurs visuelles.

Objectif final :

Maintenir une cohérence graphique globale et éviter
la duplication de valeurs visuelles dans l’ensemble de l’application.

Les ressources visuelles appartiennent à la couche UI.
Elles ne doivent jamais être définies dans la logique métier
ou dans les ViewModels.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

RESPONSABILITÉ DES CLASSES (PRINCIPE)

Chaque classe doit avoir une responsabilité claire et unique.

Exemples :

GestionnaireWinget
Responsabilité : exécuter les commandes winget et parser la sortie.

JournalService
Responsabilité : écrire les événements dans les logs.

AccueilVueModele
Responsabilité : orchestrer les interactions entre l’interface
et les services métier.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

COMPARAISON DE VERSIONS

Toute comparaison de versions logicielles :

- Doit utiliser System.Version
- Ne doit jamais utiliser une comparaison lexicographique de chaînes

Raison :

"1.10" > "1.2" est faux en comparaison texte,
mais correct via System.Version.
```
