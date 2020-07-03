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
        /// <summary>
        /// 
        /// </summary>
        public WebHeaderCollection Headers
        {
            get { return _Headers; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public String Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HttpMethodName MethodName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean IsSendBodyStream { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Stream BodyStream { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Func<String, String> UrlEncodeFunction { get; set; }
        // Summary:
        //     Gets or sets the value of the Accept HTTP header.
        //
        // Returns:
        //     The value of the Accept HTTP header. The default value is null.
        public string Accept { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Content-type HTTP header.
        //
        // Returns:
        //     The value of the Content-type HTTP header. The default value is null.
        public string ContentType { get; set; }
        //
        // Summary:
        //     Gets or sets a System.Boolean value that controls whether default credentials
        //     are sent with requests.
        //
        // Returns:
        //     true if the default credentials are used; otherwise false. The default value
        //     is false.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     You attempted to set this property after the request was sent.
        public bool UseDefaultCredentials { get; set; }
#if !SILVERLIGHT && !Pcl
        //
        // Summary:
        //     Gets or sets proxy information for the request.
        //
        // Returns:
        //     The System.Net.IWebProxy object to use to proxy the request. The default
        //     value is set by calling the System.Net.GlobalProxySelection.Select property.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     System.Net.HttpWebRequest.Proxy is set to null.
        //
        //   System.InvalidOperationException:
        //     The request has been started by calling System.Net.HttpWebRequest.GetRequestStream(),
        //     System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object),
        //     System.Net.HttpWebRequest.GetResponse(), or System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object).
        //
        //   System.Security.SecurityException:
        //     The caller does not have permission for the requested operation.
        public IWebProxy Proxy { get; set; }
#endif
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
        //
        // Summary:
        //     Gets or sets a value that indicates whether the request should follow redirection
        //     responses.
        //
        // Returns:
        //     true if the request should automatically follow redirection responses from
        //     the Internet resource; otherwise, false. The default value is true.
        public bool AllowAutoRedirect { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether to buffer the data sent to the
        //     Internet resource.
        //
        // Returns:
        //     true to enable buffering of the data sent to the Internet resource; false
        //     to disable buffering. The default is true.
        public bool AllowReadStreamBuffering { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether to buffer the data sent to the
        //     Internet resource.
        //
        // Returns:
        //     true to enable buffering of the data sent to the Internet resource; false
        //     to disable buffering. The default is true.
        public bool AllowWriteStreamBuffering { get; set; }
        //
        // Summary:
        //     Gets or sets the type of decompression that is used.
        //
        // Returns:
        //     A T:System.Net.DecompressionMethods object that indicates the type of decompression
        //     that is used.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The object's current state does not allow this property to be set.
        public DecompressionMethods AutomaticDecompression { get; set; }
        //
        // Summary:
        //     Gets or sets the collection of security certificates that are associated
        //     with this request.
        //
        // Returns:
        //     The System.Security.Cryptography.X509Certificates.X509CertificateCollection
        //     that contains the security certificates associated with this request.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The value specified for a set operation is null.
        public X509CertificateCollection ClientCertificates { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Connection HTTP header.
        //
        // Returns:
        //     The value of the Connection HTTP header. The default value is null.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The value of System.Net.HttpWebRequest.Connection is set to Keep-alive or
        //     Close.
        public string Connection { get; set; }
        //
        // Summary:
        //     Gets or sets the name of the connection group for the request.
        //
        // Returns:
        //     The name of the connection group for this request. The default value is null.
        public string ConnectionGroupName { get; set; }
        //
        // Summary:
        //     Gets or sets the Content-length HTTP header.
        //
        // Returns:
        //     The number of bytes of data to send to the Internet resource. The default
        //     is -1, which indicates the property has not been set and that there is no
        //     request data to send.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The request has been started by calling the System.Net.HttpWebRequest.GetRequestStream(),
        //     System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object),
        //     System.Net.HttpWebRequest.GetResponse(), or System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)
        //     method.
        //
        //   System.ArgumentOutOfRangeException:
        //     The new System.Net.HttpWebRequest.ContentLength value is less than 0.
        public Int64 ContentLength { get; set; }
        //
        // Summary:
        //     Gets or sets the delegate method called when an HTTP 100-continue response
        //     is received from the Internet resource.
        //
        // Returns:
        //     A delegate that implements the callback method that executes when an HTTP
        //     Continue response is returned from the Internet resource. The default value
        //     is null.
        public HttpContinueDelegate ContinueDelegate { get; set; }
        //
        // Summary:
        //     Get or set the Date HTTP header value to use in an HTTP request.
        //
        // Returns:
        //     The Date header value in the HTTP request.
        public DateTime Date { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Expect HTTP header.
        //
        // Returns:
        //     The contents of the Expect HTTP header. The default value is null.NoteThe
        //     value for this property is stored in System.Net.WebHeaderCollection. If WebHeaderCollection
        //     is set, the property value is lost.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     Expect is set to a string that contains "100-continue" as a substring.
        public string Expect { get; set; }
        //
        // Summary:
        //     Get or set the Host header value to use in an HTTP request independent from
        //     the request URI.
        //
        // Returns:
        //     The Host header value in the HTTP request.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     The Host header cannot be set to null.
        //
        //   System.ArgumentException:
        //     The Host header cannot be set to an invalid value.
        //
        //   System.InvalidOperationException:
        //     The Host header cannot be set after the System.Net.HttpWebRequest has already
        //     started to be sent.
        public string Host { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the If-Modified-Since HTTP header.
        //
        // Returns:
        //     A System.DateTime that contains the contents of the If-Modified-Since HTTP
        //     header. The default value is the current date and time.
        public DateTime IfModifiedSince { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether to make a persistent connection
        //     to the Internet resource.
        //
        // Returns:
        //     true if the request to the Internet resource should contain a Connection
        //     HTTP header with the value Keep-alive; otherwise, false. The default is true.
        public bool KeepAlive { get; set; }
        //
        // Summary:
        //     Gets or sets the maximum number of redirects that the request follows.
        //
        // Returns:
        //     The maximum number of redirection responses that the request follows. The
        //     default value is 50.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The value is set to 0 or less.
        public int MaximumAutomaticRedirections { get; set; }
        //
        // Summary:
        //     Gets or sets the maximum allowed length of the response headers.
        //
        // Returns:
        //     The length, in kilobytes (1024 bytes), of the response headers.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The property is set after the request has already been submitted.
        //
        //   System.ArgumentOutOfRangeException:
        //     The value is less than 0 and is not equal to -1.
        public int MaximumResponseHeadersLength { get; set; }
        //
        // Summary:
        //     Gets or sets the media type of the request.
        //
        // Returns:
        //     The media type of the request. The default value is null.
        public string MediaType { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether to pipeline the request to the
        //     Internet resource.
        //
        // Returns:
        //     true if the request should be pipelined; otherwise, false. The default is
        //     true.
        public bool Pipelined { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether to send an Authorization header
        //     with the request.
        //
        // Returns:
        //     true to send an HTTP Authorization header with requests after authentication
        //     has taken place; otherwise, false. The default is false.
        public bool PreAuthenticate { get; set; }
        //
        // Summary:
        //     Gets or sets the version of HTTP to use for the request.
        //
        // Returns:
        //     The HTTP version to use for the request. The default is System.Net.HttpVersion.Version11.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The HTTP version is set to a value other than 1.0 or 1.1.
        public Version ProtocolVersion { get; set; }
        //
        // Summary:
        //     Gets or sets a time-out in milliseconds when writing to or reading from a
        //     stream.
        //
        // Returns:
        //     The number of milliseconds before the writing or reading times out. The default
        //     value is 300,000 milliseconds (5 minutes).
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The request has already been sent.
        //
        //   System.ArgumentOutOfRangeException:
        //     The value specified for a set operation is less than or equal to zero and
        //     is not equal to System.Threading.Timeout.Infinite
        public int ReadWriteTimeout { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Referer HTTP header.
        //
        // Returns:
        //     The value of the Referer HTTP header. The default value is null.
        public string Referer { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether to send data in segments to the
        //     Internet resource.
        //
        // Returns:
        //     true to send data to the Internet resource in segments; otherwise, false.
        //     The default value is false.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     The request has been started by calling the System.Net.HttpWebRequest.GetRequestStream(),
        //     System.Net.HttpWebRequest.BeginGetRequestStream(System.AsyncCallback,System.Object),
        //     System.Net.HttpWebRequest.GetResponse(), or System.Net.HttpWebRequest.BeginGetResponse(System.AsyncCallback,System.Object)
        //     method.
        public bool SendChunked { get; set; }
        //
        // Summary:
        //     Gets or sets the time-out value in milliseconds for the System.Net.HttpWebRequest.GetResponse()
        //     and System.Net.HttpWebRequest.GetRequestStream() methods.
        //
        // Returns:
        //     The number of milliseconds to wait before the request times out. The default
        //     value is 100,000 milliseconds (100 seconds).
        //
        // Exceptions:
        //   System.ArgumentOutOfRangeException:
        //     The value specified is less than zero and is not System.Threading.Timeout.Infinite.
        public int Timeout { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the Transfer-encoding HTTP header.
        //
        // Returns:
        //     The value of the Transfer-encoding HTTP header. The default value is null.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     System.Net.HttpWebRequest.TransferEncoding is set when System.Net.HttpWebRequest.SendChunked
        //     is false.
        //
        //   System.ArgumentException:
        //     System.Net.HttpWebRequest.TransferEncoding is set to the value "Chunked".
        public string TransferEncoding { get; set; }
        //
        // Summary:
        //     Gets or sets a value that indicates whether to allow high-speed NTLM-authenticated
        //     connection sharing.
        //
        // Returns:
        //     true to keep the authenticated connection open; otherwise, false.
        public bool UnsafeAuthenticatedConnectionSharing { get; set; }
        //
        // Summary:
        //     Gets or sets the value of the User-agent HTTP header.
        //
        // Returns:
        //     The value of the User-agent HTTP header. The default value is null.NoteThe
        //     value for this property is stored in System.Net.WebHeaderCollection. If WebHeaderCollection
        //     is set, the property value is lost.
        public string UserAgent { get; set; }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public HttpRequestCommand(String url)
        {
            this.InitializeProperty();
            this.Url = url;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="methodName"></param>
        public HttpRequestCommand(String url, HttpMethodName methodName)
        {
            this.InitializeProperty();
            this.Url = url;
            this.MethodName = methodName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        public HttpRequestCommand(String url, Stream stream)
        {
            this.InitializeProperty();
            this.Url = url;
            this.MethodName = HttpMethodName.Post;
            this.BodyStream = stream;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        public HttpRequestCommand(String url, HttpBodyFormUrlEncodedData data)
        {
            this.InitializeProperty();
            this.Url = url;
            this.MethodName = HttpMethodName.Post;
            this.ContentType = HttpClient.ApplicationFormUrlEncoded;
            this.BodyStream = new MemoryStream(this.CreateRequestBodyData(data.Encoding, data.Values));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="values"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void SetBodyStream(Byte[] data)
        {
            this.BodyStream = new MemoryStream(data);
            this.IsSendBodyStream = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        public void SetBodyStream(Stream stream)
        {
            this.BodyStream = stream;
            this.IsSendBodyStream = true;
        }
    }
}
