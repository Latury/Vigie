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
║  - Gérer la sélection globale des logiciels                          ║
║  - Enregistrer l’historique des opérations                           ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

using Vigie.Infrastructure;
using Vigie.Modeles;
using Vigie.Services.Interfaces;
using Vigie.Services.MisesAJour;

#endregion

namespace Vigie.VueModeles
{
    #region 2. Déclaration

    public class AccueilVueModele : INotifyPropertyChanged
    {

        #region 2.1 Champs privés

        private readonly IGestionnairePaquets _packageManager;
        private readonly ServiceMiseAJourGlobal _serviceMiseAJour;
        private readonly IConfirmationService _confirmationService;

        private bool _isScanning;
        private bool _isUpdating;

        private EtatSysteme _etatActuel = EtatSysteme.Inconnu;
        private DateTime? _dernierScan;

        #endregion


        #region 2.2 Propriétés publiques

        public ICommand ScannerCommande { get; }
        public ICommand MettreAJourCommande { get; }

        public ObservableCollection<LogicielMiseAJour> Logiciels { get; }
        public ObservableCollection<HistoriqueMiseAJour> Historique { get; }

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

        public bool PeutScanner =>
            !IsScanning && !IsUpdating;

        public bool PeutMettreAJour =>
            !IsScanning &&
            !IsUpdating &&
            Logiciels.Any(l => l.EstSelectionne && l.SelectionAutorisee);


        /*
         * Sélection globale
         */

        public bool ToutSelectionner
        {
            get
            {
                var selectionnables =
                    Logiciels.Where(l => l.SelectionAutorisee).ToList();

                if (selectionnables.Count == 0)
                {
                    return false;
                }

                return selectionnables.All(l => l.EstSelectionne);
            }

            set
            {
                foreach (var logiciel in Logiciels)
                {
                    if (logiciel.SelectionAutorisee)
                    {
                        logiciel.EstSelectionne = value;
                    }
                }

                OnPropertyChanged(nameof(PeutMettreAJour));
                OnPropertyChanged(nameof(ToutSelectionner));
            }
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
                int restantes =
                    Logiciels.Count(l => l.SelectionAutorisee);

                return EtatActuel switch
                {
                    EtatSysteme.AnalyseEnCours =>
                        "Analyse en cours...",

                    EtatSysteme.Ajour =>
                        "Système à jour",

                    EtatSysteme.MisesAJourDisponibles =>
                        restantes == 0
                        ? "Système à jour"
                        : $"{restantes} mise(s) à jour disponible(s)",

                    EtatSysteme.Erreur =>
                        "Opération bloquée pour raison de sécurité",

                    _ =>
                        "État inconnu"
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


        #region 2.3 Constructeur

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
            Historique = new ObservableCollection<HistoriqueMiseAJour>();

            Logiciels.CollectionChanged += Logiciels_CollectionChanged;

            ScannerCommande = new CommandeAsynchrone(ScannerAsync);
            MettreAJourCommande = new CommandeAsynchrone(MettreAJourAsync);
        }

        #endregion


        #region 2.4 Gestion collection logiciels

        private void Logiciels_CollectionChanged(
            object? sender,
            NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LogicielMiseAJour logiciel in e.NewItems)
                {
                    logiciel.SelectionChanged += Logiciel_SelectionChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (LogicielMiseAJour logiciel in e.OldItems)
                {
                    logiciel.SelectionChanged -= Logiciel_SelectionChanged;
                }
            }

            RafraichirEtatUI();
        }

        private void Logiciel_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            RafraichirEtatUI();
        }

        #endregion


        #region 2.5 Méthodes privées

        private void RecalculerEtatSysteme()
        {
            int restantes =
                Logiciels.Count(l => l.SelectionAutorisee);

            EtatActuel =
                restantes == 0
                ? EtatSysteme.Ajour
                : EtatSysteme.MisesAJourDisponibles;
        }


        private void RafraichirEtatUI()
        {
            OnPropertyChanged(nameof(ToutSelectionner));
            OnPropertyChanged(nameof(PeutMettreAJour));
            OnPropertyChanged(nameof(TexteEtat));
        }


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
                    Logiciels.Add(new LogicielMiseAJour
                    {
                        Nom = logiciel.Nom,
                        VersionActuelle = logiciel.VersionActuelle,
                        NouvelleVersion = logiciel.NouvelleVersion,
                        Source = logiciel.Source,
                        IdentifiantSource = logiciel.IdentifiantSource,
                        IdentifiantNormalise = logiciel.IdentifiantNormalise
                    });
                }

                _dernierScan = DateTime.Now;

                OnPropertyChanged(nameof(DernierScanTexte));

                RecalculerEtatSysteme();
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
            if (!Logiciels.Any(l => l.EstSelectionne && l.SelectionAutorisee) || IsUpdating)
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

                foreach (var logiciel in Logiciels.Where(l => l.EstSelectionne && l.SelectionAutorisee))
                {
                    if (string.IsNullOrWhiteSpace(logiciel.Source))
                    {
                        continue;
                    }

                    logiciel.StatutMiseAJour = StatutMiseAJour.EnCours;

                    var resultat =
                        await _serviceMiseAJour
                            .ExecuterMiseAJourAsync(logiciel);

                    if (resultat.Statut == StatutMiseAJour.Succes)
                    {
                        logiciel.EstSelectionne = false;
                        logiciel.SelectionAutorisee = false;
                    }

                    AjouterHistorique(resultat);
                }

                RecalculerEtatSysteme();
                RafraichirEtatUI();
            }
            finally
            {
                IsUpdating = false;
            }
        }


        private void AjouterHistorique(ResultatMiseAJour resultat)
        {
            Historique.Add(
                new HistoriqueMiseAJour
                {
                    Nom = resultat.Nom,
                    VersionAvant = resultat.VersionAvant,
                    VersionApres = resultat.VersionApres,
                    Source = resultat.Source,
                    Statut = resultat.Statut,
                    MessageErreur = resultat.MessageErreur
                });
        }

        #endregion


        #region 2.6 INotifyPropertyChanged

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
