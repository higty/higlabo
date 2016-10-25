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
    public class JsonTextReslut : IHttpActionResult
    {
        private HttpRequestMessage _Request = null;

        public HttpStatusCode StatusCode { get; set; }
        public String Text { get; set; }
        
        static JsonTextReslut()
        {
        }
        public JsonTextReslut(HttpRequestMessage request, HttpStatusCode statusCode, String text)
        {
            _Request = request;
            this.StatusCode = statusCode;
            this.Text = text;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var res = new HttpResponseMessage(this.StatusCode);
            res.Content = new StringContent(this.Text, Encoding.UTF8, "application/json");
            return Task.FromResult(res);
        }
    }
}