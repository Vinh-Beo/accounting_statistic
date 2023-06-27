using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.AppCompat.App;
using iCa.Droid.Renderer;
using Utils;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(CustomEntryRenderer))]
namespace iCa.Droid.Renderer
{
    public class CustomEntryRenderer : EntryRenderer
    {

        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        [Obsolete]
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null || Element == null || e.OldElement != null) return;

            // Using this for remove underline
            if (Control != null)
            {
                
                GradientDrawable gd = new GradientDrawable();
                Control.FocusChange += (sender, args) =>
                {
                    gd.SetShape(ShapeType.Rectangle);
                    if (args.HasFocus)
                    {
                        gd.SetStroke(2, global::Android.Graphics.Color.Rgb(102, 198, 212));
                        Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Rgb(102, 198, 212)));
                    }
                    else
                    {
                        gd.SetStroke(0, global::Android.Graphics.Color.Rgb(102, 198, 212));
                        Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Rgb(102, 112, 133)));
                    }

                    if (Application.Current.UserAppTheme == OSAppTheme.Light)
                    {
                        gd.SetColor(ColorStateList.ValueOf(Android.Graphics.Color.Rgb(255, 255, 255)));
                    }
                    else if (Application.Current.UserAppTheme == OSAppTheme.Dark)
                    {
                        gd.SetColor(ColorStateList.ValueOf(Android.Graphics.Color.Rgb(29, 29, 29)));
                    }
                    else
                    {
                        gd.SetColor(ColorStateList.ValueOf(Android.Graphics.Color.Rgb(255, 255, 255)));
                    }

                    Control.Background = gd;
                };

                if (Application.Current.UserAppTheme == OSAppTheme.Light)
                {
                    gd.SetColor(ColorStateList.ValueOf(Android.Graphics.Color.Rgb(255, 255, 255)));
                }
                else if (Application.Current.UserAppTheme == OSAppTheme.Dark)
                {
                    gd.SetColor(ColorStateList.ValueOf(Android.Graphics.Color.Rgb(29, 29, 29)));
                }
                else
                {
                    gd.SetColor(ColorStateList.ValueOf(Android.Graphics.Color.Rgb(255, 255, 255)));
                }
                //AppCompatDelegate.DefaultNightMode == AppCompatDelegate.ModeNightNo
                //if (IsTablet())
                //{
                //    gd.SetCornerRadius(14);
                //}
                //else
                //{

                //}

                gd.SetCornerRadius(Dimens.EntryCornerRadius);
                //gd.SetStroke(2, global::Android.Graphics.Color.Teal);
                Control.SetBackgroundDrawable(gd);
                Control.SetPadding(15, 3, 10, 3);
                Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                
                //Control.Gravity = Android.Views.GravityFlags.Center;
                //Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.rounded_corners); 
                //Control.Gravity = GravityFlags.CenterVertical; 
                //Control.SetPadding(10, 0, 0, 0); }
                Control.ImeOptions = (ImeAction)ImeFlags.NoExtractUi;
            }
        }

        public static bool IsTablet()
        {
            DisplayMetrics displayMetrics = Android.App.Application.Context.Resources.DisplayMetrics;

            float screenWidthInDp = displayMetrics.WidthPixels / displayMetrics.Density;
            float screenHeightInDp = displayMetrics.HeightPixels / displayMetrics.Density;

            float smallestWidthInDp = Math.Min(screenWidthInDp, screenHeightInDp);

            if (smallestWidthInDp >= 600)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
