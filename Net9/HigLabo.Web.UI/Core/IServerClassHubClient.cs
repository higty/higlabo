using Newtonsoft.Json;

namespace HigLabo.Web;

public interface IClassInvokerHubClient
{
    Task Invoke(string json);
}

public static class IClassInvokerHubClientExtensions
{
    public static async Task ClassInvoke(this IClassInvokerHubClient client, string className, string functionName, string arguments)
    {
        await Invoke(client, className, functionName, [arguments]);
    }
    public static async Task Invoke(this IClassInvokerHubClient client, string className, string functionName, IEnumerable<string> arguments)
    {
        var r = new
        {
            ClassName = className,
            FunctionName = functionName,
            Args = arguments,
        };
        var json = JsonConvert.SerializeObject(r);
        await client.Invoke(json);
    }
    public static async Task HtmlElementQueryInvoke(this IClassInvokerHubClient client, string selector, string functionName)
    {
        await HtmlElementQueryInvoke(client, selector, functionName, []);
    }
    public static async Task HtmlElementQueryInvoke(this IClassInvokerHubClient client, string selector, string functionName, string arguments)
    {
        await HtmlElementQueryInvoke(client, selector, functionName, [arguments]);
    }
    public static async Task HtmlElementQueryInvoke(this IClassInvokerHubClient client, string selector, string functionName, int arguments)
    {
        await HtmlElementQueryInvoke(client, selector, functionName, [arguments.ToString()]);
    }
    public static async Task HtmlElementQueryInvoke(this IClassInvokerHubClient client, string selector, string functionName, IEnumerable<string> arguments)
    {
        var r = new
        {
            ClassName = "$",
            Selector = selector,
            FunctionName = functionName,
            Args = arguments,
        };
        var json = JsonConvert.SerializeObject(r);
        await client.Invoke(json);
    }
}
