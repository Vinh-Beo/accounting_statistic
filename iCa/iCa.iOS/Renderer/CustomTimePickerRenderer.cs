using System;
using UIKit;
using Xamarin.Forms;
using SetTimer.iOS.Renderers;

[assembly: ExportRenderer(typeof(TimePicker), typeof(TimePickerRenderer))]
namespace SetTimer.iOS.Renderers
{
    public class TimePickerRenderer : Xamarin.Forms.Platform.iOS.TimePickerRenderer
    {
        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
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