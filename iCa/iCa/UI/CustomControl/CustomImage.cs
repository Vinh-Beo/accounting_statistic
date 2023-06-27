using System;
using Gesture;
using Xamarin.Forms;

namespace CustomControl
{
    public class CustomImage : Image
    {
        // add more some custom here
        /// <summary>
        /// Gets or sets the OnAction callback. Made available in case your views need access to the gesture responses
        /// </summary>

        public CustomImage()
        {

        }
        public event TouchActionEventHandler TouchAction;

        public void OnTouchAction(Element element, TouchActionEventArgs args)
        {
            TouchAction?.Invoke(element, args);
        }
    }
}
