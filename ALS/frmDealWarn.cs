using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ALS
{
    public partial class frmDealWarn : Form
    {
        public delegate void btnclose(object sender, EventArgs e);
        public event btnclose _btnClose;

        public delegate void btnstartsp(object sender, EventArgs e);
        public event btnstartsp _btnstartsp;

        public delegate void btnspfast(object sender, EventArgs e);
        public event btnspfast _btnspfast;

        public delegate void btnChkV(object sender, EventArgs e);
        public event btnChkV _btnChkV;

        //断口初始化
        SerialPort mPort = new SerialPort();
        SerialPort hPort = new SerialPort();

        public SerialPort _mPort
        {
            get { return mPort; }
            set { mPort = value; }
        }
        public SerialPort _hPort
        {
            get { return hPort;}
            set { hPort = value; }
        }
        
        public frmDealWarn()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (_btnClose != null)
            {
                _btnClose(sender, e);
            }
        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(mPort, Cls.Comm_Main.LiquidLevel.liquidLevel1Up);  
        }

        private void frmdeal_spstart_Click(object sender, EventArgs e)
        {
            //快进键变为可用 
            if (_btnstartsp != null)
                _btnstartsp(sender, e);
        }
 

        private void button3_Click(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(mPort, Cls.Comm_Main.LiquidLevel.liquidLevel1Down);
        }

        private void chkV1_Click(object sender, EventArgs e)
        {
            if (_btnChkV != null)
                _btnChkV(sender, e);
        }

        private void frmDealWarn_Load(object sender, EventArgs e)
        {

        }

        public void ReadVState(Cls.Model_State _state)
        {
            if (_state.VState[0] == 1)
            {
                chkV1.Image = global::ALS.Properties.Resources.clipclose;
                chkV1.Checked = true;
                //chkV1.Text = "松开";
            }
            else
            {
                chkV1.Image = global::ALS.Properties.Resources.clipopen;
                chkV1.Checked = false;
                //chkV1.Text = "夹管";
            }

            if (_state.VState[1] == 1)
            {
                chkV2.Image = global::ALS.Properties.Resources.clipclose;
                chkV2.Checked = true;
                //chkV2.Text = "松开";
            }
            else
            {
                chkV2.Image = global::ALS.Properties.Resources.clipopen;
                chkV2.Checked = false;
                //chkV2.Text = "夹管";
            }
        }
    }
}
