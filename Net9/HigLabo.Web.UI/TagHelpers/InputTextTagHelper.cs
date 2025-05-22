using HigLabo.Web.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.UI.TagHelpers;

[HtmlTargetElement("input-text")]
public class InputTextTagHelper : TagHelper
{
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
    public string Placeholder { get; set; } = "";
    public string AutoComplete { get; set; } = "off";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.AddClass("input-text", HtmlEncoder.Default);
        {
            var tx = new TagBuilder("input");
            tx.Attributes.Add("type", "text");
            if (this.Name.HasValue())
            {
                tx.Attributes.Add("name", this.Name);
            }
            if (this.Value.HasValue())
            {
                tx.Attributes.Add("value", this.Value);
            }
            if (this.AutoComplete.HasValue())
            {
                tx.Attributes.Add("autocomplete", this.AutoComplete);
            }
            if (this.Placeholder.HasValue())
            {
                tx.Attributes.Add("placeholder", this.Placeholder);
            }
            output.Content.AppendHtml(tx);
        }
        await base.ProcessAsync(context, output);
    }
}
