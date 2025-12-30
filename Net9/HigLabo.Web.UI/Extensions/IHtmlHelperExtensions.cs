using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace HigLabo.Core;

public static class IHtmlHelperExtensions
{
    public static IHtmlContent AttrIf<TModel>(this IHtmlHelper<TModel> html, bool condition, string name)
    {
        return AttrIf(html, condition, name, "true");
    }
    public static IHtmlContent AttrIf<TModel>(this IHtmlHelper<TModel> html, bool condition, string name, string value)
    {
        if (!condition)
        {
            return HtmlString.Empty;
        }

        var encodedValue = HtmlEncoder.Default.Encode(value);
        return new HtmlString($"{name}=\"{encodedValue}\"");
    }
}
