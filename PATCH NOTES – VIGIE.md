# 📝 PATCH NOTES – VIGIE

Centre de maintenance logicielle intelligent

Document officiel retraçant l’évolution **technique, fonctionnelle et architecturale** du projet Vigie.

Ce fichier constitue :

- 📚 une **mémoire d’évolution du projet**
- 🧠 une **trace des décisions techniques**
- 🏗️ un **journal d’architecture**
- 🔎 un **outil d’audit technique**
- 📈 un **indicateur de maturité du projet**

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 📚 Organisation documentaire

La documentation du projet est répartie entre plusieurs fichiers spécialisés :

| Fichier                                  | Rôle                                               |
|------------------------------------------|----------------------------------------------------|
| 📘 README.md                             | Présentation générale du projet                    |
| 🧭 FEUILLE DE ROUTE – Vigie.md           | Vision stratégique et plan d’évolution             |
| 📝 PATCH NOTES – VIGIE.md                | Historique d’évolution technique et architecturale |
| 📐 ARCHITECTURE – Vigie.md               | Standard interne de structuration du code          |
| 🧾 GUIDE OFFICIEL DES COMMITS – VIGIE.md | Convention de commits et discipline Git            |
| 👤 GUIDE UTILISATEUR – VIGIE.md          | Documentation utilisateur                          |
| 🧪 TESTS – VIGIE.md                      | Stratégie de tests et suivi des validations        |

**Objectif :** maintenir une séparation claire entre :

- communication du projet  
- vision stratégique  
- évolution technique  
- discipline de développement

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🚀 VERSION 0.1.0-dev

## 📅 Période

Initialisation et consolidation des fondations du projet.

---

## 📌 Statut

🟢 Fondations stabilisées

---

## 🎯 Objectif stratégique

Mettre en place les **fondations architecturales du projet Vigie**.

Priorités :

- Structure claire
- Discipline architecturale
- Base technique propre
- Préparation à l’extensibilité

---

# ✨ Évolutions fonctionnelles

## 🧭 Initialisation de l’application

- Création du projet **WinUI 3 (.NET 8)**
- Mise en place de l’architecture **MVVM strict**
- Organisation des dossiers selon le standard interne
- Intégration du bloc licence dans les fichiers sources

Impact :

Base stable permettant l’évolution progressive du projet.

---

## 🧩 Gestion des gestionnaires de paquets

### 🔹 Interface `IGestionnairePaquets`

- Définition d’une abstraction commune
- Préparation du support multi-gestionnaires
- Découplage de la logique métier

### 🔹 Implémentation `GestionnaireWinget`

- Exécution de la commande `winget upgrade`
- Gestion des timeouts
- Gestion des erreurs de processus
- Parsing robuste basé sur la structure des colonnes `winget`
- Nettoyage des données retournées
- Journalisation détaillée des événements

Limitation :

Le parsing dépend du **format texte de winget**, en raison de l’absence d’une API JSON stable et fiable.

---

# 🏗️ Architecture

## Organisation modulaire

Structure adoptée :

```
Services/
├── Gestionnaires/
├── Interfaces/
├── MisesAJour/
└── Normalisation/

Modeles/
JournalEvenements/
Infrastructure/
VueModeles/
Vues/

Ressources/
├── Couleurs/
├── Styles/
├── Dimensions/
└── Themes/
```

Principes appliqués :

- MVVM strict
- Séparation UI / logique métier
- Single Responsibility Principle
- Services découplés et testables
- Abstraction via `IGestionnairePaquets`
- Journalisation centralisée via `JournalService`

Décision structurante :

Le support **multi-gestionnaires** est prévu dès l’origine via l’abstraction `IGestionnairePaquets`.

Chaque gestionnaire futur (Winget, Scoop, Chocolatey, etc.) pourra être intégré **sans refactorisation majeure de l’architecture.**

---

# 🎨 Interface utilisateur

## Philosophie UX initiale

- Interface volontairement minimaliste
- Bouton **Scanner** clairement identifiable
- Affichage simple de la liste des mises à jour
- Indicateur d’état lisible

Objectif :

Assurer un fonctionnement **clair et compréhensible** avant toute complexification de l’interface.

Cette base prépare l’introduction future de :

- Mode Senior
- Mode Expert

---

# 💾 Gestion des données

État actuel :

