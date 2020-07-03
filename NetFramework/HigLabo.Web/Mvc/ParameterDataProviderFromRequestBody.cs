using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Specialized;
using HigLabo.Core;

namespace HigLabo.Web.Mvc
{
    public class ParameterDataProviderFromRequestBody : ParameterDataProvider
    {
        public override string Name
        {
            get { return "ParameterDataProviderFromRequestBody"; }
        }

        public override Dictionary<String, String> GetDataSource(HttpActionContext context)
        {
            var d = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);
            var req = context.Request;

            MediaTypeHeaderValue contentType = req.Content.Headers.ContentType;

            if (contentType == null) { return d; }
            if (req.Content.Headers.ContentLength == 0) { return d; }

            switch (contentType.MediaType.ToLower())
            {
                case "application/json":
                    {
                        var bodyText = req.Content.ReadAsStringAsync().Result.Trim();
                        if (bodyText.StartsWith("{"))
                        {
                            try
                            {
                                var values = JsonConvert.DeserializeObject<Dictionary<String, Object>>(bodyText);
                                d = values.Aggregate(d, (seed, current) =>
                                {
                                    if (current.Key != null && current.Value != null)
                                    {
                                        seed[current.Key] = current.Value.ToString();
                                    }
                                    return seed;
                                });
                            }
                            catch { }
                        }
                    }
                    break;
                case "application/x-www-form-urlencoded":
                    {
                        var dd = req.Content.ReadAsFormDataAsync().Result;
                        foreach (var key in dd.AllKeys)
                        {
                            d[key] = dd[key];
                        }
                    }
                    break;
                case "multipart/form-data":
                    {
                        var result = req.Content.ReadAsMultipartAsync().Result;
                        foreach (var content in result.Contents)
                        {
                            var name = content.Headers.ContentDisposition.Name;
                            d[name] = content.ReadAsStringAsync().Result;
                        }
                    }
                    break;
            }
            return d;
        }
    }
}
