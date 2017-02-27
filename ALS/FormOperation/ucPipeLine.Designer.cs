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
            this.components = new System.ComponentModel.Container();
            this.lvStep = new System.Windows.Forms.ListView();
            this.pboxShow = new System.Windows.Forms.PictureBox();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.btnNext = new CCWin.SkinControl.SkinButton();
            this.btnReturn = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.pboxShow)).BeginInit();
            this.skinGroupBox1.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
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
            this.lvStep.Location = new System.Drawing.Point(3, 25);
            this.lvStep.MultiSelect = false;
            this.lvStep.Name = "lvStep";
            this.lvStep.ShowGroups = false;
            this.lvStep.Size = new System.Drawing.Size(156, 386);
            this.lvStep.TabIndex = 11;
            this.lvStep.UseCompatibleStateImageBehavior = false;
            this.lvStep.View = System.Windows.Forms.View.Details;
            this.lvStep.SizeChanged += new System.EventHandler(this.lvStep_SizeChanged);
            // 
            // pboxShow
            // 
            this.pboxShow.BackColor = System.Drawing.Color.Transparent;
            this.pboxShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pboxShow.Dock = System.Windows.Forms.DockStyle.Left;
            this.pboxShow.Location = new System.Drawing.Point(3, 29);
            this.pboxShow.Name = "pboxShow";
            this.pboxShow.Size = new System.Drawing.Size(724, 572);
            this.pboxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxShow.TabIndex = 10;
            this.pboxShow.TabStop = false;
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox1.Controls.Add(this.skinGroupBox2);
            this.skinGroupBox1.Controls.Add(this.pboxShow);
            this.skinGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.skinGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.Radius = 20;
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(898, 604);
            this.skinGroupBox1.TabIndex = 35;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "安装管路";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox1.TitleRadius = 16;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.Right;
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox2.Controls.Add(this.lvStep);
            this.skinGroupBox2.Controls.Add(this.btnNext);
            this.skinGroupBox2.Controls.Add(this.btnReturn);
            this.skinGroupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.skinGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.skinGroupBox2.Location = new System.Drawing.Point(733, 29);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.Radius = 20;
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.Size = new System.Drawing.Size(162, 572);
            this.skinGroupBox2.TabIndex = 64;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "安装步骤";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnNext.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnNext.DownBack = null;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(31, 515);
            this.btnNext.MouseBack = null;
            this.btnNext.Name = "btnNext";
            this.btnNext.NormlBack = null;
            this.btnNext.Radius = 50;
            this.btnNext.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnNext.Size = new System.Drawing.Size(100, 50);
            this.btnNext.TabIndex = 63;
            this.btnNext.Tag = "";
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
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
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(32, 454);
            this.btnReturn.MouseBack = null;
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.NormlBack = null;
            this.btnReturn.Radius = 50;
            this.btnReturn.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnReturn.Size = new System.Drawing.Size(100, 50);
            this.btnReturn.TabIndex = 63;
            this.btnReturn.Tag = "";
            this.btnReturn.Text = "上一步";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // ucPipeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.skinGroupBox1);
            this.Name = "ucPipeLine";
            this.Size = new System.Drawing.Size(898, 604);
            this.Load += new System.EventHandler(this.pipeLine_Load);
            this.SizeChanged += new System.EventHandler(this.pipeLine_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pboxShow)).EndInit();
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxShow;
        private System.Windows.Forms.ListView lvStep;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        public CCWin.SkinControl.SkinButton btnNext;
        public CCWin.SkinControl.SkinButton btnReturn;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
    }
}
