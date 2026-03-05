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
║  - Exposer la commande de mise à jour                                ║
║  - Interagir avec les services                                       ║
║  - Gérer la confirmation utilisateur                                 ║
║  - Superviser la mise à jour globale                                 ║
║  - Gérer l’état des boutons UI                                       ║
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

using Vigie.Infrastructure;
using Vigie.Modeles;
using Vigie.Services.Interfaces;
using Vigie.Services.MisesAJour;
using Vigie.Services.MisesAJour;

#endregion

#region 2. Description Générale

/*
 * Classe : AccueilVueModele
 *
 * Rôle :
 * Intermédiaire entre l'interface utilisateur
 * et les services métier.
 *
 * Particularités :
 * - Gestion état UI
 * - Activation dynamique des boutons
 * - Supervision pipeline de mise à jour
 */

#endregion

namespace Vigie.VueModeles
{
    #region 3. Déclaration

    public class AccueilVueModele : INotifyPropertyChanged
    {
        #region 3.1 Champs privés

        private readonly IGestionnairePaquets _packageManager;
        private readonly ServiceMiseAJourGlobal _serviceMiseAJour;
        private readonly IConfirmationService _confirmationService;

        private bool _isScanning;
        private bool _isUpdating;

        private EtatSysteme _etatActuel = EtatSysteme.Inconnu;
        private DateTime? _dernierScan;

        #endregion

        #region 3.2 Propriétés publiques

        public ICommand ScannerCommande { get; }
        public ICommand MettreAJourCommande { get; }

        public ObservableCollection<LogicielMiseAJour> Logiciels { get; }

        public bool IsScanning
        {
            get => _isScanning;
            private set
            {
                _isScanning = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PeutScanner));
                OnPropertyChanged(nameof(PeutMettreAJour));
            }
        }

        public bool IsUpdating
        {
            get => _isUpdating;
            private set
            {
                _isUpdating = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PeutScanner));
                OnPropertyChanged(nameof(PeutMettreAJour));
            }
        }

        public bool PeutScanner
        {
            get => !IsScanning && !IsUpdating;
        }

        public bool PeutMettreAJour
        {
            get => !IsScanning &&
                   !IsUpdating &&
                   Logiciels.Count > 0;
        }

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
                    EtatSysteme.Erreur =>
                        "Opération bloquée pour raison de sécurité",
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

        public AccueilVueModele(
            IGestionnairePaquets packageManager,
            ServiceMiseAJourGlobal serviceMiseAJour,
            IConfirmationService confirmationService)
        {
            _packageManager =
                packageManager ?? throw new ArgumentNullException(nameof(packageManager));

            _serviceMiseAJour =
                serviceMiseAJour ?? throw new ArgumentNullException(nameof(serviceMiseAJour));

            _confirmationService =
                confirmationService ?? throw new ArgumentNullException(nameof(confirmationService));

            Logiciels = new ObservableCollection<LogicielMiseAJour>();

            Logiciels.CollectionChanged += (_, __) =>
            {
                OnPropertyChanged(nameof(TexteEtat));
                OnPropertyChanged(nameof(PeutMettreAJour));
            };

            ScannerCommande = new CommandeAsynchrone(ScannerAsync);
            MettreAJourCommande = new CommandeAsynchrone(MettreAJourAsync);
        }

        #endregion

        #region 3.4 Méthodes privées

        private async Task ScannerAsync()
        {
            if (IsScanning || IsUpdating)
            {
                return;
            }

            try
            {
                IsScanning = true;

                EtatActuel = EtatSysteme.AnalyseEnCours;

                var resultats =
                    await _packageManager.ScanAsync();

                Logiciels.Clear();

                foreach (var logiciel in resultats)
                {
                    Logiciels.Add(logiciel);
                }

                _dernierScan = DateTime.Now;

                OnPropertyChanged(nameof(DernierScanTexte));

                EtatActuel =
                    Logiciels.Count == 0
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

        private async Task MettreAJourAsync()
        {
            if (Logiciels.Count == 0 || IsUpdating)
            {
                return;
            }

            bool confirme =
                await _confirmationService
                    .DemanderConfirmationAsync(
                        "Confirmer la mise à jour globale ?",
                        "Un point de restauration système sera créé avant exécution.");

            if (!confirme)
            {
                return;
            }

            IsUpdating = true;

            try
            {
                bool pointOk =
                    await _serviceMiseAJour
                        .PreparerPointRestaurationAsync();

                if (!pointOk)
                {
                    EtatActuel = EtatSysteme.Erreur;
                    return;
                }

                foreach (var logiciel in Logiciels)
                {
                    if (string.IsNullOrWhiteSpace(logiciel.Source))
                    {
                        continue;
                    }

                    logiciel.StatutMiseAJour = StatutMiseAJour.EnCours;

                    var resultat =
                        await _serviceMiseAJour
                            .ExecuterMiseAJourAsync(logiciel);

                    logiciel.StatutMiseAJour = resultat.Statut;
                }

                EtatActuel = EtatSysteme.Ajour;
            }
            finally
            {
                IsUpdating = false;
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

    #endregion
}
