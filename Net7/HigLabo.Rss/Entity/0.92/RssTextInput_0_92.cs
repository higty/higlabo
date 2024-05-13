using System.Xml.Linq;

namespace HigLabo.Rss
{
    public class RssTextInput_0_92 : RssTextInput_0_91
    {
        public RssTextInput_0_92()
        {
            
        }
        public RssTextInput_0_92(XElement element)
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