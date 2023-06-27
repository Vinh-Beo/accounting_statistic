using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iCa.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertDialogPopup : PopupPage
    {
        public AlertDialogPopup()
        {
            InitializeComponent();
        }
    }
}