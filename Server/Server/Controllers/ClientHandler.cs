using Server.Models;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Controllers
{
    public class ClientHandler
    {
        private readonly TcpClient _client;
        private readonly DbContext _dbContext;
        private readonly ServerController _controller;
        public NetworkStream stream { get; private set; }
        public int? userId { get; set; }
        public Users CurrentUser { get; private set; }

        public ClientHandler(TcpClient client, DbContext dbContext, ServerController controller)
        {
            _client = client;
            _dbContext = dbContext;
            _controller = controller;
            stream = _client.GetStream();
        }

        public void HandleClient()
        {

           
          
                while (_client.Connected)
                {
                    Receive(stream);

                }
               //MessageBox.Show($"_client.Close:{userId}");
                   stream.Close();
                _client.Close();
                _controller.remove(this);

        }
        public void send()
        {

            JsonResponse response = new JsonResponse { Status = true, Message = "send processed successfully" };
            response.Send(_client.GetStream());
        }
        void Receive(NetworkStream stream)
        {

            JsonRequest request = JsonRequest.Receive(stream);
            if (request != null)
            {

                //MessageBox.Show($"Received request server : userPhone:{request?.userId} ,{request.Action}, {request.Page}");
               
               JsonResponse response =_controller.HandleRequest(request,this);
                response.Send(stream);

            }

        }
        //private User Authenticate(NetworkStream stream)
        //{
        //    // تنفيذ عملية المصادقة
        //}
        //private void SendJsonResponse(NetworkStream stream, object data)
        //{
        //    string json = JsonConvert.SerializeObject(data);
        //    byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

        //    // إرسال طول البيانات أولاً
        //    byte[] lengthBytes = BitConverter.GetBytes(jsonBytes.Length);
        //    stream.Write(lengthBytes, 0, 4);

        //    // إرسال البيانات الفعلية
        //    stream.Write(jsonBytes, 0, jsonBytes.Length);
        //}


    }
}
