using Common;
using iCa.Models;
using iCa.ViewModels.Main.Order.Detail.Popup;
using Rg.Plugins.Popup.Pages;
using Sharpnado.MaterialFrame;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using iCa.Views.Main.Order.Detail.ItemsList;
using iCa.ViewModels.Main.Order.Detail.ItemsList;

namespace iCa.Views.Main.Order.Detail.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderItemDetailPopup : PopupPage
    {
        public OrderItemDetailPopup()
        {
            InitializeComponent();

            this.BindingContextChanged += (o, e) =>
            {
                if (BindingContext == null)
                {
                    return;
                }
                if (BindingContext.GetType() != typeof(OrderItemDetailViewModel))
                {
                    return;
                }

                OrderItemDetailViewModel _vm = BindingContext as OrderItemDetailViewModel;

                var _Query = _vm.Orders.Select(x => x.Price).GroupBy(s => s).Select(g => new { Price = g.Key, Count = g.Count() });
                foreach (var _result in _Query)
                {
                    List<OrderModel> _list = _vm.Orders.Where(p => p.Price == _result.Price).ToList();

                    // Set total
                    double _weightTotal = 0;
                    double _priceTotal = 0;
                    foreach (OrderModel item in _list)
                    {
                        _priceTotal += item.Total;
                        _weightTotal += double.Parse(item.Weight);
                    }

                    // Set height
                    double _height = 0;
                    if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
                    {
                        _height = FormBase.DeviceInfo.Height * 0.2;
                    }
                    else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
                    {
                        _height = FormBase.DeviceInfo.Height * 0.2;
                    }
                    else
                    {
                        _height = FormBase.DeviceInfo.Height * 0.2;
                    }

                    ItemsListView _lvInfo = new ItemsListView()
                    {
                        HeightRequest = _height,
                        BindingContext = new ItemsListViewModel()
                        {
                            IsBusy = false,
                            ResponseOK = true,
                            ResponseMessage = "",
                            Items = _list,
                            PriceTotal = _priceTotal,
                            WeightTotal = _weightTotal,
                        }
                    };
                    spnlMain.Children.Add(_lvInfo);
                }
            };
        }
    }
}