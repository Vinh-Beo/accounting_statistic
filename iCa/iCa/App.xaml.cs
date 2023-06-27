using Common;
using iCa.Helper.Gesture;
using iCa.Services;
using iCa.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iCa
{
    public partial class App : Application
    {

        public App()
        {
            Language.AppResources.Culture = Plugin.Multilingual.CrossMultilingual.Current.DeviceCultureInfo;
            InitializeComponent();
            GoogleSheetHelper _helper = new GoogleSheetHelper();
            FormBase.Service = _helper.Service;
            MainPage = new AppShell();
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
