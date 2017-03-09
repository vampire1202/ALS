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
                        this.btnRun1.Text = "停止";
                        this.btnRun1.Image = Properties.Resources.spstop;
                        this.btnRun1.ForeColor = Color.Red;
                        this.txtBP.Text = _modelPumpState.BPState.Speed.ToString();
                        this.txtBP.Enabled = false; 
                    }
                    else
                    {
                        this.btnRun1.Text = "运转";
                        this.btnRun1.Image = Properties.Resources.spstart;
                        this.btnRun1.ForeColor = Color.White;
                        this.txtBP.Text =  _modelPumpState.BPState.Speed.ToString();
                        this.txtBP.Enabled = true;
                    }
                    this.btnRun1.Enabled = true;
                }
                else 
                    this.btnRun1.Enabled = this.txtBP.Enabled = false; 

                if (_modelTreat.FPValid)
                {
                    if (_modPumpState.FPState.Runing)
                    {
                        this.btnRun2.Text = "停止";
                        this.btnRun2.Image = Properties.Resources.spstop;
                        this.btnRun2.ForeColor = Color.Red;
                        //this.lblFP.Text = _modelPumpState.FPState.Speed.ToString();
                        this.txtFP.Enabled = false;
                    }
                    else
                    {
                        this.btnRun2.Text = "运转";
                        this.btnRun2.Image = Properties.Resources.spstart;
                        this.btnRun2.ForeColor = Color.White;
                        //this.lblFP.Text = _modelPumpState.FPState.Speed.ToString();
                        this.txtFP.Enabled = true;
                    }
                    this.btnRun2.Enabled = true;
                }
                else
                    this.btnRun2.Enabled = this.txtFP.Enabled = false;

                if (_modelTreat.DPValid)
                {
                    if (_modPumpState.DPState.Runing)
                    {
                        this.btnRun3.Text = "停止";
                        this.btnRun3.Image = Properties.Resources.spstop;
                        this.btnRun3.ForeColor = Color.Red;
                        //this.lblDP.Text = _modelPumpState.DPState.Speed.ToString();
                        this.txtDP.Enabled = false;
                    }
                    else
                    {
                        this.btnRun3.Text = "运转";
                        this.btnRun3.Image = Properties.Resources.spstart;
                        this.btnRun3.ForeColor = Color.White;
                        //this.lblDP.Text = _modelPumpState.DPState.Speed.ToString();
                        this.txtDP.Enabled = true;
                    }
                    this.btnRun3.Enabled = true;
                }
                else
                    this.btnRun3.Enabled = this.txtDP.Enabled = false;

                if (_modelTreat.RPValid)
                {
                    if (_modPumpState.RPState.Runing)
                    {
                        this.btnRun4.Text = "停止";
                        this.btnRun4.Image = Properties.Resources.spstop;
                        this.btnRun4.ForeColor = Color.Red;
                        //this.lblRP.Text = _modelPumpState.RPState.Speed.ToString();
                        this.txtRP.Enabled = false;
                    }
                    else
                    {
                        this.btnRun4.Text = "运转";
                        this.btnRun4.Image = Properties.Resources.spstart;
                        this.btnRun4.ForeColor = Color.White;
                        //this.lblRP.Text = _modelPumpState.RPState.Speed.ToString();
                        this.txtRP.Enabled = true;
                    }
                    this.btnRun4.Enabled = true;
                }
                else
                    this.btnRun4.Enabled = this.txtRP.Enabled = false;

                if (_modelTreat.FP2Valid)
                {
                    if (_modPumpState.FP2State.Runing)
                    {
                        this.btnRun5.Text = "停止";
                        this.btnRun5.Image = Properties.Resources.spstop;
                        this.btnRun5.ForeColor = Color.Red;
                        this.txtFP2.Text = _modelPumpState.FP2State.Speed.ToString();
                        this.txtFP2.Enabled = false; 
                    }
                    else
                    {
                        this.btnRun5.Text = "运转";
                        this.btnRun5.Image = Properties.Resources.spstart;
                        this.btnRun5.ForeColor = Color.White;
                        //this.lblFP2.Text = _modelPumpState.FP2State.Speed.ToString();
                        this.txtFP2.Enabled = true;
                    }
                    this.btnRun5.Enabled = true;
                }
                else
                    this.btnRun5.Enabled = this.txtFP2.Enabled = false;

                if (_modelTreat.CPValid)
                {
                    if (_modPumpState.CPState.Runing)
                    {
                        this.btnRun6.Text = "停止";
                        this.btnRun6.Image = Properties.Resources.spstop;
                        this.btnRun6.ForeColor = Color.Red;
                        //this.lblCP.Text = _modelPumpState.CPState.Speed.ToString();
                        this.txtCP.Enabled = false;
                    }
                    else
                    {
                        this.btnRun6.Text = "运转";
                        this.btnRun6.Image = Properties.Resources.spstart;
                        this.btnRun6.ForeColor = Color.White;
                        //this.lblCP.Text = _modelPumpState.CPState.Speed.ToString();
                        this.txtCP.Enabled = true;
                    }
                    this.btnRun6.Enabled = true;
                }
                else
                    this.btnRun6.Enabled = this.txtCP.Enabled = false;
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
