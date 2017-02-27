namespace ALS.FormOperation
{
    partial class ucMethod
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
            this.groupMethod = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnShowPal = new System.Windows.Forms.Button();
            this.groupMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupMethod
            // 
            this.groupMethod.BackColor = System.Drawing.Color.Transparent;
            this.groupMethod.Controls.Add(this.btnOk);
            this.groupMethod.Controls.Add(this.btnShowPal);
            this.groupMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMethod.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.groupMethod.Location = new System.Drawing.Point(0, 0);
            this.groupMethod.Name = "groupMethod";
            this.groupMethod.Size = new System.Drawing.Size(898, 532);
            this.groupMethod.TabIndex = 0;
            this.groupMethod.TabStop = false;
            this.groupMethod.Text = "模式选择";
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(730, 442);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 50);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnShowPal
            // 
            this.btnShowPal.Font = new System.Drawing.Font("楷体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnShowPal.Location = new System.Drawing.Point(268, 212);
            this.btnShowPal.Name = "btnShowPal";
            this.btnShowPal.Size = new System.Drawing.Size(339, 94);
            this.btnShowPal.TabIndex = 16;
            this.btnShowPal.Text = "李氏人工肝";
            this.btnShowPal.UseVisualStyleBackColor = true;
            this.btnShowPal.Click += new System.EventHandler(this.btnShowPal_Click);
            // 
            // ucMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.groupMethod);
            this.Name = "ucMethod";
            this.Size = new System.Drawing.Size(898, 532);
            this.Load += new System.EventHandler(this.ucfrmMethod_Load);
            this.SizeChanged += new System.EventHandler(this.ucfrmMethod_SizeChanged);
            this.groupMethod.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupMethod;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnShowPal;
    }
}
