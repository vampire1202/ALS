using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
namespace ALS.Manager
{
    public partial class frmAdmin : Form
    {

        private SerialPort _port_ppump;
        /// <summary>
        /// 蠕动泵通讯端口
        /// </summary>
        public SerialPort _Port_ppump
        {
            get { return _port_ppump; }
            set { _port_ppump = value; }
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

        private SerialPort _port_hpump;
        /// <summary>
        /// 注射器通讯串口
        /// </summary>
        public SerialPort _Port_hpump
        {
            get { return _port_hpump; }
            set { _port_hpump = value; }
        }

        private int _weight1code;
        /// <summary>
        /// 注射器通讯串口
        /// </summary>
        public int _Weigh1code
        {
            get { return _weight1code; }
            set { _weight1code = value; }
        }

        private int _weight2code;
        /// <summary>
        /// 注射器通讯串口
        /// </summary>
        public int _Weigh2code
        {
            get { return _weight2code; }
            set { _weight2code = value; }
        }
        private int _weight3code;
        /// <summary>
        /// 注射器通讯串口
        /// </summary>
        public int _Weigh3code
        {
            get { return _weight3code; }
            set { _weight3code = value; }
        }

        DataRowView m_dr = null;
        int m_cmdID;
        int m_warnCodeID;
        string m_cmdInfo;
        private string m_Code = string.Empty;
        public frmAdmin()
        {
            InitializeComponent();
        }
 

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 11:
                    ReadWarnCode();
                    break;
            }
        } 

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }

        private void ReadWarnCode()
        {
            ALS.BLL.warncode bw = new BLL.warncode();
            DataSet ds = bw.GetAllShowList();
            this.lstWarnCode.DataSource = ds.Tables[0];
            this.lstWarnCode.DisplayMember = "codecontent";
            this.lstWarnCode.Refresh();
        }

        

        private void lstWarnCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_dr = (DataRowView)lstWarnCode.SelectedItem;
            this.txtReason.Text = m_dr["reason"].ToString();
            this.txtDeal.Text = m_dr["deal"].ToString();
            this.m_Code = m_dr["ID"].ToString();
            m_warnCodeID = (int)m_dr["ID"];
            UpdateCmdsList(m_warnCodeID);

        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        { 
            BLL.warncode bw = new BLL.warncode(); 
            DataRowView dr = (DataRowView)lstWarnCode.SelectedItem;
            int index = lstWarnCode.SelectedIndex;
            Model.warncode mw = bw.GetModel(Convert.ToInt32(dr["ID"].ToString()));
            mw.reason = this.txtReason.Text;
            mw.deal = this.txtDeal.Text;
            if(bw.Update(mw))
            {
                ReadWarnCode();
                lstWarnCode.SelectedIndex = index;
                MessageBox.Show("保存成功!");
            }          
        }

        private void btnBP_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;            
            string tag = b.Tag.ToString().ToLower();
            int warnCodeID = (int)m_dr["ID"];
            Model.warncmds mwcmd = new Model.warncmds();
            BLL.warncmds bwcmd = new BLL.warncmds();
            //查询是否已存在该动作 warnCodeID actionInfo
            if(bwcmd.GetModel(warnCodeID,b.Text)!=null )
            {
                MessageBox.Show("已经存在该动作,无需添加!");
                return;
            }
            mwcmd.actionInfo = b.Text;                      
            mwcmd.warnCodeID = warnCodeID;
            byte[] cmd = null;
            switch(tag)
            {
                case "bplow":
                    cmd = Cls.Comm_PeristalticPump.Command(0x01, 30, true, true);
                    mwcmd.portName = _port_ppump.PortName;  
                    break;
                case "bpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x01, 30, false, true);
                    mwcmd.portName = _port_ppump.PortName;  
                    break;
                case "fpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x02, 30, false, true);
                    mwcmd.portName = _port_ppump.PortName;  
                    break;
                case "dpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x03, 30, false, true);
                    mwcmd.portName = _port_ppump.PortName;  
                    break;
                case "rpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x04, 30, false, true);
                    mwcmd.portName = _port_ppump.PortName;  
                    break;
                case "fp2stop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x05, 30, false, true);
                    mwcmd.portName = _port_ppump.PortName;  
                    break;
                case "cpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x05, 30, false, true);
                    mwcmd.portName = _port_ppump.PortName;  
                    break;
                case "allpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x1f, 30, false, true);
                    mwcmd.portName = _port_ppump.PortName;  
                    break;
                case "v1":
                    cmd = Cls.Comm_Main.CmdValve.ClampV1;
                    mwcmd.portName = _port_main.PortName;  
                    break;
                case "v2":
                    cmd = Cls.Comm_Main.CmdValve.ClampV2;
                    mwcmd.portName = _port_main.PortName;  
                    break;
                case "v3":
                    cmd = Cls.Comm_Main.CmdValve.ClampV3;
                    mwcmd.portName = _port_main.PortName;  
                    break;
                case "v4":
                    cmd = Cls.Comm_Main.CmdValve.ClampV4;
                    mwcmd.portName = _port_main.PortName;  
                    break;
                case "v5":
                    cmd = Cls.Comm_Main.CmdValve.ClampV5;
                    mwcmd.portName = _port_main.PortName;  
                    break;
                case "v6":
                    cmd = Cls.Comm_Main.CmdValve.ClampV6;
                    mwcmd.portName = _port_main.PortName;  
                    break;
                case "htstop":
                    cmd = Cls.Comm_Main.CmdTemperature.StopHT;
                    mwcmd.portName = _port_main.PortName;
                    break;
                case "spstop":
                    cmd = Cls.Comm_SyringePump.Stop;
                    mwcmd.portName = _port_hpump.PortName;
                    break;
                case "redlight":                    
                    cmd = Cls.Comm_Main.CmdAlarmLamp.RedTwinkle;
                    mwcmd.portName = _port_main.PortName;
                    break;
                case "yellowlight":
                    cmd = Cls.Comm_Main.CmdAlarmLamp.YellowTwinkle;
                    mwcmd.portName = _port_main.PortName;
                    break;
                case "alarm1":
                    cmd = Cls.Comm_Main.CmdAlarm.OpenVoice1;
                    mwcmd.portName = _port_main.PortName;
                    break;
                case "alarm2":
                    cmd = Cls.Comm_Main.CmdAlarm.OpenVoice2;
                    mwcmd.portName = _port_main.PortName;
                    break;
                case "closealllight":
                    cmd = Cls.Comm_Main.CmdAlarmLamp.AllLightClose;
                    mwcmd.portName = _port_main.PortName;
                    break;
                case "mute":
                    cmd = Cls.Comm_Main.CmdAlarm.AllVoiceClose;
                    mwcmd.portName = _port_main.PortName;
                    break; 
                case "vall":
                     cmd = Cls.Comm_Main.CmdValve.ClampAllV;
                    mwcmd.portName = _port_main.PortName;
                    break;

            }
            mwcmd.cmd = cmd;
            mwcmd.cmdLength = cmd.Length;
            if (bwcmd.Add(mwcmd))
            {
                //刷新列表
                UpdateCmdsList(warnCodeID);
            }
        }

        private void UpdateCmdsList(int _warnCodeID)
        { 
            BLL.warncmds bw = new BLL.warncmds();
            DataSet ds = bw.GetListShow("warnCodeID='" + _warnCodeID + "'");
            DataTable dt = ds.Tables[0];           
            dt.Columns.Add("序号", System.Type.GetType("System.String")).SetOrdinal(0);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = (i + 1).ToString();
            }
            for (int i = 0; i < this.dgvWarnCmds.Columns.Count; i++)
            {
                this.dgvWarnCmds.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dgvWarnCmds.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            this.dgvWarnCmds.DataSource = dt;
            this.dgvWarnCmds.Columns[1].Visible = false;
            this.dgvWarnCmds.Columns[2].Visible = false;
            this.dgvWarnCmds.Refresh();
        }

        private void dgvWarnCmds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                m_cmdID=Convert.ToInt32( dgvWarnCmds.Rows[e.RowIndex].Cells[1].Value);
                m_warnCodeID =Convert.ToInt32( dgvWarnCmds.Rows[e.RowIndex].Cells[1].Value);
                m_cmdInfo = dgvWarnCmds.Rows[e.RowIndex].Cells[3].Value.ToString();                
            }
        }

        private void btnDelAction_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("确认删除 " + m_cmdInfo + " ？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                BLL.warncmds bllwcmd = new BLL.warncmds();
                if (bllwcmd.Delete(m_cmdID))
                {
                    lstWarnCode_SelectedIndexChanged(lstWarnCode, e);
                    m_cmdID = 0;
                    m_cmdInfo = null;
                }                    
            }
        }

        private void btnSavecode1_0_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string tag = b.Tag.ToString();
            switch(tag)
            {
                case "1-0":
                    Cls.RWconfig.SetAppSettings("1_0kgcode", _weight1code.ToString());
                    break;
                case "1-5":
                    Cls.RWconfig.SetAppSettings("1_5kgcode", _weight1code.ToString());
                    break;
                case "1-10":
                    Cls.RWconfig.SetAppSettings("1_10kgcode", _weight1code.ToString());
                    break;
                case "2-0":
                    Cls.RWconfig.SetAppSettings("2_0kgcode", _weight2code.ToString());
                    break;
                case "2-5":
                    Cls.RWconfig.SetAppSettings("2_5kgcode", _weight2code.ToString());
                    break;
                case "2-10":
                    Cls.RWconfig.SetAppSettings("2_10kgcode", _weight2code.ToString());
                    break;                   
                case "3-0": 
                    Cls.RWconfig.SetAppSettings("3_0kgcode", _weight3code.ToString());
                    break;
                case "3-5":
                    Cls.RWconfig.SetAppSettings("3_5kgcode", _weight3code.ToString());
                    break;
                case "3-10":
                    Cls.RWconfig.SetAppSettings("3_10kgcode", _weight3code.ToString());
                    break;
                case "1-10ca":
                    int code0kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("1_0kgcode"));
                    int code10kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("1_10kgcode"));
                    //一个码值代表多少g
                    double re_1 = Math.Round( 10000.0 /(code10kg - code0kg),6);
                    Cls.RWconfig.SetAppSettings("weigh1_resolution", re_1.ToString());
                    break;
                case "2-10ca":
                    code0kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("2_0kgcode"));
                    code10kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("2_10kgcode"));
                    //一个码值代表多少g
                    double re_2 =Math.Round(  10000.0 / (code10kg - code0kg),6);
                    Cls.RWconfig.SetAppSettings("weigh2_resolution", re_2.ToString());
                    break;
                case "3-10ca":
                    code0kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("3_0kgcode"));
                    code10kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("3_10kgcode"));
                    //一个码值代表多少g
                    double re_3 = Math.Round( 10000.0 / (code10kg - code0kg),6);
                    Cls.RWconfig.SetAppSettings("weigh3_resolution", re_3.ToString());
                    break;
                case "1-5ca":
                    code0kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("1_0kgcode"));
                    double code5kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("1_5kgcode"));
                    //一个码值代表多少g
                    re_1 = Math.Round(10000.0 / (code5kg - code0kg), 6);
                    Cls.RWconfig.SetAppSettings("weigh1_resolution", re_1.ToString());
                    break;
                case "2-5ca":
                    code0kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("2_0kgcode"));
                    code5kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("2_5kgcode"));
                    //一个码值代表多少g
                    re_2 = Math.Round(10000.0 / (code5kg - code0kg), 6);
                    Cls.RWconfig.SetAppSettings("weigh2_resolution", re_2.ToString());
                    break;
                case "3-5ca":
                    code0kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("3_0kgcode"));
                    code5kg = Convert.ToInt32(Cls.RWconfig.GetAppSettings("3_5kgcode"));
                    //一个码值代表多少g
                    re_3 = Math.Round(10000.0 / (code5kg - code0kg), 6);
                    Cls.RWconfig.SetAppSettings("weigh3_resolution", re_3.ToString());
                    break;
            }

        }
    }
}
