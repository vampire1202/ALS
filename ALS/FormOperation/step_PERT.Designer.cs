namespace ALS.FormOperation
{
    partial class step_PERT
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
            this.wizardPage3 = new AeroWizard.WizardPage();
            this.btnStopRecycle = new PulseButton.PulseButton();
            this.btnStartRecycle = new PulseButton.PulseButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.wizardPage4 = new AeroWizard.WizardPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblXuelvBpTarget = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblXuelvLeadBpSpeed = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.wizardPage5 = new AeroWizard.WizardPage();
            this.btnPauseCHDF = new PulseButton.PulseButton();
            this.btnStartCHDF = new PulseButton.PulseButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardPage1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            this.wizardPage4.SuspendLayout();
            this.wizardPage5.SuspendLayout();
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
            this.wizardControl1.Pages.Add(this.wizardPage3);
            this.wizardControl1.Pages.Add(this.wizardPage4);
            this.wizardControl1.Pages.Add(this.wizardPage5);
            this.wizardControl1.Size = new System.Drawing.Size(597, 315);
            this.wizardControl1.StepListWidth = 110;
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "5. 血滤滤过治疗";
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
            this.wizardPage1.Size = new System.Drawing.Size(462, 222);
            this.wizardPage1.TabIndex = 0;
            this.wizardPage1.Text = "1. 血浆置换引血";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.textBox1.Location = new System.Drawing.Point(0, 162);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(462, 60);
            this.textBox1.TabIndex = 126;
            this.textBox1.Text = "    ① 请保证旋塞三通T1、T2、T3旋转至只连接 <血浆分离器> 的位置；\r\n    ② <开始> 前，请在 <流量设置> 界面确认各泵的速度; \r\n   " +
    " ③ 引血时，请快速注入肝素 , 点 <抗凝剂泵> 进入设置;\r\n    ④ 可用设备RP泵右上侧的 <血泵速度旋钮> 控制引血速度； ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label24.Location = new System.Drawing.Point(87, 45);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(127, 21);
            this.label24.TabIndex = 11;
            this.label24.Text = "血泵BP当前速度:";
            // 
            // lblTargetBPSpeed
            // 
            this.lblTargetBPSpeed.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblTargetBPSpeed.Location = new System.Drawing.Point(220, 76);
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
            this.label1.Location = new System.Drawing.Point(87, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "血泵BP目标速度:";
            // 
            // lblLeadBloodSpeed
            // 
            this.lblLeadBloodSpeed.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblLeadBloodSpeed.Location = new System.Drawing.Point(220, 37);
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
            this.label26.Location = new System.Drawing.Point(300, 45);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 21);
            this.label26.TabIndex = 9;
            this.label26.Text = "mL/min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(300, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "mL/min";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.textBox4);
            this.wizardPage2.Controls.Add(this.btnPausePE);
            this.wizardPage2.Controls.Add(this.btnStartPE);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.NextPage = this.wizardPage3;
            this.wizardPage2.ShowCancel = false;
            this.wizardPage2.Size = new System.Drawing.Size(462, 222);
            this.wizardPage2.TabIndex = 1;
            this.wizardPage2.Text = "2. 血浆置换治疗";
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
            this.btnPausePE.Location = new System.Drawing.Point(260, 55);
            this.btnPausePE.Name = "btnPausePE";
            this.btnPausePE.NumberOfPulses = 2;
            this.btnPausePE.PulseColor = System.Drawing.Color.DimGray;
            this.btnPausePE.PulseSpeed = 0.3F;
            this.btnPausePE.PulseWidth = 6;
            this.btnPausePE.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnPausePE.Size = new System.Drawing.Size(112, 62);
            this.btnPausePE.TabIndex = 130;
            this.btnPausePE.Tag = "pausePE";
            this.btnPausePE.Text = "暂停置换";
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
            this.btnStartPE.Location = new System.Drawing.Point(113, 55);
            this.btnStartPE.Name = "btnStartPE";
            this.btnStartPE.NumberOfPulses = 2;
            this.btnStartPE.PulseColor = System.Drawing.Color.DimGray;
            this.btnStartPE.PulseSpeed = 0.3F;
            this.btnStartPE.PulseWidth = 6;
            this.btnStartPE.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStartPE.Size = new System.Drawing.Size(112, 62);
            this.btnStartPE.TabIndex = 129;
            this.btnStartPE.Tag = "startPE";
            this.btnStartPE.Text = "开始置换";
            this.btnStartPE.UseVisualStyleBackColor = true;
            this.btnStartPE.Click += new System.EventHandler(this.btnStartPE_Click);
            // 
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.btnStopRecycle);
            this.wizardPage3.Controls.Add(this.btnStartRecycle);
            this.wizardPage3.Controls.Add(this.textBox2);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.NextPage = this.wizardPage4;
            this.wizardPage3.ShowCancel = false;
            this.wizardPage3.Size = new System.Drawing.Size(462, 222);
            this.wizardPage3.TabIndex = 2;
            this.wizardPage3.Text = "3. 血浆置换回收";
            // 
            // btnStopRecycle
            // 
            this.btnStopRecycle.ButtonColorBottom = System.Drawing.Color.DarkGoldenrod;
            this.btnStopRecycle.ButtonColorTop = System.Drawing.Color.Orange;
            this.btnStopRecycle.CornerRadius = 25;
            this.btnStopRecycle.Enabled = false;
            this.btnStopRecycle.FocusColor = System.Drawing.Color.Black;
            this.btnStopRecycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopRecycle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStopRecycle.Location = new System.Drawing.Point(260, 55);
            this.btnStopRecycle.Name = "btnStopRecycle";
            this.btnStopRecycle.NumberOfPulses = 2;
            this.btnStopRecycle.PulseColor = System.Drawing.Color.DimGray;
            this.btnStopRecycle.PulseSpeed = 0.3F;
            this.btnStopRecycle.PulseWidth = 6;
            this.btnStopRecycle.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStopRecycle.Size = new System.Drawing.Size(112, 62);
            this.btnStopRecycle.TabIndex = 128;
            this.btnStopRecycle.Tag = "stopperecycle";
            this.btnStopRecycle.Text = "停止回收";
            this.btnStopRecycle.UseVisualStyleBackColor = true;
            this.btnStopRecycle.Click += new System.EventHandler(this.btnStopRecycle_Click);
            // 
            // btnStartRecycle
            // 
            this.btnStartRecycle.ButtonColorBottom = System.Drawing.Color.DarkGreen;
            this.btnStartRecycle.ButtonColorTop = System.Drawing.Color.LimeGreen;
            this.btnStartRecycle.CornerRadius = 25;
            this.btnStartRecycle.FocusColor = System.Drawing.Color.Black;
            this.btnStartRecycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartRecycle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStartRecycle.Location = new System.Drawing.Point(113, 55);
            this.btnStartRecycle.Name = "btnStartRecycle";
            this.btnStartRecycle.NumberOfPulses = 2;
            this.btnStartRecycle.PulseColor = System.Drawing.Color.DimGray;
            this.btnStartRecycle.PulseSpeed = 0.3F;
            this.btnStartRecycle.PulseWidth = 6;
            this.btnStartRecycle.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStartRecycle.Size = new System.Drawing.Size(112, 62);
            this.btnStartRecycle.TabIndex = 127;
            this.btnStartRecycle.Tag = "startperecycle";
            this.btnStartRecycle.Text = "开始回收";
            this.btnStartRecycle.UseVisualStyleBackColor = true;
            this.btnStartRecycle.Click += new System.EventHandler(this.btnStartRecycle_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox2.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox2.ForeColor = System.Drawing.Color.OrangeRed;
            this.textBox2.Location = new System.Drawing.Point(0, 147);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(462, 75);
            this.textBox2.TabIndex = 126;
            this.textBox2.Text = "    ① 用<管夹>夹住动脉端，将生理盐水连接至前稀释接口，然后点 <开始回收>;\r\n    ② 可用<血泵旋钮>控制BP的速度，将<血浆分离器>中的血液完全回" +
    "收;\r\n    ③ 结束时，点<停止回收>，然后将 <旋塞三通T1、T2、T3> 旋转至只选择 <血液滤过器> 的位置；";
            // 
            // wizardPage4
            // 
            this.wizardPage4.AllowBack = false;
            this.wizardPage4.Controls.Add(this.textBox3);
            this.wizardPage4.Controls.Add(this.label21);
            this.wizardPage4.Controls.Add(this.lblXuelvBpTarget);
            this.wizardPage4.Controls.Add(this.label20);
            this.wizardPage4.Controls.Add(this.lblXuelvLeadBpSpeed);
            this.wizardPage4.Controls.Add(this.label19);
            this.wizardPage4.Controls.Add(this.label18);
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.NextPage = this.wizardPage5;
            this.wizardPage4.ShowCancel = false;
            this.wizardPage4.Size = new System.Drawing.Size(462, 222);
            this.wizardPage4.TabIndex = 3;
            this.wizardPage4.Text = "4. 血液滤过引血";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox3.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox3.ForeColor = System.Drawing.Color.OrangeRed;
            this.textBox3.Location = new System.Drawing.Point(0, 171);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(462, 51);
            this.textBox3.TabIndex = 126;
            this.textBox3.Text = "    ① 用设备上的 <血泵调速旋钮> 控制血泵BP的引血速度；\r\n";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label21.Location = new System.Drawing.Point(83, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(127, 21);
            this.label21.TabIndex = 38;
            this.label21.Text = "血泵BP当前速度:";
            // 
            // lblXuelvBpTarget
            // 
            this.lblXuelvBpTarget.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblXuelvBpTarget.Location = new System.Drawing.Point(216, 87);
            this.lblXuelvBpTarget.Name = "lblXuelvBpTarget";
            this.lblXuelvBpTarget.Size = new System.Drawing.Size(74, 37);
            this.lblXuelvBpTarget.TabIndex = 33;
            this.lblXuelvBpTarget.Text = "30";
            this.lblXuelvBpTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label20.Location = new System.Drawing.Point(83, 95);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(127, 21);
            this.label20.TabIndex = 37;
            this.label20.Text = "血泵BP目标速度:";
            // 
            // lblXuelvLeadBpSpeed
            // 
            this.lblXuelvLeadBpSpeed.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblXuelvLeadBpSpeed.Location = new System.Drawing.Point(216, 48);
            this.lblXuelvLeadBpSpeed.Name = "lblXuelvLeadBpSpeed";
            this.lblXuelvLeadBpSpeed.Size = new System.Drawing.Size(74, 37);
            this.lblXuelvLeadBpSpeed.TabIndex = 34;
            this.lblXuelvLeadBpSpeed.Text = "0";
            this.lblXuelvLeadBpSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label19.Location = new System.Drawing.Point(296, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 21);
            this.label19.TabIndex = 36;
            this.label19.Text = "mL/min";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label18.Location = new System.Drawing.Point(296, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 21);
            this.label18.TabIndex = 35;
            this.label18.Text = "mL/min";
            // 
            // wizardPage5
            // 
            this.wizardPage5.Controls.Add(this.textBox5);
            this.wizardPage5.Controls.Add(this.btnPauseCHDF);
            this.wizardPage5.Controls.Add(this.btnStartCHDF);
            this.wizardPage5.IsFinishPage = true;
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.ShowCancel = false;
            this.wizardPage5.Size = new System.Drawing.Size(462, 222);
            this.wizardPage5.TabIndex = 4;
            this.wizardPage5.Text = "5. 血滤滤过治疗";
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
            this.btnPauseCHDF.Location = new System.Drawing.Point(260, 55);
            this.btnPauseCHDF.Name = "btnPauseCHDF";
            this.btnPauseCHDF.NumberOfPulses = 2;
            this.btnPauseCHDF.PulseColor = System.Drawing.Color.DimGray;
            this.btnPauseCHDF.PulseSpeed = 0.3F;
            this.btnPauseCHDF.PulseWidth = 6;
            this.btnPauseCHDF.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnPauseCHDF.Size = new System.Drawing.Size(112, 62);
            this.btnPauseCHDF.TabIndex = 126;
            this.btnPauseCHDF.Tag = "pauseCHDF";
            this.btnPauseCHDF.Text = "暂停血滤";
            this.btnPauseCHDF.UseVisualStyleBackColor = true;
            this.btnPauseCHDF.Click += new System.EventHandler(this.btnPauseCHDF_Click);
            // 
            // btnStartCHDF
            // 
            this.btnStartCHDF.ButtonColorBottom = System.Drawing.Color.DarkGreen;
            this.btnStartCHDF.ButtonColorTop = System.Drawing.Color.LimeGreen;
            this.btnStartCHDF.CornerRadius = 25;
            this.btnStartCHDF.FocusColor = System.Drawing.Color.Black;
            this.btnStartCHDF.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartCHDF.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStartCHDF.Location = new System.Drawing.Point(113, 55);
            this.btnStartCHDF.Name = "btnStartCHDF";
            this.btnStartCHDF.NumberOfPulses = 2;
            this.btnStartCHDF.PulseColor = System.Drawing.Color.DimGray;
            this.btnStartCHDF.PulseSpeed = 0.3F;
            this.btnStartCHDF.PulseWidth = 6;
            this.btnStartCHDF.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStartCHDF.Size = new System.Drawing.Size(112, 62);
            this.btnStartCHDF.TabIndex = 125;
            this.btnStartCHDF.Tag = "startCHDF";
            this.btnStartCHDF.Text = "开始血滤";
            this.btnStartCHDF.UseVisualStyleBackColor = true;
            this.btnStartCHDF.Click += new System.EventHandler(this.btnStartCHDF_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox4.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox4.ForeColor = System.Drawing.Color.OrangeRed;
            this.textBox4.Location = new System.Drawing.Point(0, 171);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(462, 51);
            this.textBox4.TabIndex = 131;
            this.textBox4.Text = "    ① 在<开始置换> 前，请确认各泵的速度设定值，可点击 <泵速显示标签> 进行修改泵速；\r\n    ② 点 <开始置换> 进行治疗；";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox5.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox5.ForeColor = System.Drawing.Color.OrangeRed;
            this.textBox5.Location = new System.Drawing.Point(0, 161);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(462, 61);
            this.textBox5.TabIndex = 127;
            this.textBox5.Text = "    ① 若需要脱水平衡，需要点击右侧 <泵秤平衡> 按钮，此时按钮呈选中状态；\r\n    ② 若需要更换液袋，请先点 <泵秤平衡> 取消联动，然后更换液袋，待" +
    "秤平稳后再点<泵秤平衡>；";
            // 
            // step_PERT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "step_PERT";
            this.Size = new System.Drawing.Size(597, 315);
            this.Load += new System.EventHandler(this.step_PE_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage2.PerformLayout();
            this.wizardPage3.ResumeLayout(false);
            this.wizardPage3.PerformLayout();
            this.wizardPage4.ResumeLayout(false);
            this.wizardPage4.PerformLayout();
            this.wizardPage5.ResumeLayout(false);
            this.wizardPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblTargetBPSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblLeadBloodSpeed;
        private System.Windows.Forms.Label lblXuelvBpTarget;
        public System.Windows.Forms.Label lblXuelvLeadBpSpeed;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel2;
        public AeroWizard.WizardPage wizardPage1;
        public AeroWizard.WizardPage wizardPage2;
        public AeroWizard.WizardPage wizardPage3;
        public AeroWizard.WizardPage wizardPage4;
        public AeroWizard.WizardPage wizardPage5;
        public AeroWizard.StepWizardControl wizardControl1;
        private System.Windows.Forms.TextBox textBox1;
        public PulseButton.PulseButton btnPausePE;
        public PulseButton.PulseButton btnStartPE;
        private System.Windows.Forms.TextBox textBox2;
        public PulseButton.PulseButton btnStopRecycle;
        public PulseButton.PulseButton btnStartRecycle;
        private System.Windows.Forms.TextBox textBox3;
        public PulseButton.PulseButton btnPauseCHDF;
        public PulseButton.PulseButton btnStartCHDF;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;




    }
}
