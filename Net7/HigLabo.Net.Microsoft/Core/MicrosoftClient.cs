using HigLabo.Core;
using HigLabo.Net.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Microsoft
{
    public partial class MicrosoftClient : OAuthClient
    {
        public RestApiDomainName DomainName { get; set; } = RestApiDomainName.Graph;
        public String TenantName { get; set; } = "";

        public String ApiDomain
        {
            get
            {
                switch (this.DomainName)
                {
                    case RestApiDomainName.Graph: return "https://graph.microsoft.com/v1.0";
                    case RestApiDomainName.Sharepoint: return $"https://{this.TenantName}.sharepoint.com/_api/v2.0";
                    default: throw SwitchStatementNotImplementException.Create(this.DomainName);
                }
            }
        }

        public MicrosoftClient(IJsonConverter jsonConverter, string accessToken)
               : base(jsonConverter)
        {
            this.AccessToken = accessToken;
        }
        public MicrosoftClient(IJsonConverter jsonConverter, OAuthSetting setting)
            : base(jsonConverter)
        {
            this.OAuthSetting = setting;
        }
        public MicrosoftClient(IJsonConverter jsonConverter, string accessToken, string refreshToken, OAuthSetting setting)
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
        public override async ValueTask<TResponse> SendAsync<TParameter, TResponse>(TParameter parameter, CancellationToken cancellationToken)
        {
            Func<ValueTask<TResponse>>? f = null;
            if (string.Equals(parameter.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                var queryString = "";
                if (parameter is IQueryParameterProperty q)
                {
                    queryString = q.Query.GetQueryString();
                }
                f = () => this.SendAsync<TResponse>(this.CreateHttpRequestMessage(this.ApiDomain + parameter.ApiPath + "?" + queryString, new HttpMethod(parameter.HttpMethod)), cancellationToken);
            }
            else
            {
                f = () => this.SendJsonAsync<TResponse>(this.CreateHttpRequestMessage(this.ApiDomain + parameter.ApiPath, new HttpMethod(parameter.HttpMethod)), parameter, cancellationToken);
            }
            return await this.ProcessRequest(f);
        }
        public async ValueTask<Stream> DownloadStreamAsync(IRestApiParameter parameter, CancellationToken cancellationToken)
        {
            var p = parameter;
            var queryString = "";
            if (parameter is IQueryParameterProperty q)
            {
                queryString = q.Query.GetQueryString();
            }
            var f = () => this.DownloadStreamAsync(this.CreateHttpRequestMessage(this.ApiDomain + p.ApiPath + "?" + queryString, new HttpMethod(p.HttpMethod)), cancellationToken);
            return await this.ProcessRequest(f);
        }

        protected override async Task ProcessAccessTokenAsync()
        {
            var result = await this.UpdateAccessTokenAsync();
            if (((IRestApiResponse)result).StatusCode == HttpStatusCode.OK)
            {
                this.AccessToken = result.Access_Token;
                this.RefreshToken = result.Refresh_Token;
            }
        }
        public async ValueTask<RequestCodeResponse> RequestCodeAsync(string code)
        {
            if (this.OAuthSetting == null)
            { throw new InvalidOperationException("AuthorizationUrlBuilder property is null. Please set SlackClient.OAuthSetting property."); }

            var cl = this;
            var b = (OAuthSetting)this.OAuthSetting;
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
            return this.ParseObject<RequestCodeResponse>(d, req, res, bodyText);
        }
        public async ValueTask<RequestCodeResponse> UpdateAccessTokenAsync()
        {
            if (this.OAuthSetting == null)
            { throw new InvalidOperationException("AuthorizationUrlBuilder property is null. Please set SlackClient.OAuthSetting property."); }

            var cl = this;
            var b = (OAuthSetting)this.OAuthSetting;
            var req = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/common/oauth2/v2.0/token");

            var d = new Dictionary<string, string>();
            d["client_id"] = b.ClientId;
            d["client_secret"] = b.ClientSecret;
            d["grant_type"] = "refresh_token";
            d["refresh_token"] = this.RefreshToken;
            d["scope"] = String.Join(" ", b.ScopeList.Select(el => el.GetScopeName()));
            d["redirect_uri"] = b.RedirectUrl;
            req.Content = new FormUrlEncodedContent(d);

            var res = await cl.SendAsync(req);
            var bodyText = await res.Content.ReadAsStringAsync();
            var o = this.ParseObject<RequestCodeResponse>(d, req, res, bodyText);
            if (o is IRestApiResponse iRes && iRes.StatusCode == HttpStatusCode.OK)
            {
                this.OnAccessTokenUpdated(new AccessTokenUpdatedEventArgs(o));
            }
            return o;
        }

    }
}
