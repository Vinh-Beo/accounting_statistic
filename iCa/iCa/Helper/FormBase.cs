using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Threading;
using Google.Apis.Sheets.v4;
using SkiaSharp;
using UI;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Common
{
    public class FormBase
    {
        public static SheetsService Service = new SheetsService();
        public static CancellationTokenSource Cts = new CancellationTokenSource();
        public static bool IsDoServiceOS = false;
        public static DeviceInfo DeviceInfo = new DeviceInfo();
        public static List<ScreenInfo> ScreenSizes = new List<ScreenInfo>
        {
            { new ScreenInfo(480,800, eScreenSizes.ExtraSmall)}, //Samsung Galaxy S,
            { new ScreenInfo(720,1280, eScreenSizes.Small)}, //Nesus S
            { new ScreenInfo(828,1792, eScreenSizes.Medium)}, //iphone 11
            { new ScreenInfo(1284,2778, eScreenSizes.Large)}, //Apple iPhone 12 Pro Max
            { new ScreenInfo(1440,3200, eScreenSizes.ExtraLarge)}, //Samsung Galaxy S20+	
            { new ScreenInfo(2732,2048, eScreenSizes.ExtraLarge)}, //Apple iPad Pro 12.9
        };

        public eScreenSizes getSceneSizeType(double deviceWidth, double deviceHeight)
        {
            eScreenSizes deviceScreenSize = eScreenSizes.NotSet;
            foreach (var sizeInfo in ScreenSizes)
            {
                if (deviceWidth <= sizeInfo.Width &&
                    deviceHeight <= sizeInfo.Height)
                {
                    deviceScreenSize = sizeInfo.ScreenSize;
                    break;
                }
            }
            return deviceScreenSize;
        }
        public static void InitializeSheetService(bool _isIsDarkMode)
        {
            
        }
        public static void SetDarkMode(bool _isIsDarkMode)
        {
            Common.Settings.IsDarkMode = _isIsDarkMode;
            if (!Common.Settings.IsDarkMode)
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
        }
    }
    public class DeviceInfo
    {
        public double Height = 360;
        public double Width = 640;
        public double Density = 1;
        public static eScreenSizes ScreenSizesType;

        public DeviceInfo()
        {
            Density = DeviceDisplay.MainDisplayInfo.Density;
            Height = DeviceDisplay.MainDisplayInfo.Height;
            Width = DeviceDisplay.MainDisplayInfo.Width;
            ScreenSizesType = eScreenSizes.NotSet;
        }
    }
}
