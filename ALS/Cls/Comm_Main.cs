using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    class Comm_Main
    {
        private static uint crc= 0x0ffff;

        /// <summary>
        /// 控制报警灯
        /// </summary>
        public static class CmdAlarmLamp
        {
            //红色闪烁 	FE A1 00 5F ED
            //红色关闭	FE A2 00 5C ED
            //绿色闪烁 	FE A3 00 5D ED
            //绿色关闭	FE A4 00 5A ED
            //绿常常亮	FE A5 00 5B ED
            //黄色闪烁 	FE A6 00 58 ED
            //黄色关闭	FE A7 00 59 ED
            //所有灯关闭	FE A8 00 56 ED          
            //FE A1 04 XX(红灯) XX（绿灯） XX（黄灯） XX（音频） JY（校验） ED
            //0：灯关 1：灯闪 2：绿灯常亮;0：关报警音 1：嘀嘀嘀音 2：水滴音
            //0xFE,0xA1,0x04,0x01,0x00,0x00,0x01,0x5B,0xED //红灯闪嘀嘀报警音
            //0xFE,0xA1,0x04,0x00,0x01,0x00,0x00,0x5A,0xED//绿灯闪烁无音
            //0xFE,0xA1,0x04,0x00,0x02,0x00,0x00,0x59,0xED//绿灯常亮无音
            //0xFE,0xA1,0x04,0x00,0x00,0x01,0x02,0x58,0xED//黄灯闪烁水滴报警音
            //0xFE,0xA1,0x04,0x00,0x00,0x00,0x00,0x5B,0xED//所有灯关闭所有音关闭
            //public static byte[] RedTwinkle = new byte[] { 0xFE, 0xA1, 0x00, 0x5F, 0xED };

            //灯光操作指令发送时，声音部分改为03-无动作 2016年9月9日
            public static byte[] RedTwinkle =   new byte[] { 0xFE, 0xA1, 0x04, 0x01, 0x00, 0x00, 0x01, 0x59, 0xED };//红灯闪(包含警报音1)  
            public static byte[] GreenTwinkle = new byte[] { 0xFE, 0xA1, 0x04, 0x00, 0x01, 0x00, 0x03, 0x59, 0xED };//绿灯闪 
            public static byte[] GreenAlways =  new byte[] { 0xFE, 0xA1, 0x04, 0x00, 0x02, 0x00, 0x00, 0x5A, 0xED };//绿灯常亮 
            public static byte[] YellowTwinkle= new byte[] { 0xFE, 0xA1, 0x04, 0x00, 0x00, 0x01, 0x02, 0x59, 0xED };//黄灯闪(包含警报音2)
            public static byte[] AllLightClose= new byte[] { 0xFE, 0xA1, 0x04, 0x00, 0x00, 0x00, 0x00, 0x5B, 0xED };//所有音和灯关
            public static byte[] AllVoiseClose= new byte[] { 0xFE, 0xA1, 0x04, 0x03, 0x03, 0x03, 0x00, 0x58, 0xED };//静音 
            public static byte[] Alarm1 = new byte[] { 0xFE, 0xA1, 0x04, 0x03, 0x03, 0x03, 0x01, 0x59, 0xED };//报警音1
            public static byte[] Alarm2 = new byte[] { 0xFE, 0xA1, 0x04, 0x03, 0x03, 0x03, 0x02, 0x5A, 0xED };//报警音2
        }

        /// <summary>
        /// 控制蜂鸣器
        /// </summary>
        //public static class CmdAlarm
        //{           
            //滴滴报警开	FE A9 00 57 ED
            //滴滴报警关	FE AA 00 54 ED
            //水滴提示开	FE AB 00 55 ED
            //水滴提示关	FE AC 00 52 ED
            //所有音关闭	FE AD 00 53 ED

            //public static byte[] OpenVoice1 = new byte[] { 0xFE ,0xA9 ,0x00 ,0x57 ,0xED };
            //public static byte[] CloseVoice1 = new byte[] { 0xFE ,0xAA ,0x00 ,0x54 ,0xED };
            //public static byte[] OpenVoice2 = new byte[] { 0xFE ,0xAB ,0x00 ,0x55 ,0xED };
            //public static byte[] CloseVoice2 = new byte[] { 0xFE ,0xAC ,0x00 ,0x52 ,0xED};
            //public static byte[] AllVoiceClose = new byte[] {0xFE ,0xAD ,0x00 ,0x53 ,0xED};
        //}

        /// <summary>
        /// 控制夹管阀
        /// </summary>
        public static class CmdValve
        {
            //阀1通电松管	FE B1 00 4F ED
            //阀1断电夹管	FE B2 00 4C ED
            //阀2通电松管	FE B3 00 4D ED
            //阀2断电夹管	FE B4 00 4A ED
            //阀3通电松管	FE B5 00 4B ED
            //阀3断电夹管	FE B6 00 48 ED
            //阀4通电松管	FE B7 00 49 ED
            //阀4断电夹管	FE B8 00 46 ED
            //阀5通电松管	FE B9 00 47 ED
            //阀5断电夹管	FE BA 00 44 ED
            //阀6通电松管	FE BB 00 45 ED
            //阀6断电夹管	FE BC 00 42 ED
            //public static byte[] ClampAllV = new byte[] { 0xFE  ,0xBE  ,0x00  ,0x40  ,0xED};
            //public static byte[] LoosenAllV = new byte[] {0xFE ,0xBD ,0x00 ,0x43 ,0xED };

            //public static byte[]  LoosenV1= new byte[] { 0xFE ,0xB1 ,0x00 ,0x4F ,0xED };
            //public static byte[]  ClampV1 = new byte[] { 0xFE ,0xB2 ,0x00 ,0x4C ,0xED };

          
            //public static byte[] LoosenV2 = new byte[] {0xFE ,0xB3 ,0x00 ,0x4D ,0xED };
            //public static byte[] ClampV2 = new byte[] { 0xFE ,0xB4 ,0x00 ,0x4A ,0xED };

         
            //public static byte[] LoosenV3 = new byte[] {0xFE ,0xB5 ,0x00 ,0x4B ,0xED };
            //public static byte[] ClampV3 = new byte[] { 0xFE ,0xB6 ,0x00 ,0x48 ,0xED };

           
            //public static byte[] LoosenV4 = new byte[] { 0xFE ,0xB7 ,0x00 ,0x49 ,0xED };
            //public static byte[] ClampV4 = new byte[] {0xFE ,0xB8 ,0x00 ,0x46 ,0xED };

          
            //public static byte[] LoosenV5 = new byte[] {0xFE ,0xB9 ,0x00 ,0x47 ,0xED };
            //public static byte[] ClampV5 = new byte[] { 0xFE ,0xBA ,0x00 ,0x44 ,0xED};

          
            //public static byte[] LoosenV6 = new byte[] { 0xFE ,0xBB ,0x00 ,0x45 ,0xED };            
            //public static byte[] ClampV6 = new byte[] {0xFE ,0xBC ,0x00 ,0x42 ,0xED };

            public static byte[] SetVState(byte v1,byte v2,byte v3,byte v4,byte v5,byte v6)
            {
                byte[] vstate = new byte[11];
                //FE B1 06 01 00 00 00 00 00 48 ED
                vstate[0] = 0xFE;
                vstate[1] = 0xB1;
                vstate[2] = 0x06;
                vstate[3] = v1;
                vstate[4] = v2;
                vstate[5] = v3;
                vstate[6] = v4;
                vstate[7] = v5;
                vstate[8] = v6;
                byte jy=vstate[0];
                for(int i = 0;i<9;i++)
                {
                    jy ^=vstate[i];
                }
                vstate[9] = jy;
                vstate[10] = 0xED;
                return vstate;
            }
        }


        /// <summary>
        /// 控制气泵
        /// </summary>
        public static class LiquidLevel
        {
            //气泵1通电	FE E1 00 1F ED
            //气泵1断电	FE E2 00 1C ED
            //气泵2通电	FE E3 00 1D ED
            //气泵2断电	FE E4 00 1A ED
            //气泵3通电	FE E5 00 1B ED
            //气泵3断电	FE E6 00 18 ED

            //气阀1通电	FE E7 00 19 ED
            //气阀1断电	FE E8 00 16 ED
            //气阀2通电	FE E9 00 17 ED
            //气阀2断电	FE EA 00 14 ED
            //气阀3通电	FE EB 00 15 ED
            //气阀3断电	FE EC 00 12 ED
            public static byte[] openLiquidCheck = new byte[] { 0xFE, 0xF7, 0x00, 0x09, 0xED };
            public static byte[] closeLiquidCheck = new byte[] { 0xFE, 0xF8, 0x00, 0x06, 0xED };

            public static byte[] liquidLevel1Down = new byte[] { 0xFE ,0xE1 ,0x00 ,0x1F ,0xED };
            public static byte[] liquidLevel1StopDown = new byte[] {0xFE ,0xE2 ,0x00 ,0x1C ,0xED };
            public static byte[] liquidLevel1Up = new byte[] { 0xFE ,0xE7 ,0x00 ,0x19 ,0xED };
            public static byte[] liquidLevel1StopUp = new byte[] {0xFE ,0xE8 ,0x00 ,0x16 ,0xED};
          
            public static byte[] liquidLevel2Down = new byte[] {0xFE ,0xE3 ,0x00 ,0x1D ,0xED};
            public static byte[] liquidLevel2StopDown = new byte[] { 0xFE ,0xE4 ,0x00 ,0x1A ,0xED };
            public static byte[] liquidLevel2Up = new byte[] {0xFE ,0xE9 ,0x00 ,0x17 ,0xED};
            public static byte[] liquidLevel2StopUp = new byte[] {	0xFE ,0xEA ,0x00 ,0x14 ,0xED};

        
            public static byte[] liquidLevel3Down = new byte[] { 0xFE ,0xE5 ,0x00 ,0x1B ,0xED };
            public static byte[] liquidLevel3StopDown = new byte[] {0xFE ,0xE6 ,0x00 ,0x18 ,0xED };
            public static byte[] liquidLevel3Up = new byte[] {0xFE ,0xEB ,0x00 ,0x15 ,0xED};
            public static byte[] liquidLevel3StopUp = new byte[] {0xFE ,0xEC ,0x00 ,0x12 ,0xED};
        }

        //数据传输开启	FE AE 00 50 ED
        //数据传输结束	FE AF 00 51 ED
        public static byte[] startTransData = new byte[] { 0xFE ,0xAE ,0x00 ,0x50 ,0xED };
        public static byte[] stopTransData = new byte[] {0xFE ,0xAF ,0x00 ,0x51 ,0xED};

        /// <summary>
        /// 气泡报警
        /// </summary>
        public static class CmdBubble
        {
            //气泡检测1开启	FE F1 00 0F ED
            //气泡检测1关闭	FE F2 00 0C ED
            //气泡检测2开启	FE F3 00 0D ED
            //气泡检测2关闭	FE F4 00 0A ED
            //气泡检测3开启	FE F5 00 0B ED
            //气泡检测3关闭	FE F6 00 08 ED

            public static byte[] OpenBubble1 = new byte[] { 0xFE ,0xF1 ,0x00 ,0x0F ,0xED };
            public static byte[] OpenBubble2 = new byte[] { 0xFE ,0xF3 ,0x00 ,0x0D ,0xED };
            public static byte[] OpenBubble3 = new byte[] { 0xFE ,0xF5 ,0x00 ,0x0B ,0xED };

            public static byte[] CloseBubble1 = new byte[] { 0xFE ,0xF2 ,0x00 ,0x0C ,0xED };
            public static byte[] CloseBubble2 = new byte[] { 0xFE ,0xF4 ,0x00 ,0x0A ,0xED };
            public static byte[] CloseBubble3 = new byte[] { 0xFE, 0xF6, 0x00, 0x08, 0xED };
        }

        /// <summary>
        /// 温控系统命令
        /// </summary>
        public static class CmdTemperature
        {
            //启动加热系统	F7 A1 11 25 62 ED
            //停止加热系统	F7 A1 00 00 56 ED

            public static byte[] StartHT(uint target)
            {
                List<byte> temp = new List<byte>();
                temp.Add(0xFE);
                temp.Add(0xEE);
                temp.Add(0x01); 
                temp.Add((byte)target);
                byte check=temp[0];              
                for (int i = 1; i < 4; i++)
                {
                    check ^= temp[i];
                }
                temp.Add(check);
                temp.Add(0xED);
                return temp.ToArray();
            }

            public static byte[] StopHT = new byte[] { 0xFE, 0xEF, 0x00, 0x11, 0xED };
            //{
            //    List<byte> temp = new List<byte>();
            //    temp.Add(0xF7);
            //    temp.Add(ID);
            //    if (run)
            //        temp.Add(0x11);
            //    else
            //        temp.Add(0x00);
            //    temp.Add(target);
            //    byte check = temp[0];
            //    for (int i = 1; i < 4; i++)
            //    {
            //        check ^= temp[i];
            //    }
            //    temp.Add(check);
            //    temp.Add(0xED);
            //    return temp.ToArray();
            //} 
        }


        /// <summary>
        /// Crc校验
        /// </summary>
        /// <param name="crcbuf"></param>
        private static void CalcCrc(byte crcbuf)
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

        /// <summary>
        /// 串口数据处理线程,本项目暂时不用，有需要拿来用
        /// </summary>
        /// <param name="data"></param>
        //void portMainReader_Handlers(List<byte> data)
        //{
        //    if (M_Closing_main) return;
        //    try
        //    {
        //        M_Listening_main = true;
        //        byte[] _data = new byte[data.Count];
        //        data.CopyTo(_data, 0);
        //        int len = data[2];
        //        #region 温度值 FD 1D 02 28 00 CA ED
        //        if (data[0] == 0xFD && data[1] == 0x1D)
        //        {
        //            if (checkOut(data))
        //            {
        //                //如果通过校验，则处理该组数据                            
        //                this.Invoke((EventHandler)(delegate
        //                {
        //                    double d = data[3] + data[4] / 100.0;
        //                    this.lblTemperature.Text = d.ToString("f1");
        //                }));
        //            }
        //        }
        //        #endregion

        //        #region 压力值 F1 1D 02 00 0A E4 ED
        //        if (data[0] == 0xF1)
        //        {
        //            //校验
        //            if (checkOut(data))
        //            {
        //                switch (data[1])
        //                {
        //                    case 0x1D:
        //                        this.Invoke((EventHandler)(delegate
        //                        {
        //                            int val = ((data[3] & 0xFFFF) << 8) + data[4];
        //                            lblPressure_1.Text = val.ToString("f1");
        //                        }));
        //                        break;
        //                    case 0x2D:
        //                        this.Invoke((EventHandler)(delegate
        //                        {
        //                            int val = ((data[3] & 0xFFFF) << 8) + data[4];
        //                            lblPressure_2.Text = val.ToString("f1");
        //                        }));
        //                        break;
        //                    case 0x3D:
        //                        this.Invoke((EventHandler)(delegate
        //                        {
        //                            int val = ((data[3] & 0xFFFF) << 8) + data[4];
        //                            lblPressure_3.Text = val.ToString("f1");
        //                        }));
        //                        break;
        //                    case 0x4D:
        //                        this.Invoke((EventHandler)(delegate
        //                        {
        //                            int val = ((data[3] & 0xFFFF) << 8) + data[4];
        //                            lblPressure_4.Text = val.ToString("f1");
        //                        }));
        //                        break;
        //                    case 0x5D:
        //                        this.Invoke((EventHandler)(delegate
        //                        {
        //                            int val = ((data[3] & 0xFFFF) << 8) + data[4];
        //                            lblPressure_5.Text = val.ToString("f1");
        //                        }));
        //                        break;
        //                    case 0x6D:
        //                        this.Invoke((EventHandler)(delegate
        //                        {
        //                            int val = ((data[3] & 0xFFFF) << 8) + data[4];
        //                            lblPressure_6.Text = val.ToString("f1");
        //                        })); break;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region 报警灯状态 F2 1D 00 EF ED
        //        if (data[0] == 0xF2)
        //        {
        //            if (checkOut(data))
        //            {
        //                //this.Invoke((EventHandler)(delegate
        //                //{
        //                switch (data[1])
        //                {
        //                    case 0x1D://红色闪烁  
        //                    case 0x1E://红色关闭 
        //                    case 0x2D://黄色闪烁 
        //                    case 0x2E://黄色关闭 
        //                    case 0x3D://绿色闪烁 
        //                    case 0x3E://绿色关闭
        //                        M_SendSuccess = true;
        //                        break;
        //                }
        //                //}));
        //            }
        //        }
        //        #endregion

        //        #region 漏血值 F3 1D 02 00 64 88 ED
        //        if (data[0] == 0xF3 && data[1] == 0x1D)
        //        {
        //            if (checkOut(data))
        //            {
        //                this.Invoke((EventHandler)(delegate
        //                {
        //                    int val = ((data[3] & 0xFFFF) << 8) + data[4];
        //                    this.lblBloodLeak.Text = val.ToString("f1");
        //                }));
        //            }
        //        }
        //        #endregion

        //        #region 夹管阀状态 F4 1D 00 E9 ED
        //        if (data[0] == 0xF4)
        //        {
        //            if (checkOut(data))
        //            {
        //                //this.Invoke((EventHandler)(delegate
        //                //{
        //                switch (data[1])
        //                {
        //                    case 0x1D://夹管阀1开 
        //                    case 0x1E://夹管阀1关 
        //                    case 0x2D://夹管阀2开 
        //                    case 0x2E://夹管阀2关 
        //                    case 0x3D://夹管阀3开 
        //                    case 0x3E://夹管阀3关 
        //                    case 0x4D://夹管阀4开 
        //                    case 0x4E://夹管阀4关 
        //                    case 0x5D://夹管阀5开 
        //                    case 0x5E://夹管阀5关 
        //                    case 0x6D://夹管阀6开 
        //                    case 0x6E://夹管阀6关 
        //                    case 0x7D://夹管阀7开 
        //                    case 0x7E://夹管阀7关
        //                        M_SendSuccess = true;
        //                        break;
        //                }
        //                //}));
        //            }
        //        }
        //        #endregion

        //        #region 气泵状态 F5 3A 00 CF ED
        //        if (data[0] == 0xF5)
        //        {
        //            if (checkOut(data))
        //            {
        //                //this.Invoke((EventHandler)(delegate
        //                //{
        //                switch (data[1])
        //                {
        //                    case 0x3A://气泵3-3开 
        //                    case 0x3B://气泵3-3关 
        //                    case 0x2A://气泵3-2开 
        //                    case 0x2B://气泵3-2关 
        //                    case 0x1A://气泵3-1开 
        //                    case 0x1B://气泵3-1关  
        //                    case 0x3C://气泵2-3开 
        //                    case 0x3D://气泵2-3关 
        //                    case 0x2C://气泵2-2开 
        //                    case 0x2D://气泵2-2关 
        //                    case 0x1C://气泵2-1开 
        //                    case 0x1D://气泵2-1关 
        //                    case 0x3E://气泵1-3开 
        //                    case 0x3F://气泵1-3关 
        //                    case 0x2E://气泵1-2开 
        //                    case 0x2F://气泵1-2关 
        //                    case 0x1E://气泵1-1开 
        //                    case 0x1F://气泵1-1关
        //                        M_SendSuccess = true;
        //                        break;
        //                }
        //                //}));
        //            }
        //        }

        //        #endregion

        //        #region 蜂鸣器状态 F6 1D 00 EB ED
        //        if (data[0] == 0xF6)
        //        {
        //            if (checkOut(data))
        //            {
        //                switch (data[1])
        //                {
        //                    case 0x1D://蜂鸣器开启
        //                        M_SendSuccess = true;
        //                        break;
        //                    case 0x2D://蜂鸣器关闭
        //                        M_SendSuccess = true;
        //                        break;
        //                }
        //            }
        //        }
        //        #endregion

        //        #region 温控电源状态 开 F7 1D 00 EA ED  关 F7 1E 00 E9 ED
        //        if (data[0] == 0xF7)
        //        {
        //            if (checkOut(data))
        //            {
        //                this.Invoke((EventHandler)(delegate
        //                {
        //                    //更改显示标志 开
        //                    if (data[1] == 0x1D)
        //                        this.picHt.Image = Properties.Resources.hoton;
        //                    //更改显示标志 关
        //                    else if (data[1] == 0x1E)
        //                        this.picHt.Image = Properties.Resources.hotoff;
        //                }));
        //            }
        //        }
        //        #endregion

        //        #region 气泡检测报警 F8 1D 00 E5 ED
        //        if (data[0] == 0xF8 && data[1] == 0x1D)
        //        {
        //            if (checkOut(data))
        //            {
        //                this.Invoke((EventHandler)(delegate
        //                {
        //                    this.groupSet.Visible = false;
        //                    this.groupAlert.Visible = true;
        //                    this.palTop.Controls.Add(groupAlert);
        //                    this.groupAlert.BringToFront();
        //                    this.groupAlert.Dock = DockStyle.Fill;
        //                    M_uc_Alarm = new FormsWarn.ucAlarm();
        //                    this.palContent.Controls.Add(M_uc_Alarm);
        //                    M_uc_Alarm.BringToFront();
        //                    M_uc_Alarm.Dock = DockStyle.Fill;

        //                }));
        //            }
        //        }
        //        #endregion

        //        #region 接收命令Log
        //        this.Invoke((EventHandler)(delegate
        //        {
        //            //依次的拼接出16进制字符串  
        //            M_strb_main.Append(port_main.PortName + "(" + buffcount + "):");
        //            foreach (byte b in data)
        //            {
        //                M_strb_main.Append(b.ToString("X2") + " ");
        //            }
        //            M_strb_main.Append("[" + DateTime.Now.ToString() + "]\r\n");
        //            //追加的形式添加到文本框末端，并滚动到最后。  
        //            this.txtRecieve.AppendText(M_strb_main.ToString());
        //            M_strb_main.Clear();
        //            data.Clear();
        //        }));
        //        #endregion
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        M_Listening_main = false;
        //    }
        //}
    } 
}
