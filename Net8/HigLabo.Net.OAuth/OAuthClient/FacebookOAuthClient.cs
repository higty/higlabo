using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth;

public class FacebookOAuthClient : OAuthAuthenticationClient
{
    public FacebookOAuthClient(String clientID, String clientSecret)
        : base("https://graph.facebook.com/v14.0/oauth/access_token", clientID, clientSecret)
    {

    }

    public override String CreateAuthorizeUrl(String redirectUrl, String[] scopes, string state)
    {
        return String.Format("https://www.facebook.com/dialog/oauth"
            + "?client_id={0}&redirect_uri={1}&scope={2}"
            , this.ClientID, redirectUrl, WebUtility.UrlEncode(String.Join(",", scopes)));
    }
    public override async ValueTask<OAuthTokenGetRequestResult> RequestCodeAsync(string code, string redirectUrl)
    {
        var cl = this;
        var url = String.Format("{0}?client_id={1}&redirect_uri={2}&client_secret={3}&code={4}"
            , this.Url, this.ClientID, redirectUrl, this.ClientSecret, code);
        var mg = new HttpRequestMessage(HttpMethod.Get, url);

        var res = await cl.SendAsync(mg);

        return await ParseResponse(res);
    }
}