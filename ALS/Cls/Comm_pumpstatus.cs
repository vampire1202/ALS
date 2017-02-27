using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALS.Cls
{
    class Comm_pumpstatus
    {
        public static byte[] cmdHearBeat = new byte[] { 0xFE, 0xB3, 0x01, 0x11, 0x5D, 0xED };
    }
}
