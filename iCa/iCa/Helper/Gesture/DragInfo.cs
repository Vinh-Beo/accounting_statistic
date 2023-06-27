using System;
using Xamarin.Forms;

namespace Gesture
{
    class DragInfo
    {
        public DragInfo(long id, Point pressPoint)
        {
            Id = id;
            PressPoint = pressPoint;
        }

        public long Id { private set; get; }

        public Point PressPoint { private set; get; }
    }
}
