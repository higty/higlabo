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
        public async Task<RssFeed> GetRssFeedAsync(String url)
        {
            var bodyText = await this.GetBodyTextAsync(url);
            return RssFeed.Parse(bodyText);
        }
    }
}