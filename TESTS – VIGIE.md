# 🧪 TESTS – VIGIE

Stratégie de validation et de qualité du projet Vigie.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎯 Objectif

Garantir :

- la fiabilité du scan des logiciels
- la robustesse du parsing des sorties console
- la gestion correcte des erreurs processus
- la stabilité de l’architecture interne

Les tests permettent de valider le comportement réel du moteur
avant toute évolution majeure du projet.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 1. Types de tests

## 🧪 Tests manuels (actuels)

Tests actuellement réalisés pendant le développement.

### 🔎 Tests du moteur de scan

- Scan via **winget**
- Vérification du parsing texte basé sur la structure des colonnes
- Simulation d’erreur de commande
- Test d’interruption de processus
- Test du mécanisme de timeout configurable
- Vérification de la journalisation

### 🔀 Tests multi-gestionnaires

- Scan Winget + Scoop (agrégation active)
- Vérification de la déduplication basée sur `IdentifiantNormalise`
- Vérification du pipeline **Scan → Normalisation → Fusion**
- Vérification de la comparaison des versions via `System.Version`
- Vérification de la fusion multi-sources avec versions différentes
- Vérification de la priorité Winget si même version détectée

### 📜 Tests de journalisation

- Vérification de l’absence de doublons de lignes vides dans `vigie.log`
- Vérification de la cohérence des journaux après scan multi-gestionnaires

### 🔄 Tests du moteur de mise à jour

- Vérification de la mise à jour globale via `ServiceMiseAJourGlobal`
- Vérification de la confirmation utilisateur avant exécution
- Vérification de la journalisation début / fin des mises à jour
- Vérification de la désactivation partielle de l’interface pendant la mise à jour
- Vérification de l’intégration de `PointRestaurationSimule`

### 🛡️ Tests de résilience

- Vérification de la résilience de l’orchestrateur si un gestionnaire échoue
- Vérification du comportement si aucun gestionnaire n’est disponible
- Vérification du statut logiciel pendant mise à jour  
  (`EnCours → Succès / Échec`)

### ⚠️ Cas particulier

- Test initial du système de sélection par cases  
  *(suspendu temporairement suite à une instabilité WinUI)*

---

## 🧠 Tests unitaires (à implémenter)

Tests automatisés prévus pour les composants critiques :

- Test `GestionnaireWinget`
- Test `GestionnaireGlobal`
- Test `NormaliseurWinget`
- Test gestion des erreurs
- Test normalisation des données
- Test déduplication basée sur `IdentifiantNormalise`
- Test comparaison des versions (`1.10 > 1.2`)
- Test `ParseVersionSafe` (gestion des suffixes preview)
- Test fallback `IdentifiantNormalise → Nom`
- Test résilience si un gestionnaire échoue
- Test pipeline complet **Scan → Normalisation → Fusion**
- Test robustesse parsing si le format winget évolue
- Test parsing avec colonnes décalées
- Test déduplication si un logiciel est détecté par plusieurs gestionnaires

---

## 🔒 Tests de sécurité (versions futures)

Ces tests seront introduits lorsque les opérations système
réelles seront activées.

Tests prévus :

- Test création de point de restauration réel
- Test élévation administrateur contrôlée
- Test comportement en cas d’échec partiel d’une mise à jour
- Test rollback en cas d’échec critique
- Test comportement si la création du point de restauration échoue

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 2. Stratégie

Priorités actuelles :

1. Stabilité du moteur de scan
2. Robustesse de la fusion multi-sources
3. Gestion des erreurs et résilience
4. Consolidation de l’architecture interne
5. Extensibilité contrôlée du moteur

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 3. Philosophie

Un outil système non testé devient dangereux.

Chaque fonctionnalité critique doit être validée
avant d’introduire une action système.

Les tests permettent de garantir que **l’évolution du projet
ne compromet jamais la stabilité du moteur.**
