using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Globalization;

namespace Common.Converters
{
    public class TextBoxHeightConverter : IMultiValueConverter
    {
        private const double IncreaseHeight = 20;

        public object Convert(
            object[] value,
            Type targetType,
            object parameter,
            CultureInfo culture
            )
        {
            if (parameter is null)
                
        }
    }
}
