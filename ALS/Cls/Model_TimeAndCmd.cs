using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    class Model_TimeAndCmd
    {
        private string _tipInfo;
        public string _TipInfo
        {
            get { return _tipInfo; }
            set { _tipInfo = value; }
        }

        private int _tsCount;
        public int _TsCount
        {
            get { return _tsCount; }
            set { _tsCount = value; }
        } 

        private Model_SendCMD _msCmd;
        public Model_SendCMD _MsCmd
        {
            get { return _msCmd; }
            set { _msCmd = value; }
        }
    }
}
