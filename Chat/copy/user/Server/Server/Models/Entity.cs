using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Models
{
    public class Entity
    {
        public int id { get; set; }
        public string name { get; set; }
        virtual public Dictionary<string, Object> json { get; set; }
    }

    public class EntityWithFile : Entity
    {
        virtual protected string directory => "EntityWithFile";
        private string directoryPath => Path.Combine("UploadedFiles", directory);
        private string path => Path.Combine(directoryPath, filePath);
        public byte[] file { get; set; }
        public string filePath { get; set; }

        // حذف الملف إذا كان موجودًا
        public void deleteFile()
        {
            if (file == null || string.IsNullOrEmpty(filePath) || !File.Exists(path))
                return;

            File.Delete(path);
        }

        // توليد مسار فريد للملف
        public string GenerateUniqueFilePath()
        {
            Random random = new Random();
            string newPath;
            bool isUnique;

            do
            {
                // استخدام التاريخ والوقت مع الأرقام العشوائية
                int randomNumber = random.Next(100000, 999999);
                newPath = $"file-{directory}-{randomNumber}-{DateTime.Now:yyyyMMddHHmmssfff}{Path.GetExtension(filePath)}";
                // تحقق مما إذا كان الملف موجودًا
                isUnique = !File.Exists(Path.Combine(directoryPath, newPath));
            } while (!isUnique); // كرر العملية حتى تجد مسار فريد

            return newPath;
        }

     
        public bool saveFile()
        {
            if (file == null || string.IsNullOrEmpty(filePath))
                return true;

     
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
      
            string newFilePath = GenerateUniqueFilePath(); 


            try
            {
                using (FileStream fileStream = new FileStream(Path.Combine(directoryPath, newFilePath), FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(file, 0, file.Length); 
                }
                filePath = newFilePath;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء حفظ الملف: {ex.Message}");
                return false;
            }
        }

        // قراءة الملف من المسار المحدد
        public void readFile()
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(path))
                return;

            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    file = new byte[fileStream.Length];
                    fileStream.Read(file, 0, (int)fileStream.Length); // قراءة محتوى الملف إلى مصفوفة البايت
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء قراءة الملف: {ex.Message}");
            }
        }
    }
}
