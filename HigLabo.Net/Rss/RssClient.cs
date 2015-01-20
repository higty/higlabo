using System;
using HigLabo.Rss;

namespace HigLabo.Net
{
    public partial class RssClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public RssFeed GetRssFeed(String xml)
        {
            return RssFeed.Parse(xml);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rssFeed"></param>
        /// <returns></returns>
        public string Write(RssFeed rssFeed)
        {
            var writer = RssWriter.Create(rssFeed.Version);
            return writer.Write(rssFeed);
        }
    }
}
