using HigLabo.Core;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Globalization;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("language-text")]
[RestrictChildren("text")]
public class LanguageTextTagHelper : TagHelper
{
    internal class ChildDataContext
    {
        public bool IsFirst { get; set; } = true;
        public string CurrentCulture { get; set; } = CultureInfo.CurrentUICulture.Name;
        public string Html { get; set; } = "";
    }
    internal ChildDataContext ContextData { get; set; } = new ChildDataContext();

    public String TagName { get; set; } = "p";
    public string CurrentCulture { get; set; } = CultureInfo.CurrentUICulture.Name;

    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = this.TagName;
        this.ContextData.CurrentCulture = this.CurrentCulture;
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
[HtmlTargetElement("text", ParentTag= "language-text")]
public class LanguageCultureTagHelper : TagHelper
{
    public String TagName { get; set; } = "span";
    public String Culture { get; set; } = "ja-JP";

    public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = this.TagName;

        var parent = (LanguageTextTagHelper)context.Items[typeof(LanguageTextTagHelper)];            
        if (parent.ContextData.IsFirst == false && parent.ContextData.Html.IsNullOrEmpty())
        {
            parent.ContextData.Html = (await output.GetChildContentAsync()).GetContent();
        }
        else if (this.Culture == parent.ContextData.CurrentCulture)
        {
            parent.ContextData.Html = (await output.GetChildContentAsync()).GetContent();
        }
        output.SuppressOutput();
    }
}
