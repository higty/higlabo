using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("input-error-panel")]
public class InputErrorPanelTagHelper : TagHelper
{
    public string InputErrorKey { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("input-error", HtmlEncoder.Default);
        output.Attributes.Add("input-error-key", this.InputErrorKey);
        await base.ProcessAsync(context, output);
    }
}
