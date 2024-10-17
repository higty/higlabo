using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.TagHelpers
{
    [HtmlTargetElement("paging-panel")]
    public class PagingPanelTagHelper : TagHelper
    {
        public string PreviousPageIconUrl { get; set; } = "";
        public string NextPageIconUrl { get; set; } = "";
        public string PreviousPageText { get; set; } = "<";
        public string NextPageText { get; set; } = ">";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "paging-panel");
            {
                var span = new TagBuilder("span");
                span.Attributes.Add("class", "icon-panel");
                span.Attributes.Add("hig-page-number-increment", "-1");

                if (this.PreviousPageIconUrl.HasValue())
                {
                    var img = new TagBuilder("img");
                    img.Attributes.Add("class", "icon");
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
                span.Attributes.Add("class", "page-number-panel");
                {
                    var span1 = new TagBuilder("span");
                    span1.Attributes.Add("class", "page-number");
                    span1.Attributes.Add("name", "PageNumber");
                    span1.InnerHtml.SetContent("1");
                    span.InnerHtml.AppendHtml(span1);

                    var span2 = new TagBuilder("span");
                    span2.InnerHtml.SetContent(T.Text.Page);
                    span.InnerHtml.AppendHtml(span2);
                }
                output.Content.AppendHtml(span);
            }
            {
                var span = new TagBuilder("span");
                span.Attributes.Add("class", "icon-panel");
                span.Attributes.Add("hig-page-number-increment", "1");
                if (this.NextPageIconUrl.HasValue())
                {
                    var img = new TagBuilder("img");
                    img.Attributes.Add("class", "icon");
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
    }
}
