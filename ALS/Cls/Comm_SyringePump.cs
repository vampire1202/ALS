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
            _presetValue = _presetValue * 10;
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
            double fastSpeed = _fastSpeed * 10.0;
            byte[] m_buf = new byte[9];
            m_buf[0] = 0xFE;
            byte CheckSum = m_buf[0];
            m_buf[1] = 0xC4;
            m_buf[2] = 0x02;
            m_buf[3] = (byte)(((ushort)fastSpeed >> 8) & 0xFF);
            m_buf[4] = (byte)((ushort)fastSpeed & 0xFF);
            for (int k = 1; k < 5; k++)
            {
                CheckSum ^= m_buf[k];
            }
            m_buf[5] = CheckSum;
            m_buf[6] = 0xED;
            return m_buf;
        }

        //注射器识别
        //联络帧发送(未有断电预告)   FE C7 01 00 38 ED
        public static byte[] Recog_SyVersion=new byte[6]{0xFE,0xC7,0x01,0x00,0x38,0xED };
        //联络帧发送(有断电预告)   FE C7 01 01 39 ED
        public static byte[] Sy_Outage = new byte[6] { 0xFE, 0xC7, 0x01, 0x01, 0x39, 0xED };

        //结束快进 FE C5 00 3B ED
        public static byte[] EndFastForward = new byte[] {0xFE,0xC5,0x00,0x3B,0xED };
       
        //清除累积量 FE C6 00 38 ED
        public static byte[] ClearCumulant = new byte[] { 0xFE,0xC6,0x00,0x38,0xED };

        //获取设备状态
        public static byte[] GetStatus = new byte[] { 0xFE, 0xC7, 0x01, 0x00, 0x38, 0xED };

        #region   微量注射泵校准

        //电位器校准(进入传感器界面)
        //FE CC 00 32 ED
        public static byte[] PotentialCal_start = new byte[5] { 0xFE, 0xCC, 0x00, 0x32, 0xED };

        //电位器校准停止(退出传感器界面)
        //FE CD 00 33 ED
        public static byte[] PotentialCal_stop = new byte[5] { 0xFE, 0xCD, 0x00, 0x33, 0xED };

        //15V关闭FE D2 00 2C ED
        public static byte[] Syringe_FifClose = new byte[] { 0xFE, 0xD2, 0x00, 0x2C, 0xED };
        //15V开启FE D1 00 2F ED
        public static byte[] Syringe_FifOpen = new byte[] { 0xFE, 0xD1, 0x00, 0x2F, 0xED };

        //传感器零点校准
        //FE CE 22 XXXX(S_13短电位，直径13毫米) XXXX(S_23) XXXX(S_33) XXXX(L_0长电位) XXXX(L_50) XXXX(L_100) XXXX(P_0没有打压时0点压力值) XXXX(P_50(5)) XXXX(P_100(5))
        //XXXX(P_50(10)10mL注射器加50Kpa压力) XXXX(P_100(10)XXXX(P_50(20)) XXXX(P_100(20)XXXX(P_50(30)) XXXX(P_100(30)XXXX(P_50(50)) XXXX(P_100(50)) 33 ED  
        public static byte[] ZeroCal(byte[] Cal_data)
        {
            byte[] m_buf = new byte[39];
            m_buf[0] = 0xFE;
            m_buf[1] = 0xCE;
            m_buf[2] = 0x22;
            for (int i = 3; i < 37; i++)
            {
                m_buf[i] = Cal_data[i - 3];
            }
            byte CheckSum = m_buf[0];
            for (int k = 1; k < 37; k++)
            {
                CheckSum ^= m_buf[k];
            }
            m_buf[37] = CheckSum;
            m_buf[38] = 0xED;
            return m_buf;
        }
        //注射器参数获取 管径 完成距离
        //FE D0 01 04 2B ED   30mL
        public static byte[] AutoCal_get=new byte[6]{0xFE,0xD0,0x01,0x04,0x2B,0xED };

        //注射器校准参数获取命令停止FE D1 00 2F ED
        public static byte[] AutoCal_Stop = new byte[] { 0xFE, 0xD1, 0x00, 0x2F, 0xED };

        //抗凝剂泵发送校准参数后，发送保存命令
        public static byte[] ZeroCal_Save = new byte[] { 0xFE,0xC7,0x00,0x39,0xED};
        //注射器校准
        //FE D2 07 XX(规格)XXXX（管径）XXXX(注射器长度)XXXX(完成距离) XX(校验位) ED
        public static byte[] AutoCal_set(byte[] Syr_data)
        {
            byte[] m_buf = new byte[12];
            m_buf[0] = 0xFE;
            m_buf[1] = 0xD2;
            m_buf[2] = 0x07;
            for (int i = 3; i < 10; i++)
            {
                m_buf[i] = Syr_data[i - 3];
            }
            byte CheckSum = m_buf[0];
            for (int k = 1; k < 10; k++)
            {
                CheckSum ^= m_buf[k];
            }
            m_buf[10] = CheckSum;
            m_buf[11] = 0xED;
            return m_buf;
        }

        #endregion



        //注射器品牌设置 FE C8 03 00 00 00 35 ED 洁瑞
        public static byte[] SetBrand_jierui = new byte[]{ 0xFE,0xC8,0x03,0x00,0x00,0x00,0x35,0xED };
        //注射器品牌设置 FE C8 03 01 00 00 34 ED 自定义
        public static byte[] SetBrand_Autoset = new byte[] { 0xFE, 0xC8, 0x03, 0x01, 0x00, 0x00, 0x34, 0xED };
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

        