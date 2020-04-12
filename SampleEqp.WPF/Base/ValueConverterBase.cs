using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace SampleEqp.WPF
{
    public abstract class ValueConverterBase<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {

        #region Private Members

        private static T _Converter = null;

        #endregion


        #region Markup Extensions Methods

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _Converter ?? (_Converter = new T());
        }

        #endregion


        #region Value Converter Methods

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture); 

        #endregion


    }
}
