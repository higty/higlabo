using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace HigLabo.Net
{
    public partial class OAuth1Client
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorizeInfo"></param>
        /// <param name="oauthVerifier"></param>
        public void Authenticate(OAuth1AuthorizeInfo authorizeInfo, String oauthVerifier)
        {
            this.AccessToken = this.GetAccessToken(authorizeInfo, oauthVerifier);
            if (this.AccessToken.State == OAuthAccessTokenState.Error)
            {
                throw new OAuthAuthenticateException(this.AccessToken.RawValue, "Failure to get AccessToken by OAuth1.0.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OAuth1AuthorizeInfo GetAuthorizeInfo()
        {
            String url = this.RequestTokenUrl;
            var cm = new GetRequestTokenCommand(this.ConsumerKey, this.ConsumerSecret, "", "", HttpMethodName.Post);
            SignatureInfo si = OAuth1Client.GenerateSignature(new Uri(url), cm, OAuthSignatureTypes.HMACSHA1);
            HttpRequestCommand command = this.CreateHttpRequestCommand(HttpMethodName.Post, url, "", "");
            String bodyText = this.GetBodyText(command);
            //正規表現でoauth_token,oauth_token_secret取得
            return OAuth1AuthorizeInfo.Create(this.AuthorizeUrl, bodyText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestToken"></param>
        /// <param name="requestTokenSecret"></param>
        /// <returns></returns>
        public OAuth1AccessToken GetAccessToken(String requestToken, String requestTokenSecret)
        {
            String url = this.AccessTokenUrl;
            GetRequestTokenCommand cm = new GetRequestTokenCommand(this.ConsumerKey, this.ConsumerSecret
                , requestToken, requestTokenSecret, HttpMethodName.Post);
            SignatureInfo si = OAuth1Client.GenerateSignature(new Uri(url), cm, OAuthSignatureTypes.HMACSHA1);
            HttpRequestCommand command =
                new HttpRequestCommand(String.Format("{0}?{1}&oauth_signature={2}", url, si.NormalizedRequestParameters, si.Signature), HttpMethodName.Post);
            var res = this.GetResponse(command);
            return OAuth1AccessToken.Create(res.BodyText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorizeInfo"></param>
        /// <param name="oauthVerifier"></param>
        /// <returns></returns>
        public OAuth1AccessToken GetAccessToken(OAuth1AuthorizeInfo authorizeInfo, String oauthVerifier)
        {
            var ai = authorizeInfo;
            var cm = new GetRequestTokenCommand(this.ConsumerKey, this.ConsumerSecret
                , ai.RequestToken, ai.RequestTokenSecret, HttpMethodName.Post);
            var si = OAuth1Client.GenerateSignature(new Uri(this.AccessTokenUrl), cm, OAuthSignatureTypes.HMACSHA1);
            HttpRequestCommand command = new HttpRequestCommand(String.Format("{0}?{1}&oauth_verifier={2}&oauth_signature={3}"
                    , this.AccessTokenUrl, si.NormalizedRequestParameters, oauthVerifier, si.Signature), HttpMethodName.Post);
            var res = this.GetResponse(command);
            return OAuth1AccessToken.Create(res.BodyText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <returns></returns>
        public HttpResponse GetResponse(HttpMethodName methodName, String url, String token, String tokenSecret)
        {
            return this.GetResponse(methodName, url, token, tokenSecret, new Dictionary<String, String>());
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
        public HttpResponse GetResponse(HttpMethodName methodName, String url, String token, String tokenSecret
            , IDictionary<String, String> queryString)
        {
            var cm = this.CreateHttpRequestCommand(methodName, url, token, tokenSecret, queryString);
            return this.GetResponse(cm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <param name="bodyData"></param>
        /// <returns></returns>
        public HttpResponse GetResponse(HttpMethodName methodName, String url, String token, String tokenSecret
            , Byte[] bodyData)
        {
            var cm = this.CreateHttpRequestCommand(methodName, url, token, tokenSecret, new Dictionary<String, String>());
            cm.SetBodyStream(bodyData);
            return this.GetResponse(cm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <returns></returns>
        public HttpWebResponse GetHttpWebResponse(HttpMethodName methodName, String url, String token, String tokenSecret)
        {
            return this.GetHttpWebResponse(methodName, url, token, tokenSecret, new Dictionary<String, String>(), new Dictionary<String, String>());
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
        public HttpWebResponse GetHttpWebResponse(HttpMethodName methodName, String url, String token, String tokenSecret
            , IDictionary<String, String> queryString)
        {
            return this.GetHttpWebResponse(methodName, url, token, tokenSecret, queryString, new Dictionary<String, String>());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <param name="queryString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public HttpWebResponse GetHttpWebResponse(HttpMethodName methodName, String url, String token, String tokenSecret
            , IDictionary<String, String> queryString, IDictionary<String, String> parameters)
        {
            HttpBodyFormUrlEncodedData data = new HttpBodyFormUrlEncodedData();
            var d = data.Values;
            var cm = this.CreateHttpRequestCommand(methodName, url, token, tokenSecret, queryString);
            foreach (var p in parameters)
            {
                d[p.Key] = cm.UrlEncodeFunction(p.Value);
            }
            cm.SetBodyStream(data);
            return this.GetHttpWebResponse(cm);
        }
    }
}
