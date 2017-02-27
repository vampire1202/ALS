using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;

namespace ALS.FormSet
{
    public partial class ucSetSum : UserControl
    {
        //wss
        //public Series[] Total_Flux = new Series[5];
        DateTime Flux_total = DateTime.Now;

        public ucSetSum()
        {
            InitializeComponent();
        }

        private Cls.Model_Total _modelTotal;
        public Cls.Model_Total _ModelTotal
        {
            get { return _modelTotal; }
            set { _modelTotal = value; }
        }


        private Cls.Model_Total _modelTotalPE;
        public Cls.Model_Total _ModelTotalPE
        {
            get { return _modelTotalPE; }
            set { _modelTotalPE = value; }
        }

        //private string _section;
        //public string _Section
        //{
        //    get { return _section; }
        //    set { _section = value; }
        //}

        private Model.treatmentmode _modelTreat;
        public Model.treatmentmode _ModelTreat
        {
            get { return _modelTreat; }
            set { _modelTreat = value; }
        }



        //定义委托
        public delegate void BtnClick(object sender, EventArgs e);
        //定义事件
        public event BtnClick btnZeroSum;


        private void ucSum_Load(object sender, EventArgs e)
        {
            //ReadSet(_section);
            //ReadTotal();
        }


        public void ReadTotal()
        {
            this.lblTotalTime.Text = Cls.utils.SecondsToTime(_modelTotal.TotalTime);//_modelTotal.TotalTime.Hours.ToString("00") + ":" + _modelTotal.TotalTime.Minutes.ToString("00") + ":" + _modelTotal.TotalTime.Seconds.ToString("00");
            this.lblTotalBP.Text = _modelTotal.TotalBP.ToString("f3");
            this.lblTotalFP.Text = _modelTotal.TotalFP.ToString("f3");
            this.lblTotalRP.Text = _modelTotal.TotalRP.ToString("f3");
            this.lblTotalDP.Text = _modelTotal.TotalDP.ToString("f3");
            this.lblTotalSP.Text = _modelTotal.TotalSP.ToString("f1");

            this.lblTotalTime1.Text = Cls.utils.SecondsToTime(_modelTotalPE.TotalTime);//_modelTotal.TotalTime.Hours.ToString("00") + ":" + _modelTotal.TotalTime.Minutes.ToString("00") + ":" + _modelTotal.TotalTime.Seconds.ToString("00");
            this.lblTotalBP1.Text = _modelTotalPE.TotalBP.ToString("f3");
            this.lblTotalFP1.Text = _modelTotalPE.TotalFP.ToString("f3");
            this.lblTotalRP1.Text = _modelTotalPE.TotalRP.ToString("f3");
            this.lblTotalDP1.Text = _modelTotalPE.TotalDP.ToString("f3");
            this.lblTotalSP1.Text = _modelTotalPE.TotalSP.ToString("f1");
        } 
        private void ucSum_SizeChanged(object sender, EventArgs e)
        {
            //this.groupSet.Left = (this.Width - this.groupSet.Width) / 2;
            //this.groupSet.Top = (this.Height - this.groupSet.Height) / 2;
            //获取当前分辨率
            //if(sizechangedcount ==0 )
            //{
            //    Rectangle rec = this.ClientRectangle;
            //    //与基准分辨率的放大系数
            //    float x = rec.Width / 898.0f;
            //    float y = rec.Height / 578.0f;
            //    Cls.utils.AutoSize(this, x, y);
            //}
            //sizechangedcount=1;
        }

        private void chbTime_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            { cb.BackColor = Color.FromArgb(0, 128, 0); cb.Text = "有效"; }
            else
            { cb.BackColor = Color.FromArgb(218, 18, 18); cb.Text = "无效"; }            
        }

        private void btnSetTemperature_Click(object sender, EventArgs e)
        {
            SaveSet(_modelTreat);
        }

