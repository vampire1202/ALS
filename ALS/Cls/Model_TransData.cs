using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace ALS.Cls
{
    [DataContract(Name="Model_TransData")]
    class Model_TransData
    {
        double dPacc;//'采⾎压' Pacc
        [DataMember(Name="dPacc")]
        public double DPacc
        {
            get { return dPacc; }
            set { dPacc = value; }
        }
        double dPart;//'动脉压' Part
        [DataMember(Name="dPart")]
        public double DPart
        {
            get { return dPart; }
            set { dPart = value; }
        }
        double dPven;//'静脉压' Pven
        [DataMember(Name="dPven")]
        public double DPven
        {
            get { return dPven; }
            set { dPven = value; }
        }
        double dP1st;//'⾎浆压P1st'
        [DataMember(Name = "dP1st")]
        public double DP1st
        {
            get { return dP1st; }
            set { dP1st = value; }
        }
        double dTMP;//‘跨膜压' TMP
        [DataMember(Name = "dTMP")]
        public double DTMP
        {
            get { return dTMP; }
            set { dTMP = value; }
        }

        double dP2nd;// ⾎浆⼊⼜P2nd
        [DataMember(Name = "dP2nd")]
        public double DP2nd
        {
            get { return dP2nd; }
            set { dP2nd = value; }
        }
        double dP3rd; //滤过压 P3rd
        [DataMember(Name = "dP3rd")]
        public double DP3rd
        {
            get { return dP3rd; }
            set { dP3rd = value; }
        }
        long cumulativeTime;//'累计时间'
        [DataMember(Name = "cumulativeTime")]
        public long CumulativeTime
        {
            get { return cumulativeTime; }
            set { cumulativeTime = value; }
        }
        int iBPSpeed;//⾎泵BP
        [DataMember(Name = "iBPSpeed")]
        public int IBPSpeed
        {
            get { return iBPSpeed; }
            set { iBPSpeed = value; }
        }
        int iFPSpeed;//分离泵FP
        [DataMember(Name = "iFPSpeed")]
        public int IFPSpeed
        {
            get { return iFPSpeed; }
            set { iFPSpeed = value; }
        }
        int iDPSpeed;//透析泵DP
        [DataMember(Name = "iDPSpeed")]
        public int IDPSpeed
        {
            get { return iDPSpeed; }
            set { iDPSpeed = value; }
        }
        int iRPSpeed;//返液泵RP
        [DataMember(Name = "iRPSpeed")]
        public int IRPSpeed
        {
            get { return iRPSpeed; }
            set { iRPSpeed = value; }
        }
        int iFP2SPeed;//滤过泵FP2
        [DataMember(Name = "iFP2Speed")]
        public int IFP2SPeed
        {
            get { return iFP2SPeed; }
            set { iFP2SPeed = value; }
        }
        int iCPSpeed;//循环泵CP
        [DataMember(Name = "iCPSpeed")]
        public int ICPSpeed
        {
            get { return iCPSpeed; }
            set { iCPSpeed = value; }
        }
        int iSPSpeed;//肝素泵
        [DataMember(Name = "iSPSpeed")]
        public int ISPSpeed
        {
            get { return iSPSpeed; }
            set { iSPSpeed = value; }
        }
        double warmer;//'加热温度'
        [DataMember(Name = "warmer")]
        public double Warmer
        {
            get { return warmer; }
            set { warmer = value; }
        }
        double dBPT;//'⾎液泵累计' 精确到0.1L
        [DataMember(Name = "dBPT")]
        public double DBPT
        {
            get { return dBPT; }
            set { dBPT = value; }
        }
        double dFPT;//'FP累计'精确到0.1L
         [DataMember(Name = "dFPT")]
        public double DFPT
        {
            get { return dFPT; }
            set { dFPT = value; }
        }
         double dDPT;//'DP累计'精确到0.1L
         [DataMember(Name = "dDPT")]
         public double DDPT
         {
             get { return dDPT; }
             set { dDPT = value; }
         }
         double dRPT;//'RP累计'精确到0.1L
         [DataMember(Name = "dRPT")]
         public double DRPT
         {
             get { return dRPT; }
             set { dRPT = value; }
         }
         double dFP2T;//'FP2累计'精确到0.1L
         [DataMember(Name = "dFP2T")]
         public double DFP2T
         {
             get { return dFP2T; }
             set { dFP2T = value; }
         }
         double dSPT;//‘SP累计’(精确到0.1mL) 
         [DataMember(Name = "dSPT")]
         public double DSPT
         {
             get { return dSPT; }
             set { dSPT = value; }
         }
         string surgeryNo;//手术编号
         [DataMember(Name = "surgeryNo")]
         public string SurgeryNo
         {
             get { return surgeryNo; }
             set { surgeryNo = value; }
         }

         long id;
        [DataMember(Name = "id")]
         public long Id
         {
             get { return id; }
             set { id = value; }
         }

        long timestamp;
        [DataMember(Name = "timestamp")]
        public long Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

    }
}
