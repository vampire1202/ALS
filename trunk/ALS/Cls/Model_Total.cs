using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    public class Model_Total
    {
        private int totalTime;
        /// <summary>
        /// 累计时间秒
        /// </summary>
        public int TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }

        private double totalBP;
        /// <summary>
        /// 累计血液流量(L)
        /// </summary>
        public double TotalBP
        {
            get { return totalBP; }
            set { totalBP = value; }
        }

        private double totalFP;
        /// <summary>
        /// 累计分离泵流量(L)
        /// </summary>
        public double TotalFP
        {
            get { return totalFP; }
            set { totalFP = value; }
        }

        private double totalDP;
        /// <summary>
        /// 累计透析液泵流量(L)
        /// </summary>
        public double TotalDP
        {
            get { return totalDP; }
            set { totalDP = value; }
        }

        private double totalRP;
        /// <summary>
        /// 累计补液泵流量(L)
        /// </summary>
        public double TotalRP
        {
            get { return totalRP; }
            set { totalRP = value; }
        }

        private double totalSP;
        /// <summary>
        /// 累计肝素泵流量(ml)
        /// </summary>
        public double TotalSP
        {
            get { return totalSP; }
            set { totalSP = value; }
        }

        private double totalDry;
        /// <summary>
        /// 累计脱水(L)
        /// </summary>
        public double TotalDry
        {
            get { return totalDry; }
            set { totalDry = value; }
        }
    }
}
