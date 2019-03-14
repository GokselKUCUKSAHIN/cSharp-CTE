using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using System.Windows.Forms;

namespace Numlock20
{
    public partial class MainForm : Form
    {
        bool Kilit, Trigger = false;
        
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
           // this.Hide();
        }
        public static bool NumlockActive()
        {
            return Control.IsKeyLocked(Keys.NumLock);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void System_Tray_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("This App Created by Goksel Kucuksahin", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            InputSimulator.SimulateKeyPress(VirtualKeyCode.NUMLOCK);
        }


        private void Sayac_Tick(object sender, EventArgs e)
        {
            Kilit = NumlockActive();
            if (Kilit == true)
            {
                if (Trigger == false)
                {
                    Trigger = true;
                    System_Tray.Icon = Properties.Resources.Locked;
                    ButtonOn.Visible = true;
                    ButtonOff.Visible = false;
                    pictureBox_Active.Visible = true;
                    pictureBox_Passive.Visible = false;
                }
            }
            else
            {
                if (Trigger == true)
                {
                    Trigger = false;
                    System_Tray.Icon = Properties.Resources.Unlocked;
                    ButtonOn.Visible = false;
                    ButtonOff.Visible = true;
                    pictureBox_Passive.Visible = true;
                    pictureBox_Active.Visible = false;
                }
            }
        }




    }
}
