using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using UZ.Tools;
using UZ.Constants;

namespace UZ.Data
{
    /// <summary>
    /// Class for the Data Base interaction
    /// </summary>
    public class dbClass
    {
        private readonly HttpResponse Response = HttpContext.Current.Response;

        public int debuglvl;

        public dbClass()
        {
        }

        /// <summary>
        /// Returns the xDoc for the given query
        /// </summary>
        /// <param name="sql_sent"></param>
        /// <param name="rootTag"></param>
        /// <returns></returns>
        public XDocument getXDocument(String sql_sent, String rootTag)
        {
            return new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), XElement.Parse(getXMLString(sql_sent, rootTag)));
        }

        /// <summary>
        /// Returns the xml of the result for the given query
        /// </summary>
        /// <param name="sql_sent"></param>
        /// <param name="rootTag"></param>
        /// <returns></returns>
        public string getXMLString(String sql_sent, String rootTag)
        {
            string retorna = "";

            try
            {
                XmlReader mySqlXmlReader = GetXMLDR(sql_sent);
                if (mySqlXmlReader != null)
                {
                    StringBuilder sb = new StringBuilder();
                    while (mySqlXmlReader.Read())
                    {
                        sb.AppendLine(mySqlXmlReader.ReadOuterXml());
                    }
                    retorna = sb.ToString();
                    mySqlXmlReader.Close();
                    mySqlXmlReader = null;
                }
            }
            catch (Exception e)
            {
                if (debuglvl >= 2) Response.Write("<span style='color:#ff0000'>Error: " + e.Message + "</span><br><br>");
                if (debuglvl >= 10) throw e;
            }
            if (retorna.Trim() == "") retorna = "<" + rootTag + "></" + rootTag + ">";
            return retorna;
        }

        /// <summary>
        /// Returns SQLDataReader for the given sql
        /// </summary>
        /// <param name="sql_sent"></param>
        /// <returns></returns>
        public XmlReader GetXMLDR(String sql_sent)
        {
            SqlConnection sqlConn = new SqlConnection(getStrConnection());
            sqlConn.Open();
            XmlReader mySqlXMLReader = null;
            DateTime Start = DateTime.Now;
            if (debuglvl == 2) { Response.Write(sql_sent + "<br><br>"); }
            try
            {
                SqlCommand mySqlCommand = new SqlCommand(sql_sent, sqlConn);
                mySqlCommand.CommandTimeout = 355;
                mySqlXMLReader = mySqlCommand.ExecuteXmlReader();
            }
            catch (Exception e)
            {
                if (debuglvl >= 2)
                {
                    Response.Write("<span style='color:#ff0000'>Error: " + e.Message + "</span><br><br>");
                    if (debuglvl >= 10) throw e;
                }
            }
            finally
            {
            }
            if (debuglvl == 2) { Response.Write("" + ((DateTime.Now) - Start).Milliseconds + " ms<br><br>"); }

            return mySqlXMLReader;
        }

        public String getStrConnection()
        {
            String retorna = @"Server= 192.168.1.116\SQLEXPRESS; Database= MANAGER_TBE; user id=david;password=rmn12345*;";

            return retorna.Trim();
        }

        ~dbClass()
        {

        }
    }
}
