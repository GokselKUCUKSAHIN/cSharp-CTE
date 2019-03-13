using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace angle_to_angle
{
    class Triangle
    {
        int counter;
        static int tc;
        //p
        Point p1;
        Point p2;
        Point p3;
        //m
        Point m1;
        Point m2;
        Point m3;
        //t
        List<Triangle> ts = new List<Triangle>();
        bool isFinished = false;
        Graphics grp;
        Pen kalem;

        static Triangle()
        {
            //counter = 0;
            tc = 0;
        }
        public Triangle(Point a, Point b, Point c, Graphics g, Pen p)
        {
            p1 = a;
            p2 = b;
            p3 = c;
            grp = g;
            kalem = p;
        }   
        public List<Triangle> RetTri()
        {
            Divide();
            CreateTriangle();
            return ts;
        }
        public void DrawIt()
        {
            grp.DrawLine(kalem, p1, p2);
            grp.DrawLine(kalem, p2, p3);
            grp.DrawLine(kalem, p3, p1);
        }
        private void CreateTriangle()
        {
            //Triangle t1 = new Triangle(p1, m1, m2);
            //Triangle t2 = new Triangle(m1, p2, m3);
            //Triangle t3 = new Triangle(m2, m3, p3);
            ts.Add(new Triangle(p1, m1, m2,grp,kalem));
            ts.Add(new Triangle(m1, p2, m3, grp, kalem));
            ts.Add(new Triangle(m2, m3, p3, grp, kalem));
        }
        static Point FindMiddle(Point a, Point b)
        {
            int dx = b.X - a.X;
            int dy = b.Y - a.Y;
            return new Point(a.X + dx / 2, a.Y + dy / 2);
        }
        void Divide()
        {
            m1 = FindMiddle(p1, p2);
            m2 = FindMiddle(p1, p3);
            m3 = FindMiddle(p2, p3);
        }
    }
}
