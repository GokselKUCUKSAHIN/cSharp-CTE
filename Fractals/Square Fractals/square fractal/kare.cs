using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace square_fractal
{
    class kare
    {
        Point pnt;
        int Len;
        
        public kare(Point s,int len)
        {
            pnt = s;
            Len = len;
        }
        public static SolidBrush sb = new SolidBrush(Color.Snow);
        public void draw(Graphics g, Pen p)
        {
            //g.DrawRectangle(p, new Rectangle(pnt, new Size(Len, Len)));
            g.FillRectangle(sb, new Rectangle(pnt, new Size(Len, Len)));
        }
        public List<kare> Generate()
        {
            List<kare> ls = new List<kare>();
            Point p1 = this.pnt;
            Point p2 = new Point(this.pnt.X + (int)(this.Len * (2 / 3.0)), this.pnt.Y);
            Point p3 = new Point(this.pnt.X + (int)(this.Len * (1 / 3.0)), this.pnt.Y + (int)(this.Len * (1 / 3.0)));
            Point p4 = new Point(this.pnt.X, this.pnt.Y + (int)(this.Len * (2 / 3.0)));
            Point p5 = new Point(this.pnt.X + (int)(this.Len * (2 / 3.0)), this.pnt.Y + (int)(this.Len * (2 / 3.0)));

            int nl = (int)(this.Len * (1 / 3.0));
            ls.Add(new kare(p1,nl));
            ls.Add(new kare(p2,nl));
            ls.Add(new kare(p3,nl));
            ls.Add(new kare(p4,nl));
            ls.Add(new kare(p5,nl));
            return ls;
        }
    }
}
