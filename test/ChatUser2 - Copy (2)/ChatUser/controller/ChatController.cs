using ChatUser.data.model;
using ChatUser.Services;
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
        public MessagesView NewMessageActiveChat;
        public List<MessagesView> messagesActiveChat=new List<MessagesView>();
        public List<MessagesView> updatedMessagesActiveChat = new List<MessagesView>();
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
                body = new Dictionary<string, object>() { { "ChatId", activeChat.isSender ? activeChat.sendPhone : activeChat.ChatId } },
                Action = "find",

            });
        }
        public MessagesView AddNewMessageToChat( string text)
        {
            //MessageBox.Show(activeChat.ChatId.ToString());
            var newMessage = new MessagesView() { id = -1, SenderName = NetworkService.user?.name, sendPhone = NetworkService.user.phone, MessageContent = text, Type = activeChat.messageType, Status = "unread", SentDate = DateTime.Now, receiverId = activeChat.isSender ? activeChat.sendPhone : activeChat.ChatId };
            request(new JsonRequest() { Action="add",body=newMessage.json});
            return newMessage;
        }
        public override void OnMessageReceived(JsonResponse response)
        {
            string action = "";
            //MessageBox.Show(Chat.fromListJson(response.body).Count.ToString());
            if(response == null||!response.Status|| response.Page!=page) return;
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
                case "add":
                    action = "updateShowMessages";
                    updateShowMessages(response);

                    break;
                case "Notification":
                  action=Notification(response);

                    //AddMessageToChat(new MessagesView() { json = response.body.First() });
                    break;
                case "getNewChats":
                    action = "getNewChats";
                    getNewChats(response);

                    //AddMessageToChat(new MessagesView() { json = response.body.First() });
                    break;
            }
                    MessageReceived?.Invoke(action);
        }
        public void getNewChats(JsonResponse response)
        {
            if (JsonResponse.EmptyBody(response)) return;
            var listChats=Chat.fromListJson(response.body);
              newChats.Clear();
            //var newChats=Chat.fromListJson(response.body);
            foreach (var element in listChats)
            {

                bool chatFound = chats.FirstOrDefault((chat) => chat.sendPhone == element.ChatId || chat.ChatId == element.sendPhone) != null;
                if (!chatFound)
                {
                    newChats.Add(element);
                }
            }
        }
        public void lodeMessageActiveChat(JsonResponse response)
        {
        
            //if(JsonResponse.EmptyBody(response)) return;
            MessageBox.Show("response:"+ response.body.Count);
            messagesActiveChat = MessagesView.FromListJson(response.body);
        }
        public void selectChats(JsonResponse response)
        {
           
            chats = Chat.fromListJson(response.body);
        }
        public void updateShowMessages(JsonResponse response)
        {
            if (JsonResponse.EmptyBody(response)) return;
            updatedMessagesActiveChat = MessagesView.FromListJson(response.body);
        }
        public override string Notification(JsonResponse notification)
        {
            string action = "";
            MessageBox.Show($"CurentUser:{NetworkService.user.phone},  NotificationFromUserId:{notification.userId}");
            if (notification.header["NotificationType"].ToString() == "newMessage")
                if (JsonResponse.EmptyBody(notification)) return action;
            Dictionary<string, object> newMessage = notification.body.FirstOrDefault();
            if (newMessage == null) return     action;
            //Dictionary<string, object> newMessage = notification.body.LastOrDefault();
            //if (newMessage == null) return action;


            MessagesView message = new MessagesView() { json = newMessage };
            //if (message.isReceiver)
            {
                    if (message.sendPhone==activeChat?.sendPhone|| message.receiverId == activeChat?.ChatId)
                {
                    NewMessageActiveChat = message;
                    return "AddNewMessageToChat";
                }
                //else
                //{

                //    bool chatFound = chats.FirstOrDefault((chat)=>chat.sendPhone==message.sendPhone||chat.ChatId==message.receiverId||chat.sendPhone==message.receiverId||chat.ChatId==message.sendPhone)!=null;
                //    if (!chatFound)
                //    {
                //        request(new JsonRequest() { Action = "getNewChats", });
                //    }
                //}

            }
            //MessagesView message =new MessagesView() { json=newMessage};






            return action;
        }
        //void AddNewChat(Chat chat)
        //{
        //    newChat = chat;
        //}
        void AddNewMessageActiveChat(MessagesView message)
        {
            NewMessageActiveChat=message;
        }
    }
}
