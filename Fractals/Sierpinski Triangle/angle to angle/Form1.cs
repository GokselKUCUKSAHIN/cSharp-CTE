using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace angle_to_angle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int ClickCount = 0;
        Point c1;
        Point c2;
        Point c3;
        static Pen pen = new Pen(Color.Black, 2f);
        Point x = new Point(400, 40);
        Point y = new Point(40, 740);
        Point z = new Point(760, 740);
        //Point z = new Point(700, 600);
        private void Form1_Click(object sender, EventArgs e)
        {
            List<Triangle> tr = new List<Triangle>();
            List<Triangle> ch = new List<Triangle>();
            Graphics pan = panel1.CreateGraphics();
            pan.Clear(Color.White);
            Triangle t1 = new Triangle(x, y, z,pan,pen);
            t1.DrawIt();
            ch = t1.RetTri();
            tr.Add(ch[0]);
            tr.Add(ch[1]);
            tr.Add(ch[2]);
            for (int i = 0; i < 363; i++) //1092
            {
                ch = tr[i].RetTri();
                tr.Add(ch[0]);
                tr.Add(ch[1]);
                tr.Add(ch[2]);
            }
            for (int i = 0; i < tr.Count; i++)
            {
                tr[i].DrawIt();
            }
            tr.Clear();
            ch.Clear();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (ClickCount)
            {
                case 0:
                    {
                        c1 = e.Location;
                        SelectPoint(c1);
                        ClickCount++;
                        break;
                    }
                case 1:
                    {
                        c2 = e.Location;
                        SelectPoint(c2);
                        ClickCount++;
                        break;
                    }
                case 2:
                    {
                        c3 = e.Location;
                        DrawFractal();
                        ClickCount = 0;
                        break;
                    }
                default:
                    {
                        ClickCount = 0;
                        break;
                    }
            }
        }
        private void DrawFractal()
        {
            List<Triangle> tr = new List<Triangle>();
            List<Triangle> ch = new List<Triangle>();
            Graphics pan = panel1.CreateGraphics();
            pan.Clear(Color.White);
            Triangle t1 = new Triangle(c1, c2, c3, pan, pen);
            t1.DrawIt();
            ch = t1.RetTri();
            tr.Add(ch[0]);
            tr.Add(ch[1]);
            tr.Add(ch[2]);
            for (int i = 0; i < 363; i++) //1092
            {
                ch = tr[i].RetTri();
                tr.Add(ch[0]);
                tr.Add(ch[1]);
                tr.Add(ch[2]);
            }
            for (int i = 0; i < tr.Count; i++)
            {
                tr[i].DrawIt();
            }
            tr.Clear();
            ch.Clear();
        }
        private void SelectPoint(Point Fore)
        {
            Graphics pan = panel1.CreateGraphics();
            pan.DrawEllipse(pen, Fore.X - 1, Fore.Y - 1, 2, 2);
            pan.DrawEllipse(pen, Fore.X - 5, Fore.Y - 5, 10, 10);
        }
    }
}
