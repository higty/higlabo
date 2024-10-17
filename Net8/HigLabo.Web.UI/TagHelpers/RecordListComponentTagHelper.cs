using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers
{
    [HtmlTargetElement("record-list-component")]
    public class RecordListComponentTagHelper : TagHelper
    {
        public string Id { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("id", this.Id);
            output.Attributes.Add("class", "record-list-component");
            output.Attributes.Add("hig-component", "true");

            output.Content.AppendHtml(await output.GetChildContentAsync());
            {
                var div = new TagBuilder("div");
                div.Attributes.Add("class", "detail-view-panel display-none");
                div.Attributes.Add("hig-detail-view", "true");
                output.Content.AppendHtml(div);
            }
            {
                var div = new TagBuilder("div");
                div.Attributes.Add("class", "right-view-panel display-none");
                div.Attributes.Add("hig-right-view", "true");
                output.Content.AppendHtml(div);
            }
            await base.ProcessAsync(context, output);
        }
    }
    [HtmlTargetElement("record-list-component-view-panel", ParentTag = "record-list-component")]
    public class RecordListComponentViewPanelTagHelper : TagHelper
    {
        public int MenuRowCount { get; set; } = 2;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "view-panel menu-row" + this.MenuRowCount);
            output.Attributes.Add("hig-list-view", "true");
            await base.ProcessAsync(context, output);
        }
    }
    [HtmlTargetElement("record-list-component-record-list-panel", ParentTag = "record-list-component-view-panel")]
    public class RecordListComponentRecordListPanelTagHelper : TagHelper
    {
        public string HxInclude { get; set; } = "";
        public string ApiPath { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "record-list-panel");
            output.Attributes.Add("hig-record-list-panel", "true");
            output.Attributes.Add("hx-trigger", "load once,load-record-list");
            output.Attributes.Add("hx-include", this.HxInclude);
            output.Attributes.Add("hx-ext", "json-higlabo");
            output.Attributes.Add("hx-post", this.ApiPath);
            output.Attributes.Add("hx-swap", "innerHTML scroll:top");

            await base.ProcessAsync(context, output);
        }
    }
    [HtmlTargetElement("record-list-component-footer-panel", ParentTag = "record-list-component-view-panel")]
    public class RecordListComponentFooterPanelTagHelper : TagHelper
    {
        public int MenuRowCount { get; set; } = 2;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "footer-panel");
            await base.ProcessAsync(context, output);
        }
    }
}
