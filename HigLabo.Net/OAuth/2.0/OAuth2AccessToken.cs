using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Net.Extensions;

namespace HigLabo.Net
{
    public class OAuth2AccessToken
    {
        /// <summary>
        /// 
        /// </summary>
        public OAuthAccessTokenState State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String JsonText { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String Value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 ExpiresIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String TokenType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String RefreshToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<String, String> Values { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public OAuth2AccessToken()
        {
            this.State = OAuthAccessTokenState.Unknown;
            this.JsonText = "";
            this.Value = "";
            this.ExpiresIn = -1;
            this.TokenType = "";
            this.RefreshToken = "";
            this.Values = new Dictionary<string, string>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        public void SetProperty(OAuth2AccessToken accessToken)
        {
            this.Value = accessToken.Value;
            this.ExpiresIn = accessToken.ExpiresIn;
            this.TokenType = accessToken.TokenType;
            this.RefreshToken = accessToken.RefreshToken;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static OAuth2AccessToken Create(String clientID, String jsonText)
        {
            OAuth2AccessToken t = new OAuth2AccessToken();
            t.JsonText = jsonText;
            var d = AppEnvironment.Settings.JsonSerializer.Deserialize<Dictionary<String, Object>>(jsonText);
            foreach (var key in d.Keys)
            {
                t.Values[key] = d[key].ToString();
            }
            t.Value = d.ToString("access_token");
            t.ExpiresIn = d.ToInt32("expired_in") ?? 0;
            t.TokenType = d.ToString("token_type");
            t.RefreshToken = d.ToString("refresh_token");

            if (String.IsNullOrEmpty(t.Value) == true)
            {
                t.State = OAuthAccessTokenState.Error;
            }
            else
            {
                t.State = OAuthAccessTokenState.Success;
            }

            return t;
        }
    }
}
