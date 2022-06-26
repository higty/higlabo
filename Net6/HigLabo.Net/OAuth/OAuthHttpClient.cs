using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;
using Newtonsoft.Json;

namespace HigLabo.Net.OAuth
{
    public abstract class OAuthClient : HttpClient
    {
        public String Url { get; init; } = "";
        public String ClientID { get; init; } = "";
        public String ClientSecret { get; init; } = "";

        public OAuthClient()
            : base(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            })
        {
        }
        public OAuthClient(String url, String clientID, String clientSecret)
            : this()
        {
            this.Url = url;
            this.ClientID = clientID;
            this.ClientSecret = clientSecret;
        }

        public abstract String CreateAuthorizeUrl(String redirectUrl, String[] scopes);
        public abstract Task<OAuthTokenGetRequestResult> RequestCodeAsync(String code, String redirectUrl);

        protected async Task<OAuthTokenGetRequestResult> RequestCodeAsync_Common(String code, String redirectUrl)
        {
            var cl = this;
            var d = new Dictionary<String, String>();
            d["code"] = code;
            d["grant_type"] = "authorization_code";
            d["access_type"] = "offline";
            d["client_id"] = this.ClientID;
            d["client_secret"] = this.ClientSecret;
            d["redirect_uri"] = redirectUrl;

            var res = await cl.PostFormAsync(this.Url, d);
            return await ParseResponse(res);
        }
        protected async Task<OAuthTokenGetRequestResult> ParseResponse(HttpResponseMessage responseMessage)
        {
            return await ParseResponse<OAuthTokenGetRequestResult>(responseMessage);
        }
        protected virtual async Task<T> ParseResponse<T>(HttpResponseMessage responseMessage)
            where T: class
        {
            var res = responseMessage;
            var bodyText = await res.Content.ReadAsStringAsync();
            if (res.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException("Request failesd. Response body is" + Environment.NewLine + bodyText
                    , null, res.StatusCode);
            }
            var token = JsonConvert.DeserializeObject<T>(bodyText);
            return token;
        }

    }
}
