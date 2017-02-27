using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALS.FormSet
{
    public partial class ucSetSum : UserControl
    {
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

        private string _section;
        public string _Section
        {
            get { return _section; }
            set { _section = value; }
        }

        //定义委托
        public delegate void BtnClick(object sender, EventArgs e);
        //定义事件
        public event BtnClick btnZeroSum;


        private void ucSum_Load(object sender, EventArgs e)
        {
            ReadSet(_section);
            ReadTotal();
        }

        public void ReadTotal()
        {
            this.lblTotalTime.Text = Cls.utils.SecondsToTime(_modelTotal.TotalTime);//_modelTotal.TotalTime.Hours.ToString("00") + ":" + _modelTotal.TotalTime.Minutes.ToString("00") + ":" + _modelTotal.TotalTime.Seconds.ToString("00");
            this.lblTotalBP.Text = _modelTotal.TotalBP.ToString("f3");
            this.lblTotalFP.Text = _modelTotal.TotalFP.ToString("f3");
            this.lblTotalRP.Text = _modelTotal.TotalRP.ToString("f3");           
            this.lblTotalDP.Text = _modelTotal.TotalDP.ToString("f3"); 
            this.lblTotalSP.Text = _modelTotal.TotalSP.ToString("f1");
        }

        private void ucSum_SizeChanged(object sender, EventArgs e)
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
            SaveSet(_section);
        }

        private void SaveSet(string sec)
        {  
            //<add key="TargetTimeH" value="08"/>
            //<add key ="TargetTimeMin" value="08"/>
            //<add key="IsTargetTime" value="true"/>
            //<add key ="TargetBP" value="1000"/>
            //<add key="IsTargetBP" value="true"/>
            //<add key ="TargetSP" value="50"/>
            //<add key ="IsTargetSP" value="true"/>
            //<add key ="TargetRP" value="50"/>
            //<add key="IsTargetRP" value="true"/>
            //<add key="TargetFP" value="50"/>
            //<add key="IsTargetFP" value="true"/>
            //Cls.RWconfig.SetAppSettings("TargetTimeH", this.lblTimeH.Text);
            Cls.utils.SetSectionKeyValue(sec, "TargetTimeH", this.lblTimeH.Text);
            //Cls.RWconfig.SetAppSettings("TargetTimeMin", this.lblTimeMin.Text);
            Cls.utils.SetSectionKeyValue(sec, "TargetTimeMin", this.lblTimeMin.Text);
            //Cls.RWconfig.SetAppSettings("IsTargetTime", this.chbTime.Checked ? "true" : "false");
            Cls.utils.SetSectionKeyValue(sec, "IsTargetTime", this.chbTime.Checked ? "true" : "false");
            //Cls.RWconfig.SetAppSettings("TargetBP", this.lblBP.Text);
            Cls.utils.SetSectionKeyValue(sec, "TargetBP", this.lblBP.Text);
            //Cls.RWconfig.SetAppSettings("IsTargetBP", this.chbBP.Checked ? "true" : "false");
            Cls.utils.SetSectionKeyValue(sec, "IsTargetBP", this.chbBP.Checked ? "true" : "false");
            //Cls.RWconfig.SetAppSettings("TargetSP", this.lblSP.Text);
            Cls.utils.SetSectionKeyValue(sec, "TargetSP", this.lblSP.Text);
            //Cls.RWconfig.SetAppSettings("IsTargetSP", this.chbSP.Checked ? "true" : "false");
            Cls.utils.SetSectionKeyValue(sec, "IsTargetSP", this.chbSP.Checked ? "true" : "false");
            //Cls.RWconfig.SetAppSettings("TargetDP", this.lblDP.Text);
            Cls.utils.SetSectionKeyValue(sec, "TargetDP", this.lblDP.Text);
            //Cls.RWconfig.SetAppSettings("IsTargetDP", this.chbDP.Checked ? "true" : "false");
            Cls.utils.SetSectionKeyValue(sec, "IsTargetDP", this.chbDP.Checked ? "true" : "false");
            //Cls.RWconfig.SetAppSettings("TargetRP", this.lblRP.Text);
            Cls.utils.SetSectionKeyValue(sec, "TargetRP", this.lblRP.Text);
            //Cls.RWconfig.SetAppSettings("IsTargetRP", this.chbRP.Checked ? "true" : "false");
            Cls.utils.SetSectionKeyValue(sec, "IsTargetRP", this.chbRP.Checked ? "true" : "false");
            //Cls.RWconfig.SetAppSettings("TargetFP", this.lblFP.Text);
            Cls.utils.SetSectionKeyValue(sec, "TargetFP", this.lblFP.Text);
            //Cls.RWconfig.SetAppSettings("IsTargetFP", this.chbFP.Checked ? "true" : "false");
            Cls.utils.SetSectionKeyValue(sec, "IsTargetFP", this.chbFP.Checked ? "true" : "false");
            MessageBox.Show("保存成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ReadSet(string sec)
        {
            //this.lblTimeH.Text = Cls.RWconfig.GetAppSettings("TargetTimeH");
            this.lblTimeH.Text = Cls.utils.GetSectionKeyValue(sec, "TargetTimeH");
            //this.lblTimeMin.Text = Cls.RWconfig.GetAppSettings("TargetTimeMin");
            this.lblTimeMin.Text = Cls.utils.GetSectionKeyValue(sec, "TargetTimeMin");
            //this.chbTime.Checked = (Cls.RWconfig.GetAppSettings("IsTargetTime") == "true" ? true : false);
            this.chbTime.Checked = (Cls.utils.GetSectionKeyValue(sec, "IsTargetTime") == "true" ? true : false);
            //this.lblBP.Text = Cls.RWconfig.GetAppSettings("TargetBP");
            this.lblBP.Text = Cls.utils.GetSectionKeyValue(sec, "TargetBP");
            //this.chbBP.Checked = (Cls.RWconfig.GetAppSettings("IsTargetBP") == "true" ? true : false);
            this.chbBP.Checked = (Cls.utils.GetSectionKeyValue(sec, "IsTargetBP") == "true" ? true : false);
            //this.lblDP.Text = Cls.RWconfig.GetAppSettings("TargetDP");
            this.lblDP.Text = Cls.utils.GetSectionKeyValue(sec, "TargetDP");
            //this.chbDP.Checked = (Cls.RWconfig.GetAppSettings("IsTargetDP") == "true" ? true : false);
            this.chbDP.Checked = (Cls.utils.GetSectionKeyValue(sec, "IsTargetDP") == "true" ? true : false);
            //this.lblSP.Text = Cls.RWconfig.GetAppSettings("TargetSP");
            this.lblSP.Text = Cls.utils.GetSectionKeyValue(sec, "TargetSP");
            //this.chbSP.Checked = (Cls.RWconfig.GetAppSettings("IsTargetSP") == "true" ? true : false);
            this.chbSP.Checked = (Cls.utils.GetSectionKeyValue(sec, "IsTargetSP") == "true" ? true : false);
            //this.lblFP.Text = Cls.RWconfig.GetAppSettings("TargetFP");
            this.lblFP.Text = Cls.utils.GetSectionKeyValue(sec, "TargetFP");
            //this.chbFP.Checked = (Cls.RWconfig.GetAppSettings("IsTargetFP") == "true" ? true : false);
            this.chbFP.Checked = (Cls.utils.GetSectionKeyValue(sec, "IsTargetFP") == "true" ? true : false);
            //this.lblRP.Text = Cls.RWconfig.GetAppSettings("TargetRP");
            this.lblRP.Text = Cls.utils.GetSectionKeyValue(sec, "TargetRP");
            //this.chbRP.Checked = (Cls.RWconfig.GetAppSettings("IsTargetRP") == "true" ? true : false);
            this.chbRP.Checked = (Cls.utils.GetSectionKeyValue(sec, "IsTargetRP") == "true" ? true : false);
        }

        private void lblTimeH_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad np = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == np.ShowDialog())
            {
                if (lbl.Name == "lblTimeMin")
                {
                    if (np.Value >= 59)
                        np.Value = 59;
                }
                lbl.Text = np.Value.ToString("00");
            }
        }

        private void lblBP_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            UserCtrl.numPad np = new UserCtrl.numPad(lbl.Text);
            if (DialogResult.OK == np.ShowDialog())
            {
                lbl.Text = np.Value.ToString("f1");
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
    }
}
