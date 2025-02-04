using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("field-panel")]
public class FieldPanelTagHelper : TagHelper
{
    public string Text { get; set; } = "";
    public string InputErrorKey { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("field-panel", HtmlEncoder.Default);
        {
            if (this.Text.HasValue())
            {
                var span = new TagBuilder("span");
                span.AddCssClass("field-name");
                span.InnerHtml.AppendHtml(this.Text);
                output.Content.AppendHtml(span);
            }

            var div = new TagBuilder("div");
            div.InnerHtml.AppendHtml(await output.GetChildContentAsync());
            output.Content.AppendHtml(div);
        }
        {
            var div = new InputErrorPanelTagHelper();
            div.InputErrorKey = this.InputErrorKey;
            output.Content.AppendHtml(await div.WriteHtmlAsync());
        }
        await base.ProcessAsync(context, output);
    }
}
