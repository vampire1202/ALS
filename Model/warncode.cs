using System;
namespace ALS.Model
{
    /// <summary>
    /// warncode:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class warncode
    {
        public warncode()
        { }
        #region Model
        private long _id;
        private string _code;
        private string _content;
        private string _reason;
        private string _deal;
        private int _grade;
        private string _dealsteps;
        private byte[] _dealimg;
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
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string reason
        {
            set { _reason = value; }
            get { return _reason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string deal
        {
            set { _deal = value; }
            get { return _deal; }
        }

        public int grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        /// <summary>
        /// 处理步骤
        /// </summary>
        public string dealSteps
        {
            set { _dealsteps = value; }
            get { return _dealsteps; }
        }
        /// <summary>
        /// 示意图
        /// </summary>
        public byte[] dealImg
        {
            set { _dealimg = value; }
            get { return _dealimg; }
        }

        #endregion Model

    }
}

