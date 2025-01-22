using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth;

public class TwitterOAuthClient : OAuthAuthenticationClient
{
    public TwitterOAuthClient(String clientID, String clientSecret)
        : base("https://api.twitter.com/2/oauth2/token", clientID, clientSecret)
    {

    }

    public override String CreateAuthorizeUrl(String redirectUrl, String[] scopes, string state)
    {
        return String.Format("https://twitter.com/i/oauth2/authorize?response_type=code&access_type=offline"
            + "&client_id={0}&redirect_uri={1}&scope={2}"
            + "&state=state&code_challenge=challenge&code_challenge_method=plain"
            , this.ClientID, redirectUrl, WebUtility.UrlEncode(String.Join(" ", scopes)));
    }

    private String CreateAuthorizationHeaderValue()
    {
        var cl = this;
        var authValue = Encoding.UTF8.GetBytes(Uri.EscapeDataString(cl.ClientID) + ":" + Uri.EscapeDataString(cl.ClientSecret));
        return String.Format("Basic {0}", Convert.ToBase64String(authValue));
    }
    private HttpRequestMessage CreateHttpRequestMessage(String url)
    {
        var mg = new HttpRequestMessage(HttpMethod.Post, url);
        mg.Headers.Add("Authorization", this.CreateAuthorizationHeaderValue());
        mg.Headers.Add("Accept-Encoding", "gzip");
        return mg;
    }
    public override async ValueTask<OAuthTokenGetRequestResult> RequestCodeAsync(string code, string redirectUrl)
    {
        var cl = this;
        var mg = this.CreateHttpRequestMessage(cl.Url);

        var d = new Dictionary<string, string>();
        d["code"] = code;
        d["grant_type"] = "authorization_code";
        d["client_id"] = cl.ClientID;
        d["redirect_uri"] = redirectUrl;
        d["code_verifier"] = "challenge";
        mg.Content = new FormUrlEncodedContent(d);

        var res = await cl.SendAsync(mg);
        return await ParseResponse(res);

    }
}