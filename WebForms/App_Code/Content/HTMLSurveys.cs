using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using UZ.Constants;
using UZ.Data;
using UZ.Tools;

/// <summary>
/// Descripción breve de HTMLSurveys
/// </summary>
public class HTMLSurveys : HTMLBase
{
	public HTMLSurveys()
	{
        dateTime = DateTime.Now;
	}

    private DateTime dateTime;
    private int completes;

    /// <summary>
    /// Function that gets the total of tasks
    /// </summary>
    /// <returns></returns>
    private XDocument getXdocSurvey()
    {
        TaskDAO dao = new TaskDAO();
        string sSQL = dao.s_getSurveysWhichNeedMoreDataSince(this.dateTime);
        return myDB.getXDocument(sSQL, "surveys");
    }

    /// <summary>
    /// Function that gets the total of tasks
    /// </summary>
    /// <returns></returns>
    private XDocument getXdocSurveyTotal()
    {
        XDocument foo = getXdocSurvey();

        int completes = 0;

        if (foo.Root != null)
        {
            var ff = foo.Root.Descendants("data");

            completes = ff.Descendants()
                .Where(x => x.Name == "completes")
                .Sum(y => int.Parse(y.Value));
        }

        this.completes = completes;
        

        string xml = string.Format(@"
            <surveys>
              <data>
                <total>{0}</total>
              </data>
            </surveys>", completes);

        XDocument xdoc = XDocument.Parse(xml);
        return xdoc;
    }

    private XDocument XDocHTMLSurveys2()
    {
        // Creates the root element
        XDocument xDocTasks = new XDocument(new XElement("root"));

        XDocument surveys = this.getXdocSurveyTotal();

        xDocTasks.Element("root").Add(surveys.Elements());

        return xDocTasks;
    }

    /// <summary>
    /// Returns the xDoc to render the xslt
    /// </summary>
    /// <returns></returns>
    private XDocument XDocHTMLSurveys()
    {
        // Creates the root element
        XDocument xDocTasks = new XDocument(new XElement("root"));

        XDocument surveys = this.getXdocSurvey();

        xDocTasks.Element("root").Add(surveys.Elements());

        return xDocTasks;
    }

    /// <summary>
    /// Function that returns the html for the survey table
    /// </summary>
    /// <returns></returns>
    public string getHTMLSurveys(DateTime datetime)
    {
        this.dateTime = datetime;
        return GlobalXML.ApplyXSLTransformation2(XMLConstants.XSLTFiles.htmlSurveys, XDocHTMLSurveys(), false);
    }

    /// <summary>
    /// Function that returns the html for the survey table
    /// </summary>
    /// <returns></returns>
    public string getHTMLSurveysTotal()
    {
        return GlobalXML.ApplyXSLTransformation2(XMLConstants.XSLTFiles.htmlSurveysTotal, XDocHTMLSurveys2(), false);
    }

    public int getSurveysTotal()
    {
        return this.completes;
    }
}