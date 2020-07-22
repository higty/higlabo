using System;
using System.Text;
using System.Web;
using HigLabo.Net;
using HtmlAgilityPack;
using HigLabo.Core;

namespace HigLabo.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            var cl = new HttpClient();
            cl.ResponseEncoding = Encoding.UTF8;

            try
            {
                var url = "https://www.amazon.co.jp/gp/product/B004MXPY70?pf_rd_p=3d322af3-60ce-4778-b834-9b7ade73f617&pf_rd_r=K0ATYP75NCR0XA0YKGC4";
                //url = "https://www.astro.ai";
                var res = cl.GetResponseAsync(url).GetAwaiter().GetResult();
                var body = res.BodyText;

                var doc = new HtmlDocument();
                doc.LoadHtml(res.BodyText);

                var title = HttpUtility.HtmlDecode(doc.DocumentNode.SelectSingleNode("//head//title")?.InnerText ?? "");
                if (title.IsNullOrEmpty())
                {
                    title = GetOpenGraphValue(doc, "title") ?? "";
                }
                var siteName = GetOpenGraphValue(doc, "site_name") ?? "";
                var iconUrl = GetNodeAttributeValue(doc, "//head//link[@rel='shortcut icon']", "href");
                var imageUrl = GetOpenGraphValue(doc, "image") ?? "";
                var description = GetOpenGraphValue(doc, "description") ?? "";

                Console.WriteLine(body);
            }
            catch (Exception ex)
            {
                var meg = ex.ToString();
            }
        }
        private static String GetOpenGraphValue(HtmlDocument document, String propertyName)
        {
            var doc = document;
            var xPath = String.Format("//meta[@property=\"og:{0}\"]", propertyName);
            var text = doc.DocumentNode.SelectSingleNode(xPath)?.Attributes["content"]?.Value;

            return HttpUtility.HtmlDecode(text);
        }
        private static String GetNodeAttributeValue(HtmlDocument document, String path, String name)
        {
            var doc = document;
            var node = doc.DocumentNode.SelectSingleNode(path);
            if (node != null)
            {
                return node.GetAttributeValue(name, "");
            }
            return "";
        }
    }
}
