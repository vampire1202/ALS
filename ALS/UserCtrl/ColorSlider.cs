using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ALS.UserCtrl
{
    public partial class ColorSlider : Control
    {

        [Description("Event fires when the Value property changes")]
        [Category("Action")]
        public event EventHandler ValueChanged;

        [Description("Event fires when the Value_1 property changes")]
        [Category("Action")]
        public event EventHandler Value_1Changed;

        [Description("Event fires when the Value_2 property changes")]
        [Category("Action")]
        public event EventHandler Value_2Changed;


        private Rectangle rectValue_1;
        private Rectangle rectValue_2;
        private Rectangle rectValue_3;
        private Rectangle rectValue_1half;
        private Rectangle rectValue_2half;
        private Rectangle rectValue_3half;
        private Rectangle barRect;
        //private Rectangle barHalfRect; 

        private int barMinimum = 0;
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>The minimum value.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when minimal value is greather than maximal one</exception>
        [Description("Set Slider minimal point")]
        [Category("ColorSlider")]
        [DefaultValue(0)]
        public int Minimum
        {
            get { return barMinimum; }
            set
            {
                if (value < barMaximum)
                {
                    barMinimum = value;
                    if (value_tracker < barMinimum)
                    {
                        value_tracker = barMinimum;
                        if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    }
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Minimal value is greather than maximal one");
            }
        }

        private int barMaximum = 100;
        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when maximal value is lower than minimal one</exception>
        [Description("Set Slider maximal point")]
        [Category("ColorSlider")]
        [DefaultValue(100)]
        public int Maximum
        {
            get { return barMaximum; }
            set
            {
                if (value > barMinimum)
                {
                    barMaximum = value;
                    if (value_tracker > barMaximum)
                    {
                        value_tracker = barMaximum;
                        if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    }
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Maximal value is lower than minimal one");
            }
        }

        private int value_tracker = 50;
        /// <summary>
        /// Gets or sets the value of Slider.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is outside appropriate range (min, max)</exception>
        [Description("Set Slider value")]
        [Category("ColorSlider")]
        [DefaultValue(50)]
        public int Value
        {
            get { return value_tracker; }
            set
            {
                if (value >= barMinimum & value <= barMaximum)
                {
                    value_tracker = value;
                    if (ValueChanged != null) ValueChanged(this, new EventArgs());
                    Invalidate();
                }
                else throw new ArgumentOutOfRangeException("Value is outside appropriate range (min, max)");
            }
        }

        private int value_1;
        [Description("Set Slider value1")]
        [Category("ColorSlider")]
        [DefaultValue(30)]
        public int Value_1
        {
            get { return value_1; }
            set
            {
                if (value >= barMinimum & value <= value_2)
                    value_1 = value;
                if (Value_1Changed != null) Value_1Changed(this, new EventArgs());
                Invalidate();
            }
        }

        private int value_2;
        [Description("Set Slider value2")]
        [Category("ColorSlider")]
        [DefaultValue(60)]
        public int Value_2
        {
            get { return value_2; }
            set
            {
                if (value > value_1 & value <= barMaximum)
                    value_2 = value;
                if (Value_2Changed != null) Value_2Changed(this, new EventArgs());
                Invalidate();
            }
        }

        private uint smallChange = 1;
        [Description("Set trackbar's small change")]
        [Category("ColorSlider")]
        [DefaultValue(1)]
        public uint SmallChange
        {
            get { return smallChange; }
            set { smallChange = value; }
        }

        private uint largeChange = 5;
        [Description("Set trackbar's large change")]
        [Category("ColorSlider")]
        [DefaultValue(5)]
        public uint LargeChange
        {
            get { return largeChange; }
            set { largeChange = value; }
        }

        //---------------------------------
        private Color value_Color = Color.FromArgb(15, 8, 100);
        [Description("Set Slider value outer color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "LightSalmon")]
        public Color Value_Color
        {
            get { return value_Color; }
            set
            {
                value_Color = value;
                Invalidate();
            }
        }

        //---------------------------------
        private Color value_1OuterColor = Color.LightSalmon;
        [Description("Set Slider value_1 outer color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "LightSalmon")]
        public Color Value_1OuterColor
        {
            get { return value_1OuterColor; }
            set
            {
                value_1OuterColor = value;
                Invalidate();
            }
        }

        private Color value_1innerColor = Color.IndianRed;
        [Description("Set Slider value_1 inner color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "Red")]
        public Color Value_1innerColor
        {
            get { return value_1innerColor; }
            set
            {
                value_1innerColor = value;
                Invalidate();
            }
        }

        //----------------------
        private Color value_2OuterColor = Color.LimeGreen;
        [Description("Set Slider value_2 outer color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "LimeGreen")]
        public Color Value_2OuterColor
        {
            get { return value_2OuterColor; }
            set
            {
                value_2OuterColor = value;
                Invalidate();
            }
        }

        private Color value_2innerColor = Color.DarkGreen;
        [Description("Set Slider value_2 inner color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "DarkGreen")]
        public Color Value_2innerColor
        {
            get { return value_2innerColor; }
            set
            {
                value_2innerColor = value;
                Invalidate();
            }
        }
        //----------------------
        private Color value_3OuterColor = Color.LightSalmon;
        [Description("Set Slider value_3 outer color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "LightSalmon")]
        public Color Value_3OuterColor
        {
            get { return value_3OuterColor; }
            set
            {
                value_3OuterColor = value;
                Invalidate();
            }
        }

        private Color value_3innerColor = Color.IndianRed;
        [Description("Set Slider value_3 inner color")]
        [Category("ColorSlider")]
        [DefaultValue(typeof(Color), "Red")]
        public Color Value_3innerColor
        {
            get { return value_3innerColor; }
            set
            {
                value_3innerColor = value;
                Invalidate();
            }
        }


        //private int thumbSize = 15;
        ///// <summary>
        ///// Gets or sets the size of the thumb.
        ///// </summary>
        ///// <value>The size of the thumb.</value>
        ///// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value is lower than zero or grather than half of appropiate dimension</exception>
        //[Description("Set Slider thumb size")]
        //[Category("ColorSlider")]
        //[DefaultValue(15)]
        //public int ThumbSize
        //{
        //    get { return thumbSize; }
        //    set
        //    {
        //        if (value > 0 &
        //            value < ClientRectangle.Width)
        //            thumbSize = value;
        //        else
        //            throw new ArgumentOutOfRangeException(
        //                "TrackSize has to be greather than zero and lower than half of Slider width");
        //        Invalidate();
        //    }
        //}

        //private GraphicsPath thumbCustomShape = null;
        ///// <summary>
        ///// Gets or sets the thumb custom shape. Use ThumbRect property to determine bounding rectangle.
        ///// </summary>
        ///// <value>The thumb custom shape. null means default shape</value>
        //[Description("Set Slider's thumb's custom shape")]
        //[Category("ColorSlider")]
        //[Browsable(false)]
        //[DefaultValue(typeof(GraphicsPath), "null")]
        //public GraphicsPath ThumbCustomShape
        //{
        //    get { return thumbCustomShape; }
        //    set
        //    {
        //        thumbCustomShape = value;
        //        thumbSize = (int)value.GetBounds().Width;
        //        Invalidate();
        //    }
        //}

        //private Size thumbRoundRectSize = new Size(8, 8);
        ///// <summary>
        ///// Gets or sets the size of the thumb round rectangle edges.
        ///// </summary>
        ///// <value>The size of the thumb round rectangle edges.</value>
        //[Description("Set Slider's thumb round rect size")]
        //[Category("ColorSlider")]
        //[DefaultValue(typeof(Size), "8,8")]
        //public Size ThumbRoundRectSize
        //{
        //    get { return thumbRoundRectSize; }
        //    set
        //    {
        //        int h = value.Height, w = value.Width;
        //        if (h <= 0) h = 1;
        //        if (w <= 0) w = 1;
        //        thumbRoundRectSize = new Size(w, h);
        //        Invalidate();
        //    }
        //}


        public ColorSlider(int min, int max, int val1, int val2, int val)
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.Selectable |
                     ControlStyles.SupportsTransparentBackColor | ControlStyles.UserMouse |
                     ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;

            Minimum = min;
            Maximum = max;
            value_1 = val1;
            value_2 = val2;
            Value = val;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorSlider"/> class.
        /// </summary>
        public ColorSlider() : this(0, 100, 30, 60, 50) { }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawColorSlider(pe, value_1OuterColor, value_1innerColor,
                value_2OuterColor, value_2innerColor,
                value_3OuterColor, value_3innerColor,
                value_Color
                );
        }

        /// <summary>
        /// Draws the colorslider control using passed colors.
        /// </summary>
        private void DrawColorSlider(PaintEventArgs e, Color _value_1OuterColor, Color _value_1innerColor,
                Color _value_2OuterColor, Color _value_2innerColor,
                Color _value_3OuterColor, Color _value_3innerColor,
                Color _value_Color
            )
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            try
            {
                int TrackX1 = (value_1 - barMinimum) * ClientRectangle.Width / (barMaximum - barMinimum);
                int TrackX2 = (value_2 - barMinimum) * ClientRectangle.Width / (barMaximum - barMinimum);

                //分三段,占整个clientrect的1/3
                rectValue_1 = new Rectangle(0, 5, TrackX1, ClientRectangle.Height);
                rectValue_2 = new Rectangle(TrackX1, 5, TrackX2, ClientRectangle.Height);
                rectValue_3 = new Rectangle(TrackX2, 5, ClientRectangle.Width - TrackX2, ClientRectangle.Height);

                rectValue_1half = rectValue_1;
                rectValue_1half.Height /= 2;
                //rectValue_1half.Y = rectValue_1half.Height;
                rectValue_2half = rectValue_2;
                rectValue_2half.Height /= 2;
                //rectValue_2half.Y = rectValue_2half.Height;
                rectValue_3half = rectValue_3;
                rectValue_3half.Height /= 2;
                //rectValue_3half.Y = rectValue_3half.Height;
                barRect = ClientRectangle;

                LinearGradientMode gradientOrientation;
                gradientOrientation = LinearGradientMode.Vertical;
                using (
                    LinearGradientBrush lgbBar1 =
                        new LinearGradientBrush(rectValue_1half, _value_1OuterColor, _value_1innerColor, gradientOrientation)
                    )
                {
                    lgbBar1.WrapMode = WrapMode.TileFlipXY;
                    e.Graphics.FillRectangle(lgbBar1, rectValue_1half);
                    
                    //FillRoundRectangle(e.Graphics, rectValue_1half, _value_1innerColor, 2,roundStyle.left);
                }
                using (
                   LinearGradientBrush lgbBar2 =
                       new LinearGradientBrush(rectValue_2half, _value_2OuterColor, _value_2innerColor, gradientOrientation)
                   )
                {
                    lgbBar2.WrapMode = WrapMode.TileFlipXY;
                    e.Graphics.FillRectangle(lgbBar2, rectValue_2half);
                }

                using (
                   LinearGradientBrush lgbBar3 =
                       new LinearGradientBrush(rectValue_3half, _value_3OuterColor, _value_3innerColor, gradientOrientation)
                   )
                {
                    lgbBar3.WrapMode = WrapMode.TileFlipXY;
                    e.Graphics.FillRectangle(lgbBar3, rectValue_3half);
                }

                //画值的位置,三角形 
                if (Value >= barMinimum & Value < barMaximum)
                {
                    int valuep = (Value - barMinimum) * (ClientRectangle.Width) / (barMaximum - barMinimum);
                    Point p1 = new Point(valuep, rectValue_1half.Height + 5);
                    Point p2 = new Point((int)(valuep - rectValue_1.Height * Math.Tan(60)), ClientRectangle.Height);
                    Point p3 = new Point((int)(valuep + rectValue_1.Height * Math.Tan(60)), ClientRectangle.Height);
                    Point[] arrp = new Point[] { p1, p2, p3 };
                    e.Graphics.FillPolygon(new SolidBrush(value_Color), arrp);
                }
            }
            catch (Exception Err)
            {
                Console.WriteLine("DrawBackGround Error in " + Name + ":" + Err.Message);
            }
            finally
            {

            }
        }

        #region Help routines

        /// <summary>
        /// Creates the round rect path.
        /// </summary>
        /// <param name="rect">The rectangle on which graphics path will be spanned.</param>
        /// <param name="size">The size of rounded rectangle edges.</param>
        /// <returns></returns>
        public static GraphicsPath CreateRoundRectPath(Rectangle rect, Size size)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(rect.Left + size.Width / 2, rect.Top, rect.Right - size.Width / 2, rect.Top);
            gp.AddArc(rect.Right - size.Width, rect.Top, size.Width, size.Height, 270, 90);

            gp.AddLine(rect.Right, rect.Top + size.Height / 2, rect.Right, rect.Bottom - size.Width / 2);
            gp.AddArc(rect.Right - size.Width, rect.Bottom - size.Height, size.Width, size.Height, 0, 90);

            gp.AddLine(rect.Right - size.Width / 2, rect.Bottom, rect.Left + size.Width / 2, rect.Bottom);
            gp.AddArc(rect.Left, rect.Bottom - size.Height, size.Width, size.Height, 90, 90);

            gp.AddLine(rect.Left, rect.Bottom - size.Height / 2, rect.Left, rect.Top + size.Height / 2);
            gp.AddArc(rect.Left, rect.Top, size.Width, size.Height, 180, 90);
            return gp;
        }

        /// <summary>  
        /// C# GDI+ 绘制圆角实心矩形  
        /// </summary>  
        /// <param name="g">Graphics 对象</param>  
        /// <param name="rectangle">要填充的矩形</param>  
        /// <param name="backColor">填充背景色</param>  
        /// <param name="r">圆角半径</param>  
        public static void FillRoundRectangle(Graphics g, Rectangle rectangle, Color backColor, int r,roundStyle rs)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
            Brush b = new SolidBrush(backColor);
            g.FillPath(b, GetRoundRectangle(rectangle, r,rs));
        }

        public enum roundStyle
        {
            left, right
        }
        /// <summary>  
        /// 根据普通矩形得到圆角矩形的路径  
        /// </summary>  
        /// <param name="rectangle">原始矩形</param>  
        /// <param name="r">半径</param>  
        /// <returns>图形路径</returns>  
        private static GraphicsPath GetRoundRectangle(Rectangle rectangle, int r, roundStyle rs)
        {
            int l = 2 * r;
            // 把圆角矩形分成八段直线、弧的组合，依次加到路径中  
            GraphicsPath gp = new GraphicsPath();
            switch (rs)
            {
                case roundStyle.left:
                    gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), new Point(rectangle.X + r, rectangle.Bottom));
                    gp.AddArc(new Rectangle(rectangle.X, rectangle.Bottom - l, l, l), 90F, 90F);

                    gp.AddLine(new Point(rectangle.X, rectangle.Bottom - r), new Point(rectangle.X, rectangle.Y + r));
                    gp.AddArc(new Rectangle(rectangle.X, rectangle.Y, l, l), 180F, 90F);

                    gp.AddLine(new Point(rectangle.X + r, rectangle.Y), new Point(rectangle.Right - r, rectangle.Y));
                    gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Y, l, l), 270F, 90F);

                    gp.AddLine(new Point(rectangle.Right, rectangle.Y + r), new Point(rectangle.Right, rectangle.Bottom - r));
                    gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Bottom - l, l, l), 0F, 90F);

                    break;
                case roundStyle.right:
                    gp.AddLine(new Point(rectangle.Right - r, rectangle.Bottom), new Point(rectangle.X + r, rectangle.Bottom));
                    gp.AddArc(new Rectangle(rectangle.X, rectangle.Bottom - l, l, l), 90F, 90F);

                    gp.AddLine(new Point(rectangle.X, rectangle.Bottom - r), new Point(rectangle.X, rectangle.Y + r));
                    gp.AddArc(new Rectangle(rectangle.X, rectangle.Y, l, l), 180F, 90F);

                    gp.AddLine(new Point(rectangle.X + r, rectangle.Y), new Point(rectangle.Right - r, rectangle.Y));
                    gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Y, l, l), 270F, 90F);

                    gp.AddLine(new Point(rectangle.Right, rectangle.Y + r), new Point(rectangle.Right, rectangle.Bottom - r));
                    gp.AddArc(new Rectangle(rectangle.Right - l, rectangle.Bottom - l, l, l), 0F, 90F);
                    break;
            }
            return gp;
        }

        /// <summary>
        /// Desaturates colors from given array.
        /// </summary>
        /// <param name="colorsToDesaturate">The colors to be desaturated.</param>
        /// <returns></returns>
        public static Color[] DesaturateColors(params Color[] colorsToDesaturate)
        {
            Color[] colorsToReturn = new Color[colorsToDesaturate.Length];
            for (int i = 0; i < colorsToDesaturate.Length; i++)
            {
                //use NTSC weighted avarage
                int gray =
                    (int)(colorsToDesaturate[i].R * 0.3 + colorsToDesaturate[i].G * 0.6 + colorsToDesaturate[i].B * 0.1);
                colorsToReturn[i] = Color.FromArgb(-0x010101 * (255 - gray) - 1);
            }
            return colorsToReturn;
        }

        /// <summary>
        /// Lightens colors from given array.
        /// </summary>
        /// <param name="colorsToLighten">The colors to lighten.</param>
        /// <returns></returns>
        public static Color[] LightenColors(params Color[] colorsToLighten)
        {
            Color[] colorsToReturn = new Color[colorsToLighten.Length];
            for (int i = 0; i < colorsToLighten.Length; i++)
            {
                colorsToReturn[i] = ControlPaint.Light(colorsToLighten[i]);
            }
            return colorsToReturn;
        }

        /// <summary>
        /// Sets the trackbar value so that it wont exceed allowed range.
        /// </summary>
        /// <param name="val">The value.</param>
        private void SetProperValue(int val)
        {
            if (val < barMinimum) Value = barMinimum;
            else if (val > barMaximum) Value = barMaximum;
            else Value = val;
        }

        /// <summary>
        /// Determines whether rectangle contains given point.
        /// </summary>
        /// <param name="pt">The point to test.</param>
        /// <param name="rect">The base rectangle.</param>
        /// <returns>
        /// 	<c>true</c> if rectangle contains given point; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsPointInRect(Point pt, Rectangle rect)
        {
            if (pt.X > rect.Left & pt.X < rect.Right & pt.Y > rect.Top & pt.Y < rect.Bottom)
                return true;
            else return false;
        }

        #endregion

    }
}
