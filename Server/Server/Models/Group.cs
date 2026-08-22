using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    internal class Group : EntityWithFile
    {
        override public Dictionary<string, Object> json
        {
            get
            {
                return new Dictionary<string, Object>()
                {

                    {
                        "id",
                        id
                    },

                    {
                        "name",
                        name
                    },


                      {
                 "img",//imagePath
                 filePath
                      },

                };
            }
        }

    }
}
