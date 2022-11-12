using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using HigLabo.Core;

namespace HigLabo.Web
{
    public class WebApiActionResult : WebApiResult, IActionResult
    {
        [JsonIgnore]
        public static readonly WebApiActionResultDefaultSettings Default = new WebApiActionResultDefaultSettings();
        [JsonIgnore] 
        public JsonSerializerSettings JsonSerializerSettings { get; set; } = Default.JsonSerializerSettings;

        public WebApiActionResult(Object data)
            : this(HttpStatusCode.OK, "", data)
        {
        }
        public WebApiActionResult(String message)
            : this(HttpStatusCode.OK, message, null)
        {
        }
        public WebApiActionResult(HttpStatusCode statusCode, String message)
            : this(statusCode, message, null)
        {
        }
        public WebApiActionResult(HttpStatusCode statusCode, String message, Object data)
        {
            this.HttpStatusCode = statusCode;
            this.Message = message;
            this.Data = data;
        }
        public WebApiActionResult(ValidationResult result)
        {
            this.HttpStatusCode = HttpStatusCode.BadRequest;
            this.ValidationResultList.Add(result);
        }
        public WebApiActionResult(String message, ValidationResult result)
        {
            this.HttpStatusCode = HttpStatusCode.BadRequest;
            this.Message = message;
            this.ValidationResultList.Add(result);
        }
        public WebApiActionResult(String message, ValidationResultList resultList)
        {
            this.HttpStatusCode = HttpStatusCode.BadRequest;
            this.Message = message;
            this.ValidationResultList.AddRange(resultList);
        }
        public static WebApiActionResult CreateRedirectResult(String url)
        {
            var result = new WebApiActionResult(HttpStatusCode.Redirect, "");
            result.Url = url;
            return result;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var cx = context.HttpContext;
            cx.Response.ContentType = "application/json";
            cx.Response.StatusCode = (Int32)this.HttpStatusCode;
            var json = JsonConvert.SerializeObject(this, this.JsonSerializerSettings);
            var bb = Encoding.UTF8.GetBytes(json);
            await cx.Response.Body.WriteAsync(bb, 0, bb.Length);
            await cx.Response.Body.FlushAsync();
        }
    }
}
