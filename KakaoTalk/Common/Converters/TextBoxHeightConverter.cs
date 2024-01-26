﻿using System;
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
                throw new Exception("There is no parameter set value.");

            string inputValue = value[0].ToString()!;
            Int16 maxNewLineCnt = Int16.Parse(value[1].ToString()!);
            double maxHeight = double.Parse(value[2].ToString()!);
            double defaultHeight = double.Parse(parameter.ToString()!);

            int newLineCnt = inputValue.Split(new string[] { "\r\n" }, StringSplitOptions.None).Length;

            if (newLineCnt >= maxNewLineCnt)
            {
                var height = defaultHeight + ((newLineCnt - maxNewLineCnt) * IncreaseHeight);
                if (height >= maxHeight)
                {
                    return maxHeight;
                }
                else
                {
                    return height;
                }
            }
            else
            {
                return defaultHeight;
            }
        }

        public object[] ConvertBack(
            object value,
            Type[] targetType,
            object parameter,
            CultureInfo culture)
        {
            return null;
        }
    }
}
