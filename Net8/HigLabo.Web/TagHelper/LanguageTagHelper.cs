using HigLabo.Core;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    [HtmlTargetElement("text")]
    [RestrictChildren("language")]
    public class LanguageTextTagHelper : TagHelper
    {
        internal class ChildDataContext
        {
            public bool IsFirst { get; set; } = true;
            public string Html { get; set; } = "";
        }
        internal ChildDataContext ContextData { get; set; } = new ChildDataContext();

        public String TagName { get; set; } = "span";

        public LanguageTextTagHelper()
        {
            this.TagName = "span";
        }
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = this.TagName;

            context.Items.Add(typeof(LanguageTextTagHelper), this);

            await output.GetChildContentAsync();

            if (this.ContextData.Html.IsNullOrEmpty())
            {
                ContextData.IsFirst = false;
                await output.GetChildContentAsync();
            }
            output.Content.AppendHtml(ContextData.Html);
            await base.ProcessAsync(context, output);
        }
    }
    [HtmlTargetElement("language", ParentTag="text")]
    public class LanguageCultureTagHelper : TagHelper
    {
        public String TagName { get; set; } = "span";
        public String Culture { get; set; } = "ja-JP";

        public LanguageCultureTagHelper()
        {
            this.TagName = "span";
        }
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = this.TagName;

            var parent = (LanguageTextTagHelper)context.Items[typeof(LanguageTextTagHelper)];            
            if (parent.ContextData.IsFirst == false && parent.ContextData.Html.IsNullOrEmpty())
            {
                parent.ContextData.Html = (await output.GetChildContentAsync()).GetContent();
            }
            else if (this.Culture == CultureInfo.CurrentUICulture.Name)
            {
                parent.ContextData.Html = (await output.GetChildContentAsync()).GetContent();
            }
            output.SuppressOutput();
        }
    }
}
