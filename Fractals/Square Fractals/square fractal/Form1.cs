using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace square_fractal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pen pen = new Pen(Color.Snow, 1.6f);
        Point s = new Point(50, 50);
        List<kare> permanent = new List<kare>();
        List<kare> Liste = new List<kare>();
        List<kare> tmp = new List<kare>();
        List<kare> C = new List<kare>();
        int count = 0;

        private void panel1_Click(object sender, EventArgs e)
        {
            kare sqrt = new kare(s, 500);
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.FromArgb(255, 51, 51, 51));
            if (count == 0)
            {
                g.Clear(Color.FromArgb(255, 51, 51, 51));
                sqrt.draw(g, pen);
                //permanent.Add(sqrt);
            }
            else if (count == 1)
            {
                g.Clear(Color.FromArgb(255, 51, 51, 51));
                tmp = sqrt.Generate();
                C.Add(tmp[0]);
                C.Add(tmp[1]);
                C.Add(tmp[2]);
                C.Add(tmp[3]);
                C.Add(tmp[4]);
                for (int i = 0; i < C.Count; i++)
                {
                    C[i].draw(g, pen);
                    //permanent.Add(C[i]);
                }
                tmp.Clear();
            }
            else if (count >= 2)
            {
                if (count % 2 == 0)
                {
                    g.Clear(Color.FromArgb(255, 51, 51, 51));
                    for (int i = 0; i < C.Count; i++)
                    {
                        tmp = C[i].Generate();
                        for (int k = 0; k < tmp.Count; k++)
                        {
                            Liste.Add(tmp[k]);
                        }
                        tmp.Clear();
                    }
                    C.Clear();
                    for (int i = 0; i < Liste.Count; i++)
                    {
                        Liste[i].draw(g, pen);
                        //permanent.Add(Liste[i]);
                    }
                }
                else
                {
                    g.Clear(Color.FromArgb(255, 51, 51, 51));
                    for (int i = 0; i < Liste.Count; i++)
                    {
                        tmp = Liste[i].Generate();
                        for (int k = 0; k < tmp.Count; k++)
                        {
                            C.Add(tmp[k]);
                        }
                        tmp.Clear();
                    }
                    Liste.Clear();
                    for (int i = 0; i < C.Count; i++)
                    {
                        C[i].draw(g, pen);
                        //permanent.Add(C[i]);
                    }
                }
            }
            count++;
            /*
            for (int i = 0; i < permanent.Count; i++)
            {
                permanent[i].draw(g, pen);
            }*/
        }

    }
}