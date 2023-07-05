using iCa.Models;
using iCa.ViewModels.Main.Order;
using iCa.ViewModels.Main.Order.Detail;
using iCa.ViewModels.Main.Order.Detail.Popup;
using iCa.Views.Main.Order.Detail.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iCa.Views.Main.Order.Detail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailPage : ContentPage
    {
        public OrderDetailPage(OrderDetailViewModel _vm)
        {
            InitializeComponent();
            BindingContext = _vm;
            _vm.DisplBack = new Action(() =>
            {
                _vm.AppNavigator.GoBackAsync(true);
            });
        }

        async void Handle_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(OrderDetailViewModel))
            {
                return;
            }
            OrderDetailViewModel _vm = BindingContext as OrderDetailViewModel;

            if (PopupNavigation.Instance.PopupStack.Count > 0)
            {
                await _vm.AppNavigator.PopAllAsync(true);
            }
            if (e.SelectedItem == null)
            {
                return;
            }
            if (e.SelectedItem.GetType() != typeof(OrderDetailModel))
            {
                return;
            }
            OrderDetailModel _obj = (OrderDetailModel)e.SelectedItem;


            OrderItemDetailViewModel _vmDetail = new OrderItemDetailViewModel()
            {
                IsBusy = false,
                ResponseOK = true,
                ResponseMessage = "",
                Orders = _obj.Orders,
            };

            OrderItemDetailPopup _pDetail = new OrderItemDetailPopup()
            {
                BindingContext = _vmDetail
            };
            await _vm.AppNavigator.PushAsync(_pDetail);
        }
    }
}