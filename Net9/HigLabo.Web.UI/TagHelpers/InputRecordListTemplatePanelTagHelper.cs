using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("input-record-list-template-panel")]
public class InputRecordListTemplatePanelTagHelper : TagHelper
{
    public int TabIndex { get; set; } = 0;
    public bool PreventDefault { get; set; } = false;
    public string AddRecordText { get; set; } = T.Text.Add;
    public string TemplateId { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("input-record", HtmlEncoder.Default);
        output.Attributes.Add("tabindex", this.TabIndex);

        output.Attributes.Add("selection-mode", "Template");

        {
            var div = new TagBuilder("div");
            div.AddCssClass("record-list-panel");
            div.Attributes.Add("record-list-panel", "true");
            div.InnerHtml.AppendHtml(await output.GetChildContentAsync());
            output.Content.AppendHtml(div);
        }
        {
            var div = new TagBuilder("div");
            div.AddCssClass("add-panel");
            div.Attributes.Add("add-template", "true");
            div.Attributes.Add("template-id", this.TemplateId);
            div.Attributes.Add("tabindex", "0");
            div.Attributes.Add("prevent-default", this.PreventDefault.ToString().ToLower());
            div.InnerHtml.SetContent(this.AddRecordText);
            output.Content.AppendHtml(div);
        }
        await base.ProcessAsync(context, output);
    }
}
