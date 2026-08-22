using ChatUser.controller;
using ChatUser.core.classes;
using ChatUser.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.view.screen
{
    public partial class SignIn : Form
    {
        AuthController controller;

        OpenFileDialog openFileDialog;

        (string, Image) img;
        public SignIn()
        {
            InitializeComponent();
            controller = new AuthController(OnMessageReceived);
            phone.type =  TextBoxType.Phone;
             name.type =  TextBoxType.Text;
             elesName.type =  TextBoxType.Text;
              password.type = TextBoxType.Password;   
            showOrHideSinUp();
     
        }
        public  void OnMessageReceived(JsonResponse response)
        {

            if ( response.Status)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { this.Hide(); (new Home()).Show(); }));
                }
                else
                {
                    this.Hide();
                    (new Home()).Show();
                }

                }
            }
            void showOrHideSinUp()
        {
            phone.Select();
            panelSinUp.Visible = controller.isSinUp;
            if (controller.isSinIn)
            {
                titel.Text = "تسجيل الدخول";
                submit.Top = panelSinUp.Top + 10;
                submit.Text = "تسجيل";
                changeAuth.Text = "هل تريد إنشاء حساب ؟";

            }
            else
            {
                titel.Text = "إنشاء حساب";
                submit.Top = panelSinUp.Top + panelSinUp.Height + 10;
                submit.Text = "إنشاء";
                changeAuth.Text = "هل تريد تسجيل الدخول ؟";

            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            controller.processing(phone.Text, password.Text,name.Text,elesName.Text,information.Text,img);
        }

        private void changeAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controller.changeAuth();
            showOrHideSinUp();
          
           
        }

        private void picture_Click(object sender, EventArgs e)
        {
          img=Functions.choseImage();
            //if (img.Item2!=null)
            {
                picture.Image = img.Item2;
            }
           
        }

        private void publicType_CheckedChanged(object sender, EventArgs e)
        {
            controller.changePublicType(publicType.Checked);
        }
    }
   

   
}
