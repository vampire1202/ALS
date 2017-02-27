using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;

namespace ALS.Cls
{
    class Comm_SyringePump
    {
        //开机发送检测机型编号 FE C1 06 00 01 00 00 00 00 38 ED
        public static byte[] TestSN(int ID)
        {
            byte[] buf = new byte[11];
            buf[0] = 0xFE;
            buf[1] = 0xC1;
            buf[2] = 0x06;
            buf[3] = (byte)((ID & 0xFFFF) >> 8);
            buf[4] = (byte)((ID & 0xFF));
            buf[5] = 0x00;
            buf[6] = 0x00;
            buf[7] = 0x00;
            buf[8] = 0x00;
            byte CheckSum = buf[0];
            for (int k = 1; k < 9; k++)
            {
                CheckSum ^= buf[k];
            }
            buf[9] = CheckSum;
            buf[10] = 0xED;
            return buf;
        } 

        // 开始运行，设置速度和预置量
        public static byte[] Start(double _speed, double _presetValue)
        {         
            byte[] m_buf = new byte[9];
            m_buf[0] = 0xFE;
            byte CheckSum = m_buf[0];
            m_buf[1] = 0xC2;
            m_buf[2] = 0x04;
            _speed = _speed * 10.0;
            m_buf[3] = (byte)(((int)_speed >> 8) & 0xFF);
            m_buf[4] = (byte)((int)_speed & 0xFF);
            m_buf[5] = (byte)(((int)_presetValue >> 8) & 0xFF);
            m_buf[6] = (byte)((int)_presetValue & 0xFF);
            for (int k = 1; k < 7; k++)
            {
                CheckSum ^= m_buf[k];
            }
            m_buf[7] = CheckSum;
            m_buf[8] = 0xED;
            return m_buf;
        }
        //停止
        public static byte[] Stop=new byte[]{0xFE,0xC3,0x00,0x3D,0xED };       

        //快进运行  
        public static byte[] FastForward(double _fastSpeed)
        {
            byte[] m_buf = new byte[9];
            m_buf[0] = 0xFE;
            byte CheckSum = m_buf[0];
            m_buf[1] = 0xC4;
            m_buf[2] = 0x02;
            m_buf[3] = (byte)(((ushort)_fastSpeed >> 8) & 0xFF);
            m_buf[4] = (byte)((ushort)_fastSpeed & 0xFF);
            for (int k = 1; k < 5; k++)
            {
                CheckSum ^= m_buf[k];
            }
            m_buf[5] = CheckSum;
            m_buf[6] = 0xED;
            return m_buf;
        }

        //结束快进 FE C5 00 3B ED
        public static byte[] EndFastForward = new byte[] {0xFE,0xC5,0x00,0x3B,0xED };
       
        //清除累积量 FE C6 00 38 ED
        public static byte[] ClearCumulant = new byte[] { 0xFE,0xC6,0x00,0x38,0xED };

        //获取设备状态
        public static byte[] GetStatus = new byte[] { 0xFE, 0xC7, 0x01, 0x00, 0x38, 0xED };

        //注射器品牌设置 FE C8 03 02 00 00 37 ED 双鸽
        //public static byte[] SetBrand_Shuangge = new byte[]{ 0xFE,0xC8,0x03,0x02,0x00,0x00,0x37,0xED };
        //{
        //    byte[] m_buf = new byte[9];
        //    m_buf[0] = 0xFE;
        //    byte CheckSum = m_buf[0];
        //    m_buf[1] = 0xC8;
        //    m_buf[2] = 0x03;
        //    for (int k = 1; k < 3; k++)
        //    {
        //        CheckSum ^= m_buf[k];
        //    }
        //    m_buf[3] = CheckSum;
        //    m_buf[4] = 0xED;
        //    return m_buf; 
        //}

        //启动排气
        //public static byte[] StartExhaust(double ExhaustSpeed)
        //{
        //    byte[] m_buf = new byte[9];
        //    m_buf[0] = 0xFE;
        //    byte CheckSum = m_buf[0];
        //    m_buf[1] = 0xC9;
        //    m_buf[2] = 0x02;
        //    m_buf[3] = (byte)(((ushort)(ExhaustSpeed * 10) >> 8) & 0xFF);
        //    m_buf[4] = (byte)((ushort)(ExhaustSpeed * 10) & 0xFF);
        //    for (int k = 1; k < 5; k++)
        //    {
        //        CheckSum ^= m_buf[k];
        //    }
        //    m_buf[5] = CheckSum;
        //    m_buf[6] = 0xED;
        //    return m_buf;
        //}

        ////结束排气FE CA 00 34 ED
        //public static byte[] StopExhaust = new byte[] {0xFE,0xCA,0x34,0xED };
        //{
        //    byte[] m_buf = new byte[9];
        //    m_buf[0] = 0xFE;
        //    byte CheckSum = m_buf[0];
        //    m_buf[1] = 0xCA;
        //    m_buf[2] = 0x00;
        //    for (int k = 1; k < 3; k++)
        //    {
        //        CheckSum ^= m_buf[k];
        //    }
        //    m_buf[3] = CheckSum;
        //    m_buf[4] = 0xED;
        //    return m_buf;
        //} 
    }
}

        