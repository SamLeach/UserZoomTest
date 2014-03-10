using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UZ.Constants;
using System.Xml.Linq;
using UZ.Tools;
using UZ.Data;

/// <summary>
/// Summary description for HTMLTasks
/// </summary>
public class HTMLTasks : HTMLBase
{
    public HTMLTasks()
    {
    }

    #region "Interface total tasks"

    /// <summary>
    /// Function that gets the total of tasks
    /// </summary>
    /// <returns></returns>
    private XDocument getXdocTotalTasks()
    {
        TaskDAO dao = new TaskDAO();
        string sSQL = dao.s_getTotalTasks();
        return myDB.getXDocument(sSQL, "tasks");
    }

    /// <summary>
    /// Returns the xDoc to render the xslt
    /// </summary>
    /// <returns></returns>
    private XDocument XDocHTMLTasks()
    {
        // Creates the root element
        XDocument xDocTasks = new XDocument(new XElement("root"));

        // Adds the total
        xDocTasks.Element("root").Add(this.getXdocTotalTasks().Elements());

        return xDocTasks;
    }

    /// <summary>
    /// Function that returns the hml for the total of tasks
    /// </summary>
    /// <returns></returns>
    public string getHTMLTasks()
    {
        return GlobalXML.ApplyXSLTransformation2(XMLConstants.XSLTFiles.htmlTotalTasks, XDocHTMLTasks(), false);
    }
    #endregion
}