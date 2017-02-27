namespace ALS
{
    partial class frmProgress
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
            this.btnExit = new CCWin.SkinControl.SkinButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BaseColor = System.Drawing.Color.DarkRed;
            this.btnExit.BorderColor = System.Drawing.Color.Lavender;
            this.btnExit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.DownBack = null;
            this.btnExit.DownBaseColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.Location = new System.Drawing.Point(92, 0);
            this.btnExit.MouseBack = null;
            this.btnExit.Name = "btnExit";
            this.btnExit.NormlBack = null;
            this.btnExit.Radius = 18;
            this.btnExit.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnExit.Size = new System.Drawing.Size(75, 10);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(92, 10);
            this.progressBar1.TabIndex = 2;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(12, 4);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(11, 12);
            this.lblTip.TabIndex = 3;
            this.lblTip.Text = ".";
            this.lblTip.Visible = false;
            // 
            // frmProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 10);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgress";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProgress";
            this.SizeChanged += new System.EventHandler(this.frmProgress_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CCWin.SkinControl.SkinButton btnExit;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label lblTip;

    }
}