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
    public partial class ChatGroup : Form
    {
        public ChatGroup()
        {
            InitializeComponent();

        }


        private void ChatGroup_Load(object sender, EventArgs e)
        {
            Dock= DockStyle.Fill;
            FormBorderStyle = FormBorderStyle.None;
       
        }
    }
}
