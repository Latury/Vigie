# 🏗️ ARCHITECTURE – VIGIE

Projet : **Vigie – Centre de maintenance logicielle intelligent**

Ce document définit **le standard officiel d’architecture et de structuration du code** pour le projet Vigie.

Il constitue la **référence principale** pour comprendre comment organiser le code et maintenir une architecture cohérente.

---

# 🔎 Référence rapide : AVG

Dans la documentation interne du projet, l’abréviation **AVG** signifie :

**A V G = Architecture ViGie**

Lorsqu’une décision de développement nécessite de vérifier :

- la structure du code
- les règles d’architecture
- l’organisation des classes
- les conventions du projet

il suffit de **consulter ce document**.

Exemple :

> *Voir AVG pour la structure du service.*

AVG renvoie donc directement à :

**ARCHITECTURE – Vigie.md**

---

# 🎯 Objectifs du standard

Ce standard vise à garantir :

- lisibilité du code
- cohérence architecturale
- maintenabilité long terme
- discipline documentaire
- valeur pédagogique

Ce standard est **obligatoire pour chaque fichier créé dans le projet**.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 1. EN-TÊTE OBLIGATOIRE POUR CHAQUE FICHIER

Règle absolue :

Tout fichier `.cs` ou `.xaml` doit commencer par un bloc d’en-tête conforme au modèle ci-dessous.

Aucune exception.

Objectifs :

- identifier immédiatement le rôle du fichier
- situer sa place dans l’architecture
- rappeler la licence
- maintenir une cohérence documentaire

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

Modèle obligatoire pour fichiers .xaml

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

Chaque fichier doit respecter une organisation claire.

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
3.6 Événements (si nécessaires)

Les sections peuvent être omises si elles ne sont pas nécessaires.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

3. STRUCTURE POUR LES MODÈLES ET ENUMS

Les modèles métier et énumérations suivent la même structure générale.

Sections recommandées :

#region 1. Imports
#region 2. Description Générale
#region 3. Déclaration

Règles :

Les modèles doivent rester **simples et neutres.**

Ils ne doivent jamais contenir :

- logique UI
- dépendance WinUI
- navigation
- accès direct aux services

Les modèles représentent uniquement **les données métier.**

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

4. RÈGLES DE COMMENTAIRES

Chaque élément important doit être documenté.

Pour une classe :

- rôle
- responsabilités
- limites

Pour une méthode :

- objectif
- paramètres
- valeur de retour
- effets secondaires
- exceptions possibles

Toute logique complexe doit être expliquée.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

5. RÈGLES STRICTES

- Aucun emoji dans le code
- Aucun commentaire décoratif inutile
- Aucun commentaire vide
- Aucun commentaire vague
- Aucun mélange UI / logique métier
- Toute décision non évidente doit être expliquée
- Toute dépendance importante doit être documentée
- Aucun code mort dans le projet
- Vérifier qu’il ne reste **aucun debug après les tests**

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

6. OBJECTIF DU STANDARD

Ce standard vise à produire un code :

- lisible
- structuré
- testable
- maintenable
- pédagogique
- durable

Un fichier non structuré devient fragile.
Un fichier documenté devient **un actif architectural.**

Ce standard garantit que tout nouveau fichier créé dans le projet
peut être compris rapidement par un nouveau développeur
ou par l’auteur lui-même plusieurs années plus tard.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

7. INJECTION DE DÉPENDANCES

Toute classe métier ou service :

- ne doit pas instancier directement ses dépendances
- doit recevoir ses dépendances via le constructeur
- doit dépendre d’interfaces plutôt que d’implémentations

**Exemple interdit:**

new JournalService()

**Exemple conforme:**

***public GestionnaireWinget(IJournalService journal)***

Objectifs :

- supprimer le couplage fort
- permettre la testabilité
- préparer l’intégration d’un conteneur DI

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

8. OPÉRATIONS ASYNCHRONES

Les opérations longues doivent être exécutées de manière asynchrone.

Exemples :

- scan des gestionnaires
- exécution de processus système
- opérations réseau
- accès disque

Règles :

- utiliser ***async / await***
- éviter tout blocage de l’interface
- ne jamais utiliser ***.Result*** ou ***.Wait()*** dans la couche UI

Objectif : maintenir une **interface utilisateur réactive.**

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

9. JOURNALISATION

Toute opération système importante doit être journalisée.

Exemples :

- début / fin d’un scan
- début / fin d’une mise à jour
- erreurs de processus
- exceptions capturées

La journalisation doit passer par :

**IJournalService / JournalService**

Aucun fichier ne doit écrire directement dans un fichier log. log.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

10. PIPELINE DE DONNÉES

Toute donnée externe doit passer par une normalisation.

***Pipeline officiel:***

***Scan → Normalisation → Fusion → Mise à jour***

**Objectif:**

***séparer clairement:***

- acquisition des données
- normalisation
- fusion multi-sources
- exécution des mises à jour

**Cela permet:**

- l’ajout facile de nouveaux gestionnaires
- l’indépendance vis-à-vis du format des outils externes

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

11. RESSOURCES VISUELLES

Les ressources UI doivent être centralisées dans :

Ressources/
├── Couleurs/
├── Styles/
├── Dimensions/
└── Themes/

**Exemple interdit:**

***Foreground="#2563EB"***

**Exemple conforme:**

***Foreground="{StaticResource CouleurPrincipale}"***

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

12. RESPONSABILITÉ DES CLASSES

Chaque classe doit avoir **une responsabilité unique.**

**Exemples:**

GestionnaireWinget
***→ exécuter les commandes winget et parser la sortie.***

JournalService
***→ journaliser les événements.***

AccueilVueModele
***→ orchestrer les interactions UI / services.***

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

13. COMPARAISON DE VERSIONS

Toute comparaison doit utiliser :

***System.Version***

Jamais de comparaison texte.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

14. GESTION DES EXCEPTIONS

Les exceptions ne doivent jamais remonter directement vers la couche UI.

Toute exception doit être :

- capturée
- journalisée
- transformée en résultat métier

**Objectif:**

garantir la **stabilité du moteur Vigie.**

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

15. NOMMAGE DES FICHIERS

Exemples :

- GestionnaireWinget
- ServiceMiseAJourGlobal
- JournalService
- AccueilVueModele

Règles :

- PascalCase
- nom explicite
- suffixe indiquant le rôle

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

16. RÈGLE MVVM

Les vues XAML ne doivent contenir **aucune logique métier.**

Les interactions doivent passer par :

- Command
- Binding
- ViewModel

Objectif :

maintenir la **séparation stricte UI / logique applicative.**

---

Si tu veux, je peux aussi te montrer **un petit ajout très puissant pour ce document** :  
un **diagramme visuel du moteur Vigie (Scan → Normalisation → Fusion → Mise à jour)** qui rend l’architecture compréhensible en **10 secondes pour n’importe quel développeur**.
