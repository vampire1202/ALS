namespace ALS.UserCtrl
{
    partial class uc_PumpSpeed
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
            this.picPump = new System.Windows.Forms.PictureBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblOtherInfo = new System.Windows.Forms.Label();
            this.gbox = new CodeVendor.Controls.Grouper();
            ((System.ComponentModel.ISupportInitialize)(this.picPump)).BeginInit();
            this.gbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // picPump
            // 
            this.picPump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picPump.BackColor = System.Drawing.Color.Transparent;
            this.picPump.Image = global::ALS.Properties.Resources.home;
            this.picPump.Location = new System.Drawing.Point(179, 16);
            this.picPump.Name = "picPump";
            this.picPump.Size = new System.Drawing.Size(32, 32);
            this.picPump.TabIndex = 0;
            this.picPump.TabStop = false;
            this.picPump.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSpeed.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblSpeed.Location = new System.Drawing.Point(2, 30);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(212, 60);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "120";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSpeed.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblUnit
            // 
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUnit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblUnit.Location = new System.Drawing.Point(2, 90);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(212, 22);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "mL/min";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUnit.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblOtherInfo
            // 
            this.lblOtherInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblOtherInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblOtherInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOtherInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblOtherInfo.Location = new System.Drawing.Point(2, 112);
            this.lblOtherInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblOtherInfo.Name = "lblOtherInfo";
            this.lblOtherInfo.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblOtherInfo.Size = new System.Drawing.Size(212, 16);
            this.lblOtherInfo.TabIndex = 4;
            this.lblOtherInfo.Text = "∑: 0.000 L";
            this.lblOtherInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOtherInfo.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // gbox
            // 
            this.gbox.BackgroundColor = System.Drawing.Color.White;
            this.gbox.BackgroundGradientColor = System.Drawing.Color.White;
            this.gbox.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.gbox.BorderColor = System.Drawing.Color.Silver;
            this.gbox.BorderThickness = 1F;
            this.gbox.Controls.Add(this.picPump);
            this.gbox.Controls.Add(this.lblSpeed);
            this.gbox.Controls.Add(this.lblUnit);
            this.gbox.Controls.Add(this.lblOtherInfo);
            this.gbox.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.gbox.GroupImage = null;
            this.gbox.GroupTitle = "夹管阀控制";
            this.gbox.Location = new System.Drawing.Point(0, 0);
            this.gbox.Name = "gbox";
            this.gbox.Padding = new System.Windows.Forms.Padding(2, 25, 3, 3);
            this.gbox.PaintGroupBox = true;
            this.gbox.RoundCorners = 10;
            this.gbox.ShadowColor = System.Drawing.Color.DarkGray;
            this.gbox.ShadowControl = false;
            this.gbox.ShadowThickness = 3;
            this.gbox.Size = new System.Drawing.Size(217, 131);
            this.gbox.TabIndex = 121;
            // 
            // uc_PumpSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gbox);
            this.Name = "uc_PumpSpeed";
            this.Size = new System.Drawing.Size(217, 131);
            ((System.ComponentModel.ISupportInitialize)(this.picPump)).EndInit();
            this.gbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPump;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblOtherInfo;
        private System.Windows.Forms.Label lblSpeed;
        public CodeVendor.Controls.Grouper gbox;
    }
}
