/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Infrastructure                                             ║
║  Fichier : ConvertisseurBooleenInverse.cs                            ║
║                                                                      ║
║  Rôle :                                                              ║
║  Inverse une valeur booléenne.                                       ║
║                                                                      ║
║  Responsabilités :                                                   ║
║  - Retourner false si true                                           ║
║  - Retourner true si false                                           ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using Microsoft.UI.Xaml.Data;

using System;

#endregion

#region 2. Description Générale

/*
 * Classe : ConvertisseurBooleenInverse
 *
 * Rôle :
 * Inverse une valeur booléenne.
 *
 * Exemple :
 * true  → false
 * false → true
 */

#endregion

namespace Vigie.Infrastructure
{
    #region 3. Déclaration

    public class ConvertisseurBooleenInverse : IValueConverter
    {
        #region 3.1 Méthodes publiques

        public object Convert(
            object value,
            Type targetType,
            object parameter,
            string language)
        {
            if (value is bool b)
            {
                return !b;
            }

            return false;
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #endregion
}
