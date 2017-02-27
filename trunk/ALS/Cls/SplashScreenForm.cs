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
    public partial class SplashScreenForm : Form
    {
        delegate void StringParameterDelegate(string Text);
        delegate void StringParameterWithStatusDelegate(string Text, TypeOfMessage tom);
        delegate void SplashShowCloseDelegate();
        delegate void SetTopmostDelegate(bool _tp);
        delegate void SendOrderDelegate(SerialPort _sp, byte[] _order);
        /// <summary>
        /// To ensure splash screen is closed using the API and not by keyboard or any other things
        /// </summary>
        bool CloseSplashScreenFlag = false; 

        /// <summary>
        /// Base constructor
        /// </summary>
        public SplashScreenForm()
        {
            InitializeComponent();
            //this.rtBox.Parent = this.pictureBox1; 
            rtBox.BackColor = Color.Azure;
            //rtBox.SelectionFont = new Font("微软雅黑", 12);
            rtBox.SelectionColor = Color.Black;
            progressBar1.Show();
        }

        /// <summary>
        /// Displays the splashscreen
        /// </summary>
        public void ShowSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public void CloseSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }            
            CloseSplashScreenFlag = true;            
            this.Close();
        }
 

        /// <summary>
        /// Update text in default green color of success message
        /// </summary>
        /// <param name="Text">Message</param>
        public void UdpateStatusText(string Text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateStatusText), new object[] { Text });
                return;
            } 
            // Must be on the UI thread if we've got this far
            //rtBox.ForeColor = Color.Green;
            rtBox.HideSelection = false; 
            //rtBox.SelectionFont = new Font("微软雅黑", 12);
            rtBox.SelectionColor = Color.Black;
            rtBox.AppendText(Text+"\r\n");
            rtBox.Focus();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tp"></param>
        public void SetTopmost(bool _tp)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SetTopmostDelegate(SetTopmost), new object[] { _tp });
                return;
            }
            base.TopMost = _tp;
        }

        /// <summary>
        /// Update text with message color defined as green/yellow/red/ for success/warning/failure
        /// </summary>
        /// <param name="Text">Message</param>
        /// <param name="tom">Type of Message</param>
        public void UdpateStatusTextWithStatus(string Text, TypeOfMessage tom)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterWithStatusDelegate(UdpateStatusTextWithStatus), new object[] { Text, tom });
                return;
            }  
            // Must be on the UI thread if we've got this far
            switch (tom)
            {
                case TypeOfMessage.Error:
                    //rtBox.ForeColor = Color.Red;
                    //rtBox.SelectionFont = new Font("微软雅黑", 12);
                    rtBox.SelectionColor = Color.Red;
                   
                    break;
                case TypeOfMessage.Warning:
                    //rtBox.ForeColor = Color.Yellow;
                    //rtBox.SelectionFont = new Font("微软雅黑", 12);
                    rtBox.SelectionColor = Color.Yellow;
                    break;
                case TypeOfMessage.Success:
                    //rtBox.ForeColor = Color.Green;
                    //rtBox.SelectionFont = new Font("微软雅黑", 12);
                    rtBox.SelectionColor = Color.Green;
                    break;
            }
            rtBox.HideSelection = false; 
            rtBox.AppendText(Text+"\r\n");
            rtBox.Focus();

        }

        /// <summary>
        /// Prevents the closing of form other than by calling the CloseSplashScreen function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseSplashScreenFlag == false)
                e.Cancel = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void SendOrder(SerialPort _sp, byte[] _order)
        {
            if (InvokeRequired)
            { 
                BeginInvoke(new SendOrderDelegate(SendOrder), new object[] { _sp, _order });
                return;
            }
            if (_sp.IsOpen)
            {
                Thread.Sleep(30);
                _sp.Write(_order, 0, _order.Length);
                Thread.Sleep(30);
            }
        }


    }
}
