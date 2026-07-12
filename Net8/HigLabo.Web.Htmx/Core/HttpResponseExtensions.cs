using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Web;

namespace HigLabo.Web.Htmx;

public static class HttpResponseExtensions
{
    public static void HX_Location(this HttpResponse response, string url)
    {
        response.Headers.TryAdd("HX-Location", url);
    }
    public static void HX_Push_Url(this HttpResponse response, string url)
    {
        response.Headers.TryAdd("HX-Push-Url", url);
    }
    public static void HX_Redirect(this HttpResponse response, string url)
    {
        response.Headers.TryAdd("HX-Redirect", url);
    }
    public static void HX_Refresh(this HttpResponse response)
    {
        response.Headers.TryAdd("HX-Refresh", "true");
    }
    public static void HX_Replace_Url(this HttpResponse response)
    {
        response.Headers.TryAdd("HX-Replace-Url", "true");
    }
    public static void HX_Reswap(this HttpResponse response, string value)
    {
        response.Headers.TryAdd("HX-Reswap", value);
    }
    public static void HX_Retarget(this HttpResponse response, string value)
    {
        response.Headers.TryAdd("HX-Retarget", value);
    }
    public static void HX_Reselect(this HttpResponse response, string value)
    {
        response.Headers.TryAdd("HX-Reselect", value);
    }
    public static void HX_Trigger(this HttpResponse response, string value)
    {
        response.Headers.TryAdd("HX-Trigger", value);
    }
    public static void HX_Trigger(this HttpResponse response, params string[] eventNames)
    {
        response.HX_Trigger((IEnumerable<string>)eventNames);
    }
    public static void HX_Trigger(this HttpResponse response, IEnumerable<string> eventNames)
    {
        response.HX_Trigger(String.Join(",", eventNames.Where(el => String.IsNullOrEmpty(el) == false)));
    }
    public static void HX_Trigger(this HttpResponse response, string eventName, string target)
    {
        response.HX_Trigger(CreateHX_TriggerText(new KeyValuePair<string, string>(eventName, target)));
    }
    public static void HX_TriggerFromBody(this HttpResponse response, string eventName)
    {
        var target = $"[hx-trigger*='{eventName}']";
        HX_Trigger(response, eventName, target);
    }
    public static void HX_TriggerFromBody(this HttpResponse response, params string[] eventNames)
    {
        response.HX_TriggerFromBody((IEnumerable<string>)eventNames);
    }
    public static void HX_TriggerFromBody(this HttpResponse response, IEnumerable<string> eventNames)
    {
        var l = eventNames.Where(el => String.IsNullOrEmpty(el) == false)
            .Select(eventName => new KeyValuePair<string, string>(eventName, $"[hx-trigger*='{eventName}']"))
            .ToArray();
        if (l.Length == 0) { return; }

        response.HX_Trigger(CreateHX_TriggerText(l));
    }
    public static void HX_Trigger_After_Settle(this HttpResponse response, string value)
    {
        response.Headers.TryAdd("HX-Trigger-After-Settle", value);
    }
    public static void HX_Trigger_After_Swap(this HttpResponse response, string value)
    {
        response.Headers.TryAdd("HX-Trigger-After-Swap", value);
    }

    private static string CreateHX_TriggerText(params KeyValuePair<string, string>[] eventTargets)
    {
        var d = new Dictionary<string, Dictionary<string, string>>();
        foreach (var item in eventTargets)
        {
            d[item.Key] = new Dictionary<string, string>
            {
                ["target"] = item.Value,
            };
        }
        return JsonSerializer.Serialize(d);
    }
}
