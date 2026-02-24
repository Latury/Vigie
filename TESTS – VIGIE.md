# 🧪 TESTS – VIGIE

Stratégie de validation et de qualité du projet Vigie.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎯 OBJECTIF

Garantir :

- Fiabilité du scan
- Robustesse parsing JSON
- Sécurité des mises à jour
- Stabilité architecture

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 1. TYPES DE TESTS

## 🧪 Tests manuels

- Scan winget
- Vérification parsing JSON
- Simulation erreur commande
- Test interruption processus
- Test gestion droits administrateur

---

## 🧠 Tests unitaires (à implémenter)

- Test IPackageManager
- Test WingetManager
- Test gestion erreurs
- Test normalisation données

---

## 🔒 Tests sécurité

- Test point de restauration
- Test confirmation utilisateur
- Test rollback en cas d’échec

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 2. STRATÉGIE

Priorité :

1. Stabilité scan
2. Gestion erreurs
3. Sécurité mise à jour
4. Performance

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 3. PHILOSOPHIE

Un outil système non testé devient dangereux.

Chaque fonctionnalité critique doit être validée.
