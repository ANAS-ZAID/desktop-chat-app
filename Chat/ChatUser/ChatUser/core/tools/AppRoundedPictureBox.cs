
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ChatUser.core.tools
{
    public class RoundedPictureBox : PictureBox
    {
        private int _cornerRadius = 30;
        private int _borderThickness = 3;
        private Color _borderColor = Color.Black;
        //private Color _shadowColor = Color.Transparent;
        //private int _shadowOffset = 5;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; this.Invalidate(); }
        }

        public int BorderThickness
        {
            get { return _borderThickness; }
            set { _borderThickness = value; this.Invalidate(); }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; this.Invalidate(); }
        }

        //public Color ShadowColor
        //{
        //    get { return _shadowColor; }
        //    set { _shadowColor = value; this.Invalidate(); }
        //}

        //public int ShadowOffset
        //{
        //    get { return _shadowOffset; }
        //    set { _shadowOffset = value; this.Invalidate(); }
        //}

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // إنشاء المسار المستدير
            using (GraphicsPath path = GetRoundedRectanglePath(new Rectangle(0, 0, this.Width, this.Height), _cornerRadius))
            {
                // رسم الظل
                //if (_shadowOffset > 0)
                //{
                //    using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(80, _shadowColor)))
                //    {
                //        pe.Graphics.FillPath(shadowBrush, GetRoundedRectanglePath(new Rectangle(_shadowOffset, _shadowOffset, this.Width, this.Height), _cornerRadius));
                //    }
                //}

                // تعيين حدود الصورة داخل المسار
                this.Region = new Region(path);

                // رسم الإطار حول الصورة
                using (Pen borderPen = new Pen(_borderColor, _borderThickness))
                {
                    pe.Graphics.DrawPath(borderPen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            path.AddArc(arcRect, 180, 90);  // أعلى يسار
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);  // أعلى يمين
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);   // أسفل يمين
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);  // أسفل يسار

            path.CloseFigure();
            return path;
        }
    }


}
