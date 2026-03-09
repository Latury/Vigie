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

# 2. 🧩 Portée du projet

Vigie vise à devenir un centre de maintenance logicielle simple et sécurisé.

Le projet ne cherche pas à remplacer les gestionnaires de paquets existants,
mais à offrir une couche de supervision et de simplification.

Les gestionnaires de paquets restent responsables de :

- l’installation des logiciels
- la distribution des mises à jour
- la gestion des dépendances

Vigie agit comme :

un **orchestrateur intelligent et sécurisé**.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧭 3. Philosophie de Développement

- Progression par versions maîtrisées
- Stabilisation avant expansion
- Architecture avant fonctionnalités
- Documentation obligatoire à chaque étape
- Refactorisation acceptée et assumée
- Priorité à la lisibilité et à la sécurité

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# ⚠️ 4. Nature Évolutive du Document

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
- ✅ Mise à jour individuelle ( sélection implémentée - UX encore simple )
- ✅ Centralisation des ressources visuelles
- ✅ Détection automatique des gestionnaires installés
- ✅ Timeout de sécurité implémenté pour les mises à jour afin d’éviter les blocages de packages.( Configuration statique actuelle 10 minutes.)
- ✅ Préparation modèle Historique interne ( Persistance prévue dans une autre version - Interface utilisateur prévue dans une autre version )
- ✅ Rotation automatique des logs = journaux ( création d’archives lorsque le fichier vigie.log dépasse la taille maximale autorisée)
- ✅ Simulation de l’élévation administrateur ( comportement UAC simulé afin de tester le pipeline interne,l’implémentation réelle sera réalisée lors de l’activation des gestionnaires de paquets). 

Objectif : rendre la mise à jour contrôlée, compréhensible et traçable.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🛡️ 7. Version 0.4.0 — Sécurité Renforcée + UX minimale

## 🎯 Objectif

Sécuriser le moteur de mise à jour **tout en donnant un minimum de visibilité à l’utilisateur.**

### 🔐 Sécurité système

Fonctions garantissant que **les opérations système restent sûres** avant l’exécution des mises à jour.

**Validation de l’environnement système**

- 🔲 Vérification de la présence du gestionnaire de paquets avant exécution
- 🔲 Vérification des privilèges administrateur avant mise à jour
- 🔲 Vérification de la connectivité réseau avant mise à jour
- 🔲 Vérification de l’espace disque disponible avant mise à jour

**Validation de l’environnement système avant mise à jour pour éviter les conflits et les erreurs critiques.**

- 🔲 Création automatique d’un point de restauration (UI simple pour l’instant)
- 🔲 Détection des mises à jour nécessitant un redémarrage

---

### ♻️ Résilience des opérations

Fonctions permettant de **gérer les erreurs et éviter les blocages pendant les mises à jour.**

- 🔲 Gestion des échecs avec retry automatique (UI simple pour l’instant)
- 🔲 Rapport détaillé d’erreurs

---

### 🧪 Pipeline de validation

Implémentation d’un **mécanisme centralisé de validation avant l’exécution des mises à jour.**

- 🔲 Implémentation d’un pipeline de validation avant mise à jour
- 🔲 Blocage automatique de la mise à jour si une validation critique échoue
- 🔲 Classification des validations système (Critique / Avertissement / Information)
- 🔲 Vérification centralisée de l’environnement système

---

### 📜 Journalisation de sécurité

Fonctions permettant de **tracer les événements critiques liés à la sécurité et aux validations système.**

- 🔲 Journalisation des validations système
- 🔲 Journalisation de la création des points de restauration
- 🔲 Journalisation des tentatives de récupération (retry)
- 🔲 Journalisation des conditions empêchant une mise à jour
- 🔲 Journalisation des mises à jour nécessitant un redémarrage

---

### 👁️ Retour utilisateur minimal (UX)

Fonctions donnant **une compréhension simple de l’état du système, sans interface complexe.**

- 🔲 Mise en évidence de l’action recommandée selon l’état du système
- 🔲 Adaptation automatique de l’action principale
- 🔲 Amélioration du feedback lors des opérations longues

### 💡 Pourquoi cette structure est intéressante :

**Sécurité** → ***protège le système***

**Résilience** → ***protège l’exécution***

**UX minimale** → ***protège l’utilisateur contre l’incompréhension***

**Autrement dit:**

***Sécurité → Résilience → Compréhension utilisateur***

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 👴 8. Version 0.5.0 — Mode Senior ( UX fonctionnelle )

## 🎯 Objectif

Rendre l’application **compréhensible et utilisable sans connaissance technique.**

### 📊 Vue globale du système

Fonctions permettant à l’utilisateur de comprendre rapidement l’état général du système.

- 🔲 Carte **"État du système"** affichant un résumé global clair

