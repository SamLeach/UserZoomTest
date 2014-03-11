using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UZ.TestBackEnd.Services.Concrete
{
    public class SurveyProcessing
    {
        public int Completes { get; set; }

        public XDocument GetTotalCompletes(XDocument surveys)
        {
            int completes = 0;
            if (surveys.Root != null)
            {
                completes = surveys
                            .Root
                            .Descendants("data")
                            .Descendants()
                            .Where(x => x.Name == "completes")
                            .Sum(y => int.Parse(y.Value));
            }

            Completes = completes;

            string xml = string.Format(@"
            <surveys>
              <data>
                <total>{0}</total>
              </data>
            </surveys>", completes);

            XDocument xdoc = XDocument.Parse(xml);
            return xdoc;
        }
    }
}
