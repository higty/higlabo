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

namespace HigLabo.Web;

public class LogFilter : IAsyncAuthorizationFilter, IAsyncResultFilter, IAsyncExceptionFilter
{
    private Boolean _LogAdded = false;

    public HttpContext HttpContext { get; init; }
    public LogBackgroundService BackgroundService { get; init; }

    public DateTimeOffset BeginRequestTime { get; private set; }
    public String RawRequestPathAndQuery { get; private set; } = "";

    public bool IsAddWebAccessLog { get; set; } = true;

    public LogFilter(IHttpContextAccessor accessor, LogBackgroundService backgroundService)
    {
        this.HttpContext = accessor.HttpContext!;
        this.BackgroundService = backgroundService;
    }

    public virtual Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        this.BeginRequestTime = DateTimeOffset.Now;
        return Task.CompletedTask;
    }
    public virtual async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var f = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
        var ex = f?.Error;
        _ = await this.AddLogAsync(ex);
        await next();
    }
    public virtual async Task OnExceptionAsync(ExceptionContext context)
    {
        var ex = context.Exception;

        await this.AddLogAsync(ex);

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
    }


    public virtual string GetUserId()
    {
        return "";
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
                if (this.IsAddWebAccessLog)
                {
                    var rWebAccessLog = new WebAccessLogTable.Record();
                    await rWebAccessLog.SetPropertyAsync(this.HttpContext, this.BeginRequestTime, this.GetUserId(), null);
                    this.BackgroundService.AddWebAccessLog(rWebAccessLog);
                }
            }
            else
            {
                var errorLevel = this.GetErrorLevel(ex);
                var rErrorLog = ErrorLogTable.Record.Create(ex, errorLevel, this.GetUserId());
                var rWebAccessLog = new WebAccessLogTable.Record();
                await rWebAccessLog.SetPropertyAsync(this.HttpContext, this.BeginRequestTime, this.GetUserId(), rErrorLog.LogId);
                this.BackgroundService.AddWebAccessLog(rWebAccessLog, rErrorLog);
            }
            this._LogAdded = true;
            return true;
        }
        catch { }
        return false;
    }

}
