using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace ALS.FormSet
{
    public partial class ucSetLiquidSurface : UserControl
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

        private SerialPort _port_main;
        public SerialPort _Port_main
        {
            get { return _port_main; }
            set { _port_main = value; }
        }

        private string _section;
        public string _Section
        {
            get { return _section; }
            set { _section = value; }
        }

        public delegate void CheckChanged(object sender, EventArgs e);
        public event CheckChanged chkChanged;


        /// <summary>
        /// 压力值范围显示
        /// </summary>
        //bool size=false;
        //public void ShowWarnValue()
        //{
        //    this.agauge_Pacc.RangesStartValue = new float[] { -500, _modelwarn.LowerPacc, _modelwarn.UpperPacc, 0, 0 };
        //    this.agauge_Pacc.RangesEndValue = new float[] { _modelwarn.LowerPacc, _modelwarn.UpperPacc, 500, 0, 0 };
        //    this.agauge_Part.RangesStartValue = new float[] { -500, _modelwarn.LowerPart, _modelwarn.UpperPart, 0, 0 };
        //    this.agauge_Part.RangesEndValue = new float[] { _modelwarn.LowerPart, _modelwarn.UpperPart, 500, 0, 0 };
        //    this.agauge_Pven.RangesStartValue = new float[] { -500, _modelwarn.LowerPven, _modelwarn.UpperPven, 0, 0 };
        //    this.agauge_Pven.RangesEndValue = new float[] { _modelwarn.LowerPven, _modelwarn.UpperPven, 500, 0, 0 };
        //    this.agauge_P1st.RangesStartValue = new float[] { -500, _modelwarn.LowerP1st, _modelwarn.UpperP1st, 0, 0 };
        //    this.agauge_P1st.RangesEndValue = new float[] { _modelwarn.LowerP1st, _modelwarn.UpperP1st, 500, 0, 0 };
        //    this.agauge_P2nd.RangesStartValue = new float[] { -500, _modelwarn.LowerP2nd, _modelwarn.UpperP2nd, 0, 0 };
        //    this.agauge_P2nd.RangesEndValue = new float[] { _modelwarn.LowerP2nd, _modelwarn.UpperP2nd, 500, 0, 0 };
        //    this.agauge_TMP.RangesStartValue = new float[] { -500, _modelwarn.LowerTmp, _modelwarn.UpperTmp, 0, 0 };
        //    this.agauge_TMP.RangesEndValue = new float[] { _modelwarn.LowerTmp, _modelwarn.UpperTmp, 500, 0, 0 };
        //    size = !size;
        //    Rectangle rec = this.ClientRectangle;
        //    float x = rec.Width / 893.0f;
        //    float y = rec.Height / 462.0f;
        //    if (size)
        //    {
        //        agauge_TMP.Size = agauge_P2nd.Size = agauge_P1st.Size = agauge_Pven.Size = agauge_Part.Size = this.agauge_Pacc.Size = new System.Drawing.Size((int)(141 * x + 1), (int)(100 * y));
        //    }
        //    else
        //    {
        //        agauge_TMP.Size = agauge_P2nd.Size = agauge_P1st.Size = agauge_Pven.Size = agauge_Part.Size = this.agauge_Pacc.Size = new System.Drawing.Size((int)(141 * x), (int)(100 * y));
        //    }
        //}

        public ucSetLiquidSurface()
        {
            InitializeComponent();
        }

        public void ucSetLiquidSurface_Load(object sender, EventArgs e)
        {
            //ShowWarnValue();
        }

        private void ucSetLiquidSurface_SizeChanged(object sender, EventArgs e)
        {
            //this.groupSet.Left = (this.Width - this.groupSet.Width) / 2;
            //this.groupSet.Top = (this.Height - this.groupSet.Height) / 2;
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 898.0f;
            float y = rec.Height / 578.0f;
            Cls.utils.AutoSize(this, x, y);
        } 

        //气泵1-1 放气
        private void chkC1Down_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChanged != null)
                chkChanged(sender, e);
        }
       
       
        //private void chkC1Up_MouseDown(object sender, MouseEventArgs e)
        //{
        //    chkC1Up.Checked = true;

        //}

        //private void chkC1Up_MouseUp(object sender, MouseEventArgs e)
        //{
        //    chkC1Up.Checked = false;
        //} 
    }
}
