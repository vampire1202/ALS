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
            this.groupPipeline = new System.Windows.Forms.GroupBox();
            this.lvStep = new System.Windows.Forms.ListView();
            this.pboxShow = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnGuide = new System.Windows.Forms.Button();
            this.groupPipeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxShow)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPipeline
            // 
            this.groupPipeline.Controls.Add(this.lvStep);
            this.groupPipeline.Controls.Add(this.pboxShow);
            this.groupPipeline.Controls.Add(this.btnNext);
            this.groupPipeline.Controls.Add(this.btnReturn);
            this.groupPipeline.Controls.Add(this.btnGuide);
            this.groupPipeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPipeline.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPipeline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.groupPipeline.Location = new System.Drawing.Point(0, 0);
            this.groupPipeline.Name = "groupPipeline";
            this.groupPipeline.Size = new System.Drawing.Size(898, 578);
            this.groupPipeline.TabIndex = 4;
            this.groupPipeline.TabStop = false;
            this.groupPipeline.Text = "管路安装";
            // 
            // lvStep
            // 
            this.lvStep.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lvStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvStep.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lvStep.FullRowSelect = true;
            this.lvStep.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvStep.Location = new System.Drawing.Point(733, 94);
            this.lvStep.MultiSelect = false;
            this.lvStep.Name = "lvStep";
            this.lvStep.ShowGroups = false;
            this.lvStep.Size = new System.Drawing.Size(162, 368);
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
            this.pboxShow.Size = new System.Drawing.Size(724, 546);
            this.pboxShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxShow.TabIndex = 10;
            this.pboxShow.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnNext.Location = new System.Drawing.Point(754, 519);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(118, 40);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "下一步";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnReturn.Location = new System.Drawing.Point(754, 473);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(118, 40);
            this.btnReturn.TabIndex = 8;
            this.btnReturn.Text = "上一步";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnGuide
            // 
            this.btnGuide.BackColor = System.Drawing.Color.Transparent;
            this.btnGuide.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGuide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnGuide.Location = new System.Drawing.Point(754, 41);
            this.btnGuide.Name = "btnGuide";
            this.btnGuide.Size = new System.Drawing.Size(118, 40);
            this.btnGuide.TabIndex = 7;
            this.btnGuide.Text = "导引开始";
            this.btnGuide.UseVisualStyleBackColor = false;
            this.btnGuide.Click += new System.EventHandler(this.btnGuide_Click);
            // 
            // ucPipeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.groupPipeline);
            this.Name = "ucPipeLine";
            this.Size = new System.Drawing.Size(898, 578);
            this.Load += new System.EventHandler(this.pipeLine_Load);
            this.SizeChanged += new System.EventHandler(this.pipeLine_SizeChanged);
            this.groupPipeline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupPipeline;
        private System.Windows.Forms.PictureBox pboxShow;
        public System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.Button btnReturn;
        public System.Windows.Forms.Button btnGuide;
        private System.Windows.Forms.ListView lvStep;
    }
}
