using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("input-error-panel")]
public class InputErrorPanelTagHelper : TagHelper
{
    public string InputErrorKey { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("class", "input-error");
        output.Attributes.Add("input-error-key", this.InputErrorKey);
        await base.ProcessAsync(context, output);
    }
}
