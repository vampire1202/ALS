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

        double _speedml;
        public double _Speedml
        {
            get { return _speedml; }
            set { _speedml = value; }
        }

        public Model_SendCMD(SerialPort _sp, int _len,byte[] _cmd,double speedml)
        {
            cmdLength = _len;
            sp = _sp;
            cmd = _cmd;
            _speedml = speedml;
        }
    }
}
