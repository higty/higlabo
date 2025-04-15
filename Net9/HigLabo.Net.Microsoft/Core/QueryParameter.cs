using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;

namespace HigLabo.Net.Microsoft;

public interface IQueryParameterProperty
{
    IQueryParameter Query { get; }
}
public interface IQueryParameter
{
    public string? Value { get; }
    public bool? Count { get; }
    public string? Expand { get; }
    public string? Filter { get; }
    public string? Format { get; }
    public string? OrderBy { get; }
    public string? Search { get; }
    public string? Select { get; }
    public int? Skip { get; }
    public int? Top { get; }
    public string? SkipToken { get; }
    string ConsistencyLevel { get; }
    string GetQueryString();
}
public class QueryParameter<TField> : IQueryParameter
    where TField: struct,global::System.Enum
{
    public string? Value { get; set; }
    public bool? Count { get; set; }
    public string? Expand { get; set; }
    public string? Filter { get; set; }
    public string? Format { get; set; }
    public string? OrderBy { get; set; }
    public string? Search { get; set; }
    public string? Select { get; set; }
    public List<TField> SelectList { get; init; } = new List<TField>();
    public int? Skip { get; set; }
    public int? Top { get; set; }
    public string? SkipToken { get; set; }
    public string ConsistencyLevel { get; set; } = "";

    public string GetQueryString()
    {
        if (this.Value != null) { return this.Value; }

        var sb = new StringBuilder();

        if (this.Count.HasValue)
        {
            if (sb.Length > 0) { sb.Append("&"); }
            sb.Append("$count=").Append(this.Count);
        }
        if (this.Expand != null)
        {
            if (sb.Length > 0) { sb.Append("&"); }
            sb.Append("$expand=").Append(WebUtility.UrlEncode(this.Expand));
        }
        if (this.Filter != null)
        {
            if (sb.Length > 0) { sb.Append("&"); }
            sb.Append("$filter=").Append(WebUtility.UrlEncode(this.Filter));
        }
        if (this.Format != null)
        {
            if (sb.Length > 0) { sb.Append("&"); }
            sb.Append("$format=").Append(WebUtility.UrlEncode(this.Format));
        }
        if (this.OrderBy != null)
        {
            if (sb.Length > 0) { sb.Append("&"); }
            sb.Append("$orderby=").Append(WebUtility.UrlEncode(this.OrderBy));
        }
        if (this.Search != null)
        {
            if (sb.Length > 0) { sb.Append("&"); }
            sb.Append("$search=").Append(WebUtility.UrlEncode(this.Search));
        }
        if (this.Select == null)
        {
            if (this.SelectList.Count > 0)
            {
                if (sb.Length > 0) { sb.Append("&"); }
                sb.Append("$select=");
                for (int i = 0; i < this.SelectList.Count; i++)
                {
                    sb.Append(this.SelectList[i].ToStringFromEnum().ToLower());
                    if (i < this.SelectList.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
            }
        }
        else
        {
            if (sb.Length > 0) { sb.Append("&"); }
            sb.Append("$select=").Append(WebUtility.UrlEncode(this.Select));
        }
        if (this.Skip.HasValue)
        {
            if (sb.Length > 0) { sb.Append("&"); }
            sb.Append("$skip=").Append(this.Skip);
        }
        if (this.Top.HasValue)
        {
            if (sb.Length > 0) { sb.Append("&"); }
            sb.Append("$top=").Append(this.Top);
        }
        return sb.ToString();
    }
}
