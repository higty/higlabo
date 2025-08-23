using HigLabo.Web.TagHelpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.UI.TagHelpers;

[HtmlTargetElement("input-textarea")]
public class InputTextareaTagHelper : TagHelper
{
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
    public string Placeholder { get; set; } = "";

    public IDictionary<string, string?>? TextboxAttributes { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.AddClass("input-textarea", HtmlEncoder.Default);
        {
            var tx = new TagBuilder("textarea");
            if (this.Name.HasValue())
            {
                tx.Attributes.Add("name", this.Name);
            }
            if (this.Value.HasValue())
            {
                tx.InnerHtml.SetContent(this.Value);
            }
            if (this.Placeholder.HasValue())
            {
                tx.Attributes.Add("placeholder", this.Placeholder);
            }
            if (this.TextboxAttributes != null)
            {
                tx.MergeAttributes(this.TextboxAttributes);
            }
            output.Content.AppendHtml(tx);
        }
        await base.ProcessAsync(context, output);
    }
}
