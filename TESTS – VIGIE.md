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
- Test mécanisme de timeout (30 secondes)
- Vérification journalisation
- Validation agrégation multi-gestionnaires (Winget + Scoop)
- Vérification déduplication basée sur IdentifiantNormalise
- Vérification pipeline Scan → Normalisation → Fusion

---

## 🧠 Tests unitaires (à implémenter)

- Test GestionnaireWinget
- Test GestionnaireGlobal
- Test gestion erreurs
- Test normalisation données
- Test déduplication basée sur identifiant normalisé

---

## 🔒 Tests sécurité (versions futures)

Ces tests seront activés lors de l’introduction des mises à jour automatiques :

- Test point de restauration
- Test confirmation utilisateur
- Test rollback en cas d’échec
- Test élévation administrateur contrôlée

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 2. STRATÉGIE

Priorité actuelle :

1. Stabilité du scan
2. Gestion erreurs
3. Normalisation multi-gestionnaires
4. Extensibilité architecturale

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 3. PHILOSOPHIE

Un outil système non testé devient dangereux.

Chaque fonctionnalité critique doit être validée
avant d’introduire une action système.
