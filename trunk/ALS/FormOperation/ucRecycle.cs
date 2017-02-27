using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ALS.FormOperation
{
    public partial class ucRecycle : UserControl
    {
        /// <summary>
        /// 压力值范围模型
        /// </summary>
        private Cls.Model_WarnValue _modelwarn;
        public Cls.Model_WarnValue _ModelWarn
        {
            get { return _modelwarn; }
            set { _modelwarn = value; }
        }

        private Cls.Model_State _modelPumpState;
        public Cls.Model_State _ModelPumpState
        {
            get { return _modelPumpState; }
            set { _modelPumpState = value; }
        }

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

        //运转泵委托事件
        public delegate void dlgRecycle_btnRunBP(object sender, EventArgs e);
        public event dlgRecycle_btnRunBP recycle_btnRunBP;
 
        //所有阀关闭
        public delegate void dlgRecycle_btnCloseAll(object sender, EventArgs e);
        public event dlgRecycle_btnCloseAll recyle_btnCloseAll;
        /// <summary>
        /// 压力值范围显示
        /// </summary>     

        public ucRecycle()
        {
            InitializeComponent();
        }

        private void ucfrmRecycle_SizeChanged(object sender, EventArgs e)
        {
            //this.groupRecycle.Left = (this.Width - this.groupRecycle.Width) / 2;
            //this.groupRecycle.Top = (this.Height - this.groupRecycle.Height) / 2;
            //获取当前分辨率
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 898.0f;
            float y = rec.Height / 578.0f;
            Cls.utils.AutoSize(this, x, y);
        }

        private void ucfrmRecycle_Load(object sender, EventArgs e)
        {
            SetButtonState(_modelPumpState);
        }

        public void SetButtonState(Cls.Model_State _modPumpState)
        {
            if (_modPumpState != null)
            {
                if (_modPumpState.BPState.Runing)
                {
                    this.btnRun1.Text = "停止";
                    this.btnRun1.Image = Properties.Resources.spstop;
                    this.btnRun1.ForeColor = Color.Red;
                    //this.lblBP.Text = _modelPumpState.BPState.Speed.ToString();
                    this.lblBP.Enabled = false;
                }
                else
                {
                    this.btnRun1.Text = "运转";
                    this.btnRun1.Image = Properties.Resources.spstart;
                    this.btnRun1.ForeColor = Color.FromArgb(15, 8, 100);
                    //this.lblBP.Text = _modelPumpState.BPState.Speed.ToString();
                    this.lblBP.Enabled = true;
                }

                if (_modPumpState.FPState.Runing)
                {
                    this.btnRun2.Text = "停止";
                    this.btnRun2.Image = Properties.Resources.spstop;
                    this.btnRun2.ForeColor = Color.Red;
                    //this.lblFP.Text = _modelPumpState.FPState.Speed.ToString();
                    this.lblFP.Enabled = false;
                }
                else
                {
                    this.btnRun2.Text = "运转";
                    this.btnRun2.Image = Properties.Resources.spstart;
                    this.btnRun2.ForeColor = Color.FromArgb(15, 8, 100);
                    //this.lblFP.Text = _modelPumpState.FPState.Speed.ToString();
                    this.lblFP.Enabled = true;
                }

                if (_modPumpState.DPState.Runing)
                {
                    this.btnRun3.Text = "停止";
                    this.btnRun3.Image = Properties.Resources.spstop;
                    this.btnRun3.ForeColor = Color.Red;
                    //this.lblDP.Text = _modelPumpState.DPState.Speed.ToString();
                    this.lblDP.Enabled = false;
                }
                else
                {
                    this.btnRun3.Text = "运转";
                    this.btnRun3.Image = Properties.Resources.spstart;
                    this.btnRun3.ForeColor = Color.FromArgb(15, 8, 100);
                    //this.lblDP.Text = _modelPumpState.DPState.Speed.ToString();
                    this.lblDP.Enabled = true;
                }

                if (_modPumpState.RPState.Runing)
                {
                    this.btnRun4.Text = "停止";
                    this.btnRun4.Image = Properties.Resources.spstop;
                    this.btnRun4.ForeColor = Color.Red;
                    //this.lblRP.Text = _modelPumpState.RPState.Speed.ToString();
                    this.lblRP.Enabled = false;
                }
                else
                {
                    this.btnRun4.Text = "运转";
                    this.btnRun4.Image = Properties.Resources.spstart;
                    this.btnRun4.ForeColor = Color.FromArgb(15, 8, 100);
                    //this.lblRP.Text = _modelPumpState.RPState.Speed.ToString();
                    this.lblRP.Enabled = false;
                }

                if (_modPumpState.FP2State.Runing)
                {
                    this.btnRun5.Text = "停止";
                    this.btnRun5.Image = Properties.Resources.spstop;
                    this.btnRun5.ForeColor = Color.Red;
                }
                else
                {
                    this.btnRun5.Text = "运转";
                    this.btnRun5.Image = Properties.Resources.spstart;
                    this.btnRun5.ForeColor = Color.FromArgb(15, 8, 100);
                }

                if (_modPumpState.CPState.Runing)
                {
                    this.btnRun6.Text = "停止";
                    this.btnRun6.Image = Properties.Resources.spstop;
                    this.btnRun6.ForeColor = Color.Red;
                }
                else
                {
                    this.btnRun6.Text = "运转";
                    this.btnRun6.Image = Properties.Resources.spstart;
                    this.btnRun6.ForeColor = Color.FromArgb(15, 8, 100);
                }
            }
        }

        private void btnRunBP_Click(object sender, EventArgs e)
        {
            //if (recycle_btnRunBP != null)
            //    recycle_btnRunBP(sender, e);
            Button btn = sender as Button;
            double speed = 0;
            if (btn.Tag != null)
            {
                int id = Convert.ToInt16(btn.Tag.ToString());
                switch (id)
                {
                    case 1:
                        if (btn.Text == "运转")
                        {
                            speed = Convert.ToDouble(this.lblBP.Text);
                            if(speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(0x01, speed, true,true));
                            btn.Text = "停止";
                            btn.Image = Properties.Resources.spstop;
                            btn.ForeColor = Color.Red;
                            this.lblBP.Enabled = false;
                        }
                        else
                        {
                            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(0x01, 0, false, true)); 
                            btn.Text = "运转";
                            btn.Image = Properties.Resources.spstart;
                            btn.ForeColor = Color.FromArgb(15, 8, 100);
                            this.lblBP.Enabled = true;
                        }
                        break;
                    case 2:
                        if (btn.Text == "运转")
                        {
                            speed = Convert.ToDouble(this.lblFP.Text);
                            if (speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                            
                            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(0x02, speed, true, true));
                            btn.Text = "停止";
                            btn.Image = Properties.Resources.spstop;
                            btn.ForeColor = Color.Red;
                            this.lblFP.Enabled = false;
                        }
                        else
                        {
                            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(0x02, 0, false, true));
                            btn.Text = "运转";
                            btn.Image = Properties.Resources.spstart;
                            btn.ForeColor = Color.FromArgb(15, 8, 100);
                            this.lblFP.Enabled = true;
                        }
                        break;
                    case 3:
                        if (btn.Text == "运转")
                        { 
                            speed = Convert.ToDouble(this.lblDP.Text);
                            if (speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                           
                            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(0x03, speed, true, true));
                            btn.Text = "停止";
                            btn.Image = Properties.Resources.spstop;
                            btn.ForeColor = Color.Red;
                            this.lblDP.Enabled = false;
                        }
                        else
                        {
                            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(0x03, 0, false, true));
                            btn.Text = "运转";
                            btn.Image = Properties.Resources.spstart;
                            btn.ForeColor = Color.FromArgb(15, 8, 100);
                            this.lblDP.Enabled = true;
                        }
                        break;
                    case 4:
                        if (btn.Text == "运转")
                        { 
                            speed = Convert.ToDouble(this.lblRP.Text);
                            if (speed == 0)
                            {
                                MessageBox.Show("泵速不能为0,请重新设置!"); return;
                            }
                           
                            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(0x04, speed, true, true));
                            btn.Text = "停止";
                            btn.Image = Properties.Resources.spstop;
                            btn.ForeColor = Color.Red;
                            this.lblRP.Enabled = false;
                        }
                        else
                        {
                            Cls.utils.SendOrder(_port_ppump, Cls.Comm_PeristalticPump.Command(0x04, 0, false, true));
                            btn.Text = "运转";
                            btn.Image = Properties.Resources.spstart;
                            btn.ForeColor = Color.FromArgb(15, 8, 100);
                            this.lblRP.Enabled = true;
                        }
                        break;
                }
            }
        } 

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            if (recyle_btnCloseAll != null)
                recyle_btnCloseAll(sender, e);
        }

        private DataTable dsCustomActions(string methodname)
        {
            DataTable dt = new DataTable();
            ALS.BLL.customactions bllcustom = new ALS.BLL.customactions();
            dt = bllcustom.GetList(" methodname='" + methodname + "'", true).Tables[0];
            dt.Columns.Add("  ", System.Type.GetType("System.String")).SetOrdinal(1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][1] = (i + 1).ToString();
            }
            return dt;
        }

        public void ShowRecycleActions(string _m)
        {
            this.dgvRecycle.DataSource = dsCustomActions(_m);
            for (int i = 0; i < this.dgvRecycle.Columns.Count; i++)
            {
                this.dgvRecycle.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dgvRecycle.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 
            }
            this.dgvRecycle.Columns[0].Visible = false; 
            this.dgvRecycle.Columns["步骤"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvRecycle.Refresh();
        }

        private void lblBP_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lb.Text);
            _numPad.btnNegPos.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                if (_numPad.Value > 350 || _numPad.Value < 0)
                {
                    MessageBox.Show("请将泵速设置在 (0-350)mL/min 以内!");
                    return;
                }                    
                lb.Text = _numPad.Value.ToString("f1");
            }
        }

    }
}
