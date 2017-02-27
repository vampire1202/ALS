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
            this.btnManual = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.palSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // palSelect
            // 
            this.palSelect.Controls.Add(this.btnManual);
            this.palSelect.Controls.Add(this.btnAuto);
            this.palSelect.Controls.Add(this.label2);
            this.palSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palSelect.Location = new System.Drawing.Point(3, 25);
            this.palSelect.Name = "palSelect";
            this.palSelect.Size = new System.Drawing.Size(892, 504);
            this.palSelect.TabIndex = 10;
            // 
            // btnManual
            // 
            this.btnManual.BackColor = System.Drawing.Color.Transparent;
            this.btnManual.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnManual.Location = new System.Drawing.Point(524, 154);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(188, 118);
            this.btnManual.TabIndex = 8;
            this.btnManual.Text = "手   动";
            this.btnManual.UseVisualStyleBackColor = false;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.BackColor = System.Drawing.Color.Transparent;
            this.btnAuto.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnAuto.Location = new System.Drawing.Point(182, 154);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(188, 118);
            this.btnAuto.TabIndex = 7;
            this.btnAuto.Text = "自   动";
            this.btnAuto.UseVisualStyleBackColor = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(177, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(535, 105);
            this.label2.TabIndex = 0;
            this.label2.Text = "      注意：清洗过程中要注意不要让所用的血液净化器管路中有气泡残留,若管壁上有气泡,请在清洗过程中用手指轻弹管路,清洗完成后需再次确认,保证对治疗无影响。";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.palSelect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 532);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择预冲方式";
            // 
            // ucSelectFlush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.groupBox1);
            this.Name = "ucSelectFlush";
            this.Size = new System.Drawing.Size(898, 532);
            this.SizeChanged += new System.EventHandler(this.ucSelectFlush_SizeChanged);
            this.palSelect.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel palSelect;
        public System.Windows.Forms.Button btnManual;
        public System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
