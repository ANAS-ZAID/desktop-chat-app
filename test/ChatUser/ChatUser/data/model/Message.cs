using ChatUser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.data.model
{
    public class Messages : EntityWithFile
    {
        public string content { get; set; }
        public string status { get; set; }
        public DateTime sentDate { get; set; }
        public DateTime? receivedDate { get; set; }
        public int? senderPhone { get; set; }
        public int? receiverPhone { get; set; }
        public static List<Messages> fromListJson(List<Dictionary<string, object>> listJson) => listJson.Select((j) => new Messages() { json = j }).ToList();
        public override Dictionary<string, object> json
        {
            get
            {

                return new Dictionary<string, object>()
            {
         {"content",content },
         {"status",status },
         {"sentDate",sentDate },
         {"receivedDate",receivedDate },
         {"senderPhone",senderPhone },
         {"receiverPhone",receiverPhone },

             };
            }
            set
            {
                if (value == null || !value.ContainsKey("senderPhone")) return;
                senderPhone = Convert.ToInt32(value["senderPhone"]);
                receiverPhone = Convert.ToInt32(value["receiverPhone"]);
                content = value.ContainsKey("content") ? value["content"]?.ToString() : null;
                status = value.ContainsKey("status") ? value["status"]?.ToString() : null;
                sentDate = value.ContainsKey("sentDate") ? Convert.ToDateTime(value["sentDate"]) : DateTime.Now;
                receivedDate = value.ContainsKey("receivedDate") ? Convert.ToDateTime(value["receivedDate"] ?? DateTime.Now) : DateTime.Now;
            }
        }
        public bool isSender => NetworkService.user.phone == senderPhone;
        public bool isReceiver => NetworkService.user.phone == receiverPhone;
        public bool isUnread => status == "unread";
        public bool isRead => status == "read";
        public bool isReceived => status == "received";


    }
}
