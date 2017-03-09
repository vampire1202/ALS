using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALS.Cls
{

    public class clsSysWarn
    {
        /// <summary>
        /// 是否静音
        /// </summary>
        private bool _isMute;
        public bool _IsMute
        {
            get { return _isMute; }
            set { _isMute = value; }
        }
        /// <summary>
        /// 是否解除
        /// </summary>
        private bool _isRelease;
        public bool _IsRelease
        {
            get { return _isRelease; }
            set { _isRelease = value; }
        }

        /// <summary>
        /// 警报内容
        /// </summary>
        private Cls.Model_ShowWarn _modelShowWarn;
        public Cls.Model_ShowWarn _ModelShowWarn
        {
            get { return _modelShowWarn; }
            set { _modelShowWarn = value; }
        }



    }
}
