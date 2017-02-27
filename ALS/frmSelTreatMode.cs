using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace ALS
{
    public partial class frmSelTreatMode : Form
    {
        //启动splash窗口 
        //初始化串口参数
        //预载数据库信息
        //初始化设备 
        Cls.ssf ssf = new Cls.ssf();
        private SerialPort port_main = new SerialPort();
        private SerialPort port_data = new SerialPort();
        private SerialPort port_hpump = new SerialPort();
        private SerialPort port_ppump = new SerialPort();

        frmMain m_frmMain = new frmMain();
        //预载数据库报警编码与内容
        List<Cls.Model_ShowWarn> m_lstShowWarn;
        bool M_Closing_main = false;
        bool M_Listening_main = false;
        List<byte> M_buffer_main = new List<byte>();

        Cls.utils.M_SendType m_checkType = Cls.utils.M_SendType.NoResult;
        List<Cls.utils.M_SendType> M_lstSendType = new List<Cls.utils.M_SendType>();

        CancellationTokenSource m_ctsCancelLoad;
        Task m_tskLoadSystem;
        private string m_methodName;

        public frmSelTreatMode()
        {
            this.Hide();
            InitializeComponent();
        }

        public void DoStartProgress()
        {
            var progress = new Progress<Cls.StatusProgress>();
            progress.ProgressChanged += progress_ProgressChanged;
            m_ctsCancelLoad = new CancellationTokenSource();
            m_tskLoadSystem = LoadSystem(progress, m_ctsCancelLoad.Token);
        }

        void progress_ProgressChanged(object sender, Cls.StatusProgress e)
        {
            ssf.progressBar1.Value = e.Current;
            M_lstSendType.Add(e._sendType);
            //判断启动过程 Test
            if (M_lstSendType.Contains(Cls.utils.M_SendType.databasefalse))
            {
                ssf.btnExit.Enabled = true;
                ssf.btnExit.Visible = true;
                ssf.rtBox.Visible = true;
                ssf.rtBox.Text = "启动错误:数据库连接失败!";
                ssf.rtBox.SelectionColor = Color.Red;
                m_ctsCancelLoad.Cancel();
                return;
            }

            if (M_lstSendType.Contains(Cls.utils.M_SendType.portfalse))
            {
                ssf.btnExit.Enabled = true;
                ssf.btnExit.Visible = true;
                ssf.rtBox.Visible = true;
                ssf.rtBox.Text = "启动错误:初始化通讯端口失败!";
                ssf.rtBox.SelectionColor = Color.Red;
                m_ctsCancelLoad.Cancel();
                return;
            }
            if (M_lstSendType.Contains(Cls.utils.M_SendType.vfalse))
            {
                ssf.btnExit.Enabled = true;
                ssf.btnExit.Visible = true;
                ssf.rtBox.Visible = true;
                ssf.rtBox.Text = "启动错误:夹管阀故障!";
                ssf.rtBox.SelectionColor = Color.Red;
                m_ctsCancelLoad.Cancel();
                return;
            }
            if (M_lstSendType.Contains(Cls.utils.M_SendType.NoResult))
            {
                ssf.btnExit.Enabled = true;
                ssf.btnExit.Visible = true;
                ssf.rtBox.Visible = true;
                ssf.rtBox.Text = "启动错误:硬件无响应!";
                ssf.rtBox.SelectionColor = Color.Red;
                m_ctsCancelLoad.Cancel();
                return;
            }

            if (e.Current == 100)
            {
                if (M_lstSendType.Contains(Cls.utils.M_SendType.databasefalse) ||
                    M_lstSendType.Contains(Cls.utils.M_SendType.bubblefalse) ||
                    M_lstSendType.Contains(Cls.utils.M_SendType.portfalse) ||
                    M_lstSendType.Contains(Cls.utils.M_SendType.pumpfalse) ||
                    M_lstSendType.Contains(Cls.utils.M_SendType.vfalse) ||
                    M_lstSendType.Contains(Cls.utils.M_SendType.vlfalse) ||
                    M_lstSendType.Contains(Cls.utils.M_SendType.NoResult))
                    return;
                else
                {
                    ssf.Hide();
                    this.Show();
                    this.Activate();
                    this.MaximizedBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void frmSelTreatMode_Load(object sender, EventArgs e)
        { 
            m_methodName = "Li-ALS";
            //创建传输文档
            string pah = @"D:/surgeryData.txt";
            //FileStream fs = new FileStream(pah, FileMode.OpenOrCreate); 
            //fs.Flush();
            //fs.Close();
            if (!File.Exists(pah))
                File.CreateText(pah);
            else//清空
                File.WriteAllText(pah,string.Empty);  
            DoStartProgress();
        }
        async Task LoadSystem(IProgress<Cls.StatusProgress> progress, CancellationToken ct)
        {
            ssf.Show();
            ssf.TopMost = true;
            ssf._Exit += ssf__Exit;
            int total = 100;
            string tipinfo;
            if (LoadShowWarn(out tipinfo))
                progress.Report(new Cls.StatusProgress() { Tipinfo = tipinfo, Current = 5, Total = total, Success = true, _sendType = Cls.utils.M_SendType.databasetrue });
            else
            {
                progress.Report(new Cls.StatusProgress() { Tipinfo = tipinfo, Current = 5, Total = total, Success = false, _sendType = Cls.utils.M_SendType.databasefalse });
                m_ctsCancelLoad.Cancel();
            }
            //主控COM1    波特率19200 数据位8 停止位1 偶校验
            //注射泵COM2  波特率19200 数据位8 停止位1 无校验
            //蠕动COM3    波特率1200 数据位8 停止位1 偶校验
            //称重COM4    波特率9600 数据位8 停止位1 无校验
            //温控COM5    波特率9600 数据位8 停止位1 无校验

            //初始化串口1 串口设置：  COM1(暂定) 波特率19200 数据位8位 停止位1位 偶校验 
            if (await InitComm(this.port_main, "COM1", 19200, 8, StopBits.One, Parity.Even, ct) == Cls.utils.M_SendType.porttrue)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 10, Total = total, Success = true, _sendType = Cls.utils.M_SendType.porttrue });
            else
            {
                progress.Report(new Cls.StatusProgress() { Tipinfo = "主控板失败", Current = 10, Total = total, Success = false, _sendType = Cls.utils.M_SendType.portfalse });
                m_ctsCancelLoad.Cancel();
            }
            port_main.DataReceived += port_main_DataReceived;
            //初始化注射泵串口  COM2 波特率19200 数据位8位 停止位1位 无奇偶校验 
            //Test
            if (await InitComm(this.port_hpump, "COM2", 19200, 8, StopBits.One, Parity.None, ct) == Cls.utils.M_SendType.porttrue)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 12, Total = total, Success = true, _sendType = Cls.utils.M_SendType.porttrue });
            else
            {
                progress.Report(new Cls.StatusProgress() { Tipinfo = "抗凝剂泵失败", Current = 12, Total = total, Success = false, _sendType = Cls.utils.M_SendType.portfalse });
                m_ctsCancelLoad.Cancel();
            }
            await Task.Delay(200);
            //初始化蠕动泵串口 COM3 波特率19200 数据位8位 停止位1位 偶校验
            if (await InitComm(this.port_ppump, "COM3", 1200, 8, StopBits.One, Parity.Even, ct) == Cls.utils.M_SendType.porttrue)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 15, Total = total, Success = true, _sendType = Cls.utils.M_SendType.porttrue });
            else
            {
                progress.Report(new Cls.StatusProgress() { Tipinfo = "蠕动泵失败", Current = 15, Total = total, Success = false, _sendType = Cls.utils.M_SendType.portfalse });
                m_ctsCancelLoad.Cancel();
            }
            //port_ppump.DataReceived += new SerialDataReceivedEventHandler(port_ppump_DataReceived);

            if (await InitComm(this.port_data, "COM4", 19200, 8, StopBits.One, Parity.Even, ct) == Cls.utils.M_SendType.porttrue)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 20, Total = total, Success = true, _sendType = Cls.utils.M_SendType.porttrue });
            else
            {
                progress.Report(new Cls.StatusProgress() { Tipinfo = "数据端口失败", Current = 20, Total = total, Success = false, _sendType = Cls.utils.M_SendType.portfalse });
                m_ctsCancelLoad.Cancel();
            }
            //if (InitComm(this.port_pumpstatus, "COM5", 19200, 8, StopBits.One, Parity.Even))
            //    progress.Report(new Cls.StatusProgress() { Tipinfo = "泵状态监测端口成功", Current = 75, Total = total, Success = true });
            //else
            //{
            //    progress.Report(new Cls.StatusProgress() { Tipinfo = "泵状态监测端口失败", Current = 75, Total = total, Success = false });
            //    return;
            //}
            //port_pumpstatus.DataReceived += port_pumpstatus_DataReceived;
            //await Task.Delay(200);
            //自检命令
            //绿灯闪
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdAlarmLamp.YellowTwinkle, ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 25, Total = total, Success = true, _sendType = m_checkType });
            await Task.Delay(1000);
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdAlarmLamp.RedTwinkle, ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 30, Total = total, Success = true, _sendType = m_checkType });
            await Task.Delay(1000);
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdAlarmLamp.GreenAlways, ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 35, Total = total, Success = true, _sendType = m_checkType });
            //夹管阀1松开 
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x01, 0x01, 0x01, 0x01, 0x01), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 40, Total = total, Success = true, _sendType = m_checkType });

            //夹管阀2松开 
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x01, 0x01, 0x01, 0x01), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 45, Total = total, Success = true, _sendType = m_checkType });

            //夹管阀3松开 
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x01, 0x01, 0x01), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 50, Total = total, Success = true, _sendType = m_checkType });

            //夹管阀4松开
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x00, 0x01, 0x01), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 54, Total = total, Success = true, _sendType = m_checkType });

            //夹管阀5松开
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x00, 0x00, 0x01), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 58, Total = total, Success = true, _sendType = m_checkType });

            //夹管阀6松开
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdValve.SetVState(0x00, 0x00, 0x00, 0x00, 0x00, 0x00), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 60, Total = total, Success = true, _sendType = m_checkType });

            //夹管阀全闭合
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdValve.SetVState(0x01, 0x01, 0x01, 0x01, 0x01, 0x01), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 64, Total = total, Success = true, _sendType = m_checkType });

            //泵1运转
            await ReturnResult(this.port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 100, true, true), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 68, Total = total, Success = true, _sendType = m_checkType });

            //泵2运转
            await ReturnResult(this.port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 100, true, true), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 72, Total = total, Success = true, _sendType = m_checkType });

            //泵3运转
            await ReturnResult(this.port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 100, true, false), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 76, Total = total, Success = true, _sendType = m_checkType });

            if (progress != null)     //泵4运转
                await ReturnResult(this.port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 100, true, false), ct);
            progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 80, Total = total, Success = true, _sendType = m_checkType });

            //泵5运转
            await ReturnResult(this.port_ppump, Cls.Comm_PeristalticPump.Command(0x05, 100, true, false), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 84, Total = total, Success = true, _sendType = m_checkType });

            //泵6运转
            await ReturnResult(this.port_ppump, Cls.Comm_PeristalticPump.Command(0x06, 100, true, true), ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 88, Total = total, Success = true, _sendType = m_checkType });

            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 90, Total = total, Success = true, _sendType = m_checkType });
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdBubble.CloseBubble1, ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 92, Total = total, Success = true, _sendType = m_checkType });

            await ReturnResult(this.port_main, Cls.Comm_Main.CmdBubble.CloseBubble2, ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 96, Total = total, Success = true, _sendType = m_checkType });
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdBubble.CloseBubble3, ct);
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 98, Total = total, Success = true, _sendType = m_checkType });
            await ReturnResult(this.port_main, Cls.Comm_Main.CmdAlarmLamp.GreenAlways, ct);
            //泵停
            await ReturnResult(this.port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true), ct);
            //---------------------------------------------------------------------------------------
            //M_portMainReader = new Cls.ReadMainComm.CommReader(port_main, 100);
            //M_portMainReader.Handlers += new Cls.ReadMainComm.CommReader.HandleCommData(portMainReader_Handlers);
            //M_portMainReader.Start(); 
            //注销事件
            port_main.DataReceived -= port_main_DataReceived;
            if (progress != null)
                progress.Report(new Cls.StatusProgress() { Tipinfo = "·", Current = 100, Total = total, Success = true, _sendType = m_checkType });

            //StringBuilder sb = new StringBuilder();
            //foreach (var v in M_lstSendType)
            //{
            //    sb.Append(v.ToString() + ",");
            //}
            //MessageBox.Show(sb.ToString());
        }

        void ssf__Exit(object sender, EventArgs e)
        {
            if (port_ppump.IsOpen)
                SendOrderExit(this.port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
            if (port_main.IsOpen)
            {
                SendOrderExit(this.port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose);
                SendOrderExit(this.port_main, Cls.Comm_Main.CmdValve.SetVState(0x01, 0x01, 0x01, 0x01, 0x01, 0x01));
            }
            Application.ExitThread();
            Application.Exit();
        }

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
                                case 0xB1:
                                    //夹管阀状态
                                    if (M_buffer_main[3] == 0x03 ||
                                        M_buffer_main[4] == 0x03 ||
                                        M_buffer_main[5] == 0x03 ||
                                        M_buffer_main[6] == 0x03 ||
                                        M_buffer_main[7] == 0x03 ||
                                        M_buffer_main[8] == 0x03)
                                        m_checkType = Cls.utils.M_SendType.vfalse;
                                    else
                                        m_checkType = Cls.utils.M_SendType.vtrue;
                                    break;
                                #endregion
                                #region 声光
                                case 0xA1:
                                    m_checkType = Cls.utils.M_SendType.vltrue;
                                    break;
                                #endregion

                                #region 气泡检测
                                //气泡检测1开启	FF F1 00 0E ED
                                case 0xF1:
                                    m_checkType = Cls.utils.M_SendType.bubbletrue;
                                    break;
                                //气泡检测1报警 FF 1F 00 E1 ED 
                                case 0x1F:
                                    m_checkType = Cls.utils.M_SendType.bubbletrue;
                                    break;
                                //气泡检测1关闭	FF F2 00 0D ED
                                case 0xF2:
                                    m_checkType = Cls.utils.M_SendType.bubbletrue;
                                    break;
                                //气泡检测2开启	FF F3 00 0C ED
                                case 0xF3:
                                    m_checkType = Cls.utils.M_SendType.bubbletrue;
                                    break;
                                //气泡检测2报警		FF 2F 00 D1 ED
                                case 0x2F:
                                    m_checkType = Cls.utils.M_SendType.bubbletrue;
                                    break;
                                //气泡检测2关闭 FF F4 00 0B ED
                                case 0xF4:
                                    m_checkType = Cls.utils.M_SendType.bubbletrue;
                                    break;
                                //气泡检测3开启	FF F5 00 0A ED
                                case 0xF5:
                                    m_checkType = Cls.utils.M_SendType.bubbletrue;
                                    break;
                                //气泡检测3报警		FF 3F 00 C1 ED   
                                case 0x3F:
                                    m_checkType = Cls.utils.M_SendType.bubbletrue;
                                    break;
                                //气泡检测3关闭 FF F6 00 09 ED
                                case 0xF6:
                                    m_checkType = Cls.utils.M_SendType.bubbletrue;
                                    break;
                                #endregion
                                #region  加热系统
                                //启动加热系统	FF EE 00 11 ED
                                //停止加热系统	FF EF 00 10 ED
                                case 0xEE:

                                    break;
                                case 0xEF:

                                    break;
                                #endregion
                                #region 血泵旋钮调速
                                //顺时针转动		FF 0A 00 F5 ED
                                //逆时针转动		FF 1A 00 E5 ED
                                case 0x0A://顺时针存储1 
                                    //#if LOG_MAINPORT_DATARECEIVE
                                    //                                    getLog.WriteLogFile("clockwise:1 count:" + m_lstCircleDirection.Count.ToString());
                                    //#endif
                                    break;
                                case 0x1A://逆时针存储0
                                    //#if LOG_MAINPORT_DATARECEIVE
                                    //                                    getLog.WriteLogFile("counterclockwise:0 count" + m_lstCircleDirection.Count.ToString());
                                    //#endif
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



        async Task<Cls.utils.M_SendType> InitComm(SerialPort _sp, string _name, int _baudrate, int _databits, System.IO.Ports.StopBits _stopbits, System.IO.Ports.Parity _parity, CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
            {
                return Cls.utils.M_SendType.portfalse;
            }
            else
            {
                if (_sp.IsOpen)
                {
                    _sp.Close();
                }
                await Task.Delay(300);
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
                try { _sp.Open(); return Cls.utils.M_SendType.porttrue;}
                catch { m_ctsCancelLoad.Cancel(); return Cls.utils.M_SendType.portfalse; }
            }
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

        private void frmSelTreatMode_SizeChanged(object sender, EventArgs e)
        {
            //this.palMethod.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.palMethod.Width) / 2;
            //this.palMethod.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.palMethod.Height) / 2;
            this.palLiALS.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.palLiALS.Width) / 2;
            this.palLiALS.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.palLiALS.Height) / 2;
        }

        private void btnLi_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag != null)
            {
                string tag = btn.Tag.ToString();
                string tip = tag;
                if (tip == "PERT")
                    tip = "PEF";
                Bitmap binfo = null;
                switch (tag)
                {
                    case "PE": binfo = global::ALS.Properties.Resources.PE;
                        break;
                    case "Li-ALS": binfo = global::ALS.Properties.Resources.lials;
                        break;
                    case "CHDF": binfo = global::ALS.Properties.Resources.CHDF;
                        break;
                    case "PERT": binfo = global::ALS.Properties.Resources.PERT;
                        break;
                    case "PDF": binfo = global::ALS.Properties.Resources.PDF;
                        break;
                    case "PP": binfo = global::ALS.Properties.Resources.PP;
                        break;
                }
                UserCtrl.MsgBox m = new UserCtrl.MsgBox("确认选择： " + tip + "？", UserCtrl.MsgBox.MSBoxIcon.Question, binfo, true);
                if (DialogResult.OK == m.ShowDialog())
                {
                    m_frmMain._ModeName = tag;
                    m_frmMain.Port_data = port_data;
                    m_frmMain.Port_hpump = port_hpump;
                    m_frmMain.Port_main = port_main;
                    m_frmMain.Port_ppump = port_ppump;
                    m_frmMain.LstShowWarn = m_lstShowWarn;
                    m_frmMain.ShowDialog();
                }
            }
        }


        async Task<Cls.utils.M_SendType> SendOrder(SerialPort _sp, byte[] _order)
        {
            try
            {
                if (_sp.IsOpen)
                {
                    m_checkType = Cls.utils.M_SendType.NoResult;
                    if (_sp.PortName.ToLower() == "com3")
                        m_checkType = Cls.utils.M_SendType.pumptrue;
                    _sp.DiscardOutBuffer();
                    _sp.Write(_order, 0, _order.Length);
                    await Task.Delay(1000);//Test
                    return m_checkType;
                }
                else
                    return Cls.utils.M_SendType.portfalse;

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
                return Cls.utils.M_SendType.portfalse;
            }
        }

        async Task<Cls.utils.M_SendType> ReturnResult(SerialPort _sp, byte[] _order, CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
            {
                return m_checkType;
            }
            else
            {
                m_checkType = await SendOrder(_sp, _order);
                if (m_checkType == Cls.utils.M_SendType.NoResult)
                    m_checkType = await SendOrder(_sp, _order);
                M_lstSendType.Add(m_checkType);
                return m_checkType;
            }
        }

        private void SendOrderExit(SerialPort _sp, byte[] _order)
        {
            try
            {
                if (_sp.IsOpen)
                {
                    Thread.Sleep(200);
                    _sp.DiscardOutBuffer();
                    _sp.Write(_order, 0, _order.Length);
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
        private void btnMin_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("确认退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                if (port_ppump.IsOpen)
                    SendOrderExit(this.port_ppump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                if (port_main.IsOpen)
                {
                    SendOrderExit(this.port_main, Cls.Comm_Main.CmdAlarmLamp.AllLightClose);
                    SendOrderExit(this.port_main, Cls.Comm_Main.CmdValve.SetVState(0x01, 0x01, 0x01, 0x01, 0x01, 0x01));
                }
                Application.ExitThread();
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CCWin.MessageBoxForm c = new CCWin.MessageBoxForm();
            c.ShowDrawIcon = true;
            c.ShowIcon = true;
            c.Show();
        }

        private void btnLiALS_Click(object sender, EventArgs e)
        {
            string tag = m_methodName;
            string tip = tag;
            if (tip == "PERT")
                tip = "PEF";
            Bitmap binfo = null;
            switch (tag)
            {
                case "PE": binfo = global::ALS.Properties.Resources.PE;
                    break;
                case "Li-ALS": binfo = global::ALS.Properties.Resources.lials;
                    break;
                case "CHDF": binfo = global::ALS.Properties.Resources.CHDF;
                    break;
                case "PERT": binfo = global::ALS.Properties.Resources.PERT;
                    break;
                case "PDF": binfo = global::ALS.Properties.Resources.PDF;
                    break;
                case "PP": binfo = global::ALS.Properties.Resources.PP;
                    break;
            }
            UserCtrl.MsgBox m = new UserCtrl.MsgBox("确认选择：李氏人工肝( " + tip + " )？确认后将不可更改！", UserCtrl.MsgBox.MSBoxIcon.Question, binfo, true);
            if (DialogResult.OK == m.ShowDialog())
            {
                m_frmMain._ModeName = tag;
                m_frmMain.Port_data = port_data;
                m_frmMain.Port_hpump = port_hpump;
                m_frmMain.Port_main = port_main;
                m_frmMain.Port_ppump = port_ppump;
                m_frmMain.LstShowWarn = m_lstShowWarn; 
                m_frmMain.ShowDialog(); 
            }
        }

        private void btnPatientInfo_Click(object sender, EventArgs e)
        {
           
            frmSetMethod fsm = new frmSetMethod();
            if (DialogResult.OK == fsm.ShowDialog())
            {
                m_methodName = fsm._Method;              
            }
        }
    }
}
