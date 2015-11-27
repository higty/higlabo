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
            var d = new Dictionary<String, String>();
            var req = context.Request;

            MediaTypeHeaderValue contentType = req.Content.Headers.ContentType;

            if (contentType == null) { return d; }
            if (req.Content.Headers.ContentLength == 0) { return d; }

            switch (contentType.MediaType.ToLower())
            {
                case "application/json":
                    {
                        var bodyText = req.Content.ReadAsStringAsync().Result;
                        var values = JsonConvert.DeserializeObject<Dictionary<String, String>>(bodyText);
                        d = values.Aggregate(new Dictionary<String, String>(), (seed, current) =>
                        {
                            seed[current.Key] = current.Value;
                            return seed;
                        });
                    }
                    break;
                case "application/x-www-form-urlencoded":
                    {
                        var dd = req.Content.ReadAsFormDataAsync().Result;
                        foreach (var key in dd.AllKeys)
                        {
                            if (d.ContainsKey(key) == false)
                            {
                                d[key] = dd[key];
                            }
                        }
                    }
                    break;
                case "multipart/form-data":
                    {
                        var result = req.Content.ReadAsMultipartAsync().Result;
                        foreach (var content in result.Contents)
                        {
                            foreach (var header in content.Headers.Where(el => el.Value.Any())
                                .ToDictionary(el => el.Key, el => el.Value.FirstOrDefault()))
                            {
                                d[header.Key] = header.Value;
                            }
                        }
                    }
                    break;
            }
            return d;
        }
    }
}
