using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace HigLabo.Net
{
    public partial class HttpClient
    {
#if SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatcher"></param>
        public void SetDispatcher(System.Windows.Threading.Dispatcher dispatcher)
        {
            this.BeginInvoke = action => dispatcher.BeginInvoke(action);
        }
#endif
        public void GetHttpWebResponse(String url, AsyncHttpContext context)
        {
            var req = this.CreateRequest(new HttpRequestCommand(url));
            context.BeginRequest(req);
        }
        public void GetHttpWebResponse(String url, Action<HttpWebResponse> callback)
        {
            this.GetHttpWebResponse(new HttpRequestCommand(url), callback);
        }
        public void GetHttpWebResponse(String url, HttpBodyFormUrlEncodedData data, Action<HttpWebResponse> callback)
        {
            this.GetHttpWebResponse(new HttpRequestCommand(url, data), callback);
        }
        public void GetHttpWebResponse(String url, Byte[] data, Action<HttpWebResponse> callback)
        {
            this.GetHttpWebResponse(new HttpRequestCommand(url, data), callback);
        }
        public void GetHttpWebResponse(String url, Stream stream, Action<HttpWebResponse> callback)
        {
            var cm = new HttpRequestCommand(url, stream);
            var req = this.CreateRequest(cm);
            AsyncHttpContext cx = new AsyncHttpContext(cm, this.AsyncHttpContextCallback(callback));
            if (this.RequestBufferSize.HasValue == true)
            {
                cx.RequestBufferSize = this.RequestBufferSize.Value;
            }
            cx.Uploading += (o, e) => this.OnUploading(e);
            cx.Error += (o, e) => this.OnError(e);
            cx.BeginRequest(req);
        }
        public void GetHttpWebResponse(HttpRequestCommand command, Action<HttpWebResponse> callback)
        {
            var req = this.CreateRequest(command);
            AsyncHttpContext cx = this.CreateAsyncHttpContext(command, callback);
            cx.Uploading += (o, e) => this.OnUploading(e);
            cx.Error += (o, e) => this.OnError(e);
            cx.BeginRequest(req);
        }
        public void GetHttpWebResponse(HttpRequestCommand command, Action<HttpWebResponse> callback, Action<AsyncHttpCallErrorEventArgs> errorCallback)
        {
            var req = this.CreateRequest(command);
            AsyncHttpContext cx = this.CreateAsyncHttpContext(command, callback);
            cx.Uploading += (o, e) => this.OnUploading(e);
            cx.Error += (o, e) => errorCallback(e);
            cx.BeginRequest(req);
        }
        protected AsyncHttpContext CreateAsyncHttpContext(HttpRequestCommand command, Action<HttpWebResponse> callback)
        {
            AsyncHttpContext cx = new AsyncHttpContext(command, this.AsyncHttpContextCallback(callback));
            if (this.RequestBufferSize.HasValue == true)
            {
                cx.RequestBufferSize = this.RequestBufferSize;
            }
            return cx;
        }
        private Action<T> AsyncHttpContextCallback<T>(Action<T> callback)
        {
            Action<T> f = res =>
            {
                var eh = callback;
                if (eh != null)
                {
                    if (this.BeginInvoke == null)
                    {
                        eh(res);
                    }
                    else
                    {
                        this.BeginInvoke(() => eh(res));
                    }
                }
            };
            return f;
        }
        public void GetResponse(String url, Action<HttpResponse> callback)
        {
            this.GetResponse(new HttpRequestCommand(url), callback);
        }
        public void GetResponse(String url, HttpBodyFormUrlEncodedData data, Action<HttpResponse> callback)
        {
            this.GetResponse(new HttpRequestCommand(url, data), callback);
        }
        public void GetResponse(String url, Byte[] data, Action<HttpResponse> callback)
        {
            this.GetHttpWebResponse(new HttpRequestCommand(url, data), res => this.GetResponseCallback(res, callback));
        }
        public void GetResponse(String url, Stream stream, Action<HttpResponse> callback)
        {
            this.GetHttpWebResponse(new HttpRequestCommand(url, stream), res => this.GetResponseCallback(res, callback));
        }
        public void GetResponse(HttpRequestCommand command, Action<HttpResponse> callback)
        {
            var req = this.CreateRequest(command);
            AsyncHttpContext cx = this.CreateAsyncHttpContext(command, res => this.GetResponseCallback(res, callback));
            cx.Uploading += (o, e) => this.OnUploading(e);
            cx.Error += (o, e) => this.GetResponseErrorCallback(e, callback);
            cx.BeginRequest(req);
        }
        protected void GetResponseCallback(HttpWebResponse response, Action<HttpResponse> callback)
        {
            var res = response;
            var hr = new HttpResponse(response, this);
            callback(hr);
        }
        private void GetResponseErrorCallback(AsyncHttpCallErrorEventArgs e, Action<HttpResponse> callback)
        {
            var ex = e.Exception as WebException;
            if (ex == null)
            {
                this.OnError(e);
                return;
            }
            var res = ex.Response as HttpWebResponse;
            if (res == null)
            {
                this.OnError(e);
                return;
            }
            this.GetResponseCallback(res, callback);
        }
        public void GetBodyText(String url, Action<String> callback)
        {
            this.GetBodyText(new HttpRequestCommand(url), callback);
        }
        public void GetBodyText(String url, HttpBodyFormUrlEncodedData data, Action<String> callback)
        {
            this.GetBodyText(new HttpRequestCommand(url, data), text => callback(text));
        }
        public void GetBodyText(String url, Byte[] data, Action<String> callback)
        {
            this.GetHttpWebResponse(new HttpRequestCommand(url, data), res => this.GetBodyTextCallback(res, callback));
        }
        public void GetBodyText(String url, Stream stream, Action<String> callback)
        {
            this.GetHttpWebResponse(new HttpRequestCommand(url, stream), res => this.GetBodyTextCallback(res, callback));
        }
        public void GetBodyText(HttpRequestCommand command, Action<String> callback)
        {
            this.GetHttpWebResponse(command, res => this.GetBodyTextCallback(res, callback));
        }
        private void GetBodyTextCallback(HttpWebResponse response, Action<String> callback)
        {
            this.GetBodyTextCallback(response, HttpClient.DefaultEncoding, callback);
        }
        private void GetBodyTextCallback(HttpWebResponse response, Encoding responseEncoding, Action<String> callback)
        {
            var res = response;
            StreamReader sr = new StreamReader(res.GetResponseStream(), responseEncoding);
            var text = sr.ReadToEnd();
            callback(text);
        }

        protected void OnError(AsyncHttpCallErrorEventArgs e)
        {
            var eh = this.Error;
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
