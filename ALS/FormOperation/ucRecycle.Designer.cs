namespace ALS.FormOperation
{
    partial class ucRecycle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecycle));
            this.lblRP = new System.Windows.Forms.Label();
            this.lblDP = new System.Windows.Forms.Label();
            this.lblFP = new System.Windows.Forms.Label();
            this.lblBP = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCP = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblFP2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvRecycle = new System.Windows.Forms.DataGridView();
            this.lblRecycle = new System.Windows.Forms.Label();
            this.palCtrlV = new System.Windows.Forms.Panel();
            this.chkV5 = new System.Windows.Forms.CheckBox();
            this.chkV6 = new System.Windows.Forms.CheckBox();
            this.chkV4 = new System.Windows.Forms.CheckBox();
            this.chkV3 = new System.Windows.Forms.CheckBox();
            this.chkV2 = new System.Windows.Forms.CheckBox();
            this.chkV1 = new System.Windows.Forms.CheckBox();
            this.gboxRecycle = new CodeVendor.Controls.Grouper();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.gboxPump = new CodeVendor.Controls.Grouper();
            this.grouper3 = new CodeVendor.Controls.Grouper();
            this.grouper2 = new CodeVendor.Controls.Grouper();
            this.btnRunCP = new PulseButton.PulseButton();
            this.btnRunFP2 = new PulseButton.PulseButton();
            this.btnRunRP = new PulseButton.PulseButton();
            this.btnRunDP = new PulseButton.PulseButton();
            this.btnRunBP = new PulseButton.PulseButton();
            this.btnRunFP = new PulseButton.PulseButton();
            this.btnReturn = new PulseButton.PulseButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecycle)).BeginInit();
            this.palCtrlV.SuspendLayout();
            this.gboxRecycle.SuspendLayout();
            this.grouper1.SuspendLayout();
            this.gboxPump.SuspendLayout();
            this.grouper3.SuspendLayout();
            this.grouper2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRP
            // 
            this.lblRP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRP.Location = new System.Drawing.Point(109, 234);
            this.lblRP.Name = "lblRP";
            this.lblRP.Size = new System.Drawing.Size(90, 38);
            this.lblRP.TabIndex = 31;
            this.lblRP.Tag = "RP";
            this.lblRP.Text = "0";
            this.lblRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // lblDP
            // 
            this.lblDP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDP.Location = new System.Drawing.Point(109, 171);
            this.lblDP.Name = "lblDP";
            this.lblDP.Size = new System.Drawing.Size(90, 38);
            this.lblDP.TabIndex = 31;
            this.lblDP.Tag = "DP";
            this.lblDP.Text = "0";
            this.lblDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // lblFP
            // 
            this.lblFP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFP.Location = new System.Drawing.Point(109, 108);
            this.lblFP.Name = "lblFP";
            this.lblFP.Size = new System.Drawing.Size(90, 38);
            this.lblFP.TabIndex = 31;
            this.lblFP.Tag = "FP";
            this.lblFP.Text = "0";
            this.lblFP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // lblBP
            // 
            this.lblBP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBP.Location = new System.Drawing.Point(107, 45);
            this.lblBP.Name = "lblBP";
            this.lblBP.Size = new System.Drawing.Size(90, 38);
            this.lblBP.TabIndex = 31;
            this.lblBP.Tag = "BP";
            this.lblBP.Text = "0";
            this.lblBP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(18, 243);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 21);
            this.label15.TabIndex = 26;
            this.label15.Text = "补液泵RP:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(0, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 21);
            this.label14.TabIndex = 26;
            this.label14.Text = "透析液泵DP:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(19, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "分离泵FP:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(18, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "血液泵BP:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCP
            // 
            this.lblCP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCP.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCP.Location = new System.Drawing.Point(109, 360);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(90, 38);
            this.lblCP.TabIndex = 31;
            this.lblCP.Tag = "CP";
            this.lblCP.Text = "0";
            this.lblCP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(10, 306);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 21);
            this.label18.TabIndex = 26;
            this.label18.Text = "滤过泵FP2:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFP2
            // 
            this.lblFP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFP2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFP2.Location = new System.Drawing.Point(109, 297);
            this.lblFP2.Name = "lblFP2";
            this.lblFP2.Size = new System.Drawing.Size(90, 38);
            this.lblFP2.TabIndex = 31;
            this.lblFP2.Tag = "FP2";
            this.lblFP2.Text = "0";
            this.lblFP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFP2.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(17, 369);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 21);
            this.label19.TabIndex = 26;
            this.label19.Text = "循环泵CP:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvRecycle
            // 
            this.dgvRecycle.AllowUserToAddRows = false;
            this.dgvRecycle.AllowUserToDeleteRows = false;
            this.dgvRecycle.AllowUserToResizeColumns = false;
            this.dgvRecycle.AllowUserToResizeRows = false;
            this.dgvRecycle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvRecycle.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvRecycle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecycle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecycle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecycle.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecycle.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvRecycle.Location = new System.Drawing.Point(2, 25);
            this.dgvRecycle.MultiSelect = false;
            this.dgvRecycle.Name = "dgvRecycle";
            this.dgvRecycle.ReadOnly = true;
            this.dgvRecycle.RowHeadersVisible = false;
            this.dgvRecycle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRecycle.RowTemplate.Height = 23;
            this.dgvRecycle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecycle.Size = new System.Drawing.Size(430, 299);
            this.dgvRecycle.TabIndex = 20;
            // 
            // lblRecycle
            // 
            this.lblRecycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecycle.Font = new System.Drawing.Font("Times New Roman", 38F, System.Drawing.FontStyle.Bold);
            this.lblRecycle.Location = new System.Drawing.Point(2, 25);
            this.lblRecycle.Name = "lblRecycle";
            this.lblRecycle.Size = new System.Drawing.Size(313, 101);
            this.lblRecycle.TabIndex = 0;
            this.lblRecycle.Text = "0.0";
            this.lblRecycle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // palCtrlV
            // 
            this.palCtrlV.Controls.Add(this.chkV5);
            this.palCtrlV.Controls.Add(this.chkV6);
            this.palCtrlV.Controls.Add(this.chkV4);
            this.palCtrlV.Controls.Add(this.chkV3);
            this.palCtrlV.Controls.Add(this.chkV2);
            this.palCtrlV.Controls.Add(this.chkV1);
            this.palCtrlV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palCtrlV.Location = new System.Drawing.Point(2, 25);
            this.palCtrlV.Name = "palCtrlV";
            this.palCtrlV.Size = new System.Drawing.Size(433, 187);
            this.palCtrlV.TabIndex = 115;
            // 
            // chkV5
            // 
            this.chkV5.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkV5.Checked = true;
            this.chkV5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkV5.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chkV5.Image = ((System.Drawing.Image)(resources.GetObject("chkV5.Image")));
            this.chkV5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkV5.Location = new System.Drawing.Point(172, 111);
            this.chkV5.Name = "chkV5";
            this.chkV5.Size = new System.Drawing.Size(80, 62);
            this.chkV5.TabIndex = 6;
            this.chkV5.Tag = "v5";
            this.chkV5.Text = "5";
            this.chkV5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.chkV6.Location = new System.Drawing.Point(292, 111);
            this.chkV6.Name = "chkV6";
            this.chkV6.Size = new System.Drawing.Size(80, 62);
            this.chkV6.TabIndex = 6;
            this.chkV6.Tag = "v6";
            this.chkV6.Text = "6";
            this.chkV6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.chkV4.Location = new System.Drawing.Point(52, 111);
            this.chkV4.Name = "chkV4";
            this.chkV4.Size = new System.Drawing.Size(80, 62);
            this.chkV4.TabIndex = 6;
            this.chkV4.Tag = "v4";
            this.chkV4.Text = "4";
            this.chkV4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.chkV3.Location = new System.Drawing.Point(292, 25);
            this.chkV3.Name = "chkV3";
            this.chkV3.Size = new System.Drawing.Size(80, 62);
            this.chkV3.TabIndex = 6;
            this.chkV3.Tag = "v3";
            this.chkV3.Text = "3";
            this.chkV3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.chkV2.Location = new System.Drawing.Point(172, 25);
            this.chkV2.Name = "chkV2";
            this.chkV2.Size = new System.Drawing.Size(80, 62);
            this.chkV2.TabIndex = 6;
            this.chkV2.Tag = "v2";
            this.chkV2.Text = "2";
            this.chkV2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
            this.chkV1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkV1.Location = new System.Drawing.Point(52, 25);
            this.chkV1.Name = "chkV1";
            this.chkV1.Size = new System.Drawing.Size(80, 62);
            this.chkV1.TabIndex = 6;
            this.chkV1.Tag = "v1";
            this.chkV1.Text = "1";
            this.chkV1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chkV1.UseVisualStyleBackColor = false;
            this.chkV1.Click += new System.EventHandler(this.chkV1_Click);
            // 
            // gboxRecycle
            // 
            this.gboxRecycle.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gboxRecycle.BackgroundGradientColor = System.Drawing.Color.White;
            this.gboxRecycle.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.gboxRecycle.BorderColor = System.Drawing.Color.Silver;
            this.gboxRecycle.BorderThickness = 1F;
            this.gboxRecycle.Controls.Add(this.dgvRecycle);
            this.gboxRecycle.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gboxRecycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gboxRecycle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.gboxRecycle.GroupImage = null;
            this.gboxRecycle.GroupTitle = "PE回收方法,请参照以下步骤回收";
            this.gboxRecycle.Location = new System.Drawing.Point(12, 30);
            this.gboxRecycle.Name = "gboxRecycle";
            this.gboxRecycle.Padding = new System.Windows.Forms.Padding(2, 25, 3, 3);
            this.gboxRecycle.PaintGroupBox = true;
            this.gboxRecycle.RoundCorners = 10;
            this.gboxRecycle.ShadowColor = System.Drawing.Color.DarkGray;
            this.gboxRecycle.ShadowControl = false;
            this.gboxRecycle.ShadowThickness = 3;
            this.gboxRecycle.Size = new System.Drawing.Size(435, 327);
            this.gboxRecycle.TabIndex = 117;
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper1.BorderColor = System.Drawing.Color.Silver;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.gboxPump);
            this.grouper1.Controls.Add(this.grouper3);
            this.grouper1.Controls.Add(this.grouper2);
            this.grouper1.Controls.Add(this.gboxRecycle);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouper1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grouper1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "回收";
            this.grouper1.Location = new System.Drawing.Point(0, 0);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(5, 12, 3, 3);
            this.grouper1.PaintGroupBox = true;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(790, 604);
            this.grouper1.TabIndex = 118;
            // 
            // gboxPump
            // 
            this.gboxPump.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gboxPump.BackgroundGradientColor = System.Drawing.Color.White;
            this.gboxPump.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.gboxPump.BorderColor = System.Drawing.Color.Silver;
            this.gboxPump.BorderThickness = 1F;
            this.gboxPump.Controls.Add(this.label5);
            this.gboxPump.Controls.Add(this.btnRunCP);
            this.gboxPump.Controls.Add(this.label19);
            this.gboxPump.Controls.Add(this.lblCP);
            this.gboxPump.Controls.Add(this.lblDP);
            this.gboxPump.Controls.Add(this.btnRunFP2);
            this.gboxPump.Controls.Add(this.lblFP);
            this.gboxPump.Controls.Add(this.label7);
            this.gboxPump.Controls.Add(this.btnRunRP);
            this.gboxPump.Controls.Add(this.lblFP2);
            this.gboxPump.Controls.Add(this.lblRP);
            this.gboxPump.Controls.Add(this.label14);
            this.gboxPump.Controls.Add(this.btnRunDP);
            this.gboxPump.Controls.Add(this.label18);
            this.gboxPump.Controls.Add(this.label15);
            this.gboxPump.Controls.Add(this.btnRunBP);
            this.gboxPump.Controls.Add(this.btnRunFP);
            this.gboxPump.Controls.Add(this.lblBP);
            this.gboxPump.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gboxPump.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gboxPump.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.gboxPump.GroupImage = null;
            this.gboxPump.GroupTitle = "回收操作(泵速mL/min)";
            this.gboxPump.Location = new System.Drawing.Point(461, 30);
            this.gboxPump.Name = "gboxPump";
            this.gboxPump.Padding = new System.Windows.Forms.Padding(2, 25, 3, 3);
            this.gboxPump.PaintGroupBox = true;
            this.gboxPump.RoundCorners = 10;
            this.gboxPump.ShadowColor = System.Drawing.Color.DarkGray;
            this.gboxPump.ShadowControl = false;
            this.gboxPump.ShadowThickness = 3;
            this.gboxPump.Size = new System.Drawing.Size(318, 419);
            this.gboxPump.TabIndex = 123;
            // 
            // grouper3
            // 
            this.grouper3.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grouper3.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper3.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper3.BorderColor = System.Drawing.Color.Silver;
            this.grouper3.BorderThickness = 1F;
            this.grouper3.Controls.Add(this.btnReturn);
            this.grouper3.Controls.Add(this.lblRecycle);
            this.grouper3.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grouper3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.grouper3.GroupImage = null;
            this.grouper3.GroupTitle = "回收量";
            this.grouper3.Location = new System.Drawing.Point(461, 462);
            this.grouper3.Name = "grouper3";
            this.grouper3.Padding = new System.Windows.Forms.Padding(2, 25, 3, 3);
            this.grouper3.PaintGroupBox = true;
            this.grouper3.RoundCorners = 10;
            this.grouper3.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper3.ShadowControl = false;
            this.grouper3.ShadowThickness = 3;
            this.grouper3.Size = new System.Drawing.Size(318, 129);
            this.grouper3.TabIndex = 122;
            // 
            // grouper2
            // 
            this.grouper2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grouper2.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper2.BorderColor = System.Drawing.Color.Silver;
            this.grouper2.BorderThickness = 1F;
            this.grouper2.Controls.Add(this.palCtrlV);
            this.grouper2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grouper2.GroupImage = null;
            this.grouper2.GroupTitle = "夹管阀操作";
            this.grouper2.Location = new System.Drawing.Point(12, 376);
            this.grouper2.Name = "grouper2";
            this.grouper2.Padding = new System.Windows.Forms.Padding(2, 25, 3, 3);
            this.grouper2.PaintGroupBox = true;
            this.grouper2.RoundCorners = 10;
            this.grouper2.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper2.ShadowControl = false;
            this.grouper2.ShadowThickness = 3;
            this.grouper2.Size = new System.Drawing.Size(438, 215);
            this.grouper2.TabIndex = 121;
            // 
            // btnRunCP
            // 
            this.btnRunCP.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRunCP.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRunCP.CornerRadius = 20;
            this.btnRunCP.FocusColor = System.Drawing.Color.Black;
            this.btnRunCP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunCP.ForeColor = System.Drawing.Color.Snow;
            this.btnRunCP.Image = ((System.Drawing.Image)(resources.GetObject("btnRunCP.Image")));
            this.btnRunCP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunCP.Location = new System.Drawing.Point(203, 353);
            this.btnRunCP.Name = "btnRunCP";
            this.btnRunCP.NumberOfPulses = 2;
            this.btnRunCP.PulseColor = System.Drawing.Color.DimGray;
            this.btnRunCP.PulseSpeed = 0.3F;
            this.btnRunCP.PulseWidth = 6;
            this.btnRunCP.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRunCP.Size = new System.Drawing.Size(97, 52);
            this.btnRunCP.TabIndex = 69;
            this.btnRunCP.Tag = "cp";
            this.btnRunCP.Text = "运转";
            this.btnRunCP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunCP.UseVisualStyleBackColor = true;
            this.btnRunCP.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnRunFP2
            // 
            this.btnRunFP2.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRunFP2.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRunFP2.CornerRadius = 20;
            this.btnRunFP2.FocusColor = System.Drawing.Color.Black;
            this.btnRunFP2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunFP2.ForeColor = System.Drawing.Color.Snow;
            this.btnRunFP2.Image = ((System.Drawing.Image)(resources.GetObject("btnRunFP2.Image")));
            this.btnRunFP2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunFP2.Location = new System.Drawing.Point(203, 290);
            this.btnRunFP2.Name = "btnRunFP2";
            this.btnRunFP2.NumberOfPulses = 2;
            this.btnRunFP2.PulseColor = System.Drawing.Color.DimGray;
            this.btnRunFP2.PulseSpeed = 0.3F;
            this.btnRunFP2.PulseWidth = 6;
            this.btnRunFP2.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRunFP2.Size = new System.Drawing.Size(97, 52);
            this.btnRunFP2.TabIndex = 69;
            this.btnRunFP2.Tag = "fp2";
            this.btnRunFP2.Text = "运转";
            this.btnRunFP2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunFP2.UseVisualStyleBackColor = true;
            this.btnRunFP2.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnRunRP
            // 
            this.btnRunRP.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRunRP.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRunRP.CornerRadius = 20;
            this.btnRunRP.FocusColor = System.Drawing.Color.Black;
            this.btnRunRP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunRP.ForeColor = System.Drawing.Color.Snow;
            this.btnRunRP.Image = ((System.Drawing.Image)(resources.GetObject("btnRunRP.Image")));
            this.btnRunRP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunRP.Location = new System.Drawing.Point(203, 227);
            this.btnRunRP.Name = "btnRunRP";
            this.btnRunRP.NumberOfPulses = 2;
            this.btnRunRP.PulseColor = System.Drawing.Color.DimGray;
            this.btnRunRP.PulseSpeed = 0.3F;
            this.btnRunRP.PulseWidth = 6;
            this.btnRunRP.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRunRP.Size = new System.Drawing.Size(97, 52);
            this.btnRunRP.TabIndex = 69;
            this.btnRunRP.Tag = "rp";
            this.btnRunRP.Text = "运转";
            this.btnRunRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunRP.UseVisualStyleBackColor = true;
            this.btnRunRP.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnRunDP
            // 
            this.btnRunDP.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRunDP.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRunDP.CornerRadius = 20;
            this.btnRunDP.FocusColor = System.Drawing.Color.Black;
            this.btnRunDP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunDP.ForeColor = System.Drawing.Color.Snow;
            this.btnRunDP.Image = ((System.Drawing.Image)(resources.GetObject("btnRunDP.Image")));
            this.btnRunDP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunDP.Location = new System.Drawing.Point(203, 164);
            this.btnRunDP.Name = "btnRunDP";
            this.btnRunDP.NumberOfPulses = 2;
            this.btnRunDP.PulseColor = System.Drawing.Color.DimGray;
            this.btnRunDP.PulseSpeed = 0.3F;
            this.btnRunDP.PulseWidth = 6;
            this.btnRunDP.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRunDP.Size = new System.Drawing.Size(97, 52);
            this.btnRunDP.TabIndex = 69;
            this.btnRunDP.Tag = "dp";
            this.btnRunDP.Text = "运转";
            this.btnRunDP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunDP.UseVisualStyleBackColor = true;
            this.btnRunDP.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnRunBP
            // 
            this.btnRunBP.AutoEllipsis = true;
            this.btnRunBP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRunBP.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRunBP.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRunBP.CornerRadius = 20;
            this.btnRunBP.FocusColor = System.Drawing.Color.Black;
            this.btnRunBP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunBP.ForeColor = System.Drawing.Color.Snow;
            this.btnRunBP.Image = global::ALS.Properties.Resources.spstart;
            this.btnRunBP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunBP.Location = new System.Drawing.Point(203, 38);
            this.btnRunBP.Name = "btnRunBP";
            this.btnRunBP.NumberOfPulses = 2;
            this.btnRunBP.PulseColor = System.Drawing.Color.DimGray;
            this.btnRunBP.PulseSpeed = 0.3F;
            this.btnRunBP.PulseWidth = 6;
            this.btnRunBP.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRunBP.Size = new System.Drawing.Size(97, 52);
            this.btnRunBP.TabIndex = 69;
            this.btnRunBP.Tag = "bp";
            this.btnRunBP.Text = "运转";
            this.btnRunBP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunBP.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRunBP.UseVisualStyleBackColor = true;
            this.btnRunBP.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnRunFP
            // 
            this.btnRunFP.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnRunFP.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnRunFP.CornerRadius = 20;
            this.btnRunFP.FocusColor = System.Drawing.Color.Black;
            this.btnRunFP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRunFP.ForeColor = System.Drawing.Color.Snow;
            this.btnRunFP.Image = ((System.Drawing.Image)(resources.GetObject("btnRunFP.Image")));
            this.btnRunFP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunFP.Location = new System.Drawing.Point(203, 101);
            this.btnRunFP.Name = "btnRunFP";
            this.btnRunFP.NumberOfPulses = 2;
            this.btnRunFP.PulseColor = System.Drawing.Color.DimGray;
            this.btnRunFP.PulseSpeed = 0.3F;
            this.btnRunFP.PulseWidth = 6;
            this.btnRunFP.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnRunFP.Size = new System.Drawing.Size(97, 52);
            this.btnRunFP.TabIndex = 69;
            this.btnRunFP.Tag = "fp";
            this.btnRunFP.Text = "运转";
            this.btnRunFP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunFP.UseVisualStyleBackColor = true;
            this.btnRunFP.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnReturn.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnReturn.CornerRadius = 20;
            this.btnReturn.FocusColor = System.Drawing.Color.Black;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.Color.Snow;
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(82, 21);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.PulseColor = System.Drawing.Color.DimGray;
            this.btnReturn.PulseSpeed = 0.3F;
            this.btnReturn.PulseWidth = 6;
            this.btnReturn.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnReturn.Size = new System.Drawing.Size(157, 52);
            this.btnReturn.TabIndex = 68;
            this.btnReturn.Text = "所有阀松开";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Visible = false;
            this.btnReturn.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // ucRecycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.grouper1);
            this.Name = "ucRecycle";
            this.Size = new System.Drawing.Size(790, 604);
            this.Load += new System.EventHandler(this.ucfrmRecycle_Load);
            this.SizeChanged += new System.EventHandler(this.ucfrmRecycle_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecycle)).EndInit();
            this.palCtrlV.ResumeLayout(false);
            this.gboxRecycle.ResumeLayout(false);
            this.grouper1.ResumeLayout(false);
            this.gboxPump.ResumeLayout(false);
            this.gboxPump.PerformLayout();
            this.grouper3.ResumeLayout(false);
            this.grouper2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView dgvRecycle;
        public System.Windows.Forms.Label lblBP;
        public System.Windows.Forms.Label lblRP;
        public System.Windows.Forms.Label lblDP;
        public System.Windows.Forms.Label lblFP;
        public System.Windows.Forms.Label lblCP;
        public System.Windows.Forms.Label lblFP2;
        public System.Windows.Forms.Panel palCtrlV;
        public System.Windows.Forms.CheckBox chkV5;
        public System.Windows.Forms.CheckBox chkV6;
        public System.Windows.Forms.CheckBox chkV4;
        public System.Windows.Forms.CheckBox chkV3;
        public System.Windows.Forms.CheckBox chkV2;
        public System.Windows.Forms.CheckBox chkV1;
        private System.Windows.Forms.Label lblRecycle;
        public PulseButton.PulseButton btnReturn;
        public PulseButton.PulseButton btnRunBP;
        public PulseButton.PulseButton btnRunCP;
        public PulseButton.PulseButton btnRunFP2;
        public PulseButton.PulseButton btnRunRP;
        public PulseButton.PulseButton btnRunDP;
        public PulseButton.PulseButton btnRunFP;
        public CodeVendor.Controls.Grouper gboxRecycle;
        private CodeVendor.Controls.Grouper grouper1;
        public CodeVendor.Controls.Grouper grouper2;
        public CodeVendor.Controls.Grouper grouper3;
        public CodeVendor.Controls.Grouper gboxPump;
    }
}
