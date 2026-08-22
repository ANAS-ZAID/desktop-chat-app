using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Server.Models
{
    public class Users : EntityWithFile
    {
        protected override string directory => "Users";
        public int phone { get; set; }
        public string password { get; set; }
        public string elesName { get; set; }
        public string information { get; set; }

        public bool permission { get; set; }=true;
        public bool publicType { get; set; }
        public int userCode {  get; set; }
        public Users() { }
        public static Users fromJson(Dictionary<string, Object> json) => new Users() { json = json };
        public void HashPassword()
        {
            password = PasswordHasher.HashPassword(password);
        }
        //public bool VerifyPassword(string password) => PasswordHasher.VerifyPassword(this. password, password);
        override public Dictionary<string, Object> json
        {
            get
            {
                return new Dictionary<string, Object>()
                {

                    {
                        "phone",
                        phone
                    },
                    {
                        "password",
                        password
                    },
                    {
                        "name",
                        name
                    },
                    {
                        "elesName",
                        elesName
                    },
                    {
                        "information",
                        information
                    },
                    {
                 "img",//imagePath
                 filePath
                      },
                      {
                        "userCode",userCode
                    },
                    {
                        "permission",permission
                    },
                    {
                        "publicType",publicType
                    },
                };
            }
            set
            {
                if (value != null)
                {
                    if (value.ContainsKey("phone") && value["phone"] != null)
                        phone = Convert.ToInt32(value["phone"]); // تحويل إلى int

                    if (value.ContainsKey("password") && value["password"] != null)
                        password = value["password"].ToString();

                    if (value.ContainsKey("name") && value["name"] != null)
                        name = value["name"].ToString();

                    if (value.ContainsKey("elesName") && value["elesName"] != null)
                        elesName = value["elesName"].ToString();

                    if (value.ContainsKey("information") && value["information"] != null)
                        information = value["information"].ToString();

                    if (value.ContainsKey("imagePath"))
                        filePath = value["imagePath"]?.ToString();
                    if (value.ContainsKey("img") && value["img"] != null)
                        file = Convert.FromBase64String(value["img"].ToString());
                   
                    if (value.ContainsKey("permission") && value["permission"] != null)
                        permission = Convert.ToBoolean(value["permission"]); // تحويل إلى `bool`

                    if (value.ContainsKey("publicType") && value["publicType"] != null)
                        publicType = Convert.ToBoolean(value["publicType"]); // تحويل إلى `bool`
                }
            }
        }
    }
}