- Modèle `LogicielMiseAJour` défini
- Données issues de winget nettoyées et structurées
- Séparation claire entre modèle métier et source externe

Persistance :

Aucune persistance activée.

Les données sont générées dynamiquement à chaque scan.

---

# 🚀 Performance

- Exécution asynchrone non bloquante
- Séparation traitement / interface utilisateur
- Gestion d’un timeout (30 secondes)
- Parsing texte basé sur Regex et analyse structurée des colonnes
- Mesure de la durée du scan via `Stopwatch`

Priorité donnée à la **stabilité et à la fiabilité**.

---

# 🔒 Sécurité

Version actuelle :

- Aucune mise à jour automatique
- Aucune modification système
- Aucun point de restauration

Approche adoptée :

La version **0.1.0 se limite volontairement à la détection des mises à jour**.

---

# 📊 Indicateurs de maturité

| Composant            | Statut             |
|----------------------|--------------------|
| Architecture         | Stable             |
| Scan Winget          | Robuste            |
| Parsing Winget       | Stabilisé          |
| Journalisation       | Stable             |
| Sécurité système     | Non implémentée    |
| Mode Senior          | Non implémenté     |
| Mode Expert          | Non implémenté     |
| Tests automatisés    | Non implémentés    |

---

# ⏭️ Étape suivante (0.2.0)

La version **0.2.0** introduira les premières capacités du **moteur multi-gestionnaires**.

Évolutions prévues :

- Support multi-gestionnaires
- Fusion intelligente des résultats
- Normalisation des logiciels
- Déduplication robuste

Objectif :

Passer d’un **scan simple basé sur une seule source**  
à un **moteur multi-sources extensible** capable d’agréger plusieurs gestionnaires de paquets.

Cette évolution constitue une étape importante dans la transformation de Vigie en **centre de maintenance logicielle multi-gestionnaires**.

---

# 📦 Métadonnées

Version : `0.1.0-dev`  
Type : Version expérimentale stabilisée  
Licence : MIT  
Dernière mise à jour : 28 février 2026

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🚀 VERSION 0.2.0-dev

## 📅 Période

Extension de l’architecture vers un moteur multi-gestionnaires.

---

## 📌 Statut

🟢 Stabilisée (architecture multi-gestionnaires validée)

---

## 🎯 Objectif stratégique

Étendre l’architecture afin de supporter **plusieurs gestionnaires de paquets**
tout en conservant la stabilité du moteur de scan.

Priorités :

- Préparer la fusion multi-sources
- Introduire une normalisation fiable
- Stabiliser l’orchestrateur central
- Préparer l’historisation interne

---

# ✨ Évolutions fonctionnelles

## 🧱 Extension du modèle

- Ajout de la propriété `Source`
- Ajout de la propriété `IdentifiantNormalise`

Impact :

Le modèle `LogicielMiseAJour` peut désormais représenter
des logiciels provenant de **sources multiples**.

Cette évolution prépare la **fusion multi-gestionnaires**.

---

## 🧬 Introduction de la couche de normalisation

- Création de l’interface `INormaliseur`
- Implémentation `NormaliseurWinget`
- Intégration dans `GestionnaireGlobal`
- Génération automatique de `IdentifiantNormalise`

Pipeline officiel introduit :

***Scan → Normalisation → Fusion***

Impact :

Garantit une **comparaison fiable des logiciels**
provenant de différentes sources.

---

## 🔀 Orchestrateur multi-gestionnaires

- Implémentation complète de `GestionnaireGlobal`
- Agrégation des résultats de plusieurs gestionnaires
- Intégration officielle dans `AccueilVueModele`
- Activation du pipeline multi-sources dans l’interface

Impact :

Le moteur supporte désormais **plusieurs gestionnaires simultanément**.

---

## 🧠 Fusion intelligente et déduplication

- Déduplication basée sur `IdentifiantNormalise`
- Fallback possible sur `Nom`
- Priorité donnée à Winget si versions identiques
- Comparaison de versions via `System.Version`

Impact :

Empêche les **doublons provenant de plusieurs gestionnaires**.

---

## 🧪 Tests manuels multi-sources

Tests réalisés :

- Scan Winget + Scoop (simulation)
- Vérification cohérence Journal / Interface
- Vérification déduplication active
- Vérification priorité Winget si version identique

Impact :

Validation fonctionnelle du moteur multi-sources.

