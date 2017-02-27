using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Configuration;
using System.Web.Script;
using System.Web.Script.Serialization;
namespace ALS.Cls
{
    public class utils
    {

        /// <summary>
        /// 串口发送命令
        /// </summary>
        /// <param name="_sp"></param>
        /// <param name="_order"></param>
        public static void SendOrder(SerialPort _sp, byte[] _order)
        {
            try
            {
                if (_sp.IsOpen)
                {
                    Thread.Sleep(150);
                    if (_sp.PortName.ToLower() == "com3")
                        Thread.Sleep(100);                    
                    _sp.Write(_order, 0, _order.Length);
                    Thread.Sleep(100);
                }
                else
                {
                    MessageBox.Show("串口不存在或未初始化!", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ee)          
            {
                MessageBox.Show(ee.ToString(), "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        
        /// <summary>
        /// 递归实现自适应分辨率
        /// </summary>
        /// <param name="uc"></param>
        public static void AutoSize(Control uc,float scaleX,float scaleY)
        {
            foreach (Control c in uc.Controls)
            { 
                c.Left =(int)(c.Left*scaleX);
                c.Height = (int)(c.Height*scaleY);
                c.Width = (int)(c.Width*scaleX);
                c.Top = (int)(c.Top*scaleY);
                //if (c.Name.Contains("agauge_"))
                //{
                //    UserCtrl.AGauge ag = (UserCtrl.AGauge)c;
                //    ag.Center = new Point((int)(ag.Center.X * scaleX),(int)( ag.Center.Y * scaleY));
                //    ag.CapPosition = new Point((int)(ag.CapPosition.X * scaleX), (int)(ag.CapPosition.Y * scaleY));
                //}
                AutoSize(c,scaleX,scaleY);
            } 
        }

        public  enum M_SendType
        {//无返回,夹管阀正常，夹管阀故障，声光正常，声光异常，蠕动泵正常，蠕动泵异常，气泡检测正常，气泡检测异常
            NoResult, vtrue, vfalse,
            vltrue, vlfalse,
            pumptrue, pumpfalse,
            bubbletrue, bubblefalse,
            portfalse,porttrue,
            databasefalse,databasetrue
        };
        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="value"></param>
        public static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);            
            fs.Write(info, 0, info.Length);
        }  

        public static void AddText(string value)
        {
            //创建传输文档
            string pah = @"D:/surgeryData.txt";
            //if (!File.Exists(pah))
            //    File.CreateText(pah);
            //文件以追加方式打开
            using (StreamWriter sw = new StreamWriter(pah, true, Encoding.UTF8))
            {
                try
                {
                    sw.WriteLine(value);
                    sw.Flush();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
                finally
                {
                    sw.Close();
                }
            }
        }
        /// <summary>
        /// 进制转换为字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="fromBase">源进制：2 8 10 16</param>
        /// <param name="toBase">目标进制：2 8 10 16</param>
        /// <returns></returns>
        public static string ConvertString(string value, int fromBase, int toBase)
        {
            int intValue = Convert.ToInt32(value, fromBase);
            return Convert.ToString(intValue, toBase);
        }

        public class  sysStartLog 
        {
            /// <summary>
            /// 启动时间
            /// </summary>
            private DateTime _startTime;
            public DateTime StartTime
            {
                get { return _startTime; }
                set { _startTime = value; }
            }

            /// <summary>
            /// 启动提示信息
            /// </summary>
            private string _startInfo;
            public string StartInfo
            {
                get { return _startInfo; }
                set { _startInfo = value; }
            }

            /// <summary>
            /// 提示文字颜色
            /// </summary>
            private Color _infoColor;
            public Color InfoColor
            {
                get { return _infoColor; }
                set { _infoColor = value; }
            }
        }

        /// <summary>
        /// 插入格式文本
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="title"></param>
        /// <param name="titleColor"></param>
        /// <param name="titleFont"></param>
        /// <param name="content"></param>
        /// <param name="contentColor"></param>
        /// <param name="contentFont"></param>
        public static void richBoxAppendText(RichTextBox rtb, string title, string content)
        {
            //rtb.BackColor = Color.White;
            rtb.SelectionFont = new Font("宋体", 14);
            rtb.SelectionColor = Color.FromArgb(218, 18, 18); 
            rtb.AppendText(title+"\r\n");
            rtb.SelectionFont = new Font("宋体", 12); ;
            rtb.SelectionColor = Color.FromArgb(15, 8, 100);
            rtb.AppendText(content+"\r\n");
            rtb.HideSelection = false;
            rtb.Focus(); 
        }

        /// <summary>
        /// 插入报警信息
        /// </summary>
        /// <param name="rtb"></param>
        /// <param name="_ai"></param>
        public static void richBoxAppendAlarm(RichTextBox rtb,RichTextBox rtbTop, List<Cls.Model_AlarmInfo> _lstAi)
        {
            if (rtb != null) rtb.Clear();
            if (rtbTop != null) rtbTop.Clear();
            for (int i = 0; i < _lstAi.Count; i++)
            {
                //顶部标题
                if (rtbTop != null)
                {
                    rtbTop.SelectionFont = _lstAi[i].ContentFont;
                    rtbTop.SelectionColor = _lstAi[i].TitleColor;
                    rtbTop.AppendText((i + 1).ToString() + "." + _lstAi[i].Title + "\r\n");
                }
                //详细内容
                if (rtb != null)
                { 
                    rtb.SelectionFont = _lstAi[i].TitleFont;
                    rtb.SelectionColor = _lstAi[i].TitleColor;
                    rtb.AppendText((i + 1).ToString() + "." + _lstAi[i].Title+"\r\n");
                    rtb.SelectionFont = _lstAi[i].ContentFont;
                    rtb.SelectionColor = _lstAi[i].ContentColor;
                    rtb.AppendText(_lstAi[i].Content + "\r\n");
                    rtb.SelectionFont = _lstAi[i].ContentFont;
                    rtb.SelectionColor = _lstAi[i].ContentColor;
                    rtb.AppendText(_lstAi[i].Cause + "\r\n");
                    rtb.SelectionFont = _lstAi[i].ContentFont;
                    rtb.SelectionColor = _lstAi[i].ContentColor;
                    rtb.AppendText(_lstAi[i].Deal + "\r\n");
                }
            }
            if (rtb != null)
            {
                rtb.HideSelection = false;
                rtb.Focus();
            }
            if (rtbTop != null)
            {
                rtbTop.HideSelection = false;
                rtbTop.Focus();
            }
        }
        /// <summary>
        /// 增加计算时间的函数
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string SecondsToTime(int seconds)
        {
            int hours = 0;
            int min = 0;
            int sec = 0;
            hours = seconds / 3600;
            min = (seconds-3600*hours) / 60;
            sec = seconds % 60;
            return hours.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
        }

        /// <summary>
        /// 增加治疗方法的自定义配置节
        /// </summary>
        /// <param name="methodName">治疗模式名称</param>
        /// <param name="ID">治疗模式ID</param>
        public static void CreateMethodConfig(string sectionName, string methodName, string ID)
        {
            try
            {
                Cls.Method_Config customSection;
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(                    
                        AppDomain.CurrentDomain.BaseDirectory + "ALS.exe");//ConfigurationUserLevel.None);
                // Create the section entry  
                // in <configSections> and the 
                // related target section in <configuration>.
                if (config.Sections[sectionName] == null)
                {
                    customSection = new Cls.Method_Config();
                    customSection.Name = methodName;
                    customSection.ID = ID;                   
                    //<!--泵的设置  value表示速度 Direction表示方向-->
                    //<add key="BPSpeed" value="100.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("BPSpeed", "100.0"));
                    //<add key="BPDirection" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("BPDirection", "true"));
                    //<add key="BPValid" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("BPValid", "true"));
                    //<add key="FPSpeed" value="30.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("FPSpeed", "30.0"));
                    //<add key="FPDirection" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("FPDirection", "true"));
                    //<add key="FPValid" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("FPValid", "true"));
                    //<add key="DPSpeed" value="30.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("DPSpeed", "30.0"));
                    //<add key="DPDirection" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("DPDirection", "true"));
                    //<add key="DPValid" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("DPValid", "true"));
                    //<add key="RPSpeed" value="30.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("RPSpeed", "30.0"));
                    //<add key="RPDirection" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("RPDirection", "true"));
                    //<add key="RPValid" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("RPValid", "true"));
                    //<add key="FP2Speed" value="30.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("FP2Speed", "30.0"));
                    //<add key="FP2Direction" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("FP2Direction", "true"));
                    //<add key="FP2Valid" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("FP2Valid", "true"));
                    //<add key="CPSpeed" value="30.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("CPSpeed", "30.0"));
                    //<add key="CPDirection" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("CPDirection", "true"));
                    //<add key="CPValid" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("CPValid", "true"));
                    //<!--目标累计值设置-->
                    //<add key="TargetTimeH" value="08" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TargetTimeH", "06"));
                    //<add key="TargetTimeMin" value="08" />               
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TargetTimeMin", "00"));
                    //<add key="IsTargetTime" value="true" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("IsTargetTime", "true"));
                    //<add key="TargetBP" value="5.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TargetBP", "5.0"));
                    //<add key="IsTargetBP" value="false" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("IsTargetBP", "true"));
                    //<add key="TargetDP" value="5.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TargetDP", "5.0"));
                    //<add key="IsTargetDP" value="false" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("IsTargetDP", "true"));
                    //<add key="TargetSP" value="200.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TargetSP", "200.0"));
                    //<add key="IsTargetSP" value="false" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("IsTargetSP", "true"));
                    //<add key="TargetRP" value="5.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TargetRP", "5.0"));
                    //<add key="IsTargetRP" value="false" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("IsTargetRP", "true"));
                    //<add key="TargetFP" value="5.0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TargetFP", "5.0"));
                    //<add key="IsTargetFP" value="false" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("IsTargetFP", "false"));
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("dehydrationSpeed", "0.0"));
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("dehydrationValid", "false"));
                    
                    //<!--浓度-->
                    //<add key="Concentration" value="40" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("Concentration", "40"));
                    //<!--清洗量设定-->
                    //<add key="PEFlushOut" value="1000" />
                   customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PEFlushOut", "1000")); 
                    //<add key="PEFlushIn" value="2000" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PEFlushIn", "2000"));
                    //<!--肝素泵参数设置-->  
                    //<add key="SP_Speed" value="5.0"/>  
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("SP_Speed", "5.0"));  
                    //<add key="SP_RapidValue" value="5.0"/>                    
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("SP_RapidInjectionValue", "5.0")); 
                    //<!--温度-->
                    //<add key="TargetT" value="38"/>
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TargetT", "38"));        
                    //<!--报警上下限-->
                    //<add key="PaccUpper" value="500" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PaccUpper", "500"));
                    //<add key="PaccLower" value="-250" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PaccLower", "-250"));
                    //<add key="PartUpper" value="250" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PartUpper", "250"));
                    //<add key="PartLower" value="-250" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PartLower", "-250"));
                    //<add key="PvenUpper" value="250" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PvenUpper", "250"));
                    //<add key="PvenLower" value="0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PvenLower", "0"));
                    //<add key="P1stUpper" value="250" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("P1stUpper", "250"));
                    //<add key="P1stLower" value="-300" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("P1stLower", "-300"));
                    //<add key="P2ndUpper" value="400" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("P2ndUpper", "400"));
                    //<add key="P2ndLower" value="-100" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("P2ndLower", "-100"));
                    //<add key="TmpUpper" value="250" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TmpUpper", "250"));
                    //<add key="TmpLower" value="-100" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("TmpLower", "-100"));
                    //<add key="PrePaccLower" value="0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PrePaccLower", "0"));
                    //<add key="PrePvenUpper" value="0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PrePvenUpper", "0"));
                    //<add key="PrePartUpper" value="0" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("PrePartUpper", "0"));
                    //<add key="BloodLeak" value="1900" />
                    customSection.KeyValues.Add(new Cls.MyKeyValueSetting("BloodLeak", "1900"));
              
                    config.Sections.Add(sectionName, customSection);
                    customSection.SectionInformation.ForceSave = true;
                    //config.Save(ConfigurationSaveMode.Full);
                    config.Save();
                    Console.WriteLine("Section name: {0} created",
                        customSection.SectionInformation.Name);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        /// <summary>
        /// 读取section下的key-value
        /// </summary>
        /// <param name="section">配置节</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSectionKeyValue(string section,string key)
        {
            try
            {
                Cls.Method_Config customSection;
                string value = string.Empty;
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        AppDomain.CurrentDomain.BaseDirectory + "ALS.exe");
                if (config.Sections[section] != null)
                {
                    customSection = (Method_Config)config.Sections[section];
                    value = customSection.KeyValues[key].Value;
                }
                return value;
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
                return null;
            }
        }

        /// <summary>
        /// 设置section下的key-value
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetSectionKeyValue(string section,string key, string value)
        {
            bool returnValue = false;
            try
            {
                Cls.Method_Config customSection; 
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        AppDomain.CurrentDomain.BaseDirectory + "ALS.exe");
                if (config.Sections[section] != null)
                {
                    customSection = (Method_Config)config.Sections[section];
                    customSection.KeyValues[key].Value = value;
                    customSection.SectionInformation.ForceSave = true;
                    //config.Save(ConfigurationSaveMode.Full);
                    config.Save();
                    returnValue = true;
                }
                else
                    returnValue = false;
                return returnValue;
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
                return false;
            }
        }


        /// <summary>
        /// 设置单个泵状态
        /// </summary>
        /// <param name="_modelPumpState"></param>
        public static void SetSinglePumpState(Cls.Model_State pumpstate, int _pumpID, double _speed, bool _isRuning, bool _direction)
        {
            switch (_pumpID)
            {
                case 1:
                    pumpstate.BPState.PumpID = 1;
                    pumpstate.BPState.Direction = _direction;
                    pumpstate.BPState.Runing = _isRuning;
                    pumpstate.BPState.Speed = _speed;
                    break;
                case 2:
                    pumpstate.BPState.PumpID = 2;
                    pumpstate.FPState.Direction = _direction;
                    pumpstate.FPState.Runing = _isRuning;
                    pumpstate.FPState.Speed = _speed;
                    break;
                case 3:
                    pumpstate.BPState.PumpID = 3;
                    pumpstate.DPState.Direction = _direction;
                    pumpstate.DPState.Runing = _isRuning;
                    pumpstate.DPState.Speed = _speed;
                    break;
                case 4:
                    pumpstate.BPState.PumpID = 4;
                    pumpstate.RPState.Direction = _direction;
                    pumpstate.RPState.Runing = _isRuning;
                    pumpstate.RPState.Speed = _speed;
                    break;
                case 5:
                    pumpstate.BPState.PumpID = 5;
                    pumpstate.FP2State.Direction = _direction;
                    pumpstate.FP2State.Runing = _isRuning;
                    pumpstate.FP2State.Speed = _speed;
                    break;
                case 6:
                    pumpstate.BPState.PumpID = 6;
                    pumpstate.CPState.Direction = _direction;
                    pumpstate.CPState.Runing = _isRuning;
                    pumpstate.CPState.Speed = _speed;
                    break;
            }
        }
 


    }
}
