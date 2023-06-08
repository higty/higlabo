using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    [HtmlTargetElement("language")]
    public class LanguageTagHelper : TagHelper
    {
        public String TagName { get; set; } = "span";
        public String Language { get; set; } = "ja-JP";

        public LanguageTagHelper()
        {
            this.TagName = "span";
        }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = this.TagName;
            var ci = CultureInfo.CurrentUICulture;
            var currentLanguage = CultureInfo.CreateSpecificCulture(ci.Name).Name;
            if (this.Language == currentLanguage)
            {
                var html = (await output.GetChildContentAsync()).GetContent();
                output.Content.AppendHtml(html);
            }
            else
            {
                output.Content.Clear();
            }
            await base.ProcessAsync(context, output);
        }
    }
}
