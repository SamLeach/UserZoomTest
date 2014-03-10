using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UZ.TestBackEnd.Data.Intrefaces
{
    public interface IRepository<T> where T : class
    {
         T Get(T t);
         T GetAll();
    }
}
