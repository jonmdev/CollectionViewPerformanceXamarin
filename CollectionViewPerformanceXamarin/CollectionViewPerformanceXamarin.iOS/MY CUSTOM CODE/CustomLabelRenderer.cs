using System;
using System.Collections.Generic;
using System.Text;

using CollectionViewPerformanceXamarin;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), typeof(CustomAndroidLabelRenderer))]

namespace CollectionViewPerformanceXamarin {

    public class CustomAndroidLabelRenderer : LabelRenderer {

        //https://devblogs.microsoft.com/xamarin/extending-xamarin-forms-controls-with-custom-renderers/
        //https://stackoverflow.com/questions/55101691/custom-label-renderer-in-xamarin-forms-ondraw-never-fired

        public CustomAndroidLabelRenderer() {
            //this.AddOnLayoutChangeListener(new LayoutListener());
            
        }
        public override void Draw(CGRect rect) {
            base.Draw(rect);
            UpdateCounter.addLayoutUpdate();
        }
        
    }
}
