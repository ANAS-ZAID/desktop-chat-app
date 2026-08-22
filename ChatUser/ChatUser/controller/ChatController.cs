using ChatUser.data.model;
using ChatUser.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChatUser.controller
{
    internal class ChatController : Controller
    {       protected override string page => "chat";
          Action<string> MessageReceived;
         public List<Chat> chats=new List<Chat>();
        public Messages NewMessageActiveChat;
        public Chat NewChat;
        public List<Messages> messagesActiveChat=new List<Messages>();
        public List<Messages> updatedMessagesActiveChat = new List<Messages>();
        Action<Chat> onActiveChat;
        Chat activeChat;
       public List <Chat> newChats;
        public ChatController(Action<string> MessageReceived , Action<Chat> onActiveChat) 
        {
            this.MessageReceived += MessageReceived;
            this.onActiveChat = onActiveChat;
            select();

        }

       public void onClickChat(int index, Chat chat)
        {
            activeChat = chat;
          
            onActiveChat?.Invoke(chat);
            find();
        }
        
        public override void find()
        {if (activeChat == null) return;
           
            request(new JsonRequest()
            {
                body = activeChat.json,
                Action = "find",

            });
        }
        public Messages AddNewMessageToChat( string text)
        {
            //MessageBox.Show(activeChat.ChatId.ToString());
            var newMessage = new Messages() {id=-1 , senderPhone = NetworkService.user.phone, content =text, sentDate = DateTime.Now,receiverPhone=activeChat.chatId};
            request(new JsonRequest() { Action="add",body=newMessage.json});
            return newMessage;
        }
        public override void OnMessageReceived(JsonResponse response)
        {
            string action = "";
            
            if (response == null||!response.Status|| response.Page!=page) return;
            if (response.isNotification)
            {

                action = Notification(response);
            }
            else
            {
                switch (response.Action)
                {
                    case "select":
                        selectChats(response);
                        action = "updateChatList";
                        break;
                    case "find":
                        lodeMessageActiveChat(response);
                        action = "showMessagesChat";
                        break;
                    //case "add":
                    //    action = "updateShowMessages";
                    //    updateShowMessages(response);

                        //break;

                    case "getNewChats":
                        action = "getNewChats";
                        getNewChats(response);

                        //AddMessageToChat(new MessagesView() { json = response.body.First() });
                        break;
                }
            }
            MessageReceived?.Invoke(action);
        }
        public void getNewChats(JsonResponse response)
        {
            //if (JsonResponse.EmptyBody(response)) return;
            //var listChats=Chat.fromListJson(response.body);
            //  newChats.Clear();
            ////var newChats=Chat.fromListJson(response.body);
            //foreach (var element in listChats)
            //{

            //    bool chatFound = chats.FirstOrDefault((chat) => chat.sendPhone == element.ChatId || chat.ChatId == element.sendPhone) != null;
            //    if (!chatFound)
            //    {
            //        newChats.Add(element);
            //    }
            //}
        }
        public void lodeMessageActiveChat(JsonResponse response)
        {
            if(JsonResponse.EmptyBody(response)) return;
                
            messagesActiveChat = Messages.fromListJson(response.body);
        }
        public void selectChats(JsonResponse response)
        {
           
            chats = Chat.fromListJson(response.body);
            //foreach (var item in chats)
            //{
            //    MessageBox.Show($"ChatId:{item.ChatId},sendPhone:{item.sendPhone}");
            //}
        }
        public void updateShowMessages(JsonResponse response)
        {
            if (JsonResponse.EmptyBody(response)) return;
            updatedMessagesActiveChat = Messages.fromListJson(response.body);
        }
        public override string Notification(JsonResponse notification)
        {
            //MessageBox.Show($"CurentUser:{NetworkService.user.phone},  NotificationFromUserId:{notification.userId}");
            string action = "";
            if (notification.Action== "newMessage" && notification.header!=null)
            {
                if (notification.header.ContainsKey("chat") && notification.header.ContainsKey("message"))
                {
                    //var chat = notification.header["chat"];
                    var message = notification.header["message"];
                    var chat = notification.header["chat"];
                    if (message!=null&&chat!=null)
                    {

                        var receivedMessage = new Messages() { json = JsonConvert.DeserializeObject<Dictionary<string, object>>(message.ToString()) };
                        //MessageBox.Show(NewMessageActiveChat.senderPhone + $"curr{NetworkService.user.phone}" + NewMessageActiveChat.receiverPhone);
                        if (receivedMessage.isReceiver)
                        {
                            if (activeChat.chatId == receivedMessage.senderPhone)
                            {
                                NewMessageActiveChat = receivedMessage;

                                return "AddNewMessageToChat";

                            }
                            if (chats == null)
                                chats = new List<Chat>();
                            if (!chats.Any((ch) => ch.chatId == receivedMessage.senderPhone))
                            {
                                NewChat = new Chat() { json = JsonConvert.DeserializeObject<Dictionary<string, object>>(chat.ToString()) };
                                chats.Insert(0,NewChat);
                                return "updateChatList";
                            }
                           
                        }
                        else if (receivedMessage.isSender && activeChat?.chatId == receivedMessage.receiverPhone)
                        {
                            //MessageBox.Show("isSender");
                            updatedMessagesActiveChat.Clear();
                            updatedMessagesActiveChat.Add(receivedMessage);
                            return "updateShowMessages";


                        }
                    }

                }
                
            }

            return action;
        }
        //void AddNewChat(Chat chat)
        //{
        //    newChat = chat;
        //}
        void AddNewMessageActiveChat(Messages message)
        {
            NewMessageActiveChat=message;
        }
    }
}
