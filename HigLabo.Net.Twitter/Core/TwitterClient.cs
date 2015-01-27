using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Net.Twitter.Api_1_1;
using HigLabo.Core;
using System.Net;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter
{
    public partial class TwitterClient : OAuth1Client
    {
        public ApiEndpoints Api { get; set; }
        
        public TwitterClient(String consumerKey, String consumerSecret)
            : base(consumerKey, consumerSecret
            , "https://api.twitter.com/oauth/request_token"
            , "https://api.twitter.com/oauth/authorize"
            , "https://api.twitter.com/oauth/access_token")
        {
            this.Api = new ApiEndpoints(this);
        }

        public TResult GetResult<T, TResult>(T command)
            where T : TwitterCommand
        {
            if (this.AccessToken == null) throw new OAuthAuthenticateException("", "AccessToken does not set.");
            OAuth1Client cl = this;
            IDictionary<String, String> d = new Dictionary<string, string>();
            var methodName = command.GetHttpMethodName();
            var url = command.GetApiEndpointUrl();

            if (methodName == HttpMethodName.Put ||
                methodName == HttpMethodName.Delete)
            { throw new ArgumentException(); }

            if (command != null)
            {
                d =  command.Map(new Dictionary<String, String>());
                var keys = d.Where(el => String.IsNullOrEmpty(el.Value)).Select(el => el.Key).ToList();
                foreach (var key in keys)
                {
                    d.Remove(key);
                }
            }
            var res = cl.GetResponse(methodName, url, this.AccessToken.Token, this.AccessToken.TokenSecret, d);
            if (res.StatusCode != HttpStatusCode.OK
                && res.StatusCode != HttpStatusCode.Created
                && res.StatusCode != HttpStatusCode.Accepted)
            {
                throw new HttpResponseException(res);
            }
            var json = res.BodyText;
            return JsonConvert.DeserializeObject<TResult>(json);
        }
    }
}
