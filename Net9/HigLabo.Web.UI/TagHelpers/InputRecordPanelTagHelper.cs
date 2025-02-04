using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("input-record-panel")]
public class InputRecordPanelTagHelper : TagHelper
{
    public int TabIndex { get; set; } = 0;
    public string HxPost { get; set; } = "";
    public bool PreventDefault { get; set; } = false;
    public bool AllowSearch { get; set; } = true;
    public bool FooterVisible { get; set; } = true;
    public bool SearchDefaultList { get; set; } = false;
    public string TemplateId { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("input-record", HtmlEncoder.Default);
        output.Attributes.Add("tabindex", this.TabIndex);
        output.Attributes.Add("show-data-record-popup-panel", "true");

        output.Attributes.Add("allow-search", this.AllowSearch.ToString().ToLower());
        output.Attributes.Add("footer-visible", this.FooterVisible.ToString().ToLower());
        output.Attributes.Add("search-default-list", this.SearchDefaultList.ToString().ToLower());

        output.Attributes.Add("hx-trigger", "click,keyup[keyCode==13]");
        output.Attributes.Add("hx-post", this.HxPost);
        output.Attributes.Add("hx-target", "#data-record-popup-panel [record-list-panel]");
        output.Attributes.Add("hx-swap", "innerHTML");
        output.Attributes.Add("selection-mode", "Single");

        if (this.TemplateId.HasValue())
        {
            output.Attributes.Add("add-template", "true");
            output.Attributes.Add("template-id", this.TemplateId);
        }

        output.Attributes.Add("prevent-default", this.PreventDefault.ToString().ToLower());

        await base.ProcessAsync(context, output);
    }
}
