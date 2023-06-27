using SkiaSharp.Views.Forms;
using SkiaSharp;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;
using Gesture;
using Common;

namespace UI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IconSvg : Frame
	{
        private readonly SKCanvasView _canvasView = new SKCanvasView();
        private bool isBusy = false;
        [Obsolete]
        public IconSvg ()
		{
			InitializeComponent ();
            // Thanks to TheMax for pointing out that on mobile, the icon will have a shadow by default.
            // Also it has a white background, which we might not want.
            HasShadow = false;
            BackgroundColor = Color.Transparent;
            CornerRadius = 5;
            Content = _canvasView;
            _canvasView.PaintSurface += CanvasViewOnPaintSurface;
        }
        public static readonly BindableProperty ResourceIdProperty = BindableProperty.Create(
        nameof(ResourceId),
        typeof(string),
        typeof(IconSvg),
        default(string),
        propertyChanged: RedrawCanvas);

        public string ResourceId
        {
            get => (string)GetValue(ResourceIdProperty);
            set => SetValue(ResourceIdProperty, value);
        }
        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
        nameof(TintColor),
        typeof(Color),
        typeof(IconSvg),
        default(Color),
        propertyChanged: RedrawCanvas);

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }

        private static void RedrawCanvas(BindableObject bindable, object oldvalue, object newvalue)
        {
            IconSvg svgIcon = bindable as IconSvg;
            svgIcon?._canvasView.InvalidateSurface();
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            "Command",
            typeof(ICommand),
            typeof(TapGestureRecognizer),
            null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty);}
            set { SetValue(CommandProperty, value); }
        }
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter",
            typeof(object),
            typeof(TapGestureRecognizer),
            null);

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public event TouchActionEventHandler TouchAction;

        public void OnTouchAction(Element element, TouchActionEventArgs args)
        {
            TouchAction?.Invoke(element, args);
        }

        [Obsolete]
        private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKCanvas canvas = args.Surface.Canvas;
            canvas.Clear();

            if (string.IsNullOrEmpty(ResourceId))
                return;
            string _resource = GetType().Assembly.GetName().Name + "." + UserConstant.ResourcePath + ".Icons" + "." + ResourceId;
            using (Stream stream = GetType().Assembly.GetManifestResourceStream(_resource))
            {
                if (stream == null)
                {
                    return;
                }
                SKSvg svg = new SKSvg();
                svg.Load(stream);

                SKImageInfo info = args.Info;
                canvas.Translate(info.Width / 2f, info.Height / 2f);

                SKRect bounds = svg.ViewBox;
                float xRatio = info.Width / bounds.Width;
                float yRatio = info.Height / bounds.Height;

                float ratio = Math.Min(xRatio, yRatio);

                canvas.Scale(ratio);
                canvas.Translate(-bounds.MidX, -bounds.MidY);
                using (var paint = new SKPaint())
                {
                    paint.ColorFilter = SKColorFilter.CreateBlendMode(SKColor.Parse(TintColor.ToHex()), SKBlendMode.SrcIn);
                    canvas.DrawPicture(svg.Picture, paint);
                }
            }
        }
        public event EventHandler TapAction;
        private async void Handle_TouchAction(object sender, EventArgs e)
        {
            if (isBusy) return;
            isBusy = true;
            TapAction?.Invoke(sender, e);
            await root.RelScaleTo(0.1, 100);
            await root.RelScaleTo(-0.1, 100);
            isBusy = false;
        }
    }
} 