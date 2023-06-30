using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using iCa.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomControl.CustomImage), typeof(CustomImageRenderer))]
namespace iCa.iOS.Renderer
{
    public class CustomImageRenderer : ImageRenderer
    {
        UILongPressGestureRecognizer longPressGestureRecognizer;
        //UIPinchGestureRecognizer pinchGestureRecognizer;
        //UIPanGestureRecognizer panGestureRecognizer;
        //UISwipeGestureRecognizer swipeGestureRecognizer;
        //UIRotationGestureRecognizer rotationGestureRecognizer;
        //static Dictionary<UIView, Element> viewDictionary = new Dictionary<UIView, Element>();
        //static Dictionary<long, UIView> idToTouchLLDictionary = new Dictionary<long, UIView>();
        private double lastPointX = -1;
        private double lastPointY = -1;
        public override void TouchesBegan(NSSet touches, UIEvent evt)         {             base.TouchesBegan(touches, evt);             UITouch touch = touches.AnyObject as UITouch;             if (touch != null)             {
                CGPoint newPoint = (touches.AnyObject as UITouch).LocationInView(touch.View);
                lastPointX = newPoint.X;
                lastPointY = newPoint.Y;             }         }          public override void TouchesMoved(NSSet touches, UIEvent evt)         {             base.TouchesMoved(touches, evt);             // get the touch             UITouch touch = touches.AnyObject as UITouch;             if (touch != null)             {
                CGPoint newPoint = (touches.AnyObject as UITouch).LocationInView(touch.View);
                CGPoint previousPoint = (touches.AnyObject as UITouch).PreviousLocationInView(touch.View);
                lastPointX = newPoint.X;
                lastPointY = newPoint.Y;             }         }          public override void TouchesCancelled(NSSet touches, UIEvent evt)         {             base.TouchesCancelled(touches, evt);             // reset our tracking flags
            lastPointX = -1;
            lastPointY = -1;         }          public override void TouchesEnded(NSSet touches, UIEvent evt)         {             base.TouchesEnded(touches, evt);             // get the touch             UITouch touch = touches.AnyObject as UITouch;             if (touch != null)             {
                CGPoint newPoint = (touches.AnyObject as UITouch).LocationInView(touch.View);
                lastPointX = newPoint.X;
                lastPointY = newPoint.Y;             }         }
        static Dictionary<UIView, Element> viewDictionary = new Dictionary<UIView, Element>();
        static Dictionary<long, UIView> idToTouchDictionary = new Dictionary<long, UIView>();

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                if (longPressGestureRecognizer != null)
                {
                    this.RemoveGestureRecognizer(longPressGestureRecognizer);
                    if (longPressGestureRecognizer.View != null)
                    {
                        viewDictionary.Remove(longPressGestureRecognizer.View);
                        idToTouchDictionary.Remove(longPressGestureRecognizer.Handle.ToInt64());
                    }
                    else{
                        // find touch id
                        long id = longPressGestureRecognizer.Handle.ToInt64();
                        if(idToTouchDictionary.ContainsKey(id))
                        {
                            UIView element = idToTouchDictionary[id];
                            viewDictionary.Remove(element);
                            idToTouchDictionary.Remove(id);
                        }
                        else{
                            Console.WriteLine("cannot find handle. fata ERROR");
                        }
                    }
                }
                //if (pinchGestureRecognizer != null)
                //{
                //    this.RemoveGestureRecognizer(pinchGestureRecognizer);
                //}
                //if (panGestureRecognizer != null)
                //{
                //    this.RemoveGestureRecognizer(panGestureRecognizer);
                //}
                //if (swipeGestureRecognizer != null)
                //{
                //    this.RemoveGestureRecognizer(swipeGestureRecognizer);
                //}
                //if (rotationGestureRecognizer != null)
                //{
                //    this.RemoveGestureRecognizer(rotationGestureRecognizer);
                //}
            }

            longPressGestureRecognizer = new UILongPressGestureRecognizer((UILongPressGestureRecognizer obj) => {
                if (viewDictionary.ContainsKey(obj.View))
                {
                    Element element = viewDictionary[obj.View];
                    Gesture.TouchActionType actionType = Gesture.TouchActionType.Cancelled;
                    #region custom some effect
                    switch (obj.State)
                    {
                        case UIGestureRecognizerState.Began:
                            {
                                actionType = Gesture.TouchActionType.HoldBegan;
                                break;
                            }
                        case UIGestureRecognizerState.Ended:
                            {
                                actionType = Gesture.TouchActionType.HoldEnded;
                                break;
                            }
                        case UIGestureRecognizerState.Changed:
                            {
                                actionType = Gesture.TouchActionType.HoldChanged;
                                break;
                            }

                    }
                    #endregion
                    //fire event
                    Action<Element, Gesture.TouchActionEventArgs> onTouchAction = ((CustomControl.CustomImage)element).OnTouchAction;
                    // Call that method
                    if (onTouchAction != null)
                    {
                        onTouchAction(element,
                                      new Gesture.TouchActionEventArgs(0, actionType, new Point(lastPointX, lastPointY), false));
                    }


                }
                // get element info
                //ihome.CustomControl.CustomImage view = obj.View as ihome.CustomControl.CustomImage;
                //(view).OnAction(view, CustomControl.CustomImageGestureRecognizerState.HoldBegan);
            });

            //longPressGestureRecognizer.CancelsTouchesInView = false;
            //longPressGestureRecognizer = new UILongPressGestureRecognizer(() => 
            //{
            //    Console.WriteLine("Long Press");
            //});
            //pinchGestureRecognizer = new UIPinchGestureRecognizer(() => Console.WriteLine("Pinch"));
            //panGestureRecognizer = new UIPanGestureRecognizer(() => Console.WriteLine("Pan"));
            //swipeGestureRecognizer = new UISwipeGestureRecognizer(() => Console.WriteLine("Swipe"));
            //rotationGestureRecognizer = new UIRotationGestureRecognizer(() => Console.WriteLine("Rotation"));

            if (e.OldElement == null)
            {
                this.AddGestureRecognizer(longPressGestureRecognizer);
                //this.AddGestureRecognizer(pinchGestureRecognizer);
                //this.AddGestureRecognizer(panGestureRecognizer);
                //this.AddGestureRecognizer(swipeGestureRecognizer);
                //this.AddGestureRecognizer(rotationGestureRecognizer);
                if(e.NewElement != null){
                    viewDictionary.Add(longPressGestureRecognizer.View, e.NewElement);
                    long id = longPressGestureRecognizer.Handle.ToInt64(); 
                    if(!idToTouchDictionary.ContainsKey(id))
                    idToTouchDictionary.Add(id, longPressGestureRecognizer.View);
                }
            }
        }
    }
}
