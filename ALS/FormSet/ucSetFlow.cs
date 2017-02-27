using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace ALS.FormSet
{
    public partial class ucSetFlow : UserControl
    {
        /*
        4.2.1  血液泵(BP)
            血液泵流量在 5mL/min～300mL/min范围内可调节，误差范围为±0.6mL/min或读数的±3%，二者取绝对值大者。
        4.2.2  分离泵(FP)
            分离泵流量在 5mL/min～300mL/min范围内可调节，误差范围为±0.6mL/min或读数的±3%，二者取绝对值大者。
        4.2.3  滤过泵(FP2)
            滤过泵流量在 2mL/min～200mL/min范围内可调节，误差范围为±0.6mL/min或读数的±3%，二者取绝对值大者。
        4.2.4  补液泵(RP)
            补液泵流量在 5mL/min～300mL/min范围内可调节，误差范围为±0.6mL/min或读数的±3%，二者取绝对值大者。
        4.2.5  透析液泵(DP)
            透析液泵流量在 5mL/min～300mL/min范围内可调节，误差范围为±0.6mL/min或读数的±3%，二者取绝对值大者。
        4.2.6  循环泵(CP)
            循环泵流量在 5mL/min～300mL/min范围内可调节，误差范围为±0.6mL/min或读数的±3%，二者取绝对值大者。
        4.2.7  抗凝剂泵
            抗凝剂泵注入流量监控要求：
            a） 在 0.1 mL/h～15.0mL/h 连续可调范围内，误差范围±0.6mL/h或读数的±3%，二者取绝对值大者；
            b） 当抗凝剂泵注射完毕或推注到预设时间，装置应发出声光报警；
            c） 当抗凝剂泵过负荷或速率不正确时，装置应发出声光报警。
        4.2.8  脱水误差
            脱水误差控制要求：
            a)	在标称范围内设备脱水误差不超过50mL/h； 
            b)	实际脱水量的累计误差不超过±200mL。
            c)	设备应具备防止实际脱水量偏离设置值的独立防护系统，防护系统的最大动作值为±100mL。防护系统应的动作应具有以下安全条件：
            ——激活声光报警；
            ——阻止脱水量继续偏离设置值。
        4.3  装置液体平衡误差
            4.3.1  装置液体平衡误差不超过±50mL/h；
            4.3.2  装置液体平衡累计误差不超过100mL/h。
        */
        //public delegate void btnChange_BP(object sender, EventArgs e);
        //public event btnChange_BP btnChange_bp;

        public delegate void btnRunPump(object sender, EventArgs e);
        public event btnRunPump btnRun_Pump;

        public delegate void btnSaveSet(object sender, EventArgs e);
        public event btnSaveSet btnReadset;

        //返回选择
        public delegate void btnReturnSel(object sender, EventArgs e);
        public event btnReturnSel btnReturnSelect;

        //夹管阀操作
        public delegate void chkVClick(object sender, EventArgs e);
        public event chkVClick checkVClick;


        /// <summary>
        /// 定义完成按钮委托     
        public delegate void btnClickDelegate(object sender, EventArgs e);
        /// <summary>
        /// 定义完成按钮事件
        /// </summary>
        public event btnClickDelegate btnClickFinish;

        private bool _finishFlush;
        /// <summary>
        /// 是否完成预冲
        /// </summary>
        public bool M_finishFlush
        {
            get { return _finishFlush; }
            set { _finishFlush = value; }
        }

        private Cls.Model_State _modelPumpState;
        public Cls.Model_State _ModelPumpState
        {
            get { return _modelPumpState; }
            set { _modelPumpState = value; }
        }

        private SerialPort _port_main;
        /// <summary>
        /// 夹管阀通讯端口
        /// </summary>
        public SerialPort _Port_main
        {
            get { return _port_main; }
            set { _port_main = value; }
        }

        private Model.treatmentmode _treatMode;
        public Model.treatmentmode _TreatMode
        {
            get { return _treatMode; }
            set { _treatMode = value; }
        }

        public ucSetFlow()
        {
            InitializeComponent();
        }
        private int sizechangedcount = 0;
        private void ucSetSyringe_SizeChanged(object sender, EventArgs e)
        {
            //this.groupSet.Left = (this.Width - this.groupSet.Width) / 2;
            //this.groupSet.Top = (this.Height - this.groupSet.Height) / 2;
            //获取当前分辨率
            //if (sizechangedcount == 0)
            //{
            //    Rectangle rec = this.ClientRectangle;
            //    //与基准分辨率的放大系数
            //    float x = rec.Width / 898.0f;
            //    float y = rec.Height / 550.0f;
            //    Cls.utils.AutoSize(this, x, y);
            //}
            //sizechangedcount = 1;
        }

        private void txtBP_Click(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(tb.Text);
            _numPad.btnNegPos.Visible = false;
            _numPad.btnDot.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                switch (tb.Tag.ToString())
                {
                    case "1"://BP 
                        if (_numPad.Value > 250 || _numPad.Value < 0)
                        {
                            MessageBox.Show("请将泵速设置在 250mL/min 以内!");
                            return;
                        }
                        if (_treatMode.FPSpeed > _numPad.Value * _treatMode.Concentration / 100.0)
                        {
                            MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                            return;
                        }
                        _treatMode.BPSpeed = _numPad.Value;
                        _treatMode.LeadBloodSpeed = (int)_numPad.Value;
                        break;
                    case "2"://FP 
                        if (_numPad.Value > 150 || _numPad.Value < 0)
                        {
                            MessageBox.Show("请将泵速设置在 150mL/min 以内!");
                            return;
                        }
                        if (_numPad.Value > _treatMode.BPSpeed * _treatMode.Concentration / 100.0)
                        {
                            MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                            return;
                        }

                        switch (_treatMode.name)
                        {
                            case "PE":
                            case "PERT":
                                _treatMode.FPSpeed = _treatMode.RPSpeed = _numPad.Value;
                                break;
                            case "CHDF":
                                //如果设置的FP速度小于其他两个泵速度之和
                                if (_numPad.Value < _treatMode.DPSpeed.Value + _treatMode.RPSpeed.Value)
                                {
                                    _treatMode.DPSpeed = 0;
                                    _treatMode.FPSpeed = _numPad.Value;
                                    _treatMode.RPSpeed = _treatMode.FPSpeed.Value;
                                }
                                else
                                {
                                    _treatMode.FPSpeed = _numPad.Value;
                                    _treatMode.RPSpeed = _treatMode.FPSpeed.Value - _treatMode.DPSpeed.Value;
                                }
                                break;
                            case "PP":
                                _treatMode.FPSpeed = _numPad.Value;
                                break;
                            case "PDF": 
                                //如果设置的FP速度小于其他三个泵速度之和
                                if (_numPad.Value < _treatMode.DPSpeed.Value + _treatMode.RPSpeed.Value+_treatMode.FP2Speed.Value)
                                {
                                    _treatMode.DPSpeed = 0;
                                    _treatMode.FPSpeed = _numPad.Value;
                                    _treatMode.RPSpeed = _treatMode.FP2Speed = _numPad.Value / 2;
                                }
                                else
                                {
                                    _treatMode.FPSpeed = _numPad.Value;
                                    _treatMode.RPSpeed = _treatMode.FPSpeed.Value - _treatMode.DPSpeed.Value-_treatMode.FP2Speed.Value;
                                }
                                break;
                            case "Li-ALS":
                               _treatMode.FPSpeed = _treatMode.DPSpeed = _numPad.Value;
                                break;
                        }
                        break;
                    case "3"://DP 
                        if (_numPad.Value > 250 || _numPad.Value < 0)
                        {
                            MessageBox.Show("请将泵速设置在 250mL/min 以内!");
                            return;
                        }
                        switch (_treatMode.name)
                        {
                            case "PE":
                            case "PERT":
                                if (_numPad.Value > _treatMode.FPSpeed.Value)
                                {
                                    MessageBox.Show("不符合规范的速度,请重新设置!");
                                    return;
                                }
                                _treatMode.DPSpeed = _numPad.Value;
                                break;
                            case "CHDF":
                                if (_numPad.Value > _treatMode.FPSpeed)
                                {
                                    MessageBox.Show("不符合规范的速度,请重新设置!");
                                    return;
                                }
                                _treatMode.DPSpeed = _numPad.Value;
                                _treatMode.RPSpeed = _treatMode.FPSpeed.Value - _treatMode.DPSpeed.Value;
                                break;
                            case "PDF":
                                //设置DP速度时,FP速度已确定，FP-DP=RP+FP2,平均分配RP和FP2的速度，设置上限不能超过FP的速度
                                if (_numPad.Value > _treatMode.FPSpeed.Value)
                                    _numPad.Value = _treatMode.FPSpeed.Value;
                                _treatMode.DPSpeed = _numPad.Value;
                                _treatMode.RPSpeed = _treatMode.FP2Speed =(int)(_treatMode.FPSpeed.Value - _treatMode.DPSpeed.Value) / 2;
                                break;
                            case "Li-ALS":
                                if (_numPad.Value > _treatMode.BPSpeed * _treatMode.Concentration / 100.0)
                                {
                                    MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                                    return;
                                }
                                _treatMode.FPSpeed = _treatMode.DPSpeed = _numPad.Value;
                                break;
                        }

                        break;
                    case "4"://RP  
                        if (_numPad.Value > 250 || _numPad.Value < 0)
                        {
                            MessageBox.Show("请将泵速设置在 250mL/min 以内!");
                            return;
                        }
                        switch (_treatMode.name)
                        {
                            case "PE":
                            case "PERT":
                                //判断过浓缩
                                if (_numPad.Value > _treatMode.BPSpeed * _treatMode.Concentration / 100.0)
                                {
                                    MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                                    return;
                                }
                                _treatMode.FPSpeed = _treatMode.RPSpeed = _numPad.Value;
                                break;
                            case "CHDF":
                                if (_numPad.Value > _treatMode.FPSpeed)
                                {
                                    MessageBox.Show("不符合规范的速度,请重新设置!"); return;
                                }
                                _treatMode.RPSpeed = _numPad.Value;
                                _treatMode.DPSpeed = _treatMode.FPSpeed.Value - _treatMode.RPSpeed.Value;
                                break;
                            case "PDF":
                                if (_numPad.Value > _treatMode.FPSpeed.Value)
                                    _numPad.Value = _treatMode.FPSpeed.Value;
                                _treatMode.RPSpeed = _numPad.Value;
                                break;
                            case "Li-ALS":
                                //判断过浓缩
                                if (_numPad.Value > _treatMode.BPSpeed * _treatMode.Concentration / 100.0)
                                {
                                    MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                                    return;
                                }
                                _treatMode.FP2Speed = _treatMode.RPSpeed = _numPad.Value; 
                                break;
                        }
                        break;
                    case "5"://FP2 
                        if (_numPad.Value > 150 || _numPad.Value < 0)
                        {
                            MessageBox.Show("请将泵速设置在 150mL/min 以内!");
                            return;
                        }
                        switch (_treatMode.name)
                        {
                            case "Li-ALS":
                                //判断过浓缩
                                if (_numPad.Value > _treatMode.BPSpeed * _treatMode.Concentration / 100.0)
                                {
                                    MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                                    return;
                                }
                                _treatMode.FP2Speed = _treatMode.RPSpeed = _numPad.Value;
                                break;
                            case "PDF":
                                if (_numPad.Value > _treatMode.FPSpeed.Value)
                                    _numPad.Value = _treatMode.FPSpeed.Value;
                                _TreatMode.FP2Speed = _numPad.Value;
                                break;
                        }
                        //自定设置分离泵速度
                        //FP速度不能超过血液泵速度的30% 
                        _treatMode.FP2Speed = _numPad.Value;
                        break;
                    case "6"://CP
                        if (_numPad.Value > 250 || _numPad.Value < 0)
                        {
                            MessageBox.Show("请将泵速设置在 250mL/min 以内!");
                            return;
                        }
                        _treatMode.CPSpeed = _numPad.Value;
                        break;
                    case "7"://脱水速度
                        if (_numPad.Value > 200 || _numPad.Value < 0)
                        {
                            MessageBox.Show("请确认脱水速度!");
                            return;
                        }
                        _treatMode.dehydrationSpeed = _numPad.Value;
                        break;
                }
                //保存设置
                if (new BLL.treatmentmode().Update(_treatMode))
                    ReadPumpSet(_treatMode);
                //主界面读取设置
                if (btnReadset != null)
                    btnReadset(sender, e);
            }
        }

        private void SetPumpSpeed(string modeName, byte pumpID, int val)
        {
            switch (pumpID)
            {
                case 1://BP
                    if (val > 250 || val < 0)
                    {
                        MessageBox.Show("请将泵速设置在 250mL/min 以内!");
                        return;
                    }
                    if (_treatMode.FPSpeed > val * _treatMode.Concentration / 100.0)
                    {
                        MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                        return;
                    }
                    _treatMode.BPSpeed = val;
                    _treatMode.LeadBloodSpeed = val;
                    break;
                case 2://FP
                    if (val > 150 || val < 0)
                        {
                            MessageBox.Show("请将泵速设置在 150mL/min 以内!");
                            return;
                        }
                    if (val > _treatMode.BPSpeed * _treatMode.Concentration / 100.0)
                        {
                            MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                            return;
                        }

                        switch (_treatMode.name)
                        {
                            case "PE":
                            case "PERT":
                                _treatMode.FPSpeed = _treatMode.RPSpeed = val;
                                break;
                            case "CHDF":
                                //如果设置的FP速度小于其他两个泵速度之和
                                if (val < _treatMode.RPSpeed.Value + _treatMode.DPSpeed.Value)
                                {
                                    _treatMode.DPSpeed = 0;
                                    _treatMode.FPSpeed = val;
                                    _treatMode.RPSpeed = _treatMode.FPSpeed.Value;
                                }
                                else
                                {
                                    _treatMode.FPSpeed = val;
                                    _treatMode.RPSpeed = _treatMode.FPSpeed.Value - _treatMode.DPSpeed.Value;
                                }
                                break;
                            case "PP":
                                _treatMode.FPSpeed = val;
                                break;
                            case "PDF":

                                break;
                            case "Li-ALS":
                                _treatMode.DPSpeed = val;
                                break;
                        }
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        }

        private void ucSetFlow_Load(object sender, EventArgs e)
        {

        }

        public void ReadPumpSet(Model.treatmentmode _tm)
        {
            //根据泵的有效性设置Enable
            if (_tm.BPValid)
            { this.palBP.Enabled = true; this.txtBP.Text = _tm.BPSpeed.Value.ToString("f0"); }
            else
            { this.palBP.Enabled = false; }

            if (_tm.CPValid)
            { this.txtCP.Text = _tm.CPSpeed.Value.ToString("f0"); this.palCP.Enabled = true; }
            else
            { this.palCP.Enabled = false; this.txtCP.Text = "0"; }

            if (_tm.DPValid)
            { this.txtDP.Text = _tm.DPSpeed.Value.ToString("f0"); this.palDP.Enabled = true; }
            else
            { this.palDP.Enabled = false; this.txtDP.Text = "0"; }

            if (_tm.FPValid)
            { this.txtFP.Text = _tm.FPSpeed.Value.ToString("f0"); this.palFP.Enabled = true; }
            else
            { this.palFP.Enabled = false; this.txtFP.Text = "0"; }

            if (_tm.RPValid)
            { this.txtRP.Text = _tm.RPSpeed.Value.ToString("f0"); this.palRP.Enabled = true; }
            else
            { this.palRP.Enabled = false; this.txtRP.Text = "0"; }

            if (_tm.FP2Valid)
            { this.txtFP2.Text = _tm.FP2Speed.Value.ToString("f0"); this.palFP2.Enabled = true; }
            else
            { this.palFP2.Enabled = false; this.txtFP2.Text = "0"; }

            if (_tm.dehydrationValid)
            { this.txtDehydrationSpeed.Text = _tm.dehydrationSpeed.Value.ToString("f0"); this.palDehydration.Enabled = true; }
            else
            { this.palDehydration.Enabled = false; this.txtDehydrationSpeed.Text = "0"; }
        }

        private void btnRun1_Click(object sender, EventArgs e)
        {
            //运行泵
            if (btnRun_Pump != null)
                btnRun_Pump(sender, e);
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (btnReturnSelect != null)
                btnReturnSelect(sender, e);
        }


        private void btnConfirmM_Click(object sender, EventArgs e)
        {
            _finishFlush = true;
            if (btnClickFinish != null)
                btnClickFinish(sender, e);
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

            if (_state.VState[2] == 1)
            {
                chkV3.Image = global::ALS.Properties.Resources.clipclose;
                chkV3.Checked = true;
                //chkV3.Text = "松开";
            }
            else
            {
                chkV3.Image = global::ALS.Properties.Resources.clipopen;
                chkV3.Checked = false;
                //chkV3.Text = "夹管";
            }

            if (_state.VState[3] == 1)
            {
                chkV4.Image = global::ALS.Properties.Resources.clipclose;
                chkV4.Checked = true;
                //chkV4.Text = "松开";
            }
            else
            {
                chkV4.Image = global::ALS.Properties.Resources.clipopen;
                chkV4.Checked = false;
                //chkV4.Text = "夹管";
            }

            if (_state.VState[4] == 1)
            {
                chkV5.Image = global::ALS.Properties.Resources.clipclose;
                chkV5.Checked = true;
                //chkV5.Text = "松开";
            }
            else
            {
                chkV5.Image = global::ALS.Properties.Resources.clipopen;
                chkV5.Checked = false;
                //chkV5.Text = "夹管";
            }

            if (_state.VState[5] == 1)
            {
                chkV6.Image = global::ALS.Properties.Resources.clipclose;
                chkV6.Checked = true;
                //chkV6.Text = "松开";
            }
            else
            {
                chkV6.Image = global::ALS.Properties.Resources.clipopen;
                chkV6.Checked = false;
                //chkV6.Text = "夹管";
            }
        }

        private void chkV1_Click(object sender, EventArgs e)
        {
            if (checkVClick != null)
                checkVClick(sender, e);
        }
    }
}
