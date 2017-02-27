using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        public delegate void btnChange_BP(object sender, EventArgs e);
        public event btnChange_BP btnChange_bp;

        //public delegate void btnChange_FP(object sender, EventArgs e);
        //public event btnChange_FP btnChange_fp;

        //public delegate void btnChange_RP(object sender, EventArgs e);
        //public event btnChange_RP btnChange_rp;

        public delegate void btnRunPump(object sender, EventArgs e);
        public event btnRunPump btnRun_Pump;

        public delegate void btnSaveSet(object sender, EventArgs e);
        public event btnSaveSet btnReadset;

        public delegate void chkCheckChanged(object sender, EventArgs e);
        public event chkCheckChanged chkCheckChange;

        //返回选择
        public delegate void btnReturnSel(object sender, EventArgs e);
        public event btnReturnSel btnReturnSelect;

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

        /// <summary>
        /// 配置节名字
        /// </summary>
        private string _section;
        public string _Section
        {
            get { return _section; }
            set { _section = value; }
        }

        public ucSetFlow()
        {
            InitializeComponent();
        }

        private void ucSetSyringe_SizeChanged(object sender, EventArgs e)
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

        private void txtBP_Click(object sender, EventArgs e)
        {
            TextBox tb =  sender as TextBox;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(tb.Text);
            _numPad.btnNegPos.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                if (_numPad.Value > 350 || _numPad.Value < 0)
                {
                    MessageBox.Show("请将泵速设置在 (0-350)mL/min 以内!");
                        return;  
                }
                   
                switch (tb.Tag.ToString())
                {
                    case "1"://BP
                        if (btnRun1.Text == "停止")
                        {
                            btnRun1_Click(btnChangeBP, e);
                        }
                        //自定设置分离泵速度
                        //FP速度不能超过血液泵速度的30% 
                        tb.Text = _numPad.Value.ToString("f1");
                        this.txtFP.Text = ((_numPad.Value) * 0.25).ToString("f1");
                        //如果是cvvhdf模式,计算和脱水相关速度
                        if (_section == "CHDFConfig")
                        {
                            double dehydrationSpeed = Convert.ToDouble(Cls.utils.GetSectionKeyValue(_section, "dehydrationSpeed"));
                            double fpspeed =(_numPad.Value) * 0.25;
                            //平均分配速度
                            string dpspeed = ((fpspeed - (dehydrationSpeed / 60.0)) / 2.0).ToString("f1");
                            this.txtDP.Text = this.txtRP.Text = dpspeed;
                        }
                                           
                        break;
                    case "2"://FP
                        if (btnRun2.Text == "停止")
                        {
                            btnRun1_Click(btnChangeFP, e);
                        }
                        //FP速度不能超过血液泵速度的30%
                        double bpspeed = Convert.ToDouble(Cls.utils.GetSectionKeyValue(_section, "BPSpeed"));
                        if(_numPad.Value > bpspeed * 0.5)
                        {
                            MessageBox.Show("请将分离泵速度设置为血泵速度的50%以下");
                            return;
                        } 
                        tb.Text = _numPad.Value.ToString("f1");                      

                        //如果存在脱水设置，则自动计算出透析液泵和返液泵的速度
                        if (_section == "CHDFConfig")
                        {
                            double dehydrationSpeed = Convert.ToDouble( Cls.utils.GetSectionKeyValue(_section, "dehydrationSpeed"));
                            double fpspeed = _numPad.Value;
                            //平均分配速度
                            string dpspeed = ((fpspeed - (dehydrationSpeed / 60.0)) / 2.0).ToString("f1");
                            this.txtDP.Text = this.txtRP.Text = dpspeed;                          
                        }
                        //保存设置
                        SaveConfig(_section);
                        if (btnReadset != null)
                            btnReadset(sender, e);
                        break;
                    case "3"://DP
                        if (btnRun3.Text == "停止")
                        {
                            btnRun1_Click(btnChangeDP, e);
                        }
                        //如果存在脱水设置，改变DP的速度，相应改变 RP的速度
                        if (_section == "CHDFConfig")
                        {
                            double dehydrationSpeed = Convert.ToDouble(Cls.utils.GetSectionKeyValue(_section, "dehydrationSpeed"));
                            double fpspeed = Convert.ToDouble(Cls.utils.GetSectionKeyValue(_section, "FPSpeed"));
                            double dpspeed = _numPad.Value;
                            //计算RP速度
                            double rpspeed = (fpspeed - (dehydrationSpeed / 60.0)) - dpspeed;
                            if(rpspeed <0)
                            {
                                MessageBox.Show("计算出的返液泵速度为负数,请重新设置!");
                                return;
                            }
                            else
                            {
                                this.txtRP.Text = rpspeed.ToString("f1");
                            }
                        }
                        this.txtDP.Text = _numPad.Value.ToString("f1");
                    
                        break;
                    case "4"://RP
                        if (btnRun4.Text == "停止")
                        {
                            btnRun1_Click(btnChangeRP, e);
                        }
                        //如果存在脱水设置，改变RP的速度，相应改变 DP的速度
                        if (_section == "CHDFConfig")
                        {
                            double dehydrationSpeed = Convert.ToDouble(Cls.utils.GetSectionKeyValue(_section, "dehydrationSpeed"));
                            double fpspeed = Convert.ToDouble(Cls.utils.GetSectionKeyValue(_section, "FPSpeed"));
                            double rpspeed = _numPad.Value;
                            //计算RP速度
                            double dpspeed = (fpspeed - (dehydrationSpeed / 60.0)) - rpspeed;
                            if (dpspeed < 0)
                            {
                                MessageBox.Show("计算出的透析液泵速度为负数,请重新设置!");
                                return;
                            }
                            else
                            {
                                this.txtDP.Text = dpspeed.ToString("f1");
                            }
                        }
                        this.txtRP.Text = _numPad.Value.ToString("f1");
                  
                        break;
                    case "5"://FP2
                        if (btnRun5.Text == "停止")
                        {
                            btnRun1_Click(btnChangeFP2, e);
                        }
                      
                        break;
                    case "6"://CP
                        if (btnRun6.Text == "停止")
                        {
                            btnRun1_Click(btnChangeCP, e);
                        }                    
                        break;
                    case "7"://脱水速度
                        //如果存在脱水设置，改变脱水速度，相应改变RP的速度,脱水速度范围是(0-350)ml/h
                        if (_section == "CHDFConfig")
                        {
                            double fpspeed = Convert.ToDouble(Cls.utils.GetSectionKeyValue(_section, "FPSpeed"));
                            //double rpspeed = Convert.ToDouble(Cls.utils.GetSectionKeyValue(_section, "RPSpeed"));
                            double dpspeed = Convert.ToDouble(Cls.utils.GetSectionKeyValue(_section, "DPSpeed"));
                            double dehydrationSpeed = _numPad.Value;
                            //计算RP的速度
                            double rpspeed = (fpspeed - (dehydrationSpeed / 60.0)) - dpspeed;
                            if (rpspeed < 0)
                            {
                                MessageBox.Show("计算出的返液泵速度为负数,请重新设置!");
                                return;
                            }
                            else
                            {
                                this.txtRP.Text = rpspeed.ToString("f1");
                            }
                        }
                        this.txtDehydrationSpeed.Text = _numPad.Value.ToString("f1");                      
                        break;
                }
                //保存设置
                SaveConfig(_section);
                if (btnReadset != null)
                    btnReadset(sender, e);  
            }
        }

        private void ucSetFlow_Load(object sender, EventArgs e)
        {
            //读取设置
            ReadConfig(_section);
            SetButtonState(_modelPumpState);
        }

        public void SetButtonState(Cls.Model_State _modPumpState)
        {
            if (_modPumpState != null)
            {
                if (_modPumpState.BPState.Runing)
                {
                    this.btnRun1.Text = "停止";
                    this.btnRun1.Image = Properties.Resources.spstop;
                    this.btnRun1.ForeColor = Color.Red;
                }
                else
                {
                    this.btnRun1.Text = "运转";
                    this.btnRun1.Image = Properties.Resources.spstart;
                    this.btnRun1.ForeColor = Color.FromArgb(15, 8, 100);
                }

                if (_modPumpState.FPState.Runing)
                {
                    this.btnRun2.Text = "停止";
                    this.btnRun2.Image = Properties.Resources.spstop;
                    this.btnRun2.ForeColor = Color.Red;
                }
                else
                {
                    this.btnRun2.Text = "运转";
                    this.btnRun2.Image = Properties.Resources.spstart;
                    this.btnRun2.ForeColor = Color.FromArgb(15, 8, 100);
                }

                if (_modPumpState.DPState.Runing)
                {
                    this.btnRun3.Text = "停止";
                    this.btnRun3.Image = Properties.Resources.spstop;
                    this.btnRun3.ForeColor = Color.Red;
                }
                else
                {
                    this.btnRun3.Text = "运转";
                    this.btnRun3.Image = Properties.Resources.spstart;
                    this.btnRun3.ForeColor = Color.FromArgb(15, 8, 100);
                }

                if (_modPumpState.RPState.Runing)
                {
                    this.btnRun4.Text = "停止";
                    this.btnRun4.Image = Properties.Resources.spstop;
                    this.btnRun4.ForeColor = Color.Red;
                }
                else
                {
                    this.btnRun4.Text = "运转";
                    this.btnRun4.Image = Properties.Resources.spstart;
                    this.btnRun4.ForeColor = Color.FromArgb(15, 8, 100);
                }

                if (_modPumpState.FP2State.Runing)
                {
                    this.btnRun5.Text = "停止";
                    this.btnRun5.Image = Properties.Resources.spstop;
                    this.btnRun5.ForeColor = Color.Red;
                }
                else
                {
                    this.btnRun5.Text = "运转";
                    this.btnRun5.Image = Properties.Resources.spstart;
                    this.btnRun5.ForeColor = Color.FromArgb(15, 8, 100);
                }

                if (_modPumpState.CPState.Runing)
                {
                    this.btnRun6.Text = "停止";
                    this.btnRun6.Image = Properties.Resources.spstop;
                    this.btnRun6.ForeColor = Color.Red;
                }
                else
                {
                    this.btnRun6.Text = "运转";
                    this.btnRun6.Image = Properties.Resources.spstart;
                    this.btnRun6.ForeColor = Color.FromArgb(15, 8, 100);
                }
            }
        }

        public void SaveConfig(string _sectionName)
        {
            //全部保存          
            Cls.utils.SetSectionKeyValue(_sectionName, "BPSpeed", txtBP.Text);
            Cls.utils.SetSectionKeyValue(_sectionName, "FPSpeed", txtFP.Text);
            Cls.utils.SetSectionKeyValue(_sectionName, "DPSpeed", txtDP.Text);
            Cls.utils.SetSectionKeyValue(_sectionName, "RPSpeed", txtRP.Text);
            Cls.utils.SetSectionKeyValue(_sectionName, "FP2Speed", txtFP2.Text);
            Cls.utils.SetSectionKeyValue(_sectionName, "CPSpeed", txtCP.Text);
            Cls.utils.SetSectionKeyValue(_sectionName, "dehydrationSpeed", txtDehydrationSpeed.Text);   
                      
        }

        public void ReadConfig(string _sectionName)
        {
            if (Cls.utils.GetSectionKeyValue(_sectionName, "BPDirection") == "true")
            { this.btnBPDirection.Text = "正转"; this.btnBPDirection.ForeColor = Color.Green; }
            else { this.btnBPDirection.Text = "反转"; this.btnBPDirection.ForeColor = Color.Orange; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "CPDirection") == "true")
            { this.btnCPDirection.Text = "正转"; this.btnCPDirection.ForeColor = Color.Green; }
            else { this.btnCPDirection.Text = "反转"; this.btnCPDirection.ForeColor = Color.Orange; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "DPDirection") == "true")
            { this.btnDPDirection.Text = "正转"; this.btnDPDirection.ForeColor = Color.Green; }
            else { this.btnDPDirection.Text = "反转"; this.btnDPDirection.ForeColor = Color.Orange; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "FPDirection") == "true")
            { this.btnFPDirection.Text = "正转"; this.btnFPDirection.ForeColor = Color.Green; }
            else { this.btnFPDirection.Text = "反转"; this.btnFPDirection.ForeColor = Color.Orange; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "FP2Direction") == "true")
            { this.btnFP2Direction.Text = "正转"; this.btnFP2Direction.ForeColor = Color.Green; }
            else { this.btnFP2Direction.Text = "反转"; this.btnFP2Direction.ForeColor = Color.Orange; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "RPDirection") == "true")
            { this.btnRPDirection.Text = "正转"; this.btnRPDirection.ForeColor = Color.Green; }
            else { this.btnRPDirection.Text = "反转"; this.btnRPDirection.ForeColor = Color.Orange; }
            //根据泵的有效性设置Enable
            if (Cls.utils.GetSectionKeyValue(_sectionName, "BPValid") == "true")
            { this.palBP.Enabled = true; this.txtBP.Text = Cls.utils.GetSectionKeyValue(_sectionName, "BPSpeed"); }
            else
            { this.palBP.Enabled = false; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "CPValid") == "true")
            { this.txtCP.Text = Cls.utils.GetSectionKeyValue(_sectionName, "CPSpeed"); this.palCP.Enabled = true; }
            else
            { this.palCP.Enabled = false; this.txtCP.Text = "0.0"; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "DPValid") == "true")
            { this.txtDP.Text = Cls.utils.GetSectionKeyValue(_sectionName, "DPSpeed"); this.palDP.Enabled = true; }
            else
            { this.palDP.Enabled = false; this.txtDP.Text = "0.0"; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "FPValid") == "true")
            { this.txtFP.Text = Cls.utils.GetSectionKeyValue(_sectionName, "FPSpeed"); this.palFP.Enabled = true; }
            else
            { this.palFP.Enabled = false; this.txtFP.Text = "0.0"; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "RPValid") == "true")
            { this.txtRP.Text = Cls.utils.GetSectionKeyValue(_sectionName, "RPSpeed"); this.palRP.Enabled = true; }
            else
            { this.palRP.Enabled = false; this.txtRP.Text = "0.0"; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "FP2Valid") == "true")
            { this.txtFP2.Text = Cls.utils.GetSectionKeyValue(_sectionName, "FP2Speed"); this.palFP2.Enabled = true; }
            else
            { this.palFP2.Enabled = false; this.txtFP2.Text = "0.0"; }

            if (Cls.utils.GetSectionKeyValue(_sectionName, "dehydrationValid") == "true")
            { this.txtDehydrationSpeed.Text = Cls.utils.GetSectionKeyValue(_sectionName, "dehydrationSpeed"); this.palDehydration.Enabled = true; }
            else
            { this.palDehydration.Enabled = false; this.txtDehydrationSpeed.Text = "0.0"; } 
        }

        private void btnBPDirection_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "正转")
            {
                b.Text = "反转";
                b.ForeColor = Color.Orange;
            }
            else
            {
                b.Text = "正转";
                b.ForeColor = Color.Green;
            }
            //改变设置
            if (btnChange_bp != null)
                btnChange_bp(sender, e);

            switch (b.Tag.ToString())
            {
                case "1":
                    if (btnRun1.Text == "停止")
                    {
                        btnRun1_Click(btnChangeBP, e);
                    }
                    break;
                case "2":
                    if (btnRun2.Text == "停止")
                    {
                        btnRun1_Click(btnChangeFP, e);
                    }
                    break;
                case "3":
                    if (btnRun3.Text == "停止")
                    {
                        btnRun1_Click(btnChangeDP, e);
                    }
                    break;
                case "4":
                    if (btnRun4.Text == "停止")
                    {
                        btnRun1_Click(btnChangeRP, e);
                    }
                    break;
                case "5":
                    if (btnRun5.Text == "停止")
                    {
                        btnRun1_Click(btnChangeFP2, e);
                    }
                    break;
                case "6":
                    if (btnRun6.Text == "停止")
                    {
                        btnRun1_Click(btnChangeCP, e);
                    }
                    break;
            }
        }

        private void btnChangeBP_Click(object sender, EventArgs e)
        {
            if (btnChange_bp != null)
                btnChange_bp(sender, e);
        }

        private void btnRun1_Click(object sender, EventArgs e)
        {
            if (btnRun_Pump != null)
                btnRun_Pump(sender, e);
        }

        private void txtBP_TextChanged(object sender, EventArgs e)
        {
            ////保存设置
            //if (btnSaveset != null)
            //    btnSaveset(sender, e);
            //////运转设置
            ////btnRun1_Click(sender, e); 
            //TextBox tb = (TextBox)sender;
            //switch (tb.Tag.ToString())
            //{
            //    case "1":
            //        if (btnRun1.Text == "停止")
            //        {
            //            btnRun1_Click(btnChangeBP, e);
            //        }
            //        break;
            //    case "2":
            //        if (btnRun2.Text == "停止")
            //        {
            //            btnRun1_Click(btnChangeFP, e);
            //        }
            //        break;
            //    case "3":
            //        if (btnRun3.Text == "停止")
            //        {
            //            btnRun1_Click(btnChangeDP, e);
            //        }
            //        break;
            //    case "4":
            //        if (btnRun4.Text == "停止")
            //        {
            //            btnRun1_Click(btnChangeRP, e);
            //        }
            //        break;
            //    case "5":
            //        if (btnRun5.Text == "停止")
            //        {
            //            btnRun1_Click(btnChangeFP2, e);
            //        }
            //        break;
            //    case "6":
            //        if (btnRun6.Text == "停止")
            //        {
            //            btnRun1_Click(btnChangeCP, e);
            //        }
            //        break;
            //}
        }

        private void chkBP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckChange != null)
                chkCheckChange(sender, e);
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
    }
}
