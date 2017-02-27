namespace TestWizard
{
	partial class Main
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
            this.appRenderVS = new System.Windows.Forms.CheckBox();
            this.compEnabledCheck = new System.Windows.Forms.CheckBox();
            this.vsEnabledByUser = new System.Windows.Forms.CheckBox();
            this.vsOnOS = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.oldButton = new System.Windows.Forms.Button();
            this.customBtn = new System.Windows.Forms.Button();
            this.stepBtn = new System.Windows.Forms.Button();
            this.wizBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.stepWizardControl1 = new AeroWizard.StepWizardControl();
            this.wizardPage1 = new AeroWizard.WizardPage();
            this.wizardPage2 = new AeroWizard.WizardPage();
            this.wizardPage3 = new AeroWizard.WizardPage();
            this.wizardPage4 = new AeroWizard.WizardPage();
            this.wizardPage5 = new AeroWizard.WizardPage();
            this.wizardPage6 = new AeroWizard.WizardPage();
            this.wizardPage7 = new AeroWizard.WizardPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepWizardControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // appRenderVS
            // 
            this.appRenderVS.AutoCheck = false;
            this.appRenderVS.AutoSize = true;
            this.appRenderVS.Location = new System.Drawing.Point(6, 39);
            this.appRenderVS.Name = "appRenderVS";
            this.appRenderVS.Size = new System.Drawing.Size(90, 16);
            this.appRenderVS.TabIndex = 0;
            this.appRenderVS.Text = "AppRenderVS";
            this.toolTip1.SetToolTip(this.appRenderVS, "Indicates if Visual Styles are enabled for this application.");
            this.appRenderVS.UseVisualStyleBackColor = true;
            // 
            // compEnabledCheck
            // 
            this.compEnabledCheck.AutoSize = true;
            this.compEnabledCheck.Location = new System.Drawing.Point(6, 18);
            this.compEnabledCheck.Name = "compEnabledCheck";
            this.compEnabledCheck.Size = new System.Drawing.Size(138, 16);
            this.compEnabledCheck.TabIndex = 0;
            this.compEnabledCheck.Text = "Composition Enabled";
            this.toolTip1.SetToolTip(this.compEnabledCheck, "Indicates if Desktop Window Composition (Aero) is enabled. For Windows Vista and " +
        "Windows 7, this setting is user configurable.");
            this.compEnabledCheck.UseVisualStyleBackColor = true;
            this.compEnabledCheck.CheckedChanged += new System.EventHandler(this.compEnabledCheck_CheckedChanged);
            // 
            // vsEnabledByUser
            // 
            this.vsEnabledByUser.AutoCheck = false;
            this.vsEnabledByUser.AutoSize = true;
            this.vsEnabledByUser.Location = new System.Drawing.Point(149, 18);
            this.vsEnabledByUser.Name = "vsEnabledByUser";
            this.vsEnabledByUser.Size = new System.Drawing.Size(114, 16);
            this.vsEnabledByUser.TabIndex = 0;
            this.vsEnabledByUser.Text = "VSEnabledByUser";
            this.toolTip1.SetToolTip(this.vsEnabledByUser, "Indicates if Visual Styles are enabled by the user.");
            this.vsEnabledByUser.UseVisualStyleBackColor = true;
            // 
            // vsOnOS
            // 
            this.vsOnOS.AutoCheck = false;
            this.vsOnOS.AutoSize = true;
            this.vsOnOS.Location = new System.Drawing.Point(149, 39);
            this.vsOnOS.Name = "vsOnOS";
            this.vsOnOS.Size = new System.Drawing.Size(60, 16);
            this.vsOnOS.TabIndex = 0;
            this.vsOnOS.Text = "VSonOS";
            this.toolTip1.SetToolTip(this.vsOnOS, "Indicates if Visual Styles are enabled by the Operating System.");
            this.vsOnOS.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.compEnabledCheck);
            this.groupBox1.Controls.Add(this.appRenderVS);
            this.groupBox1.Controls.Add(this.vsOnOS);
            this.groupBox1.Controls.Add(this.vsEnabledByUser);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Environment";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.oldButton);
            this.groupBox2.Controls.Add(this.customBtn);
            this.groupBox2.Controls.Add(this.stepBtn);
            this.groupBox2.Controls.Add(this.wizBtn);
            this.groupBox2.Location = new System.Drawing.Point(12, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 76);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wizard";
            // 
            // oldButton
            // 
            this.oldButton.Location = new System.Drawing.Point(149, 45);
            this.oldButton.Name = "oldButton";
            this.oldButton.Size = new System.Drawing.Size(107, 21);
            this.oldButton.TabIndex = 0;
            this.oldButton.Text = "Old Wizard";
            this.oldButton.UseVisualStyleBackColor = true;
            this.oldButton.Click += new System.EventHandler(this.oldButton_Click);
            // 
            // customBtn
            // 
            this.customBtn.Location = new System.Drawing.Point(7, 45);
            this.customBtn.Name = "customBtn";
            this.customBtn.Size = new System.Drawing.Size(107, 21);
            this.customBtn.TabIndex = 0;
            this.customBtn.Text = "Custom Wizard";
            this.toolTip1.SetToolTip(this.customBtn, "Launches a custom wizard.");
            this.customBtn.UseVisualStyleBackColor = true;
            this.customBtn.Click += new System.EventHandler(this.customBtn_Click);
            // 
            // stepBtn
            // 
            this.stepBtn.Location = new System.Drawing.Point(149, 18);
            this.stepBtn.Name = "stepBtn";
            this.stepBtn.Size = new System.Drawing.Size(107, 21);
            this.stepBtn.TabIndex = 0;
            this.stepBtn.Text = "Step Wizard";
            this.toolTip1.SetToolTip(this.stepBtn, "Lauches a modification of the Aero Wizard that includes a checked step list on th" +
        "e left.");
            this.stepBtn.UseVisualStyleBackColor = true;
            this.stepBtn.Click += new System.EventHandler(this.stepBtn_Click);
            // 
            // wizBtn
            // 
            this.wizBtn.Location = new System.Drawing.Point(7, 18);
            this.wizBtn.Name = "wizBtn";
            this.wizBtn.Size = new System.Drawing.Size(107, 21);
            this.wizBtn.TabIndex = 0;
            this.wizBtn.Text = "Aero Wizard";
            this.toolTip1.SetToolTip(this.wizBtn, "Launches a wizard using the Aero Wizard styling defined for Operating Systems aft" +
        "er Windows Vista.");
            this.wizBtn.UseVisualStyleBackColor = true;
            this.wizBtn.Click += new System.EventHandler(this.wizBtn_Click);
            // 
            // stepWizardControl1
            // 
            this.stepWizardControl1.Location = new System.Drawing.Point(0, 0);
            this.stepWizardControl1.Name = "stepWizardControl1";
            this.stepWizardControl1.Pages.Add(this.wizardPage1);
            this.stepWizardControl1.Pages.Add(this.wizardPage2);
            this.stepWizardControl1.Pages.Add(this.wizardPage3);
            this.stepWizardControl1.Pages.Add(this.wizardPage4);
            this.stepWizardControl1.Pages.Add(this.wizardPage5);
            this.stepWizardControl1.Pages.Add(this.wizardPage6);
            this.stepWizardControl1.Pages.Add(this.wizardPage7);
            this.stepWizardControl1.Size = new System.Drawing.Size(834, 324);
            this.stepWizardControl1.TabIndex = 4;
            // 
            // wizardPage1
            // 
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(636, 169);
            this.wizardPage1.TabIndex = 2;
            this.wizardPage1.Text = "wizardPage1";
            // 
            // wizardPage2
            // 
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(615, 11);
            this.wizardPage2.TabIndex = 3;
            this.wizardPage2.Text = "wizardPage2";
            // 
            // wizardPage3
            // 
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(615, 11);
            this.wizardPage3.TabIndex = 4;
            this.wizardPage3.Text = "wizardPage3";
            // 
            // wizardPage4
            // 
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.Size = new System.Drawing.Size(615, 11);
            this.wizardPage4.TabIndex = 5;
            this.wizardPage4.Text = "wizardPage4";
            // 
            // wizardPage5
            // 
            this.wizardPage5.Name = "wizardPage5";
            this.wizardPage5.Size = new System.Drawing.Size(615, 11);
            this.wizardPage5.TabIndex = 6;
            this.wizardPage5.Text = "wizardPage5";
            // 
            // wizardPage6
            // 
            this.wizardPage6.Name = "wizardPage6";
            this.wizardPage6.Size = new System.Drawing.Size(615, 11);
            this.wizardPage6.TabIndex = 7;
            this.wizardPage6.Text = "wizardPage6";
            // 
            // wizardPage7
            // 
            this.wizardPage7.Name = "wizardPage7";
            this.wizardPage7.Size = new System.Drawing.Size(615, 11);
            this.wizardPage7.TabIndex = 8;
            this.wizardPage7.Text = "wizardPage7";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 324);
            this.Controls.Add(this.stepWizardControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wizard Test C#源码世界";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stepWizardControl1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox appRenderVS;
		private System.Windows.Forms.CheckBox compEnabledCheck;
		private System.Windows.Forms.CheckBox vsEnabledByUser;
		private System.Windows.Forms.CheckBox vsOnOS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button customBtn;
		private System.Windows.Forms.Button stepBtn;
		private System.Windows.Forms.Button wizBtn;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button oldButton;
        private AeroWizard.StepWizardControl stepWizardControl1;
        private AeroWizard.WizardPage wizardPage1;
        private AeroWizard.WizardPage wizardPage2;
        private AeroWizard.WizardPage wizardPage3;
        private AeroWizard.WizardPage wizardPage4;
        private AeroWizard.WizardPage wizardPage5;
        private AeroWizard.WizardPage wizardPage6;
        private AeroWizard.WizardPage wizardPage7;

    }
}