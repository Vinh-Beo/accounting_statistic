using System;
using Common;
using Utils;

namespace Converter
{
    public class TypeToDisplaySetAlertColorConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            AlertType _val = (AlertType)value;

            if (_val == AlertType.Error)
            {
                return AppColors.RedColor;
            }
            else if (_val == AlertType.Warning)
            {
                return AppColors.IconYellowColor;
            }
            else if (_val == AlertType.Notification)
            {
                return AppColors.OrangeColor;
            }
            else if (_val == AlertType.Success)
            {
                return AppColors.GreenColor;
            }
            else
            {
                return AppColors.PrimaryColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
