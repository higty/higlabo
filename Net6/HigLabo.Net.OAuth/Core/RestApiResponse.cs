using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public interface IRestApiResponse
    {
        object Parameter { get; }
        HttpRequestMessage Request { get; }
        HttpStatusCode StatusCode { get; }
        Dictionary<String, String> Headers { get; } 
        string ResponseBodyText { get; }
        bool IsThrowException();
    }

    public abstract class RestApiResponse : IRestApiResponse
    {
        private Object _Parameter = null; 
        private HttpRequestMessage _Request = null;
        private HttpStatusCode _StatusCode = HttpStatusCode.OK;
        private Dictionary<String, String> _Headers = new Dictionary<string, string>();
        private string _ResponseBodyText = "";

        object IRestApiResponse.Parameter
        {
            get { return _Parameter; }
        }
        HttpRequestMessage IRestApiResponse.Request
        {
            get { return _Request; }
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

        public void SetProperty(object parameter, HttpRequestMessage request, HttpResponseMessage response, string bodyText)
        {
            var res = response;
            _Parameter = parameter;
            _Request = request;
            _StatusCode = res.StatusCode;
            foreach (var header in res.Headers)
            {
                _Headers[header.Key] = header.Value.ToString() ?? "";
            }
            _ResponseBodyText = bodyText;
        }
        public virtual string GetNextPageToken()
        {
            return "";
        }
        public abstract bool IsThrowException();
    }
}
