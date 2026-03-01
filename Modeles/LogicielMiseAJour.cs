/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Modeles                                                    ║
║  Fichier : LogicielMiseAJour.cs                                      ║
║                                                                      ║
║  Rôle :                                                              ║
║  Représente un logiciel détecté avec une mise à jour disponible.     ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Stocker les informations normalisées d’un logiciel                ║
║  - Servir de modèle de données pour l’affichage UI                   ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - Aucune dépendance métier                                          ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;

#endregion

namespace Vigie.Modeles
{

    #region 2. Description Générale

    /*
     * Classe : LogicielMiseAJour
     *
     * Rôle :
     * Modèle représentant un logiciel nécessitant une mise à jour.
     *
     * Objectif architectural :
     * Fournir une structure de données claire et indépendante
     * de toute logique UI ou logique métier.
     *
     * Limites :
     * - Ne contient aucune logique métier
     * - Ne gère aucun traitement
     * - Ne dépend d’aucune vue
     */

    #endregion

    #region 3. Déclaration de la Classe

    public class LogicielMiseAJour
    {
        #region 3.1 Propriétés

        /*
         * Propriété : Nom
         *
         * Rôle :
         * Nom du logiciel détecté.
         */
        public string Nom { get; set; } = string.Empty;

        /*
         * Propriété : VersionActuelle
         *
         * Rôle :
         * Version actuellement installée sur le système.
         */
        public string VersionActuelle { get; set; } = string.Empty;

        /*
         * Propriété : NouvelleVersion
         *
         * Rôle :
         * Version disponible à la mise à jour.
         */
        public string NouvelleVersion { get; set; } = string.Empty;

        /*
         * Propriété : Source
         *
         * Rôle :
         * Gestionnaire ayant détecté la mise à jour
         * (ex : winget, scoop).
         */
        public string Source { get; set; } = string.Empty;

        /*
         * Propriété : IdentifiantSource
         *
         * Rôle :
         * Identifiant technique brut fourni par le gestionnaire
         * (ex : Notepad++.Notepad++).
         */
        public string IdentifiantSource { get; set; } = string.Empty;

        /*
         * Propriété : IdentifiantNormalise
         *
         * Rôle :
         * Identifiant interne normalisé utilisé pour
         * la déduplication multi-gestionnaires.
         *
         * Remarque :
         * Généré par la couche de normalisation.
         */
        public string IdentifiantNormalise { get; set; } = string.Empty;

        #endregion
    }

    #endregion

}
