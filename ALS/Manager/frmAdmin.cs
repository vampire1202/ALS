using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
namespace ALS.Manager
{
    public partial class frmAdmin : Form
    {
        private SerialPort _port_ppump;
        bool m_isfast = false;
        private double Sp_FastInjection = 0;
        private int count_brand;
        System.Diagnostics.Stopwatch m_watchFast = new System.Diagnostics.Stopwatch();

        List<Cls.Model_SendCMD> m_lstModelSendCMD = new List<Cls.Model_SendCMD>();
        //用来查询治疗数据 2017年2月22日
        BLL.pump_speed_data pum_data = new BLL.pump_speed_data();
        BLL.pressure_data pre_data = new BLL.pressure_data();

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

        private int _weight4code;
        public int _Weight4code
        {
            get { return _weight4code; }
            set { _weight4code = value; }
        }

        private bool _isopenAD1;
        public bool _IsOpenAD1
        {
            get { return _isopenAD1; }
            set { _isopenAD1 = value; }
        }

        private bool _isopenAD2;
        public bool _IsOpenAD2
        {
            get { return _isopenAD2; }
            set { _isopenAD2 = value; }
        }

        private bool _isopenAD3;
        public bool _IsOpenAD3
        {
            get { return _isopenAD3; }
            set { _isopenAD3 = value; }
        }

        private string _method;

        public string _Method
        {
            get { return _method; }
            set { _method = value; }
        }



        private string m_methodAction = string.Empty;
        DataRowView m_dr = null;
        int m_cmdID;
        int m_warnCodeID;
        string m_cmdInfo;
        int []JugeArray=new int[9]{1,2,3,4,5,6,7,14,15};
        private string m_Code = string.Empty;
        BLL.treatmentmode m_btm = new BLL.treatmentmode();
        Model.treatmentmode m_mtm;
        Cls.calsyringepump m_syrdata=new Cls.calsyringepump();
        Model.syringecal m_sySet=new Model.syringecal();
        BLL.syringecal m_syringeset = new BLL.syringecal();
        List<Model.syringecal>lst_SyAllBrands=new List<Model.syringecal>();
        BLL.calibrateweigh m_bcw = new BLL.calibrateweigh();
        Model.calibrateweigh m_mcw;
        double pumpspeedchange = 0;

        public delegate void btnExitEvent(object sender, EventArgs e);
        public event btnExitEvent btnexit;

        public delegate void chVClick(object sender, EventArgs e);
        public event chVClick ch_VClick;

        public delegate void btnRunPump(object sender, EventArgs e);
        public event btnRunPump btn_RunPump;

        public delegate void tsItemClick(object sender, ToolStripItemClickedEventArgs e);
        public event tsItemClick _tsItemClick;

        //砝码满量程标重g
        int int_FullRange = 0;

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
                case 1:
                    ReadSy_Brands();
                    break;
                case 2:
                    //读取上一次标定称重时砝码的标重；
                    //wss 2016年5月27日
                    this.w1_fr.Text = m_mcw.weigh1_10kgcode.Value.ToString();
                    this.w2_fr.Text = m_mcw.weigh2_10kgcode.Value.ToString();
                    this.w3_fr.Text = m_mcw.weigh3_10kgcode.Value.ToString();
                    this.w4_fr.Text = m_mcw.weigh4_10kgcode.Value.ToString();
                    break;
                case 3://声光气泡温控
                    if (_isopenAD1)
                        this.tsBtnAD1.Image = Properties.Resources.AD1;
                    else
                        this.tsBtnAD1.Image = Properties.Resources.AD1Off;

                    if (_isopenAD2)
                        this.tsBtnAD2.Image = Properties.Resources.AD2;
                    else
                        this.tsBtnAD2.Image = Properties.Resources.AD2Off;

