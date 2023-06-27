using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using iHome.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.SearchBar), typeof(CustomSearchBarRenderer))]
namespace iHome.Droid.Renderer
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {

        public CustomSearchBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                var plate = Control.FindViewById(plateId);
                plate.SetBackgroundColor(Android.Graphics.Color.Transparent);
                
                AutoCompleteTextView textField = (AutoCompleteTextView)
                    (((Control.GetChildAt(0) as ViewGroup)
                        .GetChildAt(2) as ViewGroup)
                        .GetChildAt(1) as ViewGroup)
                        .GetChildAt(0);
                // Set color for icon
                var icon = Control?.FindViewById(Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null));
                (icon as ImageView)?.SetColorFilter(Android.Graphics.Color.LightGray);

                if (textField != null)
                    textField.ImeOptions = (ImeAction)ImeFlags.NoExtractUi; // This does the magic
            }
        }
    }
}
