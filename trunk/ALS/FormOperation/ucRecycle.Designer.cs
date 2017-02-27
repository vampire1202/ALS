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
            this.groupRecycle = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblRP = new System.Windows.Forms.Label();
            this.lblDP = new System.Windows.Forms.Label();
            this.lblFP = new System.Windows.Forms.Label();
            this.lblBP = new System.Windows.Forms.Label();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRun4 = new System.Windows.Forms.Button();
            this.btnRun3 = new System.Windows.Forms.Button();
            this.btnRun1 = new System.Windows.Forms.Button();
            this.btnRun2 = new System.Windows.Forms.Button();
            this.palP = new System.Windows.Forms.Panel();
            this.uc_ptmp = new ALS.UserCtrl.uc_p();
            this.uc_pven = new ALS.UserCtrl.uc_p();
            this.uc_p2nd = new ALS.UserCtrl.uc_p();
            this.label20 = new System.Windows.Forms.Label();
            this.uc_pacc = new ALS.UserCtrl.uc_p();
            this.uc_p1st = new ALS.UserCtrl.uc_p();
            this.uc_part = new ALS.UserCtrl.uc_p();
            this.gboxRecycle = new System.Windows.Forms.GroupBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.lblFP2 = new System.Windows.Forms.Label();
            this.btnRun5 = new System.Windows.Forms.Button();
            this.btnRun6 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvRecycle = new System.Windows.Forms.DataGridView();
            this.groupRecycle.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.palP.SuspendLayout();
            this.gboxRecycle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecycle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupRecycle
            // 
            this.groupRecycle.Controls.Add(this.groupBox3);
            this.groupRecycle.Controls.Add(this.palP);
            this.groupRecycle.Controls.Add(this.gboxRecycle);
            this.groupRecycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRecycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupRecycle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.groupRecycle.Location = new System.Drawing.Point(0, 0);
            this.groupRecycle.Name = "groupRecycle";
            this.groupRecycle.Size = new System.Drawing.Size(898, 532);
            this.groupRecycle.TabIndex = 5;
            this.groupRecycle.TabStop = false;
            this.groupRecycle.Text = "回收";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblRP);
            this.groupBox3.Controls.Add(this.lblDP);
            this.groupBox3.Controls.Add(this.lblFP);
            this.groupBox3.Controls.Add(this.lblBP);
            this.groupBox3.Controls.Add(this.btnCloseAll);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnRun4);
            this.groupBox3.Controls.Add(this.btnRun3);
            this.groupBox3.Controls.Add(this.btnRun1);
            this.groupBox3.Controls.Add(this.btnRun2);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.groupBox3.Location = new System.Drawing.Point(540, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 388);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "回收操作(泵速单位:mL/min)";
            // 
            // lblRP
            // 
            this.lblRP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRP.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRP.Location = new System.Drawing.Point(110, 242);
            this.lblRP.Name = "lblRP";
            this.lblRP.Size = new System.Drawing.Size(118, 48);
            this.lblRP.TabIndex = 31;
            this.lblRP.Tag = "RP";
            this.lblRP.Text = "0.0";
            this.lblRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // lblDP
            // 
            this.lblDP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDP.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDP.Location = new System.Drawing.Point(110, 172);
            this.lblDP.Name = "lblDP";
            this.lblDP.Size = new System.Drawing.Size(118, 48);
            this.lblDP.TabIndex = 31;
            this.lblDP.Tag = "DP";
            this.lblDP.Text = "0.0";
            this.lblDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // lblFP
            // 
            this.lblFP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFP.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFP.Location = new System.Drawing.Point(110, 102);
            this.lblFP.Name = "lblFP";
            this.lblFP.Size = new System.Drawing.Size(118, 48);
            this.lblFP.TabIndex = 31;
            this.lblFP.Tag = "FP";
            this.lblFP.Text = "0.0";
            this.lblFP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // lblBP
            // 
            this.lblBP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBP.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBP.Location = new System.Drawing.Point(110, 32);
            this.lblBP.Name = "lblBP";
            this.lblBP.Size = new System.Drawing.Size(118, 48);
            this.lblBP.TabIndex = 31;
            this.lblBP.Tag = "BP";
            this.lblBP.Text = "30.0";
            this.lblBP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseAll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnCloseAll.Location = new System.Drawing.Point(232, 332);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(108, 50);
            this.btnCloseAll.TabIndex = 12;
            this.btnCloseAll.Text = "所有阀\r\n松开";
            this.btnCloseAll.UseVisualStyleBackColor = false;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(249, 308);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 21);
            this.label13.TabIndex = 11;
            this.label13.Text = "废弃管路";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(22, 256);
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
            this.label14.Location = new System.Drawing.Point(4, 186);
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
            this.label7.Location = new System.Drawing.Point(23, 116);
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
            this.label5.Location = new System.Drawing.Point(22, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "血液泵BP:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRun4
            // 
            this.btnRun4.BackColor = System.Drawing.Color.Transparent;
            this.btnRun4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnRun4.Image = global::ALS.Properties.Resources.spstart;
            this.btnRun4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun4.Location = new System.Drawing.Point(232, 241);
            this.btnRun4.Name = "btnRun4";
            this.btnRun4.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRun4.Size = new System.Drawing.Size(108, 50);
            this.btnRun4.TabIndex = 15;
            this.btnRun4.Tag = "4";
            this.btnRun4.Text = "运转";
            this.btnRun4.UseVisualStyleBackColor = false;
            this.btnRun4.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnRun3
            // 
            this.btnRun3.BackColor = System.Drawing.Color.Transparent;
            this.btnRun3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnRun3.Image = global::ALS.Properties.Resources.spstart;
            this.btnRun3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun3.Location = new System.Drawing.Point(232, 171);
            this.btnRun3.Name = "btnRun3";
            this.btnRun3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRun3.Size = new System.Drawing.Size(108, 50);
            this.btnRun3.TabIndex = 24;
            this.btnRun3.Tag = "3";
            this.btnRun3.Text = "运转";
            this.btnRun3.UseVisualStyleBackColor = false;
            this.btnRun3.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnRun1
            // 
            this.btnRun1.BackColor = System.Drawing.Color.Transparent;
            this.btnRun1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnRun1.Image = global::ALS.Properties.Resources.spstart;
            this.btnRun1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun1.Location = new System.Drawing.Point(232, 31);
            this.btnRun1.Name = "btnRun1";
            this.btnRun1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRun1.Size = new System.Drawing.Size(108, 50);
            this.btnRun1.TabIndex = 24;
            this.btnRun1.Tag = "1";
            this.btnRun1.Text = "运转";
            this.btnRun1.UseVisualStyleBackColor = false;
            this.btnRun1.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnRun2
            // 
            this.btnRun2.BackColor = System.Drawing.Color.Transparent;
            this.btnRun2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnRun2.Image = global::ALS.Properties.Resources.spstart;
            this.btnRun2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun2.Location = new System.Drawing.Point(232, 101);
            this.btnRun2.Name = "btnRun2";
            this.btnRun2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRun2.Size = new System.Drawing.Size(108, 50);
            this.btnRun2.TabIndex = 9;
            this.btnRun2.Tag = "2";
            this.btnRun2.Text = "运转";
            this.btnRun2.UseVisualStyleBackColor = false;
            this.btnRun2.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // palP
            // 
            this.palP.BackColor = System.Drawing.Color.Transparent;
            this.palP.Controls.Add(this.uc_ptmp);
            this.palP.Controls.Add(this.uc_pven);
            this.palP.Controls.Add(this.uc_p2nd);
            this.palP.Controls.Add(this.label20);
            this.palP.Controls.Add(this.uc_pacc);
            this.palP.Controls.Add(this.uc_p1st);
            this.palP.Controls.Add(this.uc_part);
            this.palP.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.palP.Location = new System.Drawing.Point(53, 40);
            this.palP.Name = "palP";
            this.palP.Size = new System.Drawing.Size(801, 92);
            this.palP.TabIndex = 31;
            // 
            // uc_ptmp
            // 
            this.uc_ptmp._LineColor = System.Drawing.Color.DeepPink;
            this.uc_ptmp._Lower = "-100.0";
            this.uc_ptmp._Title = "TMP";
            this.uc_ptmp._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_ptmp._Upper = "-100.0";
            this.uc_ptmp._Value = "-155.0";
            this.uc_ptmp._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_ptmp._VisibleLeft = true;
            this.uc_ptmp.BackColor = System.Drawing.Color.Transparent;
            this.uc_ptmp.Location = new System.Drawing.Point(422, 11);
            this.uc_ptmp.Name = "uc_ptmp";
            this.uc_ptmp.Size = new System.Drawing.Size(107, 65);
            this.uc_ptmp.TabIndex = 2;
            // 
            // uc_pven
            // 
            this.uc_pven._LineColor = System.Drawing.Color.DodgerBlue;
            this.uc_pven._Lower = "-100.0";
            this.uc_pven._Title = "静脉Pven";
            this.uc_pven._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_pven._Upper = "-100.0";
            this.uc_pven._Value = "-155.0";
            this.uc_pven._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_pven._VisibleLeft = true;
            this.uc_pven.BackColor = System.Drawing.Color.Transparent;
            this.uc_pven.Location = new System.Drawing.Point(296, 11);
            this.uc_pven.Name = "uc_pven";
            this.uc_pven.Size = new System.Drawing.Size(107, 65);
            this.uc_pven.TabIndex = 2;
            // 
            // uc_p2nd
            // 
            this.uc_p2nd._LineColor = System.Drawing.Color.DarkOrange;
            this.uc_p2nd._Lower = "-100.0";
            this.uc_p2nd._Title = "入口P2nd";
            this.uc_p2nd._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_p2nd._Upper = "-100.0";
            this.uc_p2nd._Value = "-155.0";
            this.uc_p2nd._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_p2nd._VisibleLeft = true;
            this.uc_p2nd.BackColor = System.Drawing.Color.Transparent;
            this.uc_p2nd.Location = new System.Drawing.Point(674, 11);
            this.uc_p2nd.Name = "uc_p2nd";
            this.uc_p2nd.Size = new System.Drawing.Size(107, 65);
            this.uc_p2nd.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(3, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 36);
            this.label20.TabIndex = 1;
            this.label20.Text = "压力\r\n\r\n[mmHg]";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uc_pacc
            // 
            this.uc_pacc._LineColor = System.Drawing.Color.Maroon;
            this.uc_pacc._Lower = "-100";
            this.uc_pacc._Title = "采血Pacc";
            this.uc_pacc._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_pacc._Upper = "500";
            this.uc_pacc._Value = "-155.0";
            this.uc_pacc._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_pacc._VisibleLeft = true;
            this.uc_pacc.BackColor = System.Drawing.Color.Transparent;
            this.uc_pacc.Location = new System.Drawing.Point(44, 11);
            this.uc_pacc.Name = "uc_pacc";
            this.uc_pacc.Size = new System.Drawing.Size(107, 65);
            this.uc_pacc.TabIndex = 2;
            // 
            // uc_p1st
            // 
            this.uc_p1st._LineColor = System.Drawing.Color.Lime;
            this.uc_p1st._Lower = "-100.0";
            this.uc_p1st._Title = "血浆P1st";
            this.uc_p1st._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_p1st._Upper = "-100.0";
            this.uc_p1st._Value = "-155.0";
            this.uc_p1st._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_p1st._VisibleLeft = true;
            this.uc_p1st.BackColor = System.Drawing.Color.Transparent;
            this.uc_p1st.Location = new System.Drawing.Point(548, 11);
            this.uc_p1st.Name = "uc_p1st";
            this.uc_p1st.Size = new System.Drawing.Size(107, 65);
            this.uc_p1st.TabIndex = 2;
            // 
            // uc_part
            // 
            this.uc_part._LineColor = System.Drawing.Color.Red;
            this.uc_part._Lower = "-100.0";
            this.uc_part._Title = "动脉Part";
            this.uc_part._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_part._Upper = "-100.0";
            this.uc_part._Value = "-155.0";
            this.uc_part._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_part._VisibleLeft = true;
            this.uc_part.BackColor = System.Drawing.Color.Transparent;
            this.uc_part.Location = new System.Drawing.Point(170, 11);
            this.uc_part.Name = "uc_part";
            this.uc_part.Size = new System.Drawing.Size(107, 65);
            this.uc_part.TabIndex = 2;
            // 
            // gboxRecycle
            // 
            this.gboxRecycle.Controls.Add(this.lblCP);
            this.gboxRecycle.Controls.Add(this.lblFP2);
            this.gboxRecycle.Controls.Add(this.btnRun5);
            this.gboxRecycle.Controls.Add(this.btnRun6);
            this.gboxRecycle.Controls.Add(this.label18);
            this.gboxRecycle.Controls.Add(this.label19);
            this.gboxRecycle.Controls.Add(this.dgvRecycle);
            this.gboxRecycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gboxRecycle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.gboxRecycle.Location = new System.Drawing.Point(10, 137);
            this.gboxRecycle.Name = "gboxRecycle";
            this.gboxRecycle.Size = new System.Drawing.Size(524, 388);
            this.gboxRecycle.TabIndex = 15;
            this.gboxRecycle.TabStop = false;
            this.gboxRecycle.Text = "PE回收方法,请参照以下步骤回收";
            // 
            // lblCP
            // 
            this.lblCP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCP.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCP.Location = new System.Drawing.Point(220, 271);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(69, 36);
            this.lblCP.TabIndex = 31;
            this.lblCP.Text = "0.0";
            this.lblCP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCP.Visible = false;
            // 
            // lblFP2
            // 
            this.lblFP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFP2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFP2.Location = new System.Drawing.Point(220, 221);
            this.lblFP2.Name = "lblFP2";
            this.lblFP2.Size = new System.Drawing.Size(69, 36);
            this.lblFP2.TabIndex = 31;
            this.lblFP2.Text = "0.0";
            this.lblFP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFP2.Visible = false;
            // 
            // btnRun5
            // 
            this.btnRun5.BackColor = System.Drawing.Color.Transparent;
            this.btnRun5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnRun5.Image = global::ALS.Properties.Resources.spstart;
            this.btnRun5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun5.Location = new System.Drawing.Point(295, 219);
            this.btnRun5.Name = "btnRun5";
            this.btnRun5.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRun5.Size = new System.Drawing.Size(86, 40);
            this.btnRun5.TabIndex = 24;
            this.btnRun5.Tag = "5";
            this.btnRun5.Text = "运转";
            this.btnRun5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun5.UseVisualStyleBackColor = false;
            this.btnRun5.Visible = false;
            this.btnRun5.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // btnRun6
            // 
            this.btnRun6.BackColor = System.Drawing.Color.Transparent;
            this.btnRun6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnRun6.Image = global::ALS.Properties.Resources.spstart;
            this.btnRun6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun6.Location = new System.Drawing.Point(295, 269);
            this.btnRun6.Name = "btnRun6";
            this.btnRun6.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRun6.Size = new System.Drawing.Size(86, 40);
            this.btnRun6.TabIndex = 24;
            this.btnRun6.Tag = "6";
            this.btnRun6.Text = "运转";
            this.btnRun6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun6.UseVisualStyleBackColor = false;
            this.btnRun6.Visible = false;
            this.btnRun6.Click += new System.EventHandler(this.btnRunBP_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(122, 229);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 21);
            this.label18.TabIndex = 26;
            this.label18.Text = "滤过泵FP2:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label18.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(129, 279);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 21);
            this.label19.TabIndex = 26;
            this.label19.Text = "循环泵CP:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Visible = false;
            // 
            // dgvRecycle
            // 
            this.dgvRecycle.AllowUserToAddRows = false;
            this.dgvRecycle.AllowUserToDeleteRows = false;
            this.dgvRecycle.AllowUserToResizeColumns = false;
            this.dgvRecycle.AllowUserToResizeRows = false;
            this.dgvRecycle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRecycle.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvRecycle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRecycle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecycle.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecycle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecycle.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvRecycle.Location = new System.Drawing.Point(3, 25);
            this.dgvRecycle.MultiSelect = false;
            this.dgvRecycle.Name = "dgvRecycle";
            this.dgvRecycle.ReadOnly = true;
            this.dgvRecycle.RowHeadersVisible = false;
            this.dgvRecycle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRecycle.RowTemplate.Height = 23;
            this.dgvRecycle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecycle.Size = new System.Drawing.Size(518, 360);
            this.dgvRecycle.TabIndex = 20;
            // 
            // ucRecycle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.groupRecycle);
            this.Name = "ucRecycle";
            this.Size = new System.Drawing.Size(898, 532);
            this.Load += new System.EventHandler(this.ucfrmRecycle_Load);
            this.SizeChanged += new System.EventHandler(this.ucfrmRecycle_SizeChanged);
            this.groupRecycle.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.palP.ResumeLayout(false);
            this.palP.PerformLayout();
            this.gboxRecycle.ResumeLayout(false);
            this.gboxRecycle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecycle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRecycle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCloseAll;
        public System.Windows.Forms.Button btnRun2;
        public System.Windows.Forms.Button btnRun4;
        public System.Windows.Forms.Button btnRun1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnRun5;
        public System.Windows.Forms.Button btnRun6;
        public System.Windows.Forms.Button btnRun3;
        private System.Windows.Forms.Panel palP;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox3;
        public UserCtrl.uc_p uc_ptmp;
        public UserCtrl.uc_p uc_pven;
        public UserCtrl.uc_p uc_p2nd;
        public UserCtrl.uc_p uc_pacc;
        public UserCtrl.uc_p uc_p1st;
        public UserCtrl.uc_p uc_part;
        public System.Windows.Forms.DataGridView dgvRecycle;
        public System.Windows.Forms.GroupBox gboxRecycle;
        public System.Windows.Forms.Label lblBP;
        public System.Windows.Forms.Label lblRP;
        public System.Windows.Forms.Label lblDP;
        public System.Windows.Forms.Label lblFP;
        public System.Windows.Forms.Label lblCP;
        public System.Windows.Forms.Label lblFP2;
    }
}
