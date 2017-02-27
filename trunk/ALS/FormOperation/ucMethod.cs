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
    public partial class ucMethod : UserControl
    {
        public delegate void btnOKClick(object sender, EventArgs e);
        public event btnOKClick btnOkClicked;
        //自定义操作
        private string m_methodName=string.Empty;
        private string m_methodAction = string.Empty;

        private SerialPort _port_Main;
        public SerialPort Port_Main
        {
            get { return _port_Main; }
            set { _port_Main = value; }
        }

        private SerialPort _port_Pump;
        public SerialPort Port_Pump
        {
            get { return _port_Pump; }
            set { _port_Pump = value; }
        }


        public ucMethod()
        {
            InitializeComponent();
        }

        /// <summary>
        /// --自适应分辨率 自动调节控件大小及位置--
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucfrmMethod_SizeChanged(object sender, EventArgs e)
        {
            //this.groupMethod.Left = (this.Width - this.groupMethod.Width) / 2;
            //this.groupMethod.Top = (this.Height - this.groupMethod.Height) / 2;
            //获取当前分辨率
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 898.0f;
            float y = rec.Height / 578.0f;
            Cls.utils.AutoSize(this, x, y);
        }

        private void ucfrmMethod_Load(object sender, EventArgs e)
        {

        }  

        private void btnOk_Click(object sender, EventArgs e)
        {            
            if (btnOkClicked != null)
                btnOkClicked(this.btnOk, e);           
        }

        private void btnShowPal_Click(object sender, EventArgs e)
        {
            frmSetMethod frmSm = new frmSetMethod();
            frmSm.Port_Main = _port_Main;
            frmSm.Port_Pump = _port_Pump;
            if (DialogResult.OK == frmSm.ShowDialog())
            {
                m_methodName = frmSm._Method;
                btnOk.Tag = m_methodName;
                btnOk_Click(sender, e);
            }
        }
    }
}
