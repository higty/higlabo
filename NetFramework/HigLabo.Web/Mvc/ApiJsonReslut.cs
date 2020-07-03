using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HigLabo.Web.Mvc
{
    public class ApiJsonReslut
    {
        public static JsonSerializerSettings JsonSerializerSettings { get; set; }

        static ApiJsonReslut()
        {
            JsonSerializerSettings = new JsonSerializerSettings();
        }
    }
    public class ApiJsonReslut<T> : IHttpActionResult
    {
        private HttpRequestMessage _Request = null;

        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public Formatting Formatting { get; set; }

        static ApiJsonReslut()
        {
        }
        public ApiJsonReslut(HttpRequestMessage request, HttpStatusCode statusCode, T data)
        {
            _Request = request;
            this.StatusCode = statusCode;
            this.Data = data;
#if DEBUG
            this.Formatting = Formatting.Indented;
#else
            this.Formatting = Formatting.None;
#endif
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            if (ApiJsonReslut.JsonSerializerSettings == null)
            {
                throw new InvalidOperationException("You must set ApiJsonReslut.JsonSerializerSettings property.");
            }
            var json = JsonConvert.SerializeObject(this.Data, this.Formatting, ApiJsonReslut.JsonSerializerSettings);
            var res = new HttpResponseMessage(this.StatusCode);
            res.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return Task.FromResult(res);
        }
    }
}