using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace HigLabo.Web.Mvc
{
    public class ParameterDataProviderFromQueryString : ParameterDataProvider
    {
        public override string Name
        {
            get { return "ParameterDataProviderFromQueryString"; }
        }
        public override Dictionary<string, string> GetDataSource(HttpActionContext context)
        {
            var d = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);
            foreach (var item in context.Request.GetQueryNameValuePairs())
            {
                d[item.Key] = item.Value;
            }
            return d;
        }
    }
}
