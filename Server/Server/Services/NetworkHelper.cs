using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Services
{
    public class JsonRequest
    {
        public Dictionary<string, object> files { get; set; }
        public Dictionary<string, object> header { get; set; }
        public int? userId { get; set; }
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

        public bool isNotification { get; set; }=false;
        public string Page { get; set; }
        public string Action { get; set; }
        public int? userId { get; set; }
        public Dictionary<string, object> files { get; set; }
        public Dictionary<string, object> header { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<Dictionary<string, object>> body { get; set; }
        
        public void Send(NetworkStream stream)
        {
            NetworkHelper.Send(stream, JsonConvert.SerializeObject(this));
        }
        public void setStatus(bool status=false, string action = "", List<Dictionary<string, object>> data = null,string message=null ) {

            if (string.IsNullOrEmpty(message))

                if (action != null)
                 {
                if (action == "add")
                {
                   
                    Message = status ?  "نجحت عملية الإضافة" : "فشلت عملية الإضافة";
                }
                else if (action == "update")
                {
                    Message = status ? "نجحت عملية التحديث" : "فشلت عملية التحديث";
                }
                else if (action == "delete")
                {
                    Message = status ? "نجحت عملية الإضافة" : "فشلت عملية الإضافة";
                }
                else
                {
                    status =  data != null && data.Count > 0;
               
                    if (status)
                    {
                        this.body = data;
                    }
                    if (action == "find")
                    {
                        Message = status ? "نجحت عملية البحث" : "فشلت عملية البحث";
                        
                    }
                    else if (action == "select")
                    {
                        Message = status ? "نجحت عملية جلب البيانات" : "فشلت عملية جلب البيانات";
                    }
                }
            }
            Status = status;
        }
        public static JsonResponse Receive(NetworkStream stream)
        {
            string json = NetworkHelper.Receive(stream);
            return json != null ? JsonConvert.DeserializeObject<JsonResponse>(json) : null;
        }
        public JsonResponse copy()=> new JsonResponse() { Page=Page, Status=Status,Message=Message,isNotification=isNotification,Action = Action ,body = body ,header = header ,userId = userId ,files=files};
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
                MessageBox.Show($"[Error] Failed server to send body: {ex.Message}");
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
}
