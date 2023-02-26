using Avalonia.Data.Converters;
using Avalonia.Data;
using Avalonia.Media;
using System;
using System.Globalization;


namespace StudentsProgress.Converters
{
    public class ScoreColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is ushort score && targetType.IsAssignableTo(typeof(IBrush)))
            {
                switch (score)
                {
                    case 0: return new SolidColorBrush(Colors.Red);
                    case 1: return new SolidColorBrush(Colors.Yellow);
                    case 2: return new SolidColorBrush(Colors.Green);
                    default: break;
                }
            }
            if (value is float sr_score && targetType.IsAssignableTo(typeof(IBrush)))
            {
                if (sr_score < 1) return new SolidColorBrush(Colors.Red);
                if (sr_score < 1.5) return new SolidColorBrush(Colors.Yellow);
                else return new SolidColorBrush(Colors.Green);
            }
            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
