using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net
{
    public abstract partial class OAuth2Client : HttpClient
    {
        public Task<OAuth2AccessToken> AuthenticateAsync(String code)
        {
            var result = new TaskCompletionSource<OAuth2AccessToken>();
            var cm = this.CreateGetAccessTokenCommand(code);
            this.GetBodyText(cm, text =>
            {
                var token = OAuth2AccessToken.Create(text);
                this.AccessToken = token;
                result.SetResult(token);
            });
            return result.Task;
        }
        public Task<OAuth2AccessToken> GetAccessTokenAsync(String code)
        {
            var result = new TaskCompletionSource<OAuth2AccessToken>();
            var cm = this.CreateGetAccessTokenCommand(code);
            this.GetBodyText(cm, text =>
            {
                var token = OAuth2AccessToken.Create(text);
                result.SetResult(token);
            });
            return result.Task;
        }
    }
}
