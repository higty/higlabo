using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("accordion-panel")]
public class AccordionPanelTagHelper : TagHelper
{
    public ToggleState ToggleState { get; set; } = ToggleState.Hidden;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("accordion-panel", "true");
        output.Attributes.Add("class", "accordion-panel");
        output.Attributes.Add("toggle-state", this.ToggleState.ToStringFromEnum());

        await base.ProcessAsync(context, output);
    }
}
[HtmlTargetElement("accordion-panel-header", ParentTag = "accordion-panel")]
public class AccordionPanelHeaderTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("class", "header-panel");
        await base.ProcessAsync(context, output);
    }
}
[HtmlTargetElement("accordion-panel-content", ParentTag = "accordion-panel")]
public class AccordionPanelContentTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("class", "content-panel");
        await base.ProcessAsync(context, output);
    }
}
