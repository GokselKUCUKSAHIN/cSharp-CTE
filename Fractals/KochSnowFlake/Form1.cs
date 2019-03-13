using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koch_SnowFlake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }/*
        Point a = new Point(50, 160);
        Point b = new Point(300, 560);
        Point c = new Point(550, 160);*/
        Point a = new Point(100, 260);
        Point b = new Point(500, 940);
        Point c = new Point(900, 260);

        static Pen kalem = new Pen(Color.Snow, 1f);
        static List<Segment> Liste = new List<Segment>();
        static List<Segment> C = new List<Segment>();
        int count = 0;
        private void Form1_Click(object sender, EventArgs e)
        {
            //
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.FromArgb(255, 51, 51, 51));
            if (count == 0)
            {
                g.Clear(Color.FromArgb(255, 51, 51, 51));
                g.DrawLine(kalem, a, c);
                g.DrawLine(kalem, b, a);
                g.DrawLine(kalem, c, b);
            }
            else if (count == 1)
            {
                g.Clear(Color.FromArgb(255, 51, 51, 51));
                Segment s1 = new Segment(a, c);
                Segment s2 = new Segment(b, a);
                Segment s3 = new Segment(c, b);
                C.Add(s1);
                C.Add(s2);
                C.Add(s3);
                s1.Draw(g, kalem);
                s2.Draw(g, kalem);
                s3.Draw(g, kalem);
            }
            else if (count >= 2)
            {
                if (count % 2 == 0)
                {
                    g.Clear(Color.FromArgb(255, 51, 51, 51));
                    for (int i = 0; i < C.Count; i++)
                    {
                        Liste.Add(new Segment(C[i].p1, C[i].p2));
                        Liste.Add(new Segment(C[i].p2, C[i].p3));
                        Liste.Add(new Segment(C[i].p3, C[i].p4));
                        Liste.Add(new Segment(C[i].p4, C[i].p5));
                    }
                    C.Clear();
                    for (int i = 0; i < Liste.Count; i++)
                    {
                        Liste[i].Draw(g, kalem);
                    }
                }
                else
                {
                    g.Clear(Color.FromArgb(255, 51, 51, 51));
                    for (int i = 0; i < Liste.Count; i++)
                    {
                        C.Add(new Segment(Liste[i].p1, Liste[i].p2));
                        C.Add(new Segment(Liste[i].p2, Liste[i].p3));
                        C.Add(new Segment(Liste[i].p3, Liste[i].p4));
                        C.Add(new Segment(Liste[i].p4, Liste[i].p5));
                    }
                    Liste.Clear();
                    for (int i = 0; i < C.Count; i++)
                    {
                        C[i].Draw(g, kalem);
                    }
                }
            }
            count++;
        }
    }
}
