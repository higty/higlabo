using HigLabo.Web.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.UI.TagHelpers;

[HtmlTargetElement("input-date")]
public class InputDateTagHelper : TagHelper
{
    public class Settings
    {
        public string CalendarImageUrl { get; set; } = "";
    }
    public static readonly Settings Default = new();

    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
    public string Placeholder { get; set; } = "";
    public string AutoComplete { get; set; } = "off";
    public string CalendarImageUrl { get; set; } = Default.CalendarImageUrl;
    public IDictionary<string, string?>? TextboxAttributes { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.AddClass("input-text", HtmlEncoder.Default);
        output.Attributes.Add("input-date", "true");
        output.Attributes.Add("date-picker", "true");
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
            if (this.TextboxAttributes != null)
            {
                tx.MergeAttributes(this.TextboxAttributes);
            }
            output.Content.AppendHtml(tx);
        }
        if (this.CalendarImageUrl.HasValue())
        {
            var img = new TagBuilder("img");
            img.AddCssClass("input-date-icon");
            img.Attributes.Add("src", this.CalendarImageUrl);
            output.Content.AppendHtml(img);
        }
        await base.ProcessAsync(context, output);
    }
}
