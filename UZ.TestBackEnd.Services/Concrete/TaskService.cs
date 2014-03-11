using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UZ.TestBackEnd.Data.Concrete;
using UZ.TestBackEnd.Data.Intrefaces;
using UZ.TestBackEnd.Services.Legacy;

namespace UZ.TestBackEnd.Services.Concrete
{
    public class TaskService : Service
    {
        private readonly TaskRepository taskRepository;

        public TaskService()
        {
            // Ioc
            this.taskRepository = new TaskRepository();
        }

        public string GetTotalNumberOfTasksHtml()
        {
            // Get the data
            XDocument xDocument = this.taskRepository.GetTotalNumberOfTasks();

            // Convert to html ready for the view to consume
            string html = base.converter.Convert(XMLConstants.XSLTFiles.htmlTotalTasks, xDocument);
            return html;
        }
    }
}
