using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    public class Model_CustomCMD
    {
        /// <summary>
        /// 命令及端口集合
        /// </summary>
        private List<Model_SendCMD> _lstsendCMDs;
        public List<Model_SendCMD> _LstSendCMDs
        {
            get { return _lstsendCMDs; }
            set { _lstsendCMDs = value; }
        }
        /// <summary>
        /// 时间点
        /// </summary>
        private int _timesCount;
        public int _TimesCount
        {
            get { return _timesCount; }
            set { _timesCount = value; }
        }

        private int _lastTime;
        public int _LastTime
        {
            get { return _lastTime; }
            set { _lastTime = value; }
        }

        private string _actionName;
        public string _ActionName
        {
            get { return _actionName; }
            set { _actionName = value; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        private int _index;
        public int _Index
        {
            get { return _index; }
            set { _index = value; }
        }

        //public Model_CustomCMD(List<Model_SendCMD> lstSendCmd, int timeCount,int lastTime,string actionName,int index)
        //{
        //    _lstsendCMDs = lstSendCmd;
        //    _timesCount = timeCount;
        //    _lastTime = lastTime;
        //    _actionName = actionName;
        //    _index = index;
        //}
    }
}
