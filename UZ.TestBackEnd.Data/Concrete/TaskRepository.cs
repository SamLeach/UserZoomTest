using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZ.TestBackEnd.Data.Intrefaces;

namespace UZ.TestBackEnd.Data.Concrete
{
    public class TaskRepository : IRepository<Task>
    {
        public Task Get(Task task)
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetTotalNumberOfTasks()
        {
            return 0;
        }
    }
}
