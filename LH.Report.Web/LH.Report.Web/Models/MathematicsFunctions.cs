using System;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class MathematicsFunctions {
        static double ToRadian(double angle) {
            return angle * Math.PI / 180.0;
        }
        static double LemniscateFunction(double m, double angle) {
            double cos = Math.Cos(m * ToRadian(90.0 + angle));
            return Math.Pow(Math.Abs(cos), m);
        }
        public static List<RealPoint> GetArchimedianSpiralPoints() {
            List<RealPoint> points = new List<RealPoint>();
            for (int i = 0; i < 720; i += 10) {
                double t = (double)i / 180 * Math.PI;
                double x = t * Math.Cos(t);
                double y = t * Math.Sin(t);
                points.Add(new RealPoint(x, y));
            }
            return points;
        }
        public static List<RealPoint> GetLemniscatePoints() {
            int pointsCount = 72;
            int step = 360 / 72;
            double m = 2;
            List<RealPoint> points = new List<RealPoint>();
            for (int i = 0; i < pointsCount; i++)
                points.Add(new RealPoint(step * i, LemniscateFunction(m, step * i)));
            return points;
        }
    }

    public struct RealPoint {
        double x;
        double y;

        public double X { get { return x; } }
        public double Y { get { return y; } }

        public RealPoint(double x, double y) {
            this.x = x;
            this.y = y;
        }
    }
}
