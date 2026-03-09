# 👤 GUIDE UTILISATEUR – VIGIE

Vigie est un **centre de maintenance logicielle intelligent**.

L’application permet d’analyser les logiciels installés
et d’identifier les mises à jour disponibles sur votre système Windows.

Vigie centralise les informations provenant de plusieurs gestionnaires
de paquets afin de fournir une **vision claire des mises à jour disponibles.**

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧭 1. Scanner les mises à jour

1. Ouvrir Vigie
2. Cliquer sur **"Scanner"**
3. Attendre la fin de l’analyse
4. Consulter la liste des mises à jour détectées

Pendant l’analyse, un indicateur visuel signale que le scan est en cours.

Le scan permet de :

- détecter les logiciels pouvant être mis à jour
- identifier leur version actuelle
- identifier la version disponible

Le scan interroge plusieurs gestionnaires de paquets
(ex : **winget**, **Scoop**).

Les résultats sont **fusionnés automatiquement**
afin d’éviter les doublons.

Aucun logiciel n’est installé, modifié ou supprimé
pendant la phase de scan.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🔄 2. Mettre à jour les logiciels

Vigie permet de lancer la mise à jour des logiciels détectés.

Deux modes sont disponibles :

### Mise à jour globale

1. Scanner les mises à jour
2. Cliquer sur **"Mettre à jour"**
3. Confirmer l’opération

Vigie exécutera alors les mises à jour nécessaires.

### Mise à jour individuelle

Vous pouvez sélectionner précisément les logiciels
à mettre à jour grâce aux **cases à cocher** dans la liste.

Seuls les logiciels sélectionnés seront mis à jour.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🔐 3. Sécurité des mises à jour

Les opérations de mise à jour sont protégées par plusieurs mécanismes :

- confirmation explicite de l’utilisateur
- journalisation complète des opérations
- préparation d’un point de restauration système

Ces mécanismes visent à garantir une **mise à jour contrôlée et traçable.**

Des mécanismes de validation supplémentaires seront ajoutés
dans les prochaines versions du projet.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 👴 4. Mode Senior (prévu)

Une interface simplifiée est prévue afin de rendre
l’application accessible aux utilisateurs peu techniques.

Objectifs :

- afficher uniquement les actions essentielles
- utiliser des boutons larges
- supprimer le jargon technique
- présenter clairement l’état du système

Implémentation prévue en **version 0.5.0**.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# 🧠 5. Mode Expert (prévu)

Un mode avancé permettra d’accéder
à des informations techniques détaillées.

Fonctionnalités prévues :

- affichage détaillé des journaux d’événements
- visualisation de la source des mises à jour détectées
- sélection et configuration des gestionnaires de paquets
- accès à des paramètres techniques avancés

Implémentation progressive jusqu’à la **version 1.0.0**.

━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━

# ⚠️ 6. Recommandations

Pour garantir un fonctionnement optimal :

- vérifier votre connexion internet avant un scan
- éviter de fermer l’application pendant une mise à jour
- consulter les journaux en cas d’erreur (Mode Expert futur)

Vigie est conçu pour **simplifier la maintenance logicielle**
et rendre la gestion des mises à jour plus compréhensible.
