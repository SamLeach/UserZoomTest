using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Linq;
using System.Drawing.Imaging;

namespace UZ.Tools
{
    public struct GlobalXML
    {
        public static String ApplyXSLTransformation2(String xslFile, XDocument xDoc, bool bIncludeXSLTObjects)
        {
            String textHtml = "";
            MemoryStream myMemoryStream = new MemoryStream();
            XmlTextWriter myXmlTextWriter = new XmlTextWriter(myMemoryStream, System.Text.Encoding.UTF8);
            string xslt_path = HttpContext.Current.Server.MapPath(xslFile);
            XslCompiledTransform myXslTransform = LoadXslCompiledTransformFromCache(xslt_path, System.Web.Caching.Cache.NoSlidingExpiration);

            if (bIncludeXSLTObjects == true)
            {
                XsltArgumentList xslArg = new XsltArgumentList();
                XSLTObjects myXSLTObjects = new XSLTObjects();
                xslArg.AddExtensionObject("urn:XSLTObjects", myXSLTObjects);
                myXslTransform.Transform(xDoc.CreateNavigator(), xslArg, myXmlTextWriter);
                xslArg.Clear();
                xslArg = null;
            }
            else
            {
                myXslTransform.Transform(xDoc.CreateNavigator(), myXmlTextWriter);
            }

            myXmlTextWriter.Flush();
            myMemoryStream.Position = 0;
            StreamReader myStreamReader = new StreamReader(myMemoryStream);
            textHtml = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myXmlTextWriter.Close();
            return textHtml.ToString();
        }

        private static XslCompiledTransform LoadXslCompiledTransformFromCache(string strKey, TimeSpan timeExpiration)
        {
            XslCompiledTransform myXslTransform = null;
            myXslTransform = (XslCompiledTransform)(HttpRuntime.Cache[strKey]);

            if (myXslTransform == null)
            {
                myXslTransform = new XslCompiledTransform();
                myXslTransform.Load(strKey);
                System.Web.Caching.CacheDependency dep = new System.Web.Caching.CacheDependency(strKey);
                HttpRuntime.Cache.Insert(strKey, myXslTransform, dep, System.Web.Caching.Cache.NoAbsoluteExpiration, timeExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            }
            return myXslTransform;
        }
    }
}
