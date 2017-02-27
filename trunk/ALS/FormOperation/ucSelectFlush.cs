using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALS.FormOperation
{
    public partial class ucSelectFlush : UserControl
    {
        public ucSelectFlush()
        {
            InitializeComponent();
        }
        public delegate void btnSelAutoFlush(object sender, EventArgs e);
        public event btnSelAutoFlush _btnSelAutoFlush;
        public delegate void btnSelManualFlush(object sender, EventArgs e);
        public event btnSelManualFlush _btnSelManualFlush;
        private void ucSelectFlush_SizeChanged(object sender, EventArgs e)
        {
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 898.0f;
            float y = rec.Height / 578.0f;
            Cls.utils.AutoSize(this, x, y);
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (_btnSelAutoFlush != null)
                _btnSelAutoFlush(sender, e);

        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (_btnSelManualFlush != null)
                _btnSelManualFlush(sender, e);
        }
    }
}
