using ChatUser.core.classes;
using ChatUser.data.local;
using ChatUser.data.model;
using ChatUser.Services;
using ChatUser.view.screen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.controller
{
    internal class AuthController:Controller
    {
        protected override string page { get => "user"; }
        public  bool isSinIn { get; set; }=true;
        public  bool isSinUp { get { return !isSinIn; } }

        Users user { get; set; } = new Users();
        Action<JsonResponse> onMessageReceived;
        public AuthController(Action<JsonResponse> MessageReceived) {

            onMessageReceived=MessageReceived;
        }
       public void changeAuth()
        {
            isSinIn = !isSinIn;
        }
         public void processing(string phone, string password, string name, string elesName, string information, (string, Image) img)
        {
           if (!ValidatingData.validate(phone, "رقم الهاتف",minLength:9)|| !ValidatingData.validate(password, "كلمة المرور"))
                return;
            if (isSinUp)
            {
                if (!ValidatingData.validate(name, "الأسم") || !ValidatingData.validate(elesName, "الأسم الظاهر عند الأخرين"))
                    return;
            }
            if ( img.Item2 != null)
            {

                MemoryStream memoryStream = new MemoryStream();

                img.Item2.Save(memoryStream, img.Item2.RawFormat);
                user. file = memoryStream.ToArray();
               
                user.filePath = img.Item1;
            }
            else
            {
                user. file = null;
                user.filePath= null;
            }
            user.phone = int.Parse(phone);
            user.name = name;
            user.password = password;
            user.elesName = elesName;
            user.information = information;
            NetworkService.user.id = user.phone;
            NetworkService.user.password = user.password;
            NetworkService.user.name = user.name;
            if (isSinIn)
            {
                find();
            }
            else
            {
                add();
            }

        }
        public override void add()
        {
            request(new JsonRequest()
            {
                Action = "add",
                body = user.json,
            });
        }

        public override void find()
        {
            request(new JsonRequest()
            {
                Action = "find",
                body = user.json,
            });
        }
        public override void OnMessageReceived(JsonResponse response)
        { if (response == null||response.Page!= "user") return;
            if ( response.Status)
            {
                NetworkService.user.id=user.phone;
                NetworkService.user.password=user.password;
                NetworkService.user.name=user.name;
                onMessageReceived(response);
            }
        }
        
       
    public   void changePublicType(bool check)
        {
            user.publicType = check;
        }
    }
}
