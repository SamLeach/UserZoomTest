using System;
using System.Collections.Generic;

namespace UZ.TestBackEnd.Services.Legacy
{
    public class XMLConstants
    {
        /// <summary>
        /// Structure that contains the XMLConstants for the XSLT
        /// </summary>
        public struct XSLTFiles
        {
            public const string htmlTotalTasks = "~/xslt/TotalTasks.xslt";
            public const string htmlSurveys = "~/xslt/SurveyTable.xslt";
            public const string htmlSurveysTotal = "~/xslt/TotalSurvey.xslt";
        }
    }
}