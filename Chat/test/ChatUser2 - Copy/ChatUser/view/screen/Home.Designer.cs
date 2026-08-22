namespace ChatUser.view.screen
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cardActiveChat = new ChatUser.core.tools.CustomCard();
            this.appSidBarButton4 = new ChatUser.core.tools.AppSidBarButton();
            this.btnChat = new ChatUser.core.tools.AppSidBarButton();
            this.appSidBarButton2 = new ChatUser.core.tools.AppSidBarButton();
            this.btnGroup = new ChatUser.core.tools.AppSidBarButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.appSidBarButton4);
            this.flowLayoutPanel1.Controls.Add(this.btnChat);
            this.flowLayoutPanel1.Controls.Add(this.appSidBarButton2);
            this.flowLayoutPanel1.Controls.Add(this.btnGroup);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(66, 478);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(60, 47);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.cardActiveChat);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(66, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1164, 50);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(66, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 428);
            this.panel1.TabIndex = 5;
            // 
            // cardActiveChat
            // 
            this.cardActiveChat.BackColor = System.Drawing.Color.White;
            this.cardActiveChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardActiveChat.Date = "";
            this.cardActiveChat.Image = null;
            this.cardActiveChat.ImageCornerRadius = 10;
            this.cardActiveChat.Location = new System.Drawing.Point(743, 3);
            this.cardActiveChat.Name = "cardActiveChat";
            this.cardActiveChat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cardActiveChat.Size = new System.Drawing.Size(354, 44);
            this.cardActiveChat.TabIndex = 0;
            this.cardActiveChat.Title = "العنوان";
            this.cardActiveChat.Visible = false;
            // 
            // appSidBarButton4
            // 
            this.appSidBarButton4.active = false;
            this.appSidBarButton4.FlatAppearance.BorderSize = 0;
            this.appSidBarButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.appSidBarButton4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.appSidBarButton4.Image = global::ChatUser.Properties.Resources.ZondiconsMenu__1_;
            this.appSidBarButton4.Location = new System.Drawing.Point(6, 56);
            this.appSidBarButton4.Name = "appSidBarButton4";
            this.appSidBarButton4.Size = new System.Drawing.Size(57, 50);
            this.appSidBarButton4.TabIndex = 1;
            this.appSidBarButton4.UseVisualStyleBackColor = true;
            // 
            // btnChat
            // 
            this.btnChat.active = false;
            this.btnChat.Image = global::ChatUser.Properties.Resources.MajesticonsChat2TextLine;
            this.btnChat.Location = new System.Drawing.Point(6, 112);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(57, 50);
            this.btnChat.TabIndex = 1;
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // appSidBarButton2
            // 
            this.appSidBarButton2.active = false;
            this.appSidBarButton2.Image = global::ChatUser.Properties.Resources.StreamlinePhoneTelephoneAndroidPhoneMobileDeviceSmartphoneIphone;
            this.appSidBarButton2.Location = new System.Drawing.Point(6, 168);
            this.appSidBarButton2.Name = "appSidBarButton2";
            this.appSidBarButton2.Size = new System.Drawing.Size(57, 50);
            this.appSidBarButton2.TabIndex = 1;
            this.appSidBarButton2.UseVisualStyleBackColor = true;
            this.appSidBarButton2.Click += new System.EventHandler(this.appSidBarButton2_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.active = false;
            this.btnGroup.Image = global::ChatUser.Properties.Resources.ZmdiPortableWifiChanges;
            this.btnGroup.Location = new System.Drawing.Point(6, 224);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(57, 50);
            this.btnGroup.TabIndex = 1;
            this.btnGroup.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 478);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الرئيسية";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private core.tools.AppSidBarButton btnChat;
        private core.tools.AppSidBarButton btnGroup;
        private core.tools.AppSidBarButton appSidBarButton2;
        private core.tools.AppSidBarButton appSidBarButton4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private core.tools.CustomCard cardActiveChat;
    }
}