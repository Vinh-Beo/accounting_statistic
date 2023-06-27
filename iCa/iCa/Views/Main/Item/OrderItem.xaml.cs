using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iCa.Views.Main.Item
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderItem : ContentView
	{
		public OrderItem ()
		{
			InitializeComponent ();
		}

        async void Handle_TouchAction(object sender, Gesture.TouchActionEventArgs args)
        {

        }
    }
}