Aucune régression détectée.

---

## 🧹 Stabilisation du `JournalService`

- Protection contre les lignes vides consécutives
- Nettoyage automatique des messages (`Trim`)
- Introduction de l’état interne `_derniereLigneVide`
- Amélioration de la lisibilité des logs

Impact :

Amélioration de la **qualité des journaux techniques**
et préparation future de la gestion des niveaux de logs.

---

## 🛡️ Consolidation de la résilience de l’orchestrateur

- Ajout d’un `try/catch` global dans `GestionnaireGlobal.ScanAsync`
- Isolation complète des exceptions par gestionnaire
- Protection de la phase de normalisation
- Protection de la phase de fusion
- Journalisation des erreurs critiques de l’orchestrateur

Tests réalisés :

- Exception volontaire dans `GestionnaireWinget`
- Exception volontaire dans la normalisation
- Simulation de timeout Winget
- Exception volontaire dans la phase globale

Conséquence :

Le moteur multi-gestionnaires tolère désormais
les **échecs partiels sans compromettre la stabilité globale.**

---

## 🔍 Observabilité

- Journalisation détaillée du moteur de scan
- Traçabilité des gestionnaires utilisés
- Journalisation des erreurs d’exécution
- Journalisation des phases de normalisation et de fusion

Impact :

Permet d’auditer le comportement du moteur
et de diagnostiquer plus facilement les problèmes.

---

# 📊 Indicateurs de maturité

| Fonctionnalité               | Statut                |
|------------------------------|-----------------------|
| Scan Winget                  | Stable                |
| Scan multi-gestionnaires     | Fonctionnel           |
| Normalisation des logiciels  | Implémentée           |
| Fusion / Déduplication       | Stable                |
| Journalisation               | Améliorée             |
| Historique interne           | Structure préparée    |

---

# ⏭️ Étape suivante (0.3.0)

La version **0.3.0** introduira :

- Mise à jour globale des logiciels
- Confirmation utilisateur avant mise à jour
- Sécurisation par point de restauration
- Préparation de l’historisation des mises à jour

Objectif :

Passer d’un **moteur d’analyse**
à un **moteur d’action contrôlée**.

---

# 📦 Métadonnées

Version : `0.2.0-dev`  
Type : Development (architecture multi-gestionnaires stabilisée)  
Licence : MIT  
Dernière mise à jour : 03 mars 2026

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🚀 VERSION 0.3.0-dev

## 📅 Période

Implémentation du moteur de mise à jour contrôlée et stabilisation de l’orchestration des opérations.

---

## 📌 Statut

🟢 Stabilisée (milestone atteint)

---

## 🎯 Objectif stratégique

Permettre la mise à jour **sécurisée, maîtrisée et traçable** des logiciels.

Priorités :

- Contrôle utilisateur
- Sécurité des opérations
- Stabilisation de l’orchestration des mises à jour
- Préparation de l’historisation interne

---

# ✨ Évolutions fonctionnelles

## 🔄 Mise à jour globale

- Implémentation du `ServiceMiseAJourGlobal`
- Orchestration des mises à jour séquentielles
- Journalisation début / fin par logiciel
- Mesure de la durée d’exécution
- Gestion des exceptions critiques
- Mise à jour automatique du statut visuel des logiciels
- Rafraîchissement automatique du scan après mise à jour

Impact :

La mise à jour globale est désormais **fonctionnelle et sécurisée**.

---

## ☑️ Sélection individuelle des mises à jour

- Implémentation de la sélection individuelle des logiciels
- Introduction de `CheckBox` dans la liste des logiciels
- Synchronisation de la sélection avec le moteur de mise à jour
- Désactivation automatique des logiciels déjà mis à jour
- Retrait visuel des `CheckBox` pour les logiciels non éligibles

Impact :

L’utilisateur peut sélectionner précisément les logiciels à mettre à jour
tout en évitant les opérations redondantes.

---

## 🔐 Confirmation utilisateur

- Introduction de `IConfirmationService`
- Implémentation `ConfirmationService` (ContentDialog WinUI)
- Injection propre via `App.xaml.cs`
- Respect strict du pattern **MVVM**

Impact :

Aucune mise à jour globale ne peut être exécutée **sans confirmation explicite de l’utilisateur**.

---

## 🛡️ Préparation du point de restauration système

