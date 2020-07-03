using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using HigLabo.Core;

namespace HigLabo.Bot.Facebook.Send
{
    public class UrlButton : IButton
    {
        public String Url { get; set; }
        public String Title { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public WebViewHeightRatio WebViewHeightRatio { get; set; }
        public String FallbackUrl { get; set; }

        public UrlButton()
        {
            this.WebViewHeightRatio = WebViewHeightRatio.Full;
        }
        public string CreateJson()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            {
                sb.Append("\"type\":\"web_url\",");
                sb.Append("\"url\":\"").AppendJsonEncoded(this.Url).Append("\",");
                sb.Append("\"title\":\"").AppendJsonEncoded(this.Title).Append("\",");
                sb.Append("\"webview_height_ratio\":\"").Append(this.WebViewHeightRatio.ToStringFromEnum().ToLower()).Append("\",");
                sb.Append("\"fallback_url\":\"").AppendJsonEncoded(this.FallbackUrl).Append("\"");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
