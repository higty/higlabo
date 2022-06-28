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
            var response = OAuthClient.JsonConverter.DeserializeObject<RequestCodeResponse>(bodyText);
            await response.SetProperty(req, res, CancellationToken.None);
            return response;
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
            d["redirect_uri"] = b.RedirectUrl;
            req.Content = new FormUrlEncodedContent(d);

            var res = await cl.SendAsync(req);
            var bodyText = await res.Content.ReadAsStringAsync();
            var response = this.DeserializeObject<RequestCodeResponse>(bodyText);
            await response.SetProperty(req, res, CancellationToken.None);
            return response;
        }

        private async Task<RestApiResponse> GetResponseAsync(String apiPath, HttpMethod httpMethod, Dictionary<String, String> parameter, CancellationToken cancellationToken)
        {
            var cl = this;
            var req = cl.CreateHttpRequestMessage(ApiUrl + apiPath, httpMethod);
            var d = new Dictionary<String, String>();
            foreach (var key in parameter.Keys)
            {
                d[key.ToLower()] = parameter[key];
            }
            req.Content = new FormUrlEncodedContent(d);
            var res = await cl.SendAsync(req);

            var response = new RestApiResponse();
            await response.SetProperty(req, res, cancellationToken);
            return response;
        }
        private async Task<RestApiResponse> GetResponseAsync(String apiPath, HttpMethod httpMethod, object parameter, CancellationToken cancellationToken)
        {
            var cl = this;
            var req = cl.CreateHttpRequestMessage(ApiUrl + apiPath, httpMethod);
            var json = this.SerializeObject(parameter);
            req.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await cl.SendAsync(req);

            var response = new RestApiResponse();
            await response.SetProperty(req, res, cancellationToken);
            return response;
        }

        public async Task<RestApiResponse> SendAsync(IRestApiParameter parameter)
        {
            return await SendAsync(parameter, CancellationToken.None);
        }
        public async Task<RestApiResponse> SendAsync(IRestApiParameter parameter, CancellationToken cancellationToken)
        {
            var d = parameter.Map(new Dictionary<string, string>());
            if (parameter is RemindersAddParameter p)
            {
                d["Recurrence"] = p.Recurrence.ToString();
            }
            Func<Task<RestApiResponse>> func = () => this.GetResponseAsync(parameter.ApiPath, new HttpMethod("POST"), d, cancellationToken);

            var isFirst = true;

            while (true)
            {
                try
                {
                    return await func();
                }
                catch (Exception ex)
                {
                    if (isFirst == false) { throw; }
                    isFirst = false;
                }
                try
                {
                    var result = await this.UpdateAccessTokenAsync();
                    this.OnAccessTokenUpdated(new AccessTokenUpdatedEventArgs(result));
                }
                catch
                {
                }
            }
        }

        public async Task<TResponse> SendAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
            where TParameter : IRestApiParameter
            where TResponse: RestApiResponse
        {
            var res = await this.SendAsync(parameter, cancellationToken);
            var o = this.DeserializeObject<TResponse>((res as IRestApiResponse).ResponseBodyText);
            o.SetProperty(res);
            return o;
        }
        public async Task<List<TResponse>> SendBatchAsync<TParameter, TResponse>(TParameter parameter, PagingContext<TResponse> context)
            where TParameter : IRestApiParameter, ICursor
            where TResponse : RestApiResponse
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<TResponse>> SendBatchAsync<TParameter, TResponse>(TParameter parameter, PagingContext<TResponse> context, CancellationToken cancellationToken)
            where TParameter : IRestApiParameter, ICursor
            where TResponse : RestApiResponse
        {
            var p = parameter;
            var l = new List<TResponse>();
            while (true)
            {
                var res = await this.SendAsync(p, cancellationToken);
                var o = this.DeserializeObject<TResponse>((res as IRestApiResponse).ResponseBodyText);
                res.Map(o);
                l.Add(o);

                context.InvokeResponseReceived(new ResponseReceivedEventArgs<TResponse>(this, l));
                if (context.Break) { break; }
                if (res.Response_MetaData == null || res.Response_MetaData.Next_Cursor.IsNullOrEmpty()) { break; }
                p.Cursor = res.Response_MetaData.Next_Cursor;
            }
            return l;
        }
    }
}
