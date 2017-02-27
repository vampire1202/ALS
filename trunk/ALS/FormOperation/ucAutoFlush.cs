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
using System.Threading.Tasks;

namespace ALS.FormOperation
{
    public partial class ucAutoFlush : UserControl
    {
        /// <summary>
        /// 返回重新选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ReturnSel(object sender, EventArgs e);
        public event ReturnSel btnReturnSelEvent;
        //结束预冲
        public delegate void EndFlush(object sender, EventArgs e);
        public event EndFlush btnEndFlush;

        public delegate void StartFlush(object sender, EventArgs e);
        public event StartFlush btnStartFlush;

        private Task m_taskCustomAction;
        private Task m_taskActions; 

        public bool m_isFlush;
        public bool M_pauseFlush;
        public bool m_isAddFlush = false;
        //如果暂停线程，则
        DateTime _timePause;
        TimeSpan _spanPause;
        TimeSpan _spanPauseSum;
        int M_int_FlushCount;
        int m_tCountAddFlush;
        //默认值
        public Cls.Model_State m_pumpState=new Cls.Model_State();

        public ucAutoFlush()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 方法名称 如:PE_Flush
        /// </summary>
        private string _methodName;
        public string m_methodName
        {
            get { return _methodName; }
            set { _methodName = value; }
        }

        private bool _isExistActions;
        public bool m_isExistActions
        {
            get { return _isExistActions; }
            set { _isExistActions = value; }
        }

        /// <summary>
        /// 主控制端口
        /// </summary>
        private SerialPort _port_Main;
        public SerialPort _Port_Main
        {
            get { return _port_Main; }
            set { _port_Main = value; }
        }

        /// <summary>
        /// 蠕动泵端口
        /// </summary>
        private SerialPort _port_Pump;

        public SerialPort _Port_Pump
        {
            get { return _port_Pump; }
            set { _port_Pump = value; }
        }

        //自动化操作步骤列表，包括具体时间点里的动作列表
        Queue<Cls.Model_CustomCMD> m_queueCustSendCmd = new Queue<Cls.Model_CustomCMD>();
        List<ALS.Model.customactions> m_lstCust = new List<Model.customactions>();
        private void af_custom_Load(object sender, EventArgs e)
        {
            //GetCustCmd(_methodName);           
        }

