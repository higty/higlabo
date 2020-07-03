using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    public abstract partial class OAuth2Client : HttpClient
    {
        public void Authenticate(String code)
        {
            this.AccessToken = this.GetAccessToken(code);
            if (this.AccessToken.State == OAuthAccessTokenState.Error)
            {
                throw new OAuthAuthenticateException(this.AccessToken.JsonText, "Failure to get AccessToken by OAuth2.0.");
            }
        }
        public virtual OAuth2AccessToken GetAccessToken(String code)
        {
            var cm = this.CreateGetAccessTokenCommand(code);
            var text = this.GetBodyText(cm);
            var t = OAuth2AccessToken.Create(text);
            return t;
        }
    }
}
