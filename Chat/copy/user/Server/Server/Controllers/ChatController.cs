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
        public override JsonResponse add()
        {
      
            Messages message = new Messages() { json=request.body,sendPhone=request.userId};
            message.status = "sender";
            int newId = db.Messages.Insert(message,true);
            if (newId > 0)
            {
               
                int receiverId = Convert.ToInt32(request.body["receiverId"]);
             
                var r = GetMessagesByChatId(receiverId);
                
                var newMessage=db.Messages.SelectOne(whereConditions: new List<Tuple<string, object, string>> { new Tuple<string, object, string>("id", newId, "") });
 
                if (newMessage == null || !r.Status)
                    return r;
                var newMessageView= r.body.FirstOrDefault((item)=>item.ContainsKey("id")&&item["id"].Equals(newId));
         
                if (newMessageView == null)
                    return new JsonResponse() { Message = "حدث خطأ ما في العمليه", Status = true };

                NotificationClientsAdd(newMessageView); //newChat
                return   new JsonResponse() { Message = "تمت العملية بنجاح" , Status =true,body=new List<Dictionary<string, object>>() { newMessageView } };
            }
            return new JsonResponse() { Message =  "حدث خطأ ما في العمليه", Status =false, };
        }
        void NotificationClientsAdd(Dictionary<string, object> newMessageView)
        {
            Dictionary<string, object> header = new Dictionary<string, object>()
                                      {
                                          //{"Notification", "chat" },
                                          {"NotificationType", "newMessage" },
                                          {"chatType", request.body["Type"] },
                                        

                                      };
            var Notification = new JsonResponse() { Status=true,userId=request.userId,Action = "Notification", Page = "chat", header = header, body = new List<Dictionary<string, object>>() { newMessageView} };
            //MessageBox.Show($"NotificationClientsAdd:notification.userId{Notification.userId}");
            ServerController.NotificationClients?.Invoke(Notification);
        }
        public override JsonResponse Request()
        {
            if (request.Action== "getNewChats")
            {
                MessageBox.Show("getNewChats");
                return select();
            }
            return base.Request();
        }
        public override JsonResponse delete()
        {
            throw new NotImplementedException();
        }

        public override JsonResponse find()
        {
            
            if (request.body == null || request.body["ChatId"] == null)
                    return new JsonResponse() { Status = false, Message = "البيانات ليست صحيحه" };
           
            int ChatId = int.Parse(request.body["ChatId"].ToString());

            //execute  @CurrentUserPhone = 730000001 , @ChatId = 1;
            var r=GetMessagesByChatId(ChatId);
         
            return r;
        }
        JsonResponse GetMessagesByChatId(int ChatId)
        {
            try
            {
                
               
                var body = db.Messages.Procedure("GetMessagesByChatId", new Dictionary<string, object>()
             {
          { "CurrentUserPhone",request.userId},
           {  "ChatId",ChatId }
                 });
                if (body == null)
                    return new JsonResponse() { Status = false, Message = "حدث خطأ في العملية" };

                MessageBox.Show("ChatId"+ ChatId);
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
        public override JsonResponse select()
        {

          
            var  body = db.Messages.Procedure("GetChatList", new Dictionary<string, object>()
                    {
                     {
                    "CurrentUserPhone",request.userId
                    }
                            });

            if (body == null)
                return new JsonResponse() { Status = false, Message = "حدث خطأ في العملية" };


            //for (global::System.Int32 i = 0; i < body.Count; i++)
            //    {
            //        body[i]["ChatImage"] = FileHelper.ConvertFileToBase64(body[i]["ChatImage"]?.ToString());
            //    }

                return new JsonResponse() { Status = true ,body=body,Message="تمت العملية بنجاح"};

            
        }

        public override JsonResponse update()
        {
            throw new NotImplementedException();
        }
    }
}
