using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HigLabo.Web
{
    public static class HttpResponseExtensions
    {
        public static void EnableLengthProperty(this HttpResponse response)
        {
            response.Filter = new HttpResponseStream(response.Filter);
        }
    }
}
