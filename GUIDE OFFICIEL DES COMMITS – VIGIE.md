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

# 🔎 RÉFÉRENCE ARCHITECTURALE

Lorsqu’un commit modifie :

- la structure du code
- les services principaux
- le pipeline interne
- l’orchestration des gestionnaires
- l’architecture MVVM

il est recommandé de consulter :

**AVG — Architecture Vigie**

Le document de référence est :

**ARCHITECTURE – Vigie.md**

AVG constitue la référence officielle pour :

- la structuration du code
- les règles d’architecture
- les principes de conception du moteur Vigie

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# ⚙️ PIPELINE OFFICIEL VIGIE

Le moteur interne de Vigie repose sur un pipeline structuré.

Pipeline officiel :

Scan → Normalisation → Fusion → Mise à jour

Description des étapes :

1. Scan  
   Les gestionnaires interrogent le système (winget, scoop, etc.)

2. Normalisation  
   Les données sont converties dans un format interne cohérent.

3. Fusion  
   Les résultats provenant de plusieurs gestionnaires sont consolidés
   et dédupliqués.

4. Mise à jour  
   Les opérations de mise à jour sont orchestrées de manière sécurisée.

Toute modification d’une étape du pipeline doit être explicitement documentée dans le commit.

Le commit doit préciser :

- quelle étape est modifiée
- l’ordre d’exécution
- les impacts sur les gestionnaires
- les impacts sur la fusion des données

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🏗️ RÈGLE ARCHITECTURALE SPÉCIFIQUE

Tout commit modifiant une classe métier doit préciser :

- Si une dépendance est ajoutée ou supprimée
- Si une instanciation directe a été remplacée par une injection
- Si une interface a été introduite

Objectif :

Tracer l’évolution du découplage architectural  
et garantir la testabilité progressive du projet.

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
✨ [Feature] Implémentation mise à jour globale contrôlée  
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

| Emoji | Type | Utilisation spécifique Vigie |
|------|------|------|
| 📎 | Init | Initialisation projet |
| 🏗️ | Architecture | Modification structure MVVM |
| 🧱 | Core | Modification logique cœur |
| ✨ | Feature | Nouvelle fonctionnalité |
| ⛓️‍💥 | Bug | Correction dysfonctionnement |
| 🛠️ | Fix | Correction mineure |
| ♻️ | Refactor | Réorganisation sans changement fonctionnel |
| 📝 | Docs | Documentation |
| 📚 | Readme | Modification README |
| 🔒 | Security | Sécurité système |
| 🚀 | Performance | Optimisation |
| 🧪 | Test | Ajout ou modification tests |
| 🧹 | Cleanup | Nettoyage code |
| 🔥 | Remove | Suppression code |
| 🔧 | Config | Configuration projet |
| 🔄 | Upgrade | Mise à jour dépendances |
| 🧠 | Logic | Modification logique métier |
| 🛡️ | Validation | Validation données |
| 🧵 | Async | Passage en asynchrone |
| 🧭 | Navigation | Navigation UI |
| 🎯 | UX | Amélioration UX |
| 📁 | Structure | Réorganisation dossiers |
| 🧬 | Experimental | Fonctionnalité expérimentale |
| ⚙️ | Service | Création ou modification service |

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
- Exécution commande winget upgrade
- Lecture sortie standard
- Parsing texte basé sur structure colonnes winget
- Nettoyage des données
- Journalisation structurée

---

📁 Fichiers concernés :

- Services/Gestionnaires/GestionnaireWinget.cs
- Services/Interfaces/IGestionnairePaquets.cs
- Modeles/LogicielMiseAJour.cs

---

⚠️ Risques ou effets secondaires :

Parsing dépend du format texte winget.

---

🎯 Impact global :

Activation du scan robuste  
et base pour extension multi-gestionnaires.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 📚 RELATION ENTRE COMMITS ET PATCH NOTES

Les commits documentent les **modifications détaillées du code**.

Les Patch Notes documentent les **évolutions consolidées du projet**.

Règle :

Un commit ne doit jamais annoncer une version officielle.

Les versions sont documentées uniquement dans :

**PATCH NOTES – VIGIE.md**

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 📏 RÈGLES AVANCÉES

- Toujours respecter le format
- Toujours écrire la partie simplifiée
- Toujours détailler les fichiers
- Toujours indiquer l’impact
- Pas de commit émotionnel
- Pas de commit automatique non documenté
- Pas de commit massif sans explication détaillée

Toute modification de :

- logique de fusion
- comparaison de versions
- pipeline interne
- journalisation

doit être explicitement décrite.

Un commit ne doit pas dépasser **~300 lignes modifiées**
sauf justification explicite.

Toute nouvelle fonctionnalité doit mentionner :

Version cible : ex 0.4.0

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧾 FORMAT FOURNI PAR L’ASSISTANT

À chaque demande de rédaction de commit, l’assistant doit fournir :

- Summary en texte brut
- Description complète en bloc code
- Format prêt à copier-coller

Objectif :

- accélérer la rédaction
- éviter les erreurs de format
- maintenir une discipline professionnelle constante

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

Un historique Git lisible  
Une architecture documentée  
Un projet auditable  
Un futur mainteneur serein

Un bon commit aujourd’hui évite une catastrophe mentale dans 6 mois.
