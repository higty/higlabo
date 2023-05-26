using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class SlackOAuthClient : OAuthAuthenticationClient
    {
        public SlackOAuthClient(String clientID, String clientSecret)
            : base("https://slack.com/api/oauth.v2.access", clientID, clientSecret)
        {

        }

        public override String CreateAuthorizeUrl(String redirectUrl, String[] scopes)
        {
            return String.Format("https://slack.com/oauth/v2/authorize?"
                + "client_id={0}&scope={1}&redirect_uri={2}"
                , this.ClientID, WebUtility.UrlEncode(String.Join(",", scopes)), redirectUrl);
        }
        public String CreateAuthorizeUrlForUserScope(String redirectUrl, String[] scopes)
        {
            return String.Format("https://slack.com/oauth/v2/authorize?"
                + "client_id={0}&user_scope={1}&redirect_uri={2}"
                , this.ClientID, WebUtility.UrlEncode(String.Join(",", scopes)), redirectUrl);
        }

        public override async Task<OAuthTokenGetRequestResult> RequestCodeAsync(string code, string redirectUrl)
        {
            var cl = this;
            var mg = new HttpRequestMessage(HttpMethod.Post, cl.Url);

            var d = new Dictionary<string, string>();
            d["code"] = code;
            d["client_id"] = cl.ClientID;
            d["client_secret"] = cl.ClientSecret;
            d["redirect_uri"] = redirectUrl;
            mg.Content = new FormUrlEncodedContent(d);

            var res = await cl.SendAsync(mg);
            return await ParseResponse<SlackOAuthTokenGetRequestResult>(res);
        }
        protected override async Task<T> ParseResponse<T>(HttpResponseMessage responseMessage)
           where T : class
        {
            var res = responseMessage;
            var bodyText = await res.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<T>(bodyText)!;
            return token;
        }
    }
    public class SlackOAuthTokenGetRequestResult : OAuthTokenGetRequestResult
    {
        public Boolean Ok { get; set; }
        public String Scope { get; set; } = "";
        public String Bot_User_Id { get; set; } = "";
        public String App_Id { get; set; } = "";
        public Team? Team { get; set; }
        public Enterprise? Enterprise { get; set; }
        public Authed_User? Authed_User { get; set; }
    }
    public class Team
    {
        public String Name { get; set; } = "";
        public String Id { get; set; } = "";
    }
    public class Enterprise
    {
        public String Name { get; set; } = "";
        public String Id { get; set; } = "";
    }
    public class Authed_User
    {
        public String Id { get; set; } = "";
        public String Scope { get; set; } = "";
        public String Access_Token { get; set; } = "";
        public String Token_Type { get; set; } = "";
    }
}