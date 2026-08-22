namespace ChatUser.view.screen
{
    partial class ChatGroup
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
            this.text1 = new ChatUser.core.tools.Text();
            this.SuspendLayout();
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.text1.Location = new System.Drawing.Point(326, 208);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(88, 21);
            this.text1.TabIndex = 0;
            this.text1.Text = "ChatGroup";
            // 
            // ChatGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.text1);
            this.Name = "ChatGroup";
            this.Text = "ChatGroup";
            this.Load += new System.EventHandler(this.ChatGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private core.tools.Text text1;
    }
}