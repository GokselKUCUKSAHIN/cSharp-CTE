using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int res = 500;
        
        Random r = new Random();
        Bitmap bmp = new Bitmap(res, res);
        private void button1_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < res; y+=10)
            {
                for (int x = 0; x < res; x+=10)
                {
                    int gray = r.Next(256);
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            bmp.SetPixel(x+i, y+j, Color.FromArgb(255, gray, gray, gray));
                        }
                    }
                }
            }
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(bmp != null)
            {
                bmp.Save("white_noise.png");
            }
        }
    }
}
/*
 * bmp.SetPixel(x, y, Color.FromArgb(255, gray, gray, gray));
                    bmp.SetPixel(x+1, y, Color.FromArgb(255, gray, gray, gray));
                    bmp.SetPixel(x, y+1, Color.FromArgb(255, gray, gray, gray));
                    bmp.SetPixel(x+1, y+1, Color.FromArgb(255, gray, gray, gray));
*/