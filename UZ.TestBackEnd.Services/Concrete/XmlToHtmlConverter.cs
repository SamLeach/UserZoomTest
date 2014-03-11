using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UZ.TestBackEnd.Services.Legacy;

namespace UZ.TestBackEnd.Services.Concrete
{
    public class XmlToHtmlConverter
    {
        public string Convert(string xsltPath, XDocument document)
        {
            XDocument xDocTasks = SetRootElement(document);
            return GlobalXML.ApplyXSLTransformation(xsltPath, xDocTasks, false);
        }

        private static XDocument SetRootElement(XDocument document)
        {
            // Creates the root element
            XDocument xDocTasks = new XDocument(new XElement("root"));
            xDocTasks.Element("root").Add(document.Elements());
            return xDocTasks;
        }
    }
}
