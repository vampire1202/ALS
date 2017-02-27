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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.wizardControl1 = new AeroWizard.StepWizardControl();
            this.wizardPage1 = new AeroWizard.WizardPage();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTargetBPSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLeadBloodSpeed = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wizardPage2 = new AeroWizard.WizardPage();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.btnPausePE = new CCWin.SkinControl.SkinButton();
            this.btnStartPE = new CCWin.SkinControl.SkinButton();
            this.wizardPage3 = new AeroWizard.WizardPage();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.btnStopRecycle = new CCWin.SkinControl.SkinButton();
            this.btnStartRecycle = new CCWin.SkinControl.SkinButton();
            this.wizardPage4 = new AeroWizard.WizardPage();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.label21 = new System.Windows.Forms.Label();
            this.lblXuelvBpTarget = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblXuelvLeadBpSpeed = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.wizardPage5 = new AeroWizard.WizardPage();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.btnPauseCHDF = new CCWin.SkinControl.SkinButton();
            this.btnStartCHDF = new CCWin.SkinControl.SkinButton();
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
            this.wizardControl1.StepListWidth = 110;
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = "2. 血浆置换治疗";
            this.wizardControl1.Cancelling += new System.ComponentModel.CancelEventHandler(this.wizardControl1_Cancelling);
            this.wizardControl1.Finished += new System.EventHandler(this.wizardControl1_Finished);
            this.wizardControl1.SelectedPageChanged += new System.EventHandler(this.wizardControl1_SelectedPageChanged);
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.skinLabel1);
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
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.AutoEllipsis = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel1.ForeColor = System.Drawing.Color.OrangeRed;
            this.skinLabel1.Location = new System.Drawing.Point(0, 150);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(462, 72);
            this.skinLabel1.TabIndex = 34;
            this.skinLabel1.Text = "    ① 请保证旋塞三通T1、T2、T3旋转至只连接 <血浆分离器> 的位置；\r\n    ② <开始> 前，请在 <流量设置> 界面确认各泵的速度; \r\n   " +
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
            this.wizardPage2.Controls.Add(this.skinLabel2);
            this.wizardPage2.Controls.Add(this.btnPausePE);
            this.wizardPage2.Controls.Add(this.btnStartPE);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.NextPage = this.wizardPage3;
            this.wizardPage2.ShowCancel = false;
            this.wizardPage2.Size = new System.Drawing.Size(462, 222);
            this.wizardPage2.TabIndex = 1;
            this.wizardPage2.Text = "2. 血浆置换治疗";
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
            this.skinLabel2.Location = new System.Drawing.Point(0, 155);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(462, 67);
            this.skinLabel2.TabIndex = 23;
            this.skinLabel2.Text = "    ① 在<开始置换> 前，请确认各泵的速度设定值，可点击 <泵速显示标签> 进行修改泵速；\r\n    ② 点 <开始置换> 进行治疗；";
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
            this.btnPausePE.Location = new System.Drawing.Point(260, 51);
            this.btnPausePE.MouseBack = null;
            this.btnPausePE.Name = "btnPausePE";
            this.btnPausePE.NormlBack = null;
            this.btnPausePE.Radius = 50;
            this.btnPausePE.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnPausePE.Size = new System.Drawing.Size(100, 50);
            this.btnPausePE.TabIndex = 21;
            this.btnPausePE.Tag = "pausePE";
            this.btnPausePE.Text = "暂停置换";
            this.btnPausePE.UseVisualStyleBackColor = false;
            this.btnPausePE.Click += new System.EventHandler(this.btnPausePE_Click);
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
            this.btnStartPE.Location = new System.Drawing.Point(118, 51);
            this.btnStartPE.MouseBack = null;
            this.btnStartPE.Name = "btnStartPE";
            this.btnStartPE.NormlBack = null;
            this.btnStartPE.Radius = 50;
            this.btnStartPE.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStartPE.Size = new System.Drawing.Size(100, 50);
            this.btnStartPE.TabIndex = 22;
            this.btnStartPE.Tag = "startPE";
            this.btnStartPE.Text = "开始置换";
            this.btnStartPE.UseVisualStyleBackColor = false;
            this.btnStartPE.Click += new System.EventHandler(this.btnStartPE_Click);
            // 
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.skinLabel3);
            this.wizardPage3.Controls.Add(this.btnStopRecycle);
            this.wizardPage3.Controls.Add(this.btnStartRecycle);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.NextPage = this.wizardPage4;
            this.wizardPage3.ShowCancel = false;
            this.wizardPage3.Size = new System.Drawing.Size(462, 222);
            this.wizardPage3.TabIndex = 2;
            this.wizardPage3.Text = "3. 血浆置换回收";
            // 
            // skinLabel3
            // 
            this.skinLabel3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel3.AutoEllipsis = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel3.ForeColor = System.Drawing.Color.OrangeRed;
            this.skinLabel3.Location = new System.Drawing.Point(0, 136);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(462, 86);
            this.skinLabel3.TabIndex = 25;
            this.skinLabel3.Text = "    ① 用<管夹>夹住动脉端，将生理盐水连接至前稀释接口，然后点 <开始回收>;\r\n    ② 可用<血泵旋钮>控制BP的速度，将<血浆分离器>中的血液完全回" +
    "收;\r\n    ③ 结束时，点<停止回收>，然后将 <旋塞三通T1、T2、T3> 旋转至只选择 <血液滤过器> 的位置；";
            // 
            // btnStopRecycle
            // 
            this.btnStopRecycle.BackColor = System.Drawing.Color.Transparent;
            this.btnStopRecycle.BackRectangle = new System.Drawing.Rectangle(20, 20, 20, 20);
            this.btnStopRecycle.BaseColor = System.Drawing.Color.DarkGoldenrod;
            this.btnStopRecycle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnStopRecycle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStopRecycle.DownBack = null;
            this.btnStopRecycle.Enabled = false;
            this.btnStopRecycle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopRecycle.ForeColor = System.Drawing.Color.White;
            this.btnStopRecycle.Location = new System.Drawing.Point(260, 51);
            this.btnStopRecycle.MouseBack = null;
            this.btnStopRecycle.Name = "btnStopRecycle";
            this.btnStopRecycle.NormlBack = null;
            this.btnStopRecycle.Radius = 50;
            this.btnStopRecycle.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStopRecycle.Size = new System.Drawing.Size(100, 50);
            this.btnStopRecycle.TabIndex = 23;
            this.btnStopRecycle.Tag = "stopperecycle";
            this.btnStopRecycle.Text = "停止回收";
            this.btnStopRecycle.UseVisualStyleBackColor = false;
            this.btnStopRecycle.Click += new System.EventHandler(this.btnStopRecycle_Click);
            // 
            // btnStartRecycle
            // 
            this.btnStartRecycle.BackColor = System.Drawing.Color.Transparent;
            this.btnStartRecycle.BaseColor = System.Drawing.Color.DarkGreen;
            this.btnStartRecycle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnStartRecycle.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStartRecycle.DownBack = null;
            this.btnStartRecycle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartRecycle.ForeColor = System.Drawing.Color.White;
            this.btnStartRecycle.Location = new System.Drawing.Point(118, 51);
            this.btnStartRecycle.MouseBack = null;
            this.btnStartRecycle.Name = "btnStartRecycle";
            this.btnStartRecycle.NormlBack = null;
            this.btnStartRecycle.Radius = 50;
            this.btnStartRecycle.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStartRecycle.Size = new System.Drawing.Size(100, 50);
            this.btnStartRecycle.TabIndex = 24;
            this.btnStartRecycle.Tag = "startperecycle";
            this.btnStartRecycle.Text = "开始回收";
            this.btnStartRecycle.UseVisualStyleBackColor = false;
            this.btnStartRecycle.Click += new System.EventHandler(this.btnStartRecycle_Click);
            // 
            // wizardPage4
            // 
            this.wizardPage4.AllowBack = false;
            this.wizardPage4.Controls.Add(this.skinLabel4);
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
            // skinLabel4
            // 
            this.skinLabel4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel4.AutoEllipsis = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel4.ForeColor = System.Drawing.Color.OrangeRed;
            this.skinLabel4.Location = new System.Drawing.Point(0, 175);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(462, 47);
            this.skinLabel4.TabIndex = 41;
            this.skinLabel4.Text = "    ① 用设备上的 <血泵调速旋钮> 控制血泵BP的引血速度；";
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
            this.wizardPage5.Controls.Add(this.skinLabel5);
            this.wizardPage5.Controls.Add(this.btnPauseCHDF);
            this.wizardPage5.Controls.Add(this.btnStartCHDF);
            this.wizardPage5.IsFinishPage = true;
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.ShowCancel = false;
            this.wizardPage5.Size = new System.Drawing.Size(462, 222);
            this.wizardPage5.TabIndex = 4;
            this.wizardPage5.Text = "5. 血滤滤过治疗";
            // 
            // skinLabel5
            // 
            this.skinLabel5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel5.AutoEllipsis = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel5.ForeColor = System.Drawing.Color.OrangeRed;
            this.skinLabel5.Location = new System.Drawing.Point(0, 159);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(462, 63);
            this.skinLabel5.TabIndex = 42;
            this.skinLabel5.Text = "    ① 若需要脱水平衡，需要点击右侧 <泵秤平衡> 按钮，此时按钮呈选中状态；\r\n    ② 若需要更换液袋，请先点 <泵秤平衡> 取消联动，然后更换液袋，待" +
    "秤平稳后再点<泵秤平衡>；";
            // 
            // btnPauseCHDF
            // 
            this.btnPauseCHDF.BackColor = System.Drawing.Color.Transparent;
            this.btnPauseCHDF.BackRectangle = new System.Drawing.Rectangle(20, 20, 20, 20);
            this.btnPauseCHDF.BaseColor = System.Drawing.Color.DarkGoldenrod;
            this.btnPauseCHDF.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnPauseCHDF.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnPauseCHDF.DownBack = null;
            this.btnPauseCHDF.Enabled = false;
            this.btnPauseCHDF.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPauseCHDF.ForeColor = System.Drawing.Color.White;
            this.btnPauseCHDF.Location = new System.Drawing.Point(260, 51);
            this.btnPauseCHDF.MouseBack = null;
            this.btnPauseCHDF.Name = "btnPauseCHDF";
            this.btnPauseCHDF.NormlBack = null;
            this.btnPauseCHDF.Radius = 50;
            this.btnPauseCHDF.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnPauseCHDF.Size = new System.Drawing.Size(100, 50);
            this.btnPauseCHDF.TabIndex = 30;
            this.btnPauseCHDF.Tag = "pauseCHDF";
            this.btnPauseCHDF.Text = "暂停血滤";
            this.btnPauseCHDF.UseVisualStyleBackColor = false;
            this.btnPauseCHDF.Click += new System.EventHandler(this.btnPauseCHDF_Click);
            // 
            // btnStartCHDF
            // 
            this.btnStartCHDF.BackColor = System.Drawing.Color.Transparent;
            this.btnStartCHDF.BaseColor = System.Drawing.Color.DarkGreen;
            this.btnStartCHDF.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnStartCHDF.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStartCHDF.DownBack = null;
            this.btnStartCHDF.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartCHDF.ForeColor = System.Drawing.Color.White;
            this.btnStartCHDF.Location = new System.Drawing.Point(118, 51);
            this.btnStartCHDF.MouseBack = null;
            this.btnStartCHDF.Name = "btnStartCHDF";
            this.btnStartCHDF.NormlBack = null;
            this.btnStartCHDF.Radius = 50;
            this.btnStartCHDF.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStartCHDF.Size = new System.Drawing.Size(100, 50);
            this.btnStartCHDF.TabIndex = 31;
            this.btnStartCHDF.Tag = "startCHDF";
            this.btnStartCHDF.Text = "开始血滤";
            this.btnStartCHDF.UseVisualStyleBackColor = false;
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
        public CCWin.SkinControl.SkinButton btnPausePE;
        public CCWin.SkinControl.SkinButton btnStartPE;
        public CCWin.SkinControl.SkinButton btnStopRecycle;
        public CCWin.SkinControl.SkinButton btnStartRecycle;
        public CCWin.SkinControl.SkinButton btnPauseCHDF;
        public CCWin.SkinControl.SkinButton btnStartCHDF;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel skinLabel5;




    }
}
