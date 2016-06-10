using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Controllers;
using HigLabo.Core;

namespace HigLabo.Web.Mvc
{
    public class ParameterDataProviderFromQueryString : ParameterDataProvider
    {
        public override string Name
        {
            get { return "ParameterDataProviderFromQueryString"; }
        }
        public QueryStringConverter QueryStringConverter { get; private set; }

        public ParameterDataProviderFromQueryString()
        {
            this.QueryStringConverter = new QueryStringConverter();
        }

        public override Dictionary<string, string> GetDataSource(HttpActionContext context)
        {
            var d = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);
            var cv = this.QueryStringConverter;
            return cv.Parse(context.Request.RequestUri.Query);
        }
    }
}
