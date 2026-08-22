using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatUser.data.local
{
    public class DatabaseConnection
    {
        private string connectionString;
        static private string constConnectionString = "Server=localhost;DataBase=chat;Integrated Security=true";
        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DatabaseConnection()
        {

        }
        static public SqlConnection GetConnection()
        {
            return new SqlConnection(constConnectionString);
        }
    }
}
