namespace ALS.UserCtrl
{
    partial class MsgBox
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
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.btnOk = new PulseButton.PulseButton();
            this.btnCancel = new PulseButton.PulseButton();
            this.lblContent = new System.Windows.Forms.TextBox();
            this.picTip = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTip)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.Image = global::ALS.Properties.Resources.icon_question;
            this.picIcon.Location = new System.Drawing.Point(17, 89);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(80, 80);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picIcon.TabIndex = 40;
            this.picIcon.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnOk.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnOk.CornerRadius = 20;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FocusColor = System.Drawing.Color.Black;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOk.Location = new System.Drawing.Point(0, 201);
            this.btnOk.Name = "btnOk";
            this.btnOk.NumberOfPulses = 2;
            this.btnOk.PulseColor = System.Drawing.Color.DimGray;
            this.btnOk.PulseSpeed = 0.3F;
            this.btnOk.PulseWidth = 6;
            this.btnOk.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnOk.Size = new System.Drawing.Size(112, 52);
            this.btnOk.TabIndex = 122;
            this.btnOk.Text = "确  定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnCancel.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnCancel.CornerRadius = 20;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FocusColor = System.Drawing.Color.Black;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(0, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NumberOfPulses = 2;
            this.btnCancel.PulseColor = System.Drawing.Color.DimGray;
            this.btnCancel.PulseSpeed = 0.3F;
            this.btnCancel.PulseWidth = 6;
            this.btnCancel.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnCancel.Size = new System.Drawing.Size(112, 52);
            this.btnCancel.TabIndex = 122;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblContent
            // 
            this.lblContent.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblContent.ForeColor = System.Drawing.Color.Black;
            this.lblContent.Location = new System.Drawing.Point(2, 2);
            this.lblContent.Multiline = true;
            this.lblContent.Name = "lblContent";
            this.lblContent.ReadOnly = true;
            this.lblContent.Size = new System.Drawing.Size(514, 63);
            this.lblContent.TabIndex = 126;
            this.lblContent.Text = "    ① 在<启动治疗> 前，请确认各泵的速度设定值，可在 <泵速显示单元> 上进行修改泵速；\r\n    ② 在<启动治疗> 前，可点击脱水速度的 <速度值标签" +
    "> 进行修改脱水速度；\r\n";
            this.lblContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // picTip
            // 
            this.picTip.Location = new System.Drawing.Point(3, 3);
            this.picTip.Name = "picTip";
            this.picTip.Size = new System.Drawing.Size(400, 240);
            this.picTip.TabIndex = 127;
            this.picTip.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.picTip);
            this.panel1.Location = new System.Drawing.Point(113, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 242);
            this.panel1.TabIndex = 128;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Silver;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 242);
            this.splitter1.TabIndex = 128;
            this.splitter1.TabStop = false;
            // 
            // MsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(518, 318);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MsgBox";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MsgBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTip)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        public PulseButton.PulseButton btnOk;
        public PulseButton.PulseButton btnCancel;
        private System.Windows.Forms.TextBox lblContent;
        private System.Windows.Forms.PictureBox picTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
    }
}