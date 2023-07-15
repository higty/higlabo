using HigLabo.Core;
using HigLabo.Service;
using Hignull.Core;
using Hignull.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static HigLabo.Core.ErrorLogTable;

namespace HigLabo.Web
{
    public class HignullWebRequestFilter : IAuthorizationFilter, IAsyncResultFilter
    {
        public class RegexList
        {
            public static readonly Regex Password_Value = new Regex("Password\":\"[^\"]*\"");
        }
        public static Int64 MaxUploadFileSize { get; set; } = 209715200;

        public HttpContext X { get; set; }
        public BackgroundService BackgroundService { get; init; }
        public DateTimeOffset BeginRequestTime { get; private set; }
        public String RawRequestPathAndQuery { get; private set; } = "";

        public HignullWebRequestFilter(IHttpContextAccessor context, BackgroundService backgroundService)
        {
            X = context;
            this.BackgroundService = backgroundService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            this.BeginRequestTime = DateTimeOffset.Now;
            var f = this.X.HttpContext.Features.Get<IHttpRequestFeature>();
            if (f == null)
            {
                this.RawRequestPathAndQuery = this.X.Request.GetDisplayUrl();
            }
            else
            {
                this.RawRequestPathAndQuery = f.RawTarget;
            }
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var f = X.HttpContext.Features.Get<IExceptionHandlerFeature>();
            var ex = f?.Error;
            _ = await this.AddLogAsync(X.User?.UserId, ex);
            await next();
        }
        public async Task<WebAccessLogTable.Record> CreateWebAccessLogRecordAsync(Guid? userId, ErrorLogTable.Record? record)
        {
            var endRequestTime = DateTimeOffset.Now;

            var r = new WebAccessLogTable.Record();
            r.LogId = SequentialGuid.NewGuid();
            r.RequestUrl = this.RawRequestPathAndQuery;
            r.HttpMethodName = X.Request.Method;
            r.BeginRequestTime = this.BeginRequestTime;
            r.EndRequestTime = endRequestTime;
            var ts = endRequestTime - this.BeginRequestTime;
            r.RequestDurationMilliSeconds = (Int32)ts.TotalMilliseconds;
            r.MachineName = Environment.MachineName;
            var process = Process.GetCurrentProcess();
            r.ProcessName = process.ProcessName;
            r.ProcessId = process.Id;
            r.ThreadName = Thread.CurrentThread.Name ?? "";
            r.ThreadId = Thread.CurrentThread.ManagedThreadId;
            r.UserId = userId;
            r.UserHostAddress = X.Request.GetClientIPAddressText();
            if (X.Request.Headers.ContainsKey("Host"))
            {
                r.UserHostName = X.Request.Headers["Host"]!;
            }
            r.UserAgent = X.Request.GetUserAgent();
            r.Referer = X.Request.Headers["Referer"].ToString();
            if (record != null)
            {
                r.ErrorLogId = record.LogId;
            }
            r.RequestHeaderData = X.Request.GetRequestHeaderText();

            if (X.Request.ContentLength > MaxUploadFileSize)
            {
                r.RequestBodyData = "Content body size is too large.";
            }
            else
            {
                var bodyData = await X.Request.GetRequestBodyTextAsync();
                r.RequestBodyData = RegexList.Password_Value.Replace(bodyData, m =>
                {
                    return "Password\":\"password is deleted\"";
                });
            }
            r.ResponseStatusCode = X.HttpContext.Response.StatusCode;
            r.RequestLength = r.RequestHeaderData.Length + r.RequestBodyData.Length;
            r.ResponseLength = (Int32)(X.HttpContext.Response.ContentLength ?? -1);

            return r;
        }
        public async Task<Boolean> AddLogAsync(Guid? userId, Exception? exception)
        {
            try
            {
                var ex = exception;

                if (ex == null)
                {
                    var rWebAccessLog = await this.CreateWebAccessLogRecordAsync(userId, null);
                    this.BackgroundService.AddWebAccessLog(rWebAccessLog);
                }
                else
                {
                    var errorLevel = this.GetErrorLevel(ex);
                    var rErrorLog = ErrorLogTable.Record.Create(ex, errorLevel, userId);
                    var rWebAccessLog = await this.CreateWebAccessLogRecordAsync(userId, rErrorLog);
                    this.BackgroundService.AddWebAccessLog(rWebAccessLog, rErrorLog);
                }
                return true;
            }
            catch { }
            return false;
        }
        public virtual Int32 GetErrorLevel(Exception exception)
        {
            var errorLevel = 1;
            var userAgent = X.Request.GetUserAgent();
            if (userAgent.Contains("bot", StringComparison.OrdinalIgnoreCase))
            {
                errorLevel = 0;
            }
            else if (userAgent.Contains("BingPreview", StringComparison.OrdinalIgnoreCase))
            {
                errorLevel = 0;
            }
            else if (X.Request.Method.Equals("Head", StringComparison.OrdinalIgnoreCase))
            {
                errorLevel = 0;
            }
            else if (X.Request.GetUserAgent() == "IIS Application Initialization Preload")
            {
                errorLevel = 0;
            }
            return errorLevel;
        }

    }
}
