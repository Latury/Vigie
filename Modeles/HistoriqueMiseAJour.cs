/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Modeles                                                    ║
║  Fichier : HistoriqueMiseAJour.cs                                    ║
║                                                                      ║
║  Rôle :                                                              ║
║  Représente une entrée d’historique liée à une tentative             ║
║  de mise à jour logicielle.                                          ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Stocker les informations d’une opération de mise à jour           ║
║  - Conserver le statut (Succès / Échec)                              ║
║  - Conserver un message d’erreur éventuel                            ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - StatutMiseAJour                                                   ║
║                                                                      ║
║  Licence : MIT                                                       ║
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
     * Classe : HistoriqueMiseAJour
     *
     * Rôle :
     * Modèle représentant une entrée d’historique
     * d’une tentative de mise à jour logicielle.
     *
     * Responsabilités :
     * 1. Conserver les informations avant/après mise à jour
     * 2. Conserver la source du gestionnaire
     * 3. Conserver la date de l’opération
     * 4. Conserver le statut final
     * 5. Conserver un message d’erreur si échec
     *
     * Limites :
     * - Ne gère aucune logique métier
     * - Ne gère aucune persistance
     * - Ne gère aucune interaction UI
     */

    #endregion

    #region 3. Déclaration

    public class HistoriqueMiseAJour
    {
        #region 3.1 Propriétés

        public string Nom { get; set; } = string.Empty;

        public string VersionAvant { get; set; } = string.Empty;

        public string VersionApres { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;

        public DateTime DateOperation { get; set; }

        public StatutMiseAJour Statut { get; set; }
            = StatutMiseAJour.Inconnu;

        public string MessageErreur { get; set; } = string.Empty;

        #endregion

        #region 3.2 Constructeur

        public HistoriqueMiseAJour()
        {
            DateOperation = DateTime.Now;
        }

        #endregion
    }

    #endregion
}
