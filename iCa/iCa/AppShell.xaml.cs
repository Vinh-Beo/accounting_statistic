using Common;
using iCa.Models;
using iCa.ViewModels.Common;
using iCa.ViewModels.Main;
using iCa.ViewModels.Main.Order;
using iCa.Views;
using iCa.Views.Common;
using iCa.Views.Main;
using iCa.Views.Main.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Utils;
using Xamarin.Forms;

namespace iCa
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Sharpnado.MaterialFrame.Initializer.Initialize(loggerEnable: false, debugLogEnable: true);

            MainViewModel _vm = new MainViewModel()
            {
                IsBusy = false,
                ResponseOK = true,
                ResponseMessage = "",
                Order = new OrdersViewModel()
                {
                    Orders = new ObservableCollection<OrderModel>()
                }
            };

            Device.BeginInvokeOnMainThread(async () =>
            {
                MainPage _p = new MainPage()
                {
                    BindingContext = _vm
                };
                await _vm.AppNavigator.NavigateAsync(_p);
            });
        }

    }
}
