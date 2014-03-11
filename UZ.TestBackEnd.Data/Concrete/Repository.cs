using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZ.TestBackEnd.Data.Data;
using UZ.TestBackEnd.Data.Intrefaces;

namespace UZ.TestBackEnd.Data.Concrete
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly XmlService xmlService;
        protected readonly SqlQueries sqlQueries;

        public Repository()
        {
            // IoC Container this
            xmlService = new XmlService(new SqlCaller());
            sqlQueries = new SqlQueries();
        }

        public virtual T Get(T t)
        {
            throw new NotImplementedException();
        }

        public virtual T GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
