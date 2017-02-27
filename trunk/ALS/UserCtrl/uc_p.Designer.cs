namespace ALS.UserCtrl
{
    partial class uc_p
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
            this.lblLower = new System.Windows.Forms.Label();
            this.lblUpper = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.Panel();
            this.palLeft = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblLower
            // 
            this.lblLower.BackColor = System.Drawing.Color.Transparent;
            this.lblLower.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLower.ForeColor = System.Drawing.Color.DimGray;
            this.lblLower.Location = new System.Drawing.Point(75, 46);
            this.lblLower.Name = "lblLower";
            this.lblLower.Size = new System.Drawing.Size(34, 16);
            this.lblLower.TabIndex = 8;
            this.lblLower.Text = "-100";
            this.lblLower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUpper
            // 
            this.lblUpper.BackColor = System.Drawing.Color.Transparent;
            this.lblUpper.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpper.ForeColor = System.Drawing.Color.DimGray;
            this.lblUpper.Location = new System.Drawing.Point(78, 29);
            this.lblUpper.Name = "lblUpper";
            this.lblUpper.Size = new System.Drawing.Size(34, 16);
            this.lblUpper.TabIndex = 9;
            this.lblUpper.Text = "500";
            this.lblUpper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblTitle.Location = new System.Drawing.Point(9, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(95, 23);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "采血Pacc";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValue
            // 
            this.lblValue.BackColor = System.Drawing.Color.Transparent;
            this.lblValue.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.lblValue.Location = new System.Drawing.Point(7, 31);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(74, 28);
            this.lblValue.TabIndex = 10;
            this.lblValue.Text = "-155.0";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.Orange;
            this.line.Location = new System.Drawing.Point(12, 26);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(69, 2);
            this.line.TabIndex = 11;
            // 
            // palLeft
            // 
            this.palLeft.BackColor = System.Drawing.Color.LightGray;
            this.palLeft.Location = new System.Drawing.Point(2, 5);
            this.palLeft.Name = "palLeft";
            this.palLeft.Size = new System.Drawing.Size(2, 48);
            this.palLeft.TabIndex = 12;
            // 
            // uc_p
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLower);
            this.Controls.Add(this.lblUpper);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.palLeft);
            this.Controls.Add(this.line);
            this.Controls.Add(this.lblTitle);
            this.Name = "uc_p";
            this.Size = new System.Drawing.Size(105, 65);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLower;
        private System.Windows.Forms.Label lblUpper;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Panel line;
        private System.Windows.Forms.Panel palLeft;
    }
}
