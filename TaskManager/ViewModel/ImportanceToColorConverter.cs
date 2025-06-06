using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using TaskManager.Models;

namespace TaskManager.ViewModel
{
    public class ImportanceToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TaskImportance importance)
            {
                switch (importance)
                {
                    case TaskImportance.Low:
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50")); // Green
                    case TaskImportance.Medium:
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC107")); // Yellow
                    case TaskImportance.High:
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9800")); // Orange
                    case TaskImportance.Critical:
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F44336")); // Red
                    default:
                        return new SolidColorBrush(Colors.Gray);
                }
            }
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 