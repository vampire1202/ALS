using System;
namespace ALS.Model
{
    /// <summary>
    /// pump_speed_data:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class pump_speed_data
    {
        public pump_speed_data()
        { }
        #region Model
        private string _surgery_no;
        private string _time_stamp;
        private string _cumulative_time;
        private string _blood_pump;
        private string _separation_pump;
        private string _dialysis_pump;
        private string _tripe_pump;
        private string _filtration_pump;
        private string _circulating_pump;
        private string _heparin_pump;
        private string _warmer;
        private string _blood_pump_t;
        private string _separation_pump_t;
        private string _dialysis_pump_t;
        private string _tripe_pump_t;
        private string _filtration_pump_t;
        private string _circulating_pump_t;
        private string _heparin_pump_t;
        /// <summary>
        /// 手术号
        /// </summary>
        public string surgery_no
        {
            set { _surgery_no = value; }
            get { return _surgery_no; }
        }
        /// <summary>
        /// 治疗时间s
        /// </summary>
        public string time_stamp
        {
            set { _time_stamp = value; }
            get { return _time_stamp; }
        }
        /// <summary>
        /// 累计时间
        /// </summary>
        public string cumulative_time
        {
            set { _cumulative_time = value; }
            get { return _cumulative_time; }
        }
        /// <summary>
        /// 血泵速度
        /// </summary>
        public string blood_pump
        {
            set { _blood_pump = value; }
            get { return _blood_pump; }
        }
        /// <summary>
        /// 分离泵速度
        /// </summary>
        public string separation_pump
        {
            set { _separation_pump = value; }
            get { return _separation_pump; }
        }
        /// <summary>
        /// 透析液泵速度
        /// </summary>
        public string dialysis_pump
        {
            set { _dialysis_pump = value; }
            get { return _dialysis_pump; }
        }
        /// <summary>
        /// 补液泵速度
        /// </summary>
        public string tripe_pump
        {
            set { _tripe_pump = value; }
            get { return _tripe_pump; }
        }
        /// <summary>
        /// 滤过泵速度
        /// </summary>
        public string filtration_pump
        {
            set { _filtration_pump = value; }
            get { return _filtration_pump; }
        }
        /// <summary>
        /// 循环泵速度
        /// </summary>
        public string circulating_pump
        {
            set { _circulating_pump = value; }
            get { return _circulating_pump; }
        }
        /// <summary>
        /// 肝素泵速度
        /// </summary>
        public string heparin_pump
        {
            set { _heparin_pump = value; }
            get { return _heparin_pump; }
        }
        /// <summary>
        /// 加温器温度
        /// </summary>
        public string warmer
        {
            set { _warmer = value; }
            get { return _warmer; }
        }
        /// <summary>
        /// 血泵累计
        /// </summary>
        public string blood_pump_t
        {
            set { _blood_pump_t = value; }
            get { return _blood_pump_t; }
        }
        /// <summary>
        /// 分离泵累计
        /// </summary>
        public string separation_pump_t
        {
            set { _separation_pump_t = value; }
            get { return _separation_pump_t; }
        }
        /// <summary>
        /// 透析泵累计
        /// </summary>
        public string dialysis_pump_t
        {
            set { _dialysis_pump_t = value; }
            get { return _dialysis_pump_t; }
        }
        /// <summary>
        /// 补液泵累计
        /// </summary>
        public string tripe_pump_t
        {
            set { _tripe_pump_t = value; }
            get { return _tripe_pump_t; }
        }
        /// <summary>
        /// 滤过泵累计
        /// </summary>
        public string filtration_pump_t
        {
            set { _filtration_pump_t = value; }
            get { return _filtration_pump_t; }
        }
        /// <summary>
        /// 循环泵累计
        /// </summary>
        public string circulating_pump_t
        {
            set { _circulating_pump_t = value; }
            get { return _circulating_pump_t; }
        }
        /// <summary>
        /// 肝素泵累计
        /// </summary>
        public string heparin_pump_t
        {
            set { _heparin_pump_t = value; }
            get { return _heparin_pump_t; }
        }
        #endregion Model

    }
}

