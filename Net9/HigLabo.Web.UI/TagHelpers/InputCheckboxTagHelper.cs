using HigLabo.Web.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.UI.TagHelpers;

[HtmlTargetElement("input-checkbox")]
public class InputCheckboxTagHelper : TagHelper
{
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
    public string Text { get; set; } = "";
    public bool Checked { get; set; } = false;

    public string CheckedText { get; set; } = "✓";
    public string CheckedImageUrl { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.AddClass("input-checkbox", HtmlEncoder.Default);
        {
            var label = new TagBuilder("label");
            {
                var chx = new TagBuilder("input");
                chx.AddCssClass("checkbox");
                chx.Attributes.Add("type", "checkbox");
                if (this.Name.HasValue())
                {
                    chx.Attributes.Add("name", this.Name);
                }
                if (this.Value.HasValue())
                {
                    chx.Attributes.Add("value", this.Value);
                }
                if (this.Checked == true)
                {
                    chx.Attributes.Add("checked", "checked");
                }
                label.InnerHtml.AppendHtml(chx);
            }
            {
                var span = new TagBuilder("span");
                span.AddCssClass("box");
                label.InnerHtml.AppendHtml(span);
                if (this.CheckedImageUrl.HasValue())
                {
                    var img = new TagBuilder("img");
                    img.Attributes.Add("src", this.CheckedImageUrl);
                    img.AddCssClass("checked");
                    span.InnerHtml.AppendHtml(img);
                }
                else
                {
                    var text = new TagBuilder("span");
                    text.InnerHtml.AppendHtml(this.CheckedText);
                    text.AddCssClass("checked");
                    span.InnerHtml.AppendHtml(text);
                }
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
