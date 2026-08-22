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
                   
                    response = add(request);
                    //response.setStatus(result.Item1 > 0, action,message:result.Item2); 
                }
                else if (action == "update")
                {
                    response = update(request);
                    //response.setStatus(result.Item1 > -1, action,message:result.Item2);
                }
                else if (action == "delete")
                    {
                        response = delete(request);
                    //response.setStatus(result.Item1 > 0, action, message: result.Item2);
                }
                else if (action == "find")
                {
                    response = find(request);
                //    response.setStatus(action:action,data: json!=null? new List<Dictionary<string, object>>() { json }:null);
                //}
                }
                else if (action == "select")
                {
                    response=select(request);
                    //response.setStatus(action: action, data:select());
                }
                else
                {
                  response=Request(request);
                }
            }
            response.Page=request.Page;
            response.Action=request.Action;
            response.userId=request.userId;
            return response;
        }
      abstract public JsonResponse add(JsonRequest request);
        virtual public JsonResponse Request(JsonRequest request)
        {
            return new JsonResponse() { Status = false,Message="حدث خطأ ما" };
        }
        abstract public JsonResponse update(JsonRequest request);
      abstract public JsonResponse delete(JsonRequest request);
      abstract public JsonResponse find(JsonRequest request);
      abstract public JsonResponse select(JsonRequest request);


    }
}
