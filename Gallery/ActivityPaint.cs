using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System;

namespace Gallery
{
    [Activity(Label = "ActivityPaint")]
    public class ActivityPaint : Activity
    {
        Button back;
        Button clear;
        FingerPaintCanvasView fingerPaintCanvasView;
        Spinner colorSpinner;
        Spinner widthSpinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Paintpage);

            back = FindViewById<Button>(Resource.Id.button1);
            clear = FindViewById<Button>(Resource.Id.clearButton);
            fingerPaintCanvasView = FindViewById<FingerPaintCanvasView>(Resource.Id.fingerPaintCanvasView);
            colorSpinner = FindViewById<Spinner>(Resource.Id.colorSpinner);
            widthSpinner = FindViewById<Spinner>(Resource.Id.widthSpinner);

            back.Click += Back_Click;
            clear.Click += OnClearButtonClick;

            colorSpinner.ItemSelected += OnColorSpinnerItemSelected;
            widthSpinner.ItemSelected += OnWidthSpinnerItemSelected;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity)); 
        }

        private void OnClearButtonClick(object sender, EventArgs args)
        {
            fingerPaintCanvasView.ClearAll(); 
        }

        private void OnColorSpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs args)
        {
            Spinner spinner = (Spinner)sender;
            string strColor = (string)spinner.GetItemAtPosition(args.Position);
            Color strokeColor = (Color)(typeof(Color).GetProperty(strColor).GetValue(null));
            fingerPaintCanvasView.StrokeColor = strokeColor;
        }

        private void OnWidthSpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs args)
        {
            float[] strokeWidths = { 2, 5, 10, 20, 50 };
            fingerPaintCanvasView.StrokeWidth = strokeWidths[args.Position];
        }
    }
}
