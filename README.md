<div align="center">

# 🧭 VIGIE

### Centre de maintenance logicielle intelligent

Application WinUI 3 (.NET 8) dédiée à la gestion, au contrôle et à la sécurisation des mises à jour logicielles sous Windows.

![Version](https://img.shields.io/badge/Version-0.4.0--dev-1E90FF?style=for-the-badge)
![Statut](https://img.shields.io/badge/Statut-S%C3%A9curit%C3%A9%20renforc%C3%A9e%20en%20dev-FF8C00?style=for-the-badge)
![Licence](https://img.shields.io/badge/Licence-MIT-2E8B57?style=for-the-badge)

![.NET](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge)
![WinUI](https://img.shields.io/badge/WinUI-3-0078D6?style=for-the-badge)
![Architecture](https://img.shields.io/badge/Architecture-MVVM-6A5ACD?style=for-the-badge)
![Plateforme](https://img.shields.io/badge/Plateforme-Windows-0078D6?style=for-the-badge)

Auteur : Flo Latury
Dernière mise à jour : 09 mars 2026

</div>

---

# 📖 1. Présentation Générale

Vigie est un **centre de maintenance logicielle moderne conçu pour Windows.**

L'application agit comme un **orchestrateur de 

gestionnaires de paquets,** permettant de centraliser l’analyse et la mise à jour des logiciels installés sur le système.

Vigie s’appuie sur plusieurs sources de mise à jour :

- winget
- scoop
- chocolatey

L'objectif est de fournir une **vision unifiée des mises à jour disponibles,** tout en garantissant un processus de maintenance **sécurisé et contrôlé.**

Les principales fonctions de Vigie sont :

- Scanner les logiciels installés

- Identifier les mises à jour disponibles

- Préparer la mise à jour sécurisée des applications

- Centraliser les informations provenant de plusieurs gestionnaires

- Simplifier la maintenance pour les utilisateurs non techniques

- Fournir un cadre pédagogique structuré pour l’apprentissage du développement logiciel

**Actuellement, Vigie se concentre sur:**
   
   ***la détection fiable des mises à jour***
   ***la stabilisation du moteur de mise à jour***
   ***la consolidation de son architecture interne***

Vigie n’est pas un simple utilitaire.

**C’est un projet conçu pour être:**

- Structuré
- Maintenable
- Évolutif
- Documenté
- Pédagogique

---

# 🎯 2. Objectif du Projet

**Vigie vise progressivement à:**

***Centraliser la gestion des mises à jour logicielles***

***Supporter plusieurs gestionnaires de paquets***

***Offrir un mode simplifié pour les **personnes âgées** (Mode Senior)***

***Proposer un mode avancé pour les utilisateurs techniques (Mode Expert)***

***Appliquer une architecture MVVM stricte***

***Maintenir une discipline documentaire complète***

Ces objectifs sont atteints **progressivement,** selon une progression maîtrisée définie dans **la feuille de route officielle du projet.**

---

# 🧠 3. Vision & Philosophie

## 📌 Vision

Construire un outil **fiable, sécurisé et évolutif,** capable d'assurer la maintenance logicielle d’un système Windows sur le long terme.

L’objectif est de créer un outil :

- compréhensible
- robuste
- extensible
- maintenable sur plusieurs années

## 🧭 Principes Directeurs

Le développement de Vigie repose sur plusieurs principes fondamentaux :

- **Architecture avant fonctionnalités**
- **Lisibilité avant optimisation**
- **Sécurité avant automatisation**
- **Documentation avant rapidité**
- **Consolidation avant expansion**

Chaque version stabilise l’existant avant d’introduire de nouvelles capacités.

## 🎓 Dimension pédagogique

Le projet sert également de **support d’apprentissage avancé,** notamment pour :

- la structuration d’un projet **WinUI 3 (.NET 8)**
- l’application rigoureuse du **pattern MVVM**
- la gestion de **processus système Windows**
- **le parsing robuste des sorties console**
- **la normalisation de données multi-sources**
- la mise en place d’une **discipline Git professionnelle**
- la production **d’une documentation technique structurée**

Vigie constitue ainsi un projet combinant :

- apprentissage
- architecture logicielle
- maintenance système
- bonnes pratiques de développement.

---

# 🏗️ 4. Architecture

## 🧩 Organisation Générale

```
Vigie/
│
├── Services/            → Logique métier principale de l'application
│   ├── Gestionnaires/   → Implémentations des gestionnaires de paquets
│   ├── Historique/      → Gestion de l’historique des mises à jour
│   ├── Interfaces/      → Abstractions des services
│   ├── MiseAJour/       → Orchestration des mises à jour
│   ├── Normalisation/   → Normalisation des données multi-gestionnaires
│   ├── Securite/        → Vérifications système et sécurité
│   └── UI/              → Services d'interaction utilisateur (dialogues, confirmations, feedback)
│
├── Modeles/             → Modèles de données utilisés dans l’application
├── JournalEvenements/   → Infrastructure de journalisation
├── Infrastructure/      → Services techniques internes
├── VueModeles/          → Logique MVVM reliant UI et services
├── Vues/                → Interfaces graphiques WinUI
│
├── Ressources/          → Ressources graphiques globales
│   ├── Couleurs/
│   ├── Dimensions/
│   ├── Styles/
│   └── Themes/
│
├── Assets/              → Images et ressources statiques
├── Properties/          → Configuration du projet
│
├── README.md
├── FEUILLE DE ROUTE – Vigie.md
├── PATCH NOTES – VIGIE.md
├── ARCHITECTURE – Vigie.md
├── GUIDE OFFICIEL DES COMMITS – VIGIE.md
├── GUIDE UTILISATEUR – VIGIE.md
├── TESTS – VIGIE.md
├── LICENSE.md
```

## 🏗️ Principes d’Architecture

- MVVM strict
- Séparation claire des responsabilités
- Logique métier isolée des vues

- Services découplés et testables
- Journalisation centralisée

- Abstraction via IGestionnairePaquets
- Implémentations concrètes découplées (GestionnaireWinget, futur Scoop, etc.)

- Orchestrateur central (GestionnaireGlobal)
- Pipeline de traitement structuré (Scan → Normalisation → Fusion → Mise à jour)

- Support multi-gestionnaires activé (Winget réel - Scoop simulé - Chocolatey simulé)
- Extensibilité progressive

## ⚙️ Pipeline interne de traitement

Scan des gestionnaires
        ↓
Normalisation des données
        ↓
Fusion des résultats
        ↓
Analyse des mises à jour disponibles
        ↓
Orchestration des mises à jour sécurisées

## 🧠 Fonctionnement interne de Vigie

Gestionnaires
   │
   ├─ Winget
   ├─ Scoop
   └─ Chocolatey
        │
        ▼
Normalisation
        │
        ▼
Fusion des résultats
        │
        ▼
Orchestrateur
        │
        ▼
Mise à jour sécurisée

---

# ✨ 5. Fonctionnalités

## ✅ Version 0.1.0 — Fondations

Première version du projet, consacrée à la **mise en place des bases architecturales de l'application.**

Objectifs :

- établir une **architecture propre**
- préparer le **upport multi-gestionnaires**
- construire un **socle stable pour les versions suivantes**

### 🏗️ Infrastructure du projet

- Initialisation du projet **WinUI 3 (.NET 8)**
- Mise en place d'une architecture **MVVM stricte**
- Structuration initiale du projet (Services / Modeles / Vues / VueModeles)

### ⚙️ Moteur de détection des mises à jour

- Création de l'interface générique ***IGestionnairePaquets***
- Implémentation du gestionnaire ***GestionnaireWinget***
- Introduction de l'orchestrateur central ***GestionnaireGlobal***

### 🔎 Scan des logiciels

- Scan des mises à jour via **winget**
- Parsing texte robuste basé sur la **structure des colonnes**
- Nettoyage et normalisation des données récupérées

### ⏱️ Gestion des processus

- Implémentation d’un **timeout de sécurité (30 secondes) pour les processus système**
- Prévention des blocages lors de l’exécution des commandes

### 📜 Journalisation

- Mise en place d’une **journalisation structurée des événements**
- Centralisation de l’écriture dans les journaux

### 🖥️ Interface minimale

- Interface principale simple
- Affichage de la **liste des mises à jour détectées**

---

## ✅ Version 0.2.0 — Extension multi-gestionnaires

Cette version introduit les **fondations du support multi-gestionnaires** et prépare l’architecture permettant d’agréger plusieurs sources de mises à jour.

L’objectif principal est de **structurer le pipeline interne** afin de gérer correctement les données provenant de plusieurs gestionnaires de paquets.

### 📦 Support multi-gestionnaires

- Introduction de la propriété Source dans le modèle ***LogicielMiseAJour***
- Activation du support **multi-gestionnaires (Winget + Scoop)**
- Préparation du support futur pour **Chocolatey**

### 🔎 Normalisation et fusion des données

Pour gérer plusieurs gestionnaires, Vigie introduit un pipeline structuré :

***Scan → Normalisation → Fusion***

Fonctionnalités associées :

- Production d’une **couche de normalisation multi-sources**
- Déduplication robuste basée sur ***IdentifiantNormalise***
- Fusion des résultats provenant de plusieurs gestionnaires

### 📜 Journalisation

- Stabilisation du **JournalService**
- Suppression des **doublons et lignes vides dans les journaux**

### ⚙️ Préparation des futures fonctionnalités

Cette version prépare plusieurs éléments qui seront utilisés dans les versions suivantes :

- Préparation de l’infrastructure **paramètres utilisateur**
- Préparation du modèle **Historique interne** (non persistant pour le moment)

---

## 🔄 Version 0.3.0 — Mise à jour contrôlée

Cette version introduit le **moteur de mise à jour des logiciels**, permettant à Vigie
de passer d’un simple outil de détection à un **outil capable d’exécuter des mises à jour contrôlées**.

L’objectif principal est de **sécuriser et tracer les opérations de mise à jour**.

### ⚙️ Moteur de mise à jour

- Implémentation de la **mise à jour globale contrôlée**
- Introduction du service **`ServiceMiseAJourGlobal`**
- Orchestration des mises à jour via l’orchestrateur central

### 🔐 Sécurisation des opérations

- Confirmation utilisateur via **`IConfirmationService`**
- Préparation de l’infrastructure pour la **création de points de restauration système (simulation)**

### 📜 Journalisation et traçabilité

- Journalisation détaillée des opérations de mise à jour
- Traçabilité complète des actions effectuées par Vigie

### 🖥️ Interaction avec l’interface

- Désactivation partielle de l’interface pendant une opération
- Introduction d’un **feedback visuel des opérations**
- Mise à jour du **statut des logiciels pendant les opérations**

### ⚠️ Fonctionnalités encore en cours

Certaines fonctionnalités sont partiellement préparées mais finalisées dans les versions suivantes :

- Mise à jour individuelle (sélection par logiciel)
- Gestion de l’élévation administrateur
- Historique interne des mises à jour
- Amélioration du feedback visuel dans l’interface

### 📌 Fonctionnalités prévues (versions ultérieures)

Les prochaines versions introduiront des capacités supplémentaires :

- Création automatique d’un point de restauration système
- Mode **Senior** simplifié
- Mode **Expert** avancé
- Extension complète du support **Scoop**
- Support **Chocolatey**
- Support des gestionnaires de paquets développeur (pip, npm, etc.)
- Historique persistant des mises à jour
- Planification automatique des mises à jour
- Niveaux de journalisation configurables

---

### 🔄 Version 0.4.0-dev — Sécurité renforcée

Cette version introduira des mécanismes visant à sécuriser les opérations
de mise à jour et à vérifier l’environnement système avant leur exécution.

Principales améliorations prévues :

- Vérification de la présence des gestionnaires de paquets
- Vérification des privilèges administrateur
- Vérification de la connectivité réseau
- Vérification de l’espace disque disponible
- Création automatique d’un point de restauration système
- Détection des mises à jour nécessitant un redémarrage
- Implémentation d’un pipeline de validation avant mise à jour
- Journalisation des validations système
- Gestion des échecs avec retry automatique

---

### 📌 Version 0.5.0 — Expérience utilisateur (Mode Senior)

Cette version visera à rendre l’application plus accessible
aux utilisateurs non techniques.

Améliorations prévues :

- Carte **"État du système"**
- Barre de progression globale des mises à jour
- Feedback visuel par logiciel pendant les opérations
- Confirmation utilisateur améliorée
- Tri des logiciels dans la liste
- Recherche dans la liste des logiciels
- Affichage de la source du gestionnaire dans la liste

Objectif : rendre l’application **compréhensible en un coup d’œil.**

---

### 📌 Version 0.6.0 — Simulation des mises à jour

Introduction d’un mode **simulation (dry-run)** permettant
d’analyser les mises à jour avant leur exécution.

Fonctionnalités prévues :

- Liste des logiciels concernés
- Gestionnaire utilisé pour chaque logiciel
- Indication des redémarrages potentiels
- Estimation du volume de téléchargement
- Analyse prévisionnelle des mises à jour
- Simulation du pipeline d’exécution

Objectif : permettre à l’utilisateur **d’anticiper les impacts d’une mise à jour.**

---

### 📌 Version 0.7.0 — Observabilité et suivi

Cette version introduira des mécanismes permettant
de suivre les opérations réalisées par Vigie dans le temps.

Fonctionnalités prévues :

- Notifications système après mise à jour
- Historique des mises à jour
- Rapport synthétique santé système
- Export des rapports
- Conservation configurable des journaux

Objectif : offrir **une visibilité complète sur les opérations réalisées.**

---

### 📌 Version 0.8.0 — Moteur multi-gestionnaires avancé

Cette version étendra le moteur de Vigie afin de supporter
plusieurs gestionnaires de paquets réels.

Fonctionnalités prévues :

- Activation réelle de **Scoop**
- Activation réelle de **Chocolatey**
- Support des gestionnaires développeur (**pip, npm**)
- Détection robuste des gestionnaires installés
- Vérification de leur présence dans le PATH système
- Mise en cache des résultats de détection

Objectif : transformer Vigie en **centre de maintenance multi-gestionnaires.**

---

### 📌 Version 0.9.0 — Configuration et personnalisation

Introduction d’un système de configuration avancé permettant
d’adapter le comportement du moteur de mise à jour.

Fonctionnalités prévues :

- Import configuration Vigie
- Export configuration Vigie
- Configuration utilisateur du timeout des mises à jour
- Définition d’une durée maximale d’exécution
- Niveaux de journalisation configurables
- Filtrage des messages selon le niveau choisi

Objectif : offrir **un moteur configurable et adaptable.**

---

### 📌 Version 1.0.0 — Maturité du moteur

Cette version marque une étape importante
dans la stabilité et la robustesse du moteur Vigie.

Fonctionnalités prévues :

- Formalisation des états principaux de l’application
- Centralisation de la gestion des états dans le ViewModel
- Implémentation réelle de l’élévation administrateur (UAC)
- Planification automatique des mises à jour
- Optimisations de performance
- Tests unitaires automatisés

Objectif : atteindre une **version stable pour une utilisation quotidienne.**

---

### 📌 Version 1.5 — Refonte UX/UI complète

Cette version introduira une **refonte complète de l’interface utilisateur**
afin d’améliorer l’ergonomie et la lisibilité de l’application.

Améliorations prévues :

- Icônes visuelles cohérentes pour les statuts
- Interface simplifiée (Mode Senior)
- Boutons larges et messages clairs
- Mode Expert avec informations techniques détaillées
- Visualisation des points de restauration
- Affichage des tentatives de récupération (retry)
- Interface avancée des paramètres

Objectif : rendre Vigie **accessible à tous les utilisateurs tout en restant puissant.**

---

### 📌 Version 2.0.0 — Architecture long terme

Cette version explorera des capacités avancées
destinées à des environnements plus complexes.

Fonctionnalités envisagées :

- Synchronisation distante
- API interne
- Supervision multi-machines
- Extension entreprise
- Internationalisation de l’application
- Traduction complète en anglais

Objectif : transformer Vigie en **plateforme de maintenance logicielle évolutive.**

---

# 🧭 6. Philosophie UX

L’interface de Vigie suit des principes simples :

- **Lisibilité avant effets visuels**
- **Clarté avant complexité**
- **Feedback avant ambiguïté**

L’objectif est de garantir que **l’état du système et les actions possibles soient toujours compréhensibles immédiatement**, même pour un utilisateur non technique.

Vigie privilégie donc une interface :

- simple
- explicite
- prévisible

---

# 🔒 7. Sécurité

La version actuelle de Vigie (0.3.0-dev) introduit la mise à jour
contrôlée des logiciels.

Les opérations de mise à jour sont actuellement protégées par plusieurs mécanismes :

- Confirmation utilisateur avant exécution des mises à jour
- Journalisation complète des opérations effectuées
- Préparation du mécanisme de création de point de restauration système
- Préparation de la gestion de l’élévation des privilèges administrateur

## 🔮 Évolution prévue du système de sécurité

Les versions suivantes introduiront des protections supplémentaires :

- Vérification de la présence des gestionnaires de paquets
- Vérification des privilèges administrateur
- Vérification de la connectivité réseau
- Vérification de l’espace disque disponible
- Création automatique d’un point de restauration système
- Détection des mises à jour nécessitant un redémarrage
- Pipeline de validation avant mise à jour
- Journalisation des validations système
- Gestion des échecs avec retry automatique

## 🔮 Stratégie de sécurité prévue (versions ultérieures)

Avant toute mise à jour globale, Vigie appliquera plusieurs mécanismes
destinés à sécuriser les opérations système et à limiter les risques.

Les protections prévues incluent :

- Création automatique d’un point de restauration système
- Confirmation explicite de l’utilisateur avant exécution
- Journalisation complète des opérations
- Gestion détaillée des erreurs
- Possibilité de relancer automatiquement une opération échouée

Ces mécanismes permettront d’assurer une **exécution plus sûre et plus
traçable des mises à jour logicielles.**

**⚠️ Vigie n’est pas destiné à un environnement critique sans validation approfondie.**

---

# 🚀 8. Performance

Vigie privilégie une approche orientée **stabilité et fiabilité** plutôt que
l’optimisation prématurée des performances.

Les mécanismes actuellement en place incluent :

- Exécution asynchrone non bloquante des processus système
- Gestion d’un timeout contrôlé (30 secondes) pour éviter les blocages
- Parsing texte robuste basé sur la structure des colonnes de `winget`
- Normalisation des données issues de plusieurs gestionnaires
- Mesure précise de la durée des scans via `Stopwatch`
- Priorité donnée à la stabilité et à la fiabilité des opérations

Les optimisations avancées seront introduites progressivement
après la consolidation du moteur multi-gestionnaires.

---

# 🧪 9. Tests & Validation

## 🔍 État actuel

Les validations sont actuellement réalisées principalement via des **tests manuels structurés**.

Les vérifications effectuées incluent :

- Tests manuels systématiques du scan et de l’agrégation multi-gestionnaires
- Validation des cas nominaux (fonctionnement attendu)
- Vérification du parsing texte basé sur la structure des colonnes
- Test du mécanisme de timeout des processus système
- Vérification du bon fonctionnement de la journalisation structurée

## 🎯 Objectifs à moyen terme

Le projet prévoit l’introduction progressive de tests automatisés afin d’améliorer la robustesse et la maintenabilité du code.

Les axes prévus incluent :

- Tests unitaires des services principaux
- Tests des cas limites (sortie vide, format inattendu, données partielles)
- Tests de gestion des erreurs et interruptions de processus
- Automatisation progressive des scénarios de test

---

# 🎨 10. Ressources UI

Le dossier `Ressources/` centralise les éléments visuels globaux de l'application.

L’objectif est de garantir une **cohérence graphique** et de faciliter
l’évolution de l’interface utilisateur.

## 🎯 Objectifs

- Garantir une cohérence visuelle dans l’ensemble de l’application
- Éviter les valeurs codées directement dans les vues
- Centraliser les styles et paramètres visuels
- Préparer un futur système de thèmes (clair / sombre)

## 🧩 Structure

```
Ressources/
│
├── Couleurs/
│ └── CouleursVigie.xaml
│
├── Styles/
│
├── Dimensions/
│
└── Themes/
```

## 📏 Règle importante

Les vues ne doivent **jamais contenir de valeurs visuelles codées en dur**
(couleurs, dimensions, styles).

Toutes les ressources doivent être référencées via le système de ressources XAML :

`{StaticResource NomDeRessource}`

Cette approche permet de :

- modifier facilement l’apparence globale de l’application
- maintenir une cohérence visuelle
- simplifier l’évolution future de l’interface

---

# 📦 11. Technologies Utilisées

| Élément                     | Technologie / Approche                                             |
|-----------------------------|--------------------------------------------------------------------|
| Langage principal           | C#                                                                 |
| Framework                   | .NET 8                                                             |
| Interface graphique         | WinUI 3                                                            |
| Architecture                | MVVM strict                                                        |
| Gestionnaires implémentés   | Winget (complet), Scoop et Chocolatey (simulation)                 |
| Support multi-gestionnaires | Actif (fusion et déduplication intégrées)                          |
| Versioning                  | Git (discipline de commits structurée)                             |
| Méthodologie                | Versionnement incrémental basé sur la consolidation progressive    |

---

# ⚙️ 12. Environnement de Développement

Le projet utilise un fichier `.editorconfig` versionné afin de garantir
une **cohérence de style et de formatage du code** sur l’ensemble du projet.

Ce fichier permet d’appliquer automatiquement des règles communes
à tous les contributeurs et aux différents environnements de développement.

## 🎯 Objectifs

- Maintenir un style de code homogène
- Éviter les différences de formatage entre les contributeurs
- Améliorer la lisibilité du code
- Réduire les modifications inutiles dans l’historique Git

## 📏 Règles principales

- Indentation standardisée (**4 espaces**)
- Accolades obligatoires en C#
- Surveillance de la nullabilité
- Conventions de nommage des champs privés (`_camelCase`)
- Nettoyage automatique des espaces superflus
- Organisation automatique des directives `using`

## 📌 Importance dans le projet

Le fichier `.editorconfig` fait partie intégrante de l’architecture technique
et contribue à la **stabilité et à la maintenabilité à long terme du projet**.

Toute contribution au projet doit respecter ces règles.

---

# 📚 13. Documentation

La documentation du projet Vigie est répartie en plusieurs fichiers
afin de séparer clairement les différents aspects du projet
(vision, architecture, développement et utilisation).

| Fichier                               | Rôle                                                  |
|---------------------------------------|-------------------------------------------------------|
| README.md                             | Présentation générale du projet                       |
| FEUILLE DE ROUTE – Vigie.md           | Vision stratégique et plan d’évolution du projet      |
| PATCH NOTES – VIGIE.md                | Historique technique et architectural des versions    |
| ARCHITECTURE – Vigie.md               | Standard interne de structuration du code             |
| GUIDE OFFICIEL DES COMMITS – VIGIE.md | Convention et discipline Git                          |
| GUIDE UTILISATEUR – VIGIE.md          | Documentation destinée aux utilisateurs               |
| TESTS – VIGIE.md                      | Stratégie de tests et validation du projet            |

***Toute évolution majeure du projet doit être accompagnée
d’une **mise à jour de la documentation correspondante**.***

---

# 🧭 14. Roadmap

La progression de Vigie suit une approche **par consolidation progressive** :
chaque version stabilise les fondations avant d’étendre les capacités du projet.

## 🔹 Version 0.x — Consolidation du moteur

- **0.1.0** : Fondations architecturales
- **0.2.0** : Extension multi-gestionnaires (normalisation, fusion, déduplication)
- **0.3.0** : Mise à jour contrôlée
- **0.4.0** : Sécurité renforcée et validation système
- **0.5.0** : Expérience utilisateur simplifiée (Mode Senior)
- **0.6.0** : Simulation des mises à jour (dry-run)
- **0.7.0** : Observabilité et suivi des opérations
- **0.8.0** : Support multi-gestionnaires avancé
- **0.9.0** : Configuration et personnalisation du moteur

## 🔹 Version 1.x — Maturité de l’application

- **1.0.0** : Stabilisation complète du moteur
- **1.5** : Refonte UX/UI complète

Objectif : rendre Vigie **stable, lisible et accessible à tous les utilisateurs.**

## 🔹 Version 2.x — Extension de l’écosystème

- **2.0.0** : Architecture long terme

Fonctionnalités envisagées :

- Synchronisation distante
- API interne
- Supervision multi-machines
- Extension entreprise
- Internationalisation de l’application

---

# 📊 15. État du Projet

Version actuelle : **0.3.0**

Statut :  
Préparation de la version **0.4.0 — Sécurité renforcée**

Architecture :  
Architecture stable, extensible et consolidée

Fonctionnalités principales :  

- Scan multi-gestionnaires consolidé  
- Moteur de mise à jour contrôlée fonctionnel  
- Fusion et normalisation multi-gestionnaires  
- Journalisation structurée des opérations  

Tests :  
Tests manuels structurés

Sécurité :  
Préparation du système de restauration avant mise à jour

Journalisation :  
Journalisation stabilisée (écriture propre, sans doublons)

| Version |       Statut      |
|-------- |-------------------|
| 0.1.0   | ✅ terminé        |
| 0.2.0   | ✅ terminé        |
| 0.3.0   | ✅ terminé        |
| 0.4.0   | 🔄 en préparation |

---

# 📜 16. Licence

Licence : **MIT**

Ce projet est distribué sous licence MIT.

Voir le fichier `LICENSE.md` pour plus de détails.

---

# 🧠 17. Philosophie Finale

Vigie n’est pas seulement un outil.

C’est :

- une démonstration d’architecture propre
- une discipline documentaire rigoureuse
- un projet pédagogique structuré
- un outil conçu pour évoluer durablement

Un projet solide ne s’accumule pas.  
Il se **consolide**.

Chaque version stabilise l’existant avant d’étendre ses capacités.

</div>
