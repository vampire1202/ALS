namespace ALS.FormOperation
{
    partial class ucSelectFlush
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
            this.palSelect = new System.Windows.Forms.Panel();
            this.btnManual = new PulseButton.PulseButton();
            this.btnAuto = new PulseButton.PulseButton();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.RichLabel5 = new RichLabel.RichLabel();
            this.palSelect.SuspendLayout();
            this.grouper1.SuspendLayout();
            this.SuspendLayout();
            // 
            // palSelect
            // 
            this.palSelect.Controls.Add(this.RichLabel5);
            this.palSelect.Controls.Add(this.btnManual);
            this.palSelect.Controls.Add(this.btnAuto);
            this.palSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palSelect.Location = new System.Drawing.Point(5, 12);
            this.palSelect.Name = "palSelect";
            this.palSelect.Size = new System.Drawing.Size(885, 589);
            this.palSelect.TabIndex = 10;
            // 
            // btnManual
            // 
            this.btnManual.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnManual.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnManual.CornerRadius = 2;
            this.btnManual.FocusColor = System.Drawing.Color.Black;
            this.btnManual.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManual.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnManual.Location = new System.Drawing.Point(518, 178);
            this.btnManual.Name = "btnManual";
            this.btnManual.NumberOfPulses = 2;
            this.btnManual.PulseColor = System.Drawing.Color.DimGray;
            this.btnManual.PulseSpeed = 0.3F;
            this.btnManual.PulseWidth = 6;
            this.btnManual.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnManual.Size = new System.Drawing.Size(196, 127);
            this.btnManual.TabIndex = 122;
            this.btnManual.Text = "手     动";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnAuto.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnAuto.CornerRadius = 2;
            this.btnAuto.FocusColor = System.Drawing.Color.Black;
            this.btnAuto.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAuto.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAuto.Location = new System.Drawing.Point(184, 178);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.NumberOfPulses = 2;
            this.btnAuto.PulseColor = System.Drawing.Color.DimGray;
            this.btnAuto.PulseSpeed = 0.3F;
            this.btnAuto.PulseWidth = 6;
            this.btnAuto.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnAuto.Size = new System.Drawing.Size(196, 127);
            this.btnAuto.TabIndex = 122;
            this.btnAuto.Text = "自     动";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper1.BorderColor = System.Drawing.Color.Silver;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.palSelect);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouper1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grouper1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "选择预冲方式";
            this.grouper1.Location = new System.Drawing.Point(0, 0);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(5, 12, 3, 3);
            this.grouper1.PaintGroupBox = true;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(893, 604);
            this.grouper1.TabIndex = 120;
            // 
            // RichLabel5
            // 
            this.RichLabel5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RichLabel5.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.RichLabel5.BorderBottom = System.Drawing.Color.Transparent;
            this.RichLabel5.BorderLeft = System.Drawing.Color.Transparent;
            this.RichLabel5.BorderRight = System.Drawing.Color.Transparent;
            this.RichLabel5.BorderTop = System.Drawing.Color.Transparent;
            this.RichLabel5.Cursor = System.Windows.Forms.Cursors.Default;
            this.RichLabel5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RichLabel5.ForeColor = System.Drawing.Color.OrangeRed;
            this.RichLabel5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.RichLabel5.GradientModeHover = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.RichLabel5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.RichLabel5.Location = new System.Drawing.Point(184, 311);
            this.RichLabel5.Name = "RichLabel5";
            this.RichLabel5.Size = new System.Drawing.Size(547, 80);
            this.RichLabel5.TabIndex = 130;
            this.RichLabel5.Text = "      注意 : 预冲过程中注意不要让所用的血液净化器管路中有气泡残留,若管壁上有气泡,请在清洗过程中用手指轻弹管路,清洗完成后需再次确认,保证对治疗无影响。" +
    "";
            this.RichLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucSelectFlush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.grouper1);
            this.Name = "ucSelectFlush";
            this.Size = new System.Drawing.Size(893, 604);
            this.SizeChanged += new System.EventHandler(this.ucSelectFlush_SizeChanged);
            this.palSelect.ResumeLayout(false);
            this.grouper1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel palSelect;
        private CodeVendor.Controls.Grouper grouper1;
        public PulseButton.PulseButton btnManual;
        public PulseButton.PulseButton btnAuto;
        internal RichLabel.RichLabel RichLabel5;
    }
}
