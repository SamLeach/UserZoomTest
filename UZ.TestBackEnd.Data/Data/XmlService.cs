using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace UZ.TestBackEnd.Data.Data
{
    public class XmlService
    {
        // These should be somewhere else
        private readonly HttpResponse Response = HttpContext.Current.Response;
        public int debuglvl;

        private SqlCaller sqlCaller;

        public XmlService(SqlCaller sqlCaller)
        {
            this.sqlCaller = sqlCaller;
        }

        /// <summary>
        /// Returns the xDoc for the given query
        /// </summary>
        /// <param name="sql">The sql query</param>
        /// <param name="rootTag">The root tag</param>
        /// <returns>The XDocument</returns>
        public XDocument GetXDocument(string sql, string rootTag = "root")
        {
            return new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), XElement.Parse(GetXml(sql, rootTag)));
        }

        /// <summary>
        /// Returns the xml of the result for the given query
        /// </summary>
        /// <param name="sql">The sql query</param>
        /// <param name="rootTag">The root tag</param>
        /// <returns>The Xml</returns>
        private string GetXml(string sql, string rootTag)
        {
            string retorna = "";

            try
            {
                XmlReader mySqlXmlReader = this.sqlCaller.Call(sql);
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
    }
}
