using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("data-record-panel")]
public class DataRecordPanelTagHelper : TagHelper
{
    public int? TabIndex { get; set; } = 0;
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("data-record-panel", HtmlEncoder.Default);
        if (this.TabIndex.HasValue)
        {
            output.Attributes.Add("tabindex", this.TabIndex);
        }
        output.Attributes.Add("data-record-panel", "true");
        await base.ProcessAsync(context, output);
    }
}
