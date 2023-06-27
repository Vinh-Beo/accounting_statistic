using System;
using System.Windows.Input;
using Utils;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace iCa.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}