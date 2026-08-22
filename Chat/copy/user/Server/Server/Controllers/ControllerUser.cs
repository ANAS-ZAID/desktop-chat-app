using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using Server.Services;

namespace Server.Controllers
{
    public class ControllerUser : Controller
    {  
        public override JsonResponse add()
        {
            JsonResponse response = new JsonResponse() { Status = false };
            Users user = Users.fromJson(request.body);
            var whereConditions = new List<Tuple<string, object, string>>()
            {
             new Tuple<string, object, string>("phone",user.phone , "or"),
             new Tuple<string, object, string>("name",user.name , "or"),
             new Tuple<string, object, string>("elesName",user.elesName , ""),
            };
            var f = db.Users.SelectOne(whereConditions: whereConditions);
             if (f != null)
            {
                string trail = "";
                if (f.phone == user.phone)
                    trail = "الرقم";
                if (f.name == user.name)
                    trail = "الأسم";
             if (f.name == user.elesName)
                    trail = "الأسم الظاهر عند الأخرين";
                response.Message = "يوجد مستخدم سابق بهذا " + trail;
                return response;
            }
            if (!user.saveFile())
            {
                response.Message = "حدث خطأ ما في العمليه saveFile";
                return response;
            }
            user.HashPassword();
            int result = db.Users.Insert(user);
            if (result > 0) {
               whereConditions = new List<Tuple<string, object, string>>() { new Tuple<string, object, string>("phone",user.phone , ""), };
                f = db.Users.SelectOne(whereConditions: whereConditions);
                if (f != null) {
                    user.userCode = f.userCode;
                    response.Message = "تم أنشاء الحساب بنجاح";
                    response.Status = true;
                    response.body = new List<Dictionary<string, object>>() { user.json };
                }
            }
            return response;
        }

        public override JsonResponse delete()
        {
            throw new NotImplementedException();
        }

        public override JsonResponse find()
        {
            try
            {

                Users user = Users.fromJson(request.body);
               
                var whereConditions = new List<Tuple<string, object, string>>
        {
            new Tuple<string, object, string>("phone", user.phone, "")
        };

          
                var foundUser = db.Users.SelectOne(whereConditions: whereConditions);
                if (foundUser == null)
                    return new JsonResponse { Status = false, Message = "المستخدم غير موجود" };

               
                foundUser.readFile();

              
                bool isValid = false;
                string message = "ليس لديه صلاحيات";

                if (foundUser.permission)
                {
                    if (PasswordHasher.VerifyPassword(user.password, foundUser.password))
                    {
                        isValid = true;
                        message = "تمت العملية بنجاح";
                    }
                    else
                    {
                        message = "كلمة المرور غير صحيحة";
                    }
                }

             
                var responseData = isValid ? new List<Dictionary<string, object>>() { foundUser.json} : null;
                var files = isValid ? new Dictionary<string, object>() { { "img", FileHelper.ConvertFileToBase64(foundUser.filePath) } } : null;

                return new JsonResponse
                {
                    Status = isValid,
                    Message = message,
                    body = responseData,
                    files=files
                };
            }
            catch (Exception ex)
            {
                // 7. معالجة الأخطاء
               
                return new JsonResponse { Status = false, Message = "حدث خطأ داخلي" };
            }
        }

        public override JsonResponse select()
        {
            throw new NotImplementedException();
        }

        public override JsonResponse update()
        {
            throw new NotImplementedException();
        }
    }
}
