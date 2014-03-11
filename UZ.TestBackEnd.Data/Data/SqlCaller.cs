using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;
using System.Data.SqlClient;


namespace UZ.TestBackEnd.Data.Data
{
    public class SqlCaller
    {
        // These should be somewhere else
        private readonly HttpResponse Response = HttpContext.Current.Response;
        public int debuglvl;

        private DataConnection data;

        public SqlCaller()
        {
            data = new DataConnection(@"Server= 192.168.1.116\SQLEXPRESS; Database= MANAGER_TBE; user id=david;password=rmn12345*;");
        }

        public XmlReader Call(string sql)
        {
            SqlConnection sqlConn = new SqlConnection(data.ConnectionString);
            sqlConn.Open();
            XmlReader mySqlXMLReader = null;
            DateTime Start = DateTime.Now;
            if (debuglvl == 2) { Response.Write(sql + "<br><br>"); }
            try
            {
                SqlCommand mySqlCommand = new SqlCommand(sql, sqlConn);
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
    }
}
