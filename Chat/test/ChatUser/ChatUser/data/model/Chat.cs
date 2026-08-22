using ChatUser.Services;
using ChatUser.view.screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.data.model
{
    public class Chat:Entity
    {

        public int id { get; set; }
        public int chatId { get; set; }
        public string content {  get; set; }
        public string status {  get; set; }
        public string chatName { get; set; }
        public byte[] chatImage { get; set; }
        public DateTime sentDate { get; set; }
         public DateTime? chatLastSeen { get; set; }
        //public int sendPhone {  get; set; }
        public bool chatActive {  get; set; }
        public bool publicType { get; set; }
        public int userCode { get; set; }


        //id, MessageContent, SentDate, SenderName, ReceiverName, GroupName,
        public static Chat fromJson(Dictionary<string, object> json)=>new Chat() { json = json };
        public static List<Chat> fromListJson(List<Dictionary<string, object>> listJson)=> listJson.Select((j)=>fromJson(j)).ToList();
        public override Dictionary<string, object> json
        {
            get
            {
                return new Dictionary<string, object>()
            {
                { "id", id },
                { "chatId", chatId },
                { "content", content },
                { "status", status },
                { "chatName", chatName },
                { "sentDate", sentDate },
                { "chatLastSeen", chatLastSeen},
                { "chatActive", chatActive }
            };
            }
            set
            {

                if(value == null) return;
                if (value.ContainsKey("id"))
                    id = Convert.ToInt32(value["id"]);
                if (value.ContainsKey("chatId"))
                    chatId = Convert.ToInt32(value["chatId"]);
               
                if (value.ContainsKey("content"))
                    content = value["content"]?.ToString();
                if (value.ContainsKey("status"))
                    status = value["status"]?.ToString();
                if (value.ContainsKey("chatName"))
                    chatName = value["chatName"]?.ToString();

                if (value.ContainsKey("sentDate") && !string.IsNullOrEmpty(value["sentDate"]?.ToString()))
                    sentDate = Convert.ToDateTime(value["sentDate"]);
                if (value.ContainsKey("chatLastSeen") && !string.IsNullOrEmpty(value["chatLastSeen"]?.ToString()))
                    sentDate = Convert.ToDateTime(value["chatLastSeen"]);

                if (value.ContainsKey("chatActive") && !string.IsNullOrEmpty(value["chatActive"]?.ToString()))
                    chatActive = Convert.ToBoolean(value["chatActive"]);
                if (value.ContainsKey("ChatImage") && !string.IsNullOrEmpty(value["ChatImage"]?.ToString()))
                    chatImage = Convert.FromBase64String(value["ChatImage"].ToString());
            }
        }
        //public bool isSender => NetworkService.user.phone == sendPhone;
        //public bool isReceiver => NetworkService.user.phone == ChatId;
        //id, MessageContent, SentDate, SenderName, ReceiverName, GroupName,ChatImage
    }
}
