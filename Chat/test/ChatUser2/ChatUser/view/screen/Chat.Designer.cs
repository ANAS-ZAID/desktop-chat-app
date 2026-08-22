namespace ChatUser.view.screen
{
    partial class Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.appTextBox1 = new ChatUser.core.tools.AppTextBox();
            this.textBox = new ChatUser.core.tools.AppTextBox();
            this.btnSend = new ChatUser.core.tools.AppSidBarButton();
            this.appSidBarButton1 = new ChatUser.core.tools.AppSidBarButton();
            this.appButton2 = new ChatUser.core.tools.AppButton();
            this.appButton1 = new ChatUser.core.tools.AppButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.appButton2);
            this.panel1.Controls.Add(this.appButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 40);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "المحادثات";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(369, 549);
            this.panel3.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 103);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(369, 446);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.appTextBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 63);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSend);
            this.panel4.Controls.Add(this.textBox);
            this.panel4.Controls.Add(this.appSidBarButton1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(369, 505);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(853, 44);
            this.panel4.TabIndex = 13;
            // 
            // messagePanel
            // 
            this.messagePanel.BackColor = System.Drawing.SystemColors.Control;
            this.messagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messagePanel.Location = new System.Drawing.Point(369, 0);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(853, 505);
            this.messagePanel.TabIndex = 14;
            // 
            // appTextBox1
            // 
            this.appTextBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.appTextBox1.labelText = "بحث أو بدء محادثه جديده";
            this.appTextBox1.Location = new System.Drawing.Point(22, 14);
            this.appTextBox1.Multiline = true;
            this.appTextBox1.Name = "appTextBox1";
            this.appTextBox1.Size = new System.Drawing.Size(329, 35);
            this.appTextBox1.TabIndex = 4;
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox.Font = new System.Drawing.Font("Tahoma", 10F);
            this.textBox.labelText = "lableText";
            this.textBox.Location = new System.Drawing.Point(59, 0);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(742, 44);
            this.textBox.TabIndex = 3;
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.active = false;
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSend.Image = global::ChatUser.Properties.Resources.FluentMdl2SendMirrored;
            this.btnSend.Location = new System.Drawing.Point(3, 0);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(56, 44);
            this.btnSend.TabIndex = 6;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // appSidBarButton1
            // 
            this.appSidBarButton1.active = false;
            this.appSidBarButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.appSidBarButton1.Image = ((System.Drawing.Image)(resources.GetObject("appSidBarButton1.Image")));
            this.appSidBarButton1.Location = new System.Drawing.Point(801, 0);
            this.appSidBarButton1.Name = "appSidBarButton1";
            this.appSidBarButton1.Size = new System.Drawing.Size(52, 44);
            this.appSidBarButton1.TabIndex = 2;
            this.appSidBarButton1.UseVisualStyleBackColor = true;
            // 
            // appButton2
            // 
            this.appButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.appButton2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.appButton2.Image = ((System.Drawing.Image)(resources.GetObject("appButton2.Image")));
            this.appButton2.Location = new System.Drawing.Point(47, 0);
            this.appButton2.Name = "appButton2";
            this.appButton2.Size = new System.Drawing.Size(47, 40);
            this.appButton2.TabIndex = 2;
            this.appButton2.UseVisualStyleBackColor = true;
            // 
            // appButton1
            // 
            this.appButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.appButton1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.appButton1.Image = ((System.Drawing.Image)(resources.GetObject("appButton1.Image")));
            this.appButton1.Location = new System.Drawing.Point(0, 0);
            this.appButton1.Name = "appButton1";
            this.appButton1.Size = new System.Drawing.Size(47, 40);
            this.appButton1.TabIndex = 1;
            this.appButton1.UseVisualStyleBackColor = true;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 549);
            this.Controls.Add(this.messagePanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Chat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Chat";
            this.Load += new System.EventHandler(this.Chat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private core.tools.AppButton appButton1;
        private core.tools.AppButton appButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private core.tools.AppTextBox appTextBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel messagePanel;
        private core.tools.AppSidBarButton btnSend;
        private core.tools.AppTextBox textBox;
        private core.tools.AppSidBarButton appSidBarButton1;
    }
}