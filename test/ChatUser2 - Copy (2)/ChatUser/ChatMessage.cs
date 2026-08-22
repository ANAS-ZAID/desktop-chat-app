using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser
{
    public partial class ChatMessage : UserControl
    {
        Label lblMessage=new Label();
        public ChatMessage()
        {
            //InitializeComponent();

            lblMessage.MaximumSize = new Size(250, 0);
        }

        public string MessageText
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }
    }
}
