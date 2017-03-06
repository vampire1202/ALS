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
            this.RichLabel5 = new RichLabel.RichLabel();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTargetBPSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLeadBloodSpeed = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wizardPage2 = new AeroWizard.WizardPage();
            this.richLabel1 = new RichLabel.RichLabel();
            this.btnPausePE = new PulseButton.PulseButton();
            this.btnStartPE = new PulseButton.PulseButton();
            this.wizardPage3 = new AeroWizard.WizardPage();
            this.richLabel2 = new RichLabel.RichLabel();
            this.btnStopRecycle = new PulseButton.PulseButton();
            this.btnStartRecycle = new PulseButton.PulseButton();
            this.wizardPage4 = new AeroWizard.WizardPage();
            this.richLabel3 = new RichLabel.RichLabel();
            this.label21 = new System.Windows.Forms.Label();
            this.lblXuelvBpTarget = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblXuelvLeadBpSpeed = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.wizardPage5 = new AeroWizard.WizardPage();
            this.richLabel4 = new RichLabel.RichLabel();
            this.btnPauseCHDF = new PulseButton.PulseButton();
            this.btnStartCHDF = new PulseButton.PulseButton();
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
            this.wizardPage1.Controls.Add(this.RichLabel5);
            this.wizardPage1.Controls.Add(this.label24);
            this.wizardPage1.Controls.Add(this.lblTargetBPSpeed);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Controls.Add(this.lblLeadBloodSpeed);
            this.wizardPage1.Controls.Add(this.label26);
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.NextPage = this.wizardPage2;
            this.wizardPage1.Size = new System.Drawing.Size(471, 222);
            this.wizardPage1.TabIndex = 0;
            this.wizardPage1.Text = "1. 血浆置换引血";
            // 
            // RichLabel5
            // 
            this.RichLabel5.BackColor = System.Drawing.Color.White;
            this.RichLabel5.BackColor2 = System.Drawing.Color.PowderBlue;
            this.RichLabel5.BorderBottom = System.Drawing.Color.Transparent;
            this.RichLabel5.BorderLeft = System.Drawing.Color.Transparent;
            this.RichLabel5.BorderRight = System.Drawing.Color.Transparent;
            this.RichLabel5.BorderTop = System.Drawing.Color.Transparent;
            this.RichLabel5.Cursor = System.Windows.Forms.Cursors.Default;
            this.RichLabel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RichLabel5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.RichLabel5.ForeColor = System.Drawing.Color.OrangeRed;
            this.RichLabel5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.RichLabel5.GradientModeHover = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.RichLabel5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.RichLabel5.Location = new System.Drawing.Point(0, 142);
            this.RichLabel5.Name = "RichLabel5";
            this.RichLabel5.Size = new System.Drawing.Size(471, 80);
            this.RichLabel5.TabIndex = 130;
            this.RichLabel5.Text = "    ① 请保证旋塞三通T1、T2、T3旋转至只连接 <血浆分离器> 的位置；\r\n    ② <开始> 前，请在 <流量设置> 界面确认各泵的速度; \r\n   " +
    " ③ 引血时，请快速注入肝素 , 点 <抗凝剂泵> 进入设置;\r\n    ④ 可用设备RP泵右上侧的 <血泵速度旋钮> 控制引血速度； ";
            this.RichLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.wizardPage2.Controls.Add(this.richLabel1);
            this.wizardPage2.Controls.Add(this.btnPausePE);
            this.wizardPage2.Controls.Add(this.btnStartPE);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.NextPage = this.wizardPage3;
            this.wizardPage2.ShowCancel = false;
            this.wizardPage2.Size = new System.Drawing.Size(471, 222);
            this.wizardPage2.TabIndex = 1;
            this.wizardPage2.Text = "2. 血浆置换治疗";
            // 
            // richLabel1
            // 
            this.richLabel1.BackColor = System.Drawing.Color.White;
            this.richLabel1.BackColor2 = System.Drawing.Color.PowderBlue;
            this.richLabel1.BorderBottom = System.Drawing.Color.Transparent;
            this.richLabel1.BorderLeft = System.Drawing.Color.Transparent;
            this.richLabel1.BorderRight = System.Drawing.Color.Transparent;
            this.richLabel1.BorderTop = System.Drawing.Color.Transparent;
            this.richLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richLabel1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.richLabel1.ForeColor = System.Drawing.Color.OrangeRed;
            this.richLabel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.richLabel1.GradientModeHover = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.richLabel1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.richLabel1.Location = new System.Drawing.Point(0, 142);
            this.richLabel1.Name = "richLabel1";
            this.richLabel1.Size = new System.Drawing.Size(471, 80);
            this.richLabel1.TabIndex = 132;
            this.richLabel1.Text = "    ① 在 <开始置换> 前，请确认各泵的速度设定值，可点击 <泵速显示标签> 进行修改泵速；\r\n    ② 点 <开始置换> 进行治疗；";
            this.richLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.wizardPage3.Controls.Add(this.richLabel2);
            this.wizardPage3.Controls.Add(this.btnStopRecycle);
            this.wizardPage3.Controls.Add(this.btnStartRecycle);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.NextPage = this.wizardPage4;
            this.wizardPage3.ShowCancel = false;
            this.wizardPage3.Size = new System.Drawing.Size(471, 222);
            this.wizardPage3.TabIndex = 2;
            this.wizardPage3.Text = "3. 血浆置换回收";
            // 
            // richLabel2
            // 
            this.richLabel2.BackColor = System.Drawing.Color.White;
            this.richLabel2.BackColor2 = System.Drawing.Color.PowderBlue;
            this.richLabel2.BorderBottom = System.Drawing.Color.Transparent;
            this.richLabel2.BorderLeft = System.Drawing.Color.Transparent;
            this.richLabel2.BorderRight = System.Drawing.Color.Transparent;
            this.richLabel2.BorderTop = System.Drawing.Color.Transparent;
            this.richLabel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.richLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richLabel2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.richLabel2.ForeColor = System.Drawing.Color.OrangeRed;
            this.richLabel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.richLabel2.GradientModeHover = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.richLabel2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.richLabel2.Location = new System.Drawing.Point(0, 142);
            this.richLabel2.Name = "richLabel2";
            this.richLabel2.Size = new System.Drawing.Size(471, 80);
            this.richLabel2.TabIndex = 131;
            this.richLabel2.Text = "    ① 用<管夹>夹住动脉端，将生理盐水连接至前稀释接口，然后点 <开始回收>;\r\n    ② 可用<血泵旋钮>控制BP的速度，将<血浆分离器>中的血液完全回" +
    "收;\r\n    ③ 结束时，点<停止回收>，然后将 <旋塞三通T1、T2、T3> 旋转至只选择 <血液滤过器> 的位置；";
            this.richLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // wizardPage4
            // 
            this.wizardPage4.AllowBack = false;
            this.wizardPage4.Controls.Add(this.richLabel3);
            this.wizardPage4.Controls.Add(this.label21);
            this.wizardPage4.Controls.Add(this.lblXuelvBpTarget);
            this.wizardPage4.Controls.Add(this.label20);
            this.wizardPage4.Controls.Add(this.lblXuelvLeadBpSpeed);
            this.wizardPage4.Controls.Add(this.label19);
            this.wizardPage4.Controls.Add(this.label18);
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.NextPage = this.wizardPage5;
            this.wizardPage4.ShowCancel = false;
            this.wizardPage4.Size = new System.Drawing.Size(471, 222);
            this.wizardPage4.TabIndex = 3;
            this.wizardPage4.Text = "4. 血液滤过引血";
            // 
            // richLabel3
            // 
            this.richLabel3.BackColor = System.Drawing.Color.White;
            this.richLabel3.BackColor2 = System.Drawing.Color.PowderBlue;
            this.richLabel3.BorderBottom = System.Drawing.Color.Transparent;
            this.richLabel3.BorderLeft = System.Drawing.Color.Transparent;
            this.richLabel3.BorderRight = System.Drawing.Color.Transparent;
            this.richLabel3.BorderTop = System.Drawing.Color.Transparent;
            this.richLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.richLabel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richLabel3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.richLabel3.ForeColor = System.Drawing.Color.OrangeRed;
            this.richLabel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.richLabel3.GradientModeHover = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.richLabel3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.richLabel3.Location = new System.Drawing.Point(0, 142);
            this.richLabel3.Name = "richLabel3";
            this.richLabel3.Size = new System.Drawing.Size(471, 80);
            this.richLabel3.TabIndex = 131;
            this.richLabel3.Text = "    ① 用设备上的 <血泵调速旋钮> 控制血泵BP的引血速度；";
            this.richLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.wizardPage5.Controls.Add(this.richLabel4);
            this.wizardPage5.Controls.Add(this.btnPauseCHDF);
            this.wizardPage5.Controls.Add(this.btnStartCHDF);
            this.wizardPage5.IsFinishPage = true;
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.ShowCancel = false;
            this.wizardPage5.Size = new System.Drawing.Size(471, 222);
            this.wizardPage5.TabIndex = 4;
            this.wizardPage5.Text = "5. 血滤滤过治疗";
            // 
            // richLabel4
            // 
            this.richLabel4.BackColor = System.Drawing.Color.White;
            this.richLabel4.BackColor2 = System.Drawing.Color.PowderBlue;
            this.richLabel4.BorderBottom = System.Drawing.Color.Transparent;
            this.richLabel4.BorderLeft = System.Drawing.Color.Transparent;
            this.richLabel4.BorderRight = System.Drawing.Color.Transparent;
            this.richLabel4.BorderTop = System.Drawing.Color.Transparent;
            this.richLabel4.Cursor = System.Windows.Forms.Cursors.Default;
            this.richLabel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richLabel4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.richLabel4.ForeColor = System.Drawing.Color.OrangeRed;
            this.richLabel4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.richLabel4.GradientModeHover = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.richLabel4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.richLabel4.Location = new System.Drawing.Point(0, 142);
            this.richLabel4.Name = "richLabel4";
            this.richLabel4.Size = new System.Drawing.Size(471, 80);
            this.richLabel4.TabIndex = 131;
            this.richLabel4.Text = "    ① 若需要脱水平衡，需要点击 <泵秤平衡> 按钮，此时按钮呈选中状态；\r\n    ② 若需要更换液袋，请先点 <泵秤平衡> 取消联动，然后更换液袋，待秤平" +
    "稳后再点<泵秤平衡>；";
            this.richLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.wizardPage3.ResumeLayout(false);
            this.wizardPage4.ResumeLayout(false);
            this.wizardPage4.PerformLayout();
            this.wizardPage5.ResumeLayout(false);
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
        public PulseButton.PulseButton btnPausePE;
        public PulseButton.PulseButton btnStartPE;
        public PulseButton.PulseButton btnStopRecycle;
        public PulseButton.PulseButton btnStartRecycle;
        public PulseButton.PulseButton btnPauseCHDF;
        public PulseButton.PulseButton btnStartCHDF;
        internal RichLabel.RichLabel RichLabel5;
        internal RichLabel.RichLabel richLabel1;
        internal RichLabel.RichLabel richLabel2;
        internal RichLabel.RichLabel richLabel3;
        internal RichLabel.RichLabel richLabel4;




    }
}
