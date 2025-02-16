using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gallery
{
    [Activity(Label = "ActivityWebView")]
    public class ActivityWebView : Activity
    {
        Button back;
        WebView web_view;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WebViewpage);

            back = FindViewById<Button>(Resource.Id.button1);
            web_view = FindViewById<WebView>(Resource.Id.webview);
            web_view.LoadUrl("https://tu-sofia.bg/");

            back.Click += Back_Click;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity)); 
        }

        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && web_view.CanGoBack())
            {
                web_view.GoBack();

                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}