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

- ✅ Création projet WinUI 3 (.NET 8)
- ✅ Mise en place structure dossiers conforme standard interne
- ✅ Implémentation MVVM strict
- ✅ Création interface IGestionnairePaquets (abstraction des gestionnaires)
- ✅ Implémentation GestionnaireWinget
- ✅ Scan winget avec parsing texte robuste
- ✅ Affichage liste simple des mises à jour
- ✅ Journalisation de base

## 🎨 UX initiale

- ✅ Page principale minimaliste
- ✅ Bouton Scanner
- ✅ Affichage liste logiciels
- ✅ Indicateur d’état

Objectif : fonctionnement minimal mais propre.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧱 5. Version 0.2.0 — Extension Architecturale Contrôlée

## 🎯 Objectif

Préparer officiellement le support multi-gestionnaires
et structurer l’architecture avancée.

- ✅ Ajout champ Source dans LogicielMiseAJour
- ✅ Début support second gestionnaire (Scoop ou Chocolatey)
- ✅ Fusion intelligente des résultats
- ✅ Tests manuels multi-sources
- ✅ Refactorisation contrôlée si nécessaire
- ✅ Stabilisation JournalService (suppression doublons lignes vides)
- ✅ Implémentation déduplication robuste basée sur ID normalisé
      (modification GestionnaireGlobal.cs)(préparation)
- ✅ Ajout propriété IdentifiantNormalise dans LogicielMiseAJour
      (Modeles/LogicielMiseAJour.cs)
- ✅ Introduction couche de normalisation multi-gestionnaires
      (création dossier Services/Normalisation)
- ✅ Séparation explicite Scan / Normalisation / Fusion
      (pipeline actif pour Winget)
- ✅ Consolidation complète de la résilience orchestrateur
      (try/catch global + validation anti-crash UI)

Aucune mise à jour automatique encore.

Priorité : extensibilité propre.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🔄 6. Version 0.3.0 — Mise à Jour Contrôlée

## 🎯 Objectif

Permettre la mise à jour sécurisée et maîtrisée des logiciels sélectionnés.

### 🧩 Fonctionnalités

