using iCa.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iCa.Views.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}
        void TabbedPage_CurrentPageChanged(System.Object sender, System.EventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            if (sender.GetType() != typeof(MainPage))
            {
                return;
            }
            MainPage _vm = sender as MainPage;
            if (_vm.CurrentPage == null)
            {
                return;
            }
            if (_vm.BindingContext == null)
            {
                return;
            }
            if (_vm.BindingContext.GetType() != typeof(MainViewModel))
            {
                return;
            }
            MainViewModel _v = _vm.BindingContext as MainViewModel;

            if (_vm.CurrentPage == tpHome)
            {
                
            }
            else if (_vm.CurrentPage == tpOrders)
            {

            }
            else if (_vm.CurrentPage == tpNotìy)
            {

            }
            else if (_vm.CurrentPage == tpHistory)
            {

            }
            else if (_vm.CurrentPage == tpSetting)
            {

            }
            else
            {
                //continue
            }
        }
    }
}