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
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Configuration;

namespace ALS
{
    public partial class frmMain : Form
    {
        //------------------------------------------
        //             各子窗体定义                |
        //------------------------------------------  
        FormOperation.ucPipeLine pipeLine;
        FormOperation.ucAutoFlush M_uc_AutoFlush;
        FormOperation.ucSelectFlush M_uc_selFlush;
        FormSet.ucSetFlow M_uc_SetFlow;                         //设置流量窗体        
        FormSet.ucSetSyringe M_uc_SetSyringe;                   //设置肝素泵窗体    
        FormOperation.ucMethod M_uc_Method;                     //治疗方法选择界面        
        FormOperation.ucTreat M_uc_Therapy;                     //治疗界面       
        FormOperation.ucRecycle M_uc_Recycle;                   //回收界面       
        FormSet.ucSetOther M_uc_OtherSet;                       //其他设置界面        
        FormSet.ucSetSum M_uc_Sum;                              //累计值界面       
        //FormSet.ucSetTemperature M_uc_SetTemprature;            //加温器、夹管阀        
        FormSet.ucSetLiquidSurface M_uc_SetLiquidSurface;
        frmWarn M_frmWarn = new frmWarn();
        frmExit m_frmExit = new frmExit();
        //System.Timers.Timer M_timer_Treat = new System.Timers.Timer();
        BackgroundWorker M_bwExit = new BackgroundWorker();
        BackgroundWorker M_bwStartPump = new BackgroundWorker();
        BackgroundWorker M_bwStartTreat = new BackgroundWorker();
        BackgroundWorker M_bwStopTreat = new BackgroundWorker();
        BackgroundWorker M_bwReleaseWarn = new BackgroundWorker();

        //------------------------------------------
        //             串口相关变量                |
        //------------------------------------------

        private SerialPort port_main = new SerialPort();
        private SerialPort port_data = new SerialPort();
        private SerialPort port_hpump = new SerialPort();
        private SerialPort port_ppump = new SerialPort();
        bool M_Closing_hpump = false;
        bool M_Listening_hpump = false;
        bool M_Closing_ppump = false;
        bool M_Listening_ppump = false;
        bool M_Closing_main = false;
        bool M_Listening_main = false;
        bool M_Closing_data = false;
        bool M_Listening_data = false;

        //Cls.ReadMainComm.CommReader M_portMainReader; 
        StringBuilder M_strb_ppump = new StringBuilder();
        StringBuilder M_strb_hpump = new StringBuilder();
        StringBuilder M_strb_main = new StringBuilder();
        List<byte> M_buffer_main = new List<byte>();
        List<byte> M_buffer_hpump = new List<byte>();
        List<byte> M_buffer_ppump = new List<byte>();
        List<byte> M_buffer_data = new List<byte>();

        int buffcount;
        bool M_SendSuccess = false;//命令是否发送成功
        bool M_SendSuccessPump = false;
        uint crc;

        //是否启动
        bool M_isStart = false;

        //报警值模型
        Cls.Model_WarnValue M_ModelWarn = new Cls.Model_WarnValue();
        //实时值模型
        Cls.Model_Value M_ModelValue = new Cls.Model_Value();
        //设置值模型
        Cls.Model_Set M_ModelSetRun = new Cls.Model_Set();
        //累计值模型
        Cls.Model_Total M_ModelTotal = new Cls.Model_Total();
        //需要发送命令读取的数据
        List<Cls.Model_SendCMD> lstByte = new List<Cls.Model_SendCMD>();

        //------------------------------------------
        //                 治疗相关                |
        //------------------------------------------
        //是否已经选择预冲方式
        int M_SelFlushType = 0;
        //是否正进行治疗
        bool M_isTreat = false;
        //是否在引血阶段
        bool M_isFlowBlood = false;
        //管路是否安装完成
        bool M_bl_isFinishPipeline = false;
        //是否完成预冲
        bool M_bl_isFinishFlush = false;
        //是否完成治疗
        bool M_bl_isFinishTreat = false;
        //是否完成回收
        bool M_bl_isFinishRecycle = false;
        //治疗时间累积
        int M_int_TreatCount = 0;
        //是否打开漏血报警 
        bool m_isOpenBloodleak = false;
        //是否打开气泡报警123
        bool m_isOpenBubble1 = false;
        bool m_isOpenBubble2 = false;
        bool m_isOpenBubble3 = false;
        //改变正在治疗背景色
        bool M_bl_changecolor = false;
        //选择治疗方法(模式)
        string M_str_CurrentConfig = string.Empty; 
        //治疗计时
        int m_startTime;
        int m_endTime;        
        int m_voidspan = 500;
        //保存数据标志量
        int m_circleNum = 0;
        //------------------------------------------
        //              预冲相关                   |
        //------------------------------------------ 
        Cls.Model_State M_PumpState = new Cls.Model_State();
        bool M_isFlush = false;
        //------------------------------------------
        //              Splash窗口                 |
        //------------------------------------------
        bool M_isError = false;
        List<Cls.utils.sysStartLog> M_lst_startLog = new List<Cls.utils.sysStartLog>();
        //------------------------------------------
        //              回收界面变量               |
        //------------------------------------------
        bool isRunBP = false;
        bool isRunRP = false;
        bool isRunFP = false;
        //------------------------------------------
        //               警报与报知                |
        //------------------------------------------
        //警报的动作任务
        private Task m_taskWarnActions;
        //警报编码
        private string m_warnCode = string.Empty;
        //是否存在报警
        private bool M_exsitsWarn = false;
        //是否存在报知
        private bool M_exsitsTip = false;
        //预载数据库报警编码与内容
        List<Cls.Model_ShowWarn> m_lstShowWarn;
        //累计值达到 标志
        bool m_isUptoBP, m_isUptoDP, m_isUptoFP, m_isUptoRP, m_isUptoTime, m_isUptoSP;
        //报警是否解除标志
        bool m_isReleaseWarn = true;
        //------------------------------------------
        //               秤标定参数                |
        //------------------------------------------
        int weigh1_code;
        int weigh2_code;
        int weigh3_code;
        int weigh1_0kgcode;
        int weigh2_0kgcode;
        int weigh3_0kgcode;
        double weigh1_resolution;
        double weigh2_resolution;
        double weigh3_resolution;
        double weigh1_startvalue;
        double weigh2_startvalue;
        double weigh3_startvalue;
        public frmMain()
        {
            this.Hide();
            Thread splashthread = new Thread(new ThreadStart(Cls.SplashScreen.ShowSplashScreen));
            splashthread.IsBackground = true;
            splashthread.Start();
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //启动日志文件
            string sysStartLog = AppDomain.CurrentDomain.BaseDirectory + "sysStartLog.txt";
            if (!File.Exists(sysStartLog))
            {
                FileStream fs = new FileStream(sysStartLog, FileMode.Create);
                fs.Flush();
                fs.Close();
            }
            string sysRunLog = AppDomain.CurrentDomain.BaseDirectory + "\\Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Log"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Log");
            }
            if (!File.Exists(sysRunLog))
            {
                FileStream fs = new FileStream(sysRunLog, FileMode.Create);
                fs.Flush();
                fs.Close();
            }

            //读取当前治疗方法           
            M_str_CurrentConfig = Cls.RWconfig.GetAppSettings("CurrentMethod");
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
                M_str_CurrentConfig = "PEConfig";
            ShowMethodName(M_str_CurrentConfig);
            //添加预发送命令
            //AddSendCmds();
            //获取报警门限值
            M_ModelWarn = Cls.utils.GetModelWarn(M_str_CurrentConfig);
            //获取设置值
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
            //启动Splash窗体
            Cls.SplashScreen.UdpateStatusText("初始化 人工肝支持系统......");
            Cls.utils.sysStartLog slog = new Cls.utils.sysStartLog();
            slog.InfoColor = Color.Black;
            slog.StartInfo = "初始化通讯端口\r\n";
            slog.StartTime = DateTime.Now;
            M_lst_startLog.Add(slog);

            //主控COM1    波特率19200 数据位8 停止位1 偶校验
            //注射泵COM2  波特率19200 数据位8 停止位1 无校验
            //蠕动COM3    波特率1200 数据位8 停止位1 偶校验
            //称重COM4    波特率9600 数据位8 停止位1 无校验
            //温控COM5    波特率9600 数据位8 停止位1 无校验

            //初始化串口1 串口设置：  COM1(暂定) 波特率19200 数据位8位 停止位1位 偶校验
            Thread.Sleep(300);
            InitComm(this.port_main, "COM1", 19200, 8, StopBits.One, Parity.Even, "主控制板");
            port_main.DataReceived += port_main_DataReceived;
            //初始化注射泵串口  COM2 波特率19200 数据位8位 停止位1位 无奇偶校验
            Thread.Sleep(300);
            InitComm(this.port_hpump, "COM2", 19200, 8, StopBits.One, Parity.None, "肝素泵");
            port_hpump.DataReceived += port_hpump_DataReceived;
            Thread.Sleep(300);
            //初始化蠕动泵串口 COM3 波特率1200 数据位8位 停止位1位 偶校验
            InitComm(this.port_ppump, "COM3", 1200, 8, StopBits.One, Parity.Even, "蠕动泵");
            //port_ppump.DataReceived += new SerialDataReceivedEventHandler(port_ppump_DataReceived);
            Thread.Sleep(300);
            InitComm(this.port_data, "COM4", 19200, 8, StopBits.One, Parity.Even, "数据端口");
            port_data.DataReceived += port_data_DataReceived;
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("初始化设备状态！");
            InitSystem();
            //---------------------------------------------------------------------------------------
            //M_portMainReader = new Cls.ReadMainComm.CommReader(port_main, 100);
            //M_portMainReader.Handlers += new Cls.ReadMainComm.CommReader.HandleCommData(portMainReader_Handlers);
            //M_portMainReader.Start();
            //---------------------------------------------------------------------------------------
            //自检线程
            //Thread.Sleep(500);
            //Thread chec = new Thread(new ThreadStart(CheckStartUP));
            //chec.Priority = ThreadPriority.Normal;
            //chec.IsBackground = true;
            //chec.Start();
            //chec.Join(); 
            //读取数据库，预载警报信息及命令
            Cls.SplashScreen.UdpateStatusText("连接数据库！");
            LoadShowWarn();
            //读取称重参数
            LoadWeighPara();
            Thread.Sleep(300);
            if (!M_isError)
            {
                this.Show();
                Cls.SplashScreen.CloseSplashScreen();
                this.Activate();
            }
            else
            {
                Cls.SplashScreen.SetTopmost(false);
                //启动错误提示框
                Cls.SplashDialog sd = new Cls.SplashDialog();
                sd.M_lst_StartLog = M_lst_startLog;
                sd.ShowDialog();
                Application.ExitThread();
                Application.Exit();
            }
            initBackGroundWorker();
            //初始化Timer
            InitTimer();
            //初始化警报窗体
            //M_frmWarn.Visible = false;
            M_frmWarn.btnMuteClick += new frmWarn.delbtnMute(M_frmWarn_btnMuteClick);
            M_frmWarn.btnReleaseClick += new frmWarn.delBtnRelease(M_frmWarn_btnReleaseClick);

            this.MaximizedBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
        }



        void InitSystem()
        {
            SendOrder(this.port_main, Cls.Comm_Main.CmdAlarmLamp.GreenAlways);
            Thread.Sleep(200);
            SendOrder(this.port_main, Cls.Comm_Main.LiquidLevel.closeLiquidCheck);
            Thread.Sleep(200);
            SendOrder(this.port_main, Cls.Comm_Main.CmdBubble.CloseBubble1);
            Thread.Sleep(200);
            SendOrder(this.port_main, Cls.Comm_Main.CmdBubble.CloseBubble2);
            Thread.Sleep(200);
            SendOrder(this.port_main, Cls.Comm_Main.CmdBubble.CloseBubble3);
            Thread.Sleep(200);
        }

        void LoadWeighPara()
        {
            weigh1_0kgcode = Convert.ToInt32(Cls.RWconfig.GetAppSettings("1_0kgcode"));
            weigh2_0kgcode = Convert.ToInt32(Cls.RWconfig.GetAppSettings("2_0kgcode"));
            weigh3_0kgcode = Convert.ToInt32(Cls.RWconfig.GetAppSettings("3_0kgcode"));
            weigh1_resolution = Convert.ToDouble(Cls.RWconfig.GetAppSettings("weigh1_resolution"));
            weigh2_resolution = Convert.ToDouble(Cls.RWconfig.GetAppSettings("weigh2_resolution"));
            weigh3_resolution = Convert.ToDouble(Cls.RWconfig.GetAppSettings("weigh3_resolution"));
        }

