using HigLabo.Core;
using HigLabo.Core.Core;
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
    public int MinYear { get; set; } = DateTimeOffset.Now.Year - 100;
    public int MaxYear { get; set; } = DateTimeOffset.Now.Year + 100;
    public SortDirection YearSortDirection { get; set; } = SortDirection.Ascending;
    public int? Year { get; set; }
    public int? Month { get; set; }
    public Func<int?, string> CreateYearText { get; set; } = (year) => year.HasValue ? year.Value.ToString("0000") : "";
    public Func<int?, string> CreateMonthText { get; set; } = (month) => month.HasValue ? new DateTime(2000, month.Value, 1).ToString("MM") : "";

    public IDictionary<string, string?>? SelectYearAttributes { get; set; }
    public IDictionary<string, string?>? SelectMonthAttributes { get; set; }
        
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
            if (this.SelectYearAttributes != null)
            {
                dl.MergeAttributes(this.SelectYearAttributes);
            }
            dl.Attributes.Add("name", "Year");
            if (this.AllowYearNull == true)
            {
                var op = new TagBuilder("option");
                op.Attributes.Add("value", "");
                op.InnerHtml.Append("");
                dl.InnerHtml.AppendHtml(op);
            }
            foreach (var year in this.GetYearList())
            {
                var op = new TagBuilder("option");
                op.Attributes.Add("value", year.ToString());
                op.InnerHtml.Append(CreateYearText(year));
                if (year == this.Year)
                {
                    op.Attributes.Add("selected", "selected");
                }
                dl.InnerHtml.AppendHtml(op);
            }
            output.Content.AppendHtml(dl);
        }
        {
            var dl = new TagBuilder("select");
            if (this.SelectMonthAttributes != null)
            {
                dl.MergeAttributes(this.SelectMonthAttributes);
            }
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
                op.InnerHtml.Append(CreateMonthText(i));
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
    private IEnumerable<int> GetYearList()
    {
        switch (this.YearSortDirection)
        {
            case SortDirection.Ascending:
                for (int i = this.MinYear; i <= this.MaxYear; i++)
                {
                    yield return i;
                }
                yield break;
            case SortDirection.Descending:
                for (int i = this.MaxYear; i >= this.MinYear; i--)
                {
                    yield return i;
                }
                yield break;
            default: throw SwitchStatementNotImplementException.Create(this.YearSortDirection);
        }
    }
}
