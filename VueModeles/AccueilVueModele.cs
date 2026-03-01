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
║  - Interagir avec GestionnaireWinget                                 ║
║  - Exposer la liste des logiciels détectés                           ║
║  - Fournir un état dynamique structuré du système                    ║
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
using Vigie.Infrastructure;
using Vigie.Services.Gestionnaires;

#endregion

#region 2. Description Générale

/*
 * Classe : AccueilVueModele
 *
 * Rôle :
 * Intermédiaire entre la vue Accueil et la logique métier.
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
        #region 3.1 Champs privés

        private readonly IGestionnairePaquets _packageManager;

        private bool _isScanning;
        private EtatSysteme _etatActuel = EtatSysteme.Inconnu;
        private DateTime? _dernierScan;

        #endregion

        #region 3.2 Propriétés publiques

        public ICommand ScannerCommande { get; }

        public ObservableCollection<LogicielMiseAJour> Logiciels { get; }

        public bool IsScanning
        {
            get => _isScanning;
            private set
            {
                _isScanning = value;
                OnPropertyChanged();
            }
        }

        /*
         * État structuré du système (enum).
         */
        public EtatSysteme EtatActuel
        {
            get => _etatActuel;
            private set
            {
                _etatActuel = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TexteEtat));
            }
        }

        /*
         * Texte affiché dans l’UI basé sur l’état.
         */
        public string TexteEtat
        {
            get
            {
                return EtatActuel switch
                {
                    EtatSysteme.AnalyseEnCours => "Analyse en cours...",
                    EtatSysteme.Ajour => "Système à jour",
                    EtatSysteme.MisesAJourDisponibles =>
                        $"{Logiciels.Count} mise(s) à jour disponible(s)",
                    EtatSysteme.Erreur => "Erreur lors du scan",
                    _ => "État inconnu"
                };
            }
        }

        public string DernierScanTexte
        {
            get
            {
                if (_dernierScan == null)
                {
                    return "Dernier scan : jamais effectué";
                }

                return $"Dernier scan : {_dernierScan:dd/MM/yyyy à HH:mm}";
            }
        }

        #endregion

        #region 3.3 Constructeur

        public AccueilVueModele()
        {
            _packageManager = new GestionnaireGlobal();

            Logiciels = new ObservableCollection<LogicielMiseAJour>();

            Logiciels.CollectionChanged += (s, e) =>
            {
                OnPropertyChanged(nameof(TexteEtat));
            };

            ScannerCommande = new CommandeAsynchrone(ScannerAsync);
        }

        #endregion

        #region 3.4 Méthodes

        private async Task ScannerAsync()
        {
            try
            {
                IsScanning = true;
                EtatActuel = EtatSysteme.AnalyseEnCours;

                var resultats = await _packageManager.ScanAsync();

                Logiciels.Clear();

                foreach (var logiciel in resultats)
                {
                    Logiciels.Add(logiciel);
                }

                _dernierScan = DateTime.Now;
                OnPropertyChanged(nameof(DernierScanTexte));

                EtatActuel = Logiciels.Count == 0
                    ? EtatSysteme.Ajour
                    : EtatSysteme.MisesAJourDisponibles;
            }
            catch
            {
                EtatActuel = EtatSysteme.Erreur;
            }
            finally
            {
                IsScanning = false;
            }
        }

        #endregion

        #region 3.5 INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

#endregion
