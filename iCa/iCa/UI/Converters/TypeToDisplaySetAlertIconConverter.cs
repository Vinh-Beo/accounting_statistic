using System;
using Common;
using Utils;

namespace Converter
{
    public class TypeToDisplaySetAlertIconConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            AlertType _val = (AlertType)value;

            if (_val == AlertType.Error)
            {
                //return "ic_close_circle.svg";
                return "ic_error.svg";
            }
            else if (_val == AlertType.Warning)
            {
                return "ic_alert.svg";
            }
            else if (_val == AlertType.Notification)
            {
                return "ic_bell_ring.svg";
            }
            else if (_val == AlertType.Success)
            {
                return "ic_checkbox.svg";
            }
            else
            {
                return "ic_bell_ring.svg";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
