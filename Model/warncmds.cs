using System;
namespace ALS.Model
{
    /// <summary>
    /// warncmds:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class warncmds
    {
        public warncmds()
        { }
        #region Model
        private int _id;
        private int? _warncodeid;
        private string _actioninfo;
        private string _portname;
        private byte[] _cmd;
        private int? _cmdlength;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? warnCodeID
        {
            set { _warncodeid = value; }
            get { return _warncodeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string actionInfo
        {
            set { _actioninfo = value; }
            get { return _actioninfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string portName
        {
            set { _portname = value; }
            get { return _portname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] cmd
        {
            set { _cmd = value; }
            get { return _cmd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cmdLength
        {
            set { _cmdlength = value; }
            get { return _cmdlength; }
        }
        #endregion Model

    }
}

