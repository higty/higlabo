using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("file-upload")]
public class FileUploadTagHelper : TagHelper
{
    public bool Multiple { get; set; } = false;
    public string ApiPath { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.AddClass("file-upload", HtmlEncoder.Default);
        output.Attributes.Add("file-upload", "true");
        output.Attributes.Add("api-path", this.ApiPath);

        {
            var input = new TagBuilder("input");
            input.Attributes.Add("type", "file");
            input.Attributes.Add("name", "file");
            if (this.Multiple == true)
            {
                input.Attributes.Add("multiple", "multiple");
            }
            output.Content.AppendHtml(input);
        }
        output.Content.AppendHtml(await output.GetChildContentAsync());

        await base.ProcessAsync(context, output);
    }
}
