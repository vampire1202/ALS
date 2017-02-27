using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALS.Cls
{
    class Model_Balance
    {
        /// <summary>
        /// 时间 s
        /// </summary>
        private double _t;
        public double _T
        {
            get { return _t; }
            set { _t = value; } 
        }

        /// <summary>
        /// 此阶段的实际脱水量 mL
        /// </summary>
        private double _dryTotalActually;
        public double _DryTotalActually
        {
            get { return _dryTotalActually; }
            set { _dryTotalActually = value; }
        }
        /// <summary>
        ///  此阶段理论上脱水量 mL
        /// </summary>
        private double _dryTotalTheoretic;
        public double _DryTotalTheoretic
        {
            get { return _dryTotalTheoretic; }
            set { _dryTotalTheoretic = value; }
        }

        /// <summary>
        /// 此阶段脱水速度
        /// </summary>
        private double _drySpeed;
        public double _DrySpeed
        {
            get { return _drySpeed; }
            set { _drySpeed = value; }
        }
        /// <summary>
        /// 脱水偏差值 
        /// </summary>
        private double _dryDeviation;
        public double _DryDeviation
        {
            get { return _dryDeviation; }
            set { _dryDeviation = value; }
        }
    }
}
