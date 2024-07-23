using System;
using System.Collections.Generic;
using System.Text;
using Android.Content;
using Android.Graphics;
using CollectionViewPerformanceXamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Image), typeof(CustomAndroidImageRenderer))]

namespace CollectionViewPerformanceXamarin {

    public class CustomAndroidImageRenderer : ImageRenderer {

        //https://devblogs.microsoft.com/xamarin/extending-xamarin-forms-controls-with-custom-renderers/
        //https://stackoverflow.com/questions/55101691/custom-label-renderer-in-xamarin-forms-ondraw-never-fired
        public CustomAndroidImageRenderer(Context context): base(context) {

        }
        // AImageView = Android.Widget.ImageView;
        //https://developer.android.com/reference/android/widget/ImageView

        protected override void DrawableStateChanged() {
            UpdateCounter.addImageDrawStateUpdate(); //does run 
            base.DrawableStateChanged();
        }
        protected override void OnDraw(Canvas canvas) {
            UpdateCounter.addImageDrawUpdate(); //doesn't run on xamarin at all
            base.OnDraw(canvas);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec) {
            UpdateCounter.addImageMeasureUpdate(this.GetHashCode().ToString());
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }
        protected override void OnLayout(bool changed, int left, int top, int right, int bottom) {
            UpdateCounter.addImageLayoutUpdate();
            base.OnLayout(changed, left, top, right, bottom);
        }

    }
}
