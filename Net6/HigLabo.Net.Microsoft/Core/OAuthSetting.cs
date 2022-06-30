using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Microsoft
{
    public enum OAuthTenant
    {
        Common,
        Organizations,
        Consumers,
    }
    public enum OAuthResponseMode
    {
        Query,
        Form_Post
    }

    public class OAuthSetting : HigLabo.Net.OAuth.OAuthSetting
    {
        public OAuthTenant? Tenant { get; set; }
        public OAuthResponseMode? ResponseMode { get; set; }
        public List<Scope> ScopeList { get; init; } = new();
        public string State { get; set; } = "";

        public override string CreateUrl()
        {
            var d = new Dictionary<string, string>();
            d["response_type"] = "code";
            d["client_id"] = this.ClientId;
            d["client_secret"] = this.ClientSecret;
            d["redirect_uri"] = this.RedirectUrl;
            d["scope"] = WebUtility.UrlEncode(String.Join(" ", this.ScopeList));
            if (this.Tenant.HasValue)
            {
                d["tenant"] = this.Tenant.ToStringFromEnum().ToLower();
            }
            if (this.ResponseMode.HasValue)
            {
                d["response_mode"] = this.ResponseMode.ToStringFromEnum().ToLower();
            }
            if (this.State.IsNullOrEmpty() == false)
            {
                d["state"] = this.State;
            }
            var q = new QueryStringConverter();
            return "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?" + q.Write(d);
        }
    }
}
