using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace HigLabo.Web
{
    public abstract class WebApiEndpoint<T> 
        where T : AppHttpContext
    {
        public T AppHttpContext { get; private set; }

        public WebApiEndpoint(T appHttpContext)
        {
            this.AppHttpContext = appHttpContext;
        }

        public abstract ValueTask<object> ExecuteAsync();
    }
    public interface IValidateData
    {
        Boolean IsValid();
    }
    public interface IWebApiRequestParameter<T>
        where T: class, IValidateData
    {
        public T Validate();
    }

    public class WebApiActionResultDefaultSetting
    {
        public JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings();
    }
    public class WebApiActionResult : WebApiResult<object>, IActionResult
    {
        public static readonly WebApiActionResultDefaultSetting DefaultSetting = new WebApiActionResultDefaultSetting();

        public WebApiActionResult(string dataType, object data)
            : this(System.Net.HttpStatusCode.OK, dataType, data)
        {
        }

        public WebApiActionResult(HttpStatusCode statusCode, string dataType, object? data)
        {
            base.HttpStatus = statusCode;
            this.DataType = dataType;
            this.Data = data;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var cx = context.HttpContext;
            cx.Response.ContentType = "application/json";
            cx.Response.StatusCode = (int)base.HttpStatusCode;
            string s = JsonConvert.SerializeObject(this, DefaultSetting.JsonSerializerSettings);
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            await cx.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            await cx.Response.Body.FlushAsync();
        }
    }
}