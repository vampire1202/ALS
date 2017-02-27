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
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
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
            this.paltop.Controls.Add(this.skinLabel2);
            this.paltop.Controls.Add(this.skinLabel1);
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
            this.paltop.Size = new System.Drawing.Size(650, 58);
            this.paltop.TabIndex = 29;
            // 
            // skinLabel2
            // 
            this.skinLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.Silver;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.skinLabel2.Location = new System.Drawing.Point(562, 28);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(33, 17);
            this.skinLabel2.TabIndex = 7;
            this.skinLabel2.Text = "V1.0";
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderSize = 2;
            this.skinLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinLabel1.Font = new System.Drawing.Font("楷体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.Red;
            this.skinLabel1.Location = new System.Drawing.Point(5, 0);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(645, 58);
            this.skinLabel1.TabIndex = 6;
            this.skinLabel1.Text = "李 氏 人 工 肝 治 疗 系 统";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ALS.Properties.Resources.homepage1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 324);
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
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel1;
    }
}