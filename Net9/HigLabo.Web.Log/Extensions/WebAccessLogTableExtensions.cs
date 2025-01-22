using HigLabo.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace HigLabo.Web;

public static class WebAccessLogTableExtensions
{
    public class RegexList
    {
        public static readonly Regex Password_Value = new Regex("Password\":\"[^\"]*\"");
    }
    public static Int64 MaxUploadFileSize { get; set; } = 209715200;

    public static async Task SetPropertyAsync(this WebAccessLogTable.Record record, HttpContext httpContext
        , DateTimeOffset beginRequestTime, string userId, Guid? errorLogId)
    {
        var req = httpContext.Request;
        var endRequestTime = DateTimeOffset.Now;

        var r = record;
        r.LogId = SequentialGuid.NewGuid();
        var f = httpContext.Features.Get<IHttpRequestFeature>();
        if (f == null)
        {
            r.RequestUrl = req.GetDisplayUrl();
        }
        else
        {
            r.RequestUrl = f.RawTarget;
        }
        r.HttpMethodName = req.Method;
        r.BeginRequestTime = beginRequestTime;
        r.EndRequestTime = endRequestTime;
        var ts = endRequestTime - beginRequestTime;
        r.RequestDurationMilliSeconds = ts.TotalMilliseconds;
        r.MachineName = Environment.MachineName;
        var process = Process.GetCurrentProcess();
        r.ProcessName = process.ProcessName;
        r.ProcessId = process.Id;
        r.ThreadName = Thread.CurrentThread.Name ?? "";
        r.ThreadId = Thread.CurrentThread.ManagedThreadId;
        r.UserId = userId;
        r.UserHostAddress = req.GetClientIPAddressText();
        if (req.Headers.ContainsKey("Host"))
        {
            r.UserHostName = req.Headers["Host"]!;
        }
        r.UserAgent = req.GetUserAgent();
        r.Referer = req.Headers["Referer"].ToString();
        if (record != null)
        {
            r.ErrorLogId = record.LogId;
        }
        r.RequestHeaderData = req.GetRequestHeaderText();

        if (req.ContentLength > MaxUploadFileSize)
        {
            r.RequestBodyData = "Content body size is too large.";
        }
        else
        {
            var bodyData = await req.GetRequestBodyTextAsync();
            r.RequestBodyData = RegexList.Password_Value.Replace(bodyData, m =>
            {
                return "Password\":\"password is deleted\"";
            });
        }
        r.ResponseStatusCode = httpContext.Response.StatusCode;
        r.RequestLength = r.RequestHeaderData.Length + r.RequestBodyData.Length;
        r.ResponseLength = (Int32)(httpContext.Response.ContentLength ?? -1);
        r.ErrorLogId = errorLogId;
    }

}
