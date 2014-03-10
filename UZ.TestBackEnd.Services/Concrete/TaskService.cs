using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZ.TestBackEnd.Data.Concrete;
using UZ.TestBackEnd.Data.Intrefaces;

namespace UZ.TestBackEnd.Services.Concrete
{
    public class TaskService
    {
        private readonly TaskRepository taskRepository;

        public TaskService()
        {
            this.taskRepository = new TaskRepository();
        }

        public int GetTotalNumberOfTasks()
        {
            return this.taskRepository.GetTotalNumberOfTasks();
        }
    }
}
