using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleTest
{
    public partial class Form1 : Form
    {
        int value = 50;
        public Form1()
        {
            InitializeComponent();
            R.Interval = value;  //RED
            G.Interval = value;  //GREEN
            B.Interval = value;  //BLUE
            I.Interval = value;  //REFRESH
        }
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
            pen.Color = Color.FromArgb(255, red, green, blue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            R.Enabled = true;
            G.Enabled = true;
            B.Enabled = true;
            I.Enabled = true;
        }



        Point m = new Point(250,250);
       
        private void Form1_Click(object sender, EventArgs e)
        {
            /*
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            g.DrawEllipse(pen, m.X - 10, m.Y - 10, 20, 20);
            Point x = EndPoint(m, 67, 150);
            g.DrawLine(pen, m, x);*/
            timer1.Start();
            R.Enabled = true;
            G.Enabled = true;
            B.Enabled = true;
            I.Enabled = true;
        }
        private Point EndPoint(Point o, int angle, int length)
        {
            var endPoint = o;
            endPoint.X += (int)(length * Math.Cos(Radian(angle)));
            endPoint.Y -= (int)(length * Math.Sin(Radian(angle)));
            return endPoint;
        }
        private double Radian(int angle)
        {
            return (Math.PI / 180.0) * angle;
        }
        int counter = 0;
        static Pen pen = new Pen(Color.Black, 0.1f);
        int i = -5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            //g.Clear(Color.White);
            //g.Clear(Color.FromArgb(255, 51, 51, 51));
            g.DrawEllipse(pen, m.X - 10, m.Y - 10, 20, 20);
            Point x = EndPoint(m, counter, 150);
            g.DrawEllipse(pen, x.X - 5, x.Y - 5, 10, 10);
            Point z = EndPoint(x, -i*counter, 75);
            g.DrawEllipse(pen, z.X - 8, z.Y - 8, 16, 16);
            g.DrawLine(pen, x, z);
            g.DrawLine(pen, m, x);

            counter++;
            if(counter == 360)
            {
                counter = 0;
                i++;
                if(i > 5)
                {
                    i = -5;
                }
            }
        }
    }
}
