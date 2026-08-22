using Server.Models;
using Server.Services;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Controllers
{
    public class ChatController : Controller
    {
        public static List<Chat> chats { get; set; }
        public ChatController()
        {
            lodeChat();

        }
        void lodeChat()
        {
            chats = new List<Chat>();
            var users = db.Users.Select();
            if (users == null) return;
            foreach (var user in users)
            {
                chats.Add(Chat.fromUser(user));
            }
        }
        public override JsonResponse add(JsonRequest request)
        {
      
            Messages message = new Messages() { json=request.body};
            message.status = "unread";
            int newId = db.Messages.Insert(message,true);
            if (newId > 0)
            {
                  message.id = newId;
                JsonResponse response = new JsonResponse() {Message = "تمت العملية بنجاح", Status = true, body = new List<Dictionary<string, object>>() { message.json } };
                NotificationClientsAdd(response.copy());
                return response ;
            }
            return new JsonResponse() { Message =  "حدث خطأ ما في العمليه", Status =false, };
        }
        void NotificationClientsAdd(JsonResponse Notification)
        {
           
            Notification.isNotification=true;
            Notification.Action = "newMessage";
            Notification.Page = request.Page;
            Notification.userId = request.userId;
            ServerController.NotificationClients?.Invoke(Notification);

        }
        public override JsonResponse Request(JsonRequest request)
        {
            if (request.Action== "getNewChats")
            {
                //MessageBox.Show("getNewChats");
                return select(request);
            }
            return base.Request(request);
        }
        public override JsonResponse delete(JsonRequest request)
        {
            throw new NotImplementedException();
        }

        public override JsonResponse find(JsonRequest request)
        {
            
            if (request.body == null || request.body["chatId"] == null)
                    return new JsonResponse() { Status = false, Message = "البيانات ليست صحيحه" };
           
            int ChatId = int.Parse(request.body["chatId"].ToString());

            //execute  @CurrentUserPhone = 730000001 , @ChatId = 1;
            var r=GetMessagesByChatId(request.userId??0,ChatId);
         
            return r;
        }
        JsonResponse GetMessagesByChatId(int userPhone, int ChatId)
        {
            try
            {
                
               
                var body = db.Messages.Procedure("GetMessagesByChatId", new Dictionary<string, object>()
             {
          { "CurrentUserPhone",userPhone},
           {  "ChatId",ChatId }
                 });
                if (body == null)
                    return new JsonResponse() { Status = false, Message = "حدث خطأ في العملية" };

                //MessageBox.Show("ChatId"+ ChatId);
                //for (global::System.Int32 i = 0; i < body.Count; i++)
                //{
                //    body[i]["SenderImage"] = FileHelper.ConvertFileToBase64(body[i]["SenderImage"]?.ToString());
                //}

                return new JsonResponse() { Status = true, body = body, Message = "تمت العملية بنجاح" };
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                return new JsonResponse() { Status = false, Message = "حدث خطأ في العملية" };

            }
        }
        public override JsonResponse select(JsonRequest request)
        {
            //var chatList=
            var r = getChatList(request.userId ?? 0);
            
            r.header = new Dictionary<string, object>() { { "allChats", chats } };
            
            return r;

        }
        public JsonResponse getChatList(int uerPhone, int? chatId=null)
        {
            var body = db.Messages.Procedure("GetChatList", new Dictionary<string, object>()
                    {
                     {
                    "CurrentUserPhone",uerPhone

                    }
                     ,{ "ChatId",chatId }       });

            //if (body == null)
            //    return new JsonResponse() { Status = false, Message = "حدث خطأ في العملية" };


            //for (global::System.Int32 i = 0; i < body.Count; i++)
            //    {
            //        body[i]["ChatImage"] = FileHelper.ConvertFileToBase64(body[i]["ChatImage"]?.ToString());
            //    }

            return new JsonResponse() { Status = true, body = body, Message = "تمت العملية بنجاح" };
        }
        public Dictionary<string, object> getChat(int uerPhone, int chatId)
        {
            return getChatList(uerPhone, chatId).body?.FirstOrDefault();
        }
        public override JsonResponse update(JsonRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
