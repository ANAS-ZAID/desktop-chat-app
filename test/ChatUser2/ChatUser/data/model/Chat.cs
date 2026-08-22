using ChatUser.Services;
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

        public int ChatId { get; set; }
        public string messageContent {  get; set; }
        public string title { get; set; }
        public string messageType { get; set; }
        public byte[] chatImage { get; set; }
        public DateTime sentDate { get; set; }
        public int sendPhone {  get; set; }
        

        //id, MessageContent, SentDate, SenderName, ReceiverName, GroupName,
        public static Chat fromJson(Dictionary<string, object> json)=>new Chat() { json = json };
        public static List<Chat> fromListJson(List<Dictionary<string, object>> listJson)=> listJson.Select((j)=>fromJson(j)).ToList();
        public override Dictionary<string, object> json
        {
            get
            {
                return new Dictionary<string, object>()
            {
                { "ChatId", ChatId },
                { "sendPhone", sendPhone },
                { "MessageContent", messageContent },
                { "MessageType", messageType },
                { "Title", title },
                { "SentDate", sentDate != DateTime.MinValue ? sentDate.ToString("yyyy-MM-ddTHH:mm:ss") : null },
                { "ChatImage", chatImage != null ? Convert.ToBase64String(chatImage) : null }
            };
            }
            set
            {

                if(value == null) return;
                if (value.ContainsKey("ChatId"))
                    ChatId = Convert.ToInt32(value["ChatId"]);
                if (value.ContainsKey("SenderPhone"))
                {
                    //MessageBox.Show($"SenderPhone:{value["SenderPhone"]}");
                    sendPhone = Convert.ToInt32(value["SenderPhone"]);
                }

                if (value.ContainsKey("MessageContent")) 
               messageContent = value["MessageContent"]?.ToString();
                if (value.ContainsKey("MessageType"))
                    messageType = value["MessageType"]?.ToString();
                if (messageType== "Private")
                    title = NetworkService.user.phone == sendPhone ? value["ReceiverName"]?.ToString() : value["SenderName"]?.ToString();
                else
                    title = value["GroupName"]?.ToString();

                if (value.ContainsKey("SentDate") && !string.IsNullOrEmpty(value["SentDate"]?.ToString()))
                    sentDate = Convert.ToDateTime(value["SentDate"]);
                if (value.ContainsKey("ChatImage") && !string.IsNullOrEmpty(value["ChatImage"]?.ToString()))
                    chatImage = Convert.FromBase64String(value["ChatImage"].ToString());
            }
        }
        public bool isSender => NetworkService.user.phone == sendPhone;
        public bool isReceiver => NetworkService.user.phone == ChatId;
        //id, MessageContent, SentDate, SenderName, ReceiverName, GroupName,ChatImage
    }
}
