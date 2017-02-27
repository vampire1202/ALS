using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace ALS.Cls
{
    public partial class SplashDialog : Form
    {
        /// <summary>
        /// 启动日志
        /// </summary>
        private List<utils.sysStartLog> _lst_StartLog;
        public List<utils.sysStartLog> M_lst_StartLog
        {
            get { return _lst_StartLog; }
            set { _lst_StartLog = value; }
        }

        public SplashDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //保存启动日志
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "sysStartLog.txt", FileMode.Append);
            string[] s = this.rtxtInfo.Lines;
            foreach( string _s in s)
            {
                utils.AddText(fs,_s +"\r\n");
            }
            fs.Flush();
            fs.Close();
            this.Dispose();
        }

        private void SplashDialog_Load(object sender, EventArgs e)
        {
            if (_lst_StartLog !=null)
            {
                for (int i = 0; i < _lst_StartLog.Count; i++)
                {
                    this.rtxtInfo.SelectionColor = _lst_StartLog[i].InfoColor;
                    this.rtxtInfo.SelectionFont = new Font("微软雅黑", 10); ;
                    this.rtxtInfo.AppendText("[" + _lst_StartLog[i].StartTime.ToString() + "] " + _lst_StartLog[i].StartInfo);
                }
            }
            this.rtxtInfo.HideSelection = false;
            this.rtxtInfo.Focus();
        }
    }
}
