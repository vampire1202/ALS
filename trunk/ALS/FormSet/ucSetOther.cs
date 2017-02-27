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
namespace ALS.FormSet
{
    public partial class ucSetOther : UserControl
    {
        private string _section;
        public string _Section
        {
            get { return _section; }
            set { _section = value; }
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

        private Cls.Model_Set _modelSet;
        public Cls.Model_Set _ModelSet
        {
            get { return _modelSet; }
            set { _modelSet = value; }
        }

        public Cls.Model_State m_pumpState = new Cls.Model_State();

        public ucSetOther()
        {
            InitializeComponent();
        }

        public delegate void btnSetT(object sender, EventArgs e);
        public event btnSetT btnSett;

        public delegate void btnSetV(object sender, EventArgs e);
        public event btnSetV btnSetv;
        bool blClip1 = true, blClip2 = true, blClip3 = true, blClip4 = true, blClip5 = true, blClip6 = true;

        private void ucOtherSet_Load(object sender, EventArgs e)
        {
            this.lblFolder.Text = Cls.RWconfig.GetAppSettings("SaveFolder");
            //ReadLevel(_section);
            //ReadServerSet();     
            //ReadPEFlush(_section);  
        }

        private void ucOtherSet_SizeChanged(object sender, EventArgs e)
        {
            //this.groupSet.Left = (this.Width - this.groupSet.Width) / 2;
            //this.groupSet.Top = (this.Height - this.groupSet.Height) / 2;
            //获取当前分辨率
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 897.0f;
            float y = rec.Height / 578.0f;
            Cls.utils.AutoSize(this, x, y);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Cls.RWconfig.SetAppSettings("SaveFolder", this.lblFolder.Text);
            }
            catch { }
            finally { MessageBox.Show("设置成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Information); }
        }

        private void cmbServer_DropDown(object sender, EventArgs e)
        {
            ////获取sql数据库服务器列表
            //this.Cursor = Cursors.WaitCursor;
            //this.cmbServer.Items.Clear();
            //SQLDMO.Application sqlApp =  new SQLDMO.Application();
            //SQLDMO.NameList sqlServers = sqlApp.ListAvailableSQLServers();
            //if (sqlServers.Count > 0)
            //{
            //    //p_strServerList = new string[sqlServers.Count]; 
            //    for (int i = 0; i < sqlServers.Count; i++)
            //    {
            //        string srv = sqlServers.Item(i + 1);
            //        if (srv != null)
            //        {
            //            this.cmbServer.Items.Add(srv);
            //        }
            //    }
            //}
            //this.Cursor = Cursors.Default;
        }

        private void lblPaccUpper_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad np = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == np.ShowDialog())
            {
                if(lbl.Tag!=null)
                {
                    if (np.Value >= 0 && np.Value <= 50)
                        lbl.Text = np.Value.ToString("f0");
                    else
                        MessageBox.Show("请将预警值设置在 0 - 50 的范围内!");                        
                }
                else
                { 
                    lbl.Text = np.Value.ToString("f0");
                }
            }
        }
       
