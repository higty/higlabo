using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
using System.IO.Compression;
#endif
using System.Text.RegularExpressions;
using HigLabo.Core;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpResponse
    {
        private class RegexList
        {
            public static readonly Regex Charset = new Regex("charset=[\"']{0,1}(?<Encoding>[a-zA-Z0-9-_]*)[\"']{0,1}", RegexOptions.IgnoreCase);
            public static readonly Regex Encoding = new Regex("encoding=[\"']{0,1}(?<Encoding>[a-zA-Z0-9-_]*)[\"']{0,1}", RegexOptions.IgnoreCase);
        }
        private Dictionary<String, String> _Headers = new Dictionary<String, String>();
        private Byte[] _BodyData = null;
        private String _BodyText = "";
        /// <summary>
        /// 
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String StatusDescription { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String ContentType { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Int64 ContentLength { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public CookieCollection Cookies { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String Method { get; private set; }
#if !SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        public String CharacterSet { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean IsMutuallyAuthenticated { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastModified { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Version ProtocolVersion { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Uri ResponseUri { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public String Server { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsFromCache { get; private set; }
#endif
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<String, String> Headers
        {
            get { return _Headers; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Byte[] BodyData
        {
            get { return _BodyData; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String BodyText
        {
            get { return _BodyText; }
        }

        public HttpResponse(HttpWebResponse response, Encoding encoding)
            : this(response, ResponseEncodingDetectionMode.Auto, 50, encoding, false)
        {
        }
        internal HttpResponse(HttpWebResponse response, HttpClient client)
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
            : this(response, client.ResponseEncodingDetectionMode, client.ResponseEncodingDetectionMaxLineNumber, client.ResponseEncoding, client.ResponseGZipDecompress)
#else
            : this(response, client.ResponseEncodingDetectionMode, client.ResponseEncodingDetectionMaxLineNumber, client.ResponseEncoding, false)
#endif
        {
        }
        internal HttpResponse(HttpWebResponse response, ResponseEncodingDetectionMode detectionMode, Int32? detectionMaxLineNumber
            , Encoding encoding, Boolean gzipDecompress)
        {
            var res = response;

            this.StatusCode = res.StatusCode;
            this.StatusDescription = res.StatusDescription;
            this.Method = res.Method;
            this.ContentType = res.ContentType;
            this.ContentLength = res.ContentLength;
            this.Cookies = res.Cookies;
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
            this.CharacterSet = res.CharacterSet;
            this.IsMutuallyAuthenticated = res.IsMutuallyAuthenticated;
            this.LastModified = res.LastModified;
            this.ProtocolVersion = res.ProtocolVersion;
            this.Server = res.Server;
            this.IsFromCache = res.IsFromCache;
#endif
            foreach (String key in res.Headers.AllKeys)
            {
                this.Headers[key] = res.Headers[key];
            }

            var bb = res.GetResponseStream().ToByteArray();
            if (detectionMode == ResponseEncodingDetectionMode.Auto)
            {
                encoding = this.ParseResponseEncoding(bb, detectionMaxLineNumber) ?? encoding;
            }

            var stm = new MemoryStream(bb);
            StreamReader sr = null;
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
            if (detectionMode == ResponseEncodingDetectionMode.Auto &&
                res.Headers["Content-Encoding"] == "gzip")
            {
                gzipDecompress = true;
            }
            if (gzipDecompress == true)
            {
                sr = new StreamReader(new GZipStream(stm, CompressionMode.Decompress), encoding);
            }
            else
            {
                sr = new StreamReader(stm, encoding);
            }
#else
            sr = new StreamReader(stm, encoding);
#endif
            _BodyText = sr.ReadToEnd();
            _BodyData = bb;
        }
        private Encoding ParseResponseEncoding(Byte[] bytes, Int32? maxLineNumber)
        {
            Int32 lineNumber = 0;
            StreamReader preReader = new StreamReader(new MemoryStream(bytes), Encoding.UTF8);

            while (preReader.Peek() > -1)
            {
                var line = preReader.ReadLine();
                lineNumber += 1;
                foreach (var rx in GetParseResponseEncodingRegexList())
                {
                    var m = rx.Match(line);
                    if (m.Success == true)
                    {
                        var encodingText = m.Groups["Encoding"].Value;
                        try
                        {
                            return Encoding.GetEncoding(encodingText);
                        }
                        catch { }
                    }
                }
                if (maxLineNumber.HasValue == true && lineNumber > maxLineNumber.Value) { break; }
            }
            return null;
        }
        private IEnumerable<Regex> GetParseResponseEncodingRegexList()
        {
            yield return RegexList.Charset;
            yield return RegexList.Encoding;
        }
    }
}
