using System;
using System.Threading.Tasks;
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
        public Task<RssFeed> GetRssFeedAsync(Uri uri)
        {
            return AsyncCall<Uri, RssFeed>(this.GetRssFeed, uri);
        }
    }
}