using System;
namespace ALS.Model
{
	/// <summary>
	/// customactions:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class customactions
	{
		public customactions()
		{}
		#region Model
		private long _id;
		private string _methodname;
		private int? _timecount;
        private int? _timespan;
		private string _actionname;
        private string _timeString;
        private string _timeSpanString;
        private byte[] _tipPic;
		/// <summary>
		/// auto_increment
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string methodName
		{
			set{ _methodname=value;}
			get{return _methodname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? timeCount
		{
			set{ _timecount=value;}
			get{return _timecount;}
		}

        /// <summary>
        /// 
        /// </summary>
        public int? timeSpan
        {
            set { _timespan = value; }
            get { return _timespan; }
        }

		/// <summary>
		/// 
		/// </summary>
		public string actionName
		{
			set{ _actionname=value;}
			get{return _actionname;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string timeString
        {
            set { _timeString = value; }
            get { return _timeString; }
        }

        public string timeSpanString
        {
            set { _timeSpanString = value; }
            get { return _timeSpanString; }
        }
        public byte[] tipPic
        {
            get { return _tipPic; }
            set { _tipPic = value; }
        }
		#endregion Model

	}
}

