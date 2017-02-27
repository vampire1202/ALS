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
    public partial class step_LiAlS : UserControl
    {
        public step_LiAlS()
        {
            InitializeComponent();
        }
        public delegate void LiAlsSteps(object sender, EventArgs e);
        public event LiAlsSteps _btnsLiAlsWizard;

        public delegate void StartRecycle(object sender, EventArgs e);
        public event StartRecycle _StartRecycle;

        public delegate void SavePETotal(object sender, EventArgs e);
        public event SavePETotal _SavePETotal;

        public delegate void SelectStepChanged(object sender, EventArgs e);
        public event SelectStepChanged _SelectStepChanged;

        public delegate void SPSet(object sender, EventArgs e);
        public event SPSet _SPSet;

        private SerialPort _port_ppump;
        /// <summary>
        /// 蠕动泵通讯端口
        /// </summary>
        public SerialPort _Port_ppump
        {
            get { return _port_ppump; }
            set { _port_ppump = value; }
        }
        //添加COM1端口，在治疗过程中停止治疗时，发送停止加热；
        //wss 2016年2月20日
        private SerialPort _port_main;
        public SerialPort _Port_main
        {
            get { return _port_main; }
            set { _port_main = value; }
        }
        /// <summary>
        /// 压力值范围模型
        /// </summary>
        private Model.treatmentmode _modelTreat;
        public Model.treatmentmode _ModelTreat
        {
            get { return _modelTreat; }
            set { _modelTreat = value; }
        }
        public void ReadSet()
        {
            this.lblBPSpeed.Text = _modelTreat.LeadBloodSpeed.Value.ToString("f0");
        }


        private void btnStartZhihuan_Click(object sender, EventArgs e)
        {
            //HPTCMessageBox.MSBox m = new HPTCMessageBox.MSBox("警 告","请确定C1松开!", HPTCMessageBox.MSBox.MSBoxIcon.Warning, global::ALS.Properties.Resources.StepLi_1);
            UserCtrl.MsgBox m = new UserCtrl.MsgBox("警告: 请确定管夹C1松开!", UserCtrl.MsgBox.MSBoxIcon.Warning, global::ALS.Properties.Resources.StepLi_1, true);
            if (DialogResult.OK == m.ShowDialog())
            {
                if (_btnsLiAlsWizard != null)
                    _btnsLiAlsWizard(this.btnStartPE, e);
                this.btnStartPE.Enabled = false;
                this.btnPausePE.Enabled = true;
                this.wizardControl1.SelectedPage.AllowNext = false;
                this.wizardControl1.SelectedPage.AllowBack = false;
            }
        }

        public void btnStopZhihuan_Click(object sender, EventArgs e)
        {
            if (_btnsLiAlsWizard != null)
                _btnsLiAlsWizard(this.btnPausePE, e);

            this.btnStartPE.Enabled = true;
            this.btnPausePE.Enabled = false;
            this.wizardControl1.SelectedPage.AllowNext = true;
            this.wizardControl1.SelectedPage.AllowBack = true;
        }

        private void btnStartShouji_Click(object sender, EventArgs e)
        {
            //HPTCMessageBox.MSBox m = new HPTCMessageBox.MSBox("警  告","请确认管夹C1闭合！", HPTCMessageBox.MSBox.MSBoxIcon.Warning, global::ALS.Properties.Resources.StepLi_2);
            UserCtrl.MsgBox m = new UserCtrl.MsgBox("警告: 请确定管夹C1闭合!", UserCtrl.MsgBox.MSBoxIcon.Warning, global::ALS.Properties.Resources.StepLi_2, true);
            if (DialogResult.OK == m.ShowDialog())
            {
                if (_btnsLiAlsWizard != null)
                    _btnsLiAlsWizard(this.btnStartShouji, e);
                this.btnStartShouji.Enabled = false;
                this.btnStopShouji.Enabled = true;
                this.wizardControl1.SelectedPage.AllowNext = false;
                this.wizardControl1.SelectedPage.AllowBack = false;
            }
        }

        public void btnStopShouji_Click(object sender, EventArgs e)
        {
            if (_btnsLiAlsWizard != null)
                _btnsLiAlsWizard(this.btnStopShouji, e);
            this.btnStartShouji.Enabled = true;
            this.btnStopShouji.Enabled = false;
            this.wizardControl1.SelectedPage.AllowNext = true;
            this.wizardControl1.SelectedPage.AllowBack = true;
        }

        public void btnStartTreat_Click(object sender, EventArgs e)
        {
            if (_btnsLiAlsWizard != null)
                _btnsLiAlsWizard(this.btnStartTreat, e);
            this.wizardControl1.SelectedPage.AllowNext = false;
            this.wizardControl1.SelectedPage.AllowBack = false;
            this.btnPauseTreat.Enabled = true;
            this.btnStartTreat.Enabled = false;
            this.btnPreCircle.Enabled = false;
        }

        private void wizardControl1_Finished(object sender, EventArgs e)
        {
            //Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, _modelTreat.RPSpeed.Value, false, _modelTreat.RPDirection));
            if (_StartRecycle != null)
                _StartRecycle(sender, e);
        }

        public void btnPauseTreat_Click(object sender, EventArgs e)
        {
            if (_btnsLiAlsWizard != null)
                _btnsLiAlsWizard(this.btnPauseTreat, e);
            this.btnStartTreat.Enabled = true;
            this.btnPauseTreat.Enabled = false;
            this.wizardControl1.SelectedPage.AllowNext = true;
            this.wizardControl1.SelectedPage.AllowBack = true;
            this.btnPreCircle.Enabled = true;
        }

        private void btnReadRecycle_Click(object sender, EventArgs e)
        {
            //HPTCMessageBox.MSBox m = new HPTCMessageBox.MSBox("警 告","请确定管夹C1松开!", HPTCMessageBox.MSBox.MSBoxIcon.Warning, global::ALS.Properties.Resources.stepLi_3);
            UserCtrl.MsgBox m = new UserCtrl.MsgBox("警告: 请确定AD2放置在V6与双腔储液袋内袋出口之间!", UserCtrl.MsgBox.MSBoxIcon.Warning, global::ALS.Properties.Resources.stepLi_3, true);
            if (DialogResult.OK == m.ShowDialog())
            {
                if (_btnsLiAlsWizard != null)
                    _btnsLiAlsWizard(this.btnReadRecycle, e);
                this.wizardControl1.SelectedPage.AllowNext = false;
                this.wizardControl1.SelectedPage.AllowBack = false;
                this.btnStopReady.Enabled = true;
                this.btnReadRecycle.Enabled = false;
            }
        }

        public void btnStopReady_Click(object sender, EventArgs e)
        {
            if (_btnsLiAlsWizard != null)
                _btnsLiAlsWizard(this.btnStopReady, e);
            this.wizardControl1.SelectedPage.AllowNext = true;
            this.wizardControl1.SelectedPage.AllowBack = true;
            this.btnReadRecycle.Enabled = true;
            this.btnStopReady.Enabled = false;
        }

        private void btnPreCircle_Click(object sender, EventArgs e)
        {
            this.wizardControl1.SelectedPage.AllowNext = false;
            this.wizardControl1.SelectedPage.AllowBack = false;
            if (_btnsLiAlsWizard != null)
                _btnsLiAlsWizard(this.btnPreCircle, e);
        }

        private void wizardControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (_SelectStepChanged != null)
                _SelectStepChanged(sender, e);

            //if(wizardControl1.SelectedPage.TabIndex == 2)
            //{
            //    _SavePETotal(sender, e);
            //}
        }

        private void wizardControl1_Cancelling(object sender, CancelEventArgs e)
        {
            if (_SPSet != null)
                _SPSet(sender, e);
        }
    }
}