        private void SetLevel(string sec)
        {
            //Cls.RWconfig.SetAppSettings("PvenUpper", this.lblPrenUpper.Text);
            Cls.utils.SetSectionKeyValue(sec, "PvenUpper", this.lblPrenUpper.Text);
            //Cls.RWconfig.SetAppSettings("PvenLower", this.lblPrenLower.Text);
            Cls.utils.SetSectionKeyValue(sec, "PvenLower", this.lblPrenLower.Text);
            //Cls.RWconfig.SetAppSettings("PartUpper", this.lblPartUpper.Text);
            Cls.utils.SetSectionKeyValue(sec, "PartUpper", this.lblPartUpper.Text);
            //Cls.RWconfig.SetAppSettings("PartLower", this.lblPartLower.Text);
            Cls.utils.SetSectionKeyValue(sec, "PartLower", this.lblPartLower.Text);
            //Cls.RWconfig.SetAppSettings("PaccUpper", this.lblPaccUpper.Text);
            Cls.utils.SetSectionKeyValue(sec, "PaccUpper", this.lblPaccUpper.Text);
            //Cls.RWconfig.SetAppSettings("PaccLower", this.lblPaccLower.Text);
            Cls.utils.SetSectionKeyValue(sec, "PaccLower", this.lblPaccLower.Text);
            //Cls.RWconfig.SetAppSettings("TmpUpper", this.lblTmpUpper.Text);
            Cls.utils.SetSectionKeyValue(sec, "TmpUpper", this.lblTmpUpper.Text);
            //Cls.RWconfig.SetAppSettings("TmpLower", this.lblTmpLower.Text);
            Cls.utils.SetSectionKeyValue(sec, "TmpLower", this.lblTmpLower.Text);
            //Cls.RWconfig.SetAppSettings("P1stUpper", this.lblP1stUpper.Text);
            Cls.utils.SetSectionKeyValue(sec, "P1stUpper", this.lblP1stUpper.Text);
            //Cls.RWconfig.SetAppSettings("P1stLower", this.lblP1stLower.Text);
            Cls.utils.SetSectionKeyValue(sec, "P1stLower", this.lblP1stLower.Text);
            //Cls.RWconfig.SetAppSettings("P2ndUpper", this.lblP2ndUpper.Text);
            Cls.utils.SetSectionKeyValue(sec, "P2ndUpper", this.lblP2ndUpper.Text);
            //Cls.RWconfig.SetAppSettings("P2ndLower", this.lblP2ndLower.Text);
            Cls.utils.SetSectionKeyValue(sec, "P2ndLower", this.lblP2ndLower.Text);

            //保存预报警值

            //Cls.RWconfig.SetAppSettings("PrePaccLower", this.lblPrePaccLower.Text);
            foreach(RadioButton r in this.gboxPrePacc.Controls)
            {
                if(r.Checked)
                    Cls.utils.SetSectionKeyValue(sec, "PrePaccLower", r.Text);
            }

            foreach (RadioButton r in this.gboxPrePart.Controls)
            {
                if (r.Checked)
                    Cls.utils.SetSectionKeyValue(sec, "PrePartUpper", r.Text);
            }

            foreach (RadioButton r in this.gboxPrePven.Controls)
            {
                if (r.Checked)
                    Cls.utils.SetSectionKeyValue(sec, "PrePvenUpper", r.Text);
            }

            //Cls.RWconfig.SetAppSettings("PrePvenUpper", this.lblPrePrenUpper.Text);
            //Cls.utils.SetSectionKeyValue(sec, "PrePvenUpper", this.lblPrePrenUpper.Text);
            //Cls.RWconfig.SetAppSettings("PrePartUpper", this.lblPrePartUpper.Text);
            //Cls.utils.SetSectionKeyValue(sec, "PrePartUpper", this.lblPrePartUpper.Text);
            //Cls.RWconfig.SetAppSettings("BloodLeak", this.lblBloodLeak.Text);
            Cls.utils.SetSectionKeyValue(sec, "BloodLeak", this.lblBloodLeak.Text);
            Cls.utils.SetSectionKeyValue(sec, "Concentration", this.lblConcentration.Text);
            ReadLevel(sec);
            MessageBox.Show("保存成功!");
        }

