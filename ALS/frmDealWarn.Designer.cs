namespace ALS
{
    partial class frmDealWarn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDealWarn));
            this.btnClose = new System.Windows.Forms.Button();
            this.palPven = new System.Windows.Forms.Panel();
            this.btn1down = new System.Windows.Forms.Button();
            this.btn1up = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pox1 = new System.Windows.Forms.PictureBox();
            this.textsteps = new System.Windows.Forms.Label();
            this.frmdeal_spstart = new System.Windows.Forms.Button();
            this.chkV2 = new System.Windows.Forms.CheckBox();
            this.chkV1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uc_Pacc = new ALS.UserCtrl.uc_ShowTreatP();
            this.uc_Part = new ALS.UserCtrl.uc_ShowTreatP();
            this.uc_Pven = new ALS.UserCtrl.uc_ShowTreatP();
            this.uc_P1st = new ALS.UserCtrl.uc_ShowTreatP();
            this.palPven.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(539, 346);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 52);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "确定";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // palPven
            // 
            this.palPven.Controls.Add(this.btn1down);
            this.palPven.Controls.Add(this.btn1up);
            this.palPven.Controls.Add(this.label1);
            this.palPven.Dock = System.Windows.Forms.DockStyle.Right;
            this.palPven.Location = new System.Drawing.Point(214, 0);
            this.palPven.Name = "palPven";
            this.palPven.Size = new System.Drawing.Size(87, 271);
            this.palPven.TabIndex = 4;
            this.palPven.Visible = false;
            // 
            // btn1down
            // 
            this.btn1down.Image = global::ALS.Properties.Resources.down_64;
            this.btn1down.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn1down.Location = new System.Drawing.Point(4, 147);
            this.btn1down.Margin = new System.Windows.Forms.Padding(0);
            this.btn1down.Name = "btn1down";
            this.btn1down.Size = new System.Drawing.Size(77, 77);
            this.btn1down.TabIndex = 39;
            this.btn1down.Tag = "1down";
            this.btn1down.Text = "下降";
            this.btn1down.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn1down.UseVisualStyleBackColor = true;
            this.btn1down.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn1up
            // 
            this.btn1up.Image = global::ALS.Properties.Resources.up_64;
            this.btn1up.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn1up.Location = new System.Drawing.Point(4, 64);
            this.btn1up.Name = "btn1up";
            this.btn1up.Size = new System.Drawing.Size(77, 77);
            this.btn1up.TabIndex = 39;
            this.btn1up.Tag = "1up";
            this.btn1up.Text = "上升";
            this.btn1up.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn1up.UseVisualStyleBackColor = true;
            this.btn1up.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 42);
            this.label1.TabIndex = 35;
            this.label1.Text = "静脉壶\r\n液面调节";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pox1
            // 
            this.pox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pox1.Location = new System.Drawing.Point(0, 0);
            this.pox1.Name = "pox1";
            this.pox1.Size = new System.Drawing.Size(214, 271);
            this.pox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pox1.TabIndex = 9;
            this.pox1.TabStop = false;
            // 
            // textsteps
            // 
            this.textsteps.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textsteps.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textsteps.Location = new System.Drawing.Point(319, 64);
            this.textsteps.Name = "textsteps";
            this.textsteps.Size = new System.Drawing.Size(309, 271);
            this.textsteps.TabIndex = 11;
            this.textsteps.Text = "label2";
            // 
            // frmdeal_spstart
            // 
            this.frmdeal_spstart.Location = new System.Drawing.Point(314, 358);
            this.frmdeal_spstart.Name = "frmdeal_spstart";
            this.frmdeal_spstart.Size = new System.Drawing.Size(75, 29);
            this.frmdeal_spstart.TabIndex = 15;
            this.frmdeal_spstart.Text = "运行肝素泵";
            this.frmdeal_spstart.UseVisualStyleBackColor = true;
            this.frmdeal_spstart.Visible = false;
            this.frmdeal_spstart.Click += new System.EventHandler(this.frmdeal_spstart_Click);
            // 
            // chkV2
            // 
            this.chkV2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkV2.Checked = true;
            this.chkV2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkV2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chkV2.Image = ((System.Drawing.Image)(resources.GetObject("chkV2.Image")));
            this.chkV2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkV2.Location = new System.Drawing.Point(107, 342);
            this.chkV2.Name = "chkV2";
            this.chkV2.Size = new System.Drawing.Size(80, 62);
            this.chkV2.TabIndex = 17;
            this.chkV2.Tag = "v2";
            this.chkV2.Text = "2";
            this.chkV2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chkV2.UseVisualStyleBackColor = true;
            this.chkV2.Click += new System.EventHandler(this.chkV1_Click);
            // 
            // chkV1
            // 
            this.chkV1.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkV1.BackColor = System.Drawing.Color.Transparent;
            this.chkV1.Checked = true;
            this.chkV1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkV1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.chkV1.Image = ((System.Drawing.Image)(resources.GetObject("chkV1.Image")));
            this.chkV1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkV1.Location = new System.Drawing.Point(12, 342);
            this.chkV1.Name = "chkV1";
            this.chkV1.Size = new System.Drawing.Size(80, 62);
            this.chkV1.TabIndex = 18;
            this.chkV1.Tag = "v1";
            this.chkV1.Text = "1";
            this.chkV1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chkV1.UseVisualStyleBackColor = false;
            this.chkV1.Click += new System.EventHandler(this.chkV1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pox1);
            this.panel1.Controls.Add(this.palPven);
            this.panel1.Location = new System.Drawing.Point(12, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 271);
            this.panel1.TabIndex = 19;
            // 
            // uc_Pacc
            // 
            this.uc_Pacc._ColorLine = System.Drawing.Color.DarkRed;
            this.uc_Pacc._ColorTitle = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.uc_Pacc._ColorValue = System.Drawing.Color.Black;
            this.uc_Pacc._FontTitle = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc_Pacc._FontValue = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_Pacc._Title = "采血压";
            this.uc_Pacc._TitleEn = "Pacc";
            this.uc_Pacc._Value = "-000";
            this.uc_Pacc._ValueSize = new System.Drawing.Size(55, 50);
            this.uc_Pacc.Location = new System.Drawing.Point(14, 2);
            this.uc_Pacc.Name = "uc_Pacc";
            this.uc_Pacc.Size = new System.Drawing.Size(128, 60);
            this.uc_Pacc.TabIndex = 20;
            // 
            // uc_Part
            // 
            this.uc_Part._ColorLine = System.Drawing.Color.Red;
            this.uc_Part._ColorTitle = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.uc_Part._ColorValue = System.Drawing.Color.Black;
            this.uc_Part._FontTitle = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc_Part._FontValue = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_Part._Title = "动脉压";
            this.uc_Part._TitleEn = "Part";
            this.uc_Part._Value = "-000";
            this.uc_Part._ValueSize = new System.Drawing.Size(55, 50);
            this.uc_Part.Location = new System.Drawing.Point(176, 2);
            this.uc_Part.Name = "uc_Part";
            this.uc_Part.Size = new System.Drawing.Size(128, 60);
            this.uc_Part.TabIndex = 20;
            // 
            // uc_Pven
            // 
            this.uc_Pven._ColorLine = System.Drawing.Color.Blue;
            this.uc_Pven._ColorTitle = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.uc_Pven._ColorValue = System.Drawing.Color.Black;
            this.uc_Pven._FontTitle = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc_Pven._FontValue = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_Pven._Title = "静脉压";
            this.uc_Pven._TitleEn = "Pven";
            this.uc_Pven._Value = "-000";
            this.uc_Pven._ValueSize = new System.Drawing.Size(55, 50);
            this.uc_Pven.Location = new System.Drawing.Point(338, 2);
            this.uc_Pven.Name = "uc_Pven";
            this.uc_Pven.Size = new System.Drawing.Size(128, 60);
            this.uc_Pven.TabIndex = 20;
            // 
            // uc_P1st
            // 
            this.uc_P1st._ColorLine = System.Drawing.Color.Lime;
            this.uc_P1st._ColorTitle = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.uc_P1st._ColorValue = System.Drawing.Color.Black;
            this.uc_P1st._FontTitle = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uc_P1st._FontValue = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_P1st._Title = "血浆压";
            this.uc_P1st._TitleEn = "P1st";
            this.uc_P1st._Value = "-000";
            this.uc_P1st._ValueSize = new System.Drawing.Size(55, 50);
            this.uc_P1st.Location = new System.Drawing.Point(500, 2);
            this.uc_P1st.Name = "uc_P1st";
            this.uc_P1st.Size = new System.Drawing.Size(128, 60);
            this.uc_P1st.TabIndex = 20;
            // 
            // frmDealWarn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 406);
            this.ControlBox = false;
            this.Controls.Add(this.uc_P1st);
            this.Controls.Add(this.uc_Pven);
            this.Controls.Add(this.uc_Part);
            this.Controls.Add(this.uc_Pacc);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkV2);
            this.Controls.Add(this.chkV1);
            this.Controls.Add(this.frmdeal_spstart);
            this.Controls.Add(this.textsteps);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDealWarn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消除警报步骤";
            this.Load += new System.EventHandler(this.frmDealWarn_Load);
            this.palPven.ResumeLayout(false);
            this.palPven.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btn1down;
        private System.Windows.Forms.Button btn1up;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel palPven;
        public System.Windows.Forms.PictureBox pox1;
        public System.Windows.Forms.Label textsteps;
        public System.Windows.Forms.Button frmdeal_spstart;
        public System.Windows.Forms.CheckBox chkV2;
        public System.Windows.Forms.CheckBox chkV1;
        private System.Windows.Forms.Panel panel1;
        public UserCtrl.uc_ShowTreatP uc_Pacc;
        public UserCtrl.uc_ShowTreatP uc_Part;
        public UserCtrl.uc_ShowTreatP uc_Pven;
        public UserCtrl.uc_ShowTreatP uc_P1st;
    }
}