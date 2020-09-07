﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfSamples
{
    public class WidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 2 && values[0] is double textWidth && values[1] is double canvasWidth)
            {
                if (textWidth < canvasWidth)
                    return 0;
                return -textWidth;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class DurationConverter : IMultiValueConverter
    {
        public float WidthForSecond = 50;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length >= 2 && values[0] is double textWidth && values[1] is double canvasWidth)
            {
                if (textWidth < canvasWidth)
                    return new Duration(new TimeSpan(0, 0, 0));
                int time = (int)(textWidth / WidthForSecond);
                Duration duration = new Duration(new TimeSpan(0, 0, time));
                return duration;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
