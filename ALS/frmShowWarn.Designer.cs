namespace ALS
{
    partial class frmShowWarn
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
            this.components = new System.ComponentModel.Container();
            this.btnMin = new CCWin.SkinControl.SkinButton();
            this.ucWarnInfo1 = new ALS.FormOperation.ucWarnInfo();
            this.SuspendLayout();
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Tomato;
            this.btnMin.BaseColor = System.Drawing.Color.Yellow;
            this.btnMin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnMin.DownBack = null;
            this.btnMin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMin.GlowColor = System.Drawing.Color.Transparent;
            this.btnMin.Location = new System.Drawing.Point(3, 8);
            this.btnMin.MouseBack = null;
            this.btnMin.Name = "btnMin";
            this.btnMin.NormlBack = null;
            this.btnMin.Radius = 30;
            this.btnMin.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnMin.Size = new System.Drawing.Size(70, 30);
            this.btnMin.TabIndex = 2;
            this.btnMin.Text = "缩小";
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // ucWarnInfo1
            // 
            this.ucWarnInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ucWarnInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucWarnInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWarnInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucWarnInfo1.Name = "ucWarnInfo1";
            this.ucWarnInfo1.Size = new System.Drawing.Size(400, 388);
            this.ucWarnInfo1.TabIndex = 0;
            this.ucWarnInfo1.Load += new System.EventHandler(this.ucWarnInfo1_Load);
            // 
            // frmShowWarn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 388);
            this.ControlBox = false;
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.ucWarnInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowWarn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "警报信息";
            this.Load += new System.EventHandler(this.frmShowWarn_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public FormOperation.ucWarnInfo ucWarnInfo1;
        public CCWin.SkinControl.SkinButton btnMin;

    }
}