using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("paging-panel")]
public class PagingPanelTagHelper : TagHelper
{
    public class Settings
    {
        public string PreviousPageIconUrl { get; set; } = "";
        public string NextPageIconUrl { get; set; } = "";
        public string PreviousPageText { get; set; } = "<";
        public string NextPageText { get; set; } = ">";
    }
    public static readonly Settings Default = new();
    
    public int PageIndex { get; set; } = 0;
    public int MaxPageNumber { get; set; } = 1;
    public string PreviousPageIconUrl { get; set; } = Default.PreviousPageIconUrl;
    public string NextPageIconUrl { get; set; } = Default.NextPageIconUrl;
    public string PreviousPageText { get; set; } = Default.PreviousPageText;
    public string NextPageText { get; set; } = Default.NextPageText;
    public string HxPost { get; set; } = "";
    public string HxInclude { get; set; } = "";
    public string HxExt { get; set; } = "json-higlabo";
    public string HxSelect { get; set; } = "";
    public string HxSelectOob { get; set; } = "";
    public string HxTarget { get; set; } = "";
    public string HxSwap { get; set; } = "innerHTML";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("paging-panel", HtmlEncoder.Default);
        output.Attributes.Add("paging-panel", "true");
        output.Attributes.Add("popup-panel-state", "Hidden");
        {
            var span = new TagBuilder("span");
            span.AddCssClass("icon-panel");
            AddHtmxAttribute(span.Attributes, "click", "this", -1);
            {
                var hidden = new TagBuilder("input");
                hidden.Attributes.Add("type", "hidden");
                hidden.Attributes.Add("increment", "-1");
                hidden.Attributes.Add("name", nameof(PageIndex));
                hidden.Attributes.Add("value", Math.Max(this.PageIndex - 1, 0).ToString());
                span.InnerHtml.AppendHtml(hidden);
            }

            if (this.PreviousPageIconUrl.HasValue())
            {
                var img = new TagBuilder("img");
                img.AddCssClass("icon");
                img.Attributes.Add("src", this.PreviousPageIconUrl);
                span.InnerHtml.AppendHtml(img);
            }
            else
            {
                span.InnerHtml.Append(this.PreviousPageText);
            }
            output.Content.AppendHtml(span);
        }
        {
            var span = new TagBuilder("span");
            span.AddCssClass("page-index-panel");
            span.Attributes.Add("page-index-panel", "true");
            span.Attributes.Add("toggle-attribute", "popup-panel-state");
            span.Attributes.Add("toggle-attribute-value", "Visible,Hidden");
            span.Attributes.Add("target-selector-method", "parent");
            span.Attributes.Add("target-selector", ".paging-panel");
            AddHtmxAttribute(span.Attributes, "page-index-change from:body", "this", null);
            {
                var tx = new TagBuilder("input");
                tx.Attributes.Add("type", "text");
                tx.AddCssClass("page-number");
                tx.Attributes.Add("name", "PageNumber");
                tx.Attributes.Add("value", (this.PageIndex + 1).ToString());
                span.InnerHtml.AppendHtml(tx);

                var hidden = new TagBuilder("input");
                hidden.Attributes.Add("type", "hidden");
                hidden.Attributes.Add("name", nameof(this.PageIndex));
                hidden.Attributes.Add("value", this.PageIndex.ToString());
                span.InnerHtml.AppendHtml(hidden);

                var spanSlash = new TagBuilder("span");
                spanSlash.InnerHtml.SetContent("/");
                span.InnerHtml.AppendHtml(spanSlash);

                var spanTotalPageCount = new TagBuilder("span");
                spanTotalPageCount.Attributes.Add("max-page-number", "true");
                spanTotalPageCount.InnerHtml.SetContent(this.MaxPageNumber.ToString());
                span.InnerHtml.AppendHtml(spanTotalPageCount);

                var spanPage = new TagBuilder("span");
                spanPage.InnerHtml.SetContent(T.Text.Page);
                span.InnerHtml.AppendHtml(spanPage);
            }
            output.Content.AppendHtml(span);
        }
        {
            var span = new TagBuilder("span");
            span.AddCssClass("icon-panel");
            AddHtmxAttribute(span.Attributes, "click", "this", 1);
            {
                var hidden = new TagBuilder("input");
                hidden.Attributes.Add("type", "hidden");
                hidden.Attributes.Add("increment", "1");
                hidden.Attributes.Add("name", nameof(PageIndex));
                hidden.Attributes.Add("value", (this.PageIndex + 1).ToString());
                span.InnerHtml.AppendHtml(hidden);
            }

            if (this.NextPageIconUrl.HasValue())
            {
                var img = new TagBuilder("img");
                img.AddCssClass("icon");
                img.Attributes.Add("src", this.NextPageIconUrl);
                span.InnerHtml.AppendHtml(img);
            }
            else
            {
                span.InnerHtml.Append(this.NextPageText);
            }
            output.Content.AppendHtml(span);
        }
        await base.ProcessAsync(context, output);
    }

    private void AddHtmxAttribute(AttributeDictionary attributes, string hxTrigger, string hxInclude, int? increment)
    {
        if (increment.HasValue)
        {
            attributes.Add("page-index-increment", increment.ToString());
        }
        attributes.Add("hx-trigger", hxTrigger);
        attributes.Add("hx-post", this.HxPost);
        if (this.HxInclude.IsNullOrEmpty())
        {
            attributes.Add("hx-include", hxInclude);
        }
        else 
        {
            attributes.Add("hx-include", $"{hxInclude},{this.HxInclude}");
        }
        if (this.HxExt.HasValue()) { attributes.Add("hx-ext", this.HxExt); }
        if (this.HxSelect.HasValue()) { attributes.Add("hx-select", this.HxSelect); }
        if (this.HxSelectOob.HasValue()) { attributes.Add("hx-select-oob", this.HxSelectOob); }
        attributes.Add("hx-target", this.HxTarget);
        attributes.Add("hx-swap", this.HxSwap);
    }
}
