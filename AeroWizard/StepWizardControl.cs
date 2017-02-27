using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace AeroWizard
{
	/// <summary>
	/// Wizard control that shows a step summary on the left of the wizard page area.
	/// </summary>
	public class StepWizardControl : WizardControl
	{
        private StepList list;
        private Splitter splitter;

		/// <summary>
		/// Initializes a new instance of the <see cref="StepWizardControl"/> class.
		/// </summary>
		public StepWizardControl()
		{
            this.pageContainer.Controls.Add(splitter = new Splitter() { Dock = DockStyle.Left, BorderStyle = BorderStyle.None,BackColor=Color.Gainsboro, Width = 1 });
            this.pageContainer.Controls.Add(list = new StepList() { Dock = DockStyle.Left });
            this.Pages.Reset += Pages_Reset;
		}

        /// <summary>
        /// Gets or sets the width of the step list.
        /// </summary>
        /// <value>
        /// The width of the step list.
        /// </value>
        [DefaultValue(120), Category("Appearance"), Description("Determines width of step list on left.")]
        public int StepListWidth
        {
            get { return list.Width; }
            set { list.Width = value; }
        }

        void Pages_Reset(object sender, System.Collections.Generic.EventedList<WizardPage>.ListChangedEventArgs<WizardPage> e)
        {
            this.pageContainer.Controls.Add(splitter);
            this.pageContainer.Controls.Add(list);
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // StepWizardControl
            // 
            this.AutoSize = true;
            this.Name = "StepWizardControl";
            this.Size = new System.Drawing.Size(739, 354);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
	}
}
