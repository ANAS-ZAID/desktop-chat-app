using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.Services
{
    internal class Functions
    {
        public static (string, System.Drawing.Image) choseImage()
        {
            System.Drawing.Image image = null;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files|*.png;*.jpg;*.jpeg";//"PDF files (*.pdf)|*.pdf"
            if (DialogResult.OK == dialog.ShowDialog())
            {
                if (!String.IsNullOrEmpty(dialog.FileName))
                {
                    image = System.Drawing.Image.FromFile(dialog.FileName);

                }

            }
            return ( Path.GetFileName(dialog.FileName), image);
        }
    }
}
