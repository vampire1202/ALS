using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALS.Cls
{
    class StatusProgress
    {
        public bool Success { get; set; }
        public string Tipinfo { get; set; } 
        public int Current { get; set; }
        public int Total { get; set; }
        public Cls.utils.M_SendType _sendType { get; set; }

    }
}
