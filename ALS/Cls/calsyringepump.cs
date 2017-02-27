using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    public   class calsyringepump
    {
        public calsyringepump()
        { }
        //管理界面注射器运行
        private static double Manager_sySpeed;
        //传感器零点校准参数byte数组
        //行程12：短电位(13,23,33)，长电位(0,50,100)(0-11);压力值6：0 30mL(50Kpa,100Kpa下)(12,13,26,27,28,29)
        private byte[] cal_SyPoten = new byte[34];
        //是否要采集传感器数据
        private  bool collectData_YN;
        private bool collectSyDta_YN;
        //注射是否识别
        private static bool rec_SyVersion;
        //注射器校准参数byte数组
        //型号1,管径23,长度45,完成距离67；
        private  byte[] cal_SyThirty = new byte[7];
        //注射器规格；
        static byte sy_version;
        //注射器品牌
        private  string sy_brand;
        private int sLen_Syringe;
        private int lLen_Syringe;
        private int p_Syringe;
        private double sy_cali;
        private double sy_Compd;

        public static double Manager_SySpeed
        {
            set { Manager_sySpeed = value; }
            get { return Manager_sySpeed; }
        }
        public  byte[] Cal_SyPoten
        {
            set { cal_SyPoten = value; }
            get { return cal_SyPoten; }
        }
        public  bool CollectData_YN
        {
            set { collectData_YN = value; }
            get { return collectData_YN; }
        }
        public bool CollectSyDta_YN
        {
            set { collectSyDta_YN = value; }
            get { return collectSyDta_YN; }
        }
        public  byte[] Cal_SyThirty
        { 
            set{cal_SyThirty= value;}
            get { return cal_SyThirty; }
        }
        public static bool Rec_SyVersion
        {
            set { rec_SyVersion = value; }
            get { return rec_SyVersion; }
        }
        public static byte Sy_version
        {
            set { sy_version = value; }
            get { return sy_version; }
        }
        public  string Sy_brand
        {
            set { sy_brand = value; }
            get { return sy_brand; }
        }
        public int SLen_Syringe
        {
            set { sLen_Syringe = value; }
            get { return sLen_Syringe; }
        }
        public int LLen_Syringe
        {
            set { lLen_Syringe = value; }
            get { return lLen_Syringe; }
        }
        public int P_Syringe
        {
            set { p_Syringe = value; }
            get { return p_Syringe; }
        }
        public double Sy_cali
        {
            set { sy_cali=value; }
            get { return sy_cali; }
        }
        public double Sy_Compd
        { 
            set { sy_Compd = value; }
            get { return sy_Compd; }
        }
    }
}
