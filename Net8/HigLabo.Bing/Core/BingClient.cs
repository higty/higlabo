using HigLabo.Core;
using HigLabo.RestApi;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HigLabo.Bing
{
    public partial class BingClient 
    {
        public static BingClientDefaultSettings Default { get; } = new();

        public event EventHandler<HttpRequestMessageEventArgs>? PreSendRequest;

        public HttpClient HttpClient { get; set; } = new();
        public IJsonConverter JsonConverter { get; set; } = new BingJsonConverter();

        public string Endpoint { get; set; } = Default.Endpoint;
        public string ApiKey { get; set; } = "";

        public BingClient()
        {

        }
        public BingClient(string apiKey)
        {
            this.ApiKey = apiKey;
        }
        public BingClient(string apiKey, HttpClient httpClient)
        {
            this.ApiKey = apiKey;
            this.HttpClient = httpClient;
        }

        public HttpRequestMessage CreateRequestMessage<T>(T parameter)
            where T: BingRestApiParameter
        {
            var p = parameter;
            var url = $"{this.Endpoint}{p.GetApiPath()}?{p.GetQueryString()}";
            var req = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
            req.Headers.Add("Ocp-Apim-Subscription-Key", this.ApiKey);
            if (p.UserAgent.HasValue())
            {
                req.Headers.TryAddWithoutValidation("User-Agent", p.UserAgent);
            }
            if (p.MSEdgeClientId.HasValue())
            {
                req.Headers.TryAddWithoutValidation("X-MSEdge-ClientID", p.MSEdgeClientId);
            }
            if (p.MSEdgeClientIP.HasValue())
            {
                req.Headers.TryAddWithoutValidation("X-MSEdge-ClientIP", p.MSEdgeClientIP);
            }

            return req;
        }
        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request, HttpCompletionOption httpCompletionOption, CancellationToken cancellationToken)
        {
            this.PreSendRequest?.Invoke(this, new HttpRequestMessageEventArgs(request));
            var res = await this.HttpClient.SendAsync(request, httpCompletionOption, cancellationToken);
            return res;
        }
        private async Task<TResponse> CreateResponse<TResponse>(object parameter, HttpRequestMessage request, string requestBodyText, HttpResponseMessage response)
                 where TResponse : BingRestApiResponse, new()
        {
            var res = response;
            var bodyText = await res.Content.ReadAsStringAsync();
            if (res.IsSuccessStatusCode)
            {
                var o = this.JsonConverter.DeserializeObject<TResponse>(bodyText);
                o.SetProperty(parameter, requestBodyText, request, res, bodyText);
                return o;
            }
            else
            {
                var errorResponse = this.JsonConverter.DeserializeObject<BingServerErrorResponse>(bodyText);
                throw new BingServerException(parameter, request, requestBodyText, response, bodyText, errorResponse.Errors);
            }
        }

        public async ValueTask<TResponse> SendJsonAsync<TParameter, TResponse>(TParameter parameter)
            where TParameter : BingRestApiParameter, IRestApiParameter
            where TResponse : BingRestApiResponse, new()
        {
            return await this.SendJsonAsync<TParameter, TResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<TResponse> SendJsonAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
            where TParameter : BingRestApiParameter
            where TResponse : BingRestApiResponse, new()
        {
            var p = parameter as IRestApiParameter;
            var req = this.CreateRequestMessage(parameter);
            var requestBodyText = "";
            if (string.Equals(p.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase) == false)
            {
                var o = parameter.GetRequestBody();
                if (o != null)
                {
                    requestBodyText = this.JsonConverter.SerializeObject(o);
                }
                req.Content = new StringContent(requestBodyText, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            }
            Debug.WriteLine(requestBodyText);
            var res = await this.SendRequestAsync(req, HttpCompletionOption.ResponseContentRead, cancellationToken);
            return await this.CreateResponse<TResponse>(parameter, req, requestBodyText, res);
        }
    }
}
