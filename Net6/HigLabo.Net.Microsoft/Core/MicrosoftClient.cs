using HigLabo.Net.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Microsoft
{
    public partial class MicrosoftClient : HigLabo.Net.OAuth.OAuthClient
    {
        public MicrosoftClient(string accessToken)
        {
            this.AccessToken = accessToken;
        }
        public MicrosoftClient(OAuthSetting setting)
        {
            this.OAuthSetting = setting;
        }
        public MicrosoftClient(string accessToken, string refreshToken, OAuthSetting setting)
        {
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
            this.OAuthSetting = setting;
        }

        private RequestCodeResponse ParseObject(object parameter, HttpRequestMessage request, HttpResponseMessage response, string bodyText)
        {
            var req = request;
            var o = this.DeserializeObject<RequestCodeResponse>(bodyText);
            var iRes = o as IRestApiResponse;
            if (this.IsThrowException == true && iRes.StatusCode != System.Net.HttpStatusCode.OK)
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
            var iRes = o as IRestApiResponse;
            if (this.IsThrowException == true && iRes.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new RestApiException(o);
            }
            return o;
        }

        public async Task<RequestCodeResponse> RequestCodeAsync(string code)
        {
            if (this.OAuthSetting == null)
            { throw new InvalidOperationException("AuthorizationUrlBuilder property is null. Please set SlackClient.OAuthSetting property."); }

            var cl = this;
            var b = this.OAuthSetting as OAuthSetting;
            var req = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/common/oauth2/v2.0/token");

            var d = new Dictionary<string, string>();
            d["code"] = code;
            d["grant_type"] = "authorization_code";
            d["access_type"] = "offline";
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
            var b = this.OAuthSetting as OAuthSetting;
            var req = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/common/oauth2/v2.0/token");

            var d = new Dictionary<string, string>();
            d["client_id"] = b.ClientId;
            d["client_secret"] = b.ClientSecret;
            d["grant_type"] = "refresh_token";
            d["refresh_token"] = this.RefreshToken;
            d["scope"] = String.Join(" ", b.ScopeList);
            d["redirect_uri"] = b.RedirectUrl;
            req.Content = new FormUrlEncodedContent(d);

            var res = await cl.SendAsync(req);
            var bodyText = await res.Content.ReadAsStringAsync();
            return this.ParseObject(d, req, res, bodyText);
        }

    }
}
