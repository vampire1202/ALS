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
using MySql.Data.MySqlClient;
namespace ALS.FormSet
{
    public partial class ucSetOther : UserControl
    {
        //int[] m_readWarnRange = new int[24];

        private SerialPort _port_main;
        LogClass getlog = new LogClass();
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

        private Model.treatmentmode _modelTreat;
        public Model.treatmentmode _ModelTreat
        {
            get { return _modelTreat; }
            set { _modelTreat = value; }
        }

        //public Cls.Model_State m_pumpState = new Cls.Model_State();

        public ucSetOther()
        {
            InitializeComponent();
        }

        public delegate void btnSetT(object sender, EventArgs e);
        public event btnSetT btnSett;

        public delegate void btnZeroWS(object sender, EventArgs e);
        public event btnZeroWS btnZeroWs;

        public delegate void sp_NearAccumulation(object sender, EventArgs e);
        public event sp_NearAccumulation Sp_NearAccumulation;

        public delegate void btnZerototalsp(object sender, EventArgs e);
        public event btnZerototalsp btnZeroTotalSp;

        //夹管阀
        public delegate void chkVClick(object sender, EventArgs e);
        public event chkVClick checkVClick;

        public delegate void btn_RunSP(object sender, EventArgs e);
        public event btn_RunSP _btnRunSP;

        public delegate void btn_RunFastSP(object sender, EventArgs e);
        public event btn_RunFastSP _btnRunFastSP;

        public delegate void btn_StopFastSP(object sender, EventArgs e);
        public event btn_StopFastSP _btn_StopFastSP;

        public delegate void btn_SaveSet(object sender, EventArgs e);
        public event btn_SaveSet btnSaveSet;

        public delegate void changeSPSpeed(object sender, EventArgs e);
        public event changeSPSpeed _ChangeSpSPeed;

        private Model.warnrange m_modWarnRange;

        double dRequireFlush = 0;
        private void ucOtherSet_Load(object sender, EventArgs e)
        {
            this.palSyringe.Enabled = true;
            //this.btnCheck.Enabled = false;
            //this.btnSetSyringe.Enabled = false;
        }
        //private int sizechangedcount = 0;
        private void ucOtherSet_SizeChanged(object sender, EventArgs e)
        {
            //this.groupSet.Left = (this.Width - this.groupSet.Width) / 2;
            //this.groupSet.Top = (this.Height - this.groupSet.Height) / 2;
            //获取当前分辨率
            //if (sizechangedcount == 0)
            //{
            //    Rectangle rec = this.ClientRectangle;
            //    //与基准分辨率的放大系数
            //    float x = rec.Width / 897.0f;
            //    float y = rec.Height / 550.0f;
            //    Cls.utils.AutoSize(this, x, y);
            //}
            //sizechangedcount = 1;
        }

        public void ReadVState(Cls.Model_State _state)
        {
            if (_state.VState[0] == 1)
            {
                chkV1.Image = global::ALS.Properties.Resources.clipclose;
                chkV1.Checked = true;
                //chkV1.Text = "松开";
            }
            else
            {
                chkV1.Image = global::ALS.Properties.Resources.clipopen;
                chkV1.Checked = false;
                //chkV1.Text = "夹管";
            }

            if (_state.VState[1] == 1)
            {
                chkV2.Image = global::ALS.Properties.Resources.clipclose;
                chkV2.Checked = true;
                //chkV2.Text = "松开";
            }
            else
            {
                chkV2.Image = global::ALS.Properties.Resources.clipopen;
                chkV2.Checked = false;
                //chkV2.Text = "夹管";
            }

            if (_state.VState[2] == 1)
            {
                chkV3.Image = global::ALS.Properties.Resources.clipclose;
                chkV3.Checked = true;
                //chkV3.Text = "松开";
            }
            else
            {
                chkV3.Image = global::ALS.Properties.Resources.clipopen;
                chkV3.Checked = false;
                //chkV3.Text = "夹管";
            }

            if (_state.VState[3] == 1)
            {
                chkV4.Image = global::ALS.Properties.Resources.clipclose;
                chkV4.Checked = true;
                //chkV4.Text = "松开";
            }
            else
            {
                chkV4.Image = global::ALS.Properties.Resources.clipopen;
                chkV4.Checked = false;
                //chkV4.Text = "夹管";
            }

            if (_state.VState[4] == 1)
            {
                chkV5.Image = global::ALS.Properties.Resources.clipclose;
                chkV5.Checked = true;
                //chkV5.Text = "松开";
            }
            else
            {
                chkV5.Image = global::ALS.Properties.Resources.clipopen;
                chkV5.Checked = false;
                //chkV5.Text = "夹管";
            }

            if (_state.VState[5] == 1)
            {
                chkV6.Image = global::ALS.Properties.Resources.clipclose;
                chkV6.Checked = true;
                //chkV6.Text = "松开";
            }
            else
            {
                chkV6.Image = global::ALS.Properties.Resources.clipopen;
                chkV6.Checked = false;
                //chkV6.Text = "夹管";
            }
        }

