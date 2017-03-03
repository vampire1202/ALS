namespace ALS.FormSet
{
    partial class ucSetFlow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSetFlow));
            this.palFP = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFP = new System.Windows.Forms.TextBox();
            this.btnRun2 = new PulseButton.PulseButton();
            this.label3 = new System.Windows.Forms.Label();
            this.palDP = new System.Windows.Forms.Panel();
            this.txtDP = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnRun3 = new PulseButton.PulseButton();
            this.palDehydration = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDehydrationSpeed = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.palRP = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRP = new System.Windows.Forms.TextBox();
            this.btnRun4 = new PulseButton.PulseButton();
            this.btnRun1 = new PulseButton.PulseButton();
            this.palCP = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.btnRun6 = new PulseButton.PulseButton();
            this.palFP2 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.txtFP2 = new System.Windows.Forms.TextBox();
            this.btnRun5 = new PulseButton.PulseButton();
            this.palBP = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBP = new System.Windows.Forms.TextBox();
            this.palCtrlV = new System.Windows.Forms.Panel();
            this.chkV5 = new System.Windows.Forms.CheckBox();
            this.chkV6 = new System.Windows.Forms.CheckBox();
            this.chkV4 = new System.Windows.Forms.CheckBox();
            this.chkV3 = new System.Windows.Forms.CheckBox();
            this.chkV2 = new System.Windows.Forms.CheckBox();
            this.chkV1 = new System.Windows.Forms.CheckBox();
            this.groupSet = new CodeVendor.Controls.Grouper();
            this.btnConfirmM = new PulseButton.PulseButton();
            this.btnReturn = new PulseButton.PulseButton();
            this.palFP.SuspendLayout();
            this.palDP.SuspendLayout();
            this.palDehydration.SuspendLayout();
            this.palRP.SuspendLayout();
            this.palCP.SuspendLayout();
            this.palFP2.SuspendLayout();
            this.palBP.SuspendLayout();
            this.palCtrlV.SuspendLayout();
            this.groupSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // palFP
            // 
            this.palFP.Controls.Add(this.label16);
            this.palFP.Controls.Add(this.txtFP);
            this.palFP.Controls.Add(this.btnRun2);
            this.palFP.Location = new System.Drawing.Point(235, 146);
            this.palFP.Name = "palFP";
            this.palFP.Size = new System.Drawing.Size(384, 55);
            this.palFP.TabIndex = 104;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(40, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 21);
            this.label16.TabIndex = 57;
            this.label16.Text = "分离泵FP:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFP
            // 
            this.txtFP.BackColor = System.Drawing.Color.White;
            this.txtFP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.txtFP.Location = new System.Drawing.Point(128, 8);
            this.txtFP.Name = "txtFP";
            this.txtFP.ReadOnly = true;
            this.txtFP.Size = new System.Drawing.Size(100, 41);
            this.txtFP.TabIndex = 1;
            this.txtFP.Tag = "2";
            this.txtFP.Text = "0.0";
            this.txtFP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFP.Click += new System.EventHandler(this.txtBP_Click);
            // 
            // btnRun2
            // 
            this.btnRun2.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRun2.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRun2.CornerRadius = 20;
            this.btnRun2.FocusColor = System.Drawing.Color.Black;
            this.btnRun2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun2.ForeColor = System.Drawing.Color.Snow;
            this.btnRun2.Image = ((System.Drawing.Image)(resources.GetObject("btnRun2.Image")));
            this.btnRun2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun2.Location = new System.Drawing.Point(264, 2);
            this.btnRun2.Name = "btnRun2";
            this.btnRun2.NumberOfPulses = 2;
            this.btnRun2.PulseColor = System.Drawing.Color.DimGray;
            this.btnRun2.PulseSpeed = 0.3F;
            this.btnRun2.PulseWidth = 6;
            this.btnRun2.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRun2.Size = new System.Drawing.Size(97, 52);
            this.btnRun2.TabIndex = 121;
            this.btnRun2.Tag = "2";
            this.btnRun2.Text = "运转";
            this.btnRun2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun2.UseVisualStyleBackColor = true;
            this.btnRun2.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(361, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 111;
            this.label3.Text = "单位:(mL/min)";
            // 
            // palDP
            // 
            this.palDP.Controls.Add(this.txtDP);
            this.palDP.Controls.Add(this.label17);
            this.palDP.Controls.Add(this.btnRun3);
            this.palDP.Location = new System.Drawing.Point(235, 218);
            this.palDP.Name = "palDP";
            this.palDP.Size = new System.Drawing.Size(384, 55);
            this.palDP.TabIndex = 105;
            // 
            // txtDP
            // 
            this.txtDP.BackColor = System.Drawing.Color.White;
            this.txtDP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.txtDP.Location = new System.Drawing.Point(128, 8);
            this.txtDP.Name = "txtDP";
            this.txtDP.ReadOnly = true;
            this.txtDP.Size = new System.Drawing.Size(100, 41);
            this.txtDP.TabIndex = 1;
            this.txtDP.Tag = "3";
            this.txtDP.Text = "0.0";
            this.txtDP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDP.Click += new System.EventHandler(this.txtBP_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(22, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 21);
            this.label17.TabIndex = 59;
            this.label17.Text = "透析液泵DP:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRun3
            // 
            this.btnRun3.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRun3.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRun3.CornerRadius = 20;
            this.btnRun3.FocusColor = System.Drawing.Color.Black;
            this.btnRun3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun3.ForeColor = System.Drawing.Color.Snow;
            this.btnRun3.Image = ((System.Drawing.Image)(resources.GetObject("btnRun3.Image")));
            this.btnRun3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun3.Location = new System.Drawing.Point(264, 2);
            this.btnRun3.Name = "btnRun3";
            this.btnRun3.NumberOfPulses = 2;
            this.btnRun3.PulseColor = System.Drawing.Color.DimGray;
            this.btnRun3.PulseSpeed = 0.3F;
            this.btnRun3.PulseWidth = 6;
            this.btnRun3.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRun3.Size = new System.Drawing.Size(97, 52);
            this.btnRun3.TabIndex = 119;
            this.btnRun3.Tag = "3";
            this.btnRun3.Text = "运转";
            this.btnRun3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun3.UseVisualStyleBackColor = true;
            this.btnRun3.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // palDehydration
            // 
            this.palDehydration.Controls.Add(this.label14);
            this.palDehydration.Controls.Add(this.txtDehydrationSpeed);
            this.palDehydration.Controls.Add(this.label13);
            this.palDehydration.Location = new System.Drawing.Point(233, 507);
            this.palDehydration.Name = "palDehydration";
            this.palDehydration.Size = new System.Drawing.Size(306, 55);
            this.palDehydration.TabIndex = 110;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(252, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 21);
            this.label14.TabIndex = 11;
            this.label14.Text = "mL/h";
            // 
            // txtDehydrationSpeed
            // 
            this.txtDehydrationSpeed.BackColor = System.Drawing.Color.White;
            this.txtDehydrationSpeed.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDehydrationSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.txtDehydrationSpeed.Location = new System.Drawing.Point(128, 7);
            this.txtDehydrationSpeed.Name = "txtDehydrationSpeed";
            this.txtDehydrationSpeed.ReadOnly = true;
            this.txtDehydrationSpeed.Size = new System.Drawing.Size(100, 41);
            this.txtDehydrationSpeed.TabIndex = 1;
            this.txtDehydrationSpeed.Tag = "7";
            this.txtDehydrationSpeed.Text = "0.0";
            this.txtDehydrationSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDehydrationSpeed.Click += new System.EventHandler(this.txtBP_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label13.Location = new System.Drawing.Point(50, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 21);
            this.label13.TabIndex = 0;
            this.label13.Text = "脱水速度:";
            // 
            // palRP
            // 
            this.palRP.Controls.Add(this.label18);
            this.palRP.Controls.Add(this.txtRP);
            this.palRP.Controls.Add(this.btnRun4);
            this.palRP.Location = new System.Drawing.Point(235, 290);
            this.palRP.Name = "palRP";
            this.palRP.Size = new System.Drawing.Size(384, 55);
            this.palRP.TabIndex = 106;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(40, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 21);
            this.label18.TabIndex = 61;
            this.label18.Text = "补液泵RP:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRP
            // 
            this.txtRP.BackColor = System.Drawing.Color.White;
            this.txtRP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.txtRP.Location = new System.Drawing.Point(128, 8);
            this.txtRP.Name = "txtRP";
            this.txtRP.ReadOnly = true;
            this.txtRP.Size = new System.Drawing.Size(100, 41);
            this.txtRP.TabIndex = 1;
            this.txtRP.Tag = "4";
            this.txtRP.Text = "0.0";
            this.txtRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRP.Click += new System.EventHandler(this.txtBP_Click);
            // 
            // btnRun4
            // 
            this.btnRun4.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRun4.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRun4.CornerRadius = 20;
            this.btnRun4.FocusColor = System.Drawing.Color.Black;
            this.btnRun4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun4.ForeColor = System.Drawing.Color.Snow;
            this.btnRun4.Image = ((System.Drawing.Image)(resources.GetObject("btnRun4.Image")));
            this.btnRun4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun4.Location = new System.Drawing.Point(264, 2);
            this.btnRun4.Name = "btnRun4";
            this.btnRun4.NumberOfPulses = 2;
            this.btnRun4.PulseColor = System.Drawing.Color.DimGray;
            this.btnRun4.PulseSpeed = 0.3F;
            this.btnRun4.PulseWidth = 6;
            this.btnRun4.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRun4.Size = new System.Drawing.Size(97, 52);
            this.btnRun4.TabIndex = 118;
            this.btnRun4.Tag = "4";
            this.btnRun4.Text = "运转";
            this.btnRun4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun4.UseVisualStyleBackColor = true;
            this.btnRun4.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // btnRun1
            // 
            this.btnRun1.AutoEllipsis = true;
            this.btnRun1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRun1.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRun1.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRun1.CornerRadius = 20;
            this.btnRun1.FocusColor = System.Drawing.Color.Black;
            this.btnRun1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun1.ForeColor = System.Drawing.Color.Snow;
            this.btnRun1.Image = global::ALS.Properties.Resources.spstart;
            this.btnRun1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun1.Location = new System.Drawing.Point(264, 0);
            this.btnRun1.Name = "btnRun1";
            this.btnRun1.NumberOfPulses = 2;
            this.btnRun1.PulseColor = System.Drawing.Color.DimGray;
            this.btnRun1.PulseSpeed = 0.3F;
            this.btnRun1.PulseWidth = 6;
            this.btnRun1.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRun1.Size = new System.Drawing.Size(97, 52);
            this.btnRun1.TabIndex = 120;
            this.btnRun1.Tag = "1";
            this.btnRun1.Text = "运转";
            this.btnRun1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRun1.UseVisualStyleBackColor = true;
            this.btnRun1.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // palCP
            // 
            this.palCP.Controls.Add(this.label20);
            this.palCP.Controls.Add(this.txtCP);
            this.palCP.Controls.Add(this.btnRun6);
            this.palCP.Location = new System.Drawing.Point(233, 434);
            this.palCP.Name = "palCP";
            this.palCP.Size = new System.Drawing.Size(384, 55);
            this.palCP.TabIndex = 108;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(38, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 21);
            this.label20.TabIndex = 65;
            this.label20.Text = "循环泵CP:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCP
            // 
            this.txtCP.BackColor = System.Drawing.Color.White;
            this.txtCP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.txtCP.Location = new System.Drawing.Point(128, 8);
            this.txtCP.Name = "txtCP";
            this.txtCP.ReadOnly = true;
            this.txtCP.Size = new System.Drawing.Size(100, 41);
            this.txtCP.TabIndex = 1;
            this.txtCP.Tag = "6";
            this.txtCP.Text = "0.0";
            this.txtCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCP.Click += new System.EventHandler(this.txtBP_Click);
            // 
            // btnRun6
            // 
            this.btnRun6.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRun6.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRun6.CornerRadius = 20;
            this.btnRun6.FocusColor = System.Drawing.Color.Black;
            this.btnRun6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun6.ForeColor = System.Drawing.Color.Snow;
            this.btnRun6.Image = ((System.Drawing.Image)(resources.GetObject("btnRun6.Image")));
            this.btnRun6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun6.Location = new System.Drawing.Point(264, 2);
            this.btnRun6.Name = "btnRun6";
            this.btnRun6.NumberOfPulses = 2;
            this.btnRun6.PulseColor = System.Drawing.Color.DimGray;
            this.btnRun6.PulseSpeed = 0.3F;
            this.btnRun6.PulseWidth = 6;
            this.btnRun6.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRun6.Size = new System.Drawing.Size(97, 52);
            this.btnRun6.TabIndex = 116;
            this.btnRun6.Tag = "6";
            this.btnRun6.Text = "运转";
            this.btnRun6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun6.UseVisualStyleBackColor = true;
            this.btnRun6.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // palFP2
            // 
            this.palFP2.Controls.Add(this.label21);
            this.palFP2.Controls.Add(this.txtFP2);
            this.palFP2.Controls.Add(this.btnRun5);
            this.palFP2.Location = new System.Drawing.Point(235, 362);
            this.palFP2.Name = "palFP2";
            this.palFP2.Size = new System.Drawing.Size(384, 55);
            this.palFP2.TabIndex = 107;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(32, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(90, 21);
            this.label21.TabIndex = 63;
            this.label21.Text = "滤过泵FP2:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFP2
            // 
            this.txtFP2.BackColor = System.Drawing.Color.White;
            this.txtFP2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFP2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.txtFP2.Location = new System.Drawing.Point(128, 7);
            this.txtFP2.Name = "txtFP2";
            this.txtFP2.ReadOnly = true;
            this.txtFP2.Size = new System.Drawing.Size(100, 41);
            this.txtFP2.TabIndex = 1;
            this.txtFP2.Tag = "5";
            this.txtFP2.Text = "0.0";
            this.txtFP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFP2.Click += new System.EventHandler(this.txtBP_Click);
            // 
            // btnRun5
            // 
            this.btnRun5.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRun5.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRun5.CornerRadius = 20;
            this.btnRun5.FocusColor = System.Drawing.Color.Black;
            this.btnRun5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun5.ForeColor = System.Drawing.Color.Snow;
            this.btnRun5.Image = ((System.Drawing.Image)(resources.GetObject("btnRun5.Image")));
            this.btnRun5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun5.Location = new System.Drawing.Point(264, 1);
            this.btnRun5.Name = "btnRun5";
            this.btnRun5.NumberOfPulses = 2;
            this.btnRun5.PulseColor = System.Drawing.Color.DimGray;
            this.btnRun5.PulseSpeed = 0.3F;
            this.btnRun5.PulseWidth = 6;
            this.btnRun5.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRun5.Size = new System.Drawing.Size(97, 52);
            this.btnRun5.TabIndex = 117;
            this.btnRun5.Tag = "5";
            this.btnRun5.Text = "运转";
            this.btnRun5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun5.UseVisualStyleBackColor = true;
            this.btnRun5.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // palBP
            // 
            this.palBP.Controls.Add(this.label1);
            this.palBP.Controls.Add(this.txtBP);
            this.palBP.Controls.Add(this.btnRun1);
            this.palBP.Location = new System.Drawing.Point(235, 74);
            this.palBP.Name = "palBP";
            this.palBP.Size = new System.Drawing.Size(384, 55);
            this.palBP.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(39, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 55;
            this.label1.Text = "血液泵BP:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBP
            // 
            this.txtBP.BackColor = System.Drawing.Color.White;
            this.txtBP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.txtBP.Location = new System.Drawing.Point(128, 8);
            this.txtBP.Name = "txtBP";
            this.txtBP.ReadOnly = true;
            this.txtBP.Size = new System.Drawing.Size(100, 41);
            this.txtBP.TabIndex = 1;
            this.txtBP.Tag = "1";
            this.txtBP.Text = "0.0";
            this.txtBP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBP.Click += new System.EventHandler(this.txtBP_Click);
            // 
            // palCtrlV
            // 
            this.palCtrlV.Controls.Add(this.chkV5);
            this.palCtrlV.Controls.Add(this.chkV6);
            this.palCtrlV.Controls.Add(this.chkV4);
            this.palCtrlV.Controls.Add(this.chkV3);
            this.palCtrlV.Controls.Add(this.chkV2);
            this.palCtrlV.Controls.Add(this.chkV1);
            this.palCtrlV.Location = new System.Drawing.Point(111, 51);
            this.palCtrlV.Name = "palCtrlV";
            this.palCtrlV.Size = new System.Drawing.Size(83, 468);
            this.palCtrlV.TabIndex = 114;
            // 
            // chkV5
            // 
            this.chkV5.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkV5.Checked = true;
            this.chkV5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkV5.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chkV5.Image = ((System.Drawing.Image)(resources.GetObject("chkV5.Image")));
            this.chkV5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkV5.Location = new System.Drawing.Point(5, 313);
            this.chkV5.Name = "chkV5";
            this.chkV5.Size = new System.Drawing.Size(71, 73);
            this.chkV5.TabIndex = 6;
            this.chkV5.Tag = "v5";
            this.chkV5.Text = "5";
            this.chkV5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkV5.UseVisualStyleBackColor = true;
            this.chkV5.Click += new System.EventHandler(this.chkV1_Click);
            // 
            // chkV6
            // 
            this.chkV6.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkV6.Checked = true;
            this.chkV6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkV6.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chkV6.Image = ((System.Drawing.Image)(resources.GetObject("chkV6.Image")));
            this.chkV6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkV6.Location = new System.Drawing.Point(3, 390);
            this.chkV6.Name = "chkV6";
            this.chkV6.Size = new System.Drawing.Size(71, 73);
            this.chkV6.TabIndex = 6;
            this.chkV6.Tag = "v6";
            this.chkV6.Text = "6";
            this.chkV6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkV6.UseVisualStyleBackColor = true;
            this.chkV6.Click += new System.EventHandler(this.chkV1_Click);
            // 
            // chkV4
            // 
            this.chkV4.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkV4.Checked = true;
            this.chkV4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkV4.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chkV4.Image = ((System.Drawing.Image)(resources.GetObject("chkV4.Image")));
            this.chkV4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkV4.Location = new System.Drawing.Point(5, 236);
            this.chkV4.Name = "chkV4";
            this.chkV4.Size = new System.Drawing.Size(71, 73);
            this.chkV4.TabIndex = 6;
            this.chkV4.Tag = "v4";
            this.chkV4.Text = "4";
            this.chkV4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkV4.UseVisualStyleBackColor = true;
            this.chkV4.Click += new System.EventHandler(this.chkV1_Click);
            // 
            // chkV3
            // 
            this.chkV3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkV3.Checked = true;
            this.chkV3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkV3.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chkV3.Image = ((System.Drawing.Image)(resources.GetObject("chkV3.Image")));
            this.chkV3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkV3.Location = new System.Drawing.Point(5, 159);
            this.chkV3.Name = "chkV3";
            this.chkV3.Size = new System.Drawing.Size(71, 73);
            this.chkV3.TabIndex = 6;
            this.chkV3.Tag = "v3";
            this.chkV3.Text = "3";
            this.chkV3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkV3.UseVisualStyleBackColor = true;
            this.chkV3.Click += new System.EventHandler(this.chkV1_Click);
            // 
            // chkV2
            // 
            this.chkV2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkV2.Checked = true;
            this.chkV2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkV2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chkV2.Image = ((System.Drawing.Image)(resources.GetObject("chkV2.Image")));
            this.chkV2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkV2.Location = new System.Drawing.Point(5, 82);
            this.chkV2.Name = "chkV2";
            this.chkV2.Size = new System.Drawing.Size(71, 73);
            this.chkV2.TabIndex = 6;
            this.chkV2.Tag = "v2";
            this.chkV2.Text = "2";
            this.chkV2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkV2.UseVisualStyleBackColor = true;
            this.chkV2.Click += new System.EventHandler(this.chkV1_Click);
            // 
            // chkV1
            // 
            this.chkV1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkV1.BackColor = System.Drawing.Color.Transparent;
            this.chkV1.Checked = true;
            this.chkV1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkV1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chkV1.Image = ((System.Drawing.Image)(resources.GetObject("chkV1.Image")));
            this.chkV1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkV1.Location = new System.Drawing.Point(5, 5);
            this.chkV1.Name = "chkV1";
            this.chkV1.Size = new System.Drawing.Size(71, 73);
            this.chkV1.TabIndex = 6;
            this.chkV1.Tag = "v1";
            this.chkV1.Text = "1";
            this.chkV1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkV1.UseVisualStyleBackColor = false;
            this.chkV1.Click += new System.EventHandler(this.chkV1_Click);
            // 
            // groupSet
            // 
            this.groupSet.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.groupSet.BackgroundGradientColor = System.Drawing.Color.White;
            this.groupSet.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.groupSet.BorderColor = System.Drawing.Color.Silver;
            this.groupSet.BorderThickness = 1F;
            this.groupSet.Controls.Add(this.btnConfirmM);
            this.groupSet.Controls.Add(this.btnReturn);
            this.groupSet.Controls.Add(this.palCtrlV);
            this.groupSet.Controls.Add(this.palBP);
            this.groupSet.Controls.Add(this.palFP2);
            this.groupSet.Controls.Add(this.palCP);
            this.groupSet.Controls.Add(this.palRP);
            this.groupSet.Controls.Add(this.palDehydration);
            this.groupSet.Controls.Add(this.palDP);
            this.groupSet.Controls.Add(this.label3);
            this.groupSet.Controls.Add(this.palFP);
            this.groupSet.CustomGroupBoxColor = System.Drawing.Color.White;
            this.groupSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSet.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.groupSet.GroupImage = null;
            this.groupSet.GroupTitle = "设置流量";
            this.groupSet.Location = new System.Drawing.Point(0, 0);
            this.groupSet.Name = "groupSet";
            this.groupSet.Padding = new System.Windows.Forms.Padding(5, 12, 3, 3);
            this.groupSet.PaintGroupBox = true;
            this.groupSet.RoundCorners = 10;
            this.groupSet.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupSet.ShadowControl = false;
            this.groupSet.ShadowThickness = 3;
            this.groupSet.Size = new System.Drawing.Size(790, 604);
            this.groupSet.TabIndex = 120;
            // 
            // btnConfirmM
            // 
            this.btnConfirmM.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnConfirmM.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnConfirmM.CornerRadius = 25;
            this.btnConfirmM.FocusColor = System.Drawing.Color.Black;
            this.btnConfirmM.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirmM.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirmM.Location = new System.Drawing.Point(678, 539);
            this.btnConfirmM.Name = "btnConfirmM";
            this.btnConfirmM.NumberOfPulses = 2;
            this.btnConfirmM.PulseColor = System.Drawing.Color.DimGray;
            this.btnConfirmM.PulseSpeed = 0.3F;
            this.btnConfirmM.PulseWidth = 6;
            this.btnConfirmM.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnConfirmM.Size = new System.Drawing.Size(112, 62);
            this.btnConfirmM.TabIndex = 123;
            this.btnConfirmM.Text = "预冲完成";
            this.btnConfirmM.UseVisualStyleBackColor = true;
            this.btnConfirmM.Click += new System.EventHandler(this.btnConfirmM_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnReturn.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnReturn.CornerRadius = 25;
            this.btnReturn.FocusColor = System.Drawing.Color.Black;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReturn.Location = new System.Drawing.Point(678, 15);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.NumberOfPulses = 2;
            this.btnReturn.PulseColor = System.Drawing.Color.DimGray;
            this.btnReturn.PulseSpeed = 0.3F;
            this.btnReturn.PulseWidth = 6;
            this.btnReturn.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnReturn.Size = new System.Drawing.Size(112, 62);
            this.btnReturn.TabIndex = 122;
            this.btnReturn.Text = "返回选择";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // ucSetFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.groupSet);
            this.Name = "ucSetFlow";
            this.Size = new System.Drawing.Size(790, 604);
            this.Load += new System.EventHandler(this.ucSetFlow_Load);
            this.SizeChanged += new System.EventHandler(this.ucSetSyringe_SizeChanged);
            this.palFP.ResumeLayout(false);
            this.palFP.PerformLayout();
            this.palDP.ResumeLayout(false);
            this.palDP.PerformLayout();
            this.palDehydration.ResumeLayout(false);
            this.palDehydration.PerformLayout();
            this.palRP.ResumeLayout(false);
            this.palRP.PerformLayout();
            this.palCP.ResumeLayout(false);
            this.palCP.PerformLayout();
            this.palFP2.ResumeLayout(false);
            this.palFP2.PerformLayout();
            this.palBP.ResumeLayout(false);
            this.palBP.PerformLayout();
            this.palCtrlV.ResumeLayout(false);
            this.groupSet.ResumeLayout(false);
            this.groupSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel palFP;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtFP;
        public PulseButton.PulseButton btnRun2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Panel palDP;
        public System.Windows.Forms.TextBox txtDP;
        private System.Windows.Forms.Label label17;
        public PulseButton.PulseButton btnRun3;
        public System.Windows.Forms.Panel palDehydration;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtDehydrationSpeed;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Panel palRP;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox txtRP;
        public PulseButton.PulseButton btnRun4;
        public PulseButton.PulseButton btnRun1;
        public System.Windows.Forms.Panel palCP;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txtCP;
        public PulseButton.PulseButton btnRun6;
        public System.Windows.Forms.Panel palFP2;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.TextBox txtFP2;
        public PulseButton.PulseButton btnRun5;
        public System.Windows.Forms.Panel palBP;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtBP;
        public System.Windows.Forms.Panel palCtrlV;
        public System.Windows.Forms.CheckBox chkV5;
        public System.Windows.Forms.CheckBox chkV6;
        public System.Windows.Forms.CheckBox chkV4;
        public System.Windows.Forms.CheckBox chkV3;
        public System.Windows.Forms.CheckBox chkV2;
        public System.Windows.Forms.CheckBox chkV1;
        public PulseButton.PulseButton btnConfirmM;
        public PulseButton.PulseButton btnReturn;
        public CodeVendor.Controls.Grouper groupSet;

    }
}
