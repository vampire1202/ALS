using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    class Model_TotalFlush : Model_Total
    {
        private TimeSpan bptime;
        public TimeSpan BPTime
        {
            get { return bptime; }
            set { bptime = value;}
        }

        private TimeSpan fptime;
        public TimeSpan FPTime
        {
            get { return fptime; }
            set { fptime = value; }
        }

        private TimeSpan dptime;
        public TimeSpan DPTime
        {
            get { return dptime; }
            set { dptime = value; }
        }

        private TimeSpan rptime;
        public TimeSpan RPTime
        {
            get { return rptime; }
            set { rptime = value; }
        }

        private TimeSpan fp2time;
        public TimeSpan FP2Time
        {
            get { return fp2time; }
            set { fp2time = value; }
        }

        private TimeSpan cptime;
        public TimeSpan CPTime
        {
            get { return cptime; }
            set { cptime = value; }
        }


    }
}
