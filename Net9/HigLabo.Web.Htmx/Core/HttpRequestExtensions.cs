using Microsoft.AspNetCore.Http;

namespace HigLabo.Web.Htmx;

public static class HttpRequestExtensions
{
    public static bool HX_Boosted(this HttpRequest request)
    {
        return string.Equals(request.Headers["HX-Boosted"], "true", StringComparison.OrdinalIgnoreCase);
    }
    public static bool Hx_Current_Url(this HttpRequest request)
    {
        return string.Equals(request.Headers["HX-Current-URL"], "true", StringComparison.OrdinalIgnoreCase);
    }
    public static bool Hx_History_Restore_Request(this HttpRequest request)
    {
        return string.Equals(request.Headers["HX-History-Restore-Request"], "true", StringComparison.OrdinalIgnoreCase);
    }
    public static bool Hx_Prompt(this HttpRequest request)
    {
        return string.Equals(request.Headers["HX-Prompt"], "true", StringComparison.OrdinalIgnoreCase);
    }
    public static bool HX_Request(this HttpRequest request)
    {
        return string.Equals(request.Headers["HX-Request"], "true", StringComparison.OrdinalIgnoreCase);
    }
    public static bool HX_Target(this HttpRequest request)
    {
        return string.Equals(request.Headers["HX-Target"], "true", StringComparison.OrdinalIgnoreCase);
    }
    public static bool HX_Trigger_Name(this HttpRequest request)
    {
        return string.Equals(request.Headers["HX-Trigger-Name"], "true", StringComparison.OrdinalIgnoreCase);
    }
    public static bool HX_Trigger(this HttpRequest request)
    {
        return string.Equals(request.Headers["HX-Trigger"], "true", StringComparison.OrdinalIgnoreCase);
    }
}
