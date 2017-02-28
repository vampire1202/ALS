namespace AeroWizard
{
	partial class WizardControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.titleImageList = new System.Windows.Forms.ImageList(this.components);
            this.commandAreaBorder = new System.Windows.Forms.Panel();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.contentArea = new AeroWizard.ThemedTableLayoutPanel();
            this.pageContainer = new AeroWizard.WizardPageContainer();
            this.backButton = new AeroWizard.ThemedImageButton();
            this.cancelButton = new CCWin.SkinControl.SkinButton();
            this.nextButton = new CCWin.SkinControl.SkinButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.commandArea = new AeroWizard.ThemedTableLayoutPanel();
            this.titleBar = new AeroWizard.ThemedTableLayoutPanel();
            this.title = new AeroWizard.ThemedLabel();
            this.titleImage = new System.Windows.Forms.PictureBox();
            this.bodyPanel.SuspendLayout();
            this.contentArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageContainer)).BeginInit();
            this.commandArea.SuspendLayout();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // titleImageList
            // 
            this.titleImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.titleImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.titleImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // commandAreaBorder
            // 
            this.commandAreaBorder.BackColor = System.Drawing.SystemColors.ControlLight;
            this.commandAreaBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandAreaBorder.Location = new System.Drawing.Point(0, 345);
            this.commandAreaBorder.Margin = new System.Windows.Forms.Padding(0);
            this.commandAreaBorder.Name = "commandAreaBorder";
            this.commandAreaBorder.Size = new System.Drawing.Size(618, 1);
            this.commandAreaBorder.TabIndex = 2;
            // 
            // bodyPanel
            // 
            this.bodyPanel.Controls.Add(this.contentArea);
            this.bodyPanel.Controls.Add(this.splitter1);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bodyPanel.Location = new System.Drawing.Point(0, 32);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(618, 313);
            this.bodyPanel.TabIndex = 1;
            // 
            // contentArea
            // 
            this.contentArea.BackColor = System.Drawing.SystemColors.Window;
            this.contentArea.ColumnCount = 3;
            this.contentArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.contentArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.contentArea.Controls.Add(this.pageContainer, 1, 0);
            this.contentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentArea.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contentArea.Location = new System.Drawing.Point(0, 1);
            this.contentArea.Name = "contentArea";
            this.contentArea.RowCount = 1;
            this.contentArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentArea.Size = new System.Drawing.Size(618, 312);
            this.contentArea.TabIndex = 1;
            this.contentArea.Paint += new System.Windows.Forms.PaintEventHandler(this.contentArea_Paint);
            // 
            // pageContainer
            // 
            this.pageContainer.BackButton = this.backButton;
            this.pageContainer.BackButtonText = "";
            this.pageContainer.CancelButton = this.cancelButton;
            this.pageContainer.CancelButtonText = "抗凝剂泵";
            this.pageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageContainer.FinishButtonText = "回收";
            this.pageContainer.Location = new System.Drawing.Point(15, 0);
            this.pageContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pageContainer.Name = "pageContainer";
            this.pageContainer.NextButton = this.nextButton;
            this.pageContainer.NextButtonText = "下一步";
            this.pageContainer.Size = new System.Drawing.Size(593, 312);
            this.pageContainer.TabIndex = 0;
            this.pageContainer.Cancelling += new System.ComponentModel.CancelEventHandler(this.pageContainer_Cancelling);
            this.pageContainer.Finished += new System.EventHandler(this.pageContainer_Finished);
            this.pageContainer.SelectedPageChanged += new System.EventHandler(this.pageContainer_SelectedPageChanged);
            // 
            // backButton
            // 
            this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.backButton.Enabled = false;
            this.backButton.Image = null;
            this.backButton.Location = new System.Drawing.Point(0, 5);
            this.backButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(30, 30);
            this.backButton.StyleClass = "NAVIGATION";
            this.backButton.TabIndex = 0;
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.cancelButton.BorderColor = System.Drawing.Color.Silver;
            this.cancelButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cancelButton.DownBack = null;
            this.cancelButton.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(307, 1);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(7, 0, 50, 0);
            this.cancelButton.MinimumSize = new System.Drawing.Size(70, 0);
            this.cancelButton.MouseBack = null;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.NormlBack = null;
            this.cancelButton.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.cancelButton.Size = new System.Drawing.Size(80, 40);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Tag = "spset";
            this.cancelButton.Text = "抗凝剂泵";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextButton.BackColor = System.Drawing.Color.Transparent;
            this.nextButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(96)))), ((int)(((byte)(152)))));
            this.nextButton.BorderColor = System.Drawing.Color.Silver;
            this.nextButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.nextButton.DownBack = null;
            this.nextButton.ForeColor = System.Drawing.Color.White;
            this.nextButton.Location = new System.Drawing.Point(548, 1);
            this.nextButton.Margin = new System.Windows.Forms.Padding(0);
            this.nextButton.MinimumSize = new System.Drawing.Size(70, 0);
            this.nextButton.MouseBack = null;
            this.nextButton.Name = "nextButton";
            this.nextButton.NormlBack = null;
            this.nextButton.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.nextButton.Size = new System.Drawing.Size(70, 40);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "下一步";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(618, 1);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // commandArea
            // 
            this.commandArea.AutoSize = true;
            this.commandArea.BackColor = System.Drawing.SystemColors.Window;
            this.commandArea.ColumnCount = 4;
            this.commandArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.commandArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.commandArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.commandArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.commandArea.Controls.Add(this.nextButton, 3, 1);
            this.commandArea.Controls.Add(this.backButton, 0, 1);
            this.commandArea.Controls.Add(this.cancelButton, 2, 1);
            this.commandArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.commandArea.Location = new System.Drawing.Point(0, 346);
            this.commandArea.Name = "commandArea";
            this.commandArea.RowCount = 3;
            this.commandArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.commandArea.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.commandArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.commandArea.Size = new System.Drawing.Size(618, 42);
            this.commandArea.TabIndex = 3;
            // 
            // titleBar
            // 
            this.titleBar.AutoSize = true;
            this.titleBar.BackColor = System.Drawing.Color.White;
            this.titleBar.ColumnCount = 2;
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.titleBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.titleBar.Controls.Add(this.title, 1, 0);
            this.titleBar.Controls.Add(this.titleImage, 0, 0);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.RowCount = 1;
            this.titleBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.titleBar.Size = new System.Drawing.Size(618, 32);
            this.titleBar.SupportGlass = true;
            this.titleBar.TabIndex = 0;
            this.titleBar.WatchFocus = true;
            this.titleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.titleBar_Paint);
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.title.AutoSize = true;
            this.title.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.title.Location = new System.Drawing.Point(35, 6);
            this.title.Margin = new System.Windows.Forms.Padding(0);
            this.title.Name = "title";
            this.title.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.title.Size = new System.Drawing.Size(126, 20);
            this.title.TabIndex = 2;
            this.title.Text = "Wizard Title";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          
            // 
            // WizardControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.commandAreaBorder);
            this.Controls.Add(this.commandArea);
            this.Controls.Add(this.titleBar);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WizardControl";
            this.Size = new System.Drawing.Size(618, 388);
            this.bodyPanel.ResumeLayout(false);
            this.contentArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageContainer)).EndInit();
            this.commandArea.ResumeLayout(false);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.titleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private AeroWizard.ThemedTableLayoutPanel titleBar;
		private AeroWizard.ThemedTableLayoutPanel commandArea;
        private CCWin.SkinControl.SkinButton cancelButton;
        internal CCWin.SkinControl.SkinButton nextButton;
		internal AeroWizard.ThemedImageButton backButton;
		private System.Windows.Forms.Panel commandAreaBorder;
		private System.Windows.Forms.ImageList titleImageList;
		private System.Windows.Forms.Panel bodyPanel;
		private ThemedTableLayoutPanel contentArea;
        internal AeroWizard.WizardPageContainer pageContainer;
        private System.Windows.Forms.Splitter splitter1;
        private ThemedLabel title;
        private System.Windows.Forms.PictureBox titleImage;

	}
}