---

### ⏱️ Suivi des opérations

Fonctions permettant de **suivre l’avancement des mises à jour et l’état des logiciels.**

- 🔲 Barre de progression globale des mises à jour
- 🟡 Feedback visuel par logiciel pendant l’opération
- 🟡 Mise à jour interne du statut des logiciels pendant l’opération

### 🤝 Interaction utilisateur

Fonctions liées aux **actions et décisions de l’utilisateur.**

- 🟡 Confirmation utilisateur améliorée (UI simple pour l’instant)

### 🔎 Navigation et lisibilité des données

Fonctions permettant de **parcourir facilement la liste des logiciels.**

- 🔲 Tri des logiciels dans la liste (nom / source / statut)
- 🔲 Recherche dans la liste des logiciels
- 🟡 Affichage de la source du gestionnaire dans la liste des logiciels

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🔎 9. Version 0.6.0 — Simulation et anticipation

## 🎯 Objectif

Permettre à l’utilisateur de **comprendre ce qui va se passer avant de lancer les mises à jour.**

Cette version introduit un **mode simulation (dry-run)** permettant d’analyser les opérations sans les exécuter.

### 📦 Analyse prévisionnelle des mises à jour

Fonctions permettant d’identifier **les logiciels qui seront concernés par l’opération.**

- 🔲 Liste des logiciels concernés (rapport simulation)
- 🔲 Gestionnaire utilisé pour chaque logiciel (rapport simulation)

---

### ⚠️ Évaluation des impacts système

Fonctions permettant d’anticiper **les conséquences potentielles des mises à jour.**

- 🔲 Indication des redémarrages potentiels (rapport simulation)

---

### 📊 Estimation des ressources nécessaires

Fonctions permettant d’évaluer **les ressources qui seront utilisées pendant l’opération.**

