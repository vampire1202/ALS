namespace ALS.FormSet
{
    partial class ucSetSum
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupSet = new System.Windows.Forms.GroupBox();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnSetTemperature = new System.Windows.Forms.Button();
            this.chbSP = new System.Windows.Forms.CheckBox();
            this.lblSP = new System.Windows.Forms.Label();
            this.chbBP = new System.Windows.Forms.CheckBox();
            this.lblBP = new System.Windows.Forms.Label();
            this.chbRP = new System.Windows.Forms.CheckBox();
            this.lblRP = new System.Windows.Forms.Label();
            this.chbDP = new System.Windows.Forms.CheckBox();
            this.lblDP = new System.Windows.Forms.Label();
            this.chbFP = new System.Windows.Forms.CheckBox();
            this.lblFP = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbTime = new System.Windows.Forms.CheckBox();
            this.lblTimeH = new System.Windows.Forms.Label();
            this.lblTimeMin = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalFP = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.lblTotalDP = new System.Windows.Forms.Label();
            this.lblTotalSP = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTotalBP = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotalRP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupSet.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSet
            // 
            this.groupSet.Controls.Add(this.chart1);
            this.groupSet.Controls.Add(this.groupBox1);
            this.groupSet.Controls.Add(this.groupBox3);
            this.groupSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.groupSet.Location = new System.Drawing.Point(0, 0);
            this.groupSet.Name = "groupSet";
            this.groupSet.Size = new System.Drawing.Size(898, 578);
            this.groupSet.TabIndex = 2;
            this.groupSet.TabStop = false;
            this.groupSet.Text = "累计";
            this.groupSet.Enter += new System.EventHandler(this.groupSet_Enter);
            // 
            // btnZero
            // 
            this.btnZero.BackColor = System.Drawing.Color.Transparent;
            this.btnZero.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnZero.Location = new System.Drawing.Point(30, 478);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(118, 58);
            this.btnZero.TabIndex = 18;
            this.btnZero.Text = "累计值清零";
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnSetTemperature
            // 
            this.btnSetTemperature.BackColor = System.Drawing.Color.Transparent;
            this.btnSetTemperature.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.btnSetTemperature.Image = global::ALS.Properties.Resources.save;
            this.btnSetTemperature.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetTemperature.Location = new System.Drawing.Point(195, 478);
            this.btnSetTemperature.Name = "btnSetTemperature";
            this.btnSetTemperature.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnSetTemperature.Size = new System.Drawing.Size(118, 58);
            this.btnSetTemperature.TabIndex = 18;
            this.btnSetTemperature.Text = "保存设置";
            this.btnSetTemperature.UseVisualStyleBackColor = false;
            this.btnSetTemperature.Click += new System.EventHandler(this.btnSetTemperature_Click);
            // 
            // chbSP
            // 
            this.chbSP.BackColor = System.Drawing.Color.Green;
            this.chbSP.Checked = true;
            this.chbSP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSP.ForeColor = System.Drawing.Color.White;
            this.chbSP.Location = new System.Drawing.Point(246, 405);
            this.chbSP.Name = "chbSP";
            this.chbSP.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.chbSP.Size = new System.Drawing.Size(87, 50);
            this.chbSP.TabIndex = 17;
            this.chbSP.Text = "有效";
            this.chbSP.UseVisualStyleBackColor = false;
            this.chbSP.CheckedChanged += new System.EventHandler(this.chbTime_CheckedChanged);
            // 
            // lblSP
            // 
            this.lblSP.BackColor = System.Drawing.Color.Transparent;
            this.lblSP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblSP.Location = new System.Drawing.Point(105, 405);
            this.lblSP.Name = "lblSP";
            this.lblSP.Size = new System.Drawing.Size(133, 50);
            this.lblSP.TabIndex = 14;
            this.lblSP.Text = "0.0";
            this.lblSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // chbBP
            // 
            this.chbBP.BackColor = System.Drawing.Color.Green;
            this.chbBP.Checked = true;
            this.chbBP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbBP.ForeColor = System.Drawing.Color.White;
            this.chbBP.Location = new System.Drawing.Point(246, 105);
            this.chbBP.Name = "chbBP";
            this.chbBP.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.chbBP.Size = new System.Drawing.Size(87, 50);
            this.chbBP.TabIndex = 17;
            this.chbBP.Text = "有效";
            this.chbBP.UseVisualStyleBackColor = false;
            this.chbBP.CheckedChanged += new System.EventHandler(this.chbTime_CheckedChanged);
            // 
            // lblBP
            // 
            this.lblBP.BackColor = System.Drawing.Color.Transparent;
            this.lblBP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblBP.Location = new System.Drawing.Point(105, 105);
            this.lblBP.Name = "lblBP";
            this.lblBP.Size = new System.Drawing.Size(133, 50);
            this.lblBP.TabIndex = 14;
            this.lblBP.Text = "0.0";
            this.lblBP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // chbRP
            // 
            this.chbRP.BackColor = System.Drawing.Color.Green;
            this.chbRP.Checked = true;
            this.chbRP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRP.ForeColor = System.Drawing.Color.White;
            this.chbRP.Location = new System.Drawing.Point(246, 255);
            this.chbRP.Name = "chbRP";
            this.chbRP.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.chbRP.Size = new System.Drawing.Size(87, 50);
            this.chbRP.TabIndex = 17;
            this.chbRP.Text = "有效";
            this.chbRP.UseVisualStyleBackColor = false;
            this.chbRP.CheckedChanged += new System.EventHandler(this.chbTime_CheckedChanged);
            // 
            // lblRP
            // 
            this.lblRP.BackColor = System.Drawing.Color.Transparent;
            this.lblRP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblRP.Location = new System.Drawing.Point(105, 255);
            this.lblRP.Name = "lblRP";
            this.lblRP.Size = new System.Drawing.Size(133, 50);
            this.lblRP.TabIndex = 14;
            this.lblRP.Text = "0.0";
            this.lblRP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // chbDP
            // 
            this.chbDP.BackColor = System.Drawing.Color.Green;
            this.chbDP.Checked = true;
            this.chbDP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDP.ForeColor = System.Drawing.Color.White;
            this.chbDP.Location = new System.Drawing.Point(246, 330);
            this.chbDP.Name = "chbDP";
            this.chbDP.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.chbDP.Size = new System.Drawing.Size(87, 50);
            this.chbDP.TabIndex = 17;
            this.chbDP.Text = "有效";
            this.chbDP.UseVisualStyleBackColor = false;
            this.chbDP.CheckedChanged += new System.EventHandler(this.chbTime_CheckedChanged);
            // 
            // lblDP
            // 
            this.lblDP.BackColor = System.Drawing.Color.Transparent;
            this.lblDP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblDP.Location = new System.Drawing.Point(105, 330);
            this.lblDP.Name = "lblDP";
            this.lblDP.Size = new System.Drawing.Size(133, 50);
            this.lblDP.TabIndex = 14;
            this.lblDP.Text = "0.0";
            this.lblDP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // chbFP
            // 
            this.chbFP.BackColor = System.Drawing.Color.Green;
            this.chbFP.Checked = true;
            this.chbFP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbFP.ForeColor = System.Drawing.Color.White;
            this.chbFP.Location = new System.Drawing.Point(246, 180);
            this.chbFP.Name = "chbFP";
            this.chbFP.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.chbFP.Size = new System.Drawing.Size(87, 50);
            this.chbFP.TabIndex = 17;
            this.chbFP.Text = "有效";
            this.chbFP.UseVisualStyleBackColor = false;
            this.chbFP.CheckedChanged += new System.EventHandler(this.chbTime_CheckedChanged);
            // 
            // lblFP
            // 
            this.lblFP.BackColor = System.Drawing.Color.Transparent;
            this.lblFP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFP.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblFP.Location = new System.Drawing.Point(105, 180);
            this.lblFP.Name = "lblFP";
            this.lblFP.Size = new System.Drawing.Size(133, 50);
            this.lblFP.TabIndex = 14;
            this.lblFP.Text = "0.0";
            this.lblFP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFP.Click += new System.EventHandler(this.lblBP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnZero);
            this.groupBox1.Controls.Add(this.chbSP);
            this.groupBox1.Controls.Add(this.btnSetTemperature);
            this.groupBox1.Controls.Add(this.chbDP);
            this.groupBox1.Controls.Add(this.lblSP);
            this.groupBox1.Controls.Add(this.chbFP);
            this.groupBox1.Controls.Add(this.lblDP);
            this.groupBox1.Controls.Add(this.chbBP);
            this.groupBox1.Controls.Add(this.lblFP);
            this.groupBox1.Controls.Add(this.chbRP);
            this.groupBox1.Controls.Add(this.lblBP);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblRP);
            this.groupBox1.Controls.Add(this.chbTime);
            this.groupBox1.Controls.Add(this.lblTimeH);
            this.groupBox1.Controls.Add(this.lblTimeMin);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(550, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 554);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目标值设定";
            // 
            // chbTime
            // 
            this.chbTime.BackColor = System.Drawing.Color.Green;
            this.chbTime.Checked = true;
            this.chbTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTime.ForeColor = System.Drawing.Color.White;
            this.chbTime.Location = new System.Drawing.Point(246, 30);
            this.chbTime.Name = "chbTime";
            this.chbTime.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.chbTime.Size = new System.Drawing.Size(87, 50);
            this.chbTime.TabIndex = 17;
            this.chbTime.Text = "有效";
            this.chbTime.UseVisualStyleBackColor = false;
            this.chbTime.CheckedChanged += new System.EventHandler(this.chbTime_CheckedChanged);
            // 
            // lblTimeH
            // 
            this.lblTimeH.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTimeH.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTimeH.Location = new System.Drawing.Point(105, 30);
            this.lblTimeH.Name = "lblTimeH";
            this.lblTimeH.Size = new System.Drawing.Size(57, 50);
            this.lblTimeH.TabIndex = 14;
            this.lblTimeH.Text = "00";
            this.lblTimeH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimeH.Click += new System.EventHandler(this.lblTimeH_Click);
            // 
            // lblTimeMin
            // 
            this.lblTimeMin.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTimeMin.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTimeMin.Location = new System.Drawing.Point(181, 30);
            this.lblTimeMin.Name = "lblTimeMin";
            this.lblTimeMin.Size = new System.Drawing.Size(57, 50);
            this.lblTimeMin.TabIndex = 14;
            this.lblTimeMin.Text = "00";
            this.lblTimeMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimeMin.Click += new System.EventHandler(this.lblTimeH_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(165, 45);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(14, 21);
            this.label32.TabIndex = 16;
            this.label32.Text = ":";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.lblTotalFP);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.lblTotalTime);
            this.groupBox3.Controls.Add(this.lblTotalDP);
            this.groupBox3.Controls.Add(this.lblTotalSP);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.lblTotalBP);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lblTotalRP);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(8)))), ((int)(((byte)(100)))));
            this.groupBox3.Location = new System.Drawing.Point(7, 463);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 109);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "当前累计值";
            // 
            // lblTotalFP
            // 
            this.lblTotalFP.AutoSize = true;
            this.lblTotalFP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTotalFP.Location = new System.Drawing.Point(146, 83);
            this.lblTotalFP.Name = "lblTotalFP";
            this.lblTotalFP.Size = new System.Drawing.Size(45, 19);
            this.lblTotalFP.TabIndex = 17;
            this.lblTotalFP.Text = "0.000";
            this.lblTotalFP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(54, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 20);
            this.label18.TabIndex = 3;
            this.label18.Text = "血液循环量:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(480, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "[L]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(480, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "[L]";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(480, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "[mL]";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(216, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "[L]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(216, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "[L]";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(68, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 20);
            this.label21.TabIndex = 17;
            this.label21.Text = "治疗时间:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTotalTime.Location = new System.Drawing.Point(146, 25);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(63, 19);
            this.lblTotalTime.TabIndex = 2;
            this.lblTotalTime.Text = "00:00:00";
            this.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalDP
            // 
            this.lblTotalDP.AutoSize = true;
            this.lblTotalDP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTotalDP.Location = new System.Drawing.Point(416, 54);
            this.lblTotalDP.Name = "lblTotalDP";
            this.lblTotalDP.Size = new System.Drawing.Size(45, 19);
            this.lblTotalDP.TabIndex = 14;
            this.lblTotalDP.Text = "0.000";
            this.lblTotalDP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalSP
            // 
            this.lblTotalSP.AutoSize = true;
            this.lblTotalSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTotalSP.Location = new System.Drawing.Point(416, 83);
            this.lblTotalSP.Name = "lblTotalSP";
            this.lblTotalSP.Size = new System.Drawing.Size(29, 19);
            this.lblTotalSP.TabIndex = 14;
            this.lblTotalSP.Text = "0.0";
            this.lblTotalSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(28, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 20);
            this.label16.TabIndex = 6;
            this.label16.Text = "分离泵(FP)累计:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalBP
            // 
            this.lblTotalBP.AutoSize = true;
            this.lblTotalBP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTotalBP.Location = new System.Drawing.Point(146, 54);
            this.lblTotalBP.Name = "lblTotalBP";
            this.lblTotalBP.Size = new System.Drawing.Size(45, 19);
            this.lblTotalBP.TabIndex = 15;
            this.lblTotalBP.Text = "0.000";
            this.lblTotalBP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(296, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "补液泵(RP)累计:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(280, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "透析液泵(DP)累计:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(283, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "抗凝剂泵(SP)累计:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalRP
            // 
            this.lblTotalRP.AutoSize = true;
            this.lblTotalRP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.lblTotalRP.Location = new System.Drawing.Point(416, 25);
            this.lblTotalRP.Name = "lblTotalRP";
            this.lblTotalRP.Size = new System.Drawing.Size(45, 19);
            this.lblTotalRP.TabIndex = 11;
            this.lblTotalRP.Text = "0.000";
            this.lblTotalRP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 42);
            this.label3.TabIndex = 18;
            this.label3.Text = "时间\r\n[hh:mm]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 42);
            this.label7.TabIndex = 18;
            this.label7.Text = "补液泵RP\r\n[L]";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 42);
            this.label8.TabIndex = 18;
            this.label8.Text = "血液循环BP\r\n[L]";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 42);
            this.label9.TabIndex = 18;
            this.label9.Text = "分离泵FP\r\n[L]";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 334);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 42);
            this.label12.TabIndex = 18;
            this.label12.Text = "透析液泵DP\r\n[L]";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 409);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 42);
            this.label14.TabIndex = 18;
            this.label14.Text = "抗凝剂泵SP\r\n[mL]";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(7, 28);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(537, 429);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // ucSetSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.groupSet);
            this.Name = "ucSetSum";
            this.Size = new System.Drawing.Size(898, 578);
            this.Load += new System.EventHandler(this.ucSum_Load);
            this.SizeChanged += new System.EventHandler(this.ucSum_SizeChanged);
            this.groupSet.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSet;
        private System.Windows.Forms.Label lblFP;
        private System.Windows.Forms.Label lblTimeH;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblTimeMin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblSP;
        private System.Windows.Forms.Label lblBP;
        private System.Windows.Forms.Label lblRP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSetTemperature;
        private System.Windows.Forms.CheckBox chbTime;
        private System.Windows.Forms.CheckBox chbSP;
        private System.Windows.Forms.CheckBox chbBP;
        private System.Windows.Forms.CheckBox chbRP;
        private System.Windows.Forms.CheckBox chbFP;
        private System.Windows.Forms.Button btnZero;
        public System.Windows.Forms.Label lblTotalFP;
        public System.Windows.Forms.Label lblTotalBP;
        public System.Windows.Forms.Label lblTotalSP;
        public System.Windows.Forms.Label lblTotalRP;
        public System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.CheckBox chbDP;
        private System.Windows.Forms.Label lblDP;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblTotalDP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
