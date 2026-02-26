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
║  - Exposer la liste des logiciels détectés                           ║
║  - Fournir un état dynamique du système                              ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Vigie.Modeles;
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
 * Particularité :
 * Implémente INotifyPropertyChanged pour permettre
 * la mise à jour dynamique de l’interface.
 */

#endregion

#region 3. Déclaration

namespace Vigie.VueModeles
{
    public class AccueilVueModele : INotifyPropertyChanged
    {
        #region 3.1 Propriétés privées

        private readonly IPackageManager _packageManager;

        #endregion

        #region 3.2 Propriétés publiques

        private bool _isScanning;

        public bool IsScanning
        {
            get => _isScanning;
            private set
            {
                _isScanning = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(EtatSysteme));
            }
        }

        public ICommand ScannerCommande { get; }

        public ObservableCollection<LogicielMiseAJour> Logiciels { get; }

        /*
         * Propriété calculée représentant l’état du système.
         */
        public string EtatSysteme
        {
            get
            {
                if (IsScanning)
                    return "Analyse en cours...";

                return Logiciels.Count == 0
                    ? "Système à jour"
                    : $"{Logiciels.Count} mise(s) à jour disponible(s)";
            }
        }

        #endregion

        #region 3.3 Constructeur

        public AccueilVueModele()
        {
            _packageManager = new WingetManager();

            Logiciels = new ObservableCollection<LogicielMiseAJour>();

            // Quand la collection change → notifier l’état
            Logiciels.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(EtatSysteme));
            };

            ScannerCommande = new AsyncRelayCommand(ScannerAsync);
        }

        private DateTime? _dernierScan;

        public string DernierScanTexte
        {
            get
            {
                if (_dernierScan == null)
                    return "Dernier scan : jamais effectué";

                return $"Dernier scan : {_dernierScan:dd/MM/yyyy à HH:mm}";
            }
        }

        #endregion

        #region 3.4 Méthodes

        private async Task ScannerAsync()
        {
            IsScanning = true;

            var resultats = await _packageManager.ScanAsync();

            Logiciels.Clear();

            foreach (var logiciel in resultats)
            {
                Logiciels.Add(logiciel);
            }

            _dernierScan = DateTime.Now;

            OnPropertyChanged(nameof(DernierScanTexte));

            IsScanning = false;
        }

        #endregion

        #region 3.5 INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

#endregion