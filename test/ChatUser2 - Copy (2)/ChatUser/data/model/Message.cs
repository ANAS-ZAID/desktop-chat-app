using ChatUser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.data.model
{
    public class Messages:EntityWithFile
    {

        public string content { get; set; }

        public string status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? receiveDate { get; set; }
        public int? sendPhone { get; set; }
        public int? receivePhone { get; set; }
        public int? receiveGroupId { get; set; }
        public string fileName { get; set; }  // اسم الملف
        public string fileData { get; set; }  // محتوى الملف بصيغة Base64
        public override Dictionary<string, object> json => new Dictionary<string, object>()
        {
            {"content",content },
            {"status",status },
            {"startDate",startDate },
            {"receiveDate",receiveDate },
            {"sendPhone",sendPhone },
            {"receivePhone",receivePhone },
            {"receiveGroupId",receiveGroupId },
            {"fileName",fileName },
            {"fileData",ConvertFileToBase64()},
        };
    }
    public class MessagesView:Entity 
    {
        public int sendPhone { get; set; }
        public int receiverId { get; set; }
        public string MessageContent { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        //public byte[] SenderImage { get; set; }
        public string SenderName { get; set; }
        //public byte[] Attachment { get; set; }
        public static List<MessagesView> FromListJson(List<Dictionary<string, object>> listJson) => listJson.Select((j) => new MessagesView() { json=j}).ToList();
        public override Dictionary<string, object> json
        {
            get
            {
         
                return new Dictionary<string, object>()
            {
                { "sendPhone", sendPhone },

                { "Type", Type },
                { "receiverId", receiverId },
                { "MessageContent", MessageContent },
                { "Status", Status },
                { "SentDate", SentDate },
                { "ReceivedDate", ReceivedDate },
                //{ "SenderImage", SenderImage != null ? Convert.ToBase64String(SenderImage) : null },
                //{ "SenderName", SenderName },
                //{ "Attachment", Attachment != null ? Convert.ToBase64String(Attachment) : null }
            };
            }
            set
            {
                if (value == null) return;
                if (value.ContainsKey("id"))
                    id = Convert.ToInt32(value["id"]);
                if (value.ContainsKey("sendPhone"))
                    sendPhone = Convert.ToInt32(value["sendPhone"]);
                if (value.ContainsKey("receiverId"))
                    receiverId = Convert.ToInt32(value["receiverId"]);
                MessageContent = value.ContainsKey("MessageContent") ? value["MessageContent"]?.ToString() : null;
                Status = value.ContainsKey("Status") ? value["Status"]?.ToString() : null;
                Type = value.ContainsKey("Type") ? value["Type"]?.ToString() : null;
                SentDate = value.ContainsKey("SentDate") && !string.IsNullOrEmpty(value["SentDate"]?.ToString())
                    ? DateTime.Parse(value["SentDate"]?.ToString()) : (DateTime?)null;
                ReceivedDate = value.ContainsKey("ReceivedDate") && !string.IsNullOrEmpty(value["ReceivedDate"]?.ToString())
                    ? DateTime.Parse(value["ReceivedDate"]?.ToString()) : (DateTime?)null;
                //SenderImage = value.ContainsKey("SenderImage") && value["SenderImage"] != null
                //    ? Convert.FromBase64String(value["SenderImage"]?.ToString()) : null;
                //SenderName = value.ContainsKey("SenderName") ? value["SenderName"]?.ToString() : null;
                //Attachment = value.ContainsKey("Attachment") && value["Attachment"] != null
                //    ? Convert.FromBase64String(value["Attachment"]?.ToString()) : null;
            }
        }
        public bool isSender=> NetworkService.user.phone==sendPhone;
        public bool isReceiver => NetworkService.user.phone == receiverId;
    }
}
