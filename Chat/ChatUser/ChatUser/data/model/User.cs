using ChatUser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatUser.data.model
{
    public class Users : EntityWithFile
    {
        public int phone { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string elesName { get; set; }
        public string information { get; set; }
        public bool permission { get; set; } = true;
        public bool publicType { get; set; } = true;
        public int userCode { get; set; }
        public DateTime? lastActive { get; set; }
        public bool active { get; set; } = true;

        public Users() { }
        public static Users fromJson(Dictionary<string, Object> json) => new Users() { json = json };
        public override Dictionary<string, Object> json
        {
            get
            {
                return new Dictionary<string, Object>()
            {
                { "phone", phone },
                { "password", password },
                { "name", name },
                { "elesName", elesName },
                { "information", information },
                { "img", file != null ? Convert.ToBase64String(file) : null },
                { "imagePath", filePath },
                { "userCode", userCode },
                { "permission", permission },
                { "publicType", publicType },
                { "lastActive", lastActive },
                { "active", active }
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
                    if (value.ContainsKey("img"))
                        filePath = value["img"]?.ToString();
                    if (value.ContainsKey("permission") && value["permission"] != null)
                        permission = Convert.ToBoolean(value["permission"]); // تحويل إلى `bool`
                }
            }
        }
        //public bool isSender ()
        //public bool isReceiver => NetworkService.user.phone == receiverId;
    }

}
