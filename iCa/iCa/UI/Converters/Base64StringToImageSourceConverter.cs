using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace Converter
{
    class Base64StringToImageSourceConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            if (value.GetType() != typeof(byte[]))
            {
                return null;
            }   
            byte[] _imgBuffer = (byte[])value;

            return ImageSource.FromStream(() => { return new MemoryStream(_imgBuffer); });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
