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

namespace Gallery
{

    [Activity(Label = "ActivityGalleryApp")]
    public class ActivityGallery : Activity
    {
        Button back;
        Android.Widget.Gallery gallery;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Gallerypage);

            back = FindViewById<Button>(Resource.Id.button1);
            gallery = FindViewById<Android.Widget.Gallery>(Resource.Id.gallery);

            gallery.Adapter = new ImageAdapter(this);

            gallery.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                Toast.MakeText(this, "Image Position: " + args.Position, ToastLength.Short).Show();
            };


            back.Click += Back_Click;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}