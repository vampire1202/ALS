namespace ALS.FormOperation
{
    partial class step_LiAlS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBPSpeed = new System.Windows.Forms.Label();
            this.lblLeadBloodSpeed = new System.Windows.Forms.Label();
            this.wizardPage2 = new AeroWizard.WizardPage();
            this.richLabel1 = new RichLabel.RichLabel();
            this.btnPausePE = new PulseButton.PulseButton();
            this.btnStartPE = new PulseButton.PulseButton();
            this.wizardPage3 = new AeroWizard.WizardPage();
            this.richLabel2 = new RichLabel.RichLabel();
            this.btnStopShouji = new PulseButton.PulseButton();
            this.btnStartShouji = new PulseButton.PulseButton();
            this.wizardPage4 = new AeroWizard.WizardPage();
            this.richLabel3 = new RichLabel.RichLabel();
            this.btnPauseTreat = new PulseButton.PulseButton();
            this.btnStartTreat = new PulseButton.PulseButton();
            this.btnPreCircle = new PulseButton.PulseButton();
            this.lblPreCircleTime = new System.Windows.Forms.Label();
            this.wizardPage5 = new AeroWizard.WizardPage();
            this.richLabel4 = new RichLabel.RichLabel();
            this.btnStopReady = new PulseButton.PulseButton();
            this.btnReadRecycle = new PulseButton.PulseButton();
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
            this.wizardControl1.StepListWidth = 90;
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "5. 准备回收";
            this.wizardControl1.Cancelling += new System.ComponentModel.CancelEventHandler(this.wizardControl1_Cancelling);
            this.wizardControl1.Finished += new System.EventHandler(this.wizardControl1_Finished);
            this.wizardControl1.SelectedPageChanged += new System.EventHandler(this.wizardControl1_SelectedPageChanged);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.RichLabel5);
            this.wizardPage1.Controls.Add(this.label24);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Controls.Add(this.label26);
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.Controls.Add(this.lblBPSpeed);
            this.wizardPage1.Controls.Add(this.lblLeadBloodSpeed);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.NextPage = this.wizardPage2;
            this.wizardPage1.Size = new System.Drawing.Size(491, 222);
            this.wizardPage1.TabIndex = 0;
            this.wizardPage1.Text = "1. 引血";
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
            this.RichLabel5.Size = new System.Drawing.Size(491, 80);
            this.RichLabel5.TabIndex = 130;
            this.RichLabel5.Text = "    ① <开始> 前，请在 <流量设置> 界面确认各泵的速度;\r\n    ② 引血时，请快速注入肝素 , 点 <抗凝剂泵> 进入设置;\r\n    ③ 可用设备" +
    "RP泵右上侧的 <血泵速度旋钮> 控制引血速度；";
            this.RichLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label24.Location = new System.Drawing.Point(91, 45);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(127, 21);
            this.label24.TabIndex = 11;
            this.label24.Text = "血泵BP当前速度:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(91, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "血泵BP目标速度:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label26.Location = new System.Drawing.Point(302, 45);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 21);
            this.label26.TabIndex = 9;
            this.label26.Text = "mL/min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(302, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "mL/min";
            // 
            // lblBPSpeed
            // 
            this.lblBPSpeed.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblBPSpeed.Location = new System.Drawing.Point(223, 78);
            this.lblBPSpeed.Name = "lblBPSpeed";
            this.lblBPSpeed.Size = new System.Drawing.Size(74, 37);
            this.lblBPSpeed.TabIndex = 7;
            this.lblBPSpeed.Text = "30.0";
            this.lblBPSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeadBloodSpeed
            // 
            this.lblLeadBloodSpeed.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblLeadBloodSpeed.Location = new System.Drawing.Point(223, 37);
            this.lblLeadBloodSpeed.Name = "lblLeadBloodSpeed";
            this.lblLeadBloodSpeed.Size = new System.Drawing.Size(74, 37);
            this.lblLeadBloodSpeed.TabIndex = 7;
            this.lblLeadBloodSpeed.Text = "30.0";
            this.lblLeadBloodSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wizardPage2
            // 
            this.wizardPage2.AllowCancel = false;
            this.wizardPage2.Controls.Add(this.richLabel1);
            this.wizardPage2.Controls.Add(this.btnPausePE);
            this.wizardPage2.Controls.Add(this.btnStartPE);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.NextPage = this.wizardPage3;
            this.wizardPage2.ShowCancel = false;
            this.wizardPage2.Size = new System.Drawing.Size(491, 222);
            this.wizardPage2.TabIndex = 1;
            this.wizardPage2.Text = "2. 血浆置换";
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
            this.richLabel1.Size = new System.Drawing.Size(491, 80);
            this.richLabel1.TabIndex = 130;
            this.richLabel1.Text = "    ① 确认 <双腔储液袋> 下方的 <管夹C1>  松开;\r\n    ② 确认<分离泵FP> 和 <透析液泵DP> 的设定速度，可点击泵速显示标签进行修改；" +
    "\r\n    ③ 点 <血浆置换> 开始治疗;";
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
            this.btnPausePE.Location = new System.Drawing.Point(265, 55);
            this.btnPausePE.Name = "btnPausePE";
            this.btnPausePE.NumberOfPulses = 2;
            this.btnPausePE.PulseColor = System.Drawing.Color.DimGray;
            this.btnPausePE.PulseSpeed = 0.3F;
            this.btnPausePE.PulseWidth = 6;
            this.btnPausePE.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnPausePE.Size = new System.Drawing.Size(112, 62);
            this.btnPausePE.TabIndex = 128;
            this.btnPausePE.Tag = "stopZhihuan";
            this.btnPausePE.Text = "暂停置换";
            this.btnPausePE.UseVisualStyleBackColor = true;
            this.btnPausePE.Click += new System.EventHandler(this.btnStopZhihuan_Click);
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
            this.btnStartPE.Tag = "startZhihuan";
            this.btnStartPE.Text = "开始置换";
            this.btnStartPE.UseVisualStyleBackColor = true;
            this.btnStartPE.Click += new System.EventHandler(this.btnStartZhihuan_Click);
            // 
            // wizardPage3
            // 
            this.wizardPage3.AllowCancel = false;
            this.wizardPage3.Controls.Add(this.richLabel2);
            this.wizardPage3.Controls.Add(this.btnStopShouji);
            this.wizardPage3.Controls.Add(this.btnStartShouji);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.NextPage = this.wizardPage4;
            this.wizardPage3.ShowCancel = false;
            this.wizardPage3.Size = new System.Drawing.Size(491, 222);
            this.wizardPage3.TabIndex = 2;
            this.wizardPage3.Text = "3. 收集血浆";
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
            this.richLabel2.Size = new System.Drawing.Size(491, 80);
            this.richLabel2.TabIndex = 130;
            this.richLabel2.Text = "    ① 确认 <双腔储液袋> 下方<管夹C1> 闭合；\r\n    ② 点 <开始收集> 将血浆收集至 <双腔储液袋>的外袋 , 请时刻查看 <双腔储液袋> 中" +
    "的外袋腔内液位高度! \r\n    ③ <双腔储液袋> 中的血浆量达到 500-800 mL时，请 <停止收集>,再进行 <下一步> 操作；";
            this.richLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStopShouji
            // 
            this.btnStopShouji.ButtonColorBottom = System.Drawing.Color.DarkGoldenrod;
            this.btnStopShouji.ButtonColorTop = System.Drawing.Color.Orange;
            this.btnStopShouji.CornerRadius = 25;
            this.btnStopShouji.Enabled = false;
            this.btnStopShouji.FocusColor = System.Drawing.Color.Black;
            this.btnStopShouji.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopShouji.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStopShouji.Location = new System.Drawing.Point(265, 55);
            this.btnStopShouji.Name = "btnStopShouji";
            this.btnStopShouji.NumberOfPulses = 2;
            this.btnStopShouji.PulseColor = System.Drawing.Color.DimGray;
            this.btnStopShouji.PulseSpeed = 0.3F;
            this.btnStopShouji.PulseWidth = 6;
            this.btnStopShouji.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStopShouji.Size = new System.Drawing.Size(112, 62);
            this.btnStopShouji.TabIndex = 128;
            this.btnStopShouji.Tag = "stopShouji";
            this.btnStopShouji.Text = "暂停收集";
            this.btnStopShouji.UseVisualStyleBackColor = true;
            this.btnStopShouji.Click += new System.EventHandler(this.btnStopShouji_Click);
            // 
            // btnStartShouji
            // 
            this.btnStartShouji.ButtonColorBottom = System.Drawing.Color.DarkGreen;
            this.btnStartShouji.ButtonColorTop = System.Drawing.Color.LimeGreen;
            this.btnStartShouji.CornerRadius = 25;
            this.btnStartShouji.FocusColor = System.Drawing.Color.Black;
            this.btnStartShouji.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartShouji.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStartShouji.Location = new System.Drawing.Point(118, 55);
            this.btnStartShouji.Name = "btnStartShouji";
            this.btnStartShouji.NumberOfPulses = 2;
            this.btnStartShouji.PulseColor = System.Drawing.Color.DimGray;
            this.btnStartShouji.PulseSpeed = 0.3F;
            this.btnStartShouji.PulseWidth = 6;
            this.btnStartShouji.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStartShouji.Size = new System.Drawing.Size(112, 62);
            this.btnStartShouji.TabIndex = 127;
            this.btnStartShouji.Tag = "startShouji";
            this.btnStartShouji.Text = "开始收集";
            this.btnStartShouji.UseVisualStyleBackColor = true;
            this.btnStartShouji.Click += new System.EventHandler(this.btnStartShouji_Click);
            // 
            // wizardPage4
            // 
            this.wizardPage4.AllowCancel = false;
            this.wizardPage4.Controls.Add(this.richLabel3);
            this.wizardPage4.Controls.Add(this.btnPauseTreat);
            this.wizardPage4.Controls.Add(this.btnStartTreat);
            this.wizardPage4.Controls.Add(this.btnPreCircle);
            this.wizardPage4.Controls.Add(this.lblPreCircleTime);
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.NextPage = this.wizardPage5;
            this.wizardPage4.ShowCancel = false;
            this.wizardPage4.Size = new System.Drawing.Size(491, 222);
            this.wizardPage4.TabIndex = 3;
            this.wizardPage4.Text = "4. 整体治疗";
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
            this.richLabel3.Size = new System.Drawing.Size(491, 80);
            this.richLabel3.TabIndex = 130;
            this.richLabel3.Text = "    ① 确认循环泵CP的速度，点 <预循环> ，运行30秒左右自动停止；\r\n    ② 确认各泵的运行速度，然后点 <启动治疗> ；";
            this.richLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPauseTreat
            // 
            this.btnPauseTreat.ButtonColorBottom = System.Drawing.Color.DarkGoldenrod;
            this.btnPauseTreat.ButtonColorTop = System.Drawing.Color.Orange;
            this.btnPauseTreat.CornerRadius = 25;
            this.btnPauseTreat.Enabled = false;
            this.btnPauseTreat.FocusColor = System.Drawing.Color.Black;
            this.btnPauseTreat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPauseTreat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPauseTreat.Location = new System.Drawing.Point(325, 55);
            this.btnPauseTreat.Name = "btnPauseTreat";
            this.btnPauseTreat.NumberOfPulses = 2;
            this.btnPauseTreat.PulseColor = System.Drawing.Color.DimGray;
            this.btnPauseTreat.PulseSpeed = 0.3F;
            this.btnPauseTreat.PulseWidth = 6;
            this.btnPauseTreat.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnPauseTreat.Size = new System.Drawing.Size(112, 62);
            this.btnPauseTreat.TabIndex = 129;
            this.btnPauseTreat.Tag = "stopAll";
            this.btnPauseTreat.Text = "暂停治疗";
            this.btnPauseTreat.UseVisualStyleBackColor = true;
            this.btnPauseTreat.Click += new System.EventHandler(this.btnPauseTreat_Click);
            // 
            // btnStartTreat
            // 
            this.btnStartTreat.ButtonColorBottom = System.Drawing.Color.DarkGreen;
            this.btnStartTreat.ButtonColorTop = System.Drawing.Color.LimeGreen;
            this.btnStartTreat.CornerRadius = 25;
            this.btnStartTreat.FocusColor = System.Drawing.Color.Black;
            this.btnStartTreat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartTreat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStartTreat.Location = new System.Drawing.Point(200, 55);
            this.btnStartTreat.Name = "btnStartTreat";
            this.btnStartTreat.NumberOfPulses = 2;
            this.btnStartTreat.PulseColor = System.Drawing.Color.DimGray;
            this.btnStartTreat.PulseSpeed = 0.3F;
            this.btnStartTreat.PulseWidth = 6;
            this.btnStartTreat.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStartTreat.Size = new System.Drawing.Size(112, 62);
            this.btnStartTreat.TabIndex = 128;
            this.btnStartTreat.Tag = "startAll";
            this.btnStartTreat.Text = "启动治疗";
            this.btnStartTreat.UseVisualStyleBackColor = true;
            this.btnStartTreat.Click += new System.EventHandler(this.btnStartTreat_Click);
            // 
            // btnPreCircle
            // 
            this.btnPreCircle.ButtonColorBottom = System.Drawing.Color.Indigo;
            this.btnPreCircle.ButtonColorTop = System.Drawing.Color.DarkOrchid;
            this.btnPreCircle.CornerRadius = 25;
            this.btnPreCircle.FocusColor = System.Drawing.Color.Black;
            this.btnPreCircle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreCircle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPreCircle.Location = new System.Drawing.Point(75, 55);
            this.btnPreCircle.Name = "btnPreCircle";
            this.btnPreCircle.NumberOfPulses = 2;
            this.btnPreCircle.PulseColor = System.Drawing.Color.DimGray;
            this.btnPreCircle.PulseSpeed = 0.3F;
            this.btnPreCircle.PulseWidth = 6;
            this.btnPreCircle.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnPreCircle.Size = new System.Drawing.Size(112, 62);
            this.btnPreCircle.TabIndex = 127;
            this.btnPreCircle.Tag = "preCircle";
            this.btnPreCircle.Text = "预循环";
            this.btnPreCircle.UseVisualStyleBackColor = true;
            this.btnPreCircle.Click += new System.EventHandler(this.btnPreCircle_Click);
            // 
            // lblPreCircleTime
            // 
            this.lblPreCircleTime.AutoSize = true;
            this.lblPreCircleTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPreCircleTime.Location = new System.Drawing.Point(90, 120);
            this.lblPreCircleTime.Name = "lblPreCircleTime";
            this.lblPreCircleTime.Size = new System.Drawing.Size(84, 20);
            this.lblPreCircleTime.TabIndex = 1;
            this.lblPreCircleTime.Text = "倒计时:30秒";
            // 
            // wizardPage5
            // 
            this.wizardPage5.AllowCancel = false;
            this.wizardPage5.Controls.Add(this.richLabel4);
            this.wizardPage5.Controls.Add(this.btnStopReady);
            this.wizardPage5.Controls.Add(this.btnReadRecycle);
            this.wizardPage5.IsFinishPage = true;
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.ShowCancel = false;
            this.wizardPage5.Size = new System.Drawing.Size(491, 222);
            this.wizardPage5.TabIndex = 4;
            this.wizardPage5.Text = "5. 准备回收";
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
            this.richLabel4.Size = new System.Drawing.Size(491, 80);
            this.richLabel4.TabIndex = 130;
            this.richLabel4.Text = "    ① 将 <AD2> 放置于 <夹管阀V6>  与 <双腔储液袋> 之间的管路上;\r\n    ② <准备回收> 是将 <滤过泵FP2> 的速度在原速度上增加" +
    "5mL/min,请手动调节 <滤过泵FP2> 的速度；\r\n    ③ 注意 <双腔储液袋> 的液位高度，可手动 <暂停>，也可以等待补液空 <AD2> 报警； " +
    "";
            this.richLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStopReady
            // 
            this.btnStopReady.ButtonColorBottom = System.Drawing.Color.DarkGoldenrod;
            this.btnStopReady.ButtonColorTop = System.Drawing.Color.Orange;
            this.btnStopReady.CornerRadius = 25;
            this.btnStopReady.Enabled = false;
            this.btnStopReady.FocusColor = System.Drawing.Color.Black;
            this.btnStopReady.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopReady.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStopReady.Location = new System.Drawing.Point(265, 55);
            this.btnStopReady.Name = "btnStopReady";
            this.btnStopReady.NumberOfPulses = 2;
            this.btnStopReady.PulseColor = System.Drawing.Color.DimGray;
            this.btnStopReady.PulseSpeed = 0.3F;
            this.btnStopReady.PulseWidth = 6;
            this.btnStopReady.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStopReady.Size = new System.Drawing.Size(112, 62);
            this.btnStopReady.TabIndex = 128;
            this.btnStopReady.Tag = "stopReady";
            this.btnStopReady.Text = "暂停";
            this.btnStopReady.UseVisualStyleBackColor = true;
            this.btnStopReady.Click += new System.EventHandler(this.btnStopReady_Click);
            // 
            // btnReadRecycle
            // 
            this.btnReadRecycle.ButtonColorBottom = System.Drawing.Color.DarkGreen;
            this.btnReadRecycle.ButtonColorTop = System.Drawing.Color.LimeGreen;
            this.btnReadRecycle.CornerRadius = 25;
            this.btnReadRecycle.FocusColor = System.Drawing.Color.Black;
            this.btnReadRecycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadRecycle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReadRecycle.Location = new System.Drawing.Point(118, 55);
            this.btnReadRecycle.Name = "btnReadRecycle";
            this.btnReadRecycle.NumberOfPulses = 2;
            this.btnReadRecycle.PulseColor = System.Drawing.Color.DimGray;
            this.btnReadRecycle.PulseSpeed = 0.3F;
            this.btnReadRecycle.PulseWidth = 6;
            this.btnReadRecycle.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnReadRecycle.Size = new System.Drawing.Size(112, 62);
            this.btnReadRecycle.TabIndex = 127;
            this.btnReadRecycle.Tag = "readyHuishou";
            this.btnReadRecycle.Text = "准备回收";
            this.btnReadRecycle.UseVisualStyleBackColor = true;
            this.btnReadRecycle.Click += new System.EventHandler(this.btnReadRecycle_Click);
            // 
            // step_LiAlS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "step_LiAlS";
            this.Size = new System.Drawing.Size(597, 315);
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
        private System.Windows.Forms.Label lblBPSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblLeadBloodSpeed;
        private System.Windows.Forms.Panel panel2;
        public AeroWizard.StepWizardControl wizardControl1;
        public AeroWizard.WizardPage wizardPage1;
        public AeroWizard.WizardPage wizardPage2;
        public AeroWizard.WizardPage wizardPage3;
        public AeroWizard.WizardPage wizardPage4;
        public AeroWizard.WizardPage wizardPage5;
        public System.Windows.Forms.Label lblPreCircleTime;
        public PulseButton.PulseButton btnStartPE;
        public PulseButton.PulseButton btnPausePE;
        public PulseButton.PulseButton btnStartShouji;
        public PulseButton.PulseButton btnStopShouji;
        public PulseButton.PulseButton btnPreCircle;
        public PulseButton.PulseButton btnStartTreat;
        public PulseButton.PulseButton btnPauseTreat;
        public PulseButton.PulseButton btnReadRecycle;
        public PulseButton.PulseButton btnStopReady;
        internal RichLabel.RichLabel RichLabel5;
        internal RichLabel.RichLabel richLabel1;
        internal RichLabel.RichLabel richLabel2;
        internal RichLabel.RichLabel richLabel3;
        internal RichLabel.RichLabel richLabel4;




    }
}
