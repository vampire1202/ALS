using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    public class Model_Set
    {
        private double speedSP;
        /// <summary>
        /// 肝素泵速度
        /// </summary>
        public double SpeedSP
        {
            get { return speedSP; }
            set { speedSP = value; }
        }

        private double speedBP;
        /// <summary>
        /// 血泵速度
        /// </summary>
        public double SpeedBP
        {
            get { return speedBP; }
            set { speedBP = value; }
        }

        private bool bpdirection;
        public bool BPDirection
        {
            get { return bpdirection; }
            set { bpdirection = value; }
        }

        private bool bpvalid;
        public bool BPValid
        {
            get {return bpvalid;}
            set {bpvalid = value;}
        } 

        private double speedFP;
        /// <summary>
        /// 分离泵速度
        /// </summary>
        public double SpeedFP
        {
            get { return speedFP; }
            set { speedFP = value; }
        }

        private bool fpvalid;
        public bool FPValid
        {
            get { return fpvalid; }
            set { fpvalid = value; }
        } 
        private bool fpdirection;
        public bool FPDirection
        {
            get { return fpdirection; }
            set { fpdirection = value; }
        }
        private double speedRP;
        /// <summary>
        /// 补液泵速度
        /// </summary>
        public double SpeedRP
        {
            get { return speedRP; }
            set { speedRP = value; }
        }

        private bool rpvalid;
        public bool RPValid
        {
            get { return rpvalid; }
            set { rpvalid = value; }
        } 
        private bool rpdirection;
        public bool RPDirection
        {
            get { return rpdirection; }
            set { rpdirection = value; }
        }
        private double speedDP;
        /// <summary>
        /// 透析液速度
        /// </summary>
        public double SpeedDP
        {
            get { return speedDP; }
            set { speedDP = value; }
        }

        private bool dpvalid;
        public bool DPValid
        {
            get { return dpvalid; }
            set { dpvalid = value; }
        } 

        private bool dpdirection;
        public bool DPDirection
        {
            get { return dpdirection; }
            set { dpdirection = value; }
        }

        private double speedFP2;
        /// <summary>
        /// 滤过泵速度
        /// </summary>
        public double SpeedFP2
        {
            get { return speedFP2; }
            set { speedFP2 = value; }
        }

        private bool fp2valid;
        public bool FP2Valid
        {
            get { return fp2valid; }
            set { fp2valid = value; }
        } 
        private bool fp2direction;
        public bool FP2Direction
        {
            get { return fp2direction; }
            set { fp2direction = value; }
        }

        private double speedCP;
        /// <summary>
        /// 循环泵速度
        /// </summary>
        public double SpeedCP
        {
            get { return speedCP; }
            set { speedCP = value; }
        }

        private bool cpvalid;
        public bool CPValid
        {
            get { return cpvalid; }
            set { cpvalid = value; }
        } 

        private bool cpdirection;
        public bool CPDirection
        {
            get { return cpdirection; }
            set { cpdirection = value; }
        }

        private int targetTime;
        /// <summary>
        /// 目标治疗时间
        /// </summary>
        public int TargetTime
        {
            get { return targetTime; }
            set { targetTime = value; }
        }

        private bool targetTimeValid;
        /// <summary>
        /// 目标治疗时间是否有效
        /// </summary>
        public bool TargetValid_time
        {
            get { return targetTimeValid; }
            set { targetTimeValid = value; }
        }

        private double targetBP;
        /// <summary>
        /// 目标血液泵循环量
        /// </summary>
        public double TargetBP
        {
            get { return targetBP; }
            set { targetBP = value; }
        }

        private bool targetValid_BP;
        /// <summary>
        /// 目标血液泵循环量
        /// </summary>
        public bool TargetValid_BP
        {
            get { return targetValid_BP; }
            set { targetValid_BP = value; }
        }

        private double targetSP;
        /// <summary>
        /// 目标肝素泵累计是否有效
        /// </summary>
        public double TargetSP
        {
            get { return targetSP; }
            set { targetSP = value; }
        }

        private bool targetValid_SP;
        /// <summary>
        /// 目标肝素泵累计是否有效
        /// </summary>
        public bool TargetValid_SP
        {
            get { return targetValid_SP; }
            set { targetValid_SP = value; }
        }

        private double targetRP;
        /// <summary>
        /// 目标补液泵累计是否有效
        /// </summary>
        public double TargetRP
        {
            get { return targetRP; }
            set { targetRP = value; }
        }

        private bool targetValid_RP;
        /// <summary>
        /// 目标补液泵泵累计是否有效
        /// </summary>
        public bool TargetValid_RP
        {
            get { return targetValid_RP; }
            set { targetValid_RP = value; }
        }

        private double targetFP;
        /// <summary>
        /// 目标分离泵累计是否有效
        /// </summary>
        public double TargetFP
        {
            get { return targetFP; }
            set { targetFP = value; }
        }

        private bool targetValid_FP;
        /// <summary>
        /// 目标分离泵累计是否有效
        /// </summary>
        public bool TargetValid_FP
        {
            get { return targetValid_FP; }
            set { targetValid_FP = value; }
        }


        private double targetDP;
        /// <summary>
        /// 目标分离泵累计是否有效
        /// </summary>
        public double TargetDP
        {
            get { return targetDP; }
            set { targetDP = value; }
        }

        private bool targetValid_DP;
        /// <summary>
        /// 目标分离泵累计是否有效
        /// </summary>
        public bool TargetValid_DP
        {
            get { return targetValid_DP; }
            set { targetValid_DP = value; }
        }


        private double targetTemperature;
        /// <summary>
        /// 目标温度
        /// </summary>
        public double TargetTemperature
        {
            get { return targetTemperature; }
            set { targetTemperature = value; }
        }

        private double targetFlushValue;
        /// <summary>
        /// 目标清洗量
        /// </summary>
        public double TargetFlushValue
        {
            get { return targetFlushValue; }
            set { targetFlushValue = value; }
        }

        /// <summary>
        /// 脱水速度
        /// </summary>
        private double dehydrationSpeed;
        public double DehydrationSpeed
        {
            get { return dehydrationSpeed; }
            set { dehydrationSpeed = value; }
        }

        /// <summary>
        /// 是否设置脱水
        /// </summary>
        private bool dehydrationValid;       
        public bool DehydrationValid
        {
            get { return dehydrationValid; }
            set { dehydrationValid = value; }
        }
    }
}
