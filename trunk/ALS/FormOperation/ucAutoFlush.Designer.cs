namespace ALS.FormOperation
{
    partial class ucAutoFlush
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.palP = new System.Windows.Forms.Panel();
            this.uc_ptmp = new ALS.UserCtrl.uc_p();
            this.uc_pven = new ALS.UserCtrl.uc_p();
            this.uc_p2nd = new ALS.UserCtrl.uc_p();
            this.label20 = new System.Windows.Forms.Label();
            this.uc_pacc = new ALS.UserCtrl.uc_p();
            this.uc_p1st = new ALS.UserCtrl.uc_p();
            this.uc_part = new ALS.UserCtrl.uc_p();
            this.dgvStep = new System.Windows.Forms.DataGridView();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnAddFlush = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFullTime = new System.Windows.Forms.Label();
            this.lblRequire = new System.Windows.Forms.Label();
            this.timerFlush = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.palP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.palP);
            this.groupBox1.Controls.Add(this.dgvStep);
            this.groupBox1.Controls.Add(this.btnContinue);
            this.groupBox1.Controls.Add(this.btnReturn);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.btnAddFlush);
            this.groupBox1.Controls.Add(this.btnFinish);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblFullTime);
            this.groupBox1.Controls.Add(this.lblRequire);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 578);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动预冲";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label3.Location = new System.Drawing.Point(156, 550);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(588, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = " ② 追加预冲功能只能选择单个步骤进行 , 持续时间为该步骤自动预冲时的时间，可随时停止；";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(69, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "追加预冲说明: ① 只有在自动预冲完成后才能使用;";
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
            this.palP.TabIndex = 32;
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
            // dgvStep
            // 
            this.dgvStep.AllowUserToAddRows = false;
            this.dgvStep.AllowUserToDeleteRows = false;
            this.dgvStep.AllowUserToResizeColumns = false;
            this.dgvStep.AllowUserToResizeRows = false;
            this.dgvStep.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStep.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvStep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStep.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStep.Enabled = false;
            this.dgvStep.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvStep.Location = new System.Drawing.Point(178, 208);
            this.dgvStep.MultiSelect = false;
            this.dgvStep.Name = "dgvStep";
            this.dgvStep.ReadOnly = true;
            this.dgvStep.RowHeadersVisible = false;
            this.dgvStep.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStep.RowTemplate.Height = 23;
            this.dgvStep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStep.Size = new System.Drawing.Size(677, 314);
            this.dgvStep.TabIndex = 19;
            this.dgvStep.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStep_CellClick);
            this.dgvStep.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStep_CellContentClick);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnContinue.Enabled = false;
            this.btnContinue.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnContinue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnContinue.Location = new System.Drawing.Point(54, 293);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(118, 58);
            this.btnContinue.TabIndex = 17;
            this.btnContinue.Text = "暂停";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnReturn.Location = new System.Drawing.Point(738, 146);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(118, 58);
            this.btnReturn.TabIndex = 7;
            this.btnReturn.Text = "返回选择";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnStart.Location = new System.Drawing.Point(54, 207);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 58);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "预冲开始";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblTime.Location = new System.Drawing.Point(127, 149);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(50, 21);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "00:00";
            // 
            // btnAddFlush
            // 
            this.btnAddFlush.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFlush.Enabled = false;
            this.btnAddFlush.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddFlush.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnAddFlush.Location = new System.Drawing.Point(54, 465);
            this.btnAddFlush.Name = "btnAddFlush";
            this.btnAddFlush.Size = new System.Drawing.Size(118, 58);
            this.btnAddFlush.TabIndex = 17;
            this.btnAddFlush.Text = "追加预冲";
            this.btnAddFlush.UseVisualStyleBackColor = false;
            this.btnAddFlush.Click += new System.EventHandler(this.btnAddFlush_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.Transparent;
            this.btnFinish.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnFinish.Location = new System.Drawing.Point(54, 379);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(118, 58);
            this.btnFinish.TabIndex = 17;
            this.btnFinish.Text = "预冲完成";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(50, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "预计时间:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label13.Location = new System.Drawing.Point(50, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 20);
            this.label13.TabIndex = 14;
            this.label13.Text = "已用时间:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label8.Location = new System.Drawing.Point(97, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "必 要 量:";
            this.label8.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label10.Location = new System.Drawing.Point(251, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "ml";
            this.label10.Visible = false;
            // 
            // lblFullTime
            // 
            this.lblFullTime.AutoSize = true;
            this.lblFullTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFullTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblFullTime.Location = new System.Drawing.Point(127, 177);
            this.lblFullTime.Name = "lblFullTime";
            this.lblFullTime.Size = new System.Drawing.Size(63, 20);
            this.lblFullTime.TabIndex = 12;
            this.lblFullTime.Text = "00:00:00";
            // 
            // lblRequire
            // 
            this.lblRequire.AutoSize = true;
            this.lblRequire.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRequire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblRequire.Location = new System.Drawing.Point(174, 125);
            this.lblRequire.Name = "lblRequire";
            this.lblRequire.Size = new System.Drawing.Size(41, 20);
            this.lblRequire.TabIndex = 12;
            this.lblRequire.Text = "1600";
            this.lblRequire.Visible = false;
            // 
            // timerFlush
            // 
            this.timerFlush.Interval = 1000;
            this.timerFlush.Tick += new System.EventHandler(this.timerFlush_Tick);
            // 
            // ucAutoFlush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ucAutoFlush";
            this.Size = new System.Drawing.Size(898, 578);
            this.Load += new System.EventHandler(this.af_custom_Load);
            this.SizeChanged += new System.EventHandler(this.af_custom_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.palP.ResumeLayout(false);
            this.palP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnContinue;
        public System.Windows.Forms.Button btnReturn;
        public System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblFullTime;
        public System.Windows.Forms.Label lblRequire;
        private System.Windows.Forms.Panel palP;
        private System.Windows.Forms.Label label20;
        public UserCtrl.uc_p uc_ptmp;
        public UserCtrl.uc_p uc_pven;
        public UserCtrl.uc_p uc_p2nd;
        public UserCtrl.uc_p uc_pacc;
        public UserCtrl.uc_p uc_p1st;
        public UserCtrl.uc_p uc_part;
        public System.Windows.Forms.Button btnAddFlush;
        public System.Windows.Forms.DataGridView dgvStep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerFlush;
    }
}
