using System.Collections.Generic;
using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
	public class RssItem_0_92 : RssItem_0_91
	{
		public RssEnclosure Enclosure { get; set; } = new();
		public List<RssCategory> CategoryList { get; set; } = new();
        public RssSource Source { get; set; } = new();

        public RssItem_0_92()
		{
			
		}
		public RssItem_0_92(XElement element)
			: base(element)
		{
			if (element != null)
			{
				Parse(element);
			}
		}
		protected new void Parse(XElement element)
		{
			var enclosure = element.ElementByNamespace("enclosure");
			if (enclosure != null)
			{
				Enclosure = new RssEnclosure(enclosure);
			}

			var source = element.ElementByNamespace("source");
			if (source != null)
			{
				Source = new RssSource(source);
			}

			foreach (var item in element.ElementsByNamespace("category"))
			{
				var r = new RssCategory(item);
				this.CategoryList.Add(r);
			}
		}
        public override string ToString()
        {
            return string.Format("{0}, Enclosure: {1}, Source: {2}", base.ToString(), Enclosure, Source);
        }
	}
}