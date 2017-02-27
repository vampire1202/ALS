using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALS.Cls
{
    class Comm_PeristalticPump
    {
        //帧格式：flag+ addr + len + pdu + fcs。  
        //addr：一个字节，表示地址，1~30，为设备地址，31为广播址--所有设备都执行的地址。
        //len：是一个字节，表示pdu的长度。
        //fcs：是addr、 len 、pdu的异或。
        //命令解析：
        //E9     E9H作帧头，发送时，帧头以后的所有内容中，若出现E8H，则以E8H、00H代替。 若出现E9H，则以E8H、01H代替。接收时将E8H、00H恢复为E8H，将E8H、01H恢复为E9H。
        //01     (ID) 
        //06     (长度) 
        //57 
        //4A     (设置运行参数WJ) 
        //01     (转速高字节)
        //F4     (转速低字节)   
        //01     (正常运行) ---- 00(正常停止) 10(全速停止) 11（全速运行）
        //01     (顺时针)   ---- 00(逆时针)
        //EF     (校验) 

        public static byte[] Command(byte _id,double _speedml, bool _run, bool _direction)
        { 
            List<byte> temp = new List<byte>();
            byte count = 0;

            temp.Add(0xE9);
            temp.Add(_id);
            //设置参数
            temp.Add(0x57);
            temp.Add(0x4A);
            double rspeed=0;
            if (_speedml > 0)
                rspeed = Math.Round((0.2314 * _speedml - 0.0289) * 10, 0);
            else
                rspeed = 0; 

            //蠕动泵函数 y = 0.2286x + 0.1825(x为流量) 测试
            //官方函数 y = 0.2314x - 0.0289
            byte speedHighByte = (byte)(((ushort)rspeed >> 8) & 0xFF);  // high eight bits
            temp.Add(speedHighByte);
            byte speedLowByte = (byte)((ushort)rspeed & 0xFF);          // low eight bits
            if (speedLowByte == 0xE9)
            {
                temp.Add(0xE8);
                temp.Add(0x01);
                count = 0x07;
            }
            else if (speedLowByte == 0xE8)
            {
                temp.Add(0xE8);
                temp.Add(0x00);
                count = 0x07;
            }
            else
            {
                temp.Add(speedLowByte);
                count = 0x06;
            }
            temp.Insert(2, count);

            // 1运行   0停止
            if (_run && _speedml >0)
            {
                temp.Add(0x01);//运行
            }
            else
            {
                temp.Add(0x00);//停止
            }

            // 1顺时针  0逆转
            if (_direction)
            {
                temp.Add(0x01);
            }
            else
            {
                temp.Add(0x00);
            }

            byte tempVal = _id;
            for (byte k = 2; k < count + 3; k++)
            {
                tempVal ^= temp[k];
            }

            if (tempVal == 0xE9)
            {
                temp.Add(0xE8);
                temp.Add(0x01);
            }
            else if (tempVal == 0xE8)
            {
                temp.Add(0xE8);
                temp.Add(0x00);
            }
            else
            {
                temp.Add(tempVal);
            }
            return temp.ToArray();
        }

        //  返回状态及地址参数 
        //  返回命令格式：
        //  RJ：2字节，表示设置运行参数的命令，用ASCII码表示；例如，W：对应ASCII码 57H；J：对应ASCII码 4AH。
        //	转速：2字节，单位0.1rpm。例如，60.0 rpm，则对应0258H，高字节在前，低字节在后。
        //	全速、启停状态字节：
        //      Bit0：启停状态位，1为运行，0为停止；
        //      Bit1： 全速状态位，1为全速运行，0为正常运行；
        //	方向状态字节：
        //      Bit0：方向状态位，1为顺时针方向，0为逆时针方向； 
        public static byte[] ReadID()//RJ
        { 
            return new byte[] { 0x52, 0x4a };
        }

        //只能单台设置
        public static byte[] SetID(byte _id)//WID
        {
            return new byte[] { 0x57,0x49,0x44,_id };
        }
    }
}
