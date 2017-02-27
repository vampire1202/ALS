
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
    public partial class step_PDF : UserControl
    {
        public delegate void StartRecycle(object sender, EventArgs e);
        public event StartRecycle _StartRecycle;

        public delegate void PDFSteps(object sender, EventArgs e);
        public event PDFSteps _PDFSteps;

        public delegate void SelectStepChanged(object sender, EventArgs e);
        public event SelectStepChanged _SelectStepChanged;

        public delegate void SPSet(object sender, EventArgs e);
        public event SPSet _SPSet;

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

        public step_PDF()
        {
            InitializeComponent();
        }
        

        public void ReadSet()
        {
            this.lblTargetSpeed.Text = _modelTreat.LeadBloodSpeed.Value.ToString("f0");
        }
        private void btnStartPDF_Click(object sender, EventArgs e)
        {
            this.btnStartPDF.Enabled = false;
            this.btnPausePDF.Enabled = true; 
            //回收按键置灰不隐藏
            this.wizardPage2.AllowNext = false; 
            this.wizardPage2.AllowBack = false;

#if LOG_SYSTEM
            new ALS.LogClass().WriteLogFile("frmMain,547,btnStartZhihuan_Click");
#endif
            if (_PDFSteps != null)
                _PDFSteps(sender, e); 
        }
 

        public void btnPausePDF_Click(object sender, EventArgs e)
        {
            this.btnStartPDF.Enabled = true;
            this.btnPausePDF.Enabled = false; 
            this.wizardPage2.AllowNext = true; 
            this.wizardPage2.AllowBack = true;
            if (_PDFSteps != null)
                _PDFSteps(sender, e); 
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
            if (_SPSet != null)
                _SPSet(sender, e);
        }
    }
}
