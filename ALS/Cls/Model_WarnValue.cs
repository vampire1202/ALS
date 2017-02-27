using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    public class Model_WarnValue
    {
        float _upperPacc;
        //<!--报警上下限-->
        //<add key="PaccUpper" value="500"/>
        /// <summary>
        /// 采血压上限
        /// </summary>       
        public float UpperPacc
        {
            get { return _upperPacc; }
            set { _upperPacc = value; }
        }

        float _lowerPacc;
        //<add key="PaccLower" value="-250"/>
        /// <summary>
        /// 采血压下限
        /// </summary>       
        public float LowerPacc
        {
            get { return _lowerPacc; }
            set { _lowerPacc = value; }
        }

        float _upperPart;
        //<add key="PartUpper" value="250"/>
        /// <summary>
        /// 动脉压上限
        /// </summary>
        public float UpperPart
        {
            get { return _upperPart; }
            set { _upperPart = value; }
        }

        float _lowerPart;
        //<add key="PartLower" value="-250"/>
        /// <summary>
        /// 动脉压下限
        /// </summary>
        public float LowerPart
        {
            get { return _lowerPart; }
            set { _lowerPart = value; }
        }

        float _upperPven;
        //<add key="PrenUpper" value="250"/>
        /// <summary>
        /// 静脉压上限
        /// </summary>
        public float UpperPven
        {
            get { return _upperPven; }
            set { _upperPven = value; }
        }

        float _lowerPven;
        //<add key="PrenLower" value="0"/>
        /// <summary>
        /// 静脉压下限
        /// </summary>
        public float LowerPven
        {
            get { return _lowerPven; }
            set { _lowerPven = value; }
        }

        float _upperP1st;
        //<add key ="P1stUpper" value="250"/>
        /// <summary>
        /// 血浆压上限
        /// </summary>
        public float UpperP1st
        {
            get { return _upperP1st; }
            set { _upperP1st = value; }
        }

        float _lowerP1st;
        //<add key="P1stLower" value="-300"/>
        /// <summary>
        /// 血浆压下限
        /// </summary>
        public float LowerP1st
        {
            get { return _lowerP1st; }
            set { _lowerP1st = value; }
        }

        float _upperP2nd;
        //<add key="P2ndUpper" value="400"/>
        /// <summary>
        /// 血浆入口压上限
        /// </summary>
        public float UpperP2nd
        {
            get { return _upperP2nd; }
            set { _upperP2nd = value; }
        }

        float _lowerP2nd;
        //<add key="P2ndLower" value="-100"/>
        /// <summary>
        /// 血浆入口压下限
        /// </summary>
        public float LowerP2nd
        {
            get { return _lowerP2nd; }
            set { _lowerP2nd = value; }
        }

        float _upperTmp;
        //<add key="TmpUpper" value="250"/>
        /// <summary>
        /// 跨膜压上限
        /// </summary>
        public float UpperTmp
        {
            get { return _upperTmp; }
            set { _upperTmp = value; }
        }

        float _lowerTmp;
        //<add key="TmpLower" value="-250"/>
        /// <summary>
        /// 跨膜压下限
        /// </summary>
        public float LowerTmp
        {
            get { return _lowerTmp; }
            set { _lowerTmp = value; }
        }

        float _lowerPrePacc;
        //<add key ="PrePaccLower" value="0"/>
        /// <summary>
        /// 采血压下限预报警
        /// </summary>
        public float LowerPrePacc
        {
            get { return _lowerPrePacc; }
            set { _lowerPrePacc = value; }
        }

        //<add key="PrePrenUpper" value="0"/>
        float _upperPrePven;
        /// <summary>
        /// 静脉压上限预报警
        /// </summary>
        public float UpperPrePven
        {
            get { return _upperPrePven; }
            set { _upperPrePven = value; }
        }

        float _lowerPrePven;
        /// <summary>
        /// 静脉压下限预报警
        /// </summary>
        public float LowerPrePven
        {
            get { return _lowerPrePven; }
            set { _lowerPrePven = value; }
        }

        float _upperPrePart;
        //<add key ="PrePartUpper" value="0"/>
        /// <summary>
        /// 动脉压上限预报警
        /// </summary>
        public float UpperPrePart
        {
            get { return _upperPrePart; }
            set { _upperPrePart = value; }
        }

        float _bloodLeak;
        //<add key ="BloodLeak" value="0"/>
        /// <summary>
        /// 漏血值
        /// </summary>
        public float BloodLeak
        {
            get { return _bloodLeak; }
            set { _bloodLeak = value; }
        }
    }
}
