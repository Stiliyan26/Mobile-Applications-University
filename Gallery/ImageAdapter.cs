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
    public class ImageAdapter : BaseAdapter
    {
        private Context context;

        public ImageAdapter(Context c)
        {
            context = c;
        }

        int[] thumbIds = {
            Resource.Drawable.sample_1,
            Resource.Drawable.sample_2,
            Resource.Drawable.sample_3,
            Resource.Drawable.sample_4,
            Resource.Drawable.sample_5,
            Resource.Drawable.sample_6,
            Resource.Drawable.sample_7
        };

        public override int Count => thumbIds.Length;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView i = new ImageView(context);
            i.SetImageResource(thumbIds[position]);
            i.LayoutParameters = new Android.Widget.Gallery.LayoutParams(750, 600);
            i.SetScaleType(ImageView.ScaleType.FitXy);

            return i;
        }
    }
}