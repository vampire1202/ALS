using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace ALS.FormSet
{
    public partial class frmSetSyringe : Form
    {
        Cls.calsyringepump calsyring = new Cls.calsyringepump();
        BLL.syringecal op_sydata = new BLL.syringecal();
        List<Model.syringecal> lstsydata = new List<Model.syringecal>();     
        public frmSetSyringe()
        {
            InitializeComponent();
        }

        private SerialPort _port_hpump;
        /// <summary>
        /// 注射器通讯串口
        /// </summary>
        public SerialPort _Port_hpump
        {
            get { return _port_hpump; }
            set { _port_hpump = value; }
        }

        private void frmSetSyringe_Load(object sender, EventArgs e)
        {         
            lstsydata = op_sydata.GetModelList("");
            int count_m = lstsydata.Count;    
            foreach(Model.syringecal m in lstsydata)
            {
                if (m.brand == "洁瑞"||m.brand==null)
                    continue;
                RadioButton rabt_brand = new RadioButton();
                rabt_brand = Cls.ControlClone.Clone(this.radioButton1);
                rabt_brand.Text = m.brand + "," + m.version + "mL";
                rabt_brand.Tag = m.ID;
                this.flowLayoutPanel1.Controls.Add(rabt_brand); 
                rabt_brand.CheckedChanged+=new EventHandler(BrandConf);
            }
            
        }
        private void BrandConf(object sender, EventArgs e)
        {
                RadioButton radiobutton = sender as RadioButton;
                if (radiobutton.Checked)
                {
                    if ((Convert.ToString(radiobutton.Tag)) != "1")
                    //选择自定义品牌
                    {
                        //读取自定义品牌信息
                        Model.syringecal brand_choose = op_sydata.GetModel(Convert.ToInt32(radiobutton.Tag));
                        Cls.utils.SendOrder(_Port_hpump, Cls.Comm_SyringePump.SetBrand_Autoset);
                        //型号1,管径23,长度45,完成距离67；
                        calsyring.Cal_SyThirty[0] = 0x04;
                        calsyring.Cal_SyThirty[1] = (byte)(Convert.ToInt32(brand_choose.calibre) >> 8 & 0xFF);
                        calsyring.Cal_SyThirty[2] = (byte)(Convert.ToInt32(brand_choose.calibre) & 0xFF);
                        calsyring.Cal_SyThirty[3] = (byte)(Convert.ToInt32(brand_choose.length*100) >> 8 & 0xFF);
                        calsyring.Cal_SyThirty[4] = (byte)(Convert.ToInt32(brand_choose.length*100) & 0xFF);
                        calsyring.Cal_SyThirty[5] = (byte)(Convert.ToInt32(brand_choose.compdis) >> 8 & 0xFF);
                        calsyring.Cal_SyThirty[6] = (byte)(Convert.ToInt32(brand_choose.compdis) & 0xFF);
                        calsyring.Sy_brand = brand_choose.brand;
                    }
                    else
                    {
                        calsyring.Sy_brand = "洁瑞";
                    }
                }
        }
        //注射器品牌确认
        private void Brand_Set(object sender, EventArgs e)
        {
            if (calsyring.Sy_brand == "洁瑞")
            {
                Cls.utils.SendOrder(_Port_hpump, Cls.Comm_SyringePump.SetBrand_jierui);
                this.Close();
            }
            else
            {
                Cls.utils.SendOrder(_Port_hpump, Cls.Comm_SyringePump.AutoCal_set(calsyring.Cal_SyThirty));
                this.Close();
            }
        }
    }
}
