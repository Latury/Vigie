<div align="center">

# 🧭 VIGIE

### Centre de maintenance logicielle intelligent

Application WinUI 3 (.NET 8) dédiée à la gestion, au contrôle et à la sécurisation des mises à jour logicielles sous Windows.

![Version](https://img.shields.io/badge/Version-0.1.0--dev-1E90FF?style=for-the-badge)
![Statut](https://img.shields.io/badge/Statut-En%20développement-FF8C00?style=for-the-badge)
![Licence](https://img.shields.io/badge/Licence-MIT-2E8B57?style=for-the-badge)

![.NET](https://img.shields.io/badge/.NET-8-512BD4?style=for-the-badge)
![WinUI](https://img.shields.io/badge/WinUI-3-0078D6?style=for-the-badge)
![Architecture](https://img.shields.io/badge/Architecture-MVVM-6A5ACD?style=for-the-badge)
![Plateforme](https://img.shields.io/badge/Plateforme-Windows-0078D6?style=for-the-badge)

Auteur : Flo Latury
Dernière mise à jour : —

</div>

---

# 📖 1. Présentation Générale

Vigie est un centre de maintenance logicielle moderne conçu pour Windows.

Son objectif est de :

- Scanner les logiciels installés
- Identifier les mises à jour disponibles
- Mettre à jour les applications de manière sécurisée
- Simplifier la maintenance pour les utilisateurs non techniques
- Fournir un cadre pédagogique structuré

Vigie n’est pas un simple utilitaire.
C’est un projet conçu pour être :

- Structuré
- Maintenable
- Évolutif
- Documenté
- Pédagogique

---

# 🎯 2. Objectif du Projet

Vigie vise à :

- Centraliser la gestion des mises à jour
- Supporter plusieurs gestionnaires de paquets
- Offrir un mode simplifié pour les personnes âgées
- Proposer un mode expert avancé
- Appliquer une architecture MVVM stricte
- Maintenir une discipline documentaire complète

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
- Parsing JSON sécurisé
- Discipline Git professionnelle
- Documentation technique exhaustive

---

# 🏗️ 4. Architecture

## 🧩 Organisation Générale

```
Vigie/
│
├── Application/
├── Services/
├── Modeles/
├── ViewModels/
├── Vues/
│
├── README.md
├── FEUILLE_DE_ROUTE.md
├── PATCH_NOTES.md
├── STANDARD_STRUCTURE_CODE.md
├── GUIDE_COMMITS.md
├── GUIDE_GITHUB_DESKTOP.md
├── TESTS.md
├── GUIDE_UTILISATEUR.md
├── LICENSE
```

## 🏗️ Principes d’Architecture

- MVVM strict
- Séparation claire des responsabilités
- Logique métier isolée des vues
- Abstraction via interfaces (IPackageManager)
- Services découplés et testables
- Journalisation centralisée
- Extensibilité progressive

---

# ✨ 5. Fonctionnalités

## ✅ Implémentées (Version en cours)

- Structure WinUI 3 initialisée
- Architecture MVVM en place
- Interface IPackageManager définie
- Implémentation WingetManager
- Scan winget avec sortie JSON
- Affichage liste des mises à jour

## 🔄 En cours

- Stabilisation parsing JSON
- Gestion erreurs robustes
- Journalisation avancée

## 📌 Prévues

- Mise à jour individuelle
- Mise à jour globale
- Création automatique point de restauration
- Mode Senior simplifié
- Mode Expert avancé
- Support Scoop, Chocolatey, pip, npm
- Historique des mises à jour
- Planification automatique

---

# 👴 6. Expérience Utilisateur

## Mode Senior

- Interface simplifiée
- Gros boutons
- Texte clair
- Aucun jargon technique
- Actions principales en un clic

## Mode Expert

- Logs détaillés
- Paramètres avancés
- Sélection des gestionnaires
- Mode silencieux
- Informations techniques visibles

Philosophie UX :

Lisibilité > Effets visuels
Clarté > Complexité
Feedback > Ambiguïté

---

# 🔒 7. Sécurité

Avant toute mise à jour globale :

- Création automatique d’un point de restauration système
- Confirmation utilisateur explicite
- Journalisation complète
- Gestion des erreurs détaillée
- Possibilité de relancer une opération échouée

⚠️ Vigie n’est pas destiné à un environnement critique sans validation approfondie.

---

# 🚀 8. Performance

- Exécution asynchrone des processus système
- Parsing JSON optimisé
- Réduction des appels redondants
- Priorité à la stabilité

Les optimisations avancées interviendront après stabilisation fonctionnelle.

---

# 🧪 9. Tests & Validation

## État actuel

- Tests manuels systématiques
- Validation des cas nominaux
- Vérification parsing JSON

## Objectifs

- Tests unitaires des services
- Tests parsing JSON
- Tests gestion erreurs
- Automatisation progressive

---

# 📦 10. Technologies Utilisées

| Élément                 | Technologie                |
| ----------------------- | -------------------------- |
| Langage principal       | C#                         |
| Framework               | .NET 8                     |
| Interface               | WinUI 3                    |
| Architecture            | MVVM strict                |
| Gestionnaires supportés | winget (priorité initiale) |
| Versioning              | Git                        |
| Méthodologie            | Version progressive        |

---

# 📚 11. Documentation

| Fichier                    | Rôle                                  |
| -------------------------- | ------------------------------------- |
| README.md                  | Présentation générale                 |
| FEUILLE_DE_ROUTE.md        | Vision stratégique                    |
| PATCH_NOTES.md             | Historique technique détaillé         |
| STANDARD_STRUCTURE_CODE.md | Standard obligatoire de structuration |
| GUIDE_COMMITS.md           | Convention stricte de commits         |

Toute évolution majeure doit être documentée.

---

# 🧭 12. Roadmap

## Version 0.x

- Fondations
- Stabilisation scan
- Mise à jour contrôlée
- Sécurisation

## Version 1.x

- Multi-gestionnaires
- Mode Senior complet
- Mode Expert avancé
- Packaging initial

## Version 2.x

- Planification automatique
- Historique détaillé
- Export rapports
- Optimisation avancée

Philosophie :

Croissance par consolidation.

---

# 📊 13. État du Projet

Version : 0.1.0-dev
Statut : Développement actif
Architecture : Stable
Fonctionnalités : En progression
Tests : Partiels
Sécurité : En implémentation

---

# 📜 14. Licence

Licence : MIT

Ce projet est distribué sous licence MIT.
Voir le fichier LICENSE pour plus de détails.

---

# 🧠 15. Philosophie Finale

Vigie n’est pas seulement un outil.

C’est :

- Une démonstration d’architecture propre
- Une discipline documentaire
- Un projet pédagogique structuré
- Un outil destiné à durer

Un projet solide ne s’accumule pas.
Il se consolide.

</div>
