/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services                                                   ║
║  Fichier : GestionnaireGlobal.cs                                     ║
║                                                                      ║
║  Rôle :                                                              ║
║  Orchestrateur central des gestionnaires de paquets.                 ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Agréger plusieurs sources de mises à jour                         ║
║  - Fusionner les résultats                                           ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigie.Modeles;
using Vigie.Services.Interfaces;

#endregion

namespace Vigie.Services.Gestionnaires
{
    public class GestionnaireGlobal : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly List<IGestionnairePaquets> _gestionnaires;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireGlobal()
        {
            _gestionnaires = new List<IGestionnairePaquets>
            {
                new PackageManagers.GestionnaireWinget()
            };
        }

        #endregion

        #region 3.3 Méthodes

        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            var tousLesResultats = new List<LogicielMiseAJour>();

            foreach (var gestionnaire in _gestionnaires)
            {
                var resultats = await gestionnaire.ScanAsync();
                tousLesResultats.AddRange(resultats);
            }

            // Déduplication simple par nom
            return tousLesResultats
                .GroupBy(l => l.Nom)
                .Select(g => g.First())
                .ToList();
        }

        #endregion
    }
}