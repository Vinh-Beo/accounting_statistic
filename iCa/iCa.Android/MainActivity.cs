using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Common;
using Android.Content.Res;
using Android.Views;
using Android.Content;

namespace iCa.Droid
{
    [Activity(Label = "iCa", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Rg.Plugins.Popup.Popup.Init(this);
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }
        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            //crashed by exception
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Obsolete]
        public override void OnBackPressed()
        {
            if (!FormBase.IsDoServiceOS)
            {
                return;
            }
            base.OnBackPressed();
        }
        public override void OnUserInteraction()
        {
            base.OnUserInteraction();
            SetFullscreenFlags();
        }
        protected override void OnResume()
        {
            base.OnResume();
            SetFullscreenFlags();
        }
        public override void OnWindowFocusChanged(bool hasFocus)
        {
            base.OnWindowFocusChanged(hasFocus);
            SetFullscreenFlags();
        }
        protected void SetFullscreenFlags()
        {
            var attrs = Window.Attributes;
            attrs.Flags |= WindowManagerFlags.Fullscreen;
            attrs.Flags |= WindowManagerFlags.KeepScreenOn;
            attrs.LayoutInDisplayCutoutMode = LayoutInDisplayCutoutMode.ShortEdges;
            Window.Attributes = attrs;

            // BuildVersionCodes has a wrong value for Android R (1000 instead of 30)
            // https://github.com/xamarin/xamarin-android/issues/5723
            // if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            if ((int)Build.VERSION.SdkInt >= 30)
            {
                Window.SetDecorFitsSystemWindows(false);

                if (Window.InsetsController != null)
                {
                    Window.InsetsController.Hide(WindowInsets.Type.NavigationBars());
                    Window.InsetsController.Hide(WindowInsets.Type.StatusBars());
                    Window.InsetsController.Hide(WindowInsets.Type.SystemBars());
                    //Window.InsetsController.Show(WindowInsets.Type.Ime());
                }
            }
            else
            {
                var uiOptions = (int)Window.DecorView.SystemUiVisibility;
                var newUiOptions = (int)uiOptions;

                newUiOptions |=
                    (int)SystemUiFlags.LayoutStable |
                    (int)SystemUiFlags.LayoutHideNavigation |
                    (int)SystemUiFlags.LayoutFullscreen |
                    (int)SystemUiFlags.HideNavigation |
                    (int)SystemUiFlags.Fullscreen |
                    (int)SystemUiFlags.ImmersiveSticky;

                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;
            }
        }
        public override Android.Content.Res.Resources Resources
        {
            get
            {
                Resources resource = base.Resources;
                var config = resource.Configuration;
                if (config == null)
                    config = new Configuration();
                config.SetToDefaults();
                resource.DisplayMetrics.SetToDefaults();
                config.FontScale = 1.0f;
                resource.DisplayMetrics.ScaledDensity = config.FontScale * resource.DisplayMetrics.Density;

                return CreateConfigurationContext(config).Resources;
            }
        }

        public static int convertDpToPixel(float dp)
        {
            float px = dp * (Android.App.Application.Context.Resources.DisplayMetrics.Density);
            return (int)Math.Round(px);
        }
    }
}