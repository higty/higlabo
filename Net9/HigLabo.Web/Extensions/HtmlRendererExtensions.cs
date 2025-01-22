using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HigLabo.Web;

public static class HtmlRendererExtensions
{
    public static async ValueTask<string> ToHtml<T>(this HtmlRenderer htmlRenderer)
        where T : IComponent
    {
        return await htmlRenderer.ToHtml<T>(ParameterView.Empty);
    }
    public static async ValueTask<string> ToHtml<T>(this HtmlRenderer htmlRenderer, Dictionary<string, object?> parameters)
        where T : IComponent
    {
        return await htmlRenderer.ToHtml<T>(ParameterView.FromDictionary(parameters));
    }
    public static async ValueTask<string> ToHtml<T>(this HtmlRenderer htmlRenderer, ParameterView parameters)
        where T : IComponent
    {
        return await htmlRenderer.Dispatcher.InvokeAsync(async () =>
        {
            var output = await htmlRenderer.RenderComponentAsync<T>(parameters);
            return output.ToHtmlString();
        });
    }
}
