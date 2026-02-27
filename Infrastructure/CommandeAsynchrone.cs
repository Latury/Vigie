/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Infrastructure                                             ║
║  Fichier : CommandeAsynchrone.cs                                     ║
║                                                                      ║
║  Rôle :                                                              ║
║  Implémente une commande asynchrone compatible MVVM.                 ║
║                                                                      ║
║  Responsabilités :                                                   ║
║  - Exécuter une tâche asynchrone                                     ║
║  - S’intégrer au système ICommand                                    ║
║                                                                      ║
║  Limites :                                                           ║
║  - CanExecute toujours vrai                                          ║
║  - Pas de gestion d’état avancée                                     ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Threading.Tasks;
using System.Windows.Input;

#endregion

#region 2. Description Générale

/*
 * Classe : CommandeAsynchrone
 *
 * Rôle :
 * Permet d’exécuter une méthode asynchrone depuis l’interface.
 *
 * Objectif architectural :
 * Remplacer l’ancienne AsyncRelayCommand
 * par une version francisée conforme MVVM.
 */

#endregion

#region 3. Déclaration

namespace Vigie.Infrastructure
{
    public class CommandeAsynchrone : ICommand
    {
        #region 3.1 Champs privés

        private readonly Func<Task> _execute;

        #endregion

        #region 3.2 Constructeur

        public CommandeAsynchrone(Func<Task> execute)
        {
            _execute = execute;
        }

        #endregion

        #region 3.3 ICommand

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public async void Execute(object? parameter)
        {
            await _execute();
        }

        #endregion
    }
}

#endregion