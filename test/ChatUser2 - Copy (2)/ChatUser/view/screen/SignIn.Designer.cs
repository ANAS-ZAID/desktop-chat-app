namespace ChatUser.view.screen
{
    partial class SignIn
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
            this.changeAuth = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picture = new System.Windows.Forms.PictureBox();
            this.panelSinUp = new System.Windows.Forms.Panel();
            this.publicType = new System.Windows.Forms.RadioButton();
            this.privateType = new System.Windows.Forms.RadioButton();
            this.text2 = new ChatUser.core.tools.Text();
            this.text1 = new ChatUser.core.tools.Text();
            this.information = new ChatUser.core.tools.AppTextBox();
            this.elesName = new ChatUser.core.tools.AppTextBox();
            this.name = new ChatUser.core.tools.AppTextBox();
            this.appButton1 = new ChatUser.core.tools.AppButton();
            this.submit = new ChatUser.core.tools.AppButton();
            this.phone = new ChatUser.core.tools.AppTextBox();
            this.password = new ChatUser.core.tools.AppTextBox();
            this.titel = new ChatUser.core.tools.Text();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.panelSinUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // changeAuth
            // 
            this.changeAuth.AutoSize = true;
            this.changeAuth.Location = new System.Drawing.Point(131, 574);
            this.changeAuth.Name = "changeAuth";
            this.changeAuth.Size = new System.Drawing.Size(142, 17);
            this.changeAuth.TabIndex = 29;
            this.changeAuth.TabStop = true;
            this.changeAuth.Text = "هل تريد إنشاء حساب ؟";
            this.changeAuth.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.changeAuth_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(405, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(387, 442);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // picture
            // 
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.Location = new System.Drawing.Point(14, 178);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(199, 80);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture.TabIndex = 40;
            this.picture.TabStop = false;
            this.picture.Click += new System.EventHandler(this.picture_Click);
            // 
            // panelSinUp
            // 
            this.panelSinUp.Controls.Add(this.privateType);
            this.panelSinUp.Controls.Add(this.publicType);
            this.panelSinUp.Controls.Add(this.text2);
            this.panelSinUp.Controls.Add(this.text1);
            this.panelSinUp.Controls.Add(this.picture);
            this.panelSinUp.Controls.Add(this.information);
            this.panelSinUp.Controls.Add(this.elesName);
            this.panelSinUp.Controls.Add(this.name);
            this.panelSinUp.Location = new System.Drawing.Point(92, 198);
            this.panelSinUp.Name = "panelSinUp";
            this.panelSinUp.Size = new System.Drawing.Size(224, 313);
            this.panelSinUp.TabIndex = 30;
            this.panelSinUp.Visible = false;
            // 
            // publicType
            // 
            this.publicType.AutoSize = true;
            this.publicType.Checked = true;
            this.publicType.Location = new System.Drawing.Point(98, 279);
            this.publicType.Name = "publicType";
            this.publicType.Size = new System.Drawing.Size(49, 21);
            this.publicType.TabIndex = 141;
            this.publicType.TabStop = true;
            this.publicType.Text = "عام";
            this.publicType.UseVisualStyleBackColor = true;
            this.publicType.CheckedChanged += new System.EventHandler(this.publicType_CheckedChanged);
            // 
            // privateType
            // 
            this.privateType.AutoSize = true;
            this.privateType.Location = new System.Drawing.Point(14, 279);
            this.privateType.Name = "privateType";
            this.privateType.Size = new System.Drawing.Size(58, 21);
            this.privateType.TabIndex = 141;
            this.privateType.Text = "خاص";
            this.privateType.UseVisualStyleBackColor = true;
            this.privateType.CheckedChanged += new System.EventHandler(this.publicType_CheckedChanged);
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text2.Location = new System.Drawing.Point(163, 279);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(43, 21);
            this.text2.TabIndex = 44;
            this.text2.Text = "النوع";
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text1.Location = new System.Drawing.Point(97, 152);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(54, 21);
            this.text1.TabIndex = 44;
            this.text1.Text = "الصورة";
            // 
            // information
            // 
            this.information.Font = new System.Drawing.Font("Tahoma", 10F);
            this.information.labelText = "المعلومات الشخصية";
            this.information.Location = new System.Drawing.Point(12, 59);
            this.information.Multiline = true;
            this.information.Name = "information";
            this.information.Size = new System.Drawing.Size(201, 35);
            this.information.TabIndex = 36;
            // 
            // elesName
            // 
            this.elesName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.elesName.labelText = "الأسم الظاهر";
            this.elesName.Location = new System.Drawing.Point(12, 110);
            this.elesName.Multiline = true;
            this.elesName.Name = "elesName";
            this.elesName.Size = new System.Drawing.Size(201, 35);
            this.elesName.TabIndex = 34;
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.name.labelText = "الأسم";
            this.name.Location = new System.Drawing.Point(12, 9);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(201, 35);
            this.name.TabIndex = 35;
            // 
            // appButton1
            // 
            this.appButton1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.appButton1.Location = new System.Drawing.Point(339, 12);
            this.appButton1.Name = "appButton1";
            this.appButton1.Size = new System.Drawing.Size(60, 32);
            this.appButton1.TabIndex = 28;
            this.appButton1.Text = "عوده";
            this.appButton1.UseVisualStyleBackColor = true;
            this.appButton1.Visible = false;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Tahoma", 10F);
            this.submit.Location = new System.Drawing.Point(136, 520);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(127, 41);
            this.submit.TabIndex = 28;
            this.submit.Text = "تسجيل الدخول";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("Tahoma", 10F);
            this.phone.labelText = "رقم الهاتف";
            this.phone.Location = new System.Drawing.Point(101, 106);
            this.phone.Multiline = true;
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(201, 35);
            this.phone.TabIndex = 17;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Tahoma", 10F);
            this.password.labelText = "كلمة المرور";
            this.password.Location = new System.Drawing.Point(101, 157);
            this.password.Multiline = true;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(201, 35);
            this.password.TabIndex = 17;
            // 
            // titel
            // 
            this.titel.AutoSize = true;
            this.titel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.titel.Location = new System.Drawing.Point(132, 47);
            this.titel.Name = "titel";
            this.titel.Size = new System.Drawing.Size(116, 21);
            this.titel.TabIndex = 8;
            this.titel.Text = "تسجيل الدخول";
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 603);
            this.Controls.Add(this.panelSinUp);
            this.Controls.Add(this.changeAuth);
            this.Controls.Add(this.appButton1);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.password);
            this.Controls.Add(this.titel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SignIn";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignIn";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.panelSinUp.ResumeLayout(false);
            this.panelSinUp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private core.tools.Text titel;
        private core.tools.AppTextBox password;
        private core.tools.AppTextBox phone;
        private core.tools.AppButton submit;
        private System.Windows.Forms.LinkLabel changeAuth;
        private core.tools.AppButton appButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private core.tools.AppTextBox name;
        private core.tools.AppTextBox elesName;
        private core.tools.AppTextBox information;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Panel panelSinUp;
        private core.tools.Text text1;
        private System.Windows.Forms.RadioButton publicType;
        private System.Windows.Forms.RadioButton privateType;
        private core.tools.Text text2;
    }
}