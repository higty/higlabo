using System;
using HigLabo.Rss;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RssClient : HttpClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void GetRssFeed(Uri uri, Action<RssFeed> callback)
        {
            var cm = new HttpRequestCommand(uri.ToString());
            this.GetBodyText(cm, body => callback(RssFeed.Parse(body)));
        }
    }
}