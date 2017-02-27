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
using System.Drawing.Imaging;
using System.Threading;

namespace ALS
{
    public partial class frmCustomAction : Form
    {
        string _method = string.Empty;
        ALS.BLL.customactions m_bllc = new ALS.BLL.customactions();
        ALS.Model.customactions m_modc;
        List<ALS.Model.customactions> m_lstModc = new List<ALS.Model.customactions>();
        //ALS.Model.actions m_modAct;
        int m_customID = -1;
        int m_ActionID = -1;

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
        string m_strPumpText = string.Empty;
        string m_strPumpDirection = string.Empty;
        byte m_pumpID;          //泵ID
        bool m_bPumpDirection;  //泵方向
        bool m_bPumpRun;        //泵是否运转
        //夹管阀
        //byte m_VID;             //夹管阀ID 
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
            GetActionInfoList(this.cmbAction, GetmethodStyle(_method));
            this.chkV1.CheckState = chkV2.CheckState = chkV3.CheckState
                = chkV4.CheckState = chkV5.CheckState = chkV6.CheckState;
            //m_lstModc = m_bllc.GetModelList(" methodName='" + _method + "'");
        }

        private string GetmethodStyle(string method)
        {
            int index = _method.LastIndexOf('_') + 1;
            return method.Substring(index);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableControl();
            if (m_bllc.GetList("methodName='" + _method + "'", true).Tables[0].Rows.Count > 0)
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
            dt = bllcustom.GetList(" methodname='" + methodname + "'", true).Tables[0];
            dt.Columns.Add("序号", System.Type.GetType("System.String")).SetOrdinal(1);
            for (int i = 0; i < dt.Rows.Count; i++)
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
                if (m_pumpID == 31)
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
                m_modc = m_bllc.GetModel(m_customID);
                if (m_modc != null)
                {
                    this.cmbAction.Text = m_modc.actionName;
                    this.lbltsPump.Text = Cls.utils.SecondsToTime((int)m_modc.timeSpan);
                    if (m_modc.timeSpan == 0)
                        //如果持续时间为0 则表示提示框
                        btnUpdate.Enabled = false;
                    else
                        btnUpdate.Enabled = true;

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
                    //读取提示图片
                    byte[] b = (byte[])m_modc.tipPic;
                    if (b != null)
                    {
                        MemoryStream ms = new MemoryStream(b);
                        Bitmap bmp = new Bitmap(ms);
                        this.picTip.Image = bmp;
                        ms.Close();
                        ms.Dispose();
                    }
                    else
                        this.picTip.Image = null;

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
            _numPad.btnNegPos.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                tb.Text = _numPad.Value.ToString("f1");
                //计算预计流量
                int ts = 0;
                if (m_modc != null)
                    ts = (int)m_modc.timeSpan;
                double min = Math.Round(ts / 60.0, 3);
                double speed = Convert.ToDouble(this.lblPumpSpeed.Text);
                this.lblml.Text = (speed * min).ToString("0.0");
            }
        }

