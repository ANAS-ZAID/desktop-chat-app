using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server.Models
{
    public class Messages : EntityWithFile
    {


        public string content { get; set; }

        public string status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? receiveDate { get; set; }
        public int? sendPhone { get; set; }
        public int? receivePhone { get; set; }
        public int? receiveGroupId { get; set; }
        //public string fileName { get; set; }  // اسم الملف
        //public string fileData { get; set; }  // محتوى الملف بصيغة Base64
        public override Dictionary<string, object> json
        {
            get
            {
               
                return new Dictionary<string, object>()
     {
         {"containts",content },
         {"status",status },
         {"startDate",startDate },
         {"reciveDate",receiveDate },
         {"sendPhone",sendPhone },
         {"recivePhone",receivePhone },
         {"reciveGroupId",receiveGroupId },
         //{"fileName",fileName },
         //{"fileData",ConvertFileToBase64()},
     };
            }
            set
            {
            

                if (value == null||!value.ContainsKey("sendPhone")) return;
                sendPhone = Convert.ToInt32(value["sendPhone"]);


           
                if (value.ContainsKey("receiverId")&& value.ContainsKey("Type"))
                {

                    if (value["Type"].ToString()== "Group")

                    receiveGroupId = Convert.ToInt32(value["receiverId"]);
                    else
                    receivePhone = Convert.ToInt32(value["receiverId"]);
                }
                content = value.ContainsKey("MessageContent")? value["MessageContent"]?.ToString():null;
                status = value.ContainsKey("Status") ? value["Status"]?.ToString():null;
                startDate = value.ContainsKey("SentDate") ?Convert.ToDateTime(value["SentDate"]) :DateTime.Now;

                receiveDate = value.ContainsKey("ReceivedDate") ? Convert.ToDateTime(value["ReceivedDate"] ?? DateTime.Now) : DateTime.Now;
                
                //       { "content",content },
                //{ "status",status },
                //{ "startDate",startDate },
                //{ "receiveDate",receiveDate },
                //{ "sendPhone",sendPhone },
                //{ "receivePhone",receivePhone },
                //{ "receiveGroupId",receiveGroupId },              //{ "sendPhone", sendPhone },
                
            }
        }
        
        public class MessagesView
        {
          public string MessageContent {  get; set; }
            public string Status { get; set; }
            public DateTime? SentDate { get; set; }
            public DateTime? ReceivedDate { get; set; }
            public byte[] SenderImage {  get; set; }
            public string SenderName {  get; set; }
            public byte[] Attachment {  get; set; }
 

        }

    }
}
