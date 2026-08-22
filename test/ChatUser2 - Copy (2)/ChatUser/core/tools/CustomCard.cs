using ChatUser.data.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ChatUser.core.tools
{
    public class CustomCard : Panel
    {
        private Label dateLabel;
        private Label titleLabel;
        private ChatUser.core.tools.RoundedPictureBox imgBox;

        public string Title
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; this.Invalidate(); }
        }

        public string Date
        {
            get { return dateLabel.Text; }
            set { dateLabel.Text = value; this.Invalidate(); }
        }

        public Image Image
        {
            get { return imgBox.Image; }
            set { imgBox.Image = value; }
        }

        public int ImageCornerRadius
        {
            get { return imgBox.CornerRadius; }
            set { imgBox.CornerRadius = value; this.Invalidate(); }
        }

        public CustomCard()
        {
            // إعدادات اللوحة الرئيسية
            this.Size = new Size(329, 76);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

            // إنشاء الصورة
            imgBox = new ChatUser.core.tools.RoundedPictureBox
            {
                BorderColor = Color.Black,
                BorderThickness = 3,
                CornerRadius = 30,
                Location = new Point(268, 9),
                Size = new Size(57, 57),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            // إنشاء عنوان البطاقة
            titleLabel = new Label
            {  RightToLeft=RightToLeft.Yes,
                Font = new Font("Tahoma", 11.2F),
                Location = new Point(201, 9),
                AutoSize = true,
                Text = "العنوان"
            };

            // إنشاء تاريخ البطاقة
            dateLabel = new Label
            {
                Font = new Font("Tahoma", 8.2F),
                Location = new Point(7, 29),
                AutoSize = true,
                Text = "التأريخ"
            };

            // إضافة العناصر إلى البطاقة
            this.Controls.Add(imgBox);
            this.Controls.Add(titleLabel);
            this.Controls.Add(dateLabel);
            AdjustLayout();
            SizeChanged += CustomCard_SizeChanged;


        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            AdjustLayout();
        }
        private void CustomCard_SizeChanged(object sender, EventArgs e)
        {
            AdjustLayout();
        }

       
      public  static CustomCard[] buildList( List<Chat> list,Action<int,Chat> onClick)
        {
            int count=list.Count;

            CustomCard[] customCards = new CustomCard[count];//list.Count
            for (int i = 0; i < count; i++)
            {
              
                var item = list[i];
              
                customCards[i] = buildCard(item,onClick);
            }
       
            return customCards;
        }
        public static CustomCard buildCard(Chat chat, Action<int, Chat> onClick=null)
        {
            MemoryStream stream = chat.chatImage != null ? new MemoryStream(chat.chatImage) : null;
            var c = new CustomCard
            {
                Name = chat.ChatId.ToString(),
                Location = new Point(20, 100),
                //Width = 320,
                //Height = 100,
                Title = chat.title,
                Date = chat.sentDate.ToShortDateString(),//item.DateTime+ 

                ImageCornerRadius = 30,

            };
            if (stream != null)
                c.Image = Image.FromStream(stream);
            c.Click += (s, e) => onClick?.Invoke(int.Parse(c.Name), chat);
            return c;
        }
        private void AdjustLayout()
        {
            int padding = 10;
            int imgSize = Math.Min(this.Height - (2 * padding), 57); // حجم الصورة

            // تعديل حجم وموقع الصورة (في البداية يسارًا)
            imgBox.Size = new Size(imgSize, imgSize);
            imgBox.Location = new Point(Width- imgSize - padding, (this.Height - imgSize) / 2);

            // تعديل موقع العنوان (بجانب الصورة في المنتصف)
            int textX = imgBox.Right + padding;
            titleLabel.Location = new Point(Width - imgSize - padding-titleLabel.Width, (this.Height - titleLabel.Height) / 3);

            // تعديل موقع التاريخ (في أسفل البطاقة ممتد أفقيًا)
            dateLabel.Size = new Size(this.Width - 2 * padding, dateLabel.Height);
            dateLabel.Location = new Point(padding, (this.Height - dateLabel.Height) / 2);
        }
    }
}
