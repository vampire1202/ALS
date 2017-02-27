using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALS.UserCtrl
{
    public partial class numPad : Form
    {
        //输入值
        private string strInputNumber = "";
        //是否改变值
        public bool blNumberChanged = false;
        //返回值
        private double _value = 0;
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private string strPrevious;

        public numPad()
        {
            InitializeComponent();
            txtInputNumber.Text = strInputNumber;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel; 
        }

        public numPad(string str)
        {
            InitializeComponent();
            txtInputNumber.Text = str;
            strPrevious = str;
        }

        private void btnConfirm_Click(object sender, EventArgs e)       // confirm input
        {
            if ((txtInputNumber.Text == "-") || (txtInputNumber.Text == "") || txtInputNumber.Text == ".")
            {
                blNumberChanged = false;
                MessageBox.Show("请输入数字!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);               
                return;
            }
            else if (txtInputNumber.Text == strPrevious)
            {
                blNumberChanged = true;
                _value = Math.Round(double.Parse(strPrevious), 4);
            }
            else
            {
                blNumberChanged = true;
                _value = Math.Round( double.Parse(strInputNumber),4);
            }  
        }

        private void btnSeven_Click(object sender, EventArgs e)         // input 7
        {
            strInputNumber+= "7";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnEight_Click(object sender, EventArgs e)         // input 8
        {
            strInputNumber +="8";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnNine_Click(object sender, EventArgs e)          // input 9
        {
            strInputNumber += "9";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnFour_Click(object sender, EventArgs e)          // input 4
        {
            strInputNumber += "4";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnFive_Click(object sender, EventArgs e)          // input 5
        {
            strInputNumber += "5";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnSix_Click(object sender, EventArgs e)           // input 6
        {
            strInputNumber += "6";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnOne_Click(object sender, EventArgs e)           // input 1
        {
            strInputNumber += "1";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnTwo_Click(object sender, EventArgs e)           // input 2
        {
            strInputNumber += "2";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnThree_Click(object sender, EventArgs e)     // input 3
        {
            strInputNumber += "3";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnZero_Click(object sender, EventArgs e)            // input 0
        {
            strInputNumber += "0";
            txtInputNumber.Text = strInputNumber;
        }

        private void btnDot_Click(object sender, EventArgs e)           // input dot
        {
            if (strInputNumber.IndexOf(".") == -1)
            {
                strInputNumber += ".";
                txtInputNumber.Text = strInputNumber;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)   // Delete
        {
            try
            {   
                if (strInputNumber.Length > 1)
                {
                    strInputNumber = strInputNumber.Substring(0, strInputNumber.Length - 1);
                    txtInputNumber.Text = strInputNumber;
                }
                else
                {
                    strInputNumber = "";
                    txtInputNumber.Text = "";
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString(),"警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)   // Cancel input
        {
            //blNumberChanged = true;
            //_value = Math.Round(double.Parse(strPrevious), 4);
            this.Dispose();
        }

        private void btnNegPos_Click(object sender, EventArgs e)  // input "minus"
        {
            if (txtInputNumber.Text == "")
            {
                txtInputNumber.Text = "-";
                strInputNumber = "-";
            }
            else
            {
                strInputNumber = txtInputNumber.Text;
                if (strInputNumber[0] == '-')
                {
                    strInputNumber = strInputNumber.Substring(1, strInputNumber.Length - 1);
                }
                else
                {
                    if (strInputNumber == "0")
                    {
                        strInputNumber = "-";
                    }
                    else
                    {
                        strInputNumber = "-" + strInputNumber;
                    }
                }

                txtInputNumber.Text = strInputNumber;
            }   
        }

        private void NumericPadForm_Load(object sender, EventArgs e)
        {

        }

        private void numPad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (blNumberChanged)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }
}
