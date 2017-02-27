using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALS.Cls
{
    class PauseState
    {
        private string warnCode;
        private bool pause;
        private int rowNum;

        public string WarnCode
        {
            set { warnCode = value; }
            get { return warnCode; }
        }

        public bool Pause
        {
            set { pause = value; }
            get { return pause; }
        }
        public int RowNum
        {
            set { rowNum = value; }
            get { return rowNum; }
        }
    }
}
