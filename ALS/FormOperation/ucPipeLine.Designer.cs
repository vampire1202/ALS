namespace ALS.FormOperation
{
    partial class ucPipeLine
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
            this.lvStep = new System.Windows.Forms.ListView();
            this.pboxShow = new System.Windows.Forms.PictureBox();
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grouper2 = new CodeVendor.Controls.Grouper();
            this.btnReturn = new PulseButton.PulseButton();
            this.btnNext = new PulseButton.PulseButton();
            ((System.ComponentModel.ISupportInitialize)(this.pboxShow)).BeginInit();
            this.grouper1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grouper2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvStep
            // 
            this.lvStep.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lvStep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvStep.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lvStep.FullRowSelect = true;
            this.lvStep.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvStep.LabelWrap = false;
            this.lvStep.Location = new System.Drawing.Point(2, 25);
            this.lvStep.MultiSelect = false;
            this.lvStep.Name = "lvStep";
            this.lvStep.ShowGroups = false;
            this.lvStep.Size = new System.Drawing.Size(165, 430);
            this.lvStep.TabIndex = 11;
            this.lvStep.UseCompatibleStateImageBehavior = false;
            this.lvStep.View = System.Windows.Forms.View.Details;
            this.lvStep.SizeChanged += new System.EventHandler(this.lvStep_SizeChanged);
            // 
            // pboxShow
            // 
            this.pboxShow.BackColor = System.Drawing.Color.Transparent;
            this.pboxShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pboxShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pboxShow.Location = new System.Drawing.Point(0, 16);
            this.pboxShow.Name = "pboxShow";
            this.pboxShow.Size = new System.Drawing.Size(721, 573);
            this.pboxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxShow.TabIndex = 10;
            this.pboxShow.TabStop = false;
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper1.BorderColor = System.Drawing.Color.Silver;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.panel1);
            this.grouper1.Controls.Add(this.grouper2);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouper1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "安装管路";
            this.grouper1.Location = new System.Drawing.Point(0, 0);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(5, 12, 3, 3);
            this.grouper1.PaintGroupBox = true;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(898, 604);
            this.grouper1.TabIndex = 64;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pboxShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(5, 12);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.panel1.Size = new System.Drawing.Size(721, 589);
            this.panel1.TabIndex = 65;
            // 
            // grouper2
            // 
            this.grouper2.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grouper2.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper2.BorderColor = System.Drawing.Color.Silver;
            this.grouper2.BorderThickness = 1F;
            this.grouper2.Controls.Add(this.btnNext);
            this.grouper2.Controls.Add(this.btnReturn);
            this.grouper2.Controls.Add(this.lvStep);
            this.grouper2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper2.Dock = System.Windows.Forms.DockStyle.Right;
            this.grouper2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grouper2.GroupImage = null;
            this.grouper2.GroupTitle = "安装步骤";
            this.grouper2.Location = new System.Drawing.Point(725, 12);
            this.grouper2.Name = "grouper2";
            this.grouper2.Padding = new System.Windows.Forms.Padding(2, 25, 3, 3);
            this.grouper2.PaintGroupBox = true;
            this.grouper2.RoundCorners = 10;
            this.grouper2.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper2.ShadowControl = false;
            this.grouper2.ShadowThickness = 3;
            this.grouper2.Size = new System.Drawing.Size(170, 589);
            this.grouper2.TabIndex = 64;
            // 
            // btnReturn
            // 
            this.btnReturn.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnReturn.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnReturn.CornerRadius = 25;
            this.btnReturn.FocusColor = System.Drawing.Color.Black;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReturn.Location = new System.Drawing.Point(30, 452);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.PulseColor = System.Drawing.Color.DimGray;
            this.btnReturn.PulseSpeed = 0.3F;
            this.btnReturn.PulseWidth = 8;
            this.btnReturn.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnReturn.Size = new System.Drawing.Size(116, 66);
            this.btnReturn.TabIndex = 64;
            this.btnReturn.Text = "上一步";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnNext
            // 
            this.btnNext.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnNext.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnNext.CornerRadius = 25;
            this.btnNext.FocusColor = System.Drawing.Color.Black;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNext.Location = new System.Drawing.Point(30, 519);
            this.btnNext.Name = "btnNext";
            this.btnNext.PulseColor = System.Drawing.Color.DimGray;
            this.btnNext.PulseSpeed = 0.3F;
            this.btnNext.PulseWidth = 8;
            this.btnNext.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnNext.Size = new System.Drawing.Size(116, 66);
            this.btnNext.TabIndex = 64;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ucPipeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.grouper1);
            this.Name = "ucPipeLine";
            this.Size = new System.Drawing.Size(898, 604);
            this.Load += new System.EventHandler(this.pipeLine_Load);
            this.SizeChanged += new System.EventHandler(this.pipeLine_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pboxShow)).EndInit();
            this.grouper1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.grouper2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxShow;
        private System.Windows.Forms.ListView lvStep;
        private CodeVendor.Controls.Grouper grouper1;
        private System.Windows.Forms.Panel panel1;
        private CodeVendor.Controls.Grouper grouper2;
        public PulseButton.PulseButton btnReturn;
        public PulseButton.PulseButton btnNext;
    }
}
