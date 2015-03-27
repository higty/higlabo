using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HigLabo.Core;
using HigLabo.Converter;
using HigLabo.Net.Vimeo.Api_3_2;
using Newtonsoft.Json;

namespace HigLabo.Net.Vimeo
{
    public partial class VimeoClient : OAuth2Client
    {
        public ApiEndpoints Api { get; set; }

        public VimeoClient(String clientID, String clientSecret)
        {
            this.ClientID = clientID;
            this.ClientSecret = clientSecret;
            this.Api = new ApiEndpoints(this);
        }
        public override string GetAuthorizeUrl(OAuth2ResponseType responseType)
        {
            return String.Format("https://api.vimeo.com/oauth/authorize?response_type=code&client_id={0}&redirect_uri={1}"
                , this.ClientID, WebUtility.UrlEncode(this.RedirectUrl));
        }
        protected override HttpRequestCommand CreateGetAccessTokenCommand(string code)
        {
            var url = "https://api.vimeo.com/oauth/access_token";
            var cm = new HttpRequestCommand(url);
            cm.Accept = "application/vnd.vimeo.*+json;version=3.2";
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
            where T : VimeoCommand
        {
            if (this.AccessToken == null) throw new OAuthAuthenticateException("", "AccessToken does not set.");
            OAuth2Client cl = this;
            Dictionary<String, String> d = new Dictionary<string, string>();
            var url = "https://api.vimeo.com/" + command.GetApiEndpointUrl();
            var methodName = command.GetHttpMethodName();
         
            if (command != null)
            {
                d = command.Map(new Dictionary<String, String>());
                var keys = d.Where(el => String.IsNullOrEmpty(el.Value)).Select(el => el.Key).ToList();
                foreach (var key in keys)
                {
                    d.Remove(key);
                }
            }
            d["access_token"] = this.AccessToken.Value;

            if (methodName == HttpMethodName.Get)
            {
                var cv = new QueryStringConverter();
                url = String.Format("{0}?{1}", url, cv.Write(d));
            }
            var cm = new HttpRequestCommand(url);
            cm.Accept = "application/vnd.vimeo.*+json;version=3.2";
            cm.MethodName = methodName;
            if (methodName != HttpMethodName.Get)
            {
                cm.SetBodyStream(new HttpBodyFormUrlEncodedData(d));
            }

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
