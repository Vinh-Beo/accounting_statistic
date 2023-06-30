using Common;
using iCa.Helper.Gesture;
using iCa.Services;
using iCa.ViewModels.Auth;
using iCa.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iCa
{
    public partial class App : Application
    {

        public App()
        {
            FormBase.SetDarkMode(false);
            Language.AppResources.Culture = Plugin.Multilingual.CrossMultilingual.Current.DeviceCultureInfo;
            InitializeComponent();
            GoogleSheetHelper _helper = new GoogleSheetHelper();
            FormBase.Service = _helper.Service;
            Application.Current.MainPage = new AppShell()
            {
                BindingContext = new StartupViewModel()
                {
                    IsBusy = true,
                    ResponseOK = true,
                    ResponseMessage = ""
                }
            };
            Application.Current.MainPage.SizeChanged += (o, e) =>
            {
                FormBase.DeviceInfo.Density = DeviceDisplay.MainDisplayInfo.Density;
                FormBase.DeviceInfo.Width = Application.Current.MainPage.Width;
                FormBase.DeviceInfo.Height = Application.Current.MainPage.Height;
            };
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
