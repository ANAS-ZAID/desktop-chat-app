using ChatUser.core.classes;
using ChatUser.data.local;
using ChatUser.data.model;
using ChatUser.Services;
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
        Action<bool> showHomeScreen;
        Users user { get; set; } = new Users();

        public AuthController(Action<bool> showHomeScreen) { 
          
                  this.showHomeScreen=showHomeScreen;
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
        {
            if(response.isNotEqualPageOrNotification(page)) return;
      

            if (!response.Status|| response.isEmptyBody)
            {
                MessageHelper.show(response.Message, MessageHelperType.error);
                return;
            }
            if(response.Action=="add")
                MessageHelper.show(response.Message);
            else
            {
                if (response.files != null)
                {
                    if (response.files.ContainsKey("img")&& response.files["img"]!=null)
                    {
                        user.file = Convert.FromBase64String(response.files["img"].ToString());
                    }
                }
            }
            var returnUser = Users.fromJson(response.body.First());
            user.active=returnUser.active;
            user.userCode = returnUser.userCode;
            NetworkService.user=user;
            showHomeScreen?.Invoke(true);
           network.MessageReceived -= OnMessageReceived;
        }
        
       
    public   void changePublicType(bool check)
        {
            user.publicType = check;
        }
    }
}
