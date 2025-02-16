using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery
{
    public class FingerPaintCanvasView : View
    {
        // Collection for active and completed drawings
        private Dictionary<int, FingerPaintPolyline> inProgressPolylines = new Dictionary<int, FingerPaintPolyline>();
        private List<FingerPaintPolyline> completedPolylines = new List<FingerPaintPolyline>();

        // Paint object for drawing
        private Paint paint = new Paint();

        // Default stroke color and width
        public Color StrokeColor { set; get; } = Color.Red;
        public float StrokeWidth { set; get; } = 2;

        // Constructors
        public FingerPaintCanvasView(Context context) : base(context)
        {
            Initialize();
        }

        public FingerPaintCanvasView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        private void Initialize()
        {
            paint.AntiAlias = true;
            paint.Dither = true;
            paint.StrokeJoin = Paint.Join.Round;
            paint.StrokeCap = Paint.Cap.Round;
        }

        public void ClearAll()
        {
            completedPolylines.Clear();
            inProgressPolylines.Clear();
            Invalidate();
        }

        public override bool OnTouchEvent(MotionEvent args)
        {
            int pointerIndex = args.ActionIndex;
            int id = args.GetPointerId(pointerIndex);

            switch (args.ActionMasked)
            {
                case MotionEventActions.Down:
                case MotionEventActions.PointerDown:

                    FingerPaintPolyline polyline = new FingerPaintPolyline
                    {
                        Color = StrokeColor,
                        StrokeWidth = StrokeWidth
                    };
                    polyline.Path.MoveTo(args.GetX(pointerIndex), args.GetY(pointerIndex));
                    inProgressPolylines.Add(id, polyline);
                    break;

                case MotionEventActions.Move:

                    for (pointerIndex = 0; pointerIndex < args.PointerCount; pointerIndex++)
                    {
                        id = args.GetPointerId(pointerIndex);
                        if (inProgressPolylines.ContainsKey(id))
                        {
                            inProgressPolylines[id].Path.LineTo(args.GetX(pointerIndex), args.GetY(pointerIndex));
                        }
                    }
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.Pointer1Up:
                    
                    if (inProgressPolylines.ContainsKey(id))
                    {
                        inProgressPolylines[id].Path.LineTo(args.GetX(pointerIndex), args.GetY(pointerIndex));
                        completedPolylines.Add(inProgressPolylines[id]);
                        inProgressPolylines.Remove(id);
                    }
                    break;

                case MotionEventActions.Cancel:
                    inProgressPolylines.Remove(id);
                    break;
            }

            Invalidate();
            return true;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            paint.SetStyle(Paint.Style.Fill);
            paint.Color = Color.White;
            canvas.DrawPaint(paint);

            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeCap = Paint.Cap.Round;
            paint.StrokeJoin = Paint.Join.Round;

            foreach (FingerPaintPolyline polyline in completedPolylines)
            {
                paint.Color = polyline.Color;
                paint.StrokeWidth = polyline.StrokeWidth;
                canvas.DrawPath(polyline.Path, paint);
            }

            foreach (FingerPaintPolyline polyline in inProgressPolylines.Values)
            {
                paint.Color = polyline.Color;
                paint.StrokeWidth = polyline.StrokeWidth;
                canvas.DrawPath(polyline.Path, paint);
            }
        }
    }
}