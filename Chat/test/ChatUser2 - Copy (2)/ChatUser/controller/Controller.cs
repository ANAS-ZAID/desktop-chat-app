using ChatUser.data.local;
using ChatUser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.controller
{
    enum PossessType
    {
        add,
        update,
        delete,
        select,
        find,
        nan
    }
    abstract class Controller
    {
        PossessType possessType;    
        protected readonly DbContext db;
       abstract protected  string page {   get; }
        protected  readonly NetworkService network= NetworkService.Instance;
        //private JsonRequest JsonRequest;
         public  Controller( Action<JsonResponse> MessageReceived = null)
        {
            db = new DbContext();
             //JsonRequest = new JsonRequest() { Page=page,};
            possessType = PossessType.nan;
             //this.network = network;
             this.network.MessageReceived += OnMessageReceived;
            if (MessageReceived != null)
            {
                this.network.MessageReceived += MessageReceived;
            }
        }
        public void  request(JsonRequest jsonRequest)
        {
            if (jsonRequest == null) return;
            if(jsonRequest.Page==null)
                jsonRequest.Page =page;
            network.send(jsonRequest);
        }
        abstract public void OnMessageReceived(JsonResponse response);

         virtual   public void add()
        {

        }


        virtual public void update()
        {

        }
       
        virtual public void delete()
        {

        }
        virtual public void select()
        {

         request(new JsonRequest() { Action="select",});
        }
        virtual public void find()
        {

          
        }

        virtual public string Notification(JsonResponse notification)
        {
            return "";
        }
    }
}
