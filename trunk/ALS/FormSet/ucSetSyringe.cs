using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace ALS.FormSet
{
    public partial class ucSetSyringe : UserControl
    {

        public ucSetSyringe()
        {
            InitializeComponent();
        }

        private SerialPort _port_hpump;
        /// <summary>
        /// 该界面通讯串口
        /// </summary>
        public SerialPort _Port_hpump
        {
            get { return _port_hpump; }
            set { _port_hpump = value; }
        }

        private Cls.Model_Set _modelSet;
        public Cls.Model_Set _ModelSet
        {
            get { return _modelSet; }
            set { _modelSet = value; }
        }

        private string _section;
        public string _Section
        {
            get { return _section; }
            set { _section = value; }
        }

        public delegate void btnSaveSP(object sender, EventArgs e);
        public event btnSaveSP btnSave_SP;
        
        public delegate void btnRunSP(object sender, EventArgs e);
        public event btnRunSP btnRun_SP;
        
        public delegate void btnStopSP(object sender, EventArgs e);
        public event btnStopSP btnStop_SP;

        public delegate void lblSpeedChanged(object sender, EventArgs e);
        public event lblSpeedChanged lblSpeed_Changed;

        private void frmSetPump_SizeChanged(object sender, EventArgs e)
        {
            //this.groupSet.Left = (this.Width - this.groupSet.Width) / 2;
            //this.groupSet.Top = (this.Height - this.groupSet.Height) / 2;
            //获取当前分辨率
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 898.0f;
            float y = rec.Height / 578.0f;
            Cls.utils.AutoSize(this, x, y);
        }

        private void rbtn20_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                rb.BackColor = Color.FromArgb(15,8,100);
                rb.ForeColor = Color.White;
            }
            else
            {
                rb.BackColor = Color.Transparent;
                rb.ForeColor = Color.FromArgb(15, 8, 100) ;
            }
        }

        private void chbMegadose_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                cb.BackColor = Color.FromArgb(15, 8, 100);
                cb.ForeColor = Color.White;
            }
            else
            {
                cb.BackColor = Color.Transparent;
                cb.ForeColor = Color.FromArgb(15, 8, 100);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSPSet();
            MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (btnSave_SP != null)
                btnSave_SP(sender, e);
        } 

        private void lblSpeed_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                lbl.Text = _numPad.Value.ToString("f1");
            }
        }

        private void ucSetSyringe_Load(object sender, EventArgs e)
        {
            ReadSPSet(_section);
        }

        public void ReadSPSet(string sec)
        {
            this.lblSpeed.Text = Cls.utils.GetSectionKeyValue(sec, "SP_Speed"); //Cls.RWconfig.GetAppSettings("SP_Speed");      
            //string spIsMegadose = Cls.RWconfig.GetAppSettings("SP_IsMegadose");
            //string spIsRapidInjection = Cls.RWconfig.GetAppSettings("SP_IsRapidInjection");
            this.lblRapidInjection.Text = Cls.utils.GetSectionKeyValue(sec, "SP_RapidInjectionValue");//Cls.RWconfig.GetAppSettings("SP_RapidInjectionValue");
        }

        private void SaveSPSet()
        {
            Cls.utils.SetSectionKeyValue(_section, "SP_Speed", this.lblSpeed.Text);  //Cls.RWconfig.SetAppSettings("SP_Speed", this.lblSpeed.Text); 
            Cls.utils.SetSectionKeyValue(_section, "SP_RapidInjectionValue", this.lblRapidInjection.Text); //Cls.RWconfig.SetAppSettings("SP_RapidInjectionValue", this.lblRapidInjection.Text);
            ReadSPSet(_section);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Stop);
        }

        private void lbl20Len_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                lbl.Text = _numPad.Value.ToString("f1");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {

        }

        private void rbtnJierui_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                rb.BackColor = Color.FromArgb(31, 163, 215);
                rb.ForeColor = Color.White;
            }
            else
            {
                rb.BackColor = Color.Transparent;
                rb.ForeColor = Color.FromArgb(15, 8, 100);
            }          
        }

        private void btnFast_Click(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(_port_hpump,Cls.Comm_SyringePump.Stop);
            Cls.utils.SendOrder(_port_hpump,Cls.Comm_SyringePump.FastForward(1000));
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (btnRun_SP != null)
                btnRun_SP(sender, e);
            //Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Start(500,500));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (btnStop_SP != null)
                btnStop_SP(sender, e);
            //Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Stop);
        }

        private void lblSpeed_TextChanged(object sender, EventArgs e)
        {
            if (lblSpeed_Changed != null)
                lblSpeed_Changed(sender, e);
            //保存改变速度
            //Cls.RWconfig.SetAppSettings("SP_Speed", this.lblSpeed.Text);  
            Cls.utils.SetSectionKeyValue(_section, "SP_Speed", this.lblSpeed.Text);
        }
    }
}
