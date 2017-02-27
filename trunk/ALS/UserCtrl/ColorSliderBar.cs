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
    public partial class ColorSliderBar : UserControl
    {
        public ColorSliderBar()
        {
            InitializeComponent();
        }

        public int _Min
        {
            get { return colorSlider.Minimum; }
            set { colorSlider.Minimum = value; }
        }

        public int _Max
        {
            get { return colorSlider.Maximum; }
            set { colorSlider.Maximum = value; }
        }

        public int _Value1
        {
            get { return colorSlider.Value_1; }
            set { colorSlider.Value_1 = value; }
        }

        public int _Value2
        {
            get { return colorSlider.Value_2; }
            set { colorSlider.Value_2 = value; }
        }

        public int _Value
        {
            get { return colorSlider.Value; }
            set { colorSlider.Value = value; }
        }

        private void colorSlider_ValueChanged(object sender, EventArgs e)
        {          
            //lblRealValue.Text = colorSlider.Value.ToString(); 
        }
    }
}