        public void ReadLevel(string sec)
        {
            this.lblPrenUpper.Text = Cls.utils.GetSectionKeyValue(sec, "PvenUpper"); //Cls.RWconfig.GetAppSettings("PvenUpper");
            this.lblPrenLower.Text = Cls.utils.GetSectionKeyValue(sec, "PvenLower"); //Cls.RWconfig.GetAppSettings("PvenLower");
            this.lblPartUpper.Text = Cls.utils.GetSectionKeyValue(sec, "PartUpper"); // Cls.RWconfig.GetAppSettings("PartUpper");
            this.lblPartLower.Text = Cls.utils.GetSectionKeyValue(sec, "PartLower"); // Cls.RWconfig.GetAppSettings("PartLower");
            this.lblPaccUpper.Text = Cls.utils.GetSectionKeyValue(sec, "PaccUpper"); // Cls.RWconfig.GetAppSettings("PaccUpper");
            this.lblPaccLower.Text = Cls.utils.GetSectionKeyValue(sec, "PaccLower"); // Cls.RWconfig.GetAppSettings("PaccLower");
            this.lblTmpUpper.Text = Cls.utils.GetSectionKeyValue(sec, "TmpUpper"); // Cls.RWconfig.GetAppSettings("TmpUpper");
            this.lblTmpLower.Text = Cls.utils.GetSectionKeyValue(sec, "TmpLower"); // Cls.RWconfig.GetAppSettings("TmpLower");
            this.lblP1stUpper.Text = Cls.utils.GetSectionKeyValue(sec, "P1stUpper"); //Cls.RWconfig.GetAppSettings("P1stUpper");
            this.lblP1stLower.Text = Cls.utils.GetSectionKeyValue(sec, "P1stLower"); // Cls.RWconfig.GetAppSettings("P1stLower");
            this.lblP2ndUpper.Text = Cls.utils.GetSectionKeyValue(sec, "P2ndUpper"); //Cls.RWconfig.GetAppSettings("P2ndUpper");
            this.lblP2ndLower.Text = Cls.utils.GetSectionKeyValue(sec, "P2ndLower"); //Cls.RWconfig.GetAppSettings("P2ndLower");

            switch (Cls.utils.GetSectionKeyValue(sec, "PrePaccLower"))
            {
                case "0":this.rbtnPrePacc1.Checked = true;break;
                case "10":this.rbtnPrePacc2.Checked = true;break;
                case "20": this.rbtnPrePacc3.Checked = true;break;
                case "30": this.rbtnPrePacc4.Checked = true;break;
                case "40": this.rbtnPrePacc5.Checked = true;break;
            }
            switch (Cls.utils.GetSectionKeyValue(sec, "PrePartUpper"))
            {
                case "0": this.rbtnPrePart1.Checked = true; break;
                case "10": this.rbtnPrePart2.Checked = true; break;
                case "20": this.rbtnPrePart3.Checked = true; break;
                case "30": this.rbtnPrePart4.Checked = true; break;
                case "40": this.rbtnPrePart5.Checked = true; break;
            }
            switch (Cls.utils.GetSectionKeyValue(sec, "PrePvenUpper"))
            {
                case "0": this.rbtnPrePven1.Checked = true; break;
                case "10": this.rbtnPrePven2.Checked = true; break;
                case "20": this.rbtnPrePven3.Checked = true; break;
                case "30": this.rbtnPrePven4.Checked = true; break;
                case "40": this.rbtnPrePven5.Checked = true; break; 
            }            
            //this.lblPrePaccLower.Text = Cls.utils.GetSectionKeyValue(sec, "PrePaccLower"); // Cls.RWconfig.GetAppSettings("PrePaccLower");
            //this.lblPrePrenUpper.Text = Cls.utils.GetSectionKeyValue(sec, "PrePvenUpper"); //Cls.RWconfig.GetAppSettings("PrePvenUpper");
            //this.lblPrePartUpper.Text = Cls.utils.GetSectionKeyValue(sec, "PrePartUpper"); // Cls.RWconfig.GetAppSettings("PrePartUpper");
            this.lblBloodLeak.Text = Cls.utils.GetSectionKeyValue(sec, "BloodLeak"); // Cls.RWconfig.GetAppSettings("BloodLeak");
            this.lblConcentration.Text = Cls.utils.GetSectionKeyValue(sec, "Concentration");
        } 

