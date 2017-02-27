using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace ALS.Cls
{
    public class Model_SendCMD
    {
        public static int cmdLength=0;
        private SerialPort sp = new SerialPort();
        public SerialPort SP
        {
            get { return sp; }
            set { sp = value; }
        }

        byte[] cmd= new byte[cmdLength];
        public byte[] CMD
        {
            get { return cmd; }
            set { cmd = value; }
        }

        public Model_SendCMD(SerialPort _sp, int _len,byte[] _cmd)
        {
            cmdLength = _len;
            sp = _sp;
            cmd = _cmd;
        }

        public void SendCmd()
        {
            try
            {
                if (sp.IsOpen)
                {
                    Thread.Sleep(50);
                    sp.Write(cmd, 0, cmd.Length);
                    Thread.Sleep(50);
                }
                else
                {
                    MessageBox.Show("串口不存在或未初始化!", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
    }
}
