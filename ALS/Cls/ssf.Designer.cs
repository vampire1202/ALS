namespace ALS.Cls
{
    partial class ssf
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rtBox = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.paltop = new Owf.Controls.A1Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.paltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 382);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(650, 18);
            this.progressBar1.TabIndex = 0;
            // 
            // rtBox
            // 
            this.rtBox.BackColor = System.Drawing.Color.Azure;
            this.rtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtBox.Location = new System.Drawing.Point(0, 364);
            this.rtBox.Name = "rtBox";
            this.rtBox.ReadOnly = true;
            this.rtBox.Size = new System.Drawing.Size(553, 18);
            this.rtBox.TabIndex = 3;
            this.rtBox.Text = "";
            this.rtBox.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Enabled = false;
            this.btnExit.Location = new System.Drawing.Point(575, 358);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "点击关闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // paltop
            // 
            this.paltop.BorderColor = System.Drawing.Color.Silver;
            this.paltop.Controls.Add(this.label1);
            this.paltop.Controls.Add(this.label2);
            this.paltop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paltop.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.paltop.GradientStartColor = System.Drawing.Color.White;
            this.paltop.Image = null;
            this.paltop.ImageLocation = new System.Drawing.Point(4, 4);
            this.paltop.Location = new System.Drawing.Point(0, 0);
            this.paltop.Margin = new System.Windows.Forms.Padding(0);
            this.paltop.Name = "paltop";
            this.paltop.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.paltop.ShadowOffSet = 0;
            this.paltop.Size = new System.Drawing.Size(650, 78);
            this.paltop.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(553, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "V1.0";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(645, 78);
            this.label2.TabIndex = 8;
            this.label2.Text = "李 氏 人 工 肝 治 疗 系 统";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ALS.Properties.Resources.homepage1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 304);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ssf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rtBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.paltop);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ssf";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.paltop.ResumeLayout(false);
            this.paltop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.RichTextBox rtBox;
        public System.Windows.Forms.Button btnExit;
        private Owf.Controls.A1Panel paltop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}