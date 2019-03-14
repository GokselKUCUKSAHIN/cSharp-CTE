using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayToon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = trackBar1.Value + " Hz";
            label2.Text = trackBar2.Value + " ms";
            //Console.Beep(37, 32767);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value + " Hz";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value + " ms";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep(trackBar1.Value, trackBar2.Value);
        }
    }
}
