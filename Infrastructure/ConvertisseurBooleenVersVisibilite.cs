/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Infrastructure                                             ║
║  Fichier : ConvertisseurBooleenVersVisibilite.cs                     ║
║                                                                      ║
║  Rôle :                                                              ║
║  Convertit un booléen en visibilité WinUI.                           ║
║                                                                      ║
║  Responsabilités :                                                   ║
║  - Retourner Visible si true                                         ║
║  - Retourner Collapsed si false                                      ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

#endregion

#region 2. Description Générale

/*
 * Classe : ConvertisseurBooleenVersVisibilite
 *
 * Rôle :
 * Permet de lier un booléen à la propriété Visibility
 * dans les vues XAML.
 */

#endregion

#region 3. Déclaration

namespace Vigie.Infrastructure
{
    public class ConvertisseurBooleenVersVisibilite : IValueConverter
    {
        #region 3.1 Méthodes publiques

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue)
                return boolValue ? Visibility.Visible : Visibility.Collapsed;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /*
     * Classe : ConvertisseurBooleenInverse
     *
     * Rôle :
     * Inverse la visibilité basée sur un booléen.
     */
    public class ConvertisseurBooleenInverse : IValueConverter
    {
        #region 3.2 Méthodes publiques

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool boolValue)
                return boolValue ? Visibility.Collapsed : Visibility.Visible;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

#endregion