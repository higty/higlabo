using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class TwitterOAuthClient : OAuthClient
    {
        public TwitterOAuthClient(String clientID, String clientSecret)
            : base("https://api.twitter.com/2/oauth2/token", clientID, clientSecret)
        {

        }

        public override String CreateAuthorizeUrl(OAuthServiceProvider provider, String redirectUrl, String[] scopes)
        {
            return String.Format("https://twitter.com/i/oauth2/authorize?response_type=code&access_type=offline"
                + "&client_id={0}&redirect_uri={1}&scope={2}"
                + "&state=state&code_challenge=challenge&code_challenge_method=plain"
                , this.ClientID, redirectUrl, WebUtility.UrlEncode(String.Join(" ", scopes)));
        }
        public override async Task<OAuthTokenGetRequestResult> PostCodeAsync(string code, string redirectUrl)
        {
            var cl = this;
            var authValue = Encoding.UTF8.GetBytes(Uri.EscapeDataString(this.ClientID)
                + ":" + Uri.EscapeDataString(this.ClientSecret));
            var authHeader = String.Format("Basic {0}", Convert.ToBase64String(authValue));
            var mg = new HttpRequestMessage(HttpMethod.Post, this.Url);
            mg.Headers.Add("Authorization", authHeader);
            mg.Headers.Add("Accept-Encoding", "gzip");

            var d = new Dictionary<string, string>();
            d["code"] = code;
            d["grant_type"] = "authorization_code";
            d["client_id"] = this.ClientID;
            d["redirect_uri"] = redirectUrl;
            d["code_verifier"] = "challenge";
            mg.Content = new FormUrlEncodedContent(d);

            var res = await cl.SendAsync(mg);
            return await ParseResponse(res);

        }
    }
}