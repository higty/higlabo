﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("data-view")]
public class DataViewTagHelper : TagHelper
{
    public string Id { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("data-view", HtmlEncoder.Default);
        output.Attributes.Add("id", this.Id);
        output.Attributes.Add("data-view", "true");

        output.Content.AppendHtml(await output.GetChildContentAsync());
        {
            var div = new TagBuilder("div");
            div.AddCssClass("detail-panel display-none");
            div.Attributes.Add("data-view-detail-panel", "true");
            output.Content.AppendHtml(div);
        }
        {
            var div = new TagBuilder("div");
            div.AddCssClass("right-panel");
            div.AddCssClass("display-none");
            div.Attributes.Add("data-view-right-panel", "true");
            output.Content.AppendHtml(div);
        }
        await base.ProcessAsync(context, output);
    }
}
[HtmlTargetElement("data-view-view-panel", ParentTag = "data-view")]
public class RecordListComponentViewPanelTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("view-panel", HtmlEncoder.Default);
        output.Attributes.Add("data-view-view-panel", "true");
        await base.ProcessAsync(context, output);
    }
}
[HtmlTargetElement("data-view-record-list-panel", ParentTag = "data-view-view-panel")]
public class RecordListComponentRecordListPanelTagHelper : TagHelper
{
    public string HxInclude { get; set; } = "";
    public string ApiPath { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("record-list-panel", HtmlEncoder.Default);
        output.Attributes.Add("data-view-record-list-panel", "true");
        output.Attributes.Add("hx-trigger", "load once,data-view-load from:body");
        output.Attributes.Add("hx-include", this.HxInclude);
        output.Attributes.Add("hx-ext", "json-higlabo");
        output.Attributes.Add("hx-post", this.ApiPath);
        output.Attributes.Add("hx-swap", "innerHTML scroll:top");

        await base.ProcessAsync(context, output);
    }
}
[HtmlTargetElement("data-view-footer-panel", ParentTag = "data-view-view-panel")]
public class RecordListComponentFooterPanelTagHelper : TagHelper
{
    public int MenuRowCount { get; set; } = 2;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.AddClass("footer-panel", HtmlEncoder.Default);
        await base.ProcessAsync(context, output);
    }
}
