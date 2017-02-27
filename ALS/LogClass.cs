using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ALS
{
    class LogClass
    {
        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input"></param>
        public void WriteLogFile(string input)
        {
            //建立文件夹 LogFile
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "LogFile_COM4"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "LogFile_COM4");
            //指定日志文件的目录
            //string fname = Directory.GetCurrentDirectory() + "\\LogFile.txt";
            string fname = AppDomain.CurrentDomain.BaseDirectory + "LogFile_COM4\\LogFile.txt";
            //定义文件信息对象
            FileInfo finfo = new FileInfo(fname);
            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(fname);
                fs.Close();
                finfo = new FileInfo(fname);
            }
            //判断文件是否存在以及是否大于2M
            if (finfo.Length > 1024 * 1024 * 2)
            {
                string destPath = AppDomain.CurrentDomain.BaseDirectory + "LogFile_COM4\\" + DateTime.Now.ToString("yyMMdd_HHmmss");
                if (!Directory.Exists(destPath))
                    Directory.CreateDirectory(destPath);
                File.Copy(AppDomain.CurrentDomain.BaseDirectory + "LogFile_COM4\\LogFile.txt", destPath+ "\\LogFile.txt");
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "LogFile_COM4\\LogFile.txt");
            }
            ///创建只写文件流
            using (FileStream fs = finfo.OpenWrite())
            {
                //根据上面创建的文件流创建写数据流
                StreamWriter w = new StreamWriter(fs);
                //设置写数据流的起始位置为文件流的末尾
                w.BaseStream.Seek(0, SeekOrigin.End);
                //写入日志内容并换行
                w.Write(input + "\n\r");       
                //清空缓冲区内容，并把缓冲区内容写入基础流
                w.Flush();
                //关闭写数据流
                w.Close();
            }
        }
    }
}
