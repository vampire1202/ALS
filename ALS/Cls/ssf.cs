using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace ALS.Cls
{
    public partial class ssf : Form
    {
        public delegate void _btnExit(object sender, EventArgs e);
        public event _btnExit _Exit;

        /// <summary>
        /// Base constructor
        /// </summary>
        public ssf()
        {
            InitializeComponent();
            //this.rtBox.Parent = this.pictureBox1; 
            rtBox.BackColor = Color.Azure;
            //rtBox.SelectionFont = new Font("微软雅黑", 12);
            //rtBox.SelectionColor = Color.Green;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (_Exit != null)
                _Exit(sender, e);
          
        }
    }
}