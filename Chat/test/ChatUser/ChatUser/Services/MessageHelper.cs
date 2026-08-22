using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.Services
{
  public  enum MessageHelperType
    {
        success,
        failure,
        error,
        alert

    }
    public class MessageHelper
    {
        public static void show(string message,MessageHelperType helperType=MessageHelperType.success)
        {

            MessageBox.Show(message);
        }
    }
}
