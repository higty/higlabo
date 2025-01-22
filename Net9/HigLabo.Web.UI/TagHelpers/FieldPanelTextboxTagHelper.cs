using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("class", "field-panel");
        {
            var span = new TagBuilder("span");
            span.Attributes.Add("class", "field-name");
            span.InnerHtml.AppendHtml(this.Text);
            output.Content.AppendHtml(span);

            var div = new TagBuilder("div");
            {
                var input = new TagBuilder("input");
                input.Attributes.Add("type", "text");
                input.Attributes.Add("name", this.Name);
                input.Attributes.Add("value", this.Value);
                if (this.DatePicker == true)
                {
                    input.Attributes.Add("date-picker", "true");
                    input.AddCssClass("date");
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
            div.Attributes.Add("class", "message-text");
            div.InnerHtml.SetContent(this.MessageText);
            output.Content.AppendHtml(div);
        }
        await base.ProcessAsync(context, output);
    }
}
