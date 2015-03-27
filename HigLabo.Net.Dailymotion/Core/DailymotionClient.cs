using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HigLabo.Core;
using HigLabo.Converter;
using HigLabo.Net.Dailymotion.Api_1_0;
using Newtonsoft.Json;

namespace HigLabo.Net.Dailymotion
{
    public partial class DailymotionClient : OAuth2Client
    {
        public ApiEndpoints Api { get; set; }

        public DailymotionClient(String clientID, String clientSecret)
        {
            this.ClientID = clientID;
            this.ClientSecret = clientSecret;
            this.Api = new ApiEndpoints(this);
        }
        public override string GetAuthorizeUrl(OAuth2ResponseType responseType)
        {
            return String.Format("https://api.dailymotion.com/oauth/authorize?response_type=code&client_id={0}&redirect_uri={1}"
                , this.ClientID, WebUtility.UrlEncode(this.RedirectUrl));
        }
        protected override HttpRequestCommand CreateGetAccessTokenCommand(string code)
        {
            var url = "https://api.dailymotion.com/oauth/token";
            var cm = new HttpRequestCommand(url);
            cm.MethodName = HttpMethodName.Post;
            var cv = new Base64Converter(256);
            cv.InsertNewline = false;
            var authValue = "basic " + cv.Encode(this.ClientID + ":" + this.ClientSecret, Encoding.UTF8);
            cm.Headers.Add("Authorization", authValue);
            var d = new Dictionary<String, String>();
            d["grant_type"] = "authorization_code";
            d["code"] = code;
            d["redirect_uri"] = this.RedirectUrl;
            var data = new HttpBodyFormUrlEncodedData(d);
            cm.SetBodyStream(data);

            return cm;
        }

        public TResult GetResult<T, TResult>(T command)
            where T : DailymotionCommand
        {
            if (this.AccessToken == null) throw new OAuthAuthenticateException("", "AccessToken does not set.");
            OAuth2Client cl = this;
            Dictionary<String, String> d = new Dictionary<string, string>();
            var url = command.GetApiEndpointUrl();
            var methodName = command.GetHttpMethodName();
            var cm = new HttpRequestCommand(url);
            cm.MethodName = methodName;

            if (command != null)
            {
                d =  command.Map(new Dictionary<String, String>());
                var keys = d.Where(el => String.IsNullOrEmpty(el.Value)).Select(el => el.Key).ToList();
                foreach (var key in keys)
                {
                    d.Remove(key);
                }
            }
            d["access_token"] = this.AccessToken.Value;
            cm.SetBodyStream(new HttpBodyFormUrlEncodedData(d));

            var res = cl.GetResponse(cm);
            if (res.StatusCode != HttpStatusCode.OK
                && res.StatusCode != HttpStatusCode.Created
                && res.StatusCode != HttpStatusCode.Accepted)
            {
                throw new HttpResponseException(res);
            }
            var json = res.BodyText;
            try
            {
                return JsonConvert.DeserializeObject<TResult>(json, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore });
            }
            catch (JsonReaderException)
            {
                throw new HttpResponseException(res);
            }
        }
    }
}
