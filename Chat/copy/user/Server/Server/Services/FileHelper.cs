using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Services
{
    internal class FileHelper
    {
        static void SaveFileFromBase64(string base64Data, string filePath)
        {
            try
            {
                byte[] fileBytes = Convert.FromBase64String(base64Data);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // إنشاء المجلد إذا لم يكن موجودًا
                File.WriteAllBytes(filePath, fileBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ خطأ أثناء حفظ الملف: " + ex.Message);
            }
        }
        public static string ConvertFileToBase64(string filePath)
        {
            //string basePath = @"C:\Users\Basha\source\repos\Chat\Server\Server\bin\Debug\UploadedFiles\Users";
            //string fileName = "file-Users-277924-20250221231316883.png";
            //filePath = "UploadedFiles\\Users\\Screenshot 2024-08-17 181519.png";
            if (string.IsNullOrEmpty(filePath) )
                return null;
            filePath = Path.GetFullPath(filePath);
            try
            {
                byte[] fileBytes;
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    fileBytes = new byte[fs.Length];
                    fs.Read(fileBytes, 0, fileBytes.Length);
                    //MessageBox.Show((fs.Length).ToString());
                }
                return Convert.ToBase64String(fileBytes);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
