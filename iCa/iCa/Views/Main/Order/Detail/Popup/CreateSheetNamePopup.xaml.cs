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
    public partial class CreateSheetNamePopup : PopupPage
    {
        public CreateSheetNamePopup()
        {
            InitializeComponent();
        }
    }
}