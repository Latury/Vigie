/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Infrastructure                                             ║
║  Fichier : StatutMiseAJourCouleurConverter.cs                        ║
║                                                                      ║
║  Rôle :                                                              ║
║  Convertit un StatutMiseAJour en couleur UI.                         ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Améliorer la lisibilité du statut dans l'interface                ║
║  - Fournir un feedback visuel immédiat                               ║
║                                                                      ║
║  Limites :                                                           ║
║  - Utilisation uniquement côté interface                             ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;

using Vigie.Modeles;

#endregion

namespace Vigie.Infrastructure.Convertisseurs
{
    #region 2. Déclaration

    public class StatutMiseAJourCouleurConverter : IValueConverter
    {
        #region 3.1 Méthodes publiques

        public object Convert(
            object value,
            System.Type targetType,
            object parameter,
            string language)
        {
            if (value is not StatutMiseAJour statut)
            {
                return new SolidColorBrush(Colors.Gray);
            }

            return statut switch
            {
                StatutMiseAJour.EnAttente =>
                    new SolidColorBrush(Colors.Gray),

                StatutMiseAJour.EnCours =>
                    new SolidColorBrush(Colors.DeepSkyBlue),

                StatutMiseAJour.Succes =>
                    new SolidColorBrush(Colors.LimeGreen),

                StatutMiseAJour.Echec =>
                    new SolidColorBrush(Colors.Red),

                StatutMiseAJour.Timeout =>
                    new SolidColorBrush(Colors.Orange),

                _ =>
                    new SolidColorBrush(Colors.Gray)
            };
        }

        public object ConvertBack(
            object value,
            System.Type targetType,
            object parameter,
            string language)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }

    #endregion
}
