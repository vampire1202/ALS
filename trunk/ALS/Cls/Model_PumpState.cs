using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    public class Model_PumpState
    {

        /// <summary>
        /// 泵ID
        /// </summary>
        private int pumpID=0;
        public int PumpID
        {
            get { return pumpID; }
            set { pumpID = value; }
        }

        /// <summary>
        /// 速度
        /// </summary>
        private double speed=0;
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        /// <summary>
        /// 方向
        /// </summary>
        private bool direction=true;
        public bool Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        /// <summary>
        /// 是否运转
        /// </summary>
        private bool runing=false;
        public bool Runing
        {
            get { return runing; }
            set { runing = value; }
        } 
    }
}
