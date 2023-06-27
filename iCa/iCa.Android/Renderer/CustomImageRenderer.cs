using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Common;
using Gesture;
using iCa.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomControl.CustomImage), typeof(CustomImageRenderer))]
namespace iCa.Droid
{
    public class CustomImageRenderer : ImageRenderer
    {
        //private GestureListener _listener;
        //private readonly GestureDetector _detector;
        Element element;
        private double lastXPoint = 0;
        private double lastYPoint = 0;
        public CustomImageRenderer(Context context) : base(context)
        {
            //_listener = new GestureListener();
            //_detector = new GestureDetector(_listener);
        }

        void Handle_Click(object sender, EventArgs e)
        {
            TouchActionType actionType = TouchActionType.Cancelled;
            //fire event
            actionType = TouchActionType.Taped;
            Action<Element, TouchActionEventArgs> onTouchAction = ((CustomControl.CustomImage)element).OnTouchAction;
            // Call that method
            double pointX = (lastXPoint > 0) ? lastXPoint : FormBase.DeviceInfo.Width * 0.5;
            double pointY = (lastYPoint > 0) ? lastYPoint : FormBase.DeviceInfo.Height * 0.5;
            if (onTouchAction != null)
            {
                onTouchAction(element,
                              new TouchActionEventArgs(0, actionType, new Point(pointX, pointY), false));
            }
        }



        void Handle_LongClick(object sender, LongClickEventArgs e)
        {
            TouchActionType actionType = TouchActionType.Cancelled;
            //fire event
            actionType = TouchActionType.HoldBegan;
            Action<Element, TouchActionEventArgs> onTouchAction = ((CustomControl.CustomImage)element).OnTouchAction;
            // Call that method
            double pointX = (lastXPoint > 0) ? lastXPoint : FormBase.DeviceInfo.Width * 0.5;
            double pointY = (lastYPoint > 0) ? lastYPoint : FormBase.DeviceInfo.Height * 0.5;
            if (onTouchAction != null)
            {
                onTouchAction(element,
                              new TouchActionEventArgs(0, actionType, new Point(pointX, pointY), false));
            }
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                this.Touch -= HandleTouch;
                this.LongClick -= Handle_LongClick;
                this.Click -= Handle_Click;
                this.LongClickable = true;
            }

            if (e.OldElement == null)
            {
                this.Touch += HandleTouch;
                this.LongClick += Handle_LongClick;
                this.Click += Handle_Click;
                this.LongClickable = true;
                element = e.NewElement;
            }
        }

        void HandleTouch(object sender, TouchEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == MotionEventActions.Down)
            {
                lastXPoint = (double)(e.Event.GetX()) / FormBase.DeviceInfo.Density;
                lastYPoint = (double)(e.Event.GetY()) / FormBase.DeviceInfo.Density;
            }
        }
    }
}
