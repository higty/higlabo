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

namespace HigLabo.Core
{
    public class ApiJsonReslut<T> : IHttpActionResult
    {
        public static JsonSerializerSettings JsonSerializerSettings { get; set; }

        private HttpRequestMessage _Request = null;

        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public Formatting Formatting { get; set; }

        static ApiJsonReslut()
        {
            JsonSerializerSettings = new JsonSerializerSettings();
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
            var json = JsonConvert.SerializeObject(this.Data, this.Formatting, JsonSerializerSettings);
            var res = new HttpResponseMessage(this.StatusCode);
            res.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return Task.FromResult(res);
        }
    }
}