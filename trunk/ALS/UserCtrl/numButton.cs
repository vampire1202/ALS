using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ALS.UserCtrl
{
    public delegate void ItemEvent(string TextValue);
    public partial class numButton : UserControl
    {

        public event ItemEvent ItemEventHandle;
        public numButton()
        {
            InitializeComponent();
        }
        private string _Text="";
        private void F_Click(object sender, EventArgs e)
        {

        }
        private void GetTextValue()
        {
            if (ItemEventHandle != null)
            {
                ItemEventHandle(_Text);
            }       
        }
       
       
        private void J_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            _Text = bt.Text;
            GetTextValue();
        }

     
    }
}