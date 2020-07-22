using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssItem : RssXmlObject
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? PubDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public RssItem()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssItem(XElement element)
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
        /// <returns></returns>
        protected void Parse(XElement element)
        {
            Title = element.CastElementToString("title");
            Link = element.CastElementToString("link");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pubDate"></param>
        /// <returns></returns>
        public static DateTimeOffset? ParsePubDate(String pubDate)
        {
            DateTimeOffset dtime = DateTimeOffset.MinValue;
            if (String.IsNullOrEmpty(pubDate) == true) { return null; }
            if (DateTimeOffset.TryParse(pubDate, out dtime) == true)
            {
                return dtime;
            }
            else
            {
                String tmp = pubDate;
                tmp = tmp.Substring(0, tmp.Length - 5);
                tmp += "GMT";
                if (DateTimeOffset.TryParse(tmp, out dtime) == true)
                {
                    return dtime;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTimeOffset? ParseDate(String date)
        {
            DateTimeOffset dtime = DateTimeOffset.MinValue;
            if (String.IsNullOrEmpty(date) == true) { return null; }
            if (DateTimeOffset.TryParse(date, out dtime) == true)
            {
                return dtime;
            }
            else
            {
                String tmp = date;
                tmp = tmp.Substring(0, tmp.Length - 6);
                tmp += "Z";
                if (DateTimeOffset.TryParse(tmp, out dtime) == true)
                {
                    return dtime;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Title: {0}, Link: {1}", Title, Link);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlns"></param>
        /// <returns></returns>
        public override XElement CreateElement(XNamespace xmlns)
        {
            return new XElement(xmlns + "item")
                .AddElement(xmlns + "title", Title)
                .AddElement(xmlns + "link", Link);
        }
    }
}