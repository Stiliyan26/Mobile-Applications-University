using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics;

namespace Gallery
{
    public class FingerPaintPolyline
    {
        public FingerPaintPolyline()
        {
            Path = new Path();
        }

        public Color Color { set; get; }

        public float StrokeWidth { set; get; }

        public Path Path { private set; get; }
    }
}
