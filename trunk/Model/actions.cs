using System;
namespace ALS.Model
{
    /// <summary>
    /// tb_actions:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class actions
    {
        public actions()
        { }
        #region Model
        private long _id;
        private long? _customid;
        private string _portname;
        private byte[] _arrcommand;
        private string _actionInfo;
        private int _cmdLength;
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
        public long? customID
        {
            set { _customid = value; }
            get { return _customid; }
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
        public byte[] arrCommand
        {
            set { _arrcommand = value; }
            get { return _arrcommand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string actionInfo
        {
            set { _actionInfo = value; }
            get { return _actionInfo; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int cmdLength
        {
            set { _cmdLength = value; }
            get { return _cmdLength; }
        }
        #endregion Model

    }
}

