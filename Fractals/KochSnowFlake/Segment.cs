using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Koch_SnowFlake
{
    class Segment
    {
        public Point p1;
        public Point p2;
        public Point p3;
        public Point p4;
        public Point p5;
        int Alpha;
        int Lngth;
        public Segment()
        {

        }
        public Segment(Point o, int Len, int Angle)
        {
            Point End = EndPoint(o, (int)Angle, Len);
            Alpha = (int)Angle;
            Lngth = Len/3;
            Generate(o, End);
            p1 = o;
            p5 = End;
        }
        public Segment(Point start, Point end)
        {
            Lngth = CalculatLength(start, end)/3;
            Alpha = (int)CalculateAngle(start, end);
            p1 = start;
            p5 = end;
            Generate(start, end);
        }
        public void Generate(Point s, Point e)
        {
            p2 = FirstPart(p1, p5);
            p4 = SecondPart(p1, p5);
            p3 = EndPoint(p2,Alpha+60,Lngth);
        }

        public void DrawLine(Point s, int Angle, int Len, Graphics graph, Pen pen)
        {
            Point End = EndPoint(s, Angle, Len);
            Point a = FirstPart(s, End);
            Point b = SecondPart(s, End);
            graph.Clear(Color.White);
            //graph.DrawLine(pen, s, End);
            graph.DrawEllipse(pen, a.X - 3, a.Y - 3, 6, 6);
            graph.DrawEllipse(pen, b.X - 3, b.Y - 3, 6, 6);
            int xLen = Len / 3;
            Point c = EndPoint(a, Angle+60, xLen);
            graph.DrawEllipse(pen, c.X - 3, c.Y - 3, 6, 6);
            graph.DrawLine(pen, s, a);
            graph.DrawLine(pen, a, c);
            graph.DrawLine(pen, c, b);
            graph.DrawLine(pen, b, End);
            //return CalculateAngle(s, End);
        }

        public void Draw(Graphics graph, Pen pen)
        {
            graph.DrawLine(pen, p1, p2);
            graph.DrawLine(pen, p2, p3);
            graph.DrawLine(pen, p3, p4);
            graph.DrawLine(pen, p4, p5);
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
            return new Point(a.X + 2*(dx / 3), a.Y + 2*(dy / 3));
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