        private void btnAddActionOfPump_Click(object sender, EventArgs e)
        {
            if (m_pumpID == 0)
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
            if (rbtnAllPump.Checked)
            {
                if (rbtnIsRun.Checked == false)
                {
                    MessageBox.Show("请选择所有泵的运转状态,此处必须选择停止!");
                    return;
                }
            }

            //if (lblPumpSpeed.Text == "0.0" && (!rbtnIsRun.Checked))
            //{
            //    MessageBox.Show("请设定泵速!");
            //    return;
            //}

            if (m_modc != null)
            {
                //当前选择的自定义步骤
                m_customID = (int)m_modc.ID;
                //添加泵动作
                //针对创新模式中，预计  预冲量的确认需要计算：
                //第一部分：预冲量 以自定义步骤中 BP运转时间 * 速度；
                //第二部分：预冲量 以自定义步骤中 RP运转时间 * 速度；
                //当添加的动作里包含 BP 或 RP 运转时，需要更新该步骤中的累计流量字段； 
                //注：原有字段 timeCount ,存储 累计流量
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
                    ////如果泵ID为1
                    //if(m_pumpID==1)
                    //{
                    //    m_modc.timeCount = int.Parse(lblml.Text);
                    //    new BLL.customactions().Update(m_modc);
                    //}                   
                    DataSet dsact = bllact.GetList("customID='" + m_customID + "'", true);
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
            this.btnSave.Enabled = this.cmbAction.Enabled = this.lblHourc.Enabled = this.lblMinc.Enabled = this.lblSecc.Enabled = this.btnSave.Enabled = true;
            this.tabActions.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.cmbAction.Text = "";
            this.lblPumpSpeed.Text = "0.0";
        }

        private void UnEnableControl()
        {
            this.btnSave.Enabled = this.cmbAction.Enabled = this.lblHourc.Enabled = this.lblMinc.Enabled = this.lblSecc.Enabled = this.btnSave.Enabled = false;
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
                if (DialogResult.OK == MessageBox.Show("持续时间为0，点确定将添加为提示信息！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    //添加的是一个提示框
                    m_modc = new ALS.Model.customactions();
                    m_modc.timeString = Cls.utils.SecondsToTime(0);
                    m_modc.actionName = this.cmbAction.Text.Trim();
                    m_modc.methodName = _method;
                    m_modc.timeCount = 0;
                    m_modc.timeSpan = 0;
                    m_modc.timeSpanString = Cls.utils.SecondsToTime(0);
                    m_bllc = new ALS.BLL.customactions();
                    if (m_bllc.Add(m_modc))
                    {
                        //刷新列表,sort by timecount
                        ShowCustomActions(_method);
                        m_modc = null;
                        UnEnableControl();
                    }
                }
                else return;
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

        private void rbtnClampV_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox rb = sender as CheckBox;
            if (rb.Checked)
                rb.Image = global::ALS.Properties.Resources.clipclose;
            else
                rb.Image = global::ALS.Properties.Resources.clipopen;
        }

        private void ShowActions(long customID)
        {
            ALS.BLL.actions bllact = new ALS.BLL.actions();
            DataSet dsact = bllact.GetList("customID='" + customID + "'", true);
            this.dgActions.DataSource = dsact.Tables[0];
            this.dgActions.Columns[0].Visible = this.dgActions.Columns[1].Visible = false;
            this.dgActions.Refresh();
        }

        private void btnAddActionOfV_Click(object sender, EventArgs e)
        {

            byte[] vstate = new byte[6];
            StringBuilder sb = new StringBuilder();
            ALS.Model.actions modact = new ALS.Model.actions();
            ALS.BLL.actions bllact = new ALS.BLL.actions();

            if (chkV1.Checked)
            { sb.Append("V1夹管,"); vstate[0] = 0x01; }
            else
            { sb.Append("V1松管,"); vstate[0] = 0x00; }

            if (chkV2.Checked)
            { sb.Append("V2夹管,"); vstate[1] = 0x01; }
            else
            { sb.Append("V2松管,"); vstate[1] = 0x00; }
            if (chkV3.Checked)
            { sb.Append("V3夹管,"); vstate[2] = 0x01; }
            else
            { sb.Append("V3松管,"); vstate[2] = 0x00; }
            if (chkV4.Checked)
            { sb.Append("V4夹管,"); vstate[3] = 0x01; }
            else
            { sb.Append("V4松管,"); vstate[3] = 0x00; }
            if (chkV5.Checked)
            { sb.Append("V5夹管,"); vstate[4] = 0x01; }
            else
            { sb.Append("V5松管,"); vstate[4] = 0x00; }
            if (chkV6.Checked)
            { sb.Append("V6夹管."); vstate[5] = 0x01; }
            else
            { sb.Append("V6松管."); vstate[5] = 0x00; }

            string info = sb.ToString();

            if (DialogResult.OK == MessageBox.Show("请确认夹管阀状态是否正确:[" + info + "] ?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                modact.actionInfo = info;
                modact.customID = m_customID;
                modact.portName = Port_Main.PortName;
                modact.arrCommand = Cls.Comm_Main.CmdValve.SetVState(vstate[0], vstate[1], vstate[2], vstate[3], vstate[4], vstate[5]);
                modact.cmdLength = modact.arrCommand.Length;
                if (bllact.Add(modact))
                    ShowActions(m_customID);
            }
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
            if (string.IsNullOrEmpty(this.cmbAction.Text))
            {
                MessageBox.Show("请输入描述信息");
                return;
            }

            ALS.BLL.actiontitle bllat = new ALS.BLL.actiontitle();
            if (bllat.GetModel(this.cmbAction.Text, GetmethodStyle(_method)) == null)
            {
                ALS.Model.actiontitle mat = new ALS.Model.actiontitle();
                mat.info = this.cmbAction.Text.Trim();
                mat.method = GetmethodStyle(_method);
                if (bllat.Add(mat))
                {
                    GetActionInfoList(this.cmbAction, GetmethodStyle(_method));
                    MessageBox.Show("保存成功!");
                }
            }
            else
                MessageBox.Show("已存在的描述信息!");
        }

        private void GetActionInfoList(ComboBox cmb, string method)
        {
            cmb.Items.Clear();
            ALS.BLL.actiontitle bllat = new ALS.BLL.actiontitle();
            DataSet dsAt = bllat.GetList("method='" + method + "'");
            int count = dsAt.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                cmb.Items.Add(dsAt.Tables[0].Rows[i]["info"].ToString());
            }
            //List<CustomActions.Model.actiontitle> lstMat = bllat.GetModelList("");
            //foreach(var v in lstMat)
            //{
            //    cmb.Items.Add(v.info);
            //}
        }

        private void btnVeinOpen_Click(object sender, EventArgs e)
        {
            ALS.Model.actions modact = new ALS.Model.actions();
            ALS.BLL.actions bllact = new ALS.BLL.actions();
            Button b = sender as Button;
            if (b.Tag != null)
            { 
                switch (b.Tag.ToString())
                {
                    case "1":
                        modact.arrCommand = Cls.Comm_Main.LiquidLevel.liquidLevel1Up;
                        modact.actionInfo = "静脉壶液面上升";
                        break;
                    case "2":
                        modact.arrCommand = Cls.Comm_Main.LiquidLevel.liquidLevel1Down;
                        modact.actionInfo = "静脉壶液面下降";
                        break;
                    case "3":
                        modact.arrCommand = Cls.Comm_Main.LiquidLevel.liquidLevel2Up;
                        modact.actionInfo = "动脉壶液面上升";
                        break;
                    case "4":
                        modact.arrCommand = Cls.Comm_Main.LiquidLevel.liquidLevel2Down;
                        modact.actionInfo = "动脉壶液面下降";
                        break;
                    case "5":
                        modact.arrCommand = Cls.Comm_Main.LiquidLevel.liquidLevel3Up;
                        modact.actionInfo = "M1液面上升";
                        break;
                    case "6":
                        modact.arrCommand = Cls.Comm_Main.LiquidLevel.liquidLevel3Down;
                        modact.actionInfo = "M1液面下降";
                        break;
                }
            }
            modact.customID = m_customID;
            modact.portName = Port_Main.PortName;
            modact.cmdLength = modact.arrCommand.Length;
            if (bllact.Add(modact))
                ShowActions(m_customID);
        }

        private void btnVoiseClose_Click(object sender, EventArgs e)
        {
            ALS.Model.actions modact = new ALS.Model.actions();
            ALS.BLL.actions bllact = new ALS.BLL.actions();
            Button b = sender as Button;
            switch (b.Tag.ToString())
            {

                case "voise1":
                    modact.arrCommand = Cls.Comm_Main.CmdAlarmLamp.Alarm1;
                    modact.actionInfo = "报警音1";
                    break;
                case "voise2":
                    modact.arrCommand = Cls.Comm_Main.CmdAlarmLamp.Alarm2;
                    modact.actionInfo = "报警音2";
                    break;
                case "lightclose":
                    modact.arrCommand = Cls.Comm_Main.CmdAlarmLamp.AllLightClose;
                    modact.actionInfo = "所有灯关闭";
                    break;
                case "lightred":
                    modact.arrCommand = Cls.Comm_Main.CmdAlarmLamp.RedTwinkle;
                    modact.actionInfo = "红灯闪烁";
                    break;
                case "lightyellow":
                    modact.arrCommand = Cls.Comm_Main.CmdAlarmLamp.YellowTwinkle;
                    modact.actionInfo = "黄灯闪烁";
                    break;
                case "lightgreen":
                    modact.arrCommand = Cls.Comm_Main.CmdAlarmLamp.GreenAlways;
                    modact.actionInfo = "绿灯常亮";
                    break;
            }
            modact.customID = m_customID;
            modact.portName = Port_Main.PortName;
            modact.cmdLength = modact.arrCommand.Length;
            if (bllact.Add(modact))
                ShowActions(m_customID);
        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片(*.png,*.jpg)|*.png;*.jpg";
            if(DialogResult.OK == ofd.ShowDialog())
            {
                Bitmap bp =(Bitmap)Image.FromFile(ofd.FileName);
                this.picTip.Image = bp;
            }
        }

        private void btnUpdatePic_Click(object sender, EventArgs e)
        {
            if(this.picTip.Image!=null && m_modc !=null)
            {
                Bitmap bp = (Bitmap) this.picTip.Image;
                MemoryStream ms = new MemoryStream();
                bp.Save(ms, ImageFormat.Png);
                byte[] b = new byte[ms.Length];
                b = ms.ToArray(); 
                if(m_modc!=null)
                {
                    m_modc.tipPic = b; 
                    if (m_bllc.Update(m_modc))
                        MessageBox.Show("更新成功!");
                }
            }
        }
    }
}
