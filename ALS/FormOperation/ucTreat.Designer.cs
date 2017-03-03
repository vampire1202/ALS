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
            this.btnChange = new System.Windows.Forms.Button();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWeigh4 = new System.Windows.Forms.Label();
            this.lblWeigh2 = new System.Windows.Forms.Label();
            this.lblWeigh3 = new System.Windows.Forms.Label();
            this.palDry = new System.Windows.Forms.Panel();
            this.btnZero = new PulseButton.PulseButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sgBox = new CodeVendor.Controls.Grouper();
            this.customTabControl1 = new System.Windows.Forms.CustomTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.palWizard = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.picTreat = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.palDry.SuspendLayout();
            this.panel2.SuspendLayout();
            this.sgBox.SuspendLayout();
            this.customTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTreat)).BeginInit();
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
            this.lblDryDeviation.Location = new System.Drawing.Point(412, 7);
            this.lblDryDeviation.Name = "lblDryDeviation";
            this.lblDryDeviation.Size = new System.Drawing.Size(32, 21);
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
            this.lblDryLilun.Size = new System.Drawing.Size(32, 21);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblDryDeviation);
            this.panel1.Controls.Add(this.lblTotalTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 34);
            this.panel1.TabIndex = 67;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.Silver;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 33);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(603, 1);
            this.splitter2.TabIndex = 68;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Silver;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(603, 1);
            this.splitter1.TabIndex = 67;
            this.splitter1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(192, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 26);
            this.label3.TabIndex = 66;
            this.label3.Text = "治疗时间:";
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
            // btnZero
            // 
            this.btnZero.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnZero.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnZero.CornerRadius = 16;
            this.btnZero.FocusColor = System.Drawing.Color.Black;
            this.btnZero.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZero.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnZero.Location = new System.Drawing.Point(128, 19);
            this.btnZero.Name = "btnZero";
            this.btnZero.PulseColor = System.Drawing.Color.DimGray;
            this.btnZero.PulseSpeed = 0.3F;
            this.btnZero.PulseWidth = 4;
            this.btnZero.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnZero.Size = new System.Drawing.Size(90, 42);
            this.btnZero.TabIndex = 122;
            this.btnZero.Text = "脱水清零";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZeroTime_Click);
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
            this.panel2.Location = new System.Drawing.Point(0, 372);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 116);
            this.panel2.TabIndex = 1;
            // 
            // sgBox
            // 
            this.sgBox.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.sgBox.BackgroundGradientColor = System.Drawing.SystemColors.ButtonFace;
            this.sgBox.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.sgBox.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.sgBox.BorderThickness = 1F;
            this.sgBox.Controls.Add(this.customTabControl1);
            this.sgBox.Controls.Add(this.panel2);
            this.sgBox.CustomGroupBoxColor = System.Drawing.Color.White;
            this.sgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sgBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.sgBox.GroupImage = null;
            this.sgBox.GroupTitle = "";
            this.sgBox.Location = new System.Drawing.Point(0, 0);
            this.sgBox.Name = "sgBox";
            this.sgBox.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.sgBox.PaintGroupBox = true;
            this.sgBox.RoundCorners = 10;
            this.sgBox.ShadowColor = System.Drawing.SystemColors.ButtonFace;
            this.sgBox.ShadowControl = false;
            this.sgBox.ShadowThickness = 3;
            this.sgBox.Size = new System.Drawing.Size(603, 488);
            this.sgBox.TabIndex = 121;
            // 
            // customTabControl1
            // 
            this.customTabControl1.BorderColor = System.Drawing.Color.Silver;
            this.customTabControl1.BorderColorSelected = System.Drawing.Color.Silver;
            this.customTabControl1.Controls.Add(this.tabPage1);
            this.customTabControl1.Controls.Add(this.tabPage2);
            this.customTabControl1.DisplayStyle = System.Windows.Forms.TabStyle.Chrome;
            this.customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTabControl1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.customTabControl1.Location = new System.Drawing.Point(0, 10);
            this.customTabControl1.Name = "customTabControl1";
            this.customTabControl1.Overlap = 16;
            this.customTabControl1.Padding = new System.Drawing.Point(13, 5);
            this.customTabControl1.Radius = 10;
            this.customTabControl1.SelectedIndex = 0;
            this.customTabControl1.Size = new System.Drawing.Size(603, 362);
            this.customTabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.palWizard);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "治疗向导";
            // 
            // palWizard
            // 
            this.palWizard.BackColor = System.Drawing.Color.White;
            this.palWizard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palWizard.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.palWizard.Location = new System.Drawing.Point(3, 3);
            this.palWizard.Name = "palWizard";
            this.palWizard.Size = new System.Drawing.Size(589, 317);
            this.palWizard.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picTreat);
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 323);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "模式图";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // picTreat
            // 
            this.picTreat.BackColor = System.Drawing.Color.White;
            this.picTreat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTreat.Location = new System.Drawing.Point(3, 3);
            this.picTreat.Name = "picTreat";
            this.picTreat.Size = new System.Drawing.Size(589, 317);
            this.picTreat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTreat.TabIndex = 0;
            this.picTreat.TabStop = false;
            // 
            // ucTreat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.sgBox);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.Name = "ucTreat";
            this.Size = new System.Drawing.Size(603, 488);
            this.Load += new System.EventHandler(this.ucfrmTherapy_Load);
            this.SizeChanged += new System.EventHandler(this.ucfrmTherapy_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.palDry.ResumeLayout(false);
            this.palDry.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.sgBox.ResumeLayout(false);
            this.customTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTreat)).EndInit();
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
        public System.Windows.Forms.Button btnChange;
        public System.Windows.Forms.Label lblWeigh4;
        public System.Windows.Forms.Label lblWeigh2;
        public System.Windows.Forms.Label lblWeigh3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel palDry;
        public System.Windows.Forms.Panel palWizard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox picTreat;
        private System.Windows.Forms.Label label3;
        public CodeVendor.Controls.Grouper sgBox;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.CustomTabControl customTabControl1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        public PulseButton.PulseButton btnZero;
    }
}
