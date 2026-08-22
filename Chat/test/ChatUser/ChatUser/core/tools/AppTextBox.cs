using ChatUser.core.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.core.tools
{
    

    internal class AppTextBox:TextBox
    {
        string _labelText;
        Label _label= new Label();
        Label _labelShowOrHidePasswordChar = new Label();
        Label _labelTop= new Label();
        TextBoxType? _type;
         public  TextBoxType type { set {
              
                     this.Type(value);
                if (_type == null&& value == TextBoxType.Password && PasswordChar=='\0')
                {
                    PasswordChar = '*';
                }
                _type = value;
                textLabelPasswordChar();

            }
        }
        
        void showOrHidePasswordChar()
        {
            if (_type == TextBoxType.Password)
            {
                if (PasswordChar != '*')
                {
                    PasswordChar = '*';

                }
                else
                {
                    PasswordChar = '\0';

                }
                textLabelPasswordChar();
            }
        }
        void textLabelPasswordChar()
        {
           
           
            if (_type == TextBoxType.Password)
            {
                _labelShowOrHidePasswordChar.Location = new Point(0 , (Height - _label.Height) / 2);
                _labelShowOrHidePasswordChar.Visible = true;
                if (PasswordChar == '*')
                {
                    _labelShowOrHidePasswordChar.Text = "*";

                }
                else
                {
                    _labelShowOrHidePasswordChar.Text = "/*";

                }
            }else
                _labelShowOrHidePasswordChar.Visible = false;

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (Parent!=null)
            Parent.Controls.Add(_labelTop);
            _labelTop.BackColor = Color.Transparent;
            _labelTop.BringToFront();
            updateLocationLabelText();
          

        }

        public string labelText { set { _label.Text = value;_labelTop.Text = value; } get { return _label.Text; } }
       public AppTextBox() { 
        
        Multiline=true;
            Font = new System.Drawing.Font("Tahoma", 10F);

            Height = 35;
            _label.Text = "lableText";
            _labelShowOrHidePasswordChar.Width = 20;
            FontChanged += (s, e) =>
            {
                _labelTop.Font = new System.Drawing.Font("Tahoma", Font.Size-3);
                _label.Font = new System.Drawing.Font("Tahoma", Font.Size - 3);
            };
            _labelTop.Text = "_labelTop";
            _label.TextChanged += (s, e) => updateLocationLabelText();
            SizeChanged += (s, e) => updateLocationLabelText();
            LostFocus += (s, e) => updateLocationLabelText();
            GotFocus += (s, e) => updateLocationLabelText(); 
            TextChanged += (s, e) =>
            {
                
                updateLocationLabelText();

            };
            _label.Click += _label_Click;
            _labelTop.Click += _label_Click;
            _labelShowOrHidePasswordChar.Click += (s, e) => showOrHidePasswordChar();
            _labelShowOrHidePasswordChar.Cursor= Cursors.Hand;
           //KeyDown += (s, e) =>
           //{
           //    if (e.KeyData == Keys.Enter)
           //    {
           //        int index = Parent.Controls.IndexOf(this);
           //        if (index + 1 < Parent.Controls.Count)
           //        {
           //            Parent.Controls[index + 1].Select();
           //        }
           //    }

           //};
           Controls.Add(_label);
            Controls.Add(_labelShowOrHidePasswordChar);



        }
      
        private void _label_Click(object sender, EventArgs e)
        {
            Select();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Parent.Controls.Add(_label);
            updateLocationLabelText();
        }
     
        void updateLocationLabelText()
        {
          
            _label.Visible=!Focused&&String.IsNullOrEmpty(Text);
            _labelTop.Visible = Focused|| !String.IsNullOrEmpty(Text);
            _label.Location = new Point(Width - _label.Width, (Height - _label.Height) / 2);
           
            _labelTop.Location = new Point(Left , Top - ( (int)(_labelTop.Height / 1.7)));
     
             if(IsHandleCreated)
            {
                _labelTop.Height = (int)CreateGraphics().MeasureString(_labelTop.Text, _labelTop.Font).Height;
                //_labelTop.Width = (int)CreateGraphics().MeasureString(_labelTop.Text, _labelTop.Font).Width;
            }
         
            textLabelPasswordChar();

        }
    }
}
