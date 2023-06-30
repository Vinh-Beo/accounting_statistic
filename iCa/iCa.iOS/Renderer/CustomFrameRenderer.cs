using System;
using System.ComponentModel;
using CoreGraphics;
using ICa.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Frame), typeof(CustomFrameRenderer))]
namespace ICa.iOS.Renderer
{
    public class CustomFrameRenderer : FrameRenderer
    {
        public override void Draw(CGRect rect)
        {
            try
            {
                base.Draw(rect);

                // Update shadow to match better material design standards of elevation
                Layer.ShadowRadius = 2.0f;
                Layer.ShadowColor = UIColor.FromRGBA(255, 0, 0, 0).CGColor;
                Layer.ShadowOffset = new CGSize(2, 2);
                Layer.ShadowOpacity = 0.80f;
                Layer.ShadowPath = UIBezierPath.FromRect(Layer.Bounds).CGPath;
                Layer.MasksToBounds = false;
            }
            catch (Exception)
            {
            }
        }
    }
}
