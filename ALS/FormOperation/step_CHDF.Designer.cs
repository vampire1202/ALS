namespace ALS.FormOperation
{
    partial class step_CHDF
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.wizardControl1 = new AeroWizard.StepWizardControl();
            this.wizardPage1 = new AeroWizard.WizardPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTargetSpeed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLeadBloodSpeed = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.wizardPage2 = new AeroWizard.WizardPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnPauseCHDF = new PulseButton.PulseButton();
            this.btnStartCHDF = new PulseButton.PulseButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardPage1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.wizardControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 315);
            this.panel2.TabIndex = 81;
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelButtonText = "抗凝剂泵";
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.wizardPage1);
            this.wizardControl1.Pages.Add(this.wizardPage2);
            this.wizardControl1.Size = new System.Drawing.Size(597, 315);
            this.wizardControl1.StepListWidth = 90;
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "2. 血滤治疗";
            this.wizardControl1.Cancelling += new System.ComponentModel.CancelEventHandler(this.wizardControl1_Cancelling);
            this.wizardControl1.Finished += new System.EventHandler(this.wizardControl1_Finished);
            this.wizardControl1.SelectedPageChanged += new System.EventHandler(this.wizardControl1_SelectedPageChanged);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.textBox1);
            this.wizardPage1.Controls.Add(this.label24);
            this.wizardPage1.Controls.Add(this.lblTargetSpeed);
            this.wizardPage1.Controls.Add(this.label4);
            this.wizardPage1.Controls.Add(this.lblLeadBloodSpeed);
            this.wizardPage1.Controls.Add(this.label26);
            this.wizardPage1.Controls.Add(this.label7);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(482, 222);
            this.wizardPage1.TabIndex = 0;
            this.wizardPage1.Text = "1. 引血";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.textBox1.Location = new System.Drawing.Point(0, 173);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(482, 49);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "    ① <开始> 前，请在 <流量设置> 界面确认各泵的速度;\r\n    ② 引血时，请快速注入肝素 , 点 <抗凝剂泵> 进入设置;\r\n    ③ 可用设备" +
    "RP泵右上侧的 <血泵速度旋钮> 控制引血速度；";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label24.Location = new System.Drawing.Point(86, 45);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(127, 21);
            this.label24.TabIndex = 11;
            this.label24.Text = "血泵BP当前速度:";
            // 
            // lblTargetSpeed
            // 
            this.lblTargetSpeed.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblTargetSpeed.Location = new System.Drawing.Point(218, 76);
            this.lblTargetSpeed.Name = "lblTargetSpeed";
            this.lblTargetSpeed.Size = new System.Drawing.Size(74, 37);
            this.lblTargetSpeed.TabIndex = 7;
            this.lblTargetSpeed.Text = "30.0";
            this.lblTargetSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(86, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "血泵BP目标速度:";
            // 
            // lblLeadBloodSpeed
            // 
            this.lblLeadBloodSpeed.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblLeadBloodSpeed.Location = new System.Drawing.Point(219, 37);
            this.lblLeadBloodSpeed.Name = "lblLeadBloodSpeed";
            this.lblLeadBloodSpeed.Size = new System.Drawing.Size(74, 37);
            this.lblLeadBloodSpeed.TabIndex = 7;
            this.lblLeadBloodSpeed.Text = "30.0";
            this.lblLeadBloodSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label26.Location = new System.Drawing.Point(299, 45);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 21);
            this.label26.TabIndex = 9;
            this.label26.Text = "mL/min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.Location = new System.Drawing.Point(298, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "mL/min";
            // 
            // wizardPage2
            // 
            this.wizardPage2.AllowCancel = false;
            this.wizardPage2.Controls.Add(this.textBox2);
            this.wizardPage2.Controls.Add(this.btnPauseCHDF);
            this.wizardPage2.Controls.Add(this.btnStartCHDF);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.ShowCancel = false;
            this.wizardPage2.Size = new System.Drawing.Size(482, 222);
            this.wizardPage2.TabIndex = 1;
            this.wizardPage2.Text = "2. 血滤治疗";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox2.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox2.ForeColor = System.Drawing.Color.OrangeRed;
            this.textBox2.Location = new System.Drawing.Point(0, 190);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(482, 32);
            this.textBox2.TabIndex = 126;
            this.textBox2.Text = "    ① 在 <启动治疗> 前，请确认各泵的速度；\r\n    ② 可点击 <脱水速度> 的速度值进行修改速度大小；";
            // 
            // btnPauseCHDF
            // 
            this.btnPauseCHDF.ButtonColorBottom = System.Drawing.Color.DarkGoldenrod;
            this.btnPauseCHDF.ButtonColorTop = System.Drawing.Color.Orange;
            this.btnPauseCHDF.CornerRadius = 25;
            this.btnPauseCHDF.Enabled = false;
            this.btnPauseCHDF.FocusColor = System.Drawing.Color.Black;
            this.btnPauseCHDF.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPauseCHDF.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPauseCHDF.Location = new System.Drawing.Point(252, 57);
            this.btnPauseCHDF.Name = "btnPauseCHDF";
            this.btnPauseCHDF.NumberOfPulses = 2;
            this.btnPauseCHDF.PulseColor = System.Drawing.Color.DimGray;
            this.btnPauseCHDF.PulseSpeed = 0.3F;
            this.btnPauseCHDF.PulseWidth = 6;
            this.btnPauseCHDF.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnPauseCHDF.Size = new System.Drawing.Size(112, 62);
            this.btnPauseCHDF.TabIndex = 122;
            this.btnPauseCHDF.Tag = "pauseCHDF";
            this.btnPauseCHDF.Text = "暂停";
            this.btnPauseCHDF.UseVisualStyleBackColor = true;
            this.btnPauseCHDF.ClientSizeChanged += new System.EventHandler(this.btnPauseCHDF_Click);
            // 
            // btnStartCHDF
            // 
            this.btnStartCHDF.ButtonColorBottom = System.Drawing.Color.DarkGreen;
            this.btnStartCHDF.ButtonColorTop = System.Drawing.Color.LimeGreen;
            this.btnStartCHDF.CornerRadius = 25;
            this.btnStartCHDF.FocusColor = System.Drawing.Color.Black;
            this.btnStartCHDF.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartCHDF.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStartCHDF.Location = new System.Drawing.Point(110, 57);
            this.btnStartCHDF.Name = "btnStartCHDF";
            this.btnStartCHDF.NumberOfPulses = 2;
            this.btnStartCHDF.PulseColor = System.Drawing.Color.DimGray;
            this.btnStartCHDF.PulseSpeed = 0.3F;
            this.btnStartCHDF.PulseWidth = 6;
            this.btnStartCHDF.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStartCHDF.Size = new System.Drawing.Size(112, 62);
            this.btnStartCHDF.TabIndex = 122;
            this.btnStartCHDF.Tag = "startCHDF";
            this.btnStartCHDF.Text = "启动治疗";
            this.btnStartCHDF.UseVisualStyleBackColor = true;
            this.btnStartCHDF.Click += new System.EventHandler(this.btnStartCHDF_Click);
            // 
            // step_CHDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "step_CHDF";
            this.Size = new System.Drawing.Size(597, 315);
            this.Load += new System.EventHandler(this.step_PE_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblTargetSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblLeadBloodSpeed;
        private System.Windows.Forms.Panel panel2;
        public AeroWizard.StepWizardControl wizardControl1;
        public AeroWizard.WizardPage wizardPage1;
        public AeroWizard.WizardPage wizardPage2;
        public PulseButton.PulseButton btnPauseCHDF;
        public PulseButton.PulseButton btnStartCHDF;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;




    }
}
