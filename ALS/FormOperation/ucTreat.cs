using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports; 

namespace ALS.FormOperation
{
    public partial class ucTreat : UserControl
    {
        //泵秤平衡按钮事件委托
        public delegate void ChkBalance(object sender, EventArgs e);
        public event ChkBalance checkBalance; 

        //改变脱水速度委托
        public delegate void lblChangeDrySpeed(object sender, EventArgs e);
        public event lblChangeDrySpeed _lblChangeDrySpeed;

        private SerialPort _port_ppump;
        /// <summary>
        /// 蠕动泵通讯端口
        /// </summary>
        public SerialPort _Port_ppump
        {
            get { return _port_ppump; }
            set { _port_ppump = value; }
        }
        /// <summary>
        /// 压力值范围模型
        /// </summary>
        private Model.treatmentmode _modelTreat;
        public Model.treatmentmode _ModelTreat
        {
            get { return _modelTreat; }
            set { _modelTreat = value; }
        }

        public ucTreat()
        {
            InitializeComponent();
        }
        //private int sizechangedcount = 0;
        private void ucfrmTherapy_SizeChanged(object sender, EventArgs e)
        { 
            //if(sizechangedcount==0)
            //{ 
            //    Rectangle rec = this.ClientRectangle;
            //    //与基准分辨率的放大系数
            //    float x = rec.Width / 898.0f;
            //    float y = rec.Height /550.0f;
            //    Cls.utils.AutoSize(this, x, y);
            //}
            //sizechangedcount=1;
        }

        private void ucfrmTherapy_Load(object sender, EventArgs e)
        {
         
        }

        /// <summary>
        /// 读取目标值  
        /// 如果目标值有效则显示，无效则隐藏
        /// </summary>
        public void ReadSet(Model.treatmentmode ms)
        {
            //-----------------------dehydration------------------------
            if (_modelTreat.dehydrationValid)
            {
                this.lblDehydrationSpeed.Text = ms.dehydrationSpeed.ToString(); 
            }
            else
            {
                this.lblDehydrationSpeed.Text = "0.0"; 
            } 
        }

        //public void ReadTreatPic(string _mconfig)
        //{
        //    switch(_mconfig)
        //    {
        //        case "PE":
        //            this.picTreat.BackgroundImage = global::ALS.Properties.Resources.PETreat;
        //            break;
        //        case "PP":
        //            this.picTreat.BackgroundImage = global::ALS.Properties.Resources.PPTreat;
        //            break;
        //        case "CHDF":
        //            this.picTreat.BackgroundImage = global::ALS.Properties.Resources.CHDFTreat;
        //            break;
        //        case "Li-ALS":
        //            this.picTreat.BackgroundImage = global::ALS.Properties.Resources.LiALSTreat;
        //            break;
        //        case "PERT":
        //            this.picTreat.BackgroundImage = global::ALS.Properties.Resources.PERTTreat;
        //            break;
        //        case "PDF":
        //            this.picTreat.BackgroundImage = global::ALS.Properties.Resources.PDFTreat;
        //            break;
        //    }
        //}

        //定义委托
        public delegate void BtnClick(object sender, EventArgs e);
        //定义事件
        public event BtnClick ZeroTuoshui;
        private void btnZeroTime_Click(object sender, EventArgs e)
        {
            if (ZeroTuoshui != null)
                ZeroTuoshui(sender, e);
        }

        private void chkBalance_Click(object sender, EventArgs e)
        {
            if (checkBalance != null)
                checkBalance(sender, e);
        }
 
        private void chkBalance_CheckedChanged(object sender, EventArgs e)
        {

        } 

        private void lblDehydrationSpeed_Click(object sender, EventArgs e)
        {
            if (_lblChangeDrySpeed != null)
                _lblChangeDrySpeed(sender, e);
        }
    }
}
