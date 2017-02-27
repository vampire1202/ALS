using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ALS;
using System.IO;
using System.IO.Ports;

namespace ALS
{
    public partial class frmCustomAction : Form
    {
        string _method=string.Empty;
        ALS.BLL.customactions m_bllc = new ALS.BLL.customactions();
        ALS.Model.customactions m_modc;
        List<ALS.Model.customactions> m_lstModc = new List<ALS.Model.customactions>();
        ALS.Model.actions m_modAct;
        int m_customID=-1;
        int m_ActionID=-1;

        private SerialPort _port_Main;
        public SerialPort Port_Main
        {
            get { return _port_Main; }
            set { _port_Main = value; }
        }

        private SerialPort _port_Pump;
        public SerialPort Port_Pump
        {
            get { return _port_Pump; }
            set { _port_Pump = value; }
        }

        private SerialPort _port_injectionPump;
        public SerialPort Port_injectionPump
        {
            get { return _port_injectionPump; }
            set { _port_injectionPump = value; }
        }

        //蠕动泵
        string m_strPumpText=string.Empty;
        string m_strPumpDirection=string.Empty;
        byte m_pumpID;          //泵ID
        bool m_bPumpDirection;  //泵方向
        bool m_bPumpRun;        //泵是否运转
        //夹管阀
        byte m_VID;             //夹管阀ID 
        //气泡
        byte m_ADID;            //气泡ID
        

        public frmCustomAction(string method)
        {
            _method = method;
            InitializeComponent();
        }

        private void frmCustomAction_Load(object sender, EventArgs e)
        {
            this.Text = _method + "-自定义操作管理";
            ShowCustomActions(_method);
            UnEnableControl();
            this.tabActions.Enabled = false; 
            GetActionInfoList(this.cmbAction,GetmethodStyle(_method));
            //m_lstModc = m_bllc.GetModelList(" methodName='" + _method + "'");
        }

        private string GetmethodStyle(string method)
        {
            int index = _method.LastIndexOf('_')+1;
            return method.Substring(index);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableControl();
            if (m_bllc.GetList("methodName='"+_method+"'",true).Tables[0].Rows.Count > 0)
            {
                //查询最后一项记录
                m_modc = m_bllc.GetModelOfMaxID(_method);
                if (m_modc != null)
                {
                    this.cmbAction.Text = "";
                    //取最后一条数据的时间点和持续时间 作为下一步骤的时间点
                    int sumTime = (int)m_modc.timeCount + (int)m_modc.timeSpan;
                    int hour = (int)sumTime / 3600;
                    int min = (int)(sumTime % 3600) / 60;
                    int sec = (int)sumTime % 60;
                    this.lblHour.Text = hour.ToString("00");
                    this.lblMin.Text = min.ToString("00");
                    this.lblSec.Text = sec.ToString("00");
                    this.lblHourc.Text = "00";
                    this.lblMinc.Text = "00";
                    this.lblSecc.Text = "00";
                    //持续时间自己定义
                }
            }
            else
            {
                this.lblHour.Text = this.lblHourc.Text = this.lblMin.Text = this.lblMinc.Text = this.lblSec.Text = this.lblSecc.Text = "00";
            }
        }

        private DataTable dsCustomActions(string methodname)
        {
            DataTable dt = new DataTable();
            ALS.BLL.customactions bllcustom = new ALS.BLL.customactions();
            dt= bllcustom.GetList(" methodname='" + methodname + "'",true).Tables[0];
            dt.Columns.Add("序号", System.Type.GetType("System.String")).SetOrdinal(1);
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                dt.Rows[i][1] = (i + 1).ToString();
            } 
           return dt;
        }

