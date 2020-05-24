using System;
using System.Globalization;

namespace IMPLC.Monitor
{
    public class BooleanToInt : ConverterBase<BooleanToInt>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolean))
                return value;

            return (boolean) ? 1 : 0;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}