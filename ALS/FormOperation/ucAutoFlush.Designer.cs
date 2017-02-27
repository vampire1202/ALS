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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblFullTime = new System.Windows.Forms.Label();
            this.lblRequire = new System.Windows.Forms.Label();
            this.dgvStep = new System.Windows.Forms.DataGridView();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.btnReturn = new CCWin.SkinControl.SkinButton();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.pboxFlush = new System.Windows.Forms.PictureBox();
            this.btnAddFlush = new CCWin.SkinControl.SkinButton();
            this.btnFinish = new CCWin.SkinControl.SkinButton();
            this.btnContinue = new CCWin.SkinControl.SkinButton();
            this.btnStart = new CCWin.SkinControl.SkinButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep)).BeginInit();
            this.skinGroupBox1.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFlush)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblTime.Location = new System.Drawing.Point(29, 106);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(72, 21);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(31, 41);
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
            this.label13.Location = new System.Drawing.Point(31, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 20);
            this.label13.TabIndex = 14;
            this.label13.Text = "已用时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(532, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "当前量(mL):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label8.Location = new System.Drawing.Point(396, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "必要量(mL):";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblCurrent.Location = new System.Drawing.Point(619, 26);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(17, 20);
            this.lblCurrent.TabIndex = 12;
            this.lblCurrent.Text = "0";
            // 
            // lblFullTime
            // 
            this.lblFullTime.AutoSize = true;
            this.lblFullTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFullTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblFullTime.Location = new System.Drawing.Point(29, 61);
            this.lblFullTime.Name = "lblFullTime";
            this.lblFullTime.Size = new System.Drawing.Size(72, 21);
            this.lblFullTime.TabIndex = 12;
            this.lblFullTime.Text = "00:00:00";
            // 
            // lblRequire
            // 
            this.lblRequire.AutoSize = true;
            this.lblRequire.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRequire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblRequire.Location = new System.Drawing.Point(478, 26);
            this.lblRequire.Name = "lblRequire";
            this.lblRequire.Size = new System.Drawing.Size(41, 20);
            this.lblRequire.TabIndex = 12;
            this.lblRequire.Text = "1600";
            // 
            // dgvStep
            // 
            this.dgvStep.AllowUserToAddRows = false;
            this.dgvStep.AllowUserToDeleteRows = false;
            this.dgvStep.AllowUserToResizeColumns = false;
            this.dgvStep.AllowUserToResizeRows = false;
            this.dgvStep.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvStep.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvStep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStep.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvStep.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStep.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvStep.Enabled = false;
            this.dgvStep.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvStep.Location = new System.Drawing.Point(3, 22);
            this.dgvStep.MultiSelect = false;
            this.dgvStep.Name = "dgvStep";
            this.dgvStep.ReadOnly = true;
            this.dgvStep.RowHeadersVisible = false;
            this.dgvStep.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvStep.RowTemplate.Height = 25;
            this.dgvStep.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStep.Size = new System.Drawing.Size(658, 203);
            this.dgvStep.TabIndex = 19;
            this.dgvStep.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStep_CellClick);
            this.dgvStep.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStep_CellContentClick);
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox1.Controls.Add(this.skinLabel1);
            this.skinGroupBox1.Controls.Add(this.btnReturn);
            this.skinGroupBox1.Controls.Add(this.skinGroupBox2);
            this.skinGroupBox1.Controls.Add(this.btnAddFlush);
            this.skinGroupBox1.Controls.Add(this.btnFinish);
            this.skinGroupBox1.Controls.Add(this.btnContinue);
            this.skinGroupBox1.Controls.Add(this.btnStart);
            this.skinGroupBox1.Controls.Add(this.label13);
            this.skinGroupBox1.Controls.Add(this.lblRequire);
            this.skinGroupBox1.Controls.Add(this.lblFullTime);
            this.skinGroupBox1.Controls.Add(this.lblTime);
            this.skinGroupBox1.Controls.Add(this.lblCurrent);
            this.skinGroupBox1.Controls.Add(this.label2);
            this.skinGroupBox1.Controls.Add(this.label8);
            this.skinGroupBox1.Controls.Add(this.label1);
            this.skinGroupBox1.Controls.Add(this.label5);
            this.skinGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.skinGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.Radius = 20;
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(790, 604);
            this.skinGroupBox1.TabIndex = 33;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "自动预冲";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox1.TitleRadius = 20;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.Right;
            // 
            // skinLabel1
            // 
            this.skinLabel1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(10, 442);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(107, 154);
            this.skinLabel1.TabIndex = 40;
            this.skinLabel1.Text = "追加预冲说明:\r\n    ① 只有在自动预冲完成后才能使用;\r\n    ② 追加预冲功能只能选择单个步骤进行 , 持续时间为该步骤自动预冲时的时间；";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnReturn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnReturn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnReturn.DownBack = null;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(684, 18);
            this.btnReturn.MouseBack = null;
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.NormlBack = null;
            this.btnReturn.Radius = 40;
            this.btnReturn.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnReturn.Size = new System.Drawing.Size(100, 40);
            this.btnReturn.TabIndex = 37;
            this.btnReturn.Text = "返回选择";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox2.Controls.Add(this.pboxFlush);
            this.skinGroupBox2.Controls.Add(this.dgvStep);
            this.skinGroupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.skinGroupBox2.Location = new System.Drawing.Point(120, 49);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.Radius = 20;
            this.skinGroupBox2.RectBackColor = System.Drawing.SystemColors.ButtonFace;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.Size = new System.Drawing.Size(664, 550);
            this.skinGroupBox2.TabIndex = 39;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "预冲步骤";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // pboxFlush
            // 
            this.pboxFlush.BackColor = System.Drawing.Color.Transparent;
            this.pboxFlush.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxFlush.Location = new System.Drawing.Point(3, 225);
            this.pboxFlush.Name = "pboxFlush";
            this.pboxFlush.Size = new System.Drawing.Size(658, 322);
            this.pboxFlush.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxFlush.TabIndex = 38;
            this.pboxFlush.TabStop = false;
            // 
            // btnAddFlush
            // 
            this.btnAddFlush.BackColor = System.Drawing.Color.Transparent;
            this.btnAddFlush.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnAddFlush.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnAddFlush.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAddFlush.DownBack = null;
            this.btnAddFlush.Enabled = false;
            this.btnAddFlush.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddFlush.ForeColor = System.Drawing.Color.White;
            this.btnAddFlush.Location = new System.Drawing.Point(14, 375);
            this.btnAddFlush.MouseBack = null;
            this.btnAddFlush.Name = "btnAddFlush";
            this.btnAddFlush.NormlBack = null;
            this.btnAddFlush.Radius = 50;
            this.btnAddFlush.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnAddFlush.Size = new System.Drawing.Size(100, 50);
            this.btnAddFlush.TabIndex = 37;
            this.btnAddFlush.Text = "追加预冲";
            this.btnAddFlush.UseVisualStyleBackColor = false;
            this.btnAddFlush.Click += new System.EventHandler(this.btnAddFlush_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.Transparent;
            this.btnFinish.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnFinish.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnFinish.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnFinish.DownBack = null;
            this.btnFinish.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(14, 295);
            this.btnFinish.MouseBack = null;
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.NormlBack = null;
            this.btnFinish.Radius = 50;
            this.btnFinish.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnFinish.Size = new System.Drawing.Size(100, 50);
            this.btnFinish.TabIndex = 37;
            this.btnFinish.Text = "预冲完成";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Transparent;
            this.btnContinue.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnContinue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnContinue.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnContinue.DownBack = null;
            this.btnContinue.Enabled = false;
            this.btnContinue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(14, 215);
            this.btnContinue.MouseBack = null;
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.NormlBack = null;
            this.btnContinue.Radius = 50;
            this.btnContinue.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnContinue.Size = new System.Drawing.Size(100, 50);
            this.btnContinue.TabIndex = 37;
            this.btnContinue.Text = "暂停";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnStart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnStart.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnStart.DownBack = null;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(14, 135);
            this.btnStart.MouseBack = null;
            this.btnStart.Name = "btnStart";
            this.btnStart.NormlBack = null;
            this.btnStart.Radius = 50;
            this.btnStart.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnStart.Size = new System.Drawing.Size(100, 50);
            this.btnStart.TabIndex = 37;
            this.btnStart.Text = "开始预冲";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(210, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "肝素化生理盐水(mL): 500";
            // 
            // ucAutoFlush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinGroupBox1);
            this.Name = "ucAutoFlush";
            this.Size = new System.Drawing.Size(790, 604);
            this.Load += new System.EventHandler(this.af_custom_Load);
            this.SizeChanged += new System.EventHandler(this.af_custom_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep)).EndInit();
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.PerformLayout();
            this.skinGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxFlush)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblFullTime;
        public System.Windows.Forms.Label lblRequire;
        public System.Windows.Forms.DataGridView dgvStep;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblCurrent;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        public CCWin.SkinControl.SkinButton btnStart;
        public CCWin.SkinControl.SkinButton btnReturn;
        public CCWin.SkinControl.SkinButton btnAddFlush;
        public CCWin.SkinControl.SkinButton btnFinish;
        public CCWin.SkinControl.SkinButton btnContinue;
        public System.Windows.Forms.PictureBox pboxFlush;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.Label label2;
    }
}
