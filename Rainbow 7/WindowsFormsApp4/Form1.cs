using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        int value=50;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = value;  //RED
            timer2.Interval = value;  //GREEN
            timer3.Interval = value;  //BLUE
            timer4.Interval = value;  //REFRESH
        }
        int red = 255;
        int green = 255;
        int blue = 0;
        int flag = 0;
        private void timer1_Tick(object sender, EventArgs e)
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            //GREEN
            if(flag==0)
            {
                green -= 5;
                if(green<=0)
                {
                    green = 0;
                    flag = 1;
                }

            }
            else if(flag==3)
            {
                green += 5;
                if(green>=255)
                {
                    green = 255;
                    flag = 4;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //BLUE
            if(flag==1)
            {
                blue += 5;
                if(blue>=255)
                {
                    blue = 255;
                    flag = 2;
                }
            }
            else if(flag==4)
            {
                blue -= 5;
                if(blue<=0)
                {
                    blue = 0;
                    flag = 5;
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //Refresh
            this.BackColor= Color.FromArgb(255, red, green, blue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
            button1.Visible = false;
            button2.Visible = true;
            //trackBar1.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e) //STOP
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            button1.Visible = true;
            button2.Visible = false;
            //trackBar1.Visible = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //label1.Text = trackBar1.Value.ToString();
            value = trackBar1.Value;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            value = trackBar1.Value;
            label1.Text = value.ToString();
        }
    }
}


/*
private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                int sayac = sayi-=5;
                this.BackColor = Color.FromArgb(255, sayi, sayi,sayi);
                if (sayi<=0)
                {
                    flag = 1;
                }
            }
            else
            {
                int sayac = sayi+=5;
                //label1.Text = sayac.ToString();
                this.BackColor = Color.FromArgb(sayi, sayi, sayi);
                if (sayi >= 255)
                {
                    flag = 0;
                }
            }
        }
*/