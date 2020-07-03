using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
	/// <summary>
	/// 
	/// </summary>
	public class RssItem_0_92 : RssItem_0_91
	{
		/// <summary>
		/// 
		/// </summary>
		public RssEnclosure Enclosure { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public RssCategory Category { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public RssSource Source { get; set; }
	
        /// <summary>
		/// 
		/// </summary>
		public RssItem_0_92()
		{
			
		}
	    /// <summary>
		/// 
		/// </summary>
		/// <param name="element"></param>
		public RssItem_0_92(XElement element)
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

			var category = element.ElementByNamespace("category");
			if (category != null)
			{
				Category = new RssCategory(category);
			}
		}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, Enclosure: {1}, Category: {2}, Source: {3}", base.ToString(), Enclosure, Category, Source);
        }
	}
}