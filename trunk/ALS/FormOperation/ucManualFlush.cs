using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
namespace ALS.FormOperation
{
    public partial class ucManualFlush : UserControl
    {
        private bool _finishFlush;
        /// <summary>
        /// 是否完成预冲
        /// </summary>
        public bool M_finishFlush
        {
            get { return _finishFlush; }
            set { _finishFlush = value; }
        }

        private float _totalFlush;
        public float _TotalFlush
        {
            get { return _totalFlush; }
            set { _totalFlush = value; }
        }


        private int _selType;
        /// <summary>
        /// 是否选择
        /// </summary>
        public int _SelType
        {
            get { return _selType; }
            set { _selType = value; }
        }

        private Cls.Model_State _modelPumpState;
        public Cls.Model_State _ModelPumpState
        {
            get { return _modelPumpState; }
            set { _modelPumpState = value; }
        }

        private string _section;
        public string _Section
        {
            get { return _section; }
            set { _section = value; }
        }


        /// <summary>
        /// 定义完成按钮委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void btnClickDelegate(object sender, EventArgs e);
        /// <summary>
        /// 定义完成按钮事件
        /// </summary>
        public event btnClickDelegate btnClickFinish; 

        public delegate void btnDirectionClick(object sender, EventArgs e);
        public event btnDirectionClick btnDirectionClicked;
 
        public delegate void txtChanged(object sender, EventArgs e);
        public event txtChanged txtChange;
         
        public ucManualFlush()
        {
            InitializeComponent();
        }

        private void ucfrmPreflush_SizeChanged(object sender, EventArgs e)
        {
            //this.grouppreflush.left = (this.width - this.grouppreflush.width) / 2;
            //this.grouppreflush.top = (this.height - this.grouppreflush.height) / 2;
            //获取当前分辨率
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 898.0f;
            float y = rec.Height / 578.0f;
            Cls.utils.AutoSize(this, x, y);
        }
 

        void fops_btnClickFinish(object sender, EventArgs e)
        {
            this._finishFlush = true;
        } 

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _finishFlush = true;
            if (btnClickFinish != null)
                btnClickFinish(sender, e); 
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

        private void btnStart_Click(object sender, EventArgs e)
        {
           
        }

        private void ucfrmPreflush_Load(object sender, EventArgs e)
        {
            _totalFlush = (float.Parse(Cls.utils.GetSectionKeyValue(_section,"PEFlushIn")) + float.Parse(Cls.utils.GetSectionKeyValue(_section,"PEFlushOut")) + 100);
            ReadSet(_section);
            SetButtonState(_modelPumpState);
        }

