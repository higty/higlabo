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
        /// <summary>
        /// 
        /// </summary>
        public RssChannel_Atom() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssChannel_Atom(XElement element)
            : base(element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected new void Parse(XElement element)
        {
            foreach (var link in element.ElementsByNamespace("link"))
            {
                var type = link.CastAttributeToString("type");
                if (type != null && type.Contains("text/html") == true)
                {
                    this.Link = link.CastAttributeToString("href");
                }
            }
            this.Description = "";
        }
    }
}
