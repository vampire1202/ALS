//#define LOG_WARNING
#undef LOG_WARNING                        //报警log


//#define LOG_SP_DATARECEIVE
#undef LOG_SPDATA_SPRECEIVE               //肝素泵数据接收log

//#define LOG_MAINPORT_DATARECEIVE
#undef LOG_MAINPORT_DATARECEIVE           //COM1数据接收log

//#define LOG_SYSTEM
#undef  LOG_SYSTEM                      //软件启动log

//#define LOG_PUMP
#undef LOG_PUMP                           //蠕动泵log

//#define LOG_WEIGH
#undef  LOG_WEIGH                         //称重log

//#define LOG_TREAT
#undef LOG_TREAT                          //治疗log

//define RunT
#undef RunT

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks; 
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;
using AeroWizard;
using System.Management;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Json;

namespace ALS
{
    public partial class frmMain : Form
    {
        //------------------------------------------
        //             各子窗体定义                |
        //------------------------------------------  
        
        FormOperation.ucPipeLine pipeLine = new FormOperation.ucPipeLine();
        FormOperation.ucAutoFlush M_uc_AutoFlush = new FormOperation.ucAutoFlush();
        FormOperation.ucSelectFlush M_uc_selFlush = new FormOperation.ucSelectFlush();
        FormSet.ucSetFlow M_uc_SetFlow = new FormSet.ucSetFlow();                         //设置流量窗体        
        //FormOperation.ucMethod M_uc_Method = new FormOperation.ucMethod();                    //治疗方法选择界面        
        FormOperation.ucTreat M_uc_Treat = new FormOperation.ucTreat();                    //治疗界面       
        FormOperation.ucRecycle M_uc_Recycle = new FormOperation.ucRecycle();                  //回收界面       
        FormSet.ucSetOther M_uc_OtherSet = new FormSet.ucSetOther();                       //其他设置界面    
        FormSet.ucSetSum M_uc_Sum = new FormSet.ucSetSum();                             //累计值界面         
        FormSet.ucSetLiquidSurface M_uc_SetLiquidSurface = new FormSet.ucSetLiquidSurface();
        frmShowWarn m_ucWarnInfo = new frmShowWarn();
        frmDealWarn m_frmDealWarn = new frmDealWarn();                                     //报警处理框
        Manager.frmAdmin m_frmAdmin = null;
        frmExit m_frmExit = new frmExit();
        DateTime dtPreCircle;
        FormOperation.step_PE m_stepPE;// = new FormOperation.step_PE();
        FormOperation.step_LiAlS m_stepLiALS;// = new FormOperation.step_LiAlS();
        FormOperation.step_CHDF m_stepCHDF;// = new FormOperation.step_CHDF();
        FormOperation.step_PP m_stepPP;// = new FormOperation.step_PP();
        FormOperation.step_PERT m_stepPERT;// = new FormOperation.step_PERT();
        FormOperation.step_PDF m_stepPDF;// = new FormOperation.step_PDF();
        //------------------------------------------
        //             串口相关变量                |
        //------------------------------------------

        private SerialPort port_main;

        public SerialPort Port_main
        {
            get { return port_main; }
            set { port_main = value; }
        }
        private SerialPort port_data;

        public SerialPort Port_data
        {
            get { return port_data; }
            set { port_data = value; }
        }
        private SerialPort port_hpump;

        public SerialPort Port_hpump
        {
            get { return port_hpump; }
            set { port_hpump = value; }
        }
        private SerialPort port_ppump;

        public SerialPort Port_ppump
        {
            get { return port_ppump; }
            set { port_ppump = value; }
        }
        //预载数据库报警编码与内容
        List<Cls.Model_ShowWarn> m_lstShowWarn;

        public List<Cls.Model_ShowWarn> LstShowWarn
        {
            get { return m_lstShowWarn; }
            set { m_lstShowWarn = value; }
        }

        //选择治疗方法(模式)
        string M_modeName = string.Empty;

        public string _ModeName
        {
            get { return M_modeName; }
            set { M_modeName = value; }
        }

        //治疗模式参数
        Model.treatmentmode M_ModelTreat;
        //private SerialPort port_pumpstatus = new SerialPort();
        bool M_Closing_hpump = false;
        bool M_Listening_hpump = false;
        bool M_Closing_main = false;
        bool M_Listening_main = false;
        bool M_Closing_data = false;
        bool M_Listening_data = false;
        //bool M_Closing_pumpstatus = false;
        //bool M_Listening_pumpstatus = false;
        //bool M_Closing_ppump = false;
        //bool M_Listening_ppump = false;
        bool m_ispreCircle = false;
        string m_strStartEnd = string.Empty;
        //自动预冲参数
        Cls.Model_State m_AutoFlushPumpState = new Cls.Model_State();
        bool m_isExistActions = false;
        //自动化操作步骤列表，包括具体时间点里的动作列表
        Queue<Cls.Model_CustomCMD> m_queueCustSendCmd = new Queue<Cls.Model_CustomCMD>();
        List<ALS.Model.customactions> m_lstCust = new List<Model.customactions>();
        List<Cls.Model_SendCMD> m_lstActionCmd;
        private Task m_taskCustomAction;
        private Task m_taskChildActions;
        private CancellationTokenSource m_ctsCustomAction;
        //计时器
        Stopwatch m_watchFlush = new Stopwatch();
        Stopwatch m_watchAddFlush = new Stopwatch();
        bool M_pauseFlush;
        bool m_isAddFlush = false;
        int M_int_FlushCount;
        int m_tCountAddFlush;
        string m_AutoFlushName = string.Empty;
        double m_flushBPTotal, m_flushDPTotal, m_flushRPTotal = 0;

        StringBuilder M_strb_ppump = new StringBuilder();
        List<byte> M_buffer_ppump = new List<byte>();
        StringBuilder M_strb_hpump = new StringBuilder();
        List<byte> M_buffer_hpump = new List<byte>();
        StringBuilder M_strb_main = new StringBuilder();
        List<byte> M_buffer_main = new List<byte>();
        List<byte> M_buffer_data = new List<byte>();

        List<byte> M_buffer_pumpstatus = new List<byte>();

        byte[] M_buffer_pumpstatusTmp = new byte[] { 0x01, 0x01, 0x01, 0x01, 0x01, 0x01 };

        //int buffcount;
        bool M_SendSuccess = false;//命令是否发送成功
        bool M_SendSuccessPump = false;
        uint crc;

        //是否启动
        bool M_isStart = false;


        //Model.treatmentmode M_ModelTreatDefault;
        //系统启动后，采集数据端口 计数
        int m_portdataCount = 0;
        //实时值模型
        Cls.Model_Value M_ModelValue = new Cls.Model_Value();
        //累计值模型
        Cls.Model_Total M_ModelTotal = new Cls.Model_Total();
        //实时电压
        Cls.calsyringepump M_cls_sy = new Cls.calsyringepump();
        //电压码值
        int M_realVCode = int.MaxValue;
        //实时称重值List
        List<double> M_lstWeigh1 = new List<double>();
        List<double> M_lstWeigh2 = new List<double>();
        List<double> M_lstWeigh3 = new List<double>();
        List<double> M_lstWeigh4 = new List<double>();
        List<double> M_lstRealV = new List<double>();
        List<double> M_lstBloodLeak = new List<double>();
        //采血压List
        List<double> M_lstPacc = new List<double>();

        //需要发送命令读取的数据
        List<Cls.Model_SendCMD> m_lstSend = new List<Cls.Model_SendCMD>();

        //------------------------------------------
        //                 治疗相关                |
        //------------------------------------------
        //是否已经选择预冲方式
        int M_SelFlushType = 0;
        //是否正进行治疗
        bool M_isTreat = false;
        //管路是否安装完成
        bool M_bl_isFinishPipeline = false;
        //是否完成预冲
        bool M_bl_isFinishFlush = false;
        //是否完成治疗
        bool M_bl_isFinishTreat = false;
        //治疗时间累积
        List<int> M_lst_TreatCount = new List<int>();
        int M_int_TreatCount = 0;
        int M_int_TreatCountSum = 0;
        //是否打开漏血报警 
        bool m_isOpenBloodleak = false;
        //是否打开气泡报警123
        bool m_isOpenAD1 = false;
        bool m_isOpenAD2 = false;
        bool m_isOpenAD3 = false;

        //是否已经称重清零
        bool m_isZeroWeigh = false;
        DateTime m_dtMonitor;
        //分离泵在治疗时的时间计数
        Stopwatch m_watchFPRuning = new Stopwatch();
        //警报2min静音周期计时
        Stopwatch m_watchUnreleaseWarn = new Stopwatch();

        //脱水量
        double dryLilun;
        //脱水偏差值
        double dryDeviation;
        double dryDeviationSum;
        List<Cls.Model_Balance> m_lstBalance = new List<Cls.Model_Balance>();
        Cls.Model_Balance m_BalanceSum = new Cls.Model_Balance();
        int m_voidspan = 500;
        //保存数据标志量
        int m_circleNum = 0;
        //泵状态
        Cls.Model_State M_PumpState = new Cls.Model_State();
        //是否正在预冲
        bool M_isFlush = false;
        //splash窗口错误提示
        bool M_isError = false;
        //启动日志
        List<Cls.utils.sysStartLog> M_lst_startLog = new List<Cls.utils.sysStartLog>();
        //警报的动作任务
        private Task m_taskSendWarn;
        private CancellationTokenSource m_ctsSendWarn = new CancellationTokenSource();
        //解除警报任务
        private Task m_taskReleaseWarn;
        private CancellationTokenSource m_ctsReleaseWarn = new CancellationTokenSource();
        //启动泵任务 
        private Task m_taskStartPump;
        private CancellationTokenSource m_ctsStartPump = new CancellationTokenSource();
        //启动监测任务
        private Task m_taskStartMonitor;
        private CancellationTokenSource m_ctsMonitor = new CancellationTokenSource();
        //启动系统
        private Task m_taskReadValue;
        private CancellationTokenSource m_ctsReadValue = new CancellationTokenSource();
        private CancellationTokenSource m_ctsFastSP = new CancellationTokenSource();

        //警报编码
        private string m_warnCode = string.Empty;
        //是否存在报警
        private bool M_exsitsWarn = false;
        //记录点击处理 报警 的所处行
        int Dwarn_RIndex = 0;
        //达到累计值标志
        bool m_isUptoBP = false, m_isUptoDP = false, m_isUptoFP = false, m_isUptoRP = false, m_isUptoTime = false, m_isUptoSP = false;
        bool m_isCutElec = true;
        //抗凝泵是否已提示接近完成
        private bool Sp_NearCom = false;
        //泵秤平衡处用
        private bool DoPumpBalance = false;
        //当前步骤
        int m_currentStep = 0;

        //------------------------------------------
        //               秤标定参数                |
        //------------------------------------------
        int weigh1_code;
        int weigh2_code;
        int weigh3_code;
        int weigh4_code;
        int weigh1_0kgcode;
        int weigh2_0kgcode;
        int weigh3_0kgcode;
        int weigh4_0kgcode;
        int weigh1_5kgcode;
        int weigh2_5kgcode;
        int weigh3_5kgcode;
        int weigh4_5kgcode;
        double weigh1_resolution;
        double weigh2_resolution;
        double weigh3_resolution;
        double weigh4_resolution;
        //称重初始值
        double weigh1_startvalue;
        double weigh2_startvalue;
        double weigh3_startvalue;
        double weigh4_startvalue;
        double m_realweigh1;
        double m_realweigh2;
        int m_wrongweigh2count = 0;
        double m_realweigh3;
        int m_wrongweigh3count = 0;
        double m_realweigh4;
        //是否处于泵秤平衡状态
        bool m_bl_Balance = false;

        //------------------------------------------
        //            log              |
        //------------------------------------------
        //wss
        LogClass getLog = new LogClass();
        List<string> lst_com4data = new List<string>();

        //------------------------------------------
        //            压力折线图参数               |
        //------------------------------------------
        //wss
        //private Random random = new Random();
        //DateTime Curve_Start;
        //旋钮运动方向存储器
        List<byte> m_lstCircleDirection = new List<byte>();
        //当前的警报列表
        List<Cls.clsSysWarn> m_lstSysWarn = new List<Cls.clsSysWarn>();
        //报警是否解除标志
        bool m_isReleaseWarn = true;
        List<Cls.Model_SendCMD> m_lstWarnActions = new List<Cls.Model_SendCMD>();
        Cls.Model_Total m_TotalPE = new Cls.Model_Total();

        //引血速度
        int m_leadBloodSpeed = 0;
        //自动预冲预冲量变量
        double startWeigh2, dRequireFlush;
        Cls.Model_PatientInfo m_PatientInfo;
        public frmMain()
        {
            this.Hide();
            InitializeComponent();
        }

        public void DoStartProgress()
        {
            var progress = new Progress<Cls.StatusProgress>();
            progress.ProgressChanged += progress_ProgressChanged;
            Task t = LoadSystem(progress);
        }

        void progress_ProgressChanged(object sender, Cls.StatusProgress e)
        {
            //更新UI
            if (e.Success == false)
            { 
                m_fp.lblTip.Visible = true;
                Application.Exit();
                Application.ExitThread();
            }
            m_fp.lblTip.Text = e.Tipinfo;
            m_fp.progressBar1.Value = e.Current;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            DoStartProgress();
            //初始化病人信息

            //数据格式END:{“alarmPerson”:”13073863816”,”description":"肝癌","doctor":"kk",
            //“doctorId":"jj","endTime":0,"id":0,"lastAlarm":0,"patient":"zz","patientId":"mm"
            //,”startTime”:0,"state":0,"surgeryNo":"19920327","type":"PE"}
            string type = string.Empty;
            if (M_modeName == "PERT") type = "PEF";
            else
                type = M_modeName;
            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            m_PatientInfo = new Cls.Model_PatientInfo()
            {
                Type = type,
                SurgeryNo = DateTime.Now.ToString("yyMMddHHmmss"),
                StartTime = (epoch * 1000 + DateTime.Now.Millisecond).ToString()
            };
            
            //序列化            
            m_strStartEnd = SJson(m_PatientInfo);
            Cls.utils.AddText("START:" + m_strStartEnd);
            tsbtnPipeline_Click(this.tsbtnPipeline, e);
            toolStripControl_ItemClicked(this.tsbtnPipeline, new ToolStripItemClickedEventArgs(this.tsbtnPipeline));
        }

        private string SJson(Cls.Model_PatientInfo mp)
        {
            //序列化
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Cls.Model_PatientInfo));
            MemoryStream msObj = new MemoryStream();
            //将序列化之后的Json格式数据写入流中
            js.WriteObject(msObj, mp);
            msObj.Position = 0;
            //从0这个位置开始读取流中的数据
            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string rel = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            return rel;
        }

        private string SJsonData(Cls.Model_TransData td)
        {
            //序列化
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Cls.Model_TransData));
            MemoryStream msObj = new MemoryStream();
            //将序列化之后的Json格式数据写入流中
            js.WriteObject(msObj, td);
            msObj.Position = 0;
            //从0这个位置开始读取流中的数据
            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string rel = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            return rel;
        }


        //启动Splash
        frmProgress m_fp = new frmProgress();
        async Task LoadSystem(IProgress<Cls.StatusProgress> progress)
        {
            m_fp.Show();
            m_fp.TopMost = true;
            m_fp.Visible = false;
            int total = 100;
            await Task.Delay(50);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "···", Current = 10, Total = total, Success = true });
            await Task.Delay(50);

            InitUI(M_modeName);

            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 40, Total = total, Success = true });
            await Task.Delay(50);
            ReadSet(M_ModelTreat);
            //读取称重参数
            LoadWeighPara();
            await Task.Delay(50);

            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 70, Total = total, Success = true });

            //主控COM1    波特率19200 数据位8 停止位1 偶校验
            //注射泵COM2  波特率19200 数据位8 停止位1 无校验
            //蠕动COM3    波特率1200 数据位8 停止位1 偶校验
            //称重COM4    波特率9600 数据位8 停止位1 无校验
            //温控COM5    波特率9600 数据位8 停止位1 无校验
            //先发送端口1的启动操作
            //---------------------------------------------------------------------------------------
            //M_portMainReader = new Cls.ReadMainComm.CommReader(port_main, 100);
            //M_portMainReader.Handlers += new Cls.ReadMainComm.CommReader.HandleCommData(portMainReader_Handlers);
            //M_portMainReader.Start();
            //---------------------------------------------------------------------------------------

            //读取数据库，预载警报信息及命令
            await Task.Delay(50);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 90, Total = total, Success = true });
            m_fp.Hide();

            this.Show();
            this.Activate();
            this.MaximizedBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;

            port_main.DataReceived += port_main_DataReceived;
            SendOrderToPortMain();
            port_hpump.DataReceived += port_hpump_DataReceived;
            port_data.DataReceived += port_data_DataReceived;
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 100, Total = total, Success = true });
            await Task.Delay(50);
            StartTransData();
        }

        public static double GetCPUTemperature()
        {
            ManagementObjectSearcher searcher =
                            new ManagementObjectSearcher("root\\WMI",
                                             "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            ManagementObjectCollection.ManagementObjectEnumerator enumerator =
                searcher.Get().GetEnumerator();
            int raw = 0;
            while (enumerator.MoveNext())
            {
                ManagementBaseObject tempObject = enumerator.Current;

                raw = Convert.ToInt32(tempObject["CurrentTemperature"].ToString());
            }
            return (raw / 10) - 273.15;
        }

        //void port_pumpstatus_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    Thread.Sleep(100);
        //    if (M_Closing_pumpstatus) return;
        //    try
        //    {
        //        M_Listening_pumpstatus = true;
        //        int n = this.port_pumpstatus.BytesToRead;
        //        byte[] buf = new byte[n];                   //声明一个临时数组存储当前来的串口数据 
        //        port_pumpstatus.Read(buf, 0, n);                  //读取缓冲数据              
        //        M_buffer_pumpstatus.AddRange(buf);
        //        //-------------------------------串口数据处理流程---------------------------------
        //        //1、读取缓存区数据到一个byte[]数组；
        //        //2、按字节找帧头,若不是所需要的帧头则去掉该字节；
        //        //3、找到帧头后，进行校验，校验通过则处理数据；
        //        //4、处理数据(包含更新界面)完成之后,删除该条命令；继续缓存区下一条命令的处理；
        //        //-------------------------------------------------------------------------------- 
        //        while (M_buffer_main.Count >= 11)
        //        { 
        //            //FF B2 06 XX(蠕动泵1) XX（2） XX（3） XX（4） XX（5） XX（6） JY ED
        //            //FF B2 06 11 00 00 00 00 00 5A ED 开盖为00 闭盖为11 
        //            if (M_buffer_main[0] == 0xFF)
        //            {
        //                int len = M_buffer_main[2]; 
        //                if (checkOut(M_buffer_main))
        //                {
        //                    //实时与现在的泵状态比较，如果有改变再动作。
        //                    //动作机制：当血泵运行时盖开，所有泵停止；当血泵运行时，其他泵盖开，其他泵停止，血泵保持运转；
        //                    /********************
        //                    if (M_buffer_pumpstatus[3] == 0x00)
        //                    {
        //                        //开盖 且 血泵运转中，所有泵停止
        //                        if (M_PumpState.BPState.Runing)
        //                        {
        //                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (M_buffer_pumpstatus[4] == 0x00 || M_buffer_pumpstatus[5] == 0x00 || M_buffer_pumpstatus[6] == 0x00 ||
        //                            M_buffer_pumpstatus[7] == 0x00 || M_buffer_pumpstatus[8] == 0x00)
        //                        {
        //                            //停止后面的泵
        //                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
        //                            if (M_PumpState.BPState.Runing)
        //                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_PumpState.BPState.Speed, true,true));
        //                        }
        //                    }
        //                    ******************/ 

        //                    M_buffer_pumpstatus.RemoveRange(0, 11);
        //                }
        //                else
        //                    M_buffer_pumpstatus.RemoveRange(0, 11);
        //            }
        //            else
        //            {
        //                //如果数据开始不是FF，则删除数据  
        //                M_buffer_data.RemoveAt(0);
        //                //M_buffer_pumpstatus.RemoveRange(0, M_buffer_pumpstatus.Count);
        //            }
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(this, ee.Message.ToString());
        //        M_Listening_pumpstatus = false;
        //    }
        //    finally
        //    {
        //        M_Listening_pumpstatus = false;
        //    }
        //    //throw new NotImplementedException();
        //}

        Model.treatmentmode GetTreatmentModel(string modeName)
        {
            BLL.treatmentmode bllt = new BLL.treatmentmode();
            M_ModelTreat = bllt.GetModel(modeName);
            ShowTreatSet(M_ModelTreat);
            return M_ModelTreat;
        }

        public void ShowTreatSet(Model.treatmentmode _modeTreat)
        {
            this.uc_pacc._Lower = M_ModelTreat.PaccLower.ToString();
            this.uc_pacc._Upper = M_ModelTreat.PaccUpper.ToString();
            this.uc_part._Lower = M_ModelTreat.PartLower.ToString();
            this.uc_part._Upper = M_ModelTreat.PartUpper.ToString();
            this.uc_pven._Lower = M_ModelTreat.PvenLower.ToString();
            this.uc_pven._Upper = M_ModelTreat.PvenUpper.ToString();
            this.uc_p1st._Lower = M_ModelTreat.P1stLower.ToString();
            this.uc_p1st._Upper = M_ModelTreat.P1stUpper.ToString();
            this.uc_p2nd._Lower = M_ModelTreat.P2ndLower.ToString();
            this.uc_p2nd._Upper = M_ModelTreat.P2ndUpper.ToString();
            this.uc_p3rd._Lower = M_ModelTreat.P3rdLower.ToString();
            this.uc_p3rd._Upper = M_ModelTreat.P3rdUpper.ToString();
            this.uc_ptmp._Lower = M_ModelTreat.TmpLower.ToString();
            this.uc_ptmp._Upper = M_ModelTreat.TmpUpper.ToString();
            this.tsbtnSP.Text = M_ModelTreat.SP_Speed.Value.ToString("f1") + " mL/h";

            this.uc_pacc.colorSliderBar1._Value1 = _modeTreat.PaccLower.Value;
            this.uc_pacc.colorSliderBar1._Min = -500;// _modeTreat.PaccLower.Value - 100;
            //this.uc_pacc.colorSliderBar1.lblMin.Text = this.uc_pacc.colorSliderBar1._Min.ToString();
            this.uc_pacc.colorSliderBar1._Value2 = _modeTreat.PaccUpper.Value;
            this.uc_pacc.colorSliderBar1._Max = 500;// _modeTreat.PaccUpper.Value + 100;
            //this.uc_pacc.colorSliderBar1.lblMax.Text = this.uc_pacc.colorSliderBar1._Max.ToString(); 

            this.uc_part.colorSliderBar1._Min = -500;//_modeTreat.PartLower.Value - 100;
            //this.uc_part.colorSliderBar1.lblMin.Text = this.uc_part.colorSliderBar1._Min.ToString();
            this.uc_part.colorSliderBar1._Max = 500;//_modeTreat.PartUpper.Value + 100;
            //this.uc_part.colorSliderBar1.lblMax.Text = this.uc_part.colorSliderBar1._Max.ToString();
            this.uc_part.colorSliderBar1._Value1 = _modeTreat.PartLower.Value;
            this.uc_part.colorSliderBar1._Value2 = _modeTreat.PartUpper.Value;

            this.uc_ptmp.colorSliderBar1._Min = -500;//_modeTreat.TmpLower.Value - 100;
            //this.uc_ptmp.colorSliderBar1.lblMin.Text = this.uc_ptmp.colorSliderBar1._Min.ToString();
            this.uc_ptmp.colorSliderBar1._Max = 500;//_modeTreat.TmpUpper.Value + 100;
            //this.uc_ptmp.colorSliderBar1.lblMax.Text = this.uc_ptmp.colorSliderBar1._Max.ToString();
            this.uc_ptmp.colorSliderBar1._Value1 = _modeTreat.TmpLower.Value;
            this.uc_ptmp.colorSliderBar1._Value2 = _modeTreat.TmpUpper.Value;

            this.uc_pven.colorSliderBar1._Min = -500;//_modeTreat.PvenLower.Value - 100;
            //this.uc_pven.colorSliderBar1.lblMin.Text = this.uc_pven.colorSliderBar1._Min.ToString();
            this.uc_pven.colorSliderBar1._Max = 500;//_modeTreat.PvenUpper.Value + 100;
            //this.uc_pven.colorSliderBar1.lblMax.Text = this.uc_pven.colorSliderBar1._Max.ToString();
            this.uc_pven.colorSliderBar1._Value1 = _modeTreat.PvenLower.Value;
            this.uc_pven.colorSliderBar1._Value2 = _modeTreat.PvenUpper.Value;

            this.uc_p1st.colorSliderBar1._Min = -500;//_modeTreat.P1stLower.Value - 100;
            //this.uc_p1st.colorSliderBar1.lblMin.Text = this.uc_p1st.colorSliderBar1._Min.ToString();
            this.uc_p1st.colorSliderBar1._Max = 500;//_modeTreat.P1stUpper.Value + 100;
            //this.uc_p1st.colorSliderBar1.lblMax.Text = this.uc_p1st.colorSliderBar1._Max.ToString();
            this.uc_p1st.colorSliderBar1._Value1 = _modeTreat.P1stLower.Value;
            this.uc_p1st.colorSliderBar1._Value2 = _modeTreat.P1stUpper.Value;

            this.uc_p2nd.colorSliderBar1._Min = -500;//_modeTreat.P2ndLower.Value - 100;
            //this.uc_p2nd.colorSliderBar1.lblMin.Text = this.uc_p2nd.colorSliderBar1._Min.ToString();
            this.uc_p2nd.colorSliderBar1._Max = 500;//_modeTreat.P2ndUpper.Value + 100;
            //this.uc_p2nd.colorSliderBar1.lblMax.Text = this.uc_p2nd.colorSliderBar1._Max.ToString();
            this.uc_p2nd.colorSliderBar1._Value1 = _modeTreat.P2ndLower.Value;
            this.uc_p2nd.colorSliderBar1._Value2 = _modeTreat.P2ndUpper.Value;

            this.uc_p3rd.colorSliderBar1._Min = -500;// _modeTreat.P3rdLower.Value - 100;
            //this.uc_p3rd.colorSliderBar1.lblMin.Text = this.uc_p3rd.colorSliderBar1._Min.ToString();
            this.uc_p3rd.colorSliderBar1._Max = 500;//_modeTreat.P3rdUpper.Value + 100;
            //this.uc_p3rd.colorSliderBar1.lblMax.Text = this.uc_p3rd.colorSliderBar1._Max.ToString();
            this.uc_p3rd.colorSliderBar1._Value1 = _modeTreat.P3rdLower.Value;
            this.uc_p3rd.colorSliderBar1._Value2 = _modeTreat.P3rdUpper.Value;

            this.uc_pacc.colorSliderBar1._Value1 = _modeTreat.PaccLower.Value;
            this.uc_pacc.colorSliderBar1._Min = -500;// _modeTreat.PaccLower.Value - 100;
            //this.uc_pacc.colorSliderBar1.lblMin.Text = this.uc_pacc.colorSliderBar1._Min.ToString();
            this.uc_pacc.colorSliderBar1._Value2 = _modeTreat.PaccUpper.Value;
            this.uc_pacc.colorSliderBar1._Max = 500;// _modeTreat.PaccUpper.Value + 100;
            //this.uc_pacc.colorSliderBar1.lblMax.Text = this.uc_pacc.colorSliderBar1._Max.ToString();
            //漏血状态
            if (_modeTreat.BloodLeak == 0)
                this.tslblBloodLeak.Image = ALS.Properties.Resources.ldoff;
            else
                this.tslblBloodLeak.Image = ALS.Properties.Resources.ldon;
        }

        void InitUI(string _modeName)
        {
            if (_modeName == "PERT")
                this.lblMethod.Text = "( PEF )";
            else
                this.lblMethod.Text = "( " + _modeName + " )";
            if (_modeName == "Li-ALS")
                this.uc_SpeedDP._Title = "返浆泵(DP)";
            GetTreatmentModel(_modeName);
            //pipeLine = new FormOperation.ucPipeLine();
            pipeLine._PortPump = port_ppump;
            pipeLine.M_int_CurrentIndex = 0;
            pipeLine._btnNextClicked += M_uc_Pipeline_btnNextClicked;

            M_uc_AutoFlush.btnReturnSelEvent += afCustom_btnReturnSelEvent;
            M_uc_AutoFlush.btnEndFlush += afCustom_btnEndFlush;
            M_uc_AutoFlush.btnStartFlush += M_uc_AutoFlush_btnStartFlush;
            M_uc_AutoFlush._btnStartAddFlush += M_uc_AutoFlush__btnAddFlush;
            M_uc_AutoFlush._btnPauseFlush += M_uc_AutoFlush__btnPauseFlush;
            M_uc_AutoFlush._dgvCellClick += M_uc_AutoFlush__dgvCellClick;

            M_uc_selFlush._btnSelAutoFlush += M_uc_selFlush__btnSelAutoFlush;
            M_uc_selFlush._btnSelManualFlush += M_uc_selFlush__btnSelManualFlush;

            M_uc_SetFlow._Port_main = port_main;
            M_uc_SetFlow.btnRun_Pump += M_uc_SetFlow_btnRun_Pump;
            M_uc_SetFlow.btnReadset += M_uc_SetFlow_btnReadset;
            //M_uc_SetFlow.btnChange_bp += M_uc_SetFlow_btnChange_bp;
            M_uc_SetFlow.btnReturnSelect += M_uc_SetFlow_btnReturnSelect;
            M_uc_SetFlow.btnClickFinish += M_uc_SetFlow_btnClickFinish;
            M_uc_SetFlow.checkVClick += M_uc_SetFlow_checkVClick;
            M_uc_Treat._Port_ppump = this.port_ppump;
            M_uc_Treat.ZeroTuoshui += M_uc_Treat_ZeroTuoShuiClick;
            M_uc_Treat.checkBalance += M_uc_Treat_checkBalance;
            M_uc_Treat._lblChangeDrySpeed += M_uc_Treat__lblChangeDrySpeed;

            //wss 4051-4054
            //M_uc_Treat.btnCheshowback += Check_back;
            //M_uc_Treat.btnCheshowtime += Check_show;
            //M_uc_Treat.btnChkSeries += Check_Series1;
            M_uc_Recycle._Port_main = port_main;
            M_uc_Recycle._Port_ppump = port_ppump;
            M_uc_Recycle.recyle_btnCloseAll += M_uc_Recycle_recyle_btnCloseAll;
            M_uc_Recycle.recycle_btnRunBP += M_uc_Recycle_recycle_btnRunBP;
            M_uc_Recycle.checkVClick += M_uc_SetFlow_checkVClick;

            M_uc_OtherSet._Port_main = port_main;
            M_uc_OtherSet._Port_hpump = port_hpump;
            M_uc_OtherSet.btnZeroWs += M_uc_OtherSet_btnZeroWs;
            M_uc_OtherSet.Sp_NearAccumulation += M_uc_OtherSet_Sp_NearAccumulation;
            M_uc_OtherSet.btnZeroTotalSp += M_uc_OtherSet_btnZeroTotalSp;
            M_uc_OtherSet.checkVClick += M_uc_SetFlow_checkVClick;
            M_uc_OtherSet._btnRunSP += M_uc_OtherSet__btnRunSP;
            M_uc_OtherSet._btnRunFastSP += M_uc_OtherSet__btnRunFastSP;
            M_uc_OtherSet._btn_StopFastSP += M_uc_OtherSet__btn_StopFastSP;
            M_uc_OtherSet.btnSaveSet += M_uc_OtherSet_btnSaveSet;
            M_uc_OtherSet._ChangeSpSPeed += M_uc_OtherSet__ChangeSpSPeed;

            M_uc_Sum.btnZeroSum += M_uc_Sum_btnZeroClick;
            M_uc_SetLiquidSurface._Port_main = port_main;
            M_uc_SetLiquidSurface.chkClicked += M_uc_SetLiquidSurface_chkClicked;
            m_ucWarnInfo.ucWarnInfo1._btnMute += m_ucWarnInfo__btnMute;
            m_ucWarnInfo.ucWarnInfo1._btnRelease += m_ucWarnInfo__btnRelease;
            m_ucWarnInfo.ucWarnInfo1._btnDealwarn += m_ucWarnInfo1__btnDealwarn;
            m_ucWarnInfo.ucWarnInfo1._btn_deleteLowW += m_ucWarnInfo_btn_deleteLowW;

            //报警处理框事件
            m_frmDealWarn._btnClose += m_frmDealWarn_btnClose;
            m_frmDealWarn._btnChkV += M_uc_SetFlow_checkVClick;
            m_frmDealWarn._hPort = port_hpump;
            m_frmDealWarn._mPort = port_main;
            m_frmDealWarn._btnstartsp += M_uc_OtherSet__btnRunSP;

            switch (_modeName)
            {
                case "Li-ALS":
                    //注册事件
                    m_stepLiALS = new FormOperation.step_LiAlS();
                    m_stepLiALS.Enabled = false;
                    m_stepLiALS._btnsLiAlsWizard += m_stepLiALS__btnsLiAlsWizard;
                    m_stepLiALS._StartRecycle += tsbtnRecycle_Click;
                    m_stepLiALS._SelectStepChanged += m_stepLiALS__SelectStepChanged;
                    m_stepLiALS._SPSet += m_stepCHDF__SpSet;
                    break;
                case "PERT":
                    //注册向导事件
                    m_stepPERT = new FormOperation.step_PERT();
                    m_stepPERT.Enabled = false;
                    m_stepPERT._PERTSteps += m_stepPERT_PERTSteps;
                    m_stepPERT._StartRecycle += tsbtnRecycle_Click;
                    m_stepPERT._SelectStepChanged += m_stepPERT__SelectStepChanged;
                    m_stepPERT._SPSet += m_stepCHDF__SpSet;
                    break;
                case "PDF":
                    //PDF
                    m_stepPDF = new FormOperation.step_PDF();
                    m_stepPDF.Enabled = false;
                    m_stepPDF._StartRecycle += tsbtnRecycle_Click;
                    m_stepPDF._PDFSteps += m_stepPDF__PDFSteps;
                    m_stepPDF._SelectStepChanged += m_stepPDF__SelectStepChanged;
                    m_stepPDF._SPSet += m_stepCHDF__SpSet;
                    break;
                case "PE":
                    //注册事件 
                    m_stepPE = new FormOperation.step_PE();
                    m_stepPE.Enabled = false;
                    m_stepPE._StartRecycle += tsbtnRecycle_Click;
                    m_stepPE._PESteps += m_stepPE__PESteps;
                    m_stepPE._SelectStepChanged += m_stepPE__SelectStepChanged;
                    m_stepPE._SPSet += m_stepCHDF__SpSet;
                    break;
                case "PP":
                    m_stepPP = new FormOperation.step_PP();
                    m_stepPP.Enabled = false;
                    m_stepPP._StartRecycle += tsbtnRecycle_Click;
                    m_stepPP._PPSteps += m_stepPP__PPSteps;
                    m_stepPP._SelectStepChanged += m_stepPP__SelectStepChanged;
                    m_stepPP._SPSet += m_stepCHDF__SpSet;
                    break;
                case "CHDF":
                    //注册事件 
                    m_stepCHDF = new FormOperation.step_CHDF();
                    m_stepCHDF.Enabled = false;
                    m_stepCHDF._StartRecycle += tsbtnRecycle_Click;
                    m_stepCHDF._CHDFSteps += m_stepCHDF__CHDFSteps;
                    m_stepCHDF._SelectStepChanged += m_stepCHDF__SelectStepChanged;
                    m_stepCHDF._SpSet += m_stepCHDF__SpSet;
                    break;
            }
        }

        void M_uc_OtherSet__ChangeSpSPeed(object sender, EventArgs e)
        {
            //读取SP速度
            this.tsbtnSP.Text = M_ModelTreat.SP_Speed.Value.ToString("0.0") + " mL/h";
            //throw new NotImplementedException();
        }

        void M_uc_OtherSet_btnSaveSet(object sender, EventArgs e)
        {
            GetTreatmentModel(M_modeName);
            //throw new NotImplementedException();
        }

        void M_uc_AutoFlush__dgvCellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < M_uc_AutoFlush.dgvStep.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)M_uc_AutoFlush.dgvStep.Rows[i].Cells["selAdd"];
                checkBox.Value = 0;
                M_uc_AutoFlush.dgvStep.Rows[i].Selected = false;
            }
            if (e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)M_uc_AutoFlush.dgvStep.Rows[e.RowIndex].Cells["selAdd"];
                checkBox.Value = 1;
                M_uc_AutoFlush.dgvStep.Rows[e.RowIndex].Selected = true;
                //读取该步骤的信息，如时间；
                //m_tCountAddFlush = (int)m_lstCust[e.RowIndex].timeSpan;
                m_tCountAddFlush = Convert.ToInt32(M_uc_AutoFlush.dgvStep.CurrentRow.Cells["timespan"].Value.ToString());
                //时间检测
                m_watchAddFlush.Reset();
                M_uc_AutoFlush.lblFullTime.Text = Cls.utils.SecondsToTime(m_tCountAddFlush);
            }
            //throw new NotImplementedException();
        }

        void M_uc_AutoFlush__btnPauseFlush(object sender, EventArgs e)
        {
            M_pauseFlush = !M_pauseFlush;
            if (M_pauseFlush)
            {
                SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                M_uc_AutoFlush.btnContinue.Text = "继续冲洗";
                M_uc_AutoFlush.btnFinish.Enabled = true;
                m_watchFlush.Stop();
            }
            else
            {
                M_uc_AutoFlush.btnContinue.Text = "暂停";
                M_uc_AutoFlush.btnFinish.Enabled = false;
                //NewTask
                Task t = ResumeFlush();
            }
            //throw new NotImplementedException();
        }

        async Task ResumeFlush()
        {
            await Task.Delay(100).ConfigureAwait(false);
            //打开加热 
            //Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdTemperature.StartHT((byte)_modelSet.TargetT));
            //夹管阀状态
            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(m_AutoFlushPumpState.VState[0], m_AutoFlushPumpState.VState[1],
                m_AutoFlushPumpState.VState[2], m_AutoFlushPumpState.VState[3], m_AutoFlushPumpState.VState[4], m_AutoFlushPumpState.VState[5]));
            //夹管阀状态
            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(m_AutoFlushPumpState.VState[0], m_AutoFlushPumpState.VState[1],
                m_AutoFlushPumpState.VState[2], m_AutoFlushPumpState.VState[3], m_AutoFlushPumpState.VState[4], m_AutoFlushPumpState.VState[5]));
            if (m_AutoFlushPumpState.BPState.Runing)
                SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, m_AutoFlushPumpState.BPState.Speed, m_AutoFlushPumpState.BPState.Runing, m_AutoFlushPumpState.BPState.Direction));
            if (m_AutoFlushPumpState.FPState.Runing)
                SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, m_AutoFlushPumpState.FPState.Speed, m_AutoFlushPumpState.FPState.Runing, m_AutoFlushPumpState.FPState.Direction));
            if (m_AutoFlushPumpState.RPState.Runing)
                SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, m_AutoFlushPumpState.RPState.Speed, m_AutoFlushPumpState.RPState.Runing, m_AutoFlushPumpState.RPState.Direction));
            if (m_AutoFlushPumpState.DPState.Runing)
                SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, m_AutoFlushPumpState.DPState.Speed, m_AutoFlushPumpState.DPState.Runing, m_AutoFlushPumpState.DPState.Direction));
            if (m_AutoFlushPumpState.FP2State.Runing)
                SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, m_AutoFlushPumpState.FP2State.Speed, m_AutoFlushPumpState.FP2State.Runing, m_AutoFlushPumpState.FP2State.Direction));
            if (m_AutoFlushPumpState.CPState.Runing)
                SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, m_AutoFlushPumpState.CPState.Speed, m_AutoFlushPumpState.CPState.Runing, m_AutoFlushPumpState.CPState.Direction));
            m_watchFlush.Start();
        }
        void m_stepCHDF__SpSet(object sender, EventArgs e)
        {
            tsbtnOtherSet_Click(this.tsbtnOtherSet, e);
            toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnOtherSet));
            M_uc_OtherSet.tabControl1.SelectedTab = M_uc_OtherSet.tabControl1.TabPages[0];
            //throw new NotImplementedException();
        }

        void m_stepPP__SelectStepChanged(object sender, EventArgs e)
        {
            M_uc_Treat.palDry.Enabled = false;
            M_uc_Treat.chkBalance.Enabled = false;
            M_uc_Treat.btnChange.Enabled = false;
        }

        void m_stepCHDF__SelectStepChanged(object sender, EventArgs e)
        {
            m_currentStep = m_stepCHDF.wizardControl1.SelectedPage.TabIndex;
            switch (m_currentStep)
            {
                case 0:
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = false;
                    M_uc_Treat.btnChange.Enabled = false;
                    break;
                case 1:
                    M_uc_Treat.palDry.Enabled = true;
                    M_uc_Treat.chkBalance.Enabled = true;
                    M_uc_Treat.btnChange.Enabled = true;
                    break;
            }
        }


        void m_stepPERT__SelectStepChanged(object sender, EventArgs e)
        {
            m_currentStep = m_stepPERT.wizardControl1.SelectedPage.TabIndex;
            switch (m_currentStep)
            {
                case 0://血浆置换引血
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = false;
                    M_uc_Treat.btnChange.Enabled = false;
                    break;
                case 1://血浆置换
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = true;
                    M_uc_Treat.btnChange.Enabled = true;
                    break;
                case 2://血浆置换回收
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = false;
                    M_uc_Treat.btnChange.Enabled = false;
                    //所有泵停止
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                    //夹管阀操作
                    SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                    SavePETotal();
                    break;
                case 3://血滤引血
                    UserCtrl.MsgBox m = new UserCtrl.MsgBox("请仔细确认 <旋转三通阀T1、T2和T3> 选择的是 <血液滤过器>", UserCtrl.MsgBox.MSBoxIcon.Warning, ALS.Properties.Resources.PERTTip1, true);
                    if (DialogResult.OK == m.ShowDialog())
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        m_leadBloodSpeed = 0;
                    }
                    else
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x01, 0x01, 0x01, 0x01, 0x01));
                        m_stepPERT.wizardControl1.PreviousPage();
                    }
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = false;
                    M_uc_Treat.btnChange.Enabled = false;
                    break;
                case 4://血滤治疗
                    M_uc_Treat.palDry.Enabled = true;
                    M_uc_Treat.chkBalance.Enabled = true;
                    M_uc_Treat.btnChange.Enabled = true;
                    break;
            }
            //throw new NotImplementedException();
        }

        void m_stepPE__SelectStepChanged(object sender, EventArgs e)
        {
            m_currentStep = m_stepPE.wizardControl1.SelectedPage.TabIndex;
            switch (m_currentStep)
            {
                case 0:
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = false;
                    M_uc_Treat.btnChange.Enabled = false;
                    break;
                case 1:
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = true;
                    M_uc_Treat.btnChange.Enabled = true;
                    break;
            }
        }

        void m_stepPDF__SelectStepChanged(object sender, EventArgs e)
        {
            m_currentStep = m_stepPDF.wizardControl1.SelectedPage.TabIndex;
            switch (m_currentStep)
            {
                case 0:
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = false;
                    M_uc_Treat.btnChange.Enabled = false;
                    break;
                case 1:
                    M_uc_Treat.palDry.Enabled = true;
                    M_uc_Treat.chkBalance.Enabled = true;
                    M_uc_Treat.btnChange.Enabled = true;
                    break;
            }
        }

        void m_stepLiALS__SelectStepChanged(object sender, EventArgs e)
        {
            m_currentStep = m_stepLiALS.wizardControl1.SelectedPage.TabIndex;
            switch (m_currentStep)
            {
                case 0://引血
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = false;
                    M_uc_Treat.btnChange.Enabled = false;
                    break;
                case 1://血浆置换
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = true;
                    M_uc_Treat.btnChange.Enabled = true;
                    break;
                case 2://收集血浆
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = true;
                    M_uc_Treat.btnChange.Enabled = true;
                    SavePETotal();
                    break;
                case 3://整体治疗
                    M_uc_Treat.palDry.Enabled = true;
                    M_uc_Treat.chkBalance.Enabled = true;
                    M_uc_Treat.btnChange.Enabled = true;
                    break;
                case 4://准备回收
                    M_uc_Treat.palDry.Enabled = false;
                    M_uc_Treat.chkBalance.Enabled = false;
                    M_uc_Treat.btnChange.Enabled = false;
                    break;
            }
        }

        void M_uc_Treat__lblChangeDrySpeed(object sender, EventArgs e)
        {
            UserCtrl.numPad np = new UserCtrl.numPad(M_uc_Treat.lblDehydrationSpeed.Text);
            np.btnNegPos.Visible = false;
            np.btnDot.Visible = false;
            if (DialogResult.OK == np.ShowDialog())
            {
                if (np.Value > 200 || np.Value < 0)
                {
                    MessageBox.Show("请将脱水速度设置在 (0-200) mL/h 以内!");
                    return;
                }
                M_uc_Treat.lblDehydrationSpeed.Text = np.Value.ToString("f0");
                M_ModelTreat.dehydrationSpeed = np.Value;
                //更新设置
                new BLL.treatmentmode().Update(M_ModelTreat);
            }
        }


        void m_stepCHDF__CHDFSteps(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender.Tag != null)
            {
                string tag = btnSender.Tag.ToString();
                switch (tag)
                {
                    case "spset":
                        MessageBox.Show("111");
                        break;
                    case "startCHDF":
                        //判断过浓缩
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, m_leadBloodSpeed, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed.Value, true, false));
                        //m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "pauseCHDF":
                        //this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, false));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        //如果有平衡则停止
                        if (M_uc_Treat.chkBalance.Checked == true)
                        {
                            M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                            M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                        }
                        break;
                }
            }
        }

        void m_stepPP__PPSteps(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender.Tag != null)
            {
                string tag = btnSender.Tag.ToString();
                switch (tag)
                {
                    case "startPP":
                        //判断过浓缩
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, m_leadBloodSpeed, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        //m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "pausePP":
                        //this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        break;
                }
            }
            //throw new NotImplementedExceptio
        }

        void m_stepPDF__PDFSteps(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender.Tag != null)
            {
                string tag = btnSender.Tag.ToString();
                switch (tag)
                {
                    case "startPDF":
                        //判断过浓缩
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01));
                        RunStartPumpTreatTask();
                        //m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "pausePDF":
                        m_ctsStartPump.Cancel();
                        //this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, 0, false, false));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        //如果有平衡则停止
                        if (M_uc_Treat.chkBalance.Checked == true)
                        {
                            M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                            M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                        }
                        break;
                }
            }
            //throw new NotImplementedException();
        }

        void m_stepPE__PESteps(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender.Tag != null)
            {
                string tag = btnSender.Tag.ToString();
                switch (tag)
                {
                    case "startPE":
                        //判断过浓缩
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01));
                        RunStartPumpTreatTask();
                        //m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "pausePE":
                        //this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, false));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        //如果有平衡则停止
                        if (M_uc_Treat.chkBalance.Checked == true)
                        {
                            M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                            M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                        }
                        break;
                }
            }
        }

        //过浓缩
        private bool IsOverC()
        {
            if (m_leadBloodSpeed * M_ModelTreat.Concentration / 100.0 < M_ModelTreat.FPSpeed.Value)
            {
                //MessageBox.Show(m_leadBloodSpeed.ToString() + "," + (m_leadBloodSpeed * M_ModelTreat.Concentration / 100.0).ToString() + "," + M_ModelTreat.FPSpeed.ToString());
                return true;
            }
            else
                return false;
        }
        //保存PE累计值
        void SavePETotal()
        {
            m_TotalPE = new Cls.Model_Total();
            //保存PE累计值 
            m_TotalPE.TotalBP = M_ModelTotal.TotalBP;
            m_TotalPE.TotalDP = M_ModelTotal.TotalDP;
            m_TotalPE.TotalFP = M_ModelTotal.TotalFP;
            m_TotalPE.TotalRP = M_ModelTotal.TotalRP;
            m_TotalPE.TotalSP = M_ModelTotal.TotalSP;
            m_TotalPE.TotalTime = M_ModelTotal.TotalTime;
            m_TotalPE.CurrentDry = M_ModelTotal.CurrentDry;
        }

        void M_uc_OtherSet__btn_StopFastSP(object sender, EventArgs e)
        {
            m_ctsFastSP.Cancel();
        }

        void M_uc_OtherSet__btnRunFastSP(object sender, EventArgs e)
        {
            m_ctsFastSP = new CancellationTokenSource();
            Task t = RunFastSP(m_ctsFastSP);
            double spfast = M_ModelTreat.SP_RapidInjectionValue.Value;// Convert.ToDouble(Cls.RWconfig.GetAppSettings("SP_RapidInjectionValue"));
            int spendt = (int)Math.Round(spfast * 3.0, 3) * 1000;//表示所需ms;
            m_ctsFastSP.CancelAfter(spendt);
        }
        /// <summary>
        /// SP快进
        /// </summary>
        /// <param name="cts"></param>
        /// <returns></returns>
        delegate void spstate();
        async Task RunFastSP(CancellationTokenSource cts)
        {
            await Task.Delay(50).ConfigureAwait(false);
            SendOrder(port_hpump, Cls.Comm_SyringePump.FastForward(1200.0));
            await Task.Delay(200);
            SendOrder(port_hpump, Cls.Comm_SyringePump.FastForward(1200.0));
            while (true)
            {
                if (m_ctsFastSP.IsCancellationRequested)
                {
                    SendOrder(port_hpump, Cls.Comm_SyringePump.EndFastForward);
                    SendOrder(port_hpump, Cls.Comm_SyringePump.EndFastForward);
                    this.BeginInvoke(new spstate(() =>
                    {
                        M_uc_OtherSet.btnFastStopSP.Enabled = false;
                        M_uc_OtherSet.btnFastRunSP.Enabled = true;
                    }));
                    break;
                }
                else
                    await Task.Delay(100);
            }
        }

        void M_uc_Treat__btnHotAndSP(object sender, EventArgs e)
        {
            UserCtrl.uc_PumpSpeed up = (UserCtrl.uc_PumpSpeed)sender;
            if (up.Tag != null)
            {
                string tag = up.Tag.ToString();
                switch (tag)
                {
                    case "sp":
                        tsbtnOtherSet_Click(this.tsbtnOtherSet, e);
                        toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnOtherSet));
                        M_uc_OtherSet.tabControl1.SelectedTab = M_uc_OtherSet.tabControl1.TabPages[0];
                        break;
                    case "hot":
                        tsbtnOtherSet_Click(this.tsbtnOtherSet, e);
                        toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnOtherSet));
                        M_uc_OtherSet.tabControl1.SelectedTab = M_uc_OtherSet.tabControl1.TabPages[1];
                        break;
                }
            }
            //throw new NotImplementedException();
        }


        void m_stepPERT_PERTSteps(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag != null)
            {
                string tag = btn.Tag.ToString();
                switch (tag)
                {
                    case "startPE":
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, m_leadBloodSpeed, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed.Value, true, false));
                        //m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "pausePE"://修改为暂停置换
                        //this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, false));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        //如果有平衡则停止
                        if (M_uc_Treat.chkBalance.Checked == true)
                        {
                            M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                            M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                        }
                        break;
                    case "startperecycle":
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
                        UserCtrl.MsgBox m = new UserCtrl.MsgBox("确认<管夹>夹住动脉端,将生理盐水连接至前稀释接口!", UserCtrl.MsgBox.MSBoxIcon.Warning, ALS.Properties.Resources.PERTTip3, true);
                        if (DialogResult.OK == m.ShowDialog())
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 5, true, true));
                            m_leadBloodSpeed = 0;
                        }

                        break;
                    case "stopperecycle":
                        this.gifRuning.Image = global::ALS.Properties.Resources.zanting;
                        //停止置换时，将夹管阀V2夹住，用旋塞三通更换为血滤柱子
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x01, 0x01, 0x01, 0x01, 0x01));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 0, false, true));
                        m_leadBloodSpeed = 0;
                        break;
                    case "startCHDF":
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;

                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x00, 0x01));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, m_leadBloodSpeed, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed.Value, true, false));
                        //m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "pauseCHDF"://暂停血滤
                        //this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, false));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        if (M_uc_Treat.chkBalance.Checked == true)
                        {
                            M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                            M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                        }
                        break;
                }
            }
            //throw new NotImplementedException();
        }

        void M_uc_Recycle_recycle_btnRunBP(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            double speed = 0;
            if (btn.Tag != null)
            {
                string id = btn.Tag.ToString();
                switch (id)
                {
                    case "bp":
                        if (btn.Text == "运转")
                        {
                            //夹管阀1或2没有打开时，提示
                            string msg = string.Empty;
                            if (M_PumpState.VState[0] == 0x01)
                                msg = "请将夹管阀1松开;\r\n";
                            if (M_PumpState.VState[1] == 0x01)
                                msg += "请将夹管阀2松开;";
                            if (!string.IsNullOrEmpty(msg))
                            {
                                MessageBox.Show(this, msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            speed = Convert.ToDouble(M_uc_Recycle.lblBP.Text);
                            if (speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                            //夹管阀
                            if (M_PumpState.VState[0] == 0x01 || M_PumpState.VState[1] == 0x01)
                                SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                            //开启SP
                            SendOrder(port_hpump, Cls.Comm_SyringePump.Start(M_ModelTreat.SP_Speed.Value, M_ModelTreat.TargetSP.Value));
                            //bp顺转
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, speed, true, true));
                            //开启SP
                            SendOrder(port_hpump, Cls.Comm_SyringePump.Start(M_ModelTreat.SP_Speed.Value, M_ModelTreat.TargetSP.Value));
                            //改变旋钮初始速度
                            m_leadBloodSpeed = (int)speed;
                        }
                        else
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 0, false, true));
                        }
                        break;
                    case "fp":
                        if (btn.Text == "运转")
                        {
                            //pp模式下夹管阀1,2,3都应松开
                            if (M_ModelTreat.name == "PP")
                            {
                                string msg = string.Empty;
                                if (M_PumpState.VState[0] == 0x01)
                                    msg = "请将夹管阀1松开;\r\n";
                                if (M_PumpState.VState[1] == 0x01)
                                    msg += "请将夹管阀2松开;\r\n";
                                if (M_PumpState.VState[2] == 0x01)
                                    msg += "请将夹管阀3松开;\r\n";
                                if (M_PumpState.VState[3] != 0x01)
                                    msg += "请将夹管阀4闭合";
                                if (!string.IsNullOrEmpty(msg))
                                {
                                    MessageBox.Show(this, msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                string msg = string.Empty;
                                if (M_PumpState.VState[0] == 0x01)
                                    msg = "请将夹管阀1松开;\r\n";
                                if (M_PumpState.VState[1] == 0x01)
                                    msg += "请将夹管阀2松开;";
                                if (!string.IsNullOrEmpty(msg))
                                {
                                    MessageBox.Show(this, msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            speed = Convert.ToDouble(M_uc_Recycle.lblFP.Text);
                            if (speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                            //fp顺转
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, speed, true, true));
                        }
                        else
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        }
                        break;
                    case "dp":
                        if (btn.Text == "运转")
                        {
                            if (M_ModelTreat.name == "Li-ALS")
                            {
                                string msg = string.Empty;
                                if (M_PumpState.VState[0] == 0x01)
                                    msg = "请将夹管阀1松开;\r\n";
                                if (M_PumpState.VState[1] == 0x01)
                                    msg += "请将夹管阀2松开;\r\n";
                                if (M_PumpState.VState[2] == 0x01)
                                    msg += "请将夹管阀3松开;\r\n";
                                if (M_PumpState.VState[3] == 0x00)
                                    msg += "请将夹管阀4闭合;\r\n";
                                if (M_PumpState.VState[4] == 0x00)
                                    msg += "请将夹管阀5闭合;\r\n";
                                if (M_PumpState.VState[5] == 0x01)
                                    msg += "请将夹管阀6松开;";
                                if (!string.IsNullOrEmpty(msg))
                                {
                                    MessageBox.Show(this, msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                string msg = string.Empty;
                                if (M_PumpState.VState[0] == 0x01)
                                    msg = "请将夹管阀1松开;\r\n";
                                if (M_PumpState.VState[1] == 0x01)
                                    msg += "请将夹管阀2松开;";
                                if (!string.IsNullOrEmpty(msg))
                                {
                                    MessageBox.Show(this, msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            speed = Convert.ToDouble(M_uc_Recycle.lblDP.Text);
                            if (speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                            //dp逆转
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, speed, true, false));
                        }
                        else
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, false));
                        }
                        break;
                    case "rp":
                        if (btn.Text == "运转")
                        {
                            string msg = string.Empty;
                            if (M_PumpState.VState[0] == 0x01)
                                msg = "请将夹管阀1松开;\r\n";
                            if (M_PumpState.VState[1] == 0x01)
                                msg += "请将夹管阀2松开;\r\n";
                            if (M_PumpState.VState[2] == 0x01)
                                msg += "请将夹管阀3松开;\r\n";
                            if (M_PumpState.VState[3] != 0x01)
                                msg += "请将夹管阀4闭合";
                            if (!string.IsNullOrEmpty(msg) && M_ModelTreat.name != "Li-ALS")
                            {
                                MessageBox.Show(this, msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            speed = Convert.ToDouble(M_uc_Recycle.lblRP.Text);
                            if (speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                            //rp逆转
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, speed, true, false));
                        }
                        else
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, false));
                        }
                        break;
                    case "fp2":
                        if (btn.Text == "运转")
                        {
                            speed = Convert.ToDouble(M_uc_Recycle.lblFP2.Text);
                            if (speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, speed, true, false));
                        }
                        else
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, 0, false, false));
                        }
                        break;
                    case "cp":
                        if (btn.Text == "运转")
                        {
                            speed = Convert.ToDouble(M_uc_Recycle.lblCP.Text);
                            if (speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, speed, true, true));
                        }
                        else
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, 0, false, true));
                        }
                        break;
                }
            }
            //throw new NotImplementedException();
        }

        void M_uc_OtherSet__btnRunSP(object sender, EventArgs e)
        {
            //发送两遍命令
            SendOrder(port_hpump, Cls.Comm_SyringePump.Start(M_ModelTreat.SP_Speed.Value, M_ModelTreat.TargetSP.Value));
            Thread.Sleep(100);
            SendOrder(port_hpump, Cls.Comm_SyringePump.Start(M_ModelTreat.SP_Speed.Value, M_ModelTreat.TargetSP.Value));
        }

        void M_uc_SetFlow_checkVClick(object sender, EventArgs e)
        {
            CheckBox cbox = sender as CheckBox;
            switch (cbox.Tag.ToString())
            {
                case "v1":
                    if (cbox.Checked)
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [1] 闭合？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x01, 0x02, 0x02, 0x02, 0x02, 0x02));
                        }
                        else
                            cbox.Checked = false;
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [1] 松开？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x02, 0x02, 0x02, 0x02, 0x02));
                        }
                        else
                            cbox.Checked = true;
                    }

                    break;
                case "v2":
                    if (cbox.Checked)
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [2] 闭合？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x01, 0x02, 0x02, 0x02, 0x02));
                        }
                        else cbox.Checked = false;
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [2] 松开？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x00, 0x02, 0x02, 0x02, 0x02));
                        }
                        else
                            cbox.Checked = true;
                    }

                    break;
                case "v3":
                    if (cbox.Checked)
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [3] 闭合？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x02, 0x01, 0x02, 0x02, 0x02));
                        }
                        else
                            cbox.Checked = false;
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [3] 松开？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x02, 0x00, 0x02, 0x02, 0x02));
                        }
                        else
                            cbox.Checked = true;
                    }
                    break;
                case "v4":
                    if (cbox.Checked)
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [4] 闭合？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x02, 0x02, 0x01, 0x02, 0x02));
                        }
                        else
                            cbox.Checked = false;
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [4] 松开？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x02, 0x02, 0x00, 0x02, 0x02));
                        }
                        else
                            cbox.Checked = true;
                    }
                    break;
                case "v5":
                    if (cbox.Checked)
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [5] 闭合？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x02, 0x02, 0x02, 0x01, 0x02));
                        }
                        else
                            cbox.Checked = false;
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [5] 松开？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x02, 0x02, 0x02, 0x00, 0x02));
                        }
                        else
                            cbox.Checked = true;
                    }
                    break;
                case "v6":
                    if (cbox.Checked)
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [6] 闭合？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x02, 0x02, 0x02, 0x02, 0x01));
                        }
                        else
                            cbox.Checked = false;
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show(this, "确认将管夹 [6] 松开？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                        {
                            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x02, 0x02, 0x02, 0x02, 0x02, 0x00));
                        }
                        else
                            cbox.Checked = true;
                    }
                    break;
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Li-ALS治疗向导按钮委托函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_stepLiALS__btnsLiAlsWizard(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            if (btnSender.Tag != null)
            {
                string tag = btnSender.Tag.ToString();

                switch (tag)
                {
                    case "startZhihuan":
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x00, 0x01));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, m_leadBloodSpeed, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false));
                        //m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "stopZhihuan":
                        //this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, false));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        //如果有平衡则停止
                        if (M_uc_Treat.chkBalance.Checked == true)
                        {
                            M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                            M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                        }
                        break;
                    case "startShouji":
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x00, 0x01));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, m_leadBloodSpeed, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false));
                        //m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "stopShouji":
                        //this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                        //如果有平衡则停止  
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, false));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        if (M_uc_Treat.chkBalance.Checked == true)
                        {
                            M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                            M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                        }
                        break;
                    case "preCircle":
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
                        //SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelTreat.BPSpeed.Value, true, true));
                        //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelTreat.CPSpeed.Value, true, true));
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        m_ispreCircle = true;
                        m_stepLiALS.btnStartTreat.Enabled = false;
                        m_stepLiALS.btnPauseTreat.Enabled = false;
                        m_stepLiALS.btnPreCircle.Enabled = false;
                        Task t = TaskPreCircle();
                        break;
                    case "startAll":
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x00));
                        RunStartPumpTreatTask();
                        //初始化旋钮速度
                        m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "stopAll":
                        m_ctsStartPump.Cancel();
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zanting;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, 0, false, true));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        if (M_uc_Treat.chkBalance.Checked == true)
                        {
                            M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                            M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                        }
                        break;
                    case "readyHuishou":
                        if (IsOverC())
                        {
                            ShowWarn("W3-02");
                            return;
                        }
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x00));
                        RunStartPumpTreatTask();
                        //初始化旋钮速度
                        m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
                        break;
                    case "stopReady":
                        m_ctsStartPump.Cancel();
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zanting;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, 0, false, false));
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, 0, false, true));
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                        break;
                }
            }
            //throw new NotImplementedException();
        }

        async Task TaskPreCircle()
        {
            dtPreCircle = DateTime.Now;
            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, m_leadBloodSpeed, true, true));
            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelTreat.CPSpeed.Value, true, true));
            while (m_ispreCircle)
            {
                TimeSpan ts = new TimeSpan((DateTime.Now - dtPreCircle).Ticks);
                await Task.Delay(200);
                this.BeginInvoke(new Action(() =>
                {
                    m_stepLiALS.lblPreCircleTime.Text = "倒计时:" + (30 - ts.TotalSeconds).ToString("0") + "秒";
                    if (ts.TotalSeconds > 30)
                    {
                        m_ispreCircle = false;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, 0, false, true));
                        m_stepLiALS.btnPreCircle.Enabled = true;
                        m_stepLiALS.btnStartTreat.Enabled = true;
                        m_stepLiALS.btnPauseTreat.Enabled = false;
                        m_stepLiALS.wizardControl1.SelectedPage.AllowNext = true;
                        m_stepLiALS.wizardControl1.SelectedPage.AllowBack = true;
                    }
                }));
            }
        }


        void M_uc_SetFlow_btnChange_bp(object sender, EventArgs e)
        {
            M_ModelTreat = GetTreatmentModel(M_modeName);
            //throw new NotImplementedException();
        }

        void M_uc_Treat__StartAll(object sender, EventArgs e)
        {
#if LOG_SYSTEM
            getLog.WriteLogFile("frmMain,547,M_uc_Treat__StartAll");
#endif
            //this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
            m_leadBloodSpeed = (int)M_ModelTreat.BPSpeed.Value;
            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01));
            RunStartPumpTreatTask();
            //throw new NotImplementedException();
        }

        void M_uc_Treat__StopPump(object sender, EventArgs e)
        {
            if (m_taskStartPump != null)
                m_ctsStartPump.Cancel();
            this.gifRuning.Image = global::ALS.Properties.Resources.zanting;
            //各泵停止
            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
            //夹管阀夹住
            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x01, 0x01, 0x01, 0x01, 0x01, 0x01));
            //PE CHDF PP模式下停止置换/停止治疗时，停止加热,停止肝素泵;
            //wss 2016年2月19日
            //SendOrder(port_main, Cls.Comm_Main.CmdTemperature.StopHT);
            //SendOrder(port_hpump, Cls.Comm_SyringePump.Stop);
        }

        void M_uc_AutoFlush__btnStopAddFlush(object sender, EventArgs e)
        {
            this.btnStart.Enabled = true;
        }

        void M_uc_AutoFlush__btnAddFlush(object sender, EventArgs e)
        {
            if (M_uc_AutoFlush.dgvStep.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "请选择需要追加预冲的步骤!");
                return;
            }
            else
            {
                m_isAddFlush = !m_isAddFlush;
                if (m_isAddFlush)
                {
                    this.lblTime.Text = "00:00:00";
                    int customID = Convert.ToInt32(M_uc_AutoFlush.dgvStep.SelectedRows[0].Cells["ID"].Value);
                    if (DialogResult.OK != MessageBox.Show(this, "确定追加此预冲步骤吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                    {
                        //不追加预冲时返回；
                        m_isAddFlush = false;
                        return;
                    }
                    else
                    {
                        //当需要确认夹管阀状态的时候，弹出对话框
                        int m_lstCust_Index = m_lstCust.FindIndex(m => m.ID == customID);
                        if (m_lstCust_Index > 0 && m_lstCust[m_lstCust_Index - 1].timeSpan == 0)
                        {
                            byte[] b = m_lstCust[m_lstCust_Index - 1].tipPic;
                            Bitmap bp = null;
                            if (b != null)
                            {
                                MemoryStream ms = new MemoryStream(b);
                                bp = (Bitmap)Image.FromStream(ms);
                            }
                            //弹出对话框，确认信息
                            //HPTCMessageBox.MSBox m = new HPTCMessageBox.MSBox("警告", m_lstCust[0].actionName + ",然后点击 “确定” 开始冲洗!", HPTCMessageBox.MSBox.MSBoxIcon.Warning, bp);
                            UserCtrl.MsgBox m = new UserCtrl.MsgBox("警告: " + m_lstCust[m_lstCust_Index - 1].actionName, UserCtrl.MsgBox.MSBoxIcon.Warning, bp, true);
                            if (DialogResult.OK != m.ShowDialog())
                            {
                                //不确认夹管阀状态时返回；
                                m_isAddFlush = false;
                                return;
                            }
                        }

                        M_uc_AutoFlush.btnAddFlush.Text = "停止";
                        //改变Enable
                        M_uc_AutoFlush.btnStart.Enabled = false;
                        M_uc_AutoFlush.btnFinish.Enabled = false;
                        M_uc_AutoFlush.dgvStep.Enabled = false;
                        M_uc_AutoFlush.btnReturn.Enabled = false;

                        this.tsbtnPipeline.Enabled = false;
                        this.tsbtnTherapy.Enabled = false;
                        this.tsbtnRecycle.Enabled = false;
                        this.tsbtnSetFlow.Enabled = false;
                        this.lblBloodSpeed.Enabled = false;
                        this.btnStart.Enabled = false;

                        BLL.actions bllact = new BLL.actions();
                        List<ALS.Model.actions> lstModAct = bllact.GetModelList("customID='" + customID + "'");
                        List<Cls.Model_SendCMD> lstActions = new List<Cls.Model_SendCMD>();
                        if (lstModAct.Count > 0)
                        {
                            lstActions = GetlstActions(lstModAct);
                            //创建发送追加预冲的任务  
                            m_watchAddFlush.Start();
                            m_taskChildActions = new Task(RunAddActions, lstActions, TaskCreationOptions.LongRunning);
                            m_taskChildActions.Start();
                        }
                    }
                }
                else
                {
                    M_uc_AutoFlush.btnAddFlush.Text = "追加预冲";
                    M_uc_AutoFlush.btnReturn.Enabled = true;
                    M_uc_AutoFlush.btnStart.Enabled = true;
                    //发送停止命令
                    SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                    M_uc_AutoFlush.btnFinish.Enabled = true;
                    M_uc_AutoFlush.dgvStep.Enabled = true;
                    m_watchAddFlush.Reset();
                    m_watchAddFlush.Stop();
                    //追加预冲停止后，清除选中行状态，追加预冲时
                    //左侧按键模式，管路，治疗，右下角开始按键为灰色
                    //wss 2016年5月10日
                    ((DataGridViewCheckBoxCell)M_uc_AutoFlush.dgvStep.SelectedRows[0].Cells["selAdd"]).Value = 0;
                    M_uc_AutoFlush.dgvStep.ClearSelection();
                    //if (_btnStopAddFlush != null)
                    //    _btnStopAddFlush(sender, e);
                }
            }
        }

        void m_ucWarnInfo__btnRelease(object sender, EventArgs e)
        {
            //解除时，静音周期计时关闭
            //2016年5月18日 wss
            m_watchUnreleaseWarn.Reset();
            //报警复位时，如果串口2数据读取处于关闭状态则打开 2016年8月26日
            if (M_Closing_hpump)
                M_Closing_hpump = false;
            //清空报警列表
            this.m_lstSysWarn.Clear();
            m_ucWarnInfo.ucWarnInfo1.dgvView.Rows.Clear();
            RunReleaseWarnTask();
            m_ucWarnInfo.Visible = false;
            m_isReleaseWarn = true;
        }

        void m_ucWarnInfo__btnMute(object sender, EventArgs e)
        {
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.AllVoiseClose);
            //静音周期开始计时
            //2016年5月18日 wss
            m_watchUnreleaseWarn.Reset();
            m_watchUnreleaseWarn.Start();
            //throw new NotImplementedException();
        }
        //消除警报
        void m_ucWarnInfo1__btnDealwarn(object sender, DataGridViewExs.EventArgsEx.DataGridViewButtonClickEventArgs e)
        {
            //警报等级小于3进入此处理方法
            //黄灯闪烁
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.YellowTwinkle);
            //静音
            m_ucWarnInfo__btnMute(sender, new EventArgs());
            //窗体初始化
            m_frmDealWarn.frmdeal_spstart.Visible = false;
            m_frmDealWarn.palPven.Visible = false;
            m_frmDealWarn.chkV1.Visible = false;
            m_frmDealWarn.chkV2.Visible = false;
            m_frmDealWarn.ReadVState(M_PumpState);
            //获得报警编码
            string wcode = m_ucWarnInfo.ucWarnInfo1.dgvView.Rows[e.RowIndex].Cells["code"].Value.ToString();
            //获得m_lstShowWarn报警编码列表中 报警编号
            int index_warn = m_lstShowWarn.FindIndex(m => m.mwarncode.code == wcode);
            //获得所在行
            Dwarn_RIndex = e.RowIndex;
            //警报等级
            int wgrade = m_lstShowWarn[index_warn].mwarncode.grade;
            //根据警报等级降低当前旋钮速度
            if (wgrade == 1)
            {
                if (M_PumpState.BPState.Speed > 20)
                    m_leadBloodSpeed = 20;
            }

            //处理步骤显示
            m_frmDealWarn.textsteps.Text = m_lstShowWarn[index_warn].mwarncode.dealSteps.ToString();
            //图片显示
            byte[] b = (byte[])m_lstShowWarn[index_warn].mwarncode.dealImg;
            if (b != null)
            {
                MemoryStream ms = new MemoryStream(b);
                Bitmap bmp = new Bitmap(ms);
                m_frmDealWarn.pox1.Image = bmp;
                ms.Close();
                ms.Dispose();
            }
            else
                m_frmDealWarn.pox1.Image = null;

            //操作处理显示
            switch (wcode)
            {
                case "W1-01"://气泡检测1       
                    m_frmDealWarn.palPven.Visible = true;
                    m_frmDealWarn.chkV1.Visible = true;
                    m_frmDealWarn.chkV2.Visible = true;
                    m_frmDealWarn.chkV1.Enabled = true;
                    m_frmDealWarn.chkV2.Enabled = true;
                    SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble1);
                    SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble1);
                    m_isOpenAD1 = false;
                    break;
                case "W2-01"://气泡检测2  
                    SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble2);
                    SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble2);
                    m_isOpenAD2 = false;
                    break;
                case "W2-02"://气泡检测3  
                    SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble3);
                    SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble3);
                    m_isOpenAD3 = false;
                    break;
                case "W1-03"://采血不良 
                    m_frmDealWarn.chkV1.Visible = true;
                    m_frmDealWarn.chkV2.Visible = true;
                    m_frmDealWarn.chkV1.Enabled = true;
                    m_frmDealWarn.chkV2.Enabled = true;
                    break;
                case "W1-05"://静脉压
                case "W1-06":
                case "W1-08"://动脉压
                case "W1-09":
                case "W1-23"://漏血
                    m_frmDealWarn.chkV1.Visible = true;
                    m_frmDealWarn.chkV2.Visible = true;
                    m_frmDealWarn.chkV1.Enabled = true;
                    m_frmDealWarn.chkV2.Enabled = true;
                    break;
                case "W1-21":
                    m_frmDealWarn.frmdeal_spstart.Visible = true;
                    break;
                default:
                    break;
            }
            //取消报警窗体最前端显示
            m_ucWarnInfo.TopMost = false;
            //操作处理窗口的时候软件其他东西不能操作  
            if (DialogResult.OK == m_frmDealWarn.ShowDialog())
            {
                //如果是预冲或治疗时，自动打开气泡检测
                if (M_isTreat || M_isFlush)
                {
                    switch (wcode)
                    {
                        case "W1-01"://气泡检测1
                            SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble1);
                            SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble1);
                            break;
                        case "W2-01"://气泡检测2
                            SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble2);
                            SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble2);
                            break;
                        case "W2-02"://气泡检测3
                            SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble3);
                            SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble3);
                            break;
                    }
                }
                //移除当前警报 
                int windex = m_lstSysWarn.FindIndex(m => m._ModelShowWarn.mwarncode.code == wcode);
                if (windex > 0)
                    m_lstSysWarn.RemoveAt(windex);
                //移除当前警报后，判断当前报警列表是否还存在1级报警，若存在
                //则[报警复位]按键不可用 2016年9月9日
                if (m_lstSysWarn.Find(m => m._ModelShowWarn.mwarncode.grade == 1) != null)
                    m_ucWarnInfo.ucWarnInfo1.btnReleaseWarn.Enabled = false;
                else
                    m_ucWarnInfo.ucWarnInfo1.btnReleaseWarn.Enabled = true;
                m_ucWarnInfo.TopMost = true;
            }
        }

        //对于低级报警，删除报警列表中的该报警 2016年9月9日
        void m_ucWarnInfo_btn_deleteLowW(object sender, DataGridViewExs.EventArgsEx.DataGridViewButtonClickEventArgs e)
        {
            //获得报警编码
            string wcode = m_ucWarnInfo.ucWarnInfo1.dgvView.Rows[e.RowIndex].Cells["code"].Value.ToString();
            //移除当前警报 
            m_lstSysWarn.RemoveAt(m_lstSysWarn.FindIndex(m => m._ModelShowWarn.mwarncode.code == wcode));
        }

        void m_frmDealWarn_btnClose(object sender, EventArgs e)
        {
            //将报警窗体显示在最前端
            m_ucWarnInfo.TopMost = true;
            //删除当前已处理警报
            m_ucWarnInfo.ucWarnInfo1.dgvView.Rows.RemoveAt(Dwarn_RIndex);
            //报警灯处理

            if (m_lstSysWarn.Find(m => m._ModelShowWarn.mwarncode.grade == 1) != null)
                m_ucWarnInfo.ucWarnInfo1.btnReleaseWarn.Enabled = false;
            else
                m_ucWarnInfo.ucWarnInfo1.btnReleaseWarn.Enabled = true;

            //如果当前警报列表中包含小于3的警报则发红灯亮
            if (m_lstSysWarn.Find(m => m._ModelShowWarn.mwarncode.grade <= 3) != null)
                SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.RedTwinkle);

            //foreach (DataGridViewRow dgvr in m_ucWarnInfo.ucWarnInfo1.dgvView.Rows)
            //{
            //    if (Convert.ToInt16(dgvr.Cells["grade"].Value.ToString()) < 3)
            //    {
            //        SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.RedTwinkle);
            //        break;
            //    }
            //}

            //没有报警时调用报警复位按键
            if (m_ucWarnInfo.ucWarnInfo1.dgvView.RowCount == 0)
            {
                m_ucWarnInfo.ucWarnInfo1.btnRelease_Click(sender, e);
            }
        }

        void SendOrderToPortMain()
        {
            SendOrder(port_main, Cls.Comm_Main.CmdTemperature.StartHT(Convert.ToByte(M_ModelTreat.TargetT)));
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            SendOrder(port_main, Cls.Comm_Main.CmdTemperature.StartHT(Convert.ToByte(M_ModelTreat.TargetT)));
        }

        public void LoadWeighPara()
        {
            BLL.calibrateweigh bcw = new BLL.calibrateweigh();
            Model.calibrateweigh mcw = bcw.GetModel(1);

            /****************
             * 添加秤4相关参数获取
             * 'weigh4_0kgcode,weigh4_5kgcode,weigh4_10kgcode,weigh4_resolution'
             * wss 2015年12月7日
             ****************/
            weigh1_0kgcode = mcw.weigh1_0kgcode.Value;
            weigh2_0kgcode = mcw.weigh2_0kgcode.Value;
            weigh3_0kgcode = mcw.weigh3_0kgcode.Value;
            weigh4_0kgcode = mcw.weigh4_0kgcode.Value;

            weigh1_5kgcode = mcw.weigh1_5kgcode.Value;
            weigh2_5kgcode = mcw.weigh2_5kgcode.Value;
            weigh3_5kgcode = mcw.weigh3_5kgcode.Value;
            weigh4_5kgcode = mcw.weigh4_5kgcode.Value;

            weigh1_resolution = mcw.weigh1_resolution.Value;
            weigh2_resolution = mcw.weigh2_resolution.Value;
            weigh3_resolution = mcw.weigh3_resolution.Value;
            weigh4_resolution = mcw.weigh4_resolution.Value;
        }

        public void SaveWeighPara()
        {
            BLL.calibrateweigh bcw = new BLL.calibrateweigh();
            Model.calibrateweigh mcw = bcw.GetModel(1);

            /****************
            * 添加秤4相关参数保存
            * 'weigh4_0kgcode,weigh4_5kgcode,weigh4_10kgcode'
            * wss 2015年12月7日
            ****************/
            mcw.weigh1_0kgcode = weigh1_0kgcode;// Cls.RWconfig.SetAppSettings("1_0kgcode", weigh1_0kgcode.ToString("f0"));
            mcw.weigh2_0kgcode = weigh2_0kgcode;// Cls.RWconfig.SetAppSettings("2_0kgcode", weigh2_0kgcode.ToString("f0"));
            mcw.weigh3_0kgcode = weigh3_0kgcode;//Cls.RWconfig.SetAppSettings("3_0kgcode", weigh3_0kgcode.ToString("f0"));
            mcw.weigh4_0kgcode = weigh4_0kgcode;

            mcw.weigh1_5kgcode = weigh1_5kgcode;//Cls.RWconfig.SetAppSettings("1_5kgcode", weigh1_5kgcode.ToString("f0"));
            mcw.weigh2_5kgcode = weigh2_5kgcode;//Cls.RWconfig.SetAppSettings("2_5kgcode", weigh2_5kgcode.ToString("f0"));
            mcw.weigh3_5kgcode = weigh3_5kgcode;//Cls.RWconfig.SetAppSettings("3_5kgcode", weigh3_5kgcode.ToString("f0"));
            mcw.weigh4_5kgcode = weigh4_5kgcode;

            if (bcw.Update(mcw))
                LoadWeighPara();
        }

        private bool LoadShowWarn(out string tipinfo)
        {
            try
            {
                //查询该代码的警报信息描述 及 命令组
                BLL.warncode bw = new BLL.warncode();
                List<Model.warncode> lstmwcode = bw.GetModelList("");
                m_lstShowWarn = new List<Cls.Model_ShowWarn>();
                foreach (Model.warncode m in lstmwcode)
                {
                    Cls.Model_ShowWarn msw = new Cls.Model_ShowWarn(m, port_main, port_hpump, port_ppump);
                    m_lstShowWarn.Add(msw);
                }
                tipinfo = "·";
                return true;
            }
            catch (Exception ee)
            {
                tipinfo = "预载数据失败:" + ee.Message;
                return false;
            }
        }

        /// <summary>
        /// 任务：报警监测与响应
        /// </summary>
        /// <param name="o">传递报警代码</param>
        private void ShowWarn(string warnCode)
        {
            //List查询警报代码，获取内容
            int index = m_lstShowWarn.FindIndex(m => m.mwarncode.code == warnCode);
            //如果警报等级不是提示性的，即警报等级小于4 且 无报警
            if (m_lstShowWarn[index].mwarncode.grade < 4 && m_isReleaseWarn)
            {
                if (m_taskStartPump != null)
                    m_ctsStartPump.Cancel();
#if LOG_SYSTEM
                    getLog.WriteLogFile("frmMain,729,m_ctsStartPump.Cancel");
#endif
                if (m_taskSendWarn != null)
                    m_ctsSendWarn.Cancel();

                if (m_taskReleaseWarn != null)
                    m_ctsReleaseWarn.Cancel();
#if LOG_SYSTEM
                    getLog.WriteLogFile("frmMain,733,m_ctsReleaseWarn.Cancel");
#endif

                m_isReleaseWarn = false;
            }
            //如果存在报警,弹出警报窗体               
            Cls.clsSysWarn syswarn = new Cls.clsSysWarn();
            syswarn._IsMute = false;
            syswarn._IsRelease = false;
            syswarn._ModelShowWarn = m_lstShowWarn[index];
            //首先确定是否响应该警报的动作,如果警报列表中有此警报，则忽略响应，只显示窗体                
            if (m_lstSysWarn.Find(m => (m._ModelShowWarn.mwarncode.code == syswarn._ModelShowWarn.mwarncode.code)) == null)
            {
                //新的报警出现时，静音周期重新计时
                //2016年5月18日 wss
                m_watchUnreleaseWarn.Reset();
                //此处加判断 报警等级是否为1，是则停止所有泵
                //如果在预冲时出现任何警报，都会停止所有泵
                if ((m_lstShowWarn[index].mwarncode.grade == 1 && m_lstSysWarn.Find(m => m._ModelShowWarn.mwarncode.grade == 1) == null) || M_isFlush)
                {
                    //如果是一级警报,泵当前速度为0
                    m_leadBloodSpeed = 0;
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
#if LOG_WARNING
                        getLog.WriteLogFile("frmMain,738,grade 1，stop all pump");
#endif
                }
                //添加未解除的报警记录
                m_lstSysWarn.Add(syswarn);
                this.BeginInvoke(new Action(() =>
                {
                    //添加至警报窗体列表中                    
                    m_ucWarnInfo.IsMin = true;
                    m_ucWarnInfo.btnMin_Click(m_ucWarnInfo.btnMin, new EventArgs());
                    m_ucWarnInfo.ucWarnInfo1.AddWarnInfo(syswarn._ModelShowWarn.mwarncode);
                    //当已经存在报警框时，若当前报警为1级报警，则
                    //[报警复位]按键为不可用 2016年9月9日
                    if (m_lstShowWarn[index].mwarncode.grade == 1)
                    {
                        m_ucWarnInfo.ucWarnInfo1.btnReleaseWarn.Enabled = false;
                    }
                    ShowWarnForm(m_lstShowWarn[index].mwarncode.grade);
                }));
                //根据警报等级，决定是否响应动作
                //如果现有警报列表中存在比当前警报等级高的，则不用响应，而只是显示信息 
                int grade = syswarn._ModelShowWarn.mwarncode.grade;
                //查询列表中是否存在比当前警报等级高的 1最高 4最低 grade值 小
                //如果不存在比此等级高或等的则响应动作
                if (m_lstSysWarn.Find(m => (m._ModelShowWarn.mwarncode.grade < grade)) == null)
                {
#if LOG_SYSTEM
                        getLog.WriteLogFile("frmMain,774,RunSenWarnCmdTask,Count:" + m_lstShowWarn[index].lstSendcmds.Count.ToString());
#endif
                    //获取警报动作列表
                    m_lstWarnActions = m_lstShowWarn[index].lstSendcmds;
                    //如果警报同时产生，发送警报命令的参数 m_lstWarnActions 内容改变  
                    RunSendWarnCmdTask();
                }
                //添加报警记录 
                AddWarnToDataset(syswarn._ModelShowWarn.mwarncode.grade, syswarn._ModelShowWarn.mwarncode.code, syswarn._ModelShowWarn.mwarncode.content);
            }
            //this.BeginInvoke(new Action(() =>
            ////显示警报窗体
            //{
            //    ShowWarnForm(m_lstShowWarn[index].mwarncode.grade);
            //}));
        }
        private void ShowWarnForm(int grade)
        {
            try
            {
                if (!m_ucWarnInfo.Visible)
                {
                    m_ucWarnInfo.Visible = true;
                    m_ucWarnInfo.TopMost = true;
                    //如果警报列表中有包含等级1的警报，则“复位”不可用；
                    if (m_lstSysWarn.Find(m => m._ModelShowWarn.mwarncode.grade == 1) != null)
                        m_ucWarnInfo.ucWarnInfo1.btnReleaseWarn.Enabled = false;

                    //根据警报等级修改向导界面按钮状态
                    if (M_isTreat && grade < 3)
                    {
                        //this.gifRuning.Image = global::ALS.Properties.Resources.zanting;
                        ChgTreStep_State(M_modeName);
                    }

                    m_ucWarnInfo.Location = this.palContent.PointToScreen(new Point(this.palbtmContain.Width / 2 + 50, 2));
                    m_ucWarnInfo.Height = 486;// this.palContent.Height - 2;
                    m_ucWarnInfo.Width = 400;// this.palContent.Width / 2;

                    //出现警报时，如果泵称平衡则去掉！
                    if (M_uc_Treat.chkBalance.Checked == true)
                    {
                        M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                        M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                    }

                    #region 如果是预冲窗体
                    if (M_uc_AutoFlush != null)
                    {
                        if (M_isFlush)
                        {
                            M_pauseFlush = false;
                            M_uc_AutoFlush.btnContinue_Click(M_uc_AutoFlush.btnContinue, new EventArgs());
                            //预冲时，发生报警，预冲暂停，[继续预冲]按键为可用状态;2016年9月9日
                            M_uc_AutoFlush.btnContinue.Enabled = false;
                        }
                        if (m_isAddFlush)
                        {
                            m_isAddFlush = true;
                            M_uc_AutoFlush.btnAddFlush_Click(M_uc_AutoFlush.btnAddFlush, new EventArgs());
                            M_uc_AutoFlush.btnAddFlush.Enabled = false;
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, ee.Message);
                return;
            }
        }
        void AddWarnToDataset(int _grade, string _code, string _content)
        {
            //添加报警记录
            Model.warnlog wlog = new Model.warnlog();
            wlog.grade = _grade;
            wlog.logtime = DateTime.Now;
            wlog.logdate = DateTime.Now.Date;
            wlog.warncode = _code;
            wlog.warntitle = _content;
            wlog.para1 = "-";
            wlog.para2 = "-";
            wlog.para3 = "-";
            wlog.sign = "-";
            BLL.warnlog blog = new BLL.warnlog();
            blog.Add(wlog);
        }

        private void RunSendWarnCmdTask()
        {
            m_ctsSendWarn = new CancellationTokenSource();
            m_taskSendWarn = TaskSendWarnCmd(m_ctsSendWarn.Token);
        }

        async Task TaskSendWarnCmd(CancellationToken cts)
        {
            //MessageBox.Show("响应报警:" + m_lstWarnActions.Count.ToString()); 
            await Task.Delay(TimeSpan.FromMilliseconds(50)).ConfigureAwait(false);
            for (int i = 0; i < m_lstWarnActions.Count; i++)
            {
                if (cts.IsCancellationRequested)
                {
                    break;
                }
                else
                {
                    SendOrder(m_lstWarnActions[i].SP, m_lstWarnActions[i].CMD);
                    //StringBuilder s = new StringBuilder();
                    //foreach (byte b in m_lstWarnActions[i].CMD)
                    //{
                    //    s.Append(b.ToString("X2") + " ");
                    //}
                    //this.txtRecieve.Text += (m_lstWarnActions[i].SP.PortName + ":" + s.ToString() + "\r\n");
                    //MessageBox.Show(m_lstWarnActions[i].SP.PortName + ":" + s.ToString());
                }
            }
        }

        private List<Cls.Model_SendCMD> lstReleaseCmd()
        {
            List<Cls.Model_SendCMD> _lstreleasecmd = new List<Cls.Model_SendCMD>();
            //byte[] b2 = Cls.Comm_Main.CmdAlarmLamp.AllVoiseClose;
            //_lstreleasecmd.Add(new Cls.Model_SendCMD(port_main, b2.Length, b2, 0));

            byte[] bn = Cls.Comm_Main.CmdAlarmLamp.AllLightClose;
            _lstreleasecmd.Add(new Cls.Model_SendCMD(port_main, bn.Length, bn, 0));

            byte[] b3 = Cls.Comm_Main.CmdAlarmLamp.GreenAlways;
            _lstreleasecmd.Add(new Cls.Model_SendCMD(port_main, b3.Length, b3, 0));
            //如果当前警报列表中不存在提示性报警
            //Cls.clsSysWarn csw = m_lstSysWarn.Find(m => m._ModelShowWarn.mwarncode.grade < 4);
            //MessageBox.Show(csw._ModelShowWarn.mwarncode.content.ToString());
            //解除时，根据模式和当前步骤进行夹管阀操作
            //if (csw != null)
            //{ 
            //如果是治疗，解除报警时打开抗凝剂泵，打开加热器,预冲时只打开加热器，在预冲界面继续预冲  
            byte[] bVstate = null;
            if (M_isTreat)
            {
                //开启sp第一遍命令
                byte[] b4 = Cls.Comm_SyringePump.Start(M_ModelTreat.SP_Speed.Value, M_ModelTreat.TargetSP.Value);
                _lstreleasecmd.Add(new Cls.Model_SendCMD(port_hpump, b4.Length, b4, 0));
                switch (M_modeName)
                {//如果在引血步骤，各个模式 夹管阀V3夹管
                    case "PE":
                        if (m_stepPE.wizardControl1.SelectedPage.TabIndex == 0)
                            bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01);
                        else
                            bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01);
                        break;
                    case "PP":
                        if (m_stepPP.wizardControl1.SelectedPage.TabIndex == 0)
                            bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01);
                        else
                            bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01);
                        break;
                    case "CHDF":
                        if (m_stepCHDF.wizardControl1.SelectedPage.TabIndex == 0)
                            bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01);
                        else
                            bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01);
                        break;
                    case "Li-ALS":
                        switch (m_stepLiALS.wizardControl1.SelectedPage.TabIndex)
                        {
                            case 0://引血
                                bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01);
                                break;
                            case 1://血浆置换
                            case 2://收集血浆
                                bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x00, 0x01);
                                break;
                            case 3://整体治疗
                            case 4://准备回收
                                bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x00);
                                break;
                        }
                        break;
                    case "PERT": //V5松开
                        switch (m_stepPERT.wizardControl1.SelectedPage.TabIndex)
                        {
                            case 0://置换引血
                            case 2://血滤引血
                            case 3://血浆置换回收
                                bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01);
                                break;
                            case 1://血浆置换治疗
                                bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01);
                                break;
                            case 4:
                                bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x00, 0x01);
                                break;
                        }
                        break;
                    case "PDF":
                        if (m_stepCHDF.wizardControl1.SelectedPage.TabIndex == 0)
                            bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01);
                        else
                            bVstate = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01);
                        break;
                }
                if (bVstate != null)
                    _lstreleasecmd.Add(new Cls.Model_SendCMD(port_main, bVstate.Length, bVstate, 0));
                //开启sp第二遍命令
                byte[] b5 = Cls.Comm_SyringePump.Start(M_ModelTreat.SP_Speed.Value, M_ModelTreat.TargetSP.Value);
                _lstreleasecmd.Add(new Cls.Model_SendCMD(port_hpump, b5.Length, b5, 0));
            }

            //if (M_isFlush)
            //{
            //    switch (M_modeName)
            //    {
            //        case "PE":
            //        case "PP":     
            //        case "CHDF":
            //        case "PERT":
            //        case "PDF":
            //            byte[] b9 = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01);
            //            _lstreleasecmd.Add(new Cls.Model_SendCMD(port_main, b9.Length, b9, 0));
            //            break;
            //        case "Li-ALS":
            //            b9 = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x00);
            //            _lstreleasecmd.Add(new Cls.Model_SendCMD(port_main, b9.Length, b9, 0));
            //            break;
            //    }
            //}
            //}
            //}
            return _lstreleasecmd;
        }
        //采血压预报警解除后 处理命令设置
        //wss 2016年1月6日
        //private List<Cls.Model_SendCMD> lstReleaseCmd_Pacc()
        //{
        //    List<Cls.Model_SendCMD> _lstreleasecmd_Pacc = new List<Cls.Model_SendCMD>();
        //    if (M_exitsPreWarn_Pacc)
        //    {
        //        //夹管阀状态命令设置
        //        switch (M_modeName)
        //        {
        //            case "PE":
        //            case "PP":   //添加PP模式下 预报警解除后，夹管阀动作 wss 2016年2月19日
        //            case "CHDF":
        //                byte[] b9 = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01);
        //                _lstreleasecmd_Pacc.Add(new Cls.Model_SendCMD(port_main, b9.Length, b9, 0));
        //                break;
        //            case "Li-ALS":
        //                b9 = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x00, 0x01);
        //                _lstreleasecmd_Pacc.Add(new Cls.Model_SendCMD(port_main, b9.Length, b9, 0));
        //                break;
        //        }
        //        //泵状态命令设置
        //        //Bp状态获取 BP速度大于1&当前模式下BP为有效状态
        //        if (M_PumpState.BPState.Speed > 1 && M_ModelTreat.BPValid)
        //        {
        //            byte[] b = Cls.Comm_PeristalticPump.Command(0x01, M_PumpState.BPState.Speed, true,true);
        //            Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
        //            _lstreleasecmd_Pacc.Add(cmd);
        //        }
        //        //FP状态获取 FP速度大于1&当前模式下FP为有效状态
        //        if (M_PumpState.FPState.Speed > 1 && M_ModelTreat.FPValid)
        //        {
        //            byte[] b = Cls.Comm_PeristalticPump.Command(0x02, M_PumpState.FPState.Speed, true,true);
        //            Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
        //            _lstreleasecmd_Pacc.Add(cmd);
        //        }
        //        //DP状态获取 DP速度大于1&当前模式下DP为有效状态
        //        if (M_PumpState.DPState.Speed > 1 && M_ModelTreat.DPValid)
        //        {
        //            byte[] b = Cls.Comm_PeristalticPump.Command(0x03, M_PumpState.DPState.Speed, true,false);
        //            Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
        //            _lstreleasecmd_Pacc.Add(cmd);
        //        }
        //        //RP状态获取 RP速度大于1&当前模式下RP为有效状态
        //        if (M_PumpState.RPState.Speed > 1 && M_ModelTreat.RPValid)
        //        {
        //            byte[] b = Cls.Comm_PeristalticPump.Command(0x04, M_PumpState.RPState.Speed, true,false);
        //            Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
        //            _lstreleasecmd_Pacc.Add(cmd);
        //        }
        //        //FP2状态获取 FP2速度大于1&当前模式下FP2为有效状态
        //        if (M_PumpState.FP2State.Speed > 1 && M_ModelTreat.FP2Valid)
        //        {
        //            byte[] b = Cls.Comm_PeristalticPump.Command(0x05, M_PumpState.FP2State.Speed, true,false);
        //            Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
        //            _lstreleasecmd_Pacc.Add(cmd);
        //        }
        //        //CP状态获取 CP速度大于1&当前模式下CP为有效状态
        //        if (M_PumpState.CPState.Speed > 1 && M_ModelTreat.CPValid)
        //        {
        //            byte[] b = Cls.Comm_PeristalticPump.Command(0x06, M_PumpState.CPState.Speed, true,true);
        //            Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
        //            _lstreleasecmd_Pacc.Add(cmd);
        //        }
        //    }
        //    return _lstreleasecmd_Pacc;
        //}

        private void SetOtherfrmBtnState(Cls.Model_State pumpState)
        {
            if (M_ModelTreat.BPValid)
            {
                //流量界面
                M_uc_SetFlow.palBP.Enabled = true;
                M_uc_SetFlow.btnRun1.Text = (pumpState.BPState.Runing ? "停止" : "运转");
                M_uc_SetFlow.chkV2.Enabled = M_uc_SetFlow.chkV1.Enabled = (pumpState.BPState.Runing ? false : true);
                M_uc_SetFlow.btnRun1.Image = (pumpState.BPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_SetFlow.btnRun1.ForeColor = (pumpState.BPState.Runing ? Color.Red : Color.White);
                M_uc_SetFlow.txtBP.Enabled = (pumpState.BPState.Runing ? false : true);
                //回收界面  
                M_uc_Recycle.btnRunBP.Enabled = true;
                M_uc_Recycle.btnRunBP.Text = (pumpState.BPState.Runing ? "停止" : "运转");
                M_uc_Recycle.chkV2.Enabled = M_uc_Recycle.chkV1.Enabled = (pumpState.BPState.Runing ? false : true);
                M_uc_Recycle.btnRunBP.Image = (pumpState.BPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_Recycle.btnRunBP.ForeColor = (pumpState.BPState.Runing ? Color.Red : Color.White);
                M_uc_Recycle.lblBP.Enabled = (pumpState.BPState.Runing ? false : true);
            }
            else
            {
                M_uc_SetFlow.palBP.Enabled = false;
                M_uc_Recycle.btnRunBP.Enabled = false;
            }

            if (M_ModelTreat.FPValid)
            {
                M_uc_SetFlow.palFP.Enabled = true;
                M_uc_SetFlow.btnRun2.Text = (pumpState.FPState.Runing ? "停止" : "运转");
                M_uc_SetFlow.btnRun2.Image = (pumpState.FPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_SetFlow.btnRun2.ForeColor = (pumpState.FPState.Runing ? Color.Red : Color.White);
                M_uc_SetFlow.txtFP.Enabled = (pumpState.FPState.Runing ? false : true);
                //回收界面
                M_uc_Recycle.btnRunFP.Enabled = true;
                M_uc_Recycle.btnRunFP.Text = (pumpState.FPState.Runing ? "停止" : "运转");
                M_uc_Recycle.btnRunFP.Image = (pumpState.FPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_Recycle.btnRunFP.ForeColor = (pumpState.FPState.Runing ? Color.Red : Color.White);
                M_uc_Recycle.lblFP.Enabled = (pumpState.FPState.Runing ? false : true);
            }
            else
            {
                M_uc_SetFlow.palFP.Enabled = false;
                M_uc_Recycle.btnRunFP.Enabled = false;
            }

            if (M_ModelTreat.DPValid)
            {
                M_uc_SetFlow.palDP.Enabled = true;
                M_uc_SetFlow.btnRun3.Text = (pumpState.DPState.Runing ? "停止" : "运转");
                M_uc_SetFlow.btnRun3.Image = (pumpState.DPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_SetFlow.btnRun3.ForeColor = (pumpState.DPState.Runing ? Color.Red : Color.White);
                M_uc_SetFlow.txtDP.Enabled = (pumpState.DPState.Runing ? false : true);
                //回收界面
                M_uc_Recycle.btnRunDP.Enabled = true;
                M_uc_Recycle.btnRunDP.Text = (pumpState.DPState.Runing ? "停止" : "运转");
                M_uc_Recycle.btnRunDP.Image = (pumpState.DPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_Recycle.btnRunDP.ForeColor = (pumpState.DPState.Runing ? Color.Red : Color.White);
                M_uc_Recycle.lblDP.Enabled = (pumpState.DPState.Runing ? false : true);
            }
            else
            {
                M_uc_SetFlow.palDP.Enabled = false;
                M_uc_Recycle.btnRunDP.Enabled = false;
            }

            if (M_ModelTreat.RPValid)
            {
                M_uc_SetFlow.palRP.Enabled = true;
                M_uc_SetFlow.btnRun4.Text = (pumpState.RPState.Runing ? "停止" : "运转");
                M_uc_SetFlow.btnRun4.Image = (pumpState.RPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_SetFlow.btnRun4.ForeColor = (pumpState.RPState.Runing ? Color.Red : Color.White);
                M_uc_SetFlow.txtRP.Enabled = (pumpState.RPState.Runing ? false : true);
                //回收界面
                M_uc_Recycle.btnRunRP.Enabled = true;
                M_uc_Recycle.btnRunRP.Text = (pumpState.RPState.Runing ? "停止" : "运转");
                M_uc_Recycle.btnRunRP.Image = (pumpState.RPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_Recycle.btnRunRP.ForeColor = (pumpState.RPState.Runing ? Color.Red : Color.White);
                M_uc_Recycle.lblRP.Enabled = (pumpState.RPState.Runing ? false : true);

            }
            else
            {
                M_uc_SetFlow.palRP.Enabled = false;
                M_uc_Recycle.btnRunRP.Enabled = false;
            }

            if (M_ModelTreat.FP2Valid)
            {
                M_uc_SetFlow.palFP2.Enabled = true;
                M_uc_SetFlow.btnRun5.Text = (pumpState.FP2State.Runing ? "停止" : "运转");
                M_uc_SetFlow.btnRun5.Image = (pumpState.FP2State.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_SetFlow.btnRun5.ForeColor = (pumpState.FP2State.Runing ? Color.Red : Color.White);
                M_uc_SetFlow.txtFP2.Enabled = (pumpState.FP2State.Runing ? false : true);
                //回收界面
                M_uc_Recycle.btnRunFP2.Enabled = true;
                M_uc_Recycle.btnRunFP2.Text = (pumpState.FP2State.Runing ? "停止" : "运转");
                M_uc_Recycle.btnRunFP2.Image = (pumpState.FP2State.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_Recycle.btnRunFP2.ForeColor = (pumpState.FP2State.Runing ? Color.Red : Color.White);
                M_uc_Recycle.lblFP2.Enabled = (pumpState.FP2State.Runing ? false : true);
            }
            else
            {
                M_uc_SetFlow.palFP2.Enabled = false;
                M_uc_Recycle.btnRunFP2.Enabled = false;
            }

            if (M_ModelTreat.CPValid)
            {
                M_uc_SetFlow.palCP.Enabled = true;
                M_uc_SetFlow.btnRun6.Text = (pumpState.CPState.Runing ? "停止" : "运转");
                M_uc_SetFlow.btnRun6.Image = (pumpState.CPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_SetFlow.btnRun6.ForeColor = (pumpState.CPState.Runing ? Color.Red : Color.White);
                M_uc_SetFlow.txtCP.Enabled = (pumpState.CPState.Runing ? false : true);
                //回收界面
                M_uc_Recycle.btnRunCP.Enabled = true;
                M_uc_Recycle.btnRunCP.Text = (pumpState.CPState.Runing ? "停止" : "运转");
                M_uc_Recycle.btnRunCP.Image = (pumpState.CPState.Runing ? Properties.Resources.spstop : Properties.Resources.spstart);
                M_uc_Recycle.btnRunCP.ForeColor = (pumpState.CPState.Runing ? Color.Red : Color.White);
                M_uc_Recycle.lblCP.Enabled = (pumpState.CPState.Runing ? false : true);
            }
            else
            {
                M_uc_SetFlow.palCP.Enabled = false;
                M_uc_Recycle.btnRunCP.Enabled = false;
            }
            //手动预冲&两按键显示状态为true时，[返回选择]和[预冲完成]按键显示状态
            //wss 2016年2月19日
            if (M_SelFlushType == 2 && M_uc_SetFlow.btnReturn.Visible && M_uc_SetFlow.btnConfirmM.Visible)
            {
                M_uc_SetFlow.palDehydration.Enabled = false;
                M_uc_SetFlow.btnReturn.Enabled = M_uc_SetFlow.btnConfirmM.Enabled = GetBtnState(pumpState) ? true : false;
            }
            M_uc_SetFlow.Refresh();
        }
        //手动预冲时 [返回选择][预冲完成]按键状态获取
        //wss 2016年1月14日
        private bool GetBtnState(Cls.Model_State _modPumpState)
        {
            bool btnstate = false;
            if (_modPumpState.BPState.Runing || _modPumpState.CPState.Runing || _modPumpState.DPState.Runing
                || _modPumpState.FP2State.Runing || _modPumpState.FPState.Runing || _modPumpState.RPState.Runing)
                btnstate = false;
            else
                btnstate = true;
            return btnstate;
        }
        private List<Cls.Model_SendCMD> lstStartPumpCMD()
        {
            List<Cls.Model_SendCMD> lstStartpumpcmd = new List<Cls.Model_SendCMD>();

            //SP命令
            byte[] b3 = Cls.Comm_SyringePump.Start(M_ModelTreat.SP_Speed.Value, M_ModelTreat.TargetSP.Value);

            if (!M_isFlush)
            {
                lstStartpumpcmd.Add(new Cls.Model_SendCMD(port_hpump, b3.Length, b3, 0));
            }

            if (M_isTreat)
            {
                //气泡检测开             
                byte[] ad1 = Cls.Comm_Main.CmdBubble.OpenBubble1;
                byte[] ad2 = Cls.Comm_Main.CmdBubble.OpenBubble2;
                byte[] ad3 = Cls.Comm_Main.CmdBubble.OpenBubble3;

                //气泡检测开启命令
                //wss 2016年3月4日
                switch (M_modeName)
                {
                    case "PE":          //AD1,AD3
                        lstStartpumpcmd.Add(new Cls.Model_SendCMD(port_main, ad1.Length, ad1, 0));
                        lstStartpumpcmd.Add(new Cls.Model_SendCMD(port_main, ad3.Length, ad3, 0)); break;
                    case "PP":         //AD1
                        lstStartpumpcmd.Add(new Cls.Model_SendCMD(port_main, ad1.Length, ad1, 0)); break;
                    case "CHDF":
                    case "PDF":
                    case "Li-ALS":     //AD1,AD2,AD3
                    case "PERT":
                        lstStartpumpcmd.Add(new Cls.Model_SendCMD(port_main, ad1.Length, ad1, 0));
                        lstStartpumpcmd.Add(new Cls.Model_SendCMD(port_main, ad2.Length, ad2, 0));
                        lstStartpumpcmd.Add(new Cls.Model_SendCMD(port_main, ad3.Length, ad3, 0)); break;
                    default: break;
                }
            }

            if (M_ModelTreat.BPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x01, m_leadBloodSpeed, true, true);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
            }
            if (M_ModelTreat.FPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
            }
            if (M_ModelTreat.DPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
            }
            if (M_ModelTreat.RPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed.Value, true, false);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
            }
            if (M_ModelTreat.FP2Valid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x05, M_ModelTreat.FP2Speed.Value, true, false);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
            }
            if (M_ModelTreat.CPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x06, M_ModelTreat.CPSpeed.Value, true, true);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
            }

            //肝素泵第二次命令
            if (!M_isFlush)
            {
                lstStartpumpcmd.Add(new Cls.Model_SendCMD(port_hpump, b3.Length, b3, 0));
            }
            return lstStartpumpcmd;
        }

        private List<Cls.Model_SendCMD> lstStartPumpStateCMD()
        {
            List<Cls.Model_SendCMD> lstStartpumpcmd = new List<Cls.Model_SendCMD>();
            if (M_ModelTreat.BPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x01, M_PumpState.BPState.Speed, true, true);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
            }
            if (M_ModelTreat.FPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x02, M_PumpState.FPState.Speed, true, true);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
            }
            if (M_ModelTreat.DPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x03, M_PumpState.DPState.Speed, true, false);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
                //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed, true, M_ModelTreat.DPDirection));
            }
            if (M_ModelTreat.RPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x04, M_PumpState.RPState.Speed, true, false);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
                //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed, true, M_ModelTreat.RPDirection));
            }
            if (M_ModelTreat.FP2Valid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x05, M_PumpState.FP2State.Speed, true, false);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
                //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelTreat.FP2Speed, true, M_ModelTreat.FP2Direction));
            }
            if (M_ModelTreat.CPValid)
            {
                byte[] b = Cls.Comm_PeristalticPump.Command(0x06, M_PumpState.CPState.Speed, true, true);
                Cls.Model_SendCMD cmd = new Cls.Model_SendCMD(port_ppump, b.Length, b, 0);
                lstStartpumpcmd.Add(cmd);
                //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelTreat.CPSpeed , true, M_ModelTreat.CPDirection));
            }
            return lstStartpumpcmd;
        }


        void StopPump()
        {
            //停止泵
            // SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
            //添加取消任务
            //wss 2016年3月10日
            if (m_taskStartPump != null)
                m_ctsStartPump.Cancel();
            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
            //非预冲状态时发送加热和SP停止命令
            if (!M_isFlush)
            {
                //停止加热
                //SendOrder(port_main, Cls.Comm_Main.CmdTemperature.StopHT);
                //停止SP
                SendOrder(port_hpump, Cls.Comm_SyringePump.Stop);
            }
            //SetOtherfrmBtnState(M_PumpState);
#if LOG_SYSTEM
            getLog.WriteLogFile("frmMain,1345,StopPump");
#endif
            //SetAllPumpState(null);
            if (M_uc_SetFlow != null)
            {
                M_uc_SetFlow.btnRun1.Text = M_uc_SetFlow.btnRun2.Text = M_uc_SetFlow.btnRun3.Text = M_uc_SetFlow.btnRun4.Text = M_uc_SetFlow.btnRun5.Text = M_uc_SetFlow.btnRun6.Text = "运转";
                M_uc_SetFlow.btnRun1.Image = M_uc_SetFlow.btnRun2.Image = M_uc_SetFlow.btnRun3.Image = M_uc_SetFlow.btnRun4.Image = M_uc_SetFlow.btnRun5.Image = M_uc_SetFlow.btnRun6.Image = Properties.Resources.spstart;
                M_uc_SetFlow.btnRun1.ForeColor = M_uc_SetFlow.btnRun2.ForeColor = M_uc_SetFlow.btnRun3.ForeColor = M_uc_SetFlow.btnRun4.ForeColor = M_uc_SetFlow.btnRun5.ForeColor = M_uc_SetFlow.btnRun6.ForeColor = Color.White;
                M_uc_SetFlow.btnConfirmM.Enabled = M_uc_SetFlow.btnReturn.Enabled = true;
            }
        }
        //private void CheckStartUP()
        //{
        //    //Thread.Sleep(TimeSpan.FromSeconds(0.5));
        //    //CheckBloodAndPressure();
        //    Thread.Sleep(TimeSpan.FromSeconds(0.2));
        //    CheckAlarmLamp();
        //    Thread.Sleep(TimeSpan.FromSeconds(0.2));
        //    OpenAD();
        //    Thread.Sleep(TimeSpan.FromSeconds(0.2));
        //    //CheckPPump();
        //    //Thread.Sleep(TimeSpan.FromSeconds(0.5));
        //    SendOrder(port_main, Cls.Comm_Main.startTransData);
        //}

        //void OpenAD()
        //{
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Down))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A1-1通电正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("A1-1通电正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A1-1通电失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("A1-1通电失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.5));
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopDown))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A1-2通电正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("A1-2通电正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A1-2通电失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("A1-2通电失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.5));
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Down))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A2-1通电正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("A2-1通电正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A2-1通电失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("A2-1通电失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.5));
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopDown))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A2-2通电正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("A2-2通电正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A2-2通电失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("A2-2通电失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.5));
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Down))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A3-1通电正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("A3-1通电正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A3-1通电失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("A3-1通电失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.5));
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopDown))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A3-2通电正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("A3-2通电正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A3-2通电失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("A3-2通电失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.5));

        //}

        /// <summary>
        /// 检测蜂鸣器
        /// </summary>
        void CheckBuzzer()
        {
            ////开启蜂鸣器 
            //Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测蜂鸣器开启...");
            //if (SendOrderBack(port_main, Cls.Comm_Main.CmdAlarm.OpenVoice1))
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蜂鸣器声音1测试:正常!", Cls.TypeOfMessage.Success);
            //    M_lst_startLog.Add(GetLog("蜂鸣器声音1测试:正常!", Color.Green));
            //}
            //else
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蜂鸣器开启:失败!", Cls.TypeOfMessage.Error);
            //    M_lst_startLog.Add(GetLog("蜂鸣器开启:失败!", Color.Red));
            //    M_isError = true;
            //}
            //关闭蜂鸣器  
            //Thread.Sleep(TimeSpan.FromSeconds(0.3));
            //Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测蜂鸣器关闭...");
            //if (SendOrderBack(port_main, Cls.Comm_Main.CmdAlarm.CloseVoice1))
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蜂鸣器关闭:正常!", Cls.TypeOfMessage.Success);
            //    M_lst_startLog.Add(GetLog("蜂鸣器关闭:正常!", Color.Green));
            //}
            //else
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蜂鸣器关闭:失败!", Cls.TypeOfMessage.Error);
            //    M_lst_startLog.Add(GetLog("蜂鸣器关闭:失败!", Color.Red));
            //    M_isError = true;
            //}
        }
        /// <summary>
        /// 检测注射泵
        /// </summary>
        //void CheckPPump()
        //{
        //    //检测注射泵
        //    //Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测注射泵...");
        //    //if (SendOrder(port_hpump, Cls.Comm_SyringePump.TestSN(0x0001)))
        //    //{
        //    //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]注射泵:正常!", Cls.TypeOfMessage.Success);
        //    //    M_lst_startLog.Add(GetLog("注射泵:正常!", Color.Green));
        //    //}
        //    //else
        //    //{
        //    //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]注射泵:错误!", Cls.TypeOfMessage.Error);
        //    //    M_lst_startLog.Add(GetLog("注射泵:错误!", Color.Red));
        //    //    M_isError = true;
        //    //}             
        //    if (SendOrderBackPump(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true)))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蠕动泵:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("蠕动泵:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蠕动泵通讯错误!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("蠕动泵通讯错误!", Color.Red));
        //        M_isError = true;
        //    }
        //}

        /// <summary>
        /// 检测气泵
        /// </summary>
        //void CheckAirePump()
        //{
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测气泵1开启...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Up))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵1开启:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("气泵1开启:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵1开启:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("气泵1开启:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测气泵1关闭...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopUp))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵1关闭:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("气泵1关闭:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵1关闭:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("气泵1关闭:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测气泵2开启...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Up))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵2开启:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("气泵2开启:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵2开启:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("气泵2开启:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测气泵2关闭...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopUp))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵2关闭:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("气泵2关闭:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵2关闭:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("气泵2关闭:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测气泵3开启...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Up))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵3开启:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("气泵3开启:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵3开启:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("气泵3开启:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测气泵3关闭...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopUp))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵3关闭:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("气泵3关闭:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵3关闭:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("气泵3关闭:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //}

        void CheckBloodAndPressure()
        {
            //if (SendOrder(port_main, Cls.Comm_Main.CmdBloodLeak.CloseBloodLeak))
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]漏血检测正常!", Cls.TypeOfMessage.Success);
            //    M_lst_startLog.Add(GetLog("漏血检测正常!", Color.Green));
            //}
            //else
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]漏血检测失败!", Cls.TypeOfMessage.Error);
            //    M_lst_startLog.Add(GetLog("漏血检测失败!", Color.Red));
            //    M_isError = true;
            //}
            //Thread.Sleep(TimeSpan.FromSeconds(0.5));
            //if (SendOrder(port_main, Cls.Comm_Main.CmdPressure.ClosePressure))
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]压力检测正常!", Cls.TypeOfMessage.Success);
            //    M_lst_startLog.Add(GetLog("压力检测正常!", Color.Green));
            //}
            //else
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]压力检测失败!", Cls.TypeOfMessage.Error);
            //    M_lst_startLog.Add(GetLog("压力检测失败!", Color.Red));
            //    M_isError = true;
            //}
            //Thread.Sleep(TimeSpan.FromSeconds(0.5));
        }

        /// <summary>
        /// 检测报警灯
        /// </summary>
        void CheckAlarmLamp()
        {
            //红灯
            /*
            Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测报警灯 红灯闪烁...");
            if (SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.RedTwinkle))
            {
                Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]红灯闪烁:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("红灯闪烁:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]红灯闪烁:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("红灯闪烁:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(TimeSpan.FromSeconds(0.3));
            Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测报警灯 红灯关闭...");
            if (SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.RedClose))
            {
                Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]红灯关闭:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("红灯关闭:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]红灯关闭:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("红灯关闭:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(TimeSpan.FromSeconds(0.3));
             * */
            //绿灯 
            //if (SendOrderBack(port_main, Cls.Comm_Main.CmdAlarmLamp.GreenTwinkle))
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]绿灯闪烁:正常!", Cls.TypeOfMessage.Success);
            //    M_lst_startLog.Add(GetLog("绿灯闪烁:正常!", Color.Green));
            //}
            //else
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]绿灯闪烁:失败!", Cls.TypeOfMessage.Error);
            //    M_lst_startLog.Add(GetLog("绿灯闪烁:失败!", Color.Red));
            //    M_isError = true;
            //}
            //Thread.Sleep(TimeSpan.FromSeconds(0.3));
            //if (SendOrderBack(port_main, Cls.Comm_Main.CmdAlarmLamp.GreenClose))
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]绿灯关闭:正常!", Cls.TypeOfMessage.Success);
            //    M_lst_startLog.Add(GetLog("绿灯关闭:正常!", Color.Green));
            //}
            //else
            //{
            //    Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]绿灯关闭:失败!", Cls.TypeOfMessage.Error);
            //    M_lst_startLog.Add(GetLog("绿灯关闭:失败!", Color.Red));
            //    M_isError = true;
            //}
            //黄灯
            /*
            Thread.Sleep(TimeSpan.FromSeconds(0.3));
            Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测报警灯 黄灯闪烁...");
            if (SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.YellowTwinkle))
            {
                Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]黄灯闪烁:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("黄灯闪烁:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]黄灯闪烁:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("黄灯闪烁:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(TimeSpan.FromSeconds(0.3));
            Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测报警灯 黄灯关闭...");
            if (SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.YellowClose))
            {
                Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]黄灯关闭:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("黄灯关闭:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]黄灯关闭:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("黄灯关闭:失败!", Color.Red));
                M_isError = true;
            }
             * */
        }

        /// <summary>
        /// 检测夹管阀
        /// </summary>
        //void CheckValve()
        //{
        //    #region 夹管阀1
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀1开...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.ClampV1))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀1夹管:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("夹管阀1夹管:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀1夹管:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("夹管阀1夹管:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀1关...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.LoosenV1))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀1松开:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("夹管阀1松开:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀1松开:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("夹管阀1松开:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    #endregion

        //    #region  夹管阀2
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀2夹管...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.ClampV2))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀2夹管:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("夹管阀2夹管:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀2夹管:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("夹管阀2夹管:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀2松开...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.LoosenV2))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀2松开:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("夹管阀2松开:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀2松开:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("夹管阀2松开:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    #endregion

        //    #region 夹管阀3
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀3夹管...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.ClampV3))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀3夹管:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("夹管阀3夹管:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀3夹管:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("夹管阀3夹管:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀3松开...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.LoosenV3))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀3松开:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("夹管阀3松开:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀3松开:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("夹管阀3松开:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    #endregion

        //    #region 夹管阀4
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀4夹管...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.ClampV4))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀4夹管:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("夹管阀4夹管:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀4夹管:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("夹管阀4夹管:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    Cls.SplashScreen.UpdateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀4松开...");
        //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.LoosenV4))
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀4松开:正常!", Cls.TypeOfMessage.Success);
        //        M_lst_startLog.Add(GetLog("夹管阀4松开:正常!", Color.Green));
        //    }
        //    else
        //    {
        //        Cls.SplashScreen.UpdateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀4松开:失败!", Cls.TypeOfMessage.Error);
        //        M_lst_startLog.Add(GetLog("夹管阀4松开:失败!", Color.Red));
        //        M_isError = true;
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(0.3));
        //    #endregion
        //}

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="_info"></param>
        /// <param name="_infoColor"></param>
        /// <returns></returns>
        Cls.utils.sysStartLog GetLog(string _info, Color _infoColor)
        {
            Cls.utils.sysStartLog log = new Cls.utils.sysStartLog();
            log.InfoColor = _infoColor;
            log.StartInfo = _info + "\r\n";
            log.StartTime = DateTime.Now;
            return log;
        }

        /// <summary>
        ///
        /// </summary>
        //int ClearMemoryCount = 1;
        void StartTransData()
        {
            M_isTreat = false;
            M_isStart = true;
            m_ctsReadValue = new CancellationTokenSource();
            m_taskReadValue = TaskReadValue(m_ctsReadValue.Token);
            Task tSendCmd = TaskSendCmd(m_ctsReadValue.Token);
        }

        async Task TaskSendCmd(CancellationToken ct)
        {
            while (M_isStart)
            {
                if (ct.IsCancellationRequested)
                    break;
                else
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(500)).ConfigureAwait(false);
                    SendCmd();
                }
            }
        }

        void SendCmd()
        {
            //发送读取数据命令
            //SendOrder(port_data, Cls.Comm_Main.startTransData);
            //发送读取抗凝剂泵状态命令
            //if (m_frmAdmin == null)
            //{

            //串口2读取数据关闭时，不发送联络帧  2016年8月26日
            if (M_isTreat && M_Closing_hpump == false)
                SendOrder(port_hpump, Cls.Comm_SyringePump.GetStatus);
            //}
            //心跳包
            //SendOrder(port_pumpstatus, Cls.Comm_pumpstatus.cmdHearBeat);
        }

        //监控传感器量程和读取现有值
        async Task TaskReadValue(CancellationToken cts)
        {
            while (M_isStart)
            {
                if (cts.IsCancellationRequested)
                    break;
                else
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(200)).ConfigureAwait(false);
                    m_circleNum++;
                    //保存采集数据，治疗时,大概隔5秒保存一次数据
                    if (M_isTreat && m_circleNum >= 25)
                    {
                        m_circleNum = 0;
                        SaveData();
                    }
                    //判断静音计时器是否达到2分钟，达到2分钟重新发送报警音
                    //2016年5月18日 wss
                    if (m_watchUnreleaseWarn.IsRunning && m_watchUnreleaseWarn.ElapsedMilliseconds >= 120000)
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.Alarm1);
                        m_watchUnreleaseWarn.Reset();
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        #region 治疗界面
                        if (M_uc_Treat != null && this.palContent.Controls.IndexOf(M_uc_Treat) == 0)
                            ShowTreatFormInfo();
                        #endregion

                        #region 其他设置界面
                        if (M_uc_OtherSet != null && this.palContent.Controls.IndexOf(M_uc_OtherSet) == 0)
                        {
                            ShowOtherFormInfo();
                        }
                        #endregion

                        #region 累积界面
                        if (M_uc_Sum != null)
                        {
                            //累计值显示         
                            //MessageBox.Show(M_ModelTotal.TotalSP.ToString());
                            M_uc_Sum.lblTotalTime.Text = Cls.utils.SecondsToTime(M_ModelTotal.TotalTime);  // M_ModelTotal.TotalTime.Hours.ToString("00") + ":" + M_ModelTotal.TotalTime.Minutes.ToString("00") + ":" + M_ModelTotal.TotalTime.Seconds.ToString("00");
                            M_uc_Sum.lblTotalBP.Text = M_ModelTotal.TotalBP.ToString("f3");
                            M_uc_Sum.lblTotalRP.Text = M_ModelTotal.TotalRP.ToString("f3");
                            M_uc_Sum.lblTotalFP.Text = M_ModelTotal.TotalFP.ToString("f3");
                            M_uc_Sum.lblTotalDP.Text = M_ModelTotal.TotalDP.ToString("f3");
                            M_uc_Sum.lblTotalSP.Text = M_ModelTotal.TotalSP.ToString("f1");
                        }
                        #endregion

                        #region 自动预冲界面
                        if (M_uc_AutoFlush != null && this.palContent.Controls.IndexOf(M_uc_AutoFlush) == 0)
                        {
                            //M_uc_AutoFlush.lblCurrent.Text = (M_ModelValue.M_flt_Weigh2 - startWeigh2).ToString("f0");
                        }
                        #endregion

                        #region 流量界面
                        if (M_uc_SetFlow != null && this.palContent.Controls.IndexOf(M_uc_SetFlow) == 0)
                        {
                            M_uc_SetFlow.txtBP.Text = M_ModelTreat.BPSpeed.ToString();
                        }
                        #endregion

                        #region 本主界面
                        //血泵累计值
                        if (M_isTreat)
                            this.lblTotalBP.Text = "∑: " + M_ModelTotal.TotalBP.ToString("f2") + " L"; 
                        this.lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");// +" CPU:" + GetCPUTemperature().ToString("f1") + " ℃";
                        this.tsbtnHT.Text = M_ModelValue.M_flt_Temperature.ToString("f1") + " ℃";
                        //this.lblpaccdec.Text = M_ModelValue.M_flt_PaccDecrement.ToString("f1");
                        //如果界面存在各压力值显示
                        this.uc_pacc._Value = M_ModelValue.M_flt_PofPacc.ToString("0.0");
                        this.uc_part._Value = M_ModelValue.M_flt_PofPart.ToString("0.0");
                        this.uc_pven._Value = M_ModelValue.M_flt_PofPven.ToString("0.0");
                        this.uc_p1st._Value = M_ModelValue.M_flt_PofP1st.ToString("0.0");
                        if (this.uc_p2nd.Enabled)
                            this.uc_p2nd._Value = M_ModelValue.M_flt_PofP2nd.ToString("0.0");
                        if (this.uc_p3rd.Enabled)
                            this.uc_p3rd._Value = M_ModelValue.M_flt_PofP3rd.ToString("0.0");
                        this.uc_ptmp._Value = M_ModelValue.M_flt_PofTMP.ToString("0.0");

                        //压力值显示彩条
                        if (M_ModelValue.M_flt_PofPacc <= this.uc_pacc.colorSliderBar1._Max && M_ModelValue.M_flt_PofPacc >= this.uc_pacc.colorSliderBar1._Min)
                            this.uc_pacc.colorSliderBar1._Value = (int)M_ModelValue.M_flt_PofPacc;
                        if (M_ModelValue.M_flt_PofPart <= this.uc_part.colorSliderBar1._Max && M_ModelValue.M_flt_PofPart >= this.uc_part.colorSliderBar1._Min)
                            this.uc_part.colorSliderBar1._Value = (int)M_ModelValue.M_flt_PofPart;
                        if (M_ModelValue.M_flt_PofPven <= this.uc_pven.colorSliderBar1._Max && M_ModelValue.M_flt_PofPven >= this.uc_pven.colorSliderBar1._Min)
                            this.uc_pven.colorSliderBar1._Value = (int)M_ModelValue.M_flt_PofPven;
                        if (M_ModelValue.M_flt_PofTMP <= this.uc_ptmp.colorSliderBar1._Max && M_ModelValue.M_flt_PofTMP >= this.uc_ptmp.colorSliderBar1._Min)
                            this.uc_ptmp.colorSliderBar1._Value = (int)M_ModelValue.M_flt_PofTMP;
                        if (M_ModelValue.M_flt_PofP1st <= this.uc_p1st.colorSliderBar1._Max && M_ModelValue.M_flt_PofP1st >= this.uc_p1st.colorSliderBar1._Min)
                            this.uc_p1st.colorSliderBar1._Value = (int)M_ModelValue.M_flt_PofP1st;
                        if (M_ModelValue.M_flt_PofP2nd <= this.uc_p2nd.colorSliderBar1._Max && M_ModelValue.M_flt_PofP2nd >= this.uc_p2nd.colorSliderBar1._Min)
                            this.uc_p2nd.colorSliderBar1._Value = (int)M_ModelValue.M_flt_PofP2nd;
                        if (M_ModelValue.M_flt_PofP3rd <= this.uc_p3rd.colorSliderBar1._Max && M_ModelValue.M_flt_PofP3rd >= this.uc_p3rd.colorSliderBar1._Min)
                            this.uc_p3rd.colorSliderBar1._Value = (int)M_ModelValue.M_flt_PofP3rd;
                        #endregion

                        #region 管理界面
                        if (m_frmAdmin != null)
                        {
                            ShowAdminFormInfo();
                        }
                        #endregion

                        #region 管理电源

                        if (M_ModelValue.M_flt_VCodeBB != 0)
                        {
                            double percent = M_ModelValue.M_flt_VCodeCC * 1.0 / M_ModelValue.M_flt_VCodeBB * 1.0;
                            int barvalue = (int)(percent * 100);
                            if (barvalue > 100) barvalue = 100;
                            if (barvalue < 0) barvalue = 0;
                            //放电状态
                            if (M_ModelValue.M_flt_DisChar == 0 || M_realVCode <= 1000000)
                            {
                                if (percent <= 0.1)
                                {
                                    this.lblElectric.Text = "电量低于:";
                                    //ShowWarn("W3-04");
                                }
                                else if (percent <= 0.2 && percent >= 0.1)
                                {
                                    this.lblElectric.Text = "电量低于:";
                                }
                                else
                                {
                                    this.lblElectric.Text = "剩余电量:";
                                }
                                progressBar.Value = barvalue;
                            }
                            //充电状态
                            if (M_ModelValue.M_flt_DisChar == 1 || M_realVCode > 1000000)
                            {
                                if (percent == 1)
                                {
                                    this.lblElectric.Text = "电量充满:";
                                    progressBar.Value = 100;
                                }
                                else
                                {
                                    this.lblElectric.Text = "正在充电:";
                                    progressBar.Value = barvalue;
                                }
                            }
                        }
                        #endregion

                        #region 处理警报的界面
                        if (m_frmDealWarn != null)
                        {
                            m_frmDealWarn.uc_P1st._Value = M_ModelValue.M_flt_PofP1st.ToString("f1");
                            m_frmDealWarn.uc_Pacc._Value = M_ModelValue.M_flt_PofPacc.ToString("f1");
                            m_frmDealWarn.uc_Part._Value = M_ModelValue.M_flt_PofPart.ToString("f1");
                            m_frmDealWarn.uc_Pven._Value = M_ModelValue.M_flt_PofPven.ToString("f1");
                        }
                        #endregion

                    }));

                    #region 旋钮速度调节
                    if (m_lstCircleDirection.Count > 0)//m_isReleaseWarn
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            ChangeBPSpeed();
                        }));
                    }
                    #endregion

                    #region 采血压下限超出范围
                    if (M_ModelValue.M_flt_PofPacc < -500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-02");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "采血压下限超出范围:W4-02");
#endif
                    }
                    #endregion

                    #region 采血压上限超出范围
                    if (M_ModelValue.M_flt_PofPacc > 500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-01");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "采血压上限超出范围:W4-01");
#endif
                    }
                    #endregion

                    #region 动脉压上限超出范围
                    if (M_ModelValue.M_flt_PofPart > 500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-03");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "动脉压上限超出范围:W4-03");
#endif
                    }
                    #endregion

                    #region 动脉压下限超出范围
                    if (M_ModelValue.M_flt_PofPart < -500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-04");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "动脉压下限超出范围:W4-04");
#endif
                    }
                    #endregion

                    #region 静脉压上限超出范围
                    if (M_ModelValue.M_flt_PofPven > 500)
                    {
                        //if (m_isReleaseWarn)
                        ShowWarn("W4-05");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "静脉压上限超出范围:W4-05");
#endif
                    }
                    #endregion

                    #region 静脉压下限超出范围
                    if (M_ModelValue.M_flt_PofPven < -500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-06");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "静脉压下限超出范围:W4-06");
#endif
                    }
                    #endregion

                    #region 血浆压上限超出范围
                    if (M_ModelValue.M_flt_PofP1st > 500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-07");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "血浆压上限超出范围:W4-07");
#endif
                    }
                    #endregion

                    #region 血浆压下限超出范围
                    if (M_ModelValue.M_flt_PofP1st < -500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-08");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "血浆压下限超出范围:W4-08");
#endif
                    }
                    #endregion

                    #region 血浆入口压上限超出范围
                    if (M_ModelValue.M_flt_PofP2nd > 500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-09");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "入口压上限超出范围:W4-09");
#endif
                    }
                    #endregion

                    #region 血浆入口压下限超出范围
                    if (M_ModelValue.M_flt_PofP2nd < -500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-10");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "入口压下限超出范围:W4-10");
#endif
                    }
                    #endregion

                    #region P3rd上限超出范围
                    if (M_ModelValue.M_flt_PofP3rd > 500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W4-11");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "TMP上限超出范围:W4-11");
#endif
                    }
                    #endregion

                    #region P3rd下限超出范围
                    if (M_ModelValue.M_flt_PofP3rd < -500)
                    {
                        //if (m_isReleaseWarn)
                        ShowWarn("W4-12");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "TMP下限超出范围:W4-12");
#endif
                    }
                    #endregion

                    #region 跨膜压上限超出范围
                    if (M_ModelValue.M_flt_PofTMP > 500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W1-18");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "TMP上限超出范围:W1-18");
#endif
                    }
                    #endregion

                    #region 跨膜压下限超出范围
                    if (M_ModelValue.M_flt_PofTMP < -500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W1-19");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "TMP下限超出范围:W1-19");
#endif
                    }
                    #endregion

                    #region WS1过负荷
                    if (M_ModelValue.M_flt_Weigh1 > 5000)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W2-27");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "WS1过负荷:W2-27");
#endif
                    }
                    #endregion

                    #region WS2过负荷
                    if (M_ModelValue.M_flt_Weigh2 > 5000)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W2-29");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "WS2过负荷:W2-29");
#endif
                    }
                    #endregion

                    #region WS3过负荷
                    if (M_ModelValue.M_flt_Weigh3 > 5000)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W2-31");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "WS3过负荷:W2-31");
#endif
                    }
                    #endregion

                    #region WS4过负荷
                    if (M_ModelValue.M_flt_Weigh4 > 1500)
                    {
                        //if (m_isReleaseWarn) 
                        ShowWarn("W3-07");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "WS3过负荷:W2-31");
#endif
                    }
                    #endregion

                    #region 超温报警
                    if (M_ModelValue.Flt_TemperatureJC >= 40.8 || M_ModelValue.Flt_TemperatureKZ >= 40.8)
                    {
                        //if (m_isReleaseWarn)
                        ShowWarn("W2-07");
#if LOG_WARNING
                WriteLogWarnData(M_buffer_data_copy, "超温:W2-07");
#endif
                    }
                    #endregion

                    #region 断电警报 只报一次
                    if (M_realVCode <= 6700000 && M_ModelValue.M_flt_DisChar == 0)//电压码值
                    {
                        if (m_isCutElec)
                        {
                            m_isCutElec = false;
                            ShowWarn("W2-12");//停电
#if LOG_WARNING
                                        WriteLogWarnData(M_buffer_data_copy, "断电警报:W2-12");
#endif
                        }
                    }


                    //供电恢复
                    if (M_realVCode > 1000000 && M_ModelValue.M_flt_DisChar == 1)
                    {
                        if (!m_isCutElec)//m_isReleaseWarn && 
                        {
                            m_isCutElec = true;
                            ShowWarn("W1-33");
#if LOG_WARNING
                                        WriteLogWarnData(M_buffer_data_copy, "供电恢复:W1-33");
#endif
                        }
                    }

                    #endregion

                    #region 脱水偏差超过100ml
                    if (M_isTreat && Math.Abs(dryDeviation) >= 100 && M_uc_Treat.chkBalance.Checked)
                    {
                        ShowWarn("N-14");
                    }
                    #endregion

                }
            }
        }

        void ShowTreatFormInfo()
        {
            //称重
            M_uc_Treat.lblWeigh1.Text = M_ModelValue.M_flt_Weigh1.ToString("f0");
            M_uc_Treat.lblWeigh2.Text = M_ModelValue.M_flt_Weigh2.ToString("f0");
            M_uc_Treat.lblWeigh3.Text = M_ModelValue.M_flt_Weigh3.ToString("f0");
            M_uc_Treat.lblWeigh4.Text = M_ModelValue.M_flt_Weigh4.ToString("f0");
            //加溫器
            this.tsbtnHT.Text = M_ModelValue.M_flt_Temperature.ToString("f1");

            //累计值显示
            if (M_isTreat)
            {
                M_uc_Treat.lblTotalTime.Text = Cls.utils.SecondsToTime(M_ModelTotal.TotalTime);    //M_ModelTotal.TotalTime.Hours.ToString("00") + ":" + M_ModelTotal.TotalTime.Minutes.ToString("00") + ":" + M_ModelTotal.TotalTime.Seconds.ToString("00");
                M_uc_Treat.lblTotalTime.Invalidate();
                this.uc_SpeedFP._OtherInfo = "∑: " + M_ModelTotal.TotalFP.ToString("f2") + " L";
                this.uc_SpeedDP._OtherInfo = "∑: " + M_ModelTotal.TotalDP.ToString("f2") + " L";
                this.uc_SpeedRP._OtherInfo = "∑: " + M_ModelTotal.TotalRP.ToString("f2") + " L";
                //this.uc_SpeedSP._OtherInfo = "∑: " + M_ModelTotal.TotalSP.ToString("f1") + " mL";
                this.uc_SpeedFP2._OtherInfo = "∑: " + M_ModelTotal.TotalFP2.ToString("f2") + " L";
                if (M_uc_Treat.chkBalance.Checked == true)
                {
                    M_uc_Treat.lblDryTotalActually.Text = (m_BalanceSum._DryTotalActually + M_ModelTotal.CurrentDry).ToString("f1");
                    M_uc_Treat.lblDryLilun.Text = (m_BalanceSum._DryTotalTheoretic + dryLilun).ToString("f1");
                    M_uc_Treat.lblDryDeviation.Text = dryDeviationSum.ToString("f1");
                    //M_uc_Treat.lblFPRuningTime.Text = (m_watchFPRuning.ElapsedMilliseconds / 1000.0).ToString("f1");
                }
                //this.lblBloodSpeed.Text = M_ModelTreat.BPSpeed.Value.ToString("f0m_");
            }
        }

        void ShowOtherFormInfo()
        {
            M_uc_OtherSet.sp_ACC_current.Text = M_ModelTotal.TotalSP.ToString("f1");
            M_uc_OtherSet.lblTemperature.Text = M_ModelValue.M_flt_Temperature.ToString("f1");
            M_uc_OtherSet.lblWeigh1.Text = M_ModelValue.M_flt_Weigh1.ToString("f0");
            M_uc_OtherSet.lblWeigh2.Text = M_ModelValue.M_flt_Weigh2.ToString("f0");
            M_uc_OtherSet.lblWeigh3.Text = M_ModelValue.M_flt_Weigh3.ToString("f0");
            M_uc_OtherSet.lblWeigh4.Text = M_ModelValue.M_flt_Weigh4.ToString("f0");
            M_uc_OtherSet.lblRealBloodLeak.Text = M_ModelValue.M_flt_BloodLeak.ToString();
            //漏血传感器状态判定：若漏血值不变化，表示传感器故障，设置敏感度背景红色。
            M_lstBloodLeak.Add(M_ModelValue.M_flt_BloodLeak);
            if (M_lstBloodLeak.Count > 3)
                M_lstBloodLeak.RemoveAt(0);
            if (M_lstBloodLeak.Count == 3)
            {
                if (M_lstBloodLeak[0] == M_lstBloodLeak[1] && M_lstBloodLeak[0] == M_lstBloodLeak[2])
                    M_uc_OtherSet.lblBloodLeak.BackColor = Color.Red;
                else
                    M_uc_OtherSet.lblBloodLeak.BackColor = Color.Green;
            }
        }

        void ShowAdminFormInfo()
        {
            m_frmAdmin._Weigh1code = weigh1_code;
            m_frmAdmin.lblWeigh1code.Text = weigh1_code.ToString();
            m_frmAdmin.lblweigh1.Text = M_ModelValue.M_flt_Weigh1.ToString("f0");
            m_frmAdmin._Weigh2code = weigh2_code;
            m_frmAdmin.lblWeigh2code.Text = weigh2_code.ToString();
            m_frmAdmin.lblweigh2.Text = M_ModelValue.M_flt_Weigh2.ToString("f0");
            m_frmAdmin._Weigh3code = weigh3_code;
            m_frmAdmin.lblWeigh3code.Text = weigh3_code.ToString();
            m_frmAdmin.lblweigh3.Text = M_ModelValue.M_flt_Weigh3.ToString("f0");
            /**************
             * 管理界面秤4 实时值显示
             * wss 2015年12月7日
            ***************/
            m_frmAdmin._Weight4code = weigh4_code;
            m_frmAdmin.lblWeigh4code.Text = weigh4_code.ToString();
            m_frmAdmin.lblweigh4.Text = M_ModelValue.M_flt_Weigh4.ToString("f0");
            //-------------------------
            if (M_cls_sy.CollectData_YN == true)
            {
                //采集传感器数据
                m_frmAdmin.lblRealsLen.Text = (M_cls_sy.SLen_Syringe).ToString();//短电位器值
                m_frmAdmin.lblReallLen.Text = (M_cls_sy.LLen_Syringe).ToString();//长电位器值
                m_frmAdmin.lblRealP.Text = (M_cls_sy.P_Syringe).ToString();      //压力值
                m_frmAdmin.lblReallKp.Text = (M_cls_sy.Kp_Syringe).ToString();   //压力千帕值 2017年2月15日
            }
            if (M_cls_sy.CollectSyDta_YN)
            {
                m_frmAdmin.lblRealsLen.Text = (M_cls_sy.Sy_cali).ToString();
                m_frmAdmin.lblReallLen.Text = (M_cls_sy.Sy_Compd).ToString();
            }
            m_frmAdmin.uc_pacc._Value = M_ModelValue.M_flt_PofPacc.ToString("0.0");
            m_frmAdmin.uc_part._Value = M_ModelValue.M_flt_PofPart.ToString("0.0");
            m_frmAdmin.uc_pven._Value = M_ModelValue.M_flt_PofPven.ToString("0.0");
            m_frmAdmin.uc_p1st._Value = M_ModelValue.M_flt_PofP1st.ToString("0.0");
            m_frmAdmin.uc_p2nd._Value = M_ModelValue.M_flt_PofP2nd.ToString("0.0");
            m_frmAdmin.uc_p3rd._Value = M_ModelValue.M_flt_PofP3rd.ToString("0.0");
            m_frmAdmin.uc_tmp._Value = M_ModelValue.M_flt_PofTMP.ToString("0.0");
            m_frmAdmin.lblPaccDec.Text = M_ModelValue.M_flt_PaccDecrement.ToString("0.0");
        }

        void SaveData()
        {
            //采集压力数据
            Model.pressure_data mp = new Model.pressure_data();
            mp.surgery_no = m_PatientInfo.SurgeryNo;
            //将时间格式改为ToOADate()，double类型。 2017年2月22日
            mp.time_stamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //mp.time_stamp = DateTime.Now.ToOADate();
            mp.in_blood_pressure = M_ModelValue.M_flt_PofPacc.ToString("f1");
            mp.arterial_pressure = M_ModelValue.M_flt_PofPart.ToString("f1");
            mp.venous_pressure = M_ModelValue.M_flt_PofPven.ToString("f1");
            mp.plasma_inlet_pressure = M_ModelValue.M_flt_PofP1st.ToString("f1");
            mp.plasma_pressure = M_ModelValue.M_flt_PofP2nd.ToString("f1");
            mp.transmembrane_pressure = M_ModelValue.M_flt_PofTMP.ToString("f1");
            mp.plasma2_pressure = M_ModelValue.M_flt_PofP3rd.ToString("f1");
            BLL.pressure_data bp = new BLL.pressure_data();
            bp.Add(mp);

            //采集累计量数据
            Model.pump_speed_data mpump = new Model.pump_speed_data();
            mpump.blood_pump = M_ModelTreat.BPSpeed.ToString();
            mpump.blood_pump_t = M_ModelTotal.TotalBP.ToString("f3");
            mpump.circulating_pump = M_ModelTreat.CPSpeed.ToString();
            mpump.circulating_pump_t = "0";
            mpump.cumulative_time = M_ModelTotal.TotalTime.ToString();
            mpump.dialysis_pump = M_ModelTreat.DPSpeed.ToString();
            mpump.dialysis_pump_t = M_ModelTotal.TotalDP.ToString("f3");
            mpump.filtration_pump = M_ModelTreat.FP2Speed.ToString();
            mpump.filtration_pump_t = "0";
            mpump.heparin_pump = M_ModelTreat.SP_Speed.ToString();
            mpump.heparin_pump_t = M_ModelTotal.TotalSP.ToString("f1");
            mpump.separation_pump = M_ModelTreat.FPSpeed.ToString();
            mpump.separation_pump_t = M_ModelTotal.TotalFP.ToString("f3");
            mpump.surgery_no = m_PatientInfo.SurgeryNo;
            mpump.time_stamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            mpump.tripe_pump = M_ModelTreat.RPSpeed.ToString();
            mpump.tripe_pump_t = M_ModelTotal.TotalRP.ToString("f3");
            mpump.warmer = M_ModelValue.M_flt_Temperature.ToString("f1");
            BLL.pump_speed_data pdata = new BLL.pump_speed_data();
            pdata.Add(mpump);
            //保存文本文件
            //打开文件并在文件末尾追加信息
            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            Cls.Model_TransData mtd = new Cls.Model_TransData();
            mtd.CumulativeTime = M_ModelTotal.TotalTime;
            mtd.DBPT = Math.Round(M_ModelTotal.TotalBP, 1);
            mtd.DDPT = Math.Round(M_ModelTotal.TotalDP, 1);
            mtd.DFP2T = Math.Round(M_ModelTotal.TotalFP2, 1);
            mtd.DFPT = Math.Round(M_ModelTotal.TotalFP, 1);
            mtd.DP1st = Math.Round(M_ModelValue.M_flt_PofP1st, 1);
            mtd.DP2nd = Math.Round(M_ModelValue.M_flt_PofP2nd, 1);
            mtd.DP3rd = Math.Round(M_ModelValue.M_flt_PofP3rd, 1);
            mtd.DPacc = Math.Round(M_ModelValue.M_flt_PofPacc, 1);
            mtd.DPart = Math.Round(M_ModelValue.M_flt_PofPart, 1);
            mtd.DPven = Math.Round(M_ModelValue.M_flt_PofPven, 1);
            mtd.DRPT = Math.Round(M_ModelTotal.TotalRP, 1);
            mtd.DSPT = Math.Round(M_ModelTotal.TotalSP, 1);
            mtd.DTMP = Math.Round(M_ModelValue.M_flt_PofTMP, 1);
            mtd.IBPSpeed = (int)M_PumpState.BPState.Speed;
            mtd.ICPSpeed = (int)M_PumpState.CPState.Speed;
            mtd.IDPSpeed = (int)M_PumpState.DPState.Speed;
            mtd.IFP2SPeed = (int)M_PumpState.FP2State.Speed;
            mtd.IFPSpeed = (int)M_PumpState.FPState.Speed;
            mtd.IRPSpeed = (int)M_PumpState.RPState.Speed;
            mtd.ISPSpeed = (int)M_ModelTreat.SP_Speed;
            mtd.SurgeryNo = m_PatientInfo.SurgeryNo;
            mtd.Warmer = M_ModelValue.M_flt_Temperature;
            mtd.Id = 0;
            mtd.Timestamp = epoch * 1000 + DateTime.Now.Millisecond;
            Cls.utils.AddText("DATA:" + SJsonData(mtd));
        }
        /// <summary>
        /// 串口发送命令
        /// </summary>
        /// <param name="_sp"></param>
        /// <param name="_order"></param>
        private void SendOrder(SerialPort _sp, byte[] _order)
        {
            try
            {
                if (_sp.IsOpen)
                {
                    Thread.Sleep(150);
                    #region 如果是蠕动泵,在治疗时改变状态
                    if (_sp.PortName.ToLower() == "com3")
                    {
                        ChangePumpState(_order);
                        //if (m_isReleaseWarn)
                        //_sp.Write(_order, 0, _order.Length);
                    }
                    #endregion
                    _sp.DiscardOutBuffer();
                    Thread.Sleep(100);
                    _sp.Write(_order, 0, _order.Length);
                    //如果是夹管阀命令，发送两遍
                    if (_order[1] == 0xB1)
                    {
                        Thread.Sleep(200);
                        _sp.Write(_order, 0, _order.Length);
                    }
                }
            }
            catch (Exception ee)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((EventHandler)(delegate
                    {
                        MessageBox.Show(this, ee.Message, "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else
                    MessageBox.Show(this, ee.Message, "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                //写日志
                //if (!File.Exists(m_sysRunLogPath))
                //{

                //    Cls.utils.AddText(fs, _sp.PortName + " : " + _order.ToString(""));
                //}
            }
        }


        private void SendOrderFlush(SerialPort _sp, byte[] _order)
        {
            try
            {
                if (_sp.IsOpen)
                {
                    Thread.Sleep(150);
                    _sp.DiscardOutBuffer();
                    Thread.Sleep(100);
                    _sp.Write(_order, 0, _order.Length);
                    //如果是夹管阀命令，发送两遍
                    if (_order[1] == 0xB1)
                    {
                        Thread.Sleep(200);
                        _sp.Write(_order, 0, _order.Length);
                    }
                }
            }
            catch (Exception ee)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((EventHandler)(delegate
                    {
                        MessageBox.Show(this, ee.Message, "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else
                    MessageBox.Show(this, ee.Message, "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                //写日志
                //if (!File.Exists(m_sysRunLogPath))
                //{

                //    Cls.utils.AddText(fs, _sp.PortName + " : " + _order.ToString(""));
                //}
            }
        }

        void ChangePumpState(byte[] _order)
        {
            byte[] b = _order;
            //从命令中提取泵ID,泵速和方向
            byte pumpID = b[1];
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
            //rspeed = Math.Round((0.2314 * _speedml - 0.0289) * 10 
            int rspeed = (speedhigh << 8) + speedlow;
            double mlspeed = Math.Round(((rspeed / 10.0) + 0.0289) / 0.2314, 0);

            switch (pumpID)
            {
                case 0x01:
                    M_PumpState.BPState.Speed = mlspeed;
                    M_PumpState.BPState.Runing = run;
                    M_PumpState.BPState.Direction = direction;
                    M_PumpState.BPState.PumpID = 1;
                    break;
                case 0x02:
                    M_PumpState.FPState.Speed = mlspeed;
                    M_PumpState.FPState.Runing = run;
                    M_PumpState.FPState.Direction = direction;
                    M_PumpState.FPState.PumpID = 2;
                    if (!run)
                        m_watchFPRuning.Stop();
                    break;
                case 0x03:
                    M_PumpState.DPState.Speed = mlspeed;
                    M_PumpState.DPState.Runing = run;
                    M_PumpState.DPState.Direction = direction;
                    M_PumpState.DPState.PumpID = 3;
                    break;
                case 0x04:
                    M_PumpState.RPState.Speed = mlspeed;
                    M_PumpState.RPState.Runing = run;
                    M_PumpState.RPState.Direction = direction;
                    M_PumpState.RPState.PumpID = 4;
                    break;
                case 0x05:
                    M_PumpState.FP2State.Speed = mlspeed;
                    M_PumpState.FP2State.Runing = run;
                    M_PumpState.FP2State.Direction = direction;
                    M_PumpState.FP2State.PumpID = 5;
                    break;
                case 0x06:
                    M_PumpState.CPState.Speed = mlspeed;
                    M_PumpState.CPState.Runing = run;
                    M_PumpState.CPState.Direction = direction;
                    M_PumpState.CPState.PumpID = 6;
                    break;
                case 0x1F:
                    M_PumpState.CPState.Runing = M_PumpState.FP2State.Runing = M_PumpState.RPState.Runing = M_PumpState.DPState.Runing = M_PumpState.BPState.Runing = M_PumpState.FPState.Runing = run;
                    break;
            }
            M_uc_Recycle._ModelTreat = M_ModelTreat;
            M_uc_Recycle._ModelPumpState = M_PumpState;
            //更新UI
            this.BeginInvoke(new Action(() =>
                      {
                          UpdatePumpUI(pumpID);
                          SetOtherfrmBtnState(M_PumpState);
                          //M_uc_Recycle.SetButtonState(M_PumpState);
                          //M_uc_Recycle.Refresh();
                      }));
        }

        private void UpdatePumpUI(byte _pumpID)
        {
            switch (_pumpID)
            {
                case 0x01:
                    if (M_PumpState.BPState.Runing)
                    {
                        this.M_uc_Recycle.lblBP.Text = this.lblBloodSpeed.Text = M_PumpState.BPState.Speed.ToString("f0");
                        this.picBP.Image = global::ALS.Properties.Resources.BPRun;
                    }
                    else
                    {
                        this.lblBloodSpeed.Text = "000";
                        this.picBP.Image = global::ALS.Properties.Resources.BPStop;
                    }
                    //if (M_bl_isFinishTreat)
                    //{
                    //    this.gifRuning.Image = global::ALS.Properties.Resources.tingzhi;
                    //}
                    //else
                    //    this.gifRuning.Image = global::ALS.Properties.Resources.zanting;

                    switch (M_modeName)
                    {
                        case "PE":
                            if (m_stepPE.Enabled)
                                m_stepPE.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                            break;
                        case "Li-ALS":
                            if (m_stepLiALS.Enabled)
                                m_stepLiALS.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                            break;
                        case "CHDF":
                            if (m_stepCHDF.Enabled)
                                m_stepCHDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                            break;
                        case "PERT":
                            if (m_stepPERT.Enabled)
                            {
                                if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 0)
                                    m_stepPERT.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                                if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 3)
                                    m_stepPERT.lblXuelvLeadBpSpeed.Text = m_leadBloodSpeed.ToString();
                                //if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 2)
                                //    m_stepPERT.lblRecycleBPSpeed.Text = m_leadBloodSpeed.ToString();
                            }
                            break;
                        case "PDF":
                            if (m_stepPDF.Enabled)
                                m_stepPDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                            break;
                        case "PP":
                            //添加PP模式下 引血时BP实时速度
                            //wss 2016年2月19日
                            if (m_stepPP.Enabled)
                                m_stepPP.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                            break;
                    }
                    break;
                case 0x02:
                    if (M_PumpState.FPState.Runing)
                    {
                        this.uc_SpeedFP._SpeedValue = M_PumpState.FPState.Speed.ToString("f0");
                        this.uc_SpeedFP._PicPump = global::ALS.Properties.Resources.FPRun;
                    }
                    else
                        this.uc_SpeedFP._PicPump = global::ALS.Properties.Resources.FPStop;
                    break;
                case 0x03:
                    if (M_PumpState.DPState.Runing)
                    {
                        this.uc_SpeedDP._SpeedValue = M_PumpState.DPState.Speed.ToString("f0");
                        this.uc_SpeedDP._PicPump = global::ALS.Properties.Resources.DPRun;
                    }
                    else
                        this.uc_SpeedDP._PicPump = global::ALS.Properties.Resources.DPStop;
                    break;
                case 0x04:
                    if (M_PumpState.RPState.Runing)
                    {
                        this.uc_SpeedRP._SpeedValue = M_PumpState.RPState.Speed.ToString("f0");
                        this.uc_SpeedRP._PicPump = global::ALS.Properties.Resources.RPRun;
                    }
                    else
                        this.uc_SpeedRP._PicPump = global::ALS.Properties.Resources.RPStop;
                    break;
                case 0x05:
                    if (M_PumpState.FP2State.Runing)
                    {
                        this.uc_SpeedFP2._SpeedValue = M_PumpState.FP2State.Speed.ToString("f0");
                        this.uc_SpeedFP2._PicPump = global::ALS.Properties.Resources.FP2Run;
                    }
                    else
                        this.uc_SpeedFP2._PicPump = global::ALS.Properties.Resources.FP2Stop;
                    break;
                case 0x06:
                    if (M_PumpState.CPState.Runing)
                    {
                        this.uc_SpeedCP._SpeedValue = M_PumpState.CPState.Speed.ToString("f0");
                        this.uc_SpeedCP._PicPump = global::ALS.Properties.Resources.CPRun;
                    }
                    else
                        this.uc_SpeedCP._PicPump = global::ALS.Properties.Resources.CPStop;
                    break;
                case 0x1F:
                    //发送全部泵停止时，右下角BP速度显示为000 
                    switch (M_modeName)
                    {
                        case "PE":
                            if (m_stepPE.Enabled)
                                m_stepPE.lblLeadBloodSpeed.Text = "0";
                            break;
                        case "Li-ALS":
                            if (m_stepLiALS.Enabled)
                                m_stepLiALS.lblLeadBloodSpeed.Text = "0";
                            break;
                        case "CHDF":
                            if (m_stepCHDF.Enabled)
                                m_stepCHDF.lblLeadBloodSpeed.Text = "0";
                            break;
                        case "PERT":
                            if (m_stepPERT.Enabled)
                            {
                                if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 0)
                                    m_stepPERT.lblLeadBloodSpeed.Text = "0";
                                if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 3)
                                    m_stepPERT.lblXuelvLeadBpSpeed.Text = "0";
                            }
                            break;
                        case "PDF":
                            if (m_stepPDF.Enabled)
                                m_stepPDF.lblLeadBloodSpeed.Text = "0";
                            break;
                        case "PP":
                            //添加PP模式下 引血时BP实时速度
                            //wss 2016年2月19日
                            if (m_stepPP.Enabled)
                                m_stepPP.lblLeadBloodSpeed.Text = "0";
                            break;
                    }
                    this.lblBloodSpeed.Text = "000";
                    this.picBP.Image = global::ALS.Properties.Resources.BPStop;
                    this.uc_SpeedFP._PicPump = global::ALS.Properties.Resources.FPStop;
                    this.uc_SpeedDP._PicPump = global::ALS.Properties.Resources.DPStop;
                    this.uc_SpeedRP._PicPump = global::ALS.Properties.Resources.RPStop;
                    this.uc_SpeedFP2._PicPump = global::ALS.Properties.Resources.FP2Stop;
                    this.uc_SpeedCP._PicPump = global::ALS.Properties.Resources.CPStop;
                    if (M_uc_Treat.chkBalance.Checked == true)
                    {
                        M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                        M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                    }
                    ////回收界面停止
                    //if (M_bl_isFinishTreat)
                    //{
                    //    this.gifRuning.Image = global::ALS.Properties.Resources.tingzhi;
                    //    return;
                    //}
                    //未治疗给泵发送停止命令，状态为 准备中
                    //if(M_isTreat)
                    //    this.gifRuning.Image = global::ALS.Properties.Resources.zanting;
                    //else
                    //    this.gifRuning.Image = global::ALS.Properties.Resources.zhunbei; 
                    break;
            }

            //回收时，运转任何一个泵，显示的状态都是 运行中。
            if (M_bl_isFinishTreat)
            {
                if (M_PumpState.BPState.Runing || M_PumpState.FPState.Runing || M_PumpState.DPState.Runing
                    || M_PumpState.RPState.Runing || M_PumpState.FP2State.Runing || M_PumpState.CPState.Runing)
                    this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                else
                    this.gifRuning.Image = global::ALS.Properties.Resources.tingzhi;
                return;
            }
            //运转中 只在治疗时，下方状态显示依据BP泵的运转进行改变 2016年9月10日
            if (M_isTreat)
            {
                if (M_PumpState.BPState.Runing && !M_PumpState.FPState.Runing)
                    this.gifRuning.Image = global::ALS.Properties.Resources.yunxing;
                else
                    this.gifRuning.Image = global::ALS.Properties.Resources.zhiliaozhong;
            }
            else
                this.gifRuning.Image = global::ALS.Properties.Resources.zanting;
        }


        /// <summary>
        /// 串口发送命令 需要回传
        /// 发送命令后等待回传，若未能回传则每隔1秒再发送命令，发送3次
        /// </summary>
        /// <param name="_sp"></param>
        /// <param name="_order"></param>
        /// <returns></returns>
        private bool SendOrderBack(SerialPort _sp, byte[] _order)
        {
            //发送前置 0 
            M_SendSuccess = false;
            int count = 0;
            //如果未能上传标志，继续发送命令 3次 
            SendOrder(_sp, _order);
            Thread.Sleep(50);
            while (!M_SendSuccess)
            {
                SendOrder(_sp, _order);
                count++;
                if (count >= 1)
                {
                    break;
                }
            };
            return M_SendSuccess;
        }

        private bool SendOrderBackPump(SerialPort _sp, byte[] _order)
        {
            //发送前置 0 
            M_SendSuccessPump = false;
            int count = 0;
            //如果未能上传标志，继续发送命令 3次 
            SendOrder(_sp, _order);
            while (!M_SendSuccessPump)
            {
                SendOrder(_sp, _order);
                count++;
                if (count >= 2)
                {
                    break;
                }
            };
            return M_SendSuccessPump;
        }




        private void ChangeBPSpeed()
        {
            if (m_lstCircleDirection.Count == 0)
                return;
            //回收状态下，BP不运转时，旋钮无效 2016年8月20日
            if (M_bl_isFinishTreat && !M_PumpState.BPState.Runing)
            {
                m_lstCircleDirection.Clear();
                return;
            }
            byte firstByte = m_lstCircleDirection[0];
            switch (firstByte)
            {
                case 1://逆时针
                    //检测夹管阀1和2是否都开着
                    if (M_PumpState.VState[0] == 0x00 && M_PumpState.VState[1] == 0x00 && M_isTreat)
                    {
                        //过浓缩报警
                        if (M_PumpState.FPState.Runing)
                        {
                            if (IsOverC())
                            {
                                ShowWarn("W3-02");
                                return;
                            }
                        }
                        if (m_leadBloodSpeed <= 10)
                            m_leadBloodSpeed -= 1;
                        else if (m_leadBloodSpeed > 10 && m_leadBloodSpeed < 80)
                            m_leadBloodSpeed -= 5;
                        else if (m_leadBloodSpeed >= 80)
                            m_leadBloodSpeed -= 10;
                        if (m_leadBloodSpeed < 0)
                            m_leadBloodSpeed = 0;
                        M_ModelTreat.BPSpeed = m_leadBloodSpeed;
                        //改变引血的初始速度
                        new BLL.treatmentmode().Update(M_ModelTreat);
                        //读取引血速度
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(1, m_leadBloodSpeed, true, true));
                        //switch (M_modeName)
                        //{
                        //    case "PE":
                        //        if (m_stepPE.Enabled)
                        //            m_stepPE.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //        break;
                        //    case "Li-ALS":
                        //        if (m_stepLiALS.Enabled)
                        //            m_stepLiALS.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //        break;
                        //    case "CHDF":
                        //        if (m_stepCHDF.Enabled)
                        //            m_stepCHDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //        break;
                        //    case "PERT":
                        //        if (m_stepPERT.Enabled)
                        //        {
                        //            if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 0)
                        //                m_stepPERT.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //            if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 3)
                        //                m_stepPERT.lblXuelvLeadBpSpeed.Text = m_leadBloodSpeed.ToString();
                        //            //if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 2)
                        //            //    m_stepPERT.lblRecycleBPSpeed.Text = m_leadBloodSpeed.ToString();
                        //        }
                        //        break;
                        //    case "PDF":
                        //        if (m_stepPDF.Enabled)
                        //            m_stepPDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //        break;
                        //    case "PP":
                        //        //添加PP模式下 引血时BP实时速度
                        //        //wss 2016年2月19日
                        //        if (m_stepPP.Enabled)
                        //            m_stepPP.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //break;
                        //}
                        if (m_frmDealWarn.Visible)
                        {
                            m_frmDealWarn.chkV1.Enabled = false;
                            m_frmDealWarn.chkV2.Enabled = false;
                        }
                    }
                    else
                    {
                        if (m_frmDealWarn.Visible)
                        {
                            m_frmDealWarn.chkV1.Enabled = true;
                            m_frmDealWarn.chkV2.Enabled = true;
                        }
                        //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 0, false, true));
                    }

                    break;
                case 0://顺时针
                    if (M_PumpState.VState[0] == 0x00 && M_PumpState.VState[1] == 0x00 && M_isTreat)
                    {
                        //过浓缩报警
                        if (M_PumpState.FPState.Runing)
                        {
                            if (IsOverC())
                            {
                                ShowWarn("W3-02");
                                return;
                            }
                        }
                        //Convert.ToInt32(Cls.RWconfig.GetAppSettings("LeadBloodSpeed"));
                        if (m_leadBloodSpeed < 10)
                            m_leadBloodSpeed += 1;
                        else if (m_leadBloodSpeed >= 10 && m_leadBloodSpeed < 80)
                            m_leadBloodSpeed += 5;
                        else if (m_leadBloodSpeed >= 80)
                            m_leadBloodSpeed += 10;

                        //回收时，引血速度上限为50；2016年8月20日
                        if (M_bl_isFinishTreat && m_leadBloodSpeed > 50)
                        {
                            m_leadBloodSpeed = 50;
                            break;
                        }
                        if (m_leadBloodSpeed > M_ModelTreat.LeadBloodSpeed.Value)
                            m_leadBloodSpeed = M_ModelTreat.LeadBloodSpeed.Value;
                        M_ModelTreat.BPSpeed = m_leadBloodSpeed;
                        new BLL.treatmentmode().Update(M_ModelTreat);
                        //改变引血的初始速度
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(1, m_leadBloodSpeed, true, true));
                        //switch (M_modeName)
                        //{
                        //    case "PE":
                        //        if (m_stepPE.Enabled)
                        //            m_stepPE.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //        break;
                        //    case "Li-ALS":
                        //        if (m_stepLiALS.Enabled)
                        //            m_stepLiALS.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //        break;
                        //    case "CHDF":
                        //        if (m_stepCHDF.Enabled)
                        //            m_stepCHDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //        break;
                        //    case "PERT":
                        //        if (m_stepPERT.Enabled)
                        //        {
                        //            if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 0)
                        //                m_stepPERT.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //            if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 3)
                        //                m_stepPERT.lblXuelvLeadBpSpeed.Text = m_leadBloodSpeed.ToString();
                        //            //if (m_stepPERT.wizardControl1.SelectedPage.TabIndex == 2)
                        //            //    m_stepPERT.lblRecycleBPSpeed.Text = m_leadBloodSpeed.ToString();
                        //        }
                        //        break;
                        //    case "PDF":
                        //        if (m_stepPDF.Enabled)
                        //            m_stepPDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //        break;
                        //    case "PP":
                        //        //添加PP模式下 引血时BP实时速度
                        //        //wss 2016年2月19日
                        //        if (m_stepPP.Enabled)
                        //            m_stepPP.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString();
                        //        break;
                        //}
                        if (m_frmDealWarn.Visible)
                        {
                            m_frmDealWarn.chkV1.Enabled = false;
                            m_frmDealWarn.chkV2.Enabled = false;
                        }
                    }
                    else
                    {
                        if (m_frmDealWarn.Visible)
                        {
                            m_frmDealWarn.chkV1.Enabled = true;
                            m_frmDealWarn.chkV2.Enabled = true;
                        }
                        //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 0, false, true));
                    }
                    break;
            }
            m_lstCircleDirection.Clear();
        }

        /// <summary>
        /// 主控制板串口接收处理 COM1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void port_main_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(50);
            if (M_Closing_main) return;
            try
            {
                M_Listening_main = true;
                int n = this.port_main.BytesToRead;
                byte[] buf = new byte[n];                   //声明一个临时数组存储当前来的串口数据 
                port_main.Read(buf, 0, n);                  //读取缓冲数据              
                M_buffer_main.AddRange(buf);
                //-------------------------------串口数据处理流程---------------------------------
                //1、读取缓存区数据到一个byte[]数组；
                //2、按字节找帧头,若不是所需要的帧头则去掉该字节；
                //3、找到帧头后，进行校验，校验通过则处理数据；
                //4、处理数据(包含更新界面)完成之后,删除该条命令；继续缓存区下一条命令的处理；
                //--------------------------------------------------------------------------------

                while (M_buffer_main.Count >= 5)
                {
                    if (M_buffer_main[0] == 0xFF)
                    {
                        int len = M_buffer_main[2];
                        //有校验
                        if (checkOut(M_buffer_main))
                        {
                            switch (M_buffer_main[1])
                            {
                                #region 夹管阀状态 夹管阀状态位XX: 00松管状态/01夹管状态
                                // 阀状态  夹(1) 松(2) 松(3) 松(4) 松(5) 松(6)
                                //FE B1 06 01(1) 00(2) 00(3) 00(4) 00(5) 00(6) 48 ED
                                /*
                                 * 夹管阀按键点击后，图片变化部分修改
                                 * wss 2015年12月10日
                                 */
                                case 0xB1:
                                    for (int i = 0; i < 6; i++)
                                    {
                                        M_PumpState.VState[i] = M_buffer_main[3 + i];
                                        //#if LOG_MAINPORT_DATARECEIVE
                                        //                                        getLog.WriteLogFile("V"+i.ToString() +":"+ M_PumpState.VState[i].ToString("X2"));
                                        //#endif
                                    }
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        #region 其他设置界面 夹管阀状态
                                        if (M_uc_OtherSet != null)
                                        {
                                            switch (M_buffer_main[3])
                                            {
                                                case 0x00:
                                                    M_uc_OtherSet.chkV1.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_OtherSet.chkV1.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_OtherSet.chkV1.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_OtherSet.chkV1.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-16");
                                                    break;
                                            }

                                            switch (M_buffer_main[4])
                                            {
                                                case 0x00:
                                                    M_uc_OtherSet.chkV2.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_OtherSet.chkV2.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_OtherSet.chkV2.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_OtherSet.chkV2.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-18");
                                                    break;
                                            }

                                            switch (M_buffer_main[5])
                                            {
                                                case 0x00:
                                                    M_uc_OtherSet.chkV3.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_OtherSet.chkV3.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_OtherSet.chkV3.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_OtherSet.chkV3.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-20");
                                                    break;
                                            }

                                            switch (M_buffer_main[6])
                                            {
                                                case 0x00:
                                                    M_uc_OtherSet.chkV4.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_OtherSet.chkV4.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_OtherSet.chkV4.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_OtherSet.chkV4.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-22");
                                                    break;
                                            }

                                            switch (M_buffer_main[7])
                                            {
                                                case 0x00:
                                                    M_uc_OtherSet.chkV5.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_OtherSet.chkV5.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_OtherSet.chkV5.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_OtherSet.chkV5.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-24");
                                                    break;
                                            }


                                            switch (M_buffer_main[8])
                                            {
                                                case 0x00:
                                                    M_uc_OtherSet.chkV6.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_OtherSet.chkV6.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_OtherSet.chkV6.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_OtherSet.chkV6.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-26");
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region 回收界面 夹管阀状态
                                        if (M_uc_Recycle != null)
                                        {
                                            switch (M_buffer_main[3])
                                            {
                                                case 0x00:
                                                    M_uc_Recycle.chkV1.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_Recycle.chkV1.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_Recycle.chkV1.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_Recycle.chkV1.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-16");
                                                    break;
                                            }

                                            switch (M_buffer_main[4])
                                            {
                                                case 0x00:
                                                    M_uc_Recycle.chkV2.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_Recycle.chkV2.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_Recycle.chkV2.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_Recycle.chkV2.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-18");
                                                    break;
                                            }

                                            switch (M_buffer_main[5])
                                            {
                                                case 0x00:
                                                    M_uc_Recycle.chkV3.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_Recycle.chkV3.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_Recycle.chkV3.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_Recycle.chkV3.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-20");
                                                    break;
                                            }

                                            switch (M_buffer_main[6])
                                            {
                                                case 0x00:
                                                    M_uc_Recycle.chkV4.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_Recycle.chkV4.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_Recycle.chkV4.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_Recycle.chkV4.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-22");
                                                    break;
                                            }

                                            switch (M_buffer_main[7])
                                            {
                                                case 0x00:
                                                    M_uc_Recycle.chkV5.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_Recycle.chkV5.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_Recycle.chkV5.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_Recycle.chkV5.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-24");
                                                    break;
                                            }

                                            switch (M_buffer_main[8])
                                            {
                                                case 0x00:
                                                    M_uc_Recycle.chkV6.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_Recycle.chkV6.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_Recycle.chkV6.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_Recycle.chkV6.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-26");
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region 流量设置界面 夹管阀状态
                                        if (M_uc_SetFlow != null)
                                        {
                                            switch (M_buffer_main[3])
                                            {
                                                case 0x00:
                                                    M_uc_SetFlow.chkV1.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_SetFlow.chkV1.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_SetFlow.chkV1.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_SetFlow.chkV1.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-16");
                                                    break;
                                            }

                                            switch (M_buffer_main[4])
                                            {
                                                case 0x00:
                                                    M_uc_SetFlow.chkV2.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_SetFlow.chkV2.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_SetFlow.chkV2.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_SetFlow.chkV2.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-18");
                                                    break;
                                            }

                                            switch (M_buffer_main[5])
                                            {
                                                case 0x00:
                                                    M_uc_SetFlow.chkV3.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_SetFlow.chkV3.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_SetFlow.chkV3.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_SetFlow.chkV3.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-20");
                                                    break;
                                            }

                                            switch (M_buffer_main[6])
                                            {
                                                case 0x00:
                                                    M_uc_SetFlow.chkV4.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_SetFlow.chkV4.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_SetFlow.chkV4.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_SetFlow.chkV4.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-22");
                                                    break;
                                            }

                                            switch (M_buffer_main[7])
                                            {
                                                case 0x00:
                                                    M_uc_SetFlow.chkV5.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_SetFlow.chkV5.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_SetFlow.chkV5.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_SetFlow.chkV5.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-24");
                                                    break;
                                            }

                                            switch (M_buffer_main[8])
                                            {
                                                case 0x00:
                                                    M_uc_SetFlow.chkV6.Image = global::ALS.Properties.Resources.clipopen;
                                                    M_uc_SetFlow.chkV6.Checked = false;
                                                    break;
                                                case 0x01:
                                                    M_uc_SetFlow.chkV6.Image = global::ALS.Properties.Resources.clipclose;
                                                    M_uc_SetFlow.chkV6.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-26");
                                                    break;
                                            }
                                        }
                                        #endregion

                                        #region 报警处理界面 夹管阀状态
                                        if (m_frmDealWarn != null && m_frmDealWarn.Visible == true)
                                        {
                                            switch (M_buffer_main[3])
                                            {
                                                case 0x01:
                                                    m_frmDealWarn.chkV1.Image = global::ALS.Properties.Resources.clipclose;
                                                    m_frmDealWarn.chkV1.Checked = true; break;
                                                case 0x00:
                                                    m_frmDealWarn.chkV1.Image = global::ALS.Properties.Resources.clipopen;
                                                    m_frmDealWarn.chkV1.Checked = false; break;
                                                case 0x03:
                                                    ShowWarn("W2-16"); break;
                                            }

                                            switch (M_buffer_main[4])
                                            {
                                                case 0x00:
                                                    m_frmDealWarn.chkV2.Image = global::ALS.Properties.Resources.clipopen;
                                                    m_frmDealWarn.chkV2.Checked = false;
                                                    break;
                                                case 0x01:
                                                    m_frmDealWarn.chkV2.Image = global::ALS.Properties.Resources.clipclose;
                                                    m_frmDealWarn.chkV2.Checked = true;
                                                    break;
                                                case 0x03:
                                                    ShowWarn("W2-18");
                                                    break;
                                            }
                                        }
                                        #endregion
                                    }));
                                    break;
                                #endregion
                                #region 气泡检测
                                //气泡检测1开启	FF F1 00 0E ED
                                case 0xF1:
                                    m_isOpenAD1 = true;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD1.Image = Properties.Resources.AD1;
                                        if (m_frmAdmin != null)
                                            m_frmAdmin.tsBtnAD1.Image = Properties.Resources.AD1;
                                    }));
                                    break;
                                //气泡检测1报警 FF 1F 00 E1 ED 
                                case 0x1F:
                                    M_exsitsWarn = true;
                                    ShowWarn("W1-01");
                                    break;
                                //气泡检测1关闭	FF F2 00 0D ED
                                case 0xF2:
                                    m_isOpenAD1 = false;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD1.Image = Properties.Resources.AD1Off;
                                        if (m_frmAdmin != null)
                                            m_frmAdmin.tsBtnAD1.Image = Properties.Resources.AD1Off;
                                    }));
                                    break;
                                //气泡检测2开启	FF F3 00 0C ED
                                case 0xF3:
                                    m_isOpenAD2 = true;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD2.Image = Properties.Resources.AD2;
                                        if (m_frmAdmin != null)
                                            m_frmAdmin.tsBtnAD2.Image = Properties.Resources.AD2;
                                    }));
                                    break;
                                //气泡检测2报警		FF 2F 00 D1 ED
                                case 0x2F:
                                    M_exsitsWarn = true;
                                    ShowWarn("W2-01");
                                    break;
                                //气泡检测2关闭 FF F4 00 0B ED
                                case 0xF4:
                                    m_isOpenAD2 = false;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD2.Image = Properties.Resources.AD2Off;
                                        if (m_frmAdmin != null)
                                            m_frmAdmin.tsBtnAD2.Image = Properties.Resources.AD2Off;
                                    }));
                                    break;
                                //气泡检测3开启	FF F5 00 0A ED
                                case 0xF5:
                                    m_isOpenAD3 = true;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD3.Image = Properties.Resources.AD3;
                                        if (m_frmAdmin != null)
                                            m_frmAdmin.tsBtnAD3.Image = Properties.Resources.AD3;
                                    }));
                                    break;
                                //气泡检测3报警		FF 3F 00 C1 ED   
                                case 0x3F:
                                    M_exsitsWarn = true;
                                    ShowWarn("W2-02");
                                    break;
                                //气泡检测3关闭 FF F6 00 09 ED
                                case 0xF6:
                                    m_isOpenAD3 = false;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD3.Image = Properties.Resources.AD3Off;
                                        if (m_frmAdmin != null)
                                            m_frmAdmin.tsBtnAD3.Image = Properties.Resources.AD3Off;
                                    }));
                                    break;
                                #endregion
                                #region  加热系统
                                //启动加热系统	FF EE 00 11 ED
                                //停止加热系统	FF EF 00 10 ED
                                case 0xEE:
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnHT.Image = Properties.Resources.hoton;
                                    }));
                                    break;
                                case 0xEF:
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnHT.Image = Properties.Resources.hotoff;
                                    }));
                                    break;
                                #endregion
                                #region 血泵旋钮调速
                                //顺时针转动		FF 0A 00 F5 ED
                                //逆时针转动		FF 1A 00 E5 ED
                                case 0x0A://顺时针存储1  
                                    if (m_lstCircleDirection.Count == 0)
                                        m_lstCircleDirection.Add(1);
                                    //#if LOG_MAINPORT_DATARECEIVE
                                    //                                    getLog.WriteLogFile("clockwise:1 count:" + m_lstCircleDirection.Count.ToString());
                                    //#endif
                                    break;
                                case 0x1A://逆时针存储0
                                    if (m_lstCircleDirection.Count == 0)
                                        m_lstCircleDirection.Add(0);
                                    //#if LOG_MAINPORT_DATARECEIVE
                                    //                                    getLog.WriteLogFile("counterclockwise:0 count" + m_lstCircleDirection.Count.ToString());
                                    //#endif
                                    break;
                                #endregion
                                #region 液位检测 1静脉 2动脉 3M1
                                //液位1上限报警		FF 2A 00 D5 ED
                                //case 0x2A:
                                //M_exsitsWarn = true;
                                //m_warnCode = "W3-12";
                                //ShowWarn(m_warnCode);
                                //break;
                                //液位1正常信号		FF 3A 00 C5 ED
                                //液位1下限报警		FF 4A 00 B5 ED
                                //case 0x4A:
                                //M_exsitsWarn = true;
                                //m_warnCode = "W3-13";
                                //ShowWarn(m_warnCode);
                                //break;
                                //液位2上限报警		FF 5A 00 A5 ED
                                //case 0x5A:
                                //M_exsitsWarn = true;
                                //m_warnCode = "W3-14";
                                //ShowWarn(m_warnCode);
                                //break;
                                //液位2正常信号		FF 6A 00 95 ED
                                //液位2下限报警		FF 7A 00 85 ED
                                //case 0x7A:
                                //M_exsitsWarn = true;
                                //m_warnCode = "W3-15";
                                //ShowWarn(m_warnCode);
                                //break;
                                //液位3上限报警		FF 8A 00 75 ED
                                //case 0x8A:
                                //M_exsitsWarn = true;
                                //m_warnCode = "W3-16";
                                //ShowWarn(m_warnCode);
                                //break;
                                //液位3正常信号		FF 9A 00 65 ED
                                //液位3下限报警		FF 0B 00 F4 ED 
                                //case 0x0B:
                                //M_exsitsWarn = true;
                                //m_warnCode = "W3-17";
                                //ShowWarn(m_warnCode);
                                //break;
                                //液位检测全关
                                //case 0xF7:
                                //M_SendSuccess = true;
                                //break;
                                //液位检测全开
                                //case 0xF8:
                                //M_SendSuccess = true;
                                //break;
                                #endregion

                                #region  SP传感器校准 数据写入后,重启完成
                                case 0xD1:
                                    if (m_frmAdmin != null)
                                    {
                                        this.Invoke((EventHandler)(delegate
                                        {
                                            m_frmAdmin.sy_calstatus.Text = "校准完成";
                                        }));
                                    }
                                    break;
                                #endregion
                            }
                            M_buffer_main.RemoveRange(0, 5);
                        }
                        else
                            M_buffer_main.RemoveAt(0);
                    }
                    else
                    {
                        //如果数据开始不是FF，则删除数据  
                        M_buffer_main.RemoveAt(0);
                    }

                    #region 接收命令Log
                    //this.BeginInvoke((EventHandler)(delegate
                    //{
                    //    buffcount++;
                    //    //依次的拼接出16进制字符串  
                    //    M_strb_main.Append(port_main.PortName + "(" + buffcount + "):");
                    //    foreach (byte b in buf)
                    //    {
                    //        M_strb_main.Append(b.ToString("X2") + " ");
                    //    }
                    //    M_strb_main.Append("[" + DateTime.Now.ToString() + "]\r\n");
                    //    //追加的形式添加到文本框末端，并滚动到最后。  
                    //    this.txtRecieve.AppendText(M_strb_main.ToString());
                    //    M_strb_main.Clear();
                    //}));
                    #endregion
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, ee.ToString());
            }
            finally
            {
                M_Listening_main = false;
            }
        }
        private void WriteLogWarnData(byte[] b, string code)
        {
            if (b != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (byte bb in b)
                {
                    sb.Append(bb.ToString("X2"));
                }
                getLog.WriteLogFile("code:" + code + " warn data info:" + sb.ToString());
            }
        }

        //每5条数据存储一次
        private void WriteCom4Log()
        {
            string[] str_data = lst_com4data.ToArray();
            //将lst转换为1条字符串进行输出 2016年8月29日
            string str = string.Join("", str_data);
            getLog.WriteLogFile(str);
            this.BeginInvoke((EventHandler)(delegate
            {
                //追加的形式添加到文本框末端，并滚动到最后。  
                if (m_frmAdmin != null && !m_frmAdmin.IsDisposed)
                {
                    m_frmAdmin.rtBoxData.AppendText(str);
                    m_frmAdmin.rtBoxData.Focus();
                    m_frmAdmin.rtBoxData.Select(m_frmAdmin.rtBoxData.Text.Length, 0);
                }
            }));
            lst_com4data.Clear();
        }

        void port_data_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            if (M_Closing_data) return;
            try
            {
                M_Listening_data = true;
                int n = this.port_data.BytesToRead;
                byte[] buf = new byte[n];                   //声明一个临时数组存储当前来的串口数据 
                port_data.Read(buf, 0, n);                  //读取缓冲数据              
                M_buffer_data.AddRange(buf);
                //-------------------------------串口数据处理流程---------------------------------
                //1、读取缓存区数据到一个byte[]数组；
                //2、按字节找帧头,若不是所需要的帧头则去掉该字节；
                //3、找到帧头后，进行校验，校验通过则处理数据；
                //4、处理数据(包含更新界面)完成之后,删除该条命令；继续缓存区下一条命令的处理；
                //--------------------------------------------------------------------------------
                //M_buffer_data_copy = new byte[M_buffer_data.Count];
                //M_buffer_data.CopyTo(M_buffer_data_copy, 0);

                while (M_buffer_data.Count >= 42)
                {
                    if (M_buffer_data[0] == 0xFF)
                    {
                        //数据采集协议更改 增加P3rd压力检测协议
                        //FF AE 26 01 4B 01 4C 20 01 1F 
                        //FF 20 04 20 03 20 04 20 01 4D 
                        //8D 04 A0 4E 03 DC B7 04 11 86 
                        //04 CF 89 03 40 24 00 00 FF C8 42 ED
                        if (M_buffer_data[1] == 0xAE && M_buffer_data[2] == 0x26 && M_buffer_data[41] == 0xED)
                        {
                            //扔掉前5条数据
                            m_portdataCount++;
                            if (m_portdataCount < 5)
                                return;
                            //接收5条数据后称重清零
                            if (m_portdataCount > 10)
                            {
                                m_portdataCount = 10;
                                if (!m_isZeroWeigh)
                                {
                                    m_isZeroWeigh = true;
                                    this.BeginInvoke(new Action(() =>
                                    {
                                        //称重清零
                                        M_uc_OtherSet_btnZeroWs(M_uc_OtherSet.btnZeroWS1, new EventArgs());
                                        M_uc_OtherSet_btnZeroWs(M_uc_OtherSet.btnZeroWS2, new EventArgs());
                                        M_uc_OtherSet_btnZeroWs(M_uc_OtherSet.btnZeroWS3, new EventArgs());
                                        M_uc_OtherSet_btnZeroWs(M_uc_OtherSet.btnZeroWS4, new EventArgs());
                                    }));
                                }
                            }

                            #region 所有显示值(无校验)
                            //温度
                            string strt0 = M_buffer_data[3].ToString("x2") + M_buffer_data[4].ToString("x2");
                            string strt1 = M_buffer_data[5].ToString("x2") + M_buffer_data[6].ToString("x2");
                            M_ModelValue.Flt_TemperatureKZ = Convert.ToInt32(strt0, 16) * 0.0625;
                            M_ModelValue.Flt_TemperatureJC = Convert.ToInt32(strt1, 16) * 0.0625;

                            M_ModelValue.M_flt_Temperature = (float)(M_ModelValue.Flt_TemperatureKZ + M_ModelValue.Flt_TemperatureJC) / 2;
                            //传感器断线故障
                            if ((M_buffer_data[5] == 0x05 && M_buffer_data[6] == 0xEE))
                                ShowWarn("W2-08");
                            if ((M_buffer_data[3] == 0x05 && M_buffer_data[4] == 0xEE))
                                ShowWarn("W2-09");
                            //温差±1℃报警
                            if (M_ModelValue.M_flt_Temperature < M_ModelTreat.TargetT.Value - 1 || M_ModelValue.M_flt_Temperature > M_ModelTreat.TargetT.Value + 1)
                                M_exsitsWarn = true;
                            string strvcode = M_buffer_data[33].ToString("x2") + M_buffer_data[32].ToString("x2") + M_buffer_data[31].ToString("x2");
                            string strfir = strvcode.Substring(0, 1);
                            string strval = string.Empty;
                            int VCode = 0;
                            if (strfir.ToLower() == "f")
                            {
                                strval = strvcode.Substring(1, strvcode.Length - 1);
                                VCode = Convert.ToInt32(strval, 16);
                                VCode = -VCode;
                            }
                            else
                            {
                                strval = strvcode;
                                VCode = Convert.ToInt32(strval, 16);
                            }

                            M_realVCode = VCode;//(int)GetlstAvg(M_lstRealV);
                            M_ModelValue.M_flt_DisChar = M_buffer_data[37];
                            M_ModelValue.M_flt_VCodeBB = M_buffer_data[38];
                            M_ModelValue.M_flt_VCodeCC = M_buffer_data[39];
                            //压力
                            int pacc = Convert.ToInt32(M_buffer_data[7].ToString("x2") + M_buffer_data[8].ToString("x2"), 16);
                            M_ModelValue.M_flt_PofPacc = (float)Math.Round(0.1182765 * pacc - 968.8597, 2) - 0.8;//((((pacc - 1638) * 30) - 196605) * 51.675f) / 13107
                            int part = Convert.ToInt32(M_buffer_data[9].ToString("x2") + M_buffer_data[10].ToString("x2"), 16);
                            M_ModelValue.M_flt_PofPart = (float)Math.Round(0.1182765 * part - 968.8597, 2) - 0.8;//((((part - 1638) * 30) - 196605) * 51.675f) / 13107
                            int pven = Convert.ToInt32(M_buffer_data[11].ToString("x2") + M_buffer_data[12].ToString("x2"), 16);
                            M_ModelValue.M_flt_PofPven = (float)Math.Round(0.1182765 * pven - 968.8597, 2) - 0.8;//((((pven - 1638) * 30) - 196605) * 51.675f) / 13107
                            int p1st = Convert.ToInt32(M_buffer_data[13].ToString("x2") + M_buffer_data[14].ToString("x2"), 16);
                            M_ModelValue.M_flt_PofP1st = (float)Math.Round(0.1182765 * p1st - 968.8597, 2) - 0.8;//((((p1st - 1638) * 30) - 196605) * 51.675f) / 13107
                            int p2nd = Convert.ToInt32(M_buffer_data[15].ToString("x2") + M_buffer_data[16].ToString("x2"), 16);
                            M_ModelValue.M_flt_PofP2nd = (float)Math.Round(0.1182765 * p2nd - 968.8597, 2) - 0.8;//((((p2nd - 1638) * 30) - 196605) * 51.675f) / 13107
                            int p3rd = Convert.ToInt32(M_buffer_data[17].ToString("x2") + M_buffer_data[18].ToString("x2"), 16);
                            M_ModelValue.M_flt_PofP3rd = (float)Math.Round(0.1182765 * p3rd - 968.8597, 2) - 0.8;//((((p2nd - 1638) * 30) - 196605) * 51.675f) / 13107
                            //跨膜压 = （动脉压Part + 静脉压Pven）/2 - 血浆压P1st
                            M_ModelValue.M_flt_PofTMP = (M_ModelValue.M_flt_PofPart + M_ModelValue.M_flt_PofPven) / 2.0f - M_ModelValue.M_flt_PofP1st;

                            //采血压List
                            M_lstPacc.Add(M_ModelValue.M_flt_PofPacc);
                            if (M_lstPacc.Count > 6) M_lstPacc.RemoveAt(0);
                            M_ModelValue.M_flt_PaccDecrement = GetlstDecrement(M_lstPacc);

                            if (M_ModelValue.M_flt_PaccDecrement > M_ModelTreat.PaccDecrement.Value)
                                M_exsitsWarn = true;
                            if ((M_ModelValue.M_flt_PofPacc > M_ModelTreat.PaccUpper) || (M_ModelValue.M_flt_PofPacc < M_ModelTreat.PaccLower + M_ModelTreat.PrePaccLower))
                                M_exsitsWarn = true;
                            if ((M_ModelValue.M_flt_PofPart > M_ModelTreat.PartUpper.Value - M_ModelTreat.PrePartUpper.Value) || (M_ModelValue.M_flt_PofPart < M_ModelTreat.PartLower.Value) || (M_ModelValue.M_flt_PofPart > M_ModelTreat.PartUpper.Value))
                                M_exsitsWarn = true;
                            if ((M_ModelValue.M_flt_PofPven > M_ModelTreat.PvenUpper.Value - M_ModelTreat.PrePvenUpper.Value) || (M_ModelValue.M_flt_PofPven < M_ModelTreat.PvenLower.Value) || (M_ModelValue.M_flt_PofPven > M_ModelTreat.PvenUpper.Value))
                                M_exsitsWarn = true;
                            if ((M_ModelValue.M_flt_PofP1st > M_ModelTreat.P1stUpper.Value) || (M_ModelValue.M_flt_PofP1st < M_ModelTreat.P1stLower.Value))
                                M_exsitsWarn = true;
                            if ((M_ModelValue.M_flt_PofP2nd > M_ModelTreat.P2ndUpper.Value) || (M_ModelValue.M_flt_PofP2nd < M_ModelTreat.P2ndLower.Value))
                                M_exsitsWarn = true;
                            if ((M_ModelValue.M_flt_PofP3rd > M_ModelTreat.P3rdUpper.Value) || (M_ModelValue.M_flt_PofP3rd < M_ModelTreat.P3rdLower.Value))
                                M_exsitsWarn = true;
                            if ((M_ModelValue.M_flt_PofTMP > M_ModelTreat.TmpUpper) || (M_ModelValue.M_flt_PofTMP < M_ModelTreat.TmpLower))
                                M_exsitsWarn = true;

                            //漏血
                            string strbloodleak = M_buffer_data[36].ToString("x2") + M_buffer_data[35].ToString("x2") + M_buffer_data[34].ToString("x2");
                            M_ModelValue.M_flt_BloodLeak = Convert.ToInt32(strbloodleak, 16);
                            if (M_ModelValue.M_flt_BloodLeak < M_ModelTreat.BloodLeak)
                                M_exsitsWarn = true;

                            //称重
                            if (((M_buffer_data[21] & 0x80) == 0x80))
                                weigh1_code = 0;// (weigh1_code & 0x7FFFFF); 
                            else
                            {
                                string strweigh1 = M_buffer_data[21].ToString("x2") + M_buffer_data[20].ToString("x2") + M_buffer_data[19].ToString("x2");
                                //最高位为1表示负值,需要特殊处理                                                     
                                weigh1_code = Convert.ToInt32(strweigh1, 16);
                            }

                            if ((M_buffer_data[24] & 0x80) == 0x80)
                                weigh2_code = 0;// (weigh2_code & 0x7FFFFF); 
                            else
                            {
                                string strweigh2 = M_buffer_data[24].ToString("x2") + M_buffer_data[23].ToString("x2") + M_buffer_data[22].ToString("x2");
                                weigh2_code = Convert.ToInt32(strweigh2, 16);
                            }

                            if (((M_buffer_data[27] & 0x80) == 0x80))
                                weigh3_code = 0;// (weigh3_code & 0x7FFFFF); 
                            else
                            {
                                string strweigh3 = M_buffer_data[27].ToString("x2") + M_buffer_data[26].ToString("x2") + M_buffer_data[25].ToString("x2");
                                weigh3_code = Convert.ToInt32(strweigh3, 16);
                            }

                            if (((M_buffer_data[30] & 0x80) == 0x80))
                                weigh4_code = 0;// (weigh4_code & 0x7FFFFF);  
                            else
                            {
                                string strweigh4 = M_buffer_data[30].ToString("x2") + M_buffer_data[29].ToString("x2") + M_buffer_data[28].ToString("x2");
                                weigh4_code = Convert.ToInt32(strweigh4, 16);
                            }

                            m_realweigh1 = Math.Round((weigh1_code - weigh1_0kgcode) * weigh1_resolution, 1);
                            m_realweigh2 = Math.Round((weigh2_code - weigh2_0kgcode) * weigh2_resolution, 1);
                            m_realweigh3 = Math.Round((weigh3_code - weigh3_0kgcode) * weigh3_resolution, 1);
                            m_realweigh4 = Math.Round((weigh4_code - weigh4_0kgcode) * weigh4_resolution, 1);

                            M_lstWeigh1.Add(m_realweigh1);
                            M_lstWeigh2.Add(m_realweigh2);
                            M_lstWeigh3.Add(m_realweigh3);
                            M_lstWeigh4.Add(m_realweigh4);
                            //M_lstRealV.Add(VCode); 
                            if (M_lstWeigh1.Count > 5) M_lstWeigh1.RemoveAt(0);
                            if (M_lstWeigh2.Count > 5) M_lstWeigh2.RemoveAt(0);
                            if (M_lstWeigh3.Count > 5) M_lstWeigh3.RemoveAt(0);
                            if (M_lstWeigh4.Count > 5) M_lstWeigh4.RemoveAt(0);
                            //计算实时值      Test                     
                            M_ModelValue.M_flt_Weigh1 = GetlstAvg(M_lstWeigh1);
                            M_ModelValue.M_flt_Weigh2 = GetlstAvg(M_lstWeigh2);
                            M_ModelValue.M_flt_Weigh3 = GetlstAvg(M_lstWeigh3);
                            M_ModelValue.M_flt_Weigh4 = GetlstAvg(M_lstWeigh4);

                            M_buffer_data.RemoveRange(0, 42);
                            #endregion
                        }
                        else
                            M_buffer_data.RemoveAt(0);
                    }
                    else
                    {
                        //如果数据开始不是FF，则删除数据  
                        //M_buffer_data.RemoveAt(0);
                        M_buffer_data.RemoveRange(0, M_buffer_data.Count);
                    }
                }
                #region 接收数据
                //依次的拼接出16进制字符串  
                M_strb_main.Append(DateTime.Now.ToString("yyMMdd_HH:mm:ss") + "." + DateTime.Now.Millisecond.ToString("000"));
                //显示当前血泵速度、采血压大小
                M_strb_main.Append(" BP:" + M_PumpState.BPState.Speed.ToString());
                M_strb_main.Append(" Pacc:" + M_ModelValue.M_flt_PofPacc.ToString("f1") + " ");

                foreach (byte b in buf)
                {
                    M_strb_main.Append(b.ToString("X2") + " ");
                }
                M_strb_main.Append(" \r\n");
                lst_com4data.Add(M_strb_main.ToString());
                M_strb_main.Clear();
                //每5个字符串写一次文件
                if (lst_com4data.Count >= 5)
                    WriteCom4Log();
                #endregion
            }
            catch (Exception ee)
            {
                MessageBox.Show(this, ee.Message.ToString());
                M_Listening_data = false;
            }
            finally
            {
                M_Listening_data = false;
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 加权平均值
        /// 根据List长度,(index+1)/10.0的加权算法
        /// </summary>
        /// <param name="_lstvalue"></param>
        /// <returns></returns>
        double GetlstAvg(List<double> _lstvalue)
        {
            //if (_lstvalue.Count > 2)
            //{
            //    //获取最大值最小值并去除
            //    double List_max = _lstvalue.Max();
            //    double List_min = _lstvalue.Min();
            //    _lstvalue.Remove(List_max);
            //    _lstvalue.Remove(List_min);
            return Math.Round(_lstvalue.Average(), 1);
            //}
            //else
            //    return Math.Round(_lstvalue.Average(), 1);
        }
        //计算压力减少量，而不是差值
        //前5个值平均值减去最后的值
        double GetlstDecrement(List<double> _lstvalue)
        {
            if (_lstvalue.Count < 6) return 0;
            double avg5 = (_lstvalue.Sum() - _lstvalue[5]) / 5.0;
            return Math.Round(avg5 - _lstvalue[5], 1);
        }

        /// <summary>
        /// 肝素泵串口接收处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void port_hpump_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(80);
            if (M_Closing_hpump) return;
            try
            {
                M_Listening_hpump = true;
                int n = this.port_hpump.BytesToRead;
                byte[] buf = new byte[n];                    //声明一个临时数组存储当前来的串口数据 
                port_hpump.Read(buf, 0, n);                  //读取缓冲数据              
                M_buffer_hpump.AddRange(buf);
                //-------------------------------串口数据处理流程---------------------------------
                //1、读取缓存区数据到一个byte[]数组；
                //2、按字节找帧头,若不是所需要的帧头则去掉该字节；
                //3、找到帧头后，进行校验，校验通过则处理数据；
                //4、处理数据(包含更新界面)完成之后,删除该条命令；继续缓存区下一条命令的处理；
                //--------------------------------------------------------------------------------
                //至少要包含头（2字节）+长度（1字节）+校验（1字节）  
                while (M_buffer_hpump.Count >= 5)
                {
                    //               报警标号值    报警识别码     累计量   压力Kpa 规格 断电确认 运行状态       校验
                    //正常:FF 38 12 (00 00 00 00) (00 00 00 00) (00 00 00) (00 00) 04   00       00       00 00  D1   ED 
                    //报警:FF 38 12 (40 01 00 00) (00 00 00 02) (00 00 00) (00 00) 04   00       00       00 00  92   ED 
                    if (M_buffer_hpump[0] == 0xFF && M_buffer_hpump[1] == 0x38 && M_buffer_hpump[2] == 0x12)
                    {
                        #region 处理抗凝剂泵联络帧返回数据
                        //数据长度为23
                        //if (M_buffer_hpump.Count < 23) break;
                        //如果通过校验
                        if (checkOutHPump(M_buffer_hpump))
                        {
                            #region 取累计值
                            //sp返回的当前累计值
                            string strCurrent = M_buffer_hpump[11].ToString("x2") + M_buffer_hpump[12].ToString("x2") + M_buffer_hpump[13].ToString("x2");
                            //取sp当前返回累积量值                        
                            M_ModelTotal.TotalSP = Convert.ToInt32(strCurrent, 16) / 10.0;
                            #endregion

                            #region 取压力值,压力阻塞报警
                            int pressValue = Convert.ToInt32(M_buffer_hpump[14].ToString("x2") + M_buffer_hpump[15].ToString("x2"), 16);
                            if (pressValue >= 50)
                            {
                                ShowWarn("W1-25");
                                ShowSPState("压力阻塞", Color.Red, true, true, true);
                            }
                            #endregion

                            //警报处理按由高到低处理, 首先处理系统故障级的警报
                            //0x80000000   0X0100 系统故障1（电机运行错误）
                            //             0X0200 系统故障2（注射泵主板未能接收到通讯数据错误）
                            //0x40000000   0X01 注射器错误1（识别错误）
                            //             0X02 注射器错误2（推头错误）
                            //             0X04 注射器错误3（长电位器错误）
                            //阻塞	            0x04000000
                            //离合未闭	        0x02000000
                            //注射完成	        0x01000000
                            //接近完成	        0x00010000 
                            //快进注射中	    0x00000080
                            //注射器校准成功	0x00000001
                            //注射器校准失败	0x00000002
                            //注射器校准中	    0x00000004
                            //注射器校准完成	0x00000008
                            //注射器校准中断	0x00000010                             
                            switch (M_buffer_hpump[3])
                            {
                                #region 返回FF 38 12 80 xxxx
                                case 0x80://系统故障 
                                    switch (M_buffer_hpump[9])
                                    {
                                        case 0x01://电机运行错误
                                            ShowWarn("W1-26");
                                            ShowSPState("电机运行错误", Color.Red, true, true, true);
                                            break;
                                        //case 0x02://通讯数据错误
                                        //break;
                                    }
                                    break;
                                #endregion
                                #region 返回FF 38 12 40xxxxx
                                case 0x40://注射器错误
                                    switch (M_buffer_hpump[10])
                                    {
                                        case 0x01://注射器识别错误
                                            ShowWarn("W1-16");
                                            ShowSPState("注射器识别错误", Color.Red, false, true, true);
                                            break;
                                        case 0x02://推头错误
                                            ShowWarn("W1-17");
                                            ShowSPState("推头错误", Color.Red, false, true, true);
                                            break;
                                        //case 0x04://长电位器错误
                                        //    break;
                                    }
                                    break;
                                //case 0x04://阻塞

                                //    break;
                                #endregion
                                #region 返回FF 38 12 02xxxx
                                case 0x02://离合未闭
                                    ShowWarn("W1-35");
                                    ShowSPState("离合未必", Color.Red, false, true, true);
                                    break;
                                #endregion
                                #region 返回FF 38 12 01 xxx
                                case 0x01://注射完成
                                    ShowWarn("W1-21");
                                    ShowSPState("注射完成", Color.Lime, false, true, true);
                                    SendOrder(port_hpump, Cls.Comm_SyringePump.ClearCumulant);
                                    Sp_NearCom = false;
                                    break;
                                #endregion
                                #region 返回FF 38 12 00 xxxxxxx
                                case 0x00://其他错误及提示
                                    #region 接近完成
                                    if (M_buffer_hpump[4] == 0x01)//接近完成,只报一次
                                    {
                                        //接近完成只报一次，报完后Sp_NearCom为true;                                      
                                        //解除警报时
                                        if (Sp_NearCom == false)
                                        {
                                            Sp_NearCom = true;
                                            ShowSPState("注射接近完成", Color.Lime, false, true, false);
                                            ShowWarn("W1-20");
                                        }
                                    }
                                    #endregion

                                    #region   速度错误报警测试
                                    //if (M_buffer_hpump[4] == 0x04)
                                    //{
                                    //测试"速度错误"报警   
                                    //ShowSPState("速度错误", Color.Red, true, true, true);
                                    //ShowWarn("W3-21");
                                    //}
                                    #endregion

                                    #region 没有警报  自动识别注射器型号
                                    if (M_buffer_hpump[4] == 0x00 && M_buffer_hpump[5] == 0x00 && M_buffer_hpump[6] == 0x00)
                                    {
                                        ShowSPState("状态正常", Color.Lime, false, false, false);
                                        Sp_NearCom = false;
                                        //注射器型号识别
                                        switch (M_buffer_hpump[16])
                                        {
                                            case 0x04:
                                                this.BeginInvoke((EventHandler)(delegate
                                               {
                                                   if (M_uc_OtherSet != null)
                                                   {
                                                       M_uc_OtherSet.lblSPStandard.Text = "30";
                                                   }
                                               }));
                                                break;
                                            default:
                                                this.BeginInvoke((EventHandler)(delegate
                                                {
                                                    if (M_uc_OtherSet != null)
                                                    {
                                                        M_uc_OtherSet.lblSPStandard.Text = "--";
                                                    }
                                                }));
                                                ShowWarn("W1-34");
                                                break;
                                        }
                                    }
                                    #endregion

                                    #region 没有警报
                                    if (M_buffer_hpump[4] == 0x00 && M_buffer_hpump[5] == 0x00 && M_buffer_hpump[6] == 0x00)
                                        ShowSPState("状态正常", Color.Lime, false, false, false);
                                    #endregion

                                    break;
                                #endregion
                            }
                            M_buffer_hpump.RemoveRange(0, 23);
                        }
                        else
                            M_buffer_hpump.RemoveAt(0);
                        #endregion
                    }
                    else if (M_buffer_hpump[0] == 0xFE && M_buffer_hpump[1] == 0xC1)
                    {
                        #region  抗凝剂泵返回 FE C1  微量注射泵传感器零点校准数据采集
                        int len = M_buffer_hpump[2];
                        ////不需要采集当前数据或接收数据不完成
                        //if (M_buffer_hpump.Count < len + 5)
                        //    break;

                        //校验失败
                        if (checkOutHPump(M_buffer_hpump) == false)
                        {
                            M_buffer_hpump.RemoveAt(0);
                            break;
                        }

                        M_cls_sy.SLen_Syringe = Convert.ToInt32((M_buffer_hpump[7] << 8) + M_buffer_hpump[8]);//短电位器值
                        M_cls_sy.LLen_Syringe = Convert.ToInt32((M_buffer_hpump[9] << 8) + M_buffer_hpump[10]);//长电位器值
                        M_cls_sy.P_Syringe = Convert.ToInt32((M_buffer_hpump[3] << 8) + M_buffer_hpump[4]);//压力值
                        M_cls_sy.Kp_Syringe = Convert.ToInt32((M_buffer_hpump[5] << 8) + M_buffer_hpump[6]);//压力千帕值 2017年2月15日
                        M_buffer_hpump.RemoveRange(0, len + 5);
                        M_cls_sy.CollectData_YN = true;
                        #endregion
                    }


                    else if (M_buffer_hpump[0] == 0xFE && M_buffer_hpump[1] == 0xC2)
                    {
                        #region 抗凝剂泵返回 FE C2 注射器校准参数采集
                        int len = M_buffer_hpump[2];
                        //长度不够
                        //if (M_buffer_hpump.Count < len + 5)
                        //    break;
                        //校验失败
                        if (checkOutHPump(M_buffer_hpump) == false)
                        {
                            M_buffer_hpump.RemoveAt(0);
                            break;
                        }
                        M_cls_sy.Sy_cali = (M_buffer_hpump[4] << 8) + M_buffer_hpump[5];
                        M_cls_sy.Sy_Compd = (M_buffer_hpump[8] << 8) + M_buffer_hpump[9];
                        M_cls_sy.CollectSyDta_YN = true;
                        M_buffer_hpump.RemoveRange(0, len + 5);
                        #endregion
                    }


                    else if (M_buffer_hpump[0] == 0xFF & M_buffer_hpump[1] == 0x37)
                    {
                        #region 注射器品牌选择FF  37
                        //    int len = M_buffer_hpump[2];
                        //    //长度不够
                        //    if (M_buffer_hpump.Count < len + 5)
                        //        break;
                        //    //校验失败
                        //    if (checkOutHPump(M_buffer_hpump) == false)
                        //    {
                        //        M_buffer_hpump.RemoveRange(0, len + 5);
                        //        break;
                        //    }
                        //    if (M_ModelSyringe.Sy_brand != "洁瑞")
                        //        Cls.utils.SendOrder(port_hpump, Cls.Comm_SyringePump.AutoCal_set(M_ModelSyringe.Cal_SyThirty));
                        //    M_buffer_hpump.RemoveRange(0, len + 5);
                        #endregion
                    }

                    else if (M_buffer_hpump[0] == 0xFF & M_buffer_hpump[1] == 0x31)
                    {
                        #region 传感器校准数据发送成功 FF 31
                        int len = M_buffer_hpump[2];
                        //长度不够
                        //if (M_buffer_hpump.Count < len + 5)
                        //    break;
                        if (M_buffer_hpump[2] == 0x00 && M_buffer_hpump[3] == 0xCE && M_buffer_hpump[4] == 0xED && m_frmAdmin != null)
                        {
                            this.Invoke((EventHandler)(delegate
                            {
                                m_frmAdmin.sy_calstatus.Text = "数据已写入请等待";
                            }));
                            M_buffer_hpump.RemoveRange(0, 5);
                            //发送断电联络帧
                            SendOrder(port_hpump, Cls.Comm_SyringePump.Sy_Outage);
                            Thread.Sleep(2000);
                            //发送15V断电
                            SendOrder(port_main, Cls.Comm_SyringePump.Syringe_FifClose);
                            Thread.Sleep(2000);
                            //等待2s后，发送15V上电
                            SendOrder(port_main, Cls.Comm_SyringePump.Syringe_FifOpen);
                        }
                        else
                        {
                            M_buffer_hpump.RemoveAt(0);
                        }
                        #endregion
                    }
                    else if (M_buffer_hpump[0] == 0xFF && M_buffer_hpump[1] == 0x3C)
                    {
                        #region 主界面抗凝泵图标状态转换
                        //主界面抗凝泵图标状态转变
                        //wss 2016年2月19日
                        if (checkOutHPump(M_buffer_hpump))
                        {
                            this.Invoke((EventHandler)(delegate
                            {
                                this.tsbtnSP.Image = Properties.Resources.sp30off;
                                this.tsbtnSP.Tag = "spoff";
                            }));
                            M_buffer_hpump.RemoveRange(0, 5);
                        }
                        else
                        {
                            M_buffer_hpump.RemoveAt(0);
                        }
                    }
                    else if (M_buffer_hpump[0] == 0xFF && M_buffer_hpump[1] == 0x3D)
                    {
                        if (checkOutHPump(M_buffer_hpump))
                        {
                            this.Invoke((EventHandler)(delegate
                            {
                                this.tsbtnSP.Image = Properties.Resources.sp30on;
                                this.tsbtnSP.Tag = "spon";
                            }));
                            M_buffer_hpump.RemoveRange(0, 5);
                        }
                        else
                        {
                            M_buffer_hpump.RemoveAt(0);
                        }
                        #endregion
                    }
                    else
                    {
                        //如果数据开始不是头，则删除数据  
                        M_buffer_hpump.RemoveAt(0);
                    }

                    #region 接收命令Log
                    //this.BeginInvoke((EventHandler)(delegate
                    //{
                    //    //依次的拼接出16进制字符串  
                    //    M_strb_hpump.Append(port_hpump.PortName + "(" + buffcount + "):");
                    //    foreach (byte b in buf)
                    //    {
                    //        M_strb_hpump.Append(b.ToString("X2") + " ");
                    //    }
                    //    M_strb_hpump.Append("\r\n");
                    //    //追加的形式添加到文本框末端，并滚动到最后。  
                    //    //this.txtRecieve.AppendText(M_strb_hpump.ToString());
                    //    M_strb_hpump.Clear();
                    //}));
                    #endregion
                }
            }
            catch { }
            finally
            {
                M_Listening_hpump = false;
            }
        }

        /// <summary>
        /// 注射器界面状态改变
        /// </summary>
        /// <param name="_tipInfo">提示文字</param>
        /// <param name="_tipColor">文字颜色</param>
        /// <param name="_clearWarnEnabled">清除警报按键是否可用</param>
        /// <param name="_exsitsWarn"></param>
        /// <param name="_stopSP">是否需要停止抗凝剂泵</param>
        void ShowSPState(string _tipInfo, Color _tipColor, bool _clearWarnEnabled, bool _exsitsWarn, bool _stopSP)
        {
            //需要停泵时，关闭串口2数据读取；2016年8月26日
            if (_stopSP)
                M_Closing_hpump = true;

            this.BeginInvoke((EventHandler)(delegate
            {
                if (M_uc_OtherSet != null)
                {
                    M_uc_OtherSet.Syringe_state.Text = _tipInfo;
                    M_uc_OtherSet.Syringe_state.ForeColor = _tipColor;
                    //电机运行错误的时候清除警报
                    if (_tipInfo == "电机运行错误")
                    {
                        m_ctsFastSP.Cancel();
                        //电机运行错误时发送15V断电，等待后上电，发送端口COM1
                        SendOrder(port_main, Cls.Comm_SyringePump.Syringe_FifClose);
                        //按钮状态恢复
                        M_uc_OtherSet.btnStop_Click(M_uc_OtherSet.btnStopSP, new EventArgs());
                        Thread.Sleep(2000);
                        SendOrder(port_main, Cls.Comm_SyringePump.Syringe_FifOpen);
                        return;
                    }
                    M_uc_OtherSet.Sy_ClearWarning.Enabled = _clearWarnEnabled;
                    if (_stopSP)
                    {
                        m_ctsFastSP.Cancel();
                        M_uc_OtherSet.btnStop_Click(M_uc_OtherSet.btnStopSP, new EventArgs());
                    }

                    //if (_tipInfo == "电机运行错误")
                    //    Cls.utils.SendOrder(port_data, Cls.Comm_SyringePump.Sy_Outage);
                    //肝素泵按钮状态 
                    //if (!_tipInfo.Equals("注射接近完成") || !_tipInfo.Equals("状态正常"))
                    //{
                    //    getLog.WriteLogFile("frmForm,ShowSPState(),4266,调用SetSPButton(false)");
                    //    getLog.WriteLogFile("frmForm,"+_tipInfo+"4268");
                    //    M_uc_OtherSet.SetSPButton(false);
                    //}
                    M_uc_OtherSet.Syringe_state.Refresh();
                }
            }));
        }
        /// <summary>
        /// 异或校验
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        bool checkOut(List<byte> _input)
        {
            int len = _input[2];
            //如果接收的命令长度小于数据长度+4，则弃掉该命令
            if (_input.Count < len + 5)
                return false;
            byte checksum = _input[0];
            for (int i = 1; i < len + 3; i++)
            {
                checksum ^= _input[i];
            }
            if (checksum != _input[len + 3])
                return false;
            else
                return true;
        }

        bool checkOutHPump(List<byte> _input)
        {
            int len = _input[2];
            //bool reval = false;
            //如果接收的命令长度小于数据长度+4，则弃掉该命令
            if (_input.Count < len + 5)
                return false;
            byte checksum = _input[0];
            for (int i = 1; i < len + 3; i++)
            {
                checksum ^= _input[i];
            }
            if (checksum != _input[len + 3])
                return false;
            else
                return true;
            //return reval;
        }

        /// <summary>
        /// 蠕动泵串口接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void port_ppump_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Thread.Sleep(30);
            //if (M_Closing_ppump) return;
            //try
            //{
            //    M_Listening_ppump = true;
            //    int n = port_ppump.BytesToRead;
            //    byte[] buf = new byte[n];
            //    port_ppump.Read(buf, 0, n);
            //    M_buffer_ppump.AddRange(buf);
            //    //M_strb_ppump.Clear();//清除字符串构造器的内容
            //    while (M_buffer_ppump.Count >= 5)
            //    {
            //        #region E9 01 02 57 4A + 校验
            //        if (M_buffer_ppump[0] == 0xE9)
            //        {
            //            M_SendSuccessPump = true;
            //            int len = M_buffer_ppump[2];
            //            if (M_buffer_ppump.Count < len + 4) break;
            //            //if (M_buffer_ppump[3] == 0x57 && M_buffer_ppump[4] == 0x4A)
            //            //{
            //            //    M_SendSuccessPump = true;
            //            //    M_buffer_ppump.RemoveRange(0, len + 4);
            //            //}
            //            //else
            //            //    M_buffer_ppump.RemoveRange(0, len + 4);
            //        }
            //        #endregion
            //        else
            //        {
            //            //如果数据开始不是头，则删除数据  
            //            M_buffer_ppump.RemoveAt(0);
            //        }
            //    }
            //    //this.BeginInvoke((EventHandler)(delegate
            //    //{
            //    //    //依次的拼接出16进制字符串
            //    //    foreach (byte b in buf)
            //    //    {
            //    //        M_strb_ppump.Append(b.ToString("X2") + " ");
            //    //    }
            //    //    this.txtRecieve.AppendText(M_strb_ppump.ToString());
            //    //}));
            //}
            //catch { }
            //finally
            //{
            //    M_Listening_ppump = false;
            //}
            ////throw new NotImplementedException();
        }

        /// <summary>
        /// Crc校验
        /// </summary>
        /// <param name="crcbuf"></param>
        private void CalcCrc(byte crcbuf)
        {
            byte i;
            crc = crc ^ crcbuf;
            for (i = 0; i < 8; i++)
            {
                uint TT;
                TT = crc & 1;
                crc = crc >> 1;
                crc = crc & 0x7fff;
                if (TT == 1)
                {
                    crc = crc ^ 0xa001;
                }
                crc = crc & 0xffff;
            }
        }

        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <param name="_sp">串口</param>
        /// <param name="_name">串口名</param>
        /// <param name="_baudrate">波特率</param>
        /// <param name="_databits">数据位</param>
        /// <param name="_stopbits">停止位</param>
        /// <param name="_parity">奇偶校验</param>
        private bool InitComm(SerialPort _sp, string _name, int _baudrate, int _databits, System.IO.Ports.StopBits _stopbits, System.IO.Ports.Parity _parity)
        {
            if (_sp.IsOpen)
            {
                _sp.Close();
                Thread.Sleep(TimeSpan.FromSeconds(0.3));
            }
            _sp.PortName = _name;
            _sp.BaudRate = _baudrate;
            _sp.DataBits = _databits;
            _sp.StopBits = _stopbits;
            _sp.Parity = _parity;
            _sp.ReadTimeout = 500;
            _sp.WriteTimeout = 500;
            _sp.RtsEnable = false;
            _sp.DtrEnable = false;
            _sp.ReceivedBytesThreshold = 5;
            _sp.ReadBufferSize = 2048;
            _sp.WriteBufferSize = 2048;
            // _sp.NewLine = "\r\n";
            try { _sp.Open(); return true; }
            catch { return false; }
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            //如果正在治疗，不允许退出
            if (M_isTreat)
            {
                MessageBox.Show(this, "正在治疗，不允许退出！");
                //toolStripControl_ItemClicked(tsbtnTherapy, new ToolStripItemClickedEventArgs(tsbtnTherapy));
                //tsbtnTherapy_Click(tsbtnTherapy, e);
                M_BackCheckedInterface();
                return;
            }

            if (M_isFlush)
            {
                MessageBox.Show(this, "正在预冲，不允许退出！");
                toolStripControl_ItemClicked(tsbtnTherapy, new ToolStripItemClickedEventArgs(tsbtnPreFlush));
                tsbtnPreflush_Click(tsbtnPreFlush, e);
                M_BackCheckedInterface();
                return;
            }

            UserCtrl.MsgBox m = new UserCtrl.MsgBox("确定退出？", UserCtrl.MsgBox.MSBoxIcon.Question, ALS.Properties.Resources.thanks, true);
            if (DialogResult.OK == m.ShowDialog())
            {
                string type = string.Empty;
                if (M_modeName == "PERT") type = "PEF";
                else
                    type = M_modeName;

                long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                m_PatientInfo = new Cls.Model_PatientInfo()
                {
                    Type = type,
                    SurgeryNo = DateTime.Now.ToString("yyMMddHHmmss"),
                    StartTime = (epoch * 1000 + DateTime.Now.Millisecond).ToString()
                };
                //序列化            
                m_strStartEnd = SJson(m_PatientInfo);
                Cls.utils.AddText("END:" + m_strStartEnd);

                Sp_NearCom = false;
                this.toolStripControl.Enabled = false;
                this.toolStripOther.Enabled = false;
                DoExitProgress();
                //Exit();
            }
            else
            {
                M_BackCheckedInterface();
                //toolStripControl_ItemClicked(tsbtnTherapy, new ToolStripItemClickedEventArgs(tsbtnHome));
                //tsbtnHome_Click(tsbtnHome, e);
            }
        }

        public void DoExitProgress()
        {
            var progressExit = new Progress<Cls.StatusProgress>();
            progressExit.ProgressChanged += progressExit_ProgressChanged;
            m_watchUnreleaseWarn.Restart();
            Task t = ExitSystem(progressExit);
        }

        void progressExit_ProgressChanged(object sender, Cls.StatusProgress e)
        {
            //更新UI
            if (e.Success == false)
            {
                m_frmExit.btnExit.Visible = true;
                m_frmExit.btnExit.Enabled = true;
                m_frmExit.rtbox.SelectionColor = Color.Red;
            }
            m_frmExit.rtbox.AppendText(e.Tipinfo);
            m_frmExit.pb.Value = e.Current;
        }

        async Task ExitSystem(IProgress<Cls.StatusProgress> progress)
        {
            m_frmExit.Show();
            m_frmExit.TopMost = true;
            int total = 100;
            await Task.Delay(200);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "正在退出···", Current = 10, Total = total, Success = true });
            await Task.Delay(200);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 15, Total = total, Success = true });
            await Task.Delay(200);
            M_isStart = false;
            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose);
            SendOrder(port_main, Cls.Comm_Main.CmdTemperature.StopHT);
            SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble1);
            SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble2);
            SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble3);
            SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x01, 0x01, 0x01, 0x01, 0x01, 0x01));
            //停止注射泵
            SendOrder(port_hpump, Cls.Comm_SyringePump.Stop);
            //退出时清除累积量
            //wss 2015年12月29日
            SendOrder(port_hpump, Cls.Comm_SyringePump.ClearCumulant);

            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 50, Total = total, Success = true });
            await Task.Delay(200);

            //if (port_ppump.IsOpen)
            //{
            //    M_Closing_ppump = true;
            //    while (M_Listening_ppump) Application.DoEvents();
            //    port_ppump.Close();
            //}

            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 60, Total = total, Success = true });
            await Task.Delay(200);

            if (port_data.IsOpen)
            {
                M_Closing_data = true;
                while (M_Listening_data)
                {
                    if (m_watchUnreleaseWarn.ElapsedMilliseconds > 5000)
                        m_frmExit.btnExit.Visible = true;
                    Application.DoEvents();
                }
                port_data.Close();
            }
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 70, Total = total, Success = true });
            await Task.Delay(200);
            if (port_hpump.IsOpen)
            {
                M_Closing_hpump = true;
                while (M_Listening_hpump)
                {
                    if (m_watchUnreleaseWarn.ElapsedMilliseconds > 5000)
                        m_frmExit.btnExit.Visible = true;
                    Application.DoEvents();
                }
                port_hpump.Close();
            }
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 80, Total = total, Success = true });
            await Task.Delay(200);
            if (port_main.IsOpen)
            {
                M_Closing_main = true;
                while (M_Listening_main)
                {
                    if (m_watchUnreleaseWarn.ElapsedMilliseconds > 10000)
                        m_frmExit.btnExit.Visible = true;
                    Application.DoEvents();
                }
                port_main.Close();
            }
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 90, Total = total, Success = true });
            //await Task.Delay(200);
            //if (port_pumpstatus.IsOpen)
            //{
            //    M_Closing_pumpstatus = true;
            //    while (M_Listening_pumpstatus)
            //    {
            //        if (m_watchExit.ElapsedMilliseconds > 10000)
            //            m_frmExit.btnExit.Visible = true;
            //        Application.DoEvents();
            //    }
            //    port_pumpstatus.Close();
            //}

            if (m_frmAdmin != null)
            {
                m_frmAdmin.Dispose();
            }
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·完成", Current = 100, Total = total, Success = true });
            await Task.Delay(200);
            Application.ExitThread();
            Application.Exit();
        }


        private void tsbtnSetFlow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_modeName))
            {
                MessageBox.Show(this, "请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowP(_style.w180);
            layoutPump.Visible = false;
            M_ModelTreat = GetTreatmentModel(M_modeName);
            M_uc_SetFlow._TreatMode = M_ModelTreat;
            M_uc_SetFlow._ModelPumpState = M_PumpState;
            M_uc_SetFlow.palDehydration.Visible = true;
            M_uc_SetFlow.btnReturn.Visible = false;
            M_uc_SetFlow.btnConfirmM.Visible = false;
            /*流量设置界面屏蔽泵运转按键 2017年2月27日
             * 若在治疗开始前，在流量设置界面运转泵时，点击右下角开始按键
             * 会导致软件直接进入了非正常治疗。屏蔽运转按键，目的是屏蔽手动治疗
            */
            M_uc_SetFlow.btnRun1.Visible = false;
            M_uc_SetFlow.btnRun2.Visible = false;
            M_uc_SetFlow.btnRun3.Visible = false;
            M_uc_SetFlow.btnRun4.Visible = false;
            M_uc_SetFlow.btnRun5.Visible = false;
            M_uc_SetFlow.btnRun6.Visible = false;

            M_uc_SetFlow.ReadPumpSet(M_ModelTreat);
            M_uc_SetFlow.ReadVState(M_PumpState);
            SetOtherfrmBtnState(M_PumpState);
            M_uc_SetFlow.groupSet.Text = "流量设置";
            if (!this.palContent.Controls.Contains(M_uc_SetFlow))
                this.palContent.Controls.Add(M_uc_SetFlow);
            this.palContent.Controls.SetChildIndex(M_uc_SetFlow, 0);
            M_uc_SetFlow.BringToFront();
            M_uc_SetFlow.Dock = DockStyle.Fill;
        }

        void M_uc_SetFlow_btnReadset(object sender, EventArgs e)
        {
            //重新读取设置
            M_ModelTreat = GetTreatmentModel(M_modeName);
        }

        public void ReadSet(Model.treatmentmode ms)
        {
            this.tsbtnSP.Text = ms.SP_Speed.Value.ToString("f1") + " mL/h";

            //-----------------------FP------------------------
            if (M_ModelTreat.FPValid)
            {
                this.uc_SpeedFP._SpeedValue = ms.FPSpeed.Value.ToString("f0");
                this.uc_SpeedFP._VisiblePicpump = true;
                this.uc_SpeedFP.Enabled = true;
                this.uc_SpeedFP.Visible = true;
            }
            else
            {
                this.uc_SpeedFP.Enabled = false;
            }
            //-----------------------DP------------------------
            if (M_ModelTreat.DPValid)
            {
                this.uc_SpeedDP._SpeedValue = ms.DPSpeed.Value.ToString("f0");
                this.uc_SpeedDP._VisiblePicpump = true;
                this.uc_SpeedDP.Enabled = true;
                this.uc_SpeedDP.Visible = true;
            }
            else
            {
                this.uc_SpeedDP.Enabled = false;
            }

            //-----------------------RP------------------------
            if (M_ModelTreat.RPValid)
            {
                this.uc_SpeedRP._SpeedValue = ms.RPSpeed.Value.ToString("f0");
                this.uc_SpeedRP._VisiblePicpump = true;
                this.uc_SpeedRP.Enabled = true;
                this.uc_SpeedRP.Visible = true;
            }
            else
            {
                this.uc_SpeedRP.Enabled = false;
            }
            //-----------------------FP2------------------------
            if (M_ModelTreat.FP2Valid)
            {
                this.uc_SpeedFP2._SpeedValue = ms.FP2Speed.Value.ToString("f0");
                this.uc_SpeedFP2._VisiblePicpump = true;
                this.uc_SpeedFP2.Enabled = true;
                this.uc_SpeedFP2.Visible = true;
            }
            else
            {
                this.uc_SpeedFP2.Enabled = false;
            }
            //-----------------------CP------------------------
            if (M_ModelTreat.CPValid)
            {
                this.uc_SpeedCP._SpeedValue = ms.CPSpeed.Value.ToString("f0");
                this.uc_SpeedCP._VisiblePicpump = true;
                this.uc_SpeedCP.Enabled = true;
                this.uc_SpeedCP.Visible = true;
            }
            else
            {
                this.uc_SpeedCP.Enabled = false;
            }

            //-----------------------dehydration------------------------
            if (M_ModelTreat.dehydrationValid)
            {
                M_uc_Treat.lblDehydrationSpeed.Text = ms.dehydrationSpeed.ToString();
            }
            else
            {
                M_uc_Treat.lblDehydrationSpeed.Text = "0.0";
            }


            //this.lblHT.Text = ms.TargetTemperature.ToString();
            //TimeSpan ts = new TimeSpan(0, 0, ms.IsTargetTime);
            //this.lblTargetTime.Text = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00"); 
        }
        void M_uc_Treat_btnChangePumpSpeed(object sender, EventArgs e)
        {
            if (m_lstSysWarn.Count > 0)
            {
                MessageBox.Show(this, "请先消除警报", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserCtrl.uc_PumpSpeed up = (UserCtrl.uc_PumpSpeed)sender;
            UserCtrl.numPad np = new UserCtrl.numPad(up._SpeedValue);
            np.btnDot.Visible = false;
            np.btnNegPos.Visible = false;
            if (DialogResult.OK == np.ShowDialog())
            {
                switch (up.Tag.ToString())
                {
                    #region 改变FP速度
                    case "fp":
                        if (np.Value > 150 || np.Value < 0)
                        {
                            MessageBox.Show(this, "请将泵速设置在 150mL/min 以内!");
                            return;
                        }
                        if (np.Value > M_ModelTreat.BPSpeed * M_ModelTreat.Concentration / 100.0)
                        {
                            MessageBox.Show(this, "过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                            return;
                        }
                        switch (M_ModelTreat.name)
                        {
                            case "PE":
                            case "PERT":
                                M_ModelTreat.FPSpeed = M_ModelTreat.RPSpeed = np.Value;
                                //改变速度后的动作
                                if (M_PumpState.FPState.Runing)
                                {
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed.Value, true, false));
                                }
                                break;
                            case "CHDF":
                                //如果设置的FP速度小于其他两个泵速度之和
                                if (np.Value < M_ModelTreat.RPSpeed.Value + M_ModelTreat.DPSpeed.Value)
                                {
                                    M_ModelTreat.DPSpeed = 0;
                                    M_ModelTreat.FPSpeed = np.Value;
                                    M_ModelTreat.RPSpeed = M_ModelTreat.FPSpeed.Value;
                                }
                                else
                                {
                                    M_ModelTreat.FPSpeed = np.Value;
                                    M_ModelTreat.RPSpeed = M_ModelTreat.FPSpeed.Value - M_ModelTreat.DPSpeed.Value;
                                }


                                if (M_PumpState.FPState.Runing)
                                {
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false));
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed.Value, true, false));
                                }
                                break;
                            case "PP":
                                M_ModelTreat.FPSpeed = np.Value;
                                if (M_PumpState.FPState.Runing)
                                {
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                                }
                                break;
                            case "PDF"://医护人员自行计算的速度
                                M_ModelTreat.FPSpeed = np.Value;
                                if (M_PumpState.FPState.Runing)
                                {
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                                }
                                break;
                            case "Li-ALS":
                                M_ModelTreat.FPSpeed = M_ModelTreat.DPSpeed = np.Value;
                                //改变速度后的动作
                                if (M_PumpState.FPState.Runing)
                                {
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false));
                                }
                                break;
                        }
                        break;
                    #endregion

                    #region 改变DP速度
                    case "dp":
                        if (np.Value > 250 || np.Value < 0)
                        {
                            MessageBox.Show("请将泵速设置在 250mL/min 以内!");
                            return;
                        }
                        switch (M_ModelTreat.name)
                        {
                            case "PERT":
                                if (np.Value > M_ModelTreat.FPSpeed.Value)
                                {
                                    MessageBox.Show("不符合规范的速度,请重新设置!");
                                    return;
                                }
                                M_ModelTreat.DPSpeed = np.Value;
                                break;
                            case "CHDF":
                                if (np.Value > M_ModelTreat.FPSpeed)
                                {
                                    MessageBox.Show("不符合规范的速度,请重新设置!");
                                    return;
                                }
                                M_ModelTreat.DPSpeed = np.Value;
                                M_ModelTreat.RPSpeed = M_ModelTreat.FPSpeed.Value - M_ModelTreat.DPSpeed.Value;
                                break;
                            case "PDF":
                                if (np.Value > M_ModelTreat.FPSpeed.Value * 1.2)
                                    np.Value = M_ModelTreat.FPSpeed.Value * 1.2;
                                if (np.Value < M_ModelTreat.FPSpeed.Value * 0.8)
                                    np.Value = M_ModelTreat.FPSpeed.Value * 0.8;
                                M_ModelTreat.DPSpeed = np.Value;
                                break;
                            case "Li-ALS":
                                if (np.Value > M_ModelTreat.BPSpeed * M_ModelTreat.Concentration / 100.0)
                                {
                                    MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                                    return;
                                }
                                M_ModelTreat.FPSpeed = M_ModelTreat.DPSpeed = np.Value;
                                break;
                        }
                        if (M_PumpState.DPState.Runing)
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false));
                            if (M_modeName.ToLower() == "li-als")
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        }
                        break;
                    #endregion

                    #region 改变RP速度
                    case "rp":
                        switch (M_ModelTreat.name)
                        {
                            case "PE":
                            case "PERT":
                                //判断过浓缩
                                if (np.Value > M_ModelTreat.BPSpeed * M_ModelTreat.Concentration / 100.0)
                                {
                                    MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                                    return;
                                }
                                M_ModelTreat.FPSpeed = M_ModelTreat.RPSpeed = np.Value;
                                this.uc_SpeedFP._SpeedValue = this.uc_SpeedRP._SpeedValue = np.Value.ToString("f0");
                                if (M_PumpState.RPState.Runing)
                                {
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed.Value, true, false));
                                }
                                break;
                            case "CHDF":
                                if (np.Value > M_ModelTreat.FPSpeed)
                                    np.Value = M_ModelTreat.FPSpeed.Value;
                                M_ModelTreat.RPSpeed = np.Value;
                                M_ModelTreat.DPSpeed = M_ModelTreat.FPSpeed.Value - M_ModelTreat.RPSpeed.Value;

                                if (M_PumpState.FPState.Runing)
                                {
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false));
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed.Value, true, false));
                                }
                                break;
                            case "PDF":
                                if (np.Value > M_ModelTreat.FPSpeed.Value * 1.2)
                                    np.Value = M_ModelTreat.FPSpeed.Value * 1.2;
                                if (np.Value < M_ModelTreat.FPSpeed.Value * 0.8)
                                    np.Value = M_ModelTreat.FPSpeed.Value * 0.8;
                                M_ModelTreat.RPSpeed = np.Value;
                                break;
                            case "Li-ALS":
                                //判断过浓缩
                                if (np.Value > M_ModelTreat.BPSpeed * M_ModelTreat.Concentration / 100.0)
                                {
                                    MessageBox.Show("过浓缩，请重新设置速度或检查 <其他设置> → <警报设置> → <过浓缩设置>!");
                                    return;
                                }
                                M_ModelTreat.FP2Speed = M_ModelTreat.RPSpeed = np.Value;
                                break;
                        }

                        break;
                    #endregion

                    #region 改变FP2速度
                    case "fp2":
                        if (np.Value > 150 || np.Value < 0)
                        {
                            MessageBox.Show(this, "请将泵速设置在 150mL/min 以内!");
                            return;
                        }
                        switch (M_ModelTreat.name)
                        {
                            case "Li-ALS":
                                //FP2速度限制 准备回收时，可调节+5ml/min
                                if (np.Value > M_ModelTreat.RPSpeed.Value * 1.2)
                                {
                                    if (np.Value - M_ModelTreat.RPSpeed.Value > 5)
                                        np.Value = M_ModelTreat.RPSpeed.Value + 5;
                                }
                                if (np.Value < M_ModelTreat.RPSpeed.Value * 0.8)
                                    np.Value = M_ModelTreat.RPSpeed.Value * 0.8;
                                M_ModelTreat.FP2Speed = np.Value;
                                break;
                            case "PDF":
                                if (np.Value > M_ModelTreat.FPSpeed.Value * 1.2)
                                    np.Value = M_ModelTreat.FPSpeed.Value * 1.2;
                                if (np.Value < M_ModelTreat.FPSpeed.Value * 0.8)
                                    np.Value = M_ModelTreat.FPSpeed.Value * 0.8;
                                M_ModelTreat.FP2Speed = np.Value;
                                break;
                        }
                        if (M_PumpState.FP2State.Runing)
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelTreat.FP2Speed.Value, true, false));
                        break;
                    #endregion

                    #region 改变CP速度
                    case "cp":
                        if (np.Value > 250 || np.Value < 0)
                        {
                            MessageBox.Show(this, "请将泵速设置在 250mL/min 以内!");
                            return;
                        }
                        M_ModelTreat.CPSpeed = np.Value;
                        if (M_PumpState.CPState.Runing)
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelTreat.CPSpeed.Value, true, true));
                        break;
                    #endregion
                }

                if (new BLL.treatmentmode().Update(M_ModelTreat))
                {
                    M_uc_Treat.ReadSet(M_ModelTreat);
                    this.uc_SpeedFP._SpeedValue = M_ModelTreat.FPSpeed.Value.ToString("f0");
                    if (M_ModelTreat.DPValid)
                        this.uc_SpeedDP._SpeedValue = M_ModelTreat.DPSpeed.Value.ToString("f0");
                    if (M_ModelTreat.RPValid)
                        this.uc_SpeedRP._SpeedValue = M_ModelTreat.RPSpeed.Value.ToString("f0");
                    if (M_ModelTreat.FP2Valid)
                        this.uc_SpeedFP2._SpeedValue = M_ModelTreat.FP2Speed.Value.ToString("f0");
                    if (M_ModelTreat.CPValid)
                        this.uc_SpeedCP._SpeedValue = M_ModelTreat.CPSpeed.Value.ToString("f0");
                }
            }
        }
        void M_uc_SetFlow_btnRun_Pump(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn.Tag != null)
                {
                    int id = Convert.ToInt16(btn.Tag.ToString());
                    switch (id)
                    {
                        case 1:
                            if (btn.Text == "运转")
                            {
                                if (M_PumpState.VState[0] == 0x00 && M_PumpState.VState[1] == 0x00)
                                {
                                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelTreat.BPSpeed.Value, true, true));
                                }
                                else
                                {
                                    string msg = string.Empty;
                                    if (M_PumpState.VState[0] == 0x01)
                                        msg = "请将夹管阀1松开;\r\n";
                                    if (M_PumpState.VState[1] == 0x01)
                                        msg += "请将夹管阀2松开;";
                                    MessageBox.Show(this, msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                            else
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 0, false, true));
                            }
                            break;
                        case 2:
                            if (btn.Text == "运转")
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                            else
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                            break;

                        case 3:
                            if (btn.Text == "运转")
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelTreat.DPSpeed.Value, true, false));
                            else
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, false));
                            break;

                        case 4:
                            if (btn.Text == "运转")
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelTreat.RPSpeed.Value, true, false));
                            else
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, false));
                            break;

                        case 5:
                            if (btn.Text == "运转")
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelTreat.FP2Speed.Value, true, false));
                            else
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, 0, false, false));
                            break;
                        case 6:
                            if (btn.Text == "运转")
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelTreat.CPSpeed.Value, true, true));
                            else
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, 0, false, true));
                            break;
                        //case 31:  
                        //    RunStartPumpTreatTask();
                        //    //点击全运转后，[全运转]置灰 
                        //    break;
                        //case 32:
                        //    StopPump();
                        //break;
                    }
                }
                //SetOtherfrmBtnState(M_PumpState);
            }
            //throw new NotImplementedException();
        }


        //private void tsbtnMethod_Click(object sender, EventArgs e)
        //{
        //    M_uc_Method.Port_Main = port_main;
        //    M_uc_Method.Port_Pump = port_ppump;
        //    if (!this.palContent.Controls.Contains(M_uc_Method))
        //        this.palContent.Controls.Add(M_uc_Method);
        //    this.palContent.Controls.SetChildIndex(M_uc_Method, 0);
        //    M_uc_Method.BringToFront();
        //    M_uc_Method.Dock = DockStyle.Fill;
        //    palP.Visible = false;
        //    //frmSetMethod frmSm = new frmSetMethod();
        //    //frmSm.Port_Main = port_main;
        //    //frmSm.Port_Pump = port_ppump;
        //    //if (DialogResult.OK == frmSm.ShowDialog())
        //    //{
        //    //    M_modeName = frmSm._Method;
        //    //    frmSm.btnOK.Tag = M_modeName;
        //    //    M_uc_Method_btnOkClicked(frmSm.btnOK, e);
        //    //}
        //}

        //void M_uc_Method_btnOkClicked(object sender, EventArgs e)
        //{
        //    Button b = sender as Button;
        //    if (this.M_modeName != b.Tag.ToString())
        //    {
        //        this.M_modeName = b.Tag.ToString();
        //        //初始化标志变量
        //        //是否已经选择预冲方式
        //        M_SelFlushType = 0;
        //        //是否正进行治疗
        //        M_isTreat = false;
        //        //管路是否安装完成
        //        M_bl_isFinishPipeline = false;
        //        //是否完成预冲
        //        M_bl_isFinishFlush = false;
        //        //是否完成治疗
        //        M_bl_isFinishTreat = false;
        //        //初始化累计值
        //        ZeroTotal();
        //        ZeroTuoshui();
        //        this.btnStart.Enabled = false;
        //        m_leadBloodSpeed = 0;
        //        //读取默认配置
        //        M_ModelTreat = GetTreatmentModel(M_modeName);
        //        M_uc_Treat.palDry.Enabled = false;
        //        M_uc_Treat.chkBalance.Enabled = false;
        //        M_uc_Treat.btnChange.Enabled = false;
        //    }
        //    //每次重新选择模式，对应模式向导控件从头开始显示
        //    //wss 2016年2月25日
        //    switch (M_modeName)
        //    {
        //        case "PE":
        //            m_stepPE.wizardControl1.RestartPages(); ChangeShowPControlEnabled("pe"); break;
        //        case "PP":
        //            m_stepPP.wizardControl1.RestartPages(); ChangeShowPControlEnabled("pp"); break;
        //        case "CHDF":
        //            m_stepCHDF.wizardControl1.RestartPages(); ChangeShowPControlEnabled("chdf"); break;
        //        case "Li-ALS":
        //            m_stepLiALS.wizardControl1.RestartPages(); ChangeShowPControlEnabled("li-als"); break;
        //        case "PDF":
        //            m_stepPDF.wizardControl1.RestartPages(); ChangeShowPControlEnabled("pdf"); break;
        //        case "PERT":
        //            m_stepPERT.wizardControl1.RestartPages(); ChangeShowPControlEnabled("pert"); break;
        //        default: break;
        //    }

        //    //PERT 修改为 PEF
        //    if (M_modeName == "PERT")
        //        this.lblMethod.Text = "PEF";
        //    else
        //        this.lblMethod.Text = M_modeName;

        //    toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnPipeline));
        //    tsbtnPipeline_Click(tsbtnPipeline, e);
        //}

        void ReadFlush()
        {
            switch (M_modeName)
            {
                case "Li-ALS":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("lialsflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("lialsflush2"));
                    break;
                case "PE":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("peflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("peflush2"));
                    break;
                case "CHDF":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("chdfflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("chdfflush2"));
                    break;
                case "PP":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("ppflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("ppflush2"));
                    break;
                case "PERT":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("pefflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("pefflush2"));
                    break;
                case "PDF":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("pdfflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("pdfflush2"));
                    break;
            }
            //this.lblRequire.Text = dRequire.ToString("f0");

            ////读取模式的预冲量
            //switch (M_modeName)
            //{
            //    case "PE":
            //        dPEFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("PEFlushIn")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("PEFlushOut"));
            //        break;
            //    case "CHDF":
            //        dCHDFFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("CHDFFlushIn")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("CHDFFlushOut"));
            //        break;
            //    case "PP":
            //        dPPFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("PPFlushIn")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("PPFlushSec"));
            //        break;
            //    case "Li-ALS":
            //        dLiALSFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("Li-ALS_Flush"));
            //        break;
            //}
            startWeigh2 = M_ModelValue.M_flt_Weigh2;
        }



        private void tsbtnPipeline_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_modeName))
            {
                MessageBox.Show(this, "请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            layoutPump.Visible = false;
            ShowP(_style.hide);
            ShowPipeLine();
        }

        private void ShowPipeLine()
        {
            pipeLine.M_int_CurrentIndex = 0;
            pipeLine.InitItems(M_modeName);
            pipeLine.btnNext.Text = "下一步";
            pipeLine.SetBackColor(0);
            if (!this.palContent.Controls.Contains(pipeLine))
                this.palContent.Controls.Add(pipeLine);
            this.palContent.Controls.SetChildIndex(pipeLine, 0);
            pipeLine.BringToFront();
            pipeLine.Dock = DockStyle.Fill;
        }

        void M_uc_Pipeline_btnNextClicked(object sender, EventArgs e)
        {
            Button btnNext = sender as Button;
            if (btnNext.Text == "完成")
            {
                M_bl_isFinishPipeline = true;
                toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnPreFlush));
                tsbtnPreflush_Click(tsbtnPreFlush, e);
            }
            //throw new NotImplementedException();
        }

        enum _style
        {
            w180, w300, hide
        };
        private void ShowP(_style s)
        {
            switch (s)
            {
                case _style.w180:
                    gBoxP.Visible = true;
                    //foreach (Control c in this.layoutP.Controls)
                    //{
                    //    UserCtrl.uc_p u = (UserCtrl.uc_p)c;
                    //    u.colorSliderBar1.Visible = false;
                    //}
                    gBoxP.Width = 113;
                    break;
                case _style.w300:
                    gBoxP.Visible = true;
                    //foreach (Control c in this.layoutP.Controls)
                    //{
                    //    UserCtrl.uc_p u = (UserCtrl.uc_p)c;
                    //    u.colorSliderBar1.Visible = true;
                    //}
                    gBoxP.Width = 300;
                    break;
                case _style.hide:
                    gBoxP.Visible = false;
                    break;
            }
        }
        private void tsbtnPreflush_Click(object sender, EventArgs e)
        {
            //先判断管路是否安装完成
            if (!M_bl_isFinishPipeline)
            {
                MessageBox.Show(this, "请确认管路安装!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                M_BackCheckedInterface();
                return;
            }
            ReadFlush();
            //进入预冲界面,【开始】按键不可操作
            this.tsbtnPreFlush.Enabled = true;
            this.btnStart.Enabled = false;
            //如果没选择预冲方式 0 未选择 1 自动 2 手动
            switch (M_SelFlushType)
            {
                case 0://未选择，出现选择预冲方式界面
                    layoutPump.Visible = false;
                    ShowP(_style.hide);
                    if (!this.palContent.Controls.Contains(M_uc_selFlush))
                        this.palContent.Controls.Add(M_uc_selFlush);
                    //M_uc_AutoFlush._ModelSet = M_ModelTreat;
                    M_uc_selFlush.Dock = DockStyle.Fill;
                    M_uc_selFlush.BringToFront();
                    //只要进入选择预冲，模式选择、治疗、回收、管路安装、流量设置界面都置灰。
                    //预冲标志量改变
                    //wss 2016年3月11日 
                    this.tsbtnRecycle.Enabled = false;
                    this.tsbtnTherapy.Enabled = false;
                    this.tsbtnPipeline.Enabled = false;
                    this.tsbtnSetFlow.Enabled = false;
                    this.btnStart.Enabled = false;
                    break;
                case 1://自动
                    layoutPump.Visible = false;
                    ShowP(_style.w180);
                    M_uc_selFlush__btnSelAutoFlush(sender, e);
                    break;
                case 2://手动
                    layoutPump.Visible = false;
                    ShowP(_style.w180);
                    M_uc_selFlush__btnSelManualFlush(sender, e);
                    break;
            }
            //添加列表选中状态清除
            //wss 2016年3月1日
            if (!M_isFlush)
            {
                if (!m_isAddFlush)
                    M_uc_AutoFlush.dgvStep.ClearSelection();
            }
        }

        void M_uc_selFlush__btnSelManualFlush(object sender, EventArgs e)
        {
            layoutPump.Visible = false;
            ShowP(_style.w180);
            M_SelFlushType = 2;
            M_uc_SetFlow._ModelPumpState = M_PumpState;
            M_uc_SetFlow._Port_main = port_main;
            SetOtherfrmBtnState(M_PumpState);
            M_uc_SetFlow._TreatMode = M_ModelTreat;
            M_uc_SetFlow.ReadPumpSet(M_ModelTreat);
            M_uc_SetFlow.btnReturn.Visible = true;
            M_uc_SetFlow.btnConfirmM.Visible = true;
            M_uc_SetFlow.groupSet.Text = "手动预冲";
            M_uc_SetFlow.ReadVState(M_PumpState);
            M_uc_SetFlow.palDehydration.Visible = false;

            //只要进入手动预冲，模式选择、治疗、回收、管路安装、流量设置界面都置灰。
            //预冲标志量改变
            //wss 2016年3月11日 
            this.tsbtnRecycle.Enabled = false;
            this.tsbtnTherapy.Enabled = false;
            this.tsbtnPipeline.Enabled = false;
            this.tsbtnSetFlow.Enabled = false;
            this.btnStart.Enabled = false;
            M_isFlush = false;
            M_bl_isFinishFlush = false;

            if (!this.palContent.Controls.Contains(M_uc_SetFlow))
                this.palContent.Controls.Add(M_uc_SetFlow);
            this.palContent.Controls.SetChildIndex(M_uc_SetFlow, 0);
            M_uc_SetFlow.BringToFront();
            M_uc_SetFlow.Dock = DockStyle.Fill;
        }

        void M_uc_SetFlow_btnClickFinish(object sender, EventArgs e)
        {
            this.tsbtnPipeline.Enabled = true;
            this.tsbtnPreFlush.Enabled = true;
            this.tsbtnTherapy.Enabled = true;
            //this.tsbtnRecycle.Enabled = true;
            this.tsbtnSetFlow.Enabled = true;
            this.btnStart.Enabled = true;
            M_bl_isFinishFlush = true;
            M_isFlush = false;
            toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnTherapy));
            tsbtnTherapy_Click(tsbtnTherapy, e);
        }

        void M_uc_SetFlow_btnReturnSelect(object sender, EventArgs e)
        {
            M_SelFlushType = 0;
            //手动预冲返回选择时 预冲状态为不是正在预冲
            M_isFlush = false;
            this.tsbtnSetFlow.Enabled = true;
            //this.tsbtnRecycle.Enabled = true;
            this.tsbtnTherapy.Enabled = true;
            this.tsbtnPipeline.Enabled = true;
            tsbtnPreflush_Click(this.tsbtnPreFlush, e);
            //throw new NotImplementedException();
        }

        void M_uc_selFlush__btnSelAutoFlush(object sender, EventArgs e)
        {
            layoutPump.Visible = false;
            ShowP(_style.w180);
            M_SelFlushType = 1;
            //只要进入自动预冲，模式选择、治疗、回收、管路安装、流量设置界面都置灰。
            //预冲标志量改变
            //wss 2016年3月11日 
            this.tsbtnRecycle.Enabled = false;
            this.tsbtnTherapy.Enabled = false;
            this.tsbtnPipeline.Enabled = false;
            this.tsbtnSetFlow.Enabled = false;
            this.btnStart.Enabled = false;

            switch (M_modeName)
            {
                case "PE":
                    m_AutoFlushName = "PE_Flush";
                    M_uc_AutoFlush.pboxFlush.Image = global::ALS.Properties.Resources.PE;
                    break;
                case "Li-ALS":
                    m_AutoFlushName = "Li-ALS_Flush";
                    M_uc_AutoFlush.pboxFlush.Image = global::ALS.Properties.Resources.LiALSFlush;
                    break;
                case "CHDF":
                     m_AutoFlushName = "CHDF_Flush";
                    M_uc_AutoFlush.pboxFlush.Image = global::ALS.Properties.Resources.CHDF;
                    break;
                case "PDF":
                    m_AutoFlushName = "PDF_Flush";
                    M_uc_AutoFlush.pboxFlush.Image = global::ALS.Properties.Resources.PDF;
                    break;
                case "PERT":
                    m_AutoFlushName = "PERT_Flush";
                    M_uc_AutoFlush.pboxFlush.Image = global::ALS.Properties.Resources.PERT;
                    break;
                case "PP":
                    m_AutoFlushName = "PP_Flush";
                    M_uc_AutoFlush.pboxFlush.Image = global::ALS.Properties.Resources.PP;
                    break;
            }
            M_uc_AutoFlush.m_methodName = m_AutoFlushName;
            M_uc_AutoFlush.ReadFlush();
            // 重新读取预冲步骤
            if (!M_isFlush)
            {
                if (!m_isAddFlush)
                {
                    M_uc_AutoFlush.dgvStep.ClearSelection();
                    m_isExistActions = GetCustCmd(m_AutoFlushName);
                }
            }
            //M_uc_AutoFlush._Port_Main = port_main;
            //M_uc_AutoFlush._Port_Pump = port_ppump;
            if (!this.palContent.Controls.Contains(M_uc_AutoFlush))
                this.palContent.Controls.Add(M_uc_AutoFlush);
            M_uc_AutoFlush.Dock = DockStyle.Fill;
            M_uc_AutoFlush.BringToFront();
            this.palContent.Controls.SetChildIndex(M_uc_AutoFlush, 0);
        }


        void M_uc_AutoFlush_btnStartFlush(object sender, EventArgs e)
        {
            if (!m_isExistActions)
            {
                MessageBox.Show(this, "未定义自动化操作!");
                return;
            }
            this.tsbtnPipeline.Enabled = false;
            this.tsbtnTherapy.Enabled = false;
            this.tsbtnRecycle.Enabled = false;
            this.tsbtnSetFlow.Enabled = false;
            this.lblBloodSpeed.Enabled = false;
            this.btnStart.Enabled = false;
            M_isFlush = true;
            ReadFlush();
            //初始化泵状态
            m_AutoFlushPumpState = new Cls.Model_State();
            byte[] b = m_lstCust[0].tipPic;
            Bitmap bp = null;
            if (b != null)
            {
                MemoryStream ms = new MemoryStream(b);
                bp = (Bitmap)Image.FromStream(ms);
            }
            //弹出对话框，确认信息
            //HPTCMessageBox.MSBox m = new HPTCMessageBox.MSBox("警告", m_lstCust[0].actionName + ",然后点击 “确定” 开始冲洗!", HPTCMessageBox.MSBox.MSBoxIcon.Warning, bp);
            UserCtrl.MsgBox m = new UserCtrl.MsgBox("警告: " + m_lstCust[0].actionName, UserCtrl.MsgBox.MSBoxIcon.Warning, bp, true);
            if (DialogResult.OK == m.ShowDialog())
            {
                M_uc_AutoFlush.btnStart.Enabled = false;
                M_uc_AutoFlush.btnContinue.Enabled = true;
                M_uc_AutoFlush.btnFinish.Enabled = false;
                M_uc_AutoFlush.btnReturn.Enabled = false;
                M_uc_AutoFlush.btnAddFlush.Enabled = false;
                M_uc_AutoFlush.lblTime.Text = "00:00:00";
                int timefull = (int)(m_lstCust[m_lstCust.Count - 1].timeCount + m_lstCust[m_lstCust.Count - 1].timeSpan);// (int)modCust.timeCount + (int)modCust.timeSpan;
                M_uc_AutoFlush.lblFullTime.Text = Cls.utils.SecondsToTime(timefull);

                if (m_taskCustomAction != null)
                {
                    m_taskCustomAction.Dispose();
                }
                //创建自动预冲任务
                //m_taskCustomAction = new Task(RunFlush, m_queueCustSendCmd, TaskCreationOptions.LongRunning);
                M_isFlush = true;
                M_uc_AutoFlush.dgvStep.Enabled = false;
                for (int i = 0; i < M_uc_AutoFlush.dgvStep.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)M_uc_AutoFlush.dgvStep.Rows[i].Cells["selAdd"];
                    checkBox.Value = 0;
                    checkBox.Selected = false;
                    M_uc_AutoFlush.dgvStep.Rows[i].Selected = false;
                }
                m_watchFlush.Start();
                //清空累计值
                m_flushBPTotal = m_flushDPTotal = m_flushRPTotal = 0;
                TaskRunFlush(m_queueCustSendCmd);
            }
        }

        void TaskRunFlush(Queue<Cls.Model_CustomCMD> _cmd)
        {
            m_ctsCustomAction = new CancellationTokenSource();
            m_taskCustomAction = RunFlush(m_ctsCustomAction.Token, _cmd);
        }

        async Task RunFlush(CancellationToken ct, Queue<Cls.Model_CustomCMD> _cmd)
        {
            //int nTime = lstccmd[lstccmd.Count-1]._TimesCount + lstccmd[lstccmd.Count - 1]._LastTime;  
            int fullTimeCount = _cmd.Sum(p => p._LastTime);
            //当前步骤
            Cls.Model_CustomCMD currentStep = new Cls.Model_CustomCMD();
            while (M_isFlush)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.5)).ConfigureAwait(false);
                if (!M_pauseFlush)
                {
                    if (ct.IsCancellationRequested)
                        return;
                    else
                    {
                        //显示已用时间
                        M_int_FlushCount = (int)(m_watchFlush.ElapsedMilliseconds / 1000.0);
                        BeginInvoke(new Action(() =>
                        {
                            //自动预冲的累积量计算
                            //根据治疗模式确认计算累计值的泵（累计值= 泵速×时间） m_watchFlush
                            //500ms执行一次
                            if (M_isFlush)
                            {
                                if (m_AutoFlushPumpState.BPState.Runing)
                                    m_flushBPTotal += m_AutoFlushPumpState.BPState.Speed * 5 / 600.0;
                                if (m_AutoFlushPumpState.RPState.Runing)
                                    m_flushRPTotal += m_AutoFlushPumpState.RPState.Speed * 5 / 600.0;
                                if (m_AutoFlushPumpState.DPState.Runing)
                                    m_flushDPTotal += m_AutoFlushPumpState.DPState.Speed * 5 / 600.0;
                                M_uc_AutoFlush.lblCurrent.Text = (m_flushBPTotal + m_flushRPTotal + m_flushDPTotal).ToString("f0");
                            }

                            M_uc_AutoFlush.lblTime.Text = Cls.utils.SecondsToTime(M_int_FlushCount);
                        }));
                        //获取当前步骤
                        if (_cmd.Count > 0)
                            currentStep = _cmd.Peek();
                        else
                            currentStep = null;
                        if (currentStep != null)
                        {
                            int lasttime = currentStep._LastTime;
                            int timescount = currentStep._TimesCount;
                            m_lstActionCmd = new List<Cls.Model_SendCMD>();
                            m_lstActionCmd.AddRange(currentStep._LstSendCMDs);

                            //判断当前时间是否为步骤的执行时间点  
                            if (M_int_FlushCount >= timescount)
                            {
                                //如果持续时间大于0，则表示该项是一个步骤。
                                if (lasttime > 0)
                                {
                                    string itemname = currentStep._ActionName;
                                    int index = currentStep._Index;
                                    BeginInvoke(new Action(() =>
                                    {
                                        //步骤的背景色 
                                        M_uc_AutoFlush.dgvStep.Rows[index].Selected = true;
                                    }));
                                    //更新泵及夹管阀状态
                                    UpdatePumpState(m_lstActionCmd);
                                    //创建发送命令子任务
                                    m_taskChildActions = new Task(RunActions, m_lstActionCmd, TaskCreationOptions.LongRunning);
                                    m_taskChildActions.Start();
                                    //执行任务后,移除队列的顶部
                                    _cmd.Dequeue();
                                }
                                else if (lasttime == 0) //表示此步骤为弹出对话框提示
                                {
                                    //暂停自动预冲
                                    m_watchFlush.Stop();
                                    M_pauseFlush = true;
                                    m_taskChildActions = new Task(RunActions, m_lstActionCmd, TaskCreationOptions.LongRunning);
                                    m_taskChildActions.Start();
                                    BeginInvoke(new Action(() =>
                                    {
                                        //步骤的背景色 
                                        M_uc_AutoFlush.dgvStep.Rows[currentStep._Index].Selected = true;
                                        //this.dgvStep.Rows[index].Cells["selAdd"].Value = 1;
                                        Bitmap bImage = null;
                                        if (currentStep._TipPic != null)
                                        {
                                            MemoryStream ms = new MemoryStream(currentStep._TipPic);
                                            bImage = (Bitmap)Image.FromStream(ms);
                                        }

                                        //弹出对话框，确认信息
                                        //HPTCMessageBox.MSBox m = new HPTCMessageBox.MSBox("警告",currentStep._ActionName, HPTCMessageBox.MSBox.MSBoxIcon.Warning,bImage);
                                        UserCtrl.MsgBox m = new UserCtrl.MsgBox("警告: " + currentStep._ActionName, UserCtrl.MsgBox.MSBoxIcon.Warning, bImage, false);

                                        if (DialogResult.OK == m.ShowDialog())
                                        {
                                            SendOrderFlush(port_main, Cls.Comm_Main.CmdAlarmLamp.GreenAlways);
                                            m_watchFlush.Start();
                                            M_pauseFlush = false;
                                            //执行任务后,移除队列的顶部
                                            _cmd.Dequeue();
                                        }
                                    }));
                                }
                            }
                        }
                        //判断预冲结束条件
                        if (M_int_FlushCount > fullTimeCount)
                        {
                            M_isFlush = false;
                            m_watchFlush.Stop();
                            //fullTimeCount = int.MaxValue;
                            //泵停止
                            SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                            BeginInvoke(new Action(() =>
                            {
                                FinishFlush();
                            }));
                            ShowWarn("N-07");
                        }
                    }
                }
            }
        }

        private void FinishFlush()
        {
            SendOrderFlush(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
            M_isFlush = false;
            M_pauseFlush = false;
            m_watchFlush.Reset();
            M_uc_AutoFlush.btnStart.Enabled = false;
            M_uc_AutoFlush.btnContinue.Enabled = false;
            M_uc_AutoFlush.btnContinue.Text = "暂停";
            M_uc_AutoFlush.lblTime.Text = "00:00:00";
            M_uc_AutoFlush.btnFinish.Enabled = true;
            M_uc_AutoFlush.btnReturn.Enabled = true;
            M_uc_AutoFlush.btnAddFlush.Enabled = true;
            M_uc_AutoFlush.dgvStep.Enabled = true;
            M_uc_AutoFlush.dgvStep.ClearSelection();
        }

        private void RunActions(object o)
        {
            List<Cls.Model_SendCMD> lstscmd = o as List<Cls.Model_SendCMD>;
            foreach (var v in lstscmd)
            {
                SendOrderFlush(v.SP, v.CMD);
            }
        }

        private void RunAddActions(object o)
        {
            List<Cls.Model_SendCMD> lstscmd = o as List<Cls.Model_SendCMD>;
            foreach (var v in lstscmd)
            {
                SendOrderFlush(v.SP, v.CMD);
            }
            while (m_isAddFlush)
            {
                Thread.Sleep(500);
                BeginInvoke(new Action(() =>
                {
                    int addCounts = (int)(m_watchAddFlush.ElapsedMilliseconds / 1000);
                    //追加预冲的累计
                    if (m_AutoFlushPumpState.BPState.Runing)
                        m_flushBPTotal += m_AutoFlushPumpState.BPState.Speed * 5 / 600.0;
                    if (m_AutoFlushPumpState.RPState.Runing)
                        m_flushRPTotal += m_AutoFlushPumpState.RPState.Speed * 5 / 600.0;
                    if (m_AutoFlushPumpState.DPState.Runing)
                        m_flushDPTotal += m_AutoFlushPumpState.DPState.Speed * 5 / 600.0;
                    M_uc_AutoFlush.lblCurrent.Text = (m_flushBPTotal + m_flushRPTotal + m_flushDPTotal).ToString("f0");
                    M_uc_AutoFlush.lblTime.Text = Cls.utils.SecondsToTime(M_int_FlushCount);

                    if (addCounts > m_tCountAddFlush)
                    {
                        addCounts = 0;
                        m_watchAddFlush.Stop();
                        M_uc_AutoFlush.btnAddFlush_Click(M_uc_AutoFlush.btnAddFlush, new EventArgs());
                    }
                }));
            }
        }


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
                            m_AutoFlushPumpState.BPState.Speed = mlspeed;
                            m_AutoFlushPumpState.BPState.Runing = run;
                            m_AutoFlushPumpState.BPState.Direction = direction;
                            m_AutoFlushPumpState.BPState.PumpID = 1;
                            break;
                        case 0x02:
                            m_AutoFlushPumpState.FPState.Speed = mlspeed;
                            m_AutoFlushPumpState.FPState.Runing = run;
                            m_AutoFlushPumpState.FPState.Direction = direction;
                            m_AutoFlushPumpState.FPState.PumpID = 2;
                            break;
                        case 0x03:
                            m_AutoFlushPumpState.DPState.Speed = mlspeed;
                            m_AutoFlushPumpState.DPState.Runing = run;
                            m_AutoFlushPumpState.DPState.Direction = direction;
                            m_AutoFlushPumpState.DPState.PumpID = 3;
                            break;
                        case 0x04:
                            m_AutoFlushPumpState.RPState.Speed = mlspeed;
                            m_AutoFlushPumpState.RPState.Runing = run;
                            m_AutoFlushPumpState.RPState.Direction = direction;
                            m_AutoFlushPumpState.RPState.PumpID = 4;
                            break;
                        case 0x05:
                            m_AutoFlushPumpState.FP2State.Speed = mlspeed;
                            m_AutoFlushPumpState.FP2State.Runing = run;
                            m_AutoFlushPumpState.FP2State.Direction = direction;
                            m_AutoFlushPumpState.FP2State.PumpID = 5;
                            break;
                        case 0x06:
                            m_AutoFlushPumpState.CPState.Speed = mlspeed;
                            m_AutoFlushPumpState.CPState.Runing = run;
                            m_AutoFlushPumpState.CPState.Direction = direction;
                            m_AutoFlushPumpState.CPState.PumpID = 6;
                            break;
                        //case 0x1F:
                        //    m_pumpState.CPState.Runing = m_pumpState.FP2State.Runing = m_pumpState.RPState.Runing = m_pumpState.DPState.Runing = m_pumpState.BPState.Runing = m_pumpState.FPState.Runing = run;
                        //break;
                    }
                }
                #endregion

                #region 更新夹管阀状态
                if (v.SP.PortName.ToLower() == "com1")
                {
                    byte[] b = v.CMD;
                    //FE B1 06 01(1) 00(2) 00(3) 00(4) 00(5) 00(6) 48 ED 
                    if (b[1] == 0xB1)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            m_AutoFlushPumpState.VState[i] = b[i + 3];
                        }
                    }
                }
                #endregion
            }
        }


        public bool GetCustCmd(string method)
        {
            M_uc_AutoFlush.dgvStep.ClearSelection();
            M_uc_AutoFlush.ShowCustomActions(method);
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
                    {
                        m_lstCust[i].timeCount = m_lstCust[i - 1].timeCount + m_lstCust[i - 1].timeSpan;
                    }
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
                    modCustCmd._TipPic = m_lstCust[i].tipPic;
                    //此处修改为持续时间不为0的项目总数,可用Linq查询
                    int index = m_queueCustSendCmd.Count(p => p._LastTime > 0);
                    modCustCmd._Index = index;
                    //将该动作列表加入步骤里  
                    m_queueCustSendCmd.Enqueue(modCustCmd);
                }
                //最后一项提取总时间
                int timefull = (int)(m_lstCust[m_lstCust.Count - 1].timeCount + m_lstCust[m_lstCust.Count - 1].timeSpan);// (int)modCust.timeCount + (int)modCust.timeSpan;
                M_uc_AutoFlush.lblFullTime.Text = Cls.utils.SecondsToTime(timefull);
                return true;
            }
            else
            {
                M_uc_AutoFlush.lblFullTime.Text = "00:00:00";
                return false;
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
                        sp = port_main;
                        break;
                    case "com2":
                        break;
                    case "com3":
                        sp = port_ppump;
                        break;
                }
                Cls.Model_SendCMD item = new Cls.Model_SendCMD(sp, cmdLen, cmdArry, 0);
                lstActions.Add(item);
            }
            return lstActions;
        }

        void afCustom_btnEndFlush(object sender, EventArgs e)
        {
            double finalWeigh2 = M_ModelValue.M_flt_Weigh2;
            double marginWeigh2 = finalWeigh2 - startWeigh2;

            //预冲不足的判定
            //switch (M_modeName)
            //{
            //    case "PE":

            //        if (marginWeigh2 >= dPEFlush)
            //        {
            //            ShowWarn("N-07");
            //        }
            //        else
            //        {
            //            ShowWarn("W3-03");

            //        }
            //        break;
            //    case "CHDF":
            //        if (marginWeigh2 >= dCHDFFlush)
            //        {
            //            ShowWarn("N-07");
            //        }
            //        else
            //        {
            //            ShowWarn("W3-03");

            //        }
            //        break;
            //    case "PP":
            //        if (marginWeigh2 >= dPPFlush)
            //        {
            //            ShowWarn("N-07");
            //        }
            //        else
            //        {
            //            ShowWarn("W3-03");
            //        }
            //        break;
            //}

            if (m_taskCustomAction != null)
                m_ctsCustomAction.Cancel();
            FinishFlush();
            //读取最后步骤的夹管阀状态
            ReadLastActionAVState();
            this.tsbtnPipeline.Enabled = true;
            this.tsbtnTherapy.Enabled = true;
            //this.tsbtnRecycle.Enabled = true;
            this.tsbtnSetFlow.Enabled = true;
            this.lblBloodSpeed.Enabled = true;
            this.btnStart.Enabled = true;
            M_uc_AutoFlush.btnStart.Enabled = true;
            M_bl_isFinishFlush = true;
            M_isFlush = false;
            //M_PumpState.VState = M_uc_AutoFlush.m_pumpState.VState;
            toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnTherapy));
            this.tsbtnTherapy.Enabled = true;
            tsbtnTherapy_Click(tsbtnTherapy, e);

        }

        private void ReadLastActionAVState()
        {
            BLL.actions bllact = new BLL.actions();
            if (m_lstCust.Count > 0)
            {
                //读取步骤下相应的动作列表
                int customID = (int)m_lstCust[m_lstCust.Count - 1].ID;
                List<ALS.Model.actions> lstModAct = bllact.GetModelList("customID='" + customID + "'");
                List<Cls.Model_SendCMD> lstActions = new List<Cls.Model_SendCMD>();
                if (lstModAct.Count > 0)
                {
                    lstActions = GetlstActions(lstModAct);
                    UpdatePumpState(lstActions);
                }
            }
        }

        void afCustom_btnReturnSelEvent(object sender, EventArgs e)
        {
            M_SelFlushType = 0;
            tsbtnPreflush_Click(this.tsbtnPreFlush, e);
            //throw new NotImplementedException();
        }

        private void tsbtnTherapy_Click(object sender, EventArgs e)
        {
            //先判断管路是否安装完成 是否冲洗管路
            if (!M_bl_isFinishPipeline)
            {
                MessageBox.Show(this, "请确认管路安装!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                M_BackCheckedInterface();
                return;
            }
            if (!M_bl_isFinishFlush)
            {
                MessageBox.Show(this, "未清洗管路!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                M_BackCheckedInterface();
                return;
            }
            layoutPump.Visible = true;
            ShowP(_style.w300);
            M_uc_Treat._ModelTreat = M_ModelTreat;
            M_uc_Treat.ReadSet(M_ModelTreat);
            //M_uc_Treat.ReadTreatPic(M_modeName);
            M_uc_Treat.palWizard.Controls.Clear();

            //if (M_modeName == "PERT")
            //    M_uc_Treat.sgbox.Text = "PEF";
            //else
            //    M_uc_Treat.sgbox.Text = M_modeName ;
            M_uc_Treat.customTabControl1.SelectedIndex = 0;
            switch (M_modeName.ToLower())
            {
                case "pdf":
                    m_stepPDF._ModelTreat = this.M_ModelTreat;
                    m_stepPDF.ReadSet();
                    m_stepPDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepPDF._Port_ppump = this.port_ppump;
                    if (!M_uc_Treat.palWizard.Controls.Contains(m_stepPDF))
                        M_uc_Treat.palWizard.Controls.Add(m_stepPDF);
                    m_stepPDF.Dock = DockStyle.Fill;
                    M_uc_Treat.picTreat.Image = global::ALS.Properties.Resources.PDFTreat;
                    if (M_isTreat)
                        m_stepPDF.Enabled = true;
                    else
                        m_stepPDF.Enabled = false;
                    //改变压力显示列表，创新模式为全显示
                    ChangeShowPControlEnabled("pdf");
                    break;
                case "pert":
                    m_stepPERT._ModelTreat = this.M_ModelTreat;
                    m_stepPERT.ReadSet();
                    m_stepPERT.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepPERT._Port_ppump = this.port_ppump;
                    if (!M_uc_Treat.palWizard.Controls.Contains(m_stepPERT))
                        M_uc_Treat.palWizard.Controls.Add(m_stepPERT);
                    M_uc_Treat.picTreat.Image = global::ALS.Properties.Resources.PERTTreat;
                    m_stepPERT.Dock = DockStyle.Fill;
                    if (M_isTreat)
                        m_stepPERT.Enabled = true;
                    else
                        m_stepPERT.Enabled = false;
                    //改变压力显示列表，创新模式为全显示
                    ChangeShowPControlEnabled("pert");
                    break;
                case "li-als":
                    m_stepLiALS._ModelTreat = this.M_ModelTreat;
                    m_stepLiALS.ReadSet();
                    m_stepLiALS.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepLiALS._Port_ppump = this.port_ppump;
                    m_stepLiALS._Port_main = this.port_main;
                    if (!M_uc_Treat.palWizard.Controls.Contains(m_stepLiALS))
                        M_uc_Treat.palWizard.Controls.Add(m_stepLiALS);
                    M_uc_Treat.picTreat.Image = global::ALS.Properties.Resources.LiALSTreat;
                    m_stepLiALS.Dock = DockStyle.Fill;
                    if (M_isTreat)
                        m_stepLiALS.Enabled = true;
                    else
                        m_stepLiALS.Enabled = false;
                    //改变压力显示列表，创新模式为全显示
                    ChangeShowPControlEnabled("li-als");
                    break;
                case "pe":
                    m_stepPE._ModelTreat = this.M_ModelTreat;
                    m_stepPE.ReadSet();
                    m_stepPE.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepPE._Port_ppump = this.port_ppump;
                    if (!M_uc_Treat.palWizard.Controls.Contains(m_stepPE))
                        M_uc_Treat.palWizard.Controls.Add(m_stepPE);
                    M_uc_Treat.picTreat.Image = global::ALS.Properties.Resources.PETreat;
                    m_stepPE.Dock = DockStyle.Fill;
                    if (M_isTreat)
                        m_stepPE.Enabled = true;
                    else
                        m_stepPE.Enabled = false;
                    ChangeShowPControlEnabled("pe");
                    break;
                case "chdf":
                    m_stepCHDF._ModelTreat = this.M_ModelTreat;
                    m_stepCHDF.ReadSet();
                    m_stepCHDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepCHDF._Port_ppump = this.port_ppump;
                    if (!M_uc_Treat.palWizard.Controls.Contains(m_stepCHDF))
                        M_uc_Treat.palWizard.Controls.Add(m_stepCHDF);
                    M_uc_Treat.picTreat.Image = global::ALS.Properties.Resources.CHDFTreat;
                    m_stepCHDF.Dock = DockStyle.Fill;
                    if (M_isTreat)
                        m_stepCHDF.Enabled = true;
                    else
                        m_stepCHDF.Enabled = false;
                    ChangeShowPControlEnabled("chdf");
                    break;

                case "pp":
                    m_stepPP._ModelTreat = this.M_ModelTreat;
                    m_stepPP.ReadSet();
                    m_stepPP.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepPP._Port_ppump = this.port_ppump;
                    if (!M_uc_Treat.palWizard.Controls.Contains(m_stepPP))
                        M_uc_Treat.palWizard.Controls.Add(m_stepPP);
                    M_uc_Treat.picTreat.Image = global::ALS.Properties.Resources.PPTreat;
                    m_stepPP.Dock = DockStyle.Fill;
                    if (M_isTreat)
                        m_stepPP.Enabled = true;
                    else
                        m_stepPP.Enabled = false;
                    ChangeShowPControlEnabled("pp");
                    break;
            }
            if (!this.palContent.Controls.Contains(M_uc_Treat))
                this.palContent.Controls.Add(M_uc_Treat);
            this.palContent.Controls.SetChildIndex(M_uc_Treat, 0);
            this.btnStart.Enabled = true;
            //M_uc_Treat.tabP.SelectedIndex = 0;
            //MessageBox.Show(this.palContent.Controls.GetChildIndex(M_uc_Treat).ToString() + this.palContent.Controls.GetChildIndex(M_uc_Method).ToString());
            M_uc_Treat.BringToFront();
            M_uc_Treat.Dock = DockStyle.Fill;
        }

        void ChangeShowPControlEnabled(string method)
        {
            //switch (method)
            //{
            //    case "li-als":
            //        this.uc_p2nd.Enabled = this.uc_p3rd.Enabled = true;
            //        //M_uc_Treat.Series_6.Visible = M_uc_Treat.Series_7.Visible = true;
            //        break;
            //    case "pert":
            //    case "chdf":
            //    case "pe":
            //    case "pdf":
            //        this.uc_p2nd.Enabled = this.uc_p3rd.Enabled = false;
            //        this.uc_p2nd._Value = this.uc_p3rd._Value = "0.0";
            //        //M_uc_Treat.Series_6.Visible = M_uc_Treat.Series_7.Visible = false;
            //        break;
            //    case "pp":
            //        this.uc_p3rd.Enabled = false;
            //        this.uc_p3rd._Value = "0.0";
            //        //M_uc_Treat.Series_7.Visible = false;
            //        break;
            //}
        }

        void M_uc_Treat_checkBalance(object sender, EventArgs e)
        {
            Control c = sender as Control;
            if (c.Tag != null)
            {
                string tag = c.Tag.ToString();
                switch (tag)
                {
                    case "chkbalance":
                        CheckBox chkb = c as CheckBox;
                        if (chkb.Checked)
                        {
                            //检测FP是否运转
                            if (!M_PumpState.FPState.Runing)
                            {
                                chkb.Checked = false;
                                MessageBox.Show(this, "FP未运转,不能平衡!");
                                return;
                            }
                            if (M_isTreat)
                            {
                                weigh1_startvalue = M_ModelValue.M_flt_Weigh1;
                                weigh2_startvalue = M_ModelValue.M_flt_Weigh2;
                                weigh3_startvalue = M_ModelValue.M_flt_Weigh3;
                                weigh4_startvalue = M_ModelValue.M_flt_Weigh4;
                                m_bl_Balance = true;
                                //泵称平衡的计时 
                                m_watchFPRuning.Reset();
                                m_watchFPRuning.Start();
                                //UI
                                M_uc_Treat.lblDehydrationSpeed.Enabled = false;
                                M_uc_Treat.btnZero.Enabled = false;
                            }
                            chkb.BackColor = Color.FromArgb(15, 8, 100);
                            chkb.ForeColor = Color.White;
                        }
                        else
                        {
                            if (M_isTreat)
                            {
                                m_bl_Balance = false;
                                //UI
                                M_uc_Treat.lblDehydrationSpeed.Enabled = true;
                                M_uc_Treat.btnZero.Enabled = true;
                                switch (M_modeName)
                                {
                                    case "PE":
                                        //泵称平衡的计时
                                        //m_watchFPRuning.Reset();
                                        break;
                                    case "CHDF":
                                    case "PDF":
                                    case "PERT":
                                    case "Li-ALS":
                                        //泵称平衡的计时 
                                        SaveAndInitBalance();
                                        break;
                                }
                            }
                            chkb.BackColor = Color.Transparent;
                            chkb.ForeColor = Color.FromArgb(15, 8, 100);
                        }
                        break;
                    case "change"://取消泵秤平衡
                        if (M_uc_Treat.chkBalance.Checked == true)
                        {
                            M_uc_Treat.chkBalance.CheckState = CheckState.Unchecked;
                            M_uc_Treat_checkBalance(M_uc_Treat.chkBalance, new EventArgs());
                        }
                        break;
                }
            }

            //throw new NotImplementedException();
        }

        void SaveAndInitBalance()
        {
            m_bl_Balance = false;
            //m_watchFPRuning.Stop();
            //存储当前过程脱水结果值
            Cls.Model_Balance clsBalance = new Cls.Model_Balance();
            //阶段时间
            clsBalance._T = m_watchFPRuning.ElapsedMilliseconds / 1000.0;
            m_watchFPRuning.Reset();
            //累计偏差
            clsBalance._DryDeviation = dryDeviationSum;
            //设定的脱水速度
            clsBalance._DrySpeed = M_ModelTreat.dehydrationSpeed.Value;

            //阶段实际脱水量
            clsBalance._DryTotalActually = M_ModelTotal.CurrentDry;
            //阶段理论脱水量
            clsBalance._DryTotalTheoretic = clsBalance._T * (clsBalance._DrySpeed / 3600.0);

            m_lstBalance.Add(clsBalance);
            //记录和
            CalBalanceSum(clsBalance);
            //当前过程的脱水参数清零
            M_ModelTotal.CurrentDry = 0;
            dryDeviation = 0;
            dryLilun = 0;
        }


        void CalBalanceSum(Cls.Model_Balance modBalance)
        {
            m_BalanceSum = new Cls.Model_Balance();
            m_BalanceSum._DryDeviation = modBalance._DryDeviation;
            m_BalanceSum._DryTotalActually = m_lstBalance.Sum(c => c._DryTotalActually);
            m_BalanceSum._DryTotalTheoretic = m_lstBalance.Sum(c => c._DryTotalTheoretic);
            m_BalanceSum._T = m_lstBalance.Sum(c => c._T);
        }

        void M_uc_Treat_ZeroTuoShuiClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(this, "确认将脱水累计清0?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                ZeroTuoshui();
            }
        }

        private void tsbtnRecycle_Click(object sender, EventArgs e)
        {
            //先判断管路是否安装完成 是否清洗管路
            if (!M_bl_isFinishPipeline)
            {
                MessageBox.Show(this, "请确认管路安装!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                M_BackCheckedInterface();
                return;
            }

            if (!M_bl_isFinishFlush)
            {
                MessageBox.Show(this, "未清洗管路!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                M_BackCheckedInterface();
                return;
            }

            //if (!M_bl_isFinishTreat)
            //{
            //    MessageBox.Show("未完成治疗!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            ShowP(_style.w180);
            layoutPump.Visible = false;
            this.tsbtnPipeline.Enabled = false;
            this.tsbtnPreFlush.Enabled = false;
            this.tsbtnTherapy.Enabled = false;
            this.tsbtnSetFlow.Enabled = false;
            this.tsbtnRecycle.Enabled = true;
            //this.btnStart.Enabled = false;

            //回收前夹管阀状态
            if (!M_bl_isFinishTreat)
            {
                double speed = 0;
                //回收前停止所有泵
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01));
                m_leadBloodSpeed = 0;
                M_PumpState.BPState.Speed = speed;
            }
            M_uc_Recycle._Port_main = port_main;
            M_uc_Recycle._Port_ppump = port_ppump;
            M_uc_Recycle._ModelTreat = M_ModelTreat;
            M_ModelTreat = GetTreatmentModel(M_modeName);
            M_uc_Recycle._ModelPumpState = M_PumpState;
            M_uc_Recycle.ShowRecycleActions(M_modeName + "_Recycle");
            //PERT修改为PEF
            if (M_modeName == "PERT")
                M_uc_Recycle.gboxRecycle.Text = "PEF 回收方法,请参照以下步骤回收";
            else
                M_uc_Recycle.gboxRecycle.Text = M_modeName + " 回收方法,请参照以下步骤回收";
            if (!this.palContent.Controls.Contains(M_uc_Recycle))
                this.palContent.Controls.Add(M_uc_Recycle);
            this.palContent.Controls.SetChildIndex(M_uc_Recycle, 0);
            M_uc_Recycle.BringToFront();
            M_uc_Recycle.Dock = DockStyle.Fill;
            toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnRecycle));
            //完成治疗,进入回收状态true；
            M_bl_isFinishTreat = true;
        }

        void M_uc_Recycle_recyle_btnCloseAll(object sender, EventArgs e)
        {
            UserCtrl.MsgBox m = new UserCtrl.MsgBox("请确认回收已经完成？", UserCtrl.MsgBox.MSBoxIcon.Warning, ALS.Properties.Resources.end, true);
            if (DialogResult.OK == m.ShowDialog())
            {
                MessageBox.Show(this, "治疗过程结束,请退出系统!");
                M_bl_isFinishTreat = true;
                this.btnStart.Enabled = true;
                this.tsbtnSetFlow.Enabled = false;
                this.tsbtnSum.Enabled = false;
                this.tsbtnLevel.Enabled = false;
                this.tsbtnOtherSet.Enabled = false;
                this.tsbtnTherapy.Enabled = false;
                this.tsbtnPipeline.Enabled = false;
                this.tsbtnPreFlush.Enabled = false;
                this.tsbtnExit.Enabled = true;

                //确认所有阀松开后，发送所有泵停指令。
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                //确认所有阀松开后，泵操作按键按键才置灰。
                M_uc_Recycle.gboxPump.Enabled = false;
                //SendOrder(port_main, Cls.Comm_Main.CmdTemperature.StopHT);
                SendOrder(port_hpump, Cls.Comm_SyringePump.Stop);
                switch (M_modeName)
                {
                    case "PP":
                    case "PE":
                    case "CHDF":
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x00, 0x01, 0x01));
                        break;
                    case "Li-ALS":
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x00, 0x00, 0x00));
                        break;
                    case "PERT":
                        SendOrder(port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x00, 0x00, 0x01));
                        break;
                }
            }
            else
            {
                return;
            }
            //throw new NotImplementedException();
        }

        private void tsbtnOtherSet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_modeName))
            {
                MessageBox.Show(this, "请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowP(_style.w180);
            layoutPump.Visible = false;
            M_uc_OtherSet._ModelTreat = M_ModelTreat;
            M_uc_OtherSet.ReadLevel(M_ModelTreat);
            M_uc_OtherSet.ReadFlush();
            M_uc_OtherSet.ReadVState(M_PumpState);
            M_uc_OtherSet.ReadHPumpSet();
            if (!this.palContent.Controls.Contains(M_uc_OtherSet))
                this.palContent.Controls.Add(M_uc_OtherSet);
            this.palContent.Controls.SetChildIndex(M_uc_OtherSet, 0);
            if (M_isTreat)
                M_uc_OtherSet.SetSPButton(true);
            M_uc_OtherSet.BringToFront();
            M_uc_OtherSet.Dock = DockStyle.Fill;
        }

        void M_uc_OtherSet_btnZeroWs(object sender, EventArgs e)
        {
            //<add key ="1_0kgcode" value="5535"/>
            //<add key="1_5kgcode" value="0"/>
            //<add key="1_10kgcode" value="6541631"/>
            //<add key="weigh1_resolution" value="0.00153"/>
            //<add key ="2_0kgcode" value="10492"/>
            //<add key="2_5kgcode" value="0"/>
            //<add key="2_10kgcode" value="6011425"/>
            //<add key="weigh2_resolution" value="0.001666"/>
            //<add key ="3_0kgcode" value="6604"/>
            //<add key="3_5kgcode" value="0"/>
            //<add key="3_10kgcode" value="5880648"/>
            //<add key="weigh3_resolution" value="0.001702"/>

            //int weigh1_code;
            //int weigh2_code;
            //int weigh3_code;
            //int weigh1_0kgcode;
            //int weigh2_0kgcode;
            //int weigh3_0kgcode;

            int codeoffset = 0;
            LoadWeighPara();
            Button b = sender as Button;
            switch (b.Tag.ToString())
            {
                case "zerows1":
                    codeoffset = weigh1_code - weigh1_0kgcode;
                    weigh1_0kgcode += codeoffset;
                    weigh1_5kgcode += codeoffset;
                    //weigh1_10kgcode += codeoffset;
                    break;
                case "zerows2":
                    codeoffset = weigh2_code - weigh2_0kgcode;
                    weigh2_0kgcode += codeoffset;
                    weigh2_5kgcode += codeoffset;
                    //weigh2_10kgcode += codeoffset;
                    break;
                case "zerows3":
                    codeoffset = weigh3_code - weigh3_0kgcode;
                    weigh3_0kgcode += codeoffset;
                    weigh3_5kgcode += codeoffset;
                    //weigh3_10kgcode += codeoffset;
                    break;
                /****************
                 * 添加秤4 其他设置界面清零操作
                 * ‘zerows4’
                 * wss 2015年12月7日
                 ****************/
                case "zerows4":
                    codeoffset = weigh4_code - weigh4_0kgcode;
                    weigh4_0kgcode += codeoffset;
                    weigh4_5kgcode += codeoffset;
                    //weigh4_10kgcode += codeoffset;
                    break;
            }
            SaveWeighPara();
            //throw new NotImplementedException();
        }
        //其他设置界面  抗凝泵累积量接近完成标志量改变
        //wss 2015年12月22日
        private void M_uc_OtherSet_Sp_NearAccumulation(object sender, EventArgs e)
        {
            Sp_NearCom = false;
            //sp_BackLast = 0;
        }
        //wss
        private void M_uc_OtherSet_btnZeroTotalSp(object sender, EventArgs e)
        {
            M_ModelTotal.TotalSP = 0;
        }
        private void tsbtnSum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_modeName))
            {
                MessageBox.Show(this, "请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowP(_style.w180);
            layoutPump.Visible = false;
            M_uc_Sum._ModelTreat = this.M_ModelTreat;
            M_uc_Sum.ReadSet(this.M_ModelTreat);
            M_uc_Sum._ModelTotal = this.M_ModelTotal;
            M_uc_Sum._ModelTotalPE = this.m_TotalPE;
            M_uc_Sum.ReadTotal();
            if (!this.palContent.Controls.Contains(M_uc_Sum))
                this.palContent.Controls.Add(M_uc_Sum);
            this.palContent.Controls.SetChildIndex(M_uc_Sum, 0);
            M_uc_Sum.BringToFront();
            M_uc_Sum.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 累计值清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void M_uc_Sum_btnZeroClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(this, "确认将累计清0?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                ZeroTotal();

                //foreach (var series in M_uc_Treat.chart1.Series)
                //{
                //    series.Points.Clear();
                //}
            }
            else
                return;
            M_uc_Sum.ReadTotal();
        }

        /// <summary>
        /// 清0
        /// </summary>
        private void ZeroTotal()
        {
            M_ModelTotal.TotalRP = 0;
            M_ModelTotal.TotalBP = 0;
            M_ModelTotal.TotalFP = 0;
            M_ModelTotal.TotalSP = 0;
            M_ModelTotal.TotalDP = 0;
            M_ModelTotal.TotalFP2 = 0;
            M_ModelTotal.TotalTime = 0;

            //PE阶段清零
            //m_TotalPE.TotalRP = 0;
            //m_TotalPE.TotalBP = 0;
            //m_TotalPE.TotalFP = 0;
            //m_TotalPE.TotalSP = 0;
            //m_TotalPE.TotalDP = 0;
            //m_TotalPE.CurrentDry = 0;
            //m_TotalPE.TotalTime = 0;

            //时间清0
            M_lst_TreatCount.Clear();
            M_int_TreatCount = 0;
            M_int_TreatCountSum = 0;
            m_dtMonitor = DateTime.Now;
            //达到累计量标志
            m_isUptoTime = m_isUptoBP = m_isUptoDP = m_isUptoFP = m_isUptoRP = m_isUptoSP = false;

            //抗凝剂泵累积量清零
            SendOrder(port_hpump, Cls.Comm_SyringePump.ClearCumulant);
        }

        private void ZeroTuoshui()
        {
            //脱水清零
            M_ModelTotal.CurrentDry = 0;
            m_watchFPRuning.Reset();
            if (m_lstBalance.Count > 0)
                m_lstBalance.Clear();
            M_uc_Treat.lblDryTotalActually.Text = M_ModelTotal.CurrentDry.ToString("f1");
            dryDeviationSum = 0;
            dryDeviation = 0;
            dryLilun = 0;
            m_BalanceSum._DryDeviation = 0;
            m_BalanceSum._DrySpeed = 0;
            m_BalanceSum._DryTotalActually = 0;
            m_BalanceSum._DryTotalTheoretic = 0;
            m_BalanceSum._T = 0;
            weigh1_startvalue = M_ModelValue.M_flt_Weigh1;
            weigh2_startvalue = M_ModelValue.M_flt_Weigh2;
            weigh3_startvalue = M_ModelValue.M_flt_Weigh3;
            if (M_PumpState.FPState.Runing && m_bl_Balance)
                m_watchFPRuning.Start();
        }

        private void tsbtnLevel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_modeName))
            {
                MessageBox.Show(this, "请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowP(_style.w180);
            layoutPump.Visible = false;
            M_uc_SetLiquidSurface._TreatMode = M_ModelTreat;
            M_uc_SetLiquidSurface._Port_main = port_main;
            if (!this.palContent.Controls.Contains(M_uc_SetLiquidSurface))
                this.palContent.Controls.Add(M_uc_SetLiquidSurface);
            this.palContent.Controls.SetChildIndex(M_uc_SetLiquidSurface, 0);
            M_uc_SetLiquidSurface.BringToFront();
            M_uc_SetLiquidSurface.Dock = DockStyle.Fill;
        }

        void M_uc_SetLiquidSurface_chkClicked(object sender, EventArgs e)
        {

            Button cb = sender as Button;
            switch (cb.Tag.ToString())
            {
                case "1up":
                    if (M_PumpState.VState[0] == 0x01 || M_PumpState.VState[1] == 0x01)
                    { MessageBox.Show(this, "请打开夹管阀1和2", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Up);
                    break;
                case "1down":
                    if (M_PumpState.VState[0] == 0x01 || M_PumpState.VState[1] == 0x01)
                    { MessageBox.Show(this, "请打开夹管阀1和2", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Down);
                    break;
                case "2up":
                    if (M_PumpState.VState[0] == 0x01 || M_PumpState.VState[1] == 0x01)
                    { MessageBox.Show(this, "请打开夹管阀1和2", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Up);
                    break;
                case "2down":
                    if (M_PumpState.VState[0] == 0x01 || M_PumpState.VState[1] == 0x01)
                    { MessageBox.Show(this, "请打开夹管阀1和2", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Down);
                    break;
                case "3up":
                    SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Up);
                    break;
                case "3down":
                    SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Down);
                    break;
            }
        }

        private List<Cls.Model_SendCMD> lst_Stop()
        {
            List<Cls.Model_SendCMD> lst_stop = new List<Cls.Model_SendCMD>();
            //关闭灯，绿灯常亮
            //byte[] b2 = Cls.Comm_Main.CmdAlarmLamp.AllLightClose;
            //lst_stop.Add(new Cls.Model_SendCMD(port_main, b2.Length, b2, 0));

            byte[] b3 = Cls.Comm_Main.CmdAlarmLamp.GreenAlways;
            lst_stop.Add(new Cls.Model_SendCMD(port_main, b3.Length, b3, 0));
            //各泵停止
            byte[] b4 = Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true);
            lst_stop.Add(new Cls.Model_SendCMD(port_ppump, b4.Length, b4, 0));

            //关闭夹管阀
            byte[] b5 = Cls.Comm_Main.CmdValve.SetVState(0x01, 0x01, 0x01, 0x01, 0x01, 0x01);
            lst_stop.Add(new Cls.Model_SendCMD(port_main, b5.Length, b5, 0));

            //停止SP
            byte[] b6 = Cls.Comm_SyringePump.Stop;
            lst_stop.Add(new Cls.Model_SendCMD(port_hpump, b6.Length, b6, 0));

            return lst_stop;
        }
        private List<Cls.Model_SendCMD> lst_Start()
        {
            //声音和灯光操作，一条指令就可以；夹管阀指令需要200ms延时，在发送完夹管阀指令后需等待返回，对返回进行键，如不是目标状态或异常，应重复发送，再次异常再进行夹管阀异常报警。夹管阀指令放置3个气泡检测开启之后
            List<Cls.Model_SendCMD> lst_start = new List<Cls.Model_SendCMD>();
            //气泡检测
            byte[] b_ad1 = Cls.Comm_Main.CmdBubble.OpenBubble1;
            byte[] b_ad2 = Cls.Comm_Main.CmdBubble.OpenBubble2;
            byte[] b_ad3 = Cls.Comm_Main.CmdBubble.OpenBubble3;
            switch (M_modeName.ToLower())
            {
                case "pe":
                    lst_start.Add(new Cls.Model_SendCMD(port_main, b_ad1.Length, b_ad1, 0));
                    lst_start.Add(new Cls.Model_SendCMD(port_main, b_ad3.Length, b_ad3, 0));
                    break;
                case "pp":
                    lst_start.Add(new Cls.Model_SendCMD(port_main, b_ad1.Length, b_ad1, 0));
                    break;
                case "chdf":
                case "pdf":
                case "li-als":
                case "pert":
                    lst_start.Add(new Cls.Model_SendCMD(port_main, b_ad1.Length, b_ad1, 0));
                    lst_start.Add(new Cls.Model_SendCMD(port_main, b_ad2.Length, b_ad2, 0));
                    lst_start.Add(new Cls.Model_SendCMD(port_main, b_ad3.Length, b_ad3, 0));
                    break;
                default:
                    break;
            }
            //加热 
            //byte[] b_ht = Cls.Comm_Main.CmdTemperature.StartHT(Convert.ToByte(M_ModelTreat.TargetT));
            //lst_start.Add(new Cls.Model_SendCMD(port_main, b_ht.Length, b_ht, 0));
            //打开注射泵第一遍
            byte[] b_sp = Cls.Comm_SyringePump.Start(M_ModelTreat.SP_Speed.Value, M_ModelTreat.TargetSP.Value);
            lst_start.Add(new Cls.Model_SendCMD(port_hpump, b_sp.Length, b_sp, 0));
            //夹管阀初始状态
            byte[] b_VS1 = Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01);
            lst_start.Add(new Cls.Model_SendCMD(port_main, b_VS1.Length, b_VS1, 0));
            //打开注射泵第二遍
            lst_start.Add(new Cls.Model_SendCMD(port_hpump, b_sp.Length, b_sp, 0));
            return lst_start;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //清空旋钮数据
            m_lstCircleDirection.Clear();
            //如果未安装管路
            if (!M_bl_isFinishPipeline)
                return;
            //如果未完成预冲
            if (!M_bl_isFinishFlush)
                return;
            //偏离设定温度±1 Test

            //开始时检测温度
#if RunT 
            if (M_ModelValue.M_flt_Temperature < M_ModelTreat.TargetT.Value - 1 || M_ModelValue.M_flt_Temperature > M_ModelTreat.TargetT.Value + 1)
            {
                ShowWarn("W2-10");
                return;
            }
#endif

            //是否治疗标记
            M_isTreat = !M_isTreat;
            if (M_isTreat)
            {//开始
                if (M_bl_isFinishTreat)
                {
                    MessageBox.Show(this, "已经完成治疗,请退出!");
                    M_isTreat = false;
                    return;
                }

                if (M_modeName == "PERT")
                {
                    string tip = "操作提示";
                    Image imgtip = null;
                    if (m_stepPERT.wizardControl1.SelectedPage.TabIndex < 3)
                        imgtip = ALS.Properties.Resources.tipPert1;
                    else
                        imgtip = ALS.Properties.Resources.tipPert2;
                    //如果是PERT模式，弹出确认框
                    UserCtrl.MsgBox m = new UserCtrl.MsgBox(tip, UserCtrl.MsgBox.MSBoxIcon.Warning, imgtip, true);
                    if (DialogResult.OK != m.ShowDialog())
                    {
                        M_isTreat = false;
                        return;
                    }
                }
                else
                {
                    string tip = "操作提示";
                    Image imgtip = global::ALS.Properties.Resources.tip1;

                    //如果是PERT模式，弹出确认框
                    UserCtrl.MsgBox m = new UserCtrl.MsgBox(tip, UserCtrl.MsgBox.MSBoxIcon.Warning, imgtip, true);
                    if (DialogResult.OK != m.ShowDialog())
                    {
                        M_isTreat = false;
                        return;
                    }
                }

                //回到治疗界面
                if (this.palContent.Controls.GetChildIndex(M_uc_Treat) != 0)
                {
                    tsbtnTherapy_Click(tsbtnTherapy, e);
                    //改变按钮背景
                    toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnTherapy));
                }
                //暂存称重初始值
                weigh1_startvalue = M_ModelValue.M_flt_Weigh1;
                weigh2_startvalue = M_ModelValue.M_flt_Weigh2;
                weigh3_startvalue = M_ModelValue.M_flt_Weigh3;
                weigh4_startvalue = M_ModelValue.M_flt_Weigh4;
                //根据模式显示治疗向导
                switch (M_modeName.ToLower())
                {
                    case "pert":
                        m_stepPERT.Enabled = true;
                        break;
                    case "pdf":
                        m_stepPDF.Enabled = true;
                        break;
                    case "pe":
                        m_stepPE.Enabled = true;
                        break;
                    case "pp":
                        m_stepPP.Enabled = true;
                        break;
                    case "chdf":
                        m_stepCHDF.Enabled = true;
                        break;
                    case "li-als":
                        m_stepLiALS.Enabled = true;
                        break;
                }
                //界面按键状态
                this.btnStart.Enabled = false;
                this.btnStart.Image = Properties.Resources.stop;
                this.btnStart.Text = "停止";
                this.gifRuning.Image = global::ALS.Properties.Resources.jiuxu;
                this.tsbtnSetFlow.Enabled = false;
                this.tsbtnPipeline.Enabled = false;
                this.tsbtnRecycle.Enabled = false;
                this.tsbtnPreFlush.Enabled = false;
                this.tsbtnExit.Enabled = false;
                this.btnStart.ForeColor = Color.FromArgb(218, 18, 18);
                M_uc_OtherSet.gboxV.Enabled = false;
                //wss 压力曲线
                //Curve_Start = DateTime.Now;
#if LOG_TREAT
                getLog.WriteLogFile("T2");
#endif
                RunStartMonitorTask();
            }
            else
            {//停止
#if LOG_TREAT
                getLog.WriteLogFile("T1");
#endif

#if LOG_TREAT
                getLog.WriteLogFile("T2");
#endif
                this.btnStart.Enabled = false;
                M_isTreat = false;
                //停止时，将阶段时间累积
                M_lst_TreatCount.Add(M_int_TreatCount);
                if (m_taskStartMonitor != null)
                    m_ctsMonitor.Cancel();
                if (m_taskStartPump != null)
                    m_ctsStartPump.Cancel();
                if (m_taskReleaseWarn != null)
                    m_ctsReleaseWarn.Cancel();
                if (m_taskSendWarn != null)
                    m_ctsSendWarn.Cancel();

                //向导不可用
                switch (M_modeName.ToLower())
                {
                    case "pert":
                        //M_stop_ChangePERT();
                        m_stepPERT.Enabled = false;
                        break;
                    case "li-als":
                        //创新模式向导根据当前显示的page调用停止函数
                        //M_stop_ChangeLiALS();
                        m_stepLiALS.Enabled = false;
                        break;
                    case "pe":
                        //m_stepPE.btnPausePE_Click(m_stepPE.btnPausePE, e);
                        m_stepPE.Enabled = false;
                        break;
                    //添加PP模式下 按右下角停止按键后，向导界面状态变化
                    //wss 2016年2月19日
                    case "pp":
                        //m_stepPP.btnPausePP_Click(m_stepPP.btnPausePP, e);
                        m_stepPP.Enabled = false;
                        break;
                    case "pdf":
                        //m_stepPDF.btnPausePDF_Click(m_stepPDF.btnPausePDF, e);
                        m_stepPDF.Enabled = false;
                        break;
                    case "chdf":
                        //m_stepCHDF.btnPauseCHDF_Click(m_stepCHDF.btnPauseCHDF, e);
                        m_stepCHDF.Enabled = false;
                        break;
                }
#if LOG_TREAT
                getLog.WriteLogFile("T3");
#endif
                if (M_bl_isFinishTreat)
                {
                    this.tsbtnSetFlow.Enabled = false;
                    this.tsbtnSum.Enabled = false;
                    this.tsbtnLevel.Enabled = false;
                    this.tsbtnOtherSet.Enabled = false;
                    this.tsbtnTherapy.Enabled = false;
                    this.tsbtnPipeline.Enabled = false;
                    this.tsbtnPreFlush.Enabled = false;
                    this.tsbtnExit.Enabled = true;
                    M_isTreat = false;
                    this.btnStart.Image = Properties.Resources.start;
                    this.btnStart.Text = "开始";
                    this.btnStart.ForeColor = Color.Green;
                    this.lblBloodSpeed.Text = "000";
                    SendStopOrder();
                    return;
                }

                //SetOtherfrmBtnState(M_PumpState);
                //肝素泵按钮状态
                M_uc_OtherSet.SetSPButton(false);
                ChgTreStep_State(M_modeName);
                SendStopOrder();
                this.toolStripControl.Enabled = true;
                this.tsbtnPipeline.Enabled = true;
                this.tsbtnPreFlush.Enabled = true;
                this.tsbtnSetFlow.Enabled = true;
                this.btnStart.Image = Properties.Resources.start;
                this.btnStart.Text = "开始";
                this.btnStart.ForeColor = Color.Green;
                this.lblBloodSpeed.Text = "000";
                this.tsbtnExit.Enabled = true;
                M_uc_OtherSet.gboxV.Enabled = true;
#if LOG_TREAT
                getLog.WriteLogFile("T4");
#endif
            }
        }

        private void RunStartMonitorTask()
        {
#if LOG_TREAT
            getLog.WriteLogFile("开始发送StartOrders");
#endif
            //启动所需要发送的命令
            SendStartOrder();

#if LOG_TREAT
            getLog.WriteLogFile("结束发送StartOrders");
#endif
            m_ctsMonitor = new CancellationTokenSource();
            m_taskStartMonitor = TaskMonitor(m_ctsMonitor.Token);
        }

        private void SendStartOrder()
        {
            Task t = StartOrder();
        }

        private void SendStopOrder()
        {
            Task t = StopTreat();
        }

        async Task StartOrder()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(50)).ConfigureAwait(false);
            List<Cls.Model_SendCMD> lstStart = lst_Start();
            foreach (var v in lstStart)
            {
                SendOrder(v.SP, v.CMD);
            }
            this.BeginInvoke(new Action(() =>
            {
                this.btnStart.Enabled = true;
            }));
        }

        async Task StopTreat()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(50)).ConfigureAwait(false);
            List<Cls.Model_SendCMD> _lstStop = lst_Stop();
            foreach (var v in _lstStop)
            {
                SendOrder(v.SP, v.CMD);
            }
            this.BeginInvoke(new Action(() =>
            {
                this.btnStart.Enabled = true;
            }));
        }

        async Task TaskMonitor(CancellationToken ct)
        {
            m_dtMonitor = DateTime.Now;
#if LOG_TREAT
            getLog.WriteLogFile("开始任务");
#endif
            while (M_isTreat)
            {
                //执行一次该过程时间计时
                int startTime = System.Environment.TickCount;
                await Task.Delay(TimeSpan.FromMilliseconds(500)).ConfigureAwait(false);
                if (ct.IsCancellationRequested)
                    break;
                else
                {
                    //ms为单位
                    TimeSpan tsMonitor = new TimeSpan((DateTime.Now - m_dtMonitor).Ticks);
                    M_int_TreatCount = (int)tsMonitor.TotalSeconds;
                    M_int_TreatCountSum = (int)tsMonitor.TotalSeconds + M_lst_TreatCount.Sum();    //(int)(m_watchMonitor.ElapsedMilliseconds / 1000.0);

                    if (M_exsitsWarn)
                    {
                        #region 采血压下限预报警:采血压低于 下限设定值+预报警设定值发生
                        if ((M_ModelValue.M_flt_PofPacc < M_ModelTreat.PaccLower + M_ModelTreat.PrePaccLower) && (M_ModelValue.M_flt_PofPacc > M_ModelTreat.PaccLower) && (M_ModelTreat.PrePaccLower.Value != 0))
                        {
                            ShowWarn("W1-02");
                            m_leadBloodSpeed = 20;
                        }

                        //采血压的单位时间变化量超出设定值
                        if (M_ModelTreat.PaccDecrement != 0)
                        {
                            if (M_ModelValue.M_flt_PaccDecrement > M_ModelTreat.PaccDecrement.Value)
                            { ShowWarn("W1-02"); m_leadBloodSpeed = 20; }
                        }

                        #endregion

                        #region 采血压下限超出范围
                        if (M_ModelValue.M_flt_PofPacc < M_ModelTreat.PaccLower)
                        {
                            ShowWarn("W1-03");
                            m_leadBloodSpeed = 0;
                        }

                        #endregion

                        #region 动脉压上限预报警
                        if ((M_ModelValue.M_flt_PofPart < M_ModelTreat.PartUpper) && (M_ModelValue.M_flt_PofPart > M_ModelTreat.PartUpper - M_ModelTreat.PrePartUpper) && (M_ModelTreat.PrePartUpper != 0))
                            ShowWarn("W1-07");
                        #endregion

                        #region 动脉压上限超出范围
                        if (M_ModelValue.M_flt_PofPart > M_ModelTreat.PartUpper)
                            ShowWarn("W1-08");
                        #endregion

                        #region 动脉压下限超出范围
                        if (M_ModelValue.M_flt_PofPart < M_ModelTreat.PartLower)
                            ShowWarn("W1-09");
                        #endregion

                        #region 静脉压上限预警
                        if ((M_ModelValue.M_flt_PofPven > M_ModelTreat.PvenUpper - M_ModelTreat.PrePvenUpper) && (M_ModelValue.M_flt_PofPven < M_ModelTreat.PvenUpper) && (M_ModelTreat.PrePvenUpper != 0))
                            ShowWarn("W1-04");
                        #endregion

                        #region 静脉压上限超出范围
                        if (M_ModelValue.M_flt_PofPven > M_ModelTreat.PvenUpper)
                            ShowWarn("W1-05");
                        #endregion

                        #region 静脉压下限超出范围
                        if (M_ModelValue.M_flt_PofPven < M_ModelTreat.PvenLower)
                        {
                            //M_exsitsTip = false;
                            ShowWarn("W1-06");
#if LOG_WARNING
                                getLog.WriteLogFile("W1-06,静脉压下限超出范围");
#endif
                        }
                        #endregion

                        #region 血浆压上限超出范围
                        if (M_ModelValue.M_flt_PofP1st > M_ModelTreat.P1stUpper)
                            ShowWarn("W1-10");
                        #endregion

                        #region 血浆压下限超出范围
                        if (M_ModelValue.M_flt_PofP1st < M_ModelTreat.P1stLower)
                            ShowWarn("W1-11");
                        #endregion

                        #region 温度偏离设定值
                        if (M_ModelValue.M_flt_Temperature < M_ModelTreat.TargetT.Value - 1 || M_ModelValue.M_flt_Temperature > M_ModelTreat.TargetT.Value + 1)
                            ShowWarn("W2-10");
                        #endregion

                        if (M_modeName == "Li-ALS")
                        {
                            #region 血浆入口压1上限超出范围
                            if (M_ModelValue.M_flt_PofP2nd > M_ModelTreat.P2ndUpper)
                                ShowWarn("W1-14");
                            #endregion

                            #region 血浆入口压1下限超出范围
                            if (M_ModelValue.M_flt_PofP2nd < M_ModelTreat.P2ndLower)
                                ShowWarn("W1-15");
                            #endregion

                            #region 血浆入口压2上限超出范围
                            if (M_ModelValue.M_flt_PofP3rd > M_ModelTreat.P3rdUpper)
                                ShowWarn("W3-18");
                            #endregion

                            #region 血浆入口压2下限超出范围
                            if (M_ModelValue.M_flt_PofP3rd < M_ModelTreat.P3rdLower)
                                ShowWarn("W3-19");
                            #endregion
                        }

                        if (M_modeName == "PP")
                        {
                            #region 血浆入口压1上限超出范围
                            if (M_ModelValue.M_flt_PofP2nd > M_ModelTreat.P2ndUpper)
                                ShowWarn("W1-14");
                            #endregion

                            #region 血浆入口压1下限超出范围
                            if (M_ModelValue.M_flt_PofP2nd < M_ModelTreat.P2ndLower)
                                ShowWarn("W1-15");
                            #endregion
                        }

                        #region TMP上限超出范围
                        if (M_ModelValue.M_flt_PofTMP > M_ModelTreat.TmpUpper)
                            ShowWarn("W1-18");
                        #endregion

                        #region TMP下限超出范围
                        if (M_ModelValue.M_flt_PofTMP < M_ModelTreat.TmpLower)
                            ShowWarn("W1-19");
                        #endregion

                        #region 漏血值超出范围 150W至250W 为 0% - 100% ，0表示关闭
                        int bloodleak = (150 + (int)M_ModelTreat.BloodLeak) * 10000;
                        if (M_ModelValue.M_flt_BloodLeak < bloodleak && M_ModelTreat.BloodLeak != 0)
                            ShowWarn("W1-23");
                        #endregion

                        M_exsitsWarn = false;
                    }

                    //判断各累积值是否有效，提前预警
                    #region 累计值达到 只提示一次!!!!
                    if (M_ModelTreat.IsTargetTime)
                    {
                        //不用时间计数器，应用当前时间-开始时间来计算时间累计

                        if (M_int_TreatCountSum >= M_ModelTreat.TargetTimeH * 3600 + M_ModelTreat.TargetTimeMin * 60 && !m_isUptoTime)
                        {
                            m_isUptoTime = true;
                            ShowWarn("N-03");
                        }
                    }

                    if (M_ModelTreat.IsTargetBP)
                    {
                        if (M_ModelTotal.TotalBP >= M_ModelTreat.TargetBP && !m_isUptoBP)
                        {
                            m_isUptoBP = true;
                            ShowWarn("N-01");
                        }
                    }

                    if (M_ModelTreat.IsTargetDP && M_ModelTreat.DPValid)
                    {
                        if (M_ModelTotal.TotalDP >= M_ModelTreat.TargetDP && !m_isUptoDP)
                        {
                            m_isUptoDP = true;
                            ShowWarn("N-12");
                        }
                    }

                    if (M_ModelTreat.IsTargetFP)
                    {
                        if (M_ModelTotal.TotalFP >= M_ModelTreat.TargetFP && !m_isUptoFP)
                        {
                            m_isUptoFP = true;
                            ShowWarn("N-02");
                        }
                    }

                    if (M_ModelTreat.IsTargetRP)
                    {
                        if (M_ModelTotal.TotalRP >= M_ModelTreat.TargetRP && !m_isUptoRP)
                        {
                            m_isUptoRP = true;
                            ShowWarn("N-08");
                        }
                    }

                    #endregion

                    #region 脱水如果有效，计算脱水量,以实际称重的读数为准
                    if (M_ModelTreat.dehydrationValid && m_bl_Balance)// - (weigh1_startvalue - M_ModelValue.M_flt_Weigh1)
                    {
                        //weigh2异常计数 
                        if (Math.Abs(M_ModelValue.M_flt_Weigh2 - M_lstWeigh2[3 - m_wrongweigh2count]) < 30)
                        {
                            m_wrongweigh2count--;
                            if (m_wrongweigh2count < 0)
                                m_wrongweigh2count = 0;
                        }
                        else
                        {
                            m_wrongweigh2count++;
                            if (m_wrongweigh2count > 3)
                                m_wrongweigh2count = 3;
                        }
                        //weigh3异常计数 
                        if (Math.Abs(M_ModelValue.M_flt_Weigh3 - M_lstWeigh3[3 - m_wrongweigh3count]) < 30)
                        {
                            m_wrongweigh3count--;
                            if (m_wrongweigh3count < 0)
                                m_wrongweigh3count = 0;
                        }
                        else
                        {
                            m_wrongweigh3count++;
                            if (m_wrongweigh3count > 3)
                                m_wrongweigh3count = 3;
                        }
                        //泵秤平衡异常 
                        if (m_wrongweigh2count >= 3 || m_wrongweigh3count >= 3)
                        {
                            m_bl_Balance = false;
                            ShowWarn("W3-20");
                        }
                        //计算偏差 
                        if (m_bl_Balance && m_wrongweigh2count == 0 && m_wrongweigh3count == 0)
                        {
                            M_ModelTotal.CurrentDry = (M_ModelValue.M_flt_Weigh2 - weigh2_startvalue) - (weigh3_startvalue - M_ModelValue.M_flt_Weigh3);
                        }
                    }
                    #endregion

                    if ((m_watchFPRuning.ElapsedMilliseconds / 1000) % 10 >= 1)
                        DoPumpBalance = true;

                    #region PE泵秤联动
                    if (DoPumpBalance == true && M_modeName == "PE")
                    {
                        BalanceOfPE();
                    }
                    #endregion

                    #region CHDF 泵称联动
                    if (DoPumpBalance == true && M_modeName == "CHDF" && m_bl_Balance && M_PumpState.FPState.Runing)
                    {
                        BalanceOfCHDF();
                    }
                    #endregion

                    #region PDF 泵称联动
                    if (DoPumpBalance == true && M_modeName == "PDF" && m_bl_Balance && M_PumpState.FPState.Runing)
                    {
                        BalanceOfPDF();
                    }
                    #endregion

                    #region Li-ALS平衡
                    if (DoPumpBalance == true && M_modeName == "Li-ALS" && m_bl_Balance)
                    {
                        BalanceOfLiALS();
                    }
                    #endregion

                    #region PERT 平衡
                    if (DoPumpBalance == true && M_modeName == "PERT" && m_bl_Balance)
                    {
                        BalanceOfPERT();
                    }
                    #endregion

                    #region 累计值改变
                    int endTime = System.Environment.TickCount;
                    //该过程结束时的时间段 (ms)
                    m_voidspan = endTime - startTime;
                    M_ModelTotal.TotalTime = (int)M_int_TreatCountSum;
                    //泵速度根据设置值调节，累计值跟随 泵速度调节  mL/min /1000 = L/min /60 = L/s
                    if (M_PumpState.BPState.Runing)
                        M_ModelTotal.TotalBP += M_PumpState.BPState.Speed * m_voidspan / 60000000.0; //M_ModelTreat.BPSpeed / 120000.0; //累积 L/s
                    if (M_PumpState.RPState.Runing)
                        M_ModelTotal.TotalRP += M_PumpState.RPState.Speed * m_voidspan / 60000000.0; //M_ModelTreat.RPSpeed / 120000.0;
                    if (M_PumpState.FPState.Runing)
                        M_ModelTotal.TotalFP += M_PumpState.FPState.Speed * m_voidspan / 60000000.0; //M_ModelTreat.FPSpeed / 120000.0;
                    if (M_PumpState.DPState.Runing)
                        M_ModelTotal.TotalDP += M_PumpState.DPState.Speed * m_voidspan / 60000000.0;//M_ModelTreat.DPSpeed / 120000.0;
                    if (M_PumpState.FP2State.Runing)
                        M_ModelTotal.TotalFP2 += M_PumpState.FP2State.Speed * m_voidspan / 60000000.0;
                    #endregion
                }
            }
        }
        /// <summary>
        /// WS2 和 WS3 通过FP的平衡
        /// </summary>
        private void BalanceOfPE()
        {
            //10秒检测一次
            if ((m_watchFPRuning.ElapsedMilliseconds / 1000) % 10 == 0 && m_bl_Balance)
            {
                DoPumpBalance = false;
                //泵秤平衡
                double reduce3 = weigh3_startvalue - M_ModelValue.M_flt_Weigh3;
                double add2 = M_ModelValue.M_flt_Weigh2 - weigh2_startvalue;
                if ((add2 - reduce3) > 3)
                {
                    //速度限制，调整分离泵FP的速度，FP=(0.833RP~1.25RP)
                    //FP过快
                    M_ModelTreat.FPSpeed -= 1;
                    //速度上限
                    double speedu = M_ModelTreat.RPSpeed.Value * 1.2;
                    //过浓缩限制
                    double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                    double maxSpeed = Math.Min(speedu, speedoverc);//两者取小值
                    if (M_ModelTreat.FPSpeed.Value > maxSpeed)
                        M_ModelTreat.FPSpeed = maxSpeed;
                    if (M_ModelTreat.FPSpeed.Value < M_ModelTreat.RPSpeed.Value * 0.8)
                        M_ModelTreat.FPSpeed = M_ModelTreat.RPSpeed.Value * 0.8;
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                }
                if ((add2 - reduce3) < -3)
                {
                    //FP过慢
                    M_ModelTreat.FPSpeed += 1;
                    //速度上限
                    double speedu = M_ModelTreat.RPSpeed.Value * 1.2;
                    //过浓缩限制
                    double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                    double maxSpeed = Math.Min(speedu, speedoverc);//两者取小值
                    if (M_ModelTreat.FPSpeed.Value > maxSpeed)
                        M_ModelTreat.FPSpeed = maxSpeed;
                    if (M_ModelTreat.FPSpeed.Value < M_ModelTreat.RPSpeed.Value * 0.8)
                        M_ModelTreat.FPSpeed = M_ModelTreat.RPSpeed.Value * 0.8;
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                }
                new BLL.treatmentmode().Update(M_ModelTreat);
            }
        }
        /// <summary>
        /// 调节FP, CHDF脱水平衡
        /// </summary>
        private void BalanceOfCHDF()
        {
            //以秒为单位
            int t = (int)(m_watchFPRuning.ElapsedMilliseconds / 1000.0);
            //M_uc_Treat.lblFPRuningTime.Text = t.ToString();
            //此时理论脱水总量 ml
            dryLilun = t * M_ModelTreat.dehydrationSpeed.Value / 3600.0;
            //脱水偏差值
            dryDeviation = M_ModelTotal.CurrentDry - dryLilun;
            //隔10s检测一次
            dryDeviationSum = dryDeviation + m_BalanceSum._DryDeviation;
            if ((m_watchFPRuning.ElapsedMilliseconds / 1000) % 10 == 0 && m_bl_Balance)
            {
                DoPumpBalance = false;
                //MessageBox.Show("偏差累计:" + dryDeviationSum.ToString());
                //脱水过快
                if (dryDeviationSum > 3.0)
                {
                    M_ModelTreat.FPSpeed -= 1;

                    //过浓缩速度限制
                    double speedup = (M_ModelTreat.DPSpeed.Value + M_ModelTreat.RPSpeed.Value) * 1.2;
                    double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                    double maxSpeed = Math.Max(speedup, speedoverc);
                    //速度上限
                    if (M_ModelTreat.FPSpeed > maxSpeed)
                        M_ModelTreat.FPSpeed = maxSpeed;

                    //速度下限
                    if (M_ModelTreat.FPSpeed < (M_ModelTreat.DPSpeed.Value + M_ModelTreat.RPSpeed.Value) * 0.8)
                        M_ModelTreat.FPSpeed = (M_ModelTreat.DPSpeed.Value + M_ModelTreat.RPSpeed.Value) * 0.8;
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                }
                //脱水过慢
                if (dryDeviationSum < -3.0)
                {
                    M_ModelTreat.FPSpeed += 1;
                    //过浓缩速度限制
                    double speedup = (M_ModelTreat.DPSpeed.Value + M_ModelTreat.RPSpeed.Value) * 1.2;
                    double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                    double maxSpeed = Math.Max(speedup, speedoverc);
                    //速度上限
                    if (M_ModelTreat.FPSpeed > maxSpeed)
                        M_ModelTreat.FPSpeed = maxSpeed;
                    //速度下限
                    if (M_ModelTreat.FPSpeed < (M_ModelTreat.DPSpeed + M_ModelTreat.RPSpeed) * 0.8)
                        M_ModelTreat.FPSpeed = (M_ModelTreat.DPSpeed + M_ModelTreat.RPSpeed) * 0.8;
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                }
                new BLL.treatmentmode().Update(M_ModelTreat);
            }
        }
        /// <summary>
        /// 调节FP, PDF脱水平衡
        /// </summary>
        private void BalanceOfPDF()
        {
            //以秒为单位
            int t = (int)(m_watchFPRuning.ElapsedMilliseconds / 1000.0);
            //M_uc_Treat.lblFPRuningTime.Text = t.ToString();
            //此时理论脱水总量 ml
            dryLilun = t * M_ModelTreat.dehydrationSpeed.Value / 3600.0;
            //脱水偏差值
            dryDeviation = M_ModelTotal.CurrentDry - dryLilun;
            //隔10s检测一次
            dryDeviationSum = dryDeviation + m_BalanceSum._DryDeviation;
            if ((m_watchFPRuning.ElapsedMilliseconds / 1000) % 10 == 0 && m_bl_Balance)
            {
                DoPumpBalance = false;
                //脱水过快
                if (dryDeviationSum > 3.0)
                {
                    M_ModelTreat.FPSpeed -= 1;
                    //速度上限
                    double speedu = (M_ModelTreat.DPSpeed.Value + M_ModelTreat.RPSpeed.Value + M_ModelTreat.FP2Speed.Value) * 1.2;
                    //过浓缩限制
                    double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                    double maxSpeed = Math.Min(speedu, speedoverc);//两者取小值
                    if (M_ModelTreat.FPSpeed > maxSpeed)
                        M_ModelTreat.FPSpeed = maxSpeed;
                    //速度下限
                    double speedd = (M_ModelTreat.DPSpeed.Value + M_ModelTreat.RPSpeed.Value + M_ModelTreat.FP2Speed.Value) * 0.8;
                    if (M_ModelTreat.FPSpeed < speedd)
                        M_ModelTreat.FPSpeed = speedd;
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                }
                //脱水过慢
                if (dryDeviationSum < -3.0)
                {
                    M_ModelTreat.FPSpeed += 1;
                    //速度上限
                    double speedu = (M_ModelTreat.DPSpeed.Value + M_ModelTreat.RPSpeed.Value + M_ModelTreat.FP2Speed.Value) * 1.2;
                    //过浓缩限制
                    double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                    double maxSpeed = Math.Min(speedu, speedoverc);//两者取小值
                    if (M_ModelTreat.FPSpeed > maxSpeed)
                        M_ModelTreat.FPSpeed = maxSpeed;
                    //速度下限
                    double speedd = (M_ModelTreat.DPSpeed.Value + M_ModelTreat.RPSpeed.Value + M_ModelTreat.FP2Speed.Value) * 0.8;
                    if (M_ModelTreat.FPSpeed < speedd)
                        M_ModelTreat.FPSpeed = speedd;
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                }
                new BLL.treatmentmode().Update(M_ModelTreat);
            }
        }
        private void BalanceOfLiALS()
        {
            switch (m_currentStep)
            {
                case 1:
                    #region 血浆置换，WS3 和 WS2的平衡
                    if ((m_watchFPRuning.ElapsedMilliseconds / 1000) % 10 == 0 && m_bl_Balance)
                    {
                        DoPumpBalance = false;
                        //泵秤平衡
                        double add2 = M_ModelValue.M_flt_Weigh2 - weigh2_startvalue;
                        double reduce3 = weigh3_startvalue - M_ModelValue.M_flt_Weigh3;
                        if ((add2 - reduce3) > 3)
                        {
                            //速度限制，调整分离泵FP的速度，FP=(0.833RP~1.25RP)
                            //FP过快
                            M_ModelTreat.FPSpeed -= 1;

                            //过浓缩速度限制
                            double speedup = M_ModelTreat.DPSpeed.Value * 1.2;
                            double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                            double maxSpeed = Math.Max(speedup, speedoverc);
                            //速度上限
                            if (M_ModelTreat.FPSpeed > maxSpeed)
                                M_ModelTreat.FPSpeed = maxSpeed;
                            //速度下限
                            if (M_ModelTreat.FPSpeed.Value < M_ModelTreat.DPSpeed.Value * 0.8)
                                M_ModelTreat.FPSpeed = M_ModelTreat.DPSpeed.Value * 0.8;

                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        }
                        if ((add2 - reduce3) < -3)
                        {
                            //FP过慢
                            M_ModelTreat.FPSpeed += 1;
                            //速度上限
                            double speedu = (M_ModelTreat.DPSpeed.Value) * 1.2;
                            //过浓缩限制
                            double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                            //两者取小值
                            double maxSpeed = Math.Min(speedu, speedoverc);
                            if (M_ModelTreat.FPSpeed.Value > maxSpeed)
                                M_ModelTreat.FPSpeed = maxSpeed;

                            //速度下限
                            if (M_ModelTreat.FPSpeed.Value < M_ModelTreat.DPSpeed.Value * 0.8)
                                M_ModelTreat.FPSpeed = M_ModelTreat.DPSpeed.Value * 0.8;

                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        }
                        new BLL.treatmentmode().Update(M_ModelTreat);
                    }
                    #endregion
                    break;
                case 2:
                    #region 收集血浆 WS3 与 WS4的平衡
                    if ((m_watchFPRuning.ElapsedMilliseconds / 1000) % 10 == 0 && m_bl_Balance)
                    {
                        DoPumpBalance = false;
                        //泵秤平衡
                        double add4 = M_ModelValue.M_flt_Weigh4 - weigh4_startvalue;
                        double reduce3 = weigh3_startvalue - M_ModelValue.M_flt_Weigh3;
                        if ((add4 - reduce3) > 3)
                        {
                            //速度限制，调整分离泵FP的速度，FP=(0.833RP~1.25RP)
                            //FP过快
                            M_ModelTreat.FPSpeed -= 1;

                            //过浓缩速度限制
                            double speedup = M_ModelTreat.DPSpeed.Value * 1.2;
                            double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                            double maxSpeed = Math.Max(speedup, speedoverc);
                            //速度上限
                            if (M_ModelTreat.FPSpeed > maxSpeed)
                                M_ModelTreat.FPSpeed = maxSpeed;
                            //速度下限
                            if (M_ModelTreat.FPSpeed.Value < M_ModelTreat.DPSpeed.Value * 0.8)
                                M_ModelTreat.FPSpeed = M_ModelTreat.DPSpeed.Value * 0.8;

                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        }
                        if ((add4 - reduce3) < -3)
                        {
                            //FP过慢
                            M_ModelTreat.FPSpeed += 1;
                            //速度上限
                            double speedu = (M_ModelTreat.DPSpeed.Value) * 1.2;
                            //过浓缩限制
                            double speedoverc = M_ModelTreat.BPSpeed.Value * M_ModelTreat.Concentration.Value / 100.0;
                            //两者取小值
                            double maxSpeed = Math.Min(speedu, speedoverc);
                            if (M_ModelTreat.FPSpeed.Value > maxSpeed)
                                M_ModelTreat.FPSpeed = maxSpeed;

                            //速度下限
                            if (M_ModelTreat.FPSpeed.Value < M_ModelTreat.DPSpeed.Value * 0.8)
                                M_ModelTreat.FPSpeed = M_ModelTreat.DPSpeed.Value * 0.8;

                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelTreat.FPSpeed.Value, true, true));
                        }
                        new BLL.treatmentmode().Update(M_ModelTreat);
                    }
                    #endregion
                    break;
                case 3:
                    #region 整体治疗 脱水平衡
                    //调节FP2的速度 10秒检测一次 
                    if ((m_watchFPRuning.ElapsedMilliseconds / 1000) % 10 == 0)
                    {
                        DoPumpBalance = false;
                        #region 保持秤4平衡
                        //double add4 = M_ModelValue.M_flt_Weigh4 - weigh4_startvalue;

                        //if (add4 > 3)//补液快
                        //{
                        //    M_ModelTreat.FP2Speed += 1;
                        //    if (M_ModelTreat.FP2Speed.Value > M_ModelTreat.RPSpeed.Value * 1.25)
                        //        M_ModelTreat.FP2Speed = M_ModelTreat.RPSpeed.Value * 1.25;
                        //    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelTreat.FP2Speed.Value , true, false));
                        //    //向导界面速度值更新 
                        //    m_stepLiALS.ReadSet();
                        //}

                        //if (add4 < -3)//补液慢
                        //{
                        //    M_ModelTreat.FP2Speed -= 1;
                        //    if (M_ModelTreat.FP2Speed.Value < M_ModelTreat.RPSpeed.Value * 0.833)
                        //        M_ModelTreat.FP2Speed = M_ModelTreat.RPSpeed.Value * 0.833;
                        //    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelTreat.FP2Speed.Value , true, false));
                        //    //向导界面速度值更新
                        //    m_stepLiALS.ReadSet();
                        //}
                        #endregion
                        //以秒为单位
                        int t = (int)(m_watchFPRuning.ElapsedMilliseconds / 1000.0);
                        //此时理论脱水总量 ml
                        dryLilun = t * M_ModelTreat.dehydrationSpeed.Value / 3600.0;
                        //脱水偏差值
                        dryDeviation = M_ModelTotal.CurrentDry - dryLilun;
                        //隔10s检测一次
                        dryDeviationSum = dryDeviation + m_BalanceSum._DryDeviation;
                        if ((m_watchFPRuning.ElapsedMilliseconds / 1000) % 10 == 0 && m_bl_Balance)
                        {
                            DoPumpBalance = false;
                            //脱水过快
                            if (dryDeviationSum > 3.0)
                            {
                                M_ModelTreat.FP2Speed -= 1;
                                //速度上限
                                if (M_ModelTreat.FP2Speed > M_ModelTreat.RPSpeed.Value * 1.2)
                                    M_ModelTreat.FP2Speed = M_ModelTreat.RPSpeed.Value * 1.2;
                                //速度下限
                                if (M_ModelTreat.FP2Speed < M_ModelTreat.RPSpeed.Value * 0.8)
                                    M_ModelTreat.FP2Speed = M_ModelTreat.RPSpeed.Value * 0.8;
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelTreat.FP2Speed.Value, true, false));
                            }
                            //脱水过慢
                            if (dryDeviationSum < -3.0)
                            {
                                M_ModelTreat.FP2Speed += 1;
                                //速度上限
                                if (M_ModelTreat.FP2Speed > M_ModelTreat.RPSpeed * 1.2)
                                    M_ModelTreat.FP2Speed = M_ModelTreat.RPSpeed * 1.2;
                                //速度下限
                                if (M_ModelTreat.FP2Speed < M_ModelTreat.RPSpeed * 0.8)
                                    M_ModelTreat.FP2Speed = M_ModelTreat.RPSpeed * 0.8;
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelTreat.FP2Speed.Value, true, false));
                            }
                            new BLL.treatmentmode().Update(M_ModelTreat);
                        }
                    }
                    #endregion
                    break;

            }
        }
        private void BalanceOfPERT()
        {
            switch (m_currentStep)
            {
                case 1://血浆置换
                    BalanceOfPE();
                    break;
                case 4://血滤治疗，泵秤脱水平衡
                    BalanceOfCHDF();
                    break;
            }
        }
        private void toolStripControl_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem tsi in this.toolStripControl.Items)
            {
                if (tsi is ToolStripButton)
                {
                    tsi.ForeColor = Color.FromArgb(15, 8, 100);
                    tsi.BackgroundImage = global::ALS.Properties.Resources.buttonface;
                }
            }
            if (e.ClickedItem is ToolStripButton)
            {
                e.ClickedItem.ForeColor = Color.White;
                e.ClickedItem.BackgroundImage = global::ALS.Properties.Resources.buttonfacesel;
            }
        }

        private void toolStripOther_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null) return;
            switch (e.ClickedItem.Tag.ToString())
            {
                case "sp":
                    break;
                case "ld":
                    //m_isOpenBloodleak = !m_isOpenBloodleak;
                    break;
                case "ad1":
                    //if (!m_isOpenAD1)
                    //{
                    //    SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble1);
                    //}
                    //else
                    //{
                    //    SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble1);
                    //}
                    break;
                case "ad2":
                    //if (!m_isOpenAD2)
                    //{
                    //    SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble2);
                    //}
                    //else
                    //{
                    //    SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble2);
                    //}
                    break;
                case "ad3":
                    //if (!m_isOpenAD3)
                    //{
                    //    SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble3);
                    //}
                    //else
                    //{
                    //    SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble3);
                    //}
                    break;
                case "ht":
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (m_frmAdmin == null)
            {
                m_frmAdmin = new Manager.frmAdmin();
                m_frmAdmin._Port_hpump = this.port_hpump;
                m_frmAdmin._Port_main = this.port_main;
                m_frmAdmin._Port_ppump = this.port_ppump;
                m_frmAdmin._IsOpenAD1 = this.m_isOpenAD1;
                m_frmAdmin._IsOpenAD2 = this.m_isOpenAD2;
                m_frmAdmin._IsOpenAD3 = this.m_isOpenAD3;
                m_frmAdmin._Method = M_modeName;
                m_frmAdmin.FormClosing += m_frmAdmin_FormClosing;
                m_frmAdmin.btnexit += m_frmAdmin_btnexit;
                m_frmAdmin.ch_VClick += M_uc_SetFlow_checkVClick;
                m_frmAdmin.btn_RunPump += M_uc_SetFlow_btnRun_Pump;
                m_frmAdmin._tsItemClick += m_frmAdmin__tsItemClick;
                m_frmAdmin.Show();
                //m_frmAdmin.rtBoxData.Focus();
                //m_frmAdmin.rtBoxData.Select(m_frmAdmin.rtBoxData.Text.Length, 0);
            }
            else
            {
                m_frmAdmin.WindowState = FormWindowState.Normal;
                m_frmAdmin.BringToFront();
                m_frmAdmin.Show();
                //m_frmAdmin.rtBoxData.Focus();
                //m_frmAdmin.rtBoxData.Select(m_frmAdmin.rtBoxData.Text.Length, 0);
            }
            LoadWeighPara();
        }

        void m_frmAdmin__tsItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null) return;
            switch (e.ClickedItem.Tag.ToString())
            {
                case "ad1":
                    if (!m_isOpenAD1)
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble1);
                    }
                    else
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble1);
                    }
                    break;
                case "ad2":
                    if (!m_isOpenAD2)
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble2);
                    }
                    else
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble2);
                    }
                    break;
                case "ad3":
                    if (!m_isOpenAD3)
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble3);
                    }
                    else
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble3);
                    }
                    break;
                default:
                    break;
            }
            //throw new NotImplementedException();
        }

        void m_frmAdmin_btnexit(object sender, EventArgs e)
        {
            m_frmAdmin.FormClosing -= m_frmAdmin_FormClosing;
            m_frmAdmin.btnexit -= m_frmAdmin_btnexit;
            m_frmAdmin.Dispose();
            m_frmAdmin = null;
            //throw new NotImplementedException();
        }

        void m_frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_frmAdmin.FormClosing -= m_frmAdmin_FormClosing;
            m_frmAdmin.btnexit -= m_frmAdmin_btnexit;
            m_frmAdmin.Dispose();
            m_frmAdmin = null;
            //throw new NotImplementedException();
        }

        private void RunStartPumpTreatTask()
        {
            m_ctsStartPump = new CancellationTokenSource();
            m_taskStartPump = TaskStartPumpTreat(m_ctsStartPump.Token);
            //System.Runtime.CompilerServices.TaskAwaiter<int> awaiter =  TaskStartPumpTreat(m_ctsStartPump.Token).GetAwaiter();
            //awaiter.OnCompleted(() =>
            //{
            //    m_ctsStartPump = null;
            //    #if LOG_SYSTEM
            //    getLog.WriteLogFile("frmMain - Line 5716 TaskStartPumpTreat:Finished ");
            //    #endif 
            //}); 
        }

        async Task TaskStartPumpTreat(CancellationToken ct)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(50)).ConfigureAwait(false);

            List<Cls.Model_SendCMD> lststartpumpcmd = lstStartPumpCMD();
            int count = lststartpumpcmd.Count;
#if LOG_SYSTEM
            getLog.WriteLogFile("Start async await front:" + m_watchDebug.ElapsedMilliseconds.ToString());
#endif
            for (int i = 0; i < count; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    //如果取消操作,停止所有泵
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                    //添加任务取消指令
                    //wss 2016年3月10日
                    if (m_taskStartPump != null)
                        m_ctsStartPump.Cancel();
                    break;
                }
                else
                    SendOrder(lststartpumpcmd[i].SP, lststartpumpcmd[i].CMD);
#if LOG_SYSTEM
                          getLog.WriteLogFile("Order"  +i.ToString()+":"+ port_ppump.PortName.ToString()+ "TaskStartPumpTreat Use Time(ms):" + m_watchDebug.ElapsedMilliseconds.ToString());
#endif
            }
        }

        private async void RunStartPumpStateTask()
        {
            m_ctsStartPump = new CancellationTokenSource();
            await TaskStartPumpState(m_ctsStartPump.Token);
        }

        async Task TaskStartPumpState(CancellationToken cts)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(50)).ConfigureAwait(false);
            List<Cls.Model_SendCMD> lststartpumpcmd = lstStartPumpStateCMD();
            int count = lststartpumpcmd.Count;
            for (int i = 0; i < count; i++)
            {
                if (m_ctsStartPump.IsCancellationRequested)
                {
                    //如果取消操作,停止所有泵
                    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                    break; ;
                }
                else
                {
                    SendOrder(lststartpumpcmd[i].SP, lststartpumpcmd[i].CMD);
                }
            }
            SetOtherfrmBtnState(M_PumpState);
        }


        private void RunReleaseWarnTask()
        {
            m_ctsReleaseWarn = new CancellationTokenSource();
            m_taskReleaseWarn = TaskReleaseWarn(m_ctsReleaseWarn.Token);
        }

        async Task TaskReleaseWarn(CancellationToken cts)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(50)).ConfigureAwait(false);
            List<Cls.Model_SendCMD> _lstreleasecmd = lstReleaseCmd();
            int count = _lstreleasecmd.Count;
            for (int i = 0; i < count; i++)
            {
                if (cts.IsCancellationRequested)
                    break;
                else
                    SendOrder(_lstreleasecmd[i].SP, _lstreleasecmd[i].CMD);
            }
            //重置泵秤平衡异常计数器
            m_wrongweigh3count = m_wrongweigh2count = 0;
            //如果正在治疗

            this.BeginInvoke(new Action(() =>
            {
                if (M_isTreat)
                {
                    switch (M_modeName)
                    {
                        case "Li-ALS":
                            m_stepLiALS.Enabled = true;
                            break;
                        case "CHDF":
                            m_stepCHDF.Enabled = true;
                            break;
                        case "PE":
                            m_stepPE.Enabled = true;
                            break;
                        case "PERT":
                            m_stepPERT.Enabled = true;
                            break;
                        case "PDF":
                            m_stepPDF.Enabled = true;
                            break;
                        case "PP":
                            m_stepPP.Enabled = true;
                            break;
                    }
                }
                //M_uc_Treat.tabP.TabPages[0].Select();
                //如果正在预冲
                if (M_isFlush)
                {
                    M_uc_AutoFlush.btnContinue.Enabled = true;
                }
                //如果正在追加预冲
                if (m_isAddFlush)
                {
                    M_uc_AutoFlush.btnAddFlush.Enabled = true;
                }
            }));
        }

        private void txtSurgeryNo_Click(object sender, EventArgs e)
        {
            UserCtrl.numPad np = new UserCtrl.numPad(this.txtSurgeryNo.Text);
            np.btnNegPos.Visible = false;
            np.btnDot.Visible = false;

            if (DialogResult.OK == np.ShowDialog())
            {
                this.txtSurgeryNo.Text = np.Value.ToString();
            }
        }

        //socket 程序
        private void btnDownload_Click(object sender, EventArgs e)
        {
            string hostname = System.Net.Dns.GetHostName();
            Connect(hostname, "START," + this.txtSurgeryNo.Text + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        static void Connect(String server, String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                IPAddress localIP = IPAddress.Parse("127.0.0.1");
                IPEndPoint localEP = new IPEndPoint(localIP, 8081);
                TcpClient client = new TcpClient();
                client.Connect(localEP);
                client.ReceiveTimeout = 5000;
                client.ReceiveBufferSize = 256;
                client.SendBufferSize = 256;
                client.SendTimeout = 5000;
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();
                NetworkStream stream = client.GetStream();
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
                MessageBox.Show("发送:" + message);
                // Receive the TcpServer.response.
                // Buffer to store the response bytes.
                data = new Byte[256];
                // String to store the response ASCII representation.
                String responseData = String.Empty;
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                MessageBox.Show("接收:" + responseData);
                // Close everything.  
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        //wss 4772-4853
        //void Preshow_AddData()
        //{
        //    //X轴最大值调整
        //    if (M_uc_Treat.chart1.ChartAreas[0].AxisX.Maximum <= DateTime.Now.AddSeconds(60).ToOADate())
        //    {
        //        M_uc_Treat.chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddSeconds(-60).ToOADate();
        //        M_uc_Treat.chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddSeconds(240).ToOADate();
        //    }
        //    M_uc_Treat.Series_array[0].Points.AddXY(DateTime.Now.ToOADate(), M_ModelValue.M_flt_PofPacc);
        //    M_uc_Treat.Series_array[1].Points.AddXY(DateTime.Now.ToOADate(), M_ModelValue.M_flt_PofPart);
        //    M_uc_Treat.Series_array[2].Points.AddXY(DateTime.Now.ToOADate(), M_ModelValue.M_flt_PofPven);
        //    M_uc_Treat.Series_array[3].Points.AddXY(DateTime.Now.ToOADate(), M_ModelValue.M_flt_PofTMP);
        //    M_uc_Treat.Series_array[4].Points.AddXY(DateTime.Now.ToOADate(), M_ModelValue.M_flt_PofP1st);
        //    M_uc_Treat.Series_array[5].Points.AddXY(DateTime.Now.ToOADate(), M_ModelValue.M_flt_PofP2nd);
        //    M_uc_Treat.Series_array[6].Points.AddXY(DateTime.Now.ToOADate(), M_ModelValue.M_flt_PofP3rd);
        //    M_uc_Treat.chart1.Invalidate();
        //}

        //治疗向导 相关按键状态改变
        void ChgTreStep_State(string Modename)
        {
            //报警等级小于4的时候 改变治疗界面向导控件相关按键状态
            //wss 2016年3月4日
            switch (Modename)
            {
                case "PE":
                    m_stepPE.btnStartPE.Enabled = true;
                    m_stepPE.btnPausePE.Enabled = false;
                    m_stepPE.wizardPage2.AllowBack = true;
                    m_stepPE.wizardPage2.AllowNext = true;
                    m_stepPE.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepPE.Enabled = false;
                    break;
                case "PDF":
                    m_stepPDF.btnStartPDF.Enabled = true;
                    m_stepPDF.btnPausePDF.Enabled = false;
                    m_stepPDF.wizardPage2.AllowBack = true;
                    m_stepPDF.wizardPage2.AllowNext = true;
                    m_stepPDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepPDF.Enabled = false;
                    break;

                case "PP":
                    m_stepPP.btnStartPP.Enabled = true;
                    m_stepPP.btnPausePP.Enabled = false;
                    m_stepPP.wizardPage2.AllowBack = true;
                    m_stepPP.wizardPage2.AllowNext = true;
                    m_stepPP.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepPP.Enabled = false;
                    break;
                case "CHDF":
                    m_stepCHDF.btnStartCHDF.Enabled = true;
                    m_stepCHDF.btnPauseCHDF.Enabled = false;
                    m_stepCHDF.wizardPage2.AllowBack = true;
                    m_stepCHDF.wizardPage2.AllowNext = true;
                    m_stepCHDF.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    m_stepCHDF.Enabled = false;
                    break;
                case "Li-ALS":
                    m_stepLiALS.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");
                    //血浆置换
                    m_stepLiALS.btnStartPE.Enabled = true;
                    m_stepLiALS.btnPausePE.Enabled = false;
                    //收集血浆
                    m_stepLiALS.btnStartShouji.Enabled = true;
                    m_stepLiALS.btnStopShouji.Enabled = false;
                    //整体治疗
                    m_stepLiALS.btnPreCircle.Enabled = true;
                    m_stepLiALS.btnStartTreat.Enabled = true;
                    m_stepLiALS.btnPauseTreat.Enabled = false;
                    //准备回收
                    m_stepLiALS.btnReadRecycle.Enabled = true;
                    m_stepLiALS.btnStopReady.Enabled = false;

                    m_stepLiALS.Enabled = false;
                    if (m_stepLiALS.wizardControl1.SelectedPage.TabIndex > 0)
                    {
                        m_stepLiALS.wizardControl1.SelectedPage.AllowBack = true;
                        m_stepLiALS.wizardControl1.SelectedPage.AllowNext = true;
                    }
                    else
                        m_stepLiALS.wizardControl1.SelectedPage.AllowNext = true;
                    break;

                case "PERT":
                    m_stepPERT.btnStartPE.Enabled = true;
                    m_stepPERT.btnPausePE.Enabled = false;
                    m_stepPERT.btnStartCHDF.Enabled = true;
                    m_stepPERT.btnPauseCHDF.Enabled = false;
                    m_stepPERT.lblXuelvLeadBpSpeed.Text = m_stepPERT.lblLeadBloodSpeed.Text = m_leadBloodSpeed.ToString("f0");

                    if (m_stepPERT.wizardControl1.SelectedPage.TabIndex > 0)
                    {
                        m_stepPERT.wizardControl1.SelectedPage.AllowBack = true;
                        m_stepPERT.wizardControl1.SelectedPage.AllowNext = true;
                    }
                    else
                        m_stepPERT.wizardControl1.SelectedPage.AllowNext = true;
                    break;

                default: break;
            }
        }

        //点击右下角[停止]时，Li-ALS治疗模式下，根据Li-ALS向导当前显示的tabIndex调用停止函数
        //wss 2016年3月16日
        private void M_stop_ChangeLiALS()
        {
            int tabIndex = m_stepLiALS.wizardControl1.SelectedPage.TabIndex;
            switch (tabIndex)
            {
                case 1: m_stepLiALS.btnStopZhihuan_Click(m_stepLiALS.btnPausePE, new EventArgs()); break;
                case 2: m_stepLiALS.btnStopShouji_Click(m_stepLiALS.btnStopShouji, new EventArgs()); break;
                case 3: m_stepLiALS.btnPauseTreat_Click(m_stepLiALS.btnPauseTreat, new EventArgs()); break;
                case 4: m_stepLiALS.btnStopReady_Click(m_stepLiALS.btnStopReady, new EventArgs()); break;
                default: break;
            }
        }

        private void M_stop_ChangePERT()
        {
            int tabIndex = m_stepPERT.wizardControl1.SelectedPage.TabIndex;
            switch (tabIndex)
            {
                case 1: m_stepPERT.btnPausePE_Click(m_stepPERT.btnPausePE, new EventArgs()); break;
                case 2: m_stepPERT.btnStopRecycle_Click(m_stepPERT.btnStopRecycle, new EventArgs()); break;
                case 4: m_stepPERT.btnPauseCHDF_Click(m_stepPERT.btnPauseCHDF, new EventArgs()); break;
                default: break;
            }
        }

        //当未安装管路/未冲洗时，点击其他操作出现提示框时，改变左侧按钮状态；
        //wss 2016年3月19日
        private void M_BackCheckedInterface()
        {
            if (this.palContent.Controls.Count == 0)
                return;
            string CheckedInterface_name = this.palContent.Controls[0].Name;
            switch (CheckedInterface_name)
            {
                case "ucPipeLine": toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnPipeline)); break;
                case "MucAutoFlush":
                case "ucSelectFlush": toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnPreFlush)); break;
                case "ucSetFlow": toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnSetFlow)); break;
                case "ucSetOther": toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnOtherSet)); break;
                case "ucSetSum": toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnSum)); break;
                case "ucSetLiquidSurface": toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnLevel)); break;
                default: break;
            }
        }

        private void pBoxHome_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            for (int i = 0; i < m_lstBalance.Count; i++)
            {
                msg += "阶段:" + i.ToString() + "\r\n" + "累计偏差值:" + m_lstBalance[i]._DryDeviation + "累计实际脱水值:" + m_lstBalance[i]._DryTotalActually + "累计理论值:" + m_lstBalance[i]._DryTotalTheoretic
                      + "时间：" + m_lstBalance[i]._T + "s\r\n";
            }
            MessageBox.Show(msg);
        }

        private void tsbtnHT_Click(object sender, EventArgs e)
        {
            tsbtnOtherSet_Click(this.tsbtnOtherSet, e);
            toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnOtherSet));
            M_uc_OtherSet.tabControl1.SelectedTab = M_uc_OtherSet.tabControl1.TabPages[1];
        }

        private void tsbtnSP_Click(object sender, EventArgs e)
        {
            tsbtnOtherSet_Click(this.tsbtnOtherSet, e);
            toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnOtherSet));
            M_uc_OtherSet.tabControl1.SelectedTab = M_uc_OtherSet.tabControl1.TabPages[0];
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //HPTCMessageBox.MSBox m = new HPTCMessageBox.MSBox("警 告", "确认C1松开", HPTCMessageBox.MSBox.MSBoxIcon.Warning, global::ALS.Properties.Resources.StepLi_1);
            //m.ShowOnScreen();
            //UserCtrl.MsgBox m = new UserCtrl.MsgBox("请将管夹C1松开!", UserCtrl.MsgBox.MSBoxIcon.Warning , global::ALS.Properties.Resources.StepLi_2, false);
            //m.ShowDialog();
            /*
            CCWin.MessageBoxForm mbf = new CCWin.MessageBoxForm();
            CCWin.MessageBoxArgs mba = new CCWin.MessageBoxArgs();
            Bitmap bitmap =global::ALS.Properties.Resources.stepLi_3; 
            System.IntPtr iconHandle = bitmap.GetHicon();
            System.Drawing.Icon icon = Icon.FromHandle(iconHandle);
            mbf.Width = 500;
            mbf.Height = 350;
            mbf.ShowMessageBoxDialog(new CCWin.MessageBoxArgs(this, "测试", "caption", MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1));
            */
            //mbf.ShowDialog();

        }

        private void uc_pacc_Load(object sender, EventArgs e)
        {

        }
    }
}
