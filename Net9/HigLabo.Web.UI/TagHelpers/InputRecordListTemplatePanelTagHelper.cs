using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("input-record-list-template-panel")]
public class InputRecordListTemplatePanelTagHelper : TagHelper
{
    public enum AddTemplateType
    {
        Template,
        Api,
    }
    public bool PreventDefault { get; set; } = false;
    public string AddRecordText { get; set; } = T.Text.Add;
    public AddTemplateType AddType { get; set; } = AddTemplateType.Template;
    public string TemplateId { get; set; } = "";
    public string HxPost { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("input-record", HtmlEncoder.Default);

        output.Attributes.Add("selection-mode", "Template");
        output.Attributes.Add("add-type", this.AddType.ToStringFromEnum());

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
            switch (this.AddType)
            {
                case AddTemplateType.Template:
                    div.Attributes.Add("template-id", this.TemplateId);
                    break;
                case AddTemplateType.Api:
                    div.Attributes.Add("hx-trigger", "click,keyup[keyCode==13]");
                    div.Attributes.Add("hx-post", this.HxPost);
                    div.Attributes.Add("hx-target", "previous");
                    div.Attributes.Add("hx-swap", "beforeend");
                    break;
                default: throw SwitchStatementNotImplementException.Create(this.AddType);
            }
            div.Attributes.Add("tabindex", "0");
            div.Attributes.Add("prevent-default", this.PreventDefault.ToString().ToLower());
            div.InnerHtml.SetContent(this.AddRecordText);
            output.Content.AppendHtml(div);
        }
        await base.ProcessAsync(context, output);
    }
}
