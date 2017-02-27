using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    //波特率9600, 无校验,数据位8，停止位1.
    //调显示      F0 01 A0 FF
    //设置零点    F0 01 C0 00 00 00 FF
    //标定小数点  F0 01 B8 B3 FF 
    //标定5KG     F0 01 C1 00 05 00 FF
    //标定10KG    F0 01 C1 00 10 00 FF

    class Comm_Weigh
    {
        //读取值
        public static byte[] ReadValue(byte  ID)  // = new byte[] { 0xF0,0x01,0xA0,0xFF };
        {
            byte[] buff = new byte[4];
            buff[0] = 0xF0;
            buff[1] = ID;
            buff[2] = 0xA0;
            buff[3] = 0xFF;
            return buff;
        }

        //设置零点
        public static byte[] SetZero(byte ID) // = new byte[] { 0xF0 ,0x01 ,0xC0 ,0x00 ,0x00 ,0x00 ,0xFF };
        {
            byte[] buff = new byte[7];
            buff[0] = 0xF0;
            buff[1] = ID;
            buff[2] = 0xC0;
            buff[3] = 0x00;
            buff[4] = 0x00;
            buff[5] = 0x00;
            buff[6] = 0xFF;
            return buff;
        }

        /// <summary>
        /// 设定地址  f0+C4+3B+AA+55+改写的地址+FF
        /// </summary>
        /// <returns></returns>
        public static byte[] SetID(byte ID)
        {
            byte[] buff = new byte[7];
            buff[0] = 0xF0;
            buff[1] = 0xC4;
            buff[2] = 0x3B;
            buff[3] = 0xAA;
            buff[4] = 0x55;
            buff[5] = ID;
            buff[6] = 0xFF;
            return buff;
        }

        //标定小数点
        public static byte[] CalibrateDot(byte ID) // = new byte[] {0xF0 ,0x01 ,0xB8 ,0xB3 ,0xFF };
        {
            byte[] buff = new byte[5];
            buff[0] = 0xF0;
            buff[1] = ID;
            buff[2] = 0xB8;
            buff[3] = 0xB3;
            buff[4] = 0xFF; 
            return buff;
        }
        //标定1KG
        public static byte[] Calibrate1kg(byte ID) // = new byte[] {0xF0 ,0x01 ,0xC1 ,0x00 ,0x05 ,0x00, 0xFF };
        {
            byte[] buff = new byte[7];
            buff[0] = 0xF0;
            buff[1] = ID;
            buff[2] = 0xC1;
            buff[3] = 0x00;
            buff[4] = 0x10;
            buff[5] = 0x00;
            buff[6] = 0xFF;
            return buff;
        }
        //标定5KG
        public static byte[] Calibrate5kg(byte ID) // = new byte[] {0xF0 ,0x01 ,0xC1 ,0x00 ,0x05 ,0x00, 0xFF };
        {
            byte[] buff = new byte[7];
            buff[0] = 0xF0;
            buff[1] = ID;
            buff[2] = 0xC1;
            buff[3] = 0x00;
            buff[4] = 0x50;
            buff[5] = 0x00;
            buff[6] = 0xFF;
            return buff;
        }
        //标定10KG
        public static byte[] Calibrate10kg(byte ID) // = new byte[] { 0xF0, 0x01, 0xC1, 0x00, 0x10, 0x00, 0xFF };
        {
            byte[] buff = new byte[7];
            buff[0] = 0xF0;
            buff[1] = ID;
            buff[2] = 0xC1;
            buff[3] = 0x01;
            buff[4] = 0x00;
            buff[5] = 0x00;
            buff[6] = 0xFF;
            return buff;
        }
    
    }
}
