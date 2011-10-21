using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace MenuPrincipal
{
    [ValueConversion(typeof(double), typeof(int))]
    public class ConverterEntero : IValueConverter
    {

        #region Miembros de IValueConverter

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double valor = double.Parse(value.ToString());
            return (int)valor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double valor = int.Parse(value.ToString());
            return valor;
        }

        #endregion
    }
}