        public void ReadSet(string sec)
        {
            if (Convert.ToBoolean(Cls.utils.GetSectionKeyValue(_section, "BPValid")))
            {
                palBP.Enabled = true;
                this.txtBP.Text = Cls.utils.GetSectionKeyValue(_section, "BPSpeed");//_MFlush
                if (Cls.utils.GetSectionKeyValue(_section, "BPDirection") == "true")//_MFlush
                { this.btnBPDirection.Text = "正转"; this.btnBPDirection.ForeColor = Color.Green; }
                else{this.btnBPDirection.Text = "反转"; this.btnBPDirection.ForeColor = Color.Gold;} 
            }
            else
                palBP.Enabled = false;

            if (Convert.ToBoolean(Cls.utils.GetSectionKeyValue(_section, "CPValid")))
            {
                palCP.Enabled = true;
                this.txtCP.Text = Cls.utils.GetSectionKeyValue(_section, "CPSpeed");//_MFlush
                if (Cls.utils.GetSectionKeyValue(_section, "CPDirection") == "true")//_MFlush
                { this.btnCPDirection.Text = "正转"; this.btnCPDirection.ForeColor = Color.Green; }
                else { this.btnCPDirection.Text = "反转"; this.btnCPDirection.ForeColor = Color.Gold; }
            }
            else
                palCP.Enabled = false;

            if (Convert.ToBoolean(Cls.utils.GetSectionKeyValue(_section, "DPValid")))
            {
                palDP.Enabled = true;
                this.txtDP.Text = Cls.utils.GetSectionKeyValue(_section, "DPSpeed");//_MFlush
                if (Cls.utils.GetSectionKeyValue(_section, "DPDirection") == "true")//_MFlush
                { this.btnDPDirection.Text = "正转"; this.btnDPDirection.ForeColor = Color.Green; }
                else { this.btnDPDirection.Text = "反转"; this.btnDPDirection.ForeColor = Color.Gold; }
            }
            else
                palDP.Enabled = false;

            if (Convert.ToBoolean(Cls.utils.GetSectionKeyValue(_section, "RPValid")))
            {
                palRP.Enabled = true;
                this.txtRP.Text = Cls.utils.GetSectionKeyValue(_section, "RPSpeed");//MFlush
                if (Cls.utils.GetSectionKeyValue(_section, "RPDirection") == "true")//_MFlush
                { this.btnRPDirection.Text = "正转"; this.btnRPDirection.ForeColor = Color.Green; }
                else { this.btnRPDirection.Text = "反转"; this.btnRPDirection.ForeColor = Color.Gold; }
            }
            else
                palRP.Enabled = false;

            if (Convert.ToBoolean(Cls.utils.GetSectionKeyValue(_section, "FP2Valid")))
            {
                palFP2.Enabled = true;
                this.txtFP2.Text = Cls.utils.GetSectionKeyValue(_section, "FP2Speed");//_MFlush
                if (Cls.utils.GetSectionKeyValue(_section, "FP2Direction") == "true")//_MFlush
                { this.btnFP2Direction.Text = "正转"; this.btnFP2Direction.ForeColor = Color.Green; }
                else { this.btnFP2Direction.Text = "反转"; this.btnFP2Direction.ForeColor = Color.Gold; }
            }
            else
                palFP2.Enabled = false;

            if (Convert.ToBoolean(Cls.utils.GetSectionKeyValue(_section, "FPValid")))
            {
                palFP.Enabled = true;
                this.txtFP.Text = Cls.utils.GetSectionKeyValue(_section, "FPSpeed");//_MFlush
                if (Cls.utils.GetSectionKeyValue(_section, "FPDirection") == "true")//_MFlush
                { this.btnFPDirection.Text = "正转"; this.btnFPDirection.ForeColor = Color.Green; }
                else { this.btnFPDirection.Text = "反转"; this.btnFPDirection.ForeColor = Color.Gold; }
            }
            else
                palFP.Enabled = false;
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            _selType = 2;
            //this.palManualFlush.Dock = DockStyle.Fill;
            //this.palManualFlush.BringToFront();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            //if (btnContinueC != null)
            //    btnContinueC(sender, e);
                           
        }

