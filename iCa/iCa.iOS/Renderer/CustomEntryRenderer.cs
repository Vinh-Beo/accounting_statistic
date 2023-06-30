using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using iCa.iOS.Renderer;
using Common;
using CoreGraphics;
using Utils;
using Foundation;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace iCa.iOS.Renderer
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Started += (sender, args) =>
                {
                    Control.Layer.BorderColor = UIColor.FromRGB(102, 198, 212).CGColor;
                    Control.Layer.BorderWidth = 2;
                };
                Control.Ended += (sender, args) =>
                {
                    Control.Layer.BorderWidth = 0;
                };


                Control.BackgroundColor = UIColor.FromRGB(255, 255, 255);

                Control.TintColor = UIColor.FromRGB(102, 198, 212);
                Control.LeftView = new UIView(new CGRect(0, 0, 10, 0));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.CornerRadius = 10;
                Control.Layer.MasksToBounds = true;
            }
        }
    }
}