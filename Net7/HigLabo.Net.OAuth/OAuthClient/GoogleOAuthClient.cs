using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class GoogleOAuthClient : OAuthAuthenticationClient
    {
        public GoogleOAuthClient(String clientID, String clientSecret)
         : base("https://www.googleapis.com/oauth2/v4/token", clientID, clientSecret)
        {
        }
        public override String CreateAuthorizeUrl(String redirectUrl, String[] scopes)
        {
            return String.Format("https://accounts.google.com/o/oauth2/v2/auth?response_type=code&access_type=offline"
                + "&client_id={0}&redirect_uri={1}&scope={2}"
                , this.ClientID, redirectUrl, WebUtility.UrlEncode(String.Join(" ", scopes)));
        }
        public override async ValueTask<OAuthTokenGetRequestResult> RequestCodeAsync(string code, string redirectUrl)
        {
            return await RequestCodeAsync_Common(code, redirectUrl);
        }
    }
}
