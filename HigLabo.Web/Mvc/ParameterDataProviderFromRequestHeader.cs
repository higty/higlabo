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
            var d = context.Request.GetQueryNameValuePairs().ToDictionary(el => el.Key, el => el.Value);
            return d;
        }
    }
}
