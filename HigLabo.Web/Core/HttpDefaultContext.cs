using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HigLabo.Web
{
    public class HttpDefaultContext 
    {
        protected static String HttpContextItemsKey = "HttpDefaultContext.Key";

        private String _RequestHeaderText = "";
        private String _RequestBodyText = "";
        private Boolean _RequestHeaderLoaded = false;
        private Boolean _RequestBodyLoaded = false;
        private Boolean _ControllerInfoLoaded = false;
        private String _ControllerName = "";
        private String _ActionName = "";
        private HttpWorkerRequest _HttpWorkerRequest = null;
        private Dictionary<String, Object> _Data = new Dictionary<string, object>();

        public static HttpDefaultContext Current
        {
            get
            {
                return GetContext<HttpDefaultContext>();
            }
        }
        public HttpRequest Request
        {
            get
            {
                CheckHttpContextAvailable();
                return HttpContext.Current.Request;
            }
        }
        public HttpWorkerRequest HttpWorkerRequest
        {
            get
            {
                CheckHttpContextAvailable();
                if (_HttpWorkerRequest == null)
                {
                    _HttpWorkerRequest = HttpContext.Current.GetHttpWorkerRequest();
                }
                return _HttpWorkerRequest;
            }
        }
        public HttpResponse Response
        {
            get
            {
                CheckHttpContextAvailable();
                return HttpContext.Current.Response;
            }
        }
        public HttpServerUtility Server
        {
            get
            {
                CheckHttpContextAvailable();
                return HttpContext.Current.Server;
            }
        }
        public Cookie Cookie { get; private set; }
        public String ControllerName
        {
            get
            {
                this.EnsureMvcControllerInfo();
                return _ControllerName;
            }
        }
        public String ActionName
        {
            get
            {
                this.EnsureMvcControllerInfo();
                return _ActionName;
            }
        }
        public Dictionary<String, Object> Data
        {
            get { return _Data; }
        }
        internal List<String> JavaScriptUrls { get; private set; }
        internal List<String> StyleSheetUrls { get; private set; }

        public HttpDefaultContext()
        {
            this.Cookie = new Cookie();
            this.JavaScriptUrls = new List<string>();
            this.StyleSheetUrls = new List<string>();
        }
        protected static T GetContext<T>()
            where T : HttpDefaultContext, new()
        {
            CheckHttpContextAvailable();
            if (HttpContext.Current.Items[HttpContextItemsKey] == null)
            {
                HttpContext.Current.Items[HttpContextItemsKey] = new KeyedByTypeCollection<HttpDefaultContext>();
            }
            var d = HttpContext.Current.Items[HttpContextItemsKey] as KeyedByTypeCollection<HttpDefaultContext>;
            var tp = typeof(T);
            if (d.Contains(tp) == false)
            {
                d.Add(new T());
            }
            return d[tp] as T;
        }
        public String GetRequestHeaderText()
        {
            if (_RequestHeaderLoaded == false)
            {
                _RequestHeaderLoaded = true;
                StringBuilder sb = new StringBuilder(512 + this.Request.ContentLength);

                for (int i = 0; i < this.Request.Headers.Keys.Count; i++)
                {
                    sb.AppendFormat("{0}: {1}", this.Request.Headers.Keys[i], this.Request.Headers[i]);
                    sb.AppendLine();
                }
                _RequestHeaderText = sb.ToString();
            }
            return _RequestHeaderText;
        }
        public String GetRequestBodyText()
        {
            if (_RequestBodyLoaded == false)
            {
                _RequestBodyLoaded = true;

                Byte[] bb = new Byte[this.Request.ContentLength];
                this.Request.InputStream.Read(bb, 0, bb.Length);
                //データを読み取った後、ポジションを元に戻す
                this.Request.InputStream.Position = 0;
                _RequestBodyText = Encoding.UTF8.GetString(bb);
            }
            return _RequestBodyText;
        }
        internal static void CheckHttpContextAvailable()
        {
            if (HttpContext.Current == null) { throw new InvalidOperationException("HttpContext unavailable"); }
        }
        private void EnsureMvcControllerInfo()
        {
            if (_ControllerInfoLoaded == true) { return; }
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current));
            if (routeData != null)
            {
                if (routeData.Values["controller"] != null && !String.IsNullOrEmpty(routeData.Values["controller"].ToString()))
                {
                    _ControllerName = routeData.Values["controller"].ToString();
                }
                if (routeData.Values["action"] != null && !String.IsNullOrEmpty(routeData.Values["action"].ToString()))
                {
                    _ActionName = routeData.Values["action"].ToString();
                }
                _ControllerInfoLoaded = true;
            }
        }
    }
}
