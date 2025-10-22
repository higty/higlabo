using Newtonsoft.Json;

namespace HigLabo.Web;

public interface IServerClassHubClient
{
    Task ServerClassInvoke(string json);
}

public static class IServerClassHubClientExtensions
{
    public static async Task ServerClassInvoke(this IServerClassHubClient client, string className, string functionName, string arguments)
    {
        await ServerClassInvoke(client, className, functionName, [arguments]);
    }
    public static async Task ServerClassInvoke(this IServerClassHubClient client, string className, string functionName, IEnumerable<string> arguments)
    {
        var r = new
        {
            ClassName = className,
            FunctionName = functionName,
            Args = arguments,
        };
        var json = JsonConvert.SerializeObject(r);
        await client.ServerClassInvoke(json);
    }
    public static async Task HtmlElementQueryInvoke(this IServerClassHubClient client, string selector, string functionName)
    {
        await HtmlElementQueryInvoke(client, selector, functionName, []);
    }
    public static async Task HtmlElementQueryInvoke(this IServerClassHubClient client, string selector, string functionName, string arguments)
    {
        await HtmlElementQueryInvoke(client, selector, functionName, [arguments]);
    }
    public static async Task HtmlElementQueryInvoke(this IServerClassHubClient client, string selector, string functionName, int arguments)
    {
        await HtmlElementQueryInvoke(client, selector, functionName, [arguments.ToString()]);
    }
    public static async Task HtmlElementQueryInvoke(this IServerClassHubClient client, string selector, string functionName, IEnumerable<string> arguments)
    {
        var r = new
        {
            ClassName = "$",
            Selector = selector,
            FunctionName = functionName,
            Args = arguments,
        };
        var json = JsonConvert.SerializeObject(r);
        await client.ServerClassInvoke(json);
    }
}
