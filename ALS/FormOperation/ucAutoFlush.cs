using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ALS.FormOperation
{
    public partial class ucAutoFlush : UserControl
    {
        /// <summary>
        /// 返回重新选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ReturnSel(object sender, EventArgs e);
        public event ReturnSel btnReturnSelEvent;
        //结束预冲
        public delegate void EndFlush(object sender, EventArgs e);
        public event EndFlush btnEndFlush;
        //开始预冲
        public delegate void StartFlush(object sender, EventArgs e);
        public event StartFlush btnStartFlush;
        //追加预冲
        public delegate void StartAddFlush(object sender, EventArgs e);
        public event StartAddFlush _btnStartAddFlush;
        //暂停预冲
        public delegate void PauseFlush(object sender, EventArgs e);
        public event PauseFlush _btnPauseFlush;
        //cell click
        public delegate void dgvCellClick(object sender, DataGridViewCellEventArgs e);
        public event dgvCellClick _dgvCellClick;

        public ucAutoFlush()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 方法名称 如:PE_Flush
        /// </summary>
        private string _methodName;
        public string m_methodName
        {
            get { return _methodName; }
            set { _methodName = value; }
        }

        private void af_custom_Load(object sender, EventArgs e)
        {
           // GetCustCmd(_methodName);
            ReadFlush();
        }

        public void ReadFlush()
        {
            double dRequire = 0;
            switch (_methodName)
            {
                case "Li-ALS_Flush":
                    dRequire = Convert.ToDouble(Cls.RWconfig.GetAppSettings("lialsflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("lialsflush2"));
                    break;
                case "PE_Flush":
                    dRequire = Convert.ToDouble(Cls.RWconfig.GetAppSettings("peflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("peflush2"));
                    break;
                case "CHDF_Flush":
                    dRequire = Convert.ToDouble(Cls.RWconfig.GetAppSettings("chdfflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("chdfflush2"));
                    break;
                case "PP_Flush":
                    dRequire = Convert.ToDouble(Cls.RWconfig.GetAppSettings("ppflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("ppflush2"));
                    break;
                case "PERT_Flush":
                    dRequire = Convert.ToDouble(Cls.RWconfig.GetAppSettings("pefflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("pefflush2"));
                    break;
                case "PDF_Flush":
                    dRequire = Convert.ToDouble(Cls.RWconfig.GetAppSettings("pdfflush1")) + Convert.ToDouble(Cls.RWconfig.GetAppSettings("pdfflush2"));
                    break;
            }
            this.lblRequire.Text = dRequire.ToString("f0");
        }

        /// <summary>
        /// 获取自定义操作的步骤
        /// </summary>
        /// <param name="methodname"></param>
        /// <returns></returns>
        private DataTable dsCustomActions(string methodname)
        {
            DataTable dt = new DataTable();
            ALS.BLL.customactions bllcustom = new ALS.BLL.customactions();

            dt.Columns.Add("ID");
            dt.Columns.Add("描述");
            dt.Columns.Add("timespan");
            List<Model.customactions> lstCustomact = bllcustom.GetModelList(" methodname='" + methodname + "'");
            //先合并延迟时间为0的步骤
            for (int i = 0; i < lstCustomact.Count; i++)
            {
                if (lstCustomact[i].timeSpan.Value == 0)
                {
                    //如果未超过列表项数
                    if (i + 1 < lstCustomact.Count)
                        lstCustomact[i + 1].actionName = lstCustomact[i + 1].actionName + " 【" + lstCustomact[i].actionName + "】";
                    //如果最后一项是提示
                    if (i + 1 == lstCustomact.Count)
                    {
                        object[] val = new object[] { lstCustomact[i].ID, lstCustomact[i].actionName, lstCustomact[i].timeSpan };
                        dt.Rows.Add(val);
                    }
                }
                else
                {
                    object[] val = new object[] { lstCustomact[i].ID, lstCustomact[i].actionName, lstCustomact[i].timeSpan };
                    dt.Rows.Add(val);
                }
            }
            //DataSet ds = bllcustom.GetList(" methodname='" + methodname + "'", true);
            //dt = bllcustom.GetList(" methodname='" + methodname + "'", true).Tables[0]; 
            return dt;
        }

        public void ShowCustomActions(string method)
        {
            this.dgvStep.DataSource = dsCustomActions(method); 
            DataGridViewCheckBoxColumn dgchk = new DataGridViewCheckBoxColumn();
            dgchk.HeaderText = "追加";
            dgchk.Name = "selAdd";
            dgchk.Width = 50;
            if (!this.dgvStep.Columns.Contains("selAdd"))
                this.dgvStep.Columns.Insert(1, dgchk);

            DataGridViewTextBoxColumn dgtxt = new DataGridViewTextBoxColumn();
            dgtxt.HeaderText = "步骤";
            dgtxt.Width = 50;
            dgtxt.Name = "number";
            dgtxt.ValueType = typeof(string);

            if (!this.dgvStep.Columns.Contains("number"))
                this.dgvStep.Columns.Insert(2, dgtxt);

            for (int j = 0; j < this.dgvStep.Rows.Count; j++)
            {
                this.dgvStep.Rows[j].Cells["number"].Value = (j + 1).ToString();
                DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)this.dgvStep.Rows[j].Cells["selAdd"];
                checkBox.Value = 0;
                checkBox.Selected = false;
                dgvStep.Rows[j].Selected = false;
            }           
             
            for (int i = 0; i < this.dgvStep.Columns.Count; i++)
            {
                this.dgvStep.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dgvStep.Columns["ID"].Visible = false;
            this.dgvStep.Columns["timeSpan"].Visible = false;
            this.dgvStep.Columns["number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvStep.Columns["描述"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvStep.Refresh();
            
        }

        private void af_custom_SizeChanged(object sender, EventArgs e)
        {
            //if (sizechangedcount == 0)
            //{
            //    Rectangle rec = this.ClientRectangle;
            //    //与基准分辨率的放大系数
            //    float x = rec.Width / 898.0f;
            //    float y = rec.Height / 550.0f;
            //    Cls.utils.AutoSize(this, x, y);
            //}
            //sizechangedcount = 1;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (btnReturnSelEvent != null)
                btnReturnSelEvent(sender, e);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
                if (btnStartFlush != null)
                    btnStartFlush(sender, e);
        }

        public void btnContinue_Click(object sender, EventArgs e)
        {
            if (_btnPauseFlush != null)
                _btnPauseFlush(sender, e);          
        }

        /// <summary>
        /// 更新泵状态
        /// </summary>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (btnEndFlush != null)
                btnEndFlush(sender, e);
        }

        private void dgvStep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dgvCellClick != null)
                _dgvCellClick(sender, e);         
        }

        private void dgvStep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void btnAddFlush_Click(object sender, EventArgs e)
        {;
            if (_btnStartAddFlush != null)
                _btnStartAddFlush(sender, e);
        }
    }
}
