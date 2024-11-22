using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth;

public class Microsoft365OAuthClient : OAuthAuthenticationClient
{
    public Microsoft365OAuthClient(String clientID, String clientSecret)
        : base("https://login.microsoftonline.com/common/oauth2/v2.0/token", clientID, clientSecret)
    {

    }

    public override String CreateAuthorizeUrl(String redirectUrl, String[] scopes, string state)
    {
        return "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?response_type=code"
            + $"&client_id={this.ClientID}&redirect_uri={redirectUrl}&scope={WebUtility.UrlEncode(String.Join(" ", scopes))}&state ={state}";
    }
    public override async ValueTask<OAuthTokenGetRequestResult> RequestCodeAsync(string code, string redirectUrl)
    {
        return await RequestCodeAsync_Common(code, redirectUrl);
    }
    public async ValueTask<OAuthTokenGetRequestResult> RefreshTokenAsync(String refreshToken, String redirectUrl, String[] scopes)
    {
        var cl = this;
        var d = new Dictionary<String, String>();
        d["client_id"] = cl.ClientID;
        d["client_secret"] = cl.ClientSecret;
        d["grant_type"] = "refresh_token";
        d["refresh_token"] = refreshToken;
        d["scope"] = String.Join(" ", scopes);
        d["redirect_uri"] = redirectUrl;
        var res = await cl.PostAsync("https://login.microsoftonline.com/common/oauth2/v2.0/token", new FormUrlEncodedContent(d));
        var bodyText = await res.Content.ReadAsStringAsync();
        if (res.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return JsonConvert.DeserializeObject<OAuthTokenGetRequestResult>(bodyText)!;
        }
        else
        {
            var ex = JsonConvert.DeserializeObject<RefreshTokenException>(bodyText)!;
            throw ex;
        }
    }
}
