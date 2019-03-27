using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexagonDrawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timerR.Interval = value;  //RED
            timerG.Interval = value;  //GREEN
            timerB.Interval = value;  //BLUE
            timerI.Interval = value;  //REFRESH
        }
        Graphics g;
        Bitmap bmp;
        Pen pen = new Pen(Color.FromArgb(255, 5, 5, 5), 2.6f);
        Pen pen2 = new Pen(Color.FromArgb(230, 255, 15, 15), 4f);
        //
        Pen pSec = new Pen(Color.FromArgb(5, 45, 190, 150), 2.6f);
        Pen pMin = new Pen(Color.FromArgb(200, 0, 20, 240), 2f);
        Pen pHrs = new Pen(Color.FromArgb(200, 0, 255, 0), 2f);
        //
        int W;
        int H;
        Point C;
        private void Button1_Click(object sender, EventArgs e)
        {
            W = pictureBox1.Width;
            H = pictureBox1.Height;
            bmp = new Bitmap(W + 1, H + 1);
            C = new Point(W / 2, H / 2);
            /*
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawHexagon(new Point(W / 2, H / 2), 250, 0);
            pictureBox1.Image = bmp;
            g.Dispose();
            */
            timer1.Start();
            timerR.Enabled = true;
            timerG.Enabled = true;
            timerB.Enabled = true;
            timerI.Enabled = true;
        }
        private void DrawPolygon(Point center, int Length, int angle, int edge)
        {
            //calculate
            Point[] Hexagon = new Point[edge];
            int a = angle;
            int offset = (int)(360 / (float)(edge));
            for (int i = 0; i < edge; i++)
            {
                Hexagon[i] = EndPoint(center, a, Length);
                a += offset;
            }
            //draw
            g.DrawPolygon(pSec, Hexagon);
        }
        int alfa = 0;
        int size = 200;
        bool site = false;
        //
        Random rand = new Random();
        int shape = 3;
        bool decs = false;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);
            //g.Clear(Color.White);
            //pSec.Color = Color.FromArgb(150,rand.Next(50,150), rand.Next(110,220), rand.Next(50,200));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawPolygon(new Point(W / 2, H / 2), size, alfa, shape);
            pictureBox1.Image = bmp;
            g.Dispose();
            alfa += 1;
            if (size >= 300)
            {
                site = true;
                if (!decs)
                {
                    shape++;
                }
                else
                {
                    shape--;
                }
            }
            else if (size <= 50)
            {
                site = false;
                if (!decs)
                {
                    shape++;
                }
                else
                {
                    shape--;
                }
            }
            if (site)
            {
                size -= 1;
            }
            else
            {
                size += 1;
            }
            if (shape > 7)
            {
                decs = true;
            }
            else if (shape < 3)
            {
                shape = 4;
                decs = false;
            }
        }
        //
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
        int value = 100;
        int red = 255;
        int green = 255;
        int blue = 0;
        int flag = 0;

        private void R_Tick(object sender, EventArgs e)
        {
            //RED
            if (flag == 2)
            {
                red -= 5;
                if (red <= 0)
                {
                    red = 0;
                    flag = 3;
                }
            }
            else if (flag == 5)
            {
                red += 5;
                if (red >= 255)
                {
                    red = 255;
                    flag = 0;
                }
            }

        }

        private void G_Tick(object sender, EventArgs e)
        {
            //GREEN
            if (flag == 0)
            {
                green -= 5;
                if (green <= 0)
                {
                    green = 0;
                    flag = 1;
                }

            }
            else if (flag == 3)
            {
                green += 5;
                if (green >= 255)
                {
                    green = 255;
                    flag = 4;
                }
            }
        }

        private void B_Tick(object sender, EventArgs e)
        {
            //BLUE
            if (flag == 1)
            {
                blue += 5;
                if (blue >= 255)
                {
                    blue = 255;
                    flag = 2;
                }
            }
            else if (flag == 4)
            {
                blue -= 5;
                if (blue <= 0)
                {
                    blue = 0;
                    flag = 5;
                }
            }
        }

        private void I_Tick(object sender, EventArgs e)
        {
            //Refresh
            this.BackColor = Color.FromArgb(255, red, green, blue);
            pSec.Color = Color.FromArgb(80, red, green, blue);
        }

    }
}