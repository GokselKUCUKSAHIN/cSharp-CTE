using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vintage_Computer_Art
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        Graphics g;
        Pen p = new Pen(Color.Snow, 4f);
        Pen jedi = new Pen(Color.Pink, 2.6f);
        Pen sith = new Pen(Color.Red, 2.6f);
        bool click = false;
        Random r = new Random();
        int w = 300;
        int h = 300;
        float t = -200f;
        const int LineCount = 10;

        private void Form1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(601,601);
            if(click == true)
            {
                click = false;
                timer1.Stop();
            }
            else
            {
                click = true;
                timer1.Start();
            }
            
            /*
            Point p1 = new Point(30, 60);
            Point p2 = new Point(0, -50);
            g.DrawLine(p, p1, p2);
            g.DrawLine(p, tr(w,h,p1), tr(w,h,p2));*/
        }
        private void Anim()
        {
            g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(255, 51, 51, 51));
            for (int i = 0; i < LineCount; i++)
            {
                int gr = 90 + (i * 16);
                Color gray = Color.FromArgb(255, gr, gr, gr);
                p.Color = gray;
                g.DrawLine(p, Tr(w, h, X(t + i)), Tr(w, h, Y(t + i)));
                //g.DrawLine(jedi, tr(w, h, x(t + i)), tr(w, h, y(t + i)));
                //g.DrawLine(sith, tr(w, h, x2(t + i)), tr(w, h, y2(t + i)));
            }
            t += 0.89f;
            pictureBox1.Image = bmp;
            g.Dispose();
            //System.Threading.Thread.Sleep(20);
            
            //g.Clear(Color.FromArgb(255, 20, 20, 20));
        }
        private static Point X(double t) => new Point((int)((Math.Sin(t / 6) * 100) + (Math.Sin(t / 4) * 20)), (int)((Math.Sin(t / 10) * 200) + (Math.Sin(t) * 2)));
        private static Point Y(double t) => new Point((int)(Math.Cos(t / 10) * 100), (int)((Math.Cos(t / 20) * 100) + (Math.Cos(t / 12) * 20)));
        private static Point X2(double t) => new Point((int)((Math.Sin(t / 10) * 100) + (Math.Sin(t / 3) * 10)), (int)((Math.Sin(t / 10) * 130) + (Math.Sin(-t) * 7)));
        private static Point Y2(double t) => new Point((int)(Math.Cos(t / 7) * 150), (int)((Math.Cos(t / 16) * 70) + (Math.Cos(t / 9) * 29)));
        private static Point Tr(int left, int top, Point p) => new Point(left + p.X, top + p.Y);

        private void timer1_Tick(object sender, EventArgs e)
        {
            Anim();
        }
    }
}
