using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HigLabo.Web
{
    public static class HttpContextExtensions
    {
        public static HttpWorkerRequest GetHttpWorkerRequest(this HttpContext context)
        {
            return ((IServiceProvider)context).GetService(typeof(HttpWorkerRequest)) as HttpWorkerRequest;
        }
    }
}
