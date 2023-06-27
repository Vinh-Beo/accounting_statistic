using System;
using Utils;
using Xamarin.Forms;

namespace Converter
{
    public class BoolToColorWhiteRedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                if (!Common.Settings.IsDarkMode)
                {
                    return Color.DarkGray;
                }
                else
                {
                    return AppColors.TextPrimaryDescriptionDarkColor;
                }
            }
            else
            {
                return Color.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
