using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    public class RssTextInput_Atom : RssTextInput
    {
        public RssTextInput_Atom() {}
        public RssTextInput_Atom(XElement element)
            : base(element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
        protected new void Parse(XElement element)
        {
        }
    }
}