        private void RunFlush(object o)
        {
            Queue<Cls.Model_CustomCMD> queueCustcmd = o as Queue<Cls.Model_CustomCMD>;
            //int nTime = lstccmd[lstccmd.Count-1]._TimesCount + lstccmd[lstccmd.Count - 1]._LastTime; 
            M_int_FlushCount = 0;
            int fullTimeCount = int.MaxValue;
            //当前步骤
            Cls.Model_CustomCMD currentStep = new Cls.Model_CustomCMD();

            while (m_isFlush)
            {
                Thread.Sleep(1000);
                if (!M_pauseFlush)
                {
                    BeginInvoke(new Action(() =>
                   {
                       //显示已用时间
                       this.lblTime.Text = Cls.utils.SecondsToTime(M_int_FlushCount);
                       this.lblTime.Invalidate();
                   }));
                    //获取步骤
                    if (queueCustcmd.Count > 0)
                        currentStep = queueCustcmd.Peek();
                    //判断当前时间是否为步骤的执行时间点                   
                    if (M_int_FlushCount == currentStep._TimesCount)
                    {
                        //如果只剩一项时，则获取最后这项的时间点+持续时间，计算结束时间点
                        if (queueCustcmd.Count == 1)
                            fullTimeCount = currentStep._LastTime + currentStep._TimesCount;
                        string itemname = currentStep._ActionName;
                        int index = currentStep._Index;
                        BeginInvoke(new Action(() =>
                        {
                            //步骤的背景色 
                            this.dgvStep.Rows[index].Selected = true;
                            //this.dgvStep.Rows[index].Cells["selAdd"].Value = 1;
                        }));
                        List<Cls.Model_SendCMD> lstscmd = new List<Cls.Model_SendCMD>();
                        lstscmd.AddRange(currentStep._LstSendCMDs);

                        //更新泵及夹管阀状态
                        UpdatePumpState(lstscmd);

                        //创建发送命令子任务
                        m_taskActions = new Task(RunActions, lstscmd, TaskCreationOptions.LongRunning);
                        m_taskActions.Start();
                        //执行任务后,移除队列的顶部
                        queueCustcmd.Dequeue();
                    }
                    M_int_FlushCount++;
                    //判断预冲结束条件
                    if (M_int_FlushCount == fullTimeCount)
                    {
                        BeginInvoke(new Action(() =>
                        {
                            //结束预冲,停止泵
                            m_isFlush = false;
                            //M_int_FlushCount = 0;
                            btnFinish.Enabled = true;
                            btnStart.Enabled = true;
                            btnContinue.Enabled = false;
                            btnContinue.Text = "暂停";
                            //泵停止
                            Cls.utils.SendOrder(_port_Pump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                            Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdAlarm.OpenVoice2);
                            if(DialogResult.OK == MessageBox.Show("预冲完成!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information))
                            {
                                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdAlarm.AllVoiceClose);
                                FinishFlush();
                            }                            
                        }));
                    }
                }
                else
                {
                    _spanPause = DateTime.Now - _timePause;
                }
            }
        }

        private void RunActions(object o)
        {
            List<Cls.Model_SendCMD> lstscmd = o as List<Cls.Model_SendCMD>;
            foreach (var v in lstscmd)
            {
                Cls.utils.SendOrder(v.SP, v.CMD);
            }
        }
        /// <summary>
        /// 获取自定义操作的步骤
        /// </summary>
        /// <param name="methodname"></param>
        /// <returns></returns>
        private DataTable dsCustomActions(string methodname)
        {
            DataTable dt = new DataTable();
            ALS.BLL.customactions bllcustom = new ALS.BLL.customactions();
            dt = bllcustom.GetList(" methodname='" + methodname + "'", true).Tables[0];
            return dt;
        }

        private void ShowCustomActions(string method)
        {
            this.dgvStep.DataSource = dsCustomActions(method);

            DataGridViewCheckBoxColumn dgchk = new DataGridViewCheckBoxColumn();
            dgchk.HeaderText = "选择追加";
            dgchk.Name = "selAdd";
            dgchk.Width = 84;
            if (!this.dgvStep.Columns.Contains("selAdd"))
                this.dgvStep.Columns.Insert(1, dgchk);
            DataGridViewTextBoxColumn dgtxt = new DataGridViewTextBoxColumn();
            dgtxt.HeaderText = "序号";
            dgtxt.Width = 50;
            dgtxt.Name = "number";
            if (!this.dgvStep.Columns.Contains("number"))
                this.dgvStep.Columns.Insert(2, dgtxt);

            for (int j = 0; j < this.dgvStep.Rows.Count; j++)
            {
                this.dgvStep.Rows[j].Cells["number"].Value = (j+1).ToString();
            }

            for (int i = 0; i < this.dgvStep.Columns.Count; i++)
            {
                this.dgvStep.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dgvStep.Columns["selAdd"].Visible = true;
            this.dgvStep.Columns["ID"].Visible = false;
            this.dgvStep.Columns["步骤"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvStep.Refresh();
        }

        public bool GetCustCmd(string method)
        {
            ShowCustomActions(method);
            ALS.BLL.customactions bllCust = new ALS.BLL.customactions();
            m_lstCust = bllCust.GetModelList("methodName='" + method + "'");

            if (m_lstCust.Count > 0)
            {
                m_queueCustSendCmd = new Queue<Cls.Model_CustomCMD>();
                ALS.BLL.actions bllact = new ALS.BLL.actions();
                for (int i = 0; i < m_lstCust.Count; i++)
                {
                    //重新计算时间点
                    if (i > 0)
                        m_lstCust[i].timeCount = m_lstCust[i - 1].timeCount + m_lstCust[i - 1].timeSpan;
                    //读取步骤下相应的动作列表
                    int customID = (int)m_lstCust[i].ID;
                    List<ALS.Model.actions> lstModAct = bllact.GetModelList("customID='" + customID + "'");
                    List<Cls.Model_SendCMD> lstActions = new List<Cls.Model_SendCMD>();
                    if (lstModAct.Count > 0)
                    {
                        lstActions = GetlstActions(lstModAct);
                    }
                    Cls.Model_CustomCMD modCustCmd = new Cls.Model_CustomCMD();
                    modCustCmd._TimesCount = (int)m_lstCust[i].timeCount;
                    modCustCmd._LstSendCMDs = lstActions;
                    modCustCmd._LastTime = (int)m_lstCust[i].timeSpan;
                    modCustCmd._ActionName = m_lstCust[i].actionName;
                    modCustCmd._Index = m_queueCustSendCmd.Count;
                    //将该动作列表加入步骤里  
                    m_queueCustSendCmd.Enqueue(modCustCmd);
                }
                //最后一项提取总时间
                int timefull = (int)(m_lstCust[m_lstCust.Count - 1].timeCount + m_lstCust[m_lstCust.Count - 1].timeSpan);// (int)modCust.timeCount + (int)modCust.timeSpan;
                this.lblFullTime.Text = Cls.utils.SecondsToTime(timefull);
                return true;
            }
            else
            {
                this.lblFullTime.Text = "00:00:00";
                return false;
            }
        }



        private void af_custom_SizeChanged(object sender, EventArgs e)
        {
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 898.0f;
            float y = rec.Height / 578.0f;
            Cls.utils.AutoSize(this, x, y);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (btnReturnSelEvent != null)
                btnReturnSelEvent(sender, e);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!_isExistActions)
            {
                MessageBox.Show("未定义自动化操作!");
                return;
            }

            //初始化泵状态
            m_pumpState = new Cls.Model_State();

            if (DialogResult.OK == MessageBox.Show("请检查管路是否安装正确! 然后点击 “确定” 继续冲洗!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                //创建自动预冲任务
                m_taskCustomAction = new Task(RunFlush, m_queueCustSendCmd, TaskCreationOptions.LongRunning);

                btnStart.Enabled = false;
                btnContinue.Enabled = true;
                btnFinish.Enabled = false;
                btnReturn.Enabled = false;
                btnAddFlush.Enabled = false;
                this.lblTime.Text = "00:00:00";
                int timefull = (int)(m_lstCust[m_lstCust.Count - 1].timeCount + m_lstCust[m_lstCust.Count - 1].timeSpan);// (int)modCust.timeCount + (int)modCust.timeSpan;
                this.lblFullTime.Text = Cls.utils.SecondsToTime(timefull);

                if (m_taskCustomAction.Status == TaskStatus.Running)
                {
                    MessageBox.Show("正在执行自动预冲,请稍候...", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    m_isFlush = true;
                    this.dgvStep.Enabled = false;
                    for (int i = 0; i < dgvStep.Rows.Count; i++)
                    {
                        DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvStep.Rows[i].Cells["selAdd"];
                        checkBox.Value = 0;
                        dgvStep.Rows[i].Selected = false;
                    }
                    m_taskCustomAction.Start();
                    if (btnStartFlush != null)
                        btnStartFlush(sender, e);
                }
            }
        }

        public void btnContinue_Click(object sender, EventArgs e)
        {
            M_pauseFlush = !M_pauseFlush;
            if (M_pauseFlush)
            {
                _timePause = DateTime.Now;
                Cls.utils.SendOrder(_port_Pump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                
                btnContinue.Text = "继续冲洗";
                btnFinish.Enabled = true;
            }
            else
            {
                _spanPauseSum += _spanPause;
                btnContinue.Text = "暂停";
                btnFinish.Enabled = false;
                ResumeFlush();
                //M_bwStartPump.RunWorkerAsync(this);
            }
        }
        /// <summary>
        /// 重启冲洗
        /// </summary>
        public void ResumeFlush()
        {
            //打开加热
            Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdTemperature.StartHT(38));
            //夹管阀状态
            if (m_pumpState.VState[0])
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.ClampV1);
            else
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV1);

            if (m_pumpState.VState[1])
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.ClampV2);
            else
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV2);

            if (m_pumpState.VState[2])
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.ClampV3);
            else
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV3);

