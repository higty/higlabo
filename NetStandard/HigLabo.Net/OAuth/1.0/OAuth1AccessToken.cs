using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuth1AccessToken
    {
        /// <summary>
        /// 
        /// </summary>
        public OAuthAccessTokenState State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String RawValue { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String Token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String TokenSecret { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<String, String> Values { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public OAuth1AccessToken()
            : this("", "")
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        public OAuth1AccessToken(String token, String tokenSecret)
        {
            this.State = OAuthAccessTokenState.Unknown;
            this.Values = new Dictionary<string, string>();
            this.RawValue = "";
            this.Token = token;
            this.TokenSecret = tokenSecret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        public void SetProperty(OAuth1AccessToken accessToken)
        {
            this.Token = accessToken.Token;
            this.TokenSecret = accessToken.TokenSecret;
            foreach (var key in accessToken.Values.Keys)
            {
                this.Values[key] = accessToken.Values[key];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tokenKey"></param>
        /// <param name="tokenSecretKey"></param>
        /// <returns></returns>
        public static OAuth1AccessToken Create(String value)
        {
            OAuth1AccessToken t = new OAuth1AccessToken();
            t.RawValue = value;
            var tokenKey = "oauth_token";
            var tokenSecretKey = "oauth_token_secret";
            String[] ss = value.Split('&');
            String[] sss = null;
            Dictionary<String, String> d = new Dictionary<string, string>();
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i].Contains("=") == false) { continue; }
                sss = ss[i].Split('=');
                if (sss.Length == 2)
                {
                    d[sss[0].ToLower()] = sss[1];
                }
            }
            t.Values = d;
            if (d.ContainsKey(tokenKey) == true)
            {
                t.Token = d[tokenKey];
            }
            if (d.ContainsKey(tokenSecretKey) == true)
            {
                t.TokenSecret = d[tokenSecretKey];
            }
            if (String.IsNullOrEmpty(t.Token) == false &&
                String.IsNullOrEmpty(t.TokenSecret) == false)
            {
                t.State = OAuthAccessTokenState.Success;
            }
            else
            {
                t.State = OAuthAccessTokenState.Error;
            }
            return t;
        }
   }
}