        private void lblPaccUpper_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            UserCtrl.numPad np = new UserCtrl.numPad(lbl.Text);
            np.btnDot.Visible = false;
            //np.btnNegPos.Visible = false; 
            if (DialogResult.OK == np.ShowDialog())
            {
                if (lbl.Tag != null)
                {
                    switch (lbl.Tag.ToString())
                    {
                        case "pacclower":
                            if (np.Value < m_modWarnRange.PaccLowerLower.Value || np.Value > m_modWarnRange.PaccLowerUpper.Value)// m_readWarnRange[2]m_readWarnRange[3]
                            {
                                MessageBox.Show("请将采血压(Pacc)下限设置在 " + m_modWarnRange.PaccLowerLower.Value + "~" + m_modWarnRange.PaccLowerUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.PaccLowerLower.Value.ToString("f0");
                                return;
                            }
                            break;
                        case "paccupper":
                            if (np.Value < m_modWarnRange.PaccUpperLower.Value || np.Value > m_modWarnRange.PaccUpperUpper.Value)
                            {
                                MessageBox.Show("请将采血压(Pacc)上限设置在 " + m_modWarnRange.PaccUpperLower.Value + "~" + m_modWarnRange.PaccUpperUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.PaccUpperUpper.Value.ToString("f0");
                                return;
                            }
                            break;
                        case "partlower":

                            if (np.Value < m_modWarnRange.PartLowerLower.Value || np.Value > m_modWarnRange.PartLowerUpper.Value)
                            {
                                MessageBox.Show("请将动脉压(Part)下限设置在 " + m_modWarnRange.PartLowerLower.Value + "~" + m_modWarnRange.PartLowerUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.PartLowerLower.Value.ToString("f0");
                                return;
                            }
                            break;
                        case "partupper":

                            if (np.Value < m_modWarnRange.PartUpperLower.Value || np.Value > m_modWarnRange.PartUpperUpper.Value)
                            {
                                MessageBox.Show("请将动脉压(Part)上限设置在 " + m_modWarnRange.PartUpperLower.Value + "~" + m_modWarnRange.PartUpperUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.PartUpperUpper.Value.ToString("f0");
                                return;
                            }
                            break;
                        case "tmplower":

                            if (np.Value < m_modWarnRange.TMPLowerLower.Value || np.Value > m_modWarnRange.TMPLowerUpper.Value)
                            {
                                MessageBox.Show("请将跨膜压(TMP)下限设置在 " + m_modWarnRange.TMPLowerLower.Value + "~" + m_modWarnRange.TMPLowerUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.TMPLowerLower.Value.ToString("f0");
                                return;
                            }
                            break;
                        case "tmpupper":

                            if (np.Value < m_modWarnRange.TMPUpperLower.Value || np.Value > m_modWarnRange.TMPUpperUpper.Value)
                            {
                                MessageBox.Show("请将跨膜压(TMP)上限设置在 " + m_modWarnRange.TMPUpperLower.Value + "~" + m_modWarnRange.TMPUpperUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.TMPUpperUpper.Value.ToString("f0");
                                return;
                            }
                            break;
                        case "pvenlower":

                            if (np.Value < m_modWarnRange.PvenLowerLower.Value || np.Value > m_modWarnRange.PvenLowerUpper.Value)
                            {
                                MessageBox.Show("请将静脉压(Pven)下限设置在 " + m_modWarnRange.PvenLowerLower.Value + "~" + m_modWarnRange.PvenLowerUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.PvenLowerLower.Value.ToString("f0");
                                return;
                            }
                            break;
                        case "pvenupper":
                            if (np.Value < m_modWarnRange.PvenUpperLower.Value || np.Value > m_modWarnRange.PvenUpperUpper.Value)
                            {
                                MessageBox.Show("请将静脉压(Pven)上限设置在 " + m_modWarnRange.PvenUpperLower.Value + "~" + m_modWarnRange.PvenUpperUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.PvenUpperUpper.Value.ToString("f0");
                                return;
                            }
                            break;

                        case "p1stlower":

                            if (np.Value < m_modWarnRange.P1stLowerLower.Value || np.Value > m_modWarnRange.P1stLowerUpper.Value)
                            {
                                MessageBox.Show("请将 血浆压/滤过压(P1st) 下限设置在 " + m_modWarnRange.P1stLowerLower.Value + "~" + m_modWarnRange.P1stLowerUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.P1stLowerLower.Value.ToString("f0");
                                return;
                            }
                            break;

                        case "p1stupper":
                            if (np.Value < m_modWarnRange.P1stUpperLower.Value || np.Value > m_modWarnRange.P1stUpperUpper.Value)
                            {
                                MessageBox.Show("请将 血浆压/滤过压(P1st) 上限设置在 " + m_modWarnRange.P1stUpperLower.Value + "~" + m_modWarnRange.P1stUpperUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.P1stUpperUpper.Value.ToString("f0");
                                return;
                            }
                            break;

                        case "p2ndlower":
                            if (np.Value < m_modWarnRange.P2ndLowerLower.Value || np.Value > m_modWarnRange.P2ndLowerUpper.Value)
                            {
                                MessageBox.Show("请将血浆入口压1(P2nd)下限设置在 " + m_modWarnRange.P2ndLowerLower.Value + "~" + m_modWarnRange.P2ndLowerUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.P2ndLowerLower.Value.ToString("f0");
                                return;
                            }
                            break;

                        case "p2ndupper":
                            if (np.Value < m_modWarnRange.P2ndUpperLower.Value || np.Value > m_modWarnRange.P2ndUpperUpper.Value)
                            {
                                MessageBox.Show("请将血浆入口压1(P2nd)上限设置在 " + m_modWarnRange.P2ndUpperLower.Value + "~" + m_modWarnRange.P2ndUpperUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.P2ndUpperUpper.Value.ToString("f0");
                                return;
                            }
                            break;

                        case "p3rdlower":
                            if (np.Value < m_modWarnRange.P3rdLowerLower.Value || np.Value > m_modWarnRange.P3rdLowerUpper.Value)
                            {
                                MessageBox.Show("请将血浆入口压2(P3rd)下限设置在 " + m_modWarnRange.P3rdLowerLower.Value + "~" + m_modWarnRange.P3rdLowerUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.P3rdLowerLower.Value.ToString("f0");
                                return;
                            }
                            break;

                        case "p3rdupper":

                            if (np.Value < m_modWarnRange.P3rdUpperLower.Value || np.Value > m_modWarnRange.P3rdUpperUpper.Value)
                            {
                                MessageBox.Show("请将血浆入口压2(P3rd)上限设置在 " + m_modWarnRange.P3rdUpperLower.Value + "~" + m_modWarnRange.P3rdUpperUpper.Value + " 的范围内!");
                                lbl.Text = m_modWarnRange.P3rdUpperUpper.Value.ToString("f0");
                                return;
                            }
                            break;
                        case "concentration"://过浓缩报警设置
                            if (np.Value < 0 || np.Value > 50)
                            {
                                MessageBox.Show("请将 过浓缩范围设定在 (0-50) % 之间");
                                return;
                            }
                            break;
                        case "bloodleak"://漏血 
                            np.btnNegPos.Visible = false;
                            if (np.Value < 0 || np.Value > 100)
                            {
                                MessageBox.Show("漏血值灵敏度设置范围为(0 - 100)%");
                                return;
                            }
                            this.trackBar1.Value = (int)np.Value;
                            break;
                        case "paccDecrement":
                            if (np.Value < 0 || np.Value > 150)
                            {
                                MessageBox.Show("请将采血压变化量预警设定在 0～150之间!");
                                return;
                            }
                            break;
                    }
                }
                lbl.Text = np.Value.ToString("f0");
            }
        }
        private void SaveDefaultWarnSet(Model.treatmentmode mtreat)
        {
            mtreat.PvenUpper = Convert.ToInt32(this.lblPvenUpper.Text);
            mtreat.PvenLower = Convert.ToInt32(this.lblPvenLower.Text);
            mtreat.PartUpper = Convert.ToInt32(this.lblPartUpper.Text);
            mtreat.PartLower = Convert.ToInt32(this.lblPartLower.Text);
            mtreat.PaccUpper = Convert.ToInt32(this.lblPaccUpper.Text);
            mtreat.PaccLower = Convert.ToInt32(this.lblPaccLower.Text);
            mtreat.TmpUpper = Convert.ToInt32(this.lblTmpUpper.Text);
            mtreat.TmpLower = Convert.ToInt32(this.lblTmpLower.Text);
            mtreat.P1stUpper = Convert.ToInt32(this.lblP1stUpper.Text);
            mtreat.P1stLower = Convert.ToInt32(this.lblP1stLower.Text);
            mtreat.P2ndUpper = Convert.ToInt32(this.lblP2ndUpper.Text);
            mtreat.P2ndLower = Convert.ToInt32(this.lblP2ndLower.Text);

            mtreat.P3rdLower = Convert.ToInt32(this.lblP3rdLower.Text);
            mtreat.P3rdUpper = Convert.ToInt32(this.lblP3rdUpper.Text);
            //保存预报警值

            foreach (Control c in this.gboxPrePacc.Controls)
            {
                if (c is RadioButton)
                {
                    RadioButton r = c as RadioButton;
                    if (r.Checked)
                        mtreat.PrePaccLower = Convert.ToInt32(r.Text);
                }
            }

            foreach (RadioButton r in this.gboxPrePart.Controls)
            {
                if (r.Checked)
                    mtreat.PrePartUpper = Convert.ToInt32(r.Text);
            }

            foreach (RadioButton r in this.gboxPrePven.Controls)
            {
                if (r.Checked)
                    mtreat.PrePvenUpper = Convert.ToInt32(r.Text);
            }
            mtreat.BloodLeak = Convert.ToInt32(this.lblBloodLeak.Text);
            mtreat.Concentration = Convert.ToDouble(this.lblConcentration.Text);
            mtreat.PaccDecrement = Convert.ToInt32(this.lblPaccDecWarn.Text);
            if (new BLL.treatmentmode().Update(mtreat))
            {
                ReadLevel(mtreat);
                MessageBox.Show("保存成功!");
            }
        }

        public void ReadLevel(Model.treatmentmode mtreat)
        {
            this.lblTargetT.Text = mtreat.TargetT.Value.ToString();
            this.lblPvenUpper.Text = mtreat.PvenUpper.Value.ToString();
            this.lblPvenLower.Text = mtreat.PvenLower.Value.ToString();
            this.lblPartUpper.Text = mtreat.PartUpper.Value.ToString();
            this.lblPartLower.Text = mtreat.PartLower.Value.ToString();
            this.lblPaccUpper.Text = mtreat.PaccUpper.Value.ToString();
            this.lblPaccLower.Text = mtreat.PaccLower.Value.ToString();
            this.lblTmpUpper.Text = mtreat.TmpUpper.Value.ToString();
            this.lblTmpLower.Text = mtreat.TmpLower.Value.ToString();
            this.lblP1stUpper.Text = mtreat.P1stUpper.Value.ToString();
            this.lblP1stLower.Text = mtreat.P1stLower.Value.ToString();
            this.lblP2ndUpper.Text = mtreat.P2ndUpper.Value.ToString();
            this.lblP2ndLower.Text = mtreat.P2ndLower.Value.ToString();

            this.lblP3rdLower.Text = mtreat.P3rdLower.Value.ToString();
            this.lblP3rdUpper.Text = mtreat.P3rdUpper.Value.ToString();

            m_modWarnRange = new BLL.warnrange().GetModel(1);

            switch (mtreat.PrePaccLower.Value.ToString())
            {
                case "0": this.rbtnPrePacc1.Checked = true; break;
                case "10": this.rbtnPrePacc2.Checked = true; break;
                case "20": this.rbtnPrePacc3.Checked = true; break;
                case "30": this.rbtnPrePacc4.Checked = true; break;
                case "40": this.rbtnPrePacc5.Checked = true; break;
            }
            switch (mtreat.PrePartUpper.ToString())
            {
                case "0": this.rbtnPrePart1.Checked = true; break;
                case "10": this.rbtnPrePart2.Checked = true; break;
                case "20": this.rbtnPrePart3.Checked = true; break;
                case "30": this.rbtnPrePart4.Checked = true; break;
                case "40": this.rbtnPrePart5.Checked = true; break;
            }
            switch (mtreat.PrePvenUpper.ToString())
            {
                case "0": this.rbtnPrePven1.Checked = true; break;
                case "10": this.rbtnPrePven2.Checked = true; break;
                case "20": this.rbtnPrePven3.Checked = true; break;
                case "30": this.rbtnPrePven4.Checked = true; break;
                case "40": this.rbtnPrePven5.Checked = true; break;
            }
            this.lblBloodLeak.Text = mtreat.BloodLeak.Value.ToString();
            if (mtreat.BloodLeak.Value > 100)
                this.trackBar1.Value = 100;
            else if (mtreat.BloodLeak.Value < 0)
                this.trackBar1.Value = 0;
            else
                this.trackBar1.Value = mtreat.BloodLeak.Value;

            this.lblConcentration.Text = mtreat.Concentration.Value.ToString();
            this.lblPaccDecWarn.Text = mtreat.PaccDecrement.Value.ToString();
        }
        private void SaveWarnSet(Model.treatmentmode mtreat)
        {
            mtreat.PvenUpper = Convert.ToInt32(this.lblPvenUpper.Text);
            mtreat.PvenLower = Convert.ToInt32(this.lblPvenLower.Text);
            mtreat.PartUpper = Convert.ToInt32(this.lblPartUpper.Text);
            mtreat.PartLower = Convert.ToInt32(this.lblPartLower.Text);
            mtreat.PaccUpper = Convert.ToInt32(this.lblPaccUpper.Text);
            mtreat.PaccLower = Convert.ToInt32(this.lblPaccLower.Text);
            mtreat.TmpUpper = Convert.ToInt32(this.lblTmpUpper.Text);
            mtreat.TmpLower = Convert.ToInt32(this.lblTmpLower.Text);
            mtreat.P1stUpper = Convert.ToInt32(this.lblP1stUpper.Text);
            mtreat.P1stLower = Convert.ToInt32(this.lblP1stLower.Text);
            mtreat.P2ndUpper = Convert.ToInt32(this.lblP2ndUpper.Text);
            mtreat.P2ndLower = Convert.ToInt32(this.lblP2ndLower.Text);
            mtreat.P3rdLower = Convert.ToInt32(this.lblP3rdLower.Text);
            mtreat.P3rdUpper = Convert.ToInt32(this.lblP3rdUpper.Text);
            //保存预报警值
            foreach (Control r in this.gboxPrePacc.Controls)
            {
                if (r is RadioButton)
                {
                    RadioButton rb = r as RadioButton;
                    if (rb.Checked)
                        mtreat.PrePaccLower = Convert.ToInt32(rb.Text);
                }
            }
            foreach (RadioButton r in this.gboxPrePart.Controls)
            {
                if (r.Checked)
                    mtreat.PrePartUpper = Convert.ToInt32(r.Text);
            }
            foreach (RadioButton r in this.gboxPrePven.Controls)
            {
                if (r.Checked)
                    mtreat.PrePvenUpper = Convert.ToInt32(r.Text);
            }
            mtreat.BloodLeak = Convert.ToInt32(this.lblBloodLeak.Text);
            mtreat.Concentration = Convert.ToDouble(this.lblConcentration.Text);
            mtreat.PaccDecrement = Convert.ToInt32(this.lblPaccDecWarn.Text);
            if (new BLL.treatmentmode().Update(mtreat))
            {
                if (btnSaveSet != null)
                    btnSaveSet(btnSaveWarnSet, new EventArgs());
                MessageBox.Show("保存成功!");
            }
        }



        public void ReadFlush()
        {
            this.lblPEFlush1.Text = Cls.RWconfig.GetAppSettings("peflush1");
            this.lblPEFlush2.Text = Cls.RWconfig.GetAppSettings("peflush2");
            this.lblPPFlush1.Text = Cls.RWconfig.GetAppSettings("ppflush1");
            this.lblPPFlush2.Text = Cls.RWconfig.GetAppSettings("ppflush2");
            this.lblCHDFFlush1.Text = Cls.RWconfig.GetAppSettings("chdfflush1");
            this.lblCHDFFlush2.Text = Cls.RWconfig.GetAppSettings("chdfflush2");
            this.lblLiALSFLush1.Text = Cls.RWconfig.GetAppSettings("lialsflush1");
            this.lblLiALSFLush2.Text = Cls.RWconfig.GetAppSettings("lialsflush2");
            this.lblPEFFlush1.Text = Cls.RWconfig.GetAppSettings("pefflush1");
            this.lblPEFFlush2.Text = Cls.RWconfig.GetAppSettings("pefflush2");
            this.lblPDFFlush1.Text = Cls.RWconfig.GetAppSettings("pdfflush1");
            this.lblPDFFlush2.Text = Cls.RWconfig.GetAppSettings("pdfflush2"); 
        }

        public void ReadHPumpSet()
        {
            this.lblSpeed.Text = _modelTreat.SP_Speed.Value.ToString("f1");
            this.lblRapidValue.Text = _modelTreat.SP_RapidInjectionValue.Value.ToString("f1");
            //读取预置量
            //wss 2015年12月26日
            this.lblAccvalue.Text = _modelTreat.TargetSP.Value.ToString("f0");
        }

        public void SaveHPumpSet()
        {
            _modelTreat.SP_Speed = Convert.ToDouble(this.lblSpeed.Text);
            //保存快送速度
            _modelTreat.SP_RapidInjectionValue = Convert.ToDouble(this.lblRapidValue.Text);
            //保存目标累积量
            //wss 2015年12月26日
            _modelTreat.TargetSP = Convert.ToDouble(this.lblAccvalue.Text);
            new BLL.treatmentmode().Update(_modelTreat);
        }

        private void lblSetFlush(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad np = new UserCtrl.numPad(lbl.Text);
            np.btnNegPos.Visible = false;
            np.btnDot.Visible = false;
            if (DialogResult.OK == np.ShowDialog())
            {
                string lbltag = lbl.Tag.ToString();
                int tag = int.Parse(lbltag);
                if (np.Value < tag)
                {
                    MessageBox.Show("不能低于默认值: " + lbltag);
                    return;
                }              
                lbl.Text = np.Value.ToString("f0");
            }
        }


        private void btnSetLevel_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(this, "确认保存当前警报上下限阈值？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                SaveWarnSet(_modelTreat);
            }
        }

        private void lblTargetT_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            _numPad.btnNegPos.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                //Test
                if (_numPad.Value < 35 || _numPad.Value > 40)
                {
                    MessageBox.Show("请将目标温度设置在 35 ～ 40 ℃之间!");
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
                _modelTreat.TargetT = realc;
                if (new BLL.treatmentmode().Update(_modelTreat))
                {
                    int val = Convert.ToInt32(realc);
                    byte t = Convert.ToByte(val);
                    this.lblTargetT.Text = val.ToString("f0");
                    Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdTemperature.StartHT(t));
                    Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdTemperature.StartHT(t));
                    MessageBox.Show("设置成功");
                }
                else
                    MessageBox.Show("设置失败");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.palSyringe.Enabled = true;
            this.btnSetSyringe.Enabled = false;
        }

        private void btnChangeSyringe_Click(object sender, EventArgs e)
        {
            //累积量接近完成标志量
            if (Sp_NearAccumulation != null)
            {
                Sp_NearAccumulation(sender, e);
            }
            //清除累积量
            //wss 2015年12月28日
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.ClearCumulant);
        }

        private void lblSpeed_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            _numPad.btnDot.Visible = true;
            _numPad.btnNegPos.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                double val = _numPad.Value;
                if (val >= 0 && val <= 15.0)
                {
                    lbl.Text = val.ToString("f1");
                    _modelTreat.SP_Speed = val;
                    new BLL.treatmentmode().Update(_modelTreat);
                    //更新主界面
                    if (_ChangeSpSPeed != null)
                        _ChangeSpSPeed(sender, e);
                }
                else
                    MessageBox.Show("请将速度设置在 0.1 - 15.0 mL/h 之间!");
            }
        }

        private void lblRapidInjection_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            _numPad.btnDot.Visible = true;
            _numPad.btnNegPos.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                double val = _numPad.Value;

                if (val <= 30 && val >= 0.1)
                {
                    lbl.Text = val.ToString("f1");
                    _modelTreat.SP_RapidInjectionValue = val;
                    new BLL.treatmentmode().Update(_modelTreat);
                }
                else
                    MessageBox.Show("请将快速注入量设置在0.1-30mL以内!");
            }
        }
        //设置预置量 小于等于30mL
        //wss 2015年12月26日
        private void lblAccvalue__Click(object sender, EventArgs e)
        {
            //if (this.lblSPStandard.Text == "--")
            //{
            //    MessageBox.Show("请先正确安装注射器！");
            //    return;
            //}
            if (this.btnRunSP.Enabled == false)
            {
                MessageBox.Show("请先停止注射泵，再设置预置量");
                return;
            }
            Label lbl = (Label)sender;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lbl.Text);
            _numPad.btnDot.Visible = false;
            _numPad.btnNegPos.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                double val = _numPad.Value;
                if (val <= 30 && val > 0)
                {
                    lbl.Text = val.ToString("f0");
                    _modelTreat.TargetSP = Math.Round(val, 0);
                    new BLL.treatmentmode().Update(_modelTreat);
                }
                else
                    MessageBox.Show("请将目标累计值设置在30mL以内!");
            }
        }

        public void btnRun_Click(object sender, EventArgs e)
        {
            SetSPButton(true);
            if (_btnRunSP != null)
                _btnRunSP(sender, e);
        }

        public void SetSPButton(bool run)
        {
            if (run)
            {
                this.btnRunSP.Enabled = false;
                this.btnStopSP.Enabled = true;
                this.btnFastRunSP.Enabled = true;
                this.btnFastStopSP.Enabled = false;
                this.btnChangeSP.Enabled = false;
                this.btnZeroSPSum.Enabled = false;
            }
            else
            {
                this.btnRunSP.Enabled = true;
                this.btnStopSP.Enabled = false;
                this.btnFastRunSP.Enabled = false;
                this.btnFastStopSP.Enabled = false;
                this.btnChangeSP.Enabled = true;
                this.btnZeroSPSum.Enabled = true;
            }
        }

        public void btnStop_Click(object sender, EventArgs e)
        {
            SetSPButton(false);
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Stop);
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Stop);
        }


