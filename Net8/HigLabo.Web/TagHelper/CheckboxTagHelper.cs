using HigLabo.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.TagHelpers
{
    [HtmlTargetElement("checkbox-panel")]
    public class CheckboxTagHelper : TagHelper
    {
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
        public bool Checked { get; set; } = false;

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "checkbox-panel");
            {
                var label = new TagBuilder("label");
                {
                    var span = new TagBuilder("span");
                    span.Attributes.Add("class", "checkbox");
                    {
                        var input = new TagBuilder("input");
                        input.Attributes.Add("type", "checkbox");
                        input.Attributes.Add("value", this.Value);
                        if (this.Checked)
                        {
                            input.Attributes.Add("checked", "checked");
                        }
                        if (this.Name.HasValue())
                        {
                            input.Attributes.Add("name", this.Name);
                        }
                        span.InnerHtml.AppendHtml(input);
                        span.InnerHtml.AppendHtml(new TagBuilder("span"));
                    }
                    label.InnerHtml.AppendHtml(span);
                }
                {
                    var span = new TagBuilder("span");
                    span.Attributes.Add("class", "text-panel");
                    span.InnerHtml.AppendHtml(await output.GetChildContentAsync());
                    label.InnerHtml.AppendHtml(span);
                }
                output.Content.AppendHtml(label);
            }
            await base.ProcessAsync(context, output);
        }
    }
}