                    if (_isopenAD3)
                        this.tsBtnAD3.Image = Properties.Resources.AD3;
                    else
                        this.tsBtnAD3.Image = Properties.Resources.AD3Off;
                    break;
                case 5:
                    ReadWarnCode();
                    break;
                case 7:
                    //初始化图标格式 2017年2月22日
                    Init_Chart();break;
            }
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            ReadSet();
        }

        void ReadSet()
        {
            //泵参数
            m_mtm = m_btm.GetModel("Manage");
            if (m_mtm != null)
            {
                this.txtBP.Text = m_mtm.BPSpeed.Value.ToString("f1"); //Cls.RWconfig.GetAppSettings("BPSpeed");
                this.txtFP.Text = m_mtm.FPSpeed.Value.ToString("f1"); //Cls.RWconfig.GetAppSettings("FPSpeed");
                this.txtDP.Text = m_mtm.DPSpeed.Value.ToString("f1"); //Cls.RWconfig.GetAppSettings("DPSpeed");
                this.txtRP.Text = m_mtm.RPSpeed.Value.ToString("f1");//Cls.RWconfig.GetAppSettings("RPSpeed");
                this.txtCP.Text = m_mtm.CPSpeed.Value.ToString("f1");//Cls.RWconfig.GetAppSettings("CPSpeed");
                this.txtFP2.Text = m_mtm.FP2Speed.Value.ToString("f1");//Cls.RWconfig.GetAppSettings("FP2Speed");
                this.txtDehydrationSpeed.Text = m_mtm.dehydrationSpeed.Value.ToString("f1"); //Cls.RWconfig.GetAppSettings("DryWater");
            } 

            //称重标定参数
            m_mcw = m_bcw.GetModel(1);
            if(m_mcw!=null)
            {
                this.cmbPumpSpeedChange.Text = m_mcw.pumpspeedchange.Value.ToString("f0");
                double pumpspeed = Convert.ToDouble(this.cmbPumpSpeedChange.Text);
                pumpspeedchange = 1 + pumpspeed / 100.0;

            }
        }

        private void ReadSy_Brands()
        {
            BLL.syringecal sybrand = new BLL.syringecal();
            DataSet Sybrand_source = sybrand.GetAllList();
            count_brand = Sybrand_source.Tables[0].Rows.Count - 1;
            Sybrand_source.Tables[0].Columns[0].ColumnName = "序号";
            Sybrand_source.Tables[0].Columns[1].ColumnName = "品牌";
            Sybrand_source.Tables[0].Columns[2].ColumnName = "规格";
            this.dgvSPPara.DataSource = Sybrand_source.Tables[0];
            //for (int i = 0; i < this.dgvWarnCmds.Columns.Count; i++)
            //{
            //    this.dgvSPPara.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //    this.dgvSPPara.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //}
            this.dgvSPPara.Columns[3].Visible = false;
            this.dgvSPPara.Columns[4].Visible = false;
            this.dgvSPPara.Columns[5].Visible = false;
            this.dgvSPPara.Refresh();
                
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
            this.txtSteps.Text = m_dr["dealSteps"].ToString();
            if (m_dr["dealImg"] != null && m_dr["dealImg"].ToString() != "")
            {
                byte[] b = (byte[])m_dr["dealImg"];
                MemoryStream ms = new MemoryStream(b);
                Bitmap bmp = new Bitmap(ms);
                this.picDeal.Image = bmp;
            }
            else
                this.picDeal.Image = null;
            this.m_Code = m_dr["ID"].ToString();
            this.cmbGrade.Text = (string.IsNullOrEmpty(m_dr["grade"].ToString())? "4" : m_dr["grade"].ToString());
            m_warnCodeID = (int)m_dr["ID"];

            UpdateCmdsList(m_warnCodeID);

        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty( this.cmbGrade.Text))
            {
                MessageBox.Show("请选择警报等级!\r\n 1为最高级别");
                    return;
            }
            BLL.warncode bw = new BLL.warncode();
            DataRowView dr = (DataRowView)lstWarnCode.SelectedItem;
            int index = lstWarnCode.SelectedIndex;
            Model.warncode mw = bw.GetModel(Convert.ToInt32(dr["ID"].ToString()));
            mw.reason = this.txtReason.Text;
            mw.deal = this.txtDeal.Text;
            mw.grade = Convert.ToInt16(this.cmbGrade.Text);
            mw.dealSteps = this.txtSteps.Text;
            Bitmap bmp=null;
            if (this.picDeal.Image != null)
            {
                bmp = new Bitmap(this.picDeal.Image);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                mw.dealImg = ms.ToArray();
                if (bw.Update(mw))
                {
                    ReadWarnCode();
                    ms.Close();
                    ms.Dispose();
                    lstWarnCode.SelectedIndex = index;
                    MessageBox.Show("保存成功!");
                }
            }
            else
            {
                //不需要存储图片的报警，image为空；
                mw.dealImg = null;
                if (bw.Update(mw))
                {
                    ReadWarnCode();
                    lstWarnCode.SelectedIndex = index;
                    MessageBox.Show("保存成功!");
                }
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
            //if (bwcmd.GetModel(warnCodeID, b.Text) != null)
            //{
            //    MessageBox.Show("已经存在该动作,无需添加!");
            //    return;
            //}
            mwcmd.actionInfo = b.Text;
            mwcmd.warnCodeID = warnCodeID;
            byte[] cmd = null;
            switch (tag)
            {
                case "bplow":
                    cmd = Cls.Comm_PeristalticPump.Command(0x01, 20, true, true);
                    mwcmd.portName = _port_ppump.PortName;
                    break;
                case "bpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x01, 0, false, true);
                    mwcmd.portName = _port_ppump.PortName;
                    break;
                case "fpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x02, 0, false, true);
                    mwcmd.portName = _port_ppump.PortName;
                    break;
                case "dpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x03, 0, false, true);
                    mwcmd.portName = _port_ppump.PortName;
                    break;
                case "rpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x04, 0, false, true);
                    mwcmd.portName = _port_ppump.PortName;
                    break;
                case "fp2stop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x05, 0, false, true);
                    mwcmd.portName = _port_ppump.PortName;
                    break;
                case "cpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x06, 0, false, true);
                    mwcmd.portName = _port_ppump.PortName;
                    break;
                case "allpstop":
                    cmd = Cls.Comm_PeristalticPump.Command(0x1f, 0, false, true);
                    mwcmd.portName = _port_ppump.PortName;
                    break;
                case "addvstate":
                    StringBuilder sb = new StringBuilder();
                    byte[] vstate = new byte[6];
                 
                    switch(chkV1.CheckState)
                    {
                        case CheckState.Checked: sb.Append("V1夹管,"); vstate[0] = 0x01; break;
                        case CheckState.Indeterminate: sb.Append("V1保持状态,"); vstate[0] = 0x02; break;
                        case CheckState.Unchecked: sb.Append("V1松管,"); vstate[0] = 0x00; break; 
                    }

                    switch (chkV2.CheckState)
                    {
                        case CheckState.Checked: sb.Append("V2夹管,"); vstate[1] = 0x01; break;
                        case CheckState.Indeterminate: sb.Append("V2保持状态,"); vstate[1] = 0x02; break;
                        case CheckState.Unchecked: sb.Append("V2松管,"); vstate[1] = 0x00; break;
                    }

                    switch (chkV3.CheckState)
                    {
                        case CheckState.Checked: sb.Append("V3夹管,"); vstate[2] = 0x01; break;
                        case CheckState.Indeterminate: sb.Append("V3保持状态,"); vstate[2] = 0x02; break;
                        case CheckState.Unchecked: sb.Append("V3松管,"); vstate[2] = 0x00; break;
                    }
                    switch (chkV4.CheckState)
                    {
                        case CheckState.Checked: sb.Append("V4夹管,"); vstate[3] = 0x01; break;
                        case CheckState.Indeterminate: sb.Append("V4保持状态,"); vstate[3] = 0x02; break;
                        case CheckState.Unchecked: sb.Append("V4松管,"); vstate[3] = 0x00; break;
                    }

                    switch (chkV5.CheckState)
                    {
                        case CheckState.Checked: sb.Append("V5夹管,"); vstate[4] = 0x01; break;
                        case CheckState.Indeterminate: sb.Append("V5保持状态,"); vstate[4] = 0x02; break;
                        case CheckState.Unchecked: sb.Append("V5松管,"); vstate[4] = 0x00; break;
                    }

                    switch (chkV6.CheckState)
                    {
                        case CheckState.Checked: sb.Append("V6夹管,"); vstate[5] = 0x01; break;
                        case CheckState.Indeterminate: sb.Append("V6保持状态,"); vstate[5] = 0x02; break;
                        case CheckState.Unchecked: sb.Append("V6松管,"); vstate[5] = 0x00; break;
                    }
                 
                    string info = sb.ToString();

                    if (DialogResult.OK == MessageBox.Show("请确认夹管阀状态是否正确:[" + info + "] ?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        cmd = Cls.Comm_Main.CmdValve.SetVState(vstate[0], vstate[1], vstate[2], vstate[3], vstate[4], vstate[5]);
                        mwcmd.portName = _port_main.PortName;
                        mwcmd.actionInfo =info;
                    }
                    else
                        return;
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
                    cmd = Cls.Comm_Main.CmdAlarmLamp.Alarm1;
                    mwcmd.portName = _port_main.PortName;
                    break;
                case "alarm2":
                    cmd = Cls.Comm_Main.CmdAlarmLamp.Alarm2;
                    mwcmd.portName = _port_main.PortName;
                    break;
                case "closealllight":
                    cmd = Cls.Comm_Main.CmdAlarmLamp.AllLightClose;
                    mwcmd.portName = _port_main.PortName;
                    break;
                case "mute":
                    cmd = Cls.Comm_Main.CmdAlarmLamp.AllVoiseClose;
                    mwcmd.portName = _port_main.PortName;
                    break;
                //case "vall":
                //    cmd = Cls.Comm_Main.CmdValve.ClampAllV;
                //    mwcmd.portName = _port_main.PortName;
                //    break;

            }
            mwcmd.cmd = cmd;
            mwcmd.cmdLength = cmd.Length;
            if (bwcmd.Add(mwcmd))
            {
                //刷新列表序号
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
            if (e.RowIndex != -1)
            {
                m_cmdID = Convert.ToInt32(dgvWarnCmds.Rows[e.RowIndex].Cells[1].Value);
                m_warnCodeID = Convert.ToInt32(dgvWarnCmds.Rows[e.RowIndex].Cells[1].Value);
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
            switch (tag)
            {
                case "1-0":
                    //Cls.RWconfig.SetAppSettings("1_0kgcode", _weight1code.ToString());
                    m_mcw.weigh1_0kgcode = _weight1code;
                    break;
                case "1-5":
                    //Cls.RWconfig.SetAppSettings("1_5kgcode", _weight1code.ToString());
                    m_mcw.weigh1_5kgcode = _weight1code;
                    break;
                //case "1-10":
                //    //Cls.RWconfig.SetAppSettings("1_10kgcode", _weight1code.ToString());
                //    m_mcw.weigh1_10kgcode = _weight1code;
                //    break;
                case "2-0":
                    //Cls.RWconfig.SetAppSettings("2_0kgcode", _weight2code.ToString());
                    m_mcw.weigh2_0kgcode = _weight2code;
                    break;
                case "2-5":
                    //Cls.RWconfig.SetAppSettings("2_5kgcode", _weight2code.ToString());
                    m_mcw.weigh2_5kgcode = _weight2code;
                    break;
                //case "2-10":
                //    //Cls.RWconfig.SetAppSettings("2_10kgcode", _weight2code.ToString());
                //    m_mcw.weigh2_10kgcode = _weight2code;
                //    break;
                case "3-0":
                    //Cls.RWconfig.SetAppSettings("3_0kgcode", _weight3code.ToString());
                    m_mcw.weigh3_0kgcode = _weight3code;
                    break;
                case "3-5":
                    //Cls.RWconfig.SetAppSettings("3_5kgcode", _weight3code.ToString());
                    m_mcw.weigh3_5kgcode = _weight3code;
                    break;
                //case "3-10":
                //    //Cls.RWconfig.SetAppSettings("3_10kgcode", _weight3code.ToString());
                //    m_mcw.weigh3_10kgcode = _weight3code;
                //    break;
                    /***************
                     * 添加秤4码值保存; 
                     * '4-0,4-5,4-10'
                     * wss 2015年12月7日
                    ****************/
                case "4-0":
                    m_mcw.weigh4_0kgcode = _weight4code;
                    break;
                case "4-5":
                    m_mcw.weigh4_5kgcode = _weight4code;
                    break;
                //case "4-10":
                //    m_mcw.weigh4_10kgcode = _weight4code;
                //    break;
                //case "1-10ca":
                //    int code0kg = m_mcw.weigh1_0kgcode.Value;
                //    int code10kg = m_mcw.weigh1_10kgcode.Value;
                //    //一个码值代表多少g
                //    double re_1 = Math.Round(10000.0 / (code10kg - code0kg), 6);
                //    //Cls.RWconfig.SetAppSettings("weigh1_resolution", re_1.ToString());
                //    m_mcw.weigh1_resolution = re_1;
                //    break;
                //case "2-10ca":
                //    code0kg =m_mcw.weigh2_0kgcode.Value; //Convert.ToInt32(Cls.RWconfig.GetAppSettings("2_0kgcode"));
                //    code10kg = m_mcw.weigh2_10kgcode.Value;//Convert.ToInt32(Cls.RWconfig.GetAppSettings("2_10kgcode"));
                //    //一个码值代表多少g
                //    double re_2 = Math.Round(10000.0 / (code10kg - code0kg), 6);
                //    //Cls.RWconfig.SetAppSettings("weigh2_resolution", re_2.ToString());
                //    m_mcw.weigh2_resolution = re_2;
                //    break;
                //case "3-10ca":
                //    code0kg = m_mcw.weigh3_0kgcode.Value;//Convert.ToInt32(Cls.RWconfig.GetAppSettings("3_0kgcode"));
                //    code10kg =m_mcw.weigh3_10kgcode.Value;// Convert.ToInt32(Cls.RWconfig.GetAppSettings("3_10kgcode"));
                //    //一个码值代表多少g
                //    double re_3 = Math.Round(10000.0 / (code10kg - code0kg), 6);
                //    //Cls.RWconfig.SetAppSettings("weigh3_resolution", re_3.ToString());
                //    m_mcw.weigh3_resolution = re_3;
                //    break;
                //    /****************
                //     * 添加秤4 10kg标定值保存
                //     * ‘4-10ca’
                //     * wss 2015年12月7日
                //    *****************/
                //case "4-10ca":
                //    code0kg = m_mcw.weigh4_0kgcode.Value;
                //    code10kg = m_mcw.weigh4_10kgcode.Value;
                //    double re_4 = Math.Round(10000.0 / (code10kg - code0kg), 6);
                //    m_mcw.weigh4_resolution = re_4;
                //    break;
                case "1-5ca":
                    int code0kg = m_mcw.weigh1_0kgcode.Value; //Convert.ToInt32(Cls.RWconfig.GetAppSettings("1_0kgcode"));
                    double code5kg =m_mcw.weigh1_5kgcode.Value;// Convert.ToInt32(Cls.RWconfig.GetAppSettings("1_5kgcode"));
                    //一个码值代表多少g
                    //re_1 = Math.Round(5000.0 / (code5kg - code0kg), 6);
                    double re_1 = Math.Round(int_FullRange/ (code5kg - code0kg), 6);
                    //Cls.RWconfig.SetAppSettings("weigh1_resolution", re_1.ToString());
                    m_mcw.weigh1_resolution = re_1;
                    //保存本次标定称重时使用的砝码标重；
                    m_mcw.weigh1_10kgcode = int_FullRange;
                    break;
                case "2-5ca":
                    code0kg = m_mcw.weigh2_0kgcode.Value;// Convert.ToInt32(Cls.RWconfig.GetAppSettings("2_0kgcode"));
                    code5kg = m_mcw.weigh2_5kgcode.Value;//Convert.ToInt32(Cls.RWconfig.GetAppSettings("2_5kgcode"));
                    //一个码值代表多少g
                    //double re_2 = Math.Round(5000.0 / (code5kg - code0kg), 6);
                    double re_2 = Math.Round(int_FullRange / (code5kg - code0kg), 6);
                    //Cls.RWconfig.SetAppSettings("weigh2_resolution", re_2.ToString());
                    m_mcw.weigh2_resolution = re_2;
                    m_mcw.weigh2_10kgcode = int_FullRange;
                    break;
                case "3-5ca":
                    code0kg = m_mcw.weigh3_0kgcode.Value; // Convert.ToInt32(Cls.RWconfig.GetAppSettings("3_0kgcode"));
                    code5kg = m_mcw.weigh3_5kgcode.Value;// Convert.ToInt32(Cls.RWconfig.GetAppSettings("3_5kgcode"));
                    //一个码值代表多少g
                    //double re_3 = Math.Round(5000.0 / (code5kg - code0kg), 6);
                    double re_3 = Math.Round(int_FullRange / (code5kg - code0kg), 6);
                    //Cls.RWconfig.SetAppSettings("weigh3_resolution", re_3.ToString());
                    m_mcw.weigh3_resolution = re_3;
                    m_mcw.weigh3_10kgcode = int_FullRange;
                    break;
                    /****************
                     * 添加秤4 5kg标定值保存
                     * ‘4-5ca’
                     * wss 2015年12月7日
                    *****************/
                case "4-5ca":
                    code0kg = m_mcw.weigh4_0kgcode.Value;
                    code5kg = m_mcw.weigh4_5kgcode.Value;
                    //一个码值代表多少g
                    //double re_4 = Math.Round(5000.0 / (code5kg - code0kg), 6);
                    double re_4 = Math.Round(int_FullRange/ (code5kg - code0kg), 6);
                    m_mcw.weigh4_resolution = re_4;
                    m_mcw.weigh4_10kgcode = int_FullRange;
                    break;
            } 
            m_bcw.Update(m_mcw); 
        }

        private void btnRun1_Click(object sender, EventArgs e)
        {
            if (btn_RunPump != null)
                btn_RunPump(sender, e);
        }
 
        private void cmbPumpSpeedChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cls.RWconfig.SetAppSettings("PumpSpeedChange", this.cmbPumpSpeedChange.Text); 
            m_mcw.pumpspeedchange = Convert.ToInt32(this.cmbPumpSpeedChange.Text);
            m_bcw.Update(m_mcw);
            double pumpspeed = Convert.ToDouble(this.cmbPumpSpeedChange.Text);
            pumpspeedchange = 1 + pumpspeed / 100.0;
        }

        private void txtBP_Click(object sender, EventArgs e)
        {
            TextBox Txt = (TextBox)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(Txt.Text);

            if (DialogResult.OK == _numPad.ShowDialog())
            {
                if (_numPad.Value < 0 || _numPad.Value > 500)
                {
                    MessageBox.Show("设置超出范围,请重新设置!");
                    return;
                }
                Txt.Text = _numPad.Value.ToString("f1");
                switch(Txt.Tag.ToString())
                {
                    case "1":
                        //Cls.RWconfig.SetAppSettings("BPSpeed", Txt.Text);
                        m_mtm.BPSpeed = _numPad.Value;
                        break;
                    case "2":
                        //Cls.RWconfig.SetAppSettings("FPSpeed", Txt.Text);
                        m_mtm.FPSpeed = _numPad.Value;
                        break;
                    case "3":
                        //Cls.RWconfig.SetAppSettings("DPSpeed", Txt.Text);
                        m_mtm.DPSpeed = _numPad.Value;
                        break;
                    case "4":
                        //Cls.RWconfig.SetAppSettings("RPSpeed", Txt.Text);
                        m_mtm.RPSpeed = _numPad.Value;
                        break;
                    case "5":
                        //Cls.RWconfig.SetAppSettings("FP2Speed", Txt.Text);
                        m_mtm.FP2Speed = _numPad.Value;
                        break;
                    case "6":
                        //Cls.RWconfig.SetAppSettings("CPSpeed", Txt.Text);
                        m_mtm.CPSpeed = _numPad.Value;
                        break;

                }
                //m_btm.Update(m_mtm);
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (btnexit != null)
                btnexit(sender, e);
            //this.Dispose();
        }

        private void label41_Click(object sender, EventArgs e)
        {

        }
        //发送指令准备获取传感器校准参数(进入传感器校准界面)
        private void PotenCal_start(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.PotentialCal_start);
        }
        //参数收集完成(退出传感器校准界面)
        private void PotenCal_stop(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.PotentialCal_stop);
            m_syrdata.CollectData_YN = false;
        }
        //分别获取长短电位器值
        private void Collect_PotnData(object sender, EventArgs e)
        {
            Button Sender = sender as Button;
            //采集数据个数统计
            for (int i = 0; i < 9; i++)
            {
                if (JugeArray[i] == Convert.ToInt32(Sender.Tag))
                {
                    JugeArray[i] = 0;
                    break;
                }
            }

            switch (Convert.ToString(Sender.Tag))
            {
                case "1": this.txtS13.Text = this.lblRealsLen.Text;
                          m_syrdata.Cal_SyPoten[0] = (byte)(Convert.ToInt32(this.lblRealsLen.Text) >> 8 & 0xFF);
                          m_syrdata.Cal_SyPoten[1] = (byte)(Convert.ToInt32(this.lblRealsLen.Text) & 0xFF);break;
                case "2": this.txtS23.Text = this.lblRealsLen.Text;
                          m_syrdata.Cal_SyPoten[2]=(byte)(Convert.ToInt32(this.lblRealsLen.Text)>>8 & 0xFF);
                          m_syrdata.Cal_SyPoten[3]=(byte)(Convert.ToInt32(this.lblRealsLen.Text) & 0xFF);break;
                case "3": this.txtS33.Text = this.lblRealsLen.Text; 
                          m_syrdata.Cal_SyPoten[4]=(byte)(Convert.ToInt32(this.lblRealsLen.Text)>>8 & 0xFF);
                          m_syrdata.Cal_SyPoten[5]=(byte)(Convert.ToInt32(this.lblRealsLen.Text) & 0xFF);break;
                case "4": this.txtL0.Text = this.lblReallLen.Text; 
                          m_syrdata.Cal_SyPoten[6]=(byte)(Convert.ToInt32(this.lblReallLen.Text)>>8 & 0xFF);
                          m_syrdata.Cal_SyPoten[7]=(byte)(Convert.ToInt32(this.lblReallLen.Text) & 0xFF);break;
                case "5": this.txtL50.Text = this.lblReallLen.Text; 
                          m_syrdata.Cal_SyPoten[8]=(byte)(Convert.ToInt32(this.lblReallLen.Text)>>8 & 0xFF);
                          m_syrdata.Cal_SyPoten[9]=(byte)(Convert.ToInt32(this.lblReallLen.Text) & 0xFF);break;
                case "6": this.txtL100.Text = this.lblReallLen.Text; 
                          m_syrdata.Cal_SyPoten[10]=(byte)(Convert.ToInt32(this.lblReallLen.Text)>>8 & 0xFF);
                          m_syrdata.Cal_SyPoten[11]=(byte)(Convert.ToInt32(this.lblReallLen.Text) & 0xFF);break;
                case "7": this.txtP0.Text = this.lblRealP.Text;
                          m_syrdata.Cal_SyPoten[12] = (byte)(Convert.ToInt32(this.txtP0.Text) >> 8 & 0xFF);
                          m_syrdata.Cal_SyPoten[13]=(byte)(Convert.ToInt32(this.txtP0.Text) & 0xFF);break;
                case "14": this.txtP50.Text = this.lblRealP.Text;
                           m_syrdata.Cal_SyPoten[26] = (byte)(Convert.ToInt32(this.txtP50.Text) >> 8 & 0xFF);
                           m_syrdata.Cal_SyPoten[27]=(byte)(Convert.ToInt32(this.txtP50.Text) & 0xFF);break;
                case "15": this.txtP100.Text = this.lblRealP.Text;
                           m_syrdata.Cal_SyPoten[28] = (byte)(Convert.ToInt32(this.txtP100.Text) >> 8 & 0xFF);
                           m_syrdata.Cal_SyPoten[29]=(byte)(Convert.ToInt32(this.txtP100.Text) & 0xFF);break;
                default: break;
            }
        }
        //传感器校准  
        private void PotentialCal_WriteData(object sender, EventArgs e) 
        {
            //未采集数据处理
            for (int i = 14; i < 26; i++)
            {
                m_syrdata.Cal_SyPoten[i] = 0;
            }
            for (int k = 30; k < 34; k++)
            {
                m_syrdata.Cal_SyPoten[k] = 0;
            }
            //数据未采集完全
            //for (int i = 0; i < 9; i++)
            //{
            //    if (JugeArray[i] != 0)
            //    {
            //        MessageBox.Show("数据未采集完成");
            //        return;
            //    }
            //}
            //发送校准参数后，先保存数据然后重启
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.ZeroCal(m_syrdata.Cal_SyPoten));
        }

        //获取注射器校准参数
        private void SyringeCalData_start(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.AutoCal_get);
            m_syrdata.CollectSyDta_YN = true;
            this.txtSPDia.Text=this.lblRealsLen.Text;
            this.txtSPFinishPos.Text=this.lblReallLen.Text;
        }
        //注射器校准参数获取停止
        private void SyringeCalData_stop(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(_port_hpump,Cls.Comm_SyringePump.AutoCal_Stop);
            m_syrdata.CollectSyDta_YN = false;
        }
        //注射器参数校准
        private void SyringeCalData_set(object sender, EventArgs e)
        {
            Cls.calsyringepump calsyring = new Cls.calsyringepump();
            int sy_cal;
            int sy_comp;
            int sy_len;
            sy_cal=(int)(Convert.ToDouble(this.txtSPDia.Text));
            sy_comp=(int)(Convert.ToDouble(this.txtSPFinishPos.Text));
            sy_len = (int)(Convert.ToDouble(this.txtSPLen.Text)* 100);
            calsyring.Cal_SyThirty[0] = 0x04;
            calsyring.Cal_SyThirty[1] = (byte)((Convert.ToByte(sy_cal >> 8)) & 0xFF);
            calsyring.Cal_SyThirty[2] = (byte)(Convert.ToByte(sy_cal & 0xFF));
            calsyring.Cal_SyThirty[3] = (byte)((Convert.ToByte(sy_len >> 8)) & 0xFF);
            calsyring.Cal_SyThirty[4] = (byte)(Convert.ToByte(sy_len & 0xFF));
            calsyring.Cal_SyThirty[5] = (byte)((Convert.ToByte(sy_comp >> 8)) & 0xFF);
            calsyring.Cal_SyThirty[6] = (byte)(Convert.ToByte(sy_comp & 0xFF));
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.AutoCal_set(calsyring.Cal_SyThirty));
        }
        
        //注射器管径、完成距离获取
        private void SyData(object sender, EventArgs e)
        {
            Button Sender = sender as Button;
            switch (Sender.Tag.ToString())
            {
                case "2": this.txtSPDia.Text=this.lblRealsLen.Text; break;
                case "4": this.txtSPFinishPos.Text=this.lblReallLen.Text; break;
                default: break;
            }
        }
        //识别注射器规格 未使用
        private void Recognize_SyVersion(object sender, EventArgs e)
        {
            Cls.calsyringepump.Rec_SyVersion = false;
            this.btnRun.Enabled = true;
            Cls.utils.SendOrder(_port_hpump,Cls.Comm_SyringePump.Recog_SyVersion);
        }
        //设置注射泵速度
        private void lblSpeed_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            _numPad.btnDot.Visible = false;
            _numPad.btnNegPos.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                double val = _numPad.Value;
                if (val >= 0 && val <= 1500.0)
                {
                    lbl.Text = val.ToString("f1");
                    m_mtm.SP_Speed = val;
                    new BLL.treatmentmode().Update(m_mtm);
                }
                else
                    MessageBox.Show("请将速度设置在 0 - 1500 mL/h 之间!");
            }
        }
        //设置快进注射量
        private void lblRapidInjection_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                double val = _numPad.Value;
                lbl.Text = val.ToString("f1");
                //Cls.RWconfig.SetAppSettings("SP_RapidInjectionValue", val.ToString("f1"));
                Sp_FastInjection = val;
            }
        }
        //微量注射泵运行
        private void btnRun_Click(object sender, EventArgs e)
        {
            //判断是否设置泵速 2017年2月15日
            double spvalue = Math.Round((double.Parse(this.lblSpeed.Text)), 1);
            if (spvalue < 1)
            {
                MessageBox.Show("请重新设置泵速");
                return;
            }
            this.btnStop.Enabled = true;
            this.btnFastRun.Enabled = true;
            this.btnRun.Enabled = false;
            double yuzhiValue = 50;
            if (m_mtm.IsTargetSP)
                yuzhiValue = Convert.ToDouble(m_mtm.TargetSP);
            //Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Start(Convert.ToDouble(this.lblSpeed.Text), yuzhiValue));
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Start(Convert.ToDouble(this.lblSpeed.Text), yuzhiValue));
        }
        //微量注射泵停止运行
        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnFastRun.Enabled = false;
            this.btnStop.Enabled = false;
            this.btnRun.Enabled = true;
            this.btnFastStop.Enabled = false;
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Stop);
        }
        //微量注射泵快送
        private void btnFastRun_Click(object sender, EventArgs e)
        {
            this.btnFastRun.Enabled = false;
            this.btnFastStop.Enabled = true;
            double spfast = Sp_FastInjection;
            //double spfast = m_mtm.SP_RapidInjectionValue.Value;// Convert.ToDouble(Cls.RWconfig.GetAppSettings("SP_RapidInjectionValue"));
            //快进速度设定为 1200mL/h 即 1200/3600=0.333 mL/s;  
            //假如快进量设为 5mL,需要时间为 : 5/0.333 = 15s 
            double spendt = Math.Round(spfast / 0.333333, 3) * 1000.0;//表示所需ms;
            //开始计时
            Thread threadfast = new Thread(new ParameterizedThreadStart(RunSPFast));
            threadfast.IsBackground = true;
            m_isfast = true;
            threadfast.Start(spendt);
        }
        //微量注射泵 快送停止
        private void btnFastStop_Click(object sender, EventArgs e)
        {
            this.btnFastStop.Enabled = false;
            this.btnFastRun.Enabled = true;
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.EndFastForward);
        }
        void RunSPFast(object o)
        {
            double spendtime = (double)o;
            m_watchFast.Start();
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.FastForward(1200.0));
            while (m_isfast)
            {
                Thread.Sleep(100);
                if (m_watchFast.ElapsedMilliseconds >= spendtime)
                {
                    Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.EndFastForward);
                    m_watchFast.Reset();
                    m_watchFast.Stop();
                    m_isfast = false;
                    //BeginInvoke(new Action(() =>
                    //{
                    //    this.btnFastStopSP.Enabled = false;
                    //    this.btnFastRunSP.Enabled = true;
                    //}));
                }
            }
        }
        private void SaveSyringe_data(object sender, EventArgs e)
        {
            //注射器名字 管径 完成距离 长度 为null
            if (string.IsNullOrEmpty(this.txtSPName.Text) == true||string.IsNullOrEmpty(this.txtSPFinishPos.Text)==true
                ||string.IsNullOrEmpty(this.txtSPDia.Text)==true||string.IsNullOrEmpty(this.txtSPLen.Text)==true)
            {
                MessageBox.Show("注射器参数不完整！！！");
                return;
            }
            //规格未设置
            if (this.cmbSPLen.SelectedIndex < 0)
            {
                MessageBox.Show("请选择注射器规格！");
                return;
            }
            //更新一条数据  品牌 规格 管径 长度 完成距离
            switch (this.cmbSPLen.SelectedIndex)
            {
                case 0: m_sySet.version = 20; break;
                case 1: m_sySet.version = 30; break;
                case 2: m_sySet.version = 50; break;
                default: break;

            }
            m_sySet.brand = this.txtSPName.Text;
            m_sySet.calibre = Convert.ToInt32(this.txtSPDia.Text);
            m_sySet.compdis = Convert.ToInt32(this.txtSPFinishPos.Text);
            m_sySet.length = Convert.ToInt32(this.txtSPLen.Text);

            //判断表中是否已经存在该数据，不存在则，存入
            if (!m_syringeset.Exists(m_sySet.ID, m_sySet.brand,m_sySet.version))
            {
                m_syringeset.Add(m_sySet);
            }
            count_brand++;
            BLL.syringecal sybrand = new BLL.syringecal();
            //DataSet Sybrand_Newsource = sybrand.GetList("syringecalID='" + "count_brand'");
            DataSet ds_Sybrand_Newsource = sybrand.GetAllList();
            //DataTable Sybrand_NewsourceT = Sybrand_Newsource.Tables[0];

            ds_Sybrand_Newsource.Tables[0].Columns[0].ColumnName = "序号";
            ds_Sybrand_Newsource.Tables[0].Columns[1].ColumnName = "品牌";
            ds_Sybrand_Newsource.Tables[0].Columns[2].ColumnName = "规格";
            this.dgvSPPara.DataSource = ds_Sybrand_Newsource.Tables[0];
            this.dgvSPPara.Columns[3].Visible = false;
            this.dgvSPPara.Columns[4].Visible = false;
            this.dgvSPPara.Columns[5].Visible = false;
            this.dgvSPPara.Refresh(); 
        }

        private void AutoBrandset(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.SetBrand_Autoset);          
        }

        private void btnCloseAllV_Click(object sender, EventArgs e)
        {
            chkV1.CheckState = chkV2.CheckState = chkV3.CheckState = chkV4.CheckState = chkV5.CheckState = chkV6.CheckState = CheckState.Checked;
            chkV1.Image = chkV2.Image = chkV3.Image = chkV4.Image = chkV5.Image = chkV6.Image = global::ALS.Properties.Resources.clipclose;
        }

        private void btnOpenAllV_Click(object sender, EventArgs e)
        {
            chkV1.CheckState = chkV2.CheckState = chkV3.CheckState = chkV4.CheckState = chkV5.CheckState = chkV6.CheckState = CheckState.Unchecked;
            chkV1.Image = chkV2.Image = chkV3.Image = chkV4.Image = chkV5.Image = chkV6.Image = global::ALS.Properties.Resources.clipopen;
        }

        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Dispose();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "LogFile"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "LogFile");
            string fileName = AppDomain.CurrentDomain.BaseDirectory +"LogFile\\"+ DateTime.Now.ToString("yyyyMMddHHmmss") + "_datalog.txt";
            //File.WriteAllText(fileName, this.rtBoxData.Text, Encoding.Default);
            using(StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (string s in this.rtBoxData.Lines)
                {
                    sw.WriteLine(s);
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            MessageBox.Show("保存日志到 " + fileName + " 成功!");
        }

        private void txtP0_Click(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            UserCtrl.numPad np = new UserCtrl.numPad(tbx.Text);
            if(DialogResult.OK==np.ShowDialog())
                tbx.Text = np.Value.ToString();
            //更改数据后同时调用获取textbox里面的值  2017年2月17日
            if ((Convert.ToString(tbx.Tag)) == "7")
            {
                Collect_PotnData(this.btnGetP0, e);
            }
            if ((Convert.ToString(tbx.Tag)) == "14")
            {
                Collect_PotnData(this.btnGetP50, e);
            }
            if ((Convert.ToString(tbx.Tag)) == "15")
            {
                Collect_PotnData(this.btnGetP100, e);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Label tb = sender as Label;
            UserCtrl.numPad np = new UserCtrl.numPad();
            np.btnNegPos.Visible = false;
            np.btnDot.Visible = false;
            if (DialogResult.OK == np.ShowDialog())
                tb.Text = np.Value.ToString();
            //保存砝码标重；
            int_FullRange = Convert.ToInt32(tb.Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(图片文件)|*.jpg;*.png;*.gif;*.bmp";
            if(DialogResult.OK == ofd.ShowDialog())
            {
                Bitmap b = new Bitmap(ofd.FileName);   
                MemoryStream ms = new MemoryStream();
                b.Save(ms, System.Drawing.Imaging.ImageFormat.Png); 
                this.picDeal.Image = Image.FromStream(ms); 
                ms.Dispose();
            }
        }

        private void chV1_Click(object sender, EventArgs e)
        {
            if (ch_VClick != null)
                ch_VClick(sender, e);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn.Tag!=null)
            {
                string tag = btn.Tag.ToString();
                switch(tag)
                {
                    case "closevoise":
                        Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdAlarmLamp.AllVoiseClose); 
                        break;
                    case "closelight":
                        Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose); 
                        break;
                    case "alarm1":
                        Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdAlarmLamp.Alarm1);
                        break;
                    case "alarm2":
                        Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdAlarmLamp.Alarm2);
                        break;
                    case "redtwinkle":
                        Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdAlarmLamp.RedTwinkle);
                        break;
                    case "greentwinkle":
                        Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdAlarmLamp.GreenTwinkle);
                        break;
                    case "yellowtwinkle":
                        Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdAlarmLamp.YellowTwinkle);
                        break;
                    case "greenalways":
                        Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdAlarmLamp.GreenAlways);
                        break;

                }
            }
        }

        private void chkV1_Click(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            switch (cb.CheckState)
            {
                case CheckState.Checked:
                    cb.Image = global::ALS.Properties.Resources.clipclose;
                    break;
                case CheckState.Indeterminate:
                    cb.Image = global::ALS.Properties.Resources.clipkeep;
                    break;
                case CheckState.Unchecked:
                    cb.Image = global::ALS.Properties.Resources.clipopen;
                    break;
            } 
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (_tsItemClick != null)
                _tsItemClick(sender, e);
        }

        private void btnFlush_Click(object sender, EventArgs e)
        {
            switch (_method)
            {
                case "PE":
                    m_methodAction = "PE_Flush";
                    break;
                case "PP":
                    m_methodAction = "PP_Flush";
                    break;
                case "PERT":
                    m_methodAction = "PERT_Flush";
                    break;
                case "CHDF":
                    m_methodAction = "CHDF_Flush";
                    break;
                case "PDF":
                    m_methodAction = "PDF_Flush";
                    break;
                case "Li-ALS":
                    m_methodAction = "Li-ALS_Flush";
                    break;
            }
            //显示自动化操作界面
            frmCustomAction fca = new frmCustomAction(m_methodAction);
            fca.Port_Main = _port_main;
            fca.Port_Pump = _port_ppump;
            fca.ShowDialog();
        }

        private void btnTreat_Click(object sender, EventArgs e)
        {
            switch (_method)
            {
                case "PE":
                    m_methodAction = "PE_Treat";
                    break;
                case "PP":
                    m_methodAction = "PP_Treat";
                    break;
                case "HP":
                    m_methodAction = "HP_Treat";
                    break;
                case "CHDF":
                    m_methodAction = "CHDF_Treat";
                    break;
                case "PDF":
                    m_methodAction = "PDF_Treat";
                    break;
                case "PERT":
                    m_methodAction = "PERT_Treat";
                    break;
                //case "Manual":
                //    m_methodAction = "Manual_Recycle";
                //break;
                case "Li-ALS":
                    m_methodAction = "Li-ALS_Treat";
                    break;
            }
            //显示自动化操作界面
            frmCustomAction fca = new frmCustomAction(m_methodAction);
            fca.Port_Main = _port_main;
            fca.Port_Pump = _port_ppump;
            fca.ShowDialog();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            switch (_method)
            {
                case "PE":
                    m_methodAction = "PE_Recycle";
                    break;
                case "PP":
                    m_methodAction = "PP_Recycle";
                    break;
                case "PERT":
                    m_methodAction = "PERT_Recycle";
                    break;
                case "CHDF":
                    m_methodAction = "CHDF_Recycle";
                    break;
                case "PDF":
                    m_methodAction = "PDF_Recycle";
                    break;
                //case "Manual":
                //    m_methodAction = "Manual_Recycle";
                //break;
                case "Li-ALS":
                    m_methodAction = "Li-ALS_Recycle";
                    break;
            }
            //显示自动化操作界面
            frmCustomAction fca = new frmCustomAction(m_methodAction);
            fca.Port_Main = _port_main;
            fca.Port_Pump = _port_ppump;
            fca.ShowDialog();
        }

        private void Init_Chart()
        {
            //清空上次操作；
            //this.c3_heat.Series.Clear();
            //this.c1_pre.Series.Clear();
            //this.c2_acc.Series.Clear();


            //BLL.pressure_data prd = new BLL.pressure_data();
            //prd.GetList();
        }


        /*
         输入患者号，查询出该患者所有治疗数据
         2017年2月22日
         */
        private void chck_surgery_no_click(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            UserCtrl.numPad np = new UserCtrl.numPad(tb.Text);
            if (DialogResult.OK == np.ShowDialog())
            {
                tb.Text = np.Value.ToString();
                //根据患者编号进行数据库查询
                DataSet ds_surgery = pum_data.GetList(tb.Text.ToString());
                int n = ds_surgery.Tables[0].Rows.Count;
                if (n>1)
                {
                    //this.cb_sudata.DataSource = ds_surgery.Tables[0].Columns[1];
                    int num = ds_surgery.Tables[0].Rows.Count;
                    //遍历表格给combox赋值
                    for (int i = 1; i < num; i++)
                    {
                        this.cb_sudata.Items.Add(ds_surgery.Tables[0].Rows[i][1].ToString());
                    }
                    //获取查询结果
                    List<Model.pump_speed_data> mp = pum_data.GetModelList(tb.Text.ToString());
                    //存储时间数据
                    List<double > data_xtime = new List<double>();
                    //存储温度值数据
                    List<double> data_xwarmer = new List<double>();
                    
                    //遍历查询结果，存储时间&温度值数据
                    foreach (Model.pump_speed_data psd in mp)
                    {
                        DateTime dt = (Convert.ToDateTime(psd.time_stamp));
                        //dt = new DateTime(dt.Hour, dt.Minute, dt.Second);
                        string ds = dt.ToShortTimeString();
                        //时间轴只显示时分
                        double dts = (DateTime.Parse(ds)).ToOADate();
                        data_xtime.Add(dts);
                        data_xwarmer.Add(Convert.ToDouble((psd.warmer)));
                        //MessageBox.Show("时间:" + dt.ToString() + "  温度："+ psd.warmer);
                    }
                    MessageBox.Show(data_xtime.Count.ToString());
                    //设置时间轴的最大最小值
                    this.c3_heat.ChartAreas[0].AxisX.Maximum = data_xtime.Max();
                    this.c3_heat.ChartAreas[0].AxisX.Minimum = data_xtime.Min();
                    //设置时间轴步长
                    this.c3_heat.ChartAreas[0].AxisX.Interval = (data_xtime.Max() - data_xtime.Min()) / 5;
                    this.c3_heat.Series[0].Points.DataBindXY(data_xtime, data_xwarmer);
                    MessageBox.Show(this.c3_heat.Series[0].Points.Count.ToString());

                }
                else
                { 
                    MessageBox.Show("查询为空");
                    return;
                }             
            }           
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //所要选择的时间
            DateTime check_for = this.dtimep.Value;
            //获得查询日期
            string check_data = check_for.ToShortDateString();            
            //获取列表 图2&图3
            DataSet date1_all = pum_data.GetList("");
            
            //查询为空时返回
            if(date1_all.Tables[0].Rows.Count<2)
            {
                MessageBox.Show("数据库(pump_speed_data)无数据存储！");
                return;
            }
            //存储时间数据
            List<double> data_xtime = new List<double>();
            //存储温度值数据 图表3
            List<double> data_xwarmer = new List<double>();
            //累计值存储  图表2
            List<double> data_totalbp = new List<double>();
            List<double> data_totaldp = new List<double>();
            List<double> data_totalsp = new List<double>();
            List<double> data_totalfp = new List<double>();
            List<double> data_totalrp = new List<double>();         

            //遍历查询结果，存储时间&温度值数据
            for (int i = 1; i < date1_all.Tables[0].Rows.Count;i++ )
                //foreach (Model.pump_speed_data psd in mp)
                {
                    //获取当前行的年月日
                    DateTime dt = (Convert.ToDateTime(date1_all.Tables[0].Rows[i][1]));
                    //判断获取数据日期是否与查询日期一致
                    if (dt.Date == check_for.Date)
                    {

                        string ds = dt.ToShortTimeString();
                        //时间轴只显示时分
                        double dts = (DateTime.Parse(ds)).ToOADate();
                        data_xtime.Add(dts);
                        data_xwarmer.Add(Convert.ToDouble((date1_all.Tables[0].Rows[i][10])));
                        data_totalbp.Add(Convert.ToDouble((date1_all.Tables[0].Rows[i][11])));
                        data_totaldp.Add(Convert.ToDouble((date1_all.Tables[0].Rows[i][13])));
                        data_totalsp.Add(Convert.ToDouble((date1_all.Tables[0].Rows[i][17])));
                        data_totalfp.Add(Convert.ToDouble((date1_all.Tables[0].Rows[i][12])));
                        data_totalrp.Add(Convert.ToDouble((date1_all.Tables[0].Rows[i][14])));
                    }
                }
            //有查询结果时，进行图表显示
            //无查询结果时，进行提示
            if (data_xtime.Count > 0)
            {
                //设置时间轴的最大最小值
                this.c3_heat.ChartAreas[0].AxisX.Maximum = data_xtime.Max();
                this.c3_heat.ChartAreas[0].AxisX.Minimum = data_xtime.Min();
                this.c2_acc.ChartAreas[0].AxisX.Maximum = data_xtime.Max();
                this.c2_acc.ChartAreas[0].AxisX.Minimum = data_xtime.Min();
                //设置时间轴步长
                this.c3_heat.ChartAreas[0].AxisX.Interval = (data_xtime.Max() - data_xtime.Min()) / 5;
                this.c3_heat.Series[0].Points.DataBindXY(data_xtime, data_xwarmer);
                this.c2_acc.ChartAreas[0].AxisX.Interval = (data_xtime.Max() - data_xtime.Min()) / 5;
                this.c2_acc.Series[0].Points.DataBindXY(data_xtime, data_totalbp);
                this.c2_acc.Series[1].Points.DataBindXY(data_xtime, data_totaldp);
                this.c2_acc.Series[2].Points.DataBindXY(data_xtime, data_totalrp);
                this.c2_acc.Series[3].Points.DataBindXY(data_xtime, data_totalfp);
                this.c2_acc.Series[4].Points.DataBindXY(data_xtime, data_totalsp);

                //this.c3_heat.ChartAreas[0].AxisY.LineDashStyle=

                //处理压力数据
                show_pre_data();
            }
            else
            {
                MessageBox.Show("当前查询日期数据库(pump_speed_data)无治疗数据！");
                //return;
            }
        }
        private void show_pre_data()
        {
            //所要选择的时间
            DateTime check_for = this.dtimep.Value;
            //获得年月日
            string check_data = check_for.ToShortDateString();
            //获取列表 图1
            DataSet date2_all = pre_data.GetList("");
            //查询为空时返回
            if (date2_all.Tables[0].Rows.Count < 1)
            {
                MessageBox.Show("数据库(pressure_data)无数据存储！");
                return;
            }
            //存储时间数据
            List<double> data_xtime = new List<double>();
            //压力值存储 图表1
            List<double> data_pacc = new List<double>();
            List<double> data_part = new List<double>();
            List<double> data_pven = new List<double>();
            List<double> data_p1st = new List<double>();
            List<double> data_p2nd = new List<double>();
            List<double> data_p3rd = new List<double>();
            List<double> data_tmp = new List<double>();
            //遍历查询结果，存储时间&温度值数据
            for (int i = 1; i < date2_all.Tables[0].Rows.Count; i++)
            //foreach (Model.pump_speed_data psd in mp)
            {
                //System.Data.Entity.DbFunctions.DiffDays(cs.StartTime.Value,DateTime.Now) == 0
                DateTime dt = (Convert.ToDateTime(date2_all.Tables[0].Rows[i][1]));
                //DateTime dt = (Convert.ToDateTime(psd.time_stamp));
                if (dt.Date == check_for.Date)
                {

                    string ds = dt.ToShortTimeString();
                    //时间轴只显示时分
                    double dts = (DateTime.Parse(ds)).ToOADate();
                    data_xtime.Add(dts);
                    data_pacc.Add(Convert.ToDouble(date2_all.Tables[0].Rows[i][2]));
                    data_part.Add(Convert.ToDouble(date2_all.Tables[0].Rows[i][4]));
                    data_pven.Add(Convert.ToDouble(date2_all.Tables[0].Rows[i][5]));
                    data_p1st.Add(Convert.ToDouble(date2_all.Tables[0].Rows[i][3]));
                    data_p2nd.Add(Convert.ToDouble(date2_all.Tables[0].Rows[i][6]));
                    data_p3rd.Add(Convert.ToDouble(date2_all.Tables[0].Rows[i][8]));
                    data_tmp.Add(Convert.ToDouble(date2_all.Tables[0].Rows[i][7]));
                }
            }
            if (data_xtime.Count > 0)
            {
                //设置时间轴的最大最小值
                this.c1_pre.ChartAreas[0].AxisX.Maximum = data_xtime.Max();
                this.c1_pre.ChartAreas[0].AxisX.Minimum = data_xtime.Min();
                //设置时间轴步长
                this.c1_pre.ChartAreas[0].AxisX.Interval = (data_xtime.Max() - data_xtime.Min()) / 5;
                this.c1_pre.Series[0].Points.DataBindXY(data_xtime, data_pacc);
                this.c1_pre.Series[1].Points.DataBindXY(data_xtime, data_part);
                this.c1_pre.Series[2].Points.DataBindXY(data_xtime, data_pven);
                this.c1_pre.Series[3].Points.DataBindXY(data_xtime, data_p1st);
                this.c1_pre.Series[4].Points.DataBindXY(data_xtime, data_tmp);
                this.c1_pre.Series[5].Points.DataBindXY(data_xtime, data_p2nd);
                this.c1_pre.Series[6].Points.DataBindXY(data_xtime, data_p3rd);
            }
            else
            {
                MessageBox.Show("当前查询日期数据库(pressure_data)无数据存储");
                return;
            }
            // Zoom into the X axis
            //this.c1_pre.ChartAreas[0].AxisX.ScaleView.Zoom(2, 3);

            //// Enable range selection and zooming end user interface
            //this.c1_pre.ChartAreas[0].CursorX.IsUserEnabled = true;
            //this.c1_pre.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //this.c1_pre.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            ////将滚动内嵌到坐标轴中
            //this.c1_pre.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            //// 设置滚动条的大小"Default"
            //this.c1_pre.ChartAreas[0].AxisX.ScrollBar.Size = 10;

            //// 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来"Default"
            //this.c1_pre.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.All;

            ////System.Windows.Forms.DataVisualization.Charting.ScrollBarButtonStyles.
            //// 设置自动放大与缩小的最小量"Default"
            //this.c1_pre.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            //this.c1_pre.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 2;




            //this.c1_pre.ChartAreas[0].CursorX.AutoScroll = true;
            //this.c1_pre.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            //this.c1_pre.ChartAreas[0].CursorX.IsUserEnabled = true;
            //this.c1_pre.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            ////this.c1_pre.ChartAreas[0].AxisX.Interval = _isopenAD1;
            //this.c1_pre.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            //this.c1_pre.ChartAreas[0].AxisX.ScaleView.Position = 0;
            //this.c1_pre.ChartAreas[0].AxisX.ScaleView.Size = (data_xtime.Max() - data_xtime.Min()) / 5;

        }

        private void c1_cb1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            int int_tag = Convert.ToInt32(cb.Tag);
            bool bl_checkstate=false;
            if(cb.Checked == true)
            {
                bl_checkstate = true;
                this.c1_pre.Series[int_tag].BorderWidth = 1;
            }
            else if(cb.Checked == false)
            {
                bl_checkstate = false;
                this.c1_pre.Series[int_tag].BorderWidth = 0;
            }
        }

        private void c2_cb1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            int int_tag = Convert.ToInt32(cb.Tag);
            bool bl_checkstate = false;
            if (cb.Checked == true)
            {
                bl_checkstate = true;
                this.c2_acc.Series[int_tag].BorderWidth = 1;
            }
            else if (cb.Checked == false)
            {
                bl_checkstate = false;
                this.c2_acc.Series[int_tag].BorderWidth = 0;
            }
        }
        
    }
}
