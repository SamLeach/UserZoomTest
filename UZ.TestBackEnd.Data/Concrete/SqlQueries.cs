using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZ.TestBackEnd.Data.Concrete
{
    public class SqlQueries
    {
        /// <summary>
        /// Query that return the total of tasks
        /// </summary>
        /// <returns></returns>
        public string GetTotalTasks()
        {
            return " SELECT  count(*) as total " +
                    " FROM MNG_TASK " +
                    " FOR XML PATH('data'), ROOT('tasks') ";
        }

        /// <summary>
        /// SQL Query that returns Surveys that are not complete with studies that have a description.
        /// </summary>
        /// <param name="datetime">Included date range</param>
        /// <returns>The SQL query (SPROC or ORM is preferred)</returns>
        public string GetSurveysWhichNeedMoreDataSince(DateTime datetime)
        {
            string dt = datetime.ToString("yyyyMMdd");

            string query = string.Format(" SELECT MNG_STUDY.title as studyTitle, " +
                                           " MNG_SURVEY.title as surveyTitle " +
                                          " ,MNG_SURVEY.completes " +
                                          " ,MNG_SURVEY.needed, " +
                                          " MNG_SURVEY.needed - MNG_SURVEY.completes AS participantsNeeded " +
                                          " FROM MNG_SURVEY " +
                                          " INNER JOIN MNG_STUDY on MNG_SURVEY.idStudy = MNG_STUDY.idStudy " +
                                          " WHERE MNG_SURVEY.completes < MNG_SURVEY.needed " +
                                          " AND MNG_STUDY.description != '' " +
                                          " AND MNG_STUDY.created > '{0}' " +
                                          " FOR XML PATH('data'), ROOT('surveys') ", dt);

            return query;
        }
    }
}
