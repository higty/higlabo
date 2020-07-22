using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
#if !NETFX_CORE && !Pcl
using System.Security.Cryptography.X509Certificates;
#endif
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
using System.Net.Cache;
#endif

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
    [Serializable]
#endif
    public class HttpRequestCommand
    {
        private WebHeaderCollection _Headers = new WebHeaderCollection();
        public WebHeaderCollection Headers
        {
            get { return _Headers; }
        }
        
        public String Url { get; set; }
        public HttpMethodName MethodName { get; set; }
        public Boolean IsSendBodyStream { get; set; }
        public Stream BodyStream { get; private set; }
        public Func<String, String> UrlEncodeFunction { get; set; }
        public string Accept { get; set; }
        public string ContentType { get; set; }
        public bool UseDefaultCredentials { get; set; }
#if !SILVERLIGHT && !Pcl
        public IWebProxy Proxy { get; set; }
#endif
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
        public bool AllowAutoRedirect { get; set; }
        public bool AllowReadStreamBuffering { get; set; }
        public bool AllowWriteStreamBuffering { get; set; }
        public DecompressionMethods AutomaticDecompression { get; set; }
        public X509CertificateCollection ClientCertificates { get; set; }
        public string Connection { get; set; }
        public string ConnectionGroupName { get; set; }
        public Int64 ContentLength { get; set; }
        public HttpContinueDelegate ContinueDelegate { get; set; }
        public DateTime Date { get; set; }
        public string Expect { get; set; }
        public string Host { get; set; }
        public DateTime IfModifiedSince { get; set; }
        public bool KeepAlive { get; set; }
        public int MaximumAutomaticRedirections { get; set; }
        public int MaximumResponseHeadersLength { get; set; }
        public string MediaType { get; set; }
        public bool Pipelined { get; set; }
        public bool PreAuthenticate { get; set; }
        public Version ProtocolVersion { get; set; }
        public int ReadWriteTimeout { get; set; }
        public string Referer { get; set; }
        public bool SendChunked { get; set; }
        public int Timeout { get; set; }
        public string TransferEncoding { get; set; }
        public bool UnsafeAuthenticatedConnectionSharing { get; set; }
        public string UserAgent { get; set; }
#endif

        public HttpRequestCommand(String url)
        {
            this.InitializeProperty();
            this.Url = url;
        }
        public HttpRequestCommand(String url, HttpMethodName methodName)
        {
            this.InitializeProperty();
            this.Url = url;
            this.MethodName = methodName;
        }
        public HttpRequestCommand(String url, Stream stream)
        {
            this.InitializeProperty();
            this.Url = url;
            this.MethodName = HttpMethodName.Post;
            this.BodyStream = stream;
        }
        public HttpRequestCommand(String url, HttpBodyFormUrlEncodedData data)
        {
            this.InitializeProperty();
            this.Url = url;
            this.MethodName = HttpMethodName.Post;
            this.ContentType = HttpClient.ApplicationFormUrlEncoded;
            this.BodyStream = new MemoryStream(this.CreateRequestBodyData(data.Encoding, data.Values));
        }
        public HttpRequestCommand(String url, Byte[] data)
        {
            this.InitializeProperty();
            this.Url = url;
            this.MethodName = HttpMethodName.Post;
            this.BodyStream = new MemoryStream(data);
        }
        private void InitializeProperty()
        {
            this.UrlEncodeFunction = HttpClient.UrlEncode;
            this.MethodName = HttpMethodName.Get;
            this.IsSendBodyStream = false;
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
            this.ClientCertificates = new X509CertificateCollection();
            this.ContentLength = -1;
            this.Pipelined = true;
            this.ProtocolVersion = new Version(1, 1);
            this.AutomaticDecompression = DecompressionMethods.None;
            this.MaximumAutomaticRedirections = 50;
            this.MaximumResponseHeadersLength = 64;
            this.AllowAutoRedirect = true;
            this.AllowReadStreamBuffering = false;
            this.AllowWriteStreamBuffering = true;
            this.ReadWriteTimeout = 300000;
            this.Timeout = 100000;
            this.KeepAlive = true;
#endif
        }
        public Byte[] CreateRequestBodyData(Encoding encoding, Dictionary<String, String> values)
        {
            StringBuilder sb = new StringBuilder(512);
            var d = values;
            if (d == null || d.Keys.Count == 0) { return new Byte[0]; }

            Boolean isFirst = true;
            foreach (var key in d.Keys)
            {
                if (isFirst == true)
                {
                    isFirst = false;
                }
                else
                {
                    sb.Append("&");
                }
                sb.AppendFormat("{0}={1}", this.UrlEncodeFunction(key), this.UrlEncodeFunction(d[key]));
            }
            return encoding.GetBytes(sb.ToString());
        }
        public void SetBodyStream(HttpBodyFormUrlEncodedData data)
        {
            if (String.IsNullOrEmpty(this.ContentType) == true)
            {
                this.ContentType = HttpClient.ApplicationFormUrlEncoded;
            }
            var bb = this.CreateRequestBodyData(data.Encoding, data.Values);
            this.BodyStream = new MemoryStream(bb);
            this.IsSendBodyStream = true;
        }
        public void SetBodyStream(Byte[] data)
        {
            this.BodyStream = new MemoryStream(data);
            this.IsSendBodyStream = true;
        }
        public void SetBodyStream(Stream stream)
        {
            this.BodyStream = stream;
            this.IsSendBodyStream = true;
        }
        public Int64 GetBodyLength()
        {
            if (this.ContentLength > 0) { return this.ContentLength; }
            try
            {
                if (this.BodyStream != null)
                {
                    return this.BodyStream.Length;
                }
            }
            catch { }
            return -1;
        }
    }
}
