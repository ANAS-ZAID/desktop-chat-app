using Server.Models;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class ControllerGroup : Controller
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
                response.Message = "حدث خطأ ما في العمليه";
                return response;
            }
            int result = db.Users.Insert(user);
            response.Message = "تمت العمليه بنجاح";
            response.Status = true;
            response.body = new List<Dictionary<string, object>>() { user.json };
            return response;
        }

        public override JsonResponse delete()
        {
            throw new NotImplementedException();
        }

        public override JsonResponse find()
        {
            Users user = Users.fromJson(request.body);
            var whereConditions = new List<Tuple<string, object, string>>()
            {
             new Tuple<string, object, string>("phone",user.phone , "AND"),
             new Tuple<string, object, string>("password",user.password , ""),
            };
            var f = db.Users.SelectOne(whereConditions: whereConditions);
            f?.readFile();
            bool notNull = f != null;
            return new JsonResponse() { Status = notNull, Message = notNull ? "تمت العمليه بنجاح" : "حدث خطأ في العمليه", body = notNull ? new List<Dictionary<string, object>>() { f.json } : null };
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
