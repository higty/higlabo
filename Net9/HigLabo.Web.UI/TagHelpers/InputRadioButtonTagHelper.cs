using HigLabo.Web.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.UI.TagHelpers;

[HtmlTargetElement("input-radio")]
public class InputRadioButtonTagHelper : TagHelper
{
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
    public string Text { get; set; } = "";
    public bool Checked { get; set; } = false;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.AddClass("input-radio", HtmlEncoder.Default);
        {
            var label = new TagBuilder("label");
            {
                var rb = new TagBuilder("input");
                rb.AddCssClass("radio-button");
                rb.Attributes.Add("type", "radio");
                if (this.Name.HasValue())
                {
                    rb.Attributes.Add("name", this.Name);
                }
                if (this.Value.HasValue())
                {
                    rb.Attributes.Add("value", this.Value);
                }
                if (this.Checked == true)
                {
                    rb.Attributes.Add("checked", "checked");
                }
                label.InnerHtml.AppendHtml(rb);
            }
            {
                var span = new TagBuilder("span");
                span.AddCssClass("box");
                label.InnerHtml.AppendHtml(span);
            }
            {
                var span = new TagBuilder("span");
                span.AddCssClass("text");
                span.InnerHtml.Append(this.Text);
                label.InnerHtml.AppendHtml(span);
            }
            output.Content.AppendHtml(label);
        }
        await base.ProcessAsync(context, output);
    }
}
