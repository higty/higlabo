using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace HigLabo.Web;

public static class TagHelperExtensions
{
    public static async ValueTask<string> WriteHtmlAsync(this TagHelper tagHelper)
    {
        using (var writer = new StringWriter())
        {
            await WriteToAsync(tagHelper, writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }

    public static ValueTask WriteToAsync(this TagHelper tagHelper, TextWriter writer)
    {
        return WriteToAsync(tagHelper, writer, HtmlEncoder.Default);
    }

    public static async ValueTask WriteToAsync(this TagHelper tagHelper, TextWriter writer, HtmlEncoder htmlEncoder)
    {
        var uniqueId = Guid.NewGuid().ToString(); 
        var tagHelperContext = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), uniqueId);
        var tagHelperOutput = new TagHelperOutput(uniqueId, new TagHelperAttributeList(), (useCachedResult, encoder) => Task.FromResult<TagHelperContent>(new DefaultTagHelperContent()));

        await tagHelper.ProcessAsync(tagHelperContext, tagHelperOutput);
        tagHelperOutput.WriteTo(writer, htmlEncoder);
    }
}