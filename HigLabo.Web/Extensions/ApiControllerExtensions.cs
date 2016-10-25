using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace HigLabo.Web.Mvc
{
    public static class ApiControllerExtensions
    {
        public static ApiJsonReslut<T> ApiJsonReslut<T>(this ApiController controller, HttpStatusCode statusCode, T data)
        {
            return new ApiJsonReslut<T>(controller.Request, statusCode, data);
        }
        public static JsonTextReslut JsonTextReslut(this ApiController controller, HttpStatusCode statusCode, String json)
        {
            return new JsonTextReslut(controller.Request, statusCode, json);
        }
    }
}