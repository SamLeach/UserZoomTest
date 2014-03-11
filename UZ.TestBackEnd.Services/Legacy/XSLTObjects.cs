using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UZ.TestBackEnd.Services.Legacy
{
    /// <summary>
    /// Summary description for XLSTObjects
    /// </summary>
    public class XSLTObjects
    {
        public XSLTObjects()
        {
        }

        private Int64 g_increment = 0;

        public Int64 f_increment()
        {
            g_increment = g_increment + 1;
            return g_increment;
        }
    }
}