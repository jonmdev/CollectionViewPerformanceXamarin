﻿using System;
using System.Collections.Generic;
using System.Text;

using CollectionViewPerformanceXamarin;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), typeof(CustomIOSLabelRenderer))]

namespace CollectionViewPerformanceXamarin {

    public class CustomIOSLabelRenderer : LabelRenderer {

        //https://devblogs.microsoft.com/xamarin/extending-xamarin-forms-controls-with-custom-renderers/
        //https://stackoverflow.com/questions/55101691/custom-label-renderer-in-xamarin-forms-ondraw-never-fired

        public CustomIOSLabelRenderer() {
            
        }
        public override void Draw(CGRect rect) {
            UpdateCounter.addLabelDrawUpdate();
            base.Draw(rect);
        }
        public override void LayoutSubviews() {
            UpdateCounter.addLabelLayoutUpdate();
            base.LayoutSubviews();
        }
    }
}
