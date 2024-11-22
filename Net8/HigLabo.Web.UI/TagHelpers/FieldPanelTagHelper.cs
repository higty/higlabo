using Microsoft.AspNetCore.Mvc.Rendering;
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
        output.Attributes.Add("class", "field-panel");
        {
            if (this.Text.HasValue())
            {
                var span = new TagBuilder("span");
                span.Attributes.Add("class", "field-name");
                span.InnerHtml.AppendHtml(this.Text);
                output.Content.AppendHtml(span);
            }

            var div = new TagBuilder("div");
            div.InnerHtml.AppendHtml(await output.GetChildContentAsync());
            output.Content.AppendHtml(div);
        }
        {
            var div = new TagBuilder("div");
            div.Attributes.Add("class", "input-error");
            div.Attributes.Add("input-error-key", this.InputErrorKey);
            output.Content.AppendHtml(div);
        }
        await base.ProcessAsync(context, output);
    }
}
