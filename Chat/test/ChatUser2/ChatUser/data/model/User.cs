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
        }
    }

}
