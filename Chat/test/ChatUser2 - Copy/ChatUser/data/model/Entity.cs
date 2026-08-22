using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChatUser.data.model
{
    public class Entity
    {
     public   int id {  get; set; }
        public string name { get; set; }
   virtual  public Dictionary<string, Object> json
    {
        get;
            set;
    }
    }

    public class EntityWithFile:Entity
    {
        public byte[] file { get; set; }
        public string filePath { get; set; }
        public  string ConvertFileToBase64()
        {
            if (!File.Exists(filePath)) return filePath= null;
            byte[] fileBytes = File.ReadAllBytes(filePath);
           return filePath=Convert.ToBase64String(fileBytes);

        }
    }
}
