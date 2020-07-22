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
    public partial class OAuth1Client
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <param name="callback"></param>
        public void GetResponse(HttpMethodName methodName, String url, String token, String tokenSecret, Action<HttpResponse> callback)
        {
            HttpClient cl = this;
            var cm = this.CreateHttpRequestCommand(methodName, url, token, tokenSecret, new Dictionary<String, String>());
            cl.GetResponse(cm, callback);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <param name="queryString"></param>
        /// <param name="callback"></param>
        public void GetResponse(HttpMethodName methodName, String url, String token, String tokenSecret
            , IDictionary<String, String> queryString, Action<HttpResponse> callback)
        {
            HttpClient cl = this;
            var cm = this.CreateHttpRequestCommand(methodName, url, token, tokenSecret, queryString);
            cl.GetResponse(cm, callback);
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
        /// <param name="callback"></param>
        public void GetResponse(HttpMethodName methodName, String url, String token, String tokenSecret
            , IDictionary<String, String> queryString, IDictionary<String, String> parameters, Action<HttpResponse> callback)
        {
            var cm = this.CreateHttpRequestCommand(methodName, url, token, tokenSecret, queryString);
            Dictionary<String, String> d = null;
            if (parameters != null)
            {
                d = new Dictionary<string, string>();
                cm.ContentType = HttpClient.ApplicationFormUrlEncoded;
                foreach (var p in parameters)
                {
                    d[p.Key] = cm.UrlEncodeFunction(p.Value);
                }
            }
            var data = new HttpBodyFormUrlEncodedData(Encoding.UTF8, d);
            cm.SetBodyStream(data);
            this.GetResponse(cm, callback);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <param name="bodyData"></param>
        /// <param name="callback"></param>
        public void GetResponse(HttpMethodName methodName, String url, String token, String tokenSecret
            , Byte[] bodyData, Action<HttpResponse> callback)
        {
            var cm = this.CreateHttpRequestCommand(methodName, url, token, tokenSecret, new Dictionary<String, String>());
            cm.SetBodyStream(bodyData);
            this.GetResponse(cm, callback);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        /// <param name="queryString"></param>
        /// <param name="callback"></param>
        public void GetHttpWebResponse(HttpMethodName methodName, String url, String token, String tokenSecret
            , IDictionary<String, String> queryString, Action<HttpWebResponse> callback)
        {
            this.GetHttpWebResponse(methodName, url, token, tokenSecret, queryString, null, callback);
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
        /// <param name="callback"></param>
        public void GetHttpWebResponse(HttpMethodName methodName, String url, String token, String tokenSecret
            , IDictionary<String, String> queryString, IDictionary<String, String> parameters, Action<HttpWebResponse> callback)
        {
            Dictionary<String, String> d = null;
            var cm = this.CreateHttpRequestCommand(methodName, url, token, tokenSecret, queryString);
            if (parameters != null)
            {
                d = new Dictionary<string, string>();
                cm.ContentType = HttpClient.ApplicationFormUrlEncoded;
                foreach (var p in parameters)
                {
                    d[p.Key] = cm.UrlEncodeFunction(p.Value);
                }
            }
            cm.SetBodyStream(new HttpBodyFormUrlEncodedData(Encoding.UTF8, d));
            this.GetHttpWebResponse(cm, callback);
        }
    }
}

