using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SmartVendingMachineManager.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                return status switch
                {
                    "Online" => new SolidColorBrush(Colors.Green),
                    "Offline" => new SolidColorBrush(Colors.Red),
                    "Needs Restock" => new SolidColorBrush(Colors.Orange),
                    "Maintenance Required" => new SolidColorBrush(Colors.Black),
                    _ => new SolidColorBrush(Colors.Gray)
                };
            }
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}