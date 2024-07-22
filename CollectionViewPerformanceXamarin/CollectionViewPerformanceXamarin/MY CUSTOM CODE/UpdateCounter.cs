using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewPerformanceXamarin {
    public static class UpdateCounter {

        public static int measureUpdates = 0;
        public static int drawUpdates = 0;
        public static int layoutUpdates = 0;

        public static void addMeasureUpdate(string idCode) {
            measureUpdates++;
            Debug.WriteLine("MEASURE UPDATE " + UpdateCounter.measureUpdates + " ID: " + idCode);
        }
        public static void resetMeasureUpdates() {
            measureUpdates = 0;
        }
        public static void addDrawUpdate() {
            drawUpdates++;
            Debug.WriteLine("DRAW UPDATE " + UpdateCounter.drawUpdates);
        }
        public static void addLayoutUpdate() {
            layoutUpdates++;
            Debug.WriteLine("LAYOUT UPDATE " + UpdateCounter.layoutUpdates);
        }
        public static void resetPaintUpdates() {
            drawUpdates = 0;
        }
        public static void resetCounters() {
            measureUpdates = 0;
            layoutUpdates = 0;
            drawUpdates = 0;
        }
    }
}
