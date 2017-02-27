using System;
namespace ALS.Model
{
    /// <summary>
    /// actiontitle:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class actiontitle
    {
        public actiontitle()
        { }
        #region Model
        private int _id;
        private string _info;
        private string _method;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string info
        {
            set { _info = value; }
            get { return _info; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string method
        {
            set { _method = value; }
            get { return _method; }
        }
        #endregion Model

    }
}

