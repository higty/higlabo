/*------------------------
 * Copyright http://www.developerzen.com/2009/01/11/aspnet-mvc-rss-feed-action-result/
------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace HigLabo.Web.Mvc
{
    public class RssResult : FileResult
    {
        private readonly SyndicationFeed _Feed;

        /// <summary>
        /// Creates a new instance of RssResult
        /// </summary>
        /// <param name="feed">The feed to return the user.</param>
        public RssResult(SyndicationFeed feed)
            : base("application/rss+xml")
        {
            _Feed = feed;
        }

        /// <summary>
        /// Creates a new instance of RssResult
        /// </summary>
        /// <param name="title">The title for the feed.</param>
        /// <param name="feedItems">The items of the feed.</param>
        public RssResult(string title, List<SyndicationItem> feedItems)
            : base("application/rss+xml")
        {
            _Feed = new SyndicationFeed(title, title, HttpContext.Current.Request.Url) { Items = feedItems };
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            using (XmlWriter writer = XmlWriter.Create(response.OutputStream))
            {
                _Feed.GetRss20Formatter().WriteTo(writer);
            }
        }
    }
}