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
        private Model.treatmentmode _modelTreat;
        public Model.treatmentmode _ModelTreat
        {
            get { return _modelTreat; }
            set { _modelTreat = value; }
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

        //夹管阀操作
        public delegate void chkVClick(object sender, EventArgs e);
        public event chkVClick checkVClick;
        /// <summary>
        /// 压力值范围显示
        /// </summary>     

        public ucRecycle()
        {
            InitializeComponent();
        }
        private int sizechangedcount = 0;
        private void ucfrmRecycle_SizeChanged(object sender, EventArgs e)
        {
            //this.groupRecycle.Left = (this.Width - this.groupRecycle.Width) / 2;
            //this.groupRecycle.Top = (this.Height - this.groupRecycle.Height) / 2;
            //获取当前分辨率
            //if (sizechangedcount == 0)
            //{
            //    Rectangle rec = this.ClientRectangle;
            //    //与基准分辨率的放大系数
            //    float x = rec.Width / 898.0f;
            //    float y = rec.Height / 550.0f;
            //    Cls.utils.AutoSize(this, x, y);
            //}
            //sizechangedcount = 1;
        }

        private void ucfrmRecycle_Load(object sender, EventArgs e)
        {
            SetButtonState(_modelPumpState);
        }

        public void SetButtonState(Cls.Model_State _modPumpState)
        {
            if (_modPumpState != null)
            {
                if(_modelTreat.BPValid)
                {
                    if (_modPumpState.BPState.Runing)
                    {
                        this.btnRunBP.Text = "停止";
                        this.btnRunBP.Image = Properties.Resources.spstop;
                        this.btnRunBP.ForeColor = Color.Red;
                        this.lblBP.Text = _modelPumpState.BPState.Speed.ToString();
                        this.lblBP.Enabled = false; 
                    }
                    else
                    {
                        this.btnRunBP.Text = "运转";
                        this.btnRunBP.Image = Properties.Resources.spstart;
                        this.btnRunBP.ForeColor = Color.White;
                        this.lblBP.Text =  _modelPumpState.BPState.Speed.ToString();
                        this.lblBP.Enabled = true;
                    }
                    this.btnRunBP.Enabled = true;
                }
                else 
                    this.btnRunBP.Enabled = this.lblBP.Enabled = false; 

                if (_modelTreat.FPValid)
                {
                    if (_modPumpState.FPState.Runing)
                    {
                        this.btnRunFP.Text = "停止";
                        this.btnRunFP.Image = Properties.Resources.spstop;
                        this.btnRunFP.ForeColor = Color.Red;
                        //this.lblFP.Text = _modelPumpState.FPState.Speed.ToString();
                        this.lblFP.Enabled = false;
                    }
                    else
                    {
                        this.btnRunFP.Text = "运转";
                        this.btnRunFP.Image = Properties.Resources.spstart;
                        this.btnRunFP.ForeColor = Color.White;
                        //this.lblFP.Text = _modelPumpState.FPState.Speed.ToString();
                        this.lblFP.Enabled = true;
                    }
                    this.btnRunFP.Enabled = true;
                }
                else
                    this.btnRunFP.Enabled = this.lblFP.Enabled = false;

                if (_modelTreat.DPValid)
                {
                    if (_modPumpState.DPState.Runing)
                    {
                        this.btnRunDP.Text = "停止";
                        this.btnRunDP.Image = Properties.Resources.spstop;
                        this.btnRunDP.ForeColor = Color.Red;
                        //this.lblDP.Text = _modelPumpState.DPState.Speed.ToString();
                        this.lblDP.Enabled = false;
                    }
                    else
                    {
                        this.btnRunDP.Text = "运转";
                        this.btnRunDP.Image = Properties.Resources.spstart;
                        this.btnRunDP.ForeColor = Color.White;
                        //this.lblDP.Text = _modelPumpState.DPState.Speed.ToString();
                        this.lblDP.Enabled = true;
                    }
                    this.btnRunDP.Enabled = true;
                }
                else
                    this.btnRunDP.Enabled = this.lblDP.Enabled = false;

                if (_modelTreat.RPValid)
                {
                    if (_modPumpState.RPState.Runing)
                    {
                        this.btnRunRP.Text = "停止";
                        this.btnRunRP.Image = Properties.Resources.spstop;
                        this.btnRunRP.ForeColor = Color.Red;
                        //this.lblRP.Text = _modelPumpState.RPState.Speed.ToString();
                        this.lblRP.Enabled = false;
                    }
                    else
                    {
                        this.btnRunRP.Text = "运转";
                        this.btnRunRP.Image = Properties.Resources.spstart;
                        this.btnRunRP.ForeColor = Color.White;
                        //this.lblRP.Text = _modelPumpState.RPState.Speed.ToString();
                        this.lblRP.Enabled = true;
                    }
                    this.btnRunRP.Enabled = true;
                }
                else
                    this.btnRunRP.Enabled = this.lblRP.Enabled = false;

                if (_modelTreat.FP2Valid)
                {
                    if (_modPumpState.FP2State.Runing)
                    {
                        this.btnRunFP2.Text = "停止";
                        this.btnRunFP2.Image = Properties.Resources.spstop;
                        this.btnRunFP2.ForeColor = Color.Red;
                        this.lblFP2.Text = _modelPumpState.FP2State.Speed.ToString();
                        this.lblFP2.Enabled = false; 
                    }
                    else
                    {
                        this.btnRunFP2.Text = "运转";
                        this.btnRunFP2.Image = Properties.Resources.spstart;
                        this.btnRunFP2.ForeColor = Color.White;
                        //this.lblFP2.Text = _modelPumpState.FP2State.Speed.ToString();
                        this.lblFP2.Enabled = true;
                    }
                    this.btnRunFP2.Enabled = true;
                }
                else
                    this.btnRunFP2.Enabled = this.lblFP2.Enabled = false;

                if (_modelTreat.CPValid)
                {
                    if (_modPumpState.CPState.Runing)
                    {
                        this.btnRunCP.Text = "停止";
                        this.btnRunCP.Image = Properties.Resources.spstop;
                        this.btnRunCP.ForeColor = Color.Red;
                        //this.lblCP.Text = _modelPumpState.CPState.Speed.ToString();
                        this.lblCP.Enabled = false;
                    }
                    else
                    {
                        this.btnRunCP.Text = "运转";
                        this.btnRunCP.Image = Properties.Resources.spstart;
                        this.btnRunCP.ForeColor = Color.White;
                        //this.lblCP.Text = _modelPumpState.CPState.Speed.ToString();
                        this.lblCP.Enabled = true;
                    }
                    this.btnRunCP.Enabled = true;
                }
                else
                    this.btnRunCP.Enabled = this.lblCP.Enabled = false;
            }
        }

        private void btnRunBP_Click(object sender, EventArgs e)
        {
            if (recycle_btnRunBP != null)
                recycle_btnRunBP(sender, e);
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            if (recyle_btnCloseAll != null)
                recyle_btnCloseAll(sender, e);
            //this.groupBox3.Enabled = false;
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
            this.dgvRecycle.Columns["描述"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvRecycle.Columns["timeSpan"].Visible = false;
            this.dgvRecycle.Refresh();
        }

        private void lblBP_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            UserCtrl.numPad _numPad = new UserCtrl.numPad(lb.Text);
            _numPad.btnNegPos.Visible = false;
            _numPad.btnDot.Visible = false;
            if (DialogResult.OK == _numPad.ShowDialog())
            {
                if (_numPad.Value > 50 || _numPad.Value < 0)
                {
                    MessageBox.Show("请将回收时的泵速设置在 (0-50)mL/min 以内!");
                    return;
                } 
                lb.Text = _numPad.Value.ToString("f0");
            }
        }

        private void chkV1_Click(object sender, EventArgs e)
        {
            if (checkVClick != null)
                checkVClick(sender, e);
        }

    }
}
