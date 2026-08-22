using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser
{
    public partial class ChatForm : Form
    {
        private FlowLayoutPanel chatPanel;
        //private TextBox txtMessage;
        private Button btnSend;
        private bool isSender = true; // لتحديد اتجاه الرسائل بين المرسل والمستلم

        public ChatForm()
        {
            InitializeComponent();
            //this.Text = "Chat Application";
            //this.Size = new Size(400, 500);
            //this.StartPosition = FormStartPosition.CenterScreen;
            //this.BackColor = Color.WhiteSmoke;

            //// إنشاء FlowLayoutPanel لعرض الرسائل
            //chatPanel = new FlowLayoutPanel
            //{
            //    Dock = DockStyle.Top,
            //    AutoScroll = true,
            //    FlowDirection = FlowDirection.TopDown,
            //    WrapContents = false,
            //    Padding = new Padding(10),
            //    Height = 380,
            //    BackColor = Color.White
            //};
            //this.Controls.Add(chatPanel);

            //// صندوق إدخال الرسالة
            //txtMessage = new TextBox
            //{
            //    Dock = DockStyle.Bottom,
            //    Width = 300,
            //    Font = new Font("Arial", 10)
            //};
            //this.Controls.Add(txtMessage);

            //// زر الإرسال
            //btnSend = new Button
            //{
            //    Text = "إرسال",
            //    Dock = DockStyle.Bottom,
            //    Height = 40,
            //    BackColor = Color.LightBlue
            //};
            //btnSend.Click += (s, e) => SendMessage(txtMessage.Text);
            //this.Controls.Add(btnSend);

            //// إضافة نص التلميح المخصص
            //txtMessage.GotFocus += (s, e) => RemovePlaceholderText();
            //txtMessage.LostFocus += (s, e) => AddPlaceholderText();
            //AddPlaceholderText(); // إضافة النص عند بدء التطبيق
        }

        //private void SendMessage(string text)
        //{
        //    if (string.IsNullOrWhiteSpace(text)) return;

        //    // إنشاء Label للرسالة
        //    Label lblMessage = new Label
        //    {
        //        AutoSize = false,
        //        MaximumSize = new Size(250, 0), // تحديد العرض الأقصى
        //        Padding = new Padding(8),
        //        Font = new Font("Arial", 10),
        //        Text = text,
        //        ForeColor = Color.Black,
        //        BackColor = isSender ? Color.LightGreen : Color.LightGray,
        //        BorderStyle = BorderStyle.FixedSingle
        //    };

        //    // حساب الحجم المناسب للنص
        //    Size textSize = TextRenderer.MeasureText(text, lblMessage.Font, new Size(lblMessage.MaximumSize.Width, int.MaxValue), TextFormatFlags.WordBreak);
        //    lblMessage.Size = new Size(lblMessage.MaximumSize.Width, textSize.Height + 16); // تعديل الارتفاع

        //    // محاذاة الرسالة حسب المرسل
        //    lblMessage.TextAlign = isSender ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft;

        //    // إضافة الرسالة إلى chatPanel مباشرةً
        //    chatPanel.Controls.Add(lblMessage);
        //    chatPanel.ScrollControlIntoView(lblMessage); // التمرير تلقائيًا إلى آخر رسالة

        //    txtMessage.Clear(); // مسح صندوق الإدخال
        //    isSender = !isSender; // التبديل بين المرسل والمستلم
        //}

        //// إضافة نص التلميح (Placeholder) للمربع النصي
        //private void AddPlaceholderText()
        //{
        //    if (txtMessage.Text == "")
        //    {
        //        txtMessage.ForeColor = Color.Gray;
        //        txtMessage.Text = "اكتب رسالة...";
        //    }
        //}

        //// إزالة نص التلميح عند التركيز على صندوق النص
        //private void RemovePlaceholderText()
        //{
        //    if (txtMessage.Text == "اكتب رسالة...")
        //    {
        //        txtMessage.Text = "";
        //        txtMessage.ForeColor = Color.Black;
        //    }
        //}
        private void flpChat_Resize(object sender, EventArgs e)
        {
            foreach (Control container in flpChat.Controls)
            {
                if (container is Panel panel)
                {
                    panel.Width = flpChat.Width - 20; // 🔴
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is ChatMessage msg)
                        {
                            msg.Location = (msg.Anchor == AnchorStyles.Right) ?
                                new Point(panel.Width - msg.Width, 0) :
                                new Point(0, 0);
                        }
                    }
                }
            }
        }

        private void appButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                AddMessage(txtMessage.Text, isUser: true);
                txtMessage.Clear();
                // إضافة رد آلي (اختياري)
                AddMessage("تم استلام الرسالة", isUser: false);
            }
        }
        private void AddMessage(string text, bool isUser)
        {
            ChatMessage message = new ChatMessage();
            message.MessageText = text;
            message.BackColor = isUser ? Color.LightBlue : Color.WhiteSmoke;

            // 2. إنشاء الحاوية الأساسية
            Panel container = new Panel();
            container.Width = flpChat.Width - 25; // احتياطي لشريط التمرير
            container.AutoSize = true;
            container.Margin = new Padding(3, 5, 3, 5);

            // 3. إجبار النظام على حساب الحجم الفعلي
            message.PerformLayout();
            Application.DoEvents(); // 🔴 مهم للتحديث الفوري

            // 4. تحديد موقع الرسالة داخل الحاوية
            message.Location = isUser ?
                new Point(container.Width - message.Width - 5, 5) :
                new Point(5, 5);

            // 5. إضافة العناصر إلى الواجهة
            container.Controls.Add(message);
            flpChat.Controls.Add(container);

            // 6. التمرير التلقائي والتحديث
            flpChat.ScrollControlIntoView(container);
            container.BringToFront();
            flpChat.Refresh();
                // 🔴 مهم للتحديث الفوري
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            flpChat.AutoScroll = true;
            flpChat.FlowDirection = FlowDirection.TopDown;
            flpChat.WrapContents = false;
            flpChat.Dock = DockStyle.Fill;
            flpChat.BackColor = Color.Gainsboro; // لرؤية المساحة بوضوح
        }
    }
}