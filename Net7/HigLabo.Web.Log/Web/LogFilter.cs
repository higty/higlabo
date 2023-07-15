using HigLabo.Core;
using HigLabo.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static HigLabo.Core.ErrorLogTable;

namespace HigLabo.Web
{
    public class LogFilter : IAsyncAuthorizationFilter, IAsyncResultFilter, IAsyncExceptionFilter
    {
        public class RegexList
        {
            public static readonly Regex Password_Value = new Regex("Password\":\"[^\"]*\"");
        }
        public static Int64 MaxUploadFileSize { get; set; } = 209715200;

        private Boolean _LogAdded = false;

        public HttpContext HttpContext { get; init; }
        public LogBackgroundService BackgroundService { get; init; }
        public DateTimeOffset BeginRequestTime { get; private set; }
        public String RawRequestPathAndQuery { get; private set; } = "";

        public LogFilter(IHttpContextAccessor accessor, LogBackgroundService backgroundService)
        {
            this.HttpContext = accessor.HttpContext!;
            this.BackgroundService = backgroundService;
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            this.BeginRequestTime = DateTimeOffset.Now;
            var f = this.HttpContext.Features.Get<IHttpRequestFeature>();
            if (f == null)
            {
                this.RawRequestPathAndQuery = this.HttpContext.Request.GetDisplayUrl();
            }
            else
            {
                this.RawRequestPathAndQuery = f.RawTarget;
            }
            return Task.CompletedTask;
        }
        public virtual async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var f = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            var ex = f?.Error;
            _ = await this.AddLogAsync(ex);
            await next();
        }
        public virtual Task OnExceptionAsync(ExceptionContext context)
        {
            var ex = context.Exception;

            this.BackgroundService.AddErrorLog(ex, 1);

            if (String.Equals(this.HttpContext.Request.Method, "Get", StringComparison.OrdinalIgnoreCase) == true)
            {
                context.Result = new RedirectResult("/login");
            }
            else
            {
                if (ex is WebServerException)
                {
                    context.Result = new WebApiActionResult(HttpStatusCode.BadRequest, "Error", ex.Message);
                }
                else if (ex is WebServerException && ex.Message == String.Format(T.Text.FileSizeMustBeSmallerThan_, "20MB"))
                {
                    context.Result = new WebApiActionResult(HttpStatusCode.BadRequest, "Error", ex.Message);
                }
            }
            return Task.CompletedTask;
        }


        public virtual string GetUserId()
        {
            return "";
        }
        public virtual async Task<WebAccessLogTable.Record> CreateWebAccessLogRecordAsync(ErrorLogTable.Record? record)
        {
            var req = this.HttpContext.Request;
            var endRequestTime = DateTimeOffset.Now;

            var r = new WebAccessLogTable.Record();
            r.LogId = SequentialGuid.NewGuid();
            r.RequestUrl = this.RawRequestPathAndQuery;
            r.HttpMethodName = req.Method;
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
            r.UserId = this.GetUserId();
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
            r.ResponseStatusCode = this.HttpContext.Response.StatusCode;
            r.RequestLength = r.RequestHeaderData.Length + r.RequestBodyData.Length;
            r.ResponseLength = (Int32)(this.HttpContext.Response.ContentLength ?? -1);

            return r;
        }
        public virtual Int32 GetErrorLevel(Exception exception)
        {
            var req = this.HttpContext.Request;
            var errorLevel = 1;
            var userAgent = req.GetUserAgent();
            if (userAgent.Contains("bot", StringComparison.OrdinalIgnoreCase))
            {
                errorLevel = 0;
            }
            else if (userAgent.Contains("BingPreview", StringComparison.OrdinalIgnoreCase))
            {
                errorLevel = 0;
            }
            else if (req.Method.Equals("Head", StringComparison.OrdinalIgnoreCase))
            {
                errorLevel = 0;
            }
            else if (req.GetUserAgent() == "IIS Application Initialization Preload")
            {
                errorLevel = 0;
            }
            return errorLevel;
        }

        public async Task<Boolean> AddLogAsync(Exception? exception)
        {
            if (this._LogAdded) { return true; }
            try
            {
                var ex = exception;

                if (ex == null)
                {
                    var rWebAccessLog = await this.CreateWebAccessLogRecordAsync(null);
                    this.BackgroundService.AddWebAccessLog(rWebAccessLog);
                }
                else
                {
                    var errorLevel = this.GetErrorLevel(ex);
                    var rErrorLog = ErrorLogTable.Record.Create(ex, errorLevel, this.GetUserId());
                    var rWebAccessLog = await this.CreateWebAccessLogRecordAsync(rErrorLog);
                    this.BackgroundService.AddWebAccessLog(rWebAccessLog, rErrorLog);
                }
                this._LogAdded = true;
                return true;
            }
            catch { }
            return false;
        }

    }
}
