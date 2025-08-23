using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("field-panel-textbox")]
public class FieldPanelTextboxTagHelper : TagHelper
{
    public string Text { get; set; } = "";
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
    public bool DatePicker { get; set; } = false;
    public string MessageText { get; set; } = "";
    public string InputErrorKey { get; set; } = "";
    public string Placeholder { get; set; } = "";
    public string AutoComplete { get; set; } = "off";

    public IDictionary<string, string?>? TextboxAttributes { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("field-panel", HtmlEncoder.Default);
        {
            var span = new TagBuilder("span");
            span.AddCssClass("field-name");
            span.InnerHtml.AppendHtml(this.Text);
            output.Content.AppendHtml(span);

            var div = new TagBuilder("div");
            {
                var tx = new TagBuilder("input");
                tx.Attributes.Add("type", "text");
                tx.Attributes.Add("name", this.Name);
                tx.Attributes.Add("value", this.Value);
                if (this.DatePicker == true)
                {
                    tx.Attributes.Add("date-picker", "true");
                    tx.AddCssClass("date");
                }
                if (this.Placeholder.HasValue())
                {
                    tx.Attributes.Add("placeholder", this.Placeholder);
                }
                if (this.AutoComplete.HasValue())
                {
                    tx.Attributes.Add("autocomplete", this.AutoComplete);
                }
                if (this.TextboxAttributes != null)
                {
                    tx.MergeAttributes(this.TextboxAttributes);
                }
                div.InnerHtml.AppendHtml(tx);
            }
            output.Content.AppendHtml(div);
        }
        {
            var div = new InputErrorPanelTagHelper();
            div.InputErrorKey = this.InputErrorKey;
            output.Content.AppendHtml(await div.WriteHtmlAsync());
        }
        {
            var div = new TagBuilder("div");
            div.AddCssClass("message-text");
            div.InnerHtml.SetContent(this.MessageText);
            output.Content.AppendHtml(div);
        }
        await base.ProcessAsync(context, output);
    }
}
