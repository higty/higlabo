using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    public class RssImage_0_91 : RssImage
    {
        public int? Width { get; set; }
        public int? Height { get; set; }
        public RssImage_0_91()
        {
            
        }
        public RssImage_0_91(XElement element)
            : base(element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
        protected new void Parse(XElement element)
        {
            if (int.TryParse(element.CastElementToString("width"), out var w))
            {
                this.Width = w;
            }
            if (int.TryParse(element.CastElementToString("height"), out var h))
            {
                this.Height = h;
            }
        }
    }
}