using ChatUser.core.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ChatUser.core.classes
{
    static internal class ValidatingData
    {
        static public void Type(this AppTextBox control, TextBoxType type)
        {
            switch (type) { 
            
            case TextBoxType.Number:
                    control.NumberOnly();
                    break;
                case TextBoxType.Phone:
                    control.PhoneOnly();
                    break;
                case TextBoxType.Text:
                    control.TextOnly();
                    break;

                default:
                  
                    break;
            }
        }
        static public void NumberOnly(this AppTextBox control)
        {
            control.KeyPress += Control_KeyPress;
         
            void Control_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }

        }
        public static void PhoneOnly(this AppTextBox control)
        {
            control.MaxLength = 9;
            control.KeyPress += Control_KeyPress;

            void Control_KeyPress(object sender, KeyPressEventArgs e)
            {
                // السماح دائمًا بمفاتيح التحكم (مثل Backspace/Delete)
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                    return;
                }

                // منع إدخال أي شيء غير رقم
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                // إنشاء النص المؤقت مع الحرف الجديد
                string newText = control.Text.Insert(control.SelectionStart, e.KeyChar.ToString());

                // التحقق من الحرف الأول
                if (newText.Length == 1 && newText[0] != '7')
                {
                    //MessageBox.Show("يجب أن يبدأ الرقم بـ 7");
                    e.Handled = true;
                    return;
                }

                // التحقق من البداية الصحيحة عند الحرف الثاني
                if (newText.Length >= 2 && !IsValidPhoneStart(newText))
                {
                    //MessageBox.Show("يجب أن يبدأ الرقم بـ: 73, 77, 70, 71, 78, 79");
                    e.Handled = true;
                }
            }

            bool IsValidPhoneStart(string phone)
            {
                string[] validStarts = { "73", "77", "70", "71", "78" };
                return validStarts.Any(start => phone.StartsWith(start));
            }
        }

        static public void TextOnly(this AppTextBox control)
        {
            control.KeyPress += Control_KeyPress;
           
            void Control_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space)
                    e.Handled = true;
            }
        }



        static public bool validate(string text, string message = "البيانات", int minLength = 0, int? maxLength = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show($"يجب ادخال {message}");
                return false;
            }
            if (text.Length < minLength)
            {
                MessageBox.Show($"يجب ادخال {message} بطول لا يقل عن {minLength} أحرف");
                return false;
            }
            if (maxLength.HasValue && text.Length > maxLength.Value)
            {
                MessageBox.Show($"يجب ألا يتجاوز {message} الطول {maxLength.Value} أحرف");
                return false;
            }
            return true;
        }

    }
    enum TextBoxType
    {
        Text,
        Phone,
        Number,
        Password

    }
}
