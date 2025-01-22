using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers;

[HtmlTargetElement("input-record-list-panel")]
public class InputRecordListPanelTagHelper : TagHelper
{
    public int TabIndex { get; set; } = 0;
    public string AddRecordText { get; set; } = T.Text.Add;
    public bool PreventDefault { get; set; } = false;

    public bool AllowSearch { get; set; } = true;
    public bool FooterVisible { get; set; } = true;
    public bool SearchDefaultList { get; set; } = false;
    public string HxPost { get; set; } = "";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("class", "input-record");
        output.Attributes.Add("tabindex", this.TabIndex);

        output.Attributes.Add("allow-search", this.AllowSearch.ToString().ToLower());
        output.Attributes.Add("footer-visible", this.FooterVisible.ToString().ToLower());
        output.Attributes.Add("search-default-list", this.SearchDefaultList.ToString().ToLower());

        output.Attributes.Add("hx-trigger", "click,keyup[keyCode==13]");
        output.Attributes.Add("hx-post", this.HxPost);
        output.Attributes.Add("hx-target", "#data-record-popup-panel [record-list-panel]");
        output.Attributes.Add("hx-swap", "innerHTML");
        output.Attributes.Add("selection-mode", "Multiple");

        {
            var div = new TagBuilder("div");
            div.Attributes.Add("class", "record-list-panel");
            div.Attributes.Add("record-list-panel", "true");
            div.InnerHtml.AppendHtml(await output.GetChildContentAsync());
            output.Content.AppendHtml(div);
        }
        {
            var div = new TagBuilder("div");
            div.Attributes.Add("class", "add-panel");
            div.Attributes.Add("add-panel", "true");
            div.Attributes.Add("prevent-default", this.PreventDefault.ToString().ToLower());
            div.Attributes.Add("show-data-record-popup-panel", "true");
            div.Attributes.Add("target-panel-type", "input-record-list-panel");
            div.InnerHtml.SetContent(this.AddRecordText);
            output.Content.AppendHtml(div);
        }

        await base.ProcessAsync(context, output);
    }
}
