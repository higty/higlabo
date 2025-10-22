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
    public static void ServerClassInvoke(this HttpResponse response, string className, string functionName, string arguments)
    {
        ServerClassInvoke(response, className, functionName, [arguments]);
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
    public static void HtmlElementQueryInvoke(this HttpResponse response, string selector, string functionName, string arguments)
    {
        HtmlElementQueryInvoke(response, selector, functionName, [arguments]);
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
}
