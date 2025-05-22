using HigLabo.Web.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Reflection.Emit;

namespace HigLabo.Web.UI.TagHelpers;

[HtmlTargetElement("input-password")]
public class InputPasswordTagHelper : TagHelper
{
    public class Settings
    {
        public string ToggleInputTypeImageUrl { get; set; } = "";
    }
    public static readonly Settings Default = new();

    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
    public string Placeholder { get; set; } = "";
    public string AutoComplete { get; set; } = "off";
    public string ToggleInputTypeImageUrl { get; set; } = Default.ToggleInputTypeImageUrl;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.AddClass("input-text", HtmlEncoder.Default);
        output.Attributes.Add("input-password", "true");
        {
            var tx = new TagBuilder("input");
            tx.Attributes.Add("type", "password");
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
        {
            var span = new TagBuilder("span");
            span.AddCssClass("toggle-input-type");
            span.Attributes.Add("toggle-input-type", "true");
            span.InnerHtml.AppendHtml("👁");
            output.Content.AppendHtml(span);
        }
        await base.ProcessAsync(context, output);
    }
}
