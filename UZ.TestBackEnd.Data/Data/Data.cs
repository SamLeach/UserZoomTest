using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZ.TestBackEnd.Data.Data
{
    public class Data
    {
        private readonly string connectionString;

        public Data(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
