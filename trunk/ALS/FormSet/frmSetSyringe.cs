using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace ALS.FormSet
{
    public partial class frmSetSyringe : Form
    {
        public frmSetSyringe()
        {
            InitializeComponent();
        }

        private SerialPort _port_hpump;
        /// <summary>
        /// 注射器通讯串口
        /// </summary>
        public SerialPort _Port_hpump
        {
            get { return _port_hpump; }
            set { _port_hpump = value; }
        }

        private void frmSetSyringe_Load(object sender, EventArgs e)
        {
            ReadLenConfig();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveLenConfig();
            ReadLenConfig();
            MessageBox.Show("保存成功!");
        }

        private void SaveLenConfig()
        {
            Cls.RWconfig.SetAppSettings("SP_20Len", this.txtLen20.Text);
            Cls.RWconfig.SetAppSettings("SP_30Len", this.txtLen30.Text);
            Cls.RWconfig.SetAppSettings("SP_50Len", this.txtLen50.Text);
        }

        private void ReadLenConfig()
        {
            this.txtLen20.Text = Cls.RWconfig.GetAppSettings("SP_20Len");
            this.txtLen30.Text = Cls.RWconfig.GetAppSettings("SP_30Len");
            this.txtLen50.Text = Cls.RWconfig.GetAppSettings("SP_50Len");
        }

        private void txtLen20_Click(object sender, EventArgs e)
        {
            TextBox lbl = (TextBox)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                double val = _numPad.Value;
                if (val > 0 && val < 200.0)
                    lbl.Text = val.ToString("f1");
                else
                    MessageBox.Show("设置的值不符合规范!");
            }
        }
    }
}
