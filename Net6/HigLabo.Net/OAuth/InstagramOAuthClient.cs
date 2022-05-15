using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class InstagramOAuthClient : OAuthClient
    {
        public InstagramOAuthClient(String clientID, String clientSecret)
            : base("https://api.instagram.com/oauth/access_token", clientID, clientSecret)
        {

        }

        public override String CreateAuthorizeUrl(OAuthServiceProvider provider, String redirectUrl, String[] scopes)
        {
            return String.Format("https://api.instagram.com/oauth/authorize?response_type=code&access_type=offline"
                + "&client_id={0}&redirect_uri={1}&scope={2}"
                + "&state=state&code_challenge=challenge&code_challenge_method=plain"
                , this.ClientID, redirectUrl, WebUtility.UrlEncode(String.Join(",", scopes)));
        }
        public override async Task<OAuthTokenGetRequestResult> PostCodeAsync(string code, string redirectUrl)
        {
            var cl = this;
            var mg = new HttpRequestMessage(HttpMethod.Post, this.Url);

            var d = new Dictionary<string, string>();
            d["client_id"] = this.ClientID;
            d["client_secret"] = this.ClientSecret;
            d["code"] = code;
            d["grant_type"] = "authorization_code";
            d["redirect_uri"] = redirectUrl;

            mg.Content = new FormUrlEncodedContent(d);

            var res = await cl.SendAsync(mg);

            return await ParseResponse(res);
        }
    }
}