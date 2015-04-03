using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    public abstract class RssParser : IRssParser
    {
        public abstract RssVersion Version { get; }
        public static IRssParser Create(RssVersion version)
        {
            switch (version)
            {
                case RssVersion.Rss_0_90: return new Rss_0_90_Parser();
                case RssVersion.Rss_0_91: return new Rss_0_91_Parser();
                case RssVersion.Rss_0_92: return new Rss_0_92_Parser();
                case RssVersion.Rss_1_0: return new Rss_1_0_Parser();
                case RssVersion.Rss_2_0: return new Rss_2_0_Parser();
                case RssVersion.Atom: return new AtomParser();
            }
            throw new InvalidOperationException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public RssFeed Parse(String xml)
        {
            var feed = new RssFeed();
            feed.Version = this.Version;
            var doc = XDocument.Parse(xml);
            var element = doc.Root;

            feed.Channel = this.CreateRssChannel(element.ElementByNamespace("channel"));
            
            var image = element.ElementByNamespace("image");
            if (image == null)
            {
                var channel = element.ElementByNamespace("channel");
                if (channel != null)
                {
                    image = channel.ElementByNamespace("image");
                }
            }
            feed.Image = this.CreateRssImage(image);
            
            var items = element.ElementsByNamespace("item");
            if (!items.Any())
            {
                var channel = element.ElementByNamespace("channel");
                if (channel != null)
                {
                    items = channel.ElementsByNamespace("item");
                }
            }
            feed.Items.AddRange(items.Select(el => this.CreateRssItem(el)));

            var textInput = element.ElementByNamespace("textinput");
            if (textInput == null)
            {
                var channel = element.ElementByNamespace("channel");
                if (channel != null)
                {
                    textInput = channel.ElementByNamespace("textinput");
                }
            }
            feed.TextInput = this.CreateRssTextInput(image);

            return feed;
        }
        public abstract RssChannel CreateRssChannel(XElement element);
        public abstract RssItem CreateRssItem(XElement element);
        public abstract RssImage CreateRssImage(XElement element);
        public abstract RssTextInput CreateRssTextInput(XElement element);
    }
}
