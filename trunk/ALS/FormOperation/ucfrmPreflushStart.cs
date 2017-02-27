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
    public partial class ucfrmPreflushStart : UserControl
    {
        private SerialPort _port_Main;
        /// <summary>
        /// 该界面通讯串口
        /// </summary>
        public SerialPort _Port_Main
        {
            get { return _port_Main; }
            set { _port_Main = value; }
        }

        /// <summary>
        /// 警报值 model
        /// </summary>
        private Cls.Model_Warn _modelWarn;
        public Cls.Model_Warn _ModelWarn
        {
            get { return _modelWarn; }
            set { _modelWarn = value; }
        }

        //定义委托
        public delegate void btnClickDelegate(object sender, EventArgs e);
        //定义事件
        public event btnClickDelegate btnClickFinish;
        System.Timers.Timer M_Timer_AutoFlush;


        //计时数
        int M_count = 0; 
        DateTime M_dt;
        //预冲用时
        TimeSpan ts;

        //PE必要量
        public int M_int_Require = 0;
        //预计时间
        public int M_int_Time = 0;

        //1.	安装好管路，系统自检结束，血泵不动，夹管伐1，3，4开，2闭，将肝素化生理盐水连接至静脉端，
        //      废液靠重力作用从V4处管路流出，预冲200ml。（Y形管路构建安装问题请问相国民）
        //      
        //      人工检测管路(提示框),夹管阀1，3，4开 2闭，
        //
        //2.	血泵（泵1）反转，转速40ml/min，夹管伐3、4关闭，夹管伐1，2开放，气泡检测传感器1运行，
        //      压力传感器1，2，3，4工作，开始逆向预冲；
        //
        //3.	拍打血浆分离柱，排净气体，逆向排净管路中气体；血泵转动流量累计达到500ml后（转动12min），
        //      分离泵（泵2）开始转动，顺向20ml/min，排净分离柱外侧腔气体，冲洗分离血浆管路。
        //4.	血泵转动流量累计达到1200ml后，夹管伐3仍关闭，4开放，顺向转动返浆泵，转速20ml/min，
        //      补液管路气体排净后自动开放夹管伐3，关闭夹管伐4；

        //5.	逆向预冲总计运行40min（血泵累计流量1500-1600ml）后，更换生理盐水至动脉端，
        //      分离泵（泵2）停止，返浆泵（泵4）停止，夹管伐2，3维持开放，夹管伐4维持关闭，
        //      血泵（泵1）转为顺向，40ml/min，气泡传感器开始检测，运行5分钟内无气泡报警，提示结束预冲。
        
        public ucfrmPreflushStart()
        {
            InitializeComponent();
        }

        private void ucfrmPreflushStart_SizeChanged(object sender, EventArgs e)
        {
            Rectangle rec = this.ClientRectangle; 
            float x = rec.Width / 893.0f;
            float y = rec.Height / 462.0f;
            Cls.utils.AutoSize(this, x, y);
        }

        private void ucfrmPreflushStart_Load(object sender, EventArgs e)
        {
            //读取必要量
            int peFlushOut = int.Parse(Cls.RWconfig.GetAppSettings("PEFlushOut"));
            int peFlushIn = int.Parse(Cls.RWconfig.GetAppSettings("PEFlushIn"));
            M_int_Require = peFlushIn + peFlushOut + 100;
            this.lblRequire.Text = M_int_Require.ToString();
            //计算必要时间
            //this.lblTime.Text = "40";
            M_Timer_AutoFlush = new System.Timers.Timer();
            M_Timer_AutoFlush.Interval = 1000;
            M_Timer_AutoFlush.AutoReset = true;
            M_Timer_AutoFlush.Elapsed += new System.Timers.ElapsedEventHandler(M_FlushTimer_Elapsed);
        }
       
        void M_FlushTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {            
            //当达到某个时间点时，进行动作，以秒计时
            ts = DateTime.Now - M_dt; 
            //tsRemain = tsAll - ts;            
            //if (tsRemain.TotalSeconds < 0)
            //    tsRemain = new TimeSpan(0, 0, 0);

            //显示提示消息
            if (this.InvokeRequired)
            {
                this.Invoke((EventHandler)(delegate
                {
                    ShowInfo(M_count);
                }));
            }
            else
            {
                ShowInfo(M_count);
            }
            M_count++;
            //throw new NotImplementedException();
        }

        void ShowInfo(int count)
        {
            lblTime.Text = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            //1.	安装好管路，系统自检结束，血泵不动，夹管伐1，3，4开，2闭，将肝素化生理盐水连接至静脉端，
            //      废液靠重力作用从V4处管路流出，预冲200ml。           
            
            if (count == 0)
            {
                this.pic2.BackColor = Color.Gold;
                string step_1 = "   1、安装好管路，系统自检结束，血泵不动，夹管伐1，3，4开，2闭，将肝素化生理盐水连接至静脉端，"
                   + "废液靠重力作用从V4处管路流出，预冲200ml。然后按 ‘确定’按键";
                this.rtbox.AppendText("[" + ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00") + "] - " + step_1+"\r\n");
                //夹管阀134开
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV1);
                Thread.Sleep(10);
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV3);
                Thread.Sleep(10);
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV4);
                Thread.Sleep(10);
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.ClampV2);  
            } 

            this.rtbox.HideSelection = false;
            this.rtbox.Focus();
        }
        
        private void btnPreflushStart_Click(object sender, EventArgs e)
        {
            this.pic1.BackColor = Color.Gold;
            if (DialogResult.OK == MessageBox.Show("请检查管路是否安装正确! 然后点击 “确定” 继续冲洗!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                string step_1 = "   1、安装好管路，系统自检结束，血泵不动，夹管伐1，3，4开，2闭，将肝素化生理盐水连接至静脉端，"
                 + "废液靠重力作用从V4处管路流出，预冲200ml。然后按 ‘确定’按键";
                this.rtbox.AppendText("[" + ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00") + "] - " + step_1 + "\r\n");
                //夹管阀134开
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV1);
                Thread.Sleep(10);
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV3);
                Thread.Sleep(10);
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.LoosenV4);
                Thread.Sleep(10);
                Cls.utils.SendOrder(_port_Main, Cls.Comm_Main.CmdValve.ClampV2);  
                
                this.pic2.BackColor = Color.Gold;
                //冲洗Timer开始工作                
                M_Timer_AutoFlush.Start();
                M_dt = DateTime.Now;                
                this.btnPreflushStart.Enabled = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (btnClickFinish != null)
                btnClickFinish(sender, e);
            this.Dispose();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //1.	安装好管路，系统自检结束，血泵不动，夹管伐1，3，4开，2闭，将肝素化生理盐水连接至静脉端，
            //      废液靠重力作用从V4处管路流出，预冲200ml。（Y形管路构建安装问题请问相国民）
            //      
            //      人工检测管路(提示框),夹管阀1，3，4开 2闭，
            //
            //2.	血泵（泵1）反转，转速40ml/min，夹管伐3、4关闭，夹管伐1，2开放，气泡检测传感器1运行，
            //      压力传感器1，2，3，4工作，开始逆向预冲；
            //
            //3.	拍打血浆分离柱，排净气体，逆向排净管路中气体；血泵转动流量累计达到500ml后（转动12min），
            //      分离泵（泵2）开始转动，顺向20ml/min，排净分离柱外侧腔气体，冲洗分离血浆管路。
            //4.	血泵转动流量累计达到1200ml后，夹管伐3仍关闭，4开放，顺向转动返浆泵，转速20ml/min，
            //      补液管路气体排净后自动开放夹管伐3，关闭夹管伐4；

            //5.	逆向预冲总计运行40min（血泵累计流量1500-1600ml）后，更换生理盐水至动脉端，
            //      分离泵（泵2）停止，返浆泵（泵4）停止，夹管伐2，3维持开放，夹管伐4维持关闭，
            //      血泵（泵1）转为顺向，40ml/min，气泡传感器开始检测，运行5分钟内无气泡报警，提示结束预冲。
            if (DialogResult.OK == MessageBox.Show("请确认第一步是否完成？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                //自动预冲开始
                M_Timer_AutoFlush.Start();
            }
        }

       

    }
}