        private void btnSaveServer_Click(object sender, EventArgs e)
        {
            // <!--存储及网络设置-->
            //<add key="SaveFolder" value="D:\"/>
            //<add key ="Server_Name" value ="192.168.1.1"/>
            //<add key ="Server_dbName" value="db_test"/>
            //<add key ="Server_User" value="sa"/>
            //<add key ="Server_Pwd" value ="admin"/>
            Cls.RWconfig.SetAppSettings("Server_Name", this.cmbServer.Text);
            Cls.RWconfig.SetAppSettings("Server_dbName", this.txtDbName.Text);
            Cls.RWconfig.SetAppSettings("Server_User",this.txtUser.Text);
            Cls.RWconfig.SetAppSettings("Server_Pwd",this.txtPwd.Text);
            ReadServerSet();
            MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ReadServerSet()
        {
            this.cmbServer.Text = Cls.RWconfig.GetAppSettings("Server_Name");
            this.txtDbName.Text = Cls.RWconfig.GetAppSettings("Server_dbName");
            this.txtUser.Text = Cls.RWconfig.GetAppSettings("Server_User");
            this.txtPwd.Text = Cls.RWconfig.GetAppSettings("Server_Pwd");
        }

        private void btnSetOut_Click(object sender, EventArgs e)
        {
            //<!--清洗量设定-->
            //<add key="PEFlushOut" value="1000"/>
            //<add key="PEFlushIn" value="2000"/>
            //Cls.RWconfig.SetAppSettings("PEFlushOut", this.lblPeFlushOut.Text);
            Cls.utils.SetSectionKeyValue(_section, "PEFlushOut", this.lblPEFlushIn.Text);
            //Cls.RWconfig.SetAppSettings("PEFlushIn", this.lblPeFlushIn.Text);
            Cls.utils.SetSectionKeyValue(_section, "PEFlushIn", this.lblPEFlushOut.Text);
            ReadPEFlush(_section);
            MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ReadPEFlush(string section)
        {
            this.lblPEFlushIn.Text = Cls.utils.GetSectionKeyValue(_section, "PEFlushOut"); //Cls.RWconfig.GetAppSettings("PEFlushOut");
            this.lblPEFlushOut.Text = Cls.utils.GetSectionKeyValue(_section, "PEFlushIn"); //Cls.RWconfig.GetAppSettings("PEFlushIn");
        }

        public void ReadHPumpSet(string section)
        {
            this.lblSpeed.Text = Cls.utils.GetSectionKeyValue(_section, "SP_Speed");
            this.lblRapidValue.Text = Cls.utils.GetSectionKeyValue(_section, "SP_RapidInjectionValue");
        }

        private void lblPeFlushOut_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad np = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == np.ShowDialog())
            {
                lbl.Text = np.Value.ToString("f0");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (DialogResult.OK == fbd.ShowDialog())
            {
                this.lblFolder.Text = fbd.SelectedPath.ToString();
            }
        }

        private void btnSetLevel_Click(object sender, EventArgs e)
        {
            SetLevel(_section);
        }

        private void lblTargetT_Click(object sender, EventArgs e)
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

        private void btnSetTemperature_Click(object sender, EventArgs e)
        {
            //33-40度范围
            try
            {
                if (btnSett != null)
                    btnSett(sender, e);
                double realc = Convert.ToDouble(this.lblTargetT.Text);
                //Cls.RWconfig.SetAppSettings("TargetT", this.lblTargetT.Text);
                if (Cls.utils.SetSectionKeyValue(_section, "TargetT",realc.ToString()))
                { 
                    int val = Convert.ToInt32(realc);
                    byte t = Convert.ToByte(val);
                    this.lblTargetT.Text = val.ToString("f0");
                    //发送设置温度命令 现有的温控表ID为  0x0A 
                    Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdTemperature.StartHT(t));
                    MessageBox.Show("设置成功"); 
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.palSyringe.Enabled = true;
            this.btnCheck.Enabled = false;
            this.btnSetSyringe.Enabled = false;
            
        }

        private void btnChangeSyringe_Click(object sender, EventArgs e)
        {
            this.palSyringe.Enabled = false;
            this.btnCheck.Enabled = true;
            this.btnSetSyringe.Enabled = true;
        }

        private void lblSpeed_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                double val = _numPad.Value;
                if (val >= 0 && val <= 1500.0)
                    lbl.Text = val.ToString("f1");
                else
                    MessageBox.Show("请将速度设置在 0 - 1500 mL/h 之间!");
            }
        }