        private void btnFastRun_Click(object sender, EventArgs e)
        {
            btnFastRunSP.Enabled = false;
            btnFastStopSP.Enabled = true;
            if (_btnRunFastSP != null)
                _btnRunFastSP(sender, e);
        }

        private void btnFastStop_Click(object sender, EventArgs e)
        {
            if (_btn_StopFastSP != null)
                _btn_StopFastSP(sender, e);

        }

        private void btnSetSyringe_Click(object sender, EventArgs e)
        {
            frmSetSyringe fss = new frmSetSyringe();
            fss._Port_hpump = this._Port_hpump;
            fss.ShowDialog();
        }

        private void btnCloseHot_Click(object sender, EventArgs e)
        {
            Cls.utils.SendOrder(_port_main, Cls.Comm_Main.CmdTemperature.StopHT);
        }

        private void btnZeroSPSum_Click(object sender, EventArgs e)
        {
            if (Sp_NearAccumulation != null)
            {
                Sp_NearAccumulation(sender, e);
            }
            if (DialogResult.OK == MessageBox.Show("确认清除肝素泵累计量？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.ClearCumulant);
                if (btnZeroTotalSp != null)
                    btnZeroTotalSp(sender, e);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveHPumpSet();
        }

        private void btnZeroWS1_Click(object sender, EventArgs e)
        {
            if (btnZeroWs != null)
                btnZeroWs(sender, e);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab.Name.ToLower() == "tpwarnlog")
            {
                if (this.dgvLog.Rows.Count > 0)
                    this.dgvLog.Rows.Clear();
                //查询报警记录
                BLL.warnlog blog = new BLL.warnlog();
                List<Model.warnlog> lstLog = blog.GetModelList(" logdate='" + DateTime.Now.Date + "'");
                int count = lstLog.Count;
                //超过100条报警只显示最新的100条
                if (count >= 100)
                {
                    lstLog = lstLog.OrderByDescending(warn_list => warn_list.logtime).ToList();
                    count = 100;
                }
                for (int i = 0; i < count; i++)
                {
                    switch (lstLog[i].grade)
                    {
                        case 1:
                            object[] values = new object[] { "高", (i + 1).ToString(), lstLog[i].logtime.ToString(), lstLog[i].warncode, lstLog[i].warntitle };
                            DataGridViewRow dgvr = new DataGridViewRow();
                            dgvr.CreateCells(this.dgvLog);
                            dgvr.SetValues(values);
                            dgvr.DefaultCellStyle.BackColor = Color.FromArgb(230, 0, 0);
                            dgvr.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 0, 0);
                            //dgvr.Cells[0].Style.BackColor = Color.White;
                            //dgvr.Cells[0].Style.SelectionBackColor = Color.White;
                            this.dgvLog.Rows.Add(dgvr);
                            break;
                        case 2:
                        case 3:
                            object[] values1 = new object[] { "中", (i + 1).ToString(), lstLog[i].logtime.ToString(), lstLog[i].warncode, lstLog[i].warntitle };
                            DataGridViewRow dgvr1 = new DataGridViewRow();
                            dgvr1.CreateCells(this.dgvLog);
                            dgvr1.SetValues(values1);
                            dgvr1.DefaultCellStyle.BackColor = Color.DarkOrange;
                            dgvr1.DefaultCellStyle.SelectionBackColor = Color.DarkOrange;
                            //dgvr1.Cells[0].Style.BackColor = Color.White;
                            //dgvr1.Cells[0].Style.SelectionBackColor = Color.White;
                            this.dgvLog.Rows.Add(dgvr1);
                            break;
                        case 4:
                            object[] values2 = new object[] { "中", (i + 1).ToString(), lstLog[i].logtime.ToString(), lstLog[i].warncode, lstLog[i].warntitle };
                            DataGridViewRow dgvr2 = new DataGridViewRow();
                            dgvr2.CreateCells(this.dgvLog);
                            dgvr2.SetValues(values2);
                            dgvr2.DefaultCellStyle.BackColor = Color.DarkOrange;
                            dgvr2.DefaultCellStyle.SelectionBackColor = Color.DarkOrange;
                            //dgvr2.Cells[0].Style.BackColor = Color.White;
                            //dgvr2.Cells[0].Style.SelectionBackColor = Color.White;
                            this.dgvLog.Rows.Add(dgvr2);
                            break;
                    }
                }
            }
        }

