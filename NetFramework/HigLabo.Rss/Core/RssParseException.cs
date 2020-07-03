using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Rss
{
    public class RssParseException : Exception
    {
        public String Xml { get; private set; }
        public RssParseException(String xml)
        {
            this.Xml = xml;
        }
    }
}
