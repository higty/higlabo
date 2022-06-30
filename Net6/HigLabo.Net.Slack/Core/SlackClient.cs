using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Net.OAuth;
using HigLabo.Core;

namespace HigLabo.Net.Slack
{
    public partial class SlackClient : OAuthClient
    {
        public static String ApiUrl = "https://slack.com/api/";

        public SlackClient(string accessToken)
        {
            this.AccessToken = accessToken;
        }
        public SlackClient(OAuthSetting setting)
        {
            this.OAuthSetting = setting;
        }
        public SlackClient(string accessToken, string refreshToken, OAuthSetting setting)
        {
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
            this.OAuthSetting = setting;
        }

        private HttpRequestMessage CreateHttpRequestMessage(String url, HttpMethod httpMethod)
        {
            var mg = new HttpRequestMessage(httpMethod, url);
            mg.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.AccessToken);
            return mg;
        }
        private RequestCodeResponse ParseObject(object parameter, HttpRequestMessage request, HttpResponseMessage response, string bodyText)
        {
            var req = request;
            var o = this.DeserializeObject<RequestCodeResponse>(bodyText);
            o.SetProperty(parameter, req, response, bodyText);
            if (this.IsThrowException == true && o.Ok == false)
            {
                throw new RestApiException(o);
            }
            return o;
        }
        protected T ParseObject<T>(object parameter, HttpRequestMessage request, HttpResponseMessage response, string bodyText)
            where T : RestApiResponse
        {
            var req = request;
            var o = this.DeserializeObject<T>(bodyText);
            o.SetProperty(parameter, req, response, bodyText);
            if (this.IsThrowException == true && o.IsThrowException())
            {
                throw new RestApiException(o);
            }
            return o;
        }

        private async Task<TResponse> GetResponseAsync<TResponse>(Func<Task<TResponse>> func)
        {
            var isFirst = true;

            while (true)
            {
                try
                {
                    return await func();
                }
                catch
                {
                    if (isFirst == false) { throw; }
                    isFirst = false;
                }
                var result = await this.UpdateAccessTokenAsync();
                this.AccessToken = result.Authed_User.Access_Token;
                this.RefreshToken = result.Authed_User.Refresh_Token;
                this.OnAccessTokenUpdated(new AccessTokenUpdatedEventArgs(result));
            }
        }
        private async Task<TResponse> GetResponseAsync<TResponse>(String apiPath, HttpMethod httpMethod, Dictionary<String, String> parameter, CancellationToken cancellationToken)
               where TResponse : RestApiResponse
        {
            var req = this.CreateHttpRequestMessage(ApiUrl + apiPath, httpMethod);
            var d = new Dictionary<String, String>();
            foreach (var key in parameter.Keys)
            {
                d[key.ToLower()] = parameter[key];
            }
            req.Content = new FormUrlEncodedContent(d);
            var res = await this.SendAsync(req);
            var bodyText = await res.Content.ReadAsStringAsync(cancellationToken);

            return this.ParseObject<TResponse>(parameter, req, res, bodyText);
        }
        private async Task<TResponse> GetResponseAsync<TResponse>(String apiPath, HttpMethod httpMethod, object parameter, CancellationToken cancellationToken)
                where TResponse : RestApiResponse
        {
            var req = this.CreateHttpRequestMessage(ApiUrl + apiPath, httpMethod);
            var json = this.SerializeObject(parameter);
            req.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await this.SendAsync(req);
            var bodyText = await res.Content.ReadAsStringAsync(cancellationToken);
            return this.ParseObject<TResponse>(parameter, req, res, bodyText);
        }

        public async Task<TResponse> SendAsync<TParameter, TResponse>(TParameter parameter)
            where TParameter : IRestApiParameter
            where TResponse : RestApiResponse, new()
        {
            return await this.SendAsync<TParameter, TResponse>(parameter, CancellationToken.None);
        }
        public async Task<TResponse> SendAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
            where TParameter : IRestApiParameter
            where TResponse: RestApiResponse
        {
            var apiPath = parameter.ApiPath;
            if (string.Equals(parameter.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                //Use POST method with FormUrlEncodedContent for GET endpoint.
                var d = parameter.Map(new Dictionary<string, string>());
                if (parameter is RemindersAddParameter p)
                {
                    d["Recurrence"] = p.Recurrence.ToString();
                }
                return await this.GetResponseAsync(() => this.GetResponseAsync<TResponse>(apiPath, new HttpMethod("POST"), d, cancellationToken));
            }
            else
            {
                return await this.GetResponseAsync(() => this.GetResponseAsync<TResponse>(apiPath, new HttpMethod("POST"), parameter, cancellationToken));
            }
        }
        public async Task<List<TResponse>> SendBatchAsync<TParameter, TResponse>(TParameter parameter, PagingContext<TResponse> context)
            where TParameter : IRestApiParameter, IRestApiPagingParameter
            where TResponse : RestApiResponse
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<TResponse>> SendBatchAsync<TParameter, TResponse>(TParameter parameter, PagingContext<TResponse> context, CancellationToken cancellationToken)
            where TParameter : IRestApiParameter, IRestApiPagingParameter
            where TResponse : RestApiResponse
        {
            var p = parameter;
            var l = new List<TResponse>();
            while (true)
            {
                var res = await this.SendAsync<TParameter, TResponse>(p, cancellationToken);
                l.Add(res);

                context.InvokeResponseReceived(new ResponseReceivedEventArgs<TResponse>(this, l));
                if (context.Break) { break; }
                if (res.GetNextPageToken().IsNullOrEmpty()) { break; }
                p.NextPageToken = res.GetNextPageToken();
            }
            return l;
        }

        public async Task<RequestCodeResponse> RequestCodeAsync(string code)
        {
            if (this.OAuthSetting == null)
            { throw new InvalidOperationException("AuthorizationUrlBuilder property is null. Please set SlackClient.OAuthSetting property."); }

            var cl = this;
            var b = this.OAuthSetting;
            var req = new HttpRequestMessage(HttpMethod.Post, "https://slack.com/api/oauth.v2.access");

            var d = new Dictionary<string, string>();
            d["code"] = code;
            d["client_id"] = b.ClientId;
            d["client_secret"] = b.ClientSecret;
            d["redirect_uri"] = b.RedirectUrl;
            req.Content = new FormUrlEncodedContent(d);

            var res = await cl.SendAsync(req);
            var bodyText = await res.Content.ReadAsStringAsync();
            return this.ParseObject(d, req, res, bodyText);
        }
        public async Task<RequestCodeResponse> UpdateAccessTokenAsync()
        {
            if (this.OAuthSetting == null)
            { throw new InvalidOperationException("AuthorizationUrlBuilder property is null. Please set SlackClient.OAuthSetting property."); }

            var cl = this;
            var b = this.OAuthSetting;
            var req = new HttpRequestMessage(HttpMethod.Post, "https://slack.com/api/oauth.v2.access");

            var d = new Dictionary<string, string>();
            d["client_id"] = b.ClientId;
            d["client_secret"] = b.ClientSecret;
            d["grant_type"] = "refresh_token";
            d["refresh_token"] = this.RefreshToken;
            d["redirect_uri"] = b.RedirectUrl;
            req.Content = new FormUrlEncodedContent(d);

            var res = await cl.SendAsync(req);
            var bodyText = await res.Content.ReadAsStringAsync();
            return this.ParseObject(d, req, res, bodyText);
        }

    }
}
