using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UZ.TestBackEnd.Data.Intrefaces;
using UZ.TestBackEnd.Data.Models;

namespace UZ.TestBackEnd.Data.Concrete
{
    public class SurveyRepository : Repository<Survey>
    {
        public XDocument GetSurveys(DateTime dateTime)
        {
            string sql = sqlQueries.GetSurveysWhichNeedMoreDataSince(dateTime);
            XDocument xDocument = xmlService.GetXDocument(sql);
            return xDocument;
        }
    }
}
