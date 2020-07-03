using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpResponseException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpResponse HttpResponse { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get { return this.HttpResponse.StatusCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<String, String> Headers
        {
            get { return this.HttpResponse.Headers; }
        }
        /// <summary>
        /// 
        /// </summary>
        public String BodyText
        {
            get { return this.HttpResponse.BodyText; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpResponse"></param>
        public HttpResponseException(HttpResponse httpResponse)
        {
            this.HttpResponse = httpResponse;
        }
    }
}
