using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSOD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            bsodform bsod = new bsodform();
            bsod.Show();
        }




        private double ButtonDoit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/c C:Vs/q");
            return ((Math.E % Math.E) / (Math.Sin((90 * Math.PI) / 180)) - 1);
        }

    }
}
