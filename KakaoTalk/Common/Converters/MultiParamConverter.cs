using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Threading.Tasks;

namespace Common.Converters
{
    public class MultiParamConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            return values.Clone();
        }
        public object[] ConvertBack(object values, Type[] targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
