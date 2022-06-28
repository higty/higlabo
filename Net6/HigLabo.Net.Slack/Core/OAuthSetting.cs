using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;
using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public enum AuthorizationScopeType
    {
        App,
        User,
    }
    public class OAuthSetting : HigLabo.Net.OAuth.OAuthSetting, IAuthorizationUrlBuilder
    {
        public AuthorizationScopeType ScopeType { get; set; }
        public List<Scope> ScopeList { get; init; } = new();

        public OAuthSetting(string clientId, string clientSecret, AuthorizationScopeType scopeType, string redirectUrl, IEnumerable<Scope> scopeList)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.ScopeType = scopeType;
            this.RedirectUrl = redirectUrl;
            this.ScopeList.AddRange(scopeList);
        }
        public override string CreateUrl()
        {
            var scopeList = String.Join(",", this.ScopeList.Select(el => el.GetScopeName()));
            switch (this.ScopeType)
            {
                case AuthorizationScopeType.App:
                    return $"https://slack.com/oauth/v2/authorize?client_id={this.ClientId}&scope={WebUtility.UrlEncode(scopeList)}&redirect_uri={this.RedirectUrl}";
                case AuthorizationScopeType.User:
                    return $"https://slack.com/oauth/v2/authorize?client_id={this.ClientId}&user_scope={WebUtility.UrlEncode(scopeList)}&redirect_uri={this.RedirectUrl}";
                default:throw new SwitchStatementNotImplementException<AuthorizationScopeType>(this.ScopeType);
            }
        }
    }
}
