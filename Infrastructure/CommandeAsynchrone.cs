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
║  - Gérer l’état d’exécution                                          ║
║  - Bloquer la ré-entrée                                              ║
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
 * Particularité :
 * Empêche l’exécution multiple simultanée.
 */

#endregion

namespace Vigie.Infrastructure
{
    #region 3. Déclaration

    public class CommandeAsynchrone : ICommand
    {
        #region 3.1 Champs privés

        private readonly Func<Task> _execute;
        private bool _estEnExecution;

        #endregion

        #region 3.2 Constructeur

        public CommandeAsynchrone(Func<Task> execute)
        {
            _execute = execute
                ?? throw new ArgumentNullException(nameof(execute));
        }

        #endregion

        #region 3.3 ICommand

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !_estEnExecution;
        }

        public async void Execute(object? parameter)
        {
            if (_estEnExecution)
            {
                return;
            }

            try
            {
                _estEnExecution = true;
                LeverCanExecuteChanged();

                await _execute();
            }
            finally
            {
                _estEnExecution = false;
                LeverCanExecuteChanged();
            }
        }

        #endregion

        #region 3.4 Méthodes privées

        private void LeverCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }

    #endregion
}
