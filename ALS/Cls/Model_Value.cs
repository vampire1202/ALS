using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    public class Model_Value
    {
        //double _weigh2balance;

        //public double Weigh2balance
        //{
        //    get { return _weigh2balance; }
        //    set { _weigh2balance = value; }
        //}
        //double _weigh3balance;

        //public double Weigh3balance
        //{
        //    get { return _weigh3balance; }
        //    set { _weigh3balance = value; }
        //}


        double _flt_Temperature;
        double _flt_TemperatureKZ;

        public double Flt_TemperatureKZ
        {
            get { return _flt_TemperatureKZ; }
            set { _flt_TemperatureKZ = value; }
        }
        double _flt_TemperatureJC;

        public double Flt_TemperatureJC
        {
            get { return _flt_TemperatureJC; }
            set { _flt_TemperatureJC = value; }
        }
        double _flt_Weigh1;
        double _flt_Weigh2;
        double _flt_Weigh3;
        double _flt_Weigh4;
        double _flt_SpeedBP;
        double _flt_SpeedFP;
        double _flt_SpeedDP;
        double _flt_SpeedRP;
        double _flt_SpeedFP2;
        double _flt_SpeedCP;
        double _flt_PofPacc;
        double _flt_PofPart;
        double _flt_PofPven;        
        double _flt_PofP1st;
        double _flt_PofTMP;
        double _flt_PofP2nd;
        double _flt_PofP3rd;
        double _flt_BloodLeak;
        int _flt_DisChar;
        int _flt_VCodeBB;
        int _flt_VCodeCC;
        double _flt_PaccDecrement;

        /// <summary>
        /// 实时温度
        /// </summary>
        public double M_flt_Temperature
        {
            get { return _flt_Temperature; }
            set { _flt_Temperature = value; }
        }
        /// <summary>
        /// 充放电
        /// </summary>
        public int M_flt_DisChar
        {

            get { return _flt_DisChar; }
            set { _flt_DisChar = value; }
        }
        /// <summary>
        /// 电池标定容量
        /// </summary>
        public int M_flt_VCodeBB
        {

            get { return _flt_VCodeBB; }
            set { _flt_VCodeBB = value; }
        }
         /// <summary>
        /// 电池当前容量
        /// </summary>
        public int M_flt_VCodeCC
        {
            get { return _flt_VCodeCC; }
            set { _flt_VCodeCC = value; }
        }

        //各称重系统值
        
        /// <summary>
        /// 称重1
        /// </summary>
        public double M_flt_Weigh1
        { 
            
            get { return _flt_Weigh1; }
            set {_flt_Weigh1 = value; }
        }
           
        /// <summary>
        /// 称重2
        /// </summary>
        public double M_flt_Weigh2
        { 
            
            get { return _flt_Weigh2; }
            set { _flt_Weigh2 = value; }
        }
       
        /// <summary>
        /// 称重3
        /// </summary>
        public double M_flt_Weigh3
        {

            get { return _flt_Weigh3; }
            set { _flt_Weigh3 = value; }
        }
        //称重4
        public double M_flt_Weigh4
        {

            get { return _flt_Weigh4; }
            set { _flt_Weigh4 = value; }
        }  
        /// <summary>
        /// /血泵速度
        /// </summary>
        public double M_flt_SpeedBP
        {

            get { return _flt_SpeedBP; }
            set { _flt_SpeedBP = value; }
        }                
        /// <summary>
        /// 分离泵速度
        /// </summary>
        public double M_flt_SpeedFP
        {

            get { return _flt_SpeedFP; }
            set { _flt_SpeedFP = value; }
        }       
        /// <summary>
        /// 透析液泵速度
        /// </summary>
        public double M_flt_SpeedDP
        {

            get { return _flt_SpeedDP; }
            set { _flt_SpeedDP = value; }
        }       
        /// <summary>
        /// 补液泵速度
        /// </summary>
        public double M_flt_SpeedRP
        {

            get { return _flt_SpeedRP; }
            set { _flt_SpeedRP = value; }
        }       
        /// <summary>
        /// 滤过泵速度
        /// </summary>
        public double M_flt_SpeedFP2
        {

            get { return _flt_SpeedFP2; }
            set { _flt_SpeedFP2 = value; }
        }       
        /// <summary>
        /// 循环泵速度
        /// </summary>
        public double M_flt_SpeedCP
        {

            get { return _flt_SpeedCP; }
            set { _flt_SpeedCP = value; }
        }
        /// <summary>
        /// 采血压
        /// </summary>
        public double M_flt_PofPacc
        {

            get { return _flt_PofPacc; }
            set { _flt_PofPacc = value; }
        }       
        /// <summary>
        /// 动脉压
        /// </summary>
        public double M_flt_PofPart
        {

            get { return _flt_PofPart; }
            set { _flt_PofPart = value; }
        }
        /// <summary>
        /// 静脉压
        /// </summary>
        public double M_flt_PofPven
        {

            get { return _flt_PofPven; }
            set { _flt_PofPven = value; }
        }
        
        /// <summary>
        /// 跨膜压
        /// </summary>
        public double M_flt_PofTMP
        {

            get { return _flt_PofTMP; }
            set { _flt_PofTMP = value; }
        }
       
        /// <summary>
        /// 血浆压
        /// </summary>
        public double M_flt_PofP1st
        {

            get { return _flt_PofP1st; }
            set { _flt_PofP1st = value; }
        }
      
        /// <summary>
        /// 血浆入口压
        /// </summary>
        public double M_flt_PofP2nd
        {

            get { return _flt_PofP2nd; }
            set { _flt_PofP2nd = value; }
        }


        /// <summary>
        /// 血浆入口压
        /// </summary>
        public double M_flt_PofP3rd
        {

            get { return _flt_PofP3rd; }
            set { _flt_PofP3rd = value; }
        }
       
        /// <summary>
        /// 漏血值
        /// </summary>
        public double M_flt_BloodLeak
        {

            get { return _flt_BloodLeak; }
            set { _flt_BloodLeak = value; }
        }

        public double M_flt_PaccDecrement
        {
            get { return _flt_PaccDecrement; }
            set { _flt_PaccDecrement = value; }
        }
        //肝素泵速度

        //当前时间
    }
}