- Introduction de `IPointRestaurationService`
- Implémentation `PointRestaurationSimule`
- Intégration dans `ServiceMiseAJourGlobal`
- Blocage complet en cas d’échec de préparation

Impact :

Architecture prête pour une **sécurisation complète dans la version 0.4.0**.  
L’implémentation actuelle fonctionne en **mode simulé**.

---

## 🧩 Simulation des gestionnaires supplémentaires

- Simulation du support **Scoop**
- Simulation du support **Chocolatey**
- Intégration dans le pipeline du moteur multi-gestionnaires
- Préparation de l’activation réelle dans les versions futures

Impact :

Le moteur de mise à jour est désormais conçu pour supporter **plusieurs gestionnaires de paquets**.

---

## ⏱️ Timeout de sécurité des mises à jour

- Ajout d’un timeout maximal pour l’exécution des mises à jour
- Valeur actuelle : **10 minutes**
- Protection contre les blocages de gestionnaires de paquets
- Interruption contrôlée en cas de dépassement

Impact :

Empêche les blocages indéfinis lors de l’exécution de certains gestionnaires ou packages problématiques.

---

## 📜 Préparation de l’historique interne

- Création du modèle `HistoriqueMiseAJour`
- Enregistrement des résultats des mises à jour
- Intégration dans le pipeline de mise à jour globale
- Stockage en mémoire pour la session courante

Impact :

Prépare la persistance future de l’historique dans les versions ultérieures.

---

## 🗂️ Rotation automatique des journaux

- Implémentation d’un mécanisme de rotation des logs
- Création automatique d’archives lorsque `vigie.log`
  dépasse la taille maximale autorisée
- Préparation de la gestion de conservation des journaux

Impact :

Permet de conserver des journaux techniques sans risque
de croissance illimitée du fichier principal.

---

## 🔐 Simulation de l’élévation administrateur

- Implémentation d’un comportement simulé d’élévation UAC
- Validation du pipeline interne de mise à jour
- Préparation de l’élévation réelle lors de l’activation des gestionnaires de paquets

Impact :

Permet de tester le comportement de l’application dans des scénarios
nécessitant des privilèges élevés sans déclencher une élévation réelle.

---

## 🎨 Interface utilisateur

- Ajout du bouton **"Mettre à jour"**
- Ajout du **ProgressRing de scan**
- Ajout du **ProgressRing de mise à jour**
- Désactivation partielle de l’interface pendant les opérations
- Désactivation automatique des boutons pendant scan / mise à jour
- Affichage dynamique du statut des logiciels pendant la mise à jour

Impact :

Meilleur retour visuel lors des opérations longues.

---

## 🎨 Centralisation des ressources visuelles

- Création du dossier `Ressources/`
- Centralisation progressive des ressources visuelles
- Définition d’une palette de couleurs officielle
- Préparation des styles globaux et dimensions UI

Objectif :

Éviter les valeurs visuelles codées directement dans les vues
et préparer un **système de thème maintenable**.

Architecture prévue :

```
Ressources/
├── Couleurs/
├── Styles/
├── Dimensions/
└── Themes/
```

---

## ⚙️ Améliorations techniques

- Correction du blocage de l’interface lors du scan
- Stabilisation du pipeline scan → mise à jour → rafraîchissement
- Exécution séquentielle contrôlée des gestionnaires dans `GestionnaireGlobal`
- Stabilisation de l’agrégation des résultats
- Détection automatique des gestionnaires installés

Impact :

Amélioration notable de la **réactivité et de la stabilité globale du moteur**.

---

# 📊 Indicateurs de maturité

| Fonctionnalité                 | Statut              |
|--------------------------------|---------------------|
| Mise à jour globale            | Stable              |
| Sélection individuelle         | Fonctionnelle       |
| Confirmation utilisateur       | Stable              |
| Point de restauration          | Simulé              |
| Support multi-gestionnaires    | Simulation active   |
| Timeout sécurité mises à jour  | Implémenté          |
| Historique interne             | Modèle prêt         |
| Rotation journaux              | Implémentée         |
| Élévation administrateur       | Simulée             |

---

# ⏭️ Prochaines étapes (0.4.0)

- Implémentation réelle du point de restauration
- Implémentation réelle de l’élévation administrateur
- Vérification de la connectivité réseau avant mise à jour
- Vérification de l’espace disque disponible
- Gestion des erreurs détaillées
- Amélioration UX du feedback utilisateur