        private void ShowCustomActions(string _m)
        {
            this.dgvCustomActions.DataSource = dsCustomActions(_m);
            for (int i = 0; i < this.dgvCustomActions.Columns.Count; i++)
            {                
                this.dgvCustomActions.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dgvCustomActions.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
           
            this.dgvCustomActions.Columns[0].Visible = false;
            this.dgvCustomActions.Refresh(); 
        }

        private void rbtnBP_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                rb.BackColor = Color.Gold;
                m_strPumpText = rb.Text;
                m_pumpID = Convert.ToByte(rb.Tag.ToString());
                if(m_pumpID == 31)
                {
                    this.rbtnClockwise.Enabled = this.rbtnAntiClockwise.Enabled = false; 
                }
                else
                {
                    this.rbtnClockwise.Enabled = this.rbtnAntiClockwise.Enabled = true; 
                }
            }
            else
                rb.BackColor = Color.Transparent;

        }

        private void lblHour_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            _numPad.btnDot.Visible = false;
            _numPad.btnNegPos.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                //if (lbl.Name == "lblMMin" || lbl.Name == "lblSec")
                //{
                //    if (_numPad.Value >= 60)
                //    {
                //        MessageBox.Show("请输入小于60的整数"); 
                //        return;
                //    }
                //}
                lbl.Text = _numPad.Value.ToString("00");
            }
        }

        private void dgCustomAction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                UnEnableControl();
                this.lblHourc.Enabled = true;
                this.lblMinc.Enabled = true;
                this.lblSecc.Enabled = true;
                this.tabActions.Enabled = true;
                this.btnUpdate.Enabled = true;
                m_customID = Convert.ToInt32(dgvCustomActions.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                //获取该步骤信息
                ALS.BLL.customactions bllc = new ALS.BLL.customactions();
                m_modc = bllc.GetModel(m_customID);
                if (m_modc != null)
                {
                    this.cmbAction.Text = m_modc.actionName;
                    this.cmbAction.Text = m_modc.actionName;
                    this.lbltsPump.Text = Cls.utils.SecondsToTime((int)m_modc.timeSpan);
                    int hour = (int)m_modc.timeCount / 3600;
                    int min = (int)(m_modc.timeCount % 3600) / 60;
                    int sec = (int)m_modc.timeCount % 60;
                    this.lblHour.Text = hour.ToString("00");
                    this.lblMin.Text = (min).ToString("00");
                    this.lblSec.Text = sec.ToString("00");

                    int hourc = (int)m_modc.timeSpan / 3600;
                    int minc = (int)(m_modc.timeSpan % 3600) / 60;
                    int secc = (int)(m_modc.timeSpan % 60);
                    this.lblHourc.Text = hourc.ToString("00");
                    this.lblMinc.Text = minc.ToString("00");
                    this.lblSecc.Text = secc.ToString("00");
                }
                //获取该时间点作列表
                ShowActions(m_customID);
            }
            else
            {
                m_customID = -1;
                m_modc = null;
                this.tabActions.Enabled = false;
            }
        }

        private void lblPumpSpeed_Click(object sender, EventArgs e)
        {
            Label tb = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(tb.Text);
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                tb.Text = _numPad.Value.ToString("f1");
                //计算预计流量
                int ts=0;
                if(m_modc!=null)
                  ts = (int)m_modc.timeSpan;
                double min = Math.Round(ts / 60.0, 3);
                double speed = Convert.ToDouble(this.lblPumpSpeed.Text);
                this.lblml.Text = (speed * min).ToString("0.0");
            }
        }

        private void btnAddActionOfPump_Click(object sender, EventArgs e)
        {
            if (m_pumpID==0)
            {
                MessageBox.Show("请选择泵!");
                return;
            }

            if ((!rbtnClockwise.Checked) && (!rbtnAntiClockwise.Checked) && (!rbtnIsRun.Checked))
            {
                MessageBox.Show("请选择泵运转方向!");
                return;
            }
         
            //当选择所有泵时，必须选择rbtnIsRun
            if(rbtnAllPump.Checked)
            {
                if(rbtnIsRun.Checked == false)
                {
                    MessageBox.Show("请选择所有泵的运转状态,此处必须选择停止!");
                    return;
                }
            }

            if (lblPumpSpeed.Text == "0.0" && (!rbtnIsRun.Checked))
            {
                MessageBox.Show("请设定泵速!");
                return;
            }


            if (m_modc != null)
            {
                m_customID =(int) m_modc.ID;
                ALS.Model.actions modact = new ALS.Model.actions();
                modact.customID = m_customID;
                m_bPumpDirection = rbtnClockwise.Checked ? true : false;
                m_bPumpRun = rbtnIsRun.Checked ? false : true;
                modact.arrCommand = Cls.Comm_PeristalticPump.Command(m_pumpID, Convert.ToDouble(this.lblPumpSpeed.Text), m_bPumpRun, m_bPumpDirection);

                modact.portName = _port_Pump.PortName;
                modact.cmdLength = modact.arrCommand.Length;
                if (m_bPumpRun)
                    modact.actionInfo = m_strPumpText + "," + m_strPumpDirection + "," + lblPumpSpeed.Text + "mL/min,持续时间:" + lbltsPump.Text + ",预计流量:" + lblml.Text + "mL";
                else
                    modact.actionInfo = m_strPumpText + ",停止运行!";
                ALS.BLL.actions bllact = new ALS.BLL.actions();

                if (bllact.Add(modact))
                { 
                    DataSet dsact = bllact.GetList("customID='" + m_customID + "'",true);
                    this.dgActions.DataSource = dsact.Tables[0];
                    this.dgActions.Refresh();
                } 
            }
            else
            {
                MessageBox.Show("请选择需要添加操作的步骤", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void EnableControl()
        {
            this.btnSave.Enabled =  this.cmbAction.Enabled = this.lblHourc.Enabled = this.lblMinc.Enabled = this.lblSecc.Enabled=this.btnSave.Enabled  = true;
            this.tabActions.Enabled = false;
            this.btnUpdate.Enabled = false; 
            this.cmbAction.Text = "";
            this.lblPumpSpeed.Text = "0.0";
        }

        private void UnEnableControl()
        {
            this.btnSave.Enabled =  this.cmbAction.Enabled = this.lblHourc.Enabled = this.lblMinc.Enabled = this.lblSecc.Enabled = this.btnSave.Enabled =  false;
            this.btnUpdate.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //int hour = int.Parse(this.lblHour.Text);
            //int min = int.Parse(this.lblMin.Text);
            //int sec = int.Parse(this.lblSec.Text);
            //int timecount = hour * 3600 + min * 60 + sec;

            int hourc = int.Parse(this.lblHourc.Text);
            int minc = int.Parse(this.lblMinc.Text);
            int secc = int.Parse(this.lblSecc.Text);
            int timespan = hourc * 3600 + minc * 60 + secc;

            //if (!this.txtAction.Enabled)
            //{
            //    MessageBox.Show("请点击'输入步骤'按钮", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            
            //if (string.IsNullOrEmpty(this.txtAction.Text))
            //{
            //    MessageBox.Show("请输入该步骤描述信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (string.IsNullOrEmpty(this.cmbAction.Text))
            {
                MessageBox.Show("请输入该步骤描述信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    

            if (timespan == 0)
            {
                MessageBox.Show("持续时间不能为 0 ","警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ALS.BLL.customactions bllcustom = new ALS.BLL.customactions();
            ALS.Model.customactions modelcustom = bllcustom.GetModel(this._method, this.cmbAction.Text.Trim());
            //CustomActions.BLL.actions bllaction = new CustomActions.BLL.actions();
            //DataSet dsaction = bllaction.GetList("customID='"+ modelcustom.ID+"'");
            //先查询该时间点是否有重复的
            if (modelcustom != null)
            {
                MessageBox.Show("已存在相同的步骤名称，请重新设置!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }           
            else
            {
                m_modc = new ALS.Model.customactions();
                m_modc.timeString = Cls.utils.SecondsToTime(0);
                m_modc.actionName = this.cmbAction.Text.Trim();
                m_modc.methodName = _method;
                m_modc.timeCount = 0;
                m_modc.timeSpan = timespan;
                m_modc.timeSpanString = Cls.utils.SecondsToTime(timespan);
                m_bllc = new ALS.BLL.customactions();
                if (m_bllc.Add(m_modc))
                {
                    //刷新列表,sort by timecount
                    ShowCustomActions(_method);
                    m_modc = null;
                    UnEnableControl();
                }
            }
        }

        private void rbtnClockwise_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                rb.BackColor = Color.Gold;
                m_strPumpDirection = rb.Text;
            }
            else
                rb.BackColor = Color.Transparent;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            m_modc = m_bllc.GetModelOfMaxID(_method);
            if (m_modc != null)
            {
                if (DialogResult.OK == MessageBox.Show("确认删除步骤: " + m_modc.actionName + " ?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    m_bllc.Delete(m_modc.ID);
                    ShowCustomActions(_method);
                    this.lblHourc.Text = this.lblMinc.Text = this.lblSecc.Text = "00";
                    this.cmbAction.Text = "";
                    m_modc = null;
                }
            }
            else
            {
                MessageBox.Show("无删除项!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void rbtnV1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                rb.BackColor = Color.Gold;
                m_VID = Convert.ToByte(rb.Tag.ToString());
            }
            else
                rb.BackColor = Color.Transparent;
        }

        private void rbtnClampV_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                rb.BackColor = Color.Gold; 
            }
            else
                rb.BackColor = Color.Transparent;
        }

        private void ShowActions(long customID)
        {
            ALS.BLL.actions bllact = new ALS.BLL.actions();
            DataSet dsact = bllact.GetList("customID='" + customID + "'",true);
            this.dgActions.DataSource = dsact.Tables[0];
            this.dgActions.Columns[0].Visible = this.dgActions.Columns[1].Visible = false;
            this.dgActions.Refresh();
        }

        private void btnAddActionOfV_Click(object sender, EventArgs e)
        {
            if (m_VID == 0)
            {
                MessageBox.Show("请选择夹管阀");
                return;
            }

            if (!(rbtnClampV.Checked) && !(rbtnLooseV.Checked))
            {
                MessageBox.Show("请选择夹管阀动作状态");
                return;
            }

            ALS.Model.actions modact = new ALS.Model.actions();
            ALS.BLL.actions bllact = new ALS.BLL.actions();
            switch (m_VID)
            {
                case 1:
                    if (rbtnClampV.Checked)
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.ClampV1;
                        modact.actionInfo = "夹管阀1夹管";                      
                    }
                    else
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.LoosenV1;
                        modact.actionInfo = "夹管阀1松管";                        
                    }                     
                    break;
                case 2:
                    if (rbtnClampV.Checked)
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.ClampV2;
                        modact.actionInfo = "夹管阀2夹管";
                    }
                    else
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.LoosenV2;
                        modact.actionInfo = "夹管阀2松管";
                    }                 
                    break;
                case 3:
                    if (rbtnClampV.Checked)
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.ClampV3;
                        modact.actionInfo = "夹管阀3夹管";
                    }
                    else
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.LoosenV3;
                        modact.actionInfo = "夹管阀3松管";
                    }                 
                    break;
                case 4:
                    if (rbtnClampV.Checked)
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.ClampV4;
                        modact.actionInfo = "夹管阀4夹管";
                    }
                    else
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.LoosenV4;
                        modact.actionInfo = "夹管阀4松管";
                    }                 
                    break;
                case 5:
                    if (rbtnClampV.Checked)
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.ClampV5;
                        modact.actionInfo = "夹管阀5夹管";
                    }
                    else
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.LoosenV5;
                        modact.actionInfo = "夹管阀5松管";
                    }                 
                    break;
                case 6:
                    if (rbtnClampV.Checked)
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.ClampV6;
                        modact.actionInfo = "夹管阀6夹管";
                    }
                    else
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdValve.LoosenV6;
                        modact.actionInfo = "夹管阀6松管";
                    }                 
                    break;              
            }
            modact.customID = m_customID;
            modact.portName = Port_Main.PortName;
            modact.cmdLength = modact.arrCommand.Length;
            if (bllact.Add(modact))
                ShowActions(m_customID);
        }

        private void lblPumpSpeed_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rbtnAD1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                rb.BackColor = Color.Gold;
                m_ADID = Convert.ToByte(rb.Tag.ToString());
            }
            else
                rb.BackColor = Color.Transparent;         
        }

        private void rbtnAddActionOfAD_Click(object sender, EventArgs e)
        {
            if (m_ADID == 0)
            {
                MessageBox.Show("请选择气泡检测器");
                return;
            }

            if (!(this.rbtnOpenAD.Checked) && !(this.rbtnCloseAD.Checked))
            {
                MessageBox.Show("请选择气泡检测器状态");
                return;
            }

            ALS.Model.actions modact = new ALS.Model.actions();
            ALS.BLL.actions bllact = new ALS.BLL.actions();
            switch (m_ADID)
            {
                case 1:
                    if (rbtnOpenAD.Checked)
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdBubble.OpenBubble1;
                        modact.actionInfo = "气泡检测器1打开";
                    }
                    else
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdBubble.CloseBubble1;
                        modact.actionInfo = "气泡检测器1关闭";
                    }
                    break;
                case 2:
                    if (rbtnOpenAD.Checked)
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdBubble.OpenBubble2;
                        modact.actionInfo = "气泡检测器2打开";
                    }
                    else
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdBubble.CloseBubble2;
                        modact.actionInfo = "气泡检测器2关闭";
                    }
                    break;
                case 3:
                    if (rbtnOpenAD.Checked)
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdBubble.OpenBubble3;
                        modact.actionInfo = "气泡检测器3打开";
                    }
                    else
                    {
                        modact.arrCommand = Cls.Comm_Main.CmdBubble.CloseBubble3;
                        modact.actionInfo = "气泡检测器3关闭";
                    }
                    break;               
            }
            modact.customID = m_customID;
            modact.portName = Port_Main.PortName;
            modact.cmdLength = modact.arrCommand.Length;
            if (bllact.Add(modact))
                ShowActions(m_customID);
        }

        private void rbtnOpenAD_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
                rb.BackColor = Color.Gold; 
            else
                rb.BackColor = Color.Transparent;         
        }

        private void dgActions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                UnEnableControl();
                this.btnUpdate.Enabled = true;
                m_ActionID = Convert.ToInt32(dgActions.Rows[e.RowIndex].Cells["ID"].Value.ToString()); 
            }
            else
            {
                m_ActionID = -1; 
            } 
        }

        private void btnDelAction1_Click(object sender, EventArgs e)
        {
            if (m_ActionID != -1)
            {
                ALS.BLL.actions bllact = new ALS.BLL.actions();
                //获取该步骤信息  
                if (DialogResult.Yes == MessageBox.Show("确认删除该动作?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (bllact.Delete(m_ActionID))
                        ShowActions(m_customID);
                    m_ActionID = -1;
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的动作", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        private void lbltsPump_TextChanged(object sender, EventArgs e)
        {
            //计算预计流量
            int ts = 0;
            if (m_modc != null)
                ts = (int)m_modc.timeSpan;
            double min = Math.Round(ts / 60.0, 3);
            double speed = Convert.ToDouble(this.lblPumpSpeed.Text);
            this.lblml.Text = (speed * min).ToString("00");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int hourc = int.Parse(this.lblHourc.Text);
            int minc = int.Parse(this.lblMinc.Text);
            int secc = int.Parse(this.lblSecc.Text);
            int timespan = hourc * 3600 + minc * 60 + secc;
            if (timespan == 0)
            {
                MessageBox.Show("持续时间不能为 0 ", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ALS.BLL.customactions bllcustom = new ALS.BLL.customactions();
            ALS.Model.customactions modelcustom = bllcustom.GetModel(this._method, this.cmbAction.Text.Trim());
            //CustomActions.BLL.actions bllaction = new CustomActions.BLL.actions();
            //DataSet dsaction = bllaction.GetList("customID='"+ modelcustom.ID+"'");
            //先查询该时间点是否有重复的
            if (modelcustom != null)
            {
                //m_modc = new CustomActions.Model.customactions();
                modelcustom.timeString = Cls.utils.SecondsToTime(0);
                modelcustom.actionName = this.cmbAction.Text.Trim();
                modelcustom.methodName = _method;
                modelcustom.timeCount = 0;
                modelcustom.timeSpan = timespan;
                modelcustom.timeSpanString = Cls.utils.SecondsToTime(timespan);
                m_bllc = new ALS.BLL.customactions();
                if (m_bllc.Update(modelcustom))
                {
                    //刷新列表,sort by timecount
                    ShowCustomActions(_method); 
                    UnEnableControl();
                }
            }
        }

        private void btnSaveTitle_Click(object sender, EventArgs e)
        {            
            if(string.IsNullOrEmpty(this.cmbAction.Text))
            {
                MessageBox.Show("请输入描述信息");
                return;
            }

            ALS.BLL.actiontitle bllat = new ALS.BLL.actiontitle();
            if(bllat.GetModel(this.cmbAction.Text,GetmethodStyle(_method)) ==null )
            {
                ALS.Model.actiontitle mat = new ALS.Model.actiontitle();
                mat.info = this.cmbAction.Text.Trim();
                mat.method = GetmethodStyle(_method);
                if(bllat.Add(mat))
                {
                    GetActionInfoList(this.cmbAction,GetmethodStyle(_method));
                    MessageBox.Show("保存成功!");
                }
            }
            else
                MessageBox.Show("已存在的描述信息!"); 
        }

        private void GetActionInfoList(ComboBox cmb,string method)
        {
            cmb.Items.Clear();
            ALS.BLL.actiontitle bllat = new ALS.BLL.actiontitle();
            DataSet dsAt = bllat.GetList("method='" + method + "'");
            int count = dsAt.Tables[0].Rows.Count;
            for(int i = 0;i<count;i++)
            {
                cmb.Items.Add(dsAt.Tables[0].Rows[i]["info"].ToString());
            }
            //List<CustomActions.Model.actiontitle> lstMat = bllat.GetModelList("");
            //foreach(var v in lstMat)
            //{
            //    cmb.Items.Add(v.info);
            //}
        }
    }
}
