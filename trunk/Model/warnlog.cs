using System;
namespace ALS.Model
{
    /// <summary>
    /// warnlog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class warnlog
    {
        public warnlog()
        { }
        #region Model
        private long _id;
        private DateTime? _logtime;
        private string _warncode;
        private string _warntitle;
        private string _sign;
        private string _para1;
        private string _para2;
        private string _para3;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? logtime
        {
            set { _logtime = value; }
            get { return _logtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string warncode
        {
            set { _warncode = value; }
            get { return _warncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string warntitle
        {
            set { _warntitle = value; }
            get { return _warntitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sign
        {
            set { _sign = value; }
            get { return _sign; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string para1
        {
            set { _para1 = value; }
            get { return _para1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string para2
        {
            set { _para2 = value; }
            get { return _para2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string para3
        {
            set { _para3 = value; }
            get { return _para3; }
        }
        #endregion Model

    }
}

