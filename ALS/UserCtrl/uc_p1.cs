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
    public partial class uc_p1 : UserControl
    {

        [Description("左侧竖线")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(bool), "可见性")]
        public bool _LeftVisible
        {
            get { return palLeft.Visible; }
            set { palLeft.Visible = value; }
        }

        [Description("左侧竖线背景色")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(bool), "背景色")]
        public Color _LeftBgColor
        {
            get { return palLeft.BackColor; }
            set { palLeft.BackColor = value; }
        }


        [Description("标题")]
        [Category("压力控件属性")]
        [DefaultValue(typeof(string),"标题")]
        public string _Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
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
    
        public uc_p1()
        {
            InitializeComponent();
        }

        private void uc_p1_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(300, 60);
        }
    }
}
