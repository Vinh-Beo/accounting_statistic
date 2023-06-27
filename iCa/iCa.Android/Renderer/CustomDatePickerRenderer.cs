using System;
using Android.Graphics.Drawables;
using static Android.Views.ViewGroup;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(Xamarin.Forms.DatePicker), typeof(CustomDatePickerRenderer))]
public class CustomDatePickerRenderer : DatePickerRenderer
{
    public CustomDatePickerRenderer(Context context) : base(context)
    {
    }

    protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
    {
        base.OnElementChanged(e);
        if (e.OldElement == null)
        {
            Control.Background = null;

            var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
            layoutParams.SetMargins(0, 0, 0, 0);
            LayoutParameters = layoutParams;
            GradientDrawable gd = new GradientDrawable();
            gd.SetStroke(0, Android.Graphics.Color.LightGray);
            Control.SetBackground(gd);
            //Control.SetBackgroundDrawable(gd);
            Control.LayoutParameters = layoutParams;                                                        
            Control.SetPadding(0, 0, 0, 0);
            SetPadding(0, 0, 0, 0);
        }
    }
}

