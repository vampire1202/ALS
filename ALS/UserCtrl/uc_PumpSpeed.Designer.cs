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
            this.lblTitle = new CCWin.SkinControl.SkinGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPump)).BeginInit();
            this.lblTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // picPump
            // 
            this.picPump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picPump.BackColor = System.Drawing.Color.Transparent;
            this.picPump.Image = global::ALS.Properties.Resources.home;
            this.picPump.Location = new System.Drawing.Point(183, 13);
            this.picPump.Name = "picPump";
            this.picPump.Size = new System.Drawing.Size(32, 32);
            this.picPump.TabIndex = 0;
            this.picPump.TabStop = false;
            this.picPump.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpeed.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblSpeed.Location = new System.Drawing.Point(3, 30);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(211, 60);
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
            this.lblUnit.Location = new System.Drawing.Point(3, 90);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(211, 22);
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
            this.lblOtherInfo.Location = new System.Drawing.Point(3, 112);
            this.lblOtherInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblOtherInfo.Name = "lblOtherInfo";
            this.lblOtherInfo.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblOtherInfo.Size = new System.Drawing.Size(211, 16);
            this.lblOtherInfo.TabIndex = 4;
            this.lblOtherInfo.Text = "∑: 0.000 L";
            this.lblOtherInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOtherInfo.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BorderColor = System.Drawing.Color.Silver;
            this.lblTitle.Controls.Add(this.picPump);
            this.lblTitle.Controls.Add(this.lblSpeed);
            this.lblTitle.Controls.Add(this.lblUnit);
            this.lblTitle.Controls.Add(this.lblOtherInfo);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.lblTitle.RectBackColor = System.Drawing.Color.White;
            this.lblTitle.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.lblTitle.Size = new System.Drawing.Size(217, 131);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.TabStop = false;
            this.lblTitle.Text = "肝素泵";
            this.lblTitle.TitleBorderColor = System.Drawing.Color.Silver;
            this.lblTitle.TitleRectBackColor = System.Drawing.Color.White;
            this.lblTitle.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // uc_PumpSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblTitle);
            this.Name = "uc_PumpSpeed";
            this.Size = new System.Drawing.Size(217, 131);
            ((System.ComponentModel.ISupportInitialize)(this.picPump)).EndInit();
            this.lblTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPump;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblOtherInfo;
        private System.Windows.Forms.Label lblSpeed;
        private CCWin.SkinControl.SkinGroupBox lblTitle;
    }
}
