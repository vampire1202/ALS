namespace ALS.FormSet
{
    partial class ucSetLiquidSurface
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
            this.groupSet = new System.Windows.Forms.GroupBox();
            this.palP = new System.Windows.Forms.Panel();
            this.uc_ptmp = new ALS.UserCtrl.uc_p();
            this.uc_pven = new ALS.UserCtrl.uc_p();
            this.uc_p2nd = new ALS.UserCtrl.uc_p();
            this.label20 = new System.Windows.Forms.Label();
            this.uc_pacc = new ALS.UserCtrl.uc_p();
            this.uc_p1st = new ALS.UserCtrl.uc_p();
            this.uc_part = new ALS.UserCtrl.uc_p();
            this.chkUpM1 = new System.Windows.Forms.CheckBox();
            this.chkUpC2 = new System.Windows.Forms.CheckBox();
            this.chkUpC1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDownM1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDownC2 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDownC1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupSet.SuspendLayout();
            this.palP.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSet
            // 
            this.groupSet.Controls.Add(this.palP);
            this.groupSet.Controls.Add(this.chkUpM1);
            this.groupSet.Controls.Add(this.chkUpC2);
            this.groupSet.Controls.Add(this.chkUpC1);
            this.groupSet.Controls.Add(this.label1);
            this.groupSet.Controls.Add(this.chkDownM1);
            this.groupSet.Controls.Add(this.label2);
            this.groupSet.Controls.Add(this.chkDownC2);
            this.groupSet.Controls.Add(this.label3);
            this.groupSet.Controls.Add(this.chkDownC1);
            this.groupSet.Controls.Add(this.label4);
            this.groupSet.Controls.Add(this.label6);
            this.groupSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.groupSet.Location = new System.Drawing.Point(0, 0);
            this.groupSet.Name = "groupSet";
            this.groupSet.Size = new System.Drawing.Size(898, 532);
            this.groupSet.TabIndex = 5;
            this.groupSet.TabStop = false;
            this.groupSet.Text = "液面调整";
            // 
            // palP
            // 
            this.palP.BackColor = System.Drawing.Color.Transparent;
            this.palP.Controls.Add(this.uc_ptmp);
            this.palP.Controls.Add(this.uc_pven);
            this.palP.Controls.Add(this.uc_p2nd);
            this.palP.Controls.Add(this.label20);
            this.palP.Controls.Add(this.uc_pacc);
            this.palP.Controls.Add(this.uc_p1st);
            this.palP.Controls.Add(this.uc_part);
            this.palP.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.palP.Location = new System.Drawing.Point(53, 40);
            this.palP.Name = "palP";
            this.palP.Size = new System.Drawing.Size(801, 92);
            this.palP.TabIndex = 32;
            // 
            // uc_ptmp
            // 
            this.uc_ptmp._LineColor = System.Drawing.Color.DeepPink;
            this.uc_ptmp._Lower = "-100.0";
            this.uc_ptmp._Title = "TMP";
            this.uc_ptmp._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_ptmp._Upper = "-100.0";
            this.uc_ptmp._Value = "-155.0";
            this.uc_ptmp._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_ptmp._VisibleLeft = true;
            this.uc_ptmp.BackColor = System.Drawing.Color.Transparent;
            this.uc_ptmp.Location = new System.Drawing.Point(422, 11);
            this.uc_ptmp.Name = "uc_ptmp";
            this.uc_ptmp.Size = new System.Drawing.Size(107, 65);
            this.uc_ptmp.TabIndex = 2;
            // 
            // uc_pven
            // 
            this.uc_pven._LineColor = System.Drawing.Color.DodgerBlue;
            this.uc_pven._Lower = "-100.0";
            this.uc_pven._Title = "静脉Pven";
            this.uc_pven._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_pven._Upper = "-100.0";
            this.uc_pven._Value = "-155.0";
            this.uc_pven._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_pven._VisibleLeft = true;
            this.uc_pven.BackColor = System.Drawing.Color.Transparent;
            this.uc_pven.Location = new System.Drawing.Point(296, 11);
            this.uc_pven.Name = "uc_pven";
            this.uc_pven.Size = new System.Drawing.Size(107, 65);
            this.uc_pven.TabIndex = 2;
            // 
            // uc_p2nd
            // 
            this.uc_p2nd._LineColor = System.Drawing.Color.DarkOrange;
            this.uc_p2nd._Lower = "-100.0";
            this.uc_p2nd._Title = "入口P2nd";
            this.uc_p2nd._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_p2nd._Upper = "-100.0";
            this.uc_p2nd._Value = "-155.0";
            this.uc_p2nd._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_p2nd._VisibleLeft = true;
            this.uc_p2nd.BackColor = System.Drawing.Color.Transparent;
            this.uc_p2nd.Location = new System.Drawing.Point(674, 11);
            this.uc_p2nd.Name = "uc_p2nd";
            this.uc_p2nd.Size = new System.Drawing.Size(107, 65);
            this.uc_p2nd.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(3, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 36);
            this.label20.TabIndex = 1;
            this.label20.Text = "压力\r\n\r\n[mmHg]";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uc_pacc
            // 
            this.uc_pacc._LineColor = System.Drawing.Color.Maroon;
            this.uc_pacc._Lower = "-100";
            this.uc_pacc._Title = "采血Pacc";
            this.uc_pacc._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_pacc._Upper = "500";
            this.uc_pacc._Value = "-155.0";
            this.uc_pacc._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_pacc._VisibleLeft = true;
            this.uc_pacc.BackColor = System.Drawing.Color.Transparent;
            this.uc_pacc.Location = new System.Drawing.Point(44, 11);
            this.uc_pacc.Name = "uc_pacc";
            this.uc_pacc.Size = new System.Drawing.Size(107, 65);
            this.uc_pacc.TabIndex = 2;
            // 
            // uc_p1st
            // 
            this.uc_p1st._LineColor = System.Drawing.Color.Lime;
            this.uc_p1st._Lower = "-100.0";
            this.uc_p1st._Title = "血浆P1st";
            this.uc_p1st._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_p1st._Upper = "-100.0";
            this.uc_p1st._Value = "-155.0";
            this.uc_p1st._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_p1st._VisibleLeft = true;
            this.uc_p1st.BackColor = System.Drawing.Color.Transparent;
            this.uc_p1st.Location = new System.Drawing.Point(548, 11);
            this.uc_p1st.Name = "uc_p1st";
            this.uc_p1st.Size = new System.Drawing.Size(107, 65);
            this.uc_p1st.TabIndex = 2;
            // 
            // uc_part
            // 
            this.uc_part._LineColor = System.Drawing.Color.Red;
            this.uc_part._Lower = "-100.0";
            this.uc_part._Title = "动脉Part";
            this.uc_part._TitleColor = System.Drawing.SystemColors.ControlText;
            this.uc_part._Upper = "-100.0";
            this.uc_part._Value = "-155.0";
            this.uc_part._ValueColor = System.Drawing.SystemColors.ControlText;
            this.uc_part._VisibleLeft = true;
            this.uc_part.BackColor = System.Drawing.Color.Transparent;
            this.uc_part.Location = new System.Drawing.Point(170, 11);
            this.uc_part.Name = "uc_part";
            this.uc_part.Size = new System.Drawing.Size(107, 65);
            this.uc_part.TabIndex = 2;
            // 
            // chkUpM1
            // 
            this.chkUpM1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUpM1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkUpM1.Image = global::ALS.Properties.Resources.up_64;
            this.chkUpM1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkUpM1.Location = new System.Drawing.Point(692, 259);
            this.chkUpM1.Name = "chkUpM1";
            this.chkUpM1.Size = new System.Drawing.Size(85, 83);
            this.chkUpM1.TabIndex = 3;
            this.chkUpM1.Tag = "3up";
            this.chkUpM1.Text = "上升";
            this.chkUpM1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkUpM1.UseVisualStyleBackColor = true;
            this.chkUpM1.CheckedChanged += new System.EventHandler(this.chkC1Down_CheckedChanged);
            // 
            // chkUpC2
            // 
            this.chkUpC2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUpC2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkUpC2.Image = global::ALS.Properties.Resources.up_64;
            this.chkUpC2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkUpC2.Location = new System.Drawing.Point(417, 259);
            this.chkUpC2.Name = "chkUpC2";
            this.chkUpC2.Size = new System.Drawing.Size(85, 83);
            this.chkUpC2.TabIndex = 3;
            this.chkUpC2.Tag = "2up";
            this.chkUpC2.Text = "上升";
            this.chkUpC2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkUpC2.UseVisualStyleBackColor = true;
            this.chkUpC2.CheckedChanged += new System.EventHandler(this.chkC1Down_CheckedChanged);
            // 
            // chkUpC1
            // 
            this.chkUpC1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUpC1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkUpC1.Image = global::ALS.Properties.Resources.up_64;
            this.chkUpC1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkUpC1.Location = new System.Drawing.Point(142, 259);
            this.chkUpC1.Name = "chkUpC1";
            this.chkUpC1.Size = new System.Drawing.Size(85, 83);
            this.chkUpC1.TabIndex = 3;
            this.chkUpC1.Tag = "1up";
            this.chkUpC1.Text = "上升";
            this.chkUpC1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkUpC1.UseVisualStyleBackColor = true;
            this.chkUpC1.CheckedChanged += new System.EventHandler(this.chkC1Down_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(143, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "静脉壶液面";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDownM1
            // 
            this.chkDownM1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDownM1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDownM1.Image = global::ALS.Properties.Resources.down_64;
            this.chkDownM1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkDownM1.Location = new System.Drawing.Point(692, 347);
            this.chkDownM1.Name = "chkDownM1";
            this.chkDownM1.Size = new System.Drawing.Size(85, 83);
            this.chkDownM1.TabIndex = 3;
            this.chkDownM1.Tag = "3down";
            this.chkDownM1.Text = "下降";
            this.chkDownM1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkDownM1.UseVisualStyleBackColor = true;
            this.chkDownM1.CheckedChanged += new System.EventHandler(this.chkC1Down_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(145, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "C1(Pven)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDownC2
            // 
            this.chkDownC2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDownC2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDownC2.Image = global::ALS.Properties.Resources.down_64;
            this.chkDownC2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkDownC2.Location = new System.Drawing.Point(417, 347);
            this.chkDownC2.Name = "chkDownC2";
            this.chkDownC2.Size = new System.Drawing.Size(85, 83);
            this.chkDownC2.TabIndex = 3;
            this.chkDownC2.Tag = "2down";
            this.chkDownC2.Text = "下降";
            this.chkDownC2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkDownC2.UseVisualStyleBackColor = true;
            this.chkDownC2.CheckedChanged += new System.EventHandler(this.chkC1Down_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(415, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "动脉壶液面";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDownC1
            // 
            this.chkDownC1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDownC1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDownC1.Image = global::ALS.Properties.Resources.down_64;
            this.chkDownC1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkDownC1.Location = new System.Drawing.Point(142, 347);
            this.chkDownC1.Name = "chkDownC1";
            this.chkDownC1.Size = new System.Drawing.Size(85, 83);
            this.chkDownC1.TabIndex = 3;
            this.chkDownC1.Tag = "1down";
            this.chkDownC1.Text = "下降";
            this.chkDownC1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkDownC1.UseVisualStyleBackColor = true;
            this.chkDownC1.CheckedChanged += new System.EventHandler(this.chkC1Down_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(418, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "C2(Part)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(688, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 23);
            this.label6.TabIndex = 1;
            this.label6.Text = "M1(P1st)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucSetLiquidSurface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.groupSet);
            this.Name = "ucSetLiquidSurface";
            this.Size = new System.Drawing.Size(898, 532);
            this.Load += new System.EventHandler(this.ucSetLiquidSurface_Load);
            this.SizeChanged += new System.EventHandler(this.ucSetLiquidSurface_SizeChanged);
            this.groupSet.ResumeLayout(false);
            this.groupSet.PerformLayout();
            this.palP.ResumeLayout(false);
            this.palP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox chkUpC1;
        public System.Windows.Forms.CheckBox chkDownC1;
        public System.Windows.Forms.CheckBox chkUpM1;
        public System.Windows.Forms.CheckBox chkUpC2;
        public System.Windows.Forms.CheckBox chkDownM1;
        public System.Windows.Forms.CheckBox chkDownC2;
        private System.Windows.Forms.Panel palP;
        public UserCtrl.uc_p uc_ptmp;
        public UserCtrl.uc_p uc_pven;
        public UserCtrl.uc_p uc_p2nd;
        private System.Windows.Forms.Label label20;
        public UserCtrl.uc_p uc_pacc;
        public UserCtrl.uc_p uc_p1st;
        public UserCtrl.uc_p uc_part;
    }
}
