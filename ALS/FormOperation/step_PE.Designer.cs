namespace ALS.FormOperation
{
    partial class step_PE
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
            this.lblTargetBPSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLeadBloodSpeed = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wizardPage2 = new AeroWizard.WizardPage();
            this.btnPausePE = new PulseButton.PulseButton();
            this.btnStartPE = new PulseButton.PulseButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
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
            this.wizardControl1.Title = "2. 血浆置换";
            this.wizardControl1.Cancelling += new System.ComponentModel.CancelEventHandler(this.wizardControl1_Cancelling);
            this.wizardControl1.Finished += new System.EventHandler(this.wizardControl1_Finished);
            this.wizardControl1.SelectedPageChanged += new System.EventHandler(this.wizardControl1_SelectedPageChanged);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.textBox1);
            this.wizardPage1.Controls.Add(this.label24);
            this.wizardPage1.Controls.Add(this.lblTargetBPSpeed);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Controls.Add(this.lblLeadBloodSpeed);
            this.wizardPage1.Controls.Add(this.label26);
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.NextPage = this.wizardPage2;
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
            this.textBox1.Location = new System.Drawing.Point(0, 176);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(482, 46);
            this.textBox1.TabIndex = 126;
            this.textBox1.Text = "    ① <开始> 前，请在 <流量设置> 界面确认各泵的速度;\r\n    ② 引血时，请快速注入肝素 , 点 <抗凝剂泵> 进入设置;\r\n    ③ 可用设备" +
    "RP泵右上侧的 <血泵速度旋钮> 控制引血速度；";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label24.Location = new System.Drawing.Point(87, 50);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(127, 21);
            this.label24.TabIndex = 11;
            this.label24.Text = "血泵BP当前速度:";
            // 
            // lblTargetBPSpeed
            // 
            this.lblTargetBPSpeed.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblTargetBPSpeed.Location = new System.Drawing.Point(220, 83);
            this.lblTargetBPSpeed.Name = "lblTargetBPSpeed";
            this.lblTargetBPSpeed.Size = new System.Drawing.Size(74, 37);
            this.lblTargetBPSpeed.TabIndex = 7;
            this.lblTargetBPSpeed.Text = "30.0";
            this.lblTargetBPSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(87, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "血泵BP目标速度:";
            // 
            // lblLeadBloodSpeed
            // 
            this.lblLeadBloodSpeed.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblLeadBloodSpeed.Location = new System.Drawing.Point(220, 42);
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
            this.label26.Location = new System.Drawing.Point(300, 50);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 21);
            this.label26.TabIndex = 9;
            this.label26.Text = "mL/min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(300, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "mL/min";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.btnPausePE);
            this.wizardPage2.Controls.Add(this.btnStartPE);
            this.wizardPage2.Controls.Add(this.textBox2);
            this.wizardPage2.IsFinishPage = true;
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.ShowCancel = false;
            this.wizardPage2.Size = new System.Drawing.Size(482, 222);
            this.wizardPage2.TabIndex = 1;
            this.wizardPage2.Text = "2. 血浆置换";
            // 
            // btnPausePE
            // 
            this.btnPausePE.ButtonColorBottom = System.Drawing.Color.DarkGoldenrod;
            this.btnPausePE.ButtonColorTop = System.Drawing.Color.Orange;
            this.btnPausePE.CornerRadius = 25;
            this.btnPausePE.Enabled = false;
            this.btnPausePE.FocusColor = System.Drawing.Color.Black;
            this.btnPausePE.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPausePE.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPausePE.Location = new System.Drawing.Point(265, 55);
            this.btnPausePE.Name = "btnPausePE";
            this.btnPausePE.NumberOfPulses = 2;
            this.btnPausePE.PulseColor = System.Drawing.Color.DimGray;
            this.btnPausePE.PulseSpeed = 0.3F;
            this.btnPausePE.PulseWidth = 6;
            this.btnPausePE.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnPausePE.Size = new System.Drawing.Size(112, 62);
            this.btnPausePE.TabIndex = 128;
            this.btnPausePE.Tag = "pausePE";
            this.btnPausePE.Text = "暂停";
            this.btnPausePE.UseVisualStyleBackColor = true;
            this.btnPausePE.Click += new System.EventHandler(this.btnPausePE_Click);
            // 
            // btnStartPE
            // 
            this.btnStartPE.ButtonColorBottom = System.Drawing.Color.DarkGreen;
            this.btnStartPE.ButtonColorTop = System.Drawing.Color.LimeGreen;
            this.btnStartPE.CornerRadius = 25;
            this.btnStartPE.FocusColor = System.Drawing.Color.Black;
            this.btnStartPE.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartPE.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStartPE.Location = new System.Drawing.Point(118, 55);
            this.btnStartPE.Name = "btnStartPE";
            this.btnStartPE.NumberOfPulses = 2;
            this.btnStartPE.PulseColor = System.Drawing.Color.DimGray;
            this.btnStartPE.PulseSpeed = 0.3F;
            this.btnStartPE.PulseWidth = 6;
            this.btnStartPE.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStartPE.Size = new System.Drawing.Size(112, 62);
            this.btnStartPE.TabIndex = 127;
            this.btnStartPE.Tag = "startPE";
            this.btnStartPE.Text = "启动治疗";
            this.btnStartPE.UseVisualStyleBackColor = true;
            this.btnStartPE.Click += new System.EventHandler(this.btnStartPE_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox2.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox2.ForeColor = System.Drawing.Color.OrangeRed;
            this.textBox2.Location = new System.Drawing.Point(0, 171);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(482, 51);
            this.textBox2.TabIndex = 126;
            this.textBox2.Text = "    ① 在<启动治疗> 前，请确认各泵的速度设定值，可点击 <泵速显示标签> 进行修改泵速；\r\n    ② 点 <启动治疗>；";
            // 
            // step_PE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "step_PE";
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
        private System.Windows.Forms.Label lblTargetBPSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblLeadBloodSpeed;
        private System.Windows.Forms.Panel panel2;
        public AeroWizard.StepWizardControl wizardControl1;
        public AeroWizard.WizardPage wizardPage1;
        public AeroWizard.WizardPage wizardPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        public PulseButton.PulseButton btnPausePE;
        public PulseButton.PulseButton btnStartPE;




    }
}
