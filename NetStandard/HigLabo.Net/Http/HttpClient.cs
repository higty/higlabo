using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
#if !NETFX_CORE && !Pcl
using System.Security.Cryptography.X509Certificates;
#endif

namespace HigLabo.Net
{
    /// <summary>
    /// HTTPでのリクエスト及びレスポンスデータの取得を行う機能を提供するクラスです。
    /// </summary>
    public partial class HttpClient
    {
        private static String UnreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
#if SILVERLIGHT || NETFX_CORE || Pcl
        internal static readonly Encoding DefaultEncoding = Encoding.UTF8;
#else
        internal static readonly Encoding DefaultEncoding = Encoding.GetEncoding("us-ascii");
        private X509CertificateCollection _ClientCertificates = new X509CertificateCollection();
#endif
        /// <summary>
        /// WEBサーバーへポストする際に必要なヘッダーの属性のキーを表す文字を取得します。
        /// </summary>
        public static readonly String ApplicationFormUrlEncoded = "application/x-www-form-urlencoded";
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<HttpWebRequestCreatedEventArgs> HttpWebRequestCreated;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<HttpRequestUploadingEventArgs> Uploading;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AsyncHttpCallErrorEventArgs> Error;
        /// <summary>
        /// 
        /// </summary>
        public Int32? RequestBufferSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ResponseEncodingDetectionMode ResponseEncodingDetectionMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? ResponseEncodingDetectionMaxLineNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Encoding ResponseEncoding { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CookieContainer CookieContainer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICredentials Credentials { get; set; }
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
        /// <summary>
        /// 
        /// </summary>
        public Boolean ResponseGZipDecompress { get; set; }
        /// <summary>
        /// 証明書情報
        /// </summary>
        public X509CertificateCollection ClientCertificates
        {
            get { return _ClientCertificates; }
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        public Action<Action> BeginInvoke { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HttpClient()
        {
            this.ResponseEncodingDetectionMode = Net.ResponseEncodingDetectionMode.Auto;
            this.ResponseEncodingDetectionMaxLineNumber = 50;
            this.ResponseEncoding = DefaultEncoding;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public HttpWebRequest CreateRequest(HttpRequestCommand command)
        {
            HttpWebRequest req = HttpWebRequest.Create(command.Url) as HttpWebRequest;
            if (req == null) { throw new ArgumentException("Url is invalid."); }

            var cm = command;

            if (this.CookieContainer != null)
            {
                req.CookieContainer = this.CookieContainer;
            }
            if (this.Credentials != null)
            {
                req.Credentials = this.Credentials;
            }
            req.Method = cm.MethodName.ToString().ToUpper();
            req.Accept = cm.Accept;
            req.ContentType = cm.ContentType;
            req.UseDefaultCredentials = cm.UseDefaultCredentials;
#if !SILVERLIGHT && !Pcl
            if (cm.Proxy != null)
            {
                req.Proxy = cm.Proxy;
            }
#endif
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
            if (cm.ContentLength > -1)
            {
                req.ContentLength = cm.ContentLength;
            }
            req.AllowAutoRedirect = cm.AllowAutoRedirect;
            req.AllowWriteStreamBuffering = cm.AllowWriteStreamBuffering;
            req.AutomaticDecompression = cm.AutomaticDecompression;
            req.Connection = cm.Connection;
            req.ConnectionGroupName = cm.ConnectionGroupName;
            req.ContinueDelegate = cm.ContinueDelegate;
            req.Expect = cm.Expect;
            req.IfModifiedSince = cm.IfModifiedSince;
            req.KeepAlive = cm.KeepAlive;
            req.MaximumAutomaticRedirections = cm.MaximumAutomaticRedirections;
            req.MaximumResponseHeadersLength = cm.MaximumResponseHeadersLength;
            req.MediaType = cm.MediaType;
            req.Pipelined = cm.Pipelined;
            req.PreAuthenticate = cm.PreAuthenticate;
            req.ProtocolVersion = cm.ProtocolVersion;
            req.ReadWriteTimeout = cm.ReadWriteTimeout;
            req.Referer = cm.Referer;
            req.SendChunked = cm.SendChunked;
            req.Timeout = cm.Timeout;
            req.TransferEncoding = cm.TransferEncoding;
            req.UnsafeAuthenticatedConnectionSharing = cm.UnsafeAuthenticatedConnectionSharing;
            req.UserAgent = cm.UserAgent;
            req.ClientCertificates.AddRange(this.ClientCertificates);
#endif
#if !_Net_3_5 && !SILVERLIGHT && !NETFX_CORE && !Pcl
            req.Date = cm.Date;
            if (String.IsNullOrEmpty(cm.Host) == false)
            {
                req.Host = cm.Host;
            }
#endif
            foreach (String key in cm.Headers.AllKeys)
            {
                req.Headers[key] = cm.Headers[key];
            }
            this.OnHttpWebRequestCreated(new HttpWebRequestCreatedEventArgs(req));
            return req;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static String CreateQueryString(String baseUrl, IDictionary<String, String> parameters)
        {
            return CreateQueryString(baseUrl, parameters, s => s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="parameters"></param>
        /// <param name="urlEncodingFunction"></param>
        /// <returns></returns>
        public static String CreateQueryString(String baseUrl, IDictionary<String, String> parameters, Func<String, String> urlEncodingFunction)
        {
            String result = CreateKeyEqualValueAndFormatString(parameters, urlEncodingFunction);
            if (String.IsNullOrEmpty(result))
            {
                return baseUrl;
            }
            return baseUrl + "?" + result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="urlEncodingFunction"></param>
        /// <returns></returns>
        public static String CreateKeyEqualValueAndFormatString(IDictionary<String, String> parameters, Func<String, String> urlEncodingFunction)
        {
            StringBuilder sb = new StringBuilder(256);
            Boolean first = true;
            foreach (var parameter in parameters)
            {
                if (first == true)
                {
                    first = false;
                }
                else
                {
                    sb.Append('&');
                }
                sb.Append(parameter.Key);
                sb.Append('=');
                sb.Append(urlEncodingFunction(parameter.Value));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UrlEncode(String value)
        {
            return UrlEncode(value, Encoding.UTF8);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string UrlEncode(String value, Encoding encode)
        {
            if (String.IsNullOrEmpty(value) == true) return value;
            StringBuilder result = new StringBuilder();
            byte[] data = encode.GetBytes(value);
            int len = data.Length;

            for (int i = 0; i < len; i++)
            {
                int c = data[i];
                if (c < 0x80 && UnreservedChars.IndexOf((char)c) != -1)
                {
                    result.Append((char)c);
                }
                else
                {
                    result.Append('%' + String.Format("{0:X2}", (int)data[i]));
                }
            }

            return result.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Boolean IsNullOrWhiteSpace(String value)
        {
            if (String.IsNullOrEmpty(value) == true) { return true; }
            if (value.Trim().Length == 0) { return true; }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void OnUploading(HttpRequestUploadingEventArgs e)
        {
            this.OnEventHandler(this.Uploading, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected void OnHttpWebRequestCreated(HttpWebRequestCreatedEventArgs e)
        {
            this.OnEventHandler(this.HttpWebRequestCreated, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="handler"></param>
        /// <param name="e"></param>
        protected void OnEventHandler<T>(EventHandler<T> handler, T e)
            where T : EventArgs
        {
            var eh = handler;
            if (eh != null)
            {
                if (this.BeginInvoke == null)
                {
                    eh(this, e);
                }
                else
                {
                    this.BeginInvoke(() => eh(this, e));
                }
            }
        }
    }
}
