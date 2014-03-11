using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UZ.TestBackEnd.Services.Concrete;

namespace UZ.TestBackEnd.Services
{
    public abstract class Service
    {
        protected XmlToHtmlConverter converter;

        public Service()
        {
            converter = new XmlToHtmlConverter();
        }
    }
}
