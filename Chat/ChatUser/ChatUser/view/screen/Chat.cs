using ChatUser.controller;
using ChatUser.core.tools;
using ChatUser.data.model;
using ChatUser.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.view.screen
{
    public partial class Chat : Form
    {
        ChatController controller;

        public Chat(Action<data.model.Chat> onActiveChat)
        {
            InitializeComponent();

            controller = new ChatController(OnUpdate, onActiveChat);
            messagePanel.SizeChanged += MessagePanel_SizeChanged;
            //for (int i = 1; i < 10; i++)
            //{
            //    AddMessageToChat(new MessagesView() {SenderName=(i%2==0)? "Ahmed":"", MessageContent= (i % 2 == 0) ? "ِأحمدأحمدأحمدأحمدأحمدأحمد" : (i*100000).ToString()+ "عليعليعليعليعليعليعليعليعليعلي" });
            //}
            messagePanel.BackColor = ColorTranslator.FromHtml("#FCF5EB");
            panel4.BackColor = ColorTranslator.FromHtml("#EBE9E7");
            messagePanel.SizeChanged += (s, e) =>
            {
                textBox.Width = (int)(messagePanel.Width * .85);
            };

        }

        private void MessagePanel_SizeChanged(object sender, EventArgs e)
        {

            //foreach (Control control in messagePanel.Controls)
            //{
            //    control.Left = control.Left; // إعادة حساب الوضع بناءً على حجم العنصر
            //    control.Width = control.Width; // إعادة حساب العرض بناءً على النص
            //    control.Height = control.Height; // إعادة حساب الارتفاع
            //}

        }

        private void Chat_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            FormBorderStyle = FormBorderStyle.None;
            label1.Location = new Point(panel1.Width - label1.Width, (panel1.Height - label1.Height) / 2);


        }
        void updateChatList()
        {


            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {   flowLayoutPanel1.Controls.Clear();

                    flowLayoutPanel1.Controls.AddRange(CustomCard.buildList(controller.chats, controller.onClickChat));

                }));
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.AddRange(CustomCard.buildList(controller.chats, controller.onClickChat));

            }

        }
        //void AddNewChat()
        //{


        //    if (InvokeRequired)
        //    {
        //        Invoke(new Action(() =>
        //        {
        //            var newChat = CustomCard.buildCard(controller.NewChat, controller.onClickChat);
        //            flowLayoutPanel1.Controls.Clear();
        //            flowLayoutPanel1.Controls.Add();

        //        }));
        //    }
        //    else
        //    {

        //        flowLayoutPanel1.Controls.AddRange(CustomCard.buildList(controller.newChats, controller.onClickChat));

        //    }

        //}
        void showMessagesChat()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {

                    topLastMessage = 0;
                    messagePanel.Controls.Clear();
                    foreach (var message in controller.messagesActiveChat)
                    {
                        AddMessageToChat(message);
                    }
                    messagePanel.AutoScroll = true;
                    messagePanel.HorizontalScroll.Visible = false;
                }));
            }
            else
            {
                messagePanel.Controls.Clear();
                foreach (var message in controller.messagesActiveChat)
                {
                    AddMessageToChat(message);

                }
                topLastMessage = 0;
                messagePanel.AutoScroll = true;
                messagePanel.HorizontalScroll.Visible = false;
            }
        }
        int topLastMessage = 0;
        Padding margin = new Padding(8);

        private void AddMessageToChat(Messages message)
        {
            topLastMessage += margin.Top;


            Label messageLabel = new Label()
            {
                AutoSize = true,
                MaximumSize = new Size(250, 0),
                Text = message.content,
                Font = new Font("Arial", 12.5f),
                Padding = new Padding(5),
                ForeColor = Color.Black,


            };


            Panel box = new Panel()
            {
                Name = message.id.ToString(),
                BackColor = message.isSender ? ColorTranslator.FromHtml("#43DA78") : Color.White,
                Padding = new Padding(5),
                AutoSize = true,

            };


            box.Controls.Add(messageLabel);

            Label date = new Label()
            {
                Text = message.sentDate.ToString("hh:mm tt"),
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font("Arial", 8, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft
            };


            box.Controls.Add(date);


            Label read = null;
            if (message.isSender)
            {
                read = new Label()
                {
                    Name = "read",
                    Text = message.isUnread ? "✔️" : message.isReceived ? "✔️✔️" : "⏳",
                    AutoSize = true,
                    ForeColor = message.isRead ? Color.Aqua : Color.Black,
                    Font = new Font("Arial", 8, FontStyle.Italic),

                };
                box.Controls.Add(read);
            }


            box.Width = messageLabel.Width + 20;
            box.Height = messageLabel.Height + 5 + date.Height;


            box.Top = topLastMessage;

            date.Top = messageLabel.Bottom + 2;
            if (message.isSender)
            {
                read.Left = 5;
                read.Top = date.Top;
                date.Left = read.Right + 5;
            }
            else
            {
                date.Left = 5;
            }

            date.BringToFront();
            read?.BringToFront();
            messageLabel.Left = box.Width - messageLabel.Width + (read?.Width ?? 5) + 30;

            if (InvokeRequired)
            {
                Invoke(new Action(() => {
                    messagePanel.Controls.Add(box);

                    box.Left = message.isSender
                  ? margin.Left
                  : messagePanel.Width - box.Width - (margin.Right * 2);


                }));
            }
            else
            {
                messagePanel.Controls.Add(box);
                box.Left = message.isSender
              ? margin.Left
              : messagePanel.Width - box.Width - (margin.Right * 2);
            }



            topLastMessage += box.Height + margin.Bottom;


            //messagePanel.AutoScroll = true;
            //messagePanel.HorizontalScroll.Visible = false;
            messagePanel.Resize += (sender, e) =>
            {
                if (message.isSender)
                {
                    box.Left = margin.Left;
                }
                else
                {
                    box.Left = messagePanel.Width - box.Width - margin.Right;
                }
                messagePanel.AutoScroll = true;
                messagePanel.HorizontalScroll.Visible = false;
            };

        }


        public void OnUpdate(string action)
        {
            switch (action)
            {
                case "updateChatList":
                    updateChatList();
                    break;
                case "showMessagesChat":
                    showMessagesChat();
                    break;
                case "updateShowMessages":
                    updateShowMessages();
                    break;
                case "AddNewMessageToChat":
                    AddNewMessageToChat();
                    break;
                //case "updateChatList":
                //    updateChatList();
                //    break;
                //case "Notification":
                //    if (response.header["NotificationType"].ToString() == "newMessage")
                //        if (!response.body.Any()) return;

                //    AddMessageToChat();
                //    break;
                default:
                    break;
            }

        }

        void AddNewMessageToChat()
        {

            AddMessageToChat(controller.NewMessageActiveChat);
        }
        private void updateShowMessages()
        {
            if (!controller.updatedMessagesActiveChat.Any()) return;
          
            ////List<MessagesView> olde = null;
            ////List<MessagesView> newMessages = null;
            ////List<MessagesView> newMessages = null;

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {

                    foreach (Control control in messagePanel.Controls)
                    {
                        int? id = null;

                        if (!string.IsNullOrEmpty(control.Name))
                            id = Convert.ToInt32(control.Name);
                        if (!id.HasValue || id == -1)
                        {
                            //MessageBox.Show("updateShowMessages");
                            var read = control.Controls["read"];
                            if (read != null)
                            {
                                var message = controller.updatedMessagesActiveChat.First();
                                read.Text = message.isUnread ? "✔️" : message.isReceived ? "✔️✔️" : "⏳";
                                //MessageBox.Show("updateShowMessages" + message.isUnread);
                                read.ForeColor = message.isRead ? Color.Aqua : Color.Black;

                            }
                        }

                    }

                }));
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text)) return;

            AddMessageToChat(controller.AddNewMessageToChat(textBox.Text));
            textBox.Clear();
            textBox.Focus();
            if (!messagePanel.AutoScroll)
            {
                messagePanel.AutoScroll = true;
                messagePanel.HorizontalScroll.Visible = false;
            }


        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text) && e.KeyChar == (char)Keys.Enter)
            {
                btnSend.PerformClick();
                e.Handled = true;
            }
        }

    }
}