---

# 📦 Métadonnées

Version : `0.3.0-dev`  
Type : Development milestone (moteur de mise à jour stabilisé)  
Licence : MIT  
Dernière mise à jour : 07 mars 2026

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🚀 VERSION 0.4.0-dev

## 📅 Période

Renforcement de la sécurité du moteur de mise à jour et validation de l’environnement système.

---

## 📌 Statut

🟡 En développement

---

## 🎯 Objectif stratégique

Sécuriser l’exécution des mises à jour en introduisant un **pipeline de validation système** avant toute opération.

Priorités :

- Vérification de l’environnement système
- Protection contre les opérations risquées
- Résilience face aux erreurs d’exécution
- Amélioration du feedback utilisateur

---

# ✨ Évolutions fonctionnelles

## 🛡️ Validation de l’environnement système

Fonctions visant à vérifier les conditions nécessaires avant l’exécution des mises à jour.

Fonctionnalités prévues :

- Vérification de la présence des gestionnaires de paquets
- Vérification des privilèges administrateur
- Vérification de la connectivité réseau
- Vérification de l’espace disque disponible

Objectif :

Empêcher l’exécution des mises à jour si les **conditions système critiques ne sont pas remplies**.

---

## 🔄 Création automatique d’un point de restauration

Fonctions visant à sécuriser le système avant modification.

Fonctionnalités prévues :

- Implémentation réelle du service `PointRestaurationService`
- Création automatique d’un point de restauration avant mise à jour globale
- Blocage de la mise à jour en cas d’échec de création

Objectif :

Permettre une **restauration du système en cas de problème lors des mises à jour**.

---

## ⚠️ Gestion des erreurs et résilience

Fonctions visant à améliorer la tolérance aux erreurs pendant l’exécution.

Fonctionnalités prévues :

- Gestion détaillée des erreurs de mise à jour
- Implémentation d’un mécanisme de **retry automatique**
- Journalisation des tentatives de récupération
- Détection des mises à jour nécessitant un redémarrage

Objectif :

Renforcer la **robustesse du moteur de mise à jour**.

---

## 🔍 Pipeline de validation avant mise à jour

Introduction d’un mécanisme centralisé de validation.

Pipeline prévu :

Validation système
        ↓
Création point restauration
        ↓
Confirmation utilisateur
        ↓
Exécution des mises à jour

Objectif :

Garantir que **toutes les conditions de sécurité soient réunies avant l’exécution des opérations**.

---

# 📊 INDICATEURS DE MATURITÉ (prévisionnels)

| Fonctionnalités                 | Statut          |
|---------------------------------|-----------------|
| Validation environnement        | En développement|
| Point de restauration réel      | À implémenter   |
| Retry automatique               | À implémenter   |
| Gestion erreurs détaillées      | À implémenter   |
| Pipeline de validation          | En conception   |

---

# ⏭️ ÉTAPE SUIVANTE (0.5.0)

La version **0.5.0** introduira les premières améliorations majeures de l’interface utilisateur.

Objectifs :

- Améliorer la compréhension de l’état du système
- Introduire une **carte "État du système"**
- Ajouter une **barre de progression globale des mises à jour**
- Améliorer la navigation dans la liste des logiciels
- Introduire les premières bases du **Mode Senior**

---

# 📦 MÉTADONNÉES

Version : `0.4.0-dev`  
Type : Development (sécurité et validation système)  
Licence : MIT  
Dernière mise à jour : 09 mars 2026

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧠 Philosophie d’évolution

Vigie évolue selon un principe de **consolidation progressive**.

Chaque version vise à :

- stabiliser l’existant
- clarifier l’architecture
- renforcer la robustesse du moteur
- préparer les extensions futures

Les nouvelles fonctionnalités ne sont jamais ajoutées
sans cohérence structurelle avec l’architecture du projet.

L’objectif est de construire un logiciel **compréhensible, maintenable et durable**.

---

## 📜 Rôle du Patch Notes

Le fichier **PATCH NOTES – VIGIE.md** constitue une mémoire technique vivante du projet.

Il permet de :

- documenter les évolutions du moteur
- tracer les décisions architecturales
- refléter l’état réel du projet à chaque version
- préparer les évolutions futures

Il joue ainsi un rôle central dans la **discipline documentaire du projet Vigie**.

