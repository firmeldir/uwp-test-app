using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.UI.Xaml.Data;

namespace UWP.Converter
{
    public class MoneyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            return ((Int32)value).ToString() + "   [̲̅$̲̅(̲̅ ͡° ͜ʖ ͡°̲̅)̲̅$̲̅]";
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
