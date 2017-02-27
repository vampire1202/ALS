using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace ALS.Cls
{
    class ReadMainComm
    {
        internal class CommReader
        {
            //数据计数器
            private int count = 0;
            //变长标志数
            //private int bufCount = 0;
            //数字缓冲区
            List<byte> lstBuf = new List<byte>();
            //串口控件
            private SerialPort _Comm;
            //扫描的时间间隔 单位毫秒            
            private Int32 _interval;
            //添加标志
            //private bool _isadd=false;
            //数据处理函数
            public delegate void HandleCommData(List<byte> data);
            //事件侦听
            public event HandleCommData Handlers;

            //负责读写Comm的线程
            private Thread _workerThread;

            internal CommReader(SerialPort comm, Int32 interval)
            {
                _Comm = comm;
                //创建读取线程
                _workerThread = new Thread(new ThreadStart(ReadComm));
                //确保扫描时间间隔不要太小,造成线程长期占用cpu
                if (interval < 50)
                    _interval = 50;
                else
                    _interval = interval;
            }

            //读取串口数据,为线程执行函数
            public void ReadComm()
            {
                try
                {
                    while (true)
                    {
                        Object obj = null;
                        try
                        {
                            //每隔一定时间,从串口读入一字节
                            //如未读到,obj为null
                            if (_Comm.IsOpen)
                                obj = _Comm.ReadByte();
                        }
                        catch { }                      

                        if (obj == null)
                        { 
                            //未读到数据,线程休眠
                            Thread.Sleep(_interval);
                            continue;
                        }
                        //将读到的一字节数据存入缓存,这里需要做一转换   
                        if(count ==0)
                            lstBuf.Add(Convert.ToByte(obj));
                        //byte b = Convert.ToByte(obj);
                        if (lstBuf[0] == 0xFF)
                        {                            
                            if(count>0)
                                lstBuf.Add(Convert.ToByte(obj));
                            count++;
                        }
                        else
                            lstBuf.RemoveAt(0);
  
                        //如果收到结束位
                        if (lstBuf[lstBuf.Count-1] == 0xED) 
                        {                          
                            //复制数据,并清空缓存,计数器也置零
                            List<byte> data = new List<byte>();
                            data.AddRange(lstBuf); 
                            lstBuf.Clear();
                            count = 0;
                            //通知处理器处理数据
                            if (Handlers != null)
                                Handlers(data);                                              
                        }                      
                    }
                }
                catch {
                    
                }
            }

            //启动读入器
            public void Start()
            {
                //启动读取线程
                if (_workerThread.IsAlive)
                    return; 
                if (!_Comm.IsOpen)
                    _Comm.Open();
                _workerThread.Start();
                while (!_workerThread.IsAlive)
                {
                    Stop();
                };
            }

            //停止读入
            public void Stop()
            {
                //停止读取线程
                if (_workerThread.IsAlive)
                {
                    _workerThread.Abort();
                    _workerThread.Join();
                }
                _Comm.Close();
            }
        }
    }
}