            if (m_pumpState.VState[3])
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.ClampV4);
            else
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV4);

            if (m_pumpState.VState[4])
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.ClampV5);
            else
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV5);

            if (m_pumpState.VState[5])
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.ClampV6);
            else
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV6);

            if (m_pumpState.BPState.Runing)
                Cls.utils.SendOrder(_port_Pump, Cls.Comm_PeristalticPump.Command(0x01, m_pumpState.BPState.Speed, m_pumpState.BPState.Runing, m_pumpState.BPState.Direction));
            if (m_pumpState.FPState.Runing)
                Cls.utils.SendOrder(_port_Pump, Cls.Comm_PeristalticPump.Command(0x02, m_pumpState.FPState.Speed, m_pumpState.FPState.Runing, m_pumpState.FPState.Direction));
            if (m_pumpState.RPState.Runing)
                Cls.utils.SendOrder(_port_Pump, Cls.Comm_PeristalticPump.Command(0x04, m_pumpState.RPState.Speed, m_pumpState.RPState.Runing, m_pumpState.RPState.Direction));
            if (m_pumpState.DPState.Runing)
                Cls.utils.SendOrder(_port_Pump, Cls.Comm_PeristalticPump.Command(0x03, m_pumpState.DPState.Speed, m_pumpState.DPState.Runing, m_pumpState.DPState.Direction));
            if (m_pumpState.FP2State.Runing)
                Cls.utils.SendOrder(_port_Pump, Cls.Comm_PeristalticPump.Command(0x05, m_pumpState.FP2State.Speed, m_pumpState.FP2State.Runing, m_pumpState.FP2State.Direction));
            if (m_pumpState.CPState.Runing)
                Cls.utils.SendOrder(_port_Pump, Cls.Comm_PeristalticPump.Command(0x06, m_pumpState.CPState.Speed, m_pumpState.CPState.Runing, m_pumpState.CPState.Direction));
        }

        /// <summary>
        /// 更新泵状态
        /// </summary>
        void UpdatePumpState(List<Cls.Model_SendCMD> lstact)
        {
            foreach (var v in lstact)
            {
                #region 更新泵状态
                if (v.SP.PortName.ToLower() == "com3")
                {
                    byte[] b = v.CMD;
                    //从命令中提取泵ID,泵速和方向
                    int pumpID = b[1];
                    bool run = false;
                    bool direction = false;
                    //E9 01 06 57 4A 04 7E 01 00 61 
                    int speedhigh = b[5];
                    int speedlow = b[6];
                    //如果速度的低8位即[6]为0xE8,则要判断[7],若[7]为0x00则低8位为0xE8若[7]为0x01则低8位为0xE9;
                    if (b[6] == 0xE8)
                    {
                        switch (b[7])
                        {
                            case 0x00:
                                speedlow = 0xE8;
                                break;
                            case 0x01:
                                speedlow = 0xE9;
                                break;
                        }
                        run = Convert.ToBoolean(b[8]);
                        direction = Convert.ToBoolean(b[9]);
                    }
                    else
                    {
                        run = Convert.ToBoolean(b[7]);
                        direction = Convert.ToBoolean(b[8]);
                    }
                    //int rspeed = (int)(0.2314 * _speedml - 0.0289) * 10; 
                    int rspeed = (speedhigh << 8) + speedlow;
                    double mlspeed = Math.Round(((rspeed / 10.0) + 0.0289) / 0.2314, 0);

                    switch (pumpID)
                    {
                        case 0x01:
                            m_pumpState.BPState.Speed = mlspeed;
                            m_pumpState.BPState.Runing = run;
                            m_pumpState.BPState.Direction = direction;
                            m_pumpState.BPState.PumpID = 1;
                            break;
                        case 0x02:
                            m_pumpState.FPState.Speed = mlspeed;
                            m_pumpState.FPState.Runing = run;
                            m_pumpState.FPState.Direction = direction;
                            m_pumpState.FPState.PumpID = 2;
                            break;
                        case 0x03:
                            m_pumpState.DPState.Speed = mlspeed;
                            m_pumpState.DPState.Runing = run;
                            m_pumpState.DPState.Direction = direction;
                            m_pumpState.DPState.PumpID = 3;
                            break;
                        case 0x04:
                            m_pumpState.RPState.Speed = mlspeed;
                            m_pumpState.RPState.Runing = run;
                            m_pumpState.RPState.Direction = direction;
                            m_pumpState.RPState.PumpID = 4;
                            break;
                        case 0x05:
                            m_pumpState.FP2State.Speed = mlspeed;
                            m_pumpState.FP2State.Runing = run;
                            m_pumpState.FP2State.Direction = direction;
                            m_pumpState.FP2State.PumpID = 5;

                            break;
                        case 0x06:
                            m_pumpState.CPState.Speed = mlspeed;
                            m_pumpState.CPState.Runing = run;
                            m_pumpState.CPState.Direction = direction;
                            m_pumpState.CPState.PumpID = 6;
                            break;
                    }
                }
                #endregion

                #region 更新夹管阀状态
                if (v.SP.PortName.ToLower() == "com1")
                {
                    byte[] b = v.CMD;
                    switch (b[1])
                    {
                        //阀1通电松管	FE B1 00 4F ED	FF B1 01 XX XX(校验) ED
                        case 0xB1:
                            m_pumpState.VState[0] = false;  //松管
                            break;
                        //阀1断电夹管	FE B2 00 4C ED	FF B2 01 XX XX(校验) ED
                        case 0xB2:
                            m_pumpState.VState[0] = true;
                            break;
                        //阀2通电松管	FE B3 00 4D ED	FF B3 01 XX XX(校验) ED
                        case 0xB3:
                            m_pumpState.VState[1] = false;
                            break;
                        //阀2断电夹管	FE B4 00 4A ED	FF B4 01 XX XX(校验) ED
                        case 0xB4:
                            m_pumpState.VState[1] = true;
                            break;
                        //阀3通电松管	FE B5 00 4B ED	FF B5 01 XX XX(校验) ED
                        case 0xB5:
                            m_pumpState.VState[2] = false;
                            break;
                        //阀3断电夹管	FE B6 00 48 ED	FF B6 01 XX XX(校验) ED
                        case 0xB6:
                            m_pumpState.VState[2] = true;
                            break;
                        //阀4通电松管	FE B7 00 49 ED	FF B7 01 XX XX(校验) ED
                        case 0xB7:
                            m_pumpState.VState[3] = false;
                            break;

                        //阀4断电夹管	FE B8 00 46 ED	FF B8 01 XX XX(校验) ED 
                        case 0xB8:
                            m_pumpState.VState[3] = true;
                            break;
                        //阀5通电松管	FE B9 00 47 ED	FF B9 01 XX XX(校验) ED
                        case 0xB9:
                            m_pumpState.VState[4] = false;
                            break;
                        //阀5断电夹管	FE BA 00 44 ED	FF BA 01 XX XX(校验) ED
                        case 0xBA:
                            m_pumpState.VState[4] = true;
                            break;
                        //阀6通电松管	FE BB 00 45 ED	FF BB 01 XX XX(校验) ED
                        case 0xBB:
                            m_pumpState.VState[5] = false;
                            break;
                        //阀6断电夹管	FE BC 00 42 ED	FF BC 01 XX XX(校验) ED
                        case 0xBC:
                            m_pumpState.VState[5] = true;
                            break;
                    }
                }
                #endregion
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            FinishFlush();
            //读取最后步骤的夹管阀状态
            ReadLastActionAVState();  
            if (btnEndFlush != null)
                btnEndFlush(sender, e);
        }

        private void FinishFlush()
        {
            m_isFlush = false;
            M_pauseFlush = false;
            M_int_FlushCount = 0;
            btnStart.Enabled = false;
            btnContinue.Enabled = false;
            _spanPauseSum = new TimeSpan(0);
            this.btnContinue.Text = "暂停";
            this.lblTime.Text = "00:00";
            this.btnFinish.Enabled = true;
            this.btnReturn.Enabled = true;
            this.btnAddFlush.Enabled = true;
            this.dgvStep.Enabled = true;
            this.dgvStep.ClearSelection();
        }

        private void ReadLastActionAVState()
        {
            BLL.actions bllact = new BLL.actions();
            if(m_lstCust.Count > 0)
            {
                //读取步骤下相应的动作列表
                int customID = (int)m_lstCust[m_lstCust.Count-1].ID;
                List<ALS.Model.actions> lstModAct = bllact.GetModelList("customID='" + customID + "'");
                List<Cls.Model_SendCMD> lstActions = new List<Cls.Model_SendCMD>();
                if (lstModAct.Count > 0)
                {
                    lstActions = GetlstActions(lstModAct);
                    UpdatePumpState(lstActions);
                }
            }            
        }

        private void dgvStep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvStep.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvStep.Rows[i].Cells["selAdd"];
                checkBox.Value = 0;
                dgvStep.Rows[i].Selected = false;
            }

            if (e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvStep.Rows[e.RowIndex].Cells["selAdd"];
                checkBox.Value = 1;
                dgvStep.Rows[e.RowIndex].Selected = true;
                //读取该步骤的信息，如时间；
                m_tCountAddFlush = (int)m_lstCust[e.RowIndex].timeSpan;
                this.lblFullTime.Text = Cls.utils.SecondsToTime(m_tCountAddFlush);
            }
        }

        private void dgvStep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        public void btnAddFlush_Click(object sender, EventArgs e)
        {
            if (this.dgvStep.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要追加预冲的步骤!");
                return;
            }
            else
            {
                m_isAddFlush = !m_isAddFlush;
                if (m_isAddFlush)
                {
                    int customID = Convert.ToInt32(this.dgvStep.SelectedRows[0].Cells["ID"].Value);
                    m_tCountAddFlush = (int)m_lstCust[this.dgvStep.SelectedRows[0].Index].timeSpan;

                    BLL.actions bllact = new BLL.actions();
                    List<ALS.Model.actions> lstModAct = bllact.GetModelList("customID='" + customID + "'");
                    List<Cls.Model_SendCMD> lstActions = new List<Cls.Model_SendCMD>();
                    if (lstModAct.Count > 0)
                    {
                        lstActions = GetlstActions(lstModAct);
                        //创建发送追加预冲的任务
                        m_taskActions = new Task(RunActions, lstActions, TaskCreationOptions.LongRunning);
                        m_taskActions.Start();
                    }
                    this.btnAddFlush.Text = "停止";
                    //改变Enable
                    this.btnStart.Enabled = false;
                    this.btnFinish.Enabled = false;
                    this.dgvStep.Enabled = false;
                    //简单的步骤计时器
                    this.timerFlush.Enabled = true;
                    this.timerFlush.Start();
                }
                else
                {
                    this.btnAddFlush.Text = "追加预冲";
                    //发送停止命令
                    Cls.utils.SendOrder(_port_Pump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                    //this.btnStart.Enabled = false;
                    this.btnFinish.Enabled = true;
                    this.dgvStep.Enabled = true;
                    timerFlush.Enabled = false;
                    timerFlush.Stop();
                    M_int_FlushCount = 0;
                    m_tCountAddFlush = 0;
                    this.timerFlush.Stop();
                }
            }
        }

        private List<Cls.Model_SendCMD> GetlstActions(List<ALS.Model.actions> lstModAct)
        {
            List<Cls.Model_SendCMD> lstActions = new List<Cls.Model_SendCMD>();
            foreach (var v in lstModAct)
            {
                byte[] buff = v.arrCommand;
                int cmdLen = v.cmdLength;
                byte[] cmdArry = new byte[cmdLen];
                Array.Copy(buff, cmdArry, cmdLen);
                SerialPort sp = new SerialPort();
                switch (v.portName.ToLower())
                {
                    case "com1":
                        sp = _port_Main;
                        break;
                    case "com2":
                        break;
                    case "com3":
                        sp = _port_Pump;
                        break;
                }
                Cls.Model_SendCMD item = new Cls.Model_SendCMD(sp, cmdLen, cmdArry);
                lstActions.Add(item);
            }
            return lstActions;
        }

        private void timerFlush_Tick(object sender, EventArgs e)
        {
            M_int_FlushCount++;
            this.lblTime.Text = Cls.utils.SecondsToTime(M_int_FlushCount);
            if(M_int_FlushCount>=m_tCountAddFlush)
            {               
                btnAddFlush_Click(this.btnAddFlush, new EventArgs());
            }
        }
    }
}
