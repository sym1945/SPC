using System;
using System.Globalization;

namespace SampleEqp.WPF
{
    public class EqstConverter : ValueConverterBase<EqstConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Eqst eqst))
                return value;

            return eqst.ToString().ToUpper();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
