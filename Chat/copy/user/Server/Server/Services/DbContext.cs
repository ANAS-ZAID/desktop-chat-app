using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class DbContext
    {
        public DataSet<Users> Users { get; } = new DataSet<Users>();
        public DataSet<Messages> Messages { get; } = new DataSet<Messages>();
    }
}
