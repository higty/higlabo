using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("loading-panel")]
public class LoadingPanelTagHelper : TagHelper
{
    public string Text { get; set; } = "Loading...";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("loading-panel", HtmlEncoder.Default);
        {
            var span = new TagBuilder("span");
            span.AddCssClass("loading-image");
            output.Content.AppendHtml(span);
        }
        {
            var span = new TagBuilder("span");
            span.AddCssClass("text");
            span.InnerHtml.AppendHtml(Text);
            output.Content.AppendHtml(span);
        }
        await base.ProcessAsync(context, output);
    }
}
