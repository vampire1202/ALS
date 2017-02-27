using System;
namespace ALS.Model
{
    /// <summary>
    /// pressure_data:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class pressure_data
    {
        public pressure_data()
        { }
        #region Model
        private string _surgery_no;
        private string _time_stamp;
        private string _in_blood_pressure;
        private string _plasma_inlet_pressure;
        private string _arterial_pressure;
        private string _venous_pressure;
        private string _plasma_pressure;
        private string _transmembrane_pressure;
        /// <summary>
        /// 手术号
        /// </summary>
        public string surgery_no
        {
            set { _surgery_no = value; }
            get { return _surgery_no; }
        }
        /// <summary>
        /// 治疗时间 s
        /// </summary>
        public string time_stamp
        {
            set { _time_stamp = value; }
            get { return _time_stamp; }
        }
        /// <summary>
        /// 采血压
        /// </summary>
        public string in_blood_pressure
        {
            set { _in_blood_pressure = value; }
            get { return _in_blood_pressure; }
        }
        /// <summary>
        /// 血浆入口压P1st
        /// </summary>
        public string plasma_inlet_pressure
        {
            set { _plasma_inlet_pressure = value; }
            get { return _plasma_inlet_pressure; }
        }
        /// <summary>
        /// 动脉压
        /// </summary>
        public string arterial_pressure
        {
            set { _arterial_pressure = value; }
            get { return _arterial_pressure; }
        }
        /// <summary>
        /// 静脉压
        /// </summary>
        public string venous_pressure
        {
            set { _venous_pressure = value; }
            get { return _venous_pressure; }
        }
        /// <summary>
        /// 血浆压
        /// </summary>
        public string plasma_pressure
        {
            set { _plasma_pressure = value; }
            get { return _plasma_pressure; }
        }
        /// <summary>
        /// 跨膜压
        /// </summary>
        public string transmembrane_pressure
        {
            set { _transmembrane_pressure = value; }
            get { return _transmembrane_pressure; }
        }
        #endregion Model

    }
}

