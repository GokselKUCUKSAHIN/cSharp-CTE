using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinClock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        Bitmap bmp;
        Pen pen = new Pen(Color.FromArgb(255, 5, 5, 5), 2.6f);
        Pen pen2 = new Pen(Color.FromArgb(230, 255, 15, 15), 4f);
        //
        Pen pSec = new Pen(Color.FromArgb(200, 255, 15, 15), 2.6f);
        Pen pMin = new Pen(Color.FromArgb(200, 0, 20, 240), 2f);
        Pen pHrs = new Pen(Color.FromArgb(200,0,255,0), 2f);
        //
        int W;
        int H;
        Point C;
        int r;
        int rDot = 3;
        int rC = 3;
        string Zero = "0";
        //
        DateTime dt;
        //
        int Second = 0;
        int Minute = 0;
        int Hour = 0;

        private void Button1_Click(object sender, EventArgs e)
        {
            W = pictureBox1.Width;
            H = pictureBox1.Height;
            bmp = new Bitmap(W+1,H+1);
            C = new Point(W / 2, H / 2);
            r = 220;
            timer1.Start();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            dt = DateTime.Now;
            Second = dt.Second;
            Minute = dt.Minute;
            Hour = dt.Hour % 12; //for 12-24 convert
            DrawOutLine(); 
            DrawHour();
            DrawMinute();
            DrawSecond();
            DrawDot();
            pictureBox1.Image = bmp;
            g.Dispose();
        }
        //
        private void DrawOutLine()
        {
            for (int i = 0; i < 360; i += 30)
            {
                Point n = EndPoint(C, i, r);
                g.DrawEllipse(pen, n.X - rDot, n.Y - rDot, 2 * rDot, 2 * rDot);
                for (int j = i + 6; j < i + 30; j += 6)
                {
                    Point l1 = EndPoint(C, j, r - 4);
                    Point l2 = EndPoint(C, j, r + 2);
                    g.DrawLine(pen2, l1, l2);
                }
            }
        }
        private void DrawDot()
        {
            g.DrawEllipse(pen, C.X - rC, C.Y - rC, 2 * rC, 2 * rC);
        }
        private void DrawSecond()
        {
            int Angle = 90 - (Second * 6);
            Point s = EndPoint(C, Angle, r - 20);
            Point d = EndPoint(C,  180+ Angle, 22);
            Point c = EndPoint(C, 180 + Angle, 25);
            Point l = EndPoint(C, Angle, r + 30);
            label1.Location = l;
            string mn = Second.ToString();
            if(mn.Length == 1)
            {
                mn = Zero + mn;
            }
            label1.Text = mn;
            g.DrawLine(pSec, s, C);
            g.DrawLine(pSec, d, C);
            g.DrawEllipse(pSec, c.X - 5, c.Y - 5, 10, 10);
        }
        private void DrawMinute()
        {
            int Angle = 90 - (Minute * 6);
            Angle -= (int)((Second/60.1)*6);
            Point p1 = EndPoint(C, Angle, r - 50);
            Point p2 = EndPoint(C, 180 + Angle, 25);
            Point p3 = EndPoint(C, Angle+90, 10);
            Point p4 = EndPoint(C, Angle-90, 10);
            //
            g.DrawLine(pMin, p1, p3);
            g.DrawLine(pMin, p3, p2);
            g.DrawLine(pMin, p2, p4);
            g.DrawLine(pMin, p4, p1);
        }
        private void DrawHour()
        {
            int Angle = 90 - (Hour * 30);
            Angle -= (int)((Minute / 60.1) * 30);
            Point p1 = EndPoint(C, Angle, r - 85);
            Point p2 = EndPoint(C, 180 + Angle, 29);
            Point p3 = EndPoint(C, Angle + 90, 12);
            Point p4 = EndPoint(C, Angle - 90, 12);
            //
            g.DrawLine(pHrs, p1, p3);
            g.DrawLine(pHrs, p3, p2);
            g.DrawLine(pHrs, p2, p4);
            g.DrawLine(pHrs, p4, p1);
        }
        //
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
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            W = pictureBox1.Width;
            H = pictureBox1.Height;
            bmp = new Bitmap(W + 1, H + 1);
            C = new Point(W / 2, H / 2);
            r = 220;
            timer1.Start();
        }
    }
}