        private void chkBP_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkCheckChanged != null)
            //    chkCheckChanged(sender, e);
        }

        private void groupPreflush_Enter(object sender, EventArgs e)
        {

        }

        private void txtBP_TextChanged(object sender, EventArgs e)
        {
            //if (txtChange != null)
            //    txtChange(sender, e);

            // TextBox tb = (TextBox)sender;
            // switch (tb.Tag.ToString())
            // {
            //     case "1":
            //         if (btnRun1.Text == "停止")
            //         {
            //             btnRunBP_Click(btnChangeBP, e);
            //         }
            //         break;
            //     case "2":
            //         if (btnRun2.Text == "停止")
            //         {
            //             btnRunBP_Click(btnChangeFP, e);
            //         }
            //         break;
            //     case "3":
            //         if (btnRun3.Text == "停止")
            //         {
            //             btnRunBP_Click(btnChangeDP, e);
            //         }
            //         break;
            //     case "4":
            //         if (btnRun4.Text == "停止")
            //         {
            //             btnRunBP_Click(btnChangeRP, e);
            //         }
            //         break;
            //     case "5":
            //         if (btnRun5.Text == "停止")
            //         {
            //             btnRunBP_Click(btnChangeFP2, e);
            //         }
            //         break;
            //     case "6":
            //         if (btnRun6.Text == "停止")
            //         {
            //             btnRunBP_Click(btnChangeCP, e);
            //         }
            //         break;
            // }
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
            if (btnDirectionClicked != null)
                btnDirectionClicked(sender, e);

            switch (b.Tag.ToString())
            {
                case "1":
                    if (btnRun1.Text == "停止")
                    {
                        btnRunBP_Click(btnChangeBP, e);
                    }
                    break;
                case "2":
                    if (btnRun2.Text == "停止")
                    {
                        btnRunBP_Click(btnChangeFP, e);
                    }
                    break;
                case "3":
                    if (btnRun3.Text == "停止")
                    {
                        btnRunBP_Click(btnChangeDP, e);
                    }
                    break;
                case "4":
                    if (btnRun4.Text == "停止")
                    {
                        btnRunBP_Click(btnChangeRP, e);
                    }
                    break;
                case "5":
                    if (btnRun5.Text == "停止")
                    {
                        btnRunBP_Click(btnChangeFP2, e);
                    }
                    break;
                case "6":
                    if (btnRun6.Text == "停止")
                    {
                        btnRunBP_Click(btnChangeCP, e);
                    }
                    break;
            }
        }

        public delegate void btnRunSingle(object sender, EventArgs e);
        public event btnRunSingle btnRunsingle;
        private void btnRunBP_Click(object sender, EventArgs e)
        {
            if (btnRunsingle != null)
                btnRunsingle(sender, e);
        }

        private void txtBP_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(tb.Text);
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                if (_numPad.Value > 350 || _numPad.Value < 0)
                    return;
                tb.Text = _numPad.Value.ToString("f1");                

                if (txtChange != null)
                    txtChange(sender, e);
                 
                switch (tb.Tag.ToString())
                {
                    case "1":
                        if (btnRun1.Text == "停止")
                        {
                            btnRunBP_Click(btnChangeBP, e);
                        }
                        break;
                    case "2":
                        if (btnRun2.Text == "停止")
                        {
                            btnRunBP_Click(btnChangeFP, e);
                        }
                        break;
                    case "3":
                        if (btnRun3.Text == "停止")
                        {
                            btnRunBP_Click(btnChangeDP, e);
                        }
                        break;
                    case "4":
                        if (btnRun4.Text == "停止")
                        {
                            btnRunBP_Click(btnChangeRP, e);
                        }
                        break;
                    case "5":
                        if (btnRun5.Text == "停止")
                        {
                            btnRunBP_Click(btnChangeFP2, e);
                        }
                        break;
                    case "6":
                        if (btnRun6.Text == "停止")
                        {
                            btnRunBP_Click(btnChangeCP, e);
                        }
                        break;
                }
            }
        }
        //返回选择
        public delegate void btnReturnSel(object sender, EventArgs e);
        public event btnReturnSel btnReturnSel_PE;
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (btnReturnSel_PE != null)
                btnReturnSel_PE(sender, e);
        } 

        /// <summary>
        /// 预冲timer处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void M_Timer_AutoFlush_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    //1.	安装好管路，系统自检结束，血泵不动，夹管伐1，3，4开，2闭，将肝素化生理盐水连接至静脉端，
        //    //      废液靠重力作用从V4处管路流出，预冲200ml。（Y形管路构建安装问题请问相国民）
        //    //      
        //    //      人工检测管路(提示框),夹管阀1，3，4开 2闭，
        //    //
        //    //2.	血泵（泵1）反转，转速40ml/min，夹管伐3、4关闭，夹管伐1，2开放，气泡检测传感器1运转，
        //    //      压力传感器1，2，3，4工作，开始逆向预冲；
        //    //
        //    //3.	拍打血浆分离柱，排净气体，逆向排净管路中气体；血泵转动流量累计达到500ml后（转动12min），
        //    //      分离泵（泵2）开始转动，顺向20ml/min，排净分离柱外侧腔气体，冲洗分离血浆管路。
        //    //4.	血泵转动流量累计达到1200ml后，夹管伐3仍关闭，4开放，顺向转动返浆泵，转速20ml/min，
        //    //      补液管路气体排净后自动开放夹管伐3，关闭夹管伐4；

        //    //5.	逆向预冲总计运转40min（血泵累计流量1500-1600ml）后，更换生理盐水至动脉端，
        //    //      分离泵（泵2）停止，返浆泵（泵4）停止，夹管伐2，3维持开放，夹管伐4维持关闭，
        //    //      血泵（泵1）转为顺向，40ml/min，气泡传感器开始检测，运转5分钟内无气泡报警，提示结束预冲。
        //    M_int_Count++;
        //    this.Invoke((EventHandler)delegate
        //    {
        //        //显示时间
        //        TimeSpan ts = new TimeSpan(0, 0, M_int_Count); 
        //        this.lblTime.Text = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
        //    });

        //    if (M_int_Count > 2401)
        //    {
        //        if (_existWarn)//如果存在报警则重新计数
        //            M_int_Count = 2402;
        //    }

        //    switch (M_int_Count)
        //    {
        //        case 60: //血泵运转12min 721
        //            this.pic2.BackColor = Color.Gold;
        //            string title1 = "3、预冲分浆端";
        //            string content1 = "    内容："
        //            + "分离泵(泵2)开始转动，顺向20ml/min，排净分离柱外侧腔气体，冲洗分离血浆管路。";
        //            this.Invoke((EventHandler)(delegate
        //            {
        //                Cls.utils.richBoxAppendText(this.rtbox, title1, Color.FromArgb(218, 18, 18), new Font("楷体", 22), content1, Color.FromArgb(15, 8, 100), new Font("微软雅黑", 12));
        //            })); 
        //            //FP 泵2转动
        //            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(2, 20, true, true)); 
        //            _flushpumpState.FPState.Speed = 20;
        //            _flushpumpState.FPState.Direction = true;
        //            _flushpumpState.FPState.Runing = true;

        //            break;
        //        case 120://血泵运转30min 1801
        //            this.pic3.BackColor = Color.Gold;
        //            string title2 = "4、预冲补液端";
        //            string content2 = "    内容：血泵转动流量累计达到1200ml后，夹管阀3仍关闭，4开放，顺向转动返浆泵(4)，转速20ml/min，补液管路气体排净后自动开放夹管伐3，关闭夹管伐4；";
        //            this.Invoke((EventHandler)(delegate
        //            {
        //                Cls.utils.richBoxAppendText(this.rtbox, title2, Color.FromArgb(218, 18, 18), new Font("楷体", 22), content2, Color.FromArgb(15, 8, 100), new Font("微软雅黑", 12));
        //            })); 
        //            //夹管阀4开放
        //            Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV4);
        //            //返浆泵RP顺转
        //            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(4, 20, true, true));
        //            _flushpumpState.RPState.Direction = true;
        //            _flushpumpState.RPState.Speed = 20;
        //            _flushpumpState.RPState.Runing = true;
        //            break;
        //        case 180://1861
        //            //一分钟后关闭夹管阀4，打开夹管阀3  
        //            Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.ClampV4);
        //            Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV3);
        //            break;
        //        case 240://总计运转40min 2401 
        //            this.pic4.BackColor = Color.Gold;
        //            string title3 = "5、全体清洗";
        //            string content3 = "    内容：逆向预冲总计运转40min（血泵累计流量1500-1600ml）后，更换生理盐水至动脉端，分离泵（泵2）停止，返浆泵（泵4）停止，夹管伐2，3维持开放，夹管伐4维持关闭，血泵（泵1）转为顺向，40ml/min，气泡传感器开始检测，运转5分钟内无气泡报警，提示结束预冲。";
        //            this.Invoke((EventHandler)(delegate
        //            {
        //                Cls.utils.richBoxAppendText(this.rtbox, title3, Color.FromArgb(218, 18, 18), new Font("楷体", 22), content3, Color.FromArgb(15, 8, 100), new Font("微软雅黑", 12));
        //            }));
                   
        //            //血泵1停止
        //            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(1, 0, false, true));
        //            _flushpumpState.BPState.Runing = false;
        //            //分离泵（泵2）停止
        //            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(3, 0, false, true));
        //            _flushpumpState.FPState.Runing = false;
        //            //返浆泵（泵4）停止
        //            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(6, 0, false, true));
        //            _flushpumpState.RPState.Runing = false;
        //            M_Timer_AutoFlush.Enabled = false;
        //            if (DialogResult.OK == MessageBox.Show("请更换生理盐水至动脉端,然后按 “确定”", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
        //            {
        //                //更换生理盐水后继续冲洗
        //                M_Timer_AutoFlush.Enabled = true;
        //                //夹管伐2，3维持开放，夹管伐4维持关闭，血泵（泵1）转为顺向，40ml/min，气泡传感器开始检测  
        //                Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(1, 40, true, true));
        //                _flushpumpState.BPState.Direction = true;
        //                _flushpumpState.BPState.Speed = 40;
        //                _flushpumpState.BPState.Runing = true;
        //                //气泡传感器工作，运转5分钟内无气泡报警，提示结束预冲。
        //                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdBubble.OpenBubble1);
        //                //如果有报警，count从该数值重新计时5分钟；此处难点：捕获气泡报警   
        //            }
        //            break;

        //        case 300://无气泡运转5分钟后提示预冲结束 2701
        //            this.pic4.BackColor = Color.Gold;
        //            string title4 = "5、预冲完成";
        //            this.Invoke((EventHandler)(delegate
        //            {
        //                Cls.utils.richBoxAppendText(this.rtbox, title4, Color.FromArgb(218, 18, 18), new Font("楷体", 22), "    内容：预冲结束，请点击按键  “预冲完成” 返回！", Color.FromArgb(15, 8, 100), new Font("微软雅黑", 12));
        //            }));
        //            M_Timer_AutoFlush.Stop();
        //            M_int_Count = 0;
        //            break;
        //    }
        //}
 
    }
}
