using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Surveys : System.Web.UI.Page
{
    private readonly HTMLSurveys htmlSurveys;

    public string html = string.Empty;

    public string total = string.Empty;

    public Surveys()
    {
        htmlSurveys = new HTMLSurveys();        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        html = htmlSurveys.getHTMLSurveys(DateTime.Now.AddMonths(-12));

        total = htmlSurveys.getHTMLSurveysTotal();
        int t = htmlSurveys.getSurveysTotal();

        if (t <= 10)
        {
            total = string.Empty;
        }
    }
}