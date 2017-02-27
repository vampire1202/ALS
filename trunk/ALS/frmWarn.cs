using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALS
{
    public partial class frmWarn : Form
    {
        public frmWarn()
        {
            InitializeComponent();
            this.btnRelease.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public Color _TitleColor
        {
            get { return this.lblTitle.ForeColor; }
            set { this.lblTitle.ForeColor = value; }
        }

        //public Color _ContentColor
        //{
        //    get { return this.rtBox.ForeColor; }
        //    set { this.rtBox.ForeColor = value; }
        //}

        
        public delegate void delbtnMute(object sender, EventArgs e);
        public event delbtnMute btnMuteClick; 
        public delegate void delBtnRelease(object sender, EventArgs e);
        public event delBtnRelease btnReleaseClick;

        private void frmWarn_Load(object sender, EventArgs e)
        {

        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (btnMuteClick != null)
                btnMuteClick(sender, e);
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if(btnReleaseClick!=null)
                btnReleaseClick(sender,e);
        }
 
    }
}
