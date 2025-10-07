using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Web;

namespace HigLabo.Core;

public static class HttpResponseExtensions
{
    public static JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings();

    public static void ServerClassInvoke(this HttpResponse response, string className, string functionName)
    {
        ServerClassInvoke(response, className, functionName, []);
    }
    public static void ServerClassInvoke(this HttpResponse response, string className, string functionName, IEnumerable<string> arguments)
    {
        var r = new
        {
            ClassName = className,
            FunctionName = functionName,
            Args = arguments,
        };
        var json = JsonConvert.SerializeObject(r, JsonSerializerSettings);
        if (response.Headers["server-invoke"].ToString() == "")
        {
            response.Headers["server-invoke"] = HttpUtility.UrlEncode(json);
        }
        else
        {
            response.Headers["server-invoke"] = $"{response.Headers["server-invoke"].ToString()},{HttpUtility.UrlEncode(json)}";
        }
    }
    public static void HtmlElementQueryInvoke(this HttpResponse response, string selector, string functionName)
    {
        HtmlElementQueryInvoke(response, selector, functionName, []);
    }
    public static void HtmlElementQueryInvoke(this HttpResponse response, string selector, string functionName, IEnumerable<string> arguments)
    {
        var r = new
        {
            ClassName = "$",
            Selector = selector,
            FunctionName = functionName,
            Args = arguments,
        };
        var json = JsonConvert.SerializeObject(r, JsonSerializerSettings);
        if (response.Headers["server-invoke"].ToString() == "")
        {
            response.Headers["server-invoke"] = HttpUtility.UrlEncode(json);
        }
        else
        {
            response.Headers["server-invoke"] = $"{response.Headers["server-invoke"].ToString()},{HttpUtility.UrlEncode(json)}";
        }
    }

    public static void HtmlElementQueryInvoke_SetValue(this HttpResponse response, string selector, string value)
    {
        response.HtmlElementQueryInvoke(selector, "setValue", [value]);
    }
    public static void HtmlElementQueryInvoke_SetAttribute(this HttpResponse response, string selector, string name, string value)
    {
        response.HtmlElementQueryInvoke(selector, "setAttribute", [name, value]);
    }
    public static void HtmlElementQueryInvoke_ToggleAttributeValue(this HttpResponse response, string selector, string name, string value1, string value2)
    {
        response.HtmlElementQueryInvoke(selector, "toggleAttributeValue", [name, value1, value2]);
    }
    public static void HtmlElementQueryInvoke_RemoveAttribute(this HttpResponse response, string selector, string name)
    {
        response.HtmlElementQueryInvoke(selector, "removeAttribute", [name]);
    }
    public static void HtmlElementQueryInvoke_AddClass(this HttpResponse response, string selector, string className)
    {
        response.HtmlElementQueryInvoke(selector, "addClass", [className]);
    }
    public static void HtmlElementQueryInvoke_ToggleClass(this HttpResponse response, string selector, string className)
    {
        response.HtmlElementQueryInvoke(selector, "toggleClass", [className]);
    }
    public static void HtmlElementQueryInvoke_RemoveClass(this HttpResponse response, string selector, string className)
    {
        response.HtmlElementQueryInvoke(selector, "removeClass", [className]);
    }
    public static void HtmlElementQueryInvoke_SetInnertHtml(this HttpResponse response, string selector, string html)
    {
        response.HtmlElementQueryInvoke(selector, "setInnerHtml", [html]);
    }
    public static void HtmlElementQueryInvoke_SetInnertText(this HttpResponse response, string selector, string html)
    {
        response.HtmlElementQueryInvoke(selector, "setInnerText", [html]);
    }
    public static void HtmlElementQueryInvoke_InsertAdjacentHTML(this HttpResponse response, string selector, InsertAdjacentHTMLPosition position, string html)
    {
        response.HtmlElementQueryInvoke(selector, "insertAdjacentHTML", [position.ToStringFromEnum().ToLower(), html]);
    }
    public static void HtmlElementQueryInvoke_SetScrollLeft(this HttpResponse response, string selector, string value)
    {
        response.HtmlElementQueryInvoke(selector, "setScrollLeft", [value]);
    }
    public static void HtmlElementQueryInvoke_SetScrollTop(this HttpResponse response, string selector, string value)
    {
        response.HtmlElementQueryInvoke(selector, "setScrollTop", [value]);
    }
    public static void HtmlElementQueryInvoke_Remove(this HttpResponse response, string selector)
    {
        response.HtmlElementQueryInvoke(selector, "remove");
    }


}
