namespace Numlock20
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.System_Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonOff = new System.Windows.Forms.Button();
            this.ButtonOn = new System.Windows.Forms.Button();
            this.Sayac = new System.Windows.Forms.Timer(this.components);
            this.button_minimize = new System.Windows.Forms.Button();
            this.pictureBox_Active = new System.Windows.Forms.PictureBox();
            this.pictureBox_Passive = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Active)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Passive)).BeginInit();
            this.SuspendLayout();
            // 
            // System_Tray
            // 
            this.System_Tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.System_Tray.BalloonTipText = "OK";
            this.System_Tray.BalloonTipTitle = "balloon";
            this.System_Tray.ContextMenuStrip = this.contextMenuStrip1;
            this.System_Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("System_Tray.Icon")));
            this.System_Tray.Text = "NumLock";
            this.System_Tray.Visible = true;
            this.System_Tray.DoubleClick += new System.EventHandler(this.System_Tray_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 56);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Image = global::Numlock20.Properties.Resources.eye_icon;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::Numlock20.Properties.Resources.cancel;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ButtonOff
            // 
            this.ButtonOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOff.BackgroundImage = global::Numlock20.Properties.Resources.SliderOffREd;
            this.ButtonOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonOff.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOff.FlatAppearance.BorderSize = 0;
            this.ButtonOff.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOff.Location = new System.Drawing.Point(149, -7);
            this.ButtonOff.Margin = new System.Windows.Forms.Padding(10);
            this.ButtonOff.Name = "ButtonOff";
            this.ButtonOff.Size = new System.Drawing.Size(150, 150);
            this.ButtonOff.TabIndex = 0;
            this.ButtonOff.TabStop = false;
            this.ButtonOff.UseVisualStyleBackColor = false;
            this.ButtonOff.Visible = false;
            this.ButtonOff.Click += new System.EventHandler(this.Button_Click);
            // 
            // ButtonOn
            // 
            this.ButtonOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOn.BackgroundImage = global::Numlock20.Properties.Resources.SliderOnGReen;
            this.ButtonOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonOn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOn.FlatAppearance.BorderSize = 0;
            this.ButtonOn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ButtonOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOn.Location = new System.Drawing.Point(149, -7);
            this.ButtonOn.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.ButtonOn.Name = "ButtonOn";
            this.ButtonOn.Size = new System.Drawing.Size(150, 150);
            this.ButtonOn.TabIndex = 0;
            this.ButtonOn.TabStop = false;
            this.ButtonOn.UseVisualStyleBackColor = false;
            this.ButtonOn.Visible = false;
            this.ButtonOn.Click += new System.EventHandler(this.Button_Click);
            // 
            // Sayac
            // 
            this.Sayac.Enabled = true;
            this.Sayac.Interval = 50;
            this.Sayac.Tick += new System.EventHandler(this.Sayac_Tick);
            // 
            // button_minimize
            // 
            this.button_minimize.BackgroundImage = global::Numlock20.Properties.Resources.Button_arrow_down_icon;
            this.button_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button_minimize.FlatAppearance.BorderSize = 0;
            this.button_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_minimize.Location = new System.Drawing.Point(324, 16);
            this.button_minimize.Margin = new System.Windows.Forms.Padding(15, 20, 15, 32);
            this.button_minimize.Name = "button_minimize";
            this.button_minimize.Size = new System.Drawing.Size(100, 100);
            this.button_minimize.TabIndex = 0;
            this.button_minimize.TabStop = false;
            this.button_minimize.UseVisualStyleBackColor = true;
            this.button_minimize.Click += new System.EventHandler(this.button_minimize_Click);
            // 
            // pictureBox_Active
            // 
            this.pictureBox_Active.Image = global::Numlock20.Properties.Resources.Lock;
            this.pictureBox_Active.Location = new System.Drawing.Point(24, 16);
            this.pictureBox_Active.Margin = new System.Windows.Forms.Padding(15, 20, 15, 32);
            this.pictureBox_Active.Name = "pictureBox_Active";
            this.pictureBox_Active.Size = new System.Drawing.Size(100, 100);
            this.pictureBox_Active.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Active.TabIndex = 1;
            this.pictureBox_Active.TabStop = false;
            this.pictureBox_Active.Visible = false;
            // 
            // pictureBox_Passive
            // 
            this.pictureBox_Passive.Image = global::Numlock20.Properties.Resources.LockPassive;
            this.pictureBox_Passive.Location = new System.Drawing.Point(24, 16);
            this.pictureBox_Passive.Margin = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.pictureBox_Passive.Name = "pictureBox_Passive";
            this.pictureBox_Passive.Size = new System.Drawing.Size(100, 100);
            this.pictureBox_Passive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Passive.TabIndex = 1;
            this.pictureBox_Passive.TabStop = false;
            this.pictureBox_Passive.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(448, 135);
            this.Controls.Add(this.button_minimize);
            this.Controls.Add(this.pictureBox_Active);
            this.Controls.Add(this.pictureBox_Passive);
            this.Controls.Add(this.ButtonOn);
            this.Controls.Add(this.ButtonOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NumLock Toggle";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Active)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Passive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonOn;
        private System.Windows.Forms.Button ButtonOff;
        private System.Windows.Forms.NotifyIcon System_Tray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer Sayac;
        private System.Windows.Forms.Button button_minimize;
        private System.Windows.Forms.PictureBox pictureBox_Active;
        private System.Windows.Forms.PictureBox pictureBox_Passive;
    }
}

