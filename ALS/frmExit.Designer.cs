namespace ALS
{
    partial class frmExit
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
            this.pb = new System.Windows.Forms.ProgressBar();
            this.rtbox = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pb.Location = new System.Drawing.Point(0, 46);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(384, 17);
            this.pb.TabIndex = 1;
            // 
            // rtbox
            // 
            this.rtbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbox.Location = new System.Drawing.Point(0, 0);
            this.rtbox.Name = "rtbox";
            this.rtbox.Size = new System.Drawing.Size(384, 46);
            this.rtbox.TabIndex = 2;
            this.rtbox.Text = "";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(312, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 31);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "强制退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 63);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rtbox);
            this.Controls.Add(this.pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmExit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "退出系统";
            this.Load += new System.EventHandler(this.frmExit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ProgressBar pb;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.RichTextBox rtbox;
    }
}