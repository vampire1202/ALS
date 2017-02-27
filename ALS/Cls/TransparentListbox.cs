using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
namespace ALS.Cls
{
    class TransparentListbox : ListBox
    {
        public TransparentListbox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
        }
    }
}
