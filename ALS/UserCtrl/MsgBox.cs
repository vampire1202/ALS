using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALS.UserCtrl
{
    public partial class MsgBox : Form
    {
        public enum MSBoxIcon
        {
            Done,
            Edit,
            Error,
            Infomation,
            Like,
            Add,
            Password,
            Question,
            Setting,
            Update,
            Warning,
        }

        public class clsBoxStyle
        {
            Image icon = ALS.Properties.Resources.iconwarning;
            public Image Icon
            {
                get { return icon; }
                set { icon = value; }
            }
            Color titleBg = Color.DarkOrange;

            public Color TitleBg
            {
                get { return titleBg; }
                set { titleBg = value; }
            }

            Color titleBg2 = Color.Gold;

            public Color TitleBg2
            {
                get { return titleBg2; }
                set { titleBg2 = value; }
            }
        }

        public static clsBoxStyle GetStyleFromName(MSBoxIcon _iconname)
        {
            clsBoxStyle msgStyle = new clsBoxStyle();
            switch (_iconname)
            {
                case MSBoxIcon.Done:
                    msgStyle.Icon = ALS.Properties.Resources.icon_done;
                    msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Edit:
                    msgStyle.Icon = ALS.Properties.Resources.icon_editting;
                    msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Error:
                    msgStyle.Icon = ALS.Properties.Resources.icon_error;
                     msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Infomation:
                    msgStyle.Icon = ALS.Properties.Resources.icon_infomation;
                    msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Like:
                    msgStyle.Icon = ALS.Properties.Resources.icon_like;
                 msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Add:
                    msgStyle.Icon = ALS.Properties.Resources.icon_new;
                    msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Password:
                    msgStyle.Icon = ALS.Properties.Resources.icon_password;
                     msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Question:
                    msgStyle.Icon = ALS.Properties.Resources.icon_question;
                     msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Setting:
                    msgStyle.Icon = ALS.Properties.Resources.icon_setting;
                    msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Update:
                    msgStyle.Icon = ALS.Properties.Resources.icon_updating;
                    msgStyle.TitleBg = Color.FromArgb(17, 96, 152);
                    msgStyle.TitleBg2 = Color.FromArgb(9, 140, 188);
                    break;
                case MSBoxIcon.Warning:
                    msgStyle.Icon = ALS.Properties.Resources.iconwarning;
                    msgStyle.TitleBg = Color.DarkOrange;
                    msgStyle.TitleBg2 = Color.Orange;
                    break;
                default:
                    msgStyle.Icon = ALS.Properties.Resources.iconwarning;
                    msgStyle.TitleBg = Color.DarkOrange;
                    msgStyle.TitleBg2 = Color.Orange;
                    break;
            }
            return msgStyle;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_content">提示内容</param>
        /// <param name="_tipPic">提示图片</param>
        /// <param name="_enableCancel">取消是否可用</param>
        public MsgBox(string _content,MSBoxIcon _style, Image _tipPic, bool _enableCancel)
        {
            InitializeComponent();
            this.lblContent.Text = _content;
            this.picTip.Image = _tipPic;
            clsBoxStyle clsStyle = GetStyleFromName(_style);
            this.picIcon.Image = clsStyle.Icon;
            this.lblContent.BackColor = clsStyle.TitleBg;
            this.lblContent.BackColor2 = clsStyle.TitleBg2;
            this.btnCancel.Enabled = _enableCancel;
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {

        }
        private int x, y;
        private void lblContent_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void lblContent_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                this.SetDesktopLocation(MousePosition.X - x - lblContent.Location.X - Screen.PrimaryScreen.WorkingArea.X, MousePosition.Y - y - lblContent.Location.Y - Screen.PrimaryScreen.WorkingArea.Y);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
