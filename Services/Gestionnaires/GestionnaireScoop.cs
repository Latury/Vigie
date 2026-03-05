/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Gestionnaires                                     ║
║  Fichier : GestionnaireScoop.cs                                      ║
║                                                                      ║
║  Rôle :                                                              ║
║  Gestionnaire simulé de paquets Scoop.                               ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Simuler un scan Scoop                                             ║
║  - Retourner une liste de LogicielMiseAJour                          ║
║                                                                      ║
║  Limites :                                                           ║
║  - Simulation uniquement (pas d’appel système réel)                  ║
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

#region 2. Description Générale

/*
 * Classe : GestionnaireScoop
 *
 * Rôle :
 * Simuler un gestionnaire Scoop afin de tester
 * le pipeline complet de Vigie.
 */

#endregion

namespace Vigie.Services.Gestionnaires
{
    #region 3. Déclaration

    public class GestionnaireScoop : IGestionnairePaquets
    {
        #region 3.1 Champs privés

        private readonly IJournalService _journal;

        #endregion

        #region 3.2 Constructeur

        public GestionnaireScoop(IJournalService journal)
        {
            _journal =
                journal ?? throw new System.ArgumentNullException(nameof(journal));
        }

        #endregion

        #region 3.3 Méthodes publiques

        public async Task<List<LogicielMiseAJour>> ScanAsync()
        {
            _journal.Info(">>> SCOOP EST APPELÉ <<<");

            await Task.CompletedTask;

            var sortieSimulee = @"
Name        Current    Available
--------------------------------
notepadplusplus    8.9.1    8.9.2
githubdesktop      3.5.4    3.5.5
vlc                3.0.20   3.0.21
";

            var resultats = new List<LogicielMiseAJour>();

            var lignes = sortieSimulee
                .Split('\n', System.StringSplitOptions.RemoveEmptyEntries)
                .Skip(2);

            foreach (var ligne in lignes)
            {
                var colonnes = ligne
                    .Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

                if (colonnes.Length >= 3)
                {
                    var identifiant = colonnes[0];

                    var logiciel = new LogicielMiseAJour
                    {
                        Nom = colonnes[0],
                        VersionActuelle = colonnes[1],
                        NouvelleVersion = colonnes[2],
                        Source = "scoop",
                        IdentifiantSource = identifiant
                    };

                    resultats.Add(logiciel);
                }
            }

            _journal.Info($"{resultats.Count} mise(s) simulée(s) depuis Scoop.");

            return resultats;
        }

        #endregion
    }

    #endregion
}
