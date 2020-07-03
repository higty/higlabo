using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using X = HigLabo.Web.HttpDefaultContext;

namespace HigLabo.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Text(this HtmlHelper helper, Boolean condition, String trueText, String falseText)
        {
            if (condition == true)
            {
                return new MvcHtmlString(trueText);
            }
            return new MvcHtmlString(falseText);
        }
        public static MvcHtmlString IsNullText(this HtmlHelper helper, String text, String textWhenNullOrEmpty)
        {
            if (String.IsNullOrWhiteSpace(text) == true)
            {
                return new MvcHtmlString(textWhenNullOrEmpty);
            }
            return new MvcHtmlString(text);
        }

        public static void AddJavaScriptFileReference(this HtmlHelper htmlHelper, String url)
        {
            var l = X.Current.JavaScriptUrls;
            if (l.Contains(url) == false)
            {
                l.Add(url);
            }
        }
        public static MvcHtmlString RenderJavaScriptTag(this HtmlHelper HtmlHelper)
        {
            StringBuilder sb = new StringBuilder();
            var l = X.Current.JavaScriptUrls;

            foreach (var url in l)
            {
                sb.AppendFormat("<script type=\"text/javascript\" src=\"{0}\"></script>", url).AppendLine();
            }
            return MvcHtmlString.Create(sb.ToString());
        }
        public static void AddStyleSheetFileReference(this HtmlHelper htmlHelper, String url)
        {
            var l = X.Current.StyleSheetUrls;
            if (l.Contains(url) == false)
            {
                l.Add(url);
            }
        }
        public static MvcHtmlString RenderStyleSheetTag(this HtmlHelper htmlHelper)
        {
            StringBuilder sb = new StringBuilder();
            var l = X.Current.StyleSheetUrls;

            foreach (var url in l)
            {
                sb.AppendFormat("<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\" />", url).AppendLine();
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}
