using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace ALS.Cls
{
   public class Model_AlarmInfo
    {
       private Font titlefont;
       /// <summary>
       /// 标题字体
       /// </summary>
       public Font TitleFont
       {
           get { return titlefont; }
           set { titlefont = value; }
       }

       private Color titleColor;
       public Color TitleColor
       {
           get { return titleColor; }
           set { titleColor = value; }
       }

       private Font contentfont;
       /// <summary>
       /// 内容字体
       /// </summary>
       public Font ContentFont
       {
           get { return contentfont; }
           set { contentfont = value; }
       }

       private Color contentColor;
       public Color ContentColor
       {
           get { return contentColor; }
           set { contentColor = value; }
       }

       private string title;
       /// <summary>
       /// 警报标题
       /// </summary>
       public string Title
       {
           get { return title; }
           set { title = value; }
       }

       private string content;
       /// <summary>
       /// 内容
       /// </summary>
       public string Content
       {
           get { return content; }
           set { content = value; }
       }

       private string cause;
       /// <summary>
       /// 原因
       /// </summary>
       public string Cause
       {
           get { return cause; }
           set { cause = value; }
       }

       private string deal;
       /// <summary>
       /// 处理
       /// </summary>
       public string Deal
       {
           get { return deal; }
           set { deal = value; }
       }

       /// <summary>
       /// 出现时间
       /// </summary>
       private DateTime alarmtime;
       public DateTime AlarmTime
       {
           get { return alarmtime; }
           set { alarmtime = value; }
       }

    }
}
