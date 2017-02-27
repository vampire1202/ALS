
//#define LOG_SYSTEM
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ALS;

namespace ALS.FormOperation
{
    public partial class step_CHDF : UserControl
    {
        public delegate void StartRecycle(object sender, EventArgs e);
        public event StartRecycle _StartRecycle;

        public delegate void CHDFSteps(object sender, EventArgs e);
        public event CHDFSteps _CHDFSteps;

        public delegate void SPSet(object sender, EventArgs e);
        public event SPSet _SpSet;

        public delegate void SelectStepChanged(object sender, EventArgs e);
        public event SelectStepChanged _SelectStepChanged;

        /// <summary>
        /// 压力值范围模型
        /// </summary>
        private Model.treatmentmode _modelTreat;
        public Model.treatmentmode _ModelTreat
        {
            get { return _modelTreat; }
            set { _modelTreat = value; }
        }

        private SerialPort _port_ppump;
        /// <summary>
        /// 蠕动泵通讯端口
        /// </summary>
        public SerialPort _Port_ppump
        {
            get { return _port_ppump; }
            set { _port_ppump = value; }
        }

        public step_CHDF()
        {
            InitializeComponent();
        }
        

        public void ReadSet()
        {
            this.lblTargetSpeed.Text = _modelTreat.LeadBloodSpeed.Value.ToString("f0");    
        }
        private void btnStartCHDF_Click(object sender, EventArgs e)
        {
            this.btnStartCHDF.Enabled = false;
            this.btnPauseCHDF.Enabled = true; 
            //回收按键置灰不隐藏
            this.wizardPage2.AllowNext = false;  
            this.wizardPage2.AllowBack = false;

#if LOG_SYSTEM
            new ALS.LogClass().WriteLogFile("frmMain,547,btnStartZhihuan_Click");
#endif
            if (_CHDFSteps != null)
                _CHDFSteps(sender, e); 
        }

         
        public void btnPauseCHDF_Click(object sender, EventArgs e)
        {
            this.btnStartCHDF.Enabled = true;
            this.btnPauseCHDF.Enabled = false; 
            this.wizardPage2.AllowNext = true;  
            this.wizardPage2.AllowBack = true;
            if (_CHDFSteps != null)
                _CHDFSteps(sender, e); 
        }

        private void step_PE_Load(object sender, EventArgs e)
        {
            ReadSet();
        }

        private void wizardControl1_Finished(object sender, EventArgs e)
        {
             if (_StartRecycle != null)
                _StartRecycle(sender, e);
        }

        private void wizardControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (_SelectStepChanged != null)
                _SelectStepChanged(sender, e);
        }

        private void wizardControl1_Cancelling(object sender, CancelEventArgs e)
        {
            if (_SpSet != null)
                _SpSet(sender, e); 
        } 
    }
}
