using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    class Comm_Temperature
    {
        private static uint crc = 0x0ffff;
        /// <summary>
        /// 读取实测温度
        /// </summary>
        public static byte[] Read_Value(byte ID)
        {
            byte[] buf = new byte[8]; //{0x0A,0x03,0x10,0x01,0x00,0x01,0xD0,0x71 };\
            buf[0] = ID;
            buf[1] = 0x03;
            buf[2] = 0x10;
            buf[3] = 0x01;
            buf[4] = 0x00;
            buf[5] = 0x01;
            crc = 0xffff;
            CalcCrc(buf[0]);
            CalcCrc(buf[1]);
            CalcCrc(buf[2]);
            CalcCrc(buf[3]);
            CalcCrc(buf[4]);
            CalcCrc(buf[5]);
            //crc低位在前，高位在后
            buf[6] = Convert.ToByte(crc & 0xff);
            buf[7] = Convert.ToByte(crc >> 8);
            return buf;
        }
        /// <summary>
        /// 读取实测温度
        /// </summary>
        public static byte[] Read_SetValue(byte ID)
        {
            byte[] buf = new byte[8]; //{0x0A,0x03,0x10,0x01,0x00,0x01,0xD0,0x71 };\
            buf[0] = ID;
            buf[1] = 0x03;
            buf[2] = 0x00;
            buf[3] = 0x00;
            buf[4] = 0x00;
            buf[5] = 0x01;
            crc = 0xffff;
            CalcCrc(buf[0]);
            CalcCrc(buf[1]);
            CalcCrc(buf[2]);
            CalcCrc(buf[3]);
            CalcCrc(buf[4]);
            CalcCrc(buf[5]);
            //crc低位在前，高位在后
            buf[6] = Convert.ToByte(crc & 0xff);
            buf[7] = Convert.ToByte(crc >> 8);
            return buf;
        }

        /// <summary>
        /// 设置温度命令
        /// </summary>
        /// <param name="ID">仪表编号</param>
        /// <param name="chl">参数首地址</param>
        /// <param name="value">设置值</param>
        /// <returns></returns>
        public static byte[] Write_Value(byte ID, double value)
        {
            value = value * 10.0;
            byte[] cmd = new byte[8];
            cmd[0] = ID;
            cmd[1] = 0x06;
            cmd[2] = 0x00;
            cmd[3] = 0x00;
            cmd[4] = (byte)((int)value >> 8);
            cmd[5] = (byte)((int)value & 0xFF);
            crc = 0xffff;
            CalcCrc(cmd[0]);
            CalcCrc(cmd[1]);
            CalcCrc(cmd[2]);
            CalcCrc(cmd[3]);
            CalcCrc(cmd[4]);
            CalcCrc(cmd[5]);
            //crc低位在前，高位在后
            cmd[6] = Convert.ToByte(crc & 0xff);
            cmd[7] = Convert.ToByte(crc >> 8);
            return cmd;
        }

        /// <summary>
        /// Crc校验
        /// </summary>
        /// <param name="crcbuf"></param>
        public static void CalcCrc(byte crcbuf)
        {
            byte i;
            crc = crc ^ crcbuf;
            for (i = 0; i < 8; i++)
            {
                uint TT;
                TT = crc & 1;
                crc = crc >> 1;
                crc = crc & 0x7fff;
                if (TT == 1)
                {
                    crc = crc ^ 0xa001;
                }
                crc = crc & 0xffff;
            }
        }
    }
}
