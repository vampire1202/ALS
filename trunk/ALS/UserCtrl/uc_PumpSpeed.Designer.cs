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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblOtherInfo = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.picPump = new System.Windows.Forms.PictureBox();
            this.a1Panel1 = new Owf.Controls.A1Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picPump)).BeginInit();
            this.a1Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(217, 26);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "注射泵流量";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnit
            // 
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUnit.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.ForeColor = System.Drawing.Color.Navy;
            this.lblUnit.Location = new System.Drawing.Point(0, 81);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblUnit.Size = new System.Drawing.Size(217, 25);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "mL/min";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOtherInfo
            // 
            this.lblOtherInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblOtherInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblOtherInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOtherInfo.ForeColor = System.Drawing.Color.Navy;
            this.lblOtherInfo.Location = new System.Drawing.Point(0, 106);
            this.lblOtherInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lblOtherInfo.Name = "lblOtherInfo";
            this.lblOtherInfo.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblOtherInfo.Size = new System.Drawing.Size(217, 20);
            this.lblOtherInfo.TabIndex = 4;
            this.lblOtherInfo.Text = "30mL";
            this.lblOtherInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSpeed
            // 
            this.lblSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblSpeed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSpeed.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSpeed.Location = new System.Drawing.Point(0, 24);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(217, 57);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "120";
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picPump
            // 
            this.picPump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picPump.BackColor = System.Drawing.Color.Transparent;
            this.picPump.Image = global::ALS.Properties.Resources.home;
            this.picPump.Location = new System.Drawing.Point(179, 2);
            this.picPump.Name = "picPump";
            this.picPump.Size = new System.Drawing.Size(32, 32);
            this.picPump.TabIndex = 0;
            this.picPump.TabStop = false;
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.DimGray;
            this.a1Panel1.Controls.Add(this.picPump);
            this.a1Panel1.Controls.Add(this.lblTitle);
            this.a1Panel1.Controls.Add(this.lblSpeed);
            this.a1Panel1.Controls.Add(this.lblUnit);
            this.a1Panel1.Controls.Add(this.lblOtherInfo);
            this.a1Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a1Panel1.GradientEndColor = System.Drawing.Color.Gainsboro;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.WhiteSmoke;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(0, 0);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.a1Panel1.ShadowOffSet = 4;
            this.a1Panel1.Size = new System.Drawing.Size(217, 131);
            this.a1Panel1.TabIndex = 5;
            // 
            // uc_PumpSpeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.a1Panel1);
            this.Name = "uc_PumpSpeed";
            this.Size = new System.Drawing.Size(217, 131);
            ((System.ComponentModel.ISupportInitialize)(this.picPump)).EndInit();
            this.a1Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPump;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblOtherInfo;
        private System.Windows.Forms.Label lblSpeed;
        private Owf.Controls.A1Panel a1Panel1;
    }
}
