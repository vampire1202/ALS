using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ALS
{
    public partial class frmSetMethod : Form
    {
        private string _method;
        public string _Method
        {
            get { return _method; }
            set { _method = value; }
        }

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
         
        private string m_methodAction = string.Empty;

        public frmSetMethod()
        {
            InitializeComponent();
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmSetMethod_Load(object sender, EventArgs e)
        {
            ReadMethodSet();
        }

        private void ReadMethodSet()
        {
             _method= Cls.RWconfig.GetAppSettings("CurrentMethod"); 
            switch (_method)
            {
                case "PEConfig":
                    this.rbtnPE.Checked = true;  
                    break;
                case "PPConfig": 
                    this.rbtnPP.Checked = true;
                    break;
                case "PERTConfig":
                    this.rbtnHP.Checked = true; 
                    break;
                case "CHDFConfig": 
                    this.rbtnHDF.Checked = true; 
                    break;
                case "PDFConfig":
                    this.rbtnPDF.Checked = true; 
                    break; 
                case "Li-ALSConfig": 
                    this.rbtnLi.Checked = true; 
                    break;
            }

        } 


        private void rbtnLi_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cb = sender as RadioButton;                
            if (cb.Checked)
            {
                _method = cb.Tag.ToString();                    
                cb.BackColor = Color.FromArgb(31, 163, 215);
                cb.ForeColor = Color.White;
                Cls.RWconfig.SetAppSettings("CurrentMethod", _method);
                //ShowMethodName(M_str_CurrentConfig);
            }
            else
            {
                cb.BackColor = Color.Transparent;
                cb.ForeColor = Color.FromArgb(15, 8, 100);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnTreat_Click(object sender, EventArgs e)
        {
            switch (_method)
            {
                case "PEConfig":
                    m_methodAction = "PE_Treat";
                    break;
                case "PPConfig":
                    m_methodAction = "PP_Treat";
                    break;
                case "HPConfig":
                    m_methodAction = "HP_Treat";
                    break;
                case "CHDFConfig":
                    m_methodAction = "CHDF_Treat";
                    break;
                case "PDFConfig":
                    m_methodAction = "PDF_Treat";
                    break;
                //case "Manual":
                //    m_methodAction = "Manual_Recycle";
                //break;
                case "Li-ALSConfig":
                    m_methodAction = "Li-ALS_Treat";
                    break;
            }
            //显示自动化操作界面
            frmCustomAction fca = new frmCustomAction(m_methodAction);
            fca.Port_Main = _port_Main;
            fca.Port_Pump = _port_Pump;
            fca.ShowDialog();
        }

        private void btnFlush_Click(object sender, EventArgs e)
        {
            switch (_method)
            {
                case "PEConfig":
                    m_methodAction = "PE_Flush";
                    break;
                case "PPConfig":
                    m_methodAction = "PP_Flush";
                    break;
                case "HPConfig":
                    m_methodAction = "HP_Flush";
                    break;
                case "CHDFConfig":
                    m_methodAction = "CHDF_Flush";
                    break;
                case "PDFConfig":
                    m_methodAction = "PDF_Flush";
                    break; 
                case "Li-ALSConfig":
                    m_methodAction = "Li-ALS_Flush";
                    break;
            }
            //显示自动化操作界面
            frmCustomAction fca = new frmCustomAction(m_methodAction);
            fca.Port_Main = _port_Main;
            fca.Port_Pump = _port_Pump;
            fca.ShowDialog();
        }

        private void btnRecycle_Click(object sender, EventArgs e)
        {
            switch (_method)
            {
                case "PEConfig":
                    m_methodAction = "PE_Recycle";
                    break;
                case "PPConfig":
                    m_methodAction = "PP_Recycle";
                    break;
                case "HPConfig":
                    m_methodAction = "HP_Recycle";
                    break;
                case "CHDFConfig":
                    m_methodAction = "CHDF_Recycle";
                    break;
                case "PDFConfig":
                    m_methodAction = "PDF_Recycle";
                    break;
                //case "Manual":
                //    m_methodAction = "Manual_Recycle";
                //break;
                case "Li-ALSConfig":
                    m_methodAction = "Li-ALS_Recycle";
                    break;
            }
            //显示自动化操作界面
            frmCustomAction fca = new frmCustomAction(m_methodAction);
            fca.Port_Main = _port_Main;
            fca.Port_Pump = _port_Pump;
            fca.ShowDialog();
        }
    }
}
