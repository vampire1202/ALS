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
    public partial class uc_PumpSpeed : UserControl
    {
        [Description("标题字体")]
        [Category("泵速控件属性")]
        public Font _FontTitle {
            get { return lblTitle.Font; }
            set { lblTitle.Font = value; }
        }

        [Description("背景色")]
        [Category("泵速控件属性")]
        public Color _BackColor
        {
            get { return this.lblTitle.RectBackColor; }
            set { this.lblTitle.TitleRectBackColor = this.lblTitle.RectBackColor = value; }
        }

        [Description("图标可见性")]
        [Category("泵速控件属性")]
        public bool _VisiblePicpump
        {
            get { return picPump.Visible; }
            set { picPump.Visible = value; }
        }
        [Description("速度字体")]
        [Category("泵速控件属性")]
        public Font _FontSpeed
        {
            get { return lblSpeed.Font; }
            set { lblSpeed.Font = value; }
        }
        [Description("底部文字可见性")]
        [Category("泵速控件属性")]
        public bool _VisibleOtherInfo
        {
            set { this.lblOtherInfo.Visible = value; }
            get { return this.lblOtherInfo.Visible; }
        }
        [Description("标题")]
        [Category("泵速控件属性")]
        public string _Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }
        }
        [Description("标题颜色")]
        [Category("泵速控件属性")]
        public Color _TitleColor
        {
            get { return this.lblTitle.ForeColor; }
            set { this.lblTitle.ForeColor = value; }
        }
        [Description("速度")]
        [Category("泵速控件属性")]
        public string _SpeedValue
        {
            get { return this.lblSpeed.Text; }
            set { this.lblSpeed.Text = value; }
        }
        [Description("速度颜色")]
        [Category("泵速控件属性")]
        public Color _SpeedColor
        {
            get { return this.lblSpeed.ForeColor; }
            set { this.lblSpeed.ForeColor = value; }
        }
        [Description("底部信息")]
        [Category("泵速控件属性")]
        public string _OtherInfo
        {
            get { return this.lblOtherInfo.Text; }
            set { this.lblOtherInfo.Text = value; }
        }
        [Description("图标")]
        [Category("泵速控件属性")]
        public Image _PicPump
        {
            get { return this.picPump.Image; }
            set { this.picPump.Image = value; }
        }
        [Description("单位")]
        [Category("泵速控件属性")]
        public string _Unit
        {
            get { return this.lblUnit.Text; }
            set { this.lblUnit.Text = value; }
        }

        public uc_PumpSpeed()
        {
            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
