using SampleEqp;
using System;
using System.Globalization;

namespace SampleEqp.WPF
{
    public class PrstConverter : ValueConverterBase<PrstConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Prst eqst))
                return value;

            return eqst.ToString().ToUpper();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
