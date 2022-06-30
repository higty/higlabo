using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.OAuth
{
    public class OAuthClient : HttpClient
    {
        public static IJsonConverter? JsonConverter { get; set; }

        public event EventHandler<AccessTokenUpdatedEventArgs>? AccessTokenUpdated;

        public string AccessToken { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public OAuthSetting? OAuthSetting { get; set; }
        public Boolean IsThrowException { get; set; } = true;

        protected void OnAccessTokenUpdated(AccessTokenUpdatedEventArgs e)
        {
            this.AccessTokenUpdated?.Invoke(this, e);
        }

        protected string SerializeObject(object obj)
        {
            if (JsonConverter == null) { throw new InvalidOperationException("OAuthClient.JsonConverter must be set before call method."); }
            return JsonConverter.SerializeObject(obj);
        }
        protected T DeserializeObject<T>(String json)
        {
            if (JsonConverter == null) { throw new InvalidOperationException("OAuthClient.JsonConverter must be set before call method."); }
            return JsonConverter.DeserializeObject<T>(json);
        }

    }
}
