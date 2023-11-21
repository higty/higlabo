using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public interface IRestApiResponse
    {
        object? Parameter { get; }
        HttpRequestMessage Request { get; }
        string RequestBodyText { get; }
        HttpStatusCode StatusCode { get; }
        Dictionary<String, String> Headers { get; }
        string ResponseBodyText { get; }
    }
    public abstract class RestApiResponse : IRestApiResponse
    {
        private Object? _Parameter = null;
        private HttpRequestMessage? _Request = null;
        private string _RequestBodyText = "";
        private HttpStatusCode _StatusCode = HttpStatusCode.OK;
        private Dictionary<String, String> _Headers = new Dictionary<string, string>();
        private string _ResponseBodyText = "";

        object? IRestApiResponse.Parameter
        {
            get { return _Parameter; }
        }
        HttpRequestMessage IRestApiResponse.Request
        {
            get { return _Request!; }
        }
        string IRestApiResponse.RequestBodyText
        {
            get { return _RequestBodyText; }
        }
        HttpStatusCode IRestApiResponse.StatusCode
        {
            get { return _StatusCode; }
        }
        Dictionary<String, String> IRestApiResponse.Headers
        {
            get { return _Headers; }
        }
        string IRestApiResponse.ResponseBodyText
        {
            get { return _ResponseBodyText; }
        }

        public string Object { get; set; } = "";

        public void SetProperty(object? parameter, string requestBodyText, HttpRequestMessage request, HttpResponseMessage response, string bodyText)
        {
            var res = response;
            _Parameter = parameter;
            _Request = request;
            _RequestBodyText = requestBodyText;
            _StatusCode = res.StatusCode;
            foreach (var header in res.Headers)
            {
                _Headers[header.Key] = String.Join(' ', header.Value);
            }
            _ResponseBodyText = bodyText;
        }
        public string GetHeaderText()
        {
            var sb = new StringBuilder();
            foreach (var key in this._Headers.Keys)
            {
                sb.Append(key).Append(": ").AppendLine(_Headers[key]);
            }
            return sb.ToString();
        }
        public string GetResponseBodyText()
        {
            return _ResponseBodyText;
        }

        public override string ToString()
        {
            return this._ResponseBodyText;
        }
    }
}
