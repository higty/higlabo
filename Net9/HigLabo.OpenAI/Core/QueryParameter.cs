using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public interface IQueryParameter
{
    string GetQueryString();
}
public interface IQueryParameterProperty
{
    IQueryParameter QueryParameter { get; }
}
public class QueryParameter : IQueryParameter
{
    /// <summary>
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
    /// </summary>
    public int? Limit { get; set; }
    /// <summary>
    /// Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order.
    /// </summary>
    public string? Order { get; set; }
    /// <summary>
    /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </summary>
    public string? After { get; set; }
    /// <summary>
    /// A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </summary>
    public string? Before { get; set; }

    string IQueryParameter.GetQueryString()
    {
        var sb = new StringBuilder();
        if (this.Limit != null) { sb.Append($"limit={this.Limit}&"); }
        if (this.Order != null) { sb.Append($"order={WebUtility.UrlEncode(this.Order)}&"); }
        if (this.After != null) { sb.Append($"after={WebUtility.UrlEncode(this.After)}&"); }
        if (this.Before != null) { sb.Append($"before={WebUtility.UrlEncode(this.Before)}&"); }
        return sb.ToString().TrimEnd('&');
    }
}
public class FineTuningQueryParameter : IQueryParameter
{
    /// <summary>
    /// Whether to stream events for the fine-tune job. If set to true, events will be sent as data-only server-sent events as they become available. The stream will terminate with a data: [DONE] message when the job is finished (succeeded, cancelled, or failed).
    /// 
    /// If set to false, only events generated so far will be returned.
    /// </summary>
    public bool? Stream { get; set; }

    string IQueryParameter.GetQueryString()
    {
        if (this.Stream != null) { return $"stream={this.Stream}"; }
        return "";
    }
}
public class FileListQueryParameter : IQueryParameter
{
    /// <summary>
    /// Only return files with the given purpose.
    /// </summary>
    public string? Purpose { get; set; }

    public void SetPurpose(FilePurpose purpose)
    {
        this.Purpose = purpose.GetValue();
    }

    string IQueryParameter.GetQueryString()
    {
        if (this.Purpose != null) {return $"purpose={WebUtility.UrlEncode(this.Purpose)}"; }
        return "";
    }
}
