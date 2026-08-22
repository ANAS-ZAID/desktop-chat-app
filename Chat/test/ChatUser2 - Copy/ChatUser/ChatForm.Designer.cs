namespace ChatUser
{
    partial class ChatForm
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
            this.flpChat = new System.Windows.Forms.FlowLayoutPanel();
            this.appButton1 = new ChatUser.core.tools.AppButton();
            this.txtMessage = new ChatUser.core.tools.AppTextBox();
            this.SuspendLayout();
            // 
            // flpChat
            // 
            this.flpChat.AutoScroll = true;
            this.flpChat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flpChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChat.Location = new System.Drawing.Point(0, 0);
            this.flpChat.Name = "flpChat";
            this.flpChat.Size = new System.Drawing.Size(800, 400);
            this.flpChat.TabIndex = 1;
            // 
            // appButton1
            // 
            this.appButton1.Location = new System.Drawing.Point(0, 406);
            this.appButton1.Name = "appButton1";
            this.appButton1.Size = new System.Drawing.Size(75, 32);
            this.appButton1.TabIndex = 2;
            this.appButton1.Text = "appButton1";
            this.appButton1.UseVisualStyleBackColor = true;
            this.appButton1.Click += new System.EventHandler(this.appButton1_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMessage.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMessage.labelText = "lableText";
            this.txtMessage.Location = new System.Drawing.Point(0, 400);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(800, 50);
            this.txtMessage.TabIndex = 0;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.appButton1);
            this.Controls.Add(this.flpChat);
            this.Controls.Add(this.txtMessage);
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private core.tools.AppTextBox txtMessage;
        private System.Windows.Forms.FlowLayoutPanel flpChat;
        private core.tools.AppButton appButton1;
    }
}