        private void chkV1_Click(object sender, EventArgs e)
        {
            if (checkVClick != null)
                checkVClick(sender, e);
        }

        private void Sy_ClearWarning_Click(object sender, EventArgs e)
        {
            //点击按钮发送断电预告，清除注射器报警；
            Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Sy_Outage);
            //Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Syringe_FifClose);
            //Thread.Sleep(1000);
            //Cls.utils.SendOrder(_port_hpump, Cls.Comm_SyringePump.Syringe_FifOpen);
            //只有在注射器报警时，按钮处于可使用状态
            this.Sy_ClearWarning.Enabled = false;
            this.Syringe_state.Text = "正常运行中";
            this.Syringe_state.ForeColor = System.Drawing.Color.Lime;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            Model.treatmentmode modDefault = null;
            switch (_modelTreat.name)
            {
                case "Li-ALS":
                    modDefault = new BLL.treatmentmode().GetModel("Li-ALS_Default");
                    break;
                case "PE":
                    modDefault = new BLL.treatmentmode().GetModel("PE_Default");
                    break;
                case "PP":
                    modDefault = new BLL.treatmentmode().GetModel("PP_Default");
                    break;
                case "CHDF":
                    modDefault = new BLL.treatmentmode().GetModel("CHDF_Default");
                    break;
                case "PERT":
                    modDefault = new BLL.treatmentmode().GetModel("PERT_Default");
                    break;
                case "PDF":
                    modDefault = new BLL.treatmentmode().GetModel("PDF_Default");
                    break;
            }
            ReadLevel(modDefault);
        }

