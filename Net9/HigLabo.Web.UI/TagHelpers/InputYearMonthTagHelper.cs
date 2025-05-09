using HigLabo.Core;
using HigLabo.Web.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigLabo.Web.UI.TagHelpers;

[HtmlTargetElement("input-year-month")]
public class InputYearMonthTagHelper : TagHelper
{
    public string Name { get; set; } = "";
    public bool AllowYearNull { get; set; } = true;
    public bool AllowMonthNull { get; set; } = true;
    public int StartYear { get; set; } = DateTimeOffset.Now.Year - 100;
    public int EndYear { get; set; } = DateTimeOffset.Now.Year + 100;
    public int? Year { get; set; }
    public int? Month { get; set; }
    public string MonthFormat { get; set; } = "MM";

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.AddClass("input-year-month", HtmlEncoder.Default);
        if (this.Name.HasValue())
        {
            output.Attributes.Add("name", this.Name);
        }
        output.Attributes.Add("hig-property-type", "Object");
        {
            var dl = new TagBuilder("select");
            dl.Attributes.Add("name", "Year");
            if (this.AllowYearNull == true)
            {
                var op = new TagBuilder("option");
                op.Attributes.Add("value", "");
                op.InnerHtml.Append("");
                dl.InnerHtml.AppendHtml(op);
            }
            for (int i = this.StartYear; i <= this.EndYear; i++)
            {
                var op = new TagBuilder("option");
                op.Attributes.Add("value", i.ToString());
                op.InnerHtml.Append(i.ToString("0000"));
                if (i == this.Year)
                {
                    op.Attributes.Add("selected", "selected");
                }
                dl.InnerHtml.AppendHtml(op);
            }
            output.Content.AppendHtml(dl);
        }
        {
            var dl = new TagBuilder("select");
            dl.Attributes.Add("name", "Month");
            if (this.AllowMonthNull == true)
            {
                var op = new TagBuilder("option");
                op.Attributes.Add("value", "");
                op.InnerHtml.Append("");
                dl.InnerHtml.AppendHtml(op);
            }
            for (int i = 1; i <= 12; i++)
            {
                var dtime = new DateTime(2000, i, 1);
                var op = new TagBuilder("option");
                op.Attributes.Add("value", i.ToString());
                op.InnerHtml.Append(dtime.ToString(this.MonthFormat));
                if (i == this.Month)
                {
                    op.Attributes.Add("selected", "selected");
                }
                dl.InnerHtml.AppendHtml(op);
            }
            output.Content.AppendHtml(dl);
        }
        await base.ProcessAsync(context, output);
    }
}
