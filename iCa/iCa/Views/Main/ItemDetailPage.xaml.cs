using iCa.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace iCa.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}