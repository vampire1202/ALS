namespace ALS.FormSet
{
    partial class ucSetSyringe
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
            this.groupSet = new System.Windows.Forms.GroupBox();
            this.lblRapidInjection = new System.Windows.Forms.Label();
            this.btnFast = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSet
            // 
            this.groupSet.Controls.Add(this.lblRapidInjection);
            this.groupSet.Controls.Add(this.btnFast);
            this.groupSet.Controls.Add(this.btnStop);
            this.groupSet.Controls.Add(this.label3);
            this.groupSet.Controls.Add(this.btnRun);
            this.groupSet.Controls.Add(this.label4);
            this.groupSet.Controls.Add(this.label1);
            this.groupSet.Controls.Add(this.label7);
            this.groupSet.Controls.Add(this.lblSpeed);
            this.groupSet.Controls.Add(this.btnSave);
            this.groupSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.groupSet.Location = new System.Drawing.Point(0, 0);
            this.groupSet.Name = "groupSet";
            this.groupSet.Size = new System.Drawing.Size(898, 532);
            this.groupSet.TabIndex = 0;
            this.groupSet.TabStop = false;
            this.groupSet.Text = "肝素泵";
            // 
            // lblRapidInjection
            // 
            this.lblRapidInjection.BackColor = System.Drawing.Color.Transparent;
            this.lblRapidInjection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRapidInjection.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRapidInjection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblRapidInjection.Location = new System.Drawing.Point(243, 317);
            this.lblRapidInjection.Name = "lblRapidInjection";
            this.lblRapidInjection.Size = new System.Drawing.Size(159, 50);
            this.lblRapidInjection.TabIndex = 14;
            this.lblRapidInjection.Text = "0.0";
            this.lblRapidInjection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRapidInjection.Click += new System.EventHandler(this.lblSpeed_Click);
            // 
            // btnFast
            // 
            this.btnFast.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFast.Image = global::ALS.Properties.Resources.fast;
            this.btnFast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFast.Location = new System.Drawing.Point(522, 311);
            this.btnFast.Name = "btnFast";
            this.btnFast.Padding = new System.Windows.Forms.Padding(10, 0, 8, 0);
            this.btnFast.Size = new System.Drawing.Size(108, 58);
            this.btnFast.TabIndex = 1;
            this.btnFast.Text = "快送";
            this.btnFast.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFast.UseVisualStyleBackColor = true;
            this.btnFast.Click += new System.EventHandler(this.btnFast_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Image = global::ALS.Properties.Resources.spstop;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(659, 161);
            this.btnStop.Name = "btnStop";
            this.btnStop.Padding = new System.Windows.Forms.Padding(10, 0, 8, 0);
            this.btnStop.Size = new System.Drawing.Size(108, 58);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "停止";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(98, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 34);
            this.label3.TabIndex = 0;
            this.label3.Text = "快送时注入量:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun.Image = global::ALS.Properties.Resources.spstart;
            this.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun.Location = new System.Drawing.Point(522, 161);
            this.btnRun.Name = "btnRun";
            this.btnRun.Padding = new System.Windows.Forms.Padding(10, 0, 8, 0);
            this.btnRun.Size = new System.Drawing.Size(108, 58);
            this.btnRun.TabIndex = 16;
            this.btnRun.Text = "运行";
            this.btnRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(423, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "[mL]";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(98, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 35);
            this.label1.TabIndex = 15;
            this.label1.Text = "注射速度:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(423, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "[mL/h]";
            // 
            // lblSpeed
            // 
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpeed.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblSpeed.Location = new System.Drawing.Point(243, 169);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(159, 50);
            this.lblSpeed.TabIndex = 13;
            this.lblSpeed.Text = "0.0";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSpeed.TextChanged += new System.EventHandler(this.lblSpeed_TextChanged);
            this.lblSpeed.Click += new System.EventHandler(this.lblSpeed_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Image = global::ALS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(659, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 8, 0);
            this.btnSave.Size = new System.Drawing.Size(108, 58);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存\r\n参数";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucSetSyringe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.groupSet);
            this.Name = "ucSetSyringe";
            this.Size = new System.Drawing.Size(898, 532);
            this.Load += new System.EventHandler(this.ucSetSyringe_Load);
            this.SizeChanged += new System.EventHandler(this.frmSetPump_SizeChanged);
            this.groupSet.ResumeLayout(false);
            this.groupSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRapidInjection;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnRun;
        public System.Windows.Forms.Button btnStop;
    }
}