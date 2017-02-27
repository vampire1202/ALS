using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ALS.FormOperation
{
    public partial class ucPipeLine : UserControl
    {

        private string[] linePE = new string[] { "0.整体完成图", "1.安装准备", "2.血浆分离器", "3.动脉端管路", "4.静脉端管路", "5.分浆端管路", "6.补液端管路", "7.导引" };
        Image[] oPE = new Image[]{
            global::ALS.Properties.Resources.PE,
            global::ALS.Properties.Resources.PE1,
            global::ALS.Properties.Resources.PE2,
            global::ALS.Properties.Resources.PE3,
            global::ALS.Properties.Resources.PE4,
            global::ALS.Properties.Resources.PE5,
            global::ALS.Properties.Resources.PE6,
            global::ALS.Properties.Resources.PE
        };

        private string[] linePP = new string[] { "0.整体完成图", "1.安装准备","2.血浆分离器,胆红素吸附器", "3.动脉端管路", "4.静脉端管路", "5.分浆端管路", "6.回液端管路", "7.导引" };
        Image[] oPP = new Image[]{
            global::ALS.Properties.Resources.PP,
            global::ALS.Properties.Resources.PP1,
            global::ALS.Properties.Resources.PP2,
            global::ALS.Properties.Resources.PP3,
            global::ALS.Properties.Resources.PP4,
            global::ALS.Properties.Resources.PP5,
            global::ALS.Properties.Resources.PP6,
            global::ALS.Properties.Resources.PP
        };        
        
        private string[] lineLiALS = new string[] { "0.整体完成图", "1.血浆分离器", "2.静脉端管路", "3.动脉端管路", "4.透析液端管路", "5.分离端管路", 
            "6.血滤器,吸附柱,双腔储液池,血液滤过器","7.循环池管路","8.内循环管路","9.吸附柱管路","10.滤过端管路","11.补液端管路","12.导引"};
        Image[] oLiALS = new Image[]{
            global::ALS.Properties.Resources.LiALS,
            global::ALS.Properties.Resources.LiALS1,
            global::ALS.Properties.Resources.LiALS2,
            global::ALS.Properties.Resources.LiALS3,
            global::ALS.Properties.Resources.LiALS4,
            global::ALS.Properties.Resources.LiALS5,
            global::ALS.Properties.Resources.LiALS6,
            global::ALS.Properties.Resources.LiALS7,
            global::ALS.Properties.Resources.LiALS8,
            global::ALS.Properties.Resources.LiALS9,
            global::ALS.Properties.Resources.LiALS10,
            global::ALS.Properties.Resources.LiALS11,
            global::ALS.Properties.Resources.LiALS
        };

        private string[] lineCHDF = new string[] { "0.整体完成图", "1.安装准备", "2.透析滤过柱", "3.动脉端管路", "4.静脉端管路", "5.滤过端管路", "6.透析液端管路", "7.补液端管路", "8.导引" };
        Image[] oCVVHDF = new Image[]{
            global::ALS.Properties.Resources.CHDF,
            global::ALS.Properties.Resources.CHDF1,
            global::ALS.Properties.Resources.CHDF2,
            global::ALS.Properties.Resources.CHDF3,
            global::ALS.Properties.Resources.CHDF4,
            global::ALS.Properties.Resources.CHDF5,
            global::ALS.Properties.Resources.CHDF6,
            global::ALS.Properties.Resources.CHDF7,
            global::ALS.Properties.Resources.CHDF
        };

        private string[] linePDF = new string[] { "0.整体完成图", "1.安装准备", "2.透析滤过柱", "3.动脉端管路", "4.静脉端管路", "5.滤过端管路", "6.透析液端管路", "7.补液端管路", "8.导引" };
        Image[] oPDF = new Image[]{
          global::ALS.Properties.Resources.CHDF,
            global::ALS.Properties.Resources.CHDF1,
            global::ALS.Properties.Resources.CHDF2,
            global::ALS.Properties.Resources.CHDF3,
            global::ALS.Properties.Resources.CHDF4,
            global::ALS.Properties.Resources.CHDF5,
            global::ALS.Properties.Resources.CHDF6,
            global::ALS.Properties.Resources.CHDF7,
             global::ALS.Properties.Resources.CHDF
        };


        private string[] lineHP = new string[] { "0.整体完成图", "1.全血灌流吸附柱", "2.动脉端管路", "3.静脉端管路","4.导引" };
        Image[] oHP = new Image[]{
            global::ALS.Properties.Resources.HP,
            global::ALS.Properties.Resources.HP1,
            global::ALS.Properties.Resources.HP2,
            global::ALS.Properties.Resources.HP3,
            global::ALS.Properties.Resources.HP
        };

        private SerialPort _portPump;
        public SerialPort _PortPump
        {
            get { return _portPump; }
            set { _portPump = value; }
        }

        bool isGuide = false; 

        private string _methodName;
        public string _MethodName
        {
            get { return _methodName; }
            set { _methodName = value; }
        }

        private int _int_CurrentIndex;        public int M_int_CurrentIndex
        {
            get { return _int_CurrentIndex; }
            set { _int_CurrentIndex = value; }
        }
        int M_int_stepMax;

        //定义委托
        public delegate void btnClicked(object sender, EventArgs e);
        //定义事件
        public event btnClicked _btnNextClicked;

        public ucPipeLine()
        {
            InitializeComponent();
        }

        private void pipeLine_Load(object sender, EventArgs e)
        {
            InitLvStep(this.lvStep);
        }

        private void InitLvStep(ListView lv)
        {
            lv.Items.Clear();
            lv.View = View.Details;
            lv.LabelEdit = false;
            lv.AllowColumnReorder = false;
            //lv.CheckBoxes = true;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.ShowItemToolTips = true;
            lv.Sorting = SortOrder.None; 
            lv.ShowGroups = false;
            //lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv.Columns.Add("步骤",-2,HorizontalAlignment.Left); 
        }

        public void InitItems(string methodConfig)
        {
            this.lvStep.Items.Clear();
            switch (methodConfig)
            {
                case "PEConfig":
                    //绑定项和图片
                    for (int i = 0; i < linePE.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = linePE[i];
                        lvi.Tag = oPE[i];
                        lvStep.Items.Add(lvi);
                    }
                    M_int_stepMax = linePE.Length;
                    break;
                case "CHDFConfig":
                    for (int i = 0; i < lineCHDF.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = lineCHDF[i];
                        lvi.Tag = oCVVHDF[i];
                        lvStep.Items.Add(lvi);
                    }
                    M_int_stepMax = lineCHDF.Length;
                    break;
                case "PDFConfig":
                    for (int i = 0; i < linePDF.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = linePDF[i];
                        lvi.Tag = oPDF[i];
                        lvStep.Items.Add(lvi);
                    }
                    M_int_stepMax = linePDF.Length; 
                    break;
                case "HPConfig":
                    for (int i = 0; i < lineHP.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = lineHP[i];
                        lvi.Tag = oHP[i];
                        lvStep.Items.Add(lvi);
                    }
                    M_int_stepMax = lineHP.Length;
                    break;
                case "PPConfig":
                    for (int i = 0; i < linePP.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = linePP[i];
                        lvi.Tag = oPP[i];
                        lvStep.Items.Add(lvi);
                    }
                    M_int_stepMax = linePP.Length;
                    break;
                case "Li-ALSConfig":
                    for (int i = 0; i < lineLiALS.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = lineLiALS[i];
                        lvi.Tag = oLiALS[i];
                        lvStep.Items.Add(lvi);
                    }
                    lvStep.Refresh();
                    M_int_stepMax = lineLiALS.Length;
                    break;
            }

            if(lvStep.Items.Count>0)
            { 
                this.pboxShow.Image = (Image)lvStep.Items[0].Tag;
                SetBackColor(M_int_CurrentIndex);
                this.lvStep.Refresh();
            }
        }
     
        private void btnGuide_Click(object sender, EventArgs e)
        {
            isGuide = !isGuide;
            if (isGuide)
            {
                this.btnGuide.Text = "停止导引";
                this.btnNext.Enabled = false;
                this.btnReturn.Enabled = false;
                //导引开始默认120速度
                Cls.utils.SendOrder(_portPump, Cls.Comm_PeristalticPump.Command(0x1F, 120, true, true)); 
            }
            else
            {
                //停止导引
                Cls.utils.SendOrder(_portPump, Cls.Comm_PeristalticPump.Command(0x1F, 0, false, true));
                this.btnGuide.Text = "开始导引";
                this.btnNext.Enabled = true;
                this.btnReturn.Enabled = true; 
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {            
            M_int_CurrentIndex--;            
            btnGuide.Enabled = false;            
            if (M_int_CurrentIndex <= 0)
            {
                M_int_CurrentIndex = 0;
                btnGuide.Enabled = true;
            }
            SetBackColor(M_int_CurrentIndex);
            this.btnNext.Text = "下一步";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_btnNextClicked != null)
                _btnNextClicked(sender, e);            
            M_int_CurrentIndex++;
            btnGuide.Enabled = false;

            if (M_int_CurrentIndex >= M_int_stepMax - 1)
            {
                this.btnNext.Text = "完成";
            }
            else
                this.btnNext.Text = "下一步";

            if (this.btnNext.Text == "完成" && M_int_CurrentIndex >= M_int_stepMax-1)
            {
                M_int_CurrentIndex = M_int_stepMax - 1;
                btnGuide.Enabled = true;
                //this.lvStep.Items[M_int_CurrentIndex].Checked = true;
                //this.lvStep.Items[M_int_CurrentIndex].BackColor = Color.Yellow; 
            }
        
            //this.lvStep.Items[M_int_CurrentIndex].Checked = true;
            //this.lvStep.Items[M_int_CurrentIndex].BackColor = Color.Yellow; 
            SetBackColor(M_int_CurrentIndex);
            
        }

        public void SetBackColor(int currentIndex)
        {
            if(this.lvStep.Items.Count>0)
            { 
                foreach(ListViewItem lvi in this.lvStep.Items)
                {
                    lvi.BackColor = Color.FromKnownColor(KnownColor.Control);
                }
                this.lvStep.Items[currentIndex].BackColor = Color.Yellow;
                this.pboxShow.Image = (Image)this.lvStep.Items[currentIndex].Tag;
            }
        }

        private void pipeLine_SizeChanged(object sender, EventArgs e)
        {
            Rectangle rec = this.ClientRectangle;
            //与基准分辨率的放大系数
            float x = rec.Width / 898.0f;
            float y = rec.Height / 578.0f;
            Cls.utils.AutoSize(this, x, y);
        }

        private void lvStep_SizeChanged(object sender, EventArgs e)
        {
            this.lvStep.Columns[0].Width = this.lvStep.Width;
        }
    }
}
