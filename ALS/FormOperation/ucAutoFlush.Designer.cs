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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblFullTime = new System.Windows.Forms.Label();
            this.lblRequire = new System.Windows.Forms.Label();
            this.dgvStep = new System.Windows.Forms.DataGridView();
            this.pboxFlush = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grouper2 = new CodeVendor.Controls.Grouper();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStart = new PulseButton.PulseButton();
            this.btnContinue = new PulseButton.PulseButton();
            this.btnFinish = new PulseButton.PulseButton();
            this.btnAddFlush = new PulseButton.PulseButton();
            this.btnReturn = new PulseButton.PulseButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFlush)).BeginInit();
            this.grouper2.SuspendLayout();
            this.grouper1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblTime.Location = new System.Drawing.Point(23, 111);
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
            this.label1.Location = new System.Drawing.Point(25, 46);
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
            this.label13.Location = new System.Drawing.Point(25, 91);
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
            this.label5.Location = new System.Drawing.Point(534, 31);
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
            this.label8.Location = new System.Drawing.Point(390, 31);
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
            this.lblCurrent.Location = new System.Drawing.Point(614, 31);
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
            this.lblFullTime.Location = new System.Drawing.Point(23, 66);
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
            this.lblRequire.Location = new System.Drawing.Point(480, 31);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStep.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStep.Enabled = false;
            this.dgvStep.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvStep.Location = new System.Drawing.Point(2, 25);
            this.dgvStep.MultiSelect = false;
            this.dgvStep.Name = "dgvStep";
            this.dgvStep.ReadOnly = true;
            this.dgvStep.RowHeadersVisible = false;
            this.dgvStep.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvStep.RowTemplate.Height = 25;
            this.dgvStep.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStep.Size = new System.Drawing.Size(665, 199);
            this.dgvStep.TabIndex = 19;
            this.dgvStep.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStep_CellClick);
            this.dgvStep.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStep_CellContentClick);
            // 
            // pboxFlush
            // 
            this.pboxFlush.BackColor = System.Drawing.Color.Transparent;
            this.pboxFlush.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pboxFlush.Location = new System.Drawing.Point(2, 224);
            this.pboxFlush.Name = "pboxFlush";
            this.pboxFlush.Size = new System.Drawing.Size(665, 322);
            this.pboxFlush.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pboxFlush.TabIndex = 38;
            this.pboxFlush.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(204, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "肝素化生理盐水(mL): 500";
            // 
            // grouper2
            // 
            this.grouper2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grouper2.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper2.BorderColor = System.Drawing.Color.Silver;
            this.grouper2.BorderThickness = 1F;
            this.grouper2.Controls.Add(this.dgvStep);
            this.grouper2.Controls.Add(this.pboxFlush);
            this.grouper2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grouper2.GroupImage = null;
            this.grouper2.GroupTitle = "预冲步骤";
            this.grouper2.Location = new System.Drawing.Point(117, 54);
            this.grouper2.Name = "grouper2";
            this.grouper2.Padding = new System.Windows.Forms.Padding(2, 25, 3, 3);
            this.grouper2.PaintGroupBox = true;
            this.grouper2.RoundCorners = 10;
            this.grouper2.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper2.ShadowControl = false;
            this.grouper2.ShadowThickness = 3;
            this.grouper2.Size = new System.Drawing.Size(670, 549);
            this.grouper2.TabIndex = 65;
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper1.BorderColor = System.Drawing.Color.Silver;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.btnReturn);
            this.grouper1.Controls.Add(this.btnAddFlush);
            this.grouper1.Controls.Add(this.textBox1);
            this.grouper1.Controls.Add(this.btnFinish);
            this.grouper1.Controls.Add(this.grouper2);
            this.grouper1.Controls.Add(this.btnContinue);
            this.grouper1.Controls.Add(this.lblRequire);
            this.grouper1.Controls.Add(this.btnStart);
            this.grouper1.Controls.Add(this.label5);
            this.grouper1.Controls.Add(this.label1);
            this.grouper1.Controls.Add(this.label8);
            this.grouper1.Controls.Add(this.label2);
            this.grouper1.Controls.Add(this.lblCurrent);
            this.grouper1.Controls.Add(this.lblTime);
            this.grouper1.Controls.Add(this.lblFullTime);
            this.grouper1.Controls.Add(this.label13);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouper1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grouper1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "自动预冲";
            this.grouper1.Location = new System.Drawing.Point(0, 0);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(2, 25, 3, 3);
            this.grouper1.PaintGroupBox = true;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(790, 604);
            this.grouper1.TabIndex = 66;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.textBox1.Location = new System.Drawing.Point(4, 431);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(110, 171);
            this.textBox1.TabIndex = 39;
            this.textBox1.Text = "追加预冲说明:\r\n    ① 只有在自动预冲完成后才能使用;\r\n    ② 追加预冲功能只能选择单个步骤进行 , 持续时间为该步骤自动预冲时的时间；";
            // 
            // btnStart
            // 
            this.btnStart.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnStart.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnStart.CornerRadius = 25;
            this.btnStart.FocusColor = System.Drawing.Color.Black;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.Color.Snow;
            this.btnStart.Location = new System.Drawing.Point(3, 135);
            this.btnStart.Name = "btnStart";
            this.btnStart.PulseColor = System.Drawing.Color.DimGray;
            this.btnStart.PulseSpeed = 0.3F;
            this.btnStart.PulseWidth = 6;
            this.btnStart.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnStart.Size = new System.Drawing.Size(112, 62);
            this.btnStart.TabIndex = 66;
            this.btnStart.Text = "开始预冲";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnContinue.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnContinue.CornerRadius = 25;
            this.btnContinue.FocusColor = System.Drawing.Color.Black;
            this.btnContinue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnContinue.ForeColor = System.Drawing.Color.Snow;
            this.btnContinue.Location = new System.Drawing.Point(3, 211);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.PulseColor = System.Drawing.Color.DimGray;
            this.btnContinue.PulseSpeed = 0.3F;
            this.btnContinue.PulseWidth = 6;
            this.btnContinue.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnContinue.Size = new System.Drawing.Size(112, 62);
            this.btnContinue.TabIndex = 66;
            this.btnContinue.Text = "暂停";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnFinish.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnFinish.CornerRadius = 25;
            this.btnFinish.FocusColor = System.Drawing.Color.Black;
            this.btnFinish.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFinish.ForeColor = System.Drawing.Color.Snow;
            this.btnFinish.Location = new System.Drawing.Point(3, 287);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.PulseColor = System.Drawing.Color.DimGray;
            this.btnFinish.PulseSpeed = 0.3F;
            this.btnFinish.PulseWidth = 6;
            this.btnFinish.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnFinish.Size = new System.Drawing.Size(112, 62);
            this.btnFinish.TabIndex = 66;
            this.btnFinish.Text = "预冲完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnAddFlush
            // 
            this.btnAddFlush.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnAddFlush.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnAddFlush.CornerRadius = 25;
            this.btnAddFlush.FocusColor = System.Drawing.Color.Black;
            this.btnAddFlush.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddFlush.ForeColor = System.Drawing.Color.Snow;
            this.btnAddFlush.Location = new System.Drawing.Point(3, 363);
            this.btnAddFlush.Name = "btnAddFlush";
            this.btnAddFlush.PulseColor = System.Drawing.Color.DimGray;
            this.btnAddFlush.PulseSpeed = 0.3F;
            this.btnAddFlush.PulseWidth = 6;
            this.btnAddFlush.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnAddFlush.Size = new System.Drawing.Size(112, 62);
            this.btnAddFlush.TabIndex = 66;
            this.btnAddFlush.Text = "追加预冲";
            this.btnAddFlush.UseVisualStyleBackColor = true;
            this.btnAddFlush.Click += new System.EventHandler(this.btnAddFlush_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnReturn.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnReturn.CornerRadius = 20;
            this.btnReturn.FocusColor = System.Drawing.Color.Black;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.Color.Snow;
            this.btnReturn.Location = new System.Drawing.Point(677, 12);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.PulseColor = System.Drawing.Color.DimGray;
            this.btnReturn.PulseSpeed = 0.3F;
            this.btnReturn.PulseWidth = 6;
            this.btnReturn.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnReturn.Size = new System.Drawing.Size(112, 52);
            this.btnReturn.TabIndex = 67;
            this.btnReturn.Text = "返回选择";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // ucAutoFlush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grouper1);
            this.Name = "ucAutoFlush";
            this.Size = new System.Drawing.Size(790, 604);
            this.Load += new System.EventHandler(this.af_custom_Load);
            this.SizeChanged += new System.EventHandler(this.af_custom_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxFlush)).EndInit();
            this.grouper2.ResumeLayout(false);
            this.grouper1.ResumeLayout(false);
            this.grouper1.PerformLayout();
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
        public System.Windows.Forms.PictureBox pboxFlush;
        private System.Windows.Forms.Label label2;
        private CodeVendor.Controls.Grouper grouper2;
        private CodeVendor.Controls.Grouper grouper1;
        private System.Windows.Forms.TextBox textBox1;
        public PulseButton.PulseButton btnReturn;
        public PulseButton.PulseButton btnAddFlush;
        public PulseButton.PulseButton btnFinish;
        public PulseButton.PulseButton btnContinue;
        public PulseButton.PulseButton btnStart;
    }
}
