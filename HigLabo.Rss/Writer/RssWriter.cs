using System;
using System.Xml.Linq;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class RssWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public RssWriter()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rssFeed"></param>
        /// <returns></returns>
        public abstract string Write(RssFeed rssFeed);
        public static RssWriter Create(RssVersion version)
        {
            switch (version)
            {
                case RssVersion.Rss_0_90: return new Rss_0_90_Writer();
                case RssVersion.Rss_0_91: return new Rss_0_91_Writer();
                case RssVersion.Rss_1_0: return new Rss_1_0_Writer();
                case RssVersion.Rss_0_92:
                case RssVersion.Rss_2_0:
                case RssVersion.Atom:
                default: throw new InvalidOperationException();
            }
        }
    }
}