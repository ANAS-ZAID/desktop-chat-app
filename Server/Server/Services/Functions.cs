using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Services
{
    internal class Functions
    {
        public static (string,System.Drawing.Image) choseImage()
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
            return (dialog.FileName, image);
        }
        //public static System.Drawing.Image saveImage(string path)
        //{
        //    System.Drawing.Image image = choseImage();

        //    path = SharedData.pathImages + path;
        //    if (image != null)
        //    {
        //        if (!Directory.Exists(SharedData.pathImages))
        //            Directory.CreateDirectory(SharedData.pathImages);
        //        // if(File.Exists(path))

        //        image.Save(path);
        //    }

        //    return image;
        //}
        //public static System.Drawing.Image readImage(string path)
        //{
        //    System.Drawing.Image image;
        //    path = SharedData.pathImages + path;
        //    if (File.Exists(path))
        //        image = System.Drawing.Image.FromFile(path);
        //    else
        //        image = null;
        //    return image;
        //}
    }
}
