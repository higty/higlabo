using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace HigLabo.Web.Mvc
{
    public class ParameterDataProviderFromRequestHeader : ParameterDataProvider
    {
        public override string Name
        {
            get { return "ParameterDataProviderFromRequestHeader"; }
        }
        public override Dictionary<String, String> GetDataSource(HttpActionContext context)
        {
            var d = context.Request.Headers.Where(el => el.Value.Any()).ToDictionary(el => el.Key, el => el.Value.FirstOrDefault());
            return d;
        }
    }
}
