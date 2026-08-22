using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Services;
using Server.Models;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
namespace Server.Controllers
{


    public class ServerController
    {
        public static Action<JsonResponse> NotificationClients;
        private readonly DbContext _dbContext;
        private readonly List<ClientHandler> _clients = new List<ClientHandler>();
        private readonly TcpListener listener;
        public readonly ControllerUser controllerUser;
        public readonly ControllerGroup controllerGroup;
        public readonly ChatController chatController;
        public ServerController()
        {
            _dbContext = new DbContext();
            listener = new TcpListener(IPAddress.Any, 5050);
            controllerGroup = new ControllerGroup();
            controllerUser = new ControllerUser();
            chatController = new ChatController();
            NotificationClients = Notification;
        }

        public void StartServer()
        {
            listener.Start();
            new Thread(ReceiveMessage).Start();

        }
        void ReceiveMessage()
        {
            while (true)
            {
                var client = listener.AcceptTcpClient();
                var handler = new ClientHandler(client, _dbContext, this);
                lock (_clients)
                {
                    _clients.Add(handler);
                }
                new Thread(handler.HandleClient).Start();
            }
        }
       //public  void BroadcastMessage(string message, ClientHandler sender)
       // {
       //     byte[] data = Encoding.UTF8.GetBytes(message);

       //     lock (_clients)
       //     {
       //         foreach (var client in _clients)
       //         {
       //             if (client != sender)
       //             {
       //                 client.send();
       //             }
       //         }
       //     }
       // }
        public JsonResponse HandleRequest(JsonRequest request, ClientHandler sender)
        {
            JsonResponse jsonResponse = new JsonResponse()
            {
                Status = false,
                Message = "حدث خطأما في العملية"
            };
            //lock (this)
            {
                try
                {

                    if (sender.userId == null) {
                        sender.userId = request.userId;
                    }
                    switch (request.Page)
                    {
                        case "connect":
                            jsonResponse = new JsonResponse() { Status = true, Message = "تم الإتصال بنجاح" };
                            break;
                        case "user":
                            jsonResponse = controllerUser.processingRequest(request);
                            break;
                        case "group":

                            jsonResponse = controllerGroup.processingRequest(request);
                            break;
                        case "chat":

                            jsonResponse = chatController.processingRequest(request);
                            break;
                    }

                }
                catch (Exception e) { 
                jsonResponse=new JsonResponse() { Status = false, Message = e.Message };
                }
            }
    
            return jsonResponse;
        }
        public void Notification( JsonResponse notification)
        {



            if(!notification.Status||notification.Action!= "Notification") return;


            //MessageBox.Show($"ServerNotification:notification.userId: {notification.userId} ");



            lock (_clients)
            {
                foreach (var client in _clients)
                {
                    try
                    {
                        if (client.userId!= notification.userId)
                        {

                            //using (var stream = client.stream)
                            //{
                                if (client.stream != null && (client.stream.CanWrite))
                                    notification.Send(client.stream);
                            //}
                        }
                    }
                     
                    catch (Exception e) {

                        MessageBox.Show($"Exception:=>{e.Message}");

                    }

                }
            }
        }

        public void remove(ClientHandler client)
        {
            lock (_clients) { _clients.Remove(client);  }

        }
        //public void BroadcastMessage(Message message)
        //{
        //    message = new Message();

        //    _dbContext.SaveMessage(message);
        //    foreach (var client in _clients.Where(c => c.IsAuthenticated))
        //    {
        //        client.SendMessage(message);
        //    }
        //}
    }


   

    

}
