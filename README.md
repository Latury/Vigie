<div align="center">

# 🧭 VIGIE

### Centre de maintenance logicielle intelligent

Application WinUI 3 (.NET 8) dédiée à la gestion, au contrôle et à la sécurisation des mises à jour logicielles sous Windows.

![Version](https://img.shields.io/badge/Version-0.2.0--dev-1E90FF?style=for-the-badge)
![Statut](https://img.shields.io/badge/Statut-Extension%20architecturale-FF8C00?style=for-the-badge)
![Licence](https://img.shields.io/badge/Licence-MIT-2E8B57?style=for-the-badge)

![.NET](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge)
![WinUI](https://img.shields.io/badge/WinUI-3-0078D6?style=for-the-badge)
![Architecture](https://img.shields.io/badge/Architecture-MVVM-6A5ACD?style=for-the-badge)
![Plateforme](https://img.shields.io/badge/Plateforme-Windows-0078D6?style=for-the-badge)

Auteur : Flo Latury
Dernière mise à jour : 28 février 2026

</div>

---

# 📖 1. Présentation Générale

Vigie est un centre de maintenance logicielle moderne conçu pour Windows.

Son objectif est de :

- Scanner les logiciels installés
- Identifier les mises à jour disponibles
- Préparer la mise à jour sécurisée des applications
- Simplifier la maintenance pour les utilisateurs non techniques
- Fournir un cadre pédagogique structuré

Actuellement, Vigie se concentre sur la détection fiable des mises à jour
et la consolidation de son architecture interne.

Vigie n’est pas un simple utilitaire.
C’est un projet conçu pour être :

- Structuré
- Maintenable
- Évolutif
- Documenté
- Pédagogique

---

# 🎯 2. Objectif du Projet

Vigie vise progressivement à :

- Centraliser la gestion des mises à jour logicielles
- Supporter plusieurs gestionnaires de paquets
- Offrir un mode simplifié pour les personnes âgées (Mode Senior)
- Proposer un mode expert avancé (Mode Expert)
- Appliquer une architecture MVVM stricte
- Maintenir une discipline documentaire complète

Ces objectifs sont atteints par étapes, selon une progression maîtrisée
définie dans la feuille de route officielle du projet.

---

# 🧠 3. Vision & Philosophie

## 📌 Vision

Construire un outil fiable, sécurisé et évolutif, capable de durer dans le temps.

## 🧭 Principes Directeurs

- Architecture avant fonctionnalités
- Lisibilité avant optimisation
- Sécurité avant automatisation
- Documentation avant rapidité
- Consolidation avant expansion

## 🎓 Dimension pédagogique

Le projet sert également de support d’apprentissage :

- Structuration avancée d’un projet WinUI 3
- Application rigoureuse du MVVM
- Gestion de processus système
- Parsing robuste de sorties console (normalisation et analyse)
- Discipline Git professionnelle
- Documentation technique exhaustive

---

# 🏗️ 4. Architecture

## 🧩 Organisation Générale

```
Vigie/
│
├── Services/
│ ├── Gestionnaires/
│ └── Interfaces/
│
├── Modeles/
├── JournalEvenements/
├── Infrastructure/
├── VueModeles/
├── Vues/
│
├── Assets/
├── Properties/
│
├── README.md
├── FEUILLE DE ROUTE – Vigie.md
├── PATCH NOTES – VIGIE.md
├── STANDARD_STRUCTURE_CODE - Vigie.md
├── GUIDE OFFICIEL DES COMMITS – VIGIE.md
├── GUIDE UTILISATEUR – VIGIE.md
├── TESTS – VIGIE.md
├── LICENSE.md
```

## 🏗️ Principes d’Architecture

- MVVM strict
- Séparation claire des responsabilités
- Logique métier isolée des vues
- Abstraction via IGestionnairePaquets
- Implémentations concrètes découplées (GestionnaireWinget, futur Scoop, etc.)
- Services découplés et testables
- Journalisation centralisée
- Extensibilité progressive
- Orchestrateur central (GestionnaireGlobal)
- Préparation au support multi-gestionnaires

---

# ✨ 5. Fonctionnalités

## ✅ Implémentées (0.1.0-dev consolidé)

- Structure WinUI 3 initialisée
- Architecture MVVM stricte
- Interface générique IGestionnairePaquets
- Implémentation GestionnaireWinget
- Orchestrateur central (GestionnaireGlobal)
- Scan winget avec parsing texte robuste basé sur structure colonnes
- Nettoyage et normalisation des données
- Gestion timeout (30 secondes)
- Journalisation structurée des événements
- Affichage liste simple des mises à jour

## 🔄 En cours (0.2.0-dev)

- Introduction champ Source dans le modèle
- Préparation support multi-gestionnaires
- Déduplication robuste basée sur identifiant normalisé
- Introduction couche de normalisation multi-sources
- Séparation Scan / Normalisation / Fusion
- Préparation infrastructure paramètres utilisateur
- Préparation modèle Historique interne (non persistant)

## 📌 Prévues (versions ultérieures)

- Mise à jour individuelle
- Mise à jour globale sécurisée
- Création automatique point de restauration
- Mode Senior simplifié
- Mode Expert avancé
- Support Scoop, Chocolatey, pip, npm
- Historique persistant des mises à jour
- Planification automatique
- Niveaux de journalisation configurables

---

# 👴 6. Expérience Utilisateur

L’expérience utilisateur de Vigie est conçue pour évoluer
selon deux modes distincts, prévus dans la feuille de route.

## 🟡 Mode Senior (prévu)

Objectif : simplifier au maximum l’usage.

- Interface simplifiée
- Gros boutons
- Texte clair
- Aucun jargon technique
- Actions principales en un clic

Implémentation prévue en version 0.5.0.

---

## 🟡 Mode Expert (prévu)

Objectif : offrir un contrôle avancé.

- Logs détaillés
- Paramètres avancés
- Sélection des gestionnaires
- Informations techniques visibles
- Configuration avancée

Implémentation progressive jusqu’à la version 1.0.0.

---

## 🧭 Philosophie UX

Lisibilité > Effets visuels  
Clarté > Complexité  
Feedback > Ambiguïté

---

# 🔒 7. Sécurité

La version actuelle de Vigie (0.2.0-dev) se limite à la détection
des mises à jour disponibles.

Aucune modification système n’est effectuée.

---

## 🔮 Stratégie de sécurité prévue (versions ultérieures)

Avant toute mise à jour globale, les mécanismes suivants seront appliqués :

- Création automatique d’un point de restauration système
- Confirmation utilisateur explicite
- Journalisation complète des opérations
- Gestion détaillée des erreurs
- Possibilité de relancer une opération échouée

---

⚠️ Vigie n’est pas destiné à un environnement critique sans validation approfondie.

---

# 🚀 8. Performance

- Exécution asynchrone non bloquante des processus système
- Gestion d’un timeout contrôlé (30 secondes)
- Parsing texte robuste basé sur structure colonnes winget
- Mesure précise de la durée du scan (Stopwatch)
- Priorité donnée à la stabilité et à la fiabilité

Les optimisations avancées interviendront après consolidation multi-gestionnaires.

---

# 🧪 9. Tests & Validation

## État actuel

- Tests manuels systématiques du scan winget
- Validation des cas nominaux
- Vérification du parsing texte basé sur structure colonnes
- Test du mécanisme de timeout
- Vérification de la journalisation structurée

## Objectifs

- Tests unitaires des services
- Tests des cas limites (sortie vide, format inattendu)
- Tests gestion erreurs et interruptions processus
- Automatisation progressive des tests

---

# 📦 10. Technologies Utilisées

| Élément                     | Technologie / Approche                      |
|-----------------------------|---------------------------------------------|
| Langage principal           | C#                                          |
| Framework                   | .NET 8                                      |
| Interface                   | WinUI 3                                     |
| Architecture                | MVVM strict                                 |
| Gestionnaire implémenté     | winget                                      |
| Support multi-gestionnaires | Préparation architecturale en cours         |
| Versioning                  | Git (discipline commits structurée)         |
| Méthodologie                | Versionnement incrémental par consolidation |

---

# ⚙️ 11. Environnement de Développement

Le projet utilise un fichier `.editorconfig` versionné afin de garantir
une cohérence de style et de formatage sur l’ensemble du code.

Objectifs :

- Indentation standardisée (4 espaces)
- Accolades obligatoires en C#
- Surveillance nullabilité
- Conventions de nommage des champs privés (_camelCase)
- Nettoyage automatique des espaces superflus
- Organisation automatique des directives using

Ce fichier fait partie intégrante de l’architecture technique
et contribue à la stabilité long terme du projet.

Toute contribution doit respecter ces règles.

---

# 📚 12. Documentation

| Fichier                                  | Rôle                                                |
|------------------------------------------|-----------------------------------------------------|
| README.md                                | Présentation générale du projet                     |
| FEUILLE DE ROUTE – Vigie.md              | Vision stratégique et plan d’évolution              |
| PATCH NOTES – VIGIE.md                   | Historique technique et architectural détaillé      |
| STANDARD_STRUCTURE_CODE - Vigie.md       | Standard interne de structuration du code           |
| GUIDE OFFICIEL DES COMMITS – VIGIE.md    | Convention et discipline Git                        |
| GUIDE UTILISATEUR – VIGIE.md             | Documentation destinée aux utilisateurs             |
| TESTS – VIGIE.md                         | Stratégie et suivi des tests                        |

Toute évolution majeure doit être documentée.

---

# 🧭 13. Roadmap

## 🔹 Version 0.x — Consolidation

- 0.1.0 : Fondations architecturales
- 0.2.0 : Extension multi-gestionnaires (normalisation, fusion, déduplication)
- 0.3.0 : Mise à jour contrôlée
- 0.4.0 : Sécurité renforcée
- 0.5.0 : Introduction Mode Senior

---

## 🔹 Version 1.0.0 — Maturité initiale

- Support multi-gestionnaires complet
- Mode Expert avancé
- Paramètres utilisateur structurés
- Niveaux de journalisation configurables
- Packaging initial

---

## 🔹 Version 2.x — Exploitation complète

- Planification automatique
- Historique persistant
- Export rapports
- Optimisations avancées
- Tests automatisés

---

Philosophie :

Croissance par consolidation.

---

# 📊 14. État du Projet

Version : 0.2.0-dev  
Statut : Extension architecturale en cours  
Architecture : Stable et extensible  
Fonctionnalités : Détection consolidée, extension en cours  
Tests : Manuels structurés  
Sécurité : Détection uniquement (aucune action système)

---

# 📜 15. Licence

Licence : MIT

Ce projet est distribué sous licence MIT.

Voir le fichier LICENSE.md pour plus de détails.

---

# 🧠 16. Philosophie Finale

Vigie n’est pas seulement un outil.

C’est :

- Une démonstration d’architecture propre
- Une discipline documentaire rigoureuse
- Un projet pédagogique structuré
- Un outil conçu pour évoluer durablement

Un projet solide ne s’accumule pas.
Il se consolide.

Chaque version stabilise l’existant avant d’étendre ses capacités.

</div>
