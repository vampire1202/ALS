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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.wizardControl1 = new AeroWizard.StepWizardControl();
            this.wizardPage1 = new AeroWizard.WizardPage();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.label24 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBPSpeed = new System.Windows.Forms.Label();
            this.lblLeadBloodSpeed = new System.Windows.Forms.Label();
            this.wizardPage2 = new AeroWizard.WizardPage();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.btnPausePE = new CCWin.SkinControl.SkinButton();
            this.btnStartPE = new CCWin.SkinControl.SkinButton();
            this.wizardPage3 = new AeroWizard.WizardPage();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.btnStartShouji = new CCWin.SkinControl.SkinButton();
            this.btnStopShouji = new CCWin.SkinControl.SkinButton();
            this.wizardPage4 = new AeroWizard.WizardPage();
            this.lblPreCircleTime = new System.Windows.Forms.Label();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.btnPreCircle = new CCWin.SkinControl.SkinButton();
            this.btnPauseTreat = new CCWin.SkinControl.SkinButton();
            this.btnStartTreat = new CCWin.SkinControl.SkinButton();
            this.wizardPage5 = new AeroWizard.WizardPage();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.btnStopReady = new CCWin.SkinControl.SkinButton();
            this.btnReadRecycle = new CCWin.SkinControl.SkinButton();
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
            this.wizardControl1.FinishButtonText = "回收";
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextButtonText = "下一步";
            this.wizardControl1.Pages.Add(this.wizardPage1);
            this.wizardControl1.Pages.Add(this.wizardPage2);
            this.wizardControl1.Pages.Add(this.wizardPage3);
            this.wizardControl1.Pages.Add(this.wizardPage4);
            this.wizardControl1.Pages.Add(this.wizardPage5);
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
            this.wizardPage1.Controls.Add(this.skinLabel1);
            this.wizardPage1.Controls.Add(this.label24);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Controls.Add(this.label26);
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.Controls.Add(this.lblBPSpeed);
            this.wizardPage1.Controls.Add(this.lblLeadBloodSpeed);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.NextPage = this.wizardPage2;
            this.wizardPage1.Size = new System.Drawing.Size(482, 222);
            this.wizardPage1.TabIndex = 0;
            this.wizardPage1.Text = "1. 引血";
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.AutoEllipsis = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel1.ForeColor = System.Drawing.Color.OrangeRed;
            this.skinLabel1.Location = new System.Drawing.Point(0, 154);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(482, 68);
            this.skinLabel1.TabIndex = 14;
            this.skinLabel1.Text = "    ① <开始> 前，请在 <流量设置> 界面确认各泵的速度;\r\n    ② 引血时，请快速注入肝素 , 点 <抗凝剂泵> 进入设置;\r\n    ③ 可用设备" +
    "RP泵右上侧的 <血泵速度旋钮> 控制引血速度；";
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
            this.wizardPage2.Controls.Add(this.skinLabel2);
            this.wizardPage2.Controls.Add(this.btnPausePE);
            this.wizardPage2.Controls.Add(this.btnStartPE);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.NextPage = this.wizardPage3;
            this.wizardPage2.ShowCancel = false;
            this.wizardPage2.Size = new System.Drawing.Size(482, 222);
            this.wizardPage2.TabIndex = 1;
            this.wizardPage2.Text = "2. 血浆置换";
            // 
            // skinLabel2
            // 
            this.skinLabel2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel2.AutoEllipsis = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel2.ForeColor = System.Drawing.Color.OrangeRed;
            this.skinLabel2.Location = new System.Drawing.Point(0, 160);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(482, 62);
            this.skinLabel2.TabIndex = 18;
            this.skinLabel2.Text = "    ① 确认 <双腔储液袋> 下方的 <管夹C1>  松开;\r\n    ② 确认<分离泵FP> 和 <透析液泵DP> 的设定速度，可点击泵速显示标签进行修改；" +
    "\r\n    ③ 点 <血浆置换> 开始治疗;";
            // 
            // btnPausePE
            // 
            this.btnPausePE.BackColor = System.Drawing.Color.Transparent;
            this.btnPausePE.BackRectangle = new System.Drawing.Rectangle(20, 20, 20, 20);
            this.btnPausePE.BaseColor = System.Drawing.Color.DarkGoldenrod;
            this.btnPausePE.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnPausePE.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnPausePE.DownBack = null;
            this.btnPausePE.Enabled = false;
            this.btnPausePE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPausePE.ForeColor = System.Drawing.Color.White;
            this.btnPausePE.Location = new System.Drawing.Point(263, 50);
            this.btnPausePE.MouseBack = null;
            this.btnPausePE.Name = "btnPausePE";
            this.btnPausePE.NormlBack = null;
            this.btnPausePE.Radius = 50;
            this.btnPausePE.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnPausePE.Size = new System.Drawing.Size(100, 50);
            this.btnPausePE.TabIndex = 16;
            this.btnPausePE.Tag = "stopZhihuan";
            this.btnPausePE.Text = "暂停置换";
            this.btnPausePE.UseVisualStyleBackColor = false;
            this.btnPausePE.Click += new System.EventHandler(this.btnStopZhihuan_Click);
            // 
            // btnStartPE
            // 
            this.btnStartPE.BackColor = System.Drawing.Color.Transparent;
            this.btnStartPE.BaseColor = System.Drawing.Color.DarkGreen;
            this.btnStartPE.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnStartPE.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStartPE.DownBack = null;
            this.btnStartPE.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartPE.ForeColor = System.Drawing.Color.White;
            this.btnStartPE.Location = new System.Drawing.Point(135, 50);
            this.btnStartPE.MouseBack = null;
            this.btnStartPE.Name = "btnStartPE";
            this.btnStartPE.NormlBack = null;
            this.btnStartPE.Radius = 50;
            this.btnStartPE.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStartPE.Size = new System.Drawing.Size(100, 50);
            this.btnStartPE.TabIndex = 17;
            this.btnStartPE.Tag = "startZhihuan";
            this.btnStartPE.Text = "开始置换";
            this.btnStartPE.UseVisualStyleBackColor = false;
            this.btnStartPE.Click += new System.EventHandler(this.btnStartZhihuan_Click);
            // 
            // wizardPage3
            // 
            this.wizardPage3.AllowCancel = false;
            this.wizardPage3.Controls.Add(this.skinLabel3);
            this.wizardPage3.Controls.Add(this.btnStartShouji);
            this.wizardPage3.Controls.Add(this.btnStopShouji);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.NextPage = this.wizardPage4;
            this.wizardPage3.ShowCancel = false;
            this.wizardPage3.Size = new System.Drawing.Size(482, 222);
            this.wizardPage3.TabIndex = 2;
            this.wizardPage3.Text = "3. 收集血浆";
            // 
            // skinLabel3
            // 
            this.skinLabel3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel3.AutoEllipsis = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.ForeColor = System.Drawing.Color.OrangeRed;
            this.skinLabel3.Location = new System.Drawing.Point(0, 133);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(482, 89);
            this.skinLabel3.TabIndex = 26;
            this.skinLabel3.Text = "    ① 确认 <双腔储液袋> 下方<管夹C1> 闭合；\r\n    ② 点 <开始收集> 将血浆收集至 <双腔储液袋>的外袋 , 请时刻查看 <双腔储液袋> 中" +
    "的外袋腔内液位高度! \r\n    ③ <双腔储液袋> 中的血浆量达到 500-800 mL时，请 <停止收集>,再进行 <下一步> 操作；";
            this.skinLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStartShouji
            // 
            this.btnStartShouji.BackColor = System.Drawing.Color.Transparent;
            this.btnStartShouji.BaseColor = System.Drawing.Color.DarkGreen;
            this.btnStartShouji.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnStartShouji.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStartShouji.DownBack = null;
            this.btnStartShouji.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartShouji.ForeColor = System.Drawing.Color.White;
            this.btnStartShouji.Location = new System.Drawing.Point(135, 50);
            this.btnStartShouji.MouseBack = null;
            this.btnStartShouji.Name = "btnStartShouji";
            this.btnStartShouji.NormlBack = null;
            this.btnStartShouji.Radius = 50;
            this.btnStartShouji.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStartShouji.Size = new System.Drawing.Size(100, 50);
            this.btnStartShouji.TabIndex = 25;
            this.btnStartShouji.Tag = "startShouji";
            this.btnStartShouji.Text = "开始收集";
            this.btnStartShouji.UseVisualStyleBackColor = false;
            this.btnStartShouji.Click += new System.EventHandler(this.btnStartShouji_Click);
            // 
            // btnStopShouji
            // 
            this.btnStopShouji.BackColor = System.Drawing.Color.Transparent;
            this.btnStopShouji.BackRectangle = new System.Drawing.Rectangle(20, 20, 20, 20);
            this.btnStopShouji.BaseColor = System.Drawing.Color.DarkGoldenrod;
            this.btnStopShouji.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnStopShouji.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStopShouji.DownBack = null;
            this.btnStopShouji.Enabled = false;
            this.btnStopShouji.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopShouji.ForeColor = System.Drawing.Color.White;
            this.btnStopShouji.Location = new System.Drawing.Point(263, 50);
            this.btnStopShouji.MouseBack = null;
            this.btnStopShouji.Name = "btnStopShouji";
            this.btnStopShouji.NormlBack = null;
            this.btnStopShouji.Radius = 50;
            this.btnStopShouji.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStopShouji.Size = new System.Drawing.Size(100, 50);
            this.btnStopShouji.TabIndex = 24;
            this.btnStopShouji.Tag = "stopShouji";
            this.btnStopShouji.Text = "停止收集";
            this.btnStopShouji.UseVisualStyleBackColor = false;
            this.btnStopShouji.Click += new System.EventHandler(this.btnStopShouji_Click);
            // 
            // wizardPage4
            // 
            this.wizardPage4.AllowCancel = false;
            this.wizardPage4.Controls.Add(this.lblPreCircleTime);
            this.wizardPage4.Controls.Add(this.skinLabel4);
            this.wizardPage4.Controls.Add(this.btnPreCircle);
            this.wizardPage4.Controls.Add(this.btnPauseTreat);
            this.wizardPage4.Controls.Add(this.btnStartTreat);
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.NextPage = this.wizardPage5;
            this.wizardPage4.ShowCancel = false;
            this.wizardPage4.Size = new System.Drawing.Size(482, 222);
            this.wizardPage4.TabIndex = 3;
            this.wizardPage4.Text = "4. 整体治疗";
            // 
            // lblPreCircleTime
            // 
            this.lblPreCircleTime.AutoSize = true;
            this.lblPreCircleTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPreCircleTime.Location = new System.Drawing.Point(74, 103);
            this.lblPreCircleTime.Name = "lblPreCircleTime";
            this.lblPreCircleTime.Size = new System.Drawing.Size(84, 20);
            this.lblPreCircleTime.TabIndex = 1;
            this.lblPreCircleTime.Text = "倒计时:30秒";
            // 
            // skinLabel4
            // 
            this.skinLabel4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel4.AutoEllipsis = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.ForeColor = System.Drawing.Color.OrangeRed;
            this.skinLabel4.Location = new System.Drawing.Point(0, 173);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(482, 49);
            this.skinLabel4.TabIndex = 30;
            this.skinLabel4.Text = "    ① 确认循环泵CP的速度，点 <预循环> ，运行30秒左右自动停止；\r\n    ② 确认各泵的运行速度，然后点 <启动治疗> ；";
            // 
            // btnPreCircle
            // 
            this.btnPreCircle.BackColor = System.Drawing.Color.Transparent;
            this.btnPreCircle.BaseColor = System.Drawing.Color.Indigo;
            this.btnPreCircle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnPreCircle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnPreCircle.DownBack = null;
            this.btnPreCircle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreCircle.ForeColor = System.Drawing.Color.White;
            this.btnPreCircle.Location = new System.Drawing.Point(68, 50);
            this.btnPreCircle.MouseBack = null;
            this.btnPreCircle.Name = "btnPreCircle";
            this.btnPreCircle.NormlBack = null;
            this.btnPreCircle.Radius = 50;
            this.btnPreCircle.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnPreCircle.Size = new System.Drawing.Size(100, 50);
            this.btnPreCircle.TabIndex = 29;
            this.btnPreCircle.Tag = "preCircle";
            this.btnPreCircle.Text = "预循环";
            this.btnPreCircle.UseVisualStyleBackColor = false;
            this.btnPreCircle.Click += new System.EventHandler(this.btnPreCircle_Click);
            // 
            // btnPauseTreat
            // 
            this.btnPauseTreat.BackColor = System.Drawing.Color.Transparent;
            this.btnPauseTreat.BackRectangle = new System.Drawing.Rectangle(20, 20, 20, 20);
            this.btnPauseTreat.BaseColor = System.Drawing.Color.DarkGoldenrod;
            this.btnPauseTreat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnPauseTreat.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnPauseTreat.DownBack = null;
            this.btnPauseTreat.Enabled = false;
            this.btnPauseTreat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPauseTreat.ForeColor = System.Drawing.Color.White;
            this.btnPauseTreat.Location = new System.Drawing.Point(308, 50);
            this.btnPauseTreat.MouseBack = null;
            this.btnPauseTreat.Name = "btnPauseTreat";
            this.btnPauseTreat.NormlBack = null;
            this.btnPauseTreat.Radius = 50;
            this.btnPauseTreat.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnPauseTreat.Size = new System.Drawing.Size(100, 50);
            this.btnPauseTreat.TabIndex = 27;
            this.btnPauseTreat.Tag = "stopAll";
            this.btnPauseTreat.Text = "暂停治疗";
            this.btnPauseTreat.UseVisualStyleBackColor = false;
            this.btnPauseTreat.Click += new System.EventHandler(this.btnPauseTreat_Click);
            // 
            // btnStartTreat
            // 
            this.btnStartTreat.BackColor = System.Drawing.Color.Transparent;
            this.btnStartTreat.BaseColor = System.Drawing.Color.DarkGreen;
            this.btnStartTreat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnStartTreat.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStartTreat.DownBack = null;
            this.btnStartTreat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartTreat.ForeColor = System.Drawing.Color.White;
            this.btnStartTreat.Location = new System.Drawing.Point(188, 50);
            this.btnStartTreat.MouseBack = null;
            this.btnStartTreat.Name = "btnStartTreat";
            this.btnStartTreat.NormlBack = null;
            this.btnStartTreat.Radius = 50;
            this.btnStartTreat.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStartTreat.Size = new System.Drawing.Size(100, 50);
            this.btnStartTreat.TabIndex = 28;
            this.btnStartTreat.Tag = "startAll";
            this.btnStartTreat.Text = "启动治疗";
            this.btnStartTreat.UseVisualStyleBackColor = false;
            this.btnStartTreat.Click += new System.EventHandler(this.btnStartTreat_Click);
            // 
            // wizardPage5
            // 
            this.wizardPage5.AllowCancel = false;
            this.wizardPage5.Controls.Add(this.skinLabel5);
            this.wizardPage5.Controls.Add(this.btnStopReady);
            this.wizardPage5.Controls.Add(this.btnReadRecycle);
            this.wizardPage5.IsFinishPage = true;
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.ShowCancel = false;
            this.wizardPage5.Size = new System.Drawing.Size(482, 222);
            this.wizardPage5.TabIndex = 4;
            this.wizardPage5.Text = "5. 准备回收";
            // 
            // skinLabel5
            // 
            this.skinLabel5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel5.AutoEllipsis = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.ForeColor = System.Drawing.Color.OrangeRed;
            this.skinLabel5.Location = new System.Drawing.Point(0, 134);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(482, 88);
            this.skinLabel5.TabIndex = 31;
            this.skinLabel5.Text = "    ① 将 <AD2> 放置于 <夹管阀V6>  与 <双腔储液袋> 之间的管路上;\r\n    ② <准备回收> 是将 <滤过泵FP2> 的速度在原速度上增加" +
    "5mL/min,请手动调节 <滤过泵FP2> 的速度；\r\n    ③ 注意 <双腔储液袋> 的液位高度，可手动 <暂停>，也可以等待补液空 <AD2> 报警； " +
    "";
            // 
            // btnStopReady
            // 
            this.btnStopReady.BackColor = System.Drawing.Color.Transparent;
            this.btnStopReady.BackRectangle = new System.Drawing.Rectangle(20, 20, 20, 20);
            this.btnStopReady.BaseColor = System.Drawing.Color.DarkGoldenrod;
            this.btnStopReady.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnStopReady.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStopReady.DownBack = null;
            this.btnStopReady.Enabled = false;
            this.btnStopReady.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopReady.ForeColor = System.Drawing.Color.White;
            this.btnStopReady.Location = new System.Drawing.Point(263, 50);
            this.btnStopReady.MouseBack = null;
            this.btnStopReady.Name = "btnStopReady";
            this.btnStopReady.NormlBack = null;
            this.btnStopReady.Radius = 50;
            this.btnStopReady.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStopReady.Size = new System.Drawing.Size(100, 50);
            this.btnStopReady.TabIndex = 29;
            this.btnStopReady.Tag = "stopReady";
            this.btnStopReady.Text = "暂停";
            this.btnStopReady.UseVisualStyleBackColor = false;
            this.btnStopReady.Click += new System.EventHandler(this.btnStopReady_Click);
            // 
            // btnReadRecycle
            // 
            this.btnReadRecycle.BackColor = System.Drawing.Color.Transparent;
            this.btnReadRecycle.BaseColor = System.Drawing.Color.DarkGreen;
            this.btnReadRecycle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnReadRecycle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnReadRecycle.DownBack = null;
            this.btnReadRecycle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReadRecycle.ForeColor = System.Drawing.Color.White;
            this.btnReadRecycle.Location = new System.Drawing.Point(135, 50);
            this.btnReadRecycle.MouseBack = null;
            this.btnReadRecycle.Name = "btnReadRecycle";
            this.btnReadRecycle.NormlBack = null;
            this.btnReadRecycle.Radius = 50;
            this.btnReadRecycle.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnReadRecycle.Size = new System.Drawing.Size(100, 50);
            this.btnReadRecycle.TabIndex = 30;
            this.btnReadRecycle.Tag = "readyHuishou";
            this.btnReadRecycle.Text = "准备回收";
            this.btnReadRecycle.UseVisualStyleBackColor = false;
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
        public CCWin.SkinControl.SkinButton btnPausePE;
        public CCWin.SkinControl.SkinButton btnStartPE;
        public CCWin.SkinControl.SkinButton btnStopShouji;
        public CCWin.SkinControl.SkinButton btnStartShouji;
        public CCWin.SkinControl.SkinButton btnPreCircle;
        public CCWin.SkinControl.SkinButton btnPauseTreat;
        public CCWin.SkinControl.SkinButton btnStartTreat;
        public CCWin.SkinControl.SkinButton btnStopReady;
        public CCWin.SkinControl.SkinButton btnReadRecycle;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        public System.Windows.Forms.Label lblPreCircleTime;




    }
}
