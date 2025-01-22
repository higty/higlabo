using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth;

public class GoogleOAuthClient : OAuthAuthenticationClient
{
    public GoogleOAuthClient(String clientID, String clientSecret)
     : base("https://www.googleapis.com/oauth2/v4/token", clientID, clientSecret)
    {
    }
    public override String CreateAuthorizeUrl(String redirectUrl, String[] scopes, string state)
    {
        return "https://accounts.google.com/o/oauth2/v2/auth?response_type=code&access_type=offline&include_granted_scopes=true"
            + $"&client_id={this.ClientID}&redirect_uri={redirectUrl}&scope={WebUtility.UrlEncode(String.Join(" ", scopes))}&state={state}";
    }
    public override async ValueTask<OAuthTokenGetRequestResult> RequestCodeAsync(string code, string redirectUrl)
    {
        return await RequestCodeAsync_Common(code, redirectUrl);
    }
}
