using Microsoft.AspNetCore.Http;
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
    public static void HX_TriggerFromBody(this HttpResponse response, string eventName)
    {
        var target = $"[hx-trigger*='{eventName}']";
        response.HX_Trigger("{\"" + eventName + "\":{\"target\" : \"" + target + "\"}}");
    }
    public static void HX_Trigger_After_Settle(this HttpResponse response, string value)
    {
        response.Headers.TryAdd("HX-Trigger-After-Settle", value);
    }
    public static void HX_Trigger_After_Swap(this HttpResponse response, string value)
    {
        response.Headers.TryAdd("HX-Trigger-After-Swap", value);
    }
}
