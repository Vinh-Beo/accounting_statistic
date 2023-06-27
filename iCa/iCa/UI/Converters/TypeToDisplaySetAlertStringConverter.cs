using System;
using Common;
using iCa.Language;
using Utils;

namespace Converter
{
    public class TypeToDisplaySetAlertStringConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            AlertType _val = (AlertType)value;

            if (_val == AlertType.Error)
            {
                return AppResources.Error;
            }
            else if (_val == AlertType.Warning)
            {
                return AppResources.Warning;
            }
            else if (_val == AlertType.Notification)
            {
                return AppResources.Notification;
            }
            else if (_val == AlertType.Success)
            {
                return AppResources.Success;
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
