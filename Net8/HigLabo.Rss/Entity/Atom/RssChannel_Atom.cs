using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    public class RssChannel_Atom : RssChannel
    {
        public RssChannel_Atom() {}
        public RssChannel_Atom(XElement element)
            : base(element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
        protected new void Parse(XElement element)
        {
            foreach (var link in element.ElementsByNamespace("link"))
            {
                var type = link.CastAttributeToString("type");
                if (type != null && type.Contains("text/html") == true)
                {
                    this.Link = link.CastAttributeToString("href") ?? "";
                }
            }
            this.Description = "";
        }
    }
}
