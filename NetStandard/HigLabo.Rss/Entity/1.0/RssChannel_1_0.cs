using System.Collections.Generic;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssChannel_1_0 : RssChannel_0_90
    {
        /// <summary>
        /// 
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssResource Image { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssChannelItems Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssResource TextInput { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssChannel_1_0()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssChannel_1_0(XElement element)
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
            About = element.CastAttributeToString("rdf", "about");

            var image = element.ElementByNamespace("image");
            if (image != null)
            {
                Image = new RssResource(RssNamespace.RDF + "image", image.CastAttributeToString("rdf", "resource"));
            }

            var items = element.ElementByNamespace("items");
            if (items != null)
            {
                Items = new RssChannelItems(items);
            }

            var textInput = element.ElementByNamespace("textinput");
            if (textInput != null)
            {
                TextInput = new RssResource(RssNamespace.RDF + "textinput", textInput.CastAttributeToString("rdf", "resource"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlns"></param>
        /// <returns></returns>
        public override XElement CreateElement(XNamespace xmlns)
        {
            return base.CreateElement(xmlns)
                .AddAttribute(RssNamespace.RDF + "about", About)
                .AddXmlObject(xmlns, Image)
                .AddXmlObject(xmlns, Items)
                .AddXmlObject(xmlns, TextInput);
        }
    }
}