using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ALS.Cls
{
    class Model_ShowWarn
    {
        public Model.warncode mwarncode;   
        private SerialPort port_ppump;
        private SerialPort port_main;
        private SerialPort port_hpump;
        public List<Cls.Model_SendCMD> lstSendcmds = new List<Model_SendCMD>();

        public Model_ShowWarn(Model.warncode _wcode,SerialPort _portmain,SerialPort _porthpump,SerialPort _portppump)
        {
            mwarncode = _wcode;
            port_main = _portmain;
            port_ppump = _portppump;
            port_hpump = _porthpump;
            lstSendcmds = GetlstSendCmds(mwarncode);
        }

        public List<Cls.Model_SendCMD> GetlstSendCmds(Model.warncode _mwcode)
        {
            BLL.warncmds bwcmd = new BLL.warncmds();
            int ID = (int)_mwcode.ID; 
            List<Model.warncmds> mlstWarnActions = bwcmd.GetModelList(" warnCodeID='" + ID + "'");
            List<Cls.Model_SendCMD> lstWarnActions = new List<Cls.Model_SendCMD>();
            if (mlstWarnActions.Count > 0)
            {               
                foreach (var v in mlstWarnActions)
                {
                    byte[] buff = v.cmd;
                    int cmdLen = (int)v.cmdLength;
                    byte[] cmdArry = new byte[cmdLen];
                    Array.Copy(buff, cmdArry, cmdLen);
                    SerialPort sp = new SerialPort();
                    switch (v.portName.ToLower())
                    {
                        case "com1":
                            sp = port_main;
                            break;
                        case "com2":
                            sp = port_hpump;
                            break;
                        case "com3":
                            sp = port_ppump;
                            break;
                    }
                    Cls.Model_SendCMD item = new Cls.Model_SendCMD(sp, cmdLen, cmdArry);
                    lstWarnActions.Add(item);
                }                
            }
            return lstWarnActions;
        }
 
    }
}
