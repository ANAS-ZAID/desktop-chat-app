using ChatUser.data.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUser.data.local
{
    internal class DbContext
    {
      public  DataSet<Users> Users { get; } = new DataSet<Users>();
    }
}