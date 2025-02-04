using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.TagHelpers;

[HtmlTargetElement("panel-menu")]
[RestrictChildren("panel-menu-row")]
public class PanelMenuTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("panel-menu", HtmlEncoder.Default);
        await base.ProcessAsync(context, output);
    }
}

[HtmlTargetElement("panel-menu-row", ParentTag = "panel-menu")]
public class PanelMenuRowTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("panel-menu-row", HtmlEncoder.Default);
        await base.ProcessAsync(context, output);
    }
}
