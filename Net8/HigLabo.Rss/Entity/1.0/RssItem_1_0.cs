using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    public class RssItem_1_0 : RssItem_0_90
    {
        public string About { get; set; } = "";

        public RssItem_1_0()
        {
            
        }
        public RssItem_1_0(XElement element)
            : base(element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
        protected new void Parse(XElement element)
        {
            About = element.CastAttributeToString("rdf", "about") ?? "";
            Description = element.CastElementToString("description") ?? "";
            this.Date = RssItem.ParseDate(element.CastElementToString("dc", "date") ?? "");
        }
    }
}