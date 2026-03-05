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
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace Vigie.Modeles
{
    #region 2. Description Générale

    /*
     * Classe : LogicielMiseAJour
     *
     * Rôle :
     * Modèle représentant un logiciel détecté
     * avec une mise à jour disponible.
     *
     * Utilisation :
     * - Liste affichée dans l'interface
     * - Support sélection utilisateur
     * - Support statut de mise à jour
     */

    #endregion

    #region 3. Déclaration

    public class LogicielMiseAJour : INotifyPropertyChanged
    {
        #region 3.1 Champs privés

        private bool _estSelectionne;
        private StatutMiseAJour? _statutMiseAJour;

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

        /*
         * Propriété : StatutMiseAJour
         *
         * Rôle :
         * Indique l'état actuel de la mise à jour
         * pour ce logiciel.
         *
         * Utilisation :
         * - Feedback visuel dans l'interface
         * - Préparation historique futur
         */

        public StatutMiseAJour? StatutMiseAJour
        {
            get => _statutMiseAJour;
            set
            {
                if (_statutMiseAJour != value)
                {
                    _statutMiseAJour = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region 3.3 INotifyPropertyChanged

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
