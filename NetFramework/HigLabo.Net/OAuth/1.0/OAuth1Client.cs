using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace HigLabo.Net
{
    /// <summary>
    /// OAuth認証のクライアント機能を提供するクラスです。
    /// </summary>
    public partial class OAuth1Client : HttpClient
    {
        /// <summary>
        /// 
        /// </summary>
        public OAuthMode Mode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ConsumerKey { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String ConsumerSecret { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String RequestTokenUrl { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String AuthorizeUrl { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String AccessTokenUrl { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public OAuth1AccessToken AccessToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumerKey"></param>
        /// <param name="consumerSecret"></param>
        /// <param name="requestTokenUrl"></param>
        /// <param name="authorizeUrl"></param>
        /// <param name="accessTokenUrl"></param>
        public OAuth1Client(String consumerKey, String consumerSecret, String requestTokenUrl, String authorizeUrl, String accessTokenUrl)
        {
            this.Mode = OAuthMode.Header;
            this.ResponseEncoding = Encoding.UTF8;
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            RequestTokenUrl = requestTokenUrl;
            AuthorizeUrl = authorizeUrl;
            AccessTokenUrl = accessTokenUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <returns></returns>
        public HttpRequestCommand CreateHttpRequestCommand(HttpMethodName methodName, String url, String token, String tokenSecret)
        {
            return this.CreateHttpRequestCommand(methodName, url, token, tokenSecret, new Dictionary<String, String>());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public HttpRequestCommand CreateHttpRequestCommand(HttpMethodName methodName, String url, String token, String tokenSecret, IDictionary<String, String> queryString)
        {
            HttpRequestCommand cm = null;
            switch (this.Mode)
            {
                case OAuthMode.QueryString: cm = this.CreateHttpClientQueryStringMode(methodName, url, token, tokenSecret, queryString); break;
                case OAuthMode.Header: cm = this.CreateHttpClientRequestHeaderMode(methodName, url, token, tokenSecret, queryString); break;
                default: throw new InvalidOperationException();
            }
            return cm;
        }
        private HttpRequestCommand CreateHttpClientQueryStringMode(HttpMethodName methodName, String url, String token, String tokenSecret, IDictionary<String, String> queryString)
        {
            var cm = new GetRequestTokenCommand(this.ConsumerKey, this.ConsumerSecret, token, tokenSecret, methodName);
            Dictionary<String, String> pp = OAuth1Client.GenerateParameters(cm);
            foreach (var p in queryString)
            {
                pp.Add(p.Key, p.Value);
            }
            var u = new Uri(HttpClient.CreateQueryString(url, pp, OAuth1Client.UrlEncode));
            SignatureInfo si = OAuth1Client.GenerateSignature(u, cm);
            pp.Add("oauth_signature", OAuth1Client.UrlEncode(si.Signature));
            HttpRequestCommand cl = new HttpRequestCommand(HttpClient.CreateQueryString(url, pp, HttpClient.UrlEncode));
            cl.MethodName = methodName;
            return cl;
        }
        private HttpRequestCommand CreateHttpClientRequestHeaderMode(HttpMethodName methodName, String url, String token, String tokenSecret, IDictionary<String, String> queryString)
        {
            var cm = new GetRequestTokenCommand(this.ConsumerKey, this.ConsumerSecret, token, tokenSecret, methodName);
            Dictionary<String, String> pp = OAuth1Client.GenerateParameters(cm);
            var u = new Uri(HttpClient.CreateQueryString(url, queryString, OAuth1Client.UrlEncode));
            SignatureInfo si = OAuth1Client.GenerateSignature(u, cm);
            pp.Add("oauth_signature", OAuth1Client.UrlEncode(si.Signature));
            HttpRequestCommand cl = new HttpRequestCommand(HttpClient.CreateQueryString(url, queryString, HttpClient.UrlEncode));
            cl.MethodName = methodName;
            cl.Headers[HttpRequestHeader.Authorization] = this.CreateOAuthHeader(pp);
            return cl;
        }
        private String CreateOAuthHeader(IDictionary<String, String> parameters)
        {
            StringBuilder sb = new StringBuilder(512);

            sb.Append("OAuth ");
            foreach (var key in parameters.Keys)
            {
                sb.AppendFormat("{0}=\"{1}\",", key, parameters[key]);
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static Dictionary<String, String> GenerateParameters(GetRequestTokenCommand command)
        {
            var cm = command;
            Dictionary<String, String> result = new Dictionary<String, String>();
            result.Add("oauth_consumer_key", cm.ConsumerKey);
            result.Add("oauth_signature_method", "HMAC-SHA1");
            result.Add("oauth_timestamp", cm.TimeStamp);
            result.Add("oauth_nonce", cm.Nonce);
            result.Add("oauth_version", "1.0");
            if (String.IsNullOrEmpty(cm.Token) == false)
            { result.Add("oauth_token", cm.Token); }
            return result;
        }
    }
}