        private void btnSaveDefault_Click(object sender, EventArgs e)
        {
            Model.treatmentmode modDefault = null;
            switch (_modelTreat.name)
            {
                case "Li-ALS":
                    modDefault = new BLL.treatmentmode().GetModel("Li-ALS_Default");
                    break;
                case "PE":
                    modDefault = new BLL.treatmentmode().GetModel("PE_Default");
                    break;
                case "PP":
                    modDefault = new BLL.treatmentmode().GetModel("PP_Default");
                    break;
                case "CHDF":
                    modDefault = new BLL.treatmentmode().GetModel("CHDF_Default");
                    break;
                case "PERT":
                    modDefault = new BLL.treatmentmode().GetModel("PERT_Default");
                    break;
                case "PDF":
                    modDefault = new BLL.treatmentmode().GetModel("PDF_Default");
                    break;
            }
            SaveDefaultWarnSet(modDefault);
        }

        private void skinTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            this.lblBloodLeak.Text = trackBar1.Value.ToString();
        }

        private void lblBloodLeak_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSetFlush_Click(object sender, EventArgs e)
        {
            //<!--清洗量设定-->
            //<add key="PEFlushOut" value="1000"/>
            //<add key="PEFlushIn" value="2000"/>
            Cls.RWconfig.SetAppSettings("peflush1", this.lblPEFlush1.Text);
            Cls.RWconfig.SetAppSettings("peflush2", this.lblPEFlush2.Text);
            Cls.RWconfig.SetAppSettings("ppflush1", this.lblPPFlush1.Text);
            Cls.RWconfig.SetAppSettings("ppflush2", this.lblPPFlush2.Text);
            Cls.RWconfig.SetAppSettings("chdfflush1", this.lblCHDFFlush1.Text);
            Cls.RWconfig.SetAppSettings("chdfflush2", this.lblCHDFFlush2.Text);
            Cls.RWconfig.SetAppSettings("lialsflush1", this.lblLiALSFLush1.Text);
            Cls.RWconfig.SetAppSettings("lialsflush2", this.lblLiALSFLush2.Text);
            Cls.RWconfig.SetAppSettings("pefflush1", this.lblPEFFlush1.Text);
            Cls.RWconfig.SetAppSettings("pefflush2", this.lblPEFFlush2.Text);
            Cls.RWconfig.SetAppSettings("pdfflush1", this.lblPDFFlush1.Text);
            Cls.RWconfig.SetAppSettings("pdfflush2", this.lblPDFFlush2.Text);
            switch (_modelTreat.name)
            {
                case "Li-ALS":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("lialsflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("lialsflush2"));
                    //修改整体预冲时间
                    double addflush = dRequireFlush - 3500;
                    double t = addflush/3;
                    //读取原整体预冲时间
                    BLL.customactions bllcua = new BLL.customactions();
                    Model.customactions modcua = bllcua.GetModel("Li-ALS_Flush", "全体冲洗");
                    if (modcua != null)
                    {
                        int newtime = modcua.timeSpan.Value + (int)t;
                        modcua.timeSpan = newtime;
                        bllcua.Update(modcua);
                    }
                    break;
                case "PE":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("peflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("peflush2"));
                    //修改整体预冲时间
                    addflush = dRequireFlush - 1500;
                    t = addflush/3;
                    //读取原整体预冲时间
                    bllcua = new BLL.customactions();
                    modcua = bllcua.GetModel("PE_Flush", "全体冲洗");
                    if (modcua != null)
                    {
                        int newtime = modcua.timeSpan.Value + (int)t;
                        modcua.timeSpan = newtime;
                        bllcua.Update(modcua);
                    }
                    break;
                case "CHDF":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("chdfflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("chdfflush2"));
                    //修改整体预冲时间
                    addflush = dRequireFlush - 1500;
                    t = addflush / 3;
                    //读取原整体预冲时间
                    bllcua = new BLL.customactions();
                    modcua = bllcua.GetModel("PE_Flush", "全体冲洗");
                    if (modcua != null)
                    {
                        int newtime = modcua.timeSpan.Value + (int)t;
                        modcua.timeSpan = newtime;
                        bllcua.Update(modcua);
                    }
                    break;
                case "PP":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("ppflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("ppflush2"));
                    //修改整体预冲时间
                    addflush = dRequireFlush - 1500;
                    t = addflush / 3;
                    //读取原整体预冲时间
                    bllcua = new BLL.customactions();
                    modcua = bllcua.GetModel("PP_Flush", "全体冲洗");
                    if (modcua != null)
                    {
                        int newtime = modcua.timeSpan.Value + (int)t;
                        modcua.timeSpan = newtime;
                        bllcua.Update(modcua);
                    }
                    
                    break;
                case "PERT":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("pefflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("pefflush2"));
                    //修改整体预冲时间
                    addflush = dRequireFlush - 3000;
                    t = addflush / 3;
                    //读取原整体预冲时间
                    bllcua = new BLL.customactions();
                    modcua = bllcua.GetModel("PERT_Flush", "全体冲洗");
                    if (modcua != null)
                    {
                        int newtime = modcua.timeSpan.Value + (int)t;
                        modcua.timeSpan = newtime;
                        bllcua.Update(modcua);
                    }
                    break;
                case "PDF":
                    dRequireFlush = Convert.ToDouble(Cls.RWconfig.GetAppSettings("pdfflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("pdfflush2"));
                    //修改整体预冲时间
                    addflush = dRequireFlush - 1500;
                    t = addflush / 3;
                    //读取原整体预冲时间
                    bllcua = new BLL.customactions();
                    modcua = bllcua.GetModel("PDF_Flush", "全体冲洗");
                    if (modcua != null)
                    {
                        int newtime = modcua.timeSpan.Value + (int)t;
                        modcua.timeSpan = newtime;
                        bllcua.Update(modcua);
                    }
                    break;
            }
            ReadFlush();
            MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
