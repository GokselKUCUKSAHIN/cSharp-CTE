using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FractalTree2
{
    class Dal
    {
        public Point start;
        public Point end;
        public int Alpha;
        public int Lngth;
        public Point r;
        public Point l;

        public Dal(Point p1, Point p2,int a)
        {
            start = p1;
            end = p2;
            Alpha = (int)CalculateAngle(p1, p2);
            Lngth = CalculatLength(p1, p2);
            r = EndPoint(p2, Alpha - (90 - a), (int)(Lngth * 0.7));
            l = EndPoint(p2, Alpha + (90-a), (int)(Lngth * 0.7));
        }
        public void Draw(Graphics graph, Pen pen)
        {
            graph.DrawLine(pen, end, l);
            graph.DrawLine(pen, end, r);
        }
        public void DrawRoot(Graphics graph, Pen pen)
        {
            graph.DrawLine(pen, start, end);
        }
        private static Point EndPoint(Point o, int angle, int length)
        {
            var endPoint = o;
            endPoint.X += (int)(length * Math.Cos(Radian(angle)));
            endPoint.Y -= (int)(length * Math.Sin(Radian(angle)));
            return endPoint;
        }
        private static Point FindMiddle(Point a, Point b)
        {
            int dx = b.X - a.X;
            int dy = b.Y - a.Y;
            return new Point(a.X + dx / 2, a.Y + dy / 2);
        }
        private static Point FirstPart(Point a, Point b)
        {
            int dx = b.X - a.X;
            int dy = b.Y - a.Y;
            return new Point(a.X + dx / 3, a.Y + dy / 3);
        }
        private static Point SecondPart(Point a, Point b)
        {
            int dx = b.X - a.X;
            int dy = b.Y - a.Y;
            return new Point(a.X + 2 * (dx / 3), a.Y + 2 * (dy / 3));
        }
        private static double Radian(double angle)
        {
            return (Math.PI / 180.0) * angle;
        }
        private static double Angle(double Radian)
        {
            return Radian * (180 / Math.PI);
        }
        private static double CalculateAngle(Point p1, Point p2)
        {
            double dx = Math.Abs(p1.X - p2.X);
            double dy = Math.Abs(p1.Y - p2.Y);
            double a = Math.Round(Angle(Math.Atan(dy / dx)));
            if (p1.X - p2.X >= 0)
            {
                //II - III
                if (p1.Y - p2.Y >= 0)
                {
                    //II Region
                    return 180 - a;
                }
                else
                {
                    //III Region
                    return 180 + a;
                }
            }
            else
            {
                // I - IV
                if (p1.Y - p2.Y >= 0)
                {
                    //I Region
                    return a;
                }
                else
                {
                    //IV Region
                    return 360 - a;
                }
            }
        }
        private static int CalculatLength(Point p1, Point p2)
        {
            double dx = Math.Abs(p1.X - p2.X);
            double dy = Math.Abs(p1.Y - p2.Y);
            return (int)Math.Round(Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
        }
    }
}
