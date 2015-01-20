using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HigLabo.Web.Mvc
{
    public class WadlController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var writer = new WadlXmlWriter();
            HttpResponseMessage response = Request.CreateResponse();
            response.Content = new StringContent(writer.Write(Configuration), UTF8Encoding.Unicode, "text/xml");

            return response;
        }
        /// <summary>
        /// Map WadlController.Get to "/Wadl"
        /// </summary>
        /// <param name="config"></param>
        public static void MapHttpRoute(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                      name: "Wadl",
                      routeTemplate: "Wadl",
                      defaults: new { controller = "Wadl", action = "Get" });
        }
    }
}
