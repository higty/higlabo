using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Rss.Extensions;

namespace HigLabo.Rss
{
    public class RssItem_Atom : RssItem
    {
        public String ID { get; set; }
        public string Summary { get; set; }
        public List<string> Authors { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public RssItem_Atom()
            : this(null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssItem_Atom(XElement element)
            : base(element)
        {
            this.Authors = new List<string>();
            if (element != null)
            {
                Parse(element);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected new void Parse(XElement element)
        {
            this.ID = element.CastElementToString("id");
            this.PubDate = RssItem.ParseDate(element.CastElementToString("published"));
            this.Date = RssItem.ParseDate(element.CastElementToString("updated"));
            var author = element.ElementByNamespace("author");
            foreach (var name in author.ElementsByNamespace("name"))
            {
                this.Authors.Add(name.Value);
            }
            this.Link = element.ElementByNamespace("link").CastAttributeToString("href");
            this.Summary = element.CastElementToString("summary");
            this.Description = element.CastElementToString("content");
        }
        /*
         <title>ツアーだツアーだっ (o・・o)</title>
  <link rel="alternate" type="text/html" href="http://blog.nogizaka46.com/sayuri.matsumura/2014/08/019884.php" />
  <id>tag:blog.nogizaka46.com,2014:/sayuri.matsumura//169.19884</id>
  <published>2014-08-15T14:42:01Z</published>
  <updated>2014-08-15T14:50:00Z</updated>
  <summary><![CDATA[こんばんごっ(o・・o)さゆりんごっ(o・・o)&nbsp;&nbsp;&nbs...]]></summary>
  <author>
    <name>松村沙友理</name>
  </author>
  <content */
    }
}
