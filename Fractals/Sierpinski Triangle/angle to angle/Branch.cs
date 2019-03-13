using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace angle_to_angle
{
    class Branch
    {
        Point Begin;
        Point End;
        int Lenght;
        int Angle;
        static int Artim;
        // bool isFinished = false;
        public Branch(Point bgn, Point end, int len, int angle, int artim)
        {
            Begin = bgn;
            End = end;
            Lenght = len;
            Angle = angle;
            Artim = artim;
        }
        public void Show(Graphics g, Pen p)
        {
            g.DrawLine(p, Begin, End);
        }
        public BranchPair RetBranch()
        {
            Lenght = (int)(Lenght * 0.67);
            Angle = (Angle - Artim);
            //Artim = Artim * 2;
            Point newREnd = EndRPoint(End, Angle, Lenght);
            Point newLEnd = EndLPoint(End, Angle, Lenght);

            Branch r = new Branch(End, newREnd, Lenght, Angle, Artim);
            Branch l = new Branch(End, newLEnd, Lenght, Angle, Artim);
            BranchPair bp = new BranchPair(l, r);


            return bp;
        }

        private Point EndRPoint(Point o, int angle, int length)
        {
            var endPoint = o;
            endPoint.X += (int)(length * Math.Cos(Radian(angle)));
            endPoint.Y -= (int)(length * Math.Sin(Radian(angle)));
            return endPoint;
        }
        private Point EndLPoint(Point o, int angle, int length)
        {
            angle = 180 - angle;
            var endPoint = o;
            endPoint.X += (int)(length * Math.Cos(Radian(angle)));
            endPoint.Y -= (int)(length * Math.Sin(Radian(angle)));
            return endPoint;
        }
        private double Radian(int angle)
        {
            return (Math.PI / 180.0) * angle;
        }
    }
}
