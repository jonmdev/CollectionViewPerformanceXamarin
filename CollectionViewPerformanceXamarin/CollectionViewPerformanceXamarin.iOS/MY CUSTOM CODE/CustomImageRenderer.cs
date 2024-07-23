using System;
using System.Collections.Generic;
using System.Text;

using CollectionViewPerformanceXamarin;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Image), typeof(CustomIOSImageRenderer))]

namespace CollectionViewPerformanceXamarin {

    public class CustomIOSImageRenderer : ImageRenderer {

        //https://devblogs.microsoft.com/xamarin/extending-xamarin-forms-controls-with-custom-renderers/
        //https://stackoverflow.com/questions/55101691/custom-label-renderer-in-xamarin-forms-ondraw-never-fired

        public CustomIOSImageRenderer() {
            //public class FormsUIImageView : UIImageView
            //https://developer.apple.com/documentation/uikit/uiimageview
        }

        public override void Draw(CGRect rect) {
            UpdateCounter.addImageDrawUpdate();
            base.Draw(rect);
        }
        public override void LayoutSubviews() {
            UpdateCounter.addImageLayoutUpdate();
            base.LayoutSubviews();
        }
    }
}
