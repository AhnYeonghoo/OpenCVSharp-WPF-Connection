using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helper;
using System.Windows.Data;
using System.Globalization;

namespace Common.Converters
{
    public class Base64ToBitmapImageConverter : IValueConverter
    {

        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            return ImageHelper.Base64ToBitmapImage(value.ToString());
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
