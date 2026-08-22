using ChatUser.core.tools;
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
    public partial class Home : Form
    {
        Chat chat;
        ChatGroup chatGroup;
        AppSidBarButton _activeBtn;
    
        AppSidBarButton activeBtn { set
            {
                if (_activeBtn != null)
                {
                    _activeBtn.active = false;
                }
                _activeBtn = value;
                _activeBtn.active=true;
            }
        }
        //Form? activeForm;
        public Home()
        {
            InitializeComponent();
            activeBtn = appSidBarButton4;



        }

        private void Home_Load(object sender, EventArgs e)
        {
           
        }
        void hidePanel()
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;

            }
        }
        public void onCardActiveChat(data.model.Chat chat) {
         
            var c = CustomCard.buildCard(chat);
            c.Date = "";
            cardActiveChat.Title =c.Title;
            cardActiveChat.Image =c.Image;
            if (!cardActiveChat.Visible)
                cardActiveChat.Show();
        }
        private void btnChat_Click(object sender, EventArgs e)
        {
            //if (activeForm != null)
            //{
            //    activeForm.Close();
            //}
            activeBtn=btnChat;
              hidePanel();
            if (chat==null)
            {
                chat = new Chat(onCardActiveChat);
                chat.MdiParent = this;
                chat.Show();
               
            }
            else
            {
                if(!chat.Visible) 
                    chat.Show();
                
            }
            if (chatGroup != null)
                chatGroup.Hide();
        }

        private void appSidBarButton2_Click(object sender, EventArgs e)
        {
            activeBtn = appSidBarButton2;
            hidePanel();
            if (chatGroup == null)
            {
                chatGroup = new ChatGroup();
                chatGroup.MdiParent = this;
                chatGroup.Show();

            }
            else
            {
                if (!chatGroup.Visible)
                    chatGroup.Show();

            }
            if (chat != null)
                chat.Hide();
        }
    }
}
