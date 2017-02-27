using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALS.UserCtrl
{
    public partial class uc_p : UserControl
    {

        [Description("左侧竖线")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(bool), "可见性")]
        public bool _VisibleLeft
        {
            get { return palLeft.Visible; }
            set { palLeft.Visible = value; }
        }

        [Description("标题")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(string),"标题")]
        public string _Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        [Description("标题下划线颜色")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(Color),"15,8,100")]
        public Color _LineColor
        {
            get { return line.BackColor; }
            set { line.BackColor = value; }
        }
        [Description("标题颜色")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(Color), "15,8,100")]
        public Color _TitleColor
        {
            get { return lblTitle.ForeColor; }
            set { lblTitle.ForeColor = value; }
        }

        [Description("标题字体")]
        [Category("压力控件属性")]
        public Font _TitleFont
        {
            get { return lblTitle.Font; }
            set { lblTitle.Font = value; }
        }

        [Description("值颜色")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(Color), "15,8,100")]
        public Color _ValueColor
        {
            get { return lblValue.ForeColor; }
            set { lblValue.ForeColor = value; }
        }
        [Description("值")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(string), "0.0")]
        public string _Value
        {
            get { return lblValue.Text; }
            set { lblValue.Text = value; }
        }
        [Description("压力上限")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(string), "0.0")]
        public string _Upper
        {
            get { return lblUpper.Text; }
            set { lblUpper.Text = value; }
        }
        [Description("压力下限")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(string), "0.0")]
        public string _Lower
        {
            get { return lblLower.Text; }
            set { lblLower.Text = value; }
        }

        [Description("左侧竖线可见性")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(Boolean), "true")]
        public bool _VisbleLine
        {
            get { return line.Visible; }
            set { line.Visible = value; }
        }

        public uc_p()
        {
            InitializeComponent();
        }

        private void uc_p_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(300, 68);
        }
    }
}
