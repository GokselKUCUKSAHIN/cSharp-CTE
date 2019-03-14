using System;
using System.Windows.Forms;
using System.Drawing;

namespace CantTouchThis
{
    public partial class Form1 : Form
    {
        int value = 100;
        int red = 255;
        int green = 255;
        int blue = 0;
        int flag = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = value;  //RED
            timer2.Interval = value;  //GREEN
            timer3.Interval = value;  //BLUE
            timer4.Interval = value;  //REFRESH
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
            ButtonColorChanger();
            Change();
        }
        Random r = new Random();
        int Rx, Ry;
        int LolCounter = 0;

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            ButtonColorChanger();
            Change();
            LolCounter++;
            if(LolCounter==500)
            {
                MessageBox.Show("KOLSUZ! 500 Denemede bile basamadın!!!","XD",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                LolCounter = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TEBRİKLER","C#",MessageBoxButtons.OK);
        }

        public void Change()
        {
            Rx = r.Next(5, 197);
            Ry = r.Next(5, 174);
            button1.Top = Ry;
            button1.Left = Rx;
        }
        public void ButtonColorChanger()
        {
            byte Kirmizi = (byte)r.Next(0, 256);
            byte Yesil = (byte)r.Next(0, 256);
            byte Mavi = (byte)r.Next(0, 256);
            button1.BackColor = Color.FromArgb(255, Kirmizi, Yesil, Mavi);
        }

        //
        //RGB
        //
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

        private void timer3_Tick(object sender, EventArgs e)
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

        private void timer4_Tick(object sender, EventArgs e)
        {
            //Refresh
            this.BackColor = Color.FromArgb(255, red, green, blue);
        }
    }
}
