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
            this.components = new System.ComponentModel.Container();
            this.palSelect = new System.Windows.Forms.Panel();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.btnManual = new CCWin.SkinControl.SkinButton();
            this.btnAuto = new CCWin.SkinControl.SkinButton();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.palSelect.SuspendLayout();
            this.skinGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // palSelect
            // 
            this.palSelect.Controls.Add(this.skinLabel1);
            this.palSelect.Controls.Add(this.btnManual);
            this.palSelect.Controls.Add(this.btnAuto);
            this.palSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palSelect.Location = new System.Drawing.Point(3, 29);
            this.palSelect.Name = "palSelect";
            this.palSelect.Size = new System.Drawing.Size(887, 572);
            this.palSelect.TabIndex = 10;
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.skinLabel1.ForeColor = System.Drawing.Color.Red;
            this.skinLabel1.Location = new System.Drawing.Point(180, 308);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(534, 71);
            this.skinLabel1.TabIndex = 65;
            this.skinLabel1.Text = "      注意 : 预冲过程中注意不要让所用的血液净化器管路中有气泡残留,若管壁上有气泡,请在清洗过程中用手指轻弹管路,清洗完成后需再次确认,保证对治疗无影响。" +
    "";
            // 
            // btnManual
            // 
            this.btnManual.BackColor = System.Drawing.Color.Transparent;
            this.btnManual.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnManual.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnManual.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnManual.DownBack = null;
            this.btnManual.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManual.ForeColor = System.Drawing.Color.White;
            this.btnManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManual.Location = new System.Drawing.Point(524, 177);
            this.btnManual.MouseBack = null;
            this.btnManual.Name = "btnManual";
            this.btnManual.NormlBack = null;
            this.btnManual.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnManual.Size = new System.Drawing.Size(188, 118);
            this.btnManual.TabIndex = 64;
            this.btnManual.Tag = "";
            this.btnManual.Text = "手    动";
            this.btnManual.UseVisualStyleBackColor = false;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.BackColor = System.Drawing.Color.Transparent;
            this.btnAuto.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnAuto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(163)))), ((int)(((byte)(215)))));
            this.btnAuto.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAuto.DownBack = null;
            this.btnAuto.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAuto.ForeColor = System.Drawing.Color.White;
            this.btnAuto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuto.Location = new System.Drawing.Point(180, 177);
            this.btnAuto.MouseBack = null;
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.NormlBack = null;
            this.btnAuto.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnAuto.Size = new System.Drawing.Size(188, 118);
            this.btnAuto.TabIndex = 64;
            this.btnAuto.Tag = "";
            this.btnAuto.Text = "自    动";
            this.btnAuto.UseVisualStyleBackColor = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox1.Controls.Add(this.palSelect);
            this.skinGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.skinGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.Radius = 20;
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(893, 604);
            this.skinGroupBox1.TabIndex = 35;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "选择预冲方式";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Silver;
            this.skinGroupBox1.TitleRadius = 20;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.White;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.Right;
            // 
            // ucSelectFlush
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.skinGroupBox1);
            this.Name = "ucSelectFlush";
            this.Size = new System.Drawing.Size(893, 604);
            this.SizeChanged += new System.EventHandler(this.ucSelectFlush_SizeChanged);
            this.palSelect.ResumeLayout(false);
            this.skinGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel palSelect;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        public CCWin.SkinControl.SkinButton btnAuto;
        public CCWin.SkinControl.SkinButton btnManual;
        private CCWin.SkinControl.SkinLabel skinLabel1;
    }
}
