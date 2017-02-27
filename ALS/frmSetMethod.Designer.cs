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
            this.components = new System.ComponentModel.Container();
            this.rbtnCHDF = new System.Windows.Forms.RadioButton();
            this.rbtnPE = new System.Windows.Forms.RadioButton();
            this.rbtnLi = new System.Windows.Forms.RadioButton();
            this.rbtnPDF = new System.Windows.Forms.RadioButton();
            this.rbtnPERT = new System.Windows.Forms.RadioButton();
            this.rbtnPP = new System.Windows.Forms.RadioButton();
            this.btnFlush = new CCWin.SkinControl.SkinButton();
            this.btnTreat = new CCWin.SkinControl.SkinButton();
            this.btnRecycle = new CCWin.SkinControl.SkinButton();
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.btnCancle = new CCWin.SkinControl.SkinButton();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.skinGroupBox1.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnCHDF
            // 
            this.rbtnCHDF.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnCHDF.AutoEllipsis = true;
            this.rbtnCHDF.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCHDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnCHDF.Location = new System.Drawing.Point(315, 103);
            this.rbtnCHDF.Name = "rbtnCHDF";
            this.rbtnCHDF.Size = new System.Drawing.Size(120, 60);
            this.rbtnCHDF.TabIndex = 12;
            this.rbtnCHDF.Tag = "CHDF";
            this.rbtnCHDF.Text = "CHDF";
            this.rbtnCHDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnCHDF.UseVisualStyleBackColor = true;
            this.rbtnCHDF.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // rbtnPE
            // 
            this.rbtnPE.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPE.AutoEllipsis = true;
            this.rbtnPE.BackColor = System.Drawing.Color.Transparent;
            this.rbtnPE.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnPE.Location = new System.Drawing.Point(166, 19);
            this.rbtnPE.Name = "rbtnPE";
            this.rbtnPE.Size = new System.Drawing.Size(120, 60);
            this.rbtnPE.TabIndex = 13;
            this.rbtnPE.Tag = "PE";
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
            this.rbtnLi.Location = new System.Drawing.Point(17, 19);
            this.rbtnLi.Name = "rbtnLi";
            this.rbtnLi.Size = new System.Drawing.Size(120, 60);
            this.rbtnLi.TabIndex = 14;
            this.rbtnLi.Tag = "Li-ALS";
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
            this.rbtnPDF.Location = new System.Drawing.Point(166, 103);
            this.rbtnPDF.Name = "rbtnPDF";
            this.rbtnPDF.Size = new System.Drawing.Size(120, 60);
            this.rbtnPDF.TabIndex = 15;
            this.rbtnPDF.Tag = "PDF";
            this.rbtnPDF.Text = "PDF";
            this.rbtnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnPDF.UseVisualStyleBackColor = true;
            this.rbtnPDF.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // rbtnPERT
            // 
            this.rbtnPERT.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPERT.AutoEllipsis = true;
            this.rbtnPERT.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPERT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnPERT.Location = new System.Drawing.Point(18, 103);
            this.rbtnPERT.Name = "rbtnPERT";
            this.rbtnPERT.Size = new System.Drawing.Size(120, 60);
            this.rbtnPERT.TabIndex = 16;
            this.rbtnPERT.Tag = "PERT";
            this.rbtnPERT.Text = "PEF";
            this.rbtnPERT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnPERT.UseVisualStyleBackColor = true;
            this.rbtnPERT.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // rbtnPP
            // 
            this.rbtnPP.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnPP.AutoEllipsis = true;
            this.rbtnPP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnPP.Location = new System.Drawing.Point(315, 19);
            this.rbtnPP.Name = "rbtnPP";
            this.rbtnPP.Size = new System.Drawing.Size(120, 60);
            this.rbtnPP.TabIndex = 17;
            this.rbtnPP.Tag = "PP";
            this.rbtnPP.Text = "PP";
            this.rbtnPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnPP.UseVisualStyleBackColor = true;
            this.rbtnPP.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // btnFlush
            // 
            this.btnFlush.BackColor = System.Drawing.Color.Transparent;
            this.btnFlush.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnFlush.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnFlush.DownBack = null;
            this.btnFlush.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFlush.ForeColor = System.Drawing.Color.White;
            this.btnFlush.Location = new System.Drawing.Point(21, 41);
            this.btnFlush.MouseBack = null;
            this.btnFlush.Name = "btnFlush";
            this.btnFlush.NormlBack = null;
            this.btnFlush.Radius = 35;
            this.btnFlush.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnFlush.Size = new System.Drawing.Size(88, 35);
            this.btnFlush.TabIndex = 20;
            this.btnFlush.Text = "预冲";
            this.btnFlush.UseVisualStyleBackColor = false;
            // 
            // btnTreat
            // 
            this.btnTreat.BackColor = System.Drawing.Color.Transparent;
            this.btnTreat.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnTreat.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnTreat.DownBack = null;
            this.btnTreat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTreat.ForeColor = System.Drawing.Color.White;
            this.btnTreat.Location = new System.Drawing.Point(21, 89);
            this.btnTreat.MouseBack = null;
            this.btnTreat.Name = "btnTreat";
            this.btnTreat.NormlBack = null;
            this.btnTreat.Radius = 35;
            this.btnTreat.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnTreat.Size = new System.Drawing.Size(88, 35);
            this.btnTreat.TabIndex = 20;
            this.btnTreat.Text = "治疗";
            this.btnTreat.UseVisualStyleBackColor = false;
            // 
            // btnRecycle
            // 
            this.btnRecycle.BackColor = System.Drawing.Color.Transparent;
            this.btnRecycle.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRecycle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnRecycle.DownBack = null;
            this.btnRecycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecycle.ForeColor = System.Drawing.Color.White;
            this.btnRecycle.Location = new System.Drawing.Point(21, 137);
            this.btnRecycle.MouseBack = null;
            this.btnRecycle.Name = "btnRecycle";
            this.btnRecycle.NormlBack = null;
            this.btnRecycle.Radius = 35;
            this.btnRecycle.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnRecycle.Size = new System.Drawing.Size(88, 35);
            this.btnRecycle.TabIndex = 20;
            this.btnRecycle.Text = "回收";
            this.btnRecycle.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DownBack = null;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(119, 219);
            this.btnOK.MouseBack = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Radius = 40;
            this.btnOK.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnOK.Size = new System.Drawing.Size(90, 40);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.Transparent;
            this.btnCancle.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnCancle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancle.DownBack = null;
            this.btnCancle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(263, 219);
            this.btnCancle.MouseBack = null;
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.NormlBack = null;
            this.btnCancle.Radius = 40;
            this.btnCancle.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnCancle.Size = new System.Drawing.Size(90, 40);
            this.btnCancle.TabIndex = 19;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox1.Controls.Add(this.btnRecycle);
            this.skinGroupBox1.Controls.Add(this.btnTreat);
            this.skinGroupBox1.Controls.Add(this.btnFlush);
            this.skinGroupBox1.Controls.Add(this.label2);
            this.skinGroupBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox1.Location = new System.Drawing.Point(8, 253);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(127, 187);
            this.skinGroupBox1.TabIndex = 20;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "治疗方法管理";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Gainsboro;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(5, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "*仅限系统管理员编辑";
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.skinGroupBox2.Controls.Add(this.splitter1);
            this.skinGroupBox2.Controls.Add(this.rbtnCHDF);
            this.skinGroupBox2.Controls.Add(this.rbtnLi);
            this.skinGroupBox2.Controls.Add(this.rbtnPE);
            this.skinGroupBox2.Controls.Add(this.rbtnPP);
            this.skinGroupBox2.Controls.Add(this.rbtnPERT);
            this.skinGroupBox2.Controls.Add(this.rbtnPDF);
            this.skinGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox2.Font = new System.Drawing.Font("宋体", 10F);
            this.skinGroupBox2.ForeColor = System.Drawing.Color.Black;
            this.skinGroupBox2.Location = new System.Drawing.Point(8, 8);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.Size = new System.Drawing.Size(454, 192);
            this.skinGroupBox2.TabIndex = 21;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.LightGray;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 188);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(448, 1);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // frmSetMethod
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 278);
            this.ControlBox = false;
            this.Controls.Add(this.skinGroupBox2);
            this.Controls.Add(this.skinGroupBox1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSetMethod";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "李氏人工肝治疗方法设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetMethod_FormClosing);
            this.Load += new System.EventHandler(this.frmSetMethod_Load);
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.PerformLayout();
            this.skinGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnCHDF;
        private System.Windows.Forms.RadioButton rbtnPE;
        private System.Windows.Forms.RadioButton rbtnLi;
        private System.Windows.Forms.RadioButton rbtnPDF;
        private System.Windows.Forms.RadioButton rbtnPERT;
        private System.Windows.Forms.RadioButton rbtnPP;
        public CCWin.SkinControl.SkinButton btnOK;
        public CCWin.SkinControl.SkinButton btnCancle;
        private CCWin.SkinControl.SkinButton btnRecycle;
        private CCWin.SkinControl.SkinButton btnTreat;
        private CCWin.SkinControl.SkinButton btnFlush;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private System.Windows.Forms.Splitter splitter1;

    }
}