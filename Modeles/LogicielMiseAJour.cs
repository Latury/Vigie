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
    public class LogicielMiseAJour : INotifyPropertyChanged
    {
        #region 3.1 Champs privés

        private bool _estSelectionne;

        #endregion

        #region 3.2 Propriétés publiques

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
         * pour une mise à jour individuelle.
         */
        public bool EstSelectionne
        {
            get => _estSelectionne;
            set
            {
                if (_estSelectionne != value)
                {
                    _estSelectionne = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region 3.3 INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? nomPropriete = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomPropriete));
        }

        #endregion
    }
}
