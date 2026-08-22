using ChatUser.data.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.Services
{
    public class NetworkService
    {
        public event Action<JsonResponse> MessageReceived;
        private TcpClient _client;
        public bool ConnectedServer {  get; private set; }=false;
        public static Users user { get; set; }
      
        NetworkStream _stream;

         static NetworkService _Instance;
         public static NetworkService Instance { get => _Instance == null ? _Instance = new NetworkService():_Instance; }
        public NetworkService(string ip="127.0.0.2", int port=5050){
            Connect(ip, port );
           
        }
        public void Connect(string ip, int port)
        {
            try
            {
                _client = new TcpClient(ip, port);
                _stream = _client.GetStream();
                new Thread(ReceiveMessages).Start();
                ConnectedServer = true;
            }
            catch(Exception ex) 
            {
                MessageBox.Show("لم يتم الاتصال بالسيرفر");
                ConnectedServer = false;
                
            }
        }

        private void ReceiveMessages()
        {
            while (true)
            {
                JsonResponse response = JsonResponse.Receive(_stream);
                if (response != null)
                {
                    //MessageBox.Show($"Response user: {response.Status}, {response.Message}");
                    
                    MessageReceived?.Invoke(response);
                }
               
            }
        }
       public void send(JsonRequest request)
        {

            //client = new TcpClient("127.0.0.1", 5050);
            if (ConnectedServer)
            {
                request.userId = user?.phone;
                request.Send(_stream);
            }

        }
    }
    public static class NetworkHelper
    {
        public static void Send(NetworkStream stream, string json)
        {
            try
            {
                byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                byte[] lengthBytes = BitConverter.GetBytes(jsonBytes.Length);

                stream.Write(lengthBytes, 0, lengthBytes.Length);
                stream.Write(jsonBytes, 0, jsonBytes.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"[Error] Failed to send body: {ex.Message}");
            }
        }

        public static string Receive(NetworkStream stream)
        {
            try
            {
                byte[] lengthBytes = ReadBytes(stream, 4);
                int length = BitConverter.ToInt32(lengthBytes, 0);

                byte[] jsonBytes = ReadBytes(stream, length);
                return Encoding.UTF8.GetString(jsonBytes);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"[Error] Failed to receive data: {ex.Message}");
                return null;
            }
        }

        private static byte[] ReadBytes(NetworkStream stream, int count)
        {
            byte[] buffer = new byte[count];
            int offset = 0;

            while (offset < count)
            {
                int read = stream.Read(buffer, offset, count - offset);
                if (read == 0) throw new IOException("Connection closed by remote host.");
                offset += read;
            }

            return buffer;
        }
    }

    public class JsonRequest
    {
        public Dictionary<string, object> files { get; set; }
        public Dictionary<string, object> header { get; set; }
        public int? userId {  get; set; }
        public string Action { get; set; }
        public string Page { get; set; }
        public Dictionary<string, object> body { get; set; }

        public void Send(NetworkStream stream)
        {
            NetworkHelper.Send(stream, JsonConvert.SerializeObject(this));
        }
       
        public static JsonRequest Receive(NetworkStream stream)
        {
            string json = NetworkHelper.Receive(stream);
            return json != null ? JsonConvert.DeserializeObject<JsonRequest>(json) : null;
        }
       
    }

    public class JsonResponse
    {
        public bool isNotification { get; set; } = false;
        public string Action { get; set; }
        public string Page { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public int? userId { get; set; }
        public Dictionary<string, object> files { get; set; }
        public Dictionary<string, object> header { get; set; }
        public List<Dictionary<string, object>> body { get; set; }
        public void Send(NetworkStream stream)
        {
            NetworkHelper.Send(stream, JsonConvert.SerializeObject(this));
        }

        public static JsonResponse Receive(NetworkStream stream)
        {
            string json = NetworkHelper.Receive(stream);
            return json != null ? JsonConvert.DeserializeObject<JsonResponse>(json) : null;
        }
        public bool isNotEqualPageOrNotification(string page) => Page != Page||isNotification ;
        //public bool isNotification => Action == "Notification";
        public bool isNotNotification =>!isNotification;
        public bool isEmptyBody => EmptyBody(this);
        static public bool EmptyBody(JsonResponse response) => response.body == null || !response.body.Any();
        public JsonResponse copy => new JsonResponse() { Page = Page, Status = Status, Message = Message, isNotification = isNotification, Action = Action, body = body, header = header, userId = userId, files = files };

    }
}
