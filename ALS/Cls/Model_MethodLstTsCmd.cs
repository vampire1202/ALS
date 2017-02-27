using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    class Model_MethodLstTsCmd
    {
        private  List<Cls.Model_TimeAndCmd> _mlstTsCmd;
        public List<Cls.Model_TimeAndCmd> _MlstTsCmd
        {
            get { return _mlstTsCmd; }
            set { _mlstTsCmd = value; }
        }
    }
}
