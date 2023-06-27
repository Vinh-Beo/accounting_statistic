using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using iCa.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Frame), typeof(CustomFrameRenderer))]
namespace iCa.Droid.Renderer
{
    public class CustomFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer//Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer//FrameRenderer
    {

        public CustomFrameRenderer(Context context) : base(context)
        {
        }

        public override void Draw(Canvas canvas)
        {
            try
            {
                //base.Draw(canvas);
                if (Element == null)
                {
                    return;
                }

                using (var paint = new Paint
                {
                    AntiAlias = true
                })
                using (var path = new Path())
                using (Path.Direction direction = Path.Direction.Ccw)
                using (Paint.Style style = Paint.Style.Stroke)
                using (var rect = new RectF(0, 0, canvas.Width, canvas.Height))
                {
                    var raduis = Android.App.Application.Context.ToPixels(Element.CornerRadius);
                    path.AddRoundRect(rect, raduis, raduis, direction);
                    paint.StrokeWidth = Context.Resources.DisplayMetrics.ScaledDensity;
                    paint.AntiAlias = true;
                    paint.SetStyle(style);
                    paint.Color = Element.BorderColor.ToAndroid();

                    canvas.Save();
                    canvas.ClipPath(path);
                    base.Draw(canvas);
                    canvas.DrawPath(path, paint);
                }
            }
            catch (Exception)
            {

            }

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement as Frame;
            if (element == null) return;
            if (element.HasShadow)
            {
                Elevation = 30.0f;
                TranslationZ = 0.0f;
                SetZ(30f);
            }
        }
        //protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        //{
        //    base.OnElementChanged(e);

        //    //CardElevation = 50;
        //    //SetOutlineSpotShadowColor(Xamarin.Forms.Color.Black.ToAndroid());
        //    //SetOutlineAmbientShadowColor(Xamarin.Forms.Color.Black.ToAndroid());
        //}
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "CornerRadius")
            {

            }
        }

        //private void UpdateCornerRadius()
        //{
        //    if (Control.Background is GradientDrawable backgroundGradient)
        //    {
        //        var cornerRadius = (Element as Frame)?.CornerRadius;
        //        if (!cornerRadius.HasValue)
        //        {
        //            return;
        //        }

        //        var topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
        //        var topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
        //        var bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
        //        var bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

        //        var cornerRadii = new[]
        //        {
        //            topLeftCorner,
        //            topLeftCorner,

        //            topRightCorner,
        //            topRightCorner,

        //            bottomRightCorner,
        //            bottomRightCorner,

        //            bottomLeftCorner,
        //            bottomLeftCorner,
        //        };

        //        backgroundGradient.SetCornerRadii(cornerRadii);
        //    }
        //}
    }
}
