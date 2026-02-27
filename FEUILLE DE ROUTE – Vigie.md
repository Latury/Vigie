# 🗺️ FEUILLE DE ROUTE – Vigie

Centre de maintenance logicielle intelligent

⚠️ Ce document définit la trajectoire officielle du projet Vigie.
Il constitue une référence stratégique et évolutive.

Il peut être ajusté selon :

- Les contraintes techniques réelles
- Les décisions architecturales prises
- Les apprentissages réalisés
- Les priorités de stabilité

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎯 1. Vision Générale

## 📌 Objectif global

Construire une application WinUI 3 (.NET 8) permettant :

- Le scan des logiciels installés
- L’identification des mises à jour disponibles
- La mise à jour sécurisée via gestionnaires de paquets
- Une utilisation simplifiée pour les personnes âgées
- Une architecture propre, maintenable et évolutive

L’objectif n’est pas d’ajouter rapidement des fonctionnalités,
mais de bâtir un socle solide et durable.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧭 2. Philosophie de Développement

- Progression par versions maîtrisées
- Stabilisation avant expansion
- Architecture avant fonctionnalités
- Documentation obligatoire à chaque étape
- Refactorisation acceptée et assumée
- Priorité à la lisibilité et à la sécurité

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# ⚠️ 3. Nature Évolutive du Document

Cette feuille de route :

- N’est pas contractuelle
- N’est pas figée
- Peut évoluer selon les contraintes techniques
- Peut être ajustée en cas de refactorisation majeure

La cohérence est prioritaire sur la rigidité.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🚀 4. Version 0.1.0-dev — Fondations

## 🎯 Objectif stratégique

Mettre en place la base architecturale stable.

## 🏗️ Infrastructure

- 🔲 Création projet WinUI 3 (.NET 8)
- 🔲 Mise en place structure dossiers conforme standard interne
- 🔲 Implémentation MVVM strict
- 🔲 Création interface GestionnaireWinget
- 🔲 Implémentation GestionnaireWinget
- 🔲 Scan winget avec sortie JSON
- 🔲 Affichage liste simple des mises à jour
- 🔲 Journalisation de base

## 🎨 UX initiale

- 🔲 Page principale minimaliste
- 🔲 Bouton Scanner
- 🔲 Affichage liste logiciels
- 🔲 Indicateur d’état

Objectif : fonctionnement minimal mais propre.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧱 5. Version 0.2.0 — Stabilisation du Scan

## 🎯 Objectif

Rendre le scan robuste et fiable.

- 🔲 Gestion erreurs winget
- 🔲 Gestion timeout
- 🔲 Parsing JSON sécurisé
- 🔲 Logs détaillés
- 🔲 Tests manuels exhaustifs
- 🔲 Refactorisation si nécessaire

Aucune mise à jour automatique encore.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🔄 6. Version 0.3.0 — Mise à Jour Contrôlée

## 🎯 Objectif

Permettre la mise à jour sécurisée.

- 🔲 Mise à jour individuelle
- 🔲 Mise à jour globale
- 🔲 Confirmation utilisateur
- 🔲 Gestion élévation administrateur
- 🔲 Journalisation complète

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🛡️ 7. Version 0.4.0 — Sécurité Renforcée

## 🎯 Objectif

Sécuriser le processus global.

- 🔲 Création automatique point de restauration
- 🔲 Gestion échec avec retry
- 🔲 Rapport détaillé d’erreurs
- 🔲 Séparation validation UX / validation métier

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 👴 8. Version 0.5.0 — Mode Senior

## 🎯 Objectif

Rendre l’application accessible.

- 🔲 Interface simplifiée
- 🔲 Boutons larges
- 🔲 Texte clair
- 🔲 Suppression jargon technique
- 🔲 Tests ergonomiques simulés

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧠 9. Version 1.0.0 — Maturité Initiale

## 🎯 Objectif

Support multi-gestionnaires.

- 🔲 Support Scoop
- 🔲 Support Chocolatey
- 🔲 Support pip
- 🔲 Support npm
- 🔲 Paramètres avancés
- 🔲 Mode Expert complet
- 🔲 Packaging application
- 🔲 Documentation complète

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🏗️ 10. Version 2.0.0 — Exploitation Complète

## 🎯 Objectif

Faire de Vigie un outil réellement exploitable.

- 🔲 Planification automatique mises à jour
- 🔲 Rapport synthétique santé système
- 🔲 Historique des mises à jour
- 🔲 Export rapports
- 🔲 Optimisations performance
- 🔲 Tests unitaires automatisés

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🌐 11. Version 3.0.0 — Vision Long Terme

## 🎯 Exploration possible

- 🔲 Synchronisation distante
- 🔲 API interne
- 🔲 Supervision multi-machines
- 🔲 Extension entreprise

Uniquement si l’architecture le permet.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 📊 12. Suivi Global

| Version   | Statut      | Progression estimée |
| --------- | ----------- | ------------------- |
| 0.1.0-dev | 🔵 En cours | Fondations          |
| 0.2.0     | ⚪ À faire  | 0 %                 |
| 0.3.0     | ⚪ À faire  | 0 %                 |
| 0.4.0     | ⚪ À faire  | 0 %                 |
| 0.5.0     | ⚪ À faire  | 0 %                 |
| 1.0.0     | ⚪ À faire  | 0 %                 |

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎓 Apprentissage Visé

Ce projet vise à développer :

- Architecture modulaire avancée
- Abstraction propre des services
- Gestion processus système
- Parsing JSON sécurisé
- Gestion erreurs robuste
- Discipline Git professionnelle
- Documentation rigoureuse

Objectif :

Construire un projet compréhensible, maintenable et exploitable sur plusieurs années.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧭 Philosophie Finale

Vigie ne doit pas croître par accumulation.
Il doit croître par consolidation.

Stabilité avant expansion.
Architecture avant fonctionnalités.
Clarté avant complexité.
