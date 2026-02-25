/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : VueModeles                                                 ║
║  Fichier : AccueilVueModele.cs                                       ║
║                                                                      ║
║  Rôle :                                                              ║
║  Gère la logique de la page Accueil.                                 ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Exposer la commande de scan                                       ║
║  - Interagir avec IPackageManager                                    ║
║                                                                      ║
║  Dépendances :                                                       ║
║  - IPackageManager                                                   ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Threading.Tasks;
using System.Windows.Input;
using Vigie.Services.Interfaces;
using Vigie.Services.PackageManagers;

#endregion

#region 2. Description Générale

/*
 * Classe : AccueilVueModele
 *
 * Rôle :
 * Intermédiaire entre la vue Accueil et la logique métier.
 *
 * Objectif architectural :
 * Respecter le pattern MVVM strict.
 *
 * Limites :
 * - Pas encore de gestion d’état
 * - Pas encore de binding complexe
 */

#endregion

#region 3. Déclaration

namespace Vigie.VueModeles
{
    public class AccueilVueModele
    {
        #region 3.1 Propriétés

        private readonly IPackageManager _packageManager;

        public ICommand ScannerCommande { get; }

        #endregion

        #region 3.2 Constructeur

        public AccueilVueModele()
        {
            _packageManager = new WingetManager();
            ScannerCommande = new AsyncRelayCommand(ScannerAsync);
        }

        #endregion

        #region 3.3 Méthodes

        private async Task ScannerAsync()
        {
            await _packageManager.ScanAsync();
        }

        #endregion
    }
}

#endregion