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

# 1. EN-TÊTE OBLIGATOIRE POUR CHAQUE FICHIER

Règle absolue :

Tout fichier `.cs` ou `.xaml` doit commencer par un bloc d’en-tête conforme au modèle ci-dessous.

Aucune exception.

Objectifs :

- Identifier immédiatement le rôle du fichier
- Situer sa place dans l’architecture
- Rappeler la licence
- Maintenir une cohérence documentaire

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

## Modèle obligatoire pour fichiers `.cs`

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
```

Le champ Rôle est obligatoire et ne doit jamais rester vide.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

## Modèle obligatoire pour fichiers `.xaml`

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

2. STRUCTURE INTERNE D’UN FICHIER C#

Chaque fichier doit respecter une organisation numérotée claire.

Ordre recommandé :

#region 1. Imports

#region 2. Description Générale

#region 3. Déclaration

À l’intérieur de la classe :

3.1 Champs privés
3.2 Propriétés
3.3 Constructeur
3.4 Méthodes publiques
3.5 Méthodes privées
3.6 Événements (si applicables)

Les sections peuvent être omises si elles ne sont pas nécessaires.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

3. STRUCTURE POUR LES MODÈLES ET ENUMS

Les modèles métier et énumérations suivent la même structure générale.

Sections recommandées :

#region 1. Imports
#region 2. Description Générale
#region 3. Déclaration

Règles :

Les modèles doivent rester simples et neutres.

Ils ne doivent jamais contenir :

logique UI

dépendance WinUI

navigation

accès direct aux services

Les modèles représentent uniquement les données métier.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

4. RÈGLES DE COMMENTAIRES

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

rôle architectural

justification si nécessaire

Toute logique complexe doit être expliquée.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

5. RÈGLES STRICTES

Aucun emoji dans le code.

Aucun commentaire décoratif inutile.

Aucun commentaire vide.

Aucun commentaire vague.

Aucun mélange UI / logique métier.

Toute décision non évidente doit être expliquée.

Toute dépendance importante doit être documentée.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

6. OBJECTIF DU STANDARD

Ce standard vise à produire un code :

Lisible

Structuré

Testable

Maintenable

Pédagogique

Durable

Un fichier non structuré devient fragile.
Un fichier documenté devient un actif architectural.

Ce standard garantit que tout nouveau fichier créé dans le projet
peut être compris rapidement par un nouveau développeur
ou par l’auteur lui-même plusieurs années plus tard.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

7. INJECTION DE DÉPENDANCES (RÈGLE ARCHITECTURALE)

Toute classe métier ou service :

ne doit pas instancier directement ses dépendances internes

doit recevoir ses dépendances via le constructeur

doit dépendre d’interfaces plutôt que d’implémentations

Objectifs :

supprimer le couplage fort

permettre la testabilité

préparer l’intégration future d’un conteneur DI

garantir l’évolutivité long terme

Exemple interdit :

new JournalService()

Exemple conforme :

public GestionnaireWinget(IJournalService journal)

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

8. GESTION DES OPÉRATIONS ASYNCHRONES

Les opérations potentiellement longues doivent être exécutées de manière asynchrone.

Exemples :

scan des gestionnaires de paquets

exécution de processus système

opérations réseau

accès disque

Règles :

utiliser async / await

éviter les blocages de l’interface utilisateur

ne jamais utiliser .Result ou .Wait() dans la couche UI

Objectif :

Garantir une interface utilisateur réactive.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

9. JOURNALISATION

Toute opération système importante doit être journalisée.

Exemples :

début / fin d’un scan

début / fin d’une mise à jour

erreurs de processus

exceptions capturées

opérations critiques de sécurité

La journalisation doit passer par le service central :

JournalService

Aucun fichier ne doit écrire directement dans un fichier log.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

10. COUCHE DE NORMALISATION (RÈGLE)

Toute donnée issue d’une source externe doit passer par une étape de normalisation.

Pipeline officiel :

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
- garantir cohérence interne

Cela permet :

- d’ajouter facilement de nouveaux gestionnaires
- d’éviter les dépendances directes au format des outils externes
- de garantir une cohérence interne du moteur de mise à jour.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

11. RESSOURCES VISUELLES (RÈGLE ARCHITECTURALE)

Les ressources visuelles globales doivent être centralisées dans :

Ressources/
├── Couleurs/
├── Styles/
├── Dimensions/
└── Themes/

Objectifs :

éviter valeurs visuelles codées en dur

garantir cohérence graphique

préparer un système de thèmes

simplifier maintenance UI

Exemple interdit :

Foreground="#2563EB"

Exemple conforme :

Foreground="{StaticResource CouleurPrincipale}"

Les ressources appartiennent uniquement à la couche UI.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

12. RESPONSABILITÉ DES CLASSES

Chaque classe doit avoir une responsabilité claire et unique.

Exemples :

GestionnaireWinget
Responsabilité : exécuter les commandes winget et parser la sortie.

JournalService
Responsabilité : journaliser les événements.

AccueilVueModele
Responsabilité : orchestrer les interactions entre UI et services.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

13. COMPARAISON DE VERSIONS

Toute comparaison de versions doit utiliser :

System.Version

Jamais de comparaison texte.

Exemple incorrect :

"1.10" < "1.2"

Exemple correct :

new Version("1.10") > new Version("1.2")