        private void lblRapidInjection_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                double val = _numPad.Value; 
                lbl.Text = val.ToString("f1"); 
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.btnRun.Enabled = false;
            this.btnStop.Enabled = true;
            this.btnFastRun.Enabled = true;
            this.btnFastStop.Enabled = false;
            this.btnChangeSyringe.Enabled = false;
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Start(Convert.ToDouble(this.lblSpeed.Text), 10));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.btnRun.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnFastRun.Enabled = false;
            this.btnFastStop.Enabled = false;
            this.btnChangeSyringe.Enabled = true;
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Stop);
        }

        private void btnFastRun_Click(object sender, EventArgs e)
        {
            btnFastRun.Enabled = false;
            btnFastStop.Enabled = true;
        }

        private void btnFastStop_Click(object sender, EventArgs e)
        {
            btnFastStop.Enabled = false;
            btnFastRun.Enabled = true;
        }

        private void btnClip1_Click(object sender, EventArgs e)
        {
            blClip1 = !blClip1;
            //改变状态
            if (blClip1)
            {
                //发送关闭夹管阀1命令
                btnClip1.Text = "松开";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV1);
                pBox1.Image = Properties.Resources.clip1close; 
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip1.Text = "闭合";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV1);
                pBox1.Image = Properties.Resources.clip1; 
            }
            m_pumpState.VState[0] = blClip1;
            btnClip1.Tag = m_pumpState;
            if (btnSetv != null)
                btnSetv(sender, e);
        }

        private void btnClip2_Click(object sender, EventArgs e)
        {
            blClip2 = !blClip2;
            //改变状态
            if (blClip2)
            {
                //发送关闭夹管阀1命令
                btnClip2.Text = "松开";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV2);
                pBox2.Image = Properties.Resources.clip2close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip2.Text = "闭合";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV2);
                pBox2.Image = Properties.Resources.clip2;
            }
            m_pumpState.VState[1] = blClip2;
            btnClip2.Tag = m_pumpState;
            if (btnSetv != null)
                btnSetv(sender, e);
        }

        private void btnClip3_Click(object sender, EventArgs e)
        {
            blClip3 = !blClip3;
            //改变状态
            if (blClip3)
            {
                //发送关闭夹管阀1命令
                btnClip3.Text = "松开";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV3);
                pBox3.Image = Properties.Resources.clip3close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip3.Text = "闭合";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV3);
                pBox3.Image = Properties.Resources.clip3;
            }
            m_pumpState.VState[2] = blClip3;
            btnClip3.Tag = m_pumpState;
            if (btnSetv != null)
                btnSetv(sender, e);
        }

        private void btnClip4_Click(object sender, EventArgs e)
        {
            blClip4 = !blClip4;
            //改变状态
            if (blClip4)
            {
                //发送关闭夹管阀1命令
                btnClip4.Text = "松开";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV4);
                pBox4.Image = Properties.Resources.clip4close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip4.Text = "闭合";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV4);
                pBox4.Image = Properties.Resources.clip4;
            }
            m_pumpState.VState[3] = blClip4;
            btnClip4.Tag = m_pumpState;
            if (btnSetv != null)
                btnSetv(sender, e);
        }

        private void btnClip5_Click(object sender, EventArgs e)
        {
            blClip5 = !blClip5;
            //改变状态
            if (blClip5)
            {
                //发送关闭夹管阀1命令
                btnClip5.Text = "松开";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV5);
                pBox5.Image = Properties.Resources.clip5close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip5.Text = "闭合";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV5);
                pBox5.Image = Properties.Resources.clip5;
            }
            m_pumpState.VState[4] = blClip5;
            btnClip5.Tag = m_pumpState;
            if (btnSetv != null)
                btnSetv(sender, e);
        }

        private void btnClip6_Click(object sender, EventArgs e)
        {
            blClip6 = !blClip6;
            //改变状态
            if (blClip6)
            {
                //发送关闭夹管阀1命令
                btnClip6.Text = "松开";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.ClampV6);
                pBox6.Image = Properties.Resources.clip6close;
            }
            else
            {
                //发送打开夹管阀1命令
                btnClip6.Text = "闭合";
                Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdValve.LoosenV6);
                pBox6.Image = Properties.Resources.clip6;
            }
            m_pumpState.VState[5] = blClip6;
            btnClip6.Tag = m_pumpState;
            if (btnSetv != null)
                btnSetv(sender, e);
        }

        private void btnWeighZero_Click(object sender, EventArgs e)
        {
            //Cls.utils.SendOrder(_port_Weigh, Cls.Comm_Weigh.SetZero((byte)weighID.Value)); 
        }

        private void btnWeighCalibrate5kg_Click(object sender, EventArgs e)
        {
            //Cls.utils.SendOrder(_port_Weigh, Cls.Comm_Weigh.Calibrate5kg((byte)weighID.Value));
        }

        private void btnCalibrate10kg_Click(object sender, EventArgs e)
        {
            //Cls.utils.SendOrder(_port_Weigh, Cls.Comm_Weigh.Calibrate10kg((byte)weighID.Value));
        }

        private void btnSetSyringe_Click(object sender, EventArgs e)
        {
            frmSetSyringe fss = new frmSetSyringe();
            fss.ShowDialog();
        }

        private void btnOpenHot_Click(object sender, EventArgs e)
        {
            
            byte t = Convert.ToByte(this.lblTargetT.Text);
            Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdTemperature.StartHT(t));
        }

        private void btnCloseHot_Click(object sender, EventArgs e)
        { 
            Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdTemperature.StopHT);
        } 
    }
}
