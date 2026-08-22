using System;
using System.IO;


namespace ChatUser.Services
{
    public class FileHelper
    {
        public static string ConvertFileToBase64(string filePath)
        {

            if (!File.Exists(filePath)) return null;
            byte[] fileBytes = File.ReadAllBytes(filePath);
            return Convert.ToBase64String(fileBytes);
        }
    }
}
