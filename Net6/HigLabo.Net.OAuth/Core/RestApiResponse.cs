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
        HttpRequestMessage Request { get; }
        HttpStatusCode StatusCode { get; }
        Dictionary<String, String> Headers { get; } 
        string ResponseBodyText { get; } 
    }

    public class RestApiResponse : IRestApiResponse
    {
        private HttpRequestMessage _Request = null;
        private HttpStatusCode _StatusCode = HttpStatusCode.OK;
        private Dictionary<String, String> _Headers = new Dictionary<string, string>();
        private string _ResponseBodyText = "";

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

        public void SetProperty(RestApiResponse response)
        {
            var res = response;

            _Request = (res as IRestApiResponse).Request;
            _StatusCode = res._StatusCode;
            foreach (var header in res._Headers)
            {
                _Headers[header.Key] = header.Value.ToString() ?? "";
            }
            _ResponseBodyText = res._ResponseBodyText;
        }
        public async Task SetProperty(HttpRequestMessage request, HttpResponseMessage response, CancellationToken cancellationToken)
        {
            var res = response;

            _Request = request;
            _StatusCode = res.StatusCode;
            foreach (var header in res.Headers)
            {
                _Headers[header.Key] = header.Value.ToString() ?? "";
            }
            _ResponseBodyText = await res.Content.ReadAsStringAsync(cancellationToken);
        }
    }
}
