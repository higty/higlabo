using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssImage_0_91 : RssImage
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssImage_0_91()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssImage_0_91(XElement element)
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