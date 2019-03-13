using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalTree2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //p1 = new Point(panel1.Width / 2, panel1.Height);
        //p2 = new Point(panel1.Width / 2, panel1.Height/2);
        Bitmap bmp;
        Graphics g;
        static Pen kalem = new Pen(Color.Snow, 1f);
        Point p1 = new Point(300,600);
        Point p2 = new Point(300, 400);
        List<Dal> liste = new List<Dal>();
        List<Dal> C = new List<Dal>();
        int Aci = 45;
        private void Button1_Click(object sender, EventArgs e)
        {
            //Graphics g = panel1.CreateGraphics();
            bmp = new Bitmap(601, 601);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(255,51,51,51));
            p1 = new Point(pictureBox1.Width / 2, pictureBox1.Height);
            p2 = new Point(pictureBox1.Width / 2, pictureBox1.Height-200);
            Dal root = new Dal(p1, p2,Aci);
            root.Draw(g,kalem);
            root.DrawRoot(g, kalem);
            C.Clear();
            liste.Clear();
            C.Add(root);
            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < C.Count; k++)
                {
                    liste.Add(new Dal(C[k].end, C[k].r, Aci));
                    liste.Add(new Dal(C[k].end, C[k].l, Aci));
                }
                for (int k = 0; k < C.Count; k++)
                {
                    C[k].Draw(g, kalem);
                }
                C.Clear();
                for (int j = 0; j < liste.Count; j++)
                {
                    C.Add(new Dal(liste[j].end, liste[j].r, Aci));
                    C.Add(new Dal(liste[j].end, liste[j].l, Aci));
                }
                for (int k = 0; k < liste.Count; k++)
                {
                    liste[k].Draw(g, kalem);
                }
                liste.Clear();
            }
            pictureBox1.Image = bmp;
            g.Dispose();
       
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            Aci = trackBar1.Value;
            bmp = new Bitmap(601, 601);
            g = Graphics.FromImage(bmp);
            //Graphics g = panel1.CreateGraphics();
            g.Clear(Color.FromArgb(255, 51, 51, 51));
            Dal root = new Dal(p1, p2, Aci);
            root.Draw(g, kalem);
            root.DrawRoot(g, kalem);
            //Dal d1 = new Dal(root.end, root.l, Aci);
            //Dal d2 = new Dal(root.end, root.r, Aci);
            //d1.Draw(g, kalem);
            //d2.Draw(g, kalem);
            C.Clear();
            liste.Clear();
            C.Add(root);


            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < C.Count; k++)
                {
                    liste.Add(new Dal(C[k].end, C[k].r, Aci));
                    liste.Add(new Dal(C[k].end, C[k].l, Aci));
                }
                for (int k = 0; k < C.Count; k++)
                {
                    C[k].Draw(g, kalem);
                }
                C.Clear();
                for (int j = 0; j < liste.Count; j++)
                {
                    C.Add(new Dal(liste[j].end, liste[j].r, Aci));
                    C.Add(new Dal(liste[j].end, liste[j].l, Aci));
                }
                for (int k = 0; k < liste.Count; k++)
                {
                    liste[k].Draw(g, kalem);
                }
                liste.Clear();
               
            }
            pictureBox1.Image = bmp;
            g.Dispose();
        }
    }
}
