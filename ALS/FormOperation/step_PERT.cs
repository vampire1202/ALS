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

namespace ALS.FormOperation
{
    public partial class step_PERT : UserControl
    {  
        public delegate void StartRecycle(object sender, EventArgs e);
        public event StartRecycle _StartRecycle;

        public delegate void PERTSteps(object sender, EventArgs e);
        public event PERTSteps _PERTSteps;

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

        public step_PERT()
        {
            InitializeComponent();
        }
        

        public void ReadSet()
        {
            this.lblTargetBPSpeed.Text = this.lblXuelvBpTarget.Text = _modelTreat.LeadBloodSpeed.Value.ToString("f0");
        } 
 

        private void btnStartPE_Click(object sender, EventArgs e)
        {
            this.btnStartPE.Enabled = false;
            this.btnPausePE.Enabled = true;    
            this.wizardPage2.AllowNext = false;
            this.wizardPage2.AllowBack = false;
            if (_PERTSteps != null)
                _PERTSteps(sender, e);
        }

        public void btnPausePE_Click(object sender, EventArgs e)
        {
            this.btnStartPE.Enabled = true;
            this.btnPausePE.Enabled = false; 
            this.wizardPage2.AllowBack = true;
            this.wizardPage2.AllowNext = true; 
            if (_PERTSteps != null)
                _PERTSteps(sender, e);
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

        private void btnStartRecycle_Click(object sender, EventArgs e)
        {
            this.btnStartRecycle.Enabled = false;
            this.btnStopRecycle.Enabled = true;
            this.wizardPage3.AllowBack = false;
            this.wizardPage3.AllowNext = false;
            if (_PERTSteps != null)
                _PERTSteps(sender, e);
        }

        public void btnStopRecycle_Click(object sender, EventArgs e)
        {
            this.btnStartRecycle.Enabled = true;
            this.btnStopRecycle.Enabled = false;
            this.wizardPage3.AllowBack = true;
            this.wizardPage3.AllowNext = true;
            if (_PERTSteps != null)
                _PERTSteps(sender, e);
        }

        private void btnStartCHDF_Click(object sender, EventArgs e)
        {
            this.btnStartCHDF.Enabled = false;
            this.btnPauseCHDF.Enabled = true;
            this.wizardPage5.AllowBack = false;
            this.wizardPage5.AllowNext = false;
            if (_PERTSteps != null)
                _PERTSteps(sender, e);
        }

        public void btnPauseCHDF_Click(object sender, EventArgs e)
        {
            this.btnStartCHDF.Enabled = true;
            this.btnPauseCHDF.Enabled = false;
            this.wizardPage5.AllowBack = true;
            this.wizardPage5.AllowNext = true;
            if (_PERTSteps != null)
                _PERTSteps(sender, e);
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
