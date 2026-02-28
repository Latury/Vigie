# 🧠 GUIDE OFFICIEL DES COMMITS – VIGIE

Centre de maintenance logicielle intelligent

Ce document définit la convention officielle de commits pour le projet Vigie.

Objectifs :

- Structurer l’historique Git
- Clarifier chaque intention de modification
- Maintenir une cohérence documentaire
- Permettre un audit technique lisible
- Faciliter la compréhension long terme

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🎯 OBJECTIF D’UN COMMIT

Un commit dans Vigie est :

- Une trace historique
- Une décision documentée
- Une explication d’architecture
- Un message au futur développeur
- Un élément de consolidation

Chaque commit doit répondre à :

1. Qu’est-ce qui change ?
2. Pourquoi ça change ?
3. Comment ça change ?
4. Quel est l’impact ?
5. Y a-t-il des risques ?

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧩 PRINCIPE FONDAMENTAL

1 commit = 1 intention claire

Interdit :

- Corriger un bug + ajouter une feature
- Mélanger refactor + nouvelle fonctionnalité
- Commit vague
- Commit sans description complète

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 📐 FORMAT STANDARD OBLIGATOIRE

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

## 1️⃣ SUMMARY

Longueur recommandée : 50 caractères maximum.

Format strict :

[Emoji] [Catégorie] Message clair et précis

Exemples adaptés à Vigie :

📎 [Init] Initialisation projet WinUI 3
🏗️ [Architecture] Mise en place MVVM strict
🧱 [Core] Implémentation GestionnaireWinget scan texte
✨ [Feature] Ajout mise à jour individuelle
🔒 [Security] Ajout point de restauration

Règles :

- Pas de point final
- Pas de phrase longue
- Pas de formulation vague
- Toujours commencer par l’emoji

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

## 2️⃣ DESCRIPTION OBLIGATOIRE (DOUBLE NIVEAU)

Structure obligatoire :

---

👶 Description simplifiée :

Explication claire destinée :

- Aux débutants
- Aux non développeurs
- Au futur toi fatigué

---

👨‍💻 Description technique :

- Classes créées ou modifiées
- Méthodes impactées
- Interfaces ajoutées
- Architecture modifiée
- Patterns concernés (MVVM, Service, Interface)
- Processus système exécuté (winget, scoop, etc.)

---

📁 Fichiers concernés :

- Liste des fichiers ajoutés
- Liste des fichiers modifiés
- Liste des fichiers supprimés

---

⚠️ Risques ou effets secondaires :

- Impact potentiel
- Dette technique
- Refactor futur nécessaire
- Risque de régression

---

🎯 Impact global :

- Fonctionnel
- Architecture
- UX
- Performance
- Sécurité

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🏷️ CATÉGORIES OFFICIELLES DE COMMIT – VIGIE

| Emoji | Type         | Utilisation spécifique Vigie                |
| ----- | ------------ | ------------------------------------------- |
| 📎    | Init         | Initialisation projet                       |
| 🏗️    | Architecture | Modification structure MVVM                 |
| 🧱    | Core         | Modification logique cœur (PackageManagers) |
| ✨    | Feature      | Nouvelle fonctionnalité utilisateur         |
| ⛓️‍💥    | Bugfix       | Correction bug                              |
| 🛠️    | Fix          | Correction mineure                          |
| ♻️    | Refactor     | Réorganisation sans changement fonctionnel  |
| 📝    | Docs         | Documentation                               |
| 📚    | Readme       | Modification README uniquement              |
| 🔒    | Security     | Sécurité (point restauration, validation)   |
| 🚀    | Performance  | Optimisation                                |
| 🧪    | Test         | Ajout ou modification tests                 |
| 🧹    | Cleanup      | Nettoyage code                              |
| 🔥    | Remove       | Suppression code                            |
| 🔧    | Config       | Configuration projet                        |
| ⬆️    | Upgrade      | Mise à jour dépendances                     |
| 🧠    | Logic        | Modification logique métier                 |
| 🛡️    | Validation   | Validation données                          |
| 🧵    | Async        | Passage en asynchrone                       |
| 🧭    | Navigation   | Modification navigation                     |
| 🎯    | UX           | Amélioration expérience utilisateur         |
| 📁    | Structure    | Réorganisation dossiers                     |
| 🧬    | Experimental | Fonctionnalité expérimentale                |

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 📘 EXEMPLE ADAPTÉ À VIGIE

## Summary

🧱 [Core] Implémentation GestionnaireWinget scan texte

---

## Description

👶 Description simplifiée :
Ajout du moteur permettant à Vigie de scanner les mises à jour via winget.

---

👨‍💻 Description technique :

- Création classe GestionnaireWinget
- Implémentation interface IGestionnairePaquets
- Exécution commande :
  winget upgrade
- Lecture sortie standard
- Parsing texte basé sur structure colonnes winget
- Nettoyage des données (suppression ID parasite)
- Journalisation structurée

---

📁 Fichiers concernés :

- Services/PackageManagers/GestionnaireWinget.cs
- Services/Interfaces/IGestionnairePaquets.cs
- Modeles/LogicielMiseAJour.cs

---

⚠️ Risques ou effets secondaires :

- Parsing dépend du format texte winget
- Sensible aux évolutions de colonnes

---

🎯 Impact global :

Activation du scan robuste.
Base architecturale pour extension multi-gestionnaires.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 📏 RÈGLES AVANCÉES

- Toujours respecter le format
- Toujours écrire la partie simplifiée
- Toujours détailler les fichiers
- Toujours indiquer l’impact
- Pas de commit émotionnel
- Pas de commit automatique non documenté
- Pas de commit massif sans explication détaillée

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧾 FORMAT FOURNI PAR L’ASSISTANT

Règle spécifique au workflow Vigie :

À chaque demande de rédaction de commit,
l’assistant doit obligatoirement fournir :

- Le Summary en format texte brut
- La Description complète en bloc code (format prêt à copier-coller)
- Sans mise en forme décorative inutile
- Sans variation de structure

Objectif :

Optimiser la rapidité de commit,
éviter les erreurs de format,
standardiser la communication technique,
et maintenir une discipline professionnelle constante.

Cette règle est permanente.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧠 BONNES PRATIQUES PROFESSIONNELLES

- Commit petit mais régulier
- Commit atomique
- Commit testable
- Commit compréhensible isolément
- Commit aligné avec la feuille de route

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🚫 EXEMPLES INTERDITS

❌ Update
❌ Correction
❌ Divers changements
❌ Bug fix
❌ WIP
❌ Ajouts

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🏁 OBJECTIF FINAL

Un historique Git lisible.
Une architecture documentée.
Un projet auditable.
Un futur mainteneur serein.

Un bon commit aujourd’hui évite une catastrophe mentale dans 6 mois.
