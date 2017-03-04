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
            this.rbtnCHDF = new System.Windows.Forms.RadioButton();
            this.rbtnPE = new System.Windows.Forms.RadioButton();
            this.rbtnLi = new System.Windows.Forms.RadioButton();
            this.rbtnPDF = new System.Windows.Forms.RadioButton();
            this.rbtnPERT = new System.Windows.Forms.RadioButton();
            this.rbtnPP = new System.Windows.Forms.RadioButton();
            this.btnOK = new PulseButton.PulseButton();
            this.btnCancle = new PulseButton.PulseButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnCHDF
            // 
            this.rbtnCHDF.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnCHDF.AutoEllipsis = true;
            this.rbtnCHDF.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCHDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.rbtnCHDF.Location = new System.Drawing.Point(317, 101);
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
            this.rbtnPE.Location = new System.Drawing.Point(168, 17);
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
            this.rbtnLi.Location = new System.Drawing.Point(19, 17);
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
            this.rbtnPDF.Location = new System.Drawing.Point(168, 101);
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
            this.rbtnPERT.Location = new System.Drawing.Point(20, 101);
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
            this.rbtnPP.Location = new System.Drawing.Point(317, 17);
            this.rbtnPP.Name = "rbtnPP";
            this.rbtnPP.Size = new System.Drawing.Size(120, 60);
            this.rbtnPP.TabIndex = 17;
            this.rbtnPP.Tag = "PP";
            this.rbtnPP.Text = "PP";
            this.rbtnPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnPP.UseVisualStyleBackColor = true;
            this.rbtnPP.CheckedChanged += new System.EventHandler(this.rbtnLi_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnOK.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnOK.CornerRadius = 25;
            this.btnOK.FocusColor = System.Drawing.Color.Black;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.Location = new System.Drawing.Point(97, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.NumberOfPulses = 2;
            this.btnOK.PulseColor = System.Drawing.Color.DimGray;
            this.btnOK.PulseSpeed = 0.3F;
            this.btnOK.PulseWidth = 6;
            this.btnOK.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnOK.Size = new System.Drawing.Size(112, 62);
            this.btnOK.TabIndex = 122;
            this.btnOK.Text = "确  定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnCancle.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnCancle.CornerRadius = 25;
            this.btnCancle.FocusColor = System.Drawing.Color.Black;
            this.btnCancle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancle.Location = new System.Drawing.Point(247, 203);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.NumberOfPulses = 2;
            this.btnCancle.PulseColor = System.Drawing.Color.DimGray;
            this.btnCancle.PulseSpeed = 0.3F;
            this.btnCancle.PulseWidth = 6;
            this.btnCancle.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnCancle.Size = new System.Drawing.Size(112, 62);
            this.btnCancle.TabIndex = 122;
            this.btnCancle.Text = "取  消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.rbtnLi);
            this.panel1.Controls.Add(this.rbtnCHDF);
            this.panel1.Controls.Add(this.rbtnPDF);
            this.panel1.Controls.Add(this.rbtnPERT);
            this.panel1.Controls.Add(this.rbtnPE);
            this.panel1.Controls.Add(this.rbtnPP);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 189);
            this.panel1.TabIndex = 123;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Silver;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 188);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(454, 1);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // frmSetMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 278);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSetMethod";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "李氏人工肝治疗方法设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetMethod_FormClosing);
            this.Load += new System.EventHandler(this.frmSetMethod_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnCHDF;
        private System.Windows.Forms.RadioButton rbtnPE;
        private System.Windows.Forms.RadioButton rbtnLi;
        private System.Windows.Forms.RadioButton rbtnPDF;
        private System.Windows.Forms.RadioButton rbtnPERT;
        private System.Windows.Forms.RadioButton rbtnPP;
        public PulseButton.PulseButton btnOK;
        public PulseButton.PulseButton btnCancle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;

    }
}