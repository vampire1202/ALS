namespace ALS
{
    partial class frmSetMethod
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnHDF = new System.Windows.Forms.RadioButton();
            this.rbtnPE = new System.Windows.Forms.RadioButton();
            this.rbtnLi = new System.Windows.Forms.RadioButton();
            this.rbtnPDF = new System.Windows.Forms.RadioButton();
            this.rbtnHP = new System.Windows.Forms.RadioButton();
            this.rbtnPP = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTreat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecycle = new System.Windows.Forms.Button();
            this.btnFlush = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.rbtnHDF);
            this.groupBox2.Controls.Add(this.rbtnPE);
            this.groupBox2.Controls.Add(this.rbtnLi);
            this.groupBox2.Controls.Add(this.rbtnPDF);
            this.groupBox2.Controls.Add(this.rbtnHP);
            this.groupBox2.Controls.Add(this.rbtnPP);
            this.groupBox2.Location = new System.Drawing.Point(10, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 282);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择治疗方法";
            // 
            // rbtnHDF
            // 
            this.rbtnHDF.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnHDF.AutoEllipsis = true;
            this.rbtnHDF.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnHDF.Location = new System.Drawing.Point(250, 197);
            this.rbtnHDF.Name = "rbtnHDF";
            this.rbtnHDF.Size = new System.Drawing.Size(130, 60);
            this.rbtnHDF.TabIndex = 12;
            this.rbtnHDF.Tag = "CHDFConfig";
            this.rbtnHDF.Text = "CHDF";
            this.rbtnHDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnHDF.UseVisualStyleBackColor = true;
            this.rbtnHDF.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // rbtnPE
            // 
            this.rbtnPE.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPE.AutoEllipsis = true;
            this.rbtnPE.BackColor = System.Drawing.Color.Transparent;
            this.rbtnPE.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnPE.Location = new System.Drawing.Point(250, 33);
            this.rbtnPE.Name = "rbtnPE";
            this.rbtnPE.Size = new System.Drawing.Size(130, 60);
            this.rbtnPE.TabIndex = 13;
            this.rbtnPE.Tag = "PEConfig";
            this.rbtnPE.Text = "PE";
            this.rbtnPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnPE.UseVisualStyleBackColor = false;
            this.rbtnPE.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // rbtnLi
            // 
            this.rbtnLi.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnLi.AutoEllipsis = true;
            this.rbtnLi.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnLi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnLi.Location = new System.Drawing.Point(37, 33);
            this.rbtnLi.Name = "rbtnLi";
            this.rbtnLi.Size = new System.Drawing.Size(130, 60);
            this.rbtnLi.TabIndex = 14;
            this.rbtnLi.Tag = "Li-ALSConfig";
            this.rbtnLi.Text = "Li-ALS";
            this.rbtnLi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnLi.UseVisualStyleBackColor = true;
            this.rbtnLi.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // rbtnPDF
            // 
            this.rbtnPDF.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPDF.AutoEllipsis = true;
            this.rbtnPDF.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnPDF.Location = new System.Drawing.Point(250, 115);
            this.rbtnPDF.Name = "rbtnPDF";
            this.rbtnPDF.Size = new System.Drawing.Size(130, 60);
            this.rbtnPDF.TabIndex = 15;
            this.rbtnPDF.Tag = "PDFConfig";
            this.rbtnPDF.Text = "PDF";
            this.rbtnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnPDF.UseVisualStyleBackColor = true;
            this.rbtnPDF.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // rbtnHP
            // 
            this.rbtnHP.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnHP.AutoEllipsis = true;
            this.rbtnHP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnHP.Location = new System.Drawing.Point(37, 197);
            this.rbtnHP.Name = "rbtnHP";
            this.rbtnHP.Size = new System.Drawing.Size(130, 60);
            this.rbtnHP.TabIndex = 16;
            this.rbtnHP.Tag = "PERTConfig";
            this.rbtnHP.Text = "PERT";
            this.rbtnHP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnHP.UseVisualStyleBackColor = true;
            this.rbtnHP.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // rbtnPP
            // 
            this.rbtnPP.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPP.AutoEllipsis = true;
            this.rbtnPP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnPP.Location = new System.Drawing.Point(37, 115);
            this.rbtnPP.Name = "rbtnPP";
            this.rbtnPP.Size = new System.Drawing.Size(130, 60);
            this.rbtnPP.TabIndex = 17;
            this.rbtnPP.Tag = "PPConfig";
            this.rbtnPP.Text = "PP";
            this.rbtnPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnPP.UseVisualStyleBackColor = true;
            this.rbtnPP.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnTreat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRecycle);
            this.groupBox1.Controls.Add(this.btnFlush);
            this.groupBox1.Location = new System.Drawing.Point(441, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 215);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "治疗方法操作管理";
            // 
            // btnTreat
            // 
            this.btnTreat.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnTreat.Location = new System.Drawing.Point(29, 105);
            this.btnTreat.Name = "btnTreat";
            this.btnTreat.Size = new System.Drawing.Size(88, 35);
            this.btnTreat.TabIndex = 11;
            this.btnTreat.Text = "治疗";
            this.btnTreat.UseVisualStyleBackColor = true;
            this.btnTreat.Click += new System.EventHandler(this.btnTreat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "*仅限系统管理员编辑";
            // 
            // btnRecycle
            // 
            this.btnRecycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecycle.Location = new System.Drawing.Point(29, 163);
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.Size = new System.Drawing.Size(88, 35);
            this.btnRecycle.TabIndex = 9;
            this.btnRecycle.Text = "回收";
            this.btnRecycle.UseVisualStyleBackColor = true;
            this.btnRecycle.Click += new System.EventHandler(this.btnRecycle_Click);
            // 
            // btnFlush
            // 
            this.btnFlush.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlush.Location = new System.Drawing.Point(29, 47);
            this.btnFlush.Name = "btnFlush";
            this.btnFlush.Size = new System.Drawing.Size(88, 35);
            this.btnFlush.TabIndex = 9;
            this.btnFlush.Text = "预冲";
            this.btnFlush.UseVisualStyleBackColor = true;
            this.btnFlush.Click += new System.EventHandler(this.btnFlush_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnOK.Location = new System.Drawing.Point(464, 249);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 50);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmSetMethod
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 312);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSetMethod";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "李氏人工肝治疗方法设置";
            this.Load += new System.EventHandler(this.frmSetMethod_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTreat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecycle;
        private System.Windows.Forms.Button btnFlush;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rbtnHDF;
        private System.Windows.Forms.RadioButton rbtnPE;
        private System.Windows.Forms.RadioButton rbtnLi;
        private System.Windows.Forms.RadioButton rbtnPDF;
        private System.Windows.Forms.RadioButton rbtnHP;
        private System.Windows.Forms.RadioButton rbtnPP;

    }
}