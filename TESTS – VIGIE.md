# 🧪 TESTS – VIGIE

Stratégie de validation et de qualité du projet Vigie.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎯 OBJECTIF

Garantir :

- Fiabilité du scan
- Robustesse du parsing texte
- Gestion correcte des erreurs processus
- Stabilité de l’architecture

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 1. TYPES DE TESTS

## 🧪 Tests manuels (actuels)

- Scan winget
- Vérification parsing texte basé sur structure colonnes
- Simulation erreur commande
- Test interruption processus
- Test mécanisme de timeout (60 secondes)
- Vérification journalisation
- Winget + Scoop (agrégation active)
- Vérification déduplication basée sur IdentifiantNormalise
- Vérification pipeline Scan → Normalisation → Fusion
- Vérification comparaison versions via System.Version
- Vérification fusion multi-sources avec versions différentes
- Vérification priorité Winget si même version détectée
- Vérification absence doublons lignes vides dans vigie.log
- Vérification cohérence log après multi-gestionnaires
- Vérification mise à jour globale via ServiceMiseAJourGlobal
- Vérification confirmation utilisateur avant exécution mise à jour
- Vérification journalisation début / fin des mises à jour
- Vérification désactivation partielle de l’interface pendant mise à jour
- Vérification intégration PointRestaurationSimule
- Vérification résilience orchestrateur (échec d’un gestionnaire isolé)
- Test initial système de sélection par cases  
  (suspendu temporairement suite instabilité WinUI)

---

## 🧠 Tests unitaires (à implémenter)

- Test GestionnaireWinget
- Test GestionnaireGlobal
- Test NormaliseurWinget
- Test gestion erreurs
- Test normalisation données
- Test déduplication basée sur identifiant normalisé
- Test comparaison versions (1.10 > 1.2)
- Test ParseVersionSafe (gestion suffixes preview)
- Test comportement fallback IdentifiantNormalise → Nom
- Test résilience si un gestionnaire échoue
- Test pipeline complet Scan → Normalisation → Fusion
- Test robustesse parsing si format winget change

---

## 🔒 Tests sécurité (versions futures)

Ces tests seront activés lors de l’introduction des mises à jour système réelles :

- Test point de restauration réel
- Test élévation administrateur contrôlée
- Test comportement en cas d’échec partiel d’une mise à jour
- Test rollback en cas d’échec critique

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 2. STRATÉGIE

Priorité actuelle :

1. Stabilité du scan
2. Robustesse fusion multi-sources
3. Gestion erreurs et résilience
4. Consolidation architecture interne
5. Extensibilité contrôlée

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 3. PHILOSOPHIE

Un outil système non testé devient dangereux.

Chaque fonctionnalité critique doit être validée
avant d’introduire une action système.
