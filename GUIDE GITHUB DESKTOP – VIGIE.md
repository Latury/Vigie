# 🧠 GUIDE GITHUB DESKTOP – VIGIE

Guide pédagogique officiel pour la gestion du versioning du projet Vigie.

Ce document définit la méthode recommandée pour :

- Structurer l’historique Git
- Respecter le GUIDE_COMMITS.md
- Maintenir une discipline documentaire
- Éviter les erreurs de versioning

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎯 OBJECTIF

Dans Vigie, Git n’est pas un simple outil.
C’est un élément d’architecture documentaire.

Chaque commit doit être :

- Structuré
- Compréhensible
- Aligné avec la feuille de route
- Conforme au GUIDE_COMMITS.md

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧩 WORKFLOW OFFICIEL VIGIE

## Début de session

1. Ouvrir GitHub Desktop
2. Cliquer sur Fetch origin
3. Vérifier absence de conflits
4. Vérifier la feuille de route
5. Identifier l’objectif du commit à venir

---

## Pendant le développement

Règles obligatoires :

- 1 commit = 1 intention
- Code compilable
- Commentaires conformes au STANDARD_STRUCTURE_CODE
- Documentation mise à jour si nécessaire

Fréquence recommandée :
Toutes les 30 à 60 minutes.

---

## Structure obligatoire du commit

Summary :

[Emoji] [Catégorie] Message clair

Description :

- Description simplifiée
- Description technique
- Fichiers concernés
- Impact global

Conforme au GUIDE_COMMITS.md.

---

## Fin de session

1. Vérifier qu’aucun fichier non voulu n’est inclus
2. Commit final propre
3. Push origin
4. Vérifier présence sur GitHub.com

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# ⚠️ RÈGLES STRICTES

Interdit :

- Commit vague
- Commit sans description
- Commit mélangeant plusieurs intentions
- Commit sans mise à jour documentation si nécessaire

Git est une mémoire.
Une mémoire mal tenue devient inutilisable.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎯 OBJECTIF FINAL

Un historique clair.
Un projet auditable.
Un futur mainteneur serein.
