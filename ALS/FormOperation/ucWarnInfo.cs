using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ALS.DataGridViewExs.ColumnEx;

namespace ALS.FormOperation
{
    public partial class ucWarnInfo : UserControl
    {
        public ucWarnInfo()
        {
            InitializeComponent();
        }

        public delegate void btn_Mute(object sender, EventArgs e);
        public event btn_Mute _btnMute;

        public delegate void btn_Release(object sender, EventArgs e);
        public event btn_Release _btnRelease;

        public delegate void btn_dealwarn(object sender, DataGridViewExs.EventArgsEx.DataGridViewButtonClickEventArgs e);
        public event btn_dealwarn _btnDealwarn;

        public delegate void btn_deleteLowW(object sender, DataGridViewExs.EventArgsEx.DataGridViewButtonClickEventArgs e);
        public event btn_deleteLowW _btn_deleteLowW;
        

        public void ucWarnInfo_Load(object sender, EventArgs e)
        {

        }
 
        public void AddWarnInfo(Model.warncode wc)
        { 
            //获取报警框已有行数；
            int count_row=this.dgvView.RowCount;
            switch (wc.grade)
            {
                case 1:
                    object[] values = new object[] {wc.grade,"高",wc.code, wc.content, wc.reason, wc.deal };
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(this.dgvView);
                    dgvr.SetValues(values);
                    dgvr.DefaultCellStyle.BackColor = Color.FromArgb(230, 0, 0);
                    dgvr.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 0, 0);
                    //dgvr.Cells[0].Style.BackColor = Color.White;
                    //dgvr.Cells[0].Style.SelectionBackColor = Color.White;
                    this.dgvView.Rows.Add(dgvr);
                    break;
                case 2:
                case 3:
                    object[] values1 = new object[] { wc.grade, "中", wc.code, wc.content, wc.reason, wc.deal };
                    DataGridViewRow dgvr1 = new DataGridViewRow();
                    dgvr1.CreateCells(this.dgvView);
                    dgvr1.SetValues(values1);
                    dgvr1.DefaultCellStyle.BackColor = Color.DarkOrange;
                    dgvr1.DefaultCellStyle.SelectionBackColor = Color.DarkOrange;
                    //dgvr1.Cells[0].Style.BackColor = Color.White;
                    //dgvr1.Cells[0].Style.SelectionBackColor = Color.White;
                    this.dgvView.Rows.Add(dgvr1);
                    break;
                case 4:
                    object[] values2 = new object[] { wc.grade, "中", wc.code, wc.content, wc.reason, wc.deal };
                    DataGridViewRow dgvr2 = new DataGridViewRow();
                    dgvr2.CreateCells(this.dgvView);
                    dgvr2.SetValues(values2);
                    dgvr2.DefaultCellStyle.BackColor = Color.DarkOrange;
                    dgvr2.DefaultCellStyle.SelectionBackColor = Color.DarkOrange;
                    //dgvr2.Cells[0].Style.BackColor = Color.White;
                    //dgvr2.Cells[0].Style.SelectionBackColor = Color.White;
                    this.dgvView.Rows.Add(dgvr2);
                    break;
            }
            //等级小于等于3的报警不显示处理方法显示框
            //if (wc.grade >= 3)
            //{
            //    DataGridViewButtonCellEx dgvbcx = (DataGridViewButtonCellEx)this.dgvView.Rows[count_row].Cells[4];
            //    dgvbcx.Visible = false;
            //}
        } 

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (_btnMute != null)
                _btnMute(sender, e);
        }

        public void btnRelease_Click(object sender, EventArgs e)
        {
            if (_btnRelease != null)
                _btnRelease(sender, e);
        }

        private void dgvView_CellButtonClicked(object sender, DataGridViewExs.EventArgsEx.DataGridViewButtonClickEventArgs e)
        {            
            string warncode = dgvView["code", e.RowIndex].Value.ToString();
            int grade = int.Parse( dgvView[0, e.RowIndex].Value.ToString());
            //MessageBox.Show("等级:"+grade+ "代码:"+warncode);
            //如果警报等级小于3，按解除时出现处理警报的界面
            //警报等级1  血泵必停
            //警报等级2  血泵不停，其他泵都停
            //警报等级3  
            if (grade < 3)
            {
                if (_btnDealwarn != null)
                    _btnDealwarn(sender, e);
            }
            else
            {
                //在报警列表中删除该报警
                if (_btn_deleteLowW != null)
                    _btn_deleteLowW(sender, e);
                //移除当前行的警报
                dgvView.Rows.RemoveAt(e.RowIndex);
                
                //如果警报列表为空,调用复位事件
                if (dgvView.RowCount == 0)
                {
                    if (_btnRelease != null)
                        _btnRelease(sender, e);
                }
            }
        }
    }
}
