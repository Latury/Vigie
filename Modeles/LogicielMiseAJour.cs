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
║  - Contenir les informations du logiciel                             ║
║  - Permettre la sélection pour mise à jour                           ║
║  - Exposer l'état de mise à jour pour l'UI                           ║
║  - Notifier les changements pour l'interface                         ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace Vigie.Modeles
{
    #region 2. Déclaration

    public class LogicielMiseAJour : INotifyPropertyChanged
    {

        #region 2.1 Champs privés

        private bool _estSelectionne;

        private bool _selectionAutorisee = true;

        private StatutMiseAJour _statutMiseAJour =
            StatutMiseAJour.EnAttente;

        #endregion


        #region 2.2 Propriétés publiques

        public string Nom { get; set; } = string.Empty;

        public string VersionActuelle { get; set; } = string.Empty;

        public string NouvelleVersion { get; set; } = string.Empty;

        public string Source { get; set; } = string.Empty;

        public string IdentifiantSource { get; set; } = string.Empty;

        public string IdentifiantNormalise { get; set; } = string.Empty;


        /*
         * Propriété : EstSelectionne
         *
         * Rôle :
         * Indique si le logiciel est sélectionné
         * pour une mise à jour.
         */

        public bool EstSelectionne
        {
            get => _estSelectionne;

            set
            {
                if (_estSelectionne == value)
                {
                    return;
                }

                _estSelectionne = value;

                OnPropertyChanged();

                OnSelectionChanged();
            }
        }


        /*
         * Propriété : SelectionAutorisee
         *
         * Rôle :
         * Permet d'empêcher la sélection
         * lorsqu'une mise à jour a déjà été effectuée.
         */

        public bool SelectionAutorisee
        {
            get => _selectionAutorisee;

            set
            {
                if (_selectionAutorisee == value)
                {
                    return;
                }

                _selectionAutorisee = value;

                OnPropertyChanged();
            }
        }


        /*
         * Propriété : StatutMiseAJour
         *
         * Rôle :
         * Indique l'état actuel de la mise à jour.
         */

        public StatutMiseAJour StatutMiseAJour
        {
            get => _statutMiseAJour;

            set
            {
                if (_statutMiseAJour == value)
                {
                    return;
                }

                _statutMiseAJour = value;

                OnPropertyChanged();
            }
        }

        #endregion


        #region 2.3 Événement sélection

        public event EventHandler? SelectionChanged;

        private void OnSelectionChanged()
        {
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion


        #region 2.4 INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? nomPropriete = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(nomPropriete));
        }

        #endregion

    }

    #endregion
}
