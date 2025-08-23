using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("field-panel-datetime-textbox")]
public class FieldPanelDateTimeTextboxTagHelper : TagHelper
{
    public string Text { get; set; } = "";
    public string Name { get; set; } = "";
    public DateTime Value { get; set; } = DateTime.Now;
    public DateTimeFormat Format { get; set; } = DateTimeFormat.yyyyMMdd;
    public string MessageText { get; set; } = "";
    public string InputErrorKey { get; set; } = "";
    public string AutoComplete { get; set; } = "off";

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
                var input = new TagBuilder("input");
                input.Attributes.Add("type", "text");
                input.Attributes.Add("name", this.Name + "_Date");
                input.Attributes.Add("value", this.Value.ToString(this.Format));
                input.Attributes.Add("date-picker", "true");
                input.AddCssClass("date");
                if (this.AutoComplete.HasValue())
                {
                    input.Attributes.Add("autocomplete", this.AutoComplete);
                }
                div.InnerHtml.AppendHtml(input);
            }
            {
                var input = new TagBuilder("input");
                input.Attributes.Add("type", "text");
                input.Attributes.Add("name", this.Name + "_Time");
                input.Attributes.Add("value", this.Value.ToString("hh:mm"));
                input.AddCssClass("time");
                if (this.AutoComplete.HasValue())
                {
                    input.Attributes.Add("autocomplete", this.AutoComplete);
                }
                div.InnerHtml.AppendHtml(input);
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
