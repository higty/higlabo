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
    public class HttpContext<T> : HttpDefaultContext
        where T : HttpDefaultContext, new()
    {        
        public static new T Current
        {
            get
            {
                return GetContext<T>();
            }
        }
    }
}
