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
    public partial class frmShowWarn : Form
    {
        public frmShowWarn()
        {
            InitializeComponent();
        }

        private void ucWarnInfo1_Load(object sender, EventArgs e)
        {

        }

        private void frmShowWarn_Load(object sender, EventArgs e)
        {

        }

        bool isMin = false;
        public bool IsMin
        {
            get { return isMin; }
            set { isMin = value; } 
        }
        public void btnMin_Click(object sender, EventArgs e)
        {
            isMin = !isMin;
            if (isMin) 
            {
                //this.Height = 80;
                this.ucWarnInfo1.dgvView.Columns[3].Visible = false;
                this.ucWarnInfo1.dgvView.Columns[4].Visible = false;
                this.ucWarnInfo1.dgvView.Columns[2].Width =300;
                int count = this.ucWarnInfo1.dgvView.Rows.Count;
                this.Height = 80 + count * 40 ;
                this.btnMin.Text = "还原";
            } 
            else
            {
                this.ucWarnInfo1.dgvView.Columns[3].Visible = true;
                this.ucWarnInfo1.dgvView.Columns[4].Visible = true;
                this.ucWarnInfo1.dgvView.Columns[2].Width = 60;
                this.Height = 486;
                this.btnMin.Text = "缩小";
            } 
        }
    }
}
