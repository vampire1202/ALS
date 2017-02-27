namespace ALS.FormSet
{
    partial class frmSetSyringe
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLen50 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLen30 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLen20 = new System.Windows.Forms.TextBox();
            this.btnStartAdjust = new System.Windows.Forms.Button();
            this.btnStopAdjust = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "注射器长度测量,以50mL规格的注射器为例,如下图所示:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = global::ALS.Properties.Resources.SetSyringe;
            this.pictureBox1.Location = new System.Drawing.Point(5, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(686, 276);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 106);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "长度设置";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(565, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 58);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "保存设置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLen50);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(400, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 74);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "50mL(单位:mm)";
            // 
            // txtLen50
            // 
            this.txtLen50.BackColor = System.Drawing.Color.White;
            this.txtLen50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLen50.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLen50.ForeColor = System.Drawing.Color.Black;
            this.txtLen50.Location = new System.Drawing.Point(3, 25);
            this.txtLen50.Name = "txtLen50";
            this.txtLen50.ReadOnly = true;
            this.txtLen50.Size = new System.Drawing.Size(142, 41);
            this.txtLen50.TabIndex = 0;
            this.txtLen50.Text = "76.2";
            this.txtLen50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLen50.Click += new System.EventHandler(this.txtLen20_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLen30);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(209, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 74);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "30mL(单位:mm)";
            // 
            // txtLen30
            // 
            this.txtLen30.BackColor = System.Drawing.Color.White;
            this.txtLen30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLen30.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLen30.ForeColor = System.Drawing.Color.Black;
            this.txtLen30.Location = new System.Drawing.Point(3, 25);
            this.txtLen30.Name = "txtLen30";
            this.txtLen30.ReadOnly = true;
            this.txtLen30.Size = new System.Drawing.Size(142, 41);
            this.txtLen30.TabIndex = 0;
            this.txtLen30.Text = "80.9";
            this.txtLen30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLen30.Click += new System.EventHandler(this.txtLen20_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLen20);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(18, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 74);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "20mL(单位:mm)";
            // 
            // txtLen20
            // 
            this.txtLen20.BackColor = System.Drawing.Color.White;
            this.txtLen20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLen20.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLen20.ForeColor = System.Drawing.Color.Black;
            this.txtLen20.Location = new System.Drawing.Point(3, 25);
            this.txtLen20.Name = "txtLen20";
            this.txtLen20.ReadOnly = true;
            this.txtLen20.Size = new System.Drawing.Size(142, 41);
            this.txtLen20.TabIndex = 0;
            this.txtLen20.Text = "69.8";
            this.txtLen20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLen20.Click += new System.EventHandler(this.txtLen20_Click);
            // 
            // btnStartAdjust
            // 
            this.btnStartAdjust.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartAdjust.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartAdjust.Location = new System.Drawing.Point(445, 137);
            this.btnStartAdjust.Name = "btnStartAdjust";
            this.btnStartAdjust.Size = new System.Drawing.Size(108, 42);
            this.btnStartAdjust.TabIndex = 27;
            this.btnStartAdjust.Text = "开始校准";
            this.btnStartAdjust.UseVisualStyleBackColor = true;
            // 
            // btnStopAdjust
            // 
            this.btnStopAdjust.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopAdjust.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopAdjust.Location = new System.Drawing.Point(570, 137);
            this.btnStopAdjust.Name = "btnStopAdjust";
            this.btnStopAdjust.Size = new System.Drawing.Size(108, 42);
            this.btnStopAdjust.TabIndex = 27;
            this.btnStopAdjust.Text = "结束校准";
            this.btnStopAdjust.UseVisualStyleBackColor = true;
            // 
            // frmSetSyringe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 474);
            this.Controls.Add(this.btnStopAdjust);
            this.Controls.Add(this.btnStartAdjust);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSetSyringe";
            this.Padding = new System.Windows.Forms.Padding(5, 15, 5, 5);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注射器设置";
            this.Load += new System.EventHandler(this.frmSetSyringe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLen20;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtLen50;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLen30;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnStartAdjust;
        public System.Windows.Forms.Button btnStopAdjust;
    }
}