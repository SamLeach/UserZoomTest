using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UZ.TestBackEnd.Services.Concrete;

public partial class Surveys : System.Web.UI.Page
{
    private readonly SurveyService surveyService;

    // "ViewModel" Html
    public string html = string.Empty;
    public string total = string.Empty;

    public Surveys()
    {
        // Should constructor inject using IoC Container
        surveyService = new SurveyService();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Hard Code number of months...
        html = surveyService.GetHtmlSurveys(DateTime.Now.AddMonths(-12));

        GetAndSetTotalNumberOfSurveys();
    }

    /// <summary>
    /// Gets and sets total number of surveys
    /// </summary>
    private void GetAndSetTotalNumberOfSurveys()
    {
        int totalSurveys = surveyService.GetSurveysTotal();

        if (totalSurveys <= 10)
        {
            total = string.Empty;
        }
        total = surveyService.GetHtmlSurveysTotal();
    }
}