using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UZ.TestBackEnd.Data.Data;
using UZ.TestBackEnd.Data.Intrefaces;

namespace UZ.TestBackEnd.Data.Concrete
{
    public class TaskRepository : Repository<Task>
    {
        /// <summary>
        /// Get total number of tasks
        /// </summary>
        /// <returns>The data</returns>
        public XDocument GetTotalNumberOfTasks()
        {
            string sql = sqlQueries.GetTotalTasks();
            XDocument xDocument = xmlService.GetXDocument(sql);
            return xDocument;
        }
    }
}
