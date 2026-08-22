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
        //public bool isPossessingRequest=
       abstract protected  string page {   get; }
       static protected   NetworkService network= NetworkService.Instance;
        //private JsonRequest JsonRequest;
         public  Controller()
        {
            db = new DbContext();
             //JsonRequest = new JsonRequest() { Page=page,};
            possessType = PossessType.nan;
            //this.network = network;
           network.MessageReceived += OnMessageReceived;
            //if (MessageReceived != null)
            {
                //this.network.MessageReceived += OnMessageReceived;
            }
        }
        public void  request(JsonRequest jsonRequest)
        {
            if (jsonRequest == null) return;
            if(jsonRequest.Page==null)
                jsonRequest.Page =page;
            //MessageBox.Show($"requestPage:{page}");
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
