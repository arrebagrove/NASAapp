using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace NASAapp.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }
            try
            {
                bool isVisible = (bool)value;
                return isVisible ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (InvalidCastException)
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return false;
            }

            try
            {
                Visibility vis = (Visibility)value;
                if (vis == Visibility.Collapsed)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }
    }
}
