namespace BSOD
{
    partial class bsodform
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 125F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(249, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 242);
            this.label1.TabIndex = 0;
            this.label1.Text = ":)";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(290, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(764, 91);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your PC ran into a problem and needs to restart. We\'re just collecting some error" +
    " info, and then we\'ll restart for you.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(290, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(669, 43);
            this.label3.TabIndex = 2;
            this.label3.Text = "0% complete";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(509, 556);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(482, 64);
            this.label4.TabIndex = 4;
            this.label4.Text = "For more information about this issue and possible fixes, visit";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(509, 640);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(482, 40);
            this.label5.TabIndex = 5;
            this.label5.Text = "http://windows.com/j3llyb34nc1.aspx";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(509, 689);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(502, 67);
            this.label6.TabIndex = 6;
            this.label6.Text = "If you call a support person. give them this info:  Stop code: CRITICAL_TROLL_PRO" +
    "CESS_DIED";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BSOD.Properties.Resources.xd;
            this.pictureBox1.Location = new System.Drawing.Point(295, 556);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // bsodform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(1065, 589);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "bsodform";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
    }
}

