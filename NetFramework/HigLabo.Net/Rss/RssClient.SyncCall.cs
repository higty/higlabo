using System;
using HigLabo.Rss;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RssClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public RssFeed GetRssFeed(Uri uri)
        {
            var cm = new HttpRequestCommand(uri.ToString());
            var body = this.GetBodyText(cm);

            return RssFeed.Parse(body);
        }
    }
}