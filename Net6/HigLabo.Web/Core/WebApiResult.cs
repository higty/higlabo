using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Converters;
using HigLabo.Core;
using System.Security.Cryptography;

namespace HigLabo.Web
{
    public class WebApiResult<T>
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public T Data { get; set; }
        public String Url { get; set; }
        public String Message { get; set; }
        public ValidationResultList ValidationResultList { get; private set; } = new ValidationResultList();
    }
    public class WebApiResult : WebApiResult<Object>
    {
    }
}
