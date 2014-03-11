using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UZ.TestBackEnd.Data.Concrete;
using UZ.TestBackEnd.Data.Models;
using UZ.TestBackEnd.Services.Legacy;

namespace UZ.TestBackEnd.Services.Concrete
{
    public class SurveyService : Service
    { 
        private readonly SurveyRepository surveyRepository;

        private XDocument surveys;
        private int completes;
        public SurveyService()
        {
            // IoC
            this.surveyRepository = new SurveyRepository();

            surveys = new XDocument();
        }

        /// <summary>
        /// Function that returns the html for the survey table
        /// </summary>
        /// <returns></returns>
        public string GetHtmlSurveys(DateTime datetime)
        {
            surveys = this.surveyRepository.GetSurveys(datetime);

            string html = base.converter.Convert(XMLConstants.XSLTFiles.htmlSurveys, surveys);
            return html;
        }

        public string GetHtmlSurveysTotal()
        {
            SurveyProcessing surveryQuery = new SurveyProcessing();
            XDocument xDocument = surveryQuery.GetTotalCompletes(surveys);
            this.completes = surveryQuery.Completes;

            string html = base.converter.Convert(XMLConstants.XSLTFiles.htmlSurveysTotal, xDocument);
            return html;
        }

        public int GetSurveysTotal()
        {
            return this.completes;
        }
    }
}
