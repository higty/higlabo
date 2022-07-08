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

        public SlackClient(IJsonConverter jsonConverter, string accessToken)
            : base(jsonConverter)
        {
            this.AccessToken = accessToken;
        }
        public SlackClient(IJsonConverter jsonConverter, OAuthSetting setting)
            : base(jsonConverter)
        {
            this.OAuthSetting = setting;
        }
        public SlackClient(IJsonConverter jsonConverter, string accessToken, string refreshToken, OAuthSetting setting)
            : base(jsonConverter)
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

        public override async Task<TResponse> SendAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
        {
            Func<Task<TResponse>> f = null;
            if (string.Equals(parameter.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                //Use POST method with FormUrlEncodedContent for GET endpoint.
                var d = parameter.Map(new Dictionary<string, string>());
                if (parameter is RemindersAddParameter p)
                {
                    d["Recurrence"] = p.Recurrence.ToString();
                }
                f = () => this.SendFormAsync<TResponse>(this.CreateHttpRequestMessage(ApiUrl + parameter.ApiPath, new HttpMethod("POST")), d, cancellationToken);
            }
            else
            {
                f = () => this.SendJsonAsync<TResponse>(this.CreateHttpRequestMessage(ApiUrl + parameter.ApiPath, new HttpMethod("POST")), parameter, cancellationToken);
            }
            return await this.ProcessRequest(f);
        }

        protected override async Task ProcessAccessTokenAsync()
        {
            var result = await this.UpdateAccessTokenAsync();
            if (result.Ok)
            {
                this.AccessToken = result.Authed_User.Access_Token;
                this.RefreshToken = result.Authed_User.Refresh_Token;
            }
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
            return this.ParseObject<RequestCodeResponse>(d, req, res, bodyText);
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
            var q = new QueryStringConverter();
            var o = this.ParseObject<RequestCodeResponse>(d, req, res, bodyText);
            if (o.Ok)
            {
                this.OnAccessTokenUpdated(new AccessTokenUpdatedEventArgs(o));
            }
            return o;
        }

    }
}
