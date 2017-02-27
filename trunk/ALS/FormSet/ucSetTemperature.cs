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
namespace ALS.FormSet
{
    public partial class ucSetTemperature : UserControl
    {
        private SerialPort _port_Temperature;
        /// <summary>
        /// 温控通讯端口
        /// </summary>
        public SerialPort _Port_Temperature
        {
            get { return _port_Temperature; }
            set { _port_Temperature = value; }
        }

        private SerialPort _port_Weigh;
        /// <summary>
        /// 称重通讯端口
        /// </summary>
        public SerialPort _Port_Weigh
        {
            get { return _port_Weigh; }
            set { _port_Weigh = value; }
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

        private bool _sendSuccess;
        /// <summary>
        /// 夹管阀命令是否发送成功
        /// </summary>
        public bool _SendSuccess
        {
            get { return _sendSuccess; }
            set { _sendSuccess = value; }
        }

        string _section;
        public string _Section
        {
            get { return _section; }
            set { _section = value; }
        }

        public delegate void btnSetT(object sender, EventArgs e);
        public event btnSetT btnSett;

        //串口接收委托
        public delegate void _Port_main_DataReceived(object sender, SerialDataReceivedEventArgs e);
        public event _Port_main_DataReceived _port_m_datareceived;

        public ucSetTemperature()
        {
            InitializeComponent();
        }

        bool blClip1, blClip2, blClip3, blClip4,blClip5,blClip6,blClip7;
        private void lblTemper_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);

            if (DialogResult.OK == _numPad.ShowDialog())
            {
                if (_numPad.Value < 33 || _numPad.Value > 40)
                {
                    MessageBox.Show("设置超出范围,请重新设置!");                    
                    return;
                }
                lbl.Text = _numPad.Value.ToString("f1"); 
            }
        }

        private void ucSetTemperature_SizeChanged(object sender, EventArgs e)
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

        private void btnClip1_Click(object sender, EventArgs e)
        {
            blClip1 = !blClip1;
            //改变状态
            if (blClip1)
            {
                //发送关闭夹管阀1命令
                btnClip1.Text = "松开";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV1);
                Thread.Sleep(20);
                pBox1.Image = Properties.Resources.clip1close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip1.Text = "闭合";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV1);
                Thread.Sleep(20);
                pBox1.Image = Properties.Resources.clip1;
            }
        }

        private void btnClip2_Click(object sender, EventArgs e)
        {

            blClip2 = !blClip2;
            //改变状态
            if (blClip2)
            {
                //发送关闭夹管阀1命令
                btnClip2.Text = "松开";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV2);
                Thread.Sleep(20);
                pBox2.Image = Properties.Resources.clip2close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip2.Text = "闭合";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV2);
                Thread.Sleep(20);
                pBox2.Image = Properties.Resources.clip2;
            }
        }

        private void btnClip3_Click(object sender, EventArgs e)
        {
            blClip3 = !blClip3;
            //改变状态
            if (blClip3)
            {
                //发送关闭夹管阀1命令
                btnClip3.Text = "松开";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV3);
                Thread.Sleep(20);
                pBox3.Image = Properties.Resources.clip3close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip3.Text = "闭合";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV3);
                Thread.Sleep(20);
                pBox3.Image = Properties.Resources.clip3;
            }
        }

        private void btnClip4_Click(object sender, EventArgs e)
        {
            blClip4 = !blClip4;
            //改变状态
            if (blClip4)
            {
                //发送关闭夹管阀1命令
                btnClip4.Text = "松开";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV4);
                Thread.Sleep(20);
                pBox4.Image = Properties.Resources.clip4close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip4.Text = "闭合";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV4);
                Thread.Sleep(20);
                pBox4.Image = Properties.Resources.clip4;
            }
        }

        private void btnSetTemperature_Click(object sender, EventArgs e)
        {
            //33-40度范围
            try
            {
                if (btnSett != null)
                    btnSett(sender, e);
                double realc = Convert.ToDouble(this.lblTargetT.Text);
                //Cls.RWconfig.SetAppSettings("TargetT", this.lblTargetT.Text);
                if (Cls.utils.SetSectionKeyValue(_section, "TargetT", this.lblTargetT.Text))
                {
                    byte val = Convert.ToByte(Cls.utils.GetSectionKeyValue(_section,"TargetT"));
                    this.lblTargetT.Text = val.ToString("f0");                    
                    //发送设置温度命令 现有的温控表ID为  0x0A 
                    Cls.utils.SendOrder(_port_Temperature, Cls.Comm_Main.CmdTemperature.StartHT(val));
                    MessageBox.Show("设置成功"); 
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ucSetTemperature_Load(object sender, EventArgs e)
        {
            this.lblTargetT.Text = Cls.utils.GetSectionKeyValue(_section, "TargetT"); //Cls.RWconfig.GetAppSettings("TargetT");
            _port_main.DataReceived += new SerialDataReceivedEventHandler(_port_main_DataReceived);
        }

        void _port_main_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_port_m_datareceived != null)
                _port_m_datareceived(sender, e);
            //throw new NotImplementedException();
        }

        private void btnClip5_Click(object sender, EventArgs e)
        {
            blClip5 = !blClip5;
            //改变状态
            if (blClip5)
            {
                //发送关闭夹管阀1命令
                btnClip5.Text = "松开";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV5);
                Thread.Sleep(20);
                pBox5.Image = Properties.Resources.clip5close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip5.Text = "闭合";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV5);
                Thread.Sleep(20);
                pBox5.Image = Properties.Resources.clip5;
            }
        }

        private void btnClip6_Click(object sender, EventArgs e)
        {
            blClip6 = !blClip6;
            //改变状态
            if (blClip6)
            {
                //发送关闭夹管阀1命令
                btnClip6.Text = "松开";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV6);
                Thread.Sleep(20);
                pBox6.Image = Properties.Resources.clip6close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip6.Text = "闭合";
                Thread.Sleep(20);
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV6);
                Thread.Sleep(20);
                pBox6.Image = Properties.Resources.clip6;
            }
        }

        private void btnWeighZero_Click(object sender, EventArgs e)
        {
            //Cls.utils.SendOrder(_port_Weigh, Cls.Comm_Weigh.SetZero((byte)weighID.Value)); 
        }

        private void btnWeighCalibrate1kg_Click(object sender, EventArgs e)
        {
            //Cls.utils.SendOrder(_port_Weigh, Cls.Comm_Weigh.Calibrate1kg((byte)weighID.Value)); 
        }

        private void btnWeighCalibrate5kg_Click(object sender, EventArgs e)
        {
            //Cls.utils.SendOrder(_port_Weigh, Cls.Comm_Weigh.Calibrate5kg((byte)weighID.Value)); 
        }

        private void btnCalibrate10kg_Click(object sender, EventArgs e)
        {
            //Cls.utils.SendOrder(_port_Weigh, Cls.Comm_Weigh.Calibrate10kg((byte)weighID.Value)); 
        }

        private void btnCalibrateDot_Click(object sender, EventArgs e)
        {
            //Cls.utils.SendOrder(_port_Weigh, Cls.Comm_Weigh.CalibrateDot((byte)weighID.Value)); 
        }
    }
}
