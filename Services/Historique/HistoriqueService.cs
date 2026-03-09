/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Historique                                        ║
║  Fichier : HistoriqueService.cs                                      ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémentation en mémoire du service d’historique.                  ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Stocker temporairement les opérations                             ║
║  - Exposer une liste en lecture seule                                ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - IHistoriqueService                                                ║
║  - HistoriqueMiseAJour                                               ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Collections.Generic;

using Vigie.Modeles;
using Vigie.Services.Interfaces;

#endregion

namespace Vigie.Services.Historique
{
    #region 2. Description Générale

    /*
     * Classe : HistoriqueService
     *
     * Rôle :
     * Implémentation simple en mémoire du service d’historique.
     *
     * Responsabilités :
     * 1. Conserver les entrées en mémoire
     * 2. Garantir une lecture seule côté extérieur
     *
     * Limites :
     * - Non persistant
     * - Non thread-safe avancé
     * - Usage actuel limité au contexte UI
     */

    #endregion

    #region 3. Déclaration

    public class HistoriqueService : IHistoriqueService
    {
        #region 3.1 Champs privés

        private readonly List<HistoriqueMiseAJour> _entrees = new();

        #endregion

        #region 3.2 Constructeur

        public HistoriqueService()
        {
        }

        #endregion

        #region 3.3 Méthodes publiques

        public void Ajouter(HistoriqueMiseAJour entree)
        {
            _entrees.Add(entree);
        }

        public IReadOnlyList<HistoriqueMiseAJour> ObtenirTout()
        {
            return new List<HistoriqueMiseAJour>(_entrees).AsReadOnly();
        }

        #endregion
    }

    #endregion
}
