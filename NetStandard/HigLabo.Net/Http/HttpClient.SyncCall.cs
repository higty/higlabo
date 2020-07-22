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
        public HttpWebResponse GetHttpWebResponse(String url)
        {
            return this.GetHttpWebResponse(new HttpRequestCommand(url));
        }
        public HttpWebResponse GetHttpWebResponse(String url, HttpBodyFormUrlEncodedData data)
        {
            return this.GetHttpWebResponse(new HttpRequestCommand(url, data));
        }
        public HttpWebResponse GetHttpWebResponse(String url, Byte[] data)
        {
            return this.GetHttpWebResponse(new HttpRequestCommand(url, data));
        }
        public HttpWebResponse GetHttpWebResponse(String url, Stream stream)
        {
            return this.GetHttpWebResponse(new HttpRequestCommand(url, stream));
        }
        public HttpWebResponse GetHttpWebResponse(HttpRequestCommand command)
        {
            HttpWebRequest req = this.CreateRequest(command);
            StreamWriteContext scx = null;

            if (command.BodyStream != null && command.IsSendBodyStream == true)
            {
                //Request body
                //req.ContentLength = command.BodyStream.Length;
                if (command.GetBodyLength() > 0)
                {
                    using (var stm = req.GetRequestStream())
                    {
                        scx = new StreamWriteContext(stm, this.RequestBufferSize);
                        scx.Uploading += (o, e) => this.OnUploading(e);
                        scx.Write(command.BodyStream);
                        stm.Dispose();
                    }
                }
            }
            return req.GetResponse() as HttpWebResponse;
        }
        public HttpResponse GetResponse(String url)
        {
            return this.GetResponse(new HttpRequestCommand(url));
        }
        public HttpResponse GetResponse(String url, HttpBodyFormUrlEncodedData data)
        {
            return this.GetResponse(new HttpRequestCommand(url, data));
        }
        public HttpResponse GetResponse(String url, Byte[] data)
        {
            return this.GetResponse(new HttpRequestCommand(url, data));
        }
        public HttpResponse GetResponse(String url, Stream stream)
        {
            return this.GetResponse(new HttpRequestCommand(url, stream));
        }
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
        public String GetBodyText(String url)
        {
            return this.GetBodyText(new HttpRequestCommand(url));
        }
        public String GetBodyText(String url, HttpBodyFormUrlEncodedData data)
        {
            return this.GetBodyText(new HttpRequestCommand(url, data));
        }
        public String GetBodyText(String url, Byte[] data)
        {
            return this.GetBodyText(new HttpRequestCommand(url, data));
        }
        public String GetBodyText(String url, Stream stream)
        {
            return this.GetBodyText(new HttpRequestCommand(url, stream));
        }
        public String GetBodyText(HttpRequestCommand command)
        {
            var res = this.GetResponse(command);
            return res.BodyText;
        }
        public static CookieContainer GetCookieContainer(String url, String idKey, String id, String passwordKey, String password)
        {
            return GetCookieContainer(url, DefaultEncoding, idKey, id, passwordKey, password, new Dictionary<string, string>());
        }
        public static CookieContainer GetCookieContainer(String url, Encoding responseEncoding, String idKey, String id, String passwordKey, String password)
        {
            return GetCookieContainer(url, responseEncoding, idKey, id, passwordKey, password, new Dictionary<string, string>());
        }
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
