/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Normalisation                                     ║
║  Fichier : NormaliseurWinget.cs                                      ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémente la normalisation spécifique aux données                  ║
║  issues du gestionnaire Winget.                                      ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Générer un IdentifiantNormalise stable                            ║
║  - Nettoyer le nom logiciel pour fusion multi-sources                ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - Modeles/LogicielMiseAJour                                         ║
║  - INormaliseur                                                      ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Voir fichier LICENSE pour détails                                   ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Linq;
using System.Text.RegularExpressions;

using Vigie.Modeles;

#endregion

namespace Vigie.Services.Normalisation
{
    #region 2. Description Générale

    /*
     * Classe : NormaliseurWinget
     *
     * Rôle :
     * Implémente la normalisation des données provenant de Winget.
     *
     * Objectif architectural :
     * Générer un identifiant technique stable utilisé
     * pour la déduplication multi-gestionnaires.
     *
     * Limites :
     * - Ne dépend pas du processus de scan
     * - Ne gère aucune logique UI
     * - Ne modifie pas les versions
     */

    #endregion

    #region 3. Déclaration de la Classe

    public class NormaliseurWinget : INormaliseur
    {
        #region 3.1 Méthodes publiques

        /*
         * Méthode : Normaliser
         *
         * Objectif :
         * Générer un IdentifiantNormalise basé sur le Nom
         * en supprimant les caractères non alphanumériques
         * et en convertissant en minuscules.
         *
         * Paramètre :
         * - logiciel : instance issue du scan Winget
         *
         * Retour :
         * LogicielMiseAJour enrichi avec IdentifiantNormalise.
         */
        public LogicielMiseAJour Normaliser(LogicielMiseAJour logiciel)
        {
            if (logiciel == null)
            {
                return null;
            }

            string baseIdentifiant = logiciel.IdentifiantSource;

            // Si IdentifiantSource absent → fallback sur Nom
            if (string.IsNullOrWhiteSpace(baseIdentifiant))
            {
                baseIdentifiant = logiciel.Nom;
            }

            if (!string.IsNullOrWhiteSpace(baseIdentifiant) &&
                baseIdentifiant.Contains("."))
            {
                string[] parties = baseIdentifiant.Split('.');

                baseIdentifiant = parties
                    .OrderByDescending(p => p.Length)
                    .First();
            }

            string identifiant = Regex
                .Replace(baseIdentifiant ?? string.Empty, "[^a-zA-Z0-9+]", "")
                .ToLowerInvariant();

            logiciel.IdentifiantNormalise = identifiant;

            return logiciel;
        }

        #endregion
    }

    #endregion
}