        private void SaveSet(Model.treatmentmode _mtreat)
        {
            _mtreat.TargetTimeH = int.Parse(this.lblTimeH.Text);
            _mtreat.TargetTimeMin = int.Parse(this.lblTimeMin.Text);
            _mtreat.IsTargetTime = (this.chbTime.Checked ? true : false);
            _mtreat.TargetBP = double.Parse(this.lblBP.Text);
            _mtreat.IsTargetBP = (this.chbBP.Checked ? true : false);
            _mtreat.TargetSP = double.Parse(this.lblSP.Text);
            _mtreat.IsTargetSP = (this.chbSP.Checked ? true : false);
            _mtreat.TargetDP = double.Parse(this.lblDP.Text);
            _mtreat.IsTargetDP = (this.chbDP.Checked ? true : false);
            _mtreat.TargetRP = double.Parse(this.lblRP.Text);
            _mtreat.IsTargetRP = (this.chbRP.Checked ? true : false);
            _mtreat.TargetFP = double.Parse(this.lblFP.Text);
            _mtreat.IsTargetFP = (this.chbFP.Checked ? true : false);
            BLL.treatmentmode bllt = new BLL.treatmentmode();
            if (bllt.Update(_mtreat))
            {
                ReadSet(_mtreat);
                MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }

        public void ReadSet(Model.treatmentmode mtreat)
        {
            this.lblTimeH.Text = mtreat.TargetTimeH.Value.ToString();
            this.lblTimeMin.Text = mtreat.TargetTimeMin.Value.ToString();
            this.chbTime.Checked = (mtreat.IsTargetTime ? true : false);
            this.lblBP.Text = mtreat.TargetBP.Value.ToString();
            this.chbBP.Checked = (mtreat.IsTargetBP ? true :false);
            this.lblDP.Text = mtreat.TargetDP.Value.ToString();
            this.chbDP.Checked = (mtreat.IsTargetDP ? true : false);
            this.lblSP.Text = mtreat.TargetSP.Value.ToString();
            this.chbSP.Checked = (mtreat.IsTargetSP ? true : false);
            this.lblFP.Text = mtreat.TargetFP.Value.ToString();
            this.chbFP.Checked = (mtreat.IsTargetFP ? true : false);
            this.lblRP.Text = mtreat.TargetRP.Value.ToString();
            this.chbRP.Checked = (mtreat.IsTargetRP ? true : false);
        }

        private void lblTimeH_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad np = new UserCtrl.numPad(lbl.Text);
            np.btnDot.Visible = false;
            np.btnNegPos.Visible = false;
            if (DialogResult.OK == np.ShowDialog())
            {
                if (lbl.Name == "lblTimeMin")
                {
                    if (np.Value >= 59)
                        np.Value = 59;
                }
                if(lbl.Name=="lblTimeH")
                {
                    if (np.Value > 999)
                        np.Value = 999;
                }
                lbl.Text = np.Value.ToString("00");
            }
        }

        private void lblBP_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad np = new UserCtrl.numPad(lbl.Text);
            np.btnNegPos.Visible = false;
            if (DialogResult.OK == np.ShowDialog())
            {
                if (np.Value > 0 && np.Value <= 999)
                {
                    lbl.Text = np.Value.ToString("f0");
                }
                else
                {
                    MessageBox.Show("设置超出范围,请重新设置!");
                }
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            if (btnZeroSum != null)
                btnZeroSum(sender, e);
        }

        private void groupSet_Enter(object sender, EventArgs e)
        {

        }

        private void lblSP_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad np = new UserCtrl.numPad(lbl.Text);
            np.btnNegPos.Visible = false;
            if (DialogResult.OK == np.ShowDialog())
            {
                if (np.Value > 0 && np.Value <= 999)
                {
                    lbl.Text = np.Value.ToString("f0");
                }
                else
                {
                    MessageBox.Show("设置目标超出范围,请重新设置!");
                }
            }
        }
    }
}
