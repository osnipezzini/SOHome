using SOHome.Fitness.Extensions;
using System.Globalization;

namespace SOHome.Fitness.Converters
{
    internal class EnumToDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum @enum)
                return @enum.GetDisplayName();
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
