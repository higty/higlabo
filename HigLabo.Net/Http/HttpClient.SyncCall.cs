using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HttpClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HttpWebResponse GetHttpWebResponse(String url)
        {
            return this.GetHttpWebResponse(new HttpRequestCommand(url));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HttpWebResponse GetHttpWebResponse(String url, HttpBodyFormUrlEncodedData data)
        {
            return this.GetHttpWebResponse(new HttpRequestCommand(url, data));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HttpWebResponse GetHttpWebResponse(String url, Byte[] data)
        {
            return this.GetHttpWebResponse(new HttpRequestCommand(url, data));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public HttpWebResponse GetHttpWebResponse(String url, Stream stream)
        {
            return this.GetHttpWebResponse(new HttpRequestCommand(url, stream));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public HttpWebResponse GetHttpWebResponse(HttpRequestCommand command)
        {
            HttpWebRequest req = this.CreateRequest(command);
            StreamWriteContext scx = null;

            if (command.BodyStream != null && command.IsSendBodyStream == true)
            {
                //Request body
                //req.ContentLength = command.BodyStream.Length;
                if (command.BodyStream.Length > 0)
                {
                    using (var stm = req.GetRequestStream())
                    {
                        if (this.RequestBufferSize.HasValue == true)
                        {
                            scx = new StreamWriteContext(stm, this.RequestBufferSize.Value);
                        }
                        else
                        {
                            scx = new StreamWriteContext(stm);
                        }
                        scx.Uploading += (o, e) => this.OnUploading(e);
                        scx.Write(command.BodyStream);
                        stm.Dispose();
                    }
                }
            }
            return req.GetResponse() as HttpWebResponse;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HttpResponse GetResponse(String url)
        {
            return this.GetResponse(new HttpRequestCommand(url));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HttpResponse GetResponse(String url, HttpBodyFormUrlEncodedData data)
        {
            return this.GetResponse(new HttpRequestCommand(url, data));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HttpResponse GetResponse(String url, Byte[] data)
        {
            return this.GetResponse(new HttpRequestCommand(url, data));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public HttpResponse GetResponse(String url, Stream stream)
        {
            return this.GetResponse(new HttpRequestCommand(url, stream));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public HttpResponse GetResponse(HttpRequestCommand command)
        {
            HttpWebResponse res = null;
            HttpResponse hr = null;
            try
            {
                res = this.GetHttpWebResponse(command);
                hr = new HttpResponse(res, this);
            }
            catch (WebException ex)
            {
                res = ex.Response as HttpWebResponse;
                if (res != null)
                {
                    hr = new HttpResponse(res, this);
                }
                else
                {
                    throw;
                }
            }
            return hr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public String GetBodyText(String url)
        {
            return this.GetBodyText(new HttpRequestCommand(url));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public String GetBodyText(String url, HttpBodyFormUrlEncodedData data)
        {
            return this.GetBodyText(new HttpRequestCommand(url, data));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public String GetBodyText(String url, Byte[] data)
        {
            return this.GetBodyText(new HttpRequestCommand(url, data));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public String GetBodyText(String url, Stream stream)
        {
            return this.GetBodyText(new HttpRequestCommand(url, stream));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public String GetBodyText(HttpRequestCommand command)
        {
            var res = this.GetResponse(command);
            return res.BodyText;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="idKey"></param>
        /// <param name="id"></param>
        /// <param name="passwordKey"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static CookieContainer GetCookieContainer(String url, String idKey, String id, String passwordKey, String password)
        {
            return GetCookieContainer(url, DefaultEncoding, idKey, id, passwordKey, password, new Dictionary<string, string>());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="responseEncoding"></param>
        /// <param name="idKey"></param>
        /// <param name="id"></param>
        /// <param name="passwordKey"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static CookieContainer GetCookieContainer(String url, Encoding responseEncoding, String idKey, String id, String passwordKey, String password)
        {
            return GetCookieContainer(url, responseEncoding, idKey, id, passwordKey, password, new Dictionary<string, string>());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="responseEncoding"></param>
        /// <param name="idKey"></param>
        /// <param name="id"></param>
        /// <param name="passwordKey"></param>
        /// <param name="password"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static CookieContainer GetCookieContainer(String url, Encoding responseEncoding, String idKey, String id, String passwordKey, String password
            , Dictionary<String, String> values)
        {
            CookieContainer cc = new CookieContainer();
            HttpClient cl = new HttpClient();
            cl.ResponseEncoding = responseEncoding;
            cl.CookieContainer = cc;

            var cm = new HttpRequestCommand(url);
            cm.ContentType = HttpClient.ApplicationFormUrlEncoded;
            cm.MethodName = HttpMethodName.Post;
            var d = cm.Headers;
            d[idKey] = id;
            d[passwordKey] = password;
            foreach (var key in values.Keys)
            {
                d[key] = values[key];
            }
            var res = cl.GetResponse(cm);

            return cc;
        }
    } 
}
