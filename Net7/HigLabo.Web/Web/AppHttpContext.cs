using HigLabo.Core;
using HigLabo.Web;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HigLabo.Web
{
    public class AppHttpContextDefaultSetting
    {
        public JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings();
    }
    public class AppHttpContext
    {
        public static class HttpContextItemsKey
        {
            public static String HttpRequestContext = "AppHttpContext";
            public static String BeginRequestTime = "AppHttpContext.BeginRequestTime";
            public static String EndRequestTime = "AppHttpContext.EndRequestTime";
        }
        public static readonly AppHttpContextDefaultSetting DefaultSetting = new AppHttpContextDefaultSetting();

        public HttpContext HttpContext { get; init; }
        public HttpRequest Request
        {
            get { return this.HttpContext.Request; }
        }
        public String RawRequestPathAndQuery { get; set; } = "";
        public DateTimeOffset? BeginRequestTime
        {
            get { return this.HttpContext.Items[HttpContextItemsKey.BeginRequestTime] as DateTimeOffset?; }
            set
            {
                this.HttpContext.Items[HttpContextItemsKey.BeginRequestTime] = value;
            }
        }
        public DateTimeOffset? EndRequestTime
        {
            get { return this.HttpContext.Items[HttpContextItemsKey.EndRequestTime] as DateTimeOffset?; }
            set
            {
                this.HttpContext.Items[HttpContextItemsKey.EndRequestTime] = value;
            }
        }
        public AppHttpContext(IHttpContextAccessor accessor)
        {
            if (accessor.HttpContext == null) { throw new InvalidOperationException("HttpContext must not be null."); }
            this.HttpContext = accessor.HttpContext;

            var f = this.HttpContext.Features.Get<IHttpRequestFeature>();
            if (f == null)
            {
                this.RawRequestPathAndQuery = this.Request.GetDisplayUrl();
            }
            else
            {
                this.RawRequestPathAndQuery = f.RawTarget;
            }
        }

        public async ValueTask<Dictionary<String, String>?> CreateDictionaryFromBodyAsync()
        {
            if (String.Equals(this.Request.ContentType, "application/json", StringComparison.OrdinalIgnoreCase))
            {
                return await CreateObjectFromBodyJsonAsync<Dictionary<String, String>>();
            }
            else if (String.Equals(this.Request.ContentType, "application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase))
            {
                return this.Request.CreateDictionaryFromRequestFormAsync();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public async ValueTask<T> CreateObjectFromBodyAsync<T>()
            where T : new()
        {
            var contentType = this.Request.ContentType ?? "";
            if (contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
            {
                var o = await CreateObjectFromBodyJsonAsync<T>();
                if (o != null) { return o; }
            }
            else if (contentType.StartsWith("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase))
            {
                var o = CreateObjectFromRequestForm<T>();
                if (o != null) { return o; }
            }
            else
            {
                var o = await CreateObjectFromBodyJsonAsync<T>();
                if (o != null) { return o; }
                o = CreateObjectFromRequestForm<T>();
                if (o != null) { return o; }
            }
            var bodyText = await this.Request.GetRequestBodyTextAsync();
            throw new WebServerException(this.Request, "Failed to create object from request body. RequestBody is " + Environment.NewLine
                + bodyText);
        }
        public async ValueTask<T?> CreateObjectFromBodyJsonAsync<T>()
        {
            var request = this.Request;
            var bodyText = await request.GetRequestBodyTextAsync();

            var p = JsonConvert.DeserializeObject<T>(bodyText, AppHttpContext.DefaultSetting.JsonSerializerSettings);
            return p;
        }
        public T CreateObjectFromRequestForm<T>()
            where T : new()
        {
            var request = this.Request;

#if DEBUG
            Trace.WriteLine(request.Path);
#endif
            var d = new Dictionary<String, String>();
            foreach (var item in request.Form)
            {
                d[item.Key] = item.Value.ToString();
#if DEBUG
                Trace.WriteLine(item.Key + ": " + item.Value);
#endif
            }
            var p = d.Map(new T());
            return p;
        }
        public async ValueTask<String> GetValueFromBody(String key)
        {
            var d = await CreateDictionaryFromBodyAsync();
            if (d == null) { return ""; }
            if (d.TryGetValue(key, out var v))
            {
                return v;
            }
            return "";
        }
        public async ValueTask<T> GetParameter<T>() where T : new()
        {
            T result = await this.CreateObjectFromBodyAsync<T>();
            return result;
        }

    }
}
