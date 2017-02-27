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
    public partial class uc_ShowTreatP : UserControl
    {
        public uc_ShowTreatP()
        {
            InitializeComponent();
        }

        public string _Value
        {
            get { return lblValue.Text; }
            set { lblValue.Text = value; }
        }

        public string _Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public Size _ValueSize
        {
            get { return lblValue.Size; }
            set { lblValue.Size = value; }
        }

        public string _TitleEn
        {
            get { return lblTitleEn.Text; }
            set { lblTitleEn.Text = value; }
        }

        public Color _ColorLine
        {
            get { return line.LineColor; }
            set { lblTitleEn.ForeColor = line.LineColor = value; }
        }

        public Color _ColorTitle
        {
            get { return lblTitle.ForeColor; }
            set { lblTitle.ForeColor = value; }
        }

        public Color _ColorValue
        {
            get { return lblValue.ForeColor; }
            set { lblValue.ForeColor = value; }
        }

        public Font _FontTitle
        {
            get { return lblTitle.Font; }
            set { lblTitle.Font = value; }
        }

        public Font _FontValue
        {
            get { return lblValue.Font; }
            set { lblValue.Font = value; }
        }
    }
}
