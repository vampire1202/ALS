namespace ALS
{
    partial class Form1
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
            this.grouper1 = new CodeVendor.Controls.Grouper();
            this.gboxRecycle = new CodeVendor.Controls.Grouper();
            this.btnReturn = new PulseButton.PulseButton();
            this.pulseButton1 = new PulseButton.PulseButton();
            this.pulseButton2 = new PulseButton.PulseButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper1.BorderColor = System.Drawing.Color.Silver;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grouper1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.grouper1.GroupImage = null;
            this.grouper1.GroupTitle = "安装管路";
            this.grouper1.Location = new System.Drawing.Point(12, 12);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(5, 12, 3, 3);
            this.grouper1.PaintGroupBox = true;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(365, 238);
            this.grouper1.TabIndex = 119;
            // 
            // gboxRecycle
            // 
            this.gboxRecycle.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.gboxRecycle.BackgroundGradientColor = System.Drawing.Color.White;
            this.gboxRecycle.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.gboxRecycle.BorderColor = System.Drawing.Color.Silver;
            this.gboxRecycle.BorderThickness = 1F;
            this.gboxRecycle.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gboxRecycle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gboxRecycle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.gboxRecycle.GroupImage = null;
            this.gboxRecycle.GroupTitle = "夹管阀控制";
            this.gboxRecycle.Location = new System.Drawing.Point(398, 21);
            this.gboxRecycle.Name = "gboxRecycle";
            this.gboxRecycle.Padding = new System.Windows.Forms.Padding(2, 25, 3, 3);
            this.gboxRecycle.PaintGroupBox = true;
            this.gboxRecycle.RoundCorners = 10;
            this.gboxRecycle.ShadowColor = System.Drawing.Color.DarkGray;
            this.gboxRecycle.ShadowControl = false;
            this.gboxRecycle.ShadowThickness = 3;
            this.gboxRecycle.Size = new System.Drawing.Size(196, 162);
            this.gboxRecycle.TabIndex = 120;
            // 
            // btnReturn
            // 
            this.btnReturn.ButtonColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.btnReturn.ButtonColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(140)))), ((int)(((byte)(188)))));
            this.btnReturn.CornerRadius = 25;
            this.btnReturn.FocusColor = System.Drawing.Color.Black;
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReturn.Location = new System.Drawing.Point(663, 12);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.NumberOfPulses = 2;
            this.btnReturn.PulseColor = System.Drawing.Color.DimGray;
            this.btnReturn.PulseSpeed = 0.3F;
            this.btnReturn.PulseWidth = 6;
            this.btnReturn.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.btnReturn.Size = new System.Drawing.Size(112, 62);
            this.btnReturn.TabIndex = 121;
            this.btnReturn.Text = "上一步";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // pulseButton1
            // 
            this.pulseButton1.ButtonColorBottom = System.Drawing.Color.DarkGreen;
            this.pulseButton1.ButtonColorTop = System.Drawing.Color.LimeGreen;
            this.pulseButton1.CornerRadius = 25;
            this.pulseButton1.FocusColor = System.Drawing.Color.Black;
            this.pulseButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pulseButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pulseButton1.Location = new System.Drawing.Point(600, 90);
            this.pulseButton1.Name = "pulseButton1";
            this.pulseButton1.NumberOfPulses = 2;
            this.pulseButton1.PulseColor = System.Drawing.Color.DimGray;
            this.pulseButton1.PulseSpeed = 0.3F;
            this.pulseButton1.PulseWidth = 6;
            this.pulseButton1.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.pulseButton1.Size = new System.Drawing.Size(112, 62);
            this.pulseButton1.TabIndex = 123;
            this.pulseButton1.Text = "启动治疗";
            this.pulseButton1.UseVisualStyleBackColor = true;
            // 
            // pulseButton2
            // 
            this.pulseButton2.ButtonColorBottom = System.Drawing.Color.DarkGoldenrod;
            this.pulseButton2.ButtonColorTop = System.Drawing.Color.Orange;
            this.pulseButton2.CornerRadius = 25;
            this.pulseButton2.Enabled = false;
            this.pulseButton2.FocusColor = System.Drawing.Color.Black;
            this.pulseButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pulseButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pulseButton2.Location = new System.Drawing.Point(745, 90);
            this.pulseButton2.Name = "pulseButton2";
            this.pulseButton2.NumberOfPulses = 2;
            this.pulseButton2.PulseColor = System.Drawing.Color.DimGray;
            this.pulseButton2.PulseSpeed = 0.3F;
            this.pulseButton2.PulseWidth = 6;
            this.pulseButton2.ShapeType = PulseButton.PulseButton.Shape.Rectangle;
            this.pulseButton2.Size = new System.Drawing.Size(112, 62);
            this.pulseButton2.TabIndex = 124;
            this.pulseButton2.Text = "暂停";
            this.pulseButton2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox1.ForeColor = System.Drawing.Color.OrangeRed;
            this.textBox1.Location = new System.Drawing.Point(398, 216);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(415, 51);
            this.textBox1.TabIndex = 125;
            this.textBox1.Text = "    ① 若需要脱水平衡，需要点击右侧 <泵秤平衡> 按钮，此时按钮呈选中状态；\r\n    ② 若需要更换液袋，请先点 <泵秤平衡> 取消联动，然后更换液袋，待" +
    "秤平稳后再点<泵秤平衡>；";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 262);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pulseButton2);
            this.Controls.Add(this.pulseButton1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.gboxRecycle);
            this.Controls.Add(this.grouper1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public CodeVendor.Controls.Grouper gboxRecycle;
        public PulseButton.PulseButton btnReturn;
        public CodeVendor.Controls.Grouper grouper1;
        public PulseButton.PulseButton pulseButton1;
        public PulseButton.PulseButton pulseButton2;
        private System.Windows.Forms.TextBox textBox1;
    }
}