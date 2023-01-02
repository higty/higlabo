using HigLabo.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public static class HttpRequestExtensions
    {
        public static class ItemsKey
        {
            public static String HeaderText = "TinyBetter.Web.HttpRequestExtensions.HeaderText";
            public static String BodyText = "TinyBetter.Web.HttpRequestExtensions.BodyText";
        }
        public static String GetRequestHeaderText(this HttpRequest request)
        {
            var cx = request.HttpContext;
            var text = cx.Items[ItemsKey.HeaderText]?.ToString();

            if (text.IsNullOrEmpty())
            {
                StringBuilder sb = new StringBuilder();

                foreach (var header in request.Headers)
                {
                    sb.AppendFormat("{0}: {1}", header.Key, header.Value.ToString());
                    sb.AppendLine();
                }
                cx.Items[ItemsKey.HeaderText] = sb.ToString();
            }
            return cx.Items[ItemsKey.HeaderText].ToString();
        }
        public static async Task<String> GetRequestBodyTextAsync(this HttpRequest request)
        {
            return await new StreamReader(request.Body).ReadToEndAsync();
        }

        public static Dictionary<String, String> CreateDictionaryFromRequestFormAsync(this HttpRequest request)
        {
            var d = new Dictionary<String, String>();
            foreach (var item in request.Form)
            {
                d[item.Key] = item.Value;
            }
            return d;
        }

        public static Boolean IsXMLHttpRequest(this HttpRequest request)
        {
            return String.Equals(request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.OrdinalIgnoreCase);
        }
        public static String GetPathAndQuery(this HttpRequest request)
        {
            var req = request;
            var pathAndQuery = req.Path;
            if (req.GetDisplayUrl().Contains('?'))
            {
                pathAndQuery += "?" + req.GetDisplayUrl().ExtractString('?', null);
            }
            return pathAndQuery;
        }
        public static String GetDomainName(this HttpRequest request)
        {
            return request.Headers["Host"].ToString();
        }
        public static String GetClientIPAddressText(this HttpRequest request)
        {
            var ip = GetClientIPAddress(request);
            if (ip == null) { return ""; }
            return ip.ToString();
        }
        public static IPAddress_v4 GetClientIPAddress(this HttpRequest request)
        {
            var req = request;
            var cx = req.HttpContext;

            var ip = req.Headers["X-Forwarded-For"].ToString();
            if (ip.IsNullOrEmpty())
            {
                ip = req.Headers["X-Original-For"].ToString();
            }
            if (ip.IsNullOrEmpty())
            {
                ip = cx.Connection.RemoteIpAddress.ToString();
            }
            if (ip.IsNullOrEmpty())
            {
                ip = cx.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
            }
            var ipAddress = IPAddress_v4.TryCreate(ip);

            return ipAddress;
        }
        public static String GetUserAgent(this HttpRequest request)
        {
            return request.Headers["User-Agent"].ToString();
        }
        public static String GetReferer(this HttpRequest request)
        {
            return request.Headers["Referer"].ToString();
        }
    }
}
