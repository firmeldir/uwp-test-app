﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Converter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Data;

    namespace UWP.Converter
    {
        public class ObjectExistToVisible : IValueConverter
        { 
            public object Convert(object value, Type targetType, object parameter, string culture)
            {
                return (value == null) ? Windows.UI.Xaml.Visibility.Collapsed
                    : Windows.UI.Xaml.Visibility.Visible;
            }

            public object ConvertBack(object value, Type targetType,
                object parameter, string culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
