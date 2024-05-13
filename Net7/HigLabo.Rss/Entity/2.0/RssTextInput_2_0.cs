using System.Xml.Linq;

namespace HigLabo.Rss
{
    public class RssTextInput_2_0 : RssTextInput_0_92
    {
        public RssTextInput_2_0()
        {
            
        }
        public RssTextInput_2_0(XElement element)
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