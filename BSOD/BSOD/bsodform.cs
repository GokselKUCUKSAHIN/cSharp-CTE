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
    public partial class bsodform : Form
    {
        public bsodform()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            Cursor.Hide();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((i >= 3) && (i <= 5))
            {
                label3.Text = "9% complete";
            }
            else if ((i >= 6) && (i <= 9))
            {
                label3.Text = "20% complete";
            }
            else if ((i >= 10) && (i <= 15))
            {
                label3.Text = "35% complete";
            }
            else if ((i >= 16) && (i <= 19))
            {
                label3.Text = "46% complete";
            }
            else if ((i >= 20) && (i <= 21))
            {
                label3.Text = "61% complete";
            }
            else if ((i >= 22) && (i <= 26))
            {
                label3.Text = "70% complete";
            }
            else if ((i >= 27) && (i <= 30))
            {
                label3.Text = "87% complete";
            }
            else if ((i >= 30) && (i <= 50))
            {
                label3.Text = "99% complete";
            }
            i++;
        }
    }
}