- ✅ Journalisation détaillée des opérations
- ✅ Mise à jour globale stabilisée  (pipeline stable : scan - orchestration - statuts) ( les améliorations UX seront réalisées lors de la conception UI )
- ✅ Désactivation partielle de l’interface pendant opération
- ✅ Rafraîchissement automatique du scan après mise à jour réussie
- ✅ Support Scoop (simulé)
- ✅ Support Chocolatey (simulé)
- 🟡 Timeout configurable pour mise à jour ( certains packages peuvent bloquer )
- 🟡 Affichage source gestionnaire ( winget - scoop - choco dans la liste des logiciels )
- 🟡 Confirmation utilisateur (Le seul manque : UX plus riche possible )
- 🟡 Détection automatique des gestionnaires installés ( gestion PATH - logs UX )
- 🟡 Centralisation des ressources visuelles (dossier Ressources créé mais certaines valeurs sont encore codées en dur)
- 🟡 Préparation modèle Historique interne ( Nous avons : HistoriqueMiseAJour.cs Mais : pas de stockage - pas d'affichage - pas de persistance )
- 🟡 Feedback visuel par logiciel (statuts internes présents, reste affichage UI à améliorer)
- 🟡 Mise à jour interne du statut des logiciels pendant l’opération (statuts moteur implémentés, affichage UI à finaliser)
- 🔲 Mise à jour individuelle (aucune CheckBox - aucune sélection - mise à jour toujours globale - Décision : volontairement globale pour simplifier l’UX. )
- 🔲 Gestion élévation administrateur  (aucun appel UAC - aucun runas - aucun service élévation )
- 🔲 Rotation des logs (limite taille fichier journal)

Objectif : rendre la mise à jour contrôlée, compréhensible et traçable.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🛡️ 7. Version 0.4.0 — Sécurité Renforcée

## 🎯 Objectif

Renforcer la sécurité et la transparence des opérations système.

### 🔐 Sécurité système

- 🔲 Vérification de la connectivité réseau avant mise à jour
- 🔲 Création automatique point de restauration (stabilisation UX)
- 🔲 Affichage visuel du statut du point de restauration (date/heure, origine Vigie)
- 🔲 Gestion échec avec retry
- 🔲 Rapport détaillé d’erreurs
- 🔲 Séparation validation UX / validation métier
- 🔲 Vérification espace disque disponible avant mise à jour
- 🔲 Détection mise à jour nécessitant redémarrage ( Certaines mises à jour Windows - packages peuvent demander - Reboot required  Vigie pourrait afficher : Redémarrage recommandé )

### ⚙️ Paramètres liés à la sécurité

- 🔲 Options avancées liées aux points de restauration
- 🔲 Possibilité d’activer/désactiver la création automatique (Mode Expert uniquement)

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 👴 8. Version 0.5.0 — Mode Senior

## 🎯 Objectif

Rendre l’application accessible.

- 🔲 Barre de progression globale des mises à jour
- 🔲 Icônes visuelles des statuts et non des émojis ( ✔ Succès - ⚠ Échec - ⏳ En cours )
- 🔲 Amélioration UX des opérations de mise à jour (feedback visuel clair, progression, statut détaillé)
- 🔲 Interface simplifiée
- 🔲 Boutons larges
- 🔲 Texte clair
- 🔲 Suppression jargon technique
- 🔲 Tests ergonomiques simulés

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧠 9. Version 1.0.0 — Maturité Initiale

## 🎯 Objectif

Support multi-gestionnaires et mode avancé complet.

- 🔲 Import configuration Vigie pratique si l’utilisateur change de PC
- 🔲 Export configuration Vigie pratique si l’utilisateur change de PC ( Exemple : vigie-config.json - Pour sauvegarder : gestionnaires activés - paramètres - mode expert )
- 🔲 Activation réelle Scoop
- 🔲 Activation réelle Chocolatey
- 🔲 Support pip
- 🔲 Support npm
- 🔲 Paramètres avancés
- 🔲 Mode Expert complet
- 🔲 Affichage détaillé des sources en Mode Expert
- 🔲 Fusion intelligente des logiciels en Mode Senior
- 🔲 Option utilisateur pour activer/désactiver le Mode Expert
- 🔲 Packaging application
- 🔲 Documentation complète
- 🔲 Implémentation niveaux de journalisation configurables (Debug - Info - Warning - Erreur)
- 🔲 Intégration configuration niveau via Paramètres utilisateur

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🏗️ 10. Version 2.0.0 — Exploitation Complète

## 🎯 Objectif

Faire de Vigie un outil réellement exploitable.

- 🔲 Notifications système après mise à jour utile si la mise à jour est planifiée. ( Exemple : 5 logiciels mis à jour - 2 erreurs détectées )
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

| Version   | Statut          | Progression estimée                                                                   |
| --------- | --------------- | --------------------------------------------------------------------------------------|
| 0.1.0-dev | 🟢 Terminé      |  ~100 %      Fondations consolidées                                                   |
| 0.2.0-dev | 🟢 Consolidée   |  ~100 % Extension maîtrisée et résilience validée                                     |
| 0.3.0-dev | 🟡 En cours     |  ~ 85 % Mise à jour globale stable, sélection individuelle et élévation à implémenter |
| 0.4.0     | ⚪ À faire      | 0 %                                                                                   |
| 0.5.0     | ⚪ À faire      | 0 %                                                                                   |
| 1.0.0     | ⚪ À faire      | 0 %                                                                                   |

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎓 Apprentissage Visé

Ce projet vise à développer :

- Architecture modulaire avancée
- Abstraction propre des services
- Gestion processus système
- Parsing robuste des sorties console
- Gestion erreurs robuste
- Discipline Git professionnelle
- Documentation rigoureuse
- Gestion de l’expérience utilisateur dans les outils système

Objectif :

Construire un projet compréhensible, maintenable et exploitable sur plusieurs années.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧭 Philosophie Finale

Vigie ne doit pas croître par accumulation.
Il doit croître par consolidation.

Stabilité avant expansion.
Architecture avant fonctionnalités.
Clarté avant complexité.
Les fonctionnalités UI ne doivent jamais compromettre la stabilité.
