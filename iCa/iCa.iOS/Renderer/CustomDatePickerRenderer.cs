using iCa.iOS.Renderer;
using System;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(DatePicker), typeof(DatePickerRenderer))]
namespace iCa.iOS.Renderer
{
    public class DatePickerRenderer : Xamarin.Forms.Platform.iOS.DatePickerRenderer
    {
        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Remove border
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
                // Using wheels for select
                UITextField entry = Control;
                UIDatePicker picker = (UIDatePicker)entry.InputView;
                try
                {
                    picker.PreferredDatePickerStyle = UIDatePickerStyle.Wheels;
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}