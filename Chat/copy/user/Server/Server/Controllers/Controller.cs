using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.Controllers
{
  abstract  public class Controller
    {
     
      //protected  Dictionary<string, object> data;
       protected readonly DbContext db;
        protected JsonRequest request;
        public Controller() {
        db = new DbContext();
        }
   virtual   public   JsonResponse processingRequest(JsonRequest request )
        {
            this.request = request;
          JsonResponse response=new JsonResponse() { Status=false};
          string action=request.Action;
          
            if (action != null) 
            {
                if (action=="add")
                {
                   
                    response = add();
                    //response.setStatus(result.Item1 > 0, action,message:result.Item2); 
                }
                else if (action == "update")
                {
                    response = update();
                    //response.setStatus(result.Item1 > -1, action,message:result.Item2);
                }
                else if (action == "delete")
                    {
                        response = delete();
                    //response.setStatus(result.Item1 > 0, action, message: result.Item2);
                }
                else if (action == "find")
                {
                    response = find();
                //    response.setStatus(action:action,data: json!=null? new List<Dictionary<string, object>>() { json }:null);
                //}
                }
                else if (action == "select")
                {
                    response=select();
                    //response.setStatus(action: action, data:select());
                }
                else
                {
                  response=Request();
                }
            }
            response.Page=request.Page;
            response.Action=request.Action;
            response.userId=request.userId;
            return response;
        }
      abstract public JsonResponse add();
        virtual public JsonResponse Request()
        {
            return new JsonResponse() { Status = false,Message="حدث خطأ ما" };
        }
        abstract public JsonResponse update();
      abstract public JsonResponse delete();
      abstract public JsonResponse find();
      abstract public JsonResponse select();


    }
}
