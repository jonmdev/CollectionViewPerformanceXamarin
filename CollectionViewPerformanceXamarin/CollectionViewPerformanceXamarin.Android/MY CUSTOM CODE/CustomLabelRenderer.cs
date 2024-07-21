using System;
using System.Collections.Generic;
using System.Text;
using Android.Content;
using Android.Graphics;
using CollectionViewPerformanceXamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(CustomAndroidLabelRenderer))]

namespace CollectionViewPerformanceXamarin {

    public class CustomAndroidLabelRenderer : LabelRenderer {

        //https://devblogs.microsoft.com/xamarin/extending-xamarin-forms-controls-with-custom-renderers/
        //https://stackoverflow.com/questions/55101691/custom-label-renderer-in-xamarin-forms-ondraw-never-fired

        public CustomAndroidLabelRenderer() {
            this.AddOnLayoutChangeListener(new LayoutListener());

        }
        class LayoutListener : Java.Lang.Object, IOnLayoutChangeListener {
            public void OnLayoutChange(Android.Views.View? v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom) {
                UpdateCounter.addLayoutUpdate();
            }
        };

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec) {
            UpdateCounter.addMeasureUpdate(this.GetHashCode().ToString());
            //System.Diagnostics.Debug.WriteLine("MEASURE UPDATE " + UpdateCounter.measureUpdates);
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }

    }
}
