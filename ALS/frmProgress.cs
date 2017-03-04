using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALS
{
    public partial class frmProgress : Form
    {
        public frmProgress()
        {
            InitializeComponent();
        }
 

        private void frmProgress_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(170, 10);
        }
    }
}
