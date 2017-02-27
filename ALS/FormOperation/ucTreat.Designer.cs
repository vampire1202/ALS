namespace ALS.FormOperation
{
    partial class ucTreat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTreat));
            this.btnChange = new System.Windows.Forms.Button();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.btnZero = new CCWin.SkinControl.SkinButton();
            this.label25 = new System.Windows.Forms.Label();
            this.lblDryDeviation = new System.Windows.Forms.Label();
            this.lblDehydrationSpeed = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblDryLilun = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTargetTime = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chkBalance = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDryTotalActually = new System.Windows.Forms.Label();
            this.lblWeigh1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.palWizard = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.skinLine2 = new CCWin.SkinControl.SkinLine();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.lblWeigh4 = new System.Windows.Forms.Label();
            this.lblWeigh2 = new System.Windows.Forms.Label();
            this.lblWeigh3 = new System.Windows.Forms.Label();
            this.palDry = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.sgbox = new CCWin.SkinControl.SkinGroupBox();
            this.skinTabControl1 = new CCWin.SkinControl.SkinTabControl();
            this.skinTabPage1 = new CCWin.SkinControl.SkinTabPage();
            this.skinTabPage2 = new CCWin.SkinControl.SkinTabPage();
            this.picTreat = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.palDry.SuspendLayout();
            this.sgbox.SuspendLayout();
            this.skinTabControl1.SuspendLayout();
            this.skinTabPage1.SuspendLayout();
            this.skinTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTreat)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChange
            // 
            this.btnChange.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnChange.Location = new System.Drawing.Point(508, 78);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(79, 32);
            this.btnChange.TabIndex = 65;
            this.btnChange.Tag = "change";
            this.btnChange.Text = "更换液袋";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.chkBalance_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.skinLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.skinLabel1.Location = new System.Drawing.Point(207, 6);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(79, 22);
            this.skinLabel1.TabIndex = 64;
            this.skinLabel1.Text = "治疗时间:";
            // 
            // btnZero
            // 
            this.btnZero.BackColor = System.Drawing.Color.Transparent;
            this.btnZero.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnZero.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnZero.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnZero.DownBack = null;
            this.btnZero.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZero.ForeColor = System.Drawing.Color.White;
            this.btnZero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZero.Location = new System.Drawing.Point(137, 23);
            this.btnZero.MouseBack = null;
            this.btnZero.Name = "btnZero";
            this.btnZero.NormlBack = null;
            this.btnZero.Radius = 32;
            this.btnZero.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnZero.Size = new System.Drawing.Size(79, 32);
            this.btnZero.TabIndex = 62;
            this.btnZero.Tag = "";
            this.btnZero.Text = "脱水清零";
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.btnZeroTime_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label25.Location = new System.Drawing.Point(80, 58);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 16);
            this.label25.TabIndex = 57;
            this.label25.Text = "mL/h";
            // 
            // lblDryDeviation
            // 
            this.lblDryDeviation.AutoSize = true;
            this.lblDryDeviation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblDryDeviation.Location = new System.Drawing.Point(412, 5);
            this.lblDryDeviation.Name = "lblDryDeviation";
            this.lblDryDeviation.Size = new System.Drawing.Size(41, 26);
            this.lblDryDeviation.TabIndex = 59;
            this.lblDryDeviation.Text = "0.0";
            this.lblDryDeviation.Visible = false;
            // 
            // lblDehydrationSpeed
            // 
            this.lblDehydrationSpeed.BackColor = System.Drawing.Color.White;
            this.lblDehydrationSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDehydrationSpeed.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDehydrationSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblDehydrationSpeed.Location = new System.Drawing.Point(67, 24);
            this.lblDehydrationSpeed.Name = "lblDehydrationSpeed";
            this.lblDehydrationSpeed.Size = new System.Drawing.Size(65, 30);
            this.lblDehydrationSpeed.TabIndex = 19;
            this.lblDehydrationSpeed.Text = "0";
            this.lblDehydrationSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDehydrationSpeed.Click += new System.EventHandler(this.lblDehydrationSpeed_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label22.Location = new System.Drawing.Point(71, 5);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 17);
            this.label22.TabIndex = 56;
            this.label22.Text = "脱水速度";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDryLilun
            // 
            this.lblDryLilun.AutoSize = true;
            this.lblDryLilun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblDryLilun.Location = new System.Drawing.Point(161, 76);
            this.lblDryLilun.Name = "lblDryLilun";
            this.lblDryLilun.Size = new System.Drawing.Size(41, 26);
            this.lblDryLilun.TabIndex = 59;
            this.lblDryLilun.Text = "0.0";
            this.lblDryLilun.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label18.Location = new System.Drawing.Point(211, 93);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 20);
            this.label18.TabIndex = 58;
            this.label18.Text = "脱水偏差";
            this.label18.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label12.Location = new System.Drawing.Point(138, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 58;
            this.label12.Text = "理论脱水";
            this.label12.Visible = false;
            // 
            // lblTargetTime
            // 
            this.lblTargetTime.AutoSize = true;
            this.lblTargetTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTargetTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblTargetTime.Location = new System.Drawing.Point(188, 36);
            this.lblTargetTime.Name = "lblTargetTime";
            this.lblTargetTime.Size = new System.Drawing.Size(88, 23);
            this.lblTargetTime.TabIndex = 19;
            this.lblTargetTime.Text = "00:00:00";
            this.lblTargetTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTargetTime.Visible = false;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalTime.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblTotalTime.Location = new System.Drawing.Point(283, 6);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(90, 24);
            this.lblTotalTime.TabIndex = 20;
            this.lblTotalTime.Text = "00:00:00";
            this.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label21.Location = new System.Drawing.Point(23, 57);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(27, 16);
            this.label21.TabIndex = 53;
            this.label21.Text = "mL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label9.Location = new System.Drawing.Point(261, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 54;
            this.label9.Text = "WS2(g)";
            // 
            // chkBalance
            // 
            this.chkBalance.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBalance.Enabled = false;
            this.chkBalance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.chkBalance.Location = new System.Drawing.Point(508, 42);
            this.chkBalance.Name = "chkBalance";
            this.chkBalance.Size = new System.Drawing.Size(79, 32);
            this.chkBalance.TabIndex = 60;
            this.chkBalance.Tag = "chkbalance";
            this.chkBalance.Text = "泵秤平衡";
            this.chkBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBalance.UseVisualStyleBackColor = false;
            this.chkBalance.CheckedChanged += new System.EventHandler(this.chkBalance_CheckedChanged);
            this.chkBalance.Click += new System.EventHandler(this.chkBalance_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label8.Location = new System.Drawing.Point(303, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 54;
            this.label8.Text = "WS1(g)";
            this.label8.Visible = false;
            // 
            // lblDryTotalActually
            // 
            this.lblDryTotalActually.BackColor = System.Drawing.Color.Transparent;
            this.lblDryTotalActually.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDryTotalActually.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblDryTotalActually.Location = new System.Drawing.Point(3, 24);
            this.lblDryTotalActually.Name = "lblDryTotalActually";
            this.lblDryTotalActually.Size = new System.Drawing.Size(65, 30);
            this.lblDryTotalActually.TabIndex = 20;
            this.lblDryTotalActually.Text = "0.0";
            this.lblDryTotalActually.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeigh1
            // 
            this.lblWeigh1.BackColor = System.Drawing.Color.Transparent;
            this.lblWeigh1.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeigh1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblWeigh1.Location = new System.Drawing.Point(367, 94);
            this.lblWeigh1.Name = "lblWeigh1";
            this.lblWeigh1.Size = new System.Drawing.Size(70, 22);
            this.lblWeigh1.TabIndex = 31;
            this.lblWeigh1.Text = "0.0";
            this.lblWeigh1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWeigh1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label11.Location = new System.Drawing.Point(343, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 17);
            this.label11.TabIndex = 54;
            this.label11.Text = "WS3(g)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label6.Location = new System.Drawing.Point(423, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 54;
            this.label6.Text = "WS4(g)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(248, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 34);
            this.label1.TabIndex = 63;
            this.label1.Text = "注:  1.在使用过程中，秤必须保持稳定不晃动;\r\n      2.更换袋子时，请先<更换液袋>;";
            // 
            // palWizard
            // 
            this.palWizard.BackColor = System.Drawing.Color.White;
            this.palWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palWizard.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.palWizard.Location = new System.Drawing.Point(0, 0);
            this.palWizard.Name = "palWizard";
            this.palWizard.Size = new System.Drawing.Size(597, 308);
            this.palWizard.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDryDeviation);
            this.panel1.Controls.Add(this.skinLabel1);
            this.panel1.Controls.Add(this.lblTotalTime);
            this.panel1.Controls.Add(this.skinLine2);
            this.panel1.Controls.Add(this.skinLine1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 34);
            this.panel1.TabIndex = 67;
            // 
            // skinLine2
            // 
            this.skinLine2.BackColor = System.Drawing.Color.Transparent;
            this.skinLine2.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinLine2.LineColor = System.Drawing.Color.Silver;
            this.skinLine2.LineHeight = 1;
            this.skinLine2.Location = new System.Drawing.Point(0, 0);
            this.skinLine2.Name = "skinLine2";
            this.skinLine2.Size = new System.Drawing.Size(597, 2);
            this.skinLine2.TabIndex = 65;
            this.skinLine2.Text = "skinLine1";
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinLine1.LineColor = System.Drawing.Color.Silver;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(0, 32);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(597, 2);
            this.skinLine1.TabIndex = 65;
            this.skinLine1.Text = "skinLine1";
            // 
            // lblWeigh4
            // 
            this.lblWeigh4.BackColor = System.Drawing.Color.Transparent;
            this.lblWeigh4.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeigh4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblWeigh4.Location = new System.Drawing.Point(410, 61);
            this.lblWeigh4.Name = "lblWeigh4";
            this.lblWeigh4.Size = new System.Drawing.Size(70, 22);
            this.lblWeigh4.TabIndex = 31;
            this.lblWeigh4.Text = "0.0";
            this.lblWeigh4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeigh2
            // 
            this.lblWeigh2.BackColor = System.Drawing.Color.Transparent;
            this.lblWeigh2.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeigh2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblWeigh2.Location = new System.Drawing.Point(248, 61);
            this.lblWeigh2.Name = "lblWeigh2";
            this.lblWeigh2.Size = new System.Drawing.Size(70, 22);
            this.lblWeigh2.TabIndex = 31;
            this.lblWeigh2.Text = "0.0";
            this.lblWeigh2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeigh3
            // 
            this.lblWeigh3.BackColor = System.Drawing.Color.Transparent;
            this.lblWeigh3.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeigh3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblWeigh3.Location = new System.Drawing.Point(330, 61);
            this.lblWeigh3.Name = "lblWeigh3";
            this.lblWeigh3.Size = new System.Drawing.Size(70, 22);
            this.lblWeigh3.TabIndex = 31;
            this.lblWeigh3.Text = "0.0";
            this.lblWeigh3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // palDry
            // 
            this.palDry.Controls.Add(this.btnZero);
            this.palDry.Controls.Add(this.label12);
            this.palDry.Controls.Add(this.label22);
            this.palDry.Controls.Add(this.lblDryTotalActually);
            this.palDry.Controls.Add(this.label25);
            this.palDry.Controls.Add(this.lblDehydrationSpeed);
            this.palDry.Controls.Add(this.label21);
            this.palDry.Controls.Add(this.label2);
            this.palDry.Location = new System.Drawing.Point(3, 38);
            this.palDry.Name = "palDry";
            this.palDry.Size = new System.Drawing.Size(220, 78);
            this.palDry.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(7, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "当前脱水";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sgbox
            // 
            this.sgbox.BackColor = System.Drawing.Color.Transparent;
            this.sgbox.BorderColor = System.Drawing.Color.Silver;
            this.sgbox.Controls.Add(this.skinTabControl1);
            this.sgbox.Controls.Add(this.panel2);
            this.sgbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgbox.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.sgbox.Location = new System.Drawing.Point(0, 0);
            this.sgbox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.sgbox.Name = "sgbox";
            this.sgbox.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.sgbox.Radius = 20;
            this.sgbox.RectBackColor = System.Drawing.SystemColors.ButtonFace;
            this.sgbox.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.sgbox.Size = new System.Drawing.Size(603, 488);
            this.sgbox.TabIndex = 71;
            this.sgbox.TabStop = false;
            this.sgbox.TitleBorderColor = System.Drawing.Color.Silver;
            this.sgbox.TitleRadius = 20;
            this.sgbox.TitleRectBackColor = System.Drawing.Color.White;
            this.sgbox.TitleRoundStyle = CCWin.SkinClass.RoundStyle.Right;
            // 
            // skinTabControl1
            // 
            this.skinTabControl1.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.skinTabControl1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.skinTabControl1.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.skinTabControl1.Controls.Add(this.skinTabPage1);
            this.skinTabControl1.Controls.Add(this.skinTabPage2);
            this.skinTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabControl1.HeadBack = null;
            this.skinTabControl1.ImgSize = new System.Drawing.Size(0, 0);
            this.skinTabControl1.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.skinTabControl1.ItemSize = new System.Drawing.Size(80, 35);
            this.skinTabControl1.Location = new System.Drawing.Point(3, 26);
            this.skinTabControl1.Name = "skinTabControl1";
            this.skinTabControl1.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowDown")));
            this.skinTabControl1.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageArrowHover")));
            this.skinTabControl1.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseHover")));
            this.skinTabControl1.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageCloseNormal")));
            this.skinTabControl1.PageDown = global::ALS.Properties.Resources.buttonfacesel;
            this.skinTabControl1.PageDownTxtColor = System.Drawing.Color.White;
            this.skinTabControl1.PageHover = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.PageHover")));
            this.skinTabControl1.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Top;
            this.skinTabControl1.PageNorml = global::ALS.Properties.Resources.buttonface;
            this.skinTabControl1.SelectedIndex = 0;
            this.skinTabControl1.Size = new System.Drawing.Size(597, 343);
            this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.skinTabControl1.TabIndex = 2;
            // 
            // skinTabPage1
            // 
            this.skinTabPage1.BackColor = System.Drawing.Color.White;
            this.skinTabPage1.Controls.Add(this.palWizard);
            this.skinTabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabPage1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinTabPage1.Location = new System.Drawing.Point(0, 35);
            this.skinTabPage1.Name = "skinTabPage1";
            this.skinTabPage1.Size = new System.Drawing.Size(597, 308);
            this.skinTabPage1.TabIndex = 0;
            this.skinTabPage1.TabItemImage = null;
            this.skinTabPage1.Text = "治疗向导";
            // 
            // skinTabPage2
            // 
            this.skinTabPage2.BackColor = System.Drawing.Color.White;
            this.skinTabPage2.Controls.Add(this.picTreat);
            this.skinTabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabPage2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinTabPage2.Location = new System.Drawing.Point(0, 35);
            this.skinTabPage2.Name = "skinTabPage2";
            this.skinTabPage2.Size = new System.Drawing.Size(597, 308);
            this.skinTabPage2.TabIndex = 1;
            this.skinTabPage2.TabItemImage = null;
            this.skinTabPage2.Text = "模式图";
            // 
            // picTreat
            // 
            this.picTreat.BackColor = System.Drawing.Color.White;
            this.picTreat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTreat.Location = new System.Drawing.Point(0, 0);
            this.picTreat.Name = "picTreat";
            this.picTreat.Size = new System.Drawing.Size(597, 308);
            this.picTreat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTreat.TabIndex = 0;
            this.picTreat.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.palDry);
            this.panel2.Controls.Add(this.lblWeigh1);
            this.panel2.Controls.Add(this.chkBalance);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnChange);
            this.panel2.Controls.Add(this.lblDryLilun);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lblWeigh4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblWeigh3);
            this.panel2.Controls.Add(this.lblWeigh2);
            this.panel2.Controls.Add(this.lblTargetTime);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 369);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 116);
            this.panel2.TabIndex = 1;
            // 
            // ucTreat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.sgbox);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.Name = "ucTreat";
            this.Size = new System.Drawing.Size(603, 488);
            this.Load += new System.EventHandler(this.ucfrmTherapy_Load);
            this.SizeChanged += new System.EventHandler(this.ucfrmTherapy_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.palDry.ResumeLayout(false);
            this.palDry.PerformLayout();
            this.sgbox.ResumeLayout(false);
            this.skinTabControl1.ResumeLayout(false);
            this.skinTabPage1.ResumeLayout(false);
            this.skinTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTreat)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblTotalTime;
        public System.Windows.Forms.Label lblTargetTime;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label lblDryTotalActually;
        public System.Windows.Forms.Label lblDehydrationSpeed;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label lblWeigh1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.CheckBox chkBalance;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lblDryLilun;
        public System.Windows.Forms.Label lblDryDeviation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        public CCWin.SkinControl.SkinButton btnZero;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        public System.Windows.Forms.Button btnChange;
        public System.Windows.Forms.Label lblWeigh4;
        public System.Windows.Forms.Label lblWeigh2;
        public System.Windows.Forms.Label lblWeigh3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel palDry;
        public System.Windows.Forms.Panel palWizard;
        public CCWin.SkinControl.SkinGroupBox sgbox;
        private CCWin.SkinControl.SkinLine skinLine2;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CCWin.SkinControl.SkinTabPage skinTabPage1;
        private CCWin.SkinControl.SkinTabPage skinTabPage2;
        public System.Windows.Forms.PictureBox picTreat;
        public CCWin.SkinControl.SkinTabControl skinTabControl1;
    }
}