Fonctions **backend** (le moteur invisible qui fait fonctionner l'application) de simulation :

- 🔲 Estimation du volume de téléchargement (rapport simulation)

---

### 🧪 Mode simulation (dry-run)

Le mode simulation permet de **reproduire le pipeline de mise à jour sans exécution réelle.**

Fonctions backend du moteur de simulation :

- 🔲 Analyse prévisionnelle des mises à jour
- 🔲 Simulation du pipeline de mise à jour
- 🔲 Détection des opérations critiques avant exécution
- 🔲 Estimation des impacts potentiels

**Le mode simulation permet ainsi de:**

***- 1 analyser les mises à jour disponibles***

***- 2 simuler le pipeline d’exécution***

***- 3 détecter les opérations critiques***

***- 4 générer un rapport prévisionnel détaillé***

***sans exécuter réellement les mises à jour.***

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 📡 10. Version 0.7.0 — Observabilité et suivi

## 🎯 Objectif

Donner de la **visibilité sur les opérations réalisées par Vigie dans le temps**
et permettre à l’utilisateur de **comprendre l’état de son système après les mises à jour.**

Cette version introduit une **couche d’observabilité et d’audit des opérations.**

---

### 🔔 Notifications système

Fonctions permettant d’informer l’utilisateur **après l’exécution des opérations.**

- 🔲 Notifications système après mise à jour (exemple : "5 logiciels mis à jour — 2 erreurs détectées")

---

### 🧾 Historique et audit des opérations

Fonctions permettant de **consulter les actions réalisées par Vigie.**

- 🔲 Historique des mises à jour
- 🔲 Persistance de l’historique des mises à jour
- 🔲 Conservation de l’historique après redémarrage de l’application

---

### 📊 Rapports et analyse du système

Fonctions permettant d’obtenir **une vue synthétique de l’état du système.**

- 🔲 Rapport synthétique santé système
- 🔲 Export des rapports

---

### 📜 Gestion et conservation des journaux

Fonctions permettant de **contrôler la conservation et l’organisation des fichiers de journalisation.**

- 🔲 Configuration de la conservation des journaux

---

### 💡 Logique d’observabilité

Ces blocs correspondent aux **trois horizons du temps** dans l’observabilité des systèmes :

***Notification  → immédiat***
***Historique    → passé***
***Rapport       → analyse globale***

**Autrement dit:**

***ce qui vient de se passer***
***ce qui s'est passé***
***ce que cela signifie pour le système***

C’est une logique très utilisée dans les outils d’administration système.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧩 11. Version 0.8.0 — Moteur multi-gestionnaires avancé

## 🎯 Objectif

Étendre le moteur de mise à jour afin de **supporter plusieurs gestionnaires de paquets réels et améliorer la détection automatique de l’environnement logiciel.**

Cette version consolide le **cœur multi-gestionnaires de Vigie.**

---

### 📦 Support des gestionnaires de paquets

Activation réelle des gestionnaires supplémentaires pris en charge par Vigie.

- 🔲 Activation réelle Scoop
- 🔲 Activation réelle Chocolatey
- 🔲 Support pip
- 🔲 Support npm

---

### 🔎 Détection des gestionnaires

Fonctions permettant de **détecter automatiquement les gestionnaires disponibles sur le système.**

- 🔲 Analyse robuste de la disponibilité des gestionnaires de paquets
- 🔲 Vérification explicite de la présence des gestionnaires dans le PATH système
- 🔲 Mise en cache des résultats de détection des gestionnaires

---

### 📜 Journalisation des gestionnaires

Fonctions permettant de **tracer le processus de détection et d’utilisation des gestionnaires.**

- 🔲 Journalisation détaillée du processus de détection des gestionnaires

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# ⚙️ 12. Version 0.9.0 — Configuration et personnalisation

## 🎯 Objectif

Introduire un **système de configuration avancé** permettant à l’utilisateur de personnaliser le comportement du moteur de mise à jour et de la journalisation.

Cette version améliore la flexibilité et **la configurabilité de Vigie.**

---

### 🧩 Configuration utilisateur

Fonctions permettant de **sauvegarder et restaurer la configuration de Vigie.**

- 🔲 Import configuration Vigie
- 🔲 Export configuration Vigie

---

### ⚙️ Paramètres du moteur de mise à jour

Fonctions permettant de **contrôler le comportement interne du moteur.**

- 🔲 Configuration utilisateur du timeout des mises à jour
- 🔲 Définition d’une durée maximale d’exécution pour éviter le blocage des gestionnaires

---

### 📜 Journalisation avancée

Fonctions permettant d’adapter **le niveau de détail des journaux techniques.**

- 🔲 Implémentation de niveaux de journalisation configurables
- 🔲 Ajout des niveaux Debug
- 🔲 Ajout des niveaux Info
- 🔲 Ajout des niveaux Warning
- 🔲 Ajout des niveaux Erreur
- 🔲 Adaptation de la quantité d’informations écrites dans les journaux selon le niveau choisi
- 🔲 Filtrage des messages de journalisation selon le niveau configuré

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧠 13. Version 1.0.0 — Maturité du moteur

## 🎯 Objectif

Atteindre une **version stable et robuste du moteur Vigie,** prête pour une utilisation quotidienne.

Cette version finalise les fondations techniques et la stabilité de l’application.

---

### 🏗️ Architecture interne

Fonctions visant à **structurer et stabiliser le cœur de l’application.**

- 🔲 Formalisation des états principaux de l’application
- 🔲 Centralisation de la gestion des états dans le ViewModel

---

### 🔐 Élévation système

Fonctions permettant d’exécuter les opérations nécessitant **des privilèges administrateur.**

- 🔲 Implémentation réelle de l’élévation administrateur (UAC Windows)

---

### 🤖 Automatisation

Fonctions permettant **l’exécution automatique des mises à jour.**

- 🔲 Planification automatique des mises à jour

---

### 🧪 Qualité et stabilité

Fonctions permettant d’améliorer **la robustesse et la maintenabilité du projet.**

- 🔲 Optimisations des performances
- 🔲 Implémentation de tests unitaires automatisés

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎨 14. Version 1.5 — Refonte UX/UI complète

## 🎯 Objectif

Repenser l’interface de Vigie afin de **rendre l’outil clair, lisible et ergonomique,** tout en tirant parti de la maturité du moteur.

Cette version introduit une **conception UX réfléchie,** basée sur l’usage réel de l’application.

---

### 🧭 Philosophie de la refonte

L’interface doit :

rendre l’état du système **immédiatement compréhensible**

guider l’utilisateur **vers l’action recommandée**

afficher clairement **les opérations critiques**

rester utilisable par un **utilisateur non technique**

Deux modes d’utilisation seront pris en compte :

**Mode Senior** → ***interface simplifiée***

**Mode Expert** → ***informations techniques détaillées***

---

### 🧱 Structure de l’écran principal

Refonte de l’organisation générale de l’interface principale.

- 🔲 Page principale minimaliste
- 🔲 Bouton Scanner
- 🔲 Affichage de la liste des logiciels
- 🔲 Affichage simple des mises à jour disponibles
- 🔲 Indicateur d’état du système
- 🔲 Désactivation partielle de l’interface pendant une opération

Objectif :

Créer une interface **simple, lisible et orientée action,** permettant de comprendre rapidement la situation du système.

---

### 🎨 Amélioration visuelle des statuts

Remplacement des émojis par une **iconographie cohérente et lisible.**

- 🔲 Icônes visuelles des statuts
- 🔲 Harmonisation visuelle des états système
- 🔲 Codage couleur des opérations (succès / avertissement / erreur)

---

### 👴 Mode Senior

Interface simplifiée destinée à rendre l’application **accessible sans connaissance technique.**

- 🔲 Interface simplifiée
- 🔲 Boutons larges
- 🔲 Messages clairs et non techniques
- 🔲 Mise en avant de l’action principale recommandée

---

### 🧠 Mode Expert

Interface permettant d’accéder à **des informations techniques détaillées.**

- 🔲 Affichage détaillé des sources des gestionnaires
- 🔲 Activation / désactivation du Mode Expert
- 🔲 Accès aux paramètres avancés

---

### 🔄 Visualisation des opérations de mise à jour

Améliorer la compréhension et le suivi des opérations réalisées par Vigie.

- 🔲 Barre de progression globale des mises à jour
- 🔲 Feedback visuel par logiciel pendant l’opération
- 🔲 Mise à jour interne du statut des logiciels pendant l’opération
- 🔲 Amélioration du feedback lors des opérations longues

---

### 📦 Interaction avec la liste des logiciels

Améliorer la manipulation et la lisibilité de la liste des logiciels.

- 🔲 Tri des logiciels dans la liste
- 🔲 Recherche dans la liste des logiciels
- 🔲 Affichage de la source du gestionnaire dans la liste
- 🔲 Mise à jour individuelle des logiciels (sélection améliorée)

---

### 🔎 Mode simulation (rapport prévisionnel)

Interface permettant d’anticiper les mises à jour avant exécution.

- 🔲 Liste des logiciels concernés (rapport simulation)
- 🔲 Gestionnaire utilisé pour chaque logiciel (rapport simulation)
- 🔲 Indication des redémarrages potentiels (rapport simulation)
- 🔲 Estimation du volume de téléchargement (rapport simulation)

---

### 📡 Observabilité et suivi du système

Permettre à l’utilisateur de comprendre ce qui s’est passé dans le système.

- 🔲 Notifications système après mise à jour
- 🔲 Rapport synthétique santé système
- 🔲 Historique des mises à jour
- 🔲 Export des rapports

---

### 🛡️ Visualisation des mécanismes de sécurité

L’utilisateur doit comprendre les protections appliquées par Vigie.

- 🔲 Affichage visuel du statut du point de restauration
- 🔲 Indication visuelle lors de la création du point de restauration
- 🔲 Affichage des tentatives de récupération (retry)

---

### ⚙️ Interface des paramètres avancés

Amélioration de l’accessibilité des paramètres techniques.

- 🔲 Sélection du niveau de journalisation
- 🔲 Organisation claire des paramètres avancés

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🌐 15. Version 2.0.0 — Architecture long terme

## 🎯 Objectif

Étendre Vigie vers **des scénarios d’utilisation avancés et multi-systèmes.**

Cette version explore **des capacités d’administration et d’intégration plus larges.**

---

### 🌍 Infrastructure et supervision

Fonctions permettant de **connecter et superviser plusieurs systèmes.**

- 🔲 Synchronisation distante
- 🔲 ApI interne
- 🔲 Supervision multi-machines
- 🔲 Extension entreprise

---

### 🌐 Internationalisation

Fonctions permettant d’adapter Vigie à **différents environnements linguistiques et régionaux.**

- 🔲 Internationalisation du format de date des journaux (adaptation automatique selon la langue sélectionnée)
- 🔲 Internationalisation des messages de journalisation (adaptation automatique selon la langue sélectionnée)
- 🔲 traduction en anglais

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 📊 16. Suivi Global

| Version   | Statut          | Progression estimée                                 |
| --------- | --------------- | ----------------------------------------------------|
| 0.1.0-dev | 🟢 Terminé      | ~100 % Fondations architecturales stabilisées       |
| 0.2.0-dev | 🟢 Terminé      | ~100 % Moteur multi-gestionnaires stabilisé         |
| 0.3.0-dev | 🟢 Terminé      | ~100 % Moteur de mise à jour stabilisé              |
| 0.4.0     | ⚪ À faire      | 0 % Sécurité renforcée                              |
| 0.5.0     | ⚪ À faire      | 0 % UX fonctionnelle (Mode Senior)                  |
| 0.6.0     | ⚪ À faire      | 0 % Simulation des mises à jour                     |
| 0.7.0     | ⚪ À faire      | 0 % Observabilité et suivi                          |
| 0.8.0     | ⚪ À faire      | 0 % Moteur multi-gestionnaires avancé               |
| 0.9.0     | ⚪ À faire      | 0 % Configuration avancée                           |
| 1.0.0     | ⚪ À faire      | 0 % Maturité du moteur                              |
| 1.5.0     | ⚪ À faire      | 0 % Refonte UX/UI complète                          |
| 2.0.0     | ⚪ À faire      | 0 % Architecture long terme                         |

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
