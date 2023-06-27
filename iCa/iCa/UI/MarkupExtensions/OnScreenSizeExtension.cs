using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using Common;

namespace UI
{
    class OnScreenSizeExtension : IMarkupExtension
    {
        
        private Dictionary<eScreenSizes, object> _values = new Dictionary<eScreenSizes, object>() {
            { eScreenSizes.ExtraSmall, null},
            { eScreenSizes.Small, null},
            { eScreenSizes.Medium,  null},
            { eScreenSizes.Large,  null},
            { eScreenSizes.ExtraLarge,  null},
        };

        public OnScreenSizeExtension()
        {
        }


        /// <summary>
        /// Screen-size do device.
        /// </summary>
        private static eScreenSizes? deviceScreenSize;

        /// <summary>
        /// Tamanho-padrao na tela que deve ser assumido quando não for possivel determinar o tamanho dela com base na lista <see cref="_screenSizes"/>
        /// </summary>
        public object DefaultSize { get; set; }


        public object ExtraSmall
        {
            get
            {

                return _values[eScreenSizes.ExtraSmall];
            }
            set
            {
                _values[eScreenSizes.ExtraSmall] = value;
            }
        }

        public object Small
        {
            get
            {

                return _values[eScreenSizes.Small];
            }
            set
            {
                _values[eScreenSizes.Small] = value;
            }
        }
        public object Medium
        {
            get
            {

                return _values[eScreenSizes.Medium];
            }
            set
            {
                _values[eScreenSizes.Medium] = value;
            }
        }

        public object Large
        {
            get
            {

                return _values[eScreenSizes.Large];
            }
            set
            {
                _values[eScreenSizes.Large] = value;
            }
        }

        public object ExtraLarge
        {
            get
            {

                return _values[eScreenSizes.ExtraLarge];
            }
            set
            {
                _values[eScreenSizes.ExtraLarge] = value;
            }
        }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var valueProvider = serviceProvider?.GetService<IProvideValueTarget>() ?? throw new ArgumentException();

            BindableProperty bp;
            PropertyInfo pi = null;
            Type propertyType = null;

            if (valueProvider.TargetObject is Setter setter)
            {
                bp = setter.Property;
            }
            else
            {
                bp = valueProvider.TargetProperty as BindableProperty;
                pi = valueProvider.TargetProperty as PropertyInfo;
            }

            propertyType = bp?.ReturnType ?? pi?.PropertyType ?? throw new InvalidOperationException("Could not determine property to provide value");

            var value = GetValue(serviceProvider);

            return value.ConvertTo(propertyType, bp);
        }

        private object GetValue(IServiceProvider serviceProvider)
        {
            var screenSize = GetScreenSize();
            if (screenSize != eScreenSizes.NotSet)
            {
                if (_values[screenSize] != null)
                {
                    return _values[screenSize];
                }
            }

            if (DefaultSize == null)
            {
                throw new XamlParseException("OnScreenExtension requires a DefaultSize set.");
            }
            else
            {
                return DefaultSize;
            }
        }


        private eScreenSizes GetScreenSize()
        {
            if (TryGetScreenSize(out var screenSize))
            {
                return screenSize;
            }

            return eScreenSizes.NotSet;
        }


        private static bool TryGetScreenSize(out eScreenSizes screenSize)
        {
            if (deviceScreenSize != null)
            {
                if (deviceScreenSize.Value == eScreenSizes.NotSet)
                {
                    screenSize = deviceScreenSize.Value;
                    return false;
                }
                else
                {
                    screenSize = deviceScreenSize.Value;
                    return true;
                }
            }


            var device = DeviceDisplay.MainDisplayInfo;

            var deviceWidth = device.Width;
            var deviceHeight = device.Height;


            if (Xamarin.Essentials.DeviceInfo.Idiom == Xamarin.Essentials.DeviceIdiom.Tablet)
            {
                deviceWidth = Math.Max(device.Width, device.Height);
                deviceHeight = Math.Min(device.Width, device.Height);
            }


            foreach (var sizeInfo in FormBase.ScreenSizes)
            {
                if (deviceWidth <= sizeInfo.Width &&
                    deviceHeight <= sizeInfo.Height)
                {
                    deviceScreenSize = sizeInfo.ScreenSize;
                    screenSize = deviceScreenSize.Value;
                    return true;
                }
            }

            deviceScreenSize = eScreenSizes.NotSet;
            screenSize = deviceScreenSize.Value;
            return false;
        }
    }

    public class ScreenInfo
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public eScreenSizes ScreenSize { get; set; }

        public ScreenInfo()
        {

        }
        public ScreenInfo(int _width, int _height, eScreenSizes _screenSize)
        {
            Height = _height;
            Width = _width;
            ScreenSize = _screenSize;
        }
    }
    public enum eScreenSizes
    {
        /// <summary>
        /// Extra small
        /// </summary>
        ExtraSmall = 1,
        /// <summary>
        /// Small
        /// </summary>
        Small = 2,
        /// <summary>
        /// Medium
        /// </summary>
        Medium = 3,
        /// <summary>
        /// Large
        /// </summary>
        Large = 4,
        /// <summary>
        /// Extra large
        /// </summary>
        ExtraLarge = 5,
        /// <summary>
        /// No set
        /// </summary>
        NotSet = 6,
    }
}
