using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        Graphics g;
        Random r = new Random();
        static Pen kalem = new Pen(Color.Snow, 2f);
        Point a = new Point(0,0);
        Point b = new Point(10,10);
        int i;
        int j;
        bool CM = false;
        Color c = Color.Snow;
        private void Form1_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(601, 601);
            i = 0;
            j = 0;
            timer1.Start();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);
            //
            if (j < 600)
            {
                if(i < 600)
                {
                    //draw something.
                    if (r.Next(0, 2) % 2 == 0)
                    {
                        //çift
                        a = new Point(i, j + 10);
                        b = new Point(i + 10, j);
                    }
                    else
                    {
                        //tek
                        a = new Point(i, j);
                        b = new Point(i + 10, j + 10);
                    }
                    //
                    if(CM)
                    {
                        Colorness();
                    }
                    g.DrawLine(kalem, a, b);
                    //
                    pictureBox1.Image = bmp;
                    g.Dispose();
                    //
                    i += 10;
                }
                else
                {
                    i = 0;
                    j += 10;
                }
            }
            else
            {
                //done
                timer1.Stop();
                //pictureBox1.BackColor = Color.Red;
            }
        }
        private void Colorness()
        {
            byte red = (byte)r.Next(256);
            byte green = (byte)r.Next(256);
            byte blue = (byte)r.Next(256);
            c = Color.FromArgb(255, red, green, blue);
            kalem.Color = c;
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(CM)
            {
                c = Color.Snow;
                kalem.Color = c;
                CM = false;
            }
            else
            {
                CM = true;
            }
        }
    }
}
