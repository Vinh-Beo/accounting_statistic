using Common;
using iCa.Models;
using iCa.ViewModels.Common;
using iCa.ViewModels.Main.Order;
using iCa.Views;
using iCa.Views.Common;
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

            OrdersViewModel _vm = new OrdersViewModel()
            {
                IsBusy = false,
                ResponseOK = true,
                ResponseMessage = "",
                IsStart = true,
                Orders = new ObservableCollection<OrderModel>()
                {
                    //new OrderModel()
                    //{
                    //    Id = 0,
                    //    Name = "Cá đuối",
                    //    Type = ProductCode.StingRay,
                    //    Price = "150",
                    //    Weight = "15",
                    //    CreateTime = DateTime.Now,
                    //},
                    //new OrderModel()
                    //{
                    //    Id = 0,
                    //    Name = "Cá đuối",
                    //    Type = ProductCode.StingRay,
                    //    Price = "170",
                    //    Weight = "10",
                    //    CreateTime = DateTime.Now,
                    //},
                    //new OrderModel()
                    //{
                    //    Id = 0,
                    //    Name = "Cá đuối",
                    //    Type = ProductCode.StingRay,
                    //    Price = "150",
                    //    Weight = "7",
                    //    CreateTime = DateTime.Now,
                    //},
                    //new OrderModel()
                    //{
                    //    Id = 0,
                    //    Name = "Cá bop",
                    //    Type = ProductCode.StingRay,
                    //    Price = "230",
                    //    Weight = "4",
                    //    CreateTime = DateTime.Now,
                    //},
                }
            };
            Task.Factory.StartNew(async () =>
            {
                foreach (OrderModel _order in _vm.Orders)
                {
                    _order.Total = double.Parse(_order.Weight) * double.Parse(_order.Price);
                }

                OrdersPage _p = new OrdersPage(_vm);
                await _vm.AppNavigator.NavigateAsync(_p);
            });
        }

    }
}
