using System;
namespace ALS.Model
{
    /// <summary>
    /// syringecal:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class syringecal
    {
        public syringecal()
        { }
        #region Model
        private int _id;
        private string _brand;
        private int _version;
        private int? _calibre;
        private int? _compdis;
        private int? _length;
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
        public string brand
        {
            set { _brand = value; }
            get { return _brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int version
        {
            set { _version = value; }
            get { return _version; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? calibre
        {
            set { _calibre = value; }
            get { return _calibre; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? compdis
        {
            set { _compdis = value; }
            get { return _compdis; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? length
        {
            set { _length = value; }
            get { return _length; }
        }
        #endregion Model

    }
}

