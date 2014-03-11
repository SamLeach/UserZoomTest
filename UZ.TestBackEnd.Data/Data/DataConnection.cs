using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZ.TestBackEnd.Data.Data
{
    public class DataConnection
    {
        public string ConnectionString { get; set; }

        public DataConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
