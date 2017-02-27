using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    public class Model_State
    {
        private Cls.Model_PumpState bpState = new Model_PumpState();
        
        /// <summary>
        /// 血泵当前转速和方向
        /// </summary>
        public Cls.Model_PumpState BPState
        {
            get { return bpState; }
            set { bpState = value; }
        }


        private Cls.Model_PumpState fpState = new Model_PumpState();
        /// <summary>
        /// 泵当前转速和方向
        /// </summary>
        public Cls.Model_PumpState FPState
        {
            get { return fpState; }
            set { fpState = value; }
        }

        private Cls.Model_PumpState dpState = new Model_PumpState();
        /// <summary>
        /// 泵当前转速和方向
        /// </summary>
        public Cls.Model_PumpState DPState
        {
            get { return dpState; }
            set { dpState = value; }
        }

        private Cls.Model_PumpState rpState = new Model_PumpState();
        /// <summary>
        /// 当前转速和方向
        /// </summary>
        public Cls.Model_PumpState RPState
        {
            get { return rpState; }
            set { rpState = value; }
        }

        private Cls.Model_PumpState fp2State = new Model_PumpState();
        /// <summary>
        /// 当前转速和方向
        /// </summary>
        public Cls.Model_PumpState FP2State
        {
            get { return fp2State; }
            set { fp2State = value; }
        }

        private Cls.Model_PumpState cpState = new Model_PumpState();
        /// <summary>
        /// 当前转速和方向
        /// </summary>
        public Cls.Model_PumpState CPState
        {
            get { return cpState; }
            set { cpState = value; }
        }

        private double spspeed;
        public double SPSpeed
        {
            get { return spspeed; }
            set { spspeed = value; }
        }

        //夹管阀状态 初始值 为夹管
        private byte[] vState = new byte[] { 1, 1, 1, 1, 1, 1 };
        public byte[] VState
        {
            get { return vState; }
            set { vState = value; }
        }
    }
}
