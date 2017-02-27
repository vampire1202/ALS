using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;
using ALS.DataGridViewExs.CommonEx;

/*
 * @Author: 江心逐浪 [Jonson]
 * 
 * @E-Mail: jiangshan_111@126.com   
 * 
 * @Content:
 *      此类主要是在DataGridView的Button列中扩展出一个更便于控制的Button列;
 *       1> 主要是绘制大小固定的按钮，并且添加一些按钮的事件等;
 *       2> 按钮可以支持根据内容来筛选显示,增加转换器;
 *       3> 按钮的点击事件可以直接抛出。
 */
namespace ALS.DataGridViewExs.ColumnEx
{
    #region  扩展列
    /// <summary>
    /// 扩展列
    /// </summary>
    public class DataGridViewButtonColumnEx : DataGridViewColumn
    {
        static Size DefaultButtonSize = new Size(60, 40);

        //private Size m_ButtonSize = DefaultButtonSize;
        private Size m_ButtonSize=DefaultButtonSize;
        [Category("Jonson Design"), Browsable(true), Localizable(true), Description("按钮大小模板。")]
        public Size ButtonSize
        {
            get { return m_ButtonSize; }
            set { m_ButtonSize = value; }
        }

        private Color m_ButtonBgColor = Color.AliceBlue;
        [Category("Jonson Design"), Browsable(true), Localizable(true), Description("按钮背景颜色。")]
        public Color ButtonBgColor
        {
            get { return m_ButtonBgColor; }
            set { m_ButtonBgColor = value; }
        }

        private String m_ButtonText = @"操作"; //String.Empty;
        [Category("Jonson Design"), Browsable(true), Localizable(true), Description("按钮默认文本")]
        public String ButtonText
        {
            get { return m_ButtonText; }
            set { m_ButtonText = value; }
        }

        public override object Clone()
        {
            DataGridViewButtonColumnEx column = (DataGridViewButtonColumnEx)base.Clone();
            column.ButtonText = m_ButtonText;
            column.ButtonSize = m_ButtonSize;
            column.ButtonBgColor = m_ButtonBgColor;
            return column;
        }

        public DataGridViewButtonColumnEx()
            : base()
        {
            this.CellTemplate = new DataGridViewButtonCellEx();
        }
    }
    #endregion


    /// <summary>
    /// 扩展单元格
    /// </summary>
    
}
