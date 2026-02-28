/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Normalisation                                     ║
║  Fichier : INormaliseur.cs                                           ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit le contrat de normalisation des données                     ║
║  issues des gestionnaires de paquets.                                ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Transformer les données brutes en modèle normalisé                ║
║  - Fournir un identifiant technique stable                           ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - Modeles/LogicielMiseAJour                                         ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using Vigie.Modeles;

#endregion

namespace Vigie.Services.Normalisation
{
    #region 2. Description Générale

    /*
     * Interface : INormaliseur
     *
     * Rôle :
     * Définit la méthode permettant de normaliser
     * un LogicielMiseAJour issu d’un gestionnaire.
     *
     * Objectif architectural :
     * Séparer la normalisation des données
     * du processus de scan et de fusion.
     *
     * Limites :
     * - Ne dépend pas d’un gestionnaire spécifique
     * - Ne contient aucune logique de scan
     */

    #endregion

    #region 3. Déclaration de l’Interface

    public interface INormaliseur
    {
        /*
         * Méthode : Normaliser
         *
         * Objectif :
         * Transformer un LogicielMiseAJour brut
         * en modèle enrichi avec IdentifiantNormalise.
         *
         * Paramètre :
         * - logiciel : instance brute issue du scan
         *
         * Retour :
         * LogicielMiseAJour normalisé.
         */
        LogicielMiseAJour Normaliser(LogicielMiseAJour logiciel);
    }

    #endregion
}