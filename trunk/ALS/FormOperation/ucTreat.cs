using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALS.FormOperation
{
    public partial class ucTreat : UserControl
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

        /// <summary>
        /// 压力值范围模型
        /// </summary>
        private string _methodConfig;
        public string _MethodConfig
        {
            get { return _methodConfig; }
            set { _methodConfig = value; }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        private Cls.Model_Set _modelset;
        public Cls.Model_Set _ModelSet
        {
            get { return _modelset; }
            set { _modelset = value; }
        }

        /// <summary>
        /// 压力值范围显示
        /// </summary> 
        public void ShowWarnValue()
        {
            this.uc_pacc._Value1 = (int)_modelwarn.LowerPacc;
            this.uc_pacc._Min = (int)_modelwarn.LowerPacc - 100;
            this.uc_pacc.lblMin.Text = this.uc_pacc._Min.ToString();
            this.uc_pacc._Value2 = (int)_modelwarn.UpperPacc;
            this.uc_pacc._Max = (int)_modelwarn.UpperPacc+100;
            this.uc_pacc.lblMax.Text = this.uc_pacc._Max.ToString();

            this.uc_part._Min = (int)_modelwarn.LowerPart-100;
            this.uc_part.lblMin.Text = this.uc_part._Min.ToString();
            this.uc_part._Max = (int)_modelwarn.UpperPart+100;
            this.uc_part.lblMax.Text = this.uc_part._Max.ToString();
            this.uc_part._Value1 = (int)_modelwarn.LowerPart;
            this.uc_part._Value2 = (int)_modelwarn.UpperPart;

            this.uc_tmp._Min = (int)_modelwarn.LowerTmp-100;
            this.uc_tmp.lblMin.Text = this.uc_tmp._Min.ToString();
            this.uc_tmp._Max = (int)_modelwarn.UpperTmp+100;
            this.uc_tmp.lblMax.Text = this.uc_tmp._Max.ToString();
            this.uc_tmp._Value1 = (int)_modelwarn.LowerTmp;
            this.uc_tmp._Value2 = (int)_modelwarn.UpperTmp;

            this.uc_pven._Min = (int)_modelwarn.LowerPven-100;
            this.uc_pven.lblMin.Text = this.uc_pven._Min.ToString();
            this.uc_pven._Max = (int)_modelwarn.UpperPven+100;
            this.uc_pven.lblMax.Text = this.uc_pven._Max.ToString();
            this.uc_pven._Value1 = (int)_modelwarn.LowerPven;
            this.uc_pven._Value2 = (int)_modelwarn.UpperPven;

            this.uc_p1st._Min = (int)_modelwarn.LowerP1st - 100;
            this.uc_p1st.lblMin.Text = this.uc_p1st._Min.ToString();
            this.uc_p1st._Max = (int)_modelwarn.UpperP1st + 100;
            this.uc_p1st.lblMax.Text = this.uc_p1st._Max.ToString();
            this.uc_p1st._Value1 = (int)_modelwarn.LowerP1st;
            this.uc_p1st._Value2 = (int)_modelwarn.UpperP1st;

            this.uc_p2nd._Min = (int)_modelwarn.LowerP2nd - 100;
            this.uc_p2nd.lblMin.Text = this.uc_p2nd._Min.ToString();
            this.uc_p2nd._Max = (int)_modelwarn.UpperP2nd + 100;
            this.uc_p2nd.lblMax.Text = this.uc_p2nd._Max.ToString();
            this.uc_p2nd._Value1 = (int)_modelwarn.LowerP2nd;
            this.uc_p2nd._Value2 = (int)_modelwarn.UpperP2nd;
        }

        public ucTreat()
        {
            InitializeComponent();
        }

        private void ucfrmTherapy_SizeChanged(object sender, EventArgs e)
        { 
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 898.0f;
            float y = rec.Height /578.0f;
            Cls.utils.AutoSize(this, x, y);
        }

        private void ucfrmTherapy_Load(object sender, EventArgs e)
        {
            //读取压力值范围显示在数码表中
            //ShowWarnValue(); 
            //读取目标设置值
            //ReadSet(_modelset);
        }

        /// <summary>
        /// 读取目标值  
        /// 如果目标值有效则显示，无效则隐藏
        /// </summary>
        public void ReadSet(Cls.Model_Set ms)
        {
            this.uc_SpeedSP._SpeedValue = ms.SpeedSP.ToString();
            //-----------------------FP------------------------
            if (_modelset.FPValid)
            {
                this.uc_SpeedFP._SpeedValue = ms.SpeedFP.ToString("f1");
                this.lblTargetFP.Text = ms.TargetFP.ToString();  
                this.uc_SpeedFP._VisiblePicpump = true;
                this.lblTargetFP.Enabled = true;
                this.lblTotalFP.Enabled = true;
                if (_modelset.FPDirection)
                    this.uc_SpeedFP._PicPump = global::ALS.Properties.Resources.fp_s;
                else
                    this.uc_SpeedFP._PicPump = global::ALS.Properties.Resources.fp_n;
            }
            else
            {
                this.uc_SpeedFP._SpeedValue = "0";
                this.uc_SpeedFP._VisiblePicpump = false;
                this.uc_SpeedFP.Enabled = false;
                this.lblTargetFP.Enabled = false;
                this.lblTotalFP.Enabled = false;
            }
            //-----------------------DP------------------------
            if (_modelset.DPValid)
            {
                this.uc_SpeedDP._SpeedValue = ms.SpeedDP.ToString("f1");
                this.lblTargetDP.Text = ms.TargetDP.ToString();
                this.uc_SpeedDP._VisiblePicpump = true;
                this.lblTargetDP.Enabled = true;
                this.lblTotalDP.Enabled = true;
                if (_modelset.DPDirection)
                    this.uc_SpeedDP._PicPump = global::ALS.Properties.Resources.dp_s;
                else
                    this.uc_SpeedDP._PicPump = global::ALS.Properties.Resources.dp_n;
            }
            else
            {
                this.uc_SpeedDP._SpeedValue = "0";
                this.uc_SpeedDP._VisiblePicpump = false;
                this.uc_SpeedDP.Enabled = false;
                this.lblTargetDP.Enabled = false;
                this.lblTotalDP.Enabled = false;
            }

            //-----------------------RP------------------------
            if (_modelset.RPValid)
            {
                this.uc_SpeedRP._SpeedValue = ms.SpeedRP.ToString("f1");
                this.lblTargetRP.Text = ms.TargetRP.ToString("f1");
                this.uc_SpeedRP._VisiblePicpump = true;
                this.lblTargetRP.Enabled = true;
                this.lblTotalRP.Enabled = true;
                if (_modelset.RPDirection)
                    this.uc_SpeedRP._PicPump = global::ALS.Properties.Resources.rp_s;
                else
                    this.uc_SpeedRP._PicPump = global::ALS.Properties.Resources.rp_n;
            }
            else
            {
                this.uc_SpeedRP._SpeedValue = "0";
                this.uc_SpeedRP._VisiblePicpump = false;
                this.uc_SpeedRP.Enabled = false;
                this.lblTargetRP.Enabled = false;
                this.lblTotalRP.Enabled = false;
            }
            //-----------------------FP2------------------------
            if (_modelset.FP2Valid)
            {
                this.uc_SpeedFP2._SpeedValue = ms.SpeedFP2.ToString("f1"); 
                this.uc_SpeedFP2._VisiblePicpump = true;
                if (_modelset.FP2Direction)
                    this.uc_SpeedFP2._PicPump = global::ALS.Properties.Resources.fp2_s;
                else
                    this.uc_SpeedFP2._PicPump = global::ALS.Properties.Resources.fp2_n;
            }
            else
            {
                this.uc_SpeedFP2._SpeedValue = "0";
                this.uc_SpeedFP2._VisiblePicpump = false;
                this.uc_SpeedFP2.Enabled = false;
            }
            //-----------------------CP------------------------
            if (_modelset.CPValid)
            {
                this.uc_SpeedCP._SpeedValue = ms.SpeedCP.ToString("f1"); 
                this.uc_SpeedCP._VisiblePicpump = true;
                if (_modelset.CPDirection)
                    this.uc_SpeedCP._PicPump = global::ALS.Properties.Resources.cp_s;
                else
                    this.uc_SpeedCP._PicPump = global::ALS.Properties.Resources.cp_n;
            }
            else
            {
                this.uc_SpeedCP._SpeedValue = "0";
                this.uc_SpeedCP._VisiblePicpump = false;
                this.uc_SpeedCP.Enabled = false;
            }

            //-----------------------dehydration------------------------
            if (_modelset.DehydrationValid)
            {
                this.paldehydration.Enabled = true;
                this.lblDehydrationSpeed.Text = ms.DehydrationSpeed.ToString(); 
            }
            else
            {
                this.paldehydration.Enabled = false;
                this.lblDehydrationSpeed.Text = "0.0"; 
            }

            //this.lblHT.Text = ms.TargetTemperature.ToString();
            TimeSpan ts = new TimeSpan(0, 0, ms.TargetTime);
            this.lblTargetTime.Text = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            this.lblTargetBP.Text = ms.TargetBP.ToString();
            this.lblTargetSP.Text = ms.TargetSP.ToString();  
        }

        public void ReadTreatPic(string _mconfig)
        {
            switch(_mconfig)
            {
                case "PEConfig":
                    this.picTreat.Image = global::ALS.Properties.Resources.PETreat;
                    break;
                case "PPConfig":
                    this.picTreat.Image = global::ALS.Properties.Resources.PPTreat;
                    break;
                case "CHDFConfig":
                    this.picTreat.Image = global::ALS.Properties.Resources.CHDFTreat;
                    break;
            }
        }

        private void btnZeroTime_Click(object sender, EventArgs e)
        {

        }

        private void btnZerodry_Click(object sender, EventArgs e)
        {

        }
    }
}
