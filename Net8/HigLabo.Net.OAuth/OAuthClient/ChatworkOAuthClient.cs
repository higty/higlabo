using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth;

public class ChatworkOAuthClient : OAuthAuthenticationClient
{
    public ChatworkOAuthClient(String clientID, String clientSecret)
        : base("https://oauth.chatwork.com/token", clientID, clientSecret)
    {

    }

    /// <summary>
    /// https://developer.chatwork.com/docs/oauth
    /// </summary>
    /// <param name="redirectUrl"></param>
    /// <param name="scopes"></param>
    /// <returns></returns>
    public override String CreateAuthorizeUrl(String redirectUrl, String[] scopes, string state)
    {
        return CreateAuthorizeUrl(redirectUrl, scopes, state, "");
    }
    public String CreateAuthorizeUrl(String redirectUrl, String[] scopes, String state, String code_challenge)
    {
        var l = new List<String>();
        l.Add("client_id=" + this.ClientID);
        l.Add("redirect_uri=" + redirectUrl);
        l.Add("scope=" + WebUtility.UrlEncode(String.Join(" ", scopes)));
        if (state.IsNullOrEmpty() == false)
        {
            l.Add("state=" + state);
        }
        if (state.IsNullOrEmpty() == false)
        {
            l.Add("code_challenge=" + code_challenge);
            l.Add("code_challenge_method=S256");
        }
        return "https://www.chatwork.com/packages/oauth2/login.php?response_type=code&" + String.Join('&', l);
    }

    public String CreateAuthorizationHeaderValue()
    {
        var cl = this;
        var authValue = Encoding.UTF8.GetBytes(cl.ClientID + ":" + cl.ClientSecret);
        return String.Format("Basic {0}", Convert.ToBase64String(authValue));
    }
    public override async ValueTask<OAuthTokenGetRequestResult> RequestCodeAsync(string code, string redirectUrl)
    {
        var cl = this;
        var mg = new HttpRequestMessage(HttpMethod.Post, cl.Url);
        mg.Headers.Add("Authorization", this.CreateAuthorizationHeaderValue());
        mg.Headers.Add("Accept-Encoding", "gzip");

        var d = new Dictionary<string, string>();
        d["code"] = code;
        d["grant_type"] = "authorization_code";
        d["redirect_uri"] = redirectUrl;
        //d["code_verifier"] = "challenge";
        mg.Content = new FormUrlEncodedContent(d);

        var res = await cl.SendAsync(mg);
        return await ParseResponse(res);
    }
    public async ValueTask<OAuthTokenGetRequestResult> UpdateAccessTokenAsync(string refreshToken, String[] scopes)
    {
        var cl = this;
        var mg = new HttpRequestMessage(HttpMethod.Post, cl.Url);
        mg.Headers.Add("Authorization", this.CreateAuthorizationHeaderValue());
        mg.Headers.Add("Accept-Encoding", "gzip");

        var d = new Dictionary<string, string>();
        d["grant_type"] = "refresh_token";
        d["refresh_token"] = refreshToken;
        d["scope"] = String.Join(" ", scopes);
        //d["code_verifier"] = "challenge";
        mg.Content = new FormUrlEncodedContent(d);

        var res = await cl.SendAsync(mg);
        return await ParseResponse(res);
    }
}