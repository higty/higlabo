using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class OAuth2Client : HttpClient
    {
        /// <summary>
        /// 
        /// </summary>
        public String ClientID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ClientSecret { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String RedirectUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OAuth2AccessToken AccessToken { get; set; }

        public OAuth2Client()
        {
            this.ResponseEncoding = Encoding.UTF8;
        }

        public void Authenticate(String code, Action callback)
        {
            this.GetAccessToken(code, token =>
            {
                this.AccessToken = token;
                if (this.AccessToken.State == OAuthAccessTokenState.Success)
                {
                    callback();
                }
                else
                {
                    var ex = new OAuthAuthenticateException(token.JsonText, "");
                    this.OnError(new AsyncHttpCallErrorEventArgs(null, ex));
                }
            });
        }
        public abstract String GetAuthorizeUrl(OAuth2ResponseType responseType);
        public String GetAuthorizeUrl(OAuth2ResponseType responseType, IDictionary<String, String> queryString)
        {
            var url = this.GetAuthorizeUrl(responseType);
            Func<String, String> f = UrlEncode;
            StringBuilder sb = new StringBuilder();
            foreach (var key in queryString.Keys)
            {
                sb.AppendFormat("&{0}={1}", f(key), f(queryString[key]));
            }
            return url + sb.ToString();
        }
        public void GetAccessToken(String code, Action<OAuth2AccessToken> callback)
        {
            var cm = this.CreateGetAccessTokenCommand(code);
            this.GetBodyText(cm, text =>
            {
                var t = OAuth2AccessToken.Create(text);
                callback(t);
            });
        }
        protected abstract HttpRequestCommand CreateGetAccessTokenCommand(String code);
    }
}