        private void LoadShowWarn()
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
                Cls.SplashScreen.UdpateStatusTextWithStatus("预载数据成功！", Cls.TypeOfMessage.Success);
            }
            catch (Exception ee)
            {
                M_isError = true;
                Cls.SplashScreen.UdpateStatusTextWithStatus("预载数据库失败！\r\n" + ee.Message, Cls.TypeOfMessage.Error);
                Cls.utils.sysStartLog slog = new Cls.utils.sysStartLog();
                slog.InfoColor = Color.Red;
                slog.StartInfo = "初始化数据库失败!\r\n" + ee.Message;
                slog.StartTime = DateTime.Now;
                M_lst_startLog.Add(slog);
                return;
            }
        }


        /// <summary>
        /// 任务：报警监测与响应
        /// </summary>
        /// <param name="o">传递报警代码</param>
        private void ShowWarn(string warnCode)
        {
            //解除警报标志
            m_isReleaseWarn = false;
            //如果m_bwStartTreat 和 m_bwStartPump 正在执行，则先Cancel 
            if (!M_exsitsTip)
            {
                //停止引血timer
                if (timerStartTreat.Enabled)
                    timerStartTreat.Enabled = false;
                if (M_bwStartPump.IsBusy)
                    M_bwStartPump.CancelAsync();
                if (M_bwStartTreat.IsBusy)
                    M_bwStartTreat.CancelAsync();
            }

            //List查询警报代码，获取内容
            int index = m_lstShowWarn.FindIndex(m => m.mwarncode.code == warnCode);
            List<Cls.Model_SendCMD> lstWarnActions = m_lstShowWarn[index].lstSendcmds;
            //创建发送命令子任务 
            m_taskWarnActions = new Task(RunActions, lstWarnActions, TaskCreationOptions.LongRunning);
            m_taskWarnActions.Start();
            m_taskWarnActions.Wait();

            BeginInvoke(new Action(() =>
            {
                //如果存在报警,弹出警报窗体               
                M_frmWarn.lblTitle.Text = m_lstShowWarn[index].mwarncode.code + ":" + m_lstShowWarn[index].mwarncode.content;
                M_frmWarn.rtBox.Text = "原因：\r\n" + m_lstShowWarn[index].mwarncode.reason + "\r\n处理:\r\n" + m_lstShowWarn[index].mwarncode.deal;
                M_frmWarn.ShowDialog();

                #region 如果是预冲窗体
                if (M_uc_AutoFlush != null)
                {
                    if (M_uc_AutoFlush.m_isFlush)
                    {
                        M_uc_AutoFlush.M_pauseFlush = false;
                        M_uc_AutoFlush.btnContinue_Click(M_uc_AutoFlush.btnContinue, new EventArgs());
                    }
                    if (M_uc_AutoFlush.m_isAddFlush)
                    {
                        M_uc_AutoFlush.m_isAddFlush = true;
                        M_uc_AutoFlush.btnAddFlush_Click(M_uc_AutoFlush.btnAddFlush, new EventArgs());
                    }
                }

                #endregion

                #region 如果液面窗体
                if (M_uc_SetLiquidSurface != null)
                {
                    M_uc_SetLiquidSurface.chkDownC1.Text = "下降";
                    M_uc_SetLiquidSurface.chkDownC1.Image = Properties.Resources.down_64;
                    M_uc_SetLiquidSurface.chkUpC1.Text = "上升";
                    M_uc_SetLiquidSurface.chkUpC1.Image = Properties.Resources.up_64;

                    M_uc_SetLiquidSurface.chkDownC2.Text = "下降";
                    M_uc_SetLiquidSurface.chkDownC2.Image = Properties.Resources.down_64;
                    M_uc_SetLiquidSurface.chkUpC2.Text = "上升";
                    M_uc_SetLiquidSurface.chkUpC2.Image = Properties.Resources.up_64;

                    M_uc_SetLiquidSurface.chkDownM1.Text = "下降";
                    M_uc_SetLiquidSurface.chkDownM1.Image = Properties.Resources.down_64;
                    M_uc_SetLiquidSurface.chkUpM1.Text = "上升";
                    M_uc_SetLiquidSurface.chkUpM1.Image = Properties.Resources.up_64;
                }

                #endregion

            }));

        }

        private void RunActions(object o)
        {
            List<Cls.Model_SendCMD> lstscmd = o as List<Cls.Model_SendCMD>;
            foreach (var v in lstscmd)
            {
                SendOrder(v.SP, v.CMD);
            }
        }


        void ShowMethodName(string methodConfig)
        {
            switch (methodConfig)
            {
                case "PEConfig":
                    this.lblMethod.Text = "PE";
                    break;
                case "CHDFConfig":
                    this.lblMethod.Text = "CHDF";
                    break;
                case "PDFConfig":
                    this.lblMethod.Text = "PDF";
                    break;
                case "PERTConfig":
                    this.lblMethod.Text = "PERT";
                    break;
                case "PPConfig":
                    this.lblMethod.Text = "PP";
                    break;
                case "Li-ALSConfig":
                    this.lblMethod.Text = "Li-ALS";
                    break;
            }
        }

        void M_frmWarn_btnMuteClick(object sender, EventArgs e)
        {
            //关闭声光指示
            SendOrder(port_main, Cls.Comm_Main.CmdAlarm.AllVoiceClose);
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose);
        }


        void M_frmWarn_btnReleaseClick(object sender, EventArgs e)
        {
            //threadReleaseWarn();
            //this.M_frmWarn.btnRelease.Enabled = false;
            if (!M_bwReleaseWarn.IsBusy)
                M_bwReleaseWarn.RunWorkerAsync();

            #region 如果是预冲窗体则暂停
            //if (M_uc_AutoFlush != null)
            //{
            //    //解除报警
            //    if (M_uc_AutoFlush.m_isFlush)
            //    {
            //        M_uc_AutoFlush.M_pauseFlush = true;
            //        M_uc_AutoFlush.btnContinue_Click(M_uc_AutoFlush.btnContinue, new EventArgs());
            //    }
            //}
            #endregion

            //#region 如果是治疗窗体
            //if (M_uc_Therapy != null & M_isTreat)
            //{
            //    M_isTreat = false;
            //    this.btnStart.Enabled = true;
            //}
            //#endregion

            //解除警报  
            //M_frmWarn.Visible = false;
        }

        void initBackGroundWorker()
        {
            M_bwExit.WorkerReportsProgress = true;
            M_bwExit.WorkerSupportsCancellation = false;
            M_bwExit.DoWork += new DoWorkEventHandler(M_bwExit_DoWork);
            M_bwExit.ProgressChanged += new ProgressChangedEventHandler(M_bwExit_ProgressChanged);
            M_bwExit.RunWorkerCompleted += new RunWorkerCompletedEventHandler(M_bwExit_RunWorkerCompleted);

            M_bwStartTreat.WorkerReportsProgress = true;
            M_bwStartTreat.WorkerSupportsCancellation = false;
            M_bwStartTreat.DoWork += new DoWorkEventHandler(M_bwStartTreat_DoWork);
            M_bwStartTreat.ProgressChanged += new ProgressChangedEventHandler(M_bwStartTreat_ProgressChanged);
            M_bwStartTreat.RunWorkerCompleted += new RunWorkerCompletedEventHandler(M_bwStartTreat_RunWorkerCompleted);
            M_bwStartTreat.WorkerSupportsCancellation = true;

            M_bwStartPump.WorkerReportsProgress = true;
            M_bwStartPump.WorkerSupportsCancellation = false;
            M_bwStartPump.DoWork += new DoWorkEventHandler(M_bwStartPump_DoWork);
            M_bwStartPump.RunWorkerCompleted += new RunWorkerCompletedEventHandler(M_bwStartPump_RunWorkerCompleted);
            M_bwStartPump.ProgressChanged += new ProgressChangedEventHandler(M_bwStartPump_ProgressChanged);
            M_bwStartPump.WorkerSupportsCancellation = true;

            M_bwStopTreat.WorkerReportsProgress = true;
            M_bwStopTreat.WorkerSupportsCancellation = false;
            M_bwStopTreat.DoWork += new DoWorkEventHandler(M_bwStopTreat_DoWork);
            M_bwStopTreat.RunWorkerCompleted += new RunWorkerCompletedEventHandler(M_bwStopTreat_RunWorkerCompleted);
            M_bwStopTreat.ProgressChanged += new ProgressChangedEventHandler(M_bwStopTreat_ProgressChanged);

            M_bwReleaseWarn.WorkerReportsProgress = true;
            M_bwReleaseWarn.WorkerSupportsCancellation = false;
            M_bwReleaseWarn.DoWork += new DoWorkEventHandler(M_bwReleaseWarn_DoWork);
            M_bwReleaseWarn.RunWorkerCompleted += new RunWorkerCompletedEventHandler(M_bwReleaseWarn_RunWorkerCompleted);
            M_bwReleaseWarn.ProgressChanged += new ProgressChangedEventHandler(M_bwReleaseWarn_ProgressChanged);
        }

        void M_bwReleaseWarn_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
            this.progressBar1.Value = e.ProgressPercentage;
        }

        void M_bwReleaseWarn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            this.progressBar1.Value = 0;
            //this.M_frmWarn.Visible = false;
            m_isReleaseWarn = true;
        }

        void M_bwReleaseWarn_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose);
            bw.ReportProgress(5);
            SendOrder(port_main, Cls.Comm_Main.CmdAlarm.AllVoiceClose);
            bw.ReportProgress(10);
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.GreenAlways);
            bw.ReportProgress(15);
            //如果是报知则不需要恢复状态
            if (!M_exsitsTip)
            {
                //如果正在治疗 或 正在预冲
                if (M_isTreat || M_isFlush)
                {
                    //开启加热
                    SendOrder(port_main, Cls.Comm_Main.CmdTemperature.StartHT(Convert.ToByte(M_ModelSetRun.TargetTemperature)));
                    bw.ReportProgress(20);
                    //如果是治疗，解除报警时打开肝素泵，打开加热器,预冲时只打开加热器，在预冲界面继续预冲
                    if (M_isTreat)
                    {
                        SendOrder(port_hpump, Cls.Comm_SyringePump.Start(M_ModelSetRun.SpeedSP, 200));
                        //气泡检测开
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble1);
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble2);
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble3);
                        //治疗时才恢复泵运转
                        if (M_ModelSetRun.BPValid)
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection));
                        }
                        bw.ReportProgress(25);
                        if (M_ModelSetRun.FPValid)
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelSetRun.SpeedFP, true, M_ModelSetRun.FPDirection));
                        }
                        bw.ReportProgress(30);
                        if (M_ModelSetRun.DPValid)
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelSetRun.SpeedDP, true, M_ModelSetRun.DPDirection));
                        }
                        bw.ReportProgress(35);
                        if (M_ModelSetRun.RPValid)
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection));
                        }
                        bw.ReportProgress(40);
                        if (M_ModelSetRun.FP2Valid)
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelSetRun.SpeedFP2, true, M_ModelSetRun.FP2Direction));
                        }
                        bw.ReportProgress(50);
                        if (M_ModelSetRun.CPValid)
                        {
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelSetRun.SpeedCP, true, M_ModelSetRun.CPDirection));
                        }
                        ////夹管阀状态  true：夹管 / false：松管  
                        // V1肯定松开 123松管 4夹管
                        switch (M_str_CurrentConfig)
                        {
                            case "PEConfig":
                            case "CHDFConfig":
                                SendOrder(port_main, Cls.Comm_Main.CmdValve.LoosenV1);
                                SendOrder(port_main, Cls.Comm_Main.CmdValve.LoosenV2);
                                SendOrder(port_main, Cls.Comm_Main.CmdValve.LoosenV3);
                                SendOrder(port_main, Cls.Comm_Main.CmdValve.ClampV4);
                                break;
                        }
                        bw.ReportProgress(80);
                    }
                }
            }
            //重置报知标记
            M_exsitsTip = false;
            bw.ReportProgress(100);
            //throw new NotImplementedException();
        }

        void M_bwStopTreat_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            //throw new NotImplementedException();
        }

        void M_bwStopTreat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.Enabled = true;
            this.toolStripControl.Enabled = true;
            this.btnStart.Enabled = true;
            this.tsbtnPipeline.Enabled = true;
            this.tsbtnRecycle.Enabled = true;
            this.tsbtnPreFlush.Enabled = true;
            this.tsbtnSetFlow.Enabled = true;
            this.tsbtnMethod.Enabled = true;
            this.btnStart.Image = Properties.Resources.start;
            this.btnStart.Text = "开始";
            this.btnStart.ForeColor = Color.Green;
            this.lblRunning.Visible = false;
            this.progressBar1.Value = 0;
            this.lblBloodSpeed.Text = "000";
            M_bl_isFinishTreat = true;
            //其他界面按钮状态改变 
            SetButtonState(false);
            //throw new NotImplementedException();
        }

        void M_bwStopTreat_DoWork(object sender, DoWorkEventArgs e)
        {
            M_isTreat = false;
            //M_timer_Treat.Enabled = false;

            BackgroundWorker bw = sender as BackgroundWorker;
            //各泵停止
            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
            SetAllPumpState(null);
            bw.ReportProgress(20);
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.closeLiquidCheck);
            bw.ReportProgress(30);
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose);
            bw.ReportProgress(40);
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopDown);
            bw.ReportProgress(50);
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopUp);
            bw.ReportProgress(60);
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopUp);
            bw.ReportProgress(70);
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopDown);
            bw.ReportProgress(80);
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopDown);
            bw.ReportProgress(90);
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopUp);
            bw.ReportProgress(100);
            //throw new NotImplementedException();
        }

        void M_bwStartTreat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            M_bl_isFinishTreat = false;
            M_isFlowBlood = true;
            timerStartTreat.Enabled = true;
            timerStartTreat.Start();

            //this.Enabled = true;           
            this.toolStripControl.Enabled = true;
            this.tsbtnMethod.Enabled = false;
            this.tsbtnPipeline.Enabled = false;
            this.tsbtnRecycle.Enabled = false;
            this.tsbtnPreFlush.Enabled = false;
            this.tsbtnSetFlow.Enabled = true;
            this.btnStart.Image = Properties.Resources.stop;
            this.btnStart.Text = "停止";
            this.btnStart.Enabled = true;
            this.btnStart.ForeColor = Color.FromArgb(218, 18, 18);
            this.lblRunning.Visible = true;
            this.progressBar1.Value = 0;
            //this.lblBloodSpeed.Text = M_ModelSetRun.SpeedBP.ToString("f0");

            //其他界面按钮状态改变 
            if (M_uc_SetFlow != null)
            {
                M_uc_SetFlow.btnRun1.Text = M_uc_SetFlow.btnRun2.Text = M_uc_SetFlow.btnRun3.Text = M_uc_SetFlow.btnRun4.Text = M_uc_SetFlow.btnRun5.Text = M_uc_SetFlow.btnRun6.Text = "停止";
                M_uc_SetFlow.btnRun1.Image = M_uc_SetFlow.btnRun2.Image = M_uc_SetFlow.btnRun3.Image = M_uc_SetFlow.btnRun4.Image = M_uc_SetFlow.btnRun5.Image = M_uc_SetFlow.btnRun6.Image = Properties.Resources.spstop;
                M_uc_SetFlow.btnRun1.ForeColor = M_uc_SetFlow.btnRun2.ForeColor = M_uc_SetFlow.btnRun3.ForeColor = M_uc_SetFlow.btnRun4.ForeColor = M_uc_SetFlow.btnRun5.ForeColor = M_uc_SetFlow.btnRun6.ForeColor = Color.FromArgb(218, 18, 18);
                M_uc_SetFlow.btnRun1.Enabled = M_uc_SetFlow.btnRun2.Enabled = M_uc_SetFlow.btnRun3.Enabled = M_uc_SetFlow.btnRun4.Enabled = M_uc_SetFlow.btnRun5.Enabled = M_uc_SetFlow.btnRun6.Enabled = M_uc_SetFlow.btnAllRun.Enabled = M_uc_SetFlow.btnAllRun.Enabled = M_uc_SetFlow.btnAllStop.Enabled = true;
            }

            //if (M_uc_ManualFlush != null)
            //{
            //    M_uc_ManualFlush.btnRun1.Text = M_uc_ManualFlush.btnRun2.Text = M_uc_ManualFlush.btnRun3.Text = M_uc_ManualFlush.btnRun4.Text = M_uc_ManualFlush.btnRun5.Text = M_uc_ManualFlush.btnRun6.Text = "停止";
            //    M_uc_ManualFlush.btnRun1.Image = M_uc_ManualFlush.btnRun2.Image = M_uc_ManualFlush.btnRun3.Image = M_uc_ManualFlush.btnRun4.Image = M_uc_ManualFlush.btnRun5.Image = M_uc_ManualFlush.btnRun6.Image = Properties.Resources.spstop;
            //    M_uc_ManualFlush.btnRun1.ForeColor = M_uc_ManualFlush.btnRun2.ForeColor = M_uc_ManualFlush.btnRun3.ForeColor = M_uc_ManualFlush.btnRun4.ForeColor = M_uc_ManualFlush.btnRun5.ForeColor = M_uc_ManualFlush.btnRun6.ForeColor = Color.FromArgb(218, 18, 18);
            //    M_uc_ManualFlush.btnRun1.Enabled = M_uc_ManualFlush.btnRun2.Enabled = M_uc_ManualFlush.btnRun3.Enabled = M_uc_ManualFlush.btnRun4.Enabled = M_uc_ManualFlush.btnRun5.Enabled = M_uc_ManualFlush.btnRun6.Enabled = M_uc_ManualFlush.btnAllRun.Enabled = M_uc_ManualFlush.btnAllStop.Enabled = M_uc_ManualFlush.btnConfirmM.Enabled = true;
            //}
        }

        void M_bwStartTreat_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        void M_bwStartTreat_DoWork(object sender, DoWorkEventArgs e)
        {
            //保存秤1 2 3的初始值
            weigh1_startvalue = M_ModelValue.M_flt_Weigh1;
            weigh2_startvalue = M_ModelValue.M_flt_Weigh2;
            weigh3_startvalue = M_ModelValue.M_flt_Weigh3;

            BackgroundWorker bw = sender as BackgroundWorker;
            //M_isTreat = true;
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose);
            bw.ReportProgress(20);
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.GreenAlways);
            bw.ReportProgress(30);
            //夹管阀状态初始化为治疗模式最后一步预冲步骤中的夹管阀状态
            switch (M_str_CurrentConfig)
            {
                case "PEConfig":
                case "CHDFConfig":
                    SendOrder(port_main, Cls.Comm_Main.CmdValve.LoosenV1);
                    SendOrder(port_main, Cls.Comm_Main.CmdValve.LoosenV2);
                    SendOrder(port_main, Cls.Comm_Main.CmdValve.LoosenV3);
                    SendOrder(port_main, Cls.Comm_Main.CmdValve.ClampV4);
                    break;
            }
            //气泡检测开
            SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble1);
            bw.ReportProgress(80);
            SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble2);
            bw.ReportProgress(90);
            SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble3);
            //液位报警开
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.openLiquidCheck);
            bw.ReportProgress(100);
        }

        /// <summary>
        /// 设置全部泵状态
        /// </summary>
        /// <param name="_modelSetRun"></param>
        void SetAllPumpState(Cls.Model_Set _modelSetRun)
        {
            //M_PumpState.VState = new bool[] { false, false, false, false, false, false };
            if (_modelSetRun != null)
            {
                Cls.utils.SetSinglePumpState(M_PumpState, 1, _modelSetRun.SpeedBP, _modelSetRun.BPValid, _modelSetRun.BPDirection);
                Cls.utils.SetSinglePumpState(M_PumpState, 2, _modelSetRun.SpeedFP, _modelSetRun.FPValid, _modelSetRun.FPDirection);
                Cls.utils.SetSinglePumpState(M_PumpState, 3, _modelSetRun.SpeedDP, _modelSetRun.DPValid, _modelSetRun.DPDirection);
                Cls.utils.SetSinglePumpState(M_PumpState, 4, _modelSetRun.SpeedRP, _modelSetRun.RPValid, _modelSetRun.RPDirection);
                Cls.utils.SetSinglePumpState(M_PumpState, 5, _modelSetRun.SpeedFP2, _modelSetRun.FP2Valid, _modelSetRun.FP2Direction);
                Cls.utils.SetSinglePumpState(M_PumpState, 6, _modelSetRun.SpeedCP, _modelSetRun.CPValid, _modelSetRun.CPDirection);
                M_PumpState.SPSpeed = Convert.ToDouble(Cls.RWconfig.GetAppSettings("SP_Speed"));
            }
            else
            {
                M_PumpState.BPState.Runing = false;
                M_PumpState.FPState.Runing = false;
                M_PumpState.DPState.Runing = false;
                M_PumpState.RPState.Runing = false;
                M_PumpState.FP2State.Runing = false;
                M_PumpState.CPState.Runing = false;
                M_PumpState.SPSpeed = 0;
            }
        }


        void M_bwStartPump_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }


        private void SetButtonState(bool run)
        {
            if (run)
            {
                if (M_uc_SetFlow != null)
                {
                    M_uc_SetFlow.btnAllRun.Enabled = M_uc_SetFlow.btnAllStop.Enabled = true;
                    if (M_ModelSetRun.BPValid)
                    {
                        M_uc_SetFlow.btnRun1.Text = "停止";
                        M_uc_SetFlow.btnRun1.Image = Properties.Resources.spstop;
                        M_uc_SetFlow.btnRun1.ForeColor = Color.Red;
                        M_uc_SetFlow.btnRun1.Enabled = true;
                    }
                    else
                        M_uc_SetFlow.btnRun1.Enabled = true;

                    if (M_ModelSetRun.FPValid)
                    {
                        M_uc_SetFlow.btnRun2.Text = "停止";
                        M_uc_SetFlow.btnRun2.Image = Properties.Resources.spstop;
                        M_uc_SetFlow.btnRun2.ForeColor = Color.Red;
                        M_uc_SetFlow.btnRun2.Enabled = true;
                    }
                    else
                        M_uc_SetFlow.btnRun2.Enabled = true;

                    if (M_ModelSetRun.DPValid)
                    {
                        M_uc_SetFlow.btnRun3.Text = "停止";
                        M_uc_SetFlow.btnRun3.Image = Properties.Resources.spstop;
                        M_uc_SetFlow.btnRun3.ForeColor = Color.Red;
                        M_uc_SetFlow.btnRun3.Enabled = true;
                    }
                    else
                        M_uc_SetFlow.btnRun3.Enabled = true;

                    if (M_ModelSetRun.RPValid)
                    {
                        M_uc_SetFlow.btnRun4.Text = "停止";
                        M_uc_SetFlow.btnRun4.Image = Properties.Resources.spstop;
                        M_uc_SetFlow.btnRun4.ForeColor = Color.Red;
                        M_uc_SetFlow.btnRun4.Enabled = true;
                    }
                    else
                        M_uc_SetFlow.btnRun4.Enabled = true;

                    if (M_ModelSetRun.FP2Valid)
                    {
                        M_uc_SetFlow.btnRun5.Text = "停止";
                        M_uc_SetFlow.btnRun5.Image = Properties.Resources.spstop;
                        M_uc_SetFlow.btnRun5.ForeColor = Color.Red;
                        M_uc_SetFlow.btnRun5.Enabled = true;
                    }
                    else
                        M_uc_SetFlow.btnRun5.Enabled = true;

                    if (M_ModelSetRun.CPValid)
                    {
                        M_uc_SetFlow.btnRun6.Text = "停止";
                        M_uc_SetFlow.btnRun6.Image = Properties.Resources.spstop;
                        M_uc_SetFlow.btnRun6.ForeColor = Color.Red;
                        M_uc_SetFlow.btnRun6.Enabled = true;
                    }
                    else
                        M_uc_SetFlow.btnRun6.Enabled = true;

                    //M_uc_SetFlow.btnRun1.Text = M_uc_SetFlow.btnRun2.Text = M_uc_SetFlow.btnRun3.Text = M_uc_SetFlow.btnRun4.Text = M_uc_SetFlow.btnRun5.Text = M_uc_SetFlow.btnRun6.Text = "停止";
                    //M_uc_SetFlow.btnRun1.Image = M_uc_SetFlow.btnRun2.Image = M_uc_SetFlow.btnRun3.Image = M_uc_SetFlow.btnRun4.Image = M_uc_SetFlow.btnRun5.Image = M_uc_SetFlow.btnRun6.Image = Properties.Resources.spstop;
                    //M_uc_SetFlow.btnRun1.ForeColor = M_uc_SetFlow.btnRun2.ForeColor = M_uc_SetFlow.btnRun3.ForeColor = M_uc_SetFlow.btnRun4.ForeColor = M_uc_SetFlow.btnRun5.ForeColor = M_uc_SetFlow.btnRun6.ForeColor = Color.Red;
                    //M_uc_SetFlow.btnRun1.Enabled = M_uc_SetFlow.btnRun2.Enabled = M_uc_SetFlow.btnRun3.Enabled = M_uc_SetFlow.btnRun4.Enabled = M_uc_SetFlow.btnRun5.Enabled = M_uc_SetFlow.btnRun6.Enabled = M_uc_SetFlow.btnAllRun.Enabled = M_uc_SetFlow.btnAllRun.Enabled = M_uc_SetFlow.btnAllStop.Enabled = false;
                }
            }
        }

        void M_bwStartPump_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Value = 0;
            //if (M_uc_SetFlow != null)
            //{
            //    M_uc_SetFlow.btnRun1.Text = M_uc_SetFlow.btnRun2.Text = M_uc_SetFlow.btnRun3.Text = M_uc_SetFlow.btnRun4.Text = M_uc_SetFlow.btnRun5.Text = M_uc_SetFlow.btnRun6.Text = "停止";
            //    M_uc_SetFlow.btnRun1.Image = M_uc_SetFlow.btnRun2.Image = M_uc_SetFlow.btnRun3.Image = M_uc_SetFlow.btnRun4.Image = M_uc_SetFlow.btnRun5.Image = M_uc_SetFlow.btnRun6.Image = Properties.Resources.spstop;
            //    M_uc_SetFlow.btnRun1.ForeColor = M_uc_SetFlow.btnRun2.ForeColor = M_uc_SetFlow.btnRun3.ForeColor = M_uc_SetFlow.btnRun4.ForeColor = M_uc_SetFlow.btnRun5.ForeColor = M_uc_SetFlow.btnRun6.ForeColor = Color.Red;
            //    M_uc_SetFlow.btnRun1.Enabled = M_uc_SetFlow.btnRun2.Enabled = M_uc_SetFlow.btnRun3.Enabled = M_uc_SetFlow.btnRun4.Enabled = M_uc_SetFlow.btnRun5.Enabled = M_uc_SetFlow.btnRun6.Enabled = M_uc_SetFlow.btnAllRun.Enabled =M_uc_SetFlow.btnAllRun.Enabled = M_uc_SetFlow.btnAllStop.Enabled = true;
            //} 
            //SetButtonState(true);
            //M_uc_SetFlow.btnRun1.Text = M_uc_SetFlow.btnRun2.Text = M_uc_SetFlow.btnRun3.Text = M_uc_SetFlow.btnRun4.Text = M_uc_SetFlow.btnRun5.Text = M_uc_SetFlow.btnRun6.Text = "停止";
            //M_uc_SetFlow.btnRun1.Image = M_uc_SetFlow.btnRun2.Image = M_uc_SetFlow.btnRun3.Image = M_uc_SetFlow.btnRun4.Image = M_uc_SetFlow.btnRun5.Image = M_uc_SetFlow.btnRun6.Image = Properties.Resources.spstop;
            //M_uc_SetFlow.btnRun1.ForeColor = M_uc_SetFlow.btnRun2.ForeColor = M_uc_SetFlow.btnRun3.ForeColor = M_uc_SetFlow.btnRun4.ForeColor = M_uc_SetFlow.btnRun5.ForeColor = M_uc_SetFlow.btnRun6.ForeColor = Color.Red;
            //M_uc_SetFlow.btnRun1.Enabled = M_uc_SetFlow.btnRun2.Enabled = M_uc_SetFlow.btnRun3.Enabled = M_uc_SetFlow.btnRun4.Enabled = M_uc_SetFlow.btnRun5.Enabled = M_uc_SetFlow.btnRun6.Enabled = M_uc_SetFlow.btnAllRun.Enabled = M_uc_SetFlow.btnAllRun.Enabled = M_uc_SetFlow.btnAllStop.Enabled = false;

        }

        void M_bwStartPump_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            //bool isTreat = Convert.ToBoolean(e.Argument);
            if (M_ModelSetRun.BPValid)
            {
                //if (isTreat)
                //    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection));
                //else
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection));
            }
            bw.ReportProgress(20);
            if (M_ModelSetRun.FPValid)
            {
                //if (isTreat)
                //    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelSetRun.SpeedFP, true, M_ModelSetRun.FPDirection));
                //else
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelSetRun.SpeedFP, true, M_ModelSetRun.FPDirection));
            }
            bw.ReportProgress(40);
            if (M_ModelSetRun.DPValid)
            {
                //if (isTreat)
                //    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelSetRun.SpeedDP, true, M_ModelSetRun.DPDirection));
                //else
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelSetRun.SpeedDP, true, M_ModelSetRun.DPDirection));
            }
            bw.ReportProgress(60);
            if (M_ModelSetRun.RPValid)
            {
                //if (isTreat)
                //    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection));
                //else
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection));
            }
            bw.ReportProgress(70);
            if (M_ModelSetRun.FP2Valid)
            {
                //if (isTreat)
                //    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelSetRun.SpeedFP2, true, M_ModelSetRun.FP2Direction));
                //else
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelSetRun.SpeedFP2, true, M_ModelSetRun.FP2Direction));
            }
            bw.ReportProgress(80);
            if (M_ModelSetRun.CPValid)
            {
                //if (isTreat)
                //    SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelSetRun.SpeedCP, true, M_ModelSetRun.CPDirection));
                //else
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelSetRun.SpeedCP, true, M_ModelSetRun.CPDirection));
            }
            bw.ReportProgress(90);
            //bw.CancelAsync();
            SetAllPumpState(M_ModelSetRun);
            SetButtonState(true);
            bw.ReportProgress(100);
        }

        void StopPump()
        {
            //M_isTreat = false;
            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
            SetAllPumpState(null);
            if (M_uc_SetFlow != null)
            {
                M_uc_SetFlow.btnRun1.Text = M_uc_SetFlow.btnRun2.Text = M_uc_SetFlow.btnRun3.Text = M_uc_SetFlow.btnRun4.Text = M_uc_SetFlow.btnRun5.Text = M_uc_SetFlow.btnRun6.Text = "运转";
                M_uc_SetFlow.btnRun1.Image = M_uc_SetFlow.btnRun2.Image = M_uc_SetFlow.btnRun3.Image = M_uc_SetFlow.btnRun4.Image = M_uc_SetFlow.btnRun5.Image = M_uc_SetFlow.btnRun6.Image = Properties.Resources.spstart;
                M_uc_SetFlow.btnRun1.ForeColor = M_uc_SetFlow.btnRun2.ForeColor = M_uc_SetFlow.btnRun3.ForeColor = M_uc_SetFlow.btnRun4.ForeColor = M_uc_SetFlow.btnRun5.ForeColor = M_uc_SetFlow.btnRun6.ForeColor = Color.FromArgb(15, 8, 100);
            }
            this.lblBloodSpeed.Text = "000";
        }

        void M_bwExit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            //if (e.Error != null)
            //    MessageBox.Show(e.Error.ToString());
            //if (DialogResult.OK == MessageBox.Show("提示", "退出成功,请关机!", MessageBoxButtons.OK, MessageBoxIcon.Information))
            //{
            Application.ExitThread();
            Application.Exit();
            //}
        }

        void M_bwExit_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            m_frmExit.pb.Value = e.ProgressPercentage;
            //throw new NotImplementedException(); 
        }

        void M_bwExit_DoWork(object sender, DoWorkEventArgs e)
        {
            M_isStart = false;
            //StopPump();
            BackgroundWorker bw = sender as BackgroundWorker;
            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
            bw.ReportProgress(5);
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.closeLiquidCheck);
            bw.ReportProgress(10);
            SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose);
            bw.ReportProgress(15);
            SendOrder(port_main, Cls.Comm_Main.CmdAlarm.AllVoiceClose);
            bw.ReportProgress(25);
            SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble1);
            bw.ReportProgress(35);
            SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble2);
            bw.ReportProgress(45);
            SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble3);
            bw.ReportProgress(50);
            SendOrder(port_main, Cls.Comm_Main.LiquidLevel.closeLiquidCheck);
            bw.ReportProgress(50);
            SendOrder(port_main, Cls.Comm_Main.CmdValve.ClampAllV);
            //SendOrder(port_main, Cls.Comm_Main.CmdAirPump.CloseA1_1);
            //SendOrder(port_main, Cls.Comm_Main.CmdAirPump.CloseA1_2);
            //SendOrder(port_main, Cls.Comm_Main.CmdAirPump.CloseA2_1);
            //SendOrder(port_main, Cls.Comm_Main.CmdAirPump.CloseA2_2);
            //SendOrder(port_main, Cls.Comm_Main.CmdAirPump.CloseA3_1);
            //SendOrder(port_main, Cls.Comm_Main.CmdAirPump.CloseA3_2);  
            bw.ReportProgress(60);
            //M_timer_Treat.Enabled = false;
            //M_timer_Treat.Stop();
            bw.ReportProgress(75);
            //停止注射泵
            SendOrder(port_hpump, Cls.Comm_SyringePump.Stop);
            bw.ReportProgress(80);
            if (port_ppump.IsOpen)
            {
                M_Closing_ppump = true;
                while (M_Listening_ppump) Application.DoEvents();
                port_ppump.Close();
            }
            bw.ReportProgress(85);
            if (port_data.IsOpen)
            {
                M_Closing_data = true;
                while (M_Listening_data) Application.DoEvents();
                port_data.Close();
            }
            bw.ReportProgress(90);
            if (port_hpump.IsOpen)
            {
                M_Closing_hpump = true;
                while (M_Listening_hpump) Application.DoEvents();
                port_hpump.Close();
            }
            bw.ReportProgress(95);

            if (port_main.IsOpen)
            {
                M_Closing_main = true;
                while (M_Listening_main) Application.DoEvents();
                port_main.Close();
            }

            bw.ReportProgress(100);
            //throw new NotImplementedException();
        }

        private void AddSendCmds()
        {
            //lstByte.Clear();

            //Cls.Model_SendCMD weigh1 = new Cls.Model_SendCMD(port_weigh, 4, Cls.Comm_Weigh.ReadValue(0x01));
            //lstByte.Add(weigh1);

            //Cls.Model_SendCMD weigh2 = new Cls.Model_SendCMD(port_weigh, 4, Cls.Comm_Weigh.ReadValue(0x02));
            //lstByte.Add(weigh2);

            //Cls.Model_SendCMD weigh3 = new Cls.Model_SendCMD(port_weigh, 4, Cls.Comm_Weigh.ReadValue(0x03));
            //lstByte.Add(weigh3);

            //Cls.Model_SendCMD temperature = new Cls.Model_SendCMD(port_temperature, 8, Cls.Comm_Temperature.Read_Value(0x0A));
            //lstByte.Add(temperature);

        }

        private void CheckStartUP()
        {
            //Thread.Sleep(500);
            //CheckBloodAndPressure();
            Thread.Sleep(500);
            CheckAlarmLamp();
            Thread.Sleep(500);
            OpenAD();
            Thread.Sleep(500);
            //CheckPPump();
            //Thread.Sleep(500);
            SendOrder(port_main, Cls.Comm_Main.startTransData);
        }

        void OpenAD()
        {
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Down))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A1-1通电正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("A1-1通电正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A1-1通电失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("A1-1通电失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(500);
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopDown))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A1-2通电正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("A1-2通电正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A1-2通电失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("A1-2通电失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(500);
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Down))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A2-1通电正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("A2-1通电正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A2-1通电失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("A2-1通电失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(500);
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopDown))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A2-2通电正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("A2-2通电正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A2-2通电失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("A2-2通电失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(500);
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Down))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A3-1通电正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("A3-1通电正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A3-1通电失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("A3-1通电失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(500);
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopDown))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A3-2通电正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("A3-2通电正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]A3-2通电失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("A3-2通电失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(500);

        }

        /// <summary>
        /// 检测蜂鸣器
        /// </summary>
        void CheckBuzzer()
        {
            //开启蜂鸣器 
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测蜂鸣器开启...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdAlarm.OpenVoice1))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蜂鸣器声音1测试:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("蜂鸣器声音1测试:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蜂鸣器开启:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("蜂鸣器开启:失败!", Color.Red));
                M_isError = true;
            }
            //关闭蜂鸣器  
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测蜂鸣器关闭...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdAlarm.CloseVoice1))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蜂鸣器关闭:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("蜂鸣器关闭:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蜂鸣器关闭:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("蜂鸣器关闭:失败!", Color.Red));
                M_isError = true;
            }
        }
        /// <summary>
        /// 检测注射泵
        /// </summary>
        void CheckPPump()
        {
            //检测注射泵
            //Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测注射泵...");
            //if (SendOrder(port_hpump, Cls.Comm_SyringePump.TestSN(0x0001)))
            //{
            //    Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]注射泵:正常!", Cls.TypeOfMessage.Success);
            //    M_lst_startLog.Add(GetLog("注射泵:正常!", Color.Green));
            //}
            //else
            //{
            //    Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]注射泵:错误!", Cls.TypeOfMessage.Error);
            //    M_lst_startLog.Add(GetLog("注射泵:错误!", Color.Red));
            //    M_isError = true;
            //}             
            if (SendOrderBackPump(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true)))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蠕动泵:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("蠕动泵:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]蠕动泵通讯错误!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("蠕动泵通讯错误!", Color.Red));
                M_isError = true;
            }
        }

        /// <summary>
        /// 检测气泵
        /// </summary>
        void CheckAirePump()
        {
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测气泵1开启...");
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Up))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵1开启:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("气泵1开启:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵1开启:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("气泵1开启:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测气泵1关闭...");
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopUp))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵1关闭:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("气泵1关闭:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵1关闭:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("气泵1关闭:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测气泵2开启...");
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Up))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵2开启:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("气泵2开启:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵2开启:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("气泵2开启:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测气泵2关闭...");
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopUp))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵2关闭:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("气泵2关闭:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵2关闭:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("气泵2关闭:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测气泵3开启...");
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Up))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵3开启:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("气泵3开启:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵3开启:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("气泵3开启:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测气泵3关闭...");
            if (SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopUp))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵3关闭:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("气泵3关闭:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]气泵3关闭:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("气泵3关闭:失败!", Color.Red));
                M_isError = true;
            }
        }

        void CheckBloodAndPressure()
        {
            //if (SendOrder(port_main, Cls.Comm_Main.CmdBloodLeak.CloseBloodLeak))
            //{
            //    Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]漏血检测正常!", Cls.TypeOfMessage.Success);
            //    M_lst_startLog.Add(GetLog("漏血检测正常!", Color.Green));
            //}
            //else
            //{
            //    Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]漏血检测失败!", Cls.TypeOfMessage.Error);
            //    M_lst_startLog.Add(GetLog("漏血检测失败!", Color.Red));
            //    M_isError = true;
            //}
            //Thread.Sleep(500);
            //if (SendOrder(port_main, Cls.Comm_Main.CmdPressure.ClosePressure))
            //{
            //    Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]压力检测正常!", Cls.TypeOfMessage.Success);
            //    M_lst_startLog.Add(GetLog("压力检测正常!", Color.Green));
            //}
            //else
            //{
            //    Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]压力检测失败!", Cls.TypeOfMessage.Error);
            //    M_lst_startLog.Add(GetLog("压力检测失败!", Color.Red));
            //    M_isError = true;
            //}
            //Thread.Sleep(500);
        }

        /// <summary>
        /// 检测报警灯
        /// </summary>
        void CheckAlarmLamp()
        {
            //红灯
            /*
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测报警灯 红灯闪烁...");
            if (SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.RedTwinkle))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]红灯闪烁:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("红灯闪烁:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]红灯闪烁:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("红灯闪烁:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测报警灯 红灯关闭...");
            if (SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.RedClose))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]红灯关闭:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("红灯关闭:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]红灯关闭:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("红灯关闭:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
             * */
            //绿灯 
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdAlarmLamp.GreenTwinkle))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]绿灯闪烁:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("绿灯闪烁:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]绿灯闪烁:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("绿灯闪烁:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdAlarmLamp.GreenClose))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]绿灯关闭:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("绿灯关闭:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]绿灯关闭:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("绿灯关闭:失败!", Color.Red));
                M_isError = true;
            }
            //黄灯
            /*
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测报警灯 黄灯闪烁...");
            if (SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.YellowTwinkle))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]黄灯闪烁:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("黄灯闪烁:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]黄灯闪烁:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("黄灯闪烁:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测报警灯 黄灯关闭...");
            if (SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.YellowClose))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]黄灯关闭:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("黄灯关闭:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]黄灯关闭:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("黄灯关闭:失败!", Color.Red));
                M_isError = true;
            }
             * */
        }

        /// <summary>
        /// 检测夹管阀
        /// </summary>
        void CheckValve()
        {
            #region 夹管阀1
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀1开...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.ClampV1))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀1夹管:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("夹管阀1夹管:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀1夹管:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("夹管阀1夹管:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀1关...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.LoosenV1))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀1松开:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("夹管阀1松开:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀1松开:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("夹管阀1松开:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            #endregion

            #region  夹管阀2
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀2夹管...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.ClampV2))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀2夹管:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("夹管阀2夹管:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀2夹管:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("夹管阀2夹管:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀2松开...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.LoosenV2))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀2松开:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("夹管阀2松开:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀2松开:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("夹管阀2松开:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            #endregion

            #region 夹管阀3
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀3夹管...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.ClampV3))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀3夹管:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("夹管阀3夹管:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀3夹管:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("夹管阀3夹管:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀3松开...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.LoosenV3))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀3松开:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("夹管阀3松开:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀3松开:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("夹管阀3松开:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            #endregion

            #region 夹管阀4
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀4夹管...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.ClampV4))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀4夹管:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("夹管阀4夹管:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀4夹管:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("夹管阀4夹管:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            Cls.SplashScreen.UdpateStatusText("[" + DateTime.Now.ToString() + "]检测 夹管阀4松开...");
            if (SendOrderBack(port_main, Cls.Comm_Main.CmdValve.LoosenV4))
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀4松开:正常!", Cls.TypeOfMessage.Success);
                M_lst_startLog.Add(GetLog("夹管阀4松开:正常!", Color.Green));
            }
            else
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]夹管阀4松开:失败!", Cls.TypeOfMessage.Error);
                M_lst_startLog.Add(GetLog("夹管阀4松开:失败!", Color.Red));
                M_isError = true;
            }
            Thread.Sleep(300);
            #endregion
        }

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
        /// 初始化时钟
        /// </summary>
        void InitTimer()
        {
            M_isTreat = false;
            M_isStart = true;
            //发送读取命令 
            //M_timer_Treat.AutoReset = true;
            //M_timer_Treat.Interval = 1000;
            //M_timer_Treat.Enabled = false;
            //M_timer_Treat.Elapsed += M_timer_Treat_Elapsed;
            //M_timer_Treat.Start();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Thread.CurrentThread.Priority = ThreadPriority.Normal;
                while (M_isStart)
                {
                    Thread.Sleep(500);
                    BeginInvoke(new Action(() =>
                    {
                        ReadValue();
                    }));
                }
            }
            ).Start();
        }


        void ReadValue()
        {
            m_circleNum++;
            //发送读取数据命令
            SendOrderData(port_data, Cls.Comm_Main.startTransData);
            //保存采集数据，治疗时,大概隔5秒保存一次数据
            if (M_isTreat && m_circleNum>=10)
            {
                m_circleNum = 0;
                SaveData();
            }

            #region 治疗界面
            if (M_uc_Therapy != null && this.palContent.Controls.IndexOf(M_uc_Therapy) == 0)
            {
                //如果界面存在各压力值显示
                M_uc_Therapy.uc_TreatPacc._Value = M_uc_Therapy.uc_paccT._Value = M_ModelValue.M_flt_PofPacc.ToString("f1");
                M_uc_Therapy.uc_TreatPart._Value = M_uc_Therapy.uc_partT._Value = M_ModelValue.M_flt_PofPart.ToString("f1");
                M_uc_Therapy.uc_TreatPven._Value = M_uc_Therapy.uc_pvenT._Value = M_ModelValue.M_flt_PofPven.ToString("f1");
                M_uc_Therapy.uc_TreatTMP._Value = M_uc_Therapy.uc_tmpT._Value = M_ModelValue.M_flt_PofTMP.ToString("f1");
                M_uc_Therapy.uc_TreatP1st._Value = M_uc_Therapy.uc_p1stT._Value = M_ModelValue.M_flt_PofP1st.ToString("f1");
                M_uc_Therapy.uc_TreatP2nd._Value = M_uc_Therapy.uc_p2ndT._Value = M_ModelValue.M_flt_PofP2nd.ToString("f1");

                //称重
                M_uc_Therapy.lblWeigh1.Text = M_ModelValue.M_flt_Weigh1.ToString();
                M_uc_Therapy.lblWeigh2.Text = M_ModelValue.M_flt_Weigh2.ToString();
                M_uc_Therapy.lblWeigh3.Text = M_ModelValue.M_flt_Weigh3.ToString();
                //加溫器
                M_uc_Therapy.uc_T._SpeedValue = M_ModelValue.M_flt_Temperature.ToString("f1");

                //压力值显示彩条
                if (M_ModelValue.M_flt_PofPacc <= M_uc_Therapy.uc_pacc._Max && M_ModelValue.M_flt_PofPacc >= M_uc_Therapy.uc_pacc._Min)
                    M_uc_Therapy.uc_pacc._Value = (int)M_ModelValue.M_flt_PofPacc;
                if (M_ModelValue.M_flt_PofPart <= M_uc_Therapy.uc_part._Max && M_ModelValue.M_flt_PofPart >= M_uc_Therapy.uc_part._Min)
                    M_uc_Therapy.uc_part._Value = (int)M_ModelValue.M_flt_PofPart;
                if (M_ModelValue.M_flt_PofPven <= M_uc_Therapy.uc_pven._Max && M_ModelValue.M_flt_PofPven >= M_uc_Therapy.uc_pven._Min)
                    M_uc_Therapy.uc_pven._Value = (int)M_ModelValue.M_flt_PofPven;
                if (M_ModelValue.M_flt_PofTMP <= M_uc_Therapy.uc_tmp._Max && M_ModelValue.M_flt_PofTMP >= M_uc_Therapy.uc_tmp._Min)
                    M_uc_Therapy.uc_tmp._Value = (int)M_ModelValue.M_flt_PofTMP;
                if (M_ModelValue.M_flt_PofP1st <= M_uc_Therapy.uc_p1st._Max && M_ModelValue.M_flt_PofP1st >= M_uc_Therapy.uc_p1st._Min)
                    M_uc_Therapy.uc_p1st._Value = (int)M_ModelValue.M_flt_PofP1st;
                if (M_ModelValue.M_flt_PofP2nd <= M_uc_Therapy.uc_p2nd._Max && M_ModelValue.M_flt_PofP2nd >= M_uc_Therapy.uc_p2nd._Min)
                    M_uc_Therapy.uc_p2nd._Value = (int)M_ModelValue.M_flt_PofP2nd;

                //累计值显示
                if (M_isTreat && !M_isFlowBlood)
                {
                    M_uc_Therapy.lblTotalTime.Text = Cls.utils.SecondsToTime(M_ModelTotal.TotalTime);    //M_ModelTotal.TotalTime.Hours.ToString("00") + ":" + M_ModelTotal.TotalTime.Minutes.ToString("00") + ":" + M_ModelTotal.TotalTime.Seconds.ToString("00");
                    M_uc_Therapy.lblTotalBP.Text = M_ModelTotal.TotalBP.ToString("f3");
                    M_uc_Therapy.lblTotalRP.Text = M_ModelTotal.TotalRP.ToString("f3");
                    M_uc_Therapy.lblTotalDP.Text = M_ModelTotal.TotalDP.ToString("f3");
                    M_uc_Therapy.lblTotalFP.Text = M_ModelTotal.TotalFP.ToString("f3");
                    M_uc_Therapy.lblTotalSP.Text = M_ModelTotal.TotalSP.ToString("f1");
                }
            }
            #endregion

            #region 回收界面
            if (M_uc_Recycle != null && this.palContent.Controls.IndexOf(M_uc_Recycle) == 0)
            {
                //回收界面压力值及范围显示
                M_uc_Recycle.uc_pacc._Value = M_ModelValue.M_flt_PofPacc.ToString("0.0");
                M_uc_Recycle.uc_pacc._Lower = M_ModelWarn.LowerPacc.ToString("0.0");
                M_uc_Recycle.uc_pacc._Upper = M_ModelWarn.UpperPacc.ToString("0.0");

                M_uc_Recycle.uc_part._Value = M_ModelValue.M_flt_PofPart.ToString("0.0");
                M_uc_Recycle.uc_part._Lower = M_ModelWarn.LowerPart.ToString("0.0");
                M_uc_Recycle.uc_part._Upper = M_ModelWarn.UpperPart.ToString("0.0");


                M_uc_Recycle.uc_pven._Value = M_ModelValue.M_flt_PofPven.ToString("0.0");
                M_uc_Recycle.uc_pven._Lower = M_ModelWarn.LowerPven.ToString("0.0");
                M_uc_Recycle.uc_pven._Upper = M_ModelWarn.UpperPven.ToString("0.0");

                M_uc_Recycle.uc_p1st._Value = M_ModelValue.M_flt_PofP1st.ToString("0.0");
                M_uc_Recycle.uc_p1st._Lower = M_ModelWarn.LowerP1st.ToString("0.0");
                M_uc_Recycle.uc_p1st._Upper = M_ModelWarn.UpperP1st.ToString("0.0");


                M_uc_Recycle.uc_p2nd._Value = M_ModelValue.M_flt_PofP2nd.ToString("0.0");
                M_uc_Recycle.uc_p2nd._Lower = M_ModelWarn.LowerP2nd.ToString("0.0");
                M_uc_Recycle.uc_p2nd._Upper = M_ModelWarn.UpperP2nd.ToString("0.0");


                M_uc_Recycle.uc_ptmp._Value = M_ModelValue.M_flt_PofTMP.ToString("0.0");
                M_uc_Recycle.uc_ptmp._Lower = M_ModelWarn.LowerTmp.ToString("0.0");
                M_uc_Recycle.uc_ptmp._Upper = M_ModelWarn.UpperTmp.ToString("0.0");
            }
            #endregion

            #region 液面界面
            if (M_uc_SetLiquidSurface != null && this.palContent.Controls.IndexOf(M_uc_SetLiquidSurface) == 0)
            {
                M_uc_SetLiquidSurface.uc_pacc._Value = M_ModelValue.M_flt_PofPacc.ToString("0.0");
                M_uc_SetLiquidSurface.uc_pacc._Lower = M_ModelWarn.LowerPacc.ToString("0.0");
                M_uc_SetLiquidSurface.uc_pacc._Upper = M_ModelWarn.UpperPacc.ToString("0.0");

                M_uc_SetLiquidSurface.uc_part._Value = M_ModelValue.M_flt_PofPart.ToString("0.0");
                M_uc_SetLiquidSurface.uc_part._Lower = M_ModelWarn.LowerPart.ToString("0.0");
                M_uc_SetLiquidSurface.uc_part._Upper = M_ModelWarn.UpperPart.ToString("0.0");


                M_uc_SetLiquidSurface.uc_pven._Value = M_ModelValue.M_flt_PofPven.ToString("0.0");
                M_uc_SetLiquidSurface.uc_pven._Lower = M_ModelWarn.LowerPven.ToString("0.0");
                M_uc_SetLiquidSurface.uc_pven._Upper = M_ModelWarn.UpperPven.ToString("0.0");

                M_uc_SetLiquidSurface.uc_p1st._Value = M_ModelValue.M_flt_PofP1st.ToString("0.0");
                M_uc_SetLiquidSurface.uc_p1st._Lower = M_ModelWarn.LowerP1st.ToString("0.0");
                M_uc_SetLiquidSurface.uc_p1st._Upper = M_ModelWarn.UpperP1st.ToString("0.0");


                M_uc_SetLiquidSurface.uc_p2nd._Value = M_ModelValue.M_flt_PofP2nd.ToString("0.0");
                M_uc_SetLiquidSurface.uc_p2nd._Lower = M_ModelWarn.LowerP2nd.ToString("0.0");
                M_uc_SetLiquidSurface.uc_p2nd._Upper = M_ModelWarn.UpperP2nd.ToString("0.0");


                M_uc_SetLiquidSurface.uc_ptmp._Value = M_ModelValue.M_flt_PofTMP.ToString("0.0");
                M_uc_SetLiquidSurface.uc_ptmp._Lower = M_ModelWarn.LowerTmp.ToString("0.0");
                M_uc_SetLiquidSurface.uc_ptmp._Upper = M_ModelWarn.UpperTmp.ToString("0.0");

            }
            #endregion

            #region 其他设置界面
            if (M_uc_OtherSet != null && this.palContent.Controls.IndexOf(M_uc_OtherSet) == 0)
            {
                M_uc_OtherSet.lblTemperature.Text = M_ModelValue.M_flt_Temperature.ToString("f1");
                M_uc_OtherSet.lblWeigh1.Text = M_ModelValue.M_flt_Weigh1.ToString("f1");
                M_uc_OtherSet.lblWeigh2.Text = M_ModelValue.M_flt_Weigh2.ToString("f1");
                M_uc_OtherSet.lblWeigh3.Text = M_ModelValue.M_flt_Weigh3.ToString("f1");
            }
            #endregion

            #region 累积界面
            if (M_uc_Sum != null)
            {
                //累计值显示                    
                M_uc_Sum.lblTotalTime.Text = Cls.utils.SecondsToTime(M_ModelTotal.TotalTime);  // M_ModelTotal.TotalTime.Hours.ToString("00") + ":" + M_ModelTotal.TotalTime.Minutes.ToString("00") + ":" + M_ModelTotal.TotalTime.Seconds.ToString("00");
                M_uc_Sum.lblTotalBP.Text = M_ModelTotal.TotalBP.ToString("f3");
                M_uc_Sum.lblTotalRP.Text = M_ModelTotal.TotalRP.ToString("f3");
                M_uc_Sum.lblTotalFP.Text = M_ModelTotal.TotalFP.ToString("f3");
                M_uc_Sum.lblTotalDP.Text = M_ModelTotal.TotalDP.ToString("f3");
                M_uc_Sum.lblTotalSP.Text = M_ModelTotal.TotalSP.ToString("f1");
            }
            #endregion

            #region 手动预冲界面
            //if (M_uc_ManualFlush != null && this.palContent.Controls.IndexOf(M_uc_ManualFlush) == 0)
            //{
            //    M_uc_ManualFlush.uc_pacc._Value = M_ModelValue.M_flt_PofPacc.ToString("0.0");
            //    M_uc_ManualFlush.uc_pacc._Lower = M_ModelWarn.LowerPacc.ToString("0.0");
            //    M_uc_ManualFlush.uc_pacc._Upper = M_ModelWarn.UpperPacc.ToString("0.0");
            //    M_uc_ManualFlush.uc_part._Value = M_ModelValue.M_flt_PofPart.ToString("0.0");
            //    M_uc_ManualFlush.uc_part._Lower = M_ModelWarn.LowerPart.ToString("0.0");
            //    M_uc_ManualFlush.uc_part._Upper = M_ModelWarn.UpperPart.ToString("0.0");
            //    M_uc_ManualFlush.uc_pven._Value = M_ModelValue.M_flt_PofPven.ToString("0.0");
            //    M_uc_ManualFlush.uc_pven._Lower = M_ModelWarn.LowerPven.ToString("0.0");
            //    M_uc_ManualFlush.uc_pven._Upper = M_ModelWarn.UpperPven.ToString("0.0");
            //    M_uc_ManualFlush.uc_p1st._Value = M_ModelValue.M_flt_PofP1st.ToString("0.0");
            //    M_uc_ManualFlush.uc_p1st._Lower = M_ModelWarn.LowerP1st.ToString("0.0");
            //    M_uc_ManualFlush.uc_p1st._Upper = M_ModelWarn.UpperP1st.ToString("0.0");
            //    M_uc_ManualFlush.uc_p2nd._Value = M_ModelValue.M_flt_PofP2nd.ToString("0.0");
            //    M_uc_ManualFlush.uc_p2nd._Lower = M_ModelWarn.LowerP2nd.ToString("0.0");
            //    M_uc_ManualFlush.uc_p2nd._Upper = M_ModelWarn.UpperP2nd.ToString("0.0");
            //    M_uc_ManualFlush.uc_ptmp._Value = M_ModelValue.M_flt_PofTMP.ToString("0.0");
            //    M_uc_ManualFlush.uc_ptmp._Lower = M_ModelWarn.LowerTmp.ToString("0.0");
            //    M_uc_ManualFlush.uc_ptmp._Upper = M_ModelWarn.UpperTmp.ToString("0.0");
            //}
            #endregion

            #region 自动预冲界面
            if (M_uc_AutoFlush != null && this.palContent.Controls.IndexOf(M_uc_AutoFlush) == 0)
            {
                M_uc_AutoFlush.uc_pacc._Value = M_ModelValue.M_flt_PofPacc.ToString("0.0");
                M_uc_AutoFlush.uc_pacc._Lower = M_ModelWarn.LowerPacc.ToString("0.0");
                M_uc_AutoFlush.uc_pacc._Upper = M_ModelWarn.UpperPacc.ToString("0.0");
                M_uc_AutoFlush.uc_part._Value = M_ModelValue.M_flt_PofPart.ToString("0.0");
                M_uc_AutoFlush.uc_part._Lower = M_ModelWarn.LowerPart.ToString("0.0");
                M_uc_AutoFlush.uc_part._Upper = M_ModelWarn.UpperPart.ToString("0.0");
                M_uc_AutoFlush.uc_pven._Value = M_ModelValue.M_flt_PofPven.ToString("0.0");
                M_uc_AutoFlush.uc_pven._Lower = M_ModelWarn.LowerPven.ToString("0.0");
                M_uc_AutoFlush.uc_pven._Upper = M_ModelWarn.UpperPven.ToString("0.0");
                M_uc_AutoFlush.uc_p1st._Value = M_ModelValue.M_flt_PofP1st.ToString("0.0");
                M_uc_AutoFlush.uc_p1st._Lower = M_ModelWarn.LowerP1st.ToString("0.0");
                M_uc_AutoFlush.uc_p1st._Upper = M_ModelWarn.UpperP1st.ToString("0.0");
                M_uc_AutoFlush.uc_p2nd._Value = M_ModelValue.M_flt_PofP2nd.ToString("0.0");
                M_uc_AutoFlush.uc_p2nd._Lower = M_ModelWarn.LowerP2nd.ToString("0.0");
                M_uc_AutoFlush.uc_p2nd._Upper = M_ModelWarn.UpperP2nd.ToString("0.0");
                M_uc_AutoFlush.uc_ptmp._Value = M_ModelValue.M_flt_PofTMP.ToString("0.0");
                M_uc_AutoFlush.uc_ptmp._Lower = M_ModelWarn.LowerTmp.ToString("0.0");
                M_uc_AutoFlush.uc_ptmp._Upper = M_ModelWarn.UpperTmp.ToString("0.0");
            }
            #endregion

            #region 流量界面
            if (M_uc_SetFlow != null && this.palContent.Controls.IndexOf(M_uc_SetFlow) == 0)
            {
                M_uc_SetFlow.uc_pacc._Value = M_ModelValue.M_flt_PofPacc.ToString("0.0");
                M_uc_SetFlow.uc_pacc._Lower = M_ModelWarn.LowerPacc.ToString("0.0");
                M_uc_SetFlow.uc_pacc._Upper = M_ModelWarn.UpperPacc.ToString("0.0");
                M_uc_SetFlow.uc_part._Value = M_ModelValue.M_flt_PofPart.ToString("0.0");
                M_uc_SetFlow.uc_part._Lower = M_ModelWarn.LowerPart.ToString("0.0");
                M_uc_SetFlow.uc_part._Upper = M_ModelWarn.UpperPart.ToString("0.0");
                M_uc_SetFlow.uc_pven._Value = M_ModelValue.M_flt_PofPven.ToString("0.0");
                M_uc_SetFlow.uc_pven._Lower = M_ModelWarn.LowerPven.ToString("0.0");
                M_uc_SetFlow.uc_pven._Upper = M_ModelWarn.UpperPven.ToString("0.0");
                M_uc_SetFlow.uc_p1st._Value = M_ModelValue.M_flt_PofP1st.ToString("0.0");
                M_uc_SetFlow.uc_p1st._Lower = M_ModelWarn.LowerP1st.ToString("0.0");
                M_uc_SetFlow.uc_p1st._Upper = M_ModelWarn.UpperP1st.ToString("0.0");
                M_uc_SetFlow.uc_p2nd._Value = M_ModelValue.M_flt_PofP2nd.ToString("0.0");
                M_uc_SetFlow.uc_p2nd._Lower = M_ModelWarn.LowerP2nd.ToString("0.0");
                M_uc_SetFlow.uc_p2nd._Upper = M_ModelWarn.UpperP2nd.ToString("0.0");
                M_uc_SetFlow.uc_ptmp._Value = M_ModelValue.M_flt_PofTMP.ToString("0.0");
                M_uc_SetFlow.uc_ptmp._Lower = M_ModelWarn.LowerTmp.ToString("0.0");
                M_uc_SetFlow.uc_ptmp._Upper = M_ModelWarn.UpperTmp.ToString("0.0");
                M_uc_SetFlow.txtBP.Text = M_ModelSetRun.SpeedBP.ToString("0.0");
            }
            #endregion

            #region 本主界面
            this.lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.tsbtnHT.Text = M_ModelValue.M_flt_Temperature.ToString("f1") + " ℃";
            //如果是治疗时，旋钮
            if (M_isTreat && !M_isFlowBlood)
            {
                lblBloodSpeed.Text = M_ModelSetRun.SpeedBP.ToString("f0");
            }
            #endregion

            #region 管理界面
            if (m_frmfa != null)
            {
                m_frmfa._Weigh1code = weigh1_code;
                m_frmfa.lblWeigh1code.Text = weigh1_code.ToString();
                m_frmfa.lblweigh1.Text = M_ModelValue.M_flt_Weigh1.ToString("f1");
                m_frmfa._Weigh2code = weigh2_code;
                m_frmfa.lblWeigh2code.Text = weigh2_code.ToString();
                m_frmfa.lblweigh2.Text = M_ModelValue.M_flt_Weigh2.ToString("f1");
                m_frmfa._Weigh3code = weigh3_code;
                m_frmfa.lblWeigh3code.Text = weigh3_code.ToString();
                m_frmfa.lblweigh3.Text = M_ModelValue.M_flt_Weigh3.ToString("f1");
            }
            #endregion

        }

        void SaveData()
        {
            //采集压力数据
            Model.pressure_data mp = new Model.pressure_data();
            mp.surgery_no = this.txtSurgeryNo.Text;
            mp.time_stamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            mp.in_blood_pressure = M_ModelValue.M_flt_PofPacc.ToString("f1");
            mp.arterial_pressure = M_ModelValue.M_flt_PofPart.ToString("f1");
            mp.venous_pressure = M_ModelValue.M_flt_PofPven.ToString("f1");
            mp.plasma_inlet_pressure = M_ModelValue.M_flt_PofP1st.ToString("f1");
            mp.plasma_pressure = M_ModelValue.M_flt_PofP2nd.ToString("f1");
            mp.transmembrane_pressure = M_ModelValue.M_flt_PofTMP.ToString("f1");
            BLL.pressure_data bp = new BLL.pressure_data();
            bp.Add(mp);
            //采集累计量数据
            Model.pump_speed_data mpump = new Model.pump_speed_data();
            mpump.blood_pump = M_ModelSetRun.SpeedBP.ToString("f1");
            mpump.blood_pump_t = M_ModelTotal.TotalBP.ToString("f3");
            mpump.circulating_pump = M_ModelSetRun.SpeedCP.ToString("f1");
            mpump.circulating_pump_t = "0";
            mpump.cumulative_time = M_ModelTotal.TotalTime.ToString();
            mpump.dialysis_pump = M_ModelSetRun.SpeedDP.ToString("f1");
            mpump.dialysis_pump_t = M_ModelTotal.TotalDP.ToString("f3");
            mpump.filtration_pump = M_ModelSetRun.SpeedFP2.ToString("f1");
            mpump.filtration_pump_t = "0";
            mpump.heparin_pump = M_ModelSetRun.SpeedSP.ToString("f1");
            mpump.heparin_pump_t = M_ModelTotal.TotalSP.ToString("f3");
            mpump.separation_pump = M_ModelSetRun.SpeedFP.ToString("f1");
            mpump.separation_pump_t = M_ModelTotal.TotalFP.ToString("f3");
            mpump.surgery_no = this.txtSurgeryNo.Text;
            mpump.time_stamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            mpump.tripe_pump = M_ModelSetRun.SpeedRP.ToString("f1");
            mpump.tripe_pump_t = M_ModelTotal.TotalRP.ToString("f3");
            mpump.warmer = M_ModelValue.M_flt_Temperature.ToString("f1");
            BLL.pump_speed_data pdata = new BLL.pump_speed_data();
            pdata.Add(mpump);
        }
        //void ShowWarnValue()
        //{
        //    this.uc_pacc._Lower = M_ModelWarn.LowerPacc.ToString("f0");
        //    this.uc_pacc._Upper = M_ModelWarn.UpperPacc.ToString("f0");
        //    this.uc_p1st._Lower = M_ModelWarn.LowerP1st.ToString("f0");
        //    this.uc_p1st._Upper = M_ModelWarn.UpperP1st.ToString("f0");
        //    this.uc_p2nd._Lower = M_ModelWarn.LowerP2nd.ToString("f0");
        //    this.uc_p2nd._Upper = M_ModelWarn.UpperP2nd.ToString("f0");
        //    this.uc_part._Lower = M_ModelWarn.LowerPart.ToString("f0");
        //    this.uc_part._Upper = M_ModelWarn.UpperPart.ToString("f0");
        //    this.uc_ptmp._Lower = M_ModelWarn.LowerTmp.ToString("f0");
        //    this.uc_ptmp._Upper = M_ModelWarn.UpperTmp.ToString("f0");
        //    this.uc_pven._Lower = M_ModelWarn.LowerPven.ToString("f0");
        //    this.uc_pven._Upper = M_ModelWarn.UpperPven.ToString("f0");  
        //}

        /// <summary>
        /// Treat timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void M_timer_Treat_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    threadTreat();
        //}

        private void SendOrderData(SerialPort _sp, byte[] _order)
        {
            try
            {
                if (_sp.IsOpen)
                {
                    Thread.Sleep(50);

                    _sp.Write(_order, 0, _order.Length);

                    Thread.Sleep(50);
                }
                else
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke((EventHandler)(delegate
                        {
                            MessageBox.Show(this, "通讯故障", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                    else
                        MessageBox.Show(this, "通讯故障", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Thread.Sleep(100);

                    #region 如果是蠕动泵,在治疗时改变状态
                    if (_sp.PortName.ToLower() == "com3")
                    {
                        Thread.Sleep(150);
                        //如果在治療狀態，記錄泵狀態
                        if (M_isTreat)
                        {
                            byte[] b = _order;
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
                            }
                        }
                    }
                    #endregion

                    #region 如果是注射泵，在治疗时改变状态
                    if (_sp.PortName.ToLower() == "com2")
                    {

                    }
                    #endregion

                    _sp.Write(_order, 0, _order.Length);

                    Thread.Sleep(50);
                }
                else
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke((EventHandler)(delegate
                        {
                            MessageBox.Show(this, "通讯故障", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                    else
                        MessageBox.Show(this, "通讯故障", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        void threadTreat()
        {  
            m_startTime=System.Environment.TickCount;  
            //ms为单位
            M_int_TreatCount += m_voidspan;

            if (M_exsitsWarn)
            {
                M_exsitsWarn = false;

                #region 采血压下限预报警:采血压低于 下限设定值+预报警设定值发生
                if (M_ModelValue.M_flt_PofPacc < M_ModelWarn.LowerPacc + M_ModelWarn.LowerPrePacc)
                {
                    M_exsitsTip = true;
                    //ShowWarn("W1-02");
                }
                #endregion

                #region 采血压下限超出范围
                if (M_ModelValue.M_flt_PofPacc < M_ModelWarn.LowerPacc)
                {
                    //ShowWarn("W1-03");
                }
                #endregion

                #region 采血压上限超出范围
                if (M_ModelValue.M_flt_PofPacc > M_ModelWarn.UpperPacc)
                {
                    //ShowWarn("W1-03");
                }
                #endregion

                #region 动脉压上限预报警
                if (M_ModelValue.M_flt_PofPart > M_ModelWarn.UpperPart - M_ModelWarn.UpperPrePart)
                {
                    M_exsitsTip = true;
                    //ShowWarn("W1-07");
                }
                #endregion

                #region 动脉压上限超出范围
                if (M_ModelValue.M_flt_PofPart > M_ModelWarn.UpperPart)
                {
                    //ShowWarn("W1-08");
                }
                #endregion

                #region 动脉压下限超出范围
                if (M_ModelValue.M_flt_PofPart < M_ModelWarn.LowerPart)
                {
                    //ShowWarn("W1-09");
                }
                #endregion

                #region 静脉压上限预警
                if (M_ModelValue.M_flt_PofPven > M_ModelWarn.UpperPven - M_ModelWarn.UpperPrePven)
                {
                    //ShowWarn("W1-04");
                }
                #endregion

                #region 静脉压上限超出范围
                if (M_ModelValue.M_flt_PofPven > M_ModelWarn.UpperPven)
                {
                    //ShowWarn("W1-05");
                }
                #endregion

                #region 静脉压下限超出范围
                if (M_ModelValue.M_flt_PofPven < M_ModelWarn.LowerPven)
                {
                    //ShowWarn("W1-06");
                }
                #endregion

                #region 血浆压上限超出范围
                if (M_ModelValue.M_flt_PofP1st > M_ModelWarn.UpperP1st)
                {
                    //ShowWarn("W1-12");
                }
                #endregion

                #region 血浆压下限超出范围
                if (M_ModelValue.M_flt_PofP1st < M_ModelWarn.LowerP1st)
                {
                    //ShowWarn("W1-13");
                    //SendWarnCmd();
                }
                #endregion

                #region 血浆入口压上限超出范围
                if (M_ModelValue.M_flt_PofP2nd > M_ModelWarn.UpperP2nd)
                {
                    //ShowWarn("W1-14");
                }
                #endregion

                #region 血浆入口压下限超出范围
                if (M_ModelValue.M_flt_PofP2nd < M_ModelWarn.LowerP2nd)
                {
                    //ShowWarn("W1-15");
                }
                #endregion

                #region TMP上限超出范围
                if (M_ModelValue.M_flt_PofTMP > M_ModelWarn.UpperTmp)
                {
                    //ShowWarn("W1-18");
                }
                #endregion

                #region TMP下限超出范围
                if (M_ModelValue.M_flt_PofTMP < M_ModelWarn.LowerTmp)
                {
                    //ShowWarn("W1-19");
                }
                #endregion

                #region 漏血值超出范围
                if (M_ModelValue.M_flt_BloodLeak < M_ModelWarn.BloodLeak)
                {
                    //ShowWarn("W1-23");
                }
                #endregion

            }
         
            if (M_uc_Therapy != null)// && M_isTreat && !M_isFlowBlood
            {
                //时间显示        
                M_uc_Therapy.lblTotalTime.Text = Cls.utils.SecondsToTime(M_int_TreatCount/1000);// ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            }
            //判断各累积值是否有效，提前预警
            #region 累计值达到 只提示一次!!!!
            if (M_ModelSetRun.TargetValid_time)
            {
                //不用时间计数器，应用当前时间-开始时间来计算时间累计
                if (M_int_TreatCount / 1000 >= M_ModelSetRun.TargetTime && !m_isUptoTime)
                {
                    m_isUptoTime = true;
                    M_exsitsTip = true;
                    if (m_isReleaseWarn)
                        ShowWarn("N-03");
                }
            }

            if (M_ModelSetRun.TargetValid_BP)
            {
                if (M_ModelTotal.TotalBP >= M_ModelSetRun.TargetBP && !m_isUptoBP)
                {
                    m_isUptoBP = true;
                    M_exsitsTip = true;
                    if (m_isReleaseWarn)
                        ShowWarn("N-01");
                }
            }

            if (M_ModelSetRun.TargetValid_DP && M_ModelSetRun.DPValid)
            {
                if (M_ModelTotal.TotalDP >= M_ModelSetRun.TargetDP && m_isUptoDP)
                {
                    m_isUptoDP = true;
                    M_exsitsTip = true;
                    //DP累计
                }
            }

            if (M_ModelSetRun.TargetValid_FP)
            {
                if (M_ModelTotal.TotalFP >= M_ModelSetRun.TargetFP && m_isUptoFP)
                {
                    m_isUptoFP = true;
                    M_exsitsTip = true;
                    if (m_isReleaseWarn) ShowWarn("N-02");
                }
            }

            if (M_ModelSetRun.TargetValid_RP)
            {
                if (M_ModelTotal.TotalRP >= M_ModelSetRun.TargetRP && m_isUptoRP)
                {
                    m_isUptoRP = true;
                    M_exsitsTip = true;
                    //RP累计 
                    if (m_isReleaseWarn) ShowWarn("N-02");
                }
            }

            if (M_ModelSetRun.TargetValid_SP)
            {
                if (M_ModelTotal.TotalSP >= M_ModelSetRun.TargetSP && m_isUptoSP)
                {
                    m_isUptoSP = true;
                    M_exsitsTip = true;
                    if (m_isReleaseWarn) ShowWarn("N-05");
                }
            }
            #endregion

            #region PE泵秤联动 需加一个标志量
            if (M_str_CurrentConfig == "PEConfig")
            {
                //1分钟检测一次
                if ((M_int_TreatCount/1000) % 60 == 0)
                {
                    //泵秤平衡
                    double reduce3 = weigh3_startvalue - M_ModelValue.M_flt_Weigh3;
                    double add1 = M_ModelValue.M_flt_Weigh1 - weigh1_startvalue;
                    if ((reduce3 - add1) > 10.0)
                    {
                        M_ModelSetRun.SpeedRP += 1;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection));
                        //M_PumpState.RPState.Speed += 1;
                    }
                    if ((reduce3 - add1) < -10.0)
                    {
                        M_ModelSetRun.SpeedRP -= 1;
                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection));
                        //M_PumpState.RPState.Speed -= 1;
                    }
                    Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "RPSpeed", M_ModelSetRun.SpeedRP.ToString());
                }
            }
            #endregion

            M_bl_changecolor = !M_bl_changecolor;
            this.lblRunning.Visible = !this.lblRunning.Visible;

          
            //经历时间用ms表示
            #region 累计值改变
            M_ModelTotal.TotalTime = M_int_TreatCount/1000;
            //泵速度根据设置值调节，累计值跟随 泵速度调节  mL/min /1000 = L/min /60 = L/s
            if (M_PumpState.BPState.Runing)
                M_ModelTotal.TotalBP += M_PumpState.BPState.Speed * m_voidspan / 60000000.0; //M_ModelSetRun.SpeedBP / 120000.0; //累积 L/s
            if (M_PumpState.RPState.Runing)
                M_ModelTotal.TotalRP += M_PumpState.RPState.Speed * m_voidspan / 60000000.0; //M_ModelSetRun.SpeedRP / 120000.0;
            if (M_PumpState.FPState.Runing)
                M_ModelTotal.TotalFP += M_PumpState.FPState.Speed * m_voidspan / 60000000.0; //M_ModelSetRun.SpeedFP / 120000.0;
            if (M_ModelSetRun.DPValid)
                M_ModelTotal.TotalDP += M_PumpState.DPState.Speed * m_voidspan / 60000000.0;//M_ModelSetRun.SpeedDP / 120000.0;
            M_ModelTotal.TotalSP += M_PumpState.SPSpeed * m_voidspan / 3600000; // ml/h /3600 = ml/s /1000 = ml/ms
            #endregion
          
            m_endTime = System.Environment.TickCount;
            m_voidspan = m_endTime - m_startTime + 500;
        }

        /// <summary>
        /// 结束治疗
        /// </summary>
        void threadStopTreat()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Thread.CurrentThread.Priority = ThreadPriority.Normal;
                //各泵停止  
                M_isTreat = false;
                BeginInvoke(new Action(() =>
                {
                    this.tsbtnPipeline.Enabled = true;
                    this.tsbtnRecycle.Enabled = true;
                    this.tsbtnPreFlush.Enabled = true;
                    this.tsbtnSetFlow.Enabled = true;
                    this.lblRunning.Visible = false;
                    btnStart.Image = Properties.Resources.start;
                    btnStart.Text = "开始";
                    btnStart.ForeColor = Color.Green;
                    StopPump();
                    //SendOrderBack(port_main, Cls.Comm_Main.CmdAlarmLamp.RedClose);
                    SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.GreenTwinkle);
                    this.Enabled = true;
                }));
            }
                ).Start();
            this.lblRunning.Visible = false;
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
                                #region 报警灯状态
                                //红色闪烁 	FE A1 00 5F ED
                                //红色关闭	FE A2 00 5C ED
                                //绿色闪烁 	FE A3 00 5D ED
                                //绿色关闭	FE A4 00 5A ED
                                //绿常常亮	FE A5 00 5B ED
                                //黄色闪烁 	FE A6 00 58 ED
                                //黄色关闭	FE A7 00 59 ED
                                //所有灯关闭	FE A8 00 56 ED
                                case 0xA1:
                                    //M_SendSuccess = true;
                                    break;
                                case 0xA2:
                                    //M_SendSuccess = true;
                                    break;
                                case 0xA3:
                                    //M_SendSuccess = true;
                                    break;
                                case 0xA4:
                                    //M_SendSuccess = true;
                                    break;
                                case 0xA5:
                                    //M_SendSuccess = true;
                                    break;
                                case 0xA6:
                                    //M_SendSuccess = true;
                                    break;
                                case 0xA7:
                                    //M_SendSuccess = true;
                                    break;
                                #endregion
                                #region 夹管阀状态 夹管阀状态位XX: 00松管状态/01夹管状态
                                //阀1通电松管	FE B1 01 XX XX(校验) ED
                                case 0xB1:
                                    //M_PumpState.VState[0] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀1断电夹管	FE B2 01 XX XX(校验) ED
                                case 0xB2:
                                    //M_PumpState.VState[0] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀2通电松管	FE B3 01 XX XX(校验) ED
                                case 0xB3:
                                    //M_PumpState.VState[1] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀2断电夹管	FE B4 01 XX XX(校验) ED
                                case 0xB4:
                                    //M_PumpState.VState[1] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀3通电松管	FE B5 01 XX XX(校验) ED
                                case 0xB5:
                                    //M_PumpState.VState[2] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀3断电夹管	FE B6 01 XX XX(校验) ED
                                case 0xB6:
                                    //M_PumpState.VState[2] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀4通电松管	FE B7 01 XX XX(校验) ED
                                case 0xB7:
                                    //M_PumpState.VState[3] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀4断电夹管	FE B8 01 XX XX(校验) ED
                                case 0xB8:
                                    //M_PumpState.VState[3] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀5通电松管	FE B9 01 XX XX(校验) ED
                                case 0xB9:
                                    //M_PumpState.VState[4] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀5断电夹管	FE BA 01 XX XX(校验) ED
                                case 0xBA:
                                    //M_PumpState.VState[4] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀6通电松管	FE BB 01 XX XX(校验) ED
                                case 0xBB:
                                    //M_PumpState.VState[5] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                //阀6断电夹管	FE BC 01 XX XX(校验) ED
                                case 0xBC:
                                    //M_PumpState.VState[5] = Convert.ToBoolean(M_buffer_main[3]);
                                    break;
                                #endregion
                                #region 气泵与气阀
                                //气泵1通电	FE E1 00 1F ED
                                //气泵1断电	FE E2 00 1C ED
                                //气泵2通电	FE E3 00 1D ED
                                //气泵2断电	FE E4 00 1A ED
                                //气泵3通电	FE E5 00 1B ED
                                //气泵3断电	FE E6 00 18 ED

                                //气阀1通电	FE E7 00 19 ED
                                //气阀1断电	FE E8 00 16 ED
                                //气阀2通电	FE E9 00 17 ED
                                //气阀2断电	FE EA 00 14 ED
                                //气阀3通电	FE EB 00 15 ED
                                //气阀3断电	FE EC 00 12 ED
                                case 0xE1:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if(M_uc_SetFlow!=null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkDownC1.Image = global::ALS.Properties.Resources.stop64;
                                    //    }
                                    //}));
                                    break;
                                case 0xE2:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkDownC1.Image = global::ALS.Properties.Resources.down_64;
                                    //    }
                                    //}));
                                    break;
                                case 0xE3:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkDownC2.Image = global::ALS.Properties.Resources.stop64;
                                    //    }
                                    //}));
                                    break;
                                case 0xE4:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkDownC2.Image = global::ALS.Properties.Resources.down_64;
                                    //    }
                                    //}));
                                    break;
                                case 0xE5:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkDownM1.Image = global::ALS.Properties.Resources.stop64;
                                    //    }
                                    //}));
                                    break;
                                case 0xE6:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkDownM1.Image = global::ALS.Properties.Resources.down_64;
                                    //    }
                                    //}));
                                    break;
                                case 0xE7:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkUpC1.Image = global::ALS.Properties.Resources.stop64;
                                    //    }
                                    //}));
                                    break;
                                case 0xE8:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkUpC1.Image = global::ALS.Properties.Resources.up_64;
                                    //    }
                                    //}));
                                    break;
                                case 0xE9:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkUpC2.Image = global::ALS.Properties.Resources.stop64;
                                    //    }
                                    //}));
                                    break;
                                case 0xEA:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkUpC2.Image = global::ALS.Properties.Resources.up_64;
                                    //    }
                                    //}));
                                    break;
                                case 0xEB:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkUpM1.Image = global::ALS.Properties.Resources.stop64;
                                    //    }
                                    //}));
                                    break;
                                case 0xEC:
                                    //this.Invoke((EventHandler)(delegate
                                    //{
                                    //    if (M_uc_SetFlow != null)
                                    //    {
                                    //        M_uc_SetLiquidSurface.chkUpM1.Image = global::ALS.Properties.Resources.up_64;
                                    //    }
                                    //}));
                                    break;
                                #endregion
                                #region 气泡检测
                                //气泡检测1开启	FF F1 00 0E ED
                                case 0xF1:
                                    M_SendSuccess = true;
                                    m_isOpenBubble1 = true;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD1.Image = Properties.Resources.AD1;
                                        this.tsbtnAD1.Text = "气泡检测1开";
                                    }));
                                    break;
                                //气泡检测1报警 FF 1F 00 E1 ED 
                                case 0x1F:
                                    //SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble1);
                                    //m_isOpenBubble1 = false;
                                    M_exsitsWarn = true;
                                    m_warnCode = "W1-01";
                                    if (m_isReleaseWarn) ShowWarn(m_warnCode);
                                    break;
                                //气泡检测1关闭	FF F2 00 0D ED
                                case 0xF2:
                                    M_SendSuccess = true;
                                    m_isOpenBubble1 = false;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD1.Image = Properties.Resources.AD1Off;
                                        this.tsbtnAD1.Text = "气泡检测1关";
                                    }));
                                    break;
                                //气泡检测2开启	FF F3 00 0C ED
                                case 0xF3:
                                    M_SendSuccess = true;
                                    m_isOpenBubble2 = true;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD2.Image = Properties.Resources.AD2;
                                        this.tsbtnAD2.Text = "气泡检测2开";
                                    }));
                                    break;
                                //气泡检测2报警		FF 2F 00 D1 ED
                                case 0x2F:
                                    //SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble2);
                                    //m_isOpenBubble2 = false;
                                    M_exsitsWarn = true;
                                    m_warnCode = "W2-01";
                                    if (m_isReleaseWarn) ShowWarn(m_warnCode);
                                    break;
                                //气泡检测2关闭 FF F4 00 0B ED
                                case 0xF4:
                                    M_SendSuccess = true;
                                    m_isOpenBubble2 = false;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD2.Image = Properties.Resources.AD2Off;
                                        this.tsbtnAD2.Text = "气泡检测2关";
                                    }));
                                    break;
                                //气泡检测3开启	FF F5 00 0A ED
                                case 0xF5:
                                    M_SendSuccess = true;
                                    m_isOpenBubble3 = true;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD3.Image = Properties.Resources.AD3;
                                        this.tsbtnAD3.Text = "气泡检测3开";
                                    }));
                                    break;
                                //气泡检测3报警		FF 3F 00 C1 ED   
                                case 0x3F:
                                    //SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble3);
                                    //m_isOpenBubble3 = false;
                                    M_exsitsWarn = true;
                                    m_warnCode = "W2-02";
                                    if (m_isReleaseWarn) ShowWarn(m_warnCode);
                                    break;
                                //气泡检测3关闭 FF F6 00 09 ED
                                case 0xF6:
                                    M_SendSuccess = true;
                                    m_isOpenBubble3 = false;
                                    this.Invoke((EventHandler)(delegate
                                    {
                                        this.tsbtnAD3.Image = Properties.Resources.AD3Off;
                                        this.tsbtnAD3.Text = "气泡检测3关";
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
                                case 0x0A:
                                    if (M_isTreat && lblBloodSpeed.Enabled == true)
                                    {
                                        if (M_ModelSetRun.SpeedBP >= 15)
                                            M_ModelSetRun.SpeedBP -= 5;
                                        //M_PumpState.BPState.Speed = M_ModelSetRun.SpeedBP;
                                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "BPSpeed", M_ModelSetRun.SpeedBP.ToString());
                                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(1, M_ModelSetRun.SpeedBP, true, true));
                                    }
                                    break;
                                case 0x1A:
                                    if (M_isTreat && lblBloodSpeed.Enabled == true)
                                    {
                                        if (M_ModelSetRun.SpeedBP <= 195)
                                            M_ModelSetRun.SpeedBP += 5;
                                        //M_PumpState.BPState.Speed = M_ModelSetRun.SpeedBP;
                                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "BPSpeed", M_ModelSetRun.SpeedBP.ToString());
                                        SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(1, M_ModelSetRun.SpeedBP, true, true));
                                    }
                                    break;
                                #endregion
                                #region 液位检测 1静脉 2动脉 3M1
                                //液位1上限报警		FF 2A 00 D5 ED
                                case 0x2A:
                                    M_exsitsWarn = true;
                                    M_exsitsTip = true;
                                    m_warnCode = "W3-12";
                                    if (m_isReleaseWarn) ShowWarn(m_warnCode);
                                    break;
                                //液位1正常信号		FF 3A 00 C5 ED
                                //液位1下限报警		FF 4A 00 B5 ED
                                case 0x4A:
                                    M_exsitsWarn = true;
                                    M_exsitsTip = true;
                                    m_warnCode = "W3-13";
                                    if (m_isReleaseWarn) ShowWarn(m_warnCode);
                                    break;
                                //液位2上限报警		FF 5A 00 A5 ED
                                case 0x5A:
                                    M_exsitsWarn = true;
                                    M_exsitsTip = true;
                                    m_warnCode = "W3-14";
                                    if (m_isReleaseWarn) ShowWarn(m_warnCode);
                                    break;
                                //液位2正常信号		FF 6A 00 95 ED
                                //液位2下限报警		FF 7A 00 85 ED
                                case 0x7A:
                                    M_exsitsWarn = true;
                                    M_exsitsTip = true;
                                    m_warnCode = "W3-15";
                                    if (m_isReleaseWarn) ShowWarn(m_warnCode);
                                    break;
                                //液位3上限报警		FF 8A 00 75 ED
                                case 0x8A:
                                    M_exsitsWarn = true;
                                    M_exsitsTip = true;
                                    m_warnCode = "W3-16";
                                    if (m_isReleaseWarn) ShowWarn(m_warnCode);
                                    break;
                                //液位3正常信号		FF 9A 00 65 ED
                                //液位3下限报警		FF 0B 00 F4 ED 
                                case 0x0B:
                                    M_exsitsWarn = true;
                                    M_exsitsTip = true;
                                    m_warnCode = "W3-17";
                                    if (m_isReleaseWarn) ShowWarn(m_warnCode);
                                    break;
                                //液位检测全关
                                case 0xF7:
                                    M_SendSuccess = true;
                                    break;
                                //液位检测全开
                                case 0xF8:
                                    M_SendSuccess = true;
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
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }
            finally
            {
                M_Listening_main = false;
            }
        }
        void port_data_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(50);
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

                while (M_buffer_data.Count >= 34)
                {
                    if (M_buffer_data[0] == 0xFF)
                    {
                        //FF AE 1E 00 7F 00 00 00 00 00 
                        //00 00 00 00 00 A4 0B 00 D7 EA 
                        //FF 52 74 FE B6 8E 1D 9E 8E 1D 
                        //31 42 00 ED
                        if (M_buffer_data[1] == 0xAE && M_buffer_data[2] == 0x1E && M_buffer_data[33] == 0xED)
                        {
                            #region 所有显示值(无校验)
                            //温度
                            double t = (((M_buffer_data[3] & 0xFFFF) << 8) + M_buffer_data[4]) * 0.0625;
                            M_ModelValue.M_flt_Temperature = (float)t;
                            //压力
                            int pacc = ((M_buffer_data[5] & 0xFFFF) << 8) + M_buffer_data[6];
                            M_ModelValue.M_flt_PofPacc = (float)Math.Round(0.1182765 * pacc - 968.8597, 2) - 0.8;//((((pacc - 1638) * 30) - 196605) * 51.675f) / 13107
                            int part = ((M_buffer_data[7] & 0xFFFF) << 8) + M_buffer_data[8];
                            M_ModelValue.M_flt_PofPven = (float)Math.Round(0.1182765 * part - 968.8597, 2) - 0.8;//((((part - 1638) * 30) - 196605) * 51.675f) / 13107
                            int pven = ((M_buffer_data[9] & 0xFFFF) << 8) + M_buffer_data[10];
                            M_ModelValue.M_flt_PofPart = (float)Math.Round(0.1182765 * pven - 968.8597, 2) - 0.8;//((((pven - 1638) * 30) - 196605) * 51.675f) / 13107
                            int p1st = ((M_buffer_data[11] & 0xFFFF) << 8) + M_buffer_data[12];
                            M_ModelValue.M_flt_PofP1st = (float)Math.Round(0.1182765 * p1st - 968.8597, 2) - 0.8;//((((p1st - 1638) * 30) - 196605) * 51.675f) / 13107
                            int p2nd = ((M_buffer_data[13] & 0xFFFF) << 8) + M_buffer_data[14];
                            M_ModelValue.M_flt_PofP2nd = (float)Math.Round(0.1182765 * p2nd - 968.8597, 2) - 0.8;//((((p2nd - 1638) * 30) - 196605) * 51.675f) / 13107
                            int tmp = ((M_buffer_data[15] & 0xFFFF) << 8) + M_buffer_data[16];
                            //float p3rd = (float)Math.Round(0.1182765 * tmp - 968.8597, 2) - 0.8;//((((tmp - 1638) * 30) - 196605) * 51.675f) / 13107
                            //跨膜压 = （动脉压Part + 静脉压Pven）/2 - 血浆压P1st
                            M_ModelValue.M_flt_PofTMP = (M_ModelValue.M_flt_PofPart + M_ModelValue.M_flt_PofPven) / 2.0f - M_ModelValue.M_flt_PofP1st;
                            //采血压
                            if ((M_ModelValue.M_flt_PofPacc > M_ModelWarn.UpperPacc) || (M_ModelValue.M_flt_PofPacc < M_ModelWarn.LowerPacc))
                                M_exsitsWarn = true;
                            //动脉压
                            if ((M_ModelValue.M_flt_PofPart > M_ModelWarn.UpperPart) || (M_ModelValue.M_flt_PofPart < M_ModelWarn.LowerPart))
                                M_exsitsWarn = true;
                            //静脉压
                            if ((M_ModelValue.M_flt_PofPven > M_ModelWarn.UpperPven) || (M_ModelValue.M_flt_PofPven < M_ModelWarn.LowerPven))
                                M_exsitsWarn = true;

                            if ((M_ModelValue.M_flt_PofP1st > M_ModelWarn.UpperP1st) || (M_ModelValue.M_flt_PofP1st < M_ModelWarn.LowerP1st))
                                M_exsitsWarn = true;

                            if ((M_ModelValue.M_flt_PofP2nd > M_ModelWarn.UpperP2nd) || (M_ModelValue.M_flt_PofP2nd < M_ModelWarn.LowerP2nd))
                                M_exsitsWarn = true;

                            if ((M_ModelValue.M_flt_PofTMP > M_ModelWarn.UpperTmp) || (M_ModelValue.M_flt_PofTMP < M_ModelWarn.LowerTmp))
                                M_exsitsWarn = true;
                            //称重相关
                            weigh1_code = ((M_buffer_data[17] & 0xFFFF) << 16) + ((M_buffer_data[16] & 0xFFFF) << 8) + M_buffer_data[15];
                            weigh2_code = ((M_buffer_data[20] & 0xFFFF) << 16) + ((M_buffer_data[19] & 0xFFFF) << 8) + M_buffer_data[18];
                            weigh3_code = ((M_buffer_data[23] & 0xFFFF) << 16) + ((M_buffer_data[22] & 0xFFFF) << 8) + M_buffer_data[21];

                            M_ModelValue.M_flt_Weigh1 = (weigh1_code - weigh1_0kgcode) * weigh1_resolution;
                            M_ModelValue.M_flt_Weigh2 = (weigh2_code - weigh2_0kgcode) * weigh2_resolution;
                            M_ModelValue.M_flt_Weigh3 = (weigh3_code - weigh3_0kgcode) * weigh3_resolution;

                            //处理完数据后，则移除该组数据
                            M_buffer_data.RemoveRange(0, 34);
                            #endregion
                        }
                    }
                    else
                    {
                        //如果数据开始不是FF，则删除数据  
                        M_buffer_data.RemoveAt(0);
                    }
                }
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
            catch (Exception ee) { MessageBox.Show(ee.ToString()); }
            finally
            {
                M_Listening_data = false;
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 肝素泵串口接收处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void port_hpump_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(30);
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
                while (M_buffer_hpump.Count >= 4)
                {
                    #region 肝素泵返回 FF 3E 08 00 10(主控板1.0) 00 10(监控板1.0) 00 00 00 00 C9 ED
                    if (M_buffer_hpump[0] == 0xFF & M_buffer_hpump[1] == 0x3E)
                    {
                        int len = M_buffer_hpump[2];
                        if (M_buffer_hpump.Count < len + 5) break;
                        if (checkOut(M_buffer_hpump))
                        {
                            this.BeginInvoke((EventHandler)(delegate
                            {
                                this.tsbtnSP.Image = Properties.Resources.sp20off;
                                string verSBase = (((M_buffer_hpump[3] & 0xFFFF) << 8) + M_buffer_hpump[4]).ToString();
                                string verS = "主控板版本:" + Cls.utils.ConvertString(verSBase.ToString(), 10, 16);
                                verS = verS.Insert(verS.Length - 1, ".");
                                string verCBase = (((M_buffer_hpump[5] & 0xFFFF) << 8) + M_buffer_hpump[6]).ToString();
                                string verC = " 监控板版本:" + Cls.utils.ConvertString(verSBase.ToString(), 10, 16) + "\r\n";
                                verC = verC.Insert(verC.Length - 1, ".");
                                this.txtRecieve.AppendText(verS.ToString() + verC.ToString());
                                M_strb_hpump.Clear();
                            }));
                            M_buffer_hpump.RemoveRange(0, len + 5);
                        }
                        else
                            M_buffer_hpump.RemoveRange(0, len + 5);
                    }
                    #endregion

                    else
                    {
                        //如果数据开始不是头，则删除数据  
                        M_buffer_hpump.RemoveAt(0);
                    }

                    #region 接收命令Log
                    //this.BeginInvoke((EventHandler)(delegate
                    //{
                    //    buffcount++;
                    //    //依次的拼接出16进制字符串  
                    //    M_strb_hpump.Append(port_hpump.PortName + "(" + buffcount + "):");
                    //    foreach (byte b in buf)
                    //    {
                    //        M_strb_hpump.Append(b.ToString("X2") + " ");
                    //    } 
                    //    M_strb_hpump.Append("[" + DateTime.Now.ToString() + "]\r\n");
                    //    //追加的形式添加到文本框末端，并滚动到最后。  
                    //    this.txtRecieve.AppendText(M_strb_hpump.ToString());
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
        /// 异或校验
        /// </summary>
        /// <param name="_input"></param>
        /// <returns></returns>
        bool checkOut(List<byte> _input)
        {
            int len = _input[2];
            if (len > 1) return false;
            bool reval = false;
            //如果接收的命令长度小于数据长度+4，则弃掉该命令
            if (_input.Count < len + 5)
                reval = false;
            byte checksum = _input[0];
            for (int i = 1; i < len + 3; i++)
            {
                checksum ^= _input[i];
            }
            if (checksum != _input[len + 3])
                reval = false;
            else
                reval = true;
            return reval;
        }

        bool checkOut1(List<byte> _input)
        {
            int len = 1;
            bool reval = false;
            //如果接收的命令长度小于数据长度+4，则弃掉该命令
            if (_input.Count < len + 5)
                reval = false;
            byte checksum = _input[0];
            for (int i = 1; i < len + 3; i++)
            {
                checksum ^= _input[i];
            }
            if (checksum != _input[len + 3])
                reval = false;
            else
                reval = true;
            return reval;
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
        private void InitComm(SerialPort _sp, string _name, int _baudrate, int _databits, System.IO.Ports.StopBits _stopbits, System.IO.Ports.Parity _parity, string _info)
        {
            if (_sp.IsOpen)
            {
                _sp.Close();
                Thread.Sleep(300);
            }
            _sp.PortName = _name;
            _sp.BaudRate = _baudrate;
            _sp.DataBits = _databits;
            _sp.StopBits = _stopbits;
            _sp.Parity = _parity;
            _sp.ReadTimeout = 1000;
            _sp.WriteTimeout = 1000;
            _sp.RtsEnable = false;
            _sp.DtrEnable = false;
            _sp.ReceivedBytesThreshold = 5;
            _sp.ReadBufferSize = 2048;
            _sp.WriteBufferSize = 2048;
            // _sp.NewLine = "\r\n";
            try { _sp.Open(); }
            catch (Exception ee)
            {
                Cls.SplashScreen.UdpateStatusTextWithStatus("初始化通讯端口:" + _info + _name + "错误:" + ee.Message.ToString(), Cls.TypeOfMessage.Error);
                Cls.utils.sysStartLog slog = new Cls.utils.sysStartLog();
                slog.InfoColor = Color.Red;
                slog.StartInfo = "初始化通讯端口[" + _info + _name + "]错误:" + ee.Message.ToString() + "\r\n";
                slog.StartTime = DateTime.Now;
                M_lst_startLog.Add(slog);
                M_isError = true;
                return;
            }

            finally
            {
                if (_sp.IsOpen)
                {
                    Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]初始化通讯端口:" + _info + _name + "成功!", Cls.TypeOfMessage.Success);
                    M_isError = false;
                    Cls.utils.sysStartLog slog = new Cls.utils.sysStartLog();
                    slog.InfoColor = Color.Green;
                    slog.StartInfo = "初始化通讯端口[" + _info + _name + "]成功!\r\n";
                    slog.StartTime = DateTime.Now;
                    M_lst_startLog.Add(slog);
                }
                else
                {
                    M_isError = true;
                    Cls.SplashScreen.UdpateStatusTextWithStatus("[" + DateTime.Now.ToString() + "]初始化通讯端口:" + _info + _name + "失败!", Cls.TypeOfMessage.Error);
                    Cls.utils.sysStartLog slog = new Cls.utils.sysStartLog();
                    slog.InfoColor = Color.Red;
                    slog.StartInfo = "初始化通讯端口[" + _info + _name + "]失败!\r\n";
                    slog.StartTime = DateTime.Now;
                    M_lst_startLog.Add(slog);
                }
                //MessageBox.Show(_sp.IsOpen.ToString()); 
            }
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            //如果正在治疗，不允许退出
            if (M_isTreat)
            {
                MessageBox.Show("正在治疗，不允许退出！");
                toolStripControl_ItemClicked(tsbtnTherapy, new ToolStripItemClickedEventArgs(tsbtnTherapy));
                tsbtnTherapy_Click(tsbtnTherapy, e);
                return;
            }

            if (M_isFlush)
            {
                MessageBox.Show("正在预冲，不允许退出！");
                toolStripControl_ItemClicked(tsbtnTherapy, new ToolStripItemClickedEventArgs(tsbtnPreFlush));
                tsbtnPreflush_Click(tsbtnPreFlush, e);
                return;
            }

            if (DialogResult.OK == MessageBox.Show(this, "确定退出?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                tsbtnHome_Click(tsbtnHome, e);
                toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnHome));
                //this.Enabled = false;
                this.toolStripControl.Enabled = false;
                this.toolStripOther.Enabled = false;
                Exit();
            }
            else
            {
                //toolStripControl_ItemClicked(tsbtnTherapy, new ToolStripItemClickedEventArgs(tsbtnHome));
                //tsbtnHome_Click(tsbtnHome, e);
            }
        }


        private void tsBtnSetSyringe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
            {
                MessageBox.Show("请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (M_uc_SetSyringe == null)
            {
                M_uc_SetSyringe = new FormSet.ucSetSyringe();
                M_uc_SetSyringe._Port_hpump = this.port_hpump;
                M_uc_SetSyringe._ModelSet = this.M_ModelSetRun;
                M_uc_SetSyringe.btnSave_SP += new FormSet.ucSetSyringe.btnSaveSP(M_uc_SetSyringe_btnSave_SP);
                M_uc_SetSyringe.btnRun_SP += new FormSet.ucSetSyringe.btnRunSP(M_uc_SetSyringe_btnRun_SP);
                M_uc_SetSyringe.btnStop_SP += new FormSet.ucSetSyringe.btnStopSP(M_uc_SetSyringe_btnStop_SP);
                M_uc_SetSyringe.lblSpeed_Changed += new FormSet.ucSetSyringe.lblSpeedChanged(M_uc_SetSyringe_lblSpeed_Changed);
                M_uc_SetSyringe._Section = M_str_CurrentConfig;
                this.palContent.Controls.Add(M_uc_SetSyringe);
            }
            this.palContent.Controls.SetChildIndex(M_uc_SetSyringe, 0);
            M_uc_SetSyringe._Section = M_str_CurrentConfig;
            M_uc_SetSyringe.ReadSPSet(M_str_CurrentConfig);
            M_uc_SetSyringe._Port_hpump = this.port_hpump;
            M_uc_SetSyringe._ModelSet = this.M_ModelSetRun;
            M_uc_SetSyringe.BringToFront();
            M_uc_SetSyringe.Dock = DockStyle.Fill;
        }

        void M_uc_SetSyringe_lblSpeed_Changed(object sender, EventArgs e)
        {
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
            //throw new NotImplementedException();
        }

        void M_uc_SetSyringe_btnStop_SP(object sender, EventArgs e)
        {
            SendOrder(port_hpump, Cls.Comm_SyringePump.Stop);
            M_uc_SetSyringe.btnStop.Enabled = false;
            M_uc_SetSyringe.btnRun.Enabled = true;
            //throw new NotImplementedException();
        }

        void M_uc_SetSyringe_btnRun_SP(object sender, EventArgs e)
        {
            SendOrder(port_hpump, Cls.Comm_SyringePump.Start(M_ModelSetRun.SpeedSP, 0));
            M_uc_SetSyringe.btnStop.Enabled = true;
            M_uc_SetSyringe.btnRun.Enabled = false;
            //throw new NotImplementedException();
        }

        void M_uc_SetSyringe_btnSave_SP(object sender, EventArgs e)
        {
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
            //throw new NotImplementedException();
        }

        private void tsbtnSetFlow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
            {
                MessageBox.Show("请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
            if (M_uc_SetFlow == null)
            {
                M_uc_SetFlow = new FormSet.ucSetFlow();
                M_uc_SetFlow.btnChange_bp += new FormSet.ucSetFlow.btnChange_BP(M_uc_SetFlow_btnChange_bp);
                M_uc_SetFlow.btnRun_Pump += new FormSet.ucSetFlow.btnRunPump(M_uc_SetFlow_btnRun_Pump);
                M_uc_SetFlow.btnReadset += new FormSet.ucSetFlow.btnSaveSet(M_uc_SetFlow_btnReadset);
                M_uc_SetFlow.chkCheckChange += new FormSet.ucSetFlow.chkCheckChanged(M_uc_SetFlow_chkCheckChange);
                M_uc_SetFlow._ModelPumpState = M_PumpState;
                M_uc_SetFlow.SetButtonState(M_PumpState);
                M_uc_SetFlow._Section = M_str_CurrentConfig;
                this.palContent.Controls.Add(M_uc_SetFlow);
            }
            M_uc_SetFlow._ModelPumpState = M_PumpState;
            M_uc_SetFlow.SetButtonState(M_PumpState);
            M_uc_SetFlow._Section = M_str_CurrentConfig;
            M_uc_SetFlow.ReadConfig(M_str_CurrentConfig);
            M_uc_SetFlow.btnReturn.Visible = false;
            M_uc_SetFlow.btnConfirmM.Visible = false;
            M_uc_SetFlow.groupSet.Text = "流量设置";
            this.palContent.Controls.SetChildIndex(M_uc_SetFlow, 0);
            M_uc_SetFlow.BringToFront();
            M_uc_SetFlow.Dock = DockStyle.Fill;
        }

        void M_uc_SetFlow_chkCheckChange(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                cb.BackColor = Color.FromArgb(31, 163, 215);
                cb.ForeColor = Color.White;
            }
            else
            {
                cb.ForeColor = Color.FromArgb(31, 163, 215);
                cb.BackColor = Color.Transparent;
            }
            switch (cb.Tag.ToString())
            {
                case "BP":
                    if (cb.Checked)
                        //Cls.RWconfig.SetAppSettings("BPValid", "true");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "BPValid", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("BPValid", "false");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "BPValid", "false");
                    break;
                case "FP":
                    if (cb.Checked)
                        //Cls.RWconfig.SetAppSettings("FPValid", "true");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "FPValid", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("FPValid", "false");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "FPValid", "false");
                    break;
                case "DP":
                    if (cb.Checked)
                        //Cls.RWconfig.SetAppSettings("DPValid", "true");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "DPValid", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("DPValid", "false");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "DPValid", "false");
                    break;
                case "RP":
                    if (cb.Checked)
                        //Cls.RWconfig.SetAppSettings("RPValid", "true");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "RPValid", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("RPValid", "false");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "RPValid", "false");
                    break;
                case "FP2":
                    if (cb.Checked)
                        //Cls.RWconfig.SetAppSettings("FP2Valid", "true");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "FP2Valid", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("FP2Valid", "false");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "FP2Valid", "false");
                    break;
                case "CP":
                    if (cb.Checked)
                        //Cls.RWconfig.SetAppSettings("CPValid", "true");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "CPValid", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("CPValid", "false");
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "CPValid", "false");
                    break;
            }
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
            //throw new NotImplementedException();
        }

        void M_uc_SetFlow_btnReadset(object sender, EventArgs e)
        {
            //重新读取设置
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
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
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 1, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection);
                                btn.Text = "停止";
                                btn.Image = Properties.Resources.spstop;
                                btn.ForeColor = Color.Red;
                                if (!M_ModelSetRun.BPDirection)
                                {
                                    //this.lblBloodShow.Text = "血液流量(反)";
                                    this.lblBloodSpeed.Text = M_ModelSetRun.SpeedBP.ToString("f0");
                                }
                                else
                                {
                                    //this.lblBloodShow.Text = "血液流量";
                                    this.lblBloodSpeed.Text = M_ModelSetRun.SpeedBP.ToString("f0");
                                }
                            }
                            else
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, false, M_ModelSetRun.BPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 1, M_ModelSetRun.SpeedBP, false, M_ModelSetRun.BPDirection);
                                btn.Text = "运转";
                                btn.Image = Properties.Resources.spstart;
                                btn.ForeColor = Color.FromArgb(15, 8, 100);
                                this.lblBloodSpeed.Text = "000";
                            }
                            break;
                        case 11:
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection));
                            //Cls.utils.SetSinglePumpState(M_PumpState, 1, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection);
                            //btn.Text = "停止";
                            //btn.Image = Properties.Resources.spstop;
                            //btn.ForeColor = Color.Red;
                            if (!M_ModelSetRun.BPDirection)
                            {
                                //this.lblBloodShow.Text = "血液流量(反)";
                                this.lblBloodSpeed.Text = M_ModelSetRun.SpeedBP.ToString("f0");
                            }
                            else
                            {
                                //this.lblBloodShow.Text = "血液流量";
                                this.lblBloodSpeed.Text = M_ModelSetRun.SpeedBP.ToString("f0");
                            }
                            break;
                        case 2:
                            if (btn.Text == "运转")
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelSetRun.SpeedFP, true, M_ModelSetRun.FPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 2, M_ModelSetRun.SpeedFP, true, M_ModelSetRun.FPDirection);
                                btn.Text = "停止";
                                btn.Image = Properties.Resources.spstop;
                                btn.ForeColor = Color.Red;
                            }
                            else
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelSetRun.SpeedFP, false, M_ModelSetRun.FPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 2, M_ModelSetRun.SpeedFP, false, M_ModelSetRun.FPDirection);
                                btn.Text = "运转";
                                btn.Image = Properties.Resources.spstart;
                                btn.ForeColor = Color.FromArgb(15, 8, 100);
                            }
                            break;
                        case 22:
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelSetRun.SpeedFP, true, M_ModelSetRun.FPDirection));
                            //Cls.utils.SetSinglePumpState(M_PumpState, 2, M_ModelSetRun.SpeedFP, true, M_ModelSetRun.FPDirection);
                            //btn.Text = "停止";
                            //btn.Image = Properties.Resources.spstop;
                            //btn.ForeColor = Color.Red;
                            break;

                        case 3:
                            //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection));
                            if (btn.Text == "运转")
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelSetRun.SpeedDP, true, M_ModelSetRun.DPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 3, M_ModelSetRun.SpeedDP, true, M_ModelSetRun.DPDirection);
                                btn.Text = "停止";
                                btn.Image = Properties.Resources.spstop;
                                btn.ForeColor = Color.Red;
                            }
                            else
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelSetRun.SpeedDP, false, M_ModelSetRun.DPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 3, M_ModelSetRun.SpeedDP, false, M_ModelSetRun.DPDirection);
                                btn.Text = "运转";
                                btn.Image = Properties.Resources.spstart;
                                btn.ForeColor = Color.FromArgb(15, 8, 100);
                            }
                            break;
                        case 33:
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x03, M_ModelSetRun.SpeedDP, true, M_ModelSetRun.DPDirection));
                            //Cls.utils.SetSinglePumpState(M_PumpState, 3, M_ModelSetRun.SpeedDP, true, M_ModelSetRun.DPDirection);
                            break;
                        case 4:
                            //SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedDP, true, M_ModelSetRun.DPDirection));
                            if (btn.Text == "运转")
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 4, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection);
                                btn.Text = "停止";
                                btn.Image = Properties.Resources.spstop;
                                btn.ForeColor = Color.Red;
                            }
                            else
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, false, M_ModelSetRun.RPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 4, M_ModelSetRun.SpeedRP, false, M_ModelSetRun.RPDirection);
                                btn.Text = "运转";
                                btn.Image = Properties.Resources.spstart;
                                btn.ForeColor = Color.FromArgb(15, 8, 100);
                            }
                            break;
                        case 44:
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection));
                            //Cls.utils.SetSinglePumpState(M_PumpState, 4, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection);
                            break;
                        case 5:
                            if (btn.Text == "运转")
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelSetRun.SpeedFP2, true, M_ModelSetRun.FP2Direction));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 5, M_ModelSetRun.SpeedFP2, true, M_ModelSetRun.FP2Direction);
                                btn.Text = "停止";
                                btn.Image = Properties.Resources.spstop;
                                btn.ForeColor = Color.Red;
                            }
                            else
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelSetRun.SpeedFP2, false, M_ModelSetRun.FP2Direction));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 5, M_ModelSetRun.SpeedFP2, false, M_ModelSetRun.FP2Direction);
                                btn.Text = "运转";
                                btn.Image = Properties.Resources.spstart;
                                btn.ForeColor = Color.FromArgb(15, 8, 100);
                            }
                            break;
                        case 55:
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x05, M_ModelSetRun.SpeedFP2, true, M_ModelSetRun.FP2Direction));
                            //Cls.utils.SetSinglePumpState(M_PumpState, 5, M_ModelSetRun.SpeedFP2, true, M_ModelSetRun.FP2Direction);
                            break;
                        case 6:
                            if (btn.Text == "运转")
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelSetRun.SpeedCP, true, M_ModelSetRun.CPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 6, M_ModelSetRun.SpeedCP, true, M_ModelSetRun.CPDirection);
                                btn.Text = "停止";
                                btn.Image = Properties.Resources.spstop;
                                btn.ForeColor = Color.Red;
                            }
                            else
                            {
                                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelSetRun.SpeedCP, false, M_ModelSetRun.CPDirection));
                                //Cls.utils.SetSinglePumpState(M_PumpState, 6, M_ModelSetRun.SpeedCP, false, M_ModelSetRun.CPDirection);
                                btn.Text = "运转";
                                btn.Image = Properties.Resources.spstart;
                                btn.ForeColor = Color.FromArgb(15, 8, 100);
                            }
                            break;
                        case 66:
                            SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x06, M_ModelSetRun.SpeedCP, true, M_ModelSetRun.CPDirection));
                            //Cls.utils.SetSinglePumpState(M_PumpState, 6, M_ModelSetRun.SpeedCP, true, M_ModelSetRun.CPDirection);
                            break;
                        case 31:
                            if (!M_bwStartPump.IsBusy)
                                M_bwStartPump.RunWorkerAsync();
                            break;
                        case 32:
                            StopPump();
                            break;
                    }
                }
            }
            //throw new NotImplementedException();
        }

        void M_uc_SetFlow_btnChange_bp(object sender, EventArgs e)
        {
            //保存方向配置           
            //throw new NotImplementedException();
            Button btn = sender as Button;
            switch (btn.Tag.ToString())
            {
                case "1":
                    if (M_uc_SetFlow.btnBPDirection.Text == "正转")
                        //Cls.RWconfig.SetAppSettings("BPDirection", "true");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "BPDirection", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("BPDirection", "false");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "BPDirection", "false");
                    break;
                case "2":
                    if (M_uc_SetFlow.btnFPDirection.Text == "正转")
                        //Cls.RWconfig.SetAppSettings("FPDirection", "true");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "FPDirection", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("FPDirection", "false");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "FPDirection", "false");
                    break;
                case "3":
                    if (M_uc_SetFlow.btnDPDirection.Text == "正转")
                        //Cls.RWconfig.SetAppSettings("DPDirection", "true");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "DPDirection", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("DPDirection", "false");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "DPDirection", "false");
                    break;
                case "4":
                    if (M_uc_SetFlow.btnRPDirection.Text == "正转")
                        //Cls.RWconfig.SetAppSettings("RPDirection", "true");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "RPDirection", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("RPDirection", "false");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "RPDirection", "false");
                    break;
                case "5":
                    if (M_uc_SetFlow.btnFP2Direction.Text == "正转")
                        //Cls.RWconfig.SetAppSettings("FP2Direction", "true");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "FP2Direction", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("FP2Direction", "false");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "FP2Direction", "false");
                    break;
                case "6":
                    if (M_uc_SetFlow.btnCPDirection.Text == "正转")
                        //Cls.RWconfig.SetAppSettings("CPDirection", "true");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "CPDirection", "true");
                    else
                        //Cls.RWconfig.SetAppSettings("CPDirection", "false");//_MFlush
                        Cls.utils.SetSectionKeyValue(M_str_CurrentConfig, "CPDirection", "false");
                    break;
            }
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
        }

        private void tsbtnHome_Click(object sender, EventArgs e)
        {
            pBoxHome.BringToFront();
            //MessageBox.Show(this.palContent.Controls.IndexOf(pBoxHome).ToString());
        }

        private void tsbtnMethod_Click(object sender, EventArgs e)
        {
            if (M_uc_Method == null)
            {
                M_uc_Method = new FormOperation.ucMethod();
                M_uc_Method.btnOkClicked += new FormOperation.ucMethod.btnOKClick(M_uc_Method_btnOkClicked);
                M_uc_Method.Port_Main = port_main;
                M_uc_Method.Port_Pump = port_ppump;
                this.palContent.Controls.Add(M_uc_Method);
            }
            this.palContent.Controls.SetChildIndex(M_uc_Method, 0);
            //MessageBox.Show(this.palContent.Controls.GetChildIndex(M_uc_Method).ToString());
            M_uc_Method.BringToFront();
            M_uc_Method.Dock = DockStyle.Fill;
        }

        void M_uc_Method_btnOkClicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (this.M_str_CurrentConfig != b.Tag.ToString())
            {
                this.M_str_CurrentConfig = b.Tag.ToString();
                //初始化标志变量
                //是否已经选择预冲方式
                M_SelFlushType = 0;
                //是否正进行治疗
                M_isTreat = false;
                //管路是否安装完成
                M_bl_isFinishPipeline = false;
                //是否完成预冲
                M_bl_isFinishFlush = false;
                //是否完成治疗
                M_bl_isFinishTreat = false;
                //初始化累计值
                ZeroTotal();
                //初始化引血timer
                m_timerTreatCount = 0;
            }
            ShowMethodName(M_str_CurrentConfig);
            toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnPipeline));
            tsbtnPipeline_Click(tsbtnPipeline, e);
        }


        private void tsbtnPipeline_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
            {
                MessageBox.Show("请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowPipeLine();
        }

        private void ShowPipeLine()
        {
            if (pipeLine == null)
            {
                pipeLine = new FormOperation.ucPipeLine();
                pipeLine._PortPump = port_ppump;
                pipeLine._MethodName = M_str_CurrentConfig;
                pipeLine.M_int_CurrentIndex = 0;
                pipeLine._btnNextClicked += new FormOperation.ucPipeLine.btnClicked(M_uc_Pipeline_btnNextClicked);
                pipeLine.InitItems(M_str_CurrentConfig);
                //plPE.btnGuideClicked += new FormOperation.ucPipeline.btnGuideClick(M_uc_Pipeline_btnGuideClicked);
                this.palContent.Controls.Add(pipeLine);
            }
            pipeLine.M_int_CurrentIndex = 0;
            pipeLine.InitItems(M_str_CurrentConfig);
            pipeLine.btnNext.Text = "下一步";
            pipeLine.SetBackColor(0);
            pipeLine.btnGuide.Enabled = true;
            this.palContent.Controls.SetChildIndex(pipeLine, 0);
            pipeLine.BringToFront();
            pipeLine.Dock = DockStyle.Fill;

            //switch (_method)
            //{
            //    case "PEConfig": 
            //        if (plPE == null)
            //        {
            //            plPE = new PipeLine.pl_PE();
            //            plPE._PortPump = port_ppump;
            //            plPE._ModelState = M_PumpState;
            //            plPE.btnNextClicked +=new PipeLine.pl_PE.btnClicked(M_uc_Pipeline_btnNextClicked);
            //            //plPE.btnGuideClicked += new FormOperation.ucPipeline.btnGuideClick(M_uc_Pipeline_btnGuideClicked);
            //            this.palContent.Controls.Add(plPE);
            //        }
            //        this.palContent.Controls.SetChildIndex(plPE, 0);
            //        plPE.BringToFront();
            //        plPE.Dock = DockStyle.Fill;                    
            //        break;
            //    case "Li-ALSConfig":
            //        if (plLiALS == null)
            //        {
            //            plLiALS = new PipeLine.pl_LiALS();
            //            plLiALS._btnNextClicked += new PipeLine.pl_LiALS.btnClicked(M_uc_Pipeline_btnNextClicked);
            //            plLiALS._PortPump = port_ppump;
            //            plLiALS._ModelState = M_PumpState;
            //            this.palContent.Controls.Add(plLiALS);
            //        }
            //        this.palContent.Controls.SetChildIndex(plLiALS, 0);
            //        plLiALS.Dock = DockStyle.Fill;   
            //        break;
            //    case "CVVHDF":
            //        break;
            //    case "PDF":
            //        break;
            //    case "PP":
            //        break;
            //    case "HP":
            //        break; 
            //}
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

        private void tsbtnPreflush_Click(object sender, EventArgs e)
        {
            //先判断是否选择了治疗方法 和 管路是否安装完成
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
            {
                MessageBox.Show("请确认治疗方法!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!M_bl_isFinishPipeline)
            {
                MessageBox.Show("请确认管路安装!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //如果没选择预冲方式 0 未选择 1 自动 2 手动
            switch (M_SelFlushType)
            {
                case 0://未选择，出现选择预冲方式界面
                    if (M_uc_selFlush == null)
                    {
                        M_uc_selFlush = new FormOperation.ucSelectFlush();
                        M_uc_selFlush._btnSelAutoFlush += new ALS.FormOperation.ucSelectFlush.btnSelAutoFlush(M_uc_selFlush__btnSelAutoFlush);
                        M_uc_selFlush._btnSelManualFlush += new FormOperation.ucSelectFlush.btnSelManualFlush(M_uc_selFlush__btnSelManualFlush);
                        this.palContent.Controls.Add(M_uc_selFlush);
                        M_uc_selFlush.Dock = DockStyle.Fill;
                        M_uc_selFlush.BringToFront();
                    }
                    else
                    {
                        this.palContent.Controls.Add(M_uc_selFlush);
                        M_uc_selFlush.BringToFront();
                    }
                    break;
                case 1://自动
                    M_uc_selFlush__btnSelAutoFlush(sender, e);
                    break;
                case 2://手动
                    M_uc_selFlush__btnSelManualFlush(sender, e);
                    break;
            }
        }

        void M_uc_selFlush__btnSelManualFlush(object sender, EventArgs e)
        {
            M_SelFlushType = 2;
            //if (M_uc_ManualFlush == null)
            //{
            //    M_uc_ManualFlush = new FormOperation.ucManualFlush();
            //    M_uc_ManualFlush.btnClickFinish += new FormOperation.ucManualFlush.btnClickDelegate(M_uc_PreFlush_btnClickFinish);
            //    M_uc_ManualFlush.txtChange += new FormOperation.ucManualFlush.txtChanged(M_uc_PreFlush_txtChange);
            //    M_uc_ManualFlush.btnDirectionClicked += new FormOperation.ucManualFlush.btnDirectionClick(M_uc_PreFlush_btnDirectionClicked);
            //    M_uc_ManualFlush.btnRunsingle += new FormOperation.ucManualFlush.btnRunSingle(M_uc_PreFlush_btnRunsingle);
            //    M_uc_ManualFlush.btnReturnSel_PE += new FormOperation.ucManualFlush.btnReturnSel(afPE_btnReturnSel_PE);
            //    M_uc_ManualFlush.Dock = DockStyle.Fill;
            //    M_uc_ManualFlush._Section = M_str_CurrentConfig;
            //    this.palContent.Controls.Add(M_uc_ManualFlush);
            //}
            //M_uc_ManualFlush._Section = M_str_CurrentConfig;
            //M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
            //M_uc_ManualFlush.ReadSet(M_str_CurrentConfig);
            //M_uc_ManualFlush._ModelPumpState = M_PumpState;
            //M_uc_ManualFlush.SetButtonState(M_PumpState);
            //this.palContent.Controls.SetChildIndex(M_uc_ManualFlush, 0);
            //M_uc_ManualFlush.BringToFront();
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
            if (M_uc_SetFlow == null)
            {
                M_uc_SetFlow = new FormSet.ucSetFlow();
                M_uc_SetFlow.btnChange_bp += new FormSet.ucSetFlow.btnChange_BP(M_uc_SetFlow_btnChange_bp);
                M_uc_SetFlow.btnRun_Pump += new FormSet.ucSetFlow.btnRunPump(M_uc_SetFlow_btnRun_Pump);
                M_uc_SetFlow.btnReadset += new FormSet.ucSetFlow.btnSaveSet(M_uc_SetFlow_btnReadset);
                M_uc_SetFlow.chkCheckChange += new FormSet.ucSetFlow.chkCheckChanged(M_uc_SetFlow_chkCheckChange);
                M_uc_SetFlow.btnClickFinish += M_uc_SetFlow_btnClickFinish;
                M_uc_SetFlow._ModelPumpState = M_PumpState;
                M_uc_SetFlow.SetButtonState(M_PumpState);
                M_uc_SetFlow._Section = M_str_CurrentConfig;
                M_uc_SetFlow.btnReturnSelect += M_uc_SetFlow_btnReturnSelect;
                this.palContent.Controls.Add(M_uc_SetFlow);
            }
            M_uc_SetFlow._ModelPumpState = M_PumpState;
            M_uc_SetFlow.SetButtonState(M_PumpState);
            M_uc_SetFlow._Section = M_str_CurrentConfig;
            M_uc_SetFlow.ReadConfig(M_str_CurrentConfig);
            M_uc_SetFlow.btnReturn.Visible = true;
            M_uc_SetFlow.btnConfirmM.Visible = true;
            M_uc_SetFlow.groupSet.Text = "手动预冲";
            this.palContent.Controls.SetChildIndex(M_uc_SetFlow, 0);
            M_uc_SetFlow.BringToFront();
            M_uc_SetFlow.Dock = DockStyle.Fill;
        }

        void M_uc_SetFlow_btnClickFinish(object sender, EventArgs e)
        {
            this.tsbtnMethod.Enabled = true;
            this.tsbtnPipeline.Enabled = true;
            this.tsbtnPreFlush.Enabled = true;
            this.tsbtnTherapy.Enabled = true;
            this.tsbtnRecycle.Enabled = true;
            this.tsbtnSetFlow.Enabled = true;
            M_bl_isFinishFlush = true;
            M_isFlush = false;
            toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnTherapy));
            tsbtnTherapy_Click(tsbtnTherapy, e);
        }

        void M_uc_SetFlow_btnReturnSelect(object sender, EventArgs e)
        {
            M_SelFlushType = 0;
            tsbtnPreflush_Click(sender, e);
            //throw new NotImplementedException();
        }

        void M_uc_selFlush__btnSelAutoFlush(object sender, EventArgs e)
        {
            M_SelFlushType = 1;
            string strFlush = string.Empty;
            switch (M_str_CurrentConfig)
            {
                case "PEConfig":
                    strFlush = "PE_Flush";
                    break;
                case "Li-ALSConfig":
                    strFlush = "Li-ALS_Flush";
                    break;
                case "CHDFConfig":
                    strFlush = "CHDF_Flush";
                    break;
                case "PDFConfig":
                    strFlush = "PDF_Flush";
                    break;
                case "HPConfig":
                    strFlush = "HP_Flush";
                    break;
                case "PPConfig":
                    strFlush = "PP_Flush";
                    break;
            }

            if (M_uc_AutoFlush == null)
            {
                M_uc_AutoFlush = new FormOperation.ucAutoFlush();
                M_uc_AutoFlush.m_methodName = strFlush;
                M_uc_AutoFlush._Port_Main = port_main;
                M_uc_AutoFlush._Port_Pump = port_ppump;
                M_uc_AutoFlush.m_isExistActions = M_uc_AutoFlush.GetCustCmd(strFlush);
                M_uc_AutoFlush.btnReturnSelEvent += afCustom_btnReturnSelEvent;
                M_uc_AutoFlush.btnEndFlush += afCustom_btnEndFlush;
                M_uc_AutoFlush.btnStartFlush += M_uc_AutoFlush_btnStartFlush;
                this.palContent.Controls.Add(M_uc_AutoFlush);
                M_uc_AutoFlush.Dock = DockStyle.Fill;
                M_uc_AutoFlush.BringToFront();
            }
            M_uc_AutoFlush.BringToFront();
            if (!M_isFlush)
            {
                M_uc_AutoFlush.m_methodName = strFlush;
                M_uc_AutoFlush.m_isExistActions = M_uc_AutoFlush.GetCustCmd(strFlush);
            }
            M_uc_AutoFlush.dgvStep.ClearSelection();
            this.palContent.Controls.SetChildIndex(M_uc_AutoFlush, 0);
        }

        void M_uc_AutoFlush_btnStartFlush(object sender, EventArgs e)
        {
            this.tsbtnMethod.Enabled = false;
            this.tsbtnPipeline.Enabled = false;
            this.tsbtnTherapy.Enabled = false;
            this.tsbtnRecycle.Enabled = false;
            this.tsbtnSetFlow.Enabled = false;
            this.lblBloodSpeed.Enabled = false;
            M_isFlush = true;
        }

        void afCustom_btnEndFlush(object sender, EventArgs e)
        {
            this.tsbtnMethod.Enabled = true;
            this.tsbtnPipeline.Enabled = true;
            this.tsbtnTherapy.Enabled = true;
            this.tsbtnRecycle.Enabled = true;
            this.tsbtnSetFlow.Enabled = true;
            this.lblBloodSpeed.Enabled = true;
            M_uc_AutoFlush.btnStart.Enabled = true;
            M_bl_isFinishFlush = true;
            M_isFlush = false;
            M_PumpState.VState = M_uc_AutoFlush.m_pumpState.VState;
            toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnTherapy));
            tsbtnTherapy_Click(tsbtnTherapy, e);
            //throw new NotImplementedException();
        }

        void afCustom_btnReturnSelEvent(object sender, EventArgs e)
        {
            M_SelFlushType = 0;
            tsbtnPreflush_Click(sender, e);
            //throw new NotImplementedException();
        }

        private void tsbtnTherapy_Click(object sender, EventArgs e)
        {
            //先判断是否选择了治疗方法 和 管路是否安装完成
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
            {
                MessageBox.Show("请确认治疗方法!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!M_bl_isFinishPipeline)
            {
                MessageBox.Show("请确认管路安装!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //手动预冲时
            //if (M_uc_ManualFlush != null)
            //{
            //    if (!M_uc_ManualFlush.M_finishFlush)
            //    {
            //        MessageBox.Show("未清洗管路!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("未清洗管路!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (!M_bl_isFinishFlush)
            {
                MessageBox.Show("未清洗管路!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //获取报警门限值
            M_ModelWarn = Cls.utils.GetModelWarn(M_str_CurrentConfig);
            //获取设置值
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
            if (M_uc_Therapy == null)
            {
                M_uc_Therapy = new FormOperation.ucTreat();
                M_uc_Therapy._ModelWarn = M_ModelWarn;
                M_uc_Therapy._ModelSet = M_ModelSetRun;
                M_uc_Therapy.ReadSet(M_ModelSetRun);
                this.palContent.Controls.Add(M_uc_Therapy);
            }
            M_uc_Therapy._ModelWarn = M_ModelWarn;
            M_uc_Therapy._ModelSet = M_ModelSetRun;
            M_uc_Therapy.ReadSet(M_ModelSetRun);
            M_uc_Therapy.ShowWarnValue();
            M_uc_Therapy.ReadTreatPic(M_str_CurrentConfig);
            this.palContent.Controls.SetChildIndex(M_uc_Therapy, 0);
            this.btnStart.Enabled = true;

            //MessageBox.Show(this.palContent.Controls.GetChildIndex(M_uc_Therapy).ToString() + this.palContent.Controls.GetChildIndex(M_uc_Method).ToString());
            M_uc_Therapy.BringToFront();
            M_uc_Therapy.Dock = DockStyle.Fill;
        }

        private void tsbtnRecycle_Click(object sender, EventArgs e)
        {
            //先判断是否选择了治疗方法 和 管路是否安装完成
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
            {
                MessageBox.Show("请确认治疗方法!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!M_bl_isFinishPipeline)
            {
                MessageBox.Show("请确认管路安装!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!M_bl_isFinishFlush)
            {
                MessageBox.Show("未清洗管路!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!M_bl_isFinishTreat)
            {
                MessageBox.Show("未完成治疗!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (M_uc_Recycle == null)
            {
                M_uc_Recycle = new FormOperation.ucRecycle();
                M_uc_Recycle._Port_main = port_main;
                M_uc_Recycle._Port_ppump = port_ppump;
                M_uc_Recycle._ModelWarn = Cls.utils.GetModelWarn(M_str_CurrentConfig);
                M_uc_Recycle.recycle_btnRunBP += M_uc_Recycle_recycle_btnRunBP;
                M_uc_Recycle.recyle_btnCloseAll += new FormOperation.ucRecycle.dlgRecycle_btnCloseAll(M_uc_Recycle_recyle_btnCloseAll);
                M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
                this.palContent.Controls.Add(M_uc_Recycle);
            }
            M_uc_Recycle._ModelWarn = Cls.utils.GetModelWarn(M_str_CurrentConfig);
            M_ModelSetRun = Cls.utils.GetModelSet(M_str_CurrentConfig);
            //M_uc_Recycle.ShowWarnValue();
            M_uc_Recycle._ModelPumpState = M_PumpState;
            string rec = M_str_CurrentConfig.Remove(M_str_CurrentConfig.IndexOf("Config"), 6);
            M_uc_Recycle.ShowRecycleActions(rec + "_Recycle");
            M_uc_Recycle.gboxRecycle.Text = rec + " 回收方法,请参照以下步骤回收";
            M_uc_Recycle.SetButtonState(M_PumpState);
            M_uc_Recycle.lblBP.Enabled = M_uc_Recycle.btnRun1.Enabled = (M_ModelSetRun.BPValid ? true : false);
            M_uc_Recycle.lblCP.Enabled = M_uc_Recycle.btnRun6.Enabled = (M_ModelSetRun.CPValid ? true : false);
            M_uc_Recycle.lblDP.Enabled = M_uc_Recycle.btnRun3.Enabled = (M_ModelSetRun.DPValid ? true : false);
            M_uc_Recycle.lblFP.Enabled = M_uc_Recycle.btnRun2.Enabled = (M_ModelSetRun.FPValid ? true : false);
            M_uc_Recycle.lblFP2.Enabled = M_uc_Recycle.btnRun5.Enabled = (M_ModelSetRun.FP2Valid ? true : false);
            M_uc_Recycle.lblRP.Enabled = M_uc_Recycle.btnRun4.Enabled = (M_ModelSetRun.RPValid ? true : false);
            this.palContent.Controls.SetChildIndex(M_uc_Recycle, 0);
            //MessageBox.Show(this.palContent.Controls.GetChildIndex(M_uc_Recycle).ToString());
            M_uc_Recycle.BringToFront();
            M_uc_Recycle.Dock = DockStyle.Fill;
        }

        void M_uc_Recycle_recycle_btnRunBP(object sender, EventArgs e)
        {
            //Button btn = sender as Button;
            //if (btn.Tag != null)
            //{
            //    int id = Convert.ToInt16(btn.Tag.ToString());
            //    switch (id)
            //    {
            //        case 1:
            //            if (btn.Text == "运转")
            //            {
            //                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection));
            //                Cls.utils.SetSinglePumpState(M_PumpState, 1, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection);
            //                btn.Text = "停止";
            //                btn.Image = Properties.Resources.spstop;
            //                btn.ForeColor = Color.Red;
            //                if (!M_ModelSetRun.BPDirection)
            //                {
            //                    //this.lblBloodShow.Text = "血液流量(反)";
            //                    this.lblBloodSpeed.Text = M_ModelSetRun.SpeedBP.ToString("f0");
            //                }
            //                else
            //                {
            //                    //this.lblBloodShow.Text = "血液流量";
            //                    this.lblBloodSpeed.Text = M_ModelSetRun.SpeedBP.ToString("f0");
            //                }
            //            }
            //            else
            //            {
            //                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, false, M_ModelSetRun.BPDirection));
            //                Cls.utils.SetSinglePumpState(M_PumpState, 1, M_ModelSetRun.SpeedBP, false, M_ModelSetRun.BPDirection);
            //                btn.Text = "运转";
            //                btn.Image = Properties.Resources.spstart;
            //                btn.ForeColor = Color.FromArgb(15, 8, 100);
            //                this.lblBloodSpeed.Text = "0";
            //            }
            //            break;
            //    }
            //}
        }

        void M_uc_Recycle_recyle_btnCloseAll(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("请务必仔细确认是否已完成回收？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                SendOrder(port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose);
                SendOrder(port_main, Cls.Comm_Main.CmdValve.LoosenAllV);
            }
            else
            {
                return;
            }
            //throw new NotImplementedException();
        }

        void M_uc_Recycle_recycle_btnCloseRP(object sender, EventArgs e)
        {
            isRunRP = !isRunRP;
            if (isRunRP)
            {
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, true, M_ModelSetRun.RPDirection));
                M_uc_Recycle.btnRun4.Text = "关闭补液泵";
            }
            else
            {
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x04, M_ModelSetRun.SpeedRP, false, M_ModelSetRun.RPDirection));
                M_uc_Recycle.btnRun4.Text = "运转补液泵";
            }
            //throw new NotImplementedException();
        }

        void M_uc_Recycle_recycle_btnCloseFP(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            isRunFP = !isRunFP;
            if (isRunFP)
            {
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelSetRun.SpeedFP, true, M_ModelSetRun.FPDirection));
                M_uc_Recycle.btnRun2.Text = "关闭分离泵";
            }
            else
            {
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x02, M_ModelSetRun.SpeedFP, false, M_ModelSetRun.FPDirection));
                M_uc_Recycle.btnRun2.Text = "运转分离泵";
            }
        }

        //void M_uc_Recycle_recycle_btnRunBP(object sender, EventArgs e)
        //{
        //    isRunBP = !isRunBP;
        //    if (isRunBP)
        //    {
        //        SendOrderBackPump(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, true, M_ModelSetRun.BPDirection));
        //        M_uc_Recycle.btnRunBP.Text = "关闭血液泵";
        //    }
        //    else
        //    {
        //        SendOrderBackPump(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, M_ModelSetRun.SpeedBP, false, M_ModelSetRun.BPDirection));
        //        M_uc_Recycle.btnRunBP.Text = "运转血液泵";
        //    }

        //    //throw new NotImplementedException();
        //}

        private void tsbtnOtherSet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
            {
                MessageBox.Show("请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (M_uc_OtherSet == null)
            {
                M_uc_OtherSet = new FormSet.ucSetOther();
                M_uc_OtherSet._Port_main = this.port_main;
                M_uc_OtherSet._Port_hpump = this.port_hpump;
                //M_uc_OtherSet._Section = M_str_CurrentConfig;
                //M_uc_OtherSet.ReadLevel(M_str_CurrentConfig);
                //M_uc_OtherSet.ReadPEFlush(M_str_CurrentConfig);
                M_uc_OtherSet.btnSetv += M_uc_OtherSet_btnSetv;
                this.palContent.Controls.Add(M_uc_OtherSet);
            }
            M_uc_OtherSet._Section = M_str_CurrentConfig;
            M_uc_OtherSet.ReadLevel(M_str_CurrentConfig);
            M_uc_OtherSet.ReadHPumpSet(M_str_CurrentConfig);
            M_uc_OtherSet.ReadPEFlush(M_str_CurrentConfig);
            this.palContent.Controls.SetChildIndex(M_uc_OtherSet, 0);
            M_uc_OtherSet.BringToFront();
            M_uc_OtherSet.Dock = DockStyle.Fill;
        }

        void M_uc_OtherSet_btnSetv(object sender, EventArgs e)
        {
            //改变夹管阀状态
            Button btn = sender as Button;
            var v = btn.Tag;
            Cls.Model_State ms = (Cls.Model_State)v;
            M_PumpState.VState = ms.VState;
        }

        private void tsbtnSum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
            {
                MessageBox.Show("请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (M_uc_Sum == null)
            {
                M_uc_Sum = new FormSet.ucSetSum();
                M_uc_Sum._ModelTotal = this.M_ModelTotal;
                M_uc_Sum.ReadTotal();
                M_uc_Sum.btnZeroSum += new FormSet.ucSetSum.BtnClick(M_uc_Sum_btnZeroClick);
                M_uc_Sum._Section = M_str_CurrentConfig;
                this.palContent.Controls.Add(M_uc_Sum);
            }
            M_uc_Sum._Section = M_str_CurrentConfig;
            M_uc_Sum.ReadSet(M_str_CurrentConfig);
            M_uc_Sum._ModelTotal = this.M_ModelTotal;
            M_uc_Sum.ReadTotal();
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
            ZeroTotal();
            M_uc_Sum.ReadTotal();
        }

        /// <summary>
        /// 清0
        /// </summary>
        private void ZeroTotal()
        {
            M_ModelTotal.TotalTime = 0;
            M_ModelTotal.TotalRP = 0;
            M_ModelTotal.TotalBP = 0;
            M_ModelTotal.TotalFP = 0;
            M_ModelTotal.TotalSP = 0;
            M_ModelTotal.TotalDP = 0;
            M_int_TreatCount = 0;
            m_isUptoBP = m_isUptoDP = m_isUptoFP = m_isUptoRP = m_isUptoSP = m_isUptoTime = false;
        }

        private void tsbtnLevel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(M_str_CurrentConfig))
            {
                MessageBox.Show("请确认治疗模式!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (M_uc_SetLiquidSurface == null)
            {
                M_uc_SetLiquidSurface = new FormSet.ucSetLiquidSurface();
                M_uc_SetLiquidSurface._ModelWarn = Cls.utils.GetModelWarn(M_str_CurrentConfig);
                M_uc_SetLiquidSurface._Port_main = port_main;
                M_uc_SetLiquidSurface.chkChanged += new FormSet.ucSetLiquidSurface.CheckChanged(M_uc_SetLiquidSurface_chkChanged);
                this.palContent.Controls.Add(M_uc_SetLiquidSurface);
                M_uc_SetLiquidSurface._ModelWarn = Cls.utils.GetModelWarn(M_str_CurrentConfig);
                M_uc_SetLiquidSurface.BringToFront();
                M_uc_SetLiquidSurface.Dock = DockStyle.Fill;
            }

            M_uc_SetLiquidSurface._ModelWarn = Cls.utils.GetModelWarn(M_str_CurrentConfig);
            this.palContent.Controls.SetChildIndex(M_uc_SetLiquidSurface, 0);
            M_uc_SetLiquidSurface.BringToFront();
            M_uc_SetLiquidSurface.Dock = DockStyle.Fill;

        }

        void M_uc_SetLiquidSurface_chkChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            switch (cb.Tag.ToString())
            {
                case "1up":
                    if (cb.Checked)
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Up);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Up);

                        cb.Text = "停止";
                        cb.Image = Properties.Resources.stop64;
                    }
                    else
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopUp);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopUp);

                        cb.Text = "上升";
                        cb.Image = Properties.Resources.up_64;
                    }
                    break;
                case "1down":
                    if (cb.Checked)
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Down);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1Down);
                        //{
                        cb.Text = "停止";
                        cb.Image = Properties.Resources.stop64;
                        //}
                    }
                    else
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopDown);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel1StopDown);
                        //{
                        cb.Text = "下降";
                        cb.Image = Properties.Resources.down_64;
                        //}
                    }
                    break;

                case "2up":
                    if (cb.Checked)
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Up);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Up);
                        //{
                        cb.Text = "停止";
                        cb.Image = Properties.Resources.stop64;
                        //}
                    }
                    else
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopUp);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopUp);

                        //{
                        cb.Text = "上升";
                        cb.Image = Properties.Resources.up_64;
                        //}
                    }
                    break;
                case "2down":
                    if (cb.Checked)
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Down);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2Down);
                        //{
                        cb.Text = "停止";
                        cb.Image = Properties.Resources.stop64;
                        //}
                    }
                    else
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopDown);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel2StopDown);
                        //{
                        cb.Text = "下降";
                        cb.Image = Properties.Resources.down_64;
                        //}
                    }
                    break;

                case "3up":
                    if (cb.Checked)
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Up);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Up);
                        //{
                        cb.Text = "停止";
                        cb.Image = Properties.Resources.stop64;
                        //}
                    }
                    else
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopUp);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopUp);
                        //{
                        cb.Text = "上升";
                        cb.Image = Properties.Resources.up_64;
                        //}
                    }
                    break;

                case "3down":
                    if (cb.Checked)
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Down);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3Down);
                        //{
                        cb.Text = "停止";
                        cb.Image = Properties.Resources.stop64;
                        //}
                    }
                    else
                    {
                        //SendOrder(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopDown);
                        SendOrderBack(port_main, Cls.Comm_Main.LiquidLevel.liquidLevel3StopDown);
                        //{
                        cb.Text = "下降";
                        cb.Image = Properties.Resources.down_64;
                        //}
                    }
                    break;
            }
            //throw new NotImplementedException();
        }

        private void Exit()
        {
            m_frmExit = new frmExit();
            m_frmExit.TopMost = true;
            m_frmExit.Show();
            if (!M_bwExit.IsBusy)
                M_bwExit.RunWorkerAsync();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            M_isTreat = !M_isTreat;
            if (M_isTreat)
            {
                tsbtnTherapy_Click(tsbtnTherapy, e);
                toolStripControl_ItemClicked(toolStripControl, new ToolStripItemClickedEventArgs(tsbtnTherapy));
                this.toolStripControl.Enabled = false;
                //其他界面按钮状态改变
                this.btnStart.Enabled = false;
                if (M_bwStartTreat.IsBusy != true)
                    M_bwStartTreat.RunWorkerAsync();
            }
            else
            {
                this.btnStart.Enabled = false;
                this.toolStripControl.Enabled = false;
                this.timerStartTreat.Enabled = false;
                this.timerStartTreat.Stop();
                if (M_bwStopTreat.IsBusy != true)
                    M_bwStopTreat.RunWorkerAsync();
            }
        }

        private void toolStripControl_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem tsi in this.toolStripControl.Items)
            {
                if (tsi.Tag == null)
                {
                    tsi.ForeColor = Color.FromArgb(15, 8, 100);
                    tsi.BackgroundImage = global::ALS.Properties.Resources.buttonface;
                }
            }
            e.ClickedItem.ForeColor = Color.White;
            e.ClickedItem.BackgroundImage = global::ALS.Properties.Resources.buttonfacesel;
        }

        private void toolStripOther_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Tag.ToString())
            {
                case "sp":
                    break;
                case "ld":
                    m_isOpenBloodleak = !m_isOpenBloodleak;
                    //if (m_isOpenBloodleak)
                    //{
                    //    SendOrder(port_main, Cls.Comm_Main.CmdBloodLeak.OpenBloodLeak);
                    //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdBloodLeak.OpenBloodLeak))
                    //        tsbtnLD.Image = Properties.Resources.ldon;
                    //}
                    //else
                    //{
                    //    SendOrder(port_main, Cls.Comm_Main.CmdBloodLeak.CloseBloodLeak);
                    //    if (SendOrderBack(port_main, Cls.Comm_Main.CmdBloodLeak.CloseBloodLeak))
                    //        tsbtnLD.Image = Properties.Resources.ldoff;
                    //}
                    break;
                case "ad1":
                    m_isOpenBubble1 = !m_isOpenBubble1;
                    if (m_isOpenBubble1)
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble1);
                        //if (SendOrderBack(port_main, Cls.Comm_Main.CmdBubble.OpenBubble1))
                        //{
                        //    tsbtnAD1.Image = Properties.Resources.AD1;
                        //    tsbtnAD1.Text = "气泡检测1开";
                        //}
                    }
                    else
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble1);
                        //if (SendOrderBack(port_main, Cls.Comm_Main.CmdBubble.CloseBubble1))
                        //{
                        //    tsbtnAD1.Image = Properties.Resources.AD1Off;
                        //    tsbtnAD1.Text = "气泡检测1关";
                        //}
                    }
                    break;
                case "ad2":
                    m_isOpenBubble2 = !m_isOpenBubble2;
                    if (m_isOpenBubble2)
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble2);
                        //if (SendOrderBack(port_main, Cls.Comm_Main.CmdBubble.OpenBubble2))
                        //{
                        //    tsbtnAD2.Image = Properties.Resources.AD2;
                        //    tsbtnAD2.Text = "气泡检测2开";
                        //}
                    }
                    else
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble2);
                        //if (SendOrderBack(port_main, Cls.Comm_Main.CmdBubble.CloseBubble2))
                        //{
                        //    tsbtnAD2.Image = Properties.Resources.AD2Off;
                        //    tsbtnAD2.Text = "气泡检测2关";
                        //}
                    }
                    break;
                case "ad3":
                    m_isOpenBubble3 = !m_isOpenBubble3;
                    if (m_isOpenBubble3)
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.OpenBubble3);
                        //if (SendOrderBack(port_main, Cls.Comm_Main.CmdBubble.OpenBubble3))
                        //{
                        //    tsbtnAD3.Image = Properties.Resources.AD3;
                        //    tsbtnAD3.Text = "气泡检测3开";
                        //}
                    }
                    else
                    {
                        SendOrder(port_main, Cls.Comm_Main.CmdBubble.CloseBubble3);
                        //if (SendOrderBack(port_main, Cls.Comm_Main.CmdBubble.CloseBubble3))
                        //{
                        //    tsbtnAD3.Image = Properties.Resources.AD3Off;
                        //    tsbtnAD3.Text = "气泡检测3关";
                        //}
                    }
                    break;
                case "ht":
                    break;
            }
        }

        private void tsbtnAD2_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnAD1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Cls.utils.CreateMethodConfig("PEConfig", "PE", "0");
            //Cls.utils.CreateMethodConfig("Li-ALSConfig", "李氏人工肝", "1");
            //Cls.utils.CreateMethodConfig("PPConfig", "PP", "2");
            //Cls.utils.CreateMethodConfig("HPConfig", "HP", "3");
            //Cls.utils.CreateMethodConfig("HDFConfig", "HDF", "4");
            //Cls.utils.CreateMethodConfig("ManualConfig", "手动", "5");
            //Cls.utils.CreateMethodConfig("PDFConfig", "PDF", "6");
            //AutoFlush.af_PE afpe = new AutoFlush.af_PE();
            //this.palContent.Controls.Add(afpe);
            //afpe.BringToFront(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (Cls.utils.SetSectionKeyValue("PEConfig", "BPSpeed", "350"))
            //    MessageBox.Show("True");
            //MessageBox.Show(Cls.utils.GetSectionKeyValue("PEConfig", "BPSpeed"));
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tsbtnSP_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnHT_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnAD3_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnLD_Click(object sender, EventArgs e)
        {

        }

        Manager.frmAdmin m_frmfa;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            m_frmfa = new Manager.frmAdmin();
            m_frmfa._Port_hpump = this.port_hpump;
            m_frmfa._Port_main = this.port_main;
            m_frmfa._Port_ppump = this.port_ppump;
            m_frmfa.ShowDialog();
            LoadWeighPara();
        }

        int m_timerTreatCount;
        private void timerStartTreat_Tick(object sender, EventArgs e)
        {
            m_timerTreatCount++;
            if (m_timerTreatCount < 20 && M_uc_Therapy != null)//240
            {
                M_uc_Therapy.lblTotalTime.Text = Cls.utils.SecondsToTime(m_timerTreatCount);
                lblBloodSpeed.Enabled = false;
                M_uc_Therapy.lblt.Text = "引血\r\n(4Min):";
                lblRunning.Text = "引血中";
            }
            //血泵速度从40ml/min 上升至设定的 SpeedBP,时间为 4Min 左右，m_timerTreatCount的值最大为 60*4=240;
            //4分钟240秒内分10个加速点,m_timerTreatCount的点为 24 的整数倍
            //设定的速度 (SpeedBP - 40) / 10 ，每段加速提高的速度值
            //如果是暂停后开始，开始就直接是设定的 SpeedBP。
            int k = m_timerTreatCount / 2;//24
            double addSpeed = (M_ModelSetRun.SpeedBP - 40) / 10.0;
            if (m_timerTreatCount == 1)
            {
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 40, true, M_ModelSetRun.BPDirection));
            }

            if (m_timerTreatCount % 2 == 0 && m_timerTreatCount >= 2)//24
            {
                SendOrder(port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 40 + addSpeed * k, true, M_ModelSetRun.BPDirection));
            }
            //待血泵速度升至SpeedBP时,再运转以下泵，timer停止；
            if (m_timerTreatCount >= 20)//240
            {
                timerStartTreat.Enabled = false;
                timerStartTreat.Stop();
                this.lblRunning.Text = "治疗中";
                M_uc_Therapy.lblt.Text = "治疗时间:";
                lblBloodSpeed.Enabled = true;
                this.lblBloodSpeed.Text = M_ModelSetRun.SpeedBP.ToString("f0");
                if (!M_bwStartPump.IsBusy)
                    M_bwStartPump.RunWorkerAsync(); 
                //累计及报警线程
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Thread.CurrentThread.Priority = ThreadPriority.Normal;
                    while (M_isTreat)
                    {
                        Thread.Sleep(500);
                        BeginInvoke(new Action(() =>
                        {
                            threadTreat();
                        }));
                    }
                }
                ).Start();
                //M_timer_Treat.Enabled = true;
                //M_timer_Treat.Start();
                M_isFlowBlood = false;
            }
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
    }
}