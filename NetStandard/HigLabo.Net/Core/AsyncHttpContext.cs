using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace HigLabo.Net
{
#if !SILVERLIGHT && !NETFX_CORE && !Pcl
    [Serializable]
#endif
    public class AsyncHttpContext
    {
        public event EventHandler<HttpRequestUploadingEventArgs> Uploading;
        public event EventHandler<AsyncHttpCallErrorEventArgs> Error;
        private HttpRequestCommand _Command = null;
        private Action<HttpWebResponse> _Callback = null;
        public Int32? RequestBufferSize { get; set; }
        public Action<HttpWebResponse> Callback
        {
            get { return _Callback; }
            set { _Callback = value; }
        }
        public AsyncHttpContext(HttpRequestCommand command, Action<HttpWebResponse> callback)
        {
            _Command = command;
            _Callback = callback;
        }
        public AsyncHttpContext(HttpRequestCommand command, Int32 requestBufferSize, Action<HttpWebResponse> callback)
        {
            _Command = command;
            this.RequestBufferSize = requestBufferSize;
            _Callback = callback;
        }
        public void BeginRequest(HttpWebRequest request)
        {
            var cx = this;
            var req = request;
            Int64 length = 0;

            if (this._Command.BodyStream == null || this._Command.IsSendBodyStream == false)
            {
                req.BeginGetResponse(this.GetResponse, req);
            }
            else
            {
                var stream = _Command.BodyStream;
                if (stream != null)
                {
                    try
                    {
                        length = stream.Length;
                    }
                    catch (NotSupportedException)
                    { throw new NotSupportedException("This stream is not supported to read length property."); }
                }

                if (length == 0)
                {
                    req.BeginGetResponse(this.GetResponse, req);
                }
                else
                {
                    if (this.RequestBufferSize <= 0) { throw new InvalidOperationException("RequestBufferSize must be larger than zero."); }
                    req.BeginGetRequestStream(this.WriteRequestStream, req);
                }
            }
        }
        private void WriteRequestStream(IAsyncResult result)
        {
            var cx = this;
            Stream stm = null;
            StreamWriteContext scx = null;
            try
            {
                var req = result.AsyncState as HttpWebRequest;
                stm = req.EndGetRequestStream(result);
                scx = new StreamWriteContext(stm, this.RequestBufferSize);
                scx.Uploading += (o, e) => this.OnUploading(e);
                scx.Write(_Command.BodyStream);
                stm.Dispose();
                stm = null;
                req.BeginGetResponse(this.GetResponse, req);
            }
            catch (Exception ex)
            {
                this.OnError(ex);
            }
            finally
            {
                if (stm != null)
                {
                    stm.Dispose();
                }
            }
        }
        private void GetResponse(IAsyncResult result)
        {
            var cx = this;
            try
            {
                var req = result.AsyncState as HttpWebRequest;
                var res = req.EndGetResponse(result) as HttpWebResponse;
                this.OnCallback(res);
            }
            catch (Exception ex)
            {
                this.OnError(ex);
            }
        }
        protected void OnUploading(HttpRequestUploadingEventArgs e)
        {
            var eh = this.Uploading;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        protected void OnCallback(HttpWebResponse response)
        {
            var eh = this.Callback;
            if (eh != null)
            {
                eh(response);
            }
        }
        protected void OnError(Exception exception)
        {
            var eh = this.Error;
            if (eh != null)
            {
                eh(this, new AsyncHttpCallErrorEventArgs(this, exception));
            }
        }
    }
}
