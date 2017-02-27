using System;
namespace ALS.Model
{
    /// <summary>
    /// treatmentmode:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class treatmentmode
    {
        public treatmentmode()
        { }
        #region Model
        private long _id;
        private string _name;
        private double? _bpspeed;
        private bool _bpdirection;
        private bool _bpvalid;
        private double? _fpspeed;
        private bool _fpdirection;
        private bool _fpvalid;
        private double? _dpspeed;
        private bool _dpdirection;
        private bool _dpvalid;
        private double? _rpspeed;
        private bool _rpdirection;
        private bool _rpvalid;
        private double? _fp2speed;
        private bool _fp2direction;
        private bool _fp2valid;
        private double? _cpspeed;
        private bool _cpdirection;
        private bool _cpvalid;
        private double? _dehydrationspeed;
        private bool _dehydrationvalid;
        private int? _targettimeh;
        private int? _targettimemin;
        private bool _istargettime;
        private double? _targetbp;
        private bool _istargetbp;
        private double? _targetdp;
        private bool _istargetdp;
        private double? _targetsp;
        private bool _istargetsp;
        private double? _targetrp;
        private bool _istargetrp;
        private double? _targetfp;
        private bool _istargetfp;
        private double? _concentration;
        private double? _sp_speed;
        private double? _sp_rapidinjectionvalue;
        private double? _targett;
        private int? _paccupper;
        private int? _pacclower;
        private int? _partupper;
        private int? _partlower;
        private int? _pvenupper;
        private int? _pvenlower;
        private int? _p1stupper;
        private int? _p1stlower;
        private int? _p2ndupper;
        private int? _p2ndlower;
        private int? _tmpupper;
        private int? _tmplower;
        private int? _prepacclower;
        private int? _prepvenupper;
        private int? _bloodleak;
        private int? _prepartupper;
        private int? _p3rdupper;
        private int? _p3rdlower;
        private int? _leadBloodTime;
        private int? _leadBloodSpeed;
        private int? _paccDecrement;
        /// <summary>
        /// auto_increment
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? BPSpeed
        {
            set { _bpspeed = value; }
            get { return _bpspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BPDirection
        {
            set { _bpdirection = value; }
            get { return _bpdirection; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BPValid
        {
            set { _bpvalid = value; }
            get { return _bpvalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? FPSpeed
        {
            set { _fpspeed = value; }
            get { return _fpspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FPDirection
        {
            set { _fpdirection = value; }
            get { return _fpdirection; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FPValid
        {
            set { _fpvalid = value; }
            get { return _fpvalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? DPSpeed
        {
            set { _dpspeed = value; }
            get { return _dpspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DPDirection
        {
            set { _dpdirection = value; }
            get { return _dpdirection; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool DPValid
        {
            set { _dpvalid = value; }
            get { return _dpvalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? RPSpeed
        {
            set { _rpspeed = value; }
            get { return _rpspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool RPDirection
        {
            set { _rpdirection = value; }
            get { return _rpdirection; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool RPValid
        {
            set { _rpvalid = value; }
            get { return _rpvalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? FP2Speed
        {
            set { _fp2speed = value; }
            get { return _fp2speed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FP2Direction
        {
            set { _fp2direction = value; }
            get { return _fp2direction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool FP2Valid
        {
            set { _fp2valid = value; }
            get { return _fp2valid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? CPSpeed
        {
            set { _cpspeed = value; }
            get { return _cpspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool CPDirection
        {
            set { _cpdirection = value; }
            get { return _cpdirection; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool CPValid
        {
            set { _cpvalid = value; }
            get { return _cpvalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? dehydrationSpeed
        {
            set { _dehydrationspeed = value; }
            get { return _dehydrationspeed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool dehydrationValid
        {
            set { _dehydrationvalid = value; }
            get { return _dehydrationvalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TargetTimeH
        {
            set { _targettimeh = value; }
            get { return _targettimeh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TargetTimeMin
        {
            set { _targettimemin = value; }
            get { return _targettimemin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTargetTime
        {
            set { _istargettime = value; }
            get { return _istargettime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? TargetBP
        {
            set { _targetbp = value; }
            get { return _targetbp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTargetBP
        {
            set { _istargetbp = value; }
            get { return _istargetbp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? TargetDP
        {
            set { _targetdp = value; }
            get { return _targetdp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTargetDP
        {
            set { _istargetdp = value; }
            get { return _istargetdp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? TargetSP
        {
            set { _targetsp = value; }
            get { return _targetsp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTargetSP
        {
            set { _istargetsp = value; }
            get { return _istargetsp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? TargetRP
        {
            set { _targetrp = value; }
            get { return _targetrp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTargetRP
        {
            set { _istargetrp = value; }
            get { return _istargetrp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? TargetFP
        {
            set { _targetfp = value; }
            get { return _targetfp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTargetFP
        {
            set { _istargetfp = value; }
            get { return _istargetfp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? Concentration
        {
            set { _concentration = value; }
            get { return _concentration; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? SP_Speed
        {
            set { _sp_speed = value; }
            get { return _sp_speed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? SP_RapidInjectionValue
        {
            set { _sp_rapidinjectionvalue = value; }
            get { return _sp_rapidinjectionvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? TargetT
        {
            set { _targett = value; }
            get { return _targett; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PaccUpper
        {
            set { _paccupper = value; }
            get { return _paccupper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PaccLower
        {
            set { _pacclower = value; }
            get { return _pacclower; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PartUpper
        {
            set { _partupper = value; }
            get { return _partupper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PartLower
        {
            set { _partlower = value; }
            get { return _partlower; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PvenUpper
        {
            set { _pvenupper = value; }
            get { return _pvenupper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PvenLower
        {
            set { _pvenlower = value; }
            get { return _pvenlower; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? P1stUpper
        {
            set { _p1stupper = value; }
            get { return _p1stupper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? P1stLower
        {
            set { _p1stlower = value; }
            get { return _p1stlower; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? P2ndUpper
        {
            set { _p2ndupper = value; }
            get { return _p2ndupper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? P2ndLower
        {
            set { _p2ndlower = value; }
            get { return _p2ndlower; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TmpUpper
        {
            set { _tmpupper = value; }
            get { return _tmpupper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TmpLower
        {
            set { _tmplower = value; }
            get { return _tmplower; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PrePaccLower
        {
            set { _prepacclower = value; }
            get { return _prepacclower; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PrePvenUpper
        {
            set { _prepvenupper = value; }
            get { return _prepvenupper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BloodLeak
        {
            set { _bloodleak = value; }
            get { return _bloodleak; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? PrePartUpper
        {
            set { _prepartupper = value; }
            get { return _prepartupper; }
        }

        public int? P3rdUpper
        {
            set { _p3rdupper = value; }
            get { return _p3rdupper; }
        }
        public int? P3rdLower
        {
            set { _p3rdlower = value; }
            get { return _p3rdlower; }
        }

        public int? LeadBloodTime
        {
            set { _leadBloodTime = value; }
            get { return _leadBloodTime; }
        }

        public int? LeadBloodSpeed
        {
            set { _leadBloodSpeed = value; }
            get { return _leadBloodSpeed; }
        }

        public int? PaccDecrement
        {
            set { _paccDecrement = value; }
            get { return _paccDecrement; }
        }

        #endregion Model

    }
}

