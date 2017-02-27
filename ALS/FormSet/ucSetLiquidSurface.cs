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
        private Model.treatmentmode _treatMode;
        public Model.treatmentmode _TreatMode
        {
            get { return _treatMode; }
            set { _treatMode = value; }
        }

        private SerialPort _port_main;
        public SerialPort _Port_main
        {
            get { return _port_main; }
            set { _port_main = value; }
        }

        public delegate void CheckClick(object sender, EventArgs e);
        public event CheckClick chkClicked;

        public ucSetLiquidSurface()
        {
            InitializeComponent();
        }

        public void ucSetLiquidSurface_Load(object sender, EventArgs e)
        {
            //ShowWarnValue();
        }
        //private int sizechangedcount = 0;
        private void ucSetLiquidSurface_SizeChanged(object sender, EventArgs e)
        { 
            //if(sizechangedcount ==0 )
            //{
            //    Rectangle rec = this.ClientRectangle;
            //    //与基准分辨率的放大系数
            //    float x = rec.Width / 898.0f;
            //    float y = rec.Height / 550.0f;
            //    Cls.utils.AutoSize(this, x, y); 
            //}
            //sizechangedcount=1;
        } 
       

        private void chkUpC1_Click(object sender, EventArgs e)
        {
            if (chkClicked != null)
                chkClicked(sender, e);
        }
    }
}
