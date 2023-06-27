using iCa.ViewModels.Main.Order;
using iCa.ViewModels.Main.Order.Menu.Add;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iCa.Views.Main.Order.Menu.Add
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewOrderPopup : PopupPage
    {
        public AddNewOrderPopup()
        {
            InitializeComponent();
        }

        private void Handle_WeightChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(AddNewOrderViewModel))
            {
                return;
            }
            AddNewOrderViewModel _vm = BindingContext as AddNewOrderViewModel;
        }

        private void Handle_PriceChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(AddNewOrderViewModel))
            {
                return;
            }
            AddNewOrderViewModel _vm = BindingContext as AddNewOrderViewModel;
        }
